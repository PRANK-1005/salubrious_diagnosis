using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Salubrious_System.Salubrious_Web
{
    public partial class UserAppStatus : System.Web.UI.Page
    {
        Salubrious_DataAccessLayer.UserAppStatus userApp = new Salubrious_DataAccessLayer.UserAppStatus();
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string AppFrmDate = txtFrmDate.Text;
                string AppToDate = txtToDate.Text;
                string AppStatus = ddlappstatus.Text;
                DataSet uappstatus = userApp.UAppStatus(AppFrmDate, AppToDate, AppStatus);

                gvUserDashboard.DataSource = uappstatus;
                gvUserDashboard.DataBind();

            }

            catch (Exception ex)
            {
                Console.WriteLine("exception" + ex.ToString());
            }

            finally
            {

            }

        }


        protected void btnAppIDSearch_Click(object sender, EventArgs e)
        {
            try
            {

                string AppID = txtAppID.Text;
                DataSet uapp = userApp.UAppStatusbyAppID(AppID);

                gvUserDashboard.DataSource = uapp;
                gvUserDashboard.DataBind();

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