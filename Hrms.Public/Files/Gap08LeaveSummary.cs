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
        /// <remarks>Personnel Area (Agency/Sub equivalent)</remarks>
        [StartPosition(1), FieldFixedLength(4)]
        public string PersonnelArea { get; set; }

        /// <remarks>Personnel Sub Area (Bargaining Unit equivalent)</remarks>
        [StartPosition(5), FieldFixedLength(4)]
        public string PersonnelSubArea { get; set; }

        /// <remarks>Employee Group (Permanent, Temporary, etc)</remarks>
        [StartPosition(9), FieldFixedLength(1)]
        public string EmployeeGroup { get; set; }

        /// <remarks>Employee Sub Group (Monthly, Hourly, etc.)</remarks>
        [StartPosition(10), FieldFixedLength(2)]
        public string EmployeeSubGroup { get; set; }

        /// <remarks>NUMC(8) Organizational Unit (SAP assigned)</remarks>
        [StartPosition(12), FieldFixedLength(8)]
        public string OrgUnit { get; set; }

        /// <remarks>CHAR(12) Org Code (Cost Center equivalent)</remarks>
        [StartPosition(20), FieldFixedLength(12)]
        public string OrgCode { get; set; }

        /// <remarks>CHAR(40) Org Title (Department Name)</remarks>
        [StartPosition(32), FieldFixedLength(40)]
        public string OrgTitle { get; set; }

        /// <remarks>DATS(8) YYYYMMDD Date Leave Effective</remarks>
        [StartPosition(72), FieldFixedLength(8), FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime EffectiveDate { get; set; }

        /// <remarks>NUMC(8) Employee Number / Personnel Number</remarks>
        [StartPosition(80), FieldFixedLength(8)]
        public string PersonnelNumber { get; set; }

        ///// <remarks>NUMC(9) SSN - can send this or Employee number/Personnel number</remarks>
        [StartPosition(88), FieldFixedLength(9)]
        public string SSN { get; set; }

        /// <remarks>CHAR(30) Employee Name</remarks>
        [StartPosition(97), FieldFixedLength(30)]
        public string EmployeeName { get; set; }

        /// <remarks>DEC (15,2) Implied decimal point, trailing and leading zeros, single character at the end (' ' if positive, '-' if negative)</remarks>
        [StartPosition(127), FieldFixedLength(18), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 15, 2)]
        public decimal Salary { get; set; }

        /// <remarks>NUMC(8) Position Number (Assigned by SAP)</remarks>
        [StartPosition(145), FieldFixedLength(8), FieldConverter(typeof(IntConverter), 8, false)]
        public int Position { get; set; }

        /// <remarks>Char(12) Position Number (from PAY1 Conversion)</remarks>
        [StartPosition(153), FieldFixedLength(12)]
        public string PositionCode { get; set; }

        /// <remarks>Char(40) Position Title</remarks>
        [StartPosition(165), FieldFixedLength(40), FieldTrim(TrimMode.Right)]
        public string PositionTitle { get; set; }

        /// <remarks>NUMC(8) Job Key (assigned by SAP)</remarks>
        [StartPosition(205), FieldFixedLength(8), FieldConverter(typeof(IntConverter), 8, false)]
        public int Job { get; set; }

        /// <remarks>Char(12) Job Class Code (from PAY1 Conversion)</remarks>
        [StartPosition(213), FieldFixedLength(12)]
        public string JobClassCode { get; set; }

        /// <remarks>Char(40) Job Title</remarks>
        [StartPosition(225), FieldFixedLength(40)]
        public string JobTitle { get; set; }

        /// <remarks>Char(2) Leave Quota Type (code identifying Sick, Annual, Personal Holiday, etc.)</remarks>
        [StartPosition(265), FieldFixedLength(2)]
        public string LeaveType { get; set; }

        /// <remarks>DATS(8) YYYYMMDD First day of period for current leave accrual process</remarks>
        [StartPosition(267), FieldFixedLength(8), FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime BeginDate { get; set; }

        /// <remarks>DATS(8) YYYYMMDD Last day of period for current leave accrual process</remarks>
        [StartPosition(275), FieldFixedLength(8), FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime EndDate { get; set; }

        /// <remarks>DEC (10,5) Implied decimal point, trailing and leading zeros, single character at the end (' ' if positive, '-' if negative)</remarks>
        [StartPosition(283), FieldFixedLength(16), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 5)]
        public decimal BeginingBalance { get; set; }

        /// <remarks>DEC (10,5) Implied decimal point, trailing and leading zeros, single character at the end (' ' if positive, '-' if negative)</remarks>
        [StartPosition(299), FieldFixedLength(16), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 5)]
        public decimal LeaveEarned { get; set; }

        /// <remarks>DEC (10,5) Implied decimal point, trailing and leading zeros, single character at the end (' ' if positive, '-' if negative)</remarks>
        [StartPosition(315), FieldFixedLength(16), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 5)]
        public decimal LeaveTaken { get; set; }

        /// <remarks>DEC (10,5) Implied decimal point, trailing and leading zeros, single character at the end (' ' if positive, '-' if negative)</remarks>
        [StartPosition(331), FieldFixedLength(16), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 5)]
        public decimal LeavePaid { get; set; }

        /// <remarks>DEC (10,5) Implied decimal point, trailing and leading zeros, single character at the end (' ' if positive, '-' if negative)</remarks>
        [StartPosition(347), FieldFixedLength(16), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 5)]
        public decimal LeaveAdjustment { get; set; }

        /// <remarks>DEC (10,5) Implied decimal point, trailing and leading zeros, single character at the end (' ' if positive, '-' if negative)</remarks>
        [StartPosition(363), FieldFixedLength(16), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 5)]
        public decimal LeaveDonated { get; set; }

        /// <remarks>DEC (10,5) Implied decimal point, trailing and leading zeros, single character at the end (' ' if positive, '-' if negative)</remarks>
        [StartPosition(379), FieldFixedLength(16), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 5)]
        public decimal LeaveReturned { get; set; }

        /// <remarks>DEC (10,5) Implied decimal point, trailing and leading zeros, single character at the end (' ' if positive, '-' if negative)</remarks>
        [StartPosition(395), FieldFixedLength(16), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 5)]
        public decimal LeaveReceived { get; set; }

        /// <remarks>DEC (10,5) Implied decimal point, trailing and leading zeros, single character at the end (' ' if positive, '-' if negative)</remarks>
        [StartPosition(411), FieldFixedLength(16), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 5)]
        public decimal EndingBalance { get; set; }

        [FieldFixedLength(1), FieldOptional]
        public string Undefined { get; set; } = " ";

        public const int Total_Length = 426;

        public int GetRecordLength() => Total_Length;

        public bool IsPossibleRecord(string record) => !string.IsNullOrEmpty(record) && (record.Length == Total_Length || record.Length == Total_Length + 1);
    }

}
