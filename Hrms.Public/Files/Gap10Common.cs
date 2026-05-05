using FileHelpers;
using Hrms.Public.Converters;

namespace Hrms.Public.Files
{
    //[FixedLengthRecord(FixedMode.ExactLength)]
    public class Gap10Common
    {
        /// <summary>Agency/Sub Agency</summary>
        [FieldOrder(1)]
        [StartPosition(1)]
        [FieldFixedLength(4)]
        public string Agency { get; set; }

        /// <summary>Position Id</summary>
        [FieldOrder(2)]
        [StartPosition(5)]
        [FieldFixedLength(8)]
        public string PositionId { get; set; }

        /// <summary>Position Title (Legacy)</summary>
        [FieldOrder(3)]
        [StartPosition(13)]
        [FieldFixedLength(12)]
        public string PositionLegacyTitle { get; set; }

        /// <summary>Position Title</summary>
        [FieldOrder(4)]
        [StartPosition(25)]
        [FieldFixedLength(40)]
        public string PositionTitle { get; set; }

        /// <summary>Record Type</summary>
        [FieldOrder(5)]
        [StartPosition(65)]
        [FieldFixedLength(4)]
        public string RecordType { get; set; }

    }

}
