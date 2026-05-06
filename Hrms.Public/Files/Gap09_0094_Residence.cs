using FileHelpers;
using Hrms.Public.Converters;
using Hrms.Public.Interfaces;
using System;

namespace Hrms.Public.Files
{
    /// <summary>Gap09 Record type 0094 (Residence Status)</summary>
    [FixedLengthRecord(FixedMode.ExactLength)]
    public class Gap09_0094_Residence : IGap09Common, IFixedLengthFile
    {
        public const string RecordTypeDefault = "0094";
        public const int Total_Length = 233;

        #region IGap09Common

        /// <summary>Personnel Area</summary>
        /// <remarks>Agency/Sub equivalent</remarks>
        [StartPosition(1), FieldFixedLength(4), FieldOrder(1)]
        public string PersonnelArea { get; set; }

        /// <summary>Personnel Sub Area (Bargaining Unit equivalent)</summary>
        [StartPosition(5), FieldFixedLength(4), FieldOrder(2)]
        public string PersonnelSubArea { get; set; }

        /// <summary>Employee Group (Permanent, Temporary, etc)</summary>
        [StartPosition(9), FieldFixedLength(1), FieldOrder(3)]
        public string EmployeeGroup { get; set; }

        /// <summary>Employee Sub Group (Monthly, Hourly, etc.)</summary>
        [StartPosition(10), FieldFixedLength(2), FieldOrder(4)]
        public string EmployeeSubGroup { get; set; }

        /// <summary>Personnel Number / Employee Number</summary>
        /// <remarks>PA0001 PERNR Personnel Number</remarks>
        [StartPosition(12), FieldFixedLength(8), FieldOrder(5)]
        public string PersonnelNumber { get; set; }

        /// <summary>Social Security Number</summary>
        /// <remarks>PA0002 PERID Social Security Number</remarks>
        [StartPosition(20), FieldFixedLength(9), FieldOrder(6)]
        public string SSN { get; set; }

        /// <summary>Date of last change</summary>
        /// <remarks>YYYYMMDD PA0000 AEDTM Date of Last Change</remarks>
        [StartPosition(29), FieldFixedLength(8), FieldOrder(7), FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime DateChanged { get; set; }

        /// <summary>Name of person who changed object</summary>
        /// <remarks>PA0000 UNAME Name of person who changed object</remarks>
        [StartPosition(37), FieldFixedLength(12), FieldOrder(8), FieldTrim(TrimMode.Right)]
        public string PersonChanged { get; set; }

        /// <summary>Record Type</summary>
        /// <remarks>Record Type identifies the Gap09 subtype</remarks>
        [StartPosition(49), FieldFixedLength(4), FieldOrder(9)]
        public string RecordType { get; set; }

        /// <summary>CCYYMMDD Start Date</summary>
        /// <remarks>CCYYMMDD DATS(8) PA0000 BEGDA Start date</remarks>
        [StartPosition(53), FieldFixedLength(8), FieldOrder(10), FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime DateEffective { get; set; }

        /// <summary>End Date</summary>
        /// <remarks>CCYYMMDD PA0000 ENDDA End Date</remarks>
        [StartPosition(61), FieldFixedLength(8), FieldOrder(11), FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime EndDate { get; set; }

        #endregion

        /// <summary>Residence Status</summary>
        /// <remarks>Citizen, Non-Citizen, etc</remarks>
        [StartPosition(69), FieldFixedLength(1), FieldOrder(12)]
        public string ResidenceStatus { get; set; }

        /// <summary>Identification type text</summary>
        [StartPosition(70), FieldFixedLength(30), FieldOrder(13), FieldTrim(TrimMode.Right)]
        public string IdentificationType { get; set; }

        /// <summary>Issue Authority</summary>
        [StartPosition(100), FieldFixedLength(30), FieldOrder(14), FieldTrim(TrimMode.Right)]
        public string IssueAuthority { get; set; }

        /// <summary>Document Number</summary>
        [StartPosition(130), FieldFixedLength(20), FieldOrder(15), FieldTrim(TrimMode.Right)]
        public string DocumentNumber { get; set; }

        /// <summary>Date of issue for personal ID</summary>
        [StartPosition(150), FieldFixedLength(8), FieldOrder(16), FieldConverter(typeof(DateWithZeroConverter))]
        public DateTime? PersonalIdIssueDate { get; set; }

        /// <summary>Personal ID Expiration Date</summary>
        [StartPosition(158), FieldFixedLength(8), FieldOrder(17), FieldConverter(typeof(DateWithZeroConverter))]
        public DateTime? PersonalIdExpirationDate { get; set; }

        /// <summary>Type Of Work Permit</summary>
        [StartPosition(166), FieldFixedLength(2), FieldOrder(18), FieldTrim(TrimMode.Right)]
        public string WorkPermitType { get; set; }

        /// <summary>Issue Authority</summary>
        [StartPosition(168), FieldFixedLength(30), FieldOrder(19), FieldTrim(TrimMode.Right)]
        public string WorkPermitIssueAuthority { get; set; }

        /// <summary>Issue Authority</summary>
        [StartPosition(198), FieldFixedLength(20), FieldOrder(20), FieldTrim(TrimMode.Right)]
        public string WorkPermitNumber { get; set; }

        /// <summary>Work Permit Issue Date</summary>
        [StartPosition(218), FieldFixedLength(8), FieldOrder(21), FieldConverter(typeof(DateWithZeroConverter))]
        public DateTime? WorkPermitIssueDate { get; set; }

        /// <summary>Work Permit Expiration Date</summary>
        [StartPosition(226), FieldFixedLength(8), FieldOrder(22), FieldConverter(typeof(DateWithZeroConverter))]
        public DateTime? WorkPermitExpirationDate { get; set; }

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
