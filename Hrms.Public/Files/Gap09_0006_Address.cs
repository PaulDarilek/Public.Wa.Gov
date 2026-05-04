using FileHelpers;
using Hrms.Public.Converters;
using Hrms.Public.Interfaces;
using System;

namespace Hrms.Public.Files
{
    /// <summary>Gap09 Record type 0006 Addresses (Multiple Records Permissible)</summary>
    [FixedLengthRecord(FixedMode.ExactLength)]
    public class Gap09_0006_Address : IGap09Common, IFixedLengthFile
    {
        public const string RecordTypeDefault = "0006";
        public const int Total_Length = 347;

        #region IGap09Common

        /// <summary>Personnel Area (Agency/Sub equivalent)</summary>
        [FieldOrder(1)]
        [FieldFixedLength(4)]
        [FieldSpec(4, 1, "Personnel Area (Agency/Sub equivalent)")]
        public string PersonnelArea { get; set; }

        /// <summary>Personnel Sub Area (Bargaining Unit equivalent)</summary>
        [FieldOrder(2)]
        [FieldFixedLength(4)]
        [FieldSpec(4, 5, "Personnel Sub Area (Bargaining Unit equivalent)")]
        public string PersonnelSubArea { get; set; }

        /// <summary>Employee Group (Permanent, Temporary, etc)</summary>
        [FieldOrder(3)]
        [FieldFixedLength(1)]
        [FieldSpec(1, 9, "Employee Group (Permanent, Temporary, etc)")]
        public string EmployeeGroup { get; set; }

        /// <summary>Employee Sub Group (Monthly, Hourly, etc.)</summary>
        [FieldOrder(4)]
        [FieldFixedLength(2)]
        [FieldSpec(2, 10, "Employee Sub Group (Monthly, Hourly, etc.)")]
        public string EmployeeSubGroup { get; set; }

        /// <summary>Personnel Number / Employee Number</summary>
        [FieldOrder(5)]
        [FieldFixedLength(8)]
        [FieldSpec(8, 12, "PA0001 PERNR Personnel Number")]
        public string PersonnelNumber { get; set; }

        /// <summary>Social Security Number</summary>
        [FieldOrder(6)]
        [FieldFixedLength(9)]
        [FieldSpec(9, 20, "PA0002 PERID Social Security Number")]
        public string SSN { get; set; }

        /// <summary>Date of last change</summary>
        [FieldOrder(7)]
        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        [FieldSpec(8, 29, "YYYYMMDD PA0000 AEDTM Date of Last Change")]
        public DateTime DateChanged { get; set; }

        /// <summary>Name of person who changed object</summary>
        [FieldOrder(8)]
        [FieldFixedLength(12)]
        [FieldSpec(12, 37, "PA0000 UNAME Name of person who changed object")]
        [FieldTrim(TrimMode.Right)]
        public string PersonChanged { get; set; }

        /// <summary>Record Type</summary>
        [FieldOrder(9)]
        [FieldFixedLength(4)]
        [FieldSpec(4, 49, "Record Type identifies the Gap09 subtype")]
        public string RecordType { get; set; }

        /// <summary>CCYYMMDD Start Date</summary>
        [FieldOrder(10)]
        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        [FieldSpec(8, 53, "CCYYMMDD DATS(8) PA0000 BEGDA Start date")]
        public DateTime DateEffective { get; set; }

        /// <summary>End Date</summary>
        [FieldOrder(11)]
        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        [FieldSpec(8, 61, "CCYYMMDD PA0000 ENDDA End Date")]
        public DateTime EndDate { get; set; }

        #endregion

        /// <summary>Address Type</summary>
        [FieldOrder(12)]
        [FieldFixedLength(4)]
        [FieldSpec(4, 69, "Address Type")]
        public string AddressType;

        /// <summary>Street Line 1</summary>
        [FieldOrder(13)]
        [FieldFixedLength(60)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(60, 73, "Address Type")]
        public string StreetLine1;

        /// <summary>Street Line 2</summary>
        [FieldOrder(14)]
        [FieldFixedLength(40)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(40, 133, "Address Type")]
        public string StreetLine2;

        /// <summary>City</summary>
        [FieldOrder(15)]
        [FieldFixedLength(40)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(40, 173, "")]
        public string City;

        /// <summary>State / Region</summary>
        [FieldOrder(16)]
        [FieldFixedLength(3)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(3, 213, "")]
        public string State;

        /// <summary>Zip / Postal Code</summary>
        [FieldOrder(17)]
        [FieldFixedLength(10)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(10, 216, "")]
        public string ZipCode;

        /// <summary>County</summary>
        [FieldOrder(18)]
        [FieldFixedLength(3)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(3, 226, "")]
        public string County;

        /// <summary>Zip / Postal Code</summary>
        [FieldOrder(19)]
        [FieldFixedLength(3)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(3, 229, "")]
        public string Country;

        /// <summary>Home Phone</summary>
        [FieldOrder(20)]
        [FieldFixedLength(20)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(20, 232, "")]
        public string HomePhone;

        /// <summary>Phone Type (Cell, Work, etc)</summary>
        [FieldOrder(21)]
        [FieldFixedLength(4)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(4, 252, "")]
        public string PhoneType1;

        /// <summary>Phone Number</summary>
        [FieldOrder(22)]
        [FieldFixedLength(20)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(20, 256, "")]
        public string PhoneNumber1;

        /// <summary>Phone Type (Cell, Work, etc)</summary>
        [FieldOrder(23)]
        [FieldFixedLength(4)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(4, 276, "")]
        public string PhoneType2;

        /// <summary>Phone Number</summary>
        [FieldOrder(24)]
        [FieldFixedLength(20)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(20, 280, "")]
        public string PhoneNumber2;

        /// <summary>Phone Type (Cell, Work, etc)</summary>
        [FieldOrder(25)]
        [FieldFixedLength(4)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(4, 300, "")]
        public string PhoneType3;

        /// <summary>Phone Number</summary>
        [FieldOrder(26)]
        [FieldFixedLength(20)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(20, 304, "")]
        public string PhoneNumber3;

        /// <summary>Phone Type (Cell, Work, etc)</summary>
        [FieldOrder(27)]
        [FieldFixedLength(4)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(4, 324, "")]
        public string PhoneType4;

        /// <summary>Phone Number</summary>
        [FieldOrder(28)]
        [FieldFixedLength(20)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(20, 328, "")]
        public string PhoneNumber4;

        public int GetRecordLength() => Total_Length;

        public bool IsPossibleRecord(string record)
        {
            return
                !string.IsNullOrEmpty(record) &&
                record.Length >= Total_Length &&
                record.Substring(48, 4) == RecordTypeDefault; //48 zero based, 49 one based in Gap9-Map.pdf
        }
    }
}
