using FileHelpers;
using Hrms.Public.Converters;
using Hrms.Public.Interfaces;
using System;

namespace Hrms.Public.Files
{

    /// <summary>Gap 7 Map (Payroll Accounting Details)</summary>
    /// <remarks><see cref="https://support.hrms.wa.gov/sites/default/files/public/resources/interfaces/GAP7-Map.pdf"/></remarks>
    [FixedLengthRecord()]
    public class Gap07Detail : IFixedLengthFile
    {
        [FieldFixedLength(2)]
        [StartPosition(1, "Constant '01'")]
        public string RecordType { get; set; } //00 = Header, 01=Detail

        [FieldFixedLength(4)]
        [StartPosition(3, "Personnel Area (Agency/Sub equivalent)")]
        public string Agency { get; set; }

        [FieldFixedLength(4)]
        [StartPosition(7, "Personnel Sub Area (Bargaining Unit equivalent)")]
        public string BargainingUnit { get; set; }

        [FieldFixedLength(1)]
        [StartPosition(11, "Employee Group (Permanent, Temporary, etc)")]
        public string EmployeeGroup { get; set; }

        [FieldFixedLength(2)]
        [StartPosition(12, "Employee Sub Group (Monthly, Hourly, etc.)")]
        public string EmployeeSubGroup { get; set; }

        [FieldFixedLength(2)]
        [StartPosition(14, "Payroll Area (Pay Cycle)")]
        public string PayrollArea { get; set; }

        [FieldFixedLength(8)]
        [StartPosition(16, "Org Unit (Department)")]
        public string OrgUnit { get; set; }

        [FieldFixedLength(12)]
        [StartPosition(24, "Org Code (Cost Center equivalent)")]
        public string OrgCode { get; set; }

        [FieldFixedLength(40)]
        [StartPosition(36, "Org Title (Department Name)")]
        public string OrgTitle { get; set; }

        [FieldFixedLength(5)]
        [StartPosition(76, "(SAP) Function Module")]
        public string WarrantRegisterNumber { get; set; }

        [FieldFixedLength(7)]
        [StartPosition(81, "Warrant/EFT Number (Sap: truncate from 13 to 7 characters, See Extension FIEXT001)")]
        public string WarrantEftNumber { get; set; }

        [FieldFixedLength(1)]
        [StartPosition(88, "Warrant Cancellation Indicator 'C'")]
        public string WarrantCancellationIndicator { get; set; }

        /// <summary>PersonnelNumber</summary>
        [FieldFixedLength(8)]
        [StartPosition(89, "Employee number/Personnel number")]
        public string EmployeeNumber { get; set; }

        [FieldFixedLength(9)]
        //[FieldValueDiscarded]
        [StartPosition(97, "Employee Socical Security Number")]
        public string SSN { get; set; }

        [FieldFixedLength(30)]
        [StartPosition(106, "Employee Name")]
        public string EmployeeName { get; set; }

        [FieldFixedLength(1)]
        [StartPosition(136, "Employee Status (Active/Terminated) 'A' or 'T'")]
        public string EmployeeStatus { get; set; }

        [FieldFixedLength(16)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 13, 2)]
        [StartPosition(137, "DEC(13,2) 5 digits with implied decimal point (13 left, 2 right) plus low order sign or blank")]
        public decimal Salary { get; set; }

        [FieldFixedLength(2)]
        [StartPosition(153, "Salary Range (Pay Scale Area)")]
        public string SalaryRange { get; set; }

        [FieldFixedLength(8)]
        [StartPosition(155, "Char(8) Salary Step (Pay Scale Group)")]
        public string SalaryStep { get; set; }

        [FieldFixedLength(2)]
        [StartPosition(163, "Salary Level (Pay Scale Level)")]
        public string SalaryLevel { get; set; }

        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        [StartPosition(165, "DATS(8) CCYYMMDD Pay date (warrant and/or ACH date)")]
        public DateTime PayDate { get; set; }

        [FieldFixedLength(8)]
        [StartPosition(173, "NUMC(8) Position Number")]
        public string Position { get; set; }

        [FieldFixedLength(12)]
        [StartPosition(181, "CHAR(12) Position Code")]
        public string PositionCode { get; set; }

        [FieldFixedLength(40)]
        [StartPosition(193, "CHAR(40) Position Title")]
        public string PositionTitle { get; set; }

        [FieldFixedLength(8)]
        [StartPosition(233, "NUMC(8) Job Key")]
        public string JobClass { get; set; }

        [FieldFixedLength(12)]
        [StartPosition(241, "CHAR(12) Job Class Code (From PAY1 Conversion)")]
        public string JobClassCode { get; set; }

        /// <summary>JobTitle / Class Title</summary>
        [FieldFixedLength(40)]
        [StartPosition(253, "CHAR(40) (Class Title) Job Title")]
        public string JobTitle { get; set; }

        /// <summary>Pay & ded codes</summary>
        [FieldFixedLength(4)]
        [StartPosition(293, "CHAR(4) Pay & ded codes")]
        public string WageType { get; set; }

        /// <summary>Pay & ded codes</summary>
        [FieldFixedLength(8)]
        [StartPosition(297, "CHAR(8) Pay & ded text (short description)")]
        public string WageTypeText { get; set; }

