using FileHelpers;
using Hrms.Public.Abstract;
using Hrms.Public.Converters;
using System;

namespace Hrms.Public.Files
{
    /// <summary>Gap09 Record type 0019 (Monitoring of Tasks) - HR Tasks to be completed at a later date - Multiple records permissible</summary>
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class Gap09_0019_Tasks : Gap09Common, IFixedLengthFile
    {
        public const string RecordTypeDefault = "0019";
        public const int Total_Length = 87;

        /// <summary>Contract Type / Permanent Status</summary>
        [FieldOrder(12)]
        [FieldFixedLength(2)]
        [FieldSpec(2, 69, "Contract Type / Permanent Status")]
        public string TaskType { get; set; }

        /// <summary>Date of Task </summary>
        [FieldOrder(13)]
        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        [FieldSpec(8, 71, "YYYYMMDD")]
        public DateTime DateOfTask { get; set; }

        /// <summary>Processing Indicator for task</summary>
        [FieldOrder(14)]
        [FieldFixedLength(1)]
        [FieldSpec(1, 79, "Contract Type / Permanent Status")]
        public char ProcessingIndicator { get; set; }

        /// <summary>Date of Task </summary>
        [FieldOrder(15)]
        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        [FieldSpec(8, 80, "YYYYMMDD")]
        public DateTime ReminderDate { get; set; }

        public int GetRecordLength() => Total_Length;

        public bool IsPossibleRecord(string record)
        {
            return
                !string.IsNullOrEmpty(record) &&
                record.Length >= Total_Length &&
                record.Substring(48, 4) == RecordTypeDefault; //48 zero based, 49 one based in Gap9-Map.pdf
        }
    }
}
