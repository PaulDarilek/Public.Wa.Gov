using System.IO;

namespace Hrms.Public.Interfaces
{
    public interface IReadWriteFile
    {
        int RecordCount { get; }
        int ReadFile(FileInfo fileInfo, FileInfo errorFile = null);
        int WriteFile(FileInfo fileInfo);
    }
}