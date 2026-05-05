using FileHelpers;
using Hrms.Public.Converters;
using Hrms.Public.Interfaces;
using System;

namespace Hrms.Public.Files
{
    /// <summary>Gap09 Record type 0002 (Personal Data)</summary>
    [FixedLengthRecord(FixedMode.ExactLength)]
    public class Gap09_0002_PersonalData : IGap09Common, IFixedLengthFile
    {
        public const string RecordTypeDefault = "0002";
        public const int Total_Length = 292;

        #region IGap09Common

        /// <summary>Personnel Area (Agency/Sub equivalent)</summary>
        [FieldOrder(1)]
        [FieldFixedLength(4)]
        [StartPosition(1, "Personnel Area (Agency/Sub equivalent)")]
        public string PersonnelArea { get; set; }

        /// <summary>Personnel Sub Area (Bargaining Unit equivalent)</summary>
        [FieldOrder(2)]
        [FieldFixedLength(4)]
        [StartPosition(5, "Personnel Sub Area (Bargaining Unit equivalent)")]
        public string PersonnelSubArea { get; set; }

        /// <summary>Employee Group (Permanent, Temporary, etc)</summary>
        [FieldOrder(3)]
        [FieldFixedLength(1)]
        [StartPosition(9, "Employee Group (Permanent, Temporary, etc)")]
        public string EmployeeGroup { get; set; }

        /// <summary>Employee Sub Group (Monthly, Hourly, etc.)</summary>
        [FieldOrder(4)]
        [FieldFixedLength(2)]
        [StartPosition(10, "Employee Sub Group (Monthly, Hourly, etc.)")]
        public string EmployeeSubGroup { get; set; }

        /// <summary>Personnel Number / Employee Number</summary>
        [FieldOrder(5)]
        [FieldFixedLength(8)]
        [StartPosition(12, "PA0001 PERNR Personnel Number")]
        public string PersonnelNumber { get; set; }

        /// <summary>Social Security Number</summary>
        [FieldOrder(6)]
        [FieldFixedLength(9)]
        [StartPosition(20, "PA0002 PERID Social Security Number")]
        public string SSN { get; set; }

        /// <summary>Date of last change</summary>
        [FieldOrder(7)]
        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        [StartPosition(29, "YYYYMMDD PA0000 AEDTM Date of Last Change")]
        public DateTime DateChanged { get; set; }

        /// <summary>Name of person who changed object</summary>
        [FieldOrder(8)]
        [FieldFixedLength(12)]
        [StartPosition(37, "PA0000 UNAME Name of person who changed object")]
        [FieldTrim(TrimMode.Right)]
        public string PersonChanged { get; set; }

        /// <summary>Record Type</summary>
        [FieldOrder(9)]
        [FieldFixedLength(4)]
        [StartPosition(49, "Record Type identifies the Gap09 subtype")]
        public string RecordType { get; set; }

        /// <summary>CCYYMMDD Start Date</summary>
        [FieldOrder(10)]
        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        [StartPosition(53, "CCYYMMDD DATS(8) PA0000 BEGDA Start date")]
        public DateTime DateEffective { get; set; }

        /// <summary>End Date</summary>
        [FieldOrder(11)]
        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        [StartPosition(61, "CCYYMMDD PA0000 ENDDA End Date")]
        public DateTime EndDate { get; set; }

        #endregion

        /// <summary>Employee Name</summary>
        [FieldOrder(12)]
        [FieldFixedLength(30)]
        [FieldTrim(TrimMode.Right)]
        [StartPosition(69, "Employee Name")]
        public string EmployeeName;

        /// <summary>Last Name</summary>
        [FieldOrder(13)]
        [FieldFixedLength(40)]
        [FieldTrim(TrimMode.Right)]
        [StartPosition(99, "Last Name")]
        public string LastName;

        /// <summary>First Name</summary>
        [FieldOrder(14)]
        [FieldFixedLength(40)]
        [FieldTrim(TrimMode.Right)]
        [StartPosition(139, "First Name")]
        public string FirstName;

        /// <summary>Middle Name</summary>
        [FieldOrder(15)]
        [FieldFixedLength(40)]
        [FieldTrim(TrimMode.Right)]
        [StartPosition(179, "Middle Name")]
        public string MiddleName;

        /// <summary>Middle Name</summary>
        [FieldOrder(16)]
        [FieldFixedLength(40)]
        [FieldTrim(TrimMode.Right)]
        [StartPosition(219, "Alias (Also Known As)")]
        public string Alias;

        /// <summary>Date of Birth</summary>
        [FieldOrder(17)]
        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        [StartPosition(259, "CCYYMMDD Birth Date")]
        public DateTime DateOfBirth;

        /// <summary>Sex</summary>
        [FieldOrder(18)]
        [FieldFixedLength(1)]
        [StartPosition(267, "Sex Assigned at Birth (Code to identify Male or Female)")]
        public string Sex;

        /// <summary>Marital Status code</summary>
        [FieldOrder(19)]
        [FieldFixedLength(1)]
        [StartPosition(268, "Marital Status (Married, Single, Divorced, etc)")]
        public string MaritalStatus;

        /// <summary>Marital Status Date</summary>
        [FieldOrder(20)]
        [FieldFixedLength(8)]
        [FieldConverter(typeof(DateWithZeroConverter))]
        [StartPosition(269, "CCYYMMDD Marital Status Date")]
        public DateTime? MaritalStatusDate;

        /// <summary>Suffix (Jr, Sr, Title)</summary>
        [FieldOrder(21)]
        [FieldFixedLength(15)]
        [FieldTrim(TrimMode.Right)]
        [StartPosition(277, "Title: Jr, Sr")]
        public string Suffix;

        /// <summary>Gender Identity</summary>
        [FieldOrder(22)]
        [FieldFixedLength(1)]
        [StartPosition(292, "Gender Identity Code")]
        public string GenderIdentity;

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
