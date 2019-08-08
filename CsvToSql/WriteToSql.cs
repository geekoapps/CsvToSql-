using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CsvToSql
{

    class WriteToSql
    {
        protected DataTable DataTable;
        protected string TableName; 
        public WriteToSql(DataTable datatable,string tablename)
        {
            DataTable = datatable;
            TableName = tablename;
        }
        public virtual string Write()
        {


            string connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    foreach (DataColumn c in DataTable.Columns)
                        bulkCopy.ColumnMappings.Add(c.ColumnName, c.ColumnName);

                    bulkCopy.DestinationTableName = TableName;
                    try
                    {
                        bulkCopy.WriteToServer(DataTable);
                        return "Complete";

                    }
                    catch (SqlException ex)
                    {
                        StringBuilder errorMessages = new StringBuilder();
                        for (int i = 0; i < ex.Errors.Count; i++)
                        {
                            errorMessages.Append("Index #" + i + "\n" +
                                "Message: " + ex.Errors[i].Message + "\n" +
                                "Error Number: " + ex.Errors[i].Number + "\n" +
                                "LineNumber: " + ex.Errors[i].LineNumber + "\n");
                        }
                        return errorMessages.ToString();
                    }
                }

            }
            }
        }
    }

