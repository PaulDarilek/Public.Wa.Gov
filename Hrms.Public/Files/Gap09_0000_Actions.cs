using FileHelpers;
using Hrms.Public.Abstract;
using System;

namespace Hrms.Public.Files
{
    /// <summary>Gap09 Record Type "0000" Actions</summary>
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class Gap09_0000_Actions : Gap09Common, IFixedLengthFile
    {
        public const string RecordTypeDefault = "0000";
        public const int Total_Length = 73;

        /// <summary>Action Type</summary>
        [FieldOrder(12)]
        [FieldFixedLength(2)]
        [FieldSpec(2, 69, "Reason code for the Action Type ")]
        public string ActionType { get; set; }

        /// <summary>Employment Status (Active, Inactive, Retiree, etc)</summary>
        [FieldOrder(13)]
        [FieldFixedLength(1)]
        [FieldSpec(1, 73, "Employment Status (Active, Inactive, Retiree, etc)")]
        public string EmploymentStatus { get; set; }

        public int GetRecordLength() => Total_Length;

        public bool IsPossibleRecord(string record)
        {
            return
                !string.IsNullOrEmpty(record) &&
                record.Length >= Total_Length &&
                record.Substring(48, 4) == RecordTypeDefault; //48 zero based, 49 one based in Gap9-Map.pdf
        }
    }
}
