using FileHelpers;
using Hrms.Public.Abstract;
using System;

namespace Hrms.Public.Files
{
    /// <summary>Gap09 Record type 0006 Addresses (Multiple Records Permissible)</summary>
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class Gap09_0006_Address : Gap09Common, IFixedLengthFile
    {
        public const string RecordTypeDefault = "0006";
        public const int Total_Length = 347;

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
