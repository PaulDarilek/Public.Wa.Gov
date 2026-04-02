using Hrms.Public.Abstract;
using System.Collections.Generic;
using System.IO;

namespace Hrms.Public.Files
{
    public class Gap08 : IReadWriteFile
    {
        /// <summary>Data</summary>
        public List<Gap08Header> Rows { get; set; } = new List<Gap08Header>();

        /// <summary>Constructor</summary>
        public Gap08()
        {
            Rows = Rows ?? new List<Gap08Header>();
        }

        public Gap08(IEnumerable<Gap08Header> rows)
        {
            Rows = new List<Gap08Header>(rows);
        }

        public int ReadFile(FileInfo fileInfo)
        {
            Rows = fileInfo.ReadData<Gap08Header>();
            return Rows.Count;
        }

        public int WriteFile(FileInfo fileInfo) => fileInfo.WriteData(Rows);

    }

}
