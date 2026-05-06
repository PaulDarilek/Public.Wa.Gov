using FileHelpers;
using Hrms.Public.Converters;
using Hrms.Public.Interfaces;
using System;
using System.Collections.Generic;

namespace Hrms.Public.Files
{
    /// <summary>GAP01 Map (Time and Leave Activity)</summary>
    /// <remarks><see cref="https://support.hrms.wa.gov/sites/default/files/public/resources/interfaces/GAP1-Map.pdf"/> </remarks>
    [FixedLengthRecord(FixedMode.ExactLength)]
    public class Gap01Header : IFixedLengthFile
    {
        public const int Total_Length = 71;
        public const string Interface_Identifier_Constant = "IIFTM001";
        public const string RecordTypeDefault = "00";

        /// <summary>(Header) CHAR(2) 2 1 Constant "00"</summary>
        /// <remarks>Constant '00'</remarks>
        [StartPosition(1), FieldFixedLength(2)]
        public string RecordType { get; set; }

        /// <summary>CHAR(8) 8 3 Constant "IIFTM001"</summary>
        /// <remarks>Constant 'IIFTM001</remarks>
        [StartPosition(3), FieldFixedLength(8)]
        public string InterfaceIdentifier { get; set; }

        /// <summary>DATS(8) 8 11 YYYYMMDD</summary>
        [StartPosition(11), FieldFixedLength(8), FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime DateCreated { get; set; }

        /// <summary>NUMC(6) 6 19 HHMMSS</summary>
        /// <remarks>NUMC(6) HHMMSS</remarks>
        [StartPosition(19), FieldFixedLength(6)]
        public string TimeCreated { get; set; }

        /// <summary>CHAR(1) 1 25 Constant "D" or "S"</summary>
        /// <remarks>CHAR(1) Constant 'D' or 'S</remarks>
        [StartPosition(25), FieldFixedLength(1)]
        public string DetailTypeInd { get; set; }

        /// <summary></summary>
        /// <remarks>DATS(8) YYYYMMDD Begin Date of Period</remarks>
        [StartPosition(26), FieldFixedLength(8), FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime BeginDate { get; set; }

        /// <summary>DATS(8) 8 34 YYYYMMDD n/a n/a End Date of Period</summary>
        /// <remarks>DATS(8) YYYYMMDD End Date of Period</remarks>
        [StartPosition(34), FieldFixedLength(8), FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime EndDate { get; set; }

        /// <summary>NUMC(6) 6 42 Total Number of Detail records in file, leading zeros</summary>
        /// <remarks>NUMC(6) Total Number of Detail records in file, leading zeros</remarks>
        [StartPosition(42), FieldFixedLength(6), FieldConverter(typeof(IntConverter), 6, false)]
        public int TotalDetailRecordCount { get; set; }

        /// <summary>DEC(6,2) 8 48 6 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left. NO NEGATIVE NUMBERS ALLOWED.</summary>
        [StartPosition(48), FieldFixedLength(8), FieldConverter(typeof(ImpliedDecimalConverter), Sign.None, 6, 2)]
        public decimal TotalDetailNumberOfHours { get; set; }

        /// <summary>DEC(7,2) 9(7)V99 (implied decimal point), zero filled from the left, NO NEGATIVE NUMBERS ALLOWED.</summary>
        /// <remarks>DEC(7,2) 7 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, NO NEGATIVE NUMBERS ALLOWED.</remarks>
        [StartPosition(56), FieldFixedLength(9), FieldConverter(typeof(ImpliedDecimalConverter), Sign.None, 7, 2)]
        public decimal TotalDetailDollarAmount { get; set; }

        /// <summary>DEC(6) 6 65 6 whole numbers, NO decimal positions, zero filled from the left, NO NEGATIVE NUMBERS ALLOWED.</summary>
        /// <remarks>DEC(6) 6 whole numbers, NO decimal positions, zero filled from the left, NO NEGATIVE NUMBERS ALLOWED.</remarks>
        [StartPosition(65), FieldFixedLength(6), FieldConverter(typeof(IntConverter), 6, false)]
        public int TotalDetailMileageAmount { get; set; }


        /// <summary>Default Constructor</summary>
        public Gap01Header()
        {
            var now = DateTime.Now;

            RecordType = "00";
            InterfaceIdentifier = Gap01Header.Interface_Identifier_Constant;
            DateCreated = now.Date;
            TimeCreated = now.ToString("HHmmss");
            DetailTypeInd = DetailTypeInd ?? "S"; // Assuming "S" indicates summary or something similar, adjust as needed
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

        public int GetRecordLength() => Total_Length;

        public bool IsPossibleRecord(string record)
        {
            if (string.IsNullOrEmpty(record) || !(record.Length == Total_Length))
                return false;

            var recordType = record.Substring(0, 2);
            var interfaceIdentifier = record.Substring(2, 8);

            return recordType == RecordTypeDefault && interfaceIdentifier == Interface_Identifier_Constant;
        }
    }

}
