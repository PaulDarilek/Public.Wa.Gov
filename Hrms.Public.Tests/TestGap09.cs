using FileHelpers;
using FluentAssertions;
using Hrms.Public.Converters;
using Hrms.Public.Files;
using System.Data;
using System.Diagnostics;

namespace Hrms.Public.Tests
{
    public class TestGap09 : TestBase
    {
        public override string DefaultFileName => "Gap9.txt";

        [Fact]
        public void ParseBasicPayAddition()
        {
            var test = new Gap09_BasicPayAddition()
            {
                SalaryComponent = "abcd",
                SalaryRate = 12345.67M,
                AddToTotal = 'X',
            };

            string expected = "abcd1234567 X";
            string actual = BasicPayAdditionConverter.Format(test);
            actual.Should().Be(expected);

            test = new Gap09_BasicPayAddition()
            {
                SalaryComponent = null,
                SalaryRate = -123M,
                AddToTotal = 'z',
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

        [Fact]
        public async void ReadGap09_0008()
        {
            var inFile = GetInputFile("Gap9_0008.txt");

            if(inFile.Exists)
            {
                var engine = new FileHelperEngine<Gap09_0008_BasicPay>();
                engine.ErrorMode = ErrorMode.SaveAndContinue;
                var result = engine.ReadFileAsList(inFile.FullName);

                if (engine.ErrorManager.HasErrors)
                {
                    var errorFile = GetErrorFile();
                    engine.ErrorManager.SaveErrors(errorFile.FullName);
                }
                engine.ErrorManager.HasErrors.Should().BeFalse();

                result.Count.Should().BeGreaterThan(100);
            }
        }


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

            var service = new ImportService();
            var ds = new DataSet();
            DataTable tbl;

            tbl = service.CreateDataTable(gapFile.GetData<Gap09_0000_Actions>(), "Gap9Actions");
            ds.Tables.Add(tbl);

            tbl = service.CreateDataTable(gapFile.GetData<Gap09_0006_Address>(), "Gap9Address");
            ds.Tables.Add(tbl);

            tbl = service.CreateDataTable(gapFile.GetData<Gap09_0001_OrgAssignment>(), "Gap9OrgAssignments");
            ds.Tables.Add(tbl);
        }

    }
}
