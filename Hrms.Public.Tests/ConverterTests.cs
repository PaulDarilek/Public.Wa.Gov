using FluentAssertions;
using Hrms.Public.Converters;


namespace Hrms.Public.Tests
{
    public class ConverterTests
    {
        [Fact]
        public void BoolConverterTest()
        {
            const string X = "X";
            const string SPACE = " ";

            // Arrange
            var converter = new BoolConverter("X", SPACE);

            // Act & Assert
            TestConverter(converter, X, true);
            TestConverter(converter, SPACE, false);

            converter.StringToField(string.Empty).Should().Be(false);
            converter.StringToField(null).Should().Be(false);

            converter.FieldToString(null).Should().Be(SPACE);
        }

        private static void TestConverter(BoolConverter converter, string stringValue, bool boolValue)
        {
            bool converted = (bool)converter.StringToField(stringValue);
            converted.Should().Be(boolValue);

            converter.FieldToString(boolValue).Should().Be(stringValue);
        }
    }
}