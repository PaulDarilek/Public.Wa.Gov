using FileHelpers;
using Hrms.Public.Converters;

namespace Hrms.Public.Files
{
    public class Gap10CostDistributions
    {
        public const string RecordTypeDefault = "1000";
        public const int Total_Length = 714;

        /// <summary>Agency/Sub Agency</summary>
        [StartPosition(1)]
        [FieldFixedLength(4)]
        public string Agency { get; set; }

        /// <summary>Position Id</summary>
        [StartPosition(5)]
        [FieldFixedLength(8)]
        public string PositionId { get; set; }

        /// <summary>Position Title (Legacy)</summary>
        [StartPosition(13)]
        [FieldFixedLength(12)]
        public string PositionLegacyTitle { get; set; }

        /// <summary>Position Title</summary>
        [StartPosition(25)]
        [FieldFixedLength(40)]
        public string PositionTitle { get; set; }

        /// <summary>Record Type</summary>
        [StartPosition(65)]
        [FieldFixedLength(4)]
        public string RecordType { get; set; }

        public int GetRecordLength() => Total_Length;

        public bool IsPossibleRecord(string record)
        {
            return !string.IsNullOrEmpty(record) && record.Length == Total_Length && record.Substring(64, 4) == RecordTypeDefault;
        }

    }

}
