using FileHelpers;
using Hrms.Public.Converters;

namespace Hrms.Public.Files
{
    [FixedLengthRecord(FixedMode.ExactLength)]
    public class Gap10CostDistributions : Gap10Common
    {
        public const string RecordTypeDefault = "1018";
        public const int Total_Length = 144;


        /// <summary>Business Area</summary>
        /// <remarks>NUMC(4) Equiv. to AFRS Agency</remarks>
        [StartPosition(69), FieldFixedLength(4), FieldOrder(6)]
        public string BusinessArea { get; set; }

        /// <summary>Functional Area</summary>
        /// <remarks>NUMC(16) Equiv. to AFRS Agency + Prog Index</remarks>
        [StartPosition(73), FieldFixedLength(16), FieldOrder(7)]
        public string FunctionalArea { get; set; }

        /// <summary>Cost Object</summary>
        /// <remarks>NUMC(12) Equiv. to AFRS Agency + Master Index</remarks>
        [StartPosition(89), FieldFixedLength(12), FieldOrder(8)]
        public string CostObject { get; set; }

        /// <summary>Fund</summary>
        /// <remarks>NUMC(10) Equiv. to AFRS Agency + Fund + Appr Index</remarks>
        [StartPosition(101), FieldFixedLength(10), FieldOrder(9)]
        public string Fund { get; set; }

        /// <summary>Cost Center</summary>
        /// <remarks>NUMC(10) Equiv. to AFRS Agency + Org Index</remarks>
        [StartPosition(111), FieldFixedLength(10), FieldOrder(10)]
        public string CostCenter { get; set; }

        /// <summary>Project Structure</summary>
        /// <remarks>NUMC(11) Equiv. to AFRS Agency + Project + Sub-Project</remarks>
        [StartPosition(121), FieldFixedLength(11), FieldOrder(11)]
        public string ProjectStructure { get; set; }

        /// <summary>Allocation Code</summary>
        /// <remarks>NUMC(7) Equiv. to AFRS Agency + Allocation Code</remarks>
        [StartPosition(132), FieldFixedLength(7), FieldOrder(12)]
        public string AllocationCode { get; set; }

        /// <summary>Percentage</summary>
        /// <remarks>DEC(3,2) 3 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, rightmost position reserved for sign("-" for negative amount, " " for positive amount)</remarks>
        [StartPosition(221), FieldFixedLength(6), FieldOrder(19), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 3, 2)]
        public decimal Percentage { get; set; }



        public int GetRecordLength() => Total_Length;

        public bool IsPossibleRecord(string record)
        {
            return !string.IsNullOrEmpty(record) && record.Length == Total_Length && record.Substring(64, 4) == RecordTypeDefault;
        }

    }

}
