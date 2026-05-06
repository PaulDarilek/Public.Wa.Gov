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
        [StartPosition(69), FieldFixedLength(8), FieldOrder(6), FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime EffectiveDate { get; set; }

        /// <summary>End Date</summary>
        [StartPosition(77), FieldFixedLength(8), FieldOrder(7), FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime EndDate { get; set; }

        /// <summary>Job ID</summary>
        [StartPosition(85), FieldFixedLength(8), FieldOrder(8)]
        public string JobID { get; set; }

        /// <summary>Job Title (Legacy)</summary>
        [StartPosition(93), FieldFixedLength(12), FieldOrder(9)]
        public string JobTitleLegacy { get; set; }

        /// <summary>Job Title</summary>
        [StartPosition(105), FieldFixedLength(40), FieldOrder(10)]
        public string JobTitle { get; set; }

        /// <summary>Org Unit ID</summary>
        /// <remarks>NUMC(8)</remarks>
        [StartPosition(145), FieldFixedLength(8), FieldOrder(11)]
        public string OrgUnitId { get; set; }

        /// <summary>Org Unit Title-Legacy</summary>
        [StartPosition(153), FieldFixedLength(12), FieldOrder(12)]
        public string OrgUnitTitleLegacy { get; set; }

        /// <summary>Org Unit Title</summary>
        [StartPosition(165), FieldFixedLength(40), FieldOrder(13)]
        public string OrgUnitTitle { get; set; }

        /// <summary>Pay Grade Type</summary>
        [StartPosition(205), FieldFixedLength(2), FieldOrder(14)]
        public string PayGradeType { get; set; }

        /// <summary>Pay Grade Area</summary>
        [StartPosition(207), FieldFixedLength(2), FieldOrder(15)]
        public string PayGradeArea { get; set; }

        /// <summary>Pay Grade</summary>
        [StartPosition(209), FieldFixedLength(8), FieldOrder(16)]
        public string PayGrade { get; set; }

        /// <summary>Pay Grade Level From</summary>
        [StartPosition(217), FieldFixedLength(2), FieldOrder(17)]
        public string PayGradeLevelFrom { get; set; }

        /// <summary>Pay Grade Level To</summary>
        [StartPosition(219), FieldFixedLength(2), FieldOrder(18)]
        public string PayGradeLevelTo { get; set; }

        /// <summary>Minimum Salary</summary>
        /// <remarks>DEC(11,2)</remarks>
        [StartPosition(221), FieldFixedLength(14), FieldOrder(19), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 11, 2)]
        public decimal MinimumSalary { get; set; }

        /// <summary>Maximum Salary</summary>
        /// <remarks>DEC(11,2)</remarks>
        [StartPosition(235), FieldFixedLength(14), FieldOrder(20), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 11, 2)]
        public decimal MaximumSalary { get; set; }

        /// <summary>Vacancy Start</summary>
        [StartPosition(249), FieldFixedLength(8), FieldOrder(21)]
        public string VacancyStart { get; set; }

        /// <summary>Vacancy End</summary>
        [StartPosition(257), FieldFixedLength(8), FieldOrder(22)]
        public string VacancyEnd { get; set; }

        /// <summary>Vacancy Open</summary>
        /// <remarks>'X' = Open, ' '=filled</remarks>
        [StartPosition(265), FieldFixedLength(1), FieldOrder(23), FieldConverter(typeof(BoolConverter), "X", " ")]
        public bool? VacancyOpen { get; set; }

        /// <summary>Company Code</summary>
        [StartPosition(266), FieldFixedLength(4), FieldOrder(24)]
        public string CompanyCode { get; set; }

        /// <summary>Business Area</summary>
        [StartPosition(270), FieldFixedLength(4), FieldOrder(25)]
        public string BusinessArea { get; set; }

        /// <summary>Personnel Subarea</summary>
        [StartPosition(274), FieldFixedLength(4), FieldOrder(26)]
        public string PersonnelSubArea { get; set; }

        /// <summary>Employee Group</summary>
        [StartPosition(278), FieldFixedLength(1), FieldOrder(27)]
        public string EmployeeGroup { get; set; }

        /// <summary>Employee Sub Group</summary>
        [StartPosition(279), FieldFixedLength(2), FieldOrder(28)]
        public string EmployeeSubGroup { get; set; }

        /// <summary>Address Supplement-Main</summary>
        /// <remarks>(c/o)</remarks>
        [StartPosition(281), FieldFixedLength(25), FieldOrder(29), FieldTrim(TrimMode.Right)]
        public string AddressSupplementMain { get; set; }

        /// <summary>House number and street (Main)</summary>
        [StartPosition(306), FieldFixedLength(35), FieldOrder(30), FieldTrim(TrimMode.Right)]
        public string HouseNumberStreetMain { get; set; }

        /// <summary>House number (Main)</summary>
        [StartPosition(341), FieldFixedLength(6), FieldOrder(31), FieldTrim(TrimMode.Right)]
        public string HouseNumberMain { get; set; }

        /// <summary>Street (Main)</summary>
        [StartPosition(347), FieldFixedLength(30), FieldOrder(32), FieldTrim(TrimMode.Right)]
        public string StreetMain { get; set; }

        /// <summary>Postal Code (Main)</summary>
        [StartPosition(377), FieldFixedLength(10), FieldOrder(33), FieldTrim(TrimMode.Right)]
        public string PostalCodeMain { get; set; }

        /// <summary>City (Main)</summary>
        [StartPosition(387), FieldFixedLength(40), FieldOrder(34), FieldTrim(TrimMode.Right)]
        public string CityMain { get; set; }

        /// <summary>Country (Main)</summary>
        [StartPosition(427), FieldFixedLength(3), FieldOrder(35), FieldTrim(TrimMode.Right)]
        public string CountryMain { get; set; }

        /// <summary>Room Number (Main)</summary>
        [StartPosition(430), FieldFixedLength(8), FieldOrder(36), FieldTrim(TrimMode.Right)]
        public string RoomNumberMain { get; set; }

        /// <summary>Telephone Number (Main)</summary>
        [StartPosition(438), FieldFixedLength(25), FieldOrder(37), FieldTrim(TrimMode.Right)]
        public string TelephoneNumberMain { get; set; }

        /// <summary>Fax Number (Main)</summary>
        [StartPosition(463), FieldFixedLength(25), FieldOrder(38), FieldTrim(TrimMode.Right)]
        public string FaxNumberMain { get; set; }

        /// <summary>Address Supplement-Temp</summary>
        /// <remarks>(c/o)</remarks>
        [StartPosition(488), FieldFixedLength(25), FieldOrder(39), FieldTrim(TrimMode.Right)]
        public string AddressSupplementTemp { get; set; }

        /// <summary>House number and street (Temp)</summary>
        [StartPosition(513), FieldFixedLength(35), FieldOrder(40), FieldTrim(TrimMode.Right)]
        public string HouseNumberStreetTemp { get; set; }

        /// <summary>House number (Temp)</summary>
        [StartPosition(548), FieldFixedLength(6), FieldOrder(41), FieldTrim(TrimMode.Right)]
        public string HouseNumberTemp { get; set; }

        /// <summary>Street (Temp)</summary>
        [StartPosition(554), FieldFixedLength(30), FieldOrder(42), FieldTrim(TrimMode.Right)]
        public string StreetTemp { get; set; }

        /// <summary>Postal Code (Temp)</summary>
        [StartPosition(584), FieldFixedLength(10), FieldOrder(43), FieldTrim(TrimMode.Right)]
        public string PostalCodeTemp { get; set; }

        /// <summary>City (Temp)</summary>
        [StartPosition(594), FieldFixedLength(40), FieldOrder(44), FieldTrim(TrimMode.Right)]
        public string CityTemp { get; set; }

        /// <summary>Country (Temp)</summary>
        [StartPosition(634), FieldFixedLength(3), FieldOrder(45), FieldTrim(TrimMode.Right)]
        public string CountryTemp { get; set; }

        /// <summary>Room Number (Temp)</summary>
        [StartPosition(637), FieldFixedLength(8), FieldOrder(46), FieldTrim(TrimMode.Right)]
        public string RoomNumberTemp { get; set; }

        /// <summary>Telephone Number (Temp)</summary>
        [StartPosition(645), FieldFixedLength(25), FieldOrder(47), FieldTrim(TrimMode.Right)]
        public string TelephoneNumberTemp { get; set; }

        /// <summary>Fax Number (Temp)</summary>
        [StartPosition(670), FieldFixedLength(25), FieldOrder(48), FieldTrim(TrimMode.Right)]
        public string FaxNumberTemp { get; set; }

        /// <summary>Corporate Officer</summary>
        [StartPosition(695), FieldFixedLength(1), FieldOrder(49)]
        public string CorporateOfficer { get; set; }

        /// <summary>WC State</summary>
        [StartPosition(696), FieldFixedLength(3), FieldOrder(50), FieldTrim(TrimMode.Right)]
        public string WCState { get; set; }

        /// <summary>WC Classification Code</summary>
        [StartPosition(699), FieldFixedLength(4), FieldOrder(51), FieldTrim(TrimMode.Right)]
        public string WCClassificationCode { get; set; }

        /// <summary>Assignment Pay</summary>
        /// <remarks>'X' = Assign Pay, ' '=Not Assign Pay</remarks>
        [StartPosition(703), FieldFixedLength(1), FieldOrder(52), FieldConverter(typeof(BoolConverter), "X", " ")]
        public bool? AssignmentPay { get; set; }

        /// <summary>Dual Language</summary>
        /// <remarks>'X' = Dual Language, ' '=Not Dual Language</remarks>
        [StartPosition(704), FieldFixedLength(1), FieldOrder(53), FieldConverter(typeof(BoolConverter), "X", " ")]
        public bool? DualLanguage { get; set; }

        /// <summary>Budgeted</summary>
        /// <remarks>'X' = Budgeted, ' '=Not Budgeted</remarks>
        [StartPosition(705), FieldFixedLength(1), FieldOrder(54), FieldConverter(typeof(BoolConverter), "X", " ")]
        public bool? Budgeted { get; set; }

        /// <summary>Retirement Eligible</summary>
        /// <remarks>'X' = Retirement Eligible, ' '=Not Eligible</remarks>
        [StartPosition(706), FieldFixedLength(1), FieldOrder(55), FieldConverter(typeof(BoolConverter), "X", " ")]
        public bool? RetirementEligible { get; set; }

        /// <summary>Supervisors Position Id</summary>
        [StartPosition(707), FieldFixedLength(8), FieldOrder(56)]
        public string SupervisorsPositionId { get; set; }

        public int GetRecordLength() => Total_Length;

        public bool IsPossibleRecord(string record)
        {
            return !string.IsNullOrEmpty(record) && record.Length == Total_Length && record.Substring(64, 4) == RecordTypeDefault;
        }

    }

}
