using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Salubrious_System.Salubrious_DataAccessLayer
{
    public class DocRecommendations
    {
        string connection = ConfigurationManager.ConnectionStrings["DiagnosisIntelligenceSystem"].ConnectionString;
        public DataSet DoctRecommendation(string DiseaseName)
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

                //gvDoctDetails.DataSource = ds;
                //gvDoctDetails.DataBind();

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

        //public DataSet dc(string DiseaseName)
        //{
        //    SqlConnection con = new SqlConnection(connection);
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("usp_Fetch_DiseasesID", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        con.Open();
        //        cmd.Parameters.AddWithValue("@deseaseName", DiseaseName);
        //        SqlDataReader reader =cmd.ExecuteReader();
        //        return reader;
        //        //cmd.Parameters.AddWithValue("@deseaseName", DiseaseName);
        //        //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        //DataSet ds = new DataSet();
        //        //da.Fill(ds);


        //        //gvDoctDetails.DataSource = ds;
        //        //gvDoctDetails.DataBind();

        //    }

        //    catch (Exception e)
        //    {

        //        Console.WriteLine("exception" + e.ToString());
        //        return dr;
        //    }

        //    finally
        //    {
        //        con.Close();
        //    }

        //}
    }
}