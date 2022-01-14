<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="frmIndex.aspx.cs" Inherits="PS_Inventorys.frmIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <link href="https://fonts.googleapis.com/css2?family=Prompt:wght@500&display=swap" rel="stylesheet" />
    <link href="Content/font-awesome.min.css" rel="stylesheet" />

    <script>
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("ยืนยันการทำรายการ?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>

    <style>
        .panel-header, .panel-body {
            font-family: 'Prompt', sans-serif;
            border: solid;
            border-color: black;
        }

        .btn {
            background-color: DodgerBlue; /* Blue background */
            border: none; /* Remove borders */
            color: white; /* White text */
            padding: 12px 16px; /* Some padding */
            font-size: 16px; /* Set a font size */
            cursor: pointer; /* Mouse pointer on hover */
        }

            /* Darker background on mouse-over */
            .btn:hover {
                background-color: RoyalBlue;
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

        .myButton {
            box-shadow: inset 0px -3px 7px 0px #29bbff;
            background: linear-gradient(to bottom, #2dabf9 5%, #0688fa 100%);
            background-color: #2dabf9;
            border-radius: 3px;
            border: 1px solid #0b0e07;
            display: inline-block;
            cursor: pointer;
            color: #ffffff;
            font-family: 'Prompt', sans-serif;
            font-size: 15px;
            padding: 9px 23px;
            text-decoration: none;
            text-shadow: 0px 1px 0px #263666;
        }

            .myButton:hover {
                background: linear-gradient(to bottom, #0688fa 5%, #2dabf9 100%);
                background-color: #0688fa;
            }

            .myButton:active {
                position: relative;
                top: 1px;
            }

        table.mygridview {
            font-family: 'Prompt', sans-serif;
            text-align: center;
            border-collapse: collapse;
            width: 100%;
        }

            table.mygridview td, table.mygridview th {
                border: 1px solid #ddd;
                padding: 8px;
            }

            table.mygridview tr:nth-child(even) {
                background-color: #f2f2f2;
            }

            table.mygridview tr:hover {
                background-color: #ddd;
            }

            table.mygridview th {
                padding-top: 12px;
                padding-bottom: 12px;
                text-align: center;
                background-color: #4CAF50;
                text-shadow: 2px 2px black;
                color: white;
            }
    </style>

    <section id="wrapper">
        <div class="col-lg-12">
            <section class="panel">
                <div class="panel-background">
                    <header class="panel-heading">
                        <div class="panel-header">
                            <div class="col-md-10 col-md-offset-4">
                                <h1>ทะเบียนคอมพิวเตอร์โรงงาน</h1>
                            </div>
                        </div>
                    </header>

                    <br />
                    <%--<br />--%>
                    <br />

                    <div class="panel-body">
                        <div class="panel-user">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Button ID="BtnAddCom" runat="server" CssClass="myButton" Text="เพิ่มข้อมูล" OnClick="BtnAddCom_Click" />
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <h1>ข้อมูลผู้ใช้</h1>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="dropdown">
                                            <asp:Label Text="ค้นหาตามแผนก..." runat="server"></asp:Label>
                                            <asp:DropDownList runat="server" placeholder="ค้นหาตามแผนก" AutoPostBack="true" ID="cmbSearch" CssClass="form-control" OnSelectedIndexChanged="cmbSearch_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                        <div class="col-md-5">
                                            <div class="form-group">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <br />

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <asp:GridView runat="server" ID="GridComuser" AutoGenerateColumns="false" AllowPaging="True" CssClass="mygridview" OnPageIndexChanging="GridComuser_PageIndexChanging" OnRowCommand="GridComuser_RowCommand">
                                            <Columns>
                                                <asp:BoundField ItemStyle-Width="0px" DataField="Id" HeaderText="Id" Visible="false" />
                                                <asp:BoundField ItemStyle-Width="30px" DataField="No" HeaderText="เลขที่" />
                                                <asp:BoundField ItemStyle-Width="100px" DataField="ComName" HeaderText="ชื่อเครื่อง" />
                                                <asp:BoundField ItemStyle-Width="60px" DataField="FacName" HeaderText="ชื่อแผนก" />
                                                <asp:BoundField ItemStyle-Width="50px" DataField="EmpID" HeaderText="รหัสพนักงาน" />
                                                <asp:BoundField ItemStyle-Width="100px" DataField="EmpName" HeaderText="ชื่อ-สกุล" />
                                                <asp:BoundField ItemStyle-Width="50px" DataField="NickName" HeaderText="ชื่อเล่น" />
                                                <asp:BoundField ItemStyle-Width="30px" DataField="Status" HeaderText="สถานะ" />
                                                <asp:BoundField ItemStyle-Width="30px" DataField="Showall" HeaderText="Windows/Office" />
                                                <asp:TemplateField ItemStyle-Width="120px" HeaderText="จัดการ">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="BtnEdit" runat="server" CssClass="btn" CommandArgument='<%# Eval("Id") %>' OnClick="Edit_Click" ToolTip="แก้ไขข้อมูล"><i class="fa fa-address-card fa-7x"></i></asp:LinkButton>
                                                        <asp:LinkButton ID="BtnSwitch" runat="server" CssClass="btn" CommandArgument='<%# Eval("Id") %>' ToolTip="Active เครื่องนี้" OnClientClick="return Confirm();" OnClick="Switch_Click"><i class="fa fa-history fa-7x"></i></asp:LinkButton>
                                                        <asp:LinkButton ID="BtnDelete" runat="server" CssClass="btn" CommandArgument='<%# Eval("Id") %>' ToolTip="Disabled เครื่องนี้" OnClientClick="return Confirm();" OnClick="Delete_Click"><i class="fa fa-trash fa-7x"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <h1>ข้อมูล License KEY </h1>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <asp:GridView runat="server" ID="GridLicenseID" AutoGenerateColumns="false" AllowPaging="True" CssClass="mygridview" OnPageIndexChanging="GridLicenseID_PageIndexChanging">
                                            <Columns>
                                                <asp:BoundField ItemStyle-Width="0px" DataField="c_PK" HeaderText="Id" Visible="false" />
                                                <asp:BoundField ItemStyle-Width="30px" DataField="No" HeaderText="เลขที่" />
                                                <asp:BoundField ItemStyle-Width="30px" DataField="c_LicenseID" HeaderText="LicenseID" />
                                                <asp:BoundField ItemStyle-Width="30px" DataField="c_Product Family" HeaderText="ชนิดโปรแกรม" />
                                                <asp:BoundField ItemStyle-Width="30px" DataField="c_Version" HeaderText="เวอร์ชั่น" />
                                                <asp:BoundField ItemStyle-Width="30px" DataField="c_Effective" HeaderText="สูงสุด" />
                                                <asp:BoundField ItemStyle-Width="30px" DataField="c_Unresolve" HeaderText="ใช้ไป" />
                                                <asp:TemplateField ItemStyle-Width="100px" HeaderText="จัดการ">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="BtnLicenseView" runat="server" CssClass="btn" CommandArgument='<%# Eval("c_LicenseID") %> ' ToolTip="ดูข้อมูล License Key" OnClick="ViewLicense_Click"><i class="fa fa-address-card fa-7x"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4 col-md-offset-4">
                                    <div class="form-group">
                                        <asp:Button ID="BtnReturn" runat="server" CssClass="btncancel" Text="กลับไปหน้าแรก" OnClick="BtnReturn_Click" />
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </section>
        </div>
    </section>
</asp:Content>
