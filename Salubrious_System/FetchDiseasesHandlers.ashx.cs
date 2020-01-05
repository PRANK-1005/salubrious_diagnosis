using System;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Collections.Generic;

namespace Salubrious_System
{
    /// <summary>
    /// Summary description for FetchDiseasesHandler
    /// </summary>
    public class FetchDiseasesHandlers : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            List<String> testList = new List<string>();
            string diseaseName = context.Request["term"] ?? "";
            string connection = ConfigurationManager.ConnectionStrings["DiagnosisIntelligenceSystem"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("usp_Fetch_Deseases", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@deseaseName", diseaseName);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

                testList.Add(rdr["diseases_name"].ToString());
                testList.Add(rdr["diseaseid"].ToString());
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