using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Salubrious_System.Salubrious_DataAccessLayer
{
    public class DietPlan
    {

        string connection = ConfigurationManager.ConnectionStrings["DiagnosisIntelligenceSystem"].ConnectionString;
        public DataSet DietPlans(string DiseaseName)
        {
            SqlConnection con = new SqlConnection(connection);
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Fetch_DiseasesID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@deseaseName", DiseaseName);
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