using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Salubrious_System
{
    /// <summary>
    /// Summary description for GetTestDetails
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class GetTestDetails : System.Web.Services.WebService
    {

        [WebMethod]
        public List<RespObj> TestDetails(string term)
        {
            //List<string> testList = new List<string>();
            List<RespObj> testList = new List<RespObj>();
            string connection = ConfigurationManager.ConnectionStrings["DiagnosisIntelligenceSystem"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("usp_Fetch_Tests", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@testName", term);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                testList.Add(new RespObj()
                {
                    label = rdr["test_name"].ToString(),
                    value = rdr["test_id"].ToString()

                });
            }
            return testList;
        }
       public class RespObj
        {
            public string label { get; set; }
            public string value { get; set; }
        }
    }
}
