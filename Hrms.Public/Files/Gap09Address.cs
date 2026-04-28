using FileHelpers;
using Hrms.Public.Abstract;
using System;

namespace Hrms.Public.Files
{
    /// <summary>Gap09 Record type 0006 Addresses (Multiple Records Permissible)</summary>
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class Gap09Address
    {
        public const int Total_Length = 347;

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

        /// <summary>Address Type</summary>
        [FieldFixedLength(4)]
        [FieldSpec(4, 69, "Address Type")]
        public string AddressType;

        /// <summary>Street Line 1</summary>
        [FieldFixedLength(60)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(60, 73, "Address Type")]
        public string StreetLine1;

        /// <summary>Street Line 2</summary>
        [FieldFixedLength(40)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(40, 133, "Address Type")]
        public string StreetLine2;

        /// <summary>City</summary>
        [FieldFixedLength(40)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(40, 173, "")]
        public string City;

        /// <summary>State / Region</summary>
        [FieldFixedLength(3)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(3, 213, "")]
        public string State;

        /// <summary>Zip / Postal Code</summary>
        [FieldFixedLength(10)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(10, 216, "")]
        public string ZipCode;

        /// <summary>County</summary>
        [FieldFixedLength(3)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(3, 226, "")]
        public string County;

        /// <summary>Zip / Postal Code</summary>
        [FieldFixedLength(3)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(3, 229, "")]
        public string Country;

        /// <summary>Home Phone</summary>
        [FieldFixedLength(20)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(20, 232, "")]
        public string HomePhone;

        /// <summary>Phone Type (Cell, Work, etc)</summary>
        [FieldFixedLength(4)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(4, 252, "")]
        public string PhoneType1;

        /// <summary>Phone Number</summary>
        [FieldFixedLength(20)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(20, 256, "")]
        public string PhoneNumber1;

        /// <summary>Phone Type (Cell, Work, etc)</summary>
        [FieldFixedLength(4)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(4, 276, "")]
        public string PhoneType2;

        /// <summary>Phone Number</summary>
        [FieldFixedLength(20)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(20, 280, "")]
        public string PhoneNumber2;

        /// <summary>Phone Type (Cell, Work, etc)</summary>
        [FieldFixedLength(4)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(4, 300, "")]
        public string PhoneType3;

        /// <summary>Phone Number</summary>
        [FieldFixedLength(20)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(20, 304, "")]
        public string PhoneNumber3;

        /// <summary>Phone Type (Cell, Work, etc)</summary>
        [FieldFixedLength(4)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(4, 324, "")]
        public string PhoneType4;

        /// <summary>Phone Number</summary>
        [FieldFixedLength(20)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(20, 328, "")]
        public string PhoneNumber4;
    }
}
