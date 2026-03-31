using FileHelpers.MasterDetail;
using Hrms.Public.Abstract;
using System.Collections.Generic;
using System.Diagnostics;

namespace Hrms.Public.Files
{
    public class Gap01 : HeaderDetailFile<Gap01Header, Gap01Detail>
    {
        public Gap01()
        {
            Details = Details ?? new List<Gap01Detail>();
        }

        public Gap01(IEnumerable<Gap01Detail> details)
        {
            Details = new List<Gap01Detail>(details);
            Header = new Gap01Header(details);
        }

        protected override RecordAction Selector(string record)
        {
            if (string.IsNullOrEmpty(record) || record.Length < 2)
            {
                return RecordAction.Skip;
            }
            string recordType = record.Substring(0, 2);
            if (recordType == "00")
            {
                Debug.Assert(record.Length == Gap01Header.Total_Length || record.Length == Gap01Header.Total_Length -1, $"Record length {record.Length} does not match expected header lengths.");
                return RecordAction.Master;
            }
            else if (recordType == "01")
            {
                Debug.Assert(record.Length == Gap01Detail.Total_Length, $"Record length {record.Length} does not match expected header lengths.");
                return RecordAction.Detail;
            }
            else
            {
                return RecordAction.Skip;
            }
        }


    }
}
