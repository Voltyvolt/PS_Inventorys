using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PS_Inventorys
{
    public partial class frmAddCom : System.Web.UI.Page
    {
        string Mode = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true; //PagePostback ไม่ต้องขึ้นมาด้านบน

            if (!Page.IsPostBack)
            {
                Page.MaintainScrollPositionOnPostBack = true;
                fncGetCmbOSProduct(); //รับข้อมูล โปรแกรม Windows
                fncGetMSProduct(); //รับข้อมูล โปรแกรม Microsoft ต่างๆ
                EnabledTextbox(); //เปิด/ปิด TextBox
                fncGetFactionName(); //ชื่อแผนก
            }

            if (Mode.Equals("New"))
            {
                EnabledTextbox();
            }
        }

        private void EnabledTextbox()
        {
          #region //เปิดปิด Textbox
            if (txtNo.Text == "")
            {
                //ปิด
                txtSecName.Enabled = false;
                txtSecID.Enabled = false;
                txtSegID.Enabled = false;
                txtSegName.Enabled = false;
                txtFacID.Enabled = false;
                txtFacName.Enabled = false;
                txtComName.Enabled = false;
                txtEmpID.Enabled = false;
                txtEmpName.Enabled = false;
                txtNickname.Enabled = false;
                txtDateSetup.Enabled = false;
                chkWebroot.Enabled = false;
                chkBackup.Enabled = false;
                chkDriveD.Enabled = false;
                cmbOsProduct.Enabled = false;
                cmbOsKeys.Enabled = false;
                txtOSKeys.Enabled = false;
                cmbMsProduct.Enabled = false;
                cmbMsKeys.Enabled = false;
                txtMSKeys.Enabled = false;
                txtAutocadName.Enabled = false;
                txtAutocadKeys.Enabled = false;
                txtAnydeskId.Enabled = false;
                txtZipBrand.Enabled = false;
                txtMediaBrand.Enabled = false;
                txtPdfBrand.Enabled = false;
                txtMountImage.Enabled = false;
                chkLine.Enabled = false;
                chkGoogleChrome.Enabled = false;
                chkImpress.Enabled = false;
                chkCane.Enabled = false;
                txtOther.Enabled = false;
                txtCPUModel.Enabled = false;
                txtRamAmount.Enabled = false;
                txtHddAmount.Enabled = false;
                txtHwAssetID.Enabled = false;
                txtMouse.Enabled = false;
                txtKeyboard.Enabled = false;
                txtExpressTag.Enabled = false;
                txtDomain.Enabled = false;
                txtIPAddress.Enabled = false;
                txtLanAddress.Enabled = false;
                txtWifiAddress.Enabled = false;
                chkAddThai.Enabled = false;
                chkAdministrator.Enabled = false;
                txtMonitor.Enabled = false;
                txtMonitorBrand.Enabled = false;
                txtMonitorSerial.Enabled = false;
                txtMonitorAsset1.Enabled = false;
                txtMonitorAsset2.Enabled = false;
                txtMonitorDate.Enabled = false;
                txtUPS.Enabled = false;
                txtUPSBrand.Enabled = false;
                txtUPSSerial.Enabled = false;
                txtUPSAsset.Enabled = false;
                txtUPSDate.Enabled = false;
                txtRemark.Enabled = false;
                btnSubmit.Enabled = false;
                btnCancel.Enabled = false;
            }
            else
            {
                //ปิด
                txtNo.Enabled = false;
                txtSecName.Enabled = true;
                txtSecID.Enabled = true;
                txtSegID.Enabled = true;
                txtSegName.Enabled = true;
                txtFacID.Enabled = true;
                txtFacName.Enabled = true;
                txtComName.Enabled = true;
                txtEmpID.Enabled = true;
                txtEmpName.Enabled = true;
                txtNickname.Enabled = true;
                txtDateSetup.Enabled = true;
                chkWebroot.Enabled = true;
                chkBackup.Enabled = true;
                chkDriveD.Enabled = true;
                cmbOsProduct.Enabled = true;
                cmbOsKeys.Enabled = true;
                txtOSKeys.Enabled = true;
                cmbMsProduct.Enabled = true;
                cmbMsKeys.Enabled = true;
                txtMSKeys.Enabled = true;
                txtAutocadName.Enabled = true;
                txtAutocadKeys.Enabled = true;
                txtAnydeskId.Enabled = true;
                txtZipBrand.Enabled = true;
                txtMediaBrand.Enabled = true;
                txtPdfBrand.Enabled = true;
                txtMountImage.Enabled = true;
                chkLine.Enabled = true;
                chkGoogleChrome.Enabled = true;
                chkImpress.Enabled = true;
                chkCane.Enabled = true;
                txtOther.Enabled = true;
                txtCPUModel.Enabled = true;
                txtRamAmount.Enabled = true;
                txtHddAmount.Enabled = true;
                txtHwAssetID.Enabled = true;
                txtMouse.Enabled = true;
                txtKeyboard.Enabled = true;
                txtExpressTag.Enabled = true;
                txtDomain.Enabled = true;
                txtIPAddress.Enabled = true;
                txtLanAddress.Enabled = true;
                txtWifiAddress.Enabled = true;
                chkAddThai.Enabled = true;
                chkAdministrator.Enabled = true;
                txtMonitor.Enabled = true;
                txtMonitorBrand.Enabled = true;
                txtMonitorSerial.Enabled = true;
                txtMonitorAsset1.Enabled = true;
                txtMonitorAsset2.Enabled = true;
                txtMonitorDate.Enabled = true;
                txtUPS.Enabled = true;
                txtUPSBrand.Enabled = true;
                txtUPSSerial.Enabled = true;
                txtUPSAsset.Enabled = true;
                txtUPSDate.Enabled = true;
                txtRemark.Enabled = true;
                btnSubmit.Enabled = true;
                btnCancel.Enabled = true;
            }
            #endregion
        } //เปิด/ปิด TextBox

        private void fncGetFactionName()
        {
            txtFacName.Items.Add("-- เลือก --");
            DataTable DT = new DataTable();
            var lvSQL = "Select Faction_Name From emp_faction";
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                var Data = DT.Rows[i]["Faction_Name"].ToString();
                txtFacName.Items.Add(Data);
            }
        }

        private void fncSaveDataHeader(string lvComName)
        {
            #region //เช็ค LicenseID Windows ว่าครบแล้วหรือยัง
            var lvOSKeys = cmbOsKeys.Text;
            var licenseOSID = GsysSQL.fncCheckLicenseID(lvOSKeys); //OS LicenseID อ้างอิง
            var licenseOSEffective = GsysSQL.fncCheckEffecttive(lvOSKeys); //OS License ที่มีทั้งหมด
            var licenseOSUnresolve = GsysSQL.fncCheckUnresolve(lvOSKeys); //OS License ที่ถูกใช้ไป
            var licenseOSMakActive = GsysSQL.fncCheckMakActive(lvOSKeys); // OS Active
            //var licenseOSMaksplit = licenseOSMakActive.Split('/');
            //var OSsplit0 = licenseOSMaksplit[0];
            //var OSsplit1 = licenseOSMaksplit[1];

            if (licenseOSEffective == licenseOSUnresolve && licenseOSEffective != "")
            {
                MsgBox("LicenseWindowsKeys นี้ถูกใช้ครบหมดแล้ว", this.Page, this);
                return;
            }
            //if (OSsplit0 == OSsplit1)
            //{
            //    MsgBox("LicenseWindowsKeys นี้ถูก Activate เต็มแล้ว", this.Page, this);
            //    return;
            //}
            #endregion

            #region //เช็ค LicenseID Microsoft ว่าครบแล้วหรือยัง
            var lvMSKeys = cmbMsKeys.Text;
            var licenseMSID = GsysSQL.fncCheckLicenseID(lvMSKeys); //MS LicenseID อ้างอิง
            var licenseMSEffective = GsysSQL.fncCheckEffecttive(lvMSKeys); //MS License ที่มีทั้งหมด
            var licenseMSUnresolve = GsysSQL.fncCheckUnresolve(lvMSKeys); //MS License ที่ถูกใช้ไป
            var licenseMSMakActive = GsysSQL.fncCheckMakActive(lvMSKeys); // MS Active
            //var licenseMSMaksplit = licenseMSMakActive.Split('/');
            //var MSsplit0 = licenseMSMaksplit[0];
            //var MSsplit1 = licenseMSMaksplit[1];

            if (licenseMSEffective == licenseMSUnresolve && licenseMSEffective != "")
            {
                MsgBox("LicenseMicrosoftKeys นี้ถูกใช้ครบหมดแล้ว", this.Page, this);
                return;
            }

            //if (MSsplit0 == MSsplit1)
            //{
            //    MsgBox("LicenseMicrosoftKeys นี้ถูก Activate เต็มแล้ว", this.Page, this);
            //    return;
            //}
            #endregion

            //#region //เช็ครหัส AssetHardware ว่าซ้ำกันหรือไม่
            //var lvAssetHw = txtHwAssetID.Text;
            //var lvAssetHwChk = GsysSQL.fncCheckHardwareAsset(lvAssetHw);

            //if (lvAssetHw == lvAssetHwChk)
            //{
            //    MsgBox("รหัสทรัพย์สิน Hardware ถูกใช้ไปแล้วกรุณาลองใหม่อีกครั้ง", this.Page, this);
            //    return;
            //}
            //#endregion

            //#region //เช็ครหัส AssetMonitor ว่าซ้ำกันหรือไม่
            //var lvAssetMonitor1 = txtMonitorAsset1.Text;
            //var lvAssetMonitor2 = txtMonitorAsset2.Text;

            //var lvAssetMonitor1Chk = GsysSQL.fncCheckMonitorAsset1(lvAssetMonitor1);
            //var lvAssetMonitor1_2Chk = GsysSQL.fncCheckMonitorAsset1(lvAssetMonitor2);

            //var lvAssetMonitor2Chk = GsysSQL.fncCheckMonitorAsset2(lvAssetMonitor1);
            //var lvAssetMonitor2_2Chk = GsysSQL.fncCheckMonitorAsset2(lvAssetMonitor2);

            //if (lvAssetMonitor1 == lvAssetMonitor1Chk || lvAssetMonitor1 == lvAssetMonitor1_2Chk || lvAssetMonitor1 == lvAssetMonitor2Chk || lvAssetMonitor1 == lvAssetMonitor2_2Chk)
            //{
            //    MsgBox("รหัสทรัพย์สิน Monitor ตัวที่1 ถูกใช้ไปแล้วกรุณาลองใหม่อีกครั้ง", this.Page, this);
            //    return;
            //}

            //if (lvAssetMonitor2 == lvAssetMonitor2Chk || lvAssetMonitor2 == lvAssetMonitor2_2Chk || lvAssetMonitor2 == lvAssetMonitor1Chk || lvAssetMonitor2 == lvAssetMonitor1_2Chk)
            //{
            //    MsgBox("รหัสทรัพย์สิน Monitor ตัวที่2 ถูกใช้ไปแล้วกรุณาลองใหม่อีกครั้ง", this.Page, this);
            //    return;
            //}
            //#endregion

            //#region //เช็ครหัส AssetUPS ว่าซ้ำกันหรือไม่
            //var lvAssetUPS = txtUPSAsset.Text;

            //var lvAssetUPSCheck = GsysSQL.fncCheckUPSAsset(lvAssetUPS);

            //if (lvAssetUPS == lvAssetUPSCheck)
            //{
            //    MsgBox("รหัสทรัพย์สิน UPS ถูกใช้ไปแล้วกรุณาลองใหม่อีกครั้ง", this.Page, this);
            //    return;
            //}
            //#endregion

            try
            {
                var lvNo = txtNo.Text;
                var lvSecID = txtSecID.Text;
                var lvSecName = txtSecName.Text;
                var lvSegID = txtSegID.Text;
                var lvSegName = txtSegName.Text;
                var lvFacID = txtFacID.Text;
                var lvFacName = txtFacName.Text;
                if(lvFacName == "-- เลือก --")
                {
                    lvFacName = "";
                }
                var lvEmpID = txtEmpID.Text;
                var lvEmpName = txtEmpName.Text;
                var lvNickName = txtNickname.Text;
                var lvDate = txtDateSetup.Text;
                var lvDateSetup = "";
                if(lvDate != "")
                {
                    lvDateSetup = GsysFunc.fncChangeTDate(GsysFunc.Dateformatting(lvDate));
                }
                
                var lvStatus = "Active";
                var lvRemark = txtRemark.Text;

                if (lvComName.Equals(""))
                {
                    MsgBox("กรุณากรอกชื่อเครื่อง", this.Page, this);
                    return;
                }
                else if (lvEmpID.Equals("") && lvEmpName.Equals(""))
                {
                    MsgBox("กรุณากรอกข้อมูลผู้ใช้ให้ครบถ้วน", this.Page, this);
                    return;
                }
                else
                {
                    try
                    {
                        var lvSQL = "Insert Into com_pcuser (No, SecID, SecName, SegID, SegName, FacID, FacName, ComName, EmpID, EmpName, NickName, Date, Status, Remark) " +
                                    "Values ('" + lvNo + "', '" + lvSecID + "', '" + lvSecName + "', '" + lvSegID + "', '" + lvSegName + "', '" + lvFacID + "', '" + lvFacName + "', " +
                                    "'" + lvComName + "', '" + lvEmpID + "', '" + lvEmpName + "', '" + lvNickName + "', '" + lvDateSetup + "', '" + lvStatus + "', '" + lvRemark + "')";
                        var lvResult = GsysSQL.fncExecuteQueryData(lvSQL);

                        fncSaveDataSoftware(lvComName);
                    }
                    catch (Exception ex)
                    {
                        MsgBox(ex.ToString(), this.Page, this);
                    }
                }
            } catch (Exception e)
            {
                MsgBox(e.ToString(), this.Page, this);
            }
            
        } //บันทึกข้อมูลผู้ใช้

        private void fncSaveDataSoftware(string lvComName)
        {
            var lvWebroot = 0;
            var lvBackupDesk = 0;
            var lvRemoveDrive = 0;

            if (chkWebroot.Checked == true)
            {
                lvWebroot = 1;
            }
            if (chkBackup.Checked == true)
            {
                lvBackupDesk = 1;
            }
            if (chkDriveD.Checked == true)
            {
                lvRemoveDrive = 1;
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
                var lvSQL = "Insert Into com_pcsoftware (ComName, Webroot, BackupDesk, RemoveDrive, OS, Microsoft, Autocad, Antivirus, AnydeskCode, Winzip, " +
                            "Media, PDF, MountImage, Line, Chrome, Impress, Cane, Other) Values ('" + lvComName + "', '" + lvWebroot + "', '" + lvBackupDesk + "', " +
                            "'" + lvRemoveDrive + "', '" + lvOS + "', '" + lvMicrosoft + "', '" + lvAutocad + "', '" + lvAntivirus + "', '" + lvAnydeskCode + "', " +
                            "'" + lvWinzip + "', '" + lvMedia + "', '" + lvPDF + "', '" + lvMountImage + "', '" + lvLine + "', '" + lvChrome + "', '" + lvImpress + "', " +
                            "'" + lvCane + "', '" + lvOther + "')";
                var lvResult = GsysSQL.fncExecuteQueryData(lvSQL);

                fncSaveDataKeyUsing(lvComName);
                fncSaveDataHardware(lvComName);
            }
            catch (Exception ex)
            {
                MsgBox(ex.ToString(), this.Page, this);
            }
        } //บันทึกข้อมูล Software

        private void fncSaveDataKeyUsing(string lvComName)
        {
            try
            {
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

                var lvSQL = "Insert Into com_pckeyusing (EmpID, ComName, OSKeys, MicrosoftKeys, AutoCadKeys) " +
                            "Values ('" + lvEmpID + "', '" + lvComName + "', '" + lvOSKeys + "', '" + lvMSKeys + "', '" + lvAutocadKeys + "')";
                var lvResult = GsysSQL.fncExecuteQueryData(lvSQL);

                lvSQL = "Update c_Key SET c_Count = c_Count + 1 Where c_ProductKey = '" + lvOSKeys + "'";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);

                lvSQL = "Update c_Key SET c_Count = c_Count + 1 Where c_ProductKey = '" + lvMSKeys + "'";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
                    

                if (!lvOSKeys.Equals(""))
                {
                    var licenseOSID = GsysSQL.fncCheckLicenseID(lvOSKeys);
                    UpdateLicenseUSE(licenseOSID);
                    //UpdateLicenseActivate(lvOSKeys);
                }
                if (!lvMSKeys.Equals(""))
                {
                    var licenseMSID = GsysSQL.fncCheckLicenseID(lvMSKeys);
                    UpdateLicenseUSE(licenseMSID);
                    //UpdateLicenseActivate(lvMSKeys);
                }
            }
            catch (Exception ex)
            {
                MsgBox(ex.ToString(), this.Page, this);
            }
        } //บันทึกข้อมูลใช้ License

        private void fncSaveDataHardware(string lvComName)
        {
            var CPUModel = txtCPUModel.Text;
            var RamAmount = txtRamAmount.Text;
            var HDDAmount = txtHddAmount.Text;
            var Mouse = txtMouse.Text;
            var Keyboard = txtKeyboard.Text;
            var ServiceTag = txtExpressTag.Text;
            var AssetHW = txtHwAssetID.Text;

            try
            {
                var lvSQL = "Insert Into com_pchardware (ComName, CPUModel, RamAmount, HDDAmount, Mouse, Keyboard, ServiceTag, AssetHw) " +
                            "Values ('" + lvComName + "', '" + CPUModel + "', '" + RamAmount + "', '" + HDDAmount + "', '" + Mouse + "', '" + Keyboard + "', " +
                            "'" + ServiceTag + "', '" + AssetHW + "') ";
                var lvResult = GsysSQL.fncExecuteQueryData(lvSQL);

                fncSaveDataNetwork(lvComName);
            }
            catch (Exception ex)
            {
                MsgBox(ex.ToString(), this.Page, this);
            }
        } //บันทึกข้อมูล Hardware

        private void fncSaveDataNetwork(string lvComName)
        {
            var lvDomain = txtDomain.Text;
            var IPAddress = txtIPAddress.Text;
            var LanAddress = txtLanAddress.Text;
            var WifiAddress = txtWifiAddress.Text;
            var Addthai = 0;
            if(chkAddThai.Checked == true)
            {
                Addthai = 1;
            }

            var Administrator = 0;
            if(chkAdministrator.Checked == true)
            {
                Administrator = 1;
            }

            try
            {
                var lvSQL = "Insert Into com_pcnetwork (ComName, Domain, IPAddress, LanAddress, WifiAddress, ThaiAdd, Administrator) " +
                            "Values ('" + lvComName + "', '" + lvDomain + "', '" + IPAddress + "', '" + LanAddress + "', '" + WifiAddress + "', " +
                            "'" + Addthai + "', '" + Administrator + "')";
                var lvResult = GsysSQL.fncExecuteQueryData(lvSQL);

                fncSaveDataMonitor(lvComName);
            }
            catch (Exception ex)
            {
                MsgBox(ex.ToString(), this.Page, this);
            }
        } //บันทึกข้อมูล Network

        private void fncSaveDataMonitor(string lvComName)
        {
            var lvMonitor = txtMonitor.Text;
            var lvMonitorBrand = txtMonitorBrand.Text;
            var lvMonitorSerial = txtMonitorSerial.Text;
            var lvAssetMonitor1 = txtMonitorAsset1.Text;
            var lvAssetMonitor2 = txtMonitorAsset2.Text;
            var lvDateMonitor = "";
            var lvDate = txtMonitorDate.Text;
            if (lvDate != "")
            {
                lvDateMonitor = GsysFunc.fncChangeTDate(GsysFunc.Dateformatting(lvDate));
            }
           

            try
            {
                var lvSQL = "Insert Into com_pcmonitor (ComName, Monitor, Brand, Serial, AssetMonitor1, AssetMonitor2,Date) " +
                            "Values ('" + lvComName + "', '" + lvMonitor + "', '" + lvMonitorBrand + "', '" + lvMonitorSerial + "', '" + lvAssetMonitor1 + "', '" + lvAssetMonitor2 + "', " +
                            "'" + lvDateMonitor + "') ";
                var lvResult = GsysSQL.fncExecuteQueryData(lvSQL);

                fncSaveDataUPS(lvComName);
            }
            catch (Exception ex)
            {
                MsgBox(ex.ToString(), this.Page, this);
            }
        } //บันทึกข้อมูล Monitor

        private void fncSaveDataUPS(string lvComName)
        {
            var lvUPS = txtUPS.Text;
            var lvBrand = txtUPSBrand.Text;
            var lvSerial = txtUPSSerial.Text;
            var lvAssetUPS = txtUPSAsset.Text;
            var lvUPSDate = "";
            var lvDate = txtUPSDate.Text;
            if (lvDate != "")
            {
                lvUPSDate = GsysFunc.fncChangeTDate(GsysFunc.Dateformatting(lvDate));
            }

            try
            {
                var lvSQL = "Insert Into com_pcups (ComName, UPS, Brand, Serial, AssetUPS, Date) " +
                    "Values ('" + lvComName + "', '" + lvUPS + "', '" + lvBrand + "', '" + lvSerial + "', '" + lvAssetUPS + "', '" + lvUPSDate + "')";
                var lvResult = GsysSQL.fncExecuteQueryData(lvSQL);

                if(lvResult == "Success")
                {
                    lvSQL = "Update sysdocno SET S_RunNO = S_RunNo + 1 Where S_MCode = 'Invent'";
                    lvResult = GsysSQL.fncExecuteQueryData(lvSQL);

                    //MsgBox("บันทึกข้อมูลสำเร็จ", this.Page, this);
                    ClientScript.RegisterStartupScript(typeof(Page), "alertMessage", "<script type='text/javascript'>alert('บันทึกข้อมูลสำเร็จ!');window.location.replace('frmIndex.aspx');</script>");
                }

                //Response.Redirect("frmIndex.aspx");
            }
            catch (Exception ex)
            {
                MsgBox(ex.ToString(), this.Page, this);
            }
        } //บันทึกข้อมูล UPS

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
            var lvSQL = "Select c_ProductKey From c_key Where c_Product = '" + WindowsProduct + "'  And c_Type = 'MAK'";
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
            var lvSQL = "Select c_ProductKey From c_key Where c_Product = '" + MicrosoftProduct + "' And c_Type = 'MAK'";
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

        protected void btnGenNo_Click(object sender, EventArgs e) 
        {
            txtNo.Text = GsysSQL.fncGenDocNo("Invent");
            Mode = "New";
            EnabledTextbox();
        } //Gen เลขที่

        protected void cmbOsProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Product = cmbOsProduct.Text;
            fncGetcmbOSKeys(Product);
        } //Combobox OSProduct Event

        protected void cmbMsProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Product = cmbMsProduct.Text;
            fncGetMSKeys(Product);
        } //Combobox MSProduct Event

        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        } //MsgBox Alert

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            fncSaveAll();
        } //Button Submit Event

        private void fncSaveAll()
        {
            var lvComName = txtComName.Text;

            fncSaveDataHeader(lvComName);
        }

        private void UpdateLicenseUSE(string lvLicenseID)
        {
            var lvSQL = "Update c_license SET c_Unresolve = c_Unresolve + 1 Where c_LicenseID = '" + lvLicenseID + "' ";
            var lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
        } //อัพเดท Unresolve licenseID

        private void UpdateLicenseActivate(string lvLicenseKeys)
        {
            var licenseMakActive = GsysSQL.fncCheckMakActive(lvLicenseKeys); // OS Active
            var licenseMaksplit = licenseMakActive.Split('/');
            var split0 = licenseMaksplit[0];
            var split1 = licenseMaksplit[1];
            var licenseMakActiveUP = (Convert.ToInt32(split0) + 1) + "/" + split1;

            var lvSQL = "Update c_key SET c_MakActivate = '" + licenseMakActiveUP + "' WHERE c_ProductKey = '" + lvLicenseKeys + "' ";
            var lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
        } //อัพเดท LiecnseKeys MAK Activate

        protected void txtEmpID_TextChanged(object sender, EventArgs e)
        {
            var lvEmpID = txtEmpID.Text;
            DataTable DT = new DataTable();
            var lvSQL = "Select Employee_NTitle, Employee_Name, Employee_LName From employee Where Employee_ID = '" + lvEmpID + "'";
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                var lvMNAme = DT.Rows[i]["Employee_NTitle"].ToString();
                var lvFNAme = DT.Rows[i]["Employee_Name"].ToString();
                var lvLNAme = DT.Rows[i]["Employee_LName"].ToString();

                var lvFullName = lvMNAme + " " + lvFNAme + " " + lvLNAme;

                txtEmpName.Text = lvFullName;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmIndex.aspx");
        }

        protected void txtFacName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lvFactionName = txtFacName.Text;
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