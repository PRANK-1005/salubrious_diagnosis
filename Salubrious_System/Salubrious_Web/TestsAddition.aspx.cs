using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salubrious_System.Salubrious_Web
{
    public partial class TestsAddition : System.Web.UI.Page
    {

        Salubrious_DataAccessLayer.TestsAddition testadd = new Salubrious_DataAccessLayer.TestsAddition();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTestAdd_Click(object sender, EventArgs e)
        {
            try
            {

                string testName = txtTestName.Text;
                string testCost = txtTestCost.Text;

                bool checkTest = testadd.CheckExistingTest(testName);

                if (checkTest == false)
                {
                    bool result = testadd.AddTest(testName, testCost);
                    Response.Write("<script LANGUAGE='JavaScript' >alert('User Registered Successfully')</script>");
                    //string message = "Your details have been saved successfully.";
                    //string script = "window.onload = function(){ alert('";
                    //script += message;
                    //script += "')};";
                    //ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
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