using FileHelpers;
using Hrms.Public.Converters;
using Hrms.Public.Interfaces;

namespace Hrms.Public.Files
{
    /// <summary>Gap 11 (Payroll Details)</summary>
    /// <remarks><see cref="https://support.hrms.wa.gov/sites/default/files/public/resources/interfaces/GAP11-Map.pdf"/></remarks>
    [FixedLengthRecord(FixedMode.ExactLength)]
    public class Gap11PayrollDetails : IFixedLengthFile
    {
        public const int Total_Length = 417;
        public const int Undefined_Length = 9;

        /// <summary>Agency/Sub Agency</summary>
        [StartPosition(1), FieldFixedLength(4)]
        public string Agency { get; set; }

        /// <summary>Personnel Sub Area (Bargaining Unit equivalent</summary>
        [StartPosition(5), FieldFixedLength(4)]
        public string BargainingUnit { get; set; }

        /// <summary>Employee Group (Permanent, Temporary, etc.)</summary>
        [StartPosition(9), FieldFixedLength(1)]
        public string EmployeeGroup { get; set; }

        /// <summary>Employee Sub Group</summary>
        [StartPosition(10), FieldFixedLength(2)]
        public string EmployeeSubGroup { get; set; }

        /// <summary>Payroll Area</summary>
        [StartPosition(12), FieldFixedLength(2)]
        public string PayrollArea { get; set; }

        /// <summary>Organizational Unit (SAP assigned)</summary>
        /// <remarks>NUMC(8)</remarks>
        [StartPosition(14), FieldFixedLength(8)]
        public string OrgUnit { get; set; }

        /// <summary>Organizational Code</summary>
        /// <remarks>Char(12) from PAY1 conversion</remarks>
        [StartPosition(22), FieldFixedLength(12)]
        public string OrgCode { get; set; }

        /// <summary>Organizational Title</summary>
        /// <remarks>Char(40)</remarks>
        [StartPosition(34), FieldFixedLength(40)]
        public string OrgTitle { get; set; }

        /// <summary>Pay Date</summary>
        /// <remarks>Char(8) (is this a date?)</remarks>
        [StartPosition(74), FieldFixedLength(8)]
        public string PayDate { get; set; }

        /// <summary>Warrant Register Number</summary>
        /// <remarks>Char(5) First Character = "P", Characters 2-3 = Payroll Period Year, Characters 4-5 = Payroll Period</remarks>
        [StartPosition(82), FieldFixedLength(5)]
        public string WarrantRegisterNumber { get; set; }

        /// <summary>Warrant EFT Number</summary>
        /// <remarks>Char(7)</remarks>
        [StartPosition(87), FieldFixedLength(7)]
        public string WarrantEftNumber { get; set; }

        /// <summary>Personnel Number / Employee Number</summary>
        /// <remarks>NUMC(8)</remarks>
        [StartPosition(94), FieldFixedLength(8)]
        public string PersonnelNumber { get; set; }

        /// <summary>Social Security Number</summary>
        /// <remarks>PA0002 PERID Social Security Number</remarks>
        [StartPosition(102), FieldFixedLength(9)]
        public string SSN { get; set; }

        /// <summary>Employee Name</summary>
        /// <remarks></remarks>
        [StartPosition(111), FieldFixedLength(30), FieldTrim(TrimMode.Right)]
        public string EmployeeName { get; set; }

        /// <summary>Employee Status</summary>
        /// <remarks>NUMC(1)</remarks>
        [StartPosition(141), FieldFixedLength(1)]
        public string EmployeeStatus { get; set; }

        /// <summary>Salary</summary>
        /// <remarks>DEC(13,2) 13 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, rightmost position reserved for sign ('-' for negative amount, ' ' for positive amount)</remarks>
        [StartPosition(142), FieldFixedLength(16), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 13, 2)]
        public decimal Salary { get; set; }

        /// <summary>Position Number</summary>
        /// <remarks>NUMC(8)</remarks>
        [StartPosition(158), FieldFixedLength(8)]
        public string PositionNumber { get; set; }

        /// <summary>Position Code</summary>
        /// <remarks>CHAR(12)</remarks>
        [StartPosition(166), FieldFixedLength(12)]
        public string PositionCode { get; set; }

