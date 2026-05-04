using FileHelpers;
using FileHelpers.MasterDetail;
using Hrms.Public.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Hrms.Public.Files
{

    [DebuggerStepThrough]
    public abstract class HeaderDetailBase<THeader, TDetail> : IReadWriteFile 
        where THeader : class, IFixedLengthFile
        where TDetail : class, IFixedLengthFile
    {
        public THeader Header { get; set; }
        public List<TDetail> Details { get; set; } = new List<TDetail>();
        public int TotalCount => Details.Count + (Header == null ? 0 : 1);

        public virtual int ReadFile(FileInfo fileInfo, FileInfo errorFile = null)
        {
            var engine = new MasterDetailEngine<THeader, TDetail>()
            {
                RecordSelector = RecordSelector,
                ErrorMode = ErrorMode.SaveAndContinue,
            };
            var result = engine.ReadFile(fileInfo.FullName);
            if (engine.ErrorManager.HasErrors && errorFile != null)
            {
                engine.ErrorManager.SaveErrors(errorFile.FullName);
            }

            int count = 0;
            foreach (var group in result)
            {
                if (group.Master != null)
                {
                    Header = Header ?? group.Master;
                    count++;
                }
                if (group.Details != null)
                {
                    Details.AddRange(group.Details);
                    count += group.Details.Length;
                }
            }
            return count;
        }

        public virtual int WriteFile(FileInfo fileInfo)
        {
            using (var writer = new StreamWriter(fileInfo.FullName, false))
            {
                return WriteStream(writer);
            }
        }

        public virtual int WriteStream(TextWriter writer)
        {
            int count = 0;
            // Write header to stream
            if (Header != null)
            {
                var headers = new FileHelperEngine<THeader>();
                headers.WriteStream(writer, new[] { Header });
                count += headers.TotalRecords;
            }

            // Write details to stream
            if (Details != null && Details.Count > 0)
            {
                var details = new FileHelperEngine<TDetail>();
                details.WriteStream(writer, Details);
                count += details.TotalRecords;
            }

            writer.Flush();
            return count;
        }

        public abstract RecordAction RecordSelector(string record);
    }

}
