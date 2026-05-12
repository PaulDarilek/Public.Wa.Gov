using FluentAssertions;
using Hrms.Public.Converters;


namespace Hrms.Public.Tests.ConverterTests
{
    public class BoolConverterTests
    {
        private const string TrueValue = "X";
        private const string FalseValue = " ";
        private BoolConverter Converter { get; } = new BoolConverter(TrueValue, FalseValue);


        [Fact] public void BoolConverter_ShouldParseTrue() => RoundTripValue(TrueValue, true);

        [Fact] public void BoolConverter_ShouldParseFalse() => RoundTripValue(FalseValue, false);

        [Fact] public void BoolConverter_StringToField_StringEmpty_IsFalse() => Converter.StringToField(string.Empty).Should().Be(false);

        [Fact] public void BoolConverter_StringToField_Null_IsFalse() => Converter.StringToField(null).Should().Be(false);

        [Fact] public void BoolConverter_FieldToString_Null_IsFalseValue() => Converter.FieldToString(null).Should().Be(FalseValue);


        /// <summary>Test both ways (round trip) of a true or false representation</summary>
        private void RoundTripValue(string stringValue, bool boolValue)
        {
            bool converted = (bool)Converter.StringToField(stringValue);
            converted.Should().Be(boolValue);

            Converter.FieldToString(boolValue).Should().Be(stringValue);
        }
    }
}