using FileHelpers;
using Hrms.Public.Converters;
using System;

namespace Hrms.Public.Files
{
    /// <summary>Gap 7 File Header (Payroll Accounting Details)</summary>
    /// <see cref="https://support.hrms.wa.gov/sites/default/files/public/resources/interfaces/GAP7-Map.pdf"/>
    [FixedLengthRecord()]
    public class Gap07Header : FixedLengthFile
    {
        [FieldFixedLength(2)]
        public string RecordType; //00 = Header, 01=Detail

        [FieldFixedLength(8)]
        public string InterfaceIdentifer; // "OIFPY007"

        [FieldFixedLength(2)]
        public string VersionIdentifer; // "01" at go-live, incremented when format changes.

        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime DateCreated;

        [FieldFixedLength(6)]
        public string TimeCreated; //HHmmss

        [FieldFixedLength(6)]
        [FieldConverter(ConverterKind.Int32)]
        public int TotalDetailRecordCount;

        [FieldFixedLength(16)]
        [FieldConverter(typeof(DecimalSignedImpliedPeriod), 2u)]
        public decimal TotalDetailNumberOfHours;

        [FieldFixedLength(16)]
        [FieldConverter(typeof(DecimalSignedImpliedPeriod), 2u)]
        public decimal TotalDetailAmount;

        [FieldFixedLength(351)]
        public string Filler;

        public const int Total_Length = 415;
    }

}
