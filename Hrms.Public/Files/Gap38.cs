using FileHelpers.MasterDetail;
using Hrms.Public.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace Hrms.Public.Files
{
    public class Gap38 : HeaderDetailBase<Gap38Header, Gap38Detail>, IReadWriteFile
    {
        /// <summary>Default Constructor</summary>
        public Gap38()
        {
        }

        /// <summary>Default Constructor</summary>
        public Gap38(IEnumerable<Gap38Detail> details)
        {
            Details = new List<Gap38Detail>(details);
            Header = new Gap38Header(details);
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
                Debug.Assert(record.Length == Gap01Header.Total_Length || record.Length == Gap01Header.Total_Length - 1, $"Record length {record.Length} does not match expected header lengths.");
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
