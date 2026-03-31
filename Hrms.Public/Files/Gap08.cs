using FileHelpers;
using Hrms.Public.Abstract;
using Microsoft.Extensions.FileProviders;
using System.Collections.Generic;
using System.IO;

namespace Hrms.Public.Files
{
    public class Gap08 : IReadFixedLengthFile, IWriteFixedLengthFile
    {
        public List<Gap08Header> Rows { get; set; } = new List<Gap08Header>();
        public Gap08()
        {
            Rows = Rows ?? new List<Gap08Header>();
        }

        public Gap08(IEnumerable<Gap08Header> rows)
        {
            Rows = new List<Gap08Header>(rows);
        }

        public int WriteFile(IFileInfo fileInfo)
        {
            int count = 0;
            using (var writer = new StreamWriter(fileInfo.PhysicalPath))
            {
                // Write header to stream
                var headers = new FileHelperEngine<Gap08Header>();
                headers.WriteStream(writer, Rows);
                count += headers.TotalRecords;
            }
            return count;
        }

        public int ReadFile(IFileInfo fileInfo)
        {
            using (var reader = new StreamReader(fileInfo.PhysicalPath))
            {
                return ReadFromStream(reader);
            }
        }

        public int ReadFromStream(TextReader reader)
        {
            var engine = new FixedFileEngine<Gap08Header>();
            var result = engine.ReadStream(reader);
            Rows.AddRange(result);
            return engine.TotalRecords;
        }
    }

}
