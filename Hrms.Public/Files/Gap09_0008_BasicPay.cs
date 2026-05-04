using FileHelpers;
using Hrms.Public.Converters;
using Hrms.Public.Interfaces;
using System;

namespace Hrms.Public.Files
{
    /// <summary>Record type 0008 Basic Pay</summary>
    [FixedLengthRecord(FixedMode.ExactLength)]
    public class Gap09_0008_BasicPay : IGap09Common, IFixedLengthFile
    {
        public const string RecordTypeDefault = "0008";
        public const int Total_Length = 365;

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

        /// <summary>Pay Scale Reason for Change</summary>
        [FieldOrder(12)]
        [FieldFixedLength(2)]
        [FieldSpec(2, 69, "Pay Scale Reason for Change")]
        public string PayScaleReason { get; set; }

        /// <summary>Pay Scale Type</summary>
        [FieldOrder(13)]
        [FieldFixedLength(2)]
        [FieldSpec(2, 71, "Pay Scale Type")]
        public string PayScaleType { get; set; }

        /// <summary>Pay Scale Area</summary>
        [FieldOrder(14)]
        [FieldFixedLength(2)]
        [FieldSpec(2, 73, "Pay Scale Area")]
        public string PayScaleArea { get; set; }

        /// <summary>Pay Scale Group</summary>
        [FieldOrder(15)]
        [FieldFixedLength(8)]
        [FieldSpec(8, 75, "Pay Scale Group")]
        public string PayScaleGroup { get; set; }

        /// <summary>Pay Scale Level</summary>
        [FieldOrder(16)]
        [FieldFixedLength(2)]
        [FieldSpec(2, 83, "Pay Scale Level")]
        public string PayScaleLevel { get; set; }

        /// <summary>Annual Salary</summary>
        [FieldOrder(17)]
        [FieldFixedLength(13)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 2)]
        [FieldSpec(13, 85, "DEC 10.2 10 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, rightmost position reserved for sign ('-' for negative amount, ' ' for positive amount)")]
        public decimal AnnualSalary { get; set; }

        /// <summary>Salary Component (Pay Code)</summary>
        [FieldOrder(18)]
        [FieldArrayLength(20), FieldFixedLength(Gap09_BasicPayAddition.Total_Length)]
        [FieldConverter(typeof(BasicPayAdditionConverter))]
        [FieldSpec(Gap09_BasicPayAddition.Total_Length * 20, 98, "Array of 20 BasicPayAddition")]
        public Gap09_BasicPayAddition[] BasicPayAdditions { get; set; } = new Gap09_BasicPayAddition[20];

        /// <summary>Date of Next Increase</summary>
        [FieldOrder(19)]
        [FieldFixedLength(8)]
        [FieldConverter(typeof(DateWithZeroConverter))]
        [FieldSpec(8, 358, "YYYYMMDD PA0000 AEDTM Date of Last Change")]
        public DateTime? DateOfNextIncrease { get; set; }

        /// <summary>Constructor</summary>
        public Gap09_0008_BasicPay()
        {
            BasicPayAdditions = BasicPayAdditions ?? new Gap09_BasicPayAddition[20];
        }

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
