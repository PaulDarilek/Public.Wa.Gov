using FileHelpers;
using Hrms.Public.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hrms.Public.Files
{
    /// <summary>GAP01 Map (Time and Leave Activity)</summary>
    /// <remarks><see cref="https://support.hrms.wa.gov/sites/default/files/public/resources/interfaces/GAP1-Map.pdf"/> </remarks>
    [FixedLengthRecord(FixedMode.ExactLength)]
    public class Gap01Header : FixedLengthFile
    {
        //Field Name Desc Length Start Position Notes

        /// <summary>(Header) CHAR(2) 2 1 Constant "00"</summary>
        [FieldFixedLength(2)]
        [FieldSpec(2, 1, "Constant '00'")]
        public string RecordType;

        /// <summary>CHAR(8) 8 3 Constant "IIFTM001"</summary>
        [FieldFixedLength(8)][MaxLength(8)]
        [FieldSpec(8, 3, "Constant 'IIFTM001'")]
        public string InterfaceIdentifier;

        /// <summary>DATS(8) 8 11 YYYYMMDD</summary>
        [FieldFixedLength(8)][FieldSpec(8, 11, "DATS(8) 8 11 YYYYMMDD")]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime DateCreated; // 

        /// <summary>NUMC(6) 6 19 HHMMSS</summary>
        [FieldFixedLength(6)]
        [FieldSpec(6, 19, "NUMC(6) HHMMSS")]
        public string TimeCreated;

        /// <summary>CHAR(1) 1 25 Constant "D" or "S"</summary>
        [FieldFixedLength(1)]
        [FieldSpec(1, 25, "CHAR(1) Constant 'D' or 'S'")]
        public char DetailTypeInd; //

        /// <summary></summary>
        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        [FieldSpec(8, 26, "DATS(8) YYYYMMDD Begin Date of Period")]
        public DateTime BeginDate; //

        /// <summary>DATS(8) 8 34 YYYYMMDD n/a n/a End Date of Period</summary>
        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        [FieldSpec(8, 34, "DATS(8) YYYYMMDD End Date of Period")]
        public DateTime EndDate;

        /// <summary>NUMC(6) 6 42 Total Number of Detail records in file, leading zeros</summary>
        [FieldFixedLength(6)]
        [FieldConverter(typeof(UnsignedIntPadded), 6)]
        [FieldSpec(6, 42, "NUMC(6) Total Number of Detail records in file, leading zeros")]
        public uint TotalDetailRecordCount;

        /// <summary>DEC(6,2) 8 48 6 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left. NO NEGATIVE NUMBERS ALLOWED.</summary>
        [FieldFixedLength(8)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.None, 6, 2)]
        [FieldSpec(8, 48, "DEC(6,2) 8 48 6 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left. NO NEGATIVE NUMBERS ALLOWED.")]
        public decimal TotalDetailNumberOfHours;

        /// <summary>DEC(7,2) 9(7)V99 (implied decimal point), zero filled from the left, NO NEGATIVE NUMBERS ALLOWED.</summary>
        [FieldFixedLength(9)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.None, 7, 2)]
        [FieldSpec(9, 56, "DEC(7,2) 7 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, NO NEGATIVE NUMBERS ALLOWED.")]
        public decimal TotalDetailDollarAmount;

        /// <summary>DEC(6) 6 65 6 whole numbers, NO decimal positions, zero filled from the left, NO NEGATIVE NUMBERS ALLOWED.</summary>
        [FieldFixedLength(6)]
        [FieldConverter(typeof(UnsignedIntPadded), 6)]
        [FieldSpec(6, 65, "DEC(6) 6 whole numbers, NO decimal positions, zero filled from the left, NO NEGATIVE NUMBERS ALLOWED.")]
        public uint TotalDetailMileageAmount;

        public const int Total_Length = 71;
        public const string Interface_Identifier_Constant = "IIFTM001";

        /// <summary>Default Constructor</summary>
        public Gap01Header()
        {
            var now = DateTime.Now;

            RecordType = "00";
            InterfaceIdentifier = Gap01Header.Interface_Identifier_Constant;
            DateCreated = now.Date;
            TimeCreated = now.ToString("HHmmss");
            DetailTypeInd = 'S'; // Assuming 'S' indicates summary or something similar, adjust as needed
        }

        public Gap01Header(IEnumerable<Gap01Detail> details) : this()
        {
            foreach (var detail in details)
            {
                TotalDetailRecordCount++;

                if (BeginDate == default || detail.StartDate < BeginDate)
                    BeginDate = detail.StartDate;
                
                if (EndDate == default || detail.EndDate > EndDate)
                    EndDate = detail.EndDate;

                TotalDetailNumberOfHours += detail.Hours;
                TotalDetailDollarAmount += detail.Amount;
                TotalDetailMileageAmount += detail.Mileage;
            }
        }

        public static bool IsValidRecord(string line)
        {
            if (string.IsNullOrEmpty(line) || !(line.Length == Total_Length))
                return false;

            var recordType = line.Substring(0, 2);
            var interfaceIdentifier = line.Substring(2, 8);

            return recordType == "00" && interfaceIdentifier == Interface_Identifier_Constant;
        }



    }

}
