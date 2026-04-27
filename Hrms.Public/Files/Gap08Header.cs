using FileHelpers;
using Hrms.Public.Abstract;
using Hrms.Public.Converters;
using System;

namespace Hrms.Public.Files
{

    /// <summary>Gap 8 (Leave Summary)</summary>
    /// <remarks>
    /// Only "Header" Records.
    /// <see cref="https://support.hrms.wa.gov/sites/default/files/public/resources/interfaces/GAP8-Map.pdf"/>
    /// </remarks>
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class Gap08Header : IFixedLengthFile
    {
        [FieldFixedLength(4)]
        [FieldSpec(4, 1, "Personnel Area (Agency/Sub equivalent)")]
        public string PersonnelArea;
        
        [FieldFixedLength(4)]
        [FieldSpec(4, 5, "Personnel Sub Area (Bargaining Unit equivalent)")]
        public string PersonnelSubArea;
        
        [FieldFixedLength(1)]
        [FieldSpec(1, 9, "Employee Group (Permanent, Temporary, etc)")]
        public char EmployeeGroup;
        
        [FieldFixedLength(2)]
        [FieldSpec(2, 10, "Employee Sub Group (Monthly, Hourly, etc.)")]
        public string EmployeeSubGroup;
        
        [FieldFixedLength(8)]
        [FieldSpec(8, 12, "NUMC(8) Organizational Unit (SAP assigned)")]
        public string OrgUnit;

        [FieldFixedLength(12)]
        [FieldSpec(12, 20, "CHAR(12) Org Code (Cost Center equivalent)")]
        public string OrgCode;

        [FieldFixedLength(40)]
        [FieldSpec(40, 32, "CHAR(40) Org Title (Department Name)")]
        public string OrgTitle;
     
        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        [FieldSpec(8, 72, "DATS(8) YYYYMMDD Date Leave Effective")]
        public DateTime EffectiveDate;

        [FieldFixedLength(8)]
        [FieldSpec(8, 80, "NUMC(8) Employee Number / Personnel Number")]
        public string PersonnelNumber;
    
        [FieldFixedLength(9)]
        [FieldValueDiscarded]
        [FieldSpec(9, 88, "NUMC(9) SSN - can send this or Employee number/Personnel number")]
        public string SSN;
        
        [FieldFixedLength(30)]
        [FieldSpec(30, 97, "CHAR(30) Employee Name")]
        public string EmployeeName;
        
        [FieldFixedLength(18)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 15, 2)]
        [FieldSpec(18, 127, "DEC (15,2) Implied decimal point, trailing and leading zeros, single character at the end (' ' if positive, '-' if negative)")]
        public decimal Salary;
        
        [FieldFixedLength(8)]
        [FieldSpec(8, 145, "NUMC(8) Position Number (Assigned by SAP)")]
        [FieldConverter(typeof(IntConverter), 8, false)]
        public int Position;
        
        [FieldFixedLength(12)]
        [FieldSpec(12, 153, "Char(12) Position Number (from PAY1 Conversion)")]
        public string PositionCode;
     
        [FieldFixedLength(40)]
        [FieldSpec(40, 165, "Char(40) Position Title")]
        public string PositionTitle;
        
        [FieldFixedLength(8)]
        [FieldConverter(typeof(IntConverter), 8, false)]
        [FieldSpec(8, 205, "NUMC(8) Job Key (assigned by SAP)")]
        public int Job;
        
        [FieldFixedLength(12)]
        [FieldSpec(12, 213, "Char(12) Job Class Code (from PAY1 Conversion)")]
        public string JobClassCode;
        
        [FieldFixedLength(40)]
        [FieldSpec(40, 225, "Char(40) Job Title")]
        public string JobTitle;
        
        [FieldFixedLength(2)]
        [FieldSpec(2, 265, "Char(2) Leave Quota Type (code identifying Sick, Annual, Personal Holiday, etc.)")]
        public string LeaveType;
        
        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        [FieldSpec(8, 267, "DATS(8) YYYYMMDD First day of period for current leave accrual process")]
        public DateTime BeginDate;
        
        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        [FieldSpec(8, 275, "DATS(8) YYYYMMDD Last day of period for current leave accrual process")]
        public DateTime EndDate;
        
        [FieldFixedLength(16)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 5)]
        [FieldSpec(16, 283, "DEC (10,5) Implied decimal point, trailing and leading zeros, single character at the end (' ' if positive, '-' if negative)")]
        public decimal BeginingBalance;
        
        [FieldFixedLength(16)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 5)]
        [FieldSpec(16, 299, "DEC (10,5) Implied decimal point, trailing and leading zeros, single character at the end (' ' if positive, '-' if negative)")]
        public decimal LeaveEarned;
        
        [FieldFixedLength(16)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 5)]
        [FieldSpec(16, 315, "DEC (10,5) Implied decimal point, trailing and leading zeros, single character at the end (' ' if positive, '-' if negative)")]
        public decimal LeaveTaken;
        
        [FieldFixedLength(16)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 5)]
        [FieldSpec(16, 331, "DEC (10,5) Implied decimal point, trailing and leading zeros, single character at the end (' ' if positive, '-' if negative)")]
        public decimal LeavePaid;
        
        [FieldFixedLength(16)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 5)]
        [FieldSpec(16, 347, "DEC (10,5) Implied decimal point, trailing and leading zeros, single character at the end (' ' if positive, '-' if negative)")]
        public decimal LeaveAdjustment;
        
        [FieldFixedLength(16)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 5)]
        [FieldSpec(16, 363, "DEC (10,5) Implied decimal point, trailing and leading zeros, single character at the end (' ' if positive, '-' if negative)")]
        public decimal LeaveDonated;
        
        [FieldFixedLength(16)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 5)]
        [FieldSpec(16, 379, "DEC (10,5) Implied decimal point, trailing and leading zeros, single character at the end (' ' if positive, '-' if negative)")]
        public decimal LeaveReturned;

        [FieldFixedLength(16)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 5)]
        [FieldSpec(16, 395, "DEC (10,5) Implied decimal point, trailing and leading zeros, single character at the end (' ' if positive, '-' if negative)")]
        public decimal LeaveReceived;
        
        [FieldFixedLength(16)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 10, 5)]
        [FieldSpec(16, 411, "DEC (10,5) Implied decimal point, trailing and leading zeros, single character at the end (' ' if positive, '-' if negative)")]
        public decimal EndingBalance;


        public const int Total_Length = 427;

        public int GetRecordLength() => Total_Length;

        public bool IsPossibleRecord(string record) => !string.IsNullOrEmpty(record) && record.Length == Total_Length;
    }

}
