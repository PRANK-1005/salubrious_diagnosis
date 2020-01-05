using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Salubrious_System.Salubrious_DataAccessLayer
{
    public class UserRegister
    {
        string connection = ConfigurationManager.ConnectionStrings["DiagnosisIntelligenceSystem"].ConnectionString;

        /*  --> Data Access layer - RegisterUser Method <--
            Allows the users to Register to the Diagnosis Intelligence Portal */
        public bool RegisterUser(string firstName, string lastName, string emailId, string dates, string gender, string password, string address, string contact)
        {
            SqlConnection con = new SqlConnection(connection);
            try
            {
                //CheckExistingUser(emailId, contact);
                SqlCommand cmd = new SqlCommand("usp_Diagnosis_Register_User", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@first_name", firstName);
                cmd.Parameters.AddWithValue("@last_name", lastName);
                cmd.Parameters.AddWithValue("@email", emailId);
                cmd.Parameters.AddWithValue("@dob", dates);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@contact_no", contact);
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


        /*   --> Data Access layer - CheckExistingUser Method <--
             Checks from backend(Database) whether the Users are already registered to the Diagnosis Intelligence Portal */
        public bool CheckExistingUser(string emailId, string contact)
        {

            SqlConnection con = new SqlConnection(connection);
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Diagnosis_AlreadyExisting_User", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@email", emailId);
                cmd.Parameters.AddWithValue("@contact_no", contact);
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