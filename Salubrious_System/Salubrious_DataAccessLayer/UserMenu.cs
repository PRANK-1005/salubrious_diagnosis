using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace Salubrious_System.Salubrious_DataAccessLayer
{
    public class UserMenu
    {
        string connection = ConfigurationManager.ConnectionStrings["DiagnosisIntelligenceSystem"].ConnectionString;
        public DataSet BuildMenu(int isadmin)
        {
            SqlConnection con = new SqlConnection(connection);
            try
            {
                SqlCommand cmd = new SqlCommand("usp_IsAdmin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@isadmin", isadmin);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }

            catch (Exception e)
            {
                DataSet ds = new DataSet();
                Console.WriteLine("exception" + e.ToString());
                return ds;
            }

            finally
            {
                con.Close();
            }

        }
    }
}