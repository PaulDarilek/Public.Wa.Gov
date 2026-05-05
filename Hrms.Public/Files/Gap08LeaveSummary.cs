using FileHelpers;
using Hrms.Public.Converters;
using Hrms.Public.Interfaces;
using System;

namespace Hrms.Public.Files
{

    /// <summary>Gap 8 (Leave Summary)</summary>
    /// <remarks>
    /// Only "Header" Records.
    /// <see cref="https://support.hrms.wa.gov/sites/default/files/public/resources/interfaces/GAP8-Map.pdf"/>
    /// </remarks>
    [FixedLengthRecord(FixedMode.ExactLength)]
    public class Gap08LeaveSummary : IFixedLengthFile
    {
        [FieldFixedLength(4)]
        [StartPosition(1, "Personnel Area (Agency/Sub equivalent)")]
        public string PersonnelArea { get; set; }

        [FieldFixedLength(4)]
        [StartPosition(5, "Personnel Sub Area (Bargaining Unit equivalent)")]
        public string PersonnelSubArea { get; set; }

        [FieldFixedLength(1)]
        [StartPosition(9, "Employee Group (Permanent, Temporary, etc)")]
        public string EmployeeGroup { get; set; }

        [FieldFixedLength(2)]
        [StartPosition(10, "Employee Sub Group (Monthly, Hourly, etc.)")]
        public string EmployeeSubGroup { get; set; }

        [FieldFixedLength(8)]
        [StartPosition(12, "NUMC(8) Organizational Unit (SAP assigned)")]
        public string OrgUnit { get; set; }

        [FieldFixedLength(12)]
        [StartPosition(20, "CHAR(12) Org Code (Cost Center equivalent)")]
        public string OrgCode { get; set; }

        [FieldFixedLength(40)]
        [StartPosition(32, "CHAR(40) Org Title (Department Name)")]
        public string OrgTitle { get; set; }

        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        [StartPosition(72, "DATS(8) YYYYMMDD Date Leave Effective")]
        public DateTime EffectiveDate { get; set; }

        [FieldFixedLength(8)]
        [StartPosition(80, "NUMC(8) Employee Number / Personnel Number")]
        public string PersonnelNumber { get; set; }

        [FieldFixedLength(9)]
        //[FieldValueDiscarded]
        [StartPosition(88, "NUMC(9) SSN - can send this or Employee number/Personnel number")]
        public string SSN { get; set; }

        [FieldFixedLength(30)]
        [StartPosition(97, "CHAR(30) Employee Name")]
        public string EmployeeName { get; set; }

        [FieldFixedLength(18)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 15, 2)]
        [StartPosition(127, "DEC (15,2) Implied decimal point, trailing and leading zeros, single character at the end (' ' if positive, '-' if negative)")]
        public decimal Salary { get; set; }

        [FieldFixedLength(8)]
        [StartPosition(145, "NUMC(8) Position Number (Assigned by SAP)")]
        [FieldConverter(typeof(IntConverter), 8, false)]
        public int Position { get; set; }

        [FieldFixedLength(12)]
        [StartPosition(153, "Char(12) Position Number (from PAY1 Conversion)")]
        public string PositionCode { get; set; }

        [FieldFixedLength(40)]
        [FieldTrim(TrimMode.Right)]
        [StartPosition(165, "Char(40) Position Title")]
        public string PositionTitle { get; set; }

        [FieldFixedLength(8)]
        [FieldConverter(typeof(IntConverter), 8, false)]
        [StartPosition(205, "NUMC(8) Job Key (assigned by SAP)")]
        public int Job { get; set; }

        [FieldFixedLength(12)]
        [StartPosition(213, "Char(12) Job Class Code (from PAY1 Conversion)")]
        public string JobClassCode { get; set; }

        [FieldFixedLength(40)]
        [StartPosition(225, "Char(40) Job Title")]
        public string JobTitle { get; set; }

        [FieldFixedLength(2)]
        [StartPosition(265, "Char(2) Leave Quota Type (code identifying Sick, Annual, Personal Holiday, etc.)")]
        public string LeaveType { get; set; }

        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        [StartPosition(267, "DATS(8) YYYYMMDD First day of period for current leave accrual process")]
        public DateTime BeginDate { get; set; }

        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        [StartPosition(275, "DATS(8) YYYYMMDD Last day of period for current leave accrual process")]
        public DateTime EndDate { get; set; }

        [FieldFixedLength(16)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 5)]
        [StartPosition(283, "DEC (10,5) Implied decimal point, trailing and leading zeros, single character at the end (' ' if positive, '-' if negative)")]
        public decimal BeginingBalance { get; set; }

        [FieldFixedLength(16)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 5)]
        [StartPosition(299, "DEC (10,5) Implied decimal point, trailing and leading zeros, single character at the end (' ' if positive, '-' if negative)")]
        public decimal LeaveEarned { get; set; }

        [FieldFixedLength(16)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 5)]
        [StartPosition(315, "DEC (10,5) Implied decimal point, trailing and leading zeros, single character at the end (' ' if positive, '-' if negative)")]
        public decimal LeaveTaken { get; set; }

        [FieldFixedLength(16)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 5)]
        [StartPosition(331, "DEC (10,5) Implied decimal point, trailing and leading zeros, single character at the end (' ' if positive, '-' if negative)")]
        public decimal LeavePaid { get; set; }

        [FieldFixedLength(16)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 5)]
        [StartPosition(347, "DEC (10,5) Implied decimal point, trailing and leading zeros, single character at the end (' ' if positive, '-' if negative)")]
        public decimal LeaveAdjustment { get; set; }

        [FieldFixedLength(16)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 5)]
        [StartPosition(363, "DEC (10,5) Implied decimal point, trailing and leading zeros, single character at the end (' ' if positive, '-' if negative)")]
        public decimal LeaveDonated { get; set; }

        [FieldFixedLength(16)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 5)]
        [StartPosition(379, "DEC (10,5) Implied decimal point, trailing and leading zeros, single character at the end (' ' if positive, '-' if negative)")]
        public decimal LeaveReturned { get; set; }

        [FieldFixedLength(16)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 5)]
        [StartPosition(395, "DEC (10,5) Implied decimal point, trailing and leading zeros, single character at the end (' ' if positive, '-' if negative)")]
        public decimal LeaveReceived { get; set; }

        [FieldFixedLength(16)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 5)]
        [StartPosition(411, "DEC (10,5) Implied decimal point, trailing and leading zeros, single character at the end (' ' if positive, '-' if negative)")]
        public decimal EndingBalance { get; set; }

        [FieldFixedLength(1)]
        [FieldOptional]
        public string Undefined { get; set; } = " ";

        public const int Total_Length = 426;

        public int GetRecordLength() => Total_Length;

        public bool IsPossibleRecord(string record) => !string.IsNullOrEmpty(record) && (record.Length == Total_Length || record.Length == Total_Length + 1);
    }

}
