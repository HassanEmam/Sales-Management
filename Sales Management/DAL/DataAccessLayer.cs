using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace Sales_Management.DAL
{
    class DataAccessLayer
    {
        SqlConnection sqlconnection;
        // Constructor to initialize the connection object
        public DataAccessLayer()
        {
            sqlconnection= new SqlConnection(@"Srever=.\SQLEXPRESS; Database=Sales_Management; Integrated Security=true");
        }

        // method to open the connection
        public void open()
        {
            if (sqlconnection.State != ConnectionState.Open)
            {
                sqlconnection.Open();
            }
        }

        // method to close the connection

        public void close()
        {
            if(sqlconnection.State == ConnectionState.Open)
            {
                sqlconnection.Close();
            }
        }

        // Function to read Data from database using stored procedures
        // the function takes takes two inputs 1) stored procedure name 
        // 2) an array of the stored procedure parameters
        public DataTable SelectData(string stored_procedure, SqlParameter[] parameters)
        {
            SqlCommand sqlcmd= new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            if (stored_procedure != null)
            {
                sqlcmd.CommandText = stored_procedure;
            }
            if (parameters !=null)
            {
                sqlcmd.Parameters.AddRange(parameters);
            }
            SqlDataAdapter DA = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            DA.Fill(dt);
            return dt;
        }

        // method to delete, update, and insert data into the database
        public void ExecuteCommand(string storedProcedure, SqlParameter[] parameters)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            if (storedProcedure!=null)
            {
                sqlcmd.CommandText = storedProcedure;
            }
            if (parameters != null)
            {
                sqlcmd.Parameters.AddRange(parameters);
            }
            sqlcmd.ExecuteNonQuery();
        }

    }

}
