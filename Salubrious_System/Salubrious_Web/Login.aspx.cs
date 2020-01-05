using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salubrious_System.Salubrious_Web
{
    public partial class Login : System.Web.UI.Page
    {
        Salubrious_DataAccessLayer.UserLogin loginusers = new Salubrious_DataAccessLayer.UserLogin();
        Salubrious_CommonLayer.Encryption encryption = new Salubrious_CommonLayer.Encryption();

        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        /*   -->  Login Button <--
            Accepts the values from User, check whether they are already registered if yes then allow them to login to the portal */
        protected void Login_Click(object sender, EventArgs e)
        {
            try
            {
                string emailId = txtemail.Text;
                string password = encryption.EncryptData(txtpassword.Text);

                bool loginuser = loginusers.LoginUsers(emailId, password);

                if (loginuser == true)
                {
                    Response.Redirect("Home.aspx", false);

                }

                else
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('User is not Registered, Please Register first.')</script>");
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