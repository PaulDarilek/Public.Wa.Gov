using FileHelpers;
using Hrms.Public.Abstract;
using Hrms.Public.Converters;
using System;

namespace Hrms.Public.Files
{
    /// <summary>Record type 0008 Basic Pay</summary>
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class Gap09_0008_BasicPay : Gap09Common, IFixedLengthFile
    {
        public const string RecordTypeDefault = "0008";
        public const int Total_Length = 365;

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
