using FileHelpers;
using Hrms.Public.Converters;
using Hrms.Public.Interfaces;
using System;

namespace Hrms.Public.Files
{
    /// <summary>Gap09 Record type 0007 (Planned Working Time) - Employee Work Schedule</summary>
    [FixedLengthRecord(FixedMode.ExactLength)]
    public class Gap09_0007_WorkSchedule : IGap09Common, IFixedLengthFile
    {
        public const string RecordTypeDefault = "0007";
        public const int Total_Length = 120;

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

        /// <summary>Work Schedule</summary>
        [FieldOrder(12)]
        [FieldFixedLength(8)]
        [FieldTrim(TrimMode.Right)]
        [StartPosition(69, "Work Schedule")]
        public string WorkSchedule;

        /// <summary>Time Mgt Status</summary>
        [FieldOrder(13)]
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Right)]
        [StartPosition(77, "Time Mgt Status")]
        public string TimeMgtStatus;

        /// <summary>WorkingWeek</summary>
        [FieldOrder(14)]
        [FieldFixedLength(2)]
        [FieldTrim(TrimMode.Right)]
        [StartPosition(78, "Working Week")]
        public string WorkingWeek;

        /// <summary>Employee Percent</summary>
        /// <remarks>Usually '10000 '</remarks>
        [FieldOrder(15)]
        [FieldFixedLength(6)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 3, 2)]
        [StartPosition(80, "DEC(3,2) 3 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, rightmost position reserved for sign('-' for negative amount, ' ' for positive amount)")]
        public decimal FullTimePercent;

        /// <summary></summary>
        [FieldOrder(16)]
        [FieldFixedLength(6)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 3, 2)]
        [StartPosition(86, "DEC(3,2) 3 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, rightmost position reserved for sign('-' for negative amount, ' ' for positive amount)")]
        public decimal HoursWorkedDaily;

        /// <summary></summary>
        [FieldOrder(17)]
        [FieldFixedLength(6)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 3, 2)]
        [StartPosition(92, "DEC(3,2) 3 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, rightmost position reserved for sign('-' for negative amount, ' ' for positive amount)")]
        public decimal HoursWorkedWeekly;

        /// <summary></summary>
        [FieldOrder(18)]
        [FieldFixedLength(6)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 3, 2)]
        [StartPosition(98, "DEC(3,2) 3 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, rightmost position reserved for sign('-' for negative amount, ' ' for positive amount)")]
        public decimal HoursWorkedMonthly;

        /// <summary></summary>
        [FieldOrder(19)]
        [FieldFixedLength(8)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 5, 2)]
        [StartPosition(104, "DEC(5,2) 5 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, rightmost position reserved for sign('-' for negative amount, ' ' for positive amount)")]
        public decimal HoursWorkedYearly;

        /// <summary></summary>
        [FieldOrder(20)]
        [FieldFixedLength(5)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 2, 2)]
        [StartPosition(112, "DEC(2,2) 2 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, rightmost position reserved for sign('-' for negative amount, ' ' for positive amount)")]
        public decimal DaysWorkedWeekly;

        /// <summary>Part Time Indicator</summary>
        /// <remarks>(Space)' '=No, 'X'=Yes</remarks>
        [FieldOrder(21)]
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Right)]
        [StartPosition(117, "(Space)' '=No, 'X'=Yes")]
        [FieldConverter(typeof(BoolConverter), "X", " ")]
        public bool? PartTimeIndicator;

        /// <summary>ACA Status Code</summary>
        [FieldOrder(22)]
        [FieldFixedLength(2)]
        [StartPosition(118, "ACA Status Code (PA0007 ZACA_CODE)")]
        public string AcaStatusCode;

        /// <summary>Time Type Override, Reporter Flag</summary>
        [FieldOrder(23)]
        [FieldFixedLength(1)]
        [StartPosition(120, "Time Type Override, Reporter Flag (PA0007 ZTLA_TR_OV)")]
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
