using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Net;

namespace Salubrious_System.Salubrious_Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Salubrious_DataAccessLayer.DocRecommendations docRecommendation = new Salubrious_DataAccessLayer.DocRecommendations();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DoctDetails_Click(object sender, EventArgs e)
        {
            //string connection = ConfigurationManager.ConnectionStrings["DiagnosisIntelligenceSystem"].ConnectionString;
            //SqlConnection con = new SqlConnection(connection);
            //SqlCommand cmd = new SqlCommand("usp_Fetch_Tests", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //con.Open();
            //cmd.Parameters.AddWithValue("@testname", txtDiseaseName.Text);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds);

            //gvDoctDetails.DataSource = ds;
            //gvDoctDetails.DataBind();

            try
            {
                string DiseaseName = txtDiseaseName.Text;
                DataSet docrecomm = docRecommendation.DoctRecommendation(DiseaseName);

                gvDoctDetails.DataSource = docrecomm;
                gvDoctDetails.DataBind();

            }

            catch (Exception ex)
            {
                Console.WriteLine("exception" + ex.ToString());
            }

            finally
            {

            }

        }


        protected void gvDoctDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvDoctDetails.Rows[rowIndex];

                string filePath = Server.MapPath("\\Pdf\\Format of Front Pages.pdf");
                WebClient user = new WebClient();
                Byte[] FileBuffer = user.DownloadData(filePath);
                if (FileBuffer != null)
                {
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-length", FileBuffer.Length.ToString());
                    Response.BinaryWrite(FileBuffer);
                }


            }
        }
    }
}