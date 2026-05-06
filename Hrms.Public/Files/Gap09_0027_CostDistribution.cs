using FileHelpers;
using Hrms.Public.Converters;
using Hrms.Public.Interfaces;
using System;

namespace Hrms.Public.Files
{
    /// <summary>Gap09 Record type 0027 (Cost Distribution) - Override position cost assignment - Multiple records permissible</summary>
    [FixedLengthRecord(FixedMode.ExactLength)]
    public class Gap09_0027_CostDistribution : IGap09Common, IFixedLengthFile
    {
        public const string RecordTypeDefault = "0027";
        public const int Total_Length = 144;

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

        /// <summary>Business Area</summary>
        /// <remarks>Equiv. to AFRS Agency</remarks>
        [StartPosition(69), FieldFixedLength(4), FieldOrder(12)]
        public string BusinessArea { get; set; }

        /// <summary>Functional Area</summary>
        /// <remarks>Functional Area (AFRS Agency + Prog Index)</remarks>
        [StartPosition(73), FieldFixedLength(16), FieldOrder(13), FieldTrim(TrimMode.Right)]
        public string FunctionalArea { get; set; }

        /// <summary>Cost Object</summary>
        /// <remarks>Cost Object (AFRS Agency + Master Index)</remarks>
        [StartPosition(89), FieldFixedLength(12), FieldOrder(14), FieldTrim(TrimMode.Right)]
        public string CostObject { get; set; }

        /// <summary>Fund</summary>
        /// <remarks>Fund (AFRS Agency + Fund + Appr Index)</remarks>
        [StartPosition(101), FieldFixedLength(10), FieldOrder(15), FieldTrim(TrimMode.Right)]
        public string Fund { get; set; }

        /// <summary>Cost Center</summary>
        /// <remarks>Cost Center (AFRS Agency + Org Index)</remarks>
        [StartPosition(111), FieldFixedLength(10), FieldOrder(16), FieldTrim(TrimMode.Right)]
        public string CostCenter { get; set; }

        /// <summary>Project Structure</summary>
        /// <remarks>Project Structure (AFRS Agency + Project + Sub-Project)</remarks>
        [StartPosition(121), FieldFixedLength(11), FieldOrder(17), FieldTrim(TrimMode.Right)]
        public string ProjectStructure { get; set; }

        /// <summary>Allocation Code</summary>
        /// <remarks>Allocation Code (AFRS Agency + Allocation Code)</remarks>
        [StartPosition(132), FieldFixedLength(7), FieldOrder(18), FieldTrim(TrimMode.Right)]
        public string AllocationCode { get; set; }

        /// <summary>Percentage</summary>
        /// <remarks>DEC(3,2) 3 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, rightmost position reserved for sign ('-' for negative amount, ' ' for positive amount)</remarks>
        [StartPosition(139), FieldFixedLength(6), FieldOrder(19), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 3, 2)]
        public decimal AnnualSalary { get; set; }


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
