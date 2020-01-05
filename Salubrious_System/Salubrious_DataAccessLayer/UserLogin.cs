using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Salubrious_System.Salubrious_DataAccessLayer
{
    public class UserLogin
    {
        string connection = ConfigurationManager.ConnectionStrings["DiagnosisIntelligenceSystem"].ConnectionString;

        /*   --> Data Access layer - LoginUsers Method <--
              Allow the Users to Login to the Diagnosis Intelligence Portal with already registered details */
        public bool LoginUsers(string emailId, string password)
        {
            SqlConnection con = new SqlConnection(connection);
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Diagnosis_Login_User", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@email", emailId);
                cmd.Parameters.AddWithValue("@password", password);
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
    }
}