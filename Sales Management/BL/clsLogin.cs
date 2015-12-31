using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace Sales_Management.BL
{
    class clsLogin
    {
        public DataTable login(string ID, string password)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@ID", SqlDbType.VarChar);
            parameters[0].Value = ID;
            parameters[1] = new SqlParameter("@PWD", SqlDbType.VarChar);
            parameters[1].Value = password;
            DAL.open();
            DataTable dt = new DataTable();
            dt= DAL.SelectData("SP_LOGIN", parameters);
            return dt;
        }
    }
}
