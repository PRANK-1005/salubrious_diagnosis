using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Salubrious_System.Salubrious_DataAccessLayer
{
    public class UserAppStatus
    {
        string connection = ConfigurationManager.ConnectionStrings["DiagnosisIntelligenceSystem"].ConnectionString;

        public DataSet UAppStatus(string appfrmdate, string apptodate, string appstatus)
        {
            SqlConnection con = new SqlConnection(connection);
            try
            {
                SqlCommand cmd = new SqlCommand("usp_FetchAppStatus", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@app_frm_date", appfrmdate);
                cmd.Parameters.AddWithValue("@app_to_date", apptodate);
                cmd.Parameters.AddWithValue("@app_status", appstatus);
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

        public DataSet UAppStatusbyAppID(string appid)
        {
            SqlConnection con = new SqlConnection(connection);
            try
            {
                SqlCommand cmd = new SqlCommand("usp_AppStatus", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@appointment_no", appid);
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