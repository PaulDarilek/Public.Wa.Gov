using FileHelpers;
using Hrms.Public.Converters;

namespace Hrms.Public.Files
{
    //[FixedLengthRecord(FixedMode.ExactLength)]
    public class Gap10Common
    {
        /// <summary>Agency/Sub Agency</summary>
        [StartPosition(1), FieldFixedLength(4), FieldOrder(1)]
        public string Agency { get; set; }

        /// <summary>Position Id</summary>
        [StartPosition(5), FieldFixedLength(8), FieldOrder(2)]
        public string PositionId { get; set; }

        /// <summary>Position Title (Legacy)</summary>
        [StartPosition(13), FieldFixedLength(12), FieldOrder(3)]
        public string PositionLegacyTitle { get; set; }

        /// <summary>Position Title</summary>
        [StartPosition(25), FieldFixedLength(40), FieldOrder(4)]
        public string PositionTitle { get; set; }

        /// <summary>Record Type</summary>
        [StartPosition(65), FieldFixedLength(4), FieldOrder(5)]
        public string RecordType { get; set; }

    }

}
