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

        /// <summary>Employee Name</summary>
        [StartPosition(69), FieldFixedLength(30), FieldOrder(12), FieldTrim(TrimMode.Right)]
        public string EmployeeName;

        /// <summary>Last Name</summary>
        [StartPosition(99), FieldFixedLength(40), FieldOrder(13), FieldTrim(TrimMode.Right)]
        public string LastName;

        /// <summary>First Name</summary>
        [StartPosition(139), FieldFixedLength(40), FieldOrder(14), FieldTrim(TrimMode.Right)]
        public string FirstName;

        /// <summary>Middle Name</summary>
        [StartPosition(179), FieldFixedLength(40), FieldOrder(15), FieldTrim(TrimMode.Right)]
        public string MiddleName;

        /// <summary>Middle Name</summary>
        /// <remarks>Alias (Also Known As)</remarks>
        [StartPosition(219), FieldFixedLength(40), FieldOrder(16), FieldTrim(TrimMode.Right)]
        public string Alias;

        /// <summary>Date of Birth</summary>
        /// <remarks>CCYYMMDD Birth Date</remarks>
        [StartPosition(259), FieldFixedLength(8), FieldOrder(17), FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime DateOfBirth;

        /// <summary>Sex</summary>
        /// <remarks>Sex Assigned at Birth (Code to identify Male or Female)</remarks>
        [StartPosition(267), FieldFixedLength(1), FieldOrder(18)]
        public string Sex;

        /// <summary>Marital Status code</summary>
        /// <remarks>Marital Status (Married, Single, Divorced, etc)</remarks>
        [StartPosition(268), FieldFixedLength(1), FieldOrder(19)]
        public string MaritalStatus;

        /// <summary>Marital Status Date</summary>
        /// <remarks>CCYYMMDD Marital Status Date</remarks>
        [StartPosition(269), FieldFixedLength(8), FieldOrder(20), FieldConverter(typeof(DateWithZeroConverter))]
        public DateTime? MaritalStatusDate;

        /// <summary>Suffix (Jr, Sr, Title)</summary>
        /// <remarks>Title: Jr, Sr</remarks>
        [StartPosition(277), FieldFixedLength(15), FieldOrder(21), FieldTrim(TrimMode.Right)]
        public string Suffix;

        /// <summary>Gender Identity</summary>
        /// <remarks>Gender Identity Code</remarks>
        [StartPosition(292), FieldFixedLength(1), FieldOrder(22)]
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
