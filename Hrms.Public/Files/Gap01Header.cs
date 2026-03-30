using System;
using FileHelpers;
using System.ComponentModel.DataAnnotations;

namespace Hrms.Public.Files
{
    /// <summary>Definition of GAP01 record from https://support.hrms.wa.gov/sites/default/files/public/resources/interfaces/GAP1-Map.pdf</summary>
    [FixedLengthRecord(FixedMode.ExactLength)]
    public class Gap01Header : FixedLengthFile
    {
        //Field Name Desc Length Start Position Notes

        /// <summary>(Header) CHAR(2) 2 1 Constant "00"</summary>
        [FieldFixedLength(2)]
        [Field(2, 1, "Constant '00'")]
        public string RecordType;

        /// <summary>CHAR(8) 8 3 Constant "IIFTM001"</summary>
        [FieldFixedLength(8)][MaxLength(8)]
        [Field(8, 3, "Constant 'IIFTM001'")]
        public string InterfaceIdentifier;

        /// <summary>DATS(8) 8 11 YYYYMMDD</summary>
        [FieldFixedLength(8)][Field(8, 11, "DATS(8) 8 11 YYYYMMDD")]
        public DateTime DateCreated; // 

        /// <summary>NUMC(6) 6 19 HHMMSS</summary>
        [FieldFixedLength(6)]
        [Field(6, 19, "NUMC(6) HHMMSS")]]
        public DateTime TimeCreated;

        /// <summary>CHAR(1) 1 25 Constant "D" or "S"</summary>
        [FieldFixedLength(1)]
        [Field(1, 25, "CHAR(1) Constant 'D' or 'S'")]
        public char DetailTypeInd; //

        /// <summary></summary>
        [FieldFixedLength(8)]
        [Field(8, 26, "DATS(8) YYYYMMDD Begin Date of Period")]
        public DateTime BeginDate; //

        /// <summary>DATS(8) 8 34 YYYYMMDD n/a n/a End Date of Period</summary>
        [FieldFixedLength(8)]
        [Field(8, 34, "DATS(8) YYYYMMDD End Date of Period")]
        public DateTime EndDate;

        /// <summary>NUMC(6) 6 42 Total Number of Detail records in file, leading zeros</summary>
        [FieldFixedLength(6)]
        [Field(6, 42, "NUMC(6) Total Number of Detail records in file, leading zeros")]
        public int TotalDetailRecordCount;

        /// <summary>DEC(6,2) 8 48 6 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left. NO NEGATIVE NUMBERS ALLOWED.</summary>
        [FieldFixedLength(8)]
        [Field(8, 48, "DEC(6,2) 8 48 6 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left. NO NEGATIVE NUMBERS ALLOWED.")]
        public decimal TotalDetailNumberOfHours;

        /// <summary>DEC(7,2) 9(7)V99 (implied decimal point), zero filled from the left, NO NEGATIVE NUMBERS ALLOWED.</summary>
        [FieldFixedLength(9)]
        [Field(9, 56, "DEC(7,2) 7 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, NO NEGATIVE NUMBERS ALLOWED.")]
        public decimal TotalDetailDollarAmount;

        /// <summary>DEC(6) 6 65 6 whole numbers, NO decimal positions, zero filled from the left, NO NEGATIVE NUMBERS ALLOWED.</summary>
        [FieldFixedLength(6)]
        [Field(6, 65, "DEC(6) 6 whole numbers, NO decimal positions, zero filled from the left, NO NEGATIVE NUMBERS ALLOWED.")]
        public int TotalDetailMileageAmount;
    }

}
