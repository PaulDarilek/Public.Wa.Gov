using FileHelpers;
using FluentAssertions;
using Hrms.Public.Converters;
using Hrms.Public.Files;
using System.Runtime.CompilerServices;

namespace Hrms.Public.Tests.GapFileTests
{
    public class TestGap09 : TestBase<Gap09>
    {
        public override string DefaultFileName => "Gap9.txt";

        [Fact]
        public void ParseBasicPayAddition()
        {
            var test = new Gap09_BasicPayAddition()
            {
                SalaryComponent = "abcd",
                SalaryRate = 12345.67M,
                AddToTotal = "X",
            };

            string expected = "abcd1234567 X";
            string actual = BasicPayAdditionConverter.Format(test);
            actual.Should().Be(expected);

            test = new Gap09_BasicPayAddition()
            {
                SalaryComponent = null,
                SalaryRate = -123M,
                AddToTotal = "z",
            };
            expected = "    0012300-z";
            actual = BasicPayAdditionConverter.Format(test);
            actual.Should().Be(expected);
        }

        [Fact]
        public async void SplitByRecordType()
        {
            var inFile = GetInputFile();
            var gapFile = new Gap09();
            var dict = await gapFile.SplitFileAsync(inFile);
            dict.Count.Should().Be(24);
        }

        [Fact] public void Read_Gap09_0000_Actions() => TestSplitFile<Gap09_0000_Actions>("Gap9_0000.txt");
        [Fact] public void Read_Gap09_0001_OrgAssignment() => TestSplitFile<Gap09_0001_OrgAssignment>("Gap9_0001.txt");
        [Fact] public void Read_Gap09_0002_PersonalData() => TestSplitFile<Gap09_0002_PersonalData>("Gap9_0002.txt");
        [Fact] public async void Read_Gap09_0006_Address() => TestSplitFile<Gap09_0006_Address>("Gap9_0006.txt");
        [Fact] public async void Read_Gap09_0007_WorkSchedule() => TestSplitFile<Gap09_0007_WorkSchedule>("Gap9_0007.txt");

        [Fact] public async void Read_Gap09_0008_BasicPay() => TestSplitFile<Gap09_0008_BasicPay>("Gap9_0008.txt");
        [Fact] public void Read_Gap09_0019_Tasks() => TestSplitFile<Gap09_0019_Tasks>("Gap9_0019.txt");
        [Fact] public void Read_Gap09_0021_Family() => TestSplitFile<Gap09_0021_Family>("Gap9_0021.txt");
        [Fact] public void Read_Gap09_0022_Education() => TestSplitFile<Gap09_0022_Education>("Gap9_0022.txt");
        [Fact] public void Read_Gap09_0023_Employers() => TestSplitFile<Gap09_0023_Employers>("Gap9_0023.txt");
        [Fact] public void Read_Gap09_0027_CostDistribution() => TestSplitFile<Gap09_0027_CostDistribution>("Gap9_0027.txt");
        [Fact] public void Read_Gap09_0040_Loan() => TestSplitFile<Gap09_0040_Loan>("Gap9_0040.txt");
        [Fact] public void Read_Gap09_0041_Dates() => TestSplitFile<Gap09_0041_Dates>("Gap9_0041.txt");
        [Fact] public void Read_Gap09_0077_AdditionalData() => TestSplitFile<Gap09_0077_AdditionalData>("Gap9_0077.txt");

        [Fact] public void Read_Gap09_0081_Military() => TestSplitFile<Gap09_0081_Military>("Gap9_0081.txt");
        [Fact] public void Read_Gap09_0094_Residence() => TestSplitFile<Gap09_0094_Residence>("Gap9_0094.txt");
        [Fact] public void Read_Gap09_0105_Communications() => TestSplitFile<Gap09_0105_Communications>("Gap9_0105.txt");
        [Fact] public void Read_Gap09_0121_Personnel() => TestSplitFile<Gap09_0121_Personnel>("Gap9_0121.txt");
        [Fact] public void Read_Gap09_0167_HealthPlans() => TestSplitFile<Gap09_0167_HealthPlans>("Gap9_0167.txt");
        [Fact] public void Read_Gap09_0169_SavingsPlan() => TestSplitFile<Gap09_0169_SavingsPlan>("Gap9_0169.txt");
        [Fact] public void Read_Gap09_0209_Unemployment() => TestSplitFile<Gap09_0209_Unemployment>("Gap9_0209.txt");
        [Fact] public void Read_Gap09_0377_MiscPlans() => TestSplitFile<Gap09_0377_MiscPlans>("Gap9_0377.txt");
        [Fact] public void Read_Gap09_0552_Time() => TestSplitFile<Gap09_0552_Time>("Gap9_0552.txt");



        private void TestSplitFile<T>(string fileName, [CallerMemberName] string? methodName = null) where T : class, IGap09Common
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
