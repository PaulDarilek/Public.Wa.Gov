using FileHelpers;
using Hrms.Public.Abstract;
using Hrms.Public.Converters;
using System;

namespace Hrms.Public.Files
{

    /// <summary>Gap 7 Map (Payroll Accounting Details)</summary>
    /// <remarks><see cref="https://support.hrms.wa.gov/sites/default/files/public/resources/interfaces/GAP7-Map.pdf"/></remarks>
    [FixedLengthRecord()]
    public class Gap07Detail : IFixedLengthFile
    {
        [FieldFixedLength(2)]
        [FieldSpec(2, 1, "Constant '01'")]
        public string RecordType; //00 = Header, 01=Detail

        [FieldFixedLength(4)]
        [FieldSpec(4, 3, "Personnel Area (Agency/Sub equivalent)")]
        public string Agency;

        [FieldFixedLength(4)]
        [FieldSpec(4, 7, "Personnel Sub Area (Bargaining Unit equivalent)")]
        public string BargainingUnit;

        [FieldFixedLength(1)]
        [FieldSpec(1, 11, "Employee Group (Permanent, Temporary, etc)")]
        public char EmployeeGroup;

        [FieldFixedLength(2)]
        [FieldSpec(2, 12, "Employee Sub Group (Monthly, Hourly, etc.)")]
        public string EmployeeSubGroup;

        [FieldFixedLength(2)]
        [FieldSpec(2, 14, "Payroll Area (Pay Cycle)")]
        public string PayrollArea;

        [FieldFixedLength(8)]
        [FieldSpec(8, 16, "Org Unit (Department)")]
        public string OrgUnit;

        [FieldFixedLength(12)]
        [FieldSpec(12, 24, "Org Code (Cost Center equivalent)")]
        public string OrgCode;

        [FieldFixedLength(40)]
        [FieldSpec(40, 36, "Org Title (Department Name)")]
        public string OrgTitle;

        [FieldFixedLength(5)]
        [FieldSpec(5, 76, "(SAP) Function Module")]
        public string WarrantRegisterNumber;

        [FieldFixedLength(7)]
        [FieldSpec(7, 81, "Warrant/EFT Number (Sap: truncate from 13 to 7 characters, See Extension FIEXT001)")]
        [FieldNullValue(typeof(string), null)]
        public string WarrantEftNumber;

        [FieldFixedLength(1)]
        [FieldSpec(1, 88, "Warrant Cancellation Indicator 'C'")]
        [FieldNullValue(typeof(char), " ")]
        public char WarrantCancellationIndicator;

        /// <summary>PersonnelNumber</summary>
        [FieldFixedLength(8)]
        [FieldSpec(8, 89, "Employee number/Personnel number")]
        public string EmployeeNumber;

        [FieldFixedLength(9)]
        [FieldValueDiscarded]
        [FieldSpec(9, 97, "Employee Socical Security Number")]
        public string SSN;

        [FieldFixedLength(30)]
        [FieldSpec(30, 106, "Employee Name")]
        public string EmployeeName;

        [FieldFixedLength(1)]
        [FieldSpec(1, 136, "Employee Status (Active/Terminated) 'A' or 'T'")]
        public char EmployeeStatus;

        [FieldFixedLength(16)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.LeadingSeparate, 13, 2)]
        [FieldSpec(16, 137, "DEC(13,2) 5 digits with implied decimal point (13 left, 2 right) plus low order sign or blank")]
        public decimal Salary;

        [FieldFixedLength(2)]
        [FieldSpec(2, 153, "Salary Range (Pay Scale Area)")]
        public string SalaryRange;

        [FieldFixedLength(8)]
        [FieldSpec(8, 155, "Char(8) Salary Step (Pay Scale Group)")]
        public string SalaryStep;

        [FieldFixedLength(2)]
        [FieldSpec(2, 163, "Salary Level (Pay Scale Level)")]
        public string SalaryLevel;

        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        [FieldSpec(8, 165, "DATS(8) CCYYMMDD Pay date (warrant and/or ACH date)")]
        public DateTime PayDate;

        [FieldFixedLength(8)]
        [FieldSpec(8, 173, "NUMC(8) Position Number")]
        public string Position;

        [FieldFixedLength(12)]
        [FieldSpec(12, 181, "CHAR(12) Position Code")]
        public string PositionCode;

        [FieldFixedLength(40)]
        [FieldSpec(40, 193, "CHAR(40) Position Title")]
        public string PositionTitle;

        [FieldFixedLength(8)]
        [FieldSpec(8, 233, "NUMC(8) Job Key")]
        public string JobClass;

        [FieldFixedLength(12)]
        [FieldSpec(12, 241, "CHAR(12) Job Class Code (From PAY1 Conversion)")]
        public string JobClassCode;

        /// <summary>JobTitle / Class Title</summary>
        [FieldFixedLength(40)]
        [FieldSpec(40, 253, "CHAR(40) (Class Title) Job Title")]
        public string JobTitle;

        /// <summary>Pay & ded codes</summary>
        [FieldFixedLength(4)]
        [FieldSpec(4, 293, "CHAR(4) Pay & ded codes")]
        public string WageType;

        /// <summary>Pay & ded codes</summary>
        [FieldFixedLength(8)]
        [FieldSpec(8, 297, "CHAR(8) Pay & ded text (short description)")]
        public string WageTypeText;

