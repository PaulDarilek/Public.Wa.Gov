using FileHelpers;
using Hrms.Public.Converters;
using Hrms.Public.Interfaces;
using System;

namespace Hrms.Public.Files
{
    /// <summary>Gap09 Record type 0077 (Additional Personal Data)</summary>
    [FixedLengthRecord(FixedMode.ExactLength)]
    public class Gap09_0077_AdditionalData : IGap09Common, IFixedLengthFile
    {
        public const string RecordTypeDefault = "0077";
        public const int Total_Length = 137;

        #region IGap09Common

        /// <summary>Personnel Area</summary>
        /// <remarks>Agency/Sub equivalent</remarks>
        [FieldOrder(1)]
        [StartPosition(1)]
        [FieldFixedLength(4)]
        public string PersonnelArea { get; set; }

        /// <summary>Personnel Sub Area (Bargaining Unit equivalent)</summary>
        [FieldOrder(2)]
        [StartPosition(5)]
        [FieldFixedLength(4)]
        public string PersonnelSubArea { get; set; }

        /// <summary>Employee Group (Permanent, Temporary, etc)</summary>
        [FieldOrder(3)]
        [StartPosition(9)]
        [FieldFixedLength(1)]
        public string EmployeeGroup { get; set; }

        /// <summary>Employee Sub Group (Monthly, Hourly, etc.)</summary>
        [FieldOrder(4)]
        [StartPosition(10)]
        [FieldFixedLength(2)]
        public string EmployeeSubGroup { get; set; }

        /// <summary>Personnel Number / Employee Number</summary>
        /// <remarks>PA0001 PERNR Personnel Number</remarks>
        [FieldOrder(5)]
        [StartPosition(12)]
        [FieldFixedLength(8)]
        public string PersonnelNumber { get; set; }

        /// <summary>Social Security Number</summary>
        /// <remarks>PA0002 PERID Social Security Number</remarks>
        [FieldOrder(6)]
        [StartPosition(20)]
        [FieldFixedLength(9)]
        public string SSN { get; set; }

        /// <summary>Date of last change</summary>
        /// <remarks>YYYYMMDD PA0000 AEDTM Date of Last Change</remarks>
        [FieldOrder(7)]
        [StartPosition(29)]
        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime DateChanged { get; set; }

        /// <summary>Name of person who changed object</summary>
        /// <remarks>PA0000 UNAME Name of person who changed object</remarks>
        [FieldOrder(8)]
        [StartPosition(37)]
        [FieldFixedLength(12)]
        [FieldTrim(TrimMode.Right)]
        public string PersonChanged { get; set; }

        /// <summary>Record Type</summary>
        /// <remarks>Record Type identifies the Gap09 subtype</remarks>
        [FieldOrder(9)]
        [StartPosition(49)]
        [FieldFixedLength(4)]
        public string RecordType { get; set; }

        /// <summary>CCYYMMDD Start Date</summary>
        /// <remarks>CCYYMMDD DATS(8) PA0000 BEGDA Start date</remarks>
        [FieldOrder(10)]
        [StartPosition(53)]
        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime DateEffective { get; set; }

        /// <summary>End Date</summary>
        /// <remarks>CCYYMMDD PA0000 ENDDA End Date</remarks>
        [FieldOrder(11)]
        [StartPosition(61)]
        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime EndDate { get; set; }

        #endregion

        /// <summary>Ethnic code</summary>
        [FieldOrder(12)]
        [FieldFixedLength(2)]
        [StartPosition(69)]
        public string EthnicCode { get; set; }

        /// <summary>Hispanic</summary>
        [FieldOrder(13)]
        [FieldFixedLength(2)]
        [StartPosition(71)]
        public string Hispanic { get; set; }

        /// <summary>Racial Category (Array of 10)</summary>
        [FieldOrder(14)]
        [FieldArrayLength(10), FieldFixedLength(2)]
        [StartPosition(73, "(Array of 10 two char codes)")]
        public string[] RacialCategory { get; set; }

        /// <summary>Military Status</summary>
        [FieldOrder(15)]
        [FieldFixedLength(2)]
        [StartPosition(93)]
        public string MilitaryStatus { get; set; }

        /// <summary>EEO Exempt indicator</summary>
        [FieldOrder(16)]
        [FieldFixedLength(1)]
        [StartPosition(95)]
        public string EeoExemptIndicator { get; set; }

        /// <summary>Disability</summary>
        [FieldOrder(17)]
        [FieldFixedLength(1)]
        [StartPosition(96)]
        public string Disability { get; set; }

        /// <summary>Date of Determination of Disability</summary>
        [FieldOrder(18)]
        [FieldFixedLength(8)]
        [FieldConverter(typeof(DateWithZeroConverter))]
        [StartPosition(97)]
        public DateTime? DisabilityDeterminationDate { get; set; }

        /// <summary>Date Employer Learned of Disability</summary>
        [FieldOrder(19)]
        [FieldFixedLength(8)]
        [StartPosition(105)]
        public string DisabilityEmployerNotificationDate { get; set; }

        /// <summary>Veteran status</summary>
        [FieldOrder(20)]
        [FieldFixedLength(1)]
        [StartPosition(113, "VETST")]
        public string VeteranStatus { get; set; }

        /// <summary>Veteran status #1 - #12</summary>
        [FieldOrder(21)]
        [FieldArrayLength(12), FieldFixedLength(2)]
        //[FieldTrim(TrimMode.Right)]
        [StartPosition(114, "Veteran status #1 - #12 (Array of 12 two char codes)")]
        public string[] VeteranStatusCodes { get; set; }

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
