using FileHelpers;
using Hrms.Public.Converters;
using Hrms.Public.Interfaces;
using System;

namespace Hrms.Public.Files
{
    /// <summary>Gap09 Record type 0023 (Previous/ Other Employers) - Identifies Concurrent Employment/Dual Appointment - Multiple records permissible</summary>
    [FixedLengthRecord(FixedMode.ExactLength)]
    public class Gap09_0023_Employers : IGap09Common, IFixedLengthFile
    {
        public const string RecordTypeDefault = "0023";
        public const int Total_Length = 121;

        #region IGap09Common

        /// <summary>Personnel Area</summary>
        /// <remarks>Agency/Sub equivalent</remarks>
        [FieldOrder(1)]
        [StartPosition(1)]
        [FieldFixedLength(4)]
        public string PersonnelArea { get; set; }

        /// <summary>Personnel Sub Area (Bargaining Unit equivalent)</summary>
        [FieldOrder(2)]
        [StartPosition(5)]
        [FieldFixedLength(4)]
        public string PersonnelSubArea { get; set; }

        /// <summary>Employee Group (Permanent, Temporary, etc)</summary>
        [FieldOrder(3)]
        [StartPosition(9)]
        [FieldFixedLength(1)]
        public string EmployeeGroup { get; set; }

        /// <summary>Employee Sub Group (Monthly, Hourly, etc.)</summary>
        [FieldOrder(4)]
        [StartPosition(10)]
        [FieldFixedLength(2)]
        public string EmployeeSubGroup { get; set; }

        /// <summary>Personnel Number / Employee Number</summary>
        /// <remarks>PA0001 PERNR Personnel Number</remarks>
        [FieldOrder(5)]
        [StartPosition(12)]
        [FieldFixedLength(8)]
        public string PersonnelNumber { get; set; }

        /// <summary>Social Security Number</summary>
        /// <remarks>PA0002 PERID Social Security Number</remarks>
        [FieldOrder(6)]
        [StartPosition(20)]
        [FieldFixedLength(9)]
        public string SSN { get; set; }

        /// <summary>Date of last change</summary>
        /// <remarks>YYYYMMDD PA0000 AEDTM Date of Last Change</remarks>
        [FieldOrder(7)]
        [StartPosition(29)]
        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime DateChanged { get; set; }

        /// <summary>Name of person who changed object</summary>
        /// <remarks>PA0000 UNAME Name of person who changed object</remarks>
        [FieldOrder(8)]
        [StartPosition(37)]
        [FieldFixedLength(12)]
        [FieldTrim(TrimMode.Right)]
        public string PersonChanged { get; set; }

        /// <summary>Record Type</summary>
        /// <remarks>Record Type identifies the Gap09 subtype</remarks>
        [FieldOrder(9)]
        [StartPosition(49)]
        [FieldFixedLength(4)]
        public string RecordType { get; set; }

        /// <summary>CCYYMMDD Start Date</summary>
        /// <remarks>CCYYMMDD DATS(8) PA0000 BEGDA Start date</remarks>
        [FieldOrder(10)]
        [StartPosition(53)]
        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime DateEffective { get; set; }

        /// <summary>End Date</summary>
        /// <remarks>CCYYMMDD PA0000 ENDDA End Date</remarks>
        [FieldOrder(11)]
        [StartPosition(61)]
        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime EndDate { get; set; }

        #endregion

        /// <summary>Name of Employer</summary>
        [FieldOrder(12)]
        [FieldFixedLength(20)]
        [FieldTrim(TrimMode.Right)]
        [StartPosition(69, "Name of Employer")]
        public string EmployerName { get; set; }

        /// <summary>City</summary>
        [FieldOrder(13)]
        [FieldFixedLength(25)]
        [FieldTrim(TrimMode.Right)]
        [StartPosition(89, "City")]
        public string City { get; set; }

        /// <summary>Job at former employers</summary>
        /// <remarks>NUMC(8)</remarks>
        [FieldOrder(14)]
        [StartPosition(114)]
        [FieldFixedLength(8)]
        [FieldTrim(TrimMode.Right)]
        public string Job { get; set; }

        /// <summary>Undefined 40 spaces that seem to be on downloaded file</summary>
        /// <remarks>Do not use</remarks>
        [FieldOrder(99)]
        [StartPosition(122)]
        [FieldFixedLength(40)]
        [FieldTrim(TrimMode.Right)]
        [FieldOptional]
        public string Undefined { get; set; }

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
