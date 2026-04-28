using FileHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Hrms.Public.Files
{
    /// <summary>GAP09 Map (Employee Master Data)</summary>
    /// <remarks><see cref="https://support.hrms.wa.gov/sites/default/files/public/resources/interfaces/GAP9-Map.pdf"/> </remarks>
    public class Gap09
    {
        public List<Gap09Actions> Actions { get; set; }
        public List<Gap09Address> Addresses { get; set; }
        public List<Gap09OrgAssignment> OrgAssignments { get; set; }
        public List<Gap09PersonalData> PersonalData { get; set; }
        public int CountOther { get; set; }
        public int TotalRecords => CountOther + Actions.Count  + Addresses.Count + OrgAssignments.Count + PersonalData.Count;

        public Gap09()
        {
            Actions = Actions ?? new List<Gap09Actions>();
            Addresses = Addresses ?? new List<Gap09Address>();
            OrgAssignments = OrgAssignments ?? new List<Gap09OrgAssignment>();
            PersonalData = PersonalData ?? new List<Gap09PersonalData>();
        }

        public int ReadFile(FileInfo fileInfo, FileInfo errorFile)
        {
            var engine = new MultiRecordEngine(
                typeof(Gap09Actions),
                typeof(Gap09OrgAssignment),
                typeof(Gap09PersonalData),
                typeof(Gap09Address),
                typeof(NotImplementedRecord));


            engine.RecordSelector = new RecordTypeSelector(Selector);
            // Switch error mode on
            engine.ErrorManager.ErrorMode = ErrorMode.SaveAndContinue;

            engine.BeginReadFile(fileInfo.FullName);
            foreach (var rec in engine)
            {
                Console.WriteLine(rec.ToString());
                if (rec is Gap09Actions action) { Actions.Add(action); continue; }
                if (rec is Gap09Address address) { Addresses.Add(address); continue; }
                if (rec is Gap09OrgAssignment org) { OrgAssignments.Add(org); continue; }
                if (rec is Gap09PersonalData personalData) { PersonalData.Add(personalData); continue; }

                if (rec is NotImplementedRecord notImplemented) { CountOther++; continue; }
            }

            if (engine.ErrorManager.HasErrors)
                engine.ErrorManager.SaveErrors(errorFile.FullName);

            return engine.TotalRecords;
        }


        protected Type Selector(MultiRecordEngine engine, string recordLine)
        {
            Debug.Assert(engine != null);
            return Selector(recordLine);
        }

        protected Type Selector(string recordLine)
        {
            if (string.IsNullOrEmpty(recordLine) || recordLine.Length < 53)
            {
                return null;
            }
            
            string recordType = recordLine.Substring(48, 4);
            switch (recordType)
            {
                case "0000": return typeof(Gap09Actions);
                case "0001": return typeof(Gap09OrgAssignment);
                case "0002": return typeof(Gap09PersonalData);
                case "0006": return typeof(Gap09Address);
                case "0007": return typeof(NotImplementedRecord); // Planned Working Time
                case "0008": return typeof(NotImplementedRecord); // Basic Pay
                case "0016": return typeof(NotImplementedRecord); // Contract Elements - Probationary Period
                case "0019": return typeof(NotImplementedRecord); // Record type 0019 (Monitoring of Tasks) - HR Tasks to be completed at a later date - Multiple records permissible
                case "0021": return typeof(NotImplementedRecord); // Record type 0021 (Family member/Dependents) - Emergency Contact - Multiple records permissible
                case "0022": return typeof(NotImplementedRecord); // Record type 0022 (Education) - Multiple records permissible
                case "0023": return typeof(NotImplementedRecord); // Record type 0023 (Previous/ Other Employers) - Identifies Concurrent Employment/Dual Appointment - Multiple records permissible
                case "0027": return typeof(NotImplementedRecord); // Record type 0027 (Cost Distribution) - Override position cost assignment - Multiple records permissible
                case "0040": return typeof(NotImplementedRecord); // Record type 0040 (Objects on Loan) - Used for tracking (i.e. WSP Badge #) - Multiple records permissible
                case "0041": return typeof(NotImplementedRecord); // Record type 0041 (Date Specifications) - Holds various employment dates - Multiple records permissible
                case "0077": return typeof(NotImplementedRecord); // Record type 0077 (Additional Personal Data)
                case "0081": return typeof(NotImplementedRecord); // Record type 0081 (Military Service) - Multiple records permissible
                case "0094": return typeof(NotImplementedRecord); // Record type 0094 (Residence Status)
                case "0105": return typeof(NotImplementedRecord); // Record type 0105 (Comunications) - Multiple records permissible
                case "0209": return typeof(NotImplementedRecord); // Record type 0209 (Unemployment State/Work County) 
                case "0552": return typeof(NotImplementedRecord); // Record type 0552 (Time Specifications / Employment Period)
                case "0167": return typeof(NotImplementedRecord); // Record type 0167 (Health Plans)
                case "0377": return typeof(NotImplementedRecord); // Record type 0377 (Miscellaneous Plans)
                case "0121": return typeof(NotImplementedRecord); // Record type 0121 (Reference Personnel Numbers Priority)
                case "0169": return typeof(NotImplementedRecord); // Record type 0169 (Savings Plans)
                default: return null;
            }
        }



    }

    [FixedLengthRecord(FixedMode.AllowVariableLength)]
    public class NotImplementedRecord
    {
        [FieldFixedLength(8192)]
        [FieldTrim(TrimMode.Right)]
        public string Data;
    }
}
