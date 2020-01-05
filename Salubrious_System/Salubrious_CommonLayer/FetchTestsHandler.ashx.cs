using System;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Collections.Generic;



namespace Salubrious_System.Salubrious_CommonLayer
{
    /// <summary>
    /// Summary description for FetchTestsHandler
    /// </summary>
    public class FetchTestsHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            List<string> testList = new List<string>();
            string testName = context.Request["term"] ?? "";
            string connection = ConfigurationManager.ConnectionStrings["DiagnosisIntelligenceSystem"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("usp_Fetch_Tests", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@testName", testName);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

                testList.Add(rdr["test_name"].ToString());
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            context.Response.Write(js.Serialize(testList));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}