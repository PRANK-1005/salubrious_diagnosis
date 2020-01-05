using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salubrious_System.Salubrious_Web
{
    public partial class Registration : System.Web.UI.Page
    {

        Salubrious_DataAccessLayer.UserRegister register = new Salubrious_DataAccessLayer.UserRegister();
        Salubrious_CommonLayer.Encryption encryption = new Salubrious_CommonLayer.Encryption();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        /*   -->  Register Button <--
            Accepts the values from User, check whether they are already registered if not then process their details for registration */
        protected void btn_Register_User(object sender, EventArgs e)
        {
            try
            {

                string firstName = txtfirstname.Text;
                string lastName = txtlastname.Text;
                string emailId = txtemail.Text;
                string dates = date.Text;
                string gender = ddlgender.SelectedValue.ToString();
                string password = encryption.EncryptData(txtpassword.Text);
                string confirmpwd = txtconfirmpwd.Text;
                string address = txtaddress.Text;
                string contact = txtcontact.Text;
                bool checkUser = register.CheckExistingUser(emailId, contact);

                if (checkUser == false)
                {

                    bool result = register.RegisterUser(firstName, lastName, emailId, dates, gender, password, address, contact);
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