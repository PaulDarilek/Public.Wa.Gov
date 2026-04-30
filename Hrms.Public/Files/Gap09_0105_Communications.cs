using FileHelpers;
using Hrms.Public.Abstract;
using System;

namespace Hrms.Public.Files
{
    /// <summary>Gap09 Record type 0105 (Comunications) - Multiple records permissible</summary>
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class Gap09_0105_Communications : Gap09Common, IFixedLengthFile
    {
        public const string RecordTypeDefault = "0105";
        public const int Total_Length = 343;

        //[FieldOrder(12)]


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
