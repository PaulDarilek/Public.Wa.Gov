using FluentAssertions;
using Hrms.Public.Abstract;

namespace Hrms.Public.Tests
{
    public abstract class TestBaseHeaderDetail<TGapFile, THeader, TDetail> : TestBase
        where THeader : class, IFixedLengthFile
        where TDetail : class, IFixedLengthFile
        where TGapFile : HeaderDetailBase<THeader, TDetail>, new()
    {

        public virtual void ReadFile()
        {
            var gapFile = GetInputFile();
            if (gapFile.Exists)
            {
                var import = Import(gapFile);
                import.Should().NotBeNull();
            }
        }

        public virtual void WriteFile()
        {
            var inFileInfo = GetInputFile();
            var outFileInfo = GetOutputFile();

            var import = Import(inFileInfo);

            import.Should().NotBeNull();
            int expected = import.Details.Count + (import.Header == null ? 0 : 1);

            var outCount = Export(import, outFileInfo);

            outCount.Should().Be(expected);
        }

        public virtual void Import_Export_FilesCompare()
        {
            var inFileInfo = GetInputFile();
            var outFileInfo = GetOutputFile();

            var import = Import(inFileInfo);
            import.Should().NotBeNull();
            _ = Export(import, outFileInfo);

            outFileInfo.Refresh();
            CompareFiles(inFileInfo, outFileInfo);
        }

        protected virtual int Export(TGapFile gapFile) => Export(gapFile, GetOutputFile());

        protected virtual int Export(TGapFile gapFile, FileInfo outputFile)
        {
            int expected = gapFile.Details.Count + (gapFile.Header == null ? 0 : 1);

            int outCount = gapFile.WriteFile(outputFile);
            outCount.Should().Be(expected);

            return outCount;
        }

        protected virtual TGapFile? Import() => Import(GetInputFile());

        protected virtual TGapFile? Import(FileInfo gapFile)
        {
            if (!gapFile.Exists) return null;

            var gapImport = new TGapFile();
            gapImport.Header.Should().BeNull("Constructor should not set");
            gapImport.Details.Should().NotBeNull("Constructor should create empty list");

            var returnVal = gapImport.ReadFile(gapFile);

            int lineCount =
                gapFile.Length == 0 ? 0 :
                File.ReadAllLines(gapFile.FullName).Length;

            returnVal.Should().Be(lineCount);

            if (lineCount > 0)
            {
                gapImport.Header.Should().NotBeNull("Expected the first line to be a header");
                gapImport.Details.Count.Should().Be(lineCount - 1, $"Expect {lineCount - 1} of the {lineCount} lines to be details");
            }

            return gapImport;
        }

    }
}
