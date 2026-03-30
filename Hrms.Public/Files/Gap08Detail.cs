//#pragma warning disable 0649
using FileHelpers;
using Hrms.Public.Converters;

namespace Hrms.Public.Files
{

    /// <summary>Gap 8 File Structure (Leave Summary)</summary>
    /// <see cref="https://support.hrms.wa.gov/sites/default/files/public/resources/interfaces/GAP8-Map.pdf"/>
    [FixedLengthRecord()]
    public class Gap08Detail : FixedLengthFile
    {
        [FieldFixedLength(4)]
        public string PersonnelArea;
        
        [FieldFixedLength(4)]
        public string PersonnelSubArea;
        
        [FieldFixedLength(1)]
        public string EmployeeGroup;
        
        [FieldFixedLength(2)]
        public string EmployeeSubGroup;
        
        [FieldFixedLength(8)]
        public string OrgUnit;

        [FieldFixedLength(12)]
        public string OrgCode;

        [FieldFixedLength(40)]
        public string OrgTitle;
     
        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public System.DateTime EffectiveDate;

        [FieldFixedLength(8)]
        public string PersonnelNumber;
    
        [FieldFixedLength(9)]
        [FieldValueDiscarded]
        public string SSN;
        
        [FieldFixedLength(30)]
        public string EmployeeName;
        
        [FieldFixedLength(18)]
        [FieldConverter(typeof(DecimalSignedImpliedPeriod), 2u)]
        public decimal Salary;
        
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
        
        [FieldFixedLength(40)]
        public string JobTitle;
        
        [FieldFixedLength(2)]
        public string LeaveType;
        
        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public System.DateTime BeginDate;
        
        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public System.DateTime EndDate;
        
        [FieldFixedLength(16)]
        [FieldConverter(typeof(DecimalUnsignedImpliedPeriod), 5u)]
        public decimal BeginingBalance;
        
        [FieldFixedLength(16)]
        [FieldConverter(typeof(DecimalUnsignedImpliedPeriod), 5u)]
        public decimal LeaveEarned;
        
        [FieldFixedLength(16)]
        [FieldConverter(typeof(DecimalUnsignedImpliedPeriod), 5u)]
        public decimal LeaveTaken;
        
        [FieldFixedLength(16)]
        [FieldConverter(typeof(DecimalUnsignedImpliedPeriod), 5u)]
        public decimal LeavePaid;
        
        [FieldFixedLength(16)]
        [FieldConverter(typeof(DecimalUnsignedImpliedPeriod), 5u)]
        public decimal LeaveAdjustment;
        
        [FieldFixedLength(16)]
        [FieldConverter(typeof(DecimalUnsignedImpliedPeriod), 5u)]
        public decimal LeaveDonated;
        
        [FieldFixedLength(16)]
        [FieldConverter(typeof(DecimalUnsignedImpliedPeriod), 5u)]
        public decimal LeaveReturned;

        [FieldFixedLength(16)]
        [FieldConverter(typeof(DecimalUnsignedImpliedPeriod), 5u)]
        public decimal LeaveReceived;
        
        [FieldFixedLength(17)]
        [FieldConverter(typeof(DecimalSignedImpliedPeriod), 5u)]
        public decimal EndingBalance;
    }

}
