using FileHelpers;
using Hrms.Public.Abstract;
using System;

namespace Hrms.Public.Files
{
    /// <summary>Gap09 Record type 0169 (Savings Plans)</summary>
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class Gap09_0169_SavingsPlan : Gap09Common, IFixedLengthFile
    {
        public const string RecordTypeDefault = "0169";
        public const int Total_Length = 78;

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
