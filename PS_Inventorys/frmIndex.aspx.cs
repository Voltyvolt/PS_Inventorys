using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PS_Inventorys
{
    public partial class frmIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true; //PagePostback ไม่ต้องขึ้นมาด้านบน
            if (!Page.IsPostBack)
            {
                Page.MaintainScrollPositionOnPostBack = true; //PagePostback ไม่ต้องขึ้นมาด้านบน
                fncLoadGridView();
                fncLoadGridLicenseID();
                fncGetCmbSearch();
            }
            else
            {

            }
        }

        private void fncLoadGridView()
        {
            var lvSearch = cmbSearch.Text;
            if (lvSearch != "ทั้งหมด")
            {
                DataTable DT = new DataTable();
                var lvSQL = "Select * From com_pcuser inner join com_pckeyusing ON com_pcuser.ComName = com_pckeyusing.ComName Where FacName = '" + lvSearch + "'";
                DT = GsysSQL.fncGetQueryData(lvSQL, DT);

                DataTable newDT = new DataTable();
                newDT.Columns.Add("Id");
                newDT.Columns.Add("No");
                newDT.Columns.Add("FacName");
                newDT.Columns.Add("ComName");
                newDT.Columns.Add("EmpID");
                newDT.Columns.Add("EmpName");
                newDT.Columns.Add("NickName");
                newDT.Columns.Add("Status");
                newDT.Columns.Add("Showall");

                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    var Id = DT.Rows[i]["Id"].ToString();
                    var No = i + 1;
                    var ComName = DT.Rows[i]["ComName"].ToString();
                    var FacName = DT.Rows[i]["FacName"].ToString();
                    var EmpID = DT.Rows[i]["EmpID"].ToString();
                    var EmpName = DT.Rows[i]["EmpName"].ToString();
                    var NickName = DT.Rows[i]["NickName"].ToString();
                    var Status = DT.Rows[i]["Status"].ToString();
                    var OSKeys = DT.Rows[i]["OSKeys"].ToString();
                    var MicrosoftKeys = DT.Rows[i]["MicrosoftKeys"].ToString();
                    var Stat1 = "ยังไม่ได้ Active Windows";
                    var Stat2 = "ยังไม่ได้ Active Office";

                    if (OSKeys != "")
                    {
                        Stat1 = "Active Windows แล้ว";
                    }
                    if (MicrosoftKeys != "")
                    {
                        Stat2 = "Active Office แล้ว";
                    }

                    if (OSKeys == "ยังไม่ทราบ")
                    {
                        Stat1 = "Unknow Activate";
                    }
                    if (MicrosoftKeys == "ยังไม่ทราบ")
                    {
                        Stat2 = "Unknow Activate";
                    }

                    var Showall = Stat1 + "," + Stat2;

                    newDT.Rows.Add(new object[] { Id, No, FacName, ComName, EmpID, EmpName, NickName, Status, Showall });
                }

                GridComuser.DataSource = null;
                GridComuser.DataSource = newDT;
                GridComuser.DataBind();
            }
            else
            {
                DataTable DT = new DataTable();
                var lvSQL = "Select * From com_pcuser inner join com_pckeyusing ON com_pcuser.ComName = com_pckeyusing.ComName";
                DT = GsysSQL.fncGetQueryData(lvSQL, DT);

                DataTable newDT = new DataTable();
                newDT.Columns.Add("Id");
                newDT.Columns.Add("No");
                newDT.Columns.Add("FacName");
                newDT.Columns.Add("ComName");
                newDT.Columns.Add("EmpID");
                newDT.Columns.Add("EmpName");
                newDT.Columns.Add("NickName");
                newDT.Columns.Add("Status");
                newDT.Columns.Add("Showall");

                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    var Id = DT.Rows[i]["Id"].ToString();
                    var No = i + 1;
                    var ComName = DT.Rows[i]["ComName"].ToString();
                    var FacName = DT.Rows[i]["FacName"].ToString();
                    var EmpID = DT.Rows[i]["EmpID"].ToString();
                    var EmpName = DT.Rows[i]["EmpName"].ToString();
                    var NickName = DT.Rows[i]["NickName"].ToString();
                    var Status = DT.Rows[i]["Status"].ToString();
                    var OSKeys = DT.Rows[i]["OSKeys"].ToString();
                    var MicrosoftKeys = DT.Rows[i]["MicrosoftKeys"].ToString();
                    var Stat1 = "ยังไม่ได้ Active Windows";
                    var Stat2 = "ยังไม่ได้ Active Office";

                    if (OSKeys != "")
                    {
                        Stat1 = "Active Windows แล้ว";
                    }
                    if (MicrosoftKeys != "")
                    {
                        Stat2 = "Active Office แล้ว";
                    }

                    if (OSKeys == "ยังไม่ทราบ")
                    {
                        Stat1 = "Unknow Activate";
                    }
                    if (MicrosoftKeys == "ยังไม่ทราบ")
                    {
                        Stat2 = "Unknow Activate";
                    }

                    var Showall = Stat1 + "," + Stat2;

                    newDT.Rows.Add(new object[] { Id, No, FacName, ComName, EmpID, EmpName, NickName, Status, Showall });
                }

                GridComuser.DataSource = null;
                GridComuser.DataSource = newDT;
                GridComuser.DataBind();
            }
        }

        private void fncLoadGridLicenseID()
        {
            DataTable DT = new DataTable();
            var lvSQL = "Select * From c_license Order By c_LicenseID ASC";
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);

            DataTable newDT = new DataTable();
            newDT.Columns.Add("c_PK");
            newDT.Columns.Add("No");
            newDT.Columns.Add("c_LicenseID");
            newDT.Columns.Add("c_Product Family");
            newDT.Columns.Add("c_Version");
            newDT.Columns.Add("c_Effective");
            newDT.Columns.Add("c_Unresolve");

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                var Id = DT.Rows[i]["c_PK"].ToString();
                var No = i + 1;
                var LicenseID = DT.Rows[i]["c_LicenseID"].ToString();
                var ProductFamily = DT.Rows[i]["c_ProductFamily"].ToString();
                var Version = DT.Rows[i]["c_Version"].ToString();
                var Effective = DT.Rows[i]["c_Effective"].ToString();
                var Unresolve = DT.Rows[i]["c_Unresolve"].ToString();

                newDT.Rows.Add(new object[] { Id, No, LicenseID, ProductFamily, Version, Effective, Unresolve });
            }

            GridLicenseID.DataSource = null;
            GridLicenseID.DataSource = newDT;
            GridLicenseID.DataBind();
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);

            string test = id.ToString();

            Response.Redirect("frmEdit.aspx?Parameter=" + test.ToString());
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                int id = Convert.ToInt32((sender as LinkButton).CommandArgument);

                var lvSQL = "Update com_pcuser SET Status = 'Disabled' Where Id = '" + id + "'";
                var lvResult = GsysSQL.fncExecuteQueryData(lvSQL);

                if (lvResult.Equals("Success"))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script1", "<script>alert('Disabled เครื่องคอมพิวเตอร์สำเร็จ');</script>");
                    fncLoadGridView();
                }
            }
            else
            {
                return;
            }
        }

        protected void Switch_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                int id = Convert.ToInt32((sender as LinkButton).CommandArgument);


                var lvSQL = "Update com_pcuser SET Status = 'Active' Where Id = '" + id + "'";
                var lvResult = GsysSQL.fncExecuteQueryData(lvSQL);

                if (lvResult.Equals("Success"))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script1", "<script>alert('Actived เครื่องคอมพิวเตอร์สำเร็จ');</script>");
                    fncLoadGridView();
                }
            }
            else
            {
                return;
            }
        }

        protected void BtnAddCom_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmAddCom.aspx");
        }

        protected void GridComuser_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            fncLoadGridView();
            GridComuser.PageIndex = e.NewPageIndex;
            GridComuser.DataBind();
        }

        protected void GridLicenseID_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            fncLoadGridLicenseID();
            GridLicenseID.PageIndex = e.NewPageIndex;
            GridLicenseID.DataBind();
        }

        protected void ViewLicense_Click(object sender, EventArgs e)
        {
            int LicenseID = Convert.ToInt32((sender as LinkButton).CommandArgument);

            string test = LicenseID.ToString();

            Response.Redirect("frmLicenseView.aspx?Parameter=" + test.ToString());
        }

        private void fncGetCmbSearch()
        {
            cmbSearch.Items.Add("-- เลือก --");
            cmbSearch.Items.Add("ทั้งหมด");
            DataTable DT = new DataTable();
            var lvSQL = "Select Faction_Name From emp_faction";
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                var Data = DT.Rows[i]["Faction_Name"].ToString();
                cmbSearch.Items.Add(Data);
            }
        }

        protected void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lvSearch = cmbSearch.Text;
            fncLoadGridView();
        }

        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/frmSoftware.aspx");
        }

        protected void GridComuser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }
    }
}