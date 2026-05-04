using Hrms.Public.Converters;
using Hrms.Public.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace Hrms.Public.Files
{
    /// <summary>Gap 8 (Leave Summary)</summary>
    /// <remarks>
    /// Only "Header" Records.
    /// <see cref="https://support.hrms.wa.gov/sites/default/files/public/resources/interfaces/GAP8-Map.pdf"/>
    /// </remarks>
    public class Gap08 : IReadWriteFile
    {
        /// <summary>Data</summary>
        public List<Gap08LeaveSummary> Rows { get; set; } = new List<Gap08LeaveSummary>();
        public int TotalCount => Rows.Count;    

        /// <summary>Constructor</summary>
        public Gap08()
        {
            Rows = Rows ?? new List<Gap08LeaveSummary>();
        }

        public Gap08(IEnumerable<Gap08LeaveSummary> rows)
        {
            Rows = new List<Gap08LeaveSummary>(rows);
        }

        public int ReadFile(FileInfo fileInfo, FileInfo errorFile = null)
        {
            Rows = fileInfo.ReadData<Gap08LeaveSummary>();
            return Rows.Count;
        }

        public int WriteFile(FileInfo fileInfo) => fileInfo.WriteData(Rows);

    }

}
