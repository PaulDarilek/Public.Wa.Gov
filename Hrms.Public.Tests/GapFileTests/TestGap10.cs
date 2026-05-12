using FileHelpers;
using FluentAssertions;
using Hrms.Public.Files;
using System.Runtime.CompilerServices;

namespace Hrms.Public.Tests.GapFileTests
{
    public class TestGap10 : TestBase<Gap10>
    {
        public override string DefaultFileName => "Gap10.txt";

        [Fact]
        public async void SplitByRecordType()
        {
            var inFile = GetInputFile();
            var gapFile = new Gap10();
            var dict = await gapFile.SplitFileAsync(inFile);
            dict.Count.Should().Be(2);
        }


        [Fact] public void Read_Gap10Position() => TestSplitFile<Gap10Position>($"Gap10_{Gap10Position.RecordTypeDefault}.txt");
        [Fact] public void Read_Gap10CostDistributions() => TestSplitFile<Gap10CostDistributions>($"Gap10_{Gap10CostDistributions.RecordTypeDefault}.txt");


        private void TestSplitFile<T>(string fileName, [CallerMemberName] string? methodName = null) where T : Gap10Common
        {
            var inFile = GetInputFile(fileName);

            if (base.InputFile.Exists)
            {
                int countExpected = inFile.GetLineCount();

                var engine = new FileHelperEngine<T>
                {
                    ErrorMode = ErrorMode.SaveAndContinue
                };
                var result = engine.ReadFileAsList(inFile.FullName);

                if (engine.ErrorManager.HasErrors)
                {
                    var errorFile = GetErrorFile(true, methodName);
                    engine.ErrorManager.SaveErrors(errorFile.FullName);
                }
                engine.ErrorManager.HasErrors.Should().BeFalse();

                result.Count.Should().Be(countExpected);

                var outFile = GetOutputFile(fileName);
                engine.WriteFile(outFile.FullName, result);
                inFile.CompareFileContents(outFile);
            }

        }

    }
}
