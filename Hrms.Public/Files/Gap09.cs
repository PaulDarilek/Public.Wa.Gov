using FileHelpers;
using Hrms.Public.Converters;
using Hrms.Public.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hrms.Public.Files
{
    /// <summary>GAP09 Map (Employee Master Data)</summary>
    /// <remarks><see cref="https://support.hrms.wa.gov/sites/default/files/public/resources/interfaces/GAP9-Map.pdf"/> </remarks>
    public class Gap09 : IReadWriteFile
    {
        public List<IGap09Common> Data { get; }
        public List<string> Errors { get; }

        public int RecordCount => Data.Count;

        public Gap09()
        {
            Data = new List<IGap09Common>();
            Errors = new List<string>();
        }

        public IEnumerable<T> GetData<T>() where T : class, IGap09Common
            => Data.Where(x => x.GetType() == typeof(T)).Select(x => x as T);

        public int ReadFile(FileInfo fileInfo, FileInfo errorFile = null)
        {
            var engine = CreateEngine();

            engine.BeginReadFile(fileInfo.FullName);
            foreach (var rec in engine)
            {
                if (rec is IGap09Common data)
                {
                    Data.Add(data); continue;
                }
                else
                {
                    Errors.Add(rec.ToString());
                }
            }

            if (engine.ErrorManager.HasErrors && errorFile != null)
            {
                engine.ErrorManager.SaveErrors(errorFile.FullName);
            }
            //Debug.Assert(engine.TotalRecords == TotalRecords);
            return RecordCount;
        }

        /// <summary>Split Gap9 into Files per record type</summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public Task<Dictionary<string, FileInfo>> SplitFileAsync(FileInfo file) => file.SplitFileAsync(GetRecordType);

        public static Type RecordSelector(MultiRecordEngine engine, string record)
        {
            Debug.Assert(engine != null);
            string recordType = GetRecordType(record);
            var type = GetTypeOfRecord(recordType);

            return type;
        }

        public static string GetRecordType(string record)
            => string.IsNullOrEmpty(record) || record.Length < 53 ? null : record.Substring(48, 4);

        /// <summary>Get correct class type to hold data for the RecordType field</summary>
        /// <param name="recordType">Four digit RecordType field</param>
        /// <returns>Type or null if <paramref name="recordType"/> is invalid</returns>
        public static Type GetTypeOfRecord(string recordType)
        {
            switch (recordType)
            {
                case Gap09_0000_Actions.RecordTypeDefault:          // Record type 0000
                    return typeof(Gap09_0000_Actions);               
                
                case Gap09_0001_OrgAssignment.RecordTypeDefault:    // Record type 0001
                    return typeof(Gap09_0001_OrgAssignment);   
                
                case Gap09_0002_PersonalData.RecordTypeDefault:     // Record type 0002
                    return typeof(Gap09_0002_PersonalData);     
                
                case Gap09_0006_Address.RecordTypeDefault:          // Record type 0006
                    return typeof(Gap09_0006_Address);               
                
                case Gap09_0007_WorkSchedule.RecordTypeDefault:     // Record type 0007  Planned Working Time
                    return typeof(Gap09_0007_WorkSchedule);     
                
                case Gap09_0008_BasicPay.RecordTypeDefault:         // Record type 0008 Basic Pay
                    return typeof(Gap09_0008_BasicPay);             
                
                case Gap09_0016_Probationary.RecordTypeDefault:     // Record type 0016 Contract Elements - Probationary Period
                    return typeof(Gap09_0016_Probationary);                   
                
                case Gap09_0019_Tasks.RecordTypeDefault:            // Record type 0019 (Monitoring of Tasks) - HR Tasks to be completed at a later date - Multiple records permissible
                    return typeof(Gap09_0019_Tasks); 
                
                case Gap09_0021_Family.RecordTypeDefault:           // Record type 0021 (Family member/Dependents) - Emergency Contact - Multiple records permissible
                    return typeof(Gap09_0021_Family); 
                
                case Gap09_0022_Education.RecordTypeDefault:        // Record type 0022 (Education) - Multiple records permissible
                    return typeof(Gap09_0022_Education); 
                
                case Gap09_0023_Employers.RecordTypeDefault:        // Record type 0023 (Previous/ Other Employers) - Identifies Concurrent Employment/Dual Appointment - Multiple records permissible
                    return typeof(Gap09_0023_Employers); 
                
                case Gap09_0027_CostDistribution.RecordTypeDefault: // Record type 0027 (Cost Distribution) - Override position cost assignment - Multiple records permissible
                    return typeof(Gap09_0027_CostDistribution); 
                
                case Gap09_0040_Loan.RecordTypeDefault:             // Record type 0040 (Objects on Loan) - Used for tracking (i.e. WSP Badge #) - Multiple records permissible
                    return typeof(Gap09_0040_Loan);

                case Gap09_0041_Dates.RecordTypeDefault:            // Record type 0041 (Date Specifications) - Holds various employment dates - Multiple records permissible
                    return typeof(Gap09_0041_Dates);

                case Gap09_0077_AdditionalData.RecordTypeDefault:   // Record type 0077 (Additional Personal Data)
                    return typeof(Gap09_0077_AdditionalData); 
                
                case Gap09_0081_Military.RecordTypeDefault:         // Record type 0081 (Military Service) - Multiple records permissible
                    return typeof(Gap09_0081_Military); 
                
                case Gap09_0094_Residence.RecordTypeDefault:        // Record type 0094 (Residence Status)
                    return typeof(Gap09_0094_Residence); 

                case Gap09_0105_Communications.RecordTypeDefault:   // Record type 0105 (Comunications) - Multiple records permissible
                    return typeof(Gap09_0105_Communications); 
                
                case Gap09_0209_Unemployment.RecordTypeDefault:     // Record type 0209 (Unemployment State/Work County) 
                    return typeof(Gap09_0209_Unemployment); 
                
                case Gap09_0552_Time.RecordTypeDefault:             // Record type 0552 (Time Specifications / Employment Period)
                    return typeof(Gap09_0552_Time); 
                
                case Gap09_0167_HealthPlans.RecordTypeDefault:      // Record type 0167 (Health Plans)
                    return typeof(Gap09_0167_HealthPlans); 
                
                case Gap09_0377_MiscPlans.RecordTypeDefault:        // Record type 0377 (Miscellaneous Plans)
                    return typeof(Gap09_0377_MiscPlans); 
                
                case Gap09_0121_Personnel.RecordTypeDefault:        // Record type 0121 (Reference Personnel Numbers Priority)
                    return typeof(Gap09_0121_Personnel); 
                
                case Gap09_0169_SavingsPlan.RecordTypeDefault:      // Record type 0169 (Savings Plans)
                    return typeof(Gap09_0169_SavingsPlan); 
                
                default: return null;
            }
        }

        public int WriteFile(FileInfo file)
        {
            var engine = CreateEngine();
            engine.WriteFile(file.FullName, Data);
            Debug.Assert(engine.TotalRecords == RecordCount);

            return engine.TotalRecords;
        }

        private MultiRecordEngine CreateEngine()
        {
            var engine = new MultiRecordEngine(
                typeof(Gap09_0000_Actions),
                typeof(Gap09_0001_OrgAssignment),
                typeof(Gap09_0002_PersonalData),
                typeof(Gap09_0006_Address),
                typeof(Gap09_0007_WorkSchedule),
                typeof(Gap09_0008_BasicPay),
                typeof(Gap09_0016_Probationary),
                typeof(Gap09_0019_Tasks),
                typeof(Gap09_0021_Family),
                typeof(Gap09_0022_Education),
                typeof(Gap09_0023_Employers),
                typeof(Gap09_0027_CostDistribution),
                typeof(Gap09_0040_Loan),
                typeof(Gap09_0041_Dates),
                typeof(Gap09_0077_AdditionalData),
                typeof(Gap09_0081_Military),
                typeof(Gap09_0094_Residence),
                typeof(Gap09_0105_Communications),
                typeof(Gap09_0121_Personnel),
                typeof(Gap09_0167_HealthPlans),
                typeof(Gap09_0169_SavingsPlan),
                typeof(Gap09_0209_Unemployment),
                typeof(Gap09_0377_MiscPlans),
                typeof(Gap09_0552_Time)
                )
            {
                RecordSelector = RecordSelector
            };

            // Switch error mode on
            engine.ErrorManager.ErrorMode = ErrorMode.SaveAndContinue;
            return engine;
        }

    }

}
