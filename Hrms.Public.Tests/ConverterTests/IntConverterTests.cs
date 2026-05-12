using FluentAssertions;
using Hrms.Public.Converters;

namespace Hrms.Public.Tests.ConverterTests
{
    public class IntConverterTests
    {
        private const int Length = 12;
        private string Padding { get; } = new string('0', Length);

        private IntConverter SignedConverter { get; } = new IntConverter(Length, true);
        private IntConverter UnSignedConverter { get; } = new IntConverter(Length, false);

        [Fact]
        public void ConvertPositiveNumber()
        {
            // arrange
            const int intExpected = 12345;
            string strExpected = $"{Padding}{intExpected}";
            strExpected = strExpected.Substring(strExpected.Length - Length);

            RoundTripValues(SignedConverter, intExpected, strExpected);
            RoundTripValues(UnSignedConverter, intExpected, strExpected);
        }

        [Fact]
        public void NegativeNumber_SignedConverter()
        {
            // arrange
            const int intExpected = -12345;
            string strExpected = $"{Padding}{intExpected}".Replace("-", "");
            strExpected = "-" + strExpected.Substring(strExpected.Length - Length + 1);

            RoundTripValues(SignedConverter, intExpected, strExpected);
        }

        [Fact]
        public void NegativeNumber_UnSignedConverter()
        {
            // arrange
            const int intExpected = 12345;
            string strExpected = $"{Padding}{intExpected}";
            strExpected = strExpected.Substring(strExpected.Length - Length);


            int intActual = (int)UnSignedConverter.StringToField("-" + strExpected);
            string strActual = UnSignedConverter.FieldToString(0 - intExpected);

            // assert
            intActual.Should().Be(intExpected);
            strActual.Should().Be(strExpected);
        }


        // act and assert
        private void RoundTripValues(IntConverter Converter, int intExpected, string strExpected)
        {
            // act
            int intActual = (int)Converter.StringToField(strExpected);
            string strActual = Converter.FieldToString(intExpected);

            // assert
            intActual.Should().Be(intExpected);
            strActual.Should().Be(strExpected);
        }

    }
}
