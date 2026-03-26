using FileHelpers;
using System;
using System.Runtime.CompilerServices;

namespace Hrms.Public.Files
{

    /// <summary>Definition of GAP01 (Detail) record from https://support.hrms.wa.gov/sites/default/files/public/resources/interfaces/GAP1-Map.pdf</summary>
    [FixedLengthRecord(FixedMode.ExactLength)]
    public class Gap01Detail
    {
        //Field Name Desc Length Start Position Notes

        /// <summary>(Detail) CHAR(2) 2 1 Constant "00"</summary>
        [FieldFixedLength(2)]
        [Field(2, 1, "Constant '01'")]
        public string RecordType;

        /// <summary>CHAR(4) 4 3 Enterprise Structure PA0001 WERKS Personnel area Agency/subagency equivalent</summary>
        [FieldFixedLength(4)]
        [Field(4, 3, "Enterprise Structure Personnel area Agency/subagency equivalent")]
        public string PersonnelArea;

        /// <summary>NUMC(8) 8 7 CATS/ 0554 SAP Employee number. Can send this or SSN PA0001 PERNR Personnel number</summary>
        [FieldFixedLength(8)]
        [Field(8, 7, "Employee number/Personnel number")]
        public string EmployeeNumber;

        /// <summary>CHAR(9) 9 15 CATS/ 0554 Can send this or Employee number PA0002 PERID SSN</summary>
        [FieldFixedLength(9)]
        [Field(9, 15, "Can send this or Employee number")]
        public string SSN;

        /// <summary>DATS(8) 8 24 CATS YYYYMMDD PA2010 BEGDA Start date</summary>
        [FieldFixedLength(8)]
        [Field(8, 24, "YYYYMMDD Start date")]
        public DateTime StartDate; // 

        /// <summary>DATS(8) 8 32 CATS YYYYMMDD PA2010 ENDDA End Date</summary>
        [FieldFixedLength(8)]
        [Field(8, 32, "YYYYMMDD End Date")]
        public DateTime EndDate; //

        /// <summary>CHAR(4) 4 40 CATS Required to get paid for attendance. Wage Type PA2010 LGART Wage type Load into Infotype 2010</summary>
        [FieldFixedLength(4)]
        [Field(4, 40, "Required to get paid for attendance")]
        public string WageType; //

        /// <summary>CHAR(4) 4 44 CATS Required to get paid for leave taken (Absence Types)</summary>
        [FieldFixedLength(4)]
        [Field(4, 44, "Required to get paid for leave taken (Absence Types)")]
        public string AbsenceType; // 

        /// <summary>DEC(3,2) 5 48 CATS 3 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, NO NEGATIVE NUMBERS ALLOWED.</summary>
        [FieldFixedLength(5)]
        [Field(5, 48, "9(3)V99 (implied decimal point), zero filled from the left, NO NEGATIVE NUMBERS ALLOWED.")]
        public string Hours;

        /// <summary>
        /// NUMC(16) 16 53 CATS If any labor cost distribution fields are filled, all must be filled. 
        /// If a field is not used by agency, fill with AFRS agency code followed by all zeros.(AFRS Agency + Prog Index)
        /// a. Chars 1-3 Three char AFRS Agency code
        /// b. Chars 4-8 Five char AFRS Program index
        /// c. Chars 9-16 Not Used Zero fill
        /// </summary>
        [FieldFixedLength(16)]
        [Field(16, 53, "NUMC(16) 16 53 CATS If any labor cost distribution fields are filled, all must be filled. If a field is not used by agency, fill with AFRS agency code followed by all zeros.(AFRS Agency + Prog Index) a. Chars 1-3 Three char AFRS Agency code b. Chars 4-8 Five char AFRS Program index c. Chars 9-16 Not Used Zero fill")]
        public string FunctionalArea;

        /// <summary>
        /// NUMC(12) 12 69 CATS If any labor cost distribution fields are filled, all must be filled. 
        /// If a field is not used by agency, fill with AFRS agency code followed by all zeros.
        /// (AFRS Agency + Master Index)
        /// a. Chars 1-3 Three char AFRS Agency code
        /// b. Chars 4-11 Eight char AFRS Master Index code
        /// c. Chars 12-12 Not Used Zero fill
        /// </summary>
        [FieldFixedLength(12)]
        [Field(12, 69, "If any labor cost distribution fields are filled, all must be filled. If a field is not used by agency, fill with AFRS agency code followed by all zeros.(AFRS Agency + Master Index) a. Chars 1-3 Three char AFRS Agency code b. Chars 4-11 Eight char AFRS Master Index code c. Chars 12-12 Not Used Zero fill")]
        public string CostObject;

