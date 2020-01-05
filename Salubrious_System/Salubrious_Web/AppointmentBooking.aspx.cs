using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services;

namespace Salubrious_System.Salubrious_Web
{
    public partial class AppointmentBooking : System.Web.UI.Page
    {
        DataTable testDt;
        Salubrious_DataAccessLayer.AppointmentBooking bookapp = new Salubrious_DataAccessLayer.AppointmentBooking();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (ViewState["dtTestDetail"] != null)
            //    testDt = (DataTable)ViewState["dtTestDetail"];
            if (!IsPostBack)
            {
                SetInitialRow();
                FirstGridViewRow();
            }

        }

        private void FirstGridViewRow()
        {
           
        }
        //private void AddNewRowToGrid(string testId)
        //{
        //    if(ViewState["dtTestDetail"] !=null)
        //    {
        //        testDt = new DataTable();
        //        testDt.Columns.Add("test_id");
        //        testDt.Columns.Add("Test_name");
        //        testDt.Columns.Add("cost");

        //        foreach (GridViewRow gvRow in gvappointmentTests.Rows)
        //        {
        //            DataRow drCurrentRow = testDt.NewRow();
        //            drCurrentRow["test_id"] = ((Label)gvRow.FindControl("test_id")).Text;
        //            drCurrentRow["Test_name"] = ((TextBox)gvRow.FindControl("Test_name")).Text;
        //            drCurrentRow["cost"] = ((TextBox)gvRow.FindControl("cost")).Text;
        //            testDt.Rows.Add(drCurrentRow);
        //        }

        //        DataRow dr = testDt.NewRow();
        //        dr["sno"] = "";
        //        dr["name"] = "";

        //        testDt.Rows.Add(dr);

        //        gvappointmentTests.DataSource = testDt;
        //        gvappointmentTests.DataBind();

        //    }
        //    else
        //    {
        //        string TestId = testId;
        //        DataSet docrecomm = bookapp.FetchTest(testId);
        //        ViewState["dtTestDetail"] = docrecomm;
        //        gvappointmentTests.DataSource = ViewState["dtTestDetail"];
        //        gvappointmentTests.DataBind();
        //    }
            

        //}

            protected  void btnAddTestName_Click(object sender, EventArgs e)
        {
            try
            {

                string test_id = hdnTestId.Value;

              //  string test_id = "hello";
               // AddNewRowToGrid();

                
            }

            catch (Exception ex)
            {
                Console.WriteLine("exception" + ex.ToString());
            }

            finally
            {
                // AddNewRowToGrid();
            }
        }

        public void SetInitialRow()
        {

            DataTable datatable = new DataTable();

            datatable.Columns.Add("SlNo", typeof(string));
            datatable.Columns.Add("Test_name", typeof(string));
            datatable.Columns.Add("Test_cost", typeof(string));
            DataRow dr = null;

            dr = datatable.NewRow();

            dr["SlNo"] = "1";
            dr["test_name"] = string.Empty;// txtRcptHdNo.Text;
            dr["Test_cost"] = string.Empty;// ddlRcptDtlsItem.SelectedItem.Text;

            datatable.Rows.Add(dr);
            //dr = dt.NewRow();

            //Store the DataTable in ViewState
            ViewState["dtTestDetail"] = datatable;

            gvappointmentTests.DataSource = datatable;
            gvappointmentTests.DataBind();
        }

        public void AddNewRowToGrid()
        {
            int rowIndex = 0;

            if (ViewState["dtTestDetail"] != null)
            {
                DataTable dtTestTable = (DataTable)ViewState["dtTestDetail"];
                DataRow drCurrentRow = null;
                if (dtTestTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtTestTable.Rows.Count; i++)
                    {

                        drCurrentRow = dtTestTable.NewRow();
                       // drCurrentRow["SlNo"] = i + 1;

                        dtTestTable.Rows[i - 1]["test_name"] = "hello 2";
                        dtTestTable.Rows[i - 1]["test_cost"] = 5000;

                        rowIndex++;
                    }
                    dtTestTable.Rows.Add(drCurrentRow);
                    ViewState["dtTestDetail"] = dtTestTable;

                    gvappointmentTests.DataSource = dtTestTable;
                    gvappointmentTests.DataBind();
                }
            }
            else
            {
                string TestId = hdnTestId.Value;
                DataSet docrecomm = bookapp.FetchTest(TestId);
                ViewState["dtTestDetail"] = docrecomm.Tables[0];
                gvappointmentTests.DataSource = ViewState["dtTestDetail"];
                gvappointmentTests.DataBind();
            }

            //Set Previous Data on Postbacks
            SetPreviousData();
        }

        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["dtTestDetail"] != null)
            {
                DataTable dt = (DataTable)ViewState["dtTestDetail"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        dt.Rows[i]["test_name"].ToString();// = txtRcptHdNo.Text;
                        dt.Rows[i]["test_cost"].ToString();// = ddlRcptDtlsItem.SelectedItem.Text;
                       

                        rowIndex++;
                    }
                }
            }
        }


    }
}