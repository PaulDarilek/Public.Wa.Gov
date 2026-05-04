using FluentAssertions;
using Hrms.Public.Interfaces;
using System.Runtime.CompilerServices;

namespace Hrms.Public.Tests.GapFileTests
{
    public abstract class TestBase<TGapFile> 
        where TGapFile : class, IReadWriteFile, new()
    {
        public abstract string DefaultFileName { get; }

        protected AppSettings Settings { get; } = new AppSettings();

        public FileInfo InputFile { get; set; }
        public FileInfo OutputFile { get; set; }

        protected TGapFile? GapFile { get; set; }


        protected TestBase()
        {
            InputFile = GetInputFile();
            OutputFile = GetOutputFile();
        }

        protected virtual FileInfo GetInputFile(string? fileName = null)
        {
            var file = new FileInfo(Path.Combine(Settings.InputDirectory.FullName, fileName ?? DefaultFileName));

            var testData = new FileInfo(Path.Combine(Environment.CurrentDirectory, "TestData", file.Name));

            if (!file.Exists && testData.Exists)
            {
                testData.CopyTo(file.FullName);
                file.Refresh();
            }

            return file;
        }

        protected virtual FileInfo GetOutputFile(string? fileName = null) => new FileInfo(Path.Combine(Settings.OutputDirectory.FullName, fileName ?? DefaultFileName));
       
        protected virtual FileInfo GetErrorFile(bool deleteIfExists = true, [CallerMemberName] string? methodName = null)
        {
            string fileName = $"Errors_{methodName}.txt";
            var file = new FileInfo(Path.Combine(Settings.OutputDirectory.FullName, fileName));
            if (deleteIfExists && file.Exists)
            {
                file.Delete();
            }
            return file;    
        }

        [Fact]
        public void Import()
        {
            GapFile ??= ImportGapFile();
            if (GapFile != null)
            {
                int expectedCount = InputFile.GetLineCount();
                GapFile.TotalCount.Should().Be(expectedCount);
            }
        }

        [Fact]
        public void Export()
        {
            GapFile ??= ImportGapFile();
            if (GapFile != null)
            {
                int writeCount;
                writeCount = GapFile.WriteFile(OutputFile);
                OutputFile.Refresh();
                writeCount.Should().Be(GapFile.TotalCount);
            }
        }


        [Fact]
        public void ImportExportCompare()
        {
            if (!OutputFile.Exists)
            {
                Export();
            }

            if (InputFile.Exists && OutputFile.Exists)
            {
                InputFile.CompareFileContents(OutputFile);
            }
        }


        protected virtual TGapFile? ImportGapFile()
        {
            if (!InputFile.Exists) return null;

            var gapImport = new TGapFile();

            int expectedCount = InputFile.GetLineCount();
            var readCount = gapImport.ReadFile(InputFile);

            readCount.Should().Be(gapImport.TotalCount);
            readCount.Should().Be(expectedCount);

            return gapImport;
        }

    }
}