        [FieldFixedLength(5)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 2, 2)]
        [StartPosition(305, "NUMC(5) 5 digits with implied decimal point (2 left, 2 right), last position within the field is the signed character (blank for positive '-' for negative)")]
        public decimal FTE { get; set; }

        [FieldFixedLength(13)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 2)]
        [StartPosition(310, "NUMC(13) 13 digits with implied decimal point (10 left, 2 right), last position within the field is the signed character (blank for positive '-' for negative)")]
        public decimal CurrentHours { get; set; }

        [FieldFixedLength(13)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 2)]
        [StartPosition(323, "NUMC(13) 13 digits with implied decimal point (10 left, 2 right), last position within the field is the signed character (blank for positive '-' for negative)")]
        public decimal CurrentAmount { get; set; }

        /// <summary>AFRS Agency</summary>
        [FieldFixedLength(4)]
        [StartPosition(336, "Char(4) Equiv. to AFRS Agency")]
        public string BusinessArea { get; set; }

        /// <summary>
        /// AFRS Agency + Prog Index
        /// a.Chars 1-3 Three char AFRS Agency code
        /// b.Chars 4-8 Five char AFRS Program index
        /// c.Chars 9-16 Not Used Zero fill
        /// </summary>
        [FieldFixedLength(16)]
        [StartPosition(340, "Char(16) Equiv. to AFRS Agency + Prog Index")]
        public string FunctionalArea { get; set; }

        /// <summary>
        /// AFRS Agency + Master Index
        /// a. Chars 1-3 Three char AFRS Agency code
        /// b.Chars 4-11 Eight char AFRS Master Index code
        /// c.Chars 12-12 Not Used Zero fill
        /// </summary>
        [FieldFixedLength(12)]
        [StartPosition(356, "Char(12) Equiv. to AFRS Agency + Master Index")]
        public string CostObject { get; set; }

        /// <summary>
        /// AFRS Agency + Fund + Appr Index
        /// a. Chars 1-3 Three char AFRS Agency code
        /// b.Chars 4-6 Three char AFRS Fund
        /// c.Chars 7-9 Three char AFRS Appropriation Index code
        /// d. Chars 10-10 Not Used Zero fill
        /// </summary>
        [FieldFixedLength(10)]
        [StartPosition(368, "Char(10) Equiv. to AFRS Agency + Fund + Appr Index")]
        public string Fund { get; set; }

        /// <summary>
        /// AFRS Agency + Org Index
        /// a. Chars 1-3 Three char AFRS Agency code
        /// b.Chars 4-7 Four char AFRS Organization Index
        /// c.Chars 8-10 Not Used Zero fill
        /// </summary>
        [FieldFixedLength(10)]
        [StartPosition(378, "Char(10) Equiv. to AFRS Agency + Org Index")]
        public string CostCenter { get; set; }

        /// <summary>
        /// AFRS Agency + Project-No + Sub-Project + Project-Phase
        /// a. Chars 1-3 Three char AFRS Agency code
        /// b.Chars 4-11 Eight char AFRS Project structure
        /// </summary>
        [FieldFixedLength(11)]
        [StartPosition(388, "Char(11) Equiv. to AFRS Agency + Project-No + Sub-Project + Project-Phase")]
        public string ProjectStructure { get; set; }

        /// <summary>
        /// AFRS Agency + Allocation Code
        /// a. Chars 1-3 Three char AFRS Agency code
        /// b.Chars 4-7 Four char AFRS Allocation code
        /// </summary>
        [FieldFixedLength(7)]
        [StartPosition(399, "Char(7) Equiv. to AFRS Agency + Allocation Code")]
        public string AllocationCode { get; set; }

        /// <summary></summary>
        [FieldFixedLength(2)]
        [StartPosition(406, "Char(2)")]
        public string SubObject { get; set; }

        /// <summary></summary>
        [FieldFixedLength(4)]
        [StartPosition(408, "Char(4)")]
        public string SubSubObject { get; set; }

        /// <summary></summary>
        [FieldFixedLength(4)]
        [StartPosition(412, "Char(4) (SAP: GL_ACCT)")]
        public string GeneralLedgers { get; set; }

        /// <summary>Payroll In Period</summary>
        [FieldFixedLength(6)]
        [StartPosition(416, "CHAR(6) Payroll In Period")]
        public string InPeriod { get; set; }

        /// <summary>Payroll For Period</summary>
        [FieldFixedLength(6)]
        [StartPosition(422, "CHAR(6) Payroll For Period")]
        public string ForPeriod { get; set; }

        [FieldFixedLength(8)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.None, 2, 6)]
        [StartPosition(428, "NUMC(8) FTE (Full Time Equivalent) 8 digits with implied decimal point (2 left, 6 right)")]
        public decimal FTE_8 { get; set; }

        [FieldFixedLength(1)]
        [StartPosition(436, "CHAR(1) FTE 8 Sign the field is signed character ('+' for positive '-' for negative)")]
        public string FTE_8_Sign { get; set; }

        public const int Total_Length = 436;

        public int GetRecordLength() => Total_Length;

        public bool IsPossibleRecord(string record) => !string.IsNullOrEmpty(record) && record.Length == Total_Length && record.StartsWith("01");
    }

}
