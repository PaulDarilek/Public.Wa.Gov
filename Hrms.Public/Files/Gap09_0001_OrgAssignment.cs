using FileHelpers;
using Hrms.Public.Converters;
using Hrms.Public.Interfaces;
using System;

namespace Hrms.Public.Files
{
    /// <summary>Gap09 Record type 0001 (Organizational Assignment) - Map Employee to Position</summary>
    [FixedLengthRecord(FixedMode.ExactLength)]
    public class Gap09_0001_OrgAssignment : IGap09Common, IFixedLengthFile
    {
        public const string RecordTypeDefault = "0001";
        public const int Total_Length = 271;

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

        /// <summary>Position Number</summary>
        /// <remarks>Assigned by SAP</remarks>
        [StartPosition(69), FieldFixedLength(8), FieldOrder(12), FieldTrim(TrimMode.Right)]
        public string PositionNumber;

        /// <summary>Position Code</summary>
        /// <remarks>Originally from PAY1</remarks>
        [StartPosition(77), FieldFixedLength(12), FieldOrder(13), FieldTrim(TrimMode.Right)]
        public string PositionCode;

        /// <summary>Position Title</summary>
        [StartPosition(89), FieldFixedLength(40), FieldOrder(14), FieldTrim(TrimMode.Right)]
        public string PositionTitle;

        /// <summary>Job Class</summary>
        /// <remarks>Assigned by SAP</remarks>
        [StartPosition(129), FieldFixedLength(8), FieldOrder(15)]
        public string JobClass;

        /// <summary>Job Class</summary>
        /// <remarks>Originally from PAY1</remarks>
        [StartPosition(137), FieldFixedLength(12), FieldOrder(16)]
        public string JobClassCode;

        /// <summary>Job Title</summary>
        [StartPosition(149), FieldFixedLength(40), FieldOrder(17), FieldTrim(TrimMode.Right)]
        public string JobTitle;

        /// <summary>Organization Unit</summary>
        /// <remarks>Assigned by SAP</remarks>
        [StartPosition(189), FieldFixedLength(8), FieldOrder(18), FieldTrim(TrimMode.Right)]
        public string OrganizationUnit;

        /// <summary>Organization Code</summary>
        /// <remarks>HRP1000 SHORT Org Code. Originally from PAY1</remarks>
        [StartPosition(197), FieldFixedLength(12), FieldOrder(19), FieldTrim(TrimMode.Right)]
        public string OrganizationCode;

        /// <summary>Organization Title</summary>
        [StartPosition(209), FieldFixedLength(40), FieldOrder(20), FieldTrim(TrimMode.Right)]
        public string OrganizationTitle;

        /// <summary>Time Administrator (Attendance Unit)</summary>
        /// <remarks>Originally from PAY1</remarks>
        [StartPosition(249), FieldFixedLength(3), FieldOrder(21)]
        public string TimeAdministrator;

        /// <summary>Employee Group and Work Contract Type = Appointment Status</summary>
        [StartPosition(252), FieldFixedLength(2), FieldOrder(22)]
        public string WorkContractType;

        /// <summary>Appointment Org Unit code</summary>
        [StartPosition(254), FieldFixedLength(14), FieldOrder(23), FieldTrim(TrimMode.Right)]
        public string OrganizationKey;

        /// <summary>Business Area</summary>
        [StartPosition(268), FieldFixedLength(4), FieldOrder(24)]
        public string BusinessAreaCode;

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
