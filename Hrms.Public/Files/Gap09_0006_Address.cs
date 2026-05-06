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

        /// <summary>Personnel Area</summary>
        /// <remarks>Agency/Sub equivalent</remarks>
        [StartPosition(1), FieldFixedLength(4), FieldOrder(1)]
        public string PersonnelArea { get; set; }

        /// <summary>Personnel Sub Area (Bargaining Unit equivalent)</summary>
        [StartPosition(5), FieldFixedLength(4), FieldOrder(2)]
        public string PersonnelSubArea { get; set; }

        /// <summary>Employee Group (Permanent, Temporary, etc)</summary>
        [StartPosition(9), FieldFixedLength(1), FieldOrder(3)]
        public string EmployeeGroup { get; set; }

        /// <summary>Employee Sub Group (Monthly, Hourly, etc.)</summary>
        [StartPosition(10), FieldFixedLength(2), FieldOrder(4)]
        public string EmployeeSubGroup { get; set; }

        /// <summary>Personnel Number / Employee Number</summary>
        /// <remarks>PA0001 PERNR Personnel Number</remarks>
        [StartPosition(12), FieldFixedLength(8), FieldOrder(5)]
        public string PersonnelNumber { get; set; }

        /// <summary>Social Security Number</summary>
        /// <remarks>PA0002 PERID Social Security Number</remarks>
        [StartPosition(20), FieldFixedLength(9), FieldOrder(6)]
        public string SSN { get; set; }

        /// <summary>Date of last change</summary>
        /// <remarks>YYYYMMDD PA0000 AEDTM Date of Last Change</remarks>
        [StartPosition(29), FieldFixedLength(8), FieldOrder(7), FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime DateChanged { get; set; }

        /// <summary>Name of person who changed object</summary>
        /// <remarks>PA0000 UNAME Name of person who changed object</remarks>
        [StartPosition(37), FieldFixedLength(12), FieldOrder(8), FieldTrim(TrimMode.Right)]
        public string PersonChanged { get; set; }

        /// <summary>Record Type</summary>
        /// <remarks>Record Type identifies the Gap09 subtype</remarks>
        [StartPosition(49), FieldFixedLength(4), FieldOrder(9)]
        public string RecordType { get; set; }

        /// <summary>CCYYMMDD Start Date</summary>
        /// <remarks>CCYYMMDD DATS(8) PA0000 BEGDA Start date</remarks>
        [StartPosition(53), FieldFixedLength(8), FieldOrder(10), FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime DateEffective { get; set; }

        /// <summary>End Date</summary>
        /// <remarks>CCYYMMDD PA0000 ENDDA End Date</remarks>
        [StartPosition(61), FieldFixedLength(8), FieldOrder(11), FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime EndDate { get; set; }

        #endregion

        /// <summary>Address Type</summary>
        [StartPosition(69), FieldFixedLength(4), FieldOrder(12)]
        public string AddressType;

        /// <summary>Street Line 1</summary>
        [StartPosition(73), FieldFixedLength(60), FieldOrder(13), FieldTrim(TrimMode.Right)]
        public string StreetLine1;

        /// <summary>Street Line 2</summary>
        [StartPosition(133), FieldFixedLength(40), FieldOrder(14), FieldTrim(TrimMode.Right)]
        public string StreetLine2;

        /// <summary>City</summary>
        /// <remarks></remarks>
        [StartPosition(173), FieldFixedLength(40), FieldOrder(15), FieldTrim(TrimMode.Right)]
        public string City;

        /// <summary>State / Region</summary>
        /// <remarks></remarks>
        [StartPosition(213), FieldFixedLength(3), FieldOrder(16), FieldTrim(TrimMode.Right)]
        public string State;

        /// <summary>Zip / Postal Code</summary>
        /// <remarks></remarks>
        [StartPosition(216), FieldFixedLength(10), FieldOrder(17), FieldTrim(TrimMode.Right)]
        public string ZipCode;

        /// <summary>County</summary>
        /// <remarks></remarks>
        [StartPosition(226), FieldFixedLength(3), FieldOrder(18), FieldTrim(TrimMode.Right)]
        public string County;

        /// <summary>Zip / Postal Code</summary>
        /// <remarks></remarks>
        [StartPosition(229), FieldFixedLength(3), FieldOrder(19), FieldTrim(TrimMode.Right)]
        public string Country;

        /// <summary>Home Phone</summary>
        /// <remarks></remarks>
        [StartPosition(232), FieldFixedLength(20), FieldOrder(20), FieldTrim(TrimMode.Right)]
        public string HomePhone;

        /// <summary>Phone Type (Cell, Work, etc)</summary>
        /// <remarks></remarks>
        [StartPosition(252), FieldFixedLength(4), FieldOrder(21), FieldTrim(TrimMode.Right)]
        public string PhoneType1;

        /// <summary>Phone Number</summary>
        /// <remarks></remarks>
        [StartPosition(256), FieldFixedLength(20), FieldOrder(22), FieldTrim(TrimMode.Right)]
        public string PhoneNumber1;

        /// <summary>Phone Type (Cell, Work, etc)</summary>
        /// <remarks></remarks>
        [StartPosition(276), FieldFixedLength(4), FieldOrder(23), FieldTrim(TrimMode.Right)]
        public string PhoneType2;

        /// <summary>Phone Number</summary>
        /// <remarks></remarks>
        [StartPosition(280), FieldFixedLength(20), FieldOrder(24), FieldTrim(TrimMode.Right)]
        public string PhoneNumber2;

        /// <summary>Phone Type (Cell, Work, etc)</summary>
        /// <remarks></remarks>
        [StartPosition(300), FieldFixedLength(4), FieldOrder(25), FieldTrim(TrimMode.Right)]
        public string PhoneType3;

        /// <summary>Phone Number</summary>
        /// <remarks></remarks>
        [StartPosition(304), FieldFixedLength(20), FieldOrder(26), FieldTrim(TrimMode.Right)]
        public string PhoneNumber3;

        /// <summary>Phone Type (Cell, Work, etc)</summary>
        /// <remarks></remarks>
        [StartPosition(324), FieldFixedLength(4), FieldOrder(27), FieldTrim(TrimMode.Right)]
        public string PhoneType4;

        /// <summary>Phone Number</summary>
        /// <remarks></remarks>
        [StartPosition(328), FieldFixedLength(20), FieldOrder(28), FieldTrim(TrimMode.Right)]
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
