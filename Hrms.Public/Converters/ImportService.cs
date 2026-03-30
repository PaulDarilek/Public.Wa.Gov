using FileHelpers;
using Hrms.Public.Files;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Hrms.Public.Converters
{

    /// <summary>Handle Importing FlatFiles</summary>
    internal class ImportService
    {
        /// <summary>Convert a flat file into a DataTable</summary>
        public DataTable ReadFileAsDataTable<T>(FileInfo sourceFile) where T : FixedLengthFile
        {
            var engine = new FileHelperEngine<T>();
            var result = engine.ReadFileAsDT(sourceFile.FullName);
            return result;
        }

        /// <summary>Convert a flat file into a DataTable</summary>
        public List<T> ReadFileAsList<T>(FileInfo sourceFile) where T : FixedLengthFile
        {
            var engine = new FileHelperEngine<T>();
            var result = engine.ReadFileAsList(sourceFile.FullName);
            return result;
        }

        /// <summary>Import a Data Table into a SQL Server Table where the column names match</summary>
        public void BulkInsertToSql(DataTable dataTable, SqlConnection connection, string destinationTableName, bool mapByName = true, Action<Exception> errHandler = null, Action beforeInsert = null, Action afterInsert = null, int timeOutSeconds = 0)
        {
            try
            {
                EnsureOpen(connection);

                using (var bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.BulkCopyTimeout = timeOutSeconds;

                    if (mapByName)
                    {
                        // Map the columns by Name
                        for (int i = 0; i < dataTable.Columns.Count; i++)
                        {
                            string columnName = dataTable.Columns[i].ColumnName;
                            bulkCopy.ColumnMappings.Add(columnName, columnName);
                        }
                    }
                    else // Map by Number
                    {
                        // Map the columns by Name
                        for (int i = 0; i < dataTable.Columns.Count; i++)
                        {
                            bulkCopy.ColumnMappings.Add(i, i);
                        }
                    }

                    beforeInsert?.Invoke();
                    bulkCopy.DestinationTableName = destinationTableName;
                    bulkCopy.WriteToServer(dataTable);
                    afterInsert?.Invoke();
                }
            }
            catch (SqlException ex)
            {
                if (errHandler == null) throw;
                errHandler.Invoke(ex);
            }
        }

        private void EnsureOpen(SqlConnection connection)
        {
            if (ConnectionState.Open != (connection.State & ConnectionState.Open))
                connection.Open();
        }


    }
}
