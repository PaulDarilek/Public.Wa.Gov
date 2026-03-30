using System;
using System.Data;
using System.IO;

namespace Hrms.Public.Converters
{
    /// <summary>Helps with Importing CSV Files into Provided DataTable</summary>
    internal abstract class CsvHelperBase
    {
        public DataTable Table { get; }
        public string TableName => Table.TableName;

        public int FieldCount { get; }

        /// <summary>File to Import</summary>
        public FileInfo CsvFileInfo { get; set; }

        public Action<string[]> OnRowAdded { get; set; }

        /// <summary>Constructor</summary>
        public CsvHelperBase(string tableName, int fieldCount)
        {
            Table = new DataTable(tableName);
            FieldCount = fieldCount;
            ConfigureTable();
            //Debug.Assert(Table.Columns.Count == FieldCount);
        }

        public virtual int ImportCsvFile(bool firstRowIsHeader, bool trimWhiteSpace = true, bool fieldsAreQuoted = true, string delimiters = ",")
        {
            int count = 0;
            var parser = new CsvTextFieldParser(CsvFileInfo.FullName)
            {
                Delimiters = new string[] { delimiters },
                HasFieldsEnclosedInQuotes = fieldsAreQuoted,
                TrimWhiteSpace = trimWhiteSpace,
            };
            string[] fields;
            if (firstRowIsHeader)
            {
                fields = parser.ReadFields(); 
                VerifyHeader(fields);
                count++;
            }

            while (!parser.EndOfData)
            {
                fields = parser.ReadFields();
                count++;
                AddRow(fields);
            }
            parser.Close();
            return count;
        }

        public bool AddRow(string[] fields)
        {
            var row = Table.NewRow();
            bool isValid = BuildRow(row, fields);
            if (isValid)
            {
                Table.Rows.Add(row);
                OnRowAdded?.Invoke(fields);
            }
            return isValid;
        }

        public virtual bool VerifyHeader(string[] fields) => fields != null && fields.Length == FieldCount;

        /// <summary>Called from Constructor to set up Table Columns</summary>
        protected abstract void ConfigureTable();

        /// <summary>Copy Field Data to a Data Row</summary>
        /// <returns>True if row is valid</returns>
        protected abstract bool BuildRow(DataRow row, string[] fields);

    }
}
