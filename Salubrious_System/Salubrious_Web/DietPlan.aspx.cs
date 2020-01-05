using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;
using System.Configuration;

namespace Salubrious_System.Salubrious_Web
{
    public partial class DietPlan : System.Web.UI.Page
    {
        Salubrious_DataAccessLayer.DietPlan diet = new Salubrious_DataAccessLayer.DietPlan();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void DietDetails_Click(object sender, EventArgs e)
        {
            try
            {
                string DiseaseName = txtDiseaseName.Text;
                DataSet docrecomm = diet.DietPlans(DiseaseName);

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
            string FilePath = ConfigurationManager.AppSettings["FilePath"];

            if (e.CommandName == "Select")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvDoctDetails.Rows[rowIndex];
                string fileName = FilePath + "Format of Front Pages.pdf";
                //string filePath = Request.MapPath(FilePath);
                WebClient user = new WebClient();
                Byte[] FileBuffer = user.DownloadData(fileName);
                if (FileBuffer != null)
                {
                    Response.ContentType = "application/pdf";
                    Response.AppendHeader("Content-Disposition;", "attachment;");
                    Response.BinaryWrite(FileBuffer);

                }

            }
        }
    }
}