using FileHelpers;
using Hrms.Public.Converters;
using Hrms.Public.Interfaces;
using System;

namespace Hrms.Public.Files
{

    /// <summary>GAP01 Map (Time and Leave Activity)</summary>
    /// <remarks><see cref="https://support.hrms.wa.gov/sites/default/files/public/resources/interfaces/GAP1-Map.pdf"/> </remarks>
    [FixedLengthRecord(FixedMode.ExactLength)]
    public class Gap01Detail : IFixedLengthFile
    {
        public const int Total_Length = 147;
        public const string RecordTypeDefault = "01";

        /// <summary>(Detail) CHAR(2) 2 1 Constant "01"</summary>
        [StartPosition(1), FieldFixedLength(2)]
        public string RecordType { get; set; }

        /// <summary>Personnel Area</summary>
        /// <remarks>Agency/subagency equivalent</remarks>
        [StartPosition(3), FieldFixedLength(4)]
        public string PersonnelArea { get; set; }

        /// <summary>Employee/Personnel Number</summary>
        /// <remarks>NUMC(8) 8 7 CATS/ 0554 SAP Employee number. Can send this or SSN PA0001 PERNR Personnel number</remarks>
        [StartPosition(7), FieldFixedLength(8)]
        public string EmployeeNumber { get; set; }

        /// <summary>Social Security Number</summary>
        /// <remarks>CHAR(9) 9 15 CATS/ 0554 PA0002 PERID SSN (Can send this or Employee number)</remarks>
        [StartPosition(15), FieldFixedLength(9)]
        public string SSN { get; set; }

        /// <summary>Start date</summary>
        /// <remarks>DATS(8) 8 24 CATS YYYYMMDD PA2010 BEGDA Start date</remarks>
        [StartPosition(24), FieldFixedLength(8)]
        public DateTime StartDate { get; set; }

        /// <summary>End Date</summary>
        /// <remarks>DATS(8) 8 32 CATS YYYYMMDD PA2010 ENDDA End Date</remarks>
        [StartPosition(32), FieldFixedLength(8)]
        public DateTime EndDate { get; set; }

        /// <summary>Wage Type (Required to get paid for attendance)</summary>
        /// <remarks>CHAR(4) 4 40 CATS Required to get paid for attendance. Wage Type PA2010 LGART Wage type Load into Infotype 2010</remarks>
        [StartPosition(40), FieldFixedLength(4)]
        public string WageType { get; set; }

        /// <summary>Absence Type (Required to get paid for leave taken)</summary>
        /// <remarks>CHAR(4) 4 44 CATS Required to get paid for leave taken</remarks>
        [StartPosition(44), FieldFixedLength(4)]
        public string AbsenceType { get; set; }

        /// <summary>Hours</summary>
        /// <remarks>DEC(3,2) 3 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, NO NEGATIVE NUMBERS ALLOWED.</remarks>
        [StartPosition(48), FieldFixedLength(5), FieldConverter(typeof(ImpliedDecimalConverter), Sign.None, 3, 2)]
        public decimal Hours { get; set; }

        /// <summary>Functional Area</summary>
        /// <remarks>
        /// NUMC(16) 16 53 CATS If any labor cost distribution fields are filled, all must be filled. 
        /// If a field is not used by agency, fill with AFRS agency code followed by all zeros.(AFRS Agency + Prog Index) 
        /// a. Chars 1-3 Three char AFRS Agency code 
        /// b. Chars 4-8 Five char AFRS Program index 
        /// c. Chars 9-16 Not Used Zero fill
        /// </remarks>
        [StartPosition(53), FieldFixedLength(16)]
        public string FunctionalArea { get; set; }

        /// <summary>Cost Object</summary>
        /// <remarks>
        /// NUMC(12) 12 69 CATS If any labor cost distribution fields are filled, all must be filled. 
        /// If a field is not used by agency, fill with AFRS agency code followed by all zeros.
        /// (AFRS Agency + Master Index)
        /// a. Chars 1-3 Three char AFRS Agency code
        /// b. Chars 4-11 Eight char AFRS Master Index code
        /// c. Chars 12-12 Not Used Zero fill
        /// </remarks>
        [StartPosition(69), FieldFixedLength(12)]
        public string CostObject { get; set; }

