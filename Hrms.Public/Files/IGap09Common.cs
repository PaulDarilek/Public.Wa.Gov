using Hrms.Public.Converters;
using Hrms.Public.Interfaces;
using System;

namespace Hrms.Public.Files
{
    public interface IGap09Common : IFixedLengthFile
    {
        /// <summary>Personnel Area (Agency/Sub equivalent)</summary>
	[StartPosition(1)]
        string PersonnelArea { get; set; }

        /// <summary>Personnel Sub Area (Bargaining Unit equivalent)</summary>
	[StartPosition(5)]
        string PersonnelSubArea { get; set; }

        /// <summary>Employee Group (Permanent, Temporary, etc)</summary>
	[StartPosition(9)]
        string EmployeeGroup { get; set; }

        /// <summary>Employee Sub Group (Monthly, Hourly, etc.)</summary>
	[StartPosition(10)]
        string EmployeeSubGroup { get; set; }

        /// <summary>Personnel Number / Employee Number</summary>
        /// <remarks>PA0001 PERNR Personnel Number</remarks>
	[StartPosition(12)]
        string PersonnelNumber { get; set; }

        /// <summary>Social Security Number</summary>
        /// <remarks>PA0002 PERID Social Security Number</remarks>
	[StartPosition(20)]
        string SSN { get; set; }

        /// <summary>Date of last change</summary>
        /// <remarks>YYYYMMDD PA0000 AEDTM Date of Last Change</remarks>
	[StartPosition(29)]
        DateTime DateChanged { get; set; }

        /// <summary>Name of person who changed object</summary>
        /// <remarks>PA0000 UNAME Name of person who changed object</remarks>
	[StartPosition(37)]
        string PersonChanged { get; set; }

        /// <summary>Record Type</summary>
        /// <remarks>Record Type identifies the Gap09 subtype</remarks>
	[StartPosition(49)]
        string RecordType { get; set; }

        /// <summary>CCYYMMDD Start Date</summary>
        /// <remarks>CCYYMMDD DATS(8) PA0000 BEGDA Start date</remarks>
	[StartPosition(53)]
        DateTime DateEffective { get; set; }

        /// <summary>End Date</summary>
        /// <remarks>CCYYMMDD PA0000 ENDDA End Date</remarks>
	[StartPosition(61)]
        DateTime EndDate { get; set; }

        // IEnumerable<string> GetValidationErrors();
    }
}