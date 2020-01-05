using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Salubrious_System.Salubrious_DataAccessLayer
{
    public class DiseasesAddition
    {

        string connection = ConfigurationManager.ConnectionStrings["DiagnosisIntelligenceSystem"].ConnectionString;

        public bool AddDiseases(string DiseaseID, string DiseaseName)
        {
            SqlConnection con = new SqlConnection(connection);
            try
            {

                SqlCommand cmd = new SqlCommand("usp_Add_DiseaseswithIDs", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@Disease_id", DiseaseID );
                cmd.Parameters.AddWithValue("@Disease_name", DiseaseName);

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }


                //SqlCommand cmd = new SqlCommand("usp_Add_Diseases", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //con.Open();
                //cmd.Parameters.AddWithValue("@Disease_name", DiseaseName);

                //int result = cmd.ExecuteNonQuery();

                //if (result > 0)
                //{
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}

            }

            catch (Exception e)
            {

                Console.WriteLine("exception" + e.ToString());
                return false;
            }

            finally
            {
                con.Close();
            }


        }


        public bool CheckExistingDiseases(string DiseaseName)
        {

            SqlConnection con = new SqlConnection(connection);
            try
            {
                SqlCommand cmd = new SqlCommand("usp_AlreadyExisting_Diseases", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@Disease_name", DiseaseName);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    return true;

                }

                else
                {
                    return false;
                }

            }

            catch (Exception e)
            {
                Console.WriteLine("exception" + e.ToString());
                return false;
            }

            finally
            {
                con.Close();
            }


        }

        //public string FetchMaxDiseaseID()
        //{
        //    SqlConnection con = new SqlConnection(connection);
        //    try
        //    {

        //        SqlCommand cmd = new SqlCommand("usp_FetchMaxDiseaseID", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        con.Open();
        //        SqlDataReader read = cmd.ExecuteReader();
        //        while(read.HasRows)
        //        {
        //            string result = read["disease_id"].ToString();
        //        }

        //    }

        //    catch (Exception e)
        //    {

        //        Console.WriteLine("exception" + e.ToString());
        //        return false;
        //    }

        //    finally
        //    {
        //        con.Close();
        //    }


        //}
    }
}