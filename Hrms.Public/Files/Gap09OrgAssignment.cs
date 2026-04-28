using FileHelpers;
using Hrms.Public.Abstract;
using System;

namespace Hrms.Public.Files
{
    /// <summary>Gap09 Record type 0001 (Organizational Assignment) - Map Employee to Position</summary>
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class Gap09OrgAssignment
    {
        public const int Total_Length = 271;

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
        [FieldSpec(4, 49, "Constant '0001'")]
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

        /// <summary>Position Number</summary>
        [FieldFixedLength(8)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(8, 69, "Position Number (assigned by SAP)")]
        public string PositionNumber;

        /// <summary>Position Code</summary>
        [FieldFixedLength(12)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(12, 77, "Position Number (originally from PAY1)")]
        public string PositionCode;

        /// <summary>Position Title</summary>
        [FieldFixedLength(40)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(40, 89, "Position Title")]
        public string PositionTitle;

        /// <summary>Job Class</summary>
        [FieldFixedLength(8)]
        [FieldSpec(8, 129, "Job Key (assigned by SAP)")]
        public string JobClass;

        /// <summary>Job Class</summary>
        [FieldFixedLength(8)]
        [FieldSpec(8, 137, "Job Class Code (originally from PAY1)")]
        public string JobClassCode;

        /// <summary>Job Title</summary>
        [FieldFixedLength(40)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(40, 149, "Job Title")]
        public string JobTitle;

        /// <summary>Organization Unit</summary>
        [FieldFixedLength(8)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(8, 189, "Org. Unit (assigned by SAP)")]
        public string OrganizationUnit;

        /// <summary>Organization Code</summary>
        [FieldFixedLength(12)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(12, 197, "Organization Code CHAR (12) HRP1000 SHORT Org Code originally (from PAY1)")]
        public string OrganizationCode;

        /// <summary>Organization Title</summary>
        [FieldFixedLength(40)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(40, 209, "Organization Title")]
        public string OrganizationTitle;

        /// <summary>Time Administrator (Attendance Unit)</summary>
        [FieldFixedLength(3)]
        [FieldSpec(3, 249, "Time Administrator / Attendance Unit (originally from PAY1)")]
        public string TimeAdministrator;

        /// <summary>Time Administrator (Attendance Unit)</summary>
        [FieldFixedLength(2)]
        [FieldSpec(2, 252, "Employee Group and Work Contract Type = Appointment Status")]
        public string WorkContractType;

        /// <summary>Organization Code</summary>
        [FieldFixedLength(14)]
        [FieldTrim(TrimMode.Right)]
        [FieldSpec(14, 254, "Appointment Org Unit code")]
        public string OrganizationKey;

        /// <summary>Business Area</summary>
        [FieldFixedLength(4)]
        [FieldSpec(4, 268, "Business Area Code")]
        public string BusinessAreaCode;
    }
}
