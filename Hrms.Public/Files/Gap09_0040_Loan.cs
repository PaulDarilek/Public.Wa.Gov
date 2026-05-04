using FileHelpers;
using Hrms.Public.Converters;
using Hrms.Public.Interfaces;
using System;

namespace Hrms.Public.Files
{
    /// <summary>Gap09 Record type 0040 (Objects on Loan) - Used for tracking (i.e. WSP Badge #) - Multiple records permissible</summary>
    [FixedLengthRecord(FixedMode.ExactLength)]
    public class Gap09_0040_Loan : IGap09Common, IFixedLengthFile
    {
        public const string RecordTypeDefault = "0040";
        public const int Total_Length = 100;

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

        /// <summary>Object on Loan (Code)</summary>
        [FieldOrder(12)]
        [FieldFixedLength(4)]
        [FieldSpec(4, 69, "Object on Loan")]
        public string ObjectOnLoan { get; set; }

        /// <summary>Number of Objects on Loan</summary>
        [FieldOrder(13)]
        [FieldFixedLength(5)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 4, 0)]
        [FieldSpec(5, 73, "DEC(4,0) Number of Objects on Loan")]
        public decimal ObjectCount { get; set; }

        /// <summary>Measuring Unit</summary>
        [FieldOrder(14)]
        [FieldFixedLength(3)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(3, 78, "Measuring Unit")]
        public string MeasuringUnit { get; set; }

        /// <summary>Loan object number</summary>
        [FieldOrder(15)]
        [FieldFixedLength(20)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(20, 81, "Loan object number")]
        public string LoanObjectNumber { get; set; }

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
