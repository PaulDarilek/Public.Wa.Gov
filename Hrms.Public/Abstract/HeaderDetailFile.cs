using FileHelpers;
using FileHelpers.MasterDetail;
using Microsoft.Extensions.FileProviders;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Hrms.Public.Abstract
{

    [DebuggerStepThrough]
    public abstract class HeaderDetailFile<THeader, TDetail> : IReadFixedLengthFile, IWriteFixedLengthFile
        where THeader : class, IFixedLengthFile
        where TDetail : class, IFixedLengthFile
    {
        public THeader Header { get; set; } 
        public List<TDetail> Details { get; set; } = new List<TDetail>();
        
        public virtual int WriteFile(IFileInfo fileInfo)
        {
            int count = 0;
            using (var writer = new StreamWriter(fileInfo.PhysicalPath))
            {
                // Write header to stream
                var headers = new FileHelperEngine<THeader>();
                headers.WriteStream(writer, new[] { Header });
                count += headers.TotalRecords;

                // Write details to stream
                var details = new FileHelperEngine<TDetail>();
                details.WriteStream(writer, Details);
                count += details.TotalRecords;
            }
            return count;
        }

        public virtual int ReadFile(IFileInfo fileInfo)
        {
            using (var reader = new StreamReader(fileInfo.PhysicalPath))
            {
                return ReadFromStream(reader);
            }
        }
        public virtual int ReadFromStream(TextReader reader)
        {
            var engine = new MasterDetailEngine<THeader, TDetail>(Selector);
            var result = engine.ReadStream(reader);
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

        protected abstract RecordAction Selector(string record);
    }

}
