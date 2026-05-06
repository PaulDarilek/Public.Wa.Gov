using FileHelpers;
using Hrms.Public.Converters;
using Hrms.Public.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Hrms.Public.Files
{
    /// <summary>GAP01 Map (Time and Leave Activity)</summary>
    /// <remarks><see cref="https://support.hrms.wa.gov/sites/default/files/public/resources/interfaces/GAP1-Map.pdf"/> </remarks>
    [FixedLengthRecord(FixedMode.ExactLength)]
    public class Gap38Header : IFixedLengthFile
    {
        public const string RecordTypeDefault = "00";
        public const int Total_Length = 31;
        public const string Interface_Identifier_Constant = "IIFPY038";

        //Field Name Desc Length Start Position Notes

        /// <summary>(Header) CHAR(2) 2 1 </summary>
        /// <remarks>Constant "00"</remarks>
        [StartPosition(1), FieldFixedLength(2)]
        public string RecordType { get; set; }

        /// <summary>CHAR(8) 8 3 Constant "IIFTM001"</summary>
        [StartPosition(3), FieldFixedLength(8)]
        [MaxLength(8)]
        public string InterfaceIdentifier { get; set; }

        /// <summary>Date Created</summary>
        /// <remarks>DATS(8) 8 11 YYYYMMDD</remarks>
        [StartPosition(11), FieldFixedLength(8), FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime DateCreated { get; set; }

        /// <summary>Time Created</summary>
        /// <remarks>NUMC(6) 6 19 HHMMSS</remarks>
        [StartPosition(19), FieldFixedLength(6)]
        public string TimeCreated { get; set; }

        /// <summary>Total Number of Detail records in file</summary>
        /// <remarks>NUMC(6) leading zeros</remarks>
        [StartPosition(25), FieldFixedLength(6), FieldConverter(typeof(IntConverter), 6, false)]
        public int TotalDetailRecordCount { get; set; }


        /// <summary>Default Constructor</summary>
        public Gap38Header()
        {
            var now = DateTime.Now;

            RecordType = RecordTypeDefault;
            InterfaceIdentifier = Interface_Identifier_Constant;
            DateCreated = now.Date;
            TimeCreated = now.ToString("HHmmss");
        }

        public Gap38Header(IEnumerable<Gap38Detail> details) : this()
        {
            TotalDetailRecordCount = details.Count();
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
