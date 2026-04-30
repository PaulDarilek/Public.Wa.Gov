using FluentAssertions;

namespace Hrms.Public.Tests
{
    public abstract class TestBase
    {
        public abstract string DefaultFileName { get; }
        public virtual string ErrorFileName { get; } = "Errors.txt";

        protected AppSettings Settings { get; } = new AppSettings();

        protected virtual FileInfo GetInputFile(string? fileName = null) => new FileInfo(Path.Combine(Settings.InputDirectory.FullName, fileName ?? DefaultFileName));
        protected virtual FileInfo GetOutputFile(string? fileName = null) => new FileInfo(Path.Combine(Settings.OutputDirectory.FullName, fileName ?? DefaultFileName));
        protected virtual FileInfo GetErrorFile(string? fileName = null) => new FileInfo(Path.Combine(Settings.OutputDirectory.FullName, fileName ?? ErrorFileName));

        protected void CopyTestDataToInput(FileInfo file)
        {
            if (file.Exists) 
                return;
            
            var source = new FileInfo(Path.Combine(Environment.CurrentDirectory, "TestData", file.Name ?? DefaultFileName));
            
            if (source.Exists)
                source.CopyTo(file.FullName);
        }


        /// <summary>Compare two files line by Line</summary>
        public static void CompareFiles(FileInfo firstFile, FileInfo secondFile)
        {
            firstFile.Refresh();
            firstFile.Exists.Should().BeTrue();

            secondFile.Refresh();
            secondFile.Exists.Should().BeTrue();

            secondFile.Length.Should().Be(firstFile.Length);


            var firstLines = File.ReadAllLines(firstFile.FullName);
            var secondLines = File.ReadAllLines(secondFile.FullName);

            secondLines.Length.Should().Be(firstLines.Length);

            for (int i = 0; i < secondLines.Length; i++)
            {
                var firstRow = firstLines[i];
                var secondRow = secondLines[i];

                secondRow.Should().BeEquivalentTo(firstRow, $"Lines {i+1} should match");
            }
        }

    }
}
