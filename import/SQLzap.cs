using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sport
{
    class SQLzap
    {
        public DataTable SQLBase(string selectSQL)
        {
            DataTable dataTable = new DataTable("dataBase");
            string connectionString = "Server=.\\SQLEXPRESS; Trusted_Connection=Yes; Database=Trade";
            SqlConnection sqlconn = new SqlConnection(connectionString);
            sqlconn.Open();
            SqlCommand sqlcomand = sqlconn.CreateCommand();
            sqlcomand.CommandText = selectSQL;
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlcomand);
            sqlAdapter.Fill(dataTable);
            return dataTable;
        }
    }
}
