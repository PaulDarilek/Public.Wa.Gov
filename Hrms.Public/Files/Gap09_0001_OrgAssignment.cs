using FileHelpers;
using Hrms.Public.Converters;
using Hrms.Public.Interfaces;
using System;

namespace Hrms.Public.Files
{
    /// <summary>Gap09 Record type 0001 (Organizational Assignment) - Map Employee to Position</summary>
    [FixedLengthRecord(FixedMode.ExactLength)]
    public class Gap09_0001_OrgAssignment : IGap09Common, IFixedLengthFile
    {
        public const string RecordTypeDefault = "0001";
        public const int Total_Length = 271;

        #region IGap09Common

        /// <summary>Personnel Area (Agency/Sub equivalent)</summary>
        [FieldOrder(1)]
        [FieldFixedLength(4)]
        [FieldSpec(4, 1, "Personnel Area (Agency/Sub equivalent)")]
        public string PersonnelArea { get; set; }

        /// <summary>Personnel Sub Area (Bargaining Unit equivalent)</summary>
        [FieldOrder(2)]
        [FieldFixedLength(4)]
        [FieldSpec(4, 5, "Personnel Sub Area (Bargaining Unit equivalent)")]
        public string PersonnelSubArea { get; set; }

        /// <summary>Employee Group (Permanent, Temporary, etc)</summary>
        [FieldOrder(3)]
        [FieldFixedLength(1)]
        [FieldSpec(1, 9, "Employee Group (Permanent, Temporary, etc)")]
        public string EmployeeGroup { get; set; }

        /// <summary>Employee Sub Group (Monthly, Hourly, etc.)</summary>
        [FieldOrder(4)]
        [FieldFixedLength(2)]
        [FieldSpec(2, 10, "Employee Sub Group (Monthly, Hourly, etc.)")]
        public string EmployeeSubGroup { get; set; }

        /// <summary>Personnel Number / Employee Number</summary>
        [FieldOrder(5)]
        [FieldFixedLength(8)]
        [FieldSpec(8, 12, "PA0001 PERNR Personnel Number")]
        public string PersonnelNumber { get; set; }

        /// <summary>Social Security Number</summary>
        [FieldOrder(6)]
        [FieldFixedLength(9)]
        [FieldSpec(9, 20, "PA0002 PERID Social Security Number")]
        public string SSN { get; set; }

        /// <summary>Date of last change</summary>
        [FieldOrder(7)]
        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        [FieldSpec(8, 29, "YYYYMMDD PA0000 AEDTM Date of Last Change")]
        public DateTime DateChanged { get; set; }

        /// <summary>Name of person who changed object</summary>
        [FieldOrder(8)]
        [FieldFixedLength(12)]
        [FieldSpec(12, 37, "PA0000 UNAME Name of person who changed object")]
        [FieldTrim(TrimMode.Right)]
        public string PersonChanged { get; set; }

        /// <summary>Record Type</summary>
        [FieldOrder(9)]
        [FieldFixedLength(4)]
        [FieldSpec(4, 49, "Record Type identifies the Gap09 subtype")]
        public string RecordType { get; set; }

        /// <summary>CCYYMMDD Start Date</summary>
        [FieldOrder(10)]
        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        [FieldSpec(8, 53, "CCYYMMDD DATS(8) PA0000 BEGDA Start date")]
        public DateTime DateEffective { get; set; }

        /// <summary>End Date</summary>
        [FieldOrder(11)]
        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        [FieldSpec(8, 61, "CCYYMMDD PA0000 ENDDA End Date")]
        public DateTime EndDate { get; set; }

        #endregion

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
        [FieldFixedLength(12)]
        [FieldSpec(12, 137, "Job Class Code (originally from PAY1)")]
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
