using FileHelpers;
using Hrms.Public.Converters;
using Hrms.Public.Interfaces;
using System;

namespace Hrms.Public.Files
{
    public class Gap38Detail : IFixedLengthFile
    {

        public const string RecordTypeDefault = "01";
        public const int Total_Length = 120;

        /// <summary>Record Type </summary>
        /// <remarks>Detail "01"</remarks>
        [StartPosition(1), FieldFixedLength(2)]
        public string RecordType { get; set; }

        /// <summary>Personnel Area</summary>
        [StartPosition(3), FieldFixedLength(4)]
        public string PersonnelArea { get; set; }

        /// <summary>Personnel SubArea</summary>
        [StartPosition(7), FieldFixedLength(4)]
        public string PersonnelSubArea { get; set; }

        /// <summary>Personnel Number / Employee Number</summary>
        /// <remarks>NUMC(8)</remarks>
        [StartPosition(11), FieldFixedLength(8)]
        public string PersonnelNumber { get; set; }

        /// <summary>Social Security Number</summary>
        /// <remarks>Char(9)</remarks>
        [StartPosition(19), FieldFixedLength(9)]
        public string SSN { get; set; }

        /// <summary>CCYYMMDD Start Date</summary>
        /// <remarks>CCYYMMDD DATS(8) PA0000 BEGDA Start date</remarks>
        [StartPosition(28), FieldFixedLength(8), FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime StartDate { get; set; }

        /// <summary>End Date</summary>
        /// <remarks>CCYYMMDD PA0000 ENDDA End Date</remarks>
        [StartPosition(36), FieldFixedLength(8), FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime EndDate { get; set; }


        /// <summary>Business Area</summary>
        /// <remarks>NUMC(4) Chars 1-4 Four char Agency code</remarks>
        [StartPosition(44), FieldFixedLength(4)]
        public string BusinessArea { get; set; }

        /// <summary>Functional Area</summary>
        /// <remarks>
        /// Equiv. to AFRS Agency + Prog Index
        /// Chars 1-3 Three char AFRS Agency code
        /// b.Chars 4-8 Five char AFRS Program index
        /// c.Chars 9-16 Not Used Zero fill
        /// </remarks>
        [StartPosition(48), FieldFixedLength(16)]
        public string FunctionalArea { get; set; }

        /// <summary>Cost Object</summary>
        /// <remarks>
        /// Equiv. to AFRS Agency + Master Index
        /// a. Chars 1-3 Three char AFRS Agency code
        /// b. Chars 4-11 Eight char AFRS Master Index code
        /// c.Chars 12-12 Not Used Zero fill
        /// </remarks>
        [StartPosition(64), FieldFixedLength(12)]
        public string CostObject { get; set; }

        /// <summary>Fund</summary>
        /// <remarks>
        /// Equiv. to AFRS Agency + Master Index
        /// a. Chars 1-3 Three char AFRS Agency code
        /// b. Chars 4-6 Three char AFRS Fund
        /// c. Chars 7-9 Three char AFRS Appropriation Index code
        /// d.Chars 10-10 Not Used Zero fill
        /// </remarks>
        [StartPosition(76), FieldFixedLength(10)]
        public string Fund { get; set; }

        /// <summary>Cost Center</summary>
        /// <remarks></remarks>
        [StartPosition(86), FieldFixedLength(10)]
        public string CostCenter { get; set; }

        /// <summary>Project Structure</summary>
        /// <remarks>
        ///   Equiv. to AFRS Agency + Project + Sub-Project 
        ///   a. Chars 1-3 Three char AFRS Agency code        
        ///   b.Chars 4-11 Eight char AFRS Project structur
        /// </remarks>
        [StartPosition(96), FieldFixedLength(11)]
        public string ProjectStructure { get; set; }

        /// <summary>Allocation Code</summary>
        /// <remarks>
        ///   Equiv. to AFRS Agency + Allocation Code 
        ///   a. Chars 1-3 Three char AFRS Agency code
        ///   b.Chars 4-7 Four char AFRS Allocation code
        /// </remarks>
        [StartPosition(107), FieldFixedLength(7)]
        public string AllocationCode { get; set; }

        /// <summary>Percentage</summary>
        /// <remarks>DEC(3,2) PRORATE FACTOR
        /// 5 digits with implied decimal point(3 left, 2 right) plus low order sign or blank
        /// </remarks>
        [StartPosition(114), FieldFixedLength(6), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 3, 2)]
        public decimal Percentage { get; set; }

        public Gap38Detail()
        {
            RecordType = RecordType ?? RecordTypeDefault;
        }

        public int GetRecordLength() => Total_Length;

        public bool IsPossibleRecord(string record)
        {
            if (string.IsNullOrEmpty(record) || !(record.Length == Total_Length))
                return false;

            return record.Substring(0, 2) == RecordTypeDefault;
        }
    }

}