        /// <summary>
        /// NUMC(10) 10 81 CATS 
        /// If any labor cost distribution fields are filled, all must be filled. 
        /// If a field is not used by agency, fill with AFRS agency code followed by all zeros.
        /// (AFRS Agency + Fund + Appr Index)
        /// a. Chars 1-3 Three char AFRS Agency code
        /// b. Chars 4-6 Three char AFRS Fund
        /// c. Chars 7-9 Three char AFRS Appropriation Index code
        /// d. Chars 10-10 Not Used Zero fill
        /// </summary>
        [FieldFixedLength(10)]
        [Field(10, 81, "If any labor cost distribution fields are filled, all must be filled. If a field is not used by agency, fill with AFRS agency code followed by all zeros.(AFRS Agency + Fund + Appr Index) a. Chars 1-3 Three char AFRS Agency code b. Chars 4-6 Three char AFRS Fund c. Chars 7-9 Three char AFRS Appropriation Index code d. Chars 10-10 Not Used Zero fill")]
        public string Fund; //

        /// <summary>
        /// NUMC(10) 10 91 CATS 
        /// If any labor cost distribution fields are filled, all must be filled. 
        /// If a field is not used by agency, fill with AFRS agency code followed by all zeros.
        /// (AFRS Agency + Org Index)
        /// a. Chars 1-3 Three char AFRS Agency code
        /// b. Chars 4-7 Four char AFRS Organization Index
        /// c. Chars 8-10 Not Used Zero fill
        /// </summary>
        [FieldFixedLength(10)]
        [Field(10, 91, "If any labor cost distribution fields are filled, all must be filled. If a field is not used by agency, fill with AFRS agency code followed by all zeros.()AFRS Agency + Org Index) a. Chars 1-3 Three char AFRS Agency code b. Chars 4-7 Four char AFRS Organization Index c. Chars 8-10 Not Used Zero fill")]
        public string CostCenter;

        /// <summary>
        /// NUMC(11) 11 101 CATS 
        /// If any labor cost distribution fields are filled, all must be filled. 
        /// If a field is not used by agency, fill with AFRS agency code followed by all zeros. 
        /// (AFRS Agency + Project + Sub-Project)
        /// a. Chars 1-3 Three char AFRS Agency code
        /// b. Chars 4-11 Eight char AFRS Project structure
        /// </summary>
        [FieldFixedLength(11)]
        [Field(11, 101, "If any labor cost distribution fields are filled, all must be filled. If a field is not used by agency, fill with AFRS agency code followed by all zeros. (AFRS Agency + Project + Sub-Project) a. Chars 1-3 Three char AFRS Agency code b. Chars 4-11 Eight char AFRS Project structure")]
        public string ProjectStructure;

        /// <summary>
        /// NUMC(7) 7 112 CATS 
        /// If any labor cost distribution fields are filled, all must be filled. 
        /// If a field is not used by agency, fill with AFRS agency code followed by all zeros.
        /// (AFRS Agency + Allocation Code)
        /// a. Chars 1-3 Three char AFRS Agency code
        /// b. Chars 4-7 Four char AFRS Allocation code
        /// </summary>
        [FieldFixedLength(7)]
        [Field(7, 112, "NUMC(7) 7 112 CATS If any labor cost distribution fields are filled, all must be filled. If a field is not used by agency, fill with AFRS agency code followed by all zeros.(AFRS Agency + Allocation Code) a. Chars 1-3 Three char AFRS Agency code b. Chars 4-7 Four char AFRS Allocation code")]
        public string AllocationCode; 

        /// <summary>NUMC(8) 8 119 CATS/ 0554 This is the SAP position number for CATS and/or for IT0554</summary>
        [FieldFixedLength(8)]
        [Field(8, 119, "This is the SAP position number for CATS and/or for IT0554")]
        public string PositionNumber;

        /// <summary>CHAR(08) 8 127 CATS This is used for Pay Scale Information along with Position on IT2010</summary>
        [FieldFixedLength(8)]
        [Field(8, 127, "This is used for Pay Scale Information along with Position on IT2010")]
        public string PayScaleGroup;

        /// <summary>CHAR(02) 2 135 CATS This is used for Pay Scale Information along with Position on IT2010</summary>
        [FieldFixedLength(2)]
        [Field(2, 135, "This is used for Pay Scale Information along with Position on IT2010")]
        public string PayScaleLevel;

        /// <summary>DEC(4) 4 137 CATS 4 whole numbers, No decimal positions, zero filled from the left, NO NEGATIVE NUMBERS ALLOWED</summary>
        [FieldFixedLength(4)]
        [Field(4, 137, "whole numbers, No decimal positions, zero filled from the left, NO NEGATIVE NUMBERS ALLOWED")]
        public int Mileage;

        /// <summary>DEC(5,2) 7 140 CATS 5 whole numbers plus 2 decimal positions(implied decimal point), zero filled from the left, NO NEGATIVE NUMBERS ALLOWED</summary>
        [FieldFixedLength(7)]
        [Field(7, 140, "9(5)V99 (implied decimal point), zero filled from the left, NO NEGATIVE NUMBERS ALLOWED")]
        public decimal Amount;

    }

}
