using FileHelpers;
using Hrms.Public.Abstract;
using Hrms.Public.Converters;
using System;

namespace Hrms.Public.Files
{
    /// <summary>Gap09 Record type 0007 (Planned Working Time) - Employee Work Schedule</summary>
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class Gap09_0007_WorkSchedule : Gap09Common, IFixedLengthFile
    {
        public const string RecordTypeDefault = "0007";
        public const int Total_Length = 120;

        /// <summary>Work Schedule</summary>
        [FieldOrder(12)]
        [FieldFixedLength(8)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(8, 69, "Work Schedule")]
        public string WorkSchedule;

        /// <summary>Time Mgt Status</summary>
        [FieldOrder(13)]
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(1, 77, "Time Mgt Status")]
        public char TimeMgtStatus;

        /// <summary>WorkingWeek</summary>
        [FieldOrder(14)]
        [FieldFixedLength(2)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(1, 77, "Working Week")]
        public string WorkingWeek;

        /// <summary>Employee Percent</summary>
        /// <remarks>Usually '10000 '</remarks>
        [FieldOrder(15)]
        [FieldFixedLength(6)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 3, 2)]
        [FieldSpec(6, 80, "DEC(3,2) 3 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, rightmost position reserved for sign('-' for negative amount, ' ' for positive amount)")]
        public decimal FullTimePercent;

        /// <summary></summary>
        [FieldOrder(16)]
        [FieldFixedLength(6)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 3, 2)]
        [FieldSpec(6, 86, "DEC(3,2) 3 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, rightmost position reserved for sign('-' for negative amount, ' ' for positive amount)")]
        public decimal HoursWorkedDaily;

        /// <summary></summary>
        [FieldOrder(17)]
        [FieldFixedLength(6)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 3, 2)]
        [FieldSpec(6, 92, "DEC(3,2) 3 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, rightmost position reserved for sign('-' for negative amount, ' ' for positive amount)")]
        public decimal HoursWorkedWeekly;

        /// <summary></summary>
        [FieldOrder(18)]
        [FieldFixedLength(6)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 3, 2)]
        [FieldSpec(6, 98, "DEC(3,2) 3 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, rightmost position reserved for sign('-' for negative amount, ' ' for positive amount)")]
        public decimal HoursWorkedMonthly;

        /// <summary></summary>
        [FieldOrder(19)]
        [FieldFixedLength(8)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 3, 2)]
        [FieldSpec(8, 104, "DEC(5,2) 5 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, rightmost position reserved for sign('-' for negative amount, ' ' for positive amount)")]
        public decimal HoursWorkedYearly;

        /// <summary></summary>
        [FieldOrder(20)]
        [FieldFixedLength(5)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 3, 2)]
        [FieldSpec(5, 112, "DEC(2,2) 2 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, rightmost position reserved for sign('-' for negative amount, ' ' for positive amount)")]
        public decimal DaysWorkedWeekly;

        /// <summary>Part Time Indicator</summary>
        /// <remarks>(Space)' '=No, 'X'=Yes</remarks>
        [FieldOrder(21)]
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(1, 117, "(Space)' '=No, 'X'=Yes")]
        public string PartTimeIndicator;

        /// <summary>ACA Status Code</summary>
        [FieldOrder(22)]
        [FieldFixedLength(2)]
        [FieldSpec(2, 118, "ACA Status Code (PA0007 ZACA_CODE)")]
        public string AcaStatusCode;

        /// <summary>Time Type Override, Reporter Flag</summary>
        [FieldOrder(23)]
        [FieldFixedLength(1)]
        [FieldSpec(1, 120, "Time Type Override, Reporter Flag (PA0007 ZTLA_TR_OV)")]
        public string TimeTypeOverride;

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
