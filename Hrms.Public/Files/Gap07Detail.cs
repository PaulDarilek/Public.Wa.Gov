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
        public const int Total_Length = 436;
        public const string RecordTypeDefault = "01";


        /// <summary>Record Type</summary>
        /// <remarks>00 = Header, 01=Detail</remarks>
        [StartPosition(1), FieldFixedLength(2)]
        public string RecordType { get; set; }

        /// <summary>Agency</summary>
        /// <remarks>Personnel Area (Agency/Sub equivalent)</remarks>
        [StartPosition(3), FieldFixedLength(4)]
        public string Agency { get; set; }

        /// <summary>Personnel Sub Area</summary>
        /// <remarks>(Bargaining Unit equivalent)</remarks>
        [StartPosition(7), FieldFixedLength(4)]
        public string BargainingUnit { get; set; }

        /// <summary>Employee Group</summary>
        /// <remarks>Permanent, Temporary, etc</remarks>
        [StartPosition(11), FieldFixedLength(1)]
        public string EmployeeGroup { get; set; }

        /// <summary>Employee Sub Group</summary>
        /// <remarks>Monthly, Hourly, etc.</remarks>
        [StartPosition(12), FieldFixedLength(2)]
        public string EmployeeSubGroup { get; set; }

        /// <summary>Payroll Area</summary>
        /// <remarks>(Pay Cycle)</remarks>
        [StartPosition(14), FieldFixedLength(2)]
        public string PayrollArea { get; set; }

        /// <summary>Organization Unit (Department)</summary>
        /// <remarks>NUMC(8) 8 16 PA0001 ORGEH Organizational Unit (SAP assigned)</remarks>
        [StartPosition(16), FieldFixedLength(8)]
        public string OrgUnit { get; set; }

        /// <summary>Organizational Code (Cost Center equivalent)</summary>
        /// <remarks>CHAR(12) 12 24 HRP1000 SHORT (from PAY1 conversion)</remarks>
        [StartPosition(24), FieldFixedLength(12)]
        public string OrgCode { get; set; }

        /// <summary>Organizational Title</summary>
        /// <remarks>CHAR(40) 40 36 HRP1000 STEXT (Department Name)</remarks>
        [StartPosition(36), FieldFixedLength(40)]
        public string OrgTitle { get; set; }

        /// <summary>Warrant Register Number</summary>
        /// <remarks>(SAP) Function Module</remarks>
        [StartPosition(76), FieldFixedLength(5)]
        public string WarrantRegisterNumber { get; set; }

        /// <summary>Warrant/EFT Number</summary>
        /// <remarks>(Sap: truncate from 13 to 7 characters, See Extension FIEXT001)</remarks>
        [StartPosition(81), FieldFixedLength(7)]
        public string WarrantEftNumber { get; set; }

        /// <summary>Warrant Cancellation Indicator</summary>
        /// <remarks>'C'</remarks>
        [StartPosition(88), FieldFixedLength(1)]
        public string WarrantCancellationIndicator { get; set; }

        /// <summary>PersonnelNumber</summary>
        /// <remarks>Employee number/Personnel number</remarks>
        [StartPosition(89), FieldFixedLength(8)]
        public string EmployeeNumber { get; set; }

        /// <summary>Employee Socical Security Number</summary>
        /// <remarks></remarks>
        [StartPosition(97), FieldFixedLength(9)]
        public string SSN { get; set; }

        /// <summary>Employee Name</summary>
        /// <remarks></remarks>
        [StartPosition(106), FieldFixedLength(30)]
        public string EmployeeName { get; set; }

        /// <summary>Employee Status</summary>
        /// <remarks>(Active/Terminated) 'A' or 'T'</remarks>
        [StartPosition(136), FieldFixedLength(1)]
        public string EmployeeStatus { get; set; }

        /// <summary></summary>
        /// <remarks>DEC(13,2) implied decimal point (13 left, 2 right) plus low order sign or blank</remarks>
        [StartPosition(137), FieldFixedLength(16), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 13, 2)]
        public decimal Salary { get; set; }

        /// <summary>Salary Range</summary>
        /// <remarks>(Pay Scale Area)</remarks>
        [StartPosition(153), FieldFixedLength(2)]
        public string SalaryRange { get; set; }

        /// <summary>Salary Step</summary>
        /// <remarks>Char(8) (Pay Scale Group)</remarks>
        [StartPosition(155), FieldFixedLength(8)]
        public string SalaryStep { get; set; }

        /// <summary>Salary Level</summary>
        /// <remarks>(Pay Scale Level)</remarks>
        [StartPosition(163), FieldFixedLength(2)]
        public string SalaryLevel { get; set; }

        /// <summary>Pay Date</summary>
        /// <remarks>DATS(8) CCYYMMDD  (warrant and/or ACH date)</remarks>
        [StartPosition(165), FieldFixedLength(8), FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime PayDate { get; set; }

        /// <summary>Position Number</summary>
        /// <remarks>NUMC(8)</remarks>
        [StartPosition(173), FieldFixedLength(8)]
        public string Position { get; set; }

        /// <summary>Position Code</summary>
        /// <remarks>CHAR(12)</remarks>
        [StartPosition(181), FieldFixedLength(12)]
        public string PositionCode { get; set; }

        /// <summary>Position Title</summary>
        /// <remarks>CHAR(40)</remarks>
        [StartPosition(193), FieldFixedLength(40)]
        public string PositionTitle { get; set; }

        /// <summary>Job Key</summary>
        /// <remarks>NUMC(8)</remarks>
        [StartPosition(233), FieldFixedLength(8)]
        public string JobClass { get; set; }

        /// <summary>Job Class Code</summary>
        /// <remarks>CHAR(12) (From PAY1 Conversion)</remarks>
        [StartPosition(241), FieldFixedLength(12)]
        public string JobClassCode { get; set; }

        /// <summary>JobTitle / Class Title</summary>
        /// <remarks>CHAR(40)</remarks>
        [StartPosition(253), FieldFixedLength(40)]
        public string JobTitle { get; set; }

        /// <summary>Pay & ded codes</summary>
        /// <remarks>CHAR(4)</remarks>
        [StartPosition(293), FieldFixedLength(4)]
        public string WageType { get; set; }

        /// <summary>Pay & ded codes</summary>
        /// <remarks>CHAR(8) (short description)</remarks>
        [StartPosition(297), FieldFixedLength(8)]
        public string WageTypeText { get; set; }

        /// <summary></summary>
        /// <remarks>NUMC(5) 5 digits with implied decimal point (2 left, 2 right), last position within the field is the signed character (blank for positive '-' for negative)</remarks>
        [StartPosition(305), FieldFixedLength(5), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 2, 2)]
        public decimal FTE { get; set; }

        /// <summary></summary>
        /// <remarks>NUMC(13) 13 digits with implied decimal point (10 left, 2 right), last position within the field is the signed character (blank for positive '-' for negative)</remarks>
        [StartPosition(310), FieldFixedLength(13), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 2)]
        public decimal CurrentHours { get; set; }

        /// <summary></summary>
        /// <remarks>NUMC(13) 13 digits with implied decimal point (10 left, 2 right), last position within the field is the signed character (blank for positive '-' for negative)</remarks>
        [StartPosition(323), FieldFixedLength(13), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 2)]
        public decimal CurrentAmount { get; set; }

        /// <summary>AFRS Agency</summary>
        /// <remarks>Char(4) Equiv. to AFRS Agency</remarks>
        [StartPosition(336), FieldFixedLength(4)]
        public string BusinessArea { get; set; }

        /// <summary>
        /// AFRS Agency + Prog Index
        /// a.Chars 1-3 Three char AFRS Agency code
        /// b.Chars 4-8 Five char AFRS Program index
        /// c.Chars 9-16 Not Used Zero fill
        /// </summary>
        /// <remarks>Char(16) Equiv. to AFRS Agency + Prog Index</remarks>
        [StartPosition(340), FieldFixedLength(16)]
        public string FunctionalArea { get; set; }

        /// <summary>
        /// AFRS Agency + Master Index
        /// a. Chars 1-3 Three char AFRS Agency code
        /// b.Chars 4-11 Eight char AFRS Master Index code
        /// c.Chars 12-12 Not Used Zero fill
        /// </summary>
        /// <remarks>Char(12) Equiv. to AFRS Agency + Master Index</remarks>
        [StartPosition(356), FieldFixedLength(12)]
        public string CostObject { get; set; }

        /// <summary>
        /// AFRS Agency + Fund + Appr Index
        /// a. Chars 1-3 Three char AFRS Agency code
        /// b.Chars 4-6 Three char AFRS Fund
        /// c.Chars 7-9 Three char AFRS Appropriation Index code
        /// d. Chars 10-10 Not Used Zero fill
        /// </summary>
        /// <remarks>Char(10) Equiv. to AFRS Agency + Fund + Appr Index</remarks>
        [StartPosition(368), FieldFixedLength(10)]
        public string Fund { get; set; }

        /// <summary>
        /// AFRS Agency + Org Index
        /// a. Chars 1-3 Three char AFRS Agency code
        /// b.Chars 4-7 Four char AFRS Organization Index
        /// c.Chars 8-10 Not Used Zero fill
        /// </summary>
        /// <remarks>Char(10) Equiv. to AFRS Agency + Org Index</remarks>
        [StartPosition(378), FieldFixedLength(10)]
        public string CostCenter { get; set; }

        /// <summary>
        /// AFRS Agency + Project-No + Sub-Project + Project-Phase
        /// a. Chars 1-3 Three char AFRS Agency code
        /// b.Chars 4-11 Eight char AFRS Project structure
        /// </summary>
        /// <remarks>Char(11) Equiv. to AFRS Agency + Project-No + Sub-Project + Project-Phase</remarks>
        [StartPosition(388), FieldFixedLength(11)]
        public string ProjectStructure { get; set; }

        /// <summary>
        /// AFRS Agency + Allocation Code
        /// a. Chars 1-3 Three char AFRS Agency code
        /// b.Chars 4-7 Four char AFRS Allocation code
        /// </summary>
        /// <remarks>Char(7) Equiv. to AFRS Agency + Allocation Code</remarks>
        [StartPosition(399), FieldFixedLength(7)]
        public string AllocationCode { get; set; }

        /// <summary></summary>
        /// <remarks>Char(2)</remarks>
        [StartPosition(406), FieldFixedLength(2)]
        public string SubObject { get; set; }

        /// <summary></summary>
        /// <remarks>Char(4)</remarks>
        [StartPosition(408), FieldFixedLength(4)]
        public string SubSubObject { get; set; }

        /// <summary></summary>
        /// <remarks>Char(4) (SAP: GL_ACCT)</remarks>
        [StartPosition(412), FieldFixedLength(4)]
        public string GeneralLedgers { get; set; }

        /// <summary>Payroll In Period</summary>
        /// <remarks>CHAR(6) Payroll In Period</remarks>
        [StartPosition(416), FieldFixedLength(6)]
        public string InPeriod { get; set; }

        /// <summary>Payroll For Period</summary>
        /// <remarks>CHAR(6) Payroll For Period</remarks>
        [StartPosition(422), FieldFixedLength(6)]
        public string ForPeriod { get; set; }

        /// <summary></summary>
        /// <remarks>NUMC(8) FTE (Full Time Equivalent) 8 digits with implied decimal point (2 left, 6 right)</remarks>
        [StartPosition(428), FieldFixedLength(8), FieldConverter(typeof(ImpliedDecimalConverter), Sign.None, 2, 6)]
        public decimal FTE_8 { get; set; }

        /// <summary></summary>
        /// <remarks>CHAR(1) FTE 8 Sign the field is signed character ('+' for positive '-' for negative)</remarks>
        [StartPosition(436), FieldFixedLength(1)]
        public string FTE_8_Sign { get; set; }

        public Gap07Detail()
        {
            RecordType = RecordType ?? RecordTypeDefault;
        }

        public int GetRecordLength() => Total_Length;

        public bool IsPossibleRecord(string record) => !string.IsNullOrEmpty(record) && record.Length == Total_Length && record.StartsWith("01");
    }

}
