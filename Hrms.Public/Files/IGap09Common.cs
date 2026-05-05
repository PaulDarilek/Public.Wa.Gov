using FileHelpers;
using Hrms.Public.Converters;
using Hrms.Public.Interfaces;
using System;

namespace Hrms.Public.Files
{
    public interface IGap09Common : IFixedLengthFile
    {
        /// <summary>Personnel Area (Agency/Sub equivalent)</summary>
        [StartPosition(1, "Personnel Area (Agency/Sub equivalent)")]
        string PersonnelArea { get; set; }

        /// <summary>Personnel Sub Area (Bargaining Unit equivalent)</summary>
        [StartPosition(5, "Personnel Sub Area (Bargaining Unit equivalent)")]
        string PersonnelSubArea { get; set; }

        /// <summary>Employee Group (Permanent, Temporary, etc)</summary>
        [StartPosition(9, "Employee Group (Permanent, Temporary, etc)")]
        string EmployeeGroup { get; set; }

        /// <summary>Employee Sub Group (Monthly, Hourly, etc.)</summary>
        [StartPosition(10, "Employee Sub Group (Monthly, Hourly, etc.)")]
        string EmployeeSubGroup { get; set; }

        /// <summary>Personnel Number / Employee Number</summary>
        [StartPosition(12, "PA0001 PERNR Personnel Number")]
        string PersonnelNumber { get; set; }

        /// <summary>Social Security Number</summary>
        [StartPosition(20, "PA0002 PERID Social Security Number")]
        string SSN { get; set; }

        /// <summary>Date of last change</summary>
        [StartPosition(29, "YYYYMMDD PA0000 AEDTM Date of Last Change")]
        DateTime DateChanged { get; set; }

        /// <summary>Name of person who changed object</summary>
        [StartPosition(37, "PA0000 UNAME Name of person who changed object")]
        string PersonChanged { get; set; }

        /// <summary>Record Type</summary>
        [StartPosition(49, "Record Type identifies the Gap09 subtype")]
        string RecordType { get; set; }

        /// <summary>CCYYMMDD Start Date</summary>
        [StartPosition(53, "CCYYMMDD DATS(8) PA0000 BEGDA Start date")]
        DateTime DateEffective { get; set; }

        /// <summary>End Date</summary>
        [StartPosition(61, "CCYYMMDD PA0000 ENDDA End Date")]
        DateTime EndDate { get; set; }

        // IEnumerable<string> GetValidationErrors();
    }
}