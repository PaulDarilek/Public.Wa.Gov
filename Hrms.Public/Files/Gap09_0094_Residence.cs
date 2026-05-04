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

        /// <summary>Residence Status</summary>
        /// <remarks>Citizen, Non-Citizen, etc</remarks>
        [FieldOrder(12)]
        [FieldFixedLength(1)]
        [FieldSpec(1, 69)]
        public string ResidenceStatus { get; set; }

        /// <summary>Identification type text</summary>
        [FieldOrder(13)]
        [FieldFixedLength(30)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(30, 70)]
        public string IdentificationType { get; set; }

        /// <summary>Issue Authority</summary>
        [FieldOrder(14)]
        [FieldFixedLength(30)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(30, 100)]
        public string IssueAuthority { get; set; }

        /// <summary>Document Number</summary>
        [FieldOrder(15)]
        [FieldFixedLength(20)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(20, 130)]
        public string DocumentNumber { get; set; }

        /// <summary>Date of issue for personal ID</summary>
        [FieldOrder(16)]
        [FieldFixedLength(8)]
        [FieldConverter(typeof(DateWithZeroConverter))]
        [FieldSpec(8, 150)]
        public DateTime? PersonalIdIssueDate { get; set; }

        /// <summary>Personal ID Expiration Date</summary>
        [FieldOrder(17)]
        [FieldFixedLength(8)]
        [FieldConverter(typeof(DateWithZeroConverter))]
        [FieldSpec(8, 158)]
        public DateTime? PersonalIdExpirationDate { get; set; }

        /// <summary>Type Of Work Permit</summary>
        [FieldOrder(18)]
        [FieldFixedLength(2)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(2, 166)]
        public string WorkPermitType { get; set; }

        /// <summary>Issue Authority</summary>
        [FieldOrder(19)]
        [FieldFixedLength(30)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(30, 168)]
        public string WorkPermitIssueAuthority { get; set; }

        /// <summary>Issue Authority</summary>
        [FieldOrder(20)]
        [FieldFixedLength(20)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(20, 198)]
        public string WorkPermitNumber { get; set; }

        /// <summary>Work Permit Issue Date</summary>
        [FieldOrder(21)]
        [FieldFixedLength(8)]
        [FieldConverter(typeof(DateWithZeroConverter))]
        [FieldSpec(8, 218)]
        public DateTime? WorkPermitIssueDate { get; set; }

        /// <summary>Work Permit Expiration Date</summary>
        [FieldOrder(22)]
        [FieldFixedLength(8)]
        [FieldConverter(typeof(DateWithZeroConverter))]
        [FieldSpec(8, 226)]
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
