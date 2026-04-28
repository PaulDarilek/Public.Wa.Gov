using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrms.Public.Tests
{
    public abstract class TestBase
    {
        public abstract string DefaultFileName { get; }

        protected AppSettings Settings { get; } = new AppSettings();

        protected virtual FileInfo GetInputFile() => new FileInfo(Path.Combine(Settings.InputDirectory.FullName, DefaultFileName));
        protected virtual FileInfo GetOutputFile() => new FileInfo(Path.Combine(Settings.OutputDirectory.FullName, DefaultFileName));
        protected virtual FileInfo GetErrorFile() => new FileInfo(Path.Combine(Settings.OutputDirectory.FullName, "Errors.txt"));


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

                secondRow.Should().BeEquivalentTo(firstRow);
            }
        }

    }
}
