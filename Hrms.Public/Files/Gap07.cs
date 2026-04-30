using FileHelpers.MasterDetail;
using Hrms.Public.Abstract;
using System.Collections.Generic;
using System.Diagnostics;

namespace Hrms.Public.Files
{
    /// <summary>GAP7 Payroll Accounting Details</summary>
    /// <remarks><see cref="https://support.hrms.wa.gov/sites/default/files/public/resources/interfaces/GAP7-Map.pdf"/> </remarks>
    public class Gap07 : HeaderDetailBase<Gap07Header, Gap07Detail>, IReadWriteFile
    {
        public Gap07()
        {
            Details = Details ?? new List<Gap07Detail>();
        }

        public Gap07(IEnumerable<Gap07Detail> details)
        {
            Details = new List<Gap07Detail>(details);
            Header = new Gap07Header(details);
        }

        public override RecordAction RecordSelector(string record)
        {
            if (string.IsNullOrEmpty(record) || record.Length < 2)
            {
                return RecordAction.Skip;
            }
            string recordType = record.Substring(0, 2);
            if (recordType == "00")
            {
                Debug.Assert(record.Length == Gap07Header.Total_Length || record.Length == Gap07Header.Trimmed_Length || record.Length == Gap07Header.Trimmed_Length - 1, $"Record length {record.Length} does not match expected header lengths.");
                return RecordAction.Master;
            }
            else if (recordType == "01")
            {
                Debug.Assert(record.Length == Gap07Detail.Total_Length, $"Record length {record.Length} does not match expected header lengths.");
                return RecordAction.Detail;
            }
            else
            {
                return RecordAction.Skip;
            }
        }

    }
}
