using System.IO;

namespace Hrms.Public.Abstract
{
    public interface IReadWriteFile
    {
        int ReadFile(FileInfo fileInfo);
        int WriteFile(FileInfo fileInfo);
    }
}