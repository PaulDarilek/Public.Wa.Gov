using FluentAssertions;
using Hrms.Public.Files;
using Hrms.Public.Interfaces;

namespace Hrms.Public.Tests.GapFileTests
{
    public abstract class TestBaseHeaderDetail<TGapFile, THeader, TDetail> : TestBase<TGapFile>
        where THeader : class, IFixedLengthFile
        where TDetail : class, IFixedLengthFile
        where TGapFile : HeaderDetailBase<THeader, TDetail>, new()
    {


        protected override TGapFile? ImportGapFile()
        {
            if (!InputFile.Exists) return null;

            var gapImport = new TGapFile();
            gapImport.Header.Should().BeNull("Constructor should not set");
            gapImport.Details.Should().NotBeNull("Constructor should create empty list");

            int expectedCount = InputFile.GetLineCount();
            var readCount = gapImport.ReadFile(InputFile);

            readCount.Should().Be(expectedCount);

            if (expectedCount > 0)
            {
                gapImport.Header.Should().NotBeNull("Expected the first line to be a header");
                gapImport.Details.Count.Should().Be(expectedCount - 1, $"Expect {expectedCount - 1} of the {expectedCount} lines to be details");
            }

            return gapImport;
        }



    }
}
