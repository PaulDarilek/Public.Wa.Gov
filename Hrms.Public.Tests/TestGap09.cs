using FluentAssertions;
using Hrms.Public.Files;

namespace Hrms.Public.Tests
{
    public class TestGap09 : TestBase
    {
        public override string DefaultFileName => "Gap9.txt";


        [Fact]
        public void ReadFile()
        {
            var inFile = GetInputFile();
            var errFile = GetErrorFile();
            errFile.Delete();

            int countExpected = File.ReadAllLines(inFile.FullName).Length;

            var gapFile = new Gap09();
            var countActual = gapFile.ReadFile(inFile, errFile);

            gapFile.TotalRecords.Should().Be(countExpected);

            if (errFile.Exists)
            {
                throw new Exception($"Errors at: {errFile.FullName}");
            }
            
            countActual.Should().Be(countExpected);
        }

    }
}
