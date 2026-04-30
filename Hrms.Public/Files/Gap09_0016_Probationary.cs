using FileHelpers;
using Hrms.Public.Abstract;
using Hrms.Public.Converters;
using System;
using System.Runtime.InteropServices;

namespace Hrms.Public.Files
{
    /// <summary>Gap09 Contract Elements - Probationary Period</summary>
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class Gap09_0016_Probationary : Gap09Common, IFixedLengthFile
    {
        public const string RecordTypeDefault = "0016";
        public const int Total_Length = 77;

        /// <summary>Contract Type / Permanent Status</summary>
        [FieldOrder(12)]
        [FieldFixedLength(2)]
        [FieldSpec(2, 69, "Contract Type / Permanent Status")]
        public string PermanentStatus { get; set; }

        /// <summary>Probationary Period (number)</summary>
        [FieldOrder(13)]
        [FieldFixedLength(4)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 3, 0)]
        [FieldSpec(4, 71, "DEC(3,0) 3 whole numbers, no decimal positions, zero filled from the left, rightmost position reserved for sign ('-' for negative amount, ' ' for positive amount)")]
        public decimal ProbationaryPeriod { get; set; }

        /// <summary>Probationary Period (unit)</summary>
        [FieldOrder(14)]
        [FieldFixedLength(3)]
        [FieldSpec(3, 75, "Probationary Period (unit)")]
        public string ProbationaryPeriodUnit { get; set; }

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