        /// <summary></summary>
        /// <remarks>
        /// NUMC(10) 10 81 CATS 
        /// If any labor cost distribution fields are filled, all must be filled. 
        /// If a field is not used by agency, fill with AFRS agency code followed by all zeros.
        /// (AFRS Agency + Fund + Appr Index)
        /// a. Chars 1-3 Three char AFRS Agency code
        /// b. Chars 4-6 Three char AFRS Fund
        /// c. Chars 7-9 Three char AFRS Appropriation Index code
        /// d. Chars 10-10 Not Used Zero fill
        /// </remarks>
        [StartPosition(81), FieldFixedLength(10)]
        public string Fund { get; set; }

        /// <summary></summary>
        /// <remarks>
        /// NUMC(10) 10 91 CATS 
        /// If any labor cost distribution fields are filled, all must be filled. 
        /// If a field is not used by agency, fill with AFRS agency code followed by all zeros.
        /// (AFRS Agency + Org Index)
        /// a. Chars 1-3 Three char AFRS Agency code
        /// b. Chars 4-7 Four char AFRS Organization Index
        /// c. Chars 8-10 Not Used Zero fill
        /// </remarks>
        [StartPosition(91), FieldFixedLength(10)]
        public string CostCenter { get; set; }

        /// <summary></summary>
        /// <remarks>
        /// NUMC(11) 11 101 CATS 
        /// If any labor cost distribution fields are filled, all must be filled. 
        /// If a field is not used by agency, fill with AFRS agency code followed by all zeros. 
        /// (AFRS Agency + Project + Sub-Project)
        /// a. Chars 1-3 Three char AFRS Agency code
        /// b. Chars 4-11 Eight char AFRS Project structure
        /// </remarks>
        [StartPosition(101), FieldFixedLength(11)]
        public string ProjectStructure { get; set; }

        /// <summary></summary>
        /// <remarks>
        /// NUMC(7) 7 112 CATS 
        /// If any labor cost distribution fields are filled, all must be filled. 
        /// If a field is not used by agency, fill with AFRS agency code followed by all zeros.
        /// (AFRS Agency + Allocation Code)
        /// a. Chars 1-3 Three char AFRS Agency code
        /// b. Chars 4-7 Four char AFRS Allocation code
        /// </remarks>
        [StartPosition(112), FieldFixedLength(7)]
        public string AllocationCode { get; set; }

        /// <summary>Position Number</summary>
        /// <remarks>NUMC(8) CATS/ 0554 This is the SAP position number for CATS and/or for IT0554</remarks>
        [StartPosition(119), FieldFixedLength(8)]
        public string PositionNumber { get; set; }

        /// <summary></summary>
        /// <remarks>CHAR(08) 8 127 CATS This is used for Pay Scale Information along with Position on IT2010</remarks>
        [StartPosition(127), FieldFixedLength(8)]
        public string PayScaleGroup { get; set; }

        /// <summary></summary>
        /// <remarks>CHAR(02) 2 135 CATS This is used for Pay Scale Information along with Position on IT2010</remarks>
        [StartPosition(135), FieldFixedLength(2)]
        public string PayScaleLevel { get; set; }

        /// <summary></summary>
        /// <remarks>DEC(4) 4 137 CATS 4 whole numbers, No decimal positions, zero filled from the left, NO NEGATIVE NUMBERS ALLOWED</remarks>
        [StartPosition(137), FieldFixedLength(4), FieldConverter(typeof(IntConverter), 4, false)]
        public int Mileage { get; set; }

        /// <summary></summary>
        /// <remarks>DEC(5,2) 5 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, NO NEGATIVE NUMBERS ALLOWED.</remarks>
        [StartPosition(140), FieldFixedLength(7), FieldConverter(typeof(ImpliedDecimalConverter), Sign.None, 5, 2)]
        public decimal Amount { get; set; }


        public int GetRecordLength() => Total_Length;

        public bool IsPossibleRecord(string record)
        {
            if (string.IsNullOrEmpty(record) || !(record.Length == Total_Length))
                return false;

            var recordType = record.Substring(0, 2);

            return recordType == RecordTypeDefault;
        }
    }

}
