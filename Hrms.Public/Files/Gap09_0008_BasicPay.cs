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

        /// <summary>Pay Scale Reason for Change</summary>
        [FieldOrder(12)]
        [FieldFixedLength(2)]
        [StartPosition(69, "Pay Scale Reason for Change")]
        public string PayScaleReason { get; set; }

        /// <summary>Pay Scale Type</summary>
        [FieldOrder(13)]
        [FieldFixedLength(2)]
        [StartPosition(71, "Pay Scale Type")]
        public string PayScaleType { get; set; }

        /// <summary>Pay Scale Area</summary>
        [FieldOrder(14)]
        [FieldFixedLength(2)]
        [StartPosition(73, "Pay Scale Area")]
        public string PayScaleArea { get; set; }

        /// <summary>Pay Scale Group</summary>
        [FieldOrder(15)]
        [FieldFixedLength(8)]
        [StartPosition(75, "Pay Scale Group")]
        public string PayScaleGroup { get; set; }

        /// <summary>Pay Scale Level</summary>
        [FieldOrder(16)]
        [FieldFixedLength(2)]
        [StartPosition(83, "Pay Scale Level")]
        public string PayScaleLevel { get; set; }

        /// <summary>Annual Salary</summary>
        [FieldOrder(17)]
        [FieldFixedLength(13)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 2)]
        [StartPosition(85, "DEC 10.2 10 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, rightmost position reserved for sign ('-' for negative amount, ' ' for positive amount)")]
        public decimal AnnualSalary { get; set; }

        /// <summary>Salary Component (Pay Code)</summary>
        [FieldOrder(18)]
        [FieldArrayLength(20), FieldFixedLength(Gap09_BasicPayAddition.Total_Length)]
        [FieldConverter(typeof(BasicPayAdditionConverter))]
        [StartPosition(98, "Array of 20 BasicPayAddition")]
        public Gap09_BasicPayAddition[] BasicPayAdditions { get; set; } = new Gap09_BasicPayAddition[20];

        /// <summary>Date of Next Increase</summary>
        [FieldOrder(19)]
        [FieldFixedLength(8)]
        [FieldConverter(typeof(DateWithZeroConverter))]
        [StartPosition(358, "YYYYMMDD PA0000 AEDTM Date of Last Change")]
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
