using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PS_Inventorys
{
    public partial class frmEdit : System.Web.UI.Page
    {
        string Id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true; //PagePostback ไม่ต้องขึ้นมาด้านบน

            Id = Server.UrlDecode(Request.QueryString["Parameter"].ToString());

            if (!Page.IsPostBack)
            {
                fncLoadDataHeader(Id);
                fncLoadDataSoftware();
                fncLoadDataHardware();
                fncLoadDataNetwork();
                fncLoadDataUPS();
                fncLoadDataMonitor();
            }
        }

        private void fncGetFactionName()
        {
            cmbFacName.Items.Add("-- เลือก --");
            DataTable DT = new DataTable();
            var lvSQL = "Select Faction_Name From emp_faction";
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                var Data = DT.Rows[i]["Faction_Name"].ToString();
                cmbFacName.Items.Add(Data);
            }
        }

        private void fncGetCmbOSProduct()
        {
            //cmbOsProduct.Items.Clear();
            DataTable DT = new DataTable();
            var lvSQL = "Select c_Product From c_key Where c_Product Like '%Win%' And c_Type ='MAK' Group BY c_Product";
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);
            cmbOsProduct.Items.Add("-- เลือก --");
            cmbOsKeys.Items.Add("-- เลือก --");
            cmbOsKeys.Items.Add("ยังไม่ทราบ");

            var Numrows = DT.Rows.Count;

            for (var i = 0; i < Numrows; i++)
            {
                var Data = DT.Rows[i]["c_Product"].ToString();
                cmbOsProduct.Items.Add(Data);
            }

        } //Get WindowsProducts

        private void fncGetcmbOSKeys(string WindowsProduct)
        {
            cmbOsKeys.Items.Clear();
            DataTable DT = new DataTable();
            var lvSQL = "Select c_ProductKey From c_key Where c_Product = '" + WindowsProduct + "'  And c_Type = 'MAK' And c_Use != 'Y' ";
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);
            cmbOsKeys.Items.Add("-- เลือก --");
            cmbOsKeys.Items.Add("ยังไม่ทราบ");

            var Numrows = DT.Rows.Count;

            for (var i = 0; i < Numrows; i++)
            {
                var Data = DT.Rows[i]["c_ProductKey"].ToString();
                cmbOsKeys.Items.Add(Data);
            }

        } //Get WindowsKeys

        private void fncGetMSProduct()
        {
            //cmbOsProduct.Items.Clear();
            DataTable DT = new DataTable();
            var lvSQL = "Select c_Product From c_key Where c_Product NOT Like '%Win%' And c_Type ='MAK' Group BY c_Product";
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);
            cmbMsProduct.Items.Add("-- เลือก --");
            cmbMsKeys.Items.Add("-- เลือก --");
            cmbMsKeys.Items.Add("ยังไม่ทราบ");

            var Numrows = DT.Rows.Count;

            for (var i = 0; i < Numrows; i++)
            {
                var Data = DT.Rows[i]["c_Product"].ToString();
                cmbMsProduct.Items.Add(Data);
            }
        } //Get MicrosoftProducts

        private void fncGetMSKeys(string MicrosoftProduct)
        {
            cmbMsKeys.Items.Clear();
            DataTable DT = new DataTable();
            var lvSQL = "Select c_ProductKey From c_key Where c_Product = '" + MicrosoftProduct + "' And c_Type = 'MAK' And c_Use != 'Y' ";
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);
            cmbMsKeys.Items.Add("-- เลือก --");
            cmbMsKeys.Items.Add("ยังไม่ทราบ");

            var Numrows = DT.Rows.Count;
            for (var i = 0; i < Numrows; i++)
            {
                var Data = DT.Rows[i]["c_ProductKey"].ToString();
                cmbMsKeys.Items.Add(Data);
            }
        } //Get MicrosoftKeys

        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        } //MsgBox Alert

        private void fncLoadDataHeader(string id)
        {
            DataTable DT = new DataTable();
            var lvSQL = "Select * From com_pcuser Where Id = '" + id + "'";
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                var lvNo = DT.Rows[i]["No"].ToString();
                var lvSecID = DT.Rows[i]["SecID"].ToString();
                var lvSecName = DT.Rows[i]["SecName"].ToString();
                var lvSegID = DT.Rows[i]["SegID"].ToString();
                var lvSegName = DT.Rows[i]["SegName"].ToString();
                var lvFacID = DT.Rows[i]["FacID"].ToString();
                var lvFacName = DT.Rows[i]["FacName"].ToString();
                var lvComName = DT.Rows[i]["ComName"].ToString();
                var lvEmpID = DT.Rows[i]["EmpID"].ToString();
                var lvEmpName = DT.Rows[i]["EmpName"].ToString();
                var lvNickName = DT.Rows[i]["NickName"].ToString();
                var lvDate = DT.Rows[i]["Date"].ToString();
                var lvStatus = DT.Rows[i]["Status"].ToString();
                var lvRemark = DT.Rows[i]["Remark"].ToString();

                txtNo.Text = lvNo;
                txtSecID.Text = lvSecID;
                txtSecName.Text = lvSecName;
                txtSegID.Text = lvSegID;
                txtSegName.Text = lvSegName;
                txtFacID.Text = lvFacID;
                cmbFacName.Text = lvFacName;
                if (lvFacName == "")
                {
                    fncGetFactionName();
                }
                else
                {
                    fncGetFactionName();
                    cmbFacName.Text = lvFacName;
                }
                txtComName.Text = lvComName;
                txtEmpID.Text = lvEmpID;
                txtEmpName.Text = lvEmpName;
                txtNickname.Text = lvNickName;
                if(lvDate != "")
                {
                    txtDateSetup.Text = GsysFunc.DateformattingS(GsysFunc.fncChangeSDate(lvDate));
                }
               
                txtRemark.Text = lvRemark;
            }
        }

        private void fncLoadDataSoftware()
        {
            fncGetCmbOSProduct();
            fncGetMSProduct();

            var lvComName = txtComName.Text;
            DataTable DT = new DataTable();
            var lvSQL = "Select * From com_pcsoftware inner join com_pckeyusing ON com_pcsoftware.ComName = com_pckeyusing.ComName Where com_pcsoftware.ComName = '" + lvComName + "'";
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                var lvWebroot = DT.Rows[i]["Webroot"].ToString();
                var lvBackUpDesk = DT.Rows[i]["BackupDesk"].ToString();
                var lvRemoveDrive = DT.Rows[i]["RemoveDrive"].ToString();
                var lvOS = DT.Rows[i]["OS"].ToString();
                var lvOSKeys = DT.Rows[i]["OSKeys"].ToString();
                var lvMicrosoft = DT.Rows[i]["Microsoft"].ToString();
                var lvMSKeys = DT.Rows[i]["MicrosoftKeys"].ToString();
                var lvAutocad = DT.Rows[i]["Autocad"].ToString();
                var lvAntivirus = DT.Rows[i]["Antivirus"].ToString();
                var lvAnydeskCode = DT.Rows[i]["AnydeskCode"].ToString();
                var lvWinzip = DT.Rows[i]["Winzip"].ToString();
                var lvMedia = DT.Rows[i]["Media"].ToString();
                var lvPDF = DT.Rows[i]["PDF"].ToString();
                var lvMountImage = DT.Rows[i]["MountImage"].ToString();
                var lvLine = DT.Rows[i]["Line"].ToString();
                var lvChrome = DT.Rows[i]["Chrome"].ToString();
                var lvImpress = DT.Rows[i]["Impress"].ToString();
                var lvCane = DT.Rows[i]["Cane"].ToString();
                var lvOther = DT.Rows[i]["Other"].ToString();

                if(lvWebroot == "1")
                {
                    chkWebroot.Checked = true;
                }
                if(lvBackUpDesk == "1")
                {
                    chkBackup.Checked = true;
                }
                if(lvRemoveDrive == "1")
                {
                    chkDriveD.Checked = true;
                }

                cmbOsProduct.Text = lvOS;
                if(lvOSKeys == "")
                {
                    fncGetcmbOSKeys(lvOS);
                }
                else
                {
                    fncGetcmbOSKeys(lvOS);
                    cmbOsKeys.Text = lvOSKeys;
                }
                
                cmbMsProduct.Text = lvMicrosoft;
                if(lvMSKeys == "")
                {
                    fncGetMSKeys(lvMicrosoft);
                }
                else
                {
                    fncGetMSKeys(lvMicrosoft);
                    cmbMsKeys.Text = lvMSKeys;
                }
                txtAutocadName.Text = lvAutocad;
                txtAntivirus.Text = lvAntivirus;
                txtAnydeskId.Text = lvAnydeskCode;
                txtZipBrand.Text = lvWinzip;
                txtMediaBrand.Text = lvMedia;
                txtPdfBrand.Text = lvPDF;
                txtMountImage.Text = lvMountImage;
                if(lvLine == "1")
                {
                    chkLine.Checked = true;
                }
                if(lvChrome == "1")
                {
                    chkGoogleChrome.Checked = true;
                }
                if(lvImpress == "1")
                {
                    chkImpress.Checked = true;
                }
                if(lvCane == "1")
                {
                    chkCane.Checked = true;
                }
                txtOther.Text = lvOther;
            }
        }

        private void fncLoadDataHardware()
        {
            var lvComName = txtComName.Text;
            DataTable DT = new DataTable();
            var lvSQL = "Select * from com_pchardware Where ComName = '" + lvComName + "'";
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                var lvCPUModel = DT.Rows[i]["CPUModel"].ToString();
                var lvRamAmount = DT.Rows[i]["RamAmount"].ToString();
                var lvHDDAmount = DT.Rows[i]["HDDAmount"].ToString();
                var lvMouse = DT.Rows[i]["Mouse"].ToString();
                var lvKeyboard = DT.Rows[i]["Keyboard"].ToString();
                var lvServiceTag = DT.Rows[i]["ServiceTag"].ToString();
                var lvAssetHW = DT.Rows[i]["AssetHW"].ToString();

                txtCPUModel.Text = lvCPUModel;
                txtRamAmount.Text = lvRamAmount;
                txtHddAmount.Text = lvHDDAmount;
                txtMouse.Text = lvMouse;
                txtKeyboard.Text = lvKeyboard;
                txtExpressTag.Text = lvServiceTag;
                txtHwAssetID.Text = lvAssetHW;
            }
        }

        private void fncLoadDataNetwork()
        {
            var lvComName = txtComName.Text;
            DataTable DT = new DataTable();
            var lvSQL = "Select * From com_pcnetwork Where ComName = '" + lvComName + "'";
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                var lvDomain = DT.Rows[i]["Domain"].ToString();
                var lvIPAddress = DT.Rows[i]["IPAddress"].ToString();
                var lvLanAddress = DT.Rows[i]["LanAddress"].ToString();
                var lvWifiAddress = DT.Rows[i]["WifiAddress"].ToString();
                var lvThaiAdd = DT.Rows[i]["ThaiAdd"].ToString();
                var Administrator = DT.Rows[i]["Administrator"].ToString();

                txtDomain.Text = lvDomain;
                txtIPAddress.Text = lvIPAddress;
                txtLanAddress.Text = lvLanAddress;
                txtWifiAddress.Text = lvWifiAddress;
                if(lvThaiAdd == "1")
                {
                    chkAddThai.Checked = true;
                }
                if(Administrator == "1")
                {
                    chkAdministrator.Checked = true;
                }
            }
        }

        private void fncLoadDataUPS()
        {
            var lvComName = txtComName.Text;
            DataTable DT = new DataTable();
            var lvSQL = "Select * From com_pcups Where ComName = '" + lvComName + "'";
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                var lvUPS = DT.Rows[i]["UPS"].ToString();
                var lvBrand = DT.Rows[i]["Brand"].ToString();
                var lvSerial = DT.Rows[i]["Serial"].ToString();
                var lvAssetUPS = DT.Rows[i]["AssetUPS"].ToString();
                var lvDate = DT.Rows[i]["Date"].ToString();

                txtUPS.Text = lvUPS;
                txtUPSBrand.Text = lvBrand;
                txtUPSSerial.Text = lvSerial;
                txtUPSAsset.Text = lvAssetUPS;
                if(lvDate != "")
                {
                    txtUPSDate.Text = GsysFunc.DateformattingS(GsysFunc.fncChangeSDate(lvDate));
                }
               
            }
        }

        private void fncLoadDataMonitor()
        {
            var lvComName = txtComName.Text;
            DataTable DT = new DataTable();
            var lvSQL = "Select * From com_pcmonitor Where ComName = '" + lvComName + "'";
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                var lvMonitor = DT.Rows[i]["Monitor"].ToString();
                var lvBrand = DT.Rows[i]["Brand"].ToString();
                var lvSerial = DT.Rows[i]["Serial"].ToString();
                var lvAssetMonitor1 = DT.Rows[i]["AssetMonitor1"].ToString();
                var lvAssetMonitor2 = DT.Rows[i]["AssetMonitor2"].ToString();
                var lvDate = DT.Rows[i]["Date"].ToString();

                txtMonitor.Text = lvMonitor;
                txtMonitorBrand.Text = lvBrand;
                txtMonitorSerial.Text = lvSerial;
                txtMonitorAsset1.Text = lvAssetMonitor1;
                txtMonitorAsset2.Text = lvAssetMonitor2;
                if(lvDate != "")
                {
                    txtMonitorDate.Text = GsysFunc.DateformattingS(GsysFunc.fncChangeSDate(lvDate));
                }
            }
        }

        protected void cmbOsProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Product = cmbOsProduct.Text;
            fncGetcmbOSKeys(Product);
        }

        protected void cmbMsProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Product = cmbMsProduct.Text;
            fncGetMSKeys(Product);
        }

        private void fncSaveData()
        {
            //#region //เช็ค LicenseID Windows ว่าครบแล้วหรือยัง
            //var lvOSProduct = cmbOsProduct.Text;
            //var licenseOSID = GsysSQL.fncCheckLicenseID(cmbOsKeys.Text); //OS LicenseID อ้างอิง
            //var licenseOSEffective = GsysSQL.fncCheckEffecttive(cmbOsKeys.Text); //OS License ที่มีทั้งหมด
            //var licenseOSUnresolve = GsysSQL.fncCheckUnresolve(cmbOsKeys.Text); //OS License ที่ถูกใช้ไป
            //var licenseOSMakActive = GsysSQL.fncCheckMakActive(cmbOsKeys.Text); // OS Active
            ////var licenseOSMaksplit = licenseOSMakActive.Split('/');
            ////var OSsplit0 = licenseOSMaksplit[0];
            ////var OSsplit1 = licenseOSMaksplit[1];

            //if (licenseOSEffective == licenseOSUnresolve && licenseOSEffective != "")
            //{
            //    MsgBox("LicenseWindowsKeys นี้ถูกใช้ครบหมดแล้ว", this.Page, this);
            //    return;
            //}
            ////if (OSsplit0 == OSsplit1)
            ////{
            ////    MsgBox("LicenseWindowsKeys นี้ถูก Activate เต็มแล้ว", this.Page, this);
            ////    return;
            ////}
            //#endregion

            //#region //เช็ค LicenseID Microsoft ว่าครบแล้วหรือยัง
            //var licenseMSID = GsysSQL.fncCheckLicenseID(cmbMsKeys.Text); //MS LicenseID อ้างอิง
            //var licenseMSEffective = GsysSQL.fncCheckEffecttive(cmbMsKeys.Text); //MS License ที่มีทั้งหมด
            //var licenseMSUnresolve = GsysSQL.fncCheckUnresolve(cmbMsKeys.Text); //MS License ที่ถูกใช้ไป
            //var licenseMSMakActive = GsysSQL.fncCheckMakActive(cmbMsKeys.Text); // MS Active
            ////var licenseMSMaksplit = licenseMSMakActive.Split('/');
            ////var MSsplit0 = licenseMSMaksplit[0];
            ////var MSsplit1 = licenseMSMaksplit[1];

            //if (licenseMSEffective == licenseMSUnresolve && licenseMSEffective != "")
            //{
            //    MsgBox("LicenseMicrosoftKeys นี้ถูกใช้ครบหมดแล้ว", this.Page, this);
            //    return;
            //}

            ////if (MSsplit0 == MSsplit1)
            ////{
            ////    MsgBox("LicenseMicrosoftKeys นี้ถูก Activate เต็มแล้ว", this.Page, this);
            ////    return;
            ////}
            //#endregion

            //Update compcUser
            var lvSQL = "";
            var lvResult = "";
            var lvNo = txtNo.Text;
            var lvSecID = txtSecID.Text;
            var lvSecName = txtSecName.Text;
            var lvSegID = txtSegID.Text;
            var lvSegName = txtSegName.Text;
            var lvFacID = txtFacID.Text;
            var lvFacName = cmbFacName.Text;
            var lvComName = txtComName.Text;
            var lvEmpID = txtEmpID.Text;
            var lvEmpName = txtEmpName.Text;
            var lvNickName = txtNickname.Text;
            var lvDate = txtDateSetup.Text;
            var lvDateSetUp = "";
            if (lvDate != "")
            {
                lvDateSetUp = GsysFunc.fncChangeTDate(GsysFunc.Dateformatting(lvDate));
            }

            try
            {
                lvSQL = "Update com_pcuser SET SecID = '" + lvSecID + "', SecName = '" + lvSecName + "', SegID = '" + lvSegID + "', SegName = '" + lvSegName + "', " +
                "FacID = '" + lvFacID + "', FacName = '" + lvFacName + "' , ComName = '" + lvComName + "', EmpID = '" + lvEmpID + "', EmpName = '" + lvEmpName + "', " +
                "NickName = '" + lvNickName + "', Date = '" + lvDateSetUp + "' Where No = '" + lvNo + "'";

                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }
            catch(Exception ex)
            {
                MsgBox(ex.ToString(), this.Page, this);
            }
            
            var lvWebroot = "0";
            if(chkWebroot.Checked == true)
            {
                lvWebroot = "1";
            }

            var lvBackupDesk = "0";
            if(chkBackup.Checked == true)
            {
                lvBackupDesk = "1";
            }

            var lvRemoveDrive = "0";
            if(chkDriveD.Checked == true)
            {
                lvRemoveDrive = "1";
            }

            var lvOS = cmbOsProduct.Text;
            if(lvOS == "-- เลือก --")
            {
                lvOS = "";
            }

            var lvMicrosoft = cmbMsProduct.Text;
            if(lvMicrosoft == "-- เลือก --")
            {
                lvMicrosoft = "";
            }

            var lvAutocad = txtAutocadName.Text;
            var lvAntivirus = txtAntivirus.Text;
            var lvAnydeskCode = txtAnydeskId.Text;
            var lvWinzip = txtZipBrand.Text;
            var lvMedia = txtMediaBrand.Text;
            var lvPDF = txtPdfBrand.Text;
            var lvMountImage = txtMountImage.Text;
            var lvLine = 0;
            var lvChrome = 0;
            var lvImpress = 0;
            var lvCane = 0;
            var lvOther = txtOther.Text;

            if (chkLine.Checked == true)
            {
                lvLine = 1;
            }
            if (chkGoogleChrome.Checked == true)
            {
                lvChrome = 1;
            }
            if (chkImpress.Checked == true)
            {
                lvImpress = 1;
            }
            if (chkCane.Checked == true)
            {
                lvCane = 1;
            }

            try
            {
                lvSQL = "Update com_pcsoftware SET ComName = '" + lvComName + "', Webroot = '" + lvWebroot + "', BackupDesk = '" + lvBackupDesk + "', RemoveDrive = '" + lvRemoveDrive + "', " +
                    "OS = '" + lvOS + "', Microsoft = '" + lvMicrosoft + "', Autocad = '" + lvAutocad + "', Antivirus = '" + lvAntivirus + "', " +
                    "AnydeskCode = '" + lvAnydeskCode + "', Winzip = '" + lvWinzip + "', Media = '" + lvMedia + "', PDF = '" + lvPDF + "', MountImage = '" + lvMountImage + "', " +
                    "Line = '" + lvLine + "', Chrome = '" + lvChrome + "', Impress = '" + lvImpress + "', Cane = '" + lvCane + "', Other = '" + lvOther + "' Where ComName = '" + lvComName + "'";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);

                fncSaveDataKeyUsing(lvComName);
            }
            catch (Exception ex)
            {
                MsgBox(ex.ToString(), this.Page, this);
            }

            var lvCPUModel = txtCPUModel.Text;
            var lvRamAmount = txtRamAmount.Text;
            var lvHDDAmount = txtHddAmount.Text;
            var lvMouse = txtMouse.Text;
            var lvKeyboard = txtKeyboard.Text;
            var lvServiceTag = txtExpressTag.Text;
            var lvAssetHW = txtHwAssetID.Text;

            try
            {
                lvSQL = "Update com_pchardware SET ComName = '" + lvComName + "', CPUModel = '" + lvCPUModel + "', RamAmount = '" + lvRamAmount + "', HDDAmount = '" + lvHDDAmount + "', " +
                    "Mouse = '" + lvMouse + "', Keyboard = '" + lvKeyboard + "', ServiceTag = '" + lvServiceTag + "', AssetHW = '" + lvAssetHW + "' Where ComName = '" + lvComName + "'";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }
            catch(Exception ex)
            {
                MsgBox(ex.ToString(), this.Page, this);
            }

            var lvDomain = txtDomain.Text;
            var lvIPAddress = txtIPAddress.Text;
            var lvLanAddress = txtLanAddress.Text;
            var lvWifiAddress = txtWifiAddress.Text;
            var lvThaiAdd = "0";
            if(chkAddThai.Checked == true)
            {
                lvThaiAdd = "1";
            }

            var lvAdministrator = "0";
            if(chkAdministrator.Checked == true)
            {
                lvAdministrator = "1";
            }

            try
            {
                lvSQL = "Update com_pcnetwork SET ComName = '" + lvComName + "', Domain = '" + lvDomain + "', IPAddress = '" + lvIPAddress + "', LanAddress = '" + lvLanAddress + "', " +
                    "WifiAddress = '" + lvWifiAddress + "', ThaiAdd = '" + lvThaiAdd + "', Administrator = '" + lvAdministrator + "' WHERE ComName = '" + lvComName + "'";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }
            catch (Exception ex)
            {
                MsgBox(ex.ToString(), this.Page, this);
            }

            var lvMonitor = txtMonitor.Text;
            var lvMonitorBrand = txtMonitorBrand.Text;
            var lvMonitorSerial = txtMonitorSerial.Text;
            var lvMonitorAsset1 = txtMonitorAsset1.Text;
            var lvMonitorAsset2 = txtMonitorAsset2.Text;
            var lvMonitorDate = txtMonitorDate.Text;
            var lvMonitorDateSetUp = "";
            if(lvMonitorDate != "")
            {
                lvMonitorDateSetUp = GsysFunc.fncChangeTDate(GsysFunc.Dateformatting(lvMonitorDate));
            }

            try
            {
                lvSQL = "Update com_pcmonitor SET ComName = '" + lvComName + "', Monitor = '" + lvMonitor + "', Brand = '" + lvMonitorBrand + "', Serial = '" + lvMonitorSerial + "', " +
                    "AssetMonitor1 = '" + lvMonitorAsset1 + "', AssetMonitor2 = '" + lvMonitorAsset2 + "', Date = '" + lvMonitorDateSetUp + "' Where ComName = '" + lvComName + "'";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }
            catch (Exception ex)
            {
                MsgBox(ex.ToString(), this.Page, this);
            }

            var lvUPS = txtUPS.Text;
            var lvUPSBrand = txtUPSBrand.Text;
            var lvUPSSerial = txtUPSSerial.Text;
            var lvUPSAssetUPS = txtUPSAsset.Text;
            var lvUPSDate = txtUPSDate.Text;
            var lvUPSDateSetup = "";
            if(lvUPSDate != "")
            {
                lvUPSDateSetup = GsysFunc.fncChangeTDate(GsysFunc.Dateformatting(lvUPSDate));
            }

            try
            {
                lvSQL = "Update com_pcups SET ComName = '" + lvComName + "', UPS = '" + lvUPS + "', Brand = '" + lvUPSBrand + "', Serial = '" + lvUPSSerial + "', " +
                    "AssetUPS = '" + lvUPSAssetUPS + "', Date = '" + lvUPSDateSetup + "' Where ComName = '" + lvComName + "'";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);

                if(lvResult == "Success")
                {
                    //MsgBox("แก้ไขข้อมูลสำเร็จ...", this.Page, this);
                    ClientScript.RegisterStartupScript(typeof(Page), "alertMessage", "<script type='text/javascript'>alert('แก้ไขข้อมูลสำเร็จ!');window.location.replace('frmIndex.aspx');</script>");
                }
            }
            catch (Exception ex)
            {
                MsgBox(ex.ToString(), this.Page, this);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            fncSaveData();
        }

        private void fncSaveDataKeyUsing(string lvComName)
        {
            try
            {
                var lvSQL = "";
                var lvResult = "";
                var lvEmpID = txtEmpID.Text;
                var lvOSKeys = cmbOsKeys.Text;
                
                if(txtOSKeys.Text != "")
                {
                    lvOSKeys = txtOSKeys.Text;
                }
                if(lvOSKeys == "-- เลือก --")
                {
                    lvOSKeys = "";
                }

                var lvMSKeys = cmbMsKeys.Text;
                if(txtMSKeys.Text != "")
                {
                    lvMSKeys = txtMSKeys.Text;
                }
                if(lvMSKeys == "-- เลือก --")
                {
                    lvMSKeys = "";
                }

                var lvAutocadKeys = txtAutocadKeys.Text;

                var lvOSKeysChk = fncGetLicenseOS();
                var lvMSKeysChk = fncGetLicenseMS();

                if (!lvOSKeys.Equals("") && lvOSKeys != lvOSKeysChk)
                {
                    var licenseOSID = GsysSQL.fncCheckLicenseID(lvOSKeys);
                    UpdateLicenseUSE(licenseOSID);
                    lvSQL = "Update c_Key SET c_Count = c_Count + 1 Where c_ProductKey = '" + lvOSKeys + "'";
                    lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
                    //UpdateLicenseActivate(lvOSKeys);
                }
                if (!lvMSKeys.Equals("") && lvMSKeys != lvMSKeysChk)
                {
                    var licenseMSID = GsysSQL.fncCheckLicenseID(lvMSKeys);
                    UpdateLicenseUSE(licenseMSID);
                    lvSQL = "Update c_Key SET c_Count = c_Count + 1 Where c_ProductKey = '" + lvMSKeys + "'";
                    lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
                    //UpdateLicenseActivate(lvMSKeys);
                }

                lvSQL = "Update com_pckeyusing SET OSKeys = '" + lvOSKeys + "', MicrosoftKeys = '" + lvMSKeys + "', AutoCadKeys = '" + lvAutocadKeys + "' Where ComName = '" + lvComName + "'";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);


            }
            catch (Exception ex)
            {
                MsgBox(ex.ToString(), this.Page, this);
            }
        } //บันทึกข้อมูลใช้ License

        private void UpdateLicenseUSE(string lvLicenseID)
        {
            var lvSQL = "Update c_license SET c_Unresolve = c_Unresolve + 1 Where c_LicenseID = '" + lvLicenseID + "' ";
            var lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
        } //อัพเดท Unresolve licenseID

        private string fncGetLicenseOS()
        {
            var lvComName = txtComName.Text;
            var lvReturn = "";
            var lvSQL = "";
            var lvResult = "";

            DataTable DT = new DataTable();
            lvSQL = "Select OSKeys From com_pckeyusing Where ComName = '" + lvComName + "'";
            lvResult = GsysSQL.fncExecuteQueryData(lvSQL);

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                lvReturn = DT.Rows[i]["OSKeys"].ToString();
            }

            return lvReturn;
        }

        private string fncGetLicenseMS()
        {
            var lvComName = txtComName.Text;
            var lvReturn = "";
            var lvSQL = "";
            var lvResult = "";

            DataTable DT = new DataTable();
            lvSQL = "Select MicrosoftKeys From com_pckeyusing Where ComName = '" + lvComName + "'";
            lvResult = GsysSQL.fncExecuteQueryData(lvSQL);

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                lvReturn = DT.Rows[i]["MicrosoftKeys"].ToString();
            }

            return lvReturn;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmIndex.aspx");
        }

        protected void cmbFacName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lvFactionName = cmbFacName.Text;
            DataTable DT = new DataTable();
            var lvSQL = "Select Faction_ID From emp_faction Where Faction_Name = '" + lvFactionName + "'";
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                var lvFacID = DT.Rows[i]["Faction_ID"].ToString();

                txtFacID.Text = lvFacID;
            }
        }
    }
}