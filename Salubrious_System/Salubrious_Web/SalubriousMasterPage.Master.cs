using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Salubrious_System.Salubrious_Web
{
    public partial class SalubriousMasterPage : System.Web.UI.MasterPage
    {
        Salubrious_DataAccessLayer.UserMenu menu = new Salubrious_DataAccessLayer.UserMenu();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindMenu();
            }
           
        }

        protected void BindMenu()
        {
            int isadmin = 0;
            DataSet ds = menu.BuildMenu(isadmin);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                MenuItem menuItem = new MenuItem();
                menuItem.Text = row["menu_name"].ToString();
                menuItem.NavigateUrl = row["menu_url"].ToString();
                MasterPageMenu.Items.Add(menuItem);
                


            }


        }
    }
}