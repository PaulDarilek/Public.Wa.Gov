using FileHelpers;
using Hrms.Public.Abstract;
using Hrms.Public.Converters;
using System;

namespace Hrms.Public.Files
{
    /// <summary>Gap09 Record type 0002 (Personal Data)</summary>
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class Gap09_0002_PersonalData : Gap09Common, IFixedLengthFile
    {
        public const string RecordTypeDefault = "0002";
        public const int Total_Length = 292;

        /// <summary>Employee Name</summary>
        [FieldOrder(12)]
        [FieldFixedLength(30)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(30, 69, "Employee Name")]
        public string EmployeeName;

        /// <summary>Last Name</summary>
        [FieldOrder(13)]
        [FieldFixedLength(40)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(40, 99, "Last Name")]
        public string LastName;

        /// <summary>First Name</summary>
        [FieldOrder(14)]
        [FieldFixedLength(40)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(40, 139, "First Name")]
        public string FirstName;

        /// <summary>Middle Name</summary>
        [FieldOrder(15)]
        [FieldFixedLength(40)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(40, 179, "Middle Name")]
        public string MiddleName;

        /// <summary>Middle Name</summary>
        [FieldOrder(16)]
        [FieldFixedLength(40)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(40, 179, "Alias (Also Known As)")]
        public string Alias;

        /// <summary>Date of Birth</summary>
        [FieldOrder(17)]
        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        [FieldSpec(8, 259, "CCYYMMDD Birth Date")]
        public DateTime DateOfBirth;

        /// <summary>Sex</summary>
        [FieldOrder(18)]
        [FieldFixedLength(1)]
        [FieldSpec(1, 267, "Sex Assigned at Birth (Code to identify Male or Female)")]
        public char Sex;

        /// <summary>Marital Status code</summary>
        [FieldOrder(19)]
        [FieldFixedLength(1)]
        [FieldSpec(1, 268, "Marital Status (Married, Single, Divorced, etc)")]
        public char MaritalStatus;

        /// <summary>Marital Status Date</summary>
        [FieldOrder(20)]
        [FieldFixedLength(8)]
        [FieldConverter(typeof(DateWithZeroConverter))]
        [FieldSpec(8, 259, "CCYYMMDD Marital Status Date")]
        public DateTime? MaritalStatusDate;

        /// <summary>Suffix (Jr, Sr, Title)</summary>
        [FieldOrder(21)]
        [FieldFixedLength(15)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(15, 277, "Title: Jr, Sr")]
        public string Suffix;

        /// <summary>Gender Identity</summary>
        [FieldOrder(22)]
        [FieldFixedLength(1)]
        [FieldSpec(1, 292, "Gender Identity Code")]
        public char GenderIdentity;

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
