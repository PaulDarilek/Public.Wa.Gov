using FileHelpers;
using Hrms.Public.Converters;
using System;

namespace Hrms.Public.Files
{

    /// <summary>Gap 7 File Detail (Payroll Accounting Details)</summary>
    /// <see cref="https://support.hrms.wa.gov/sites/default/files/public/resources/interfaces/GAP7-Map.pdf"/>
    [FixedLengthRecord()]
    public class Gap07Detail : FixedLengthFile
    {
        [FieldFixedLength(2)]
        public string RecordType; //00 = Header, 01=Detail

        [FieldFixedLength(4)]
        public string Agency;

        [FieldFixedLength(4)]
        public string BargainingUnit;

        [FieldFixedLength(1)]
        public string EmployeeGroup;

        [FieldFixedLength(2)]
        public string EmployeeSubGroup;

        [FieldFixedLength(2)]
        public string PayrollArea;

        [FieldFixedLength(8)]
        public string OrgUnit;

        [FieldFixedLength(12)]
        public string OrgCode;

        [FieldFixedLength(40)]
        public string OrgTitle;

        [FieldFixedLength(5)]
        public string WarrantRegisterNumber;

        [FieldFixedLength(1)]
        public char WarrantCancellationIndicator;

        /// <summary>PersonnelNumber</summary>
        [FieldFixedLength(8)]
        public string EmployeeNumber;

        [FieldFixedLength(9)]
        [FieldValueDiscarded]
        public string SSN;

        [FieldFixedLength(30)]
        public string EmployeeName;

        [FieldFixedLength(1)]
        public char EmployeeStatus;

        [FieldFixedLength(16)]
        [FieldConverter(typeof(SignTwoDecimalConverter))]
        public decimal Salary;

        [FieldFixedLength(2)]
        public string SalaryRange;

        [FieldFixedLength(8)]
        public string SalaryStep;

        [FieldFixedLength(2)]
        public string SalaryLevel;

        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime PayDate;

        [FieldFixedLength(8)]
        public string Position;

        [FieldFixedLength(12)]
        public string PositionCode;

        [FieldFixedLength(40)]
        public string PositionTitle;

        [FieldFixedLength(8)]
        public string JobClass;

        [FieldFixedLength(12)]
        public string JobClassCode;

        /// <summary>JobTitle / Class Title</summary>
        [FieldFixedLength(40)]
        public string JobTitle;

        /// <summary>Pay & ded codes</summary>
        [FieldFixedLength(4)]
        public string WageType;

        /// <summary>Pay & ded codes</summary>
        [FieldFixedLength(8)]
        public string WageTypeText;

        [FieldFixedLength(5)]
        [FieldConverter(typeof(SignTwoDecimalConverter))]
        public decimal FTE;

        [FieldFixedLength(13)]
        [FieldConverter(typeof(SignTwoDecimalConverter))]
        public decimal CurrentHours;

        [FieldFixedLength(13)]
        [FieldConverter(typeof(SignTwoDecimalConverter))]
        public decimal CurrentAmount;

        /// <summary>AFRS Agency</summary>
        [FieldFixedLength(4)]
        public string BusinessArea;

        /// <summary>AFRS Agency + Prog Index</summary>
        [FieldFixedLength(16)]
        public string FunctionalArea;

        /// <summary>AFRS Agency + Master Index</summary>
        [FieldFixedLength(12)]
        public string CostObject;

        /// <summary>AFRS Agency + Fund + Appr Index</summary>
        [FieldFixedLength(10)]
        public string Fund;

        /// <summary>AFRS Agency + Org Index</summary>
        [FieldFixedLength(10)]
        public string CostCenter;

        /// <summary>AFRS Agency + Project-No + Sub-Project + Project-Phase</summary>
        [FieldFixedLength(11)]
        public string ProjectStructure;

        /// <summary>AFRS Agency + Allocation Code</summary>
        [FieldFixedLength(7)]
        public string AllocationCode;

        /// <summary></summary>
        [FieldFixedLength(2)]
        public string SubObject;

        /// <summary></summary>
        [FieldFixedLength(4)]
        public string SubSubObject;

        /// <summary></summary>
        [FieldFixedLength(4)]
        public string GeneralLedgers;

        /// <summary>Payroll In Period</summary>
        [FieldFixedLength(6)]
        public string InPeriod;

        /// <summary>Payroll For Period</summary>
        [FieldFixedLength(6)]
        public string ForPeriod;

        [FieldFixedLength(8)]
        public string FTE_8;

        [FieldFixedLength(1)]
        public string FTE_8_Sign;

        public const int Total_Length = 436;
    }

}
