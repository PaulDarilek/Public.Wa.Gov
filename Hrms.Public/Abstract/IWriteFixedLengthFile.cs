using Microsoft.Extensions.FileProviders;

namespace Hrms.Public.Abstract
{
    public interface IWriteFixedLengthFile
    {
        int WriteFile(IFileInfo fileInfo);
    }

}
