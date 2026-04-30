using FileHelpers;
using Hrms.Public.Abstract;
using System;

namespace Hrms.Public.Files
{
    /// <summary>Gap09 Record type 0001 (Organizational Assignment) - Map Employee to Position</summary>
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class Gap09_0001_OrgAssignment : Gap09Common, IFixedLengthFile
    {
        public const string RecordTypeDefault = "0001";
        public const int Total_Length = 271;

        /// <summary>Position Number</summary>
        [FieldOrder(12)]
        [FieldFixedLength(8)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(8, 69, "Position Number (assigned by SAP)")]
        public string PositionNumber;

        /// <summary>Position Code</summary>
        [FieldOrder(13)]
        [FieldFixedLength(12)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(12, 77, "Position Number (originally from PAY1)")]
        public string PositionCode;

        /// <summary>Position Title</summary>
        [FieldOrder(14)]
        [FieldFixedLength(40)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(40, 89, "Position Title")]
        public string PositionTitle;

        /// <summary>Job Class</summary>
        [FieldOrder(15)]
        [FieldFixedLength(8)]
        [FieldSpec(8, 129, "Job Key (assigned by SAP)")]
        public string JobClass;

        /// <summary>Job Class</summary>
        [FieldOrder(16)]
        [FieldFixedLength(8)]
        [FieldSpec(8, 137, "Job Class Code (originally from PAY1)")]
        public string JobClassCode;

        /// <summary>Job Title</summary>
        [FieldOrder(17)]
        [FieldFixedLength(40)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(40, 149, "Job Title")]
        public string JobTitle;

        /// <summary>Organization Unit</summary>
        [FieldOrder(18)]
        [FieldFixedLength(8)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(8, 189, "Org. Unit (assigned by SAP)")]
        public string OrganizationUnit;

        /// <summary>Organization Code</summary>
        [FieldOrder(19)]
        [FieldFixedLength(12)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(12, 197, "Organization Code CHAR (12) HRP1000 SHORT Org Code originally (from PAY1)")]
        public string OrganizationCode;

        /// <summary>Organization Title</summary>
        [FieldOrder(20)]
        [FieldFixedLength(40)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(40, 209, "Organization Title")]
        public string OrganizationTitle;

        /// <summary>Time Administrator (Attendance Unit)</summary>
        [FieldOrder(21)]
        [FieldFixedLength(3)]
        [FieldSpec(3, 249, "Time Administrator / Attendance Unit (originally from PAY1)")]
        public string TimeAdministrator;

        /// <summary>Time Administrator (Attendance Unit)</summary>
        [FieldOrder(22)]
        [FieldFixedLength(2)]
        [FieldSpec(2, 252, "Employee Group and Work Contract Type = Appointment Status")]
        public string WorkContractType;

        /// <summary>Organization Code</summary>
        [FieldOrder(23)]
        [FieldFixedLength(14)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(14, 254, "Appointment Org Unit code")]
        public string OrganizationKey;

        /// <summary>Business Area</summary>
        [FieldOrder(24)]
        [FieldFixedLength(4)]
        [FieldSpec(4, 268, "Business Area Code")]
        public string BusinessAreaCode;

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
