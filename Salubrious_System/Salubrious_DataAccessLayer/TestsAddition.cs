using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace Salubrious_System.Salubrious_DataAccessLayer
{
    public class TestsAddition
    {
        string connection = ConfigurationManager.ConnectionStrings["DiagnosisIntelligenceSystem"].ConnectionString;

        public bool AddTest(string testName, string testCost)
        {
            SqlConnection con = new SqlConnection(connection);
            try
            {
                //SHA256 sha = SHA256.Create();
                //byte[] tmpSource = ASCIIEncoding.ASCII.GetBytes(testName);
                //byte[] encriptedPassword = sha.ComputeHash(tmpSource);
                //CheckExistingUser(emailId, contact);
                SqlCommand cmd = new SqlCommand("usp_Add_Test", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@test_name", testName);
                cmd.Parameters.AddWithValue("@test_cost", testCost);

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
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


        public bool CheckExistingTest(string testName)
        {

            SqlConnection con = new SqlConnection(connection);
            try
            {
                SqlCommand cmd = new SqlCommand("usp_AlreadyExisting_Tests", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@test_name", testName);

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