<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="frmLicenseView.aspx.cs" Inherits="PS_Inventorys.frmLicenseView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <link href="https://fonts.googleapis.com/css2?family=Prompt:wght@500&display=swap" rel="stylesheet" />
    <link href="Content/font-awesome.min.css" rel="stylesheet" />

    <style>
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

        .panel-body{
            font-family: 'Prompt', sans-serif;
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
                <header class="panel-heading">
                    <div class="panel-header">
                        <div class="col-md-10 col-md-offset-5">
                            <h1>ข้อมูล License Keys</h1>
                        </div>
                    </div>
                </header>

                <br />
                <br />
                <br />

                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <asp:GridView runat="server" ID="GridViewLicense" AutoGenerateColumns="false" AllowPaging="True" CssClass="mygridview" OnPageIndexChanging="GridViewLicense_PageIndexChanging">
                                    <Columns>
                                        <asp:BoundField ItemStyle-Width="0px" DataField="c_Pk" HeaderText="Id" Visible="false" />
                                        <asp:BoundField ItemStyle-Width="70px" DataField="c_LicenseID" HeaderText="LicenseID" />
                                        <asp:BoundField ItemStyle-Width="70px" DataField="c_ProductKey" HeaderText="LicenseKey" />
                                        <asp:BoundField ItemStyle-Width="70px" DataField="c_Product" HeaderText="Product" />
                                        <asp:BoundField ItemStyle-Width="70px" DataField="c_Count" HeaderText="ใช้ไปแล้ว/ครั้ง" />
                                        <asp:TemplateField ItemStyle-Width="100px" HeaderText="ดูข้อมูล">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="BtnLicenseKeysUse" runat="server" CssClass="btn" CommandArgument='<%# Eval("c_ProductKey") %>' OnClick="ViewLicenseUse_Click" ToolTip="ดูข้อมูลเครื่องที่ใช้งาน"><i class="fa fa-address-card fa-7x"></i></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>

                    <br />
                    <br />
                    <br />

                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <asp:GridView runat="server" ID="GridViewLicenseUse" AutoGenerateColumns="false" AllowPaging="True" CssClass="mygridview" OnPageIndexChanging="GridViewLicenseUse_PageIndexChanging">
                                    <Columns>
                                        <asp:BoundField ItemStyle-Width="0px" DataField="Id" HeaderText="Id" Visible="false" />
                                        <asp:BoundField ItemStyle-Width="50px" DataField="EmpID" HeaderText="รหัสพนักงาน" />
                                        <asp:BoundField ItemStyle-Width="50px" DataField="UserName" HeaderText="ชื่อ-สกุล" />
                                        <asp:BoundField ItemStyle-Width="50px" DataField="ComName" HeaderText="ชื่อเครื่อง" />
                                        <asp:BoundField ItemStyle-Width="50px" DataField="OSKeys" HeaderText="คีย์ Windows" />
                                        <asp:BoundField ItemStyle-Width="50px" DataField="MicrosoftKeys" HeaderText="คีย์ Microsoft" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-4 col-md-offset-4">
                            <div class="form-group">
                                <asp:Button ID="BtnReturn" runat="server" CssClass="btncancel" Text="กลับไปหน้าแรก" OnClick="btnReturn_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </section>

        </div>
    </section>
</asp:Content>
