using FileHelpers;
using Hrms.Public.Converters;
using Hrms.Public.Interfaces;
using System;

namespace Hrms.Public.Files
{
    [FixedLengthRecord(FixedMode.ExactLength)]
    public class Gap10Position : Gap10Common, IFixedLengthFile
    {
        public const string RecordTypeDefault = "1000";
        public const int Total_Length = 714;


        /// <summary>Effective Date</summary>
        [FieldOrder(6)]
        [StartPosition(69)]
        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime EffectiveDate { get; set; }

        /// <summary>End Date</summary>
        [FieldOrder(7)]
        [StartPosition(77)]
        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime EndDate { get; set; }

        /// <summary>Job ID</summary>
        [FieldOrder(8)]
        [StartPosition(85)]
        [FieldFixedLength(8)]
        public string JobID { get; set; }

        /// <summary>Job Title (Legacy)</summary>
        [FieldOrder(9)]
        [StartPosition(93)]
        [FieldFixedLength(12)]
        public string JobTitleLegacy { get; set; }

        /// <summary>Job Title</summary>
        [FieldOrder(10)]
        [StartPosition(105)]
        [FieldFixedLength(40)]
        public string JobTitle { get; set; }

        /// <summary>Org Unit ID</summary>
        [FieldOrder(11)]
        [StartPosition(145, "NUMC(8)")]
        [FieldFixedLength(8)]
        public string OrgUnitId { get; set; }

        /// <summary>Org Unit Title-Legacy</summary>
        [FieldOrder(12)]
        [StartPosition(153)]
        [FieldFixedLength(12)]
        public string OrgUnitTitleLegacy { get; set; }

        /// <summary>Org Unit Title</summary>
        [FieldOrder(13)]
        [StartPosition(165)]
        [FieldFixedLength(40)]
        public string OrgUnitTitle { get; set; }

        /// <summary>Pay Grade Type</summary>
        [FieldOrder(14)]
        [StartPosition(205)]
        [FieldFixedLength(2)]
        public string PayGradeType { get; set; }

        /// <summary>Pay Grade Area</summary>
        [FieldOrder(15)]
        [StartPosition(207)]
        [FieldFixedLength(2)]
        public string PayGradeArea { get; set; }

        /// <summary>Pay Grade</summary>
        [FieldOrder(16)]
        [StartPosition(209)]
        [FieldFixedLength(8)]
        public string PayGrade { get; set; }

        /// <summary>Pay Grade Level From</summary>
        [FieldOrder(17)]
        [StartPosition(217)]
        [FieldFixedLength(2)]
        public string PayGradeLevelFrom { get; set; }

        /// <summary>Pay Grade Level To</summary>
        [FieldOrder(18)]
        [StartPosition(219)]
        [FieldFixedLength(2)]
        public string PayGradeLevelTo { get; set; }

        /// <summary>Minimum Salary</summary>
        [FieldOrder(19)]
        [StartPosition(221, "DEC(11,2)")]
        [FieldFixedLength(14)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 11, 2)]
        public decimal MinimumSalary { get; set; }

