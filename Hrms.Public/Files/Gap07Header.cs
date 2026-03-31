using FileHelpers;
using Hrms.Public.Abstract;
using Hrms.Public.Converters;
using System;
using System.Collections.Generic;

namespace Hrms.Public.Files
{
    /// <summary>Gap 7 File Header (Payroll Accounting Details)</summary>
    /// <see cref="https://support.hrms.wa.gov/sites/default/files/public/resources/interfaces/GAP7-Map.pdf"/>
    [FixedLengthRecord()]
    public class Gap07Header : IFixedLengthFile
    {

        [FieldFixedLength(2)]
        [FieldSpec(2, 1, "Constant '00'")]
        public string RecordType; //00 = Header, 01=Detail

        [FieldFixedLength(8)]
        [FieldSpec(8, 3, "Constant 'OIFPY007'")]
        public string InterfaceIdentifer; // "OIFPY007"

        [FieldFixedLength(2)]
        [FieldSpec(2, 11, "Version Identifier")]
        public string VersionIdentifer; // "01" at go-live, incremented when format changes.

        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        [FieldSpec(8, 13, "NUMC(8) CCYYMMDD")]
        public DateTime DateCreated;

        [FieldFixedLength(6)]
        [FieldSpec(6, 21, "NUMC(6) HHMMSS")]
        public string TimeCreated; //HHmmss

        [FieldFixedLength(6)]
        [FieldConverter(ConverterKind.Int32)]
        [FieldSpec(6, 27, "NUMC(6) Total Number of Detail records in file, leading zeros")]
        public int TotalDetailRecordCount;

        [FieldFixedLength(16)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 13, 2)]
        [FieldSpec(16, 33, "DEC(13,2) 5 digits with implied decimal point (13 left, 2 right) plus low order sign or blank")]
        public decimal TotalDetailNumberOfHours;

        [FieldFixedLength(16)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 13, 2)]
        [FieldSpec(16, 49, "DEC(13,2) 5 digits with implied decimal point (13 left, 2 right) plus low order sign or blank")]
        public decimal TotalDetailAmount;

        [FieldFixedLength(351)]
        [FieldSpec(351, 65, "Filler - spaces")]
        public string Filler;


        public const int Total_Length = 415;
        public const int Trimmed_Length = 65;
        public const string Interface_Identifier_Constant = "OIFPY007";

        public Gap07Header()
        {
            var now = DateTime.Now;

            RecordType = "00";
            InterfaceIdentifer = Interface_Identifier_Constant;
            VersionIdentifer = VersionIdentifer ?? "01";
            DateCreated = now.Date;
            TimeCreated = now.ToString("HHmmss");
            Filler = new string(' ', 351);
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

            return recordType == "00" && interfaceIdentifier == Interface_Identifier_Constant;
        }
    }

}
