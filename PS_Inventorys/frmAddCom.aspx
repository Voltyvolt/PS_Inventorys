<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="frmAddCom.aspx.cs" Inherits="PS_Inventorys.frmAddCom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

    <link href="https://fonts.googleapis.com/css2?family=Prompt:wght@500&display=swap" rel="stylesheet" />
    <style>
        .panel-header {
            font-family: 'Prompt', sans-serif;
            border: solid;
            border-color: black;
        }

        .panel-body {
            font-family: 'Prompt', sans-serif;
        }

        .panel-user {
            border-bottom: solid;
            border-color: black;
        }

        .panel-software {
            border-bottom: solid;
            border-color: black;
        }

        .panel-hardware {
            border-bottom: solid;
            border-color: black;
        }

        .panel-network {
            border-bottom: solid;
            border-color: black;
        }

        .panel-monitor {
            border-bottom: solid;
            border-color: black;
        }

        .panel-ups {
            border-bottom: solid;
            border-color: black;
        }

        .panel-remark {
            border-bottom: solid;
            border-color: black;
        }

        .panel-btn {
            margin-top: 25px;
        }


        .row {
            margin-left: 20px;
        }

        .btnsubmit {
            border: none;
            outline: none;
            height: 40px;
            font-size: 16px;
            color: black;
            background-color: mediumspringgreen;
            width: 100%;
            cursor: pointer;
            border-radius: 20px;
            transition: .3s ease-in-out;
        }

            .btnsubmit:hover {
                background-color: darkturquoise;
            }

        .btncancel {
            border: none;
            outline: none;
            height: 40px;
            font-size: 16px;
            color: black;
            background-color: red;
            width: 100%;
            cursor: pointer;
            border-radius: 20px;
            transition: .3s ease-in-out;
        }

            .btncancel:hover {
                background-color: darkred;
            }
        
    </style>

    <section id="wrapper">
        <div class="col-lg-12">
            <section class="panel">
                <div class="panel-background">
                    <header class="panel-heading">
                        <div class="panel-header">
                            <div class="col-md-10 col-md-offset-3">
                                <h1>แบบฟอร์มลงทะเบียนคอมพิวเตอร์โรงงาน</h1>
                            </div>
                        </div>
                    </header>

                    <br />
                    <br />
                    <br />

                    <div class="panel-body">
                        <div class="panel-user">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <h3>ข้อมูล Header</h3>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label Text="เลขที่" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="false" CssClass="form-control" placeholder="กดปุ่มเพิ่มเลขที่" ID="txtNo"></asp:TextBox>
                                        <asp:Button runat="server" Text="เพิ่มเลขที่" ID="btnGenNo" CssClass="btn btn-info" Width="100px" OnClick="btnGenNo_Click" />
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="รหัสฝ่าย" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="รหัสฝ่าย" ID="txtSecID"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="ชื่อฝ่าย" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="ชื่อฝ่าย" ID="txtSecName"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="รหัสส่วนงาน" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="รหัสส่วนงาน" ID="txtSegID"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="ชื่อส่วนงาน" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="ชื่อส่วนงาน" ID="txtSegName"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="รหัสแผนก" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="รหัสแผนก" ID="txtFacID"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="ชื่อแผนก" runat="server"></asp:Label>
                                        <div class="dropdown">
                                            <asp:DropDownList runat="server" placeholder="ชื่อแผนก" AutoPostBack="true" ID="txtFacName" CssClass="form-control" OnSelectedIndexChanged="txtFacName_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="ชื่อเครื่อง" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="ชื่อเครื่อง" ID="txtComName"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="รหัสพนักงาน" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="รหัสพนักงาน" ID="txtEmpID" AutoPostBack="True" OnTextChanged="txtEmpID_TextChanged"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="ชื่อผู้ใช้งาน" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="ชื่อผู้ใช้งาน" ID="txtEmpName"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="ชื่อเล่น" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="ชื่อเล่น" ID="txtNickname"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="วันที่ติดตั้ง" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" TextMode="Date" placeholder="วันที่ติดตั้ง" ID="txtDateSetup"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <br />
                        <br />

                        <div class="panel-software">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <h3>ข้อมูล Software</h3>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" Text="ลบ Webroot" ID="chkWebroot" Visible="false" />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" Text="Backup หน้าจอ Desktop" ID="chkBackup" Visible="false" />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" Text="ลบ Drive:D" ID="chkDriveD" Visible="false" />
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="Windows ที่ใช้งาน" runat="server"></asp:Label>
                                        <div class="dropdown">
                                            <asp:DropDownList runat="server" placeholder="เลือก Windows" AutoPostBack="true" ID="cmbOsProduct" CssClass="form-control" OnSelectedIndexChanged="cmbOsProduct_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="Windows Keys" runat="server"></asp:Label>
                                        <div class="dropdown">
                                            <asp:DropDownList runat="server" placeholder="เลือก Keys" ID="cmbOsKeys" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="กรอก Windows Keys Manual" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="ระบุ Keys" ID="txtOSKeys"></asp:TextBox>
                                    </div>
                                </div>

                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="Microsoft Office ที่ใช้งาน" runat="server"></asp:Label>
                                        <div class="dropdown">
                                            <asp:DropDownList runat="server" placeholder="เลือก Microsoft" AutoPostBack="true" ID="cmbMsProduct" CssClass="form-control" OnSelectedIndexChanged="cmbMsProduct_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="Microsoft Office Keys" runat="server"></asp:Label>
                                        <div class="dropdown">
                                            <asp:DropDownList runat="server" placeholder="เลือก Keys" ID="cmbMsKeys" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="กรอก Office Keys Manual" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="ระบุ Keys" ID="txtMSKeys"></asp:TextBox>
                                    </div>
                                </div>

                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="Antivirus" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="false" Text="TrendMicro" CssClass="form-control" placeholder="Antivirus" ID="txtAntivirus"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="ชื่อ Autocad" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="ชื่อ Autocad" ID="txtAutocadName"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="Autocad Keys" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="Autocad Keys" ID="txtAutocadKeys"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="รหัส Anydesk" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" TextMode="Number" MaxLength="9" CssClass="form-control" placeholder="รหัส Anydesk" ID="txtAnydeskId"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="โปรแกรม Zip" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" Text="7-Zip" CssClass="form-control" placeholder="โปรแกรม Zip" ID="txtZipBrand"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="โปรแกรม Media" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" Text="K-LiteCodec" CssClass="form-control" placeholder="โปรแกรม Media" ID="txtMediaBrand"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="โปรแกรม Pdf" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" Text="PDF-XChange" CssClass="form-control" placeholder="โปรแกรม Pdf" ID="txtPdfBrand"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="โปรแกรม Mount-Image" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="โปรแกรม Mount-Image" ID="txtMountImage"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" Text="ลงโปรแกรม Line" ID="chkLine" />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" Text="ลงโปรแกรม Google Chrome" ID="chkGoogleChrome" />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" Text="ลงโปรแกรม Impress" ID="chkImpress" Visible="false" />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" Text="ลงโปรแกรม Cane" ID="chkCane" Visible="false" />
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <h3>โปรแกรมอื่นๆ</h3>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="โปรแกรมอื่นๆ" ID="txtOther"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="panel-hardware">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <h3>ข้อมูล Hardware</h3>
                                    </div>
                                </div>
                            </div>
                            <br />

                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="CPU-Model" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="CPU-Model" ID="txtCPUModel"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="Ram-Amount" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="Ram-Amount" ID="txtRamAmount"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="HDD-Amount" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="HDD-Amount" ID="txtHddAmount"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="รหัสทรัพย์สิน" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="รหัสทรัพย์สิน" ID="txtHwAssetID"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="Mouse" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="Mouse" ID="txtMouse"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="Keyboard" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="Keyboard" ID="txtKeyboard"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="Express-Service-Tag" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="Express-Service-Tag" ID="txtExpressTag"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="panel-network">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <h3>ข้อมูล Network</h3>
                                    </div>
                                </div>
                            </div>
                            <br />

                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="Domain" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" Text="ps.trrgroup.com" CssClass="form-control" placeholder="Domain" ID="txtDomain"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="IP-Address" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="IP-Address" ID="txtIPAddress"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="Lan-Mac-Address" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="Lan-Mac-Address" ID="txtLanAddress"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="Wifi-Mac-Address" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="Wifi-Mac-Address" ID="txtWifiAddress"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:CheckBox runat="server" Text="เพิ่มภาษาไทย" ID="chkAddThai" />
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:CheckBox runat="server" Text="เพิ่มรหัส Admin" ID="chkAdministrator" />
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="panel-monitor">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <h3>ข้อมูล Monitor</h3>
                                    </div>
                                </div>
                            </div>
                            <br />

                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="Monitor" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="Monitor" ID="txtMonitor"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="Monitor-Brand" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="Monitor-Brand" ID="txtMonitorBrand"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="Monitor-Serial" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="Serial-Number" ID="txtMonitorSerial"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="รหัสทรัพย์สินจอที่ 1" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="รหัสทรัพย์สินจอที่ 1" ID="txtMonitorAsset1"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="รหัสทรัพย์สินจอที่ 2" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="รหัสทรัพย์สินจอที่ 2" ID="txtMonitorAsset2"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="วันที่ติดตั้ง" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" TextMode="Date" CssClass="form-control" placeholder="วันที่ติดตั้ง" ID="txtMonitorDate"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="panel-ups">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <h3>ข้อมูล UPS</h3>
                                    </div>
                                </div>
                            </div>
                            <br />

                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="UPS" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="UPS" ID="txtUPS"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="UPS-Brand" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="UPS-Brand" ID="txtUPSBrand"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="UPS-Serial" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="Serial-Number" ID="txtUPSSerial"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="รหัสทรัพย์สิน" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="รหัสทรัพย์สิน" ID="txtUPSAsset"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="วันที่ติดตั้ง" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" TextMode="Date" CssClass="form-control" placeholder="วันที่ติดตั้ง" ID="txtUPSDate"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="panel-remark">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <h3>ข้อมูลเพิ่มเติม</h3>
                                    </div>
                                </div>
                            </div>
                            <br />

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <asp:Label Text="บันทึกเพิ่มเติม" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" Enabled="true" CssClass="form-control" placeholder="บันทึกเพิ่มเติม" ID="txtRemark"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="panel-btn">
                            <div class="row">
                                <div class="col-md-4 col-md-offset-2">
                                    <asp:Button runat="server" Text="บันทึก" ID="btnSubmit" CssClass="btnsubmit" OnClick="btnSubmit_Click" />
                                </div>
                                <div class="col-md-4">
                                    <asp:Button runat="server" Text="กลับไปหน้าแรก" ID="btnCancel" CssClass="btncancel" OnClick="btnCancel_Click" />
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </section>
        </div>
    </section>


</asp:Content>
