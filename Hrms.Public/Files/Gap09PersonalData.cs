using FileHelpers;
using Hrms.Public.Abstract;
using Hrms.Public.Converters;
using System;

namespace Hrms.Public.Files
{
    /// <summary>Gap09 Record type 0002 (Personal Data)</summary>
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class Gap09PersonalData
    {
        public const int Total_Length = 292;

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
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(12, 37, "Name of person who changed object")]
        public string PersonChanged;

        /// <summary>Record Type "0000"</summary>
        [FieldFixedLength(4)]
        [FieldSpec(4, 49, "Constant '0002'")]
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

        /// <summary>Employee Name</summary>
        [FieldFixedLength(30)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(30, 69, "Employee Name")]
        public string EmployeeName;

        /// <summary>Last Name</summary>
        [FieldFixedLength(40)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(40, 99, "Last Name")]
        public string LastName;

        /// <summary>First Name</summary>
        [FieldFixedLength(40)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(40, 139, "First Name")]
        public string FirstName;

        /// <summary>Middle Name</summary>
        [FieldFixedLength(40)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(40, 179, "Middle Name")]
        public string MiddleName;

        /// <summary>Middle Name</summary>
        [FieldFixedLength(40)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(40, 179, "Alias (Also Known As)")]
        public string Alias;

        /// <summary>Date of Birth</summary>
        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        [FieldSpec(8, 259, "CCYYMMDD Birth Date")]
        public DateTime DateOfBirth;

        /// <summary>Sex</summary>
        [FieldFixedLength(1)]
        [FieldSpec(1, 267, "Sex Assigned at Birth (Code to identify Male or Female)")]
        public char Sex;

        /// <summary>Marital Status code</summary>
        [FieldFixedLength(1)]
        [FieldSpec(1, 268, "Marital Status (Married, Single, Divorced, etc)")]
        public char MaritalStatus;

        /// <summary>Marital Status Date</summary>
        [FieldFixedLength(8)]
        [FieldConverter(typeof(DateWithZeroConverter))]
        [FieldSpec(8, 259, "CCYYMMDD Marital Status Date")]
        public DateTime? MaritalStatusDate;

        /// <summary>Suffix (Jr, Sr, Title)</summary>
        [FieldFixedLength(15)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(15, 277, "Title: Jr, Sr")]
        public string Suffix;

        /// <summary>Gender Identity</summary>
        [FieldFixedLength(1)]
        [FieldSpec(1, 292, "Gender Identity Code")]
        public char GenderIdentity;
    }
}