        /// <summary>Maximum Salary</summary>
        [FieldOrder(20)]
        [StartPosition(235, "DEC(11,2)")]
        [FieldFixedLength(14)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 11, 2)]
        public decimal MaximumSalary { get; set; }

        /// <summary>Vacancy Start</summary>
        [FieldOrder(21)]
        [StartPosition(249)]
        [FieldFixedLength(8)]
        public string VacancyStart { get; set; }

        /// <summary>Vacancy End</summary>
        [FieldOrder(22)]
        [StartPosition(257)]
        [FieldFixedLength(8)]
        public string VacancyEnd { get; set; }

        /// <summary>Vacancy Open</summary>
        /// <remarks>'X' = Open, ' '=filled</remarks>
        [FieldOrder(23)]
        [StartPosition(265)]
        [FieldFixedLength(1)]
        [FieldConverter(typeof(BoolConverter), "X", " ")]
        public bool? VacancyOpen { get; set; }

        /// <summary>Company Code</summary>
        [FieldOrder(24)]
        [StartPosition(266)]
        [FieldFixedLength(4)]
        public string CompanyCode { get; set; }

        /// <summary>Business Area</summary>
        [FieldOrder(25)]
        [StartPosition(270)]
        [FieldFixedLength(4)]
        public string BusinessArea { get; set; }

        /// <summary>Personnel Subarea</summary>
        [FieldOrder(26)]
        [StartPosition(274)]
        [FieldFixedLength(4)]
        public string PersonnelSubArea { get; set; }

        /// <summary>Employee Group</summary>
        [FieldOrder(27)]
        [StartPosition(278)]
        [FieldFixedLength(1)]
        public string EmployeeGroup { get; set; }

        /// <summary>Employee Sub Group</summary>
        [FieldOrder(28)]
        [StartPosition(279)]
        [FieldFixedLength(2)]
        public string EmployeeSubGroup { get; set; }

        /// <summary>Address Supplement-Main</summary>
        /// <remarks>(c/o)</remarks>
        [FieldOrder(29)]
        [StartPosition(281)]
        [FieldFixedLength(25)]
        [FieldTrim(TrimMode.Right)]
        public string AddressSupplementMain { get; set; }

        /// <summary>House number and street (Main)</summary>
        [FieldOrder(30)]
        [StartPosition(306)]
        [FieldFixedLength(35)]
        [FieldTrim(TrimMode.Right)]
        public string HouseNumberStreetMain { get; set; }

        /// <summary>House number (Main)</summary>
        [FieldOrder(31)]
        [StartPosition(341)]
        [FieldFixedLength(6)]
        [FieldTrim(TrimMode.Right)]
        public string HouseNumberMain { get; set; }

        /// <summary>Street (Main)</summary>
        [FieldOrder(32)]
        [StartPosition(347)]
        [FieldFixedLength(30)]
        [FieldTrim(TrimMode.Right)]
        public string StreetMain { get; set; }

        /// <summary>Postal Code (Main)</summary>
        [FieldOrder(33)]
        [StartPosition(377)]
        [FieldFixedLength(10)]
        [FieldTrim(TrimMode.Right)]
        public string PostalCodeMain { get; set; }

        /// <summary>City (Main)</summary>
        [FieldOrder(34)]
        [StartPosition(387)]
        [FieldFixedLength(40)]
        [FieldTrim(TrimMode.Right)]
        public string CityMain { get; set; }

        /// <summary>Country (Main)</summary>
        [FieldOrder(35)]
        [StartPosition(427)]
        [FieldFixedLength(3)]
        [FieldTrim(TrimMode.Right)]
        public string CountryMain { get; set; }

        /// <summary>Room Number (Main)</summary>
        [FieldOrder(36)]
        [StartPosition(430)]
        [FieldFixedLength(8)]
        [FieldTrim(TrimMode.Right)]
        public string RoomNumberMain { get; set; }

        /// <summary>Telephone Number (Main)</summary>
        [FieldOrder(37)]
        [StartPosition(438)]
        [FieldFixedLength(25)]
        [FieldTrim(TrimMode.Right)]
        public string TelephoneNumberMain { get; set; }

        /// <summary>Fax Number (Main)</summary>
        [FieldOrder(38)]
        [StartPosition(463)]
        [FieldFixedLength(25)]
        [FieldTrim(TrimMode.Right)]
        public string FaxNumberMain { get; set; }

        /// <summary>Address Supplement-Temp</summary>
        /// <remarks>(c/o)</remarks>
        [FieldOrder(39)]
        [StartPosition(488)]
        [FieldFixedLength(25)]
        [FieldTrim(TrimMode.Right)]
        public string AddressSupplementTemp { get; set; }

        /// <summary>House number and street (Temp)</summary>
        [FieldOrder(40)]
        [StartPosition(513)]
        [FieldFixedLength(35)]
        [FieldTrim(TrimMode.Right)]
        public string HouseNumberStreetTemp { get; set; }

        /// <summary>House number (Temp)</summary>
        [FieldOrder(41)]
        [StartPosition(548)]
        [FieldFixedLength(6)]
        [FieldTrim(TrimMode.Right)]
        public string HouseNumberTemp { get; set; }

        /// <summary>Street (Temp)</summary>
        [FieldOrder(42)]
        [StartPosition(554)]
        [FieldFixedLength(30)]
        [FieldTrim(TrimMode.Right)]
        public string StreetTemp { get; set; }

        /// <summary>Postal Code (Temp)</summary>
        [FieldOrder(43)]
        [StartPosition(584)]
        [FieldFixedLength(10)]
        [FieldTrim(TrimMode.Right)]
        public string PostalCodeTemp { get; set; }

        /// <summary>City (Temp)</summary>
        [FieldOrder(44)]
        [StartPosition(594)]
        [FieldFixedLength(40)]
        [FieldTrim(TrimMode.Right)]
        public string CityTemp { get; set; }

        /// <summary>Country (Temp)</summary>
        [FieldOrder(45)]
        [StartPosition(634)]
        [FieldFixedLength(3)]
        [FieldTrim(TrimMode.Right)]
        public string CountryTemp { get; set; }

        /// <summary>Room Number (Temp)</summary>
        [FieldOrder(46)]
        [StartPosition(637)]
        [FieldFixedLength(8)]
        [FieldTrim(TrimMode.Right)]
        public string RoomNumberTemp { get; set; }

        /// <summary>Telephone Number (Temp)</summary>
        [FieldOrder(47)]
        [StartPosition(645)]
        [FieldFixedLength(25)]
        [FieldTrim(TrimMode.Right)]
        public string TelephoneNumberTemp { get; set; }

        /// <summary>Fax Number (Temp)</summary>
        [FieldOrder(48)]
        [StartPosition(670)]
        [FieldFixedLength(25)]
        [FieldTrim(TrimMode.Right)]
        public string FaxNumberTemp { get; set; }

        /// <summary>Corporate Officer</summary>
        [FieldOrder(49)]
        [StartPosition(695)]
        [FieldFixedLength(1)]
        public string CorporateOfficer { get; set; }

        /// <summary>WC State</summary>
        [FieldOrder(50)]
        [StartPosition(696)]
        [FieldFixedLength(3)]
        [FieldTrim(TrimMode.Right)]
        public string WCState { get; set; }

        /// <summary>WC Classification Code</summary>
        [FieldOrder(51)]
        [StartPosition(699)]
        [FieldFixedLength(4)]
        [FieldTrim(TrimMode.Right)]
        public string WCClassificationCode { get; set; }

        /// <summary>Assignment Pay</summary>
        /// <remarks>'X' = Assign Pay, ' '=Not Assign Pay</remarks>
        [FieldOrder(52)]
        [StartPosition(703)]
        [FieldFixedLength(1)]
        [FieldConverter(typeof(BoolConverter), "X", " ")]
        public bool? AssignmentPay { get; set; }

        /// <summary>Dual Language</summary>
        /// <remarks>'X' = Dual Language, ' '=Not Dual Language</remarks>
        [FieldOrder(53)]
        [StartPosition(704)]
        [FieldFixedLength(1)]
        [FieldConverter(typeof(BoolConverter), "X", " ")]
        public bool? DualLanguage { get; set; }

        /// <summary>Budgeted</summary>
        /// <remarks>'X' = Budgeted, ' '=Not Budgeted</remarks>
        [FieldOrder(54)]
        [StartPosition(705)]
        [FieldFixedLength(1)]
        [FieldConverter(typeof(BoolConverter), "X", " ")]
        public bool? Budgeted { get; set; }

        /// <summary>Retirement Eligible</summary>
        /// <remarks>'X' = Retirement Eligible, ' '=Not Eligible</remarks>
        [FieldOrder(55)]
        [StartPosition(706)]
        [FieldFixedLength(1)]
        [FieldConverter(typeof(BoolConverter), "X", " ")]
        public bool? RetirementEligible { get; set; }

        /// <summary>Supervisors Position Id</summary>
        [FieldOrder(56)]
        [StartPosition(707)]
        [FieldFixedLength(8)]
        public string SupervisorsPositionId { get; set; }

        public int GetRecordLength() => Total_Length;

        public bool IsPossibleRecord(string record)
        {
            return !string.IsNullOrEmpty(record) && record.Length == Total_Length && record.Substring(64, 4) == RecordTypeDefault;
        }
            
    }

}
