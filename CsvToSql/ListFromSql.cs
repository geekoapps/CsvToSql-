using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CsvToSql
{
    public class ListFromSql
    {
        protected string TableName;
        protected string ColumnName;
        public ListFromSql (string tableName,string columnName)
        {
            TableName = tableName;
            ColumnName = columnName;
        }
        public virtual List<string> AddTolist()
        {
            List<string> columnData = new List<string>();
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT "+ColumnName+" FROM "+TableName +"with (NoLock)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            columnData.Add(reader.GetString(0));
                        }
                    }
                }
            }
            return columnData;
        }

    }
}