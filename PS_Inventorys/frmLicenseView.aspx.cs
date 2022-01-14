using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PS_Inventorys
{
    public partial class frmLicenseView : System.Web.UI.Page
    {
        string Id = "";
        string LicenseKeys = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true; //PagePostback ไม่ต้องขึ้นมาด้านบน
            Id = Server.UrlDecode(Request.QueryString["Parameter"].ToString());

            if (!Page.IsPostBack)
            {
                fncGetKeysData(Id);
                //fncGetLicenseKeysUSE(LicenseKeys);
            }
        }

        private void fncGetKeysData(string Id)
        {
            DataTable DT = new DataTable();
            var lvSQL = "Select * From c_key Where c_LicenseID = '" + Id + "'";
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);

            GridViewLicense.DataSource = null;
            GridViewLicense.DataSource = DT;
            GridViewLicense.DataBind();
        }

        private void fncGetLicenseKeysUSE(string c_licenseKeys)
        {
            DataTable DT = new DataTable();
            var lvSQL = "Select * From com_pckeyusing cp Inner Join com_pcuser cu ON cp.ComName = cu.ComName Where (OSKeys = '" + c_licenseKeys + "') OR (MicrosoftKeys = '" + c_licenseKeys + "')";
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);

            DataTable newDT = new DataTable();
            newDT.Columns.Add("Id");
            newDT.Columns.Add("EmpID");
            newDT.Columns.Add("ComName");
            newDT.Columns.Add("UserName");
            newDT.Columns.Add("OsKeys");
            newDT.Columns.Add("MicrosoftKeys");

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                var Id = DT.Rows[i]["Id"].ToString();
                var EmpID = DT.Rows[i]["EmpID"].ToString();
                var ComName = DT.Rows[i]["ComName"].ToString();
                var UserName = DT.Rows[i]["EmpName"].ToString();
                var OSKeys = DT.Rows[i]["OSKeys"].ToString();
                var MicrosoftKeys = DT.Rows[i]["MicrosoftKeys"].ToString();

                newDT.Rows.Add(new object[] { Id ,EmpID, ComName, UserName, OSKeys, MicrosoftKeys });
            }
            
            GridViewLicenseUse.DataSource = null;
            GridViewLicenseUse.DataSource = newDT;
            GridViewLicenseUse.DataBind();
        }

        protected void ViewLicenseUse_Click(object sender, EventArgs e)
        {
            var id = (sender as LinkButton).CommandArgument;

            string c_licenseKeys = id.ToString();
            GVar.gvlvlicenseKey = c_licenseKeys;

            fncGetLicenseKeysUSE(c_licenseKeys);
        }

        protected void GridViewLicense_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            fncGetKeysData(Id);
            GridViewLicense.PageIndex = e.NewPageIndex;
            GridViewLicense.DataBind();
        }

        protected void GridViewLicenseUse_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            fncGetLicenseKeysUSE(GVar.gvlvlicenseKey);
            GridViewLicenseUse.PageIndex = e.NewPageIndex;
            GridViewLicenseUse.DataBind();
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmIndex.aspx");
        }
    }
}