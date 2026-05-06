using FileHelpers;
using Hrms.Public.Converters;
using Hrms.Public.Interfaces;
using System;
using System.Collections.Generic;

namespace Hrms.Public.Files
{
    /// <summary>Gap 7 File Header (Payroll Accounting Details)</summary>
    /// <see cref="https://support.hrms.wa.gov/sites/default/files/public/resources/interfaces/GAP7-Map.pdf"/>
    [FixedLengthRecord()]
    public class Gap07Header : IFixedLengthFile
    {
        public const int Total_Length = 415;
        public const int Trimmed_Length = 65;
        public const string RecordTypeDefault = "00";
        public const string InterfaceIdentifier_Constant = "OIFPY007";

        /// <summary>Record Type</summary>
        /// <remarks>00 = Header, 01=Detail</remarks>
        [StartPosition(1), FieldFixedLength(2)]
        public string RecordType { get; set; }

        /// <summary>Interface Identifer</summary>
        /// <remarks>Constant 'OIFPY007'"</remarks>
        [StartPosition(3), FieldFixedLength(8)]
        public string InterfaceIdentifer { get; set; } // "OIFPY007"

        /// <summary>Version Identifier</summary>
        /// <remarks>"01" at go-live, incremented when format changes.</remarks>
        [StartPosition(11), FieldFixedLength(2)]
        public string VersionIdentifer { get; set; }

        /// <summary></summary>
        /// <remarks>NUMC(8) CCYYMMDD</remarks>
        [StartPosition(13), FieldFixedLength(8), FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime DateCreated { get; set; }

        /// <summary>Time Created</summary>
        /// <remarks>NUMC(6) HHmmss</remarks>
        [StartPosition(21), FieldFixedLength(6)]
        public string TimeCreated { get; set; }

        /// <summary>Total Detail Record Count</summary>
        /// <remarks>NUMC(6) Total Number of Detail records in file, leading zeros</remarks>
        [StartPosition(27), FieldFixedLength(6), FieldConverter(typeof(IntConverter), 6, false)]
        public int TotalDetailRecordCount { get; set; }

        /// <summary></summary>
        /// <remarks>DEC(13,2) implied decimal point (13 left, 2 right) plus low order sign or blank</remarks>
        [StartPosition(33), FieldFixedLength(16), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 13, 2)]
        public decimal TotalDetailNumberOfHours { get; set; }

        /// <summary>Total Detail Amount</summary>
        /// <remarks>DEC(13,2) implied decimal point (13 left, 2 right) plus low order sign or blank</remarks>
        [StartPosition(49), FieldFixedLength(16), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 13, 2)]
        public decimal TotalDetailAmount { get; set; }

        /// <summary>Filler (Unused)</summary>
        /// <remarks>Spaces (do not use)</remarks>
        [StartPosition(65), FieldFixedLength(351), FieldTrim(TrimMode.Right)]
        public string Filler { get; set; }


        /// <summary></summary>
        public Gap07Header()
        {
            var now = DateTime.Now;

            RecordType = RecordType ?? RecordTypeDefault;
            InterfaceIdentifer = InterfaceIdentifer ?? InterfaceIdentifier_Constant;
            VersionIdentifer = VersionIdentifer ?? "01";
            DateCreated = (DateCreated == DateTime.MinValue) ? now.Date : DateCreated;
            TimeCreated = TimeCreated ?? now.ToString("HHmmss");
            Filler = Filler ?? new string(' ', 351);
        }

        public Gap07Header(IEnumerable<Gap07Detail> details) : this()
        {
            foreach (var detail in details)
            {
                TotalDetailRecordCount++;

                TotalDetailNumberOfHours += detail.CurrentHours;
                TotalDetailAmount += detail.CurrentAmount;
            }
        }

        public int GetRecordLength() => Total_Length;

        public bool IsPossibleRecord(string record)
        {
            if (string.IsNullOrEmpty(record) || !(record.Length == Total_Length || record.Length == Trimmed_Length))
                return false;

            var recordType = record.Substring(0, 2);
            var interfaceIdentifier = record.Substring(2, 8);

            return recordType == "00" && interfaceIdentifier == InterfaceIdentifier_Constant;
        }
    }

}