        [FieldFixedLength(5)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 2, 2)]
        [FieldSpec(5, 305, "NUMC(5) 5 digits with implied decimal point (2 left, 2 right), last position within the field is the signed character (blank for positive '-' for negative)")]
        public decimal FTE;

        [FieldFixedLength(13)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 2)]
        [FieldSpec(13, 310, "NUMC(13) 13 digits with implied decimal point (10 left, 2 right), last position within the field is the signed character (blank for positive '-' for negative)")]
        public decimal CurrentHours;

        [FieldFixedLength(13)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 2)]
        [FieldSpec(13, 323, "NUMC(13) 13 digits with implied decimal point (10 left, 2 right), last position within the field is the signed character (blank for positive '-' for negative)")]
        public decimal CurrentAmount;

        /// <summary>AFRS Agency</summary>
        [FieldFixedLength(4)]
        [FieldSpec(4, 336, "Char(4) Equiv. to AFRS Agency")]
        public string BusinessArea;

        /// <summary>
        /// AFRS Agency + Prog Index
        /// a.Chars 1-3 Three char AFRS Agency code
        /// b.Chars 4-8 Five char AFRS Program index
        /// c.Chars 9-16 Not Used Zero fill
        /// </summary>
        [FieldFixedLength(16)]
        [FieldSpec(16, 340, "Char(16) Equiv. to AFRS Agency + Prog Index")]
        public string FunctionalArea;

        /// <summary>
        /// AFRS Agency + Master Index
        /// a. Chars 1-3 Three char AFRS Agency code
        /// b.Chars 4-11 Eight char AFRS Master Index code
        /// c.Chars 12-12 Not Used Zero fill
        /// </summary>
        [FieldFixedLength(12)]
        [FieldSpec(12, 356, "Char(12) Equiv. to AFRS Agency + Master Index")]
        public string CostObject;

        /// <summary>
        /// AFRS Agency + Fund + Appr Index
        /// a. Chars 1-3 Three char AFRS Agency code
        /// b.Chars 4-6 Three char AFRS Fund
        /// c.Chars 7-9 Three char AFRS Appropriation Index code
        /// d. Chars 10-10 Not Used Zero fill
        /// </summary>
        [FieldFixedLength(10)]
        [FieldSpec(10, 368, "Char(10) Equiv. to AFRS Agency + Fund + Appr Index")]
        public string Fund;

        /// <summary>
        /// AFRS Agency + Org Index
        /// a. Chars 1-3 Three char AFRS Agency code
        /// b.Chars 4-7 Four char AFRS Organization Index
        /// c.Chars 8-10 Not Used Zero fill
        /// </summary>
        [FieldFixedLength(10)]
        [FieldSpec(10, 378, "Char(10) Equiv. to AFRS Agency + Org Index")]
        public string CostCenter;

        /// <summary>
        /// AFRS Agency + Project-No + Sub-Project + Project-Phase
        /// a. Chars 1-3 Three char AFRS Agency code
        /// b.Chars 4-11 Eight char AFRS Project structure
        /// </summary>
        [FieldFixedLength(11)]
        [FieldSpec(11, 388, "Char(11) Equiv. to AFRS Agency + Project-No + Sub-Project + Project-Phase")]
        public string ProjectStructure;

        /// <summary>
        /// AFRS Agency + Allocation Code
        /// a. Chars 1-3 Three char AFRS Agency code
        /// b.Chars 4-7 Four char AFRS Allocation code
        /// </summary>
        [FieldFixedLength(7)]
        [FieldSpec(7, 399, "Char(7) Equiv. to AFRS Agency + Allocation Code")]
        public string AllocationCode;

        /// <summary></summary>
        [FieldFixedLength(2)]
        [FieldSpec(2, 406, "Char(2)")]
        public string SubObject;

        /// <summary></summary>
        [FieldFixedLength(4)]
        [FieldSpec(4, 408, "Char(4)")]
        public string SubSubObject;

        /// <summary></summary>
        [FieldFixedLength(4)]
        [FieldSpec(4, 412, "Char(4) (SAP: GL_ACCT)")]
        public string GeneralLedgers;

        /// <summary>Payroll In Period</summary>
        [FieldFixedLength(6)]
        [FieldSpec(6, 416, "CHAR(6) Payroll In Period")]
        public string InPeriod;

        /// <summary>Payroll For Period</summary>
        [FieldFixedLength(6)]
        [FieldSpec(6, 422, "CHAR(6) Payroll For Period")]
        public string ForPeriod;

        [FieldFixedLength(8)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.None, 2, 6)]
        [FieldSpec(8, 428, "NUMC(8) FTE (Full Time Equivalent) 8 digits with implied decimal point (2 left, 6 right)")]
        public decimal FTE_8;

        [FieldFixedLength(1)]
        [FieldSpec(1, 436, "CHAR(1) FTE 8 Sign the field is signed character ('+' for positive '-' for negative)")]
        public char FTE_8_Sign;

        public const int Total_Length = 436;

        public int GetRecordLength() => Total_Length;

        public bool IsPossibleRecord(string record) => !string.IsNullOrEmpty(record) && record.Length == Total_Length && record.StartsWith("01");
    }

}
