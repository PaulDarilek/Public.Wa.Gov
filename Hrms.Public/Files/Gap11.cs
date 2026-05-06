using Hrms.Public.Converters;
using Hrms.Public.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace Hrms.Public.Files
{
    /// <summary>Gap 11 (Payroll Details)</summary>
    /// <remarks>
    /// Only "Header" Records.
    /// <see cref="https://support.hrms.wa.gov/sites/default/files/public/resources/interfaces/GAP11-Map.pdf"/>
    /// </remarks>
    public class Gap11 : IReadWriteFile
    {
        /// <summary>Data</summary>
        public List<Gap11PayrollDetails> Rows { get; set; }
        public int RecordCount => Rows.Count;

        /// <summary>Constructor</summary>
        public Gap11()
        {
            Rows = Rows ?? new List<Gap11PayrollDetails>();
        }

        public Gap11(IEnumerable<Gap11PayrollDetails> rows)
        {
            Rows = new List<Gap11PayrollDetails>(rows);
        }

        public int ReadFile(FileInfo fileInfo, FileInfo errorFile = null)
        {
            Rows = fileInfo.ReadAsList<Gap11PayrollDetails>();
            return Rows.Count;
        }

        public int WriteFile(FileInfo fileInfo) => fileInfo.WriteData(Rows);

    }

}
