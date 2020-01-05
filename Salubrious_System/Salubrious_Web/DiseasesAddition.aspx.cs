using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salubrious_System.Salubrious_Web
{
    public partial class DiseasesAddition : System.Web.UI.Page
    {
        Salubrious_DataAccessLayer.DiseasesAddition diseasesAdd = new Salubrious_DataAccessLayer.DiseasesAddition();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDiseases_Click(object sender, EventArgs e)
        {
            try
            {
                string DiseaseID = txtDiseaseId.Text;
                string DiseaseName = txtDiseaseName.Text;

                bool checkDisease = diseasesAdd.CheckExistingDiseases(DiseaseName);

                if (checkDisease == false)
                {
                    bool result = diseasesAdd.AddDiseases(DiseaseID, DiseaseName);
                    Response.Write("<script LANGUAGE='JavaScript' >alert('User Registered Successfully')</script>");

                }

                else
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('User Already Exists')</script>");
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine("exception" + ex.ToString());
            }

            finally
            {

            }

        }
    }
}