using FileHelpers;
using Hrms.Public.Abstract;
using System;

namespace Hrms.Public.Files
{
    /// <summary>Gap09 Record Type "0000" Actions</summary>
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class Gap09Actions
    {
        public const int Total_Length = 73;

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
        [FieldSpec(8, 12, "Personnel Number")]
        public string PersonnelNumber;

        /// <summary>CHAR(9)</summary>
        [FieldFixedLength(9)]
        [FieldSpec(9, 20, "Social Security Number")]
        public string SSN;

        /// <summary>DATS(8) 8 24 CATS YYYYMMDD PA2010 BEGDA Start date</summary>
        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        [FieldSpec(8, 24, "YYYYMMDD Date of last change")]
        public DateTime DateChanged;

        /// <summary>DATS(8) 8 32 CATS YYYYMMDD PA2010 ENDDA End Date</summary>
        [FieldFixedLength(12)]
        [FieldSpec(12, 37, "Name of person who changed object")]
        [FieldTrim(TrimMode.Right)]
        public string PersonChanged;

        /// <summary>Record Type "0000"</summary>
        [FieldFixedLength(4)]
        [FieldSpec(4, 49, "Constant '0000'")]
        public string RecordType;

        /// <summary>DATS(8) 8 24 CATS YYYYMMDD PA2010 BEGDA Start date</summary>
        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        [FieldSpec(8, 53, "CCYYMMDD Start Date")]
        public DateTime DateEffective;

        /// <summary>DATS(8) 8 24 CATS YYYYMMDD PA2010 BEGDA Start date</summary>
        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        [FieldSpec(8, 61, "CCYYMMDD End Date")]
        public DateTime EndDate;

        /// <summary>Action Type</summary>
        [FieldFixedLength(2)]
        [FieldSpec(2, 69, "Reason code for the Action Type ")]
        public string ActionType;

        /// <summary>Employment Status (Active, Inactive, Retiree, etc)</summary>
        [FieldFixedLength(1)]
        [FieldSpec(1, 73, "Employment Status (Active, Inactive, Retiree, etc)")]
        public string EmploymentStatus;

    }
}
