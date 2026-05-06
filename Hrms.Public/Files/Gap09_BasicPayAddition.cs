using FileHelpers;
using Hrms.Public.Converters;

namespace Hrms.Public.Files
{
    /// <summary>Repeated Field in Gap09 Basic Pay (RecordType=="0008")</summary>
    public class Gap09_BasicPayAddition
    {
        public const string SPACE = " ";
        public const int Total_Length = 13;

        /// <summary>Salary Component (Pay Code)</summary>
        [StartPosition(1), FieldFixedLength(4)]
        public string SalaryComponent { get; set; }

        /// <summary>Salary Rate</summary>
        /// <remarks>DEC 5.2 5 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, rightmost position reserved for sign ('-' for negative amount, ' ' for positive amount)</remarks>
        [StartPosition(5), FieldFixedLength(8), FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 5, 2)]
        public decimal SalaryRate { get; set; }

        /// <summary>Should it be added?</summary>
        /// <remarks>X = add to salary; blank = do not add to salary</remarks>
        [StartPosition(13), FieldFixedLength(1)]
        public string AddToTotal { get; set; }

        public Gap09_BasicPayAddition()
        {
            SalaryComponent = SalaryComponent ?? "    ";
            AddToTotal = AddToTotal ?? SPACE;
        }

    }
}
