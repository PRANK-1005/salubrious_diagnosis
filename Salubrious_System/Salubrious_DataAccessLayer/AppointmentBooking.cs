using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Salubrious_System.Salubrious_DataAccessLayer
{
    public class AppointmentBooking
    {

        string connection = ConfigurationManager.ConnectionStrings["DiagnosisIntelligenceSystem"].ConnectionString;
        public DataSet FetchTestsNames(string TestName)
        {
            SqlConnection con = new SqlConnection(connection);
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Fetch_Tests", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@testname", TestName);
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

        public DataSet FetchTest(string Testid)
        {
            SqlConnection con = new SqlConnection(connection);
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Fetch_Test", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@testid", Testid);
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
