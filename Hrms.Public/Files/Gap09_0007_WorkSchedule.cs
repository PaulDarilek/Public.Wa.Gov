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

        /// <summary>Work Schedule</summary>
        [StartPosition(69), FieldFixedLength(8), FieldOrder(12), FieldTrim(TrimMode.Right)]
        public string WorkSchedule;

        /// <summary>Time Mgt Status</summary>
        [StartPosition(77), FieldFixedLength(1), FieldOrder(13), FieldTrim(TrimMode.Right)]
        public string TimeMgtStatus;

        /// <summary>WorkingWeek</summary>
        /// <remarks>Working Week</remarks>
        [StartPosition(78), FieldFixedLength(2), FieldOrder(14), FieldTrim(TrimMode.Right)]
        public string WorkingWeek;

        /// <summary>Employee Percent</summary>
        /// <remarks>Usually '10000 '</remarks>
        /// <remarks>DEC(3,2) 3 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, rightmost position reserved for sign('-' for negative amount, ' ' for positive amount)</remarks>
        [StartPosition(80), FieldFixedLength(6), FieldOrder(15), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 3, 2)]
        public decimal FullTimePercent;

        /// <summary></summary>
        /// <remarks>DEC(3,2) 3 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, rightmost position reserved for sign('-' for negative amount, ' ' for positive amount)</remarks>
        [StartPosition(86), FieldFixedLength(6), FieldOrder(16), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 3, 2)]
        public decimal HoursWorkedDaily;

        /// <summary></summary>
        /// <remarks>DEC(3,2) 3 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, rightmost position reserved for sign('-' for negative amount, ' ' for positive amount)</remarks>
        [StartPosition(92), FieldFixedLength(6), FieldOrder(17), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 3, 2)]
        public decimal HoursWorkedWeekly;

        /// <summary></summary>
        /// <remarks>DEC(3,2) 3 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, rightmost position reserved for sign('-' for negative amount, ' ' for positive amount)</remarks>
        [StartPosition(98), FieldFixedLength(6), FieldOrder(18), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 3, 2)]
        public decimal HoursWorkedMonthly;

        /// <summary></summary>
        /// <remarks>DEC(5,2) 5 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, rightmost position reserved for sign('-' for negative amount, ' ' for positive amount)</remarks>
        [StartPosition(104), FieldFixedLength(8), FieldOrder(19), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 5, 2)]
        public decimal HoursWorkedYearly;

        /// <summary></summary>
        /// <remarks>DEC(2,2) 2 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, rightmost position reserved for sign('-' for negative amount, ' ' for positive amount)</remarks>
        [StartPosition(112), FieldFixedLength(5), FieldOrder(20), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 2, 2)]
        public decimal DaysWorkedWeekly;

        /// <summary>Part Time Indicator</summary>
        /// <remarks>(Space)' '=No, 'X'=Yes</remarks>
        /// <remarks>(Space)' '=No, 'X'=Yes</remarks>
        [StartPosition(117), FieldFixedLength(1), FieldOrder(21), FieldTrim(TrimMode.Right), FieldConverter(typeof(BoolConverter), "X", " ")]
        public bool? PartTimeIndicator;

        /// <summary>ACA Status Code</summary>
        /// <remarks>ACA Status Code (PA0007 ZACA_CODE)</remarks>
        [StartPosition(118), FieldFixedLength(2), FieldOrder(22)]
        public string AcaStatusCode;

        /// <summary>Time Type Override, Reporter Flag</summary>
        /// <remarks>Time Type Override, Reporter Flag (PA0007 ZTLA_TR_OV)</remarks>
        [StartPosition(120), FieldFixedLength(1), FieldOrder(23)]
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
