namespace Hrms.Public.Abstract
{

    /// <summary>Marker Interface for Fixed Length File Formats</summary>
    // <remarks>See https://support.hrms.wa.gov/resources/interfaces</remarks>
    public interface IFixedLengthFile
    {
        int GetRecordLength();

        bool IsPossibleRecord(string record);

    }

}