        /// <summary>Position Title</summary>
        /// <remarks></remarks>
        [StartPosition(178), FieldFixedLength(40), FieldTrim(TrimMode.Right)]
        public string PositionTitle { get; set; }

        /// <summary>Job Class</summary>
        /// <remarks>NUMC(8)</remarks>
        [StartPosition(218), FieldFixedLength(8)]
        public string JobClass { get; set; }

        /// <summary>Job Class Code</summary>
        /// <remarks>CHAR(12)</remarks>
        [StartPosition(226), FieldFixedLength(12), FieldTrim(TrimMode.Right)]
        public string JobClassCode { get; set; }

        /// <summary>Job Title</summary>
        [StartPosition(238), FieldFixedLength(40), FieldTrim(TrimMode.Right)]
        public string JobTitle { get; set; }

        /// <summary>Pay & Deduct Codes</summary>
        /// <remarks>Wage Type</remarks>
        [StartPosition(278), FieldFixedLength(4), FieldTrim(TrimMode.Right)]
        public string PayAndDeductCodes { get; set; }

        /// <summary>Pay & Deduct Text</summary>
        /// <remarks>Wage Type Text</remarks>
        [StartPosition(282), FieldFixedLength(8), FieldTrim(TrimMode.Right)]
        public string PayAndDeductText { get; set; }

        /// <summary>Current Hours</summary>
        /// <remarks>DEC(13,2) 13 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, rightmost position reserved for sign ('-' for negative amount, ' ' for positive amount)</remarks>
        [StartPosition(290), FieldFixedLength(16), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 13, 2)]
        public decimal CurrentHours { get; set; }

        /// <summary>Current Amount</summary>
        /// <remarks>DEC(13,2) 13 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, rightmost position reserved for sign ('-' for negative amount, ' ' for positive amount)</remarks>
        [StartPosition(306), FieldFixedLength(16), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 13, 2)]
        public decimal CurrentAmount { get; set; }

        /// <summary>Monthly Hours</summary>
        /// <remarks>DEC(13,2) 13 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, rightmost position reserved for sign ('-' for negative amount, ' ' for positive amount)</remarks>
        [StartPosition(322), FieldFixedLength(16), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 13, 2)]
        public decimal MonthlyHours { get; set; }

        /// <summary>Monthly Amount</summary>
        /// <remarks>DEC(13,2) 13 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, rightmost position reserved for sign ('-' for negative amount, ' ' for positive amount)</remarks>
        [StartPosition(338), FieldFixedLength(16), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 13, 2)]
        public decimal MonthlyAmount { get; set; }

        /// <summary>Quarterly Hours</summary>
        /// <remarks>DEC(13,2) 13 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, rightmost position reserved for sign ('-' for negative amount, ' ' for positive amount)</remarks>
        [StartPosition(354), FieldFixedLength(16), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 13, 2)]
        public decimal QuarterlyHours { get; set; }

        /// <summary>Quarterly Amount</summary>
        /// <remarks>DEC(13,2) 13 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, rightmost position reserved for sign ('-' for negative amount, ' ' for positive amount)</remarks>
        [StartPosition(370), FieldFixedLength(16), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 13, 2)]
        public decimal QuarterlyAmount { get; set; }

        /// <summary>YTD Hours</summary>
        /// <remarks>DEC(13,2) 13 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, rightmost position reserved for sign ('-' for negative amount, ' ' for positive amount)</remarks>
        [StartPosition(386), FieldFixedLength(16), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 13, 2)]
        public decimal YTDHours { get; set; }

        /// <summary>YTD Amount</summary>
        /// <remarks>DEC(13,2) 13 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, rightmost position reserved for sign ('-' for negative amount, ' ' for positive amount)</remarks>
        [StartPosition(402), FieldFixedLength(16), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 13, 2)]
        public decimal YTDAmount { get; set; }

        /// <summary>Undefined Column (present on input file)</summary>
        /// <remarks>do not use</remarks>
        [StartPosition(418), FieldFixedLength(Undefined_Length)] //"99019500 "
        [FieldOptional, FieldTrim(TrimMode.Right)]
        public string Undefined { get; set; }

        public int GetRecordLength() => Total_Length + Undefined_Length;

        public bool IsPossibleRecord(string record) => !string.IsNullOrEmpty(record) && (record.Length == Total_Length || record.Length == Total_Length + Undefined_Length);
    }

}
