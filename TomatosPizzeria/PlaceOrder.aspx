<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlaceOrder.aspx.cs" Inherits="PlaceOrder" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <link runat="server" rel="shortcut icon" href="/images/logo.ico" type="image/x-icon" />
    <link runat="server" rel="icon" href="/images/logo.ico" type="image/ico" />
    <title>Place Order</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="X-UA-Compatible" content="IE=9; IE=8; IE=7; IE=Edge,chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8, IE=9, chrome=1" />
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js"></script>
    <script src="js/jquery-1.11.1.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
    <link href="css/style.css" rel='stylesheet' type='text/css' />
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css">
    <script src="https://code.jquery.com/jquery-1.10.2.js"></script>
    <script src="https://code.jquery.com/ui/1.11.0/jquery-ui.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.11.0/themes/smoothness/jquery-ui.css">
    <style type="text/css">
        .apply_btn:hover {
            border: none;
            border-radius: 0px;
            background-color: #ca3027 !important;
            /*width: 180px;*/
            /*height: 50px;*/
        }

        .apply_btn {
            border-radius: 5px;
            background-color: #ca3027 !important;
            color: #ffffff;
            border: none;
            padding: 8px;
            text-transform: uppercase;
            width: 20%;
        }

        .nav > li > a:focus, .nav > li > a:hover {
            text-decoration: none;
            background-color: #ca3027 !important;
        }

        .customer-info .product_detail {
            height: 590px;
            overflow-y: scroll;
        }

        #lblProductName {
            font-size: 14px;
        }

        .navbar-nav > li.order a {
            text-transform: uppercase;
            font-size: 17px;
            padding: 15px 30px;
        }

        .navbar-nav > li.order {
            background: rgb(202, 48, 39) none repeat scroll 0% 0%;
            border-radius: 5px;
            margin-top: 0px !important;
            margin-left: 2px !important;
            height: 50px;
        }

        .dropdown:hover .dropdown-menu {
            display: block;
            margin-top: 0;
        }

        .LiLogin {
            margin-left: -2px;
        }

        .liReg {
            margin-left: 0px;
        }

        #Logout {
            margin-left: 65px;
        }

        @media only screen and (max-width:360px) {
            .LiLogin {
                margin-left: -2px;
            }

            .liReg {
                margin-left: 24px;
            }
            .form-control{
                margin-left: 13px;
            }
            .product_charges{
                float:right;
            }
            .product_price{
                /*float:right;*/
                margin-right:-9px;
            }
            .sales_tax{
                margin-right:-9px;
            }
            .delivery_tax{
                margin-right:-9px;
            }
            .total_price{
                 margin-right:2px;
            }
            /*.list-group{
                margin-right:-9px;
            }*/
        }

        @media only screen and (max-width:572px) and (min-width:359px) {
            #Logout {
                margin-left: 15px;
            }
        }

        @media only screen and (max-width:360px) {
            #AccountAnchor {
                margin-left: -34px;
            }

            #Logout {
                margin-left: 80px;
            }
        }

        @media only screen and (max-width:405px) {
            #liorderOnline {
                height: 60px;
            }
        }
    </style>
    <script type="text/javascript">
        //alert(window.innerWidth);
        $(function () {
            $("#datepicker").datepicker({ minDate: 0 });
            //Pass the user selected date format
            $("#format").change(function () {
                $("#datepicker").datepicker("option", "dateFormat", $(this).val());

            });
        });

        function Confirm() {

            var hdnfldVariable = document.getElementById("<%=hdnfldVariable.ClientID %>");

            if (confirm("Are you sure you want to delete Item From Cart?")) {

                hdnfldVariable.value = "Yes";

            } else {

                hdnfldVariable.value = "No";
            }

        }


        function formatTxtPhoneNumber() {


            var curval = document.getElementById("<%=txtTelephone.ClientID%>").value;
            var curchr = curval.length;

            if (curchr == 3) {

                curval = ("(" + curval + ")" + " ");
                document.getElementById("<%=txtTelephone.ClientID%>").value = curval;
            } else if (curchr == 9) {

                curval = curval + "-";
                document.getElementById("<%=txtTelephone.ClientID%>").value = curval;
            }
    }
    function validate() {
        var msg = "";
        if (document.getElementById("<%=txtName.ClientID%>").value == "Name") {
            document.getElementById("<%=txtName.ClientID%>").style.borderColor = "red";

            //return false;
        }
        else {
            document.getElementById("<%=txtName.ClientID%>").style.borderColor = "white";
        }


        if (document.getElementById("<%=txtemail.ClientID%>").value == "Email") {
            document.getElementById("<%=txtemail.ClientID%>").style.borderColor = "red";

                // return false;
            }
            else {

                var emailPat = /^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
                var emailid = document.getElementById("<%=txtemail.ClientID %>").value;
                var matchArray = emailid.match(emailPat);
                if (matchArray == null) {
                    //  alert("Enter Valid Email Address");

                    msg = "Please Enter Valid Email Address,";
                    document.getElementById("<%=txtemail.ClientID%>").style.borderColor = "red";
                    // document.getElementById("<%=ErrorMsgDiv.ClientID%>").style.display = "block";
                    document.getElementById("<%=ErrorMsgDiv.ClientID%>").innerHTML = msg;
                    //  return false;
                }
                else {
                    document.getElementById("<%=txtemail.ClientID%>").style.borderColor = "white";
                }
            }


          <%--  if (document.getElementById("<%=txtaddress.ClientID%>").value == "Customer Address") {
                document.getElementById("<%=txtaddress.ClientID%>").style.borderColor = "red";
               
            }
            else {
                document.getElementById("<%=txtaddress.ClientID%>").style.borderColor = "white";
            }
            if (document.getElementById("<%=txtCity.ClientID%>").value == "Customer City") {
                document.getElementById("<%=txtCity.ClientID%>").style.borderColor = "red";
               
            }
            else {
                document.getElementById("<%=txtCity.ClientID%>").style.borderColor = "white";
            }


            var selectedValue = document.getElementById('<%=DdlState.ClientID%>').value;
            if (selectedValue == "-1") {
             
                document.getElementById("<%=ErrorMsgDiv.ClientID%>").style.display = "block";
              
                msg = msg +"Please Select State,";
                document.getElementById("<%=DdlState.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=ErrorMsgDiv.ClientID%>").innerHTML = msg;
       
            }
            else {
                document.getElementById("<%=DdlState.ClientID%>").style.borderColor = "white";
            }

            if (document.getElementById("<%=txtzip.ClientID%>").value == "Customer Zip") {
                document.getElementById("<%=txtzip.ClientID%>").style.borderColor = "red";
               
            }
            else {
                document.getElementById("<%=txtzip.ClientID%>").style.borderColor = "white";
            }--%>

        if (document.getElementById("<%=txtTelephone.ClientID%>").value == "Number") {
            document.getElementById("<%=txtTelephone.ClientID%>").style.borderColor = "red";

            }
            else {


                var phone = document.getElementById("<%=txtTelephone.ClientID %>").value;

                if (phone.length > 14 || phone.length < 10) {

                    msg = msg + "Enter Valid Phone Number";
                    // document.getElementById("<%=ErrorMsgDiv.ClientID%>").style.display = "block";
                    document.getElementById("<%=txtTelephone.ClientID%>").style.borderColor = "red";
                    document.getElementById("<%=ErrorMsgDiv.ClientID%>").innerHTML = msg;

                }
                else {

                    document.getElementById("<%=txtTelephone.ClientID%>").style.borderColor = "white";
                }
            }


            var phone1 = document.getElementById("<%=txtTelephone.ClientID %>").value;
        var emailPat = /^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
        var emailid1 = document.getElementById("<%=txtemail.ClientID %>").value;
            var matchArray1 = emailid1.match(emailPat);
        <%-- var selectedValue1 = document.getElementById('<%=DdlState.ClientID%>').value;--%>
            

            <%-- if (document.getElementById("<%=txtName.ClientID%>").value == "Customer Name" || document.getElementById("<%=txtemail.ClientID%>").value == "Customer@mail.com"
                || document.getElementById("<%=txtaddress.ClientID%>").value == "Customer Address" || document.getElementById("<%=txtCity.ClientID%>").value == "Customer City"
                || selectedValue == "-1" || document.getElementById("<%=txtzip.ClientID%>").value == "Customer Zip" || document.getElementById("<%=txtTelephone.ClientID%>").value == "Customer Number") {
                return false;

            }
            else {
                if (phone1.length > 14 || phone1.length < 14 || matchArray1 == null ||  selectedValue1 == "-1") {                   
                    return false;
                }
                else {
                    return true;
                }
            }--%>
        if (phone1.length > 14 || phone1.length < 14 || matchArray1 == null) {
            msg = "";


            if (matchArray1 == null && emailid1 != "Email") {
                msg = msg + "Please Enter Valid Email Address,";

            }
            if (phone1.length > 14 || phone1.length < 14 && phone1 != "Number") {
                document.getElementById("<%=txtTelephone.ClientID%>").style.borderColor = "red";
                    msg = msg + "Please Enter Valid Phone Number";

                }
                if (msg != "") {
                    document.getElementById("<%=ErrorMsgDiv.ClientID%>").style.display = "block";
                    document.getElementById("<%=ErrorMsgDiv.ClientID%>").innerHTML = msg;

                    var seconds = 5;
                    setTimeout(function () {

                        document.getElementById("<%=ErrorMsgDiv.ClientID %>").style.display = "none";

                    }, seconds * 1000);

                }
                else {
                    document.getElementById("<%=ErrorMsgDiv.ClientID%>").style.display = "none";
                }

            }
            else {
                document.getElementById("<%=ErrorMsgDiv.ClientID%>").style.display = "none";
            }
            if (document.getElementById("<%=txtName.ClientID%>").value == "Name" || document.getElementById("<%=txtemail.ClientID%>").value == "Email" || document.getElementById("<%=txtTelephone.ClientID%>").value == "Number") {
            return false;

        }
        else {
            if (phone1.length > 14 || phone1.length < 14 || matchArray1 == null) {
                return false;
            }
            else {

                return true;
            }
        }
    }

        <%--function PlaceOrderConfirmation()
        {
            var hdnfldVariablePlaceOrder = document.getElementById("<%=hdnfldVariablePlaceOrder.ClientID %>");

            if (confirm("Are you sure you want to place order?")) {

                hdnfldVariablePlaceOrder.value = "Yes";
                document.getElementById("<%=btnPlaceOrder.ClientID %>").click();

            } else {

                hdnfldVariablePlaceOrder.value = "No";
            }

        }--%>
    </script>
    <script type="text/javascript">
        function HideLabel() {
            var seconds = 5;
            setTimeout(function () {

                document.getElementById("<%=UserAlreadyExistsDiv.ClientID %>").style.display = "none";
                document.getElementById("<%=StoreClosedDiv.ClientID %>").style.display = "none";
                document.getElementById("<%=StoreInvalidTime.ClientID %>").style.display = "none";
            }, seconds * 1000);

        };

        function validateCustomerZipCode(key) {
            //getting key code of pressed key
            var keycode = (key.which) ? key.which : key.keyCode;
            var phn = document.getElementById('txtMobileNumber');
            //comparing pressed keycodes
            if (!(keycode == 8 || keycode == 46) && (keycode < 48 || keycode > 57)) {
                return false;
            }
        }
    </script>
    <%--<div id="ErrorMsgDiv" class="alert alert-warning" runat="server" style="background-color:#ca3027;color:#ffffff;border-color:#ca3027;">
      <strong>Error!</strong> 
    </div>--%>

    <style type="text/css">
        #ddlHour {
            width: 77% !important;
        }

        #DdlMinute {
            width: 77% !important;
            margin-left: -29px;
        }

        #DdlTime {
            width: 12.5% !important;
            margin-left: -58px;
        }

        @media screen and (max-width:1208px) and (min-width:1170px) {
        }

        @media screen and (max-width:989px) and (min-width:979px) {
            #ddlHour {
                width: 77% !important;
            }

            #DdlMinute {
                width: 77% !important;
                margin-left: -38px;
            }

            #DdlTime {
                width: 12.5% !important;
                margin-left: -73px;
            }
        }

        @media screen and (max-width:978px) and (min-width:800px) {
            #ddlHour {
                width: 77% !important;
            }

            #DdlMinute {
                width: 77% !important;
                margin-left: -43px;
            }

            #DdlTime {
                width: 12.5% !important;
                margin-left: -83px;
            }
        }

        @media screen and (max-width:801px) and (min-width:505px) {
            #ddlHour {
                width: 76% !important;
            }

            #DdlMinute {
                width: 76% !important;
                margin-left: -35px;
            }

            #DdlTime {
                width: 11% !important;
                margin-left: -65px;
            }
        }

        @media screen and (max-width:506px) and (min-width:329px) {
            #ddlHour {
                width: 76% !important;
            }

            #DdlMinute {
                width: 76% !important;
                margin-left: -35px;
            }

            #DdlTime {
                width: 18% !important;
                margin-left: -65px;
            }
        }

        @media screen and (max-width:328px) and (min-width:229px) {
            #ddlHour {
                width: 70% !important;
            }

            #DdlMinute {
                width: 70% !important;
                margin-left: -35px;
            }

            #DdlTime {
                width: 22% !important;
                margin-left: -65px;
            }
        }

        @media only screen and (max-width:1199px) {
            #TopContactDetail {
                width: 133%;
            }
        }

        @media only screen and (max-width:480px) and (min-width:359px) {
            #TopContactDetail {
                width: 100%;
            }
        }

        @media only screen and (max-width:360px) and (min-width:347px) {
            #TopContactDetail {
                width: 105%;
            }
        }

        @media only screen and (max-width:346px) and (min-width:345px) {
            #TopContactDetail {
                width: 106%;
            }
        }

        @media only screen and (max-width:344px) and (min-width:342px) {
            #TopContactDetail {
                width: 107%;
            }
        }

        @media only screen and (max-width:341px) and (min-width:341px) {
            #TopContactDetail {
                width: 108%;
                margin-left: -10px;
            }
        }

        @media only screen and (max-width:340px) and (min-width:339px) {
            #TopContactDetail {
                width: 109%;
                margin-left: -10px;
            }
        }

        @media only screen and (max-width:338px) and (min-width:334px) {
            #TopContactDetail {
                width: 110%;
                margin-left: -16px;
            }
        }

        @media only screen and (max-width:333px) and (min-width:332px) {
            #TopContactDetail {
                width: 112%;
                margin-left: -16px;
            }
        }

        @media only screen and (max-width:331px) and (min-width:330px) {
            #TopContactDetail {
                width: 113%;
                margin-left: -18px;
            }
        }

        @media only screen and (max-width:329px) and (min-width:327px) {
            #TopContactDetail {
                width: 113%;
                margin-left: -20px;
            }
        }

        @media only screen and (max-width:326px) {
            #TopContactDetail {
                width: 114%;
                margin-left: -20px;
            }
        }

        @media only screen and (max-width:325px) {
            #TopContactDetail {
                width: 115%;
                margin-left: -20px;
            }
        }

        @media only screen and (max-width:324px) {
            #TopContactDetail {
                width: 116%;
                margin-left: -20px;
            }
        }

        @media only screen and (max-width:323px) {
            #TopContactDetail {
                width: 117%;
                margin-left: -26px;
            }
        }

        #CateringContact {
            font-size: 15px;
        }

        @media only screen and (max-width:480px) {
            #CateringContact {
                font-size: 14px;
            }

            #ContctDiv {
                margin-left: -14px;
            }
        }

        @media only screen and (max-width:640px) {
            .login-div {
                padding: 0px;
                margin: -4px;
            }

            .privacy-section ul {
                text-align: left;
                float: left;
                margin-left: -8px;
            }
        }
    </style>
    <div id="UserAlreadyExistsDiv" class="alert alert-warning" runat="server" style="background-color: #ca3027; color: #ffffff; border-color: #ca3027;">
        <strong>Error!</strong>Minimum Purchase Required is <%=MinimumPurchase %>
    </div>
    <div id="StoreClosedDiv" class="alert alert-warning" runat="server" style="background-color: #ca3027; color: #ffffff; border-color: #ca3027;">
        <strong>Error!</strong>Store is now closed.It is only open between <%=StoreStartTime %> to <%=StoreEndTime %> .so please place order for tommorow.
    </div>
    <div id="StoreInvalidTime" class="alert alert-warning" runat="server" style="background-color: #ca3027; color: #ffffff; border-color: #ca3027;">
        <strong></strong>Order can be placed only for future.
    </div>
</head>
<body>
    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="hdnfldVariable" runat="server" />
        <asp:HiddenField ID="hdnfldVariablePlaceOrder" runat="server" />
        <div class="body-wrapper">
            <div class="container">
                <div class="inner-wrapper">
                    <!------------------------header part starts------------------------------>
                    <div class="top-bar">
                        <div class="col-md-4">
                            <div class="top-left">
                                <div class="logo-img">
                                    <a href="Index.aspx">
                                        <img src="images/logo_text.png" class="img-responsive"></a>
                                </div>
                                <div class="contact-detail-top" id="TopContactDetail">
                                    <span class="phone">
                                        <asp:Label ID="lblPhone" runat="server"></asp:Label></span> <span class="fax">
                                            <asp:Label ID="lblFax" runat="server"></asp:Label></span>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="top-right">
                                <ul class="social-icons">
                                    <li><a id="afacebbok" runat="server" href="" target="_blank"><span class="facebook"></span></a></li>
                                    <li><a id="agoogleplus" runat="server" href="" target="_blank"><span class="google-plus"></span></a></li>
                                    <li><a id="alinkedin" runat="server" href="" target="_blank"><span class="linkedin"></span></a></li>
                                    <li><a id="ayoutube" runat="server" href="" target="_blank"><span class="youtube"></span></a></li>
                                </ul>
                                <ul class="login-div">
                                    <li class="dropdown" style="margin-left: 3px;">
                                        <div id="EmailDiv" runat="server" style="display: none">
                                            <a id="AccountAnchor" class="dropdown-toggle" data-toggle="dropdown" href="#"><span id="SpanEmail" runat="server">My Account</span></a>
                                            <ul class="dropdown-menu">
                                                <li runat="server" id="li1"><a onclick="window.open('Admin/DashBoard.aspx','mywindow','width=1100,height=500 resizable scrollbars menubar=yes');">DashBoard</a></li>
                                                <li runat="server" id="liEditProfile"><a href="EditProfile.aspx">Edit Profile</a></li>
                                                <li runat="server" id="liOrderHistory" visible="false"><a href="CustomerOrderDetail.aspx">Order History</a></li>
                                                <li runat="server" id="liResetPassword"><a href="ResetPassword.aspx">Reset Password</a></li>

                                            </ul>
                                        </div>
                                    </li>
                                    <li class="LiLogin">
                                        <div id="SignInDiv" runat="server"><a href="Login.aspx?PageName=PlaceOrder.aspx"><span id="SpanSignIn" runat="server">sign in</span></a></div>
                                    </li>
                                    <li class="liReg">
                                        <div id="AccountDiv" runat="server"><a href="UserRegistration.aspx"><span class="register" id="CreateAccountDiv" runat="server">create an account</span></a></div>
                                    </li>
                                    <li>
                                        <div id="LogoutDiv" runat="server" style="display: none">
                                            <asp:LinkButton runat="server" ID="Logout" OnClick="Logout_Click"><span id="SpanLogout" runat="server">Log Out</span></asp:LinkButton>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <nav class="navbar">
                        <div class="container-fluid">
                            <div class="navbar-header">
                                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#menu"><span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></button>
                                <div class="collapse navbar-collapse" id="menu">
                                    <ul class="nav navbar-nav">
                                        <li class="order" id="liorderOnline"><a href="OrderOnline.aspx">Order Online</a></li>
                                        <li><a href="Index.aspx">Home</a></li>
                                        <li>
                                            <asp:LinkButton runat="server" ID="lnkMenu" OnClick="lnkMenu_Click" OnClientClick="return true">Menu</asp:LinkButton></li>
                                        <li><a href="Offers.aspx">Offers</a></li>
                                    </ul>
                                </div>
                                <div class="navbar-brand">
                                    <img src="images/logo.png" class="img-responsive">
                                </div>
                            </div>
                        </div>
                    </nav>
                    <!------------------------header part ends------------------------------>
                    <!------------------------main-part starts------------------------------>
                    <div class="main">
                        <div class="inner-div customer-info">
                            <div class="col-md-6 ">
                                <!-----------------------Category-details starts------------------------------>
                                <div class="user-login">
                                    <div class="cart_header"><span class="title">My Info</span></div>
                                    <div id="ErrorMsgDiv" class="alert alert-warning" runat="server" style="color: white; border-radius: 0px; background-color: #ca3027; border-color: white;">
                                        <strong>Error!</strong>
                                    </div>
                                    <h4 id="h4LoginLabel" runat="server"><a href="Login.aspx?PageName=PlaceOrder.aspx">Login</a> to your Profile or continue below as a Guest</h4>
                                    <div runat="server" style="overflow: hidden; padding: 1.85em 0px;">

                                        <div class="form-group">
                                            <%-- <input type="checkbox" style="margin-left: 15px;">  Pick Order--%>
                                            <asp:CheckBox Text="" runat="server" ID="chkPickOrder" Style="margin-left: 15px;" AutoPostBack="true" OnCheckedChanged="chkPickOrder_CheckedChanged" />

                                            Pickup Order
                                          
                                        </div>
                                        <div class="form-group">
                                            <label>Name:</label>
                                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" TabIndex="1" onfocus="(this.value=='Name')? this.value='':this.value;" onblur="(this.value=='')? this.value='Name':this.value;" Height="38px">Name</asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Email:</label>
                                            <asp:TextBox ID="txtemail" runat="server" CssClass="form-control" TabIndex="1" onfocus="(this.value=='Email')? this.value='':this.value;" onblur="(this.value=='')? this.value='Email':this.value;" Height="38px">Email</asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Telephone:</label>
                                            <asp:TextBox ID="txtTelephone" runat="server" onkeyup="formatTxtPhoneNumber();" CssClass="form-control" TabIndex="1" onfocus="(this.value=='Number')? this.value='':this.value;" onblur="(this.value=='')? this.value='Number':this.value;" Height="38px">Number</asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Address:</label>
                                            <asp:TextBox ID="txtaddress" runat="server" CssClass="form-control" TabIndex="1" onfocus="(this.value=='Address')? this.value='':this.value;" onblur="(this.value=='')? this.value='Address':this.value;" Height="38px">Address</asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>City:</label>
                                            <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" TabIndex="1" onfocus="(this.value=='City')? this.value='':this.value;" onblur="(this.value=='')? this.value='City':this.value;" Height="38px">City</asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>State:</label>
                                            <asp:DropDownList ID="DdlState" runat="server" class="form-control" AutoPostBack="False" AppendDataBoundItems="True" CssClass="form-control" TabIndex="1" Height="40px">
                                                <asp:ListItem Value="-1">Select State</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label>Zip:</label>
                                            <asp:TextBox ID="txtzip" runat="server" MaxLength="7" CssClass="form-control" TabIndex="1" onfocus="(this.value=='Zip')? this.value='':this.value;" onblur="(this.value=='')? this.value='Zip':this.value;" onkeypress="return validateCustomerZipCode(event)" Height="38px">Zip</asp:TextBox>
                                        </div>

                                        <div class="form-group">
                                            <label>Delivery Instructions:</label>
                                            <asp:TextBox ID="txtDeliveryInstructions" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" TabIndex="1" onfocus="(this.value=='Delivery Instructions')? this.value='':this.value;" onblur="(this.value=='')? this.value='Delivery Instructions':this.value;">Delivery Instructions</asp:TextBox>
                                        </div>

                                        <div class="form-group">
                                            <label>Order date:</label>
                                            <%-- <input type="text" value="Order date" class="form-control">--%>
                                            <asp:TextBox ID="datepicker" runat="server" CssClass="form-control">Order Wish Date</asp:TextBox>
                                        </div>

                                        <div class="form-group">
                                            <label>Order Time:</label>
                                            <div class="span_1_of_2">
                                                <asp:DropDownList ID="ddlHour" runat="server" AutoPostBack="False" CssClass="form-control" Style="height: 40px;">
                                                    <asp:ListItem>Select Hour</asp:ListItem>
                                                    <asp:ListItem>01</asp:ListItem>
                                                    <asp:ListItem>02</asp:ListItem>
                                                    <asp:ListItem>03</asp:ListItem>
                                                    <asp:ListItem>04</asp:ListItem>
                                                    <asp:ListItem>05</asp:ListItem>
                                                    <asp:ListItem>06</asp:ListItem>
                                                    <asp:ListItem>07</asp:ListItem>
                                                    <asp:ListItem>08</asp:ListItem>
                                                    <asp:ListItem>09</asp:ListItem>
                                                    <asp:ListItem>10</asp:ListItem>
                                                    <asp:ListItem>11</asp:ListItem>
                                                    <asp:ListItem>12</asp:ListItem>

                                                </asp:DropDownList>

                                            </div>

                                            <div class="span_1_of_2">
                                                <asp:DropDownList ID="DdlMinute" runat="server" AutoPostBack="False" CssClass="form-control" Style="height: 40px;">
                                                    <asp:ListItem>Select Minute</asp:ListItem>
                                                    <asp:ListItem>00</asp:ListItem>
                                                    <asp:ListItem>05</asp:ListItem>
                                                    <asp:ListItem>10</asp:ListItem>
                                                    <asp:ListItem>15</asp:ListItem>
                                                    <asp:ListItem>20</asp:ListItem>
                                                    <asp:ListItem>25</asp:ListItem>
                                                    <asp:ListItem>30</asp:ListItem>
                                                    <asp:ListItem>35</asp:ListItem>
                                                    <asp:ListItem>40</asp:ListItem>
                                                    <asp:ListItem>45</asp:ListItem>
                                                    <asp:ListItem>50</asp:ListItem>
                                                    <asp:ListItem>55</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <asp:DropDownList ID="DdlTime" runat="server" AutoPostBack="False" CssClass="form-control" Style="height: 40px;">
                                                <asp:ListItem>AM</asp:ListItem>
                                                <asp:ListItem>PM</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <%--<div class="form-group">
                <label></label>
                <button type="submit" class="submit-btn" value="submit">Submit</button>
              </div>--%>
                                    </div>
                                </div>
                                <!-----------------------Category-details ends------------------------------>
                            </div>
                            <div class="col-md-6 place-order">
                                <div class="my_cart" id="cart">
                                    <div class="cart_header"><span class="title">My Cart </span></div>
                                    <div class="product_detail">
                                        <div class="list-group">
                                            <asp:Label ID="lblOpenOrderNoSource" runat="server" Visible="false" CssClass="nodataFound" Text="No Item Found!!!" Style="color: red;"></asp:Label>
                                            <%--                                            <asp:UpdatePanel runat="server" ID="UprecentOrder">
                                                <ContentTemplate>
                                                    <asp:Label ID="lblOpenOrderNoSource" runat="server" Visible="false" CssClass="nodataFound" Text="No Recent Order Found!!!"></asp:Label>
                                            --%>
                                            <asp:Repeater ID="rptOrderDetail" runat="server" OnItemCommand="rptOrderDetail_ItemCommand" OnItemDataBound="rptOrderDetail_ItemDataBound">

                                                <HeaderTemplate>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <div class="alert alert-default">
                                                        <asp:LinkButton CssClass="close" runat="server" OnClientClick="Confirm()" CommandArgument='<%# Eval("CartId") %>' Text="x" CommandName="DeleteItem" Style="font-size: 18px;"></asp:LinkButton>
                                                        <%-- <a href="#" class="close" data-dismiss="alert" aria-label="close" >&times;</a>--%>
                                                        <div class="product_desc" id="1123">
                                                            <div class="row row1">
                                                                <div style="display: none">
                                                                    <asp:Label ID="lblCartId" runat="server" Text='<%# Eval("CartId") %>'></asp:Label>
                                                                    <asp:Label ID="lblProductdetailId" runat="server" Text='<%# Eval("ProductdetailId") %>'></asp:Label>
                                                                    <asp:Label ID="lblPropertyId" runat="server" Text='<%# Eval("PropertiesId") %>'></asp:Label>
                                                                    <asp:Label ID="lblProductIngredientFactId" runat="server" Text='<%# Eval("IngredientFactId") %>'></asp:Label>
                                                                    <asp:Label ID="lblExtraIngredientId" runat="server" Text='<%# Eval("ExtraIngredientId") %>'></asp:Label>
                                                                    <asp:Label ID="lblSizeId" runat="server" Text='<%# Eval("SizeId") %>'></asp:Label>
                                                                    <asp:Label ID="lblOneQuantityPrice" runat="server" Text='<%# Eval("OneQuantityPrice") %>'></asp:Label>

                                                                </div>

                                                                <div class="col-md-4 col-sm-4">
                                                                    <span class="selected_prdct">
                                                                        <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label></span>
                                                                </div>
                                                                <div class="col-ms-2 col-sm-2">
                                                                    <span id="size">
                                                                        <asp:Label ID="lblSizeName" runat="server" Text='<%# "["+ Eval("SizeName")+"]" %>'></asp:Label></span>
                                                                </div>
                                                                <div class="col-md-2 col-sm-2">
                                                                    <span class="price_prdct">
                                                                        <asp:Label ID="lblPrice" runat="server" Text='<%#"$"+ Eval("Price") %>'></asp:Label></span>
                                                                </div>
                                                                <div class="col-md-2 col-sm-2">
                                                                    <span class="product_quantity">
                                                                        <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Eval("Quantity") %>' OnTextChanged="txtPrice_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                        <%-- <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Eval("Quantity") %>' onkeypress="javascript:keyPressed()" AutoPostBack="false"></asp:TextBox>
                                                                        --%>  <%--<input type="number" value="1" maxlength="5">--%>
                                                                    </span>
                                                                </div>
                                                            </div>
                                                            <div class="row row2">
                                                                <div class="col-md-10 col-sm-10">
                                                                    <div id="ing_spec">
                                                                        <asp:Label ID="lblExtraIngredientName" runat="server" Text='<%# Eval("ExtraIngredient") %>'></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-2 col-sm-2">
                                                                    <span id="ing_total_price" class="red_font">
                                                                        <asp:Label ID="Label1" runat="server" Text='<%#"$"+Eval("ExtraIngredientPrice") %>'></asp:Label></span>
                                                                </div>
                                                                <div class="col-md-10 col-sm-10">
                                                                    <asp:Label ID="lblComment" runat="server" Text='<%#"Comment:"+ Eval("Comment") %>'></asp:Label>
                                                                </div>
                                                                <%--   <div>
                                                                   
                                                                    <input type="text" style="width: 80%; background-color: lightyellow" onclick="" value="Enter Comment"/>
                                                                </div>--%>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>

                                            </asp:Repeater>

                                            <%--   </ContentTemplate>
                                               </asp:UpdatePanel>--%>

                                            <div class="product_charges" id="PriceDiv" runat="server">
                                                <div class="product_price"><span style="text-align: right;">Total:</span><span id="price" class="tax_value"><asp:Label runat="server" ID="LblTotal"></asp:Label></span></div>
                                                <div class="product_price"><span style="text-align: right;">Discount:</span><span id="Discount" class="tax_value"><asp:Label runat="server" ID="lblDiscount"></asp:Label></span></div>
                                                <div class="sales_tax"><span>Sales Tax:</span><span id="s-tax" class="tax_value"><asp:Label runat="server" ID="lblSalesPrice"></asp:Label></span></div>
                                                <div class="delivery_tax"><span>Delivery Charges:</span><span id="d-tax" class="tax_value"><asp:Label runat="server" ID="lblDeliveryCharges"></asp:Label></span></div>
                                                <div class="total_price"><span><strong>Total Price:</strong></span><span id="t-price" class="tax_value"><asp:Label runat="server" ID="LblTotalPrice"></asp:Label></span></div>
                                                <asp:Button ID="btnPlaceOrder" Text="Continue" CssClass="place_order_btn pull-right" OnClick="btnPlaceOrder_Click" OnClientClick="return validate()" runat="server" />
                                                <div class="coupon_div" id="OfferDiv" runat="server">
                                                    <h5>Apply Coupon</h5>
                                                    <div class="form-group">
                                                        <asp:TextBox runat="server" ID="txtOfferCode"></asp:TextBox>
                                                        <%-- <button type="submit" value="apply coupon" class="apply_btn">Apply coupon</button>--%>
                                                        <asp:Button ID="btnApplyCoupn" Text="Apply Coupon" CssClass="apply_btn" OnClick="btnApplyCoupn_Click" Style="text-transform: capitalize;" runat="server" />
                                                        <%-- <asp:Button ID="btnTextChanged" style="display:none"  OnClick="btnTextChanged_Click" runat="server"/>--%>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>




                            </div>
                        </div>
                    </div>
                    <%-- </div>--%>
                    <%-- </div>--%>
                    <!------------------------footer part starts------------------------------>
                    <footer>
                        <div class="footer">
                            <!------------------------footer-bottom starts------------------------------>
                            <div class="footer-bottom" id="ContctDiv">
                                <span class="contact">
                                    <asp:Label ID="lblAddress" runat="server"></asp:Label></span>
                                <span class="contact-phone" id="CateringContact">For Catering, Please call 630-766-2221</span>
                            </div>
                            <div class="bottom-section">
                                <div class="copyright-section"><span>Copyright © 2016 Tomatos Pizzeria </div>
                                <div class="message-section">
                                    <p>
                                        We deliver to Bensenville, Wood Dale and Neighboring Areas.
                Minimum Delivery Purchase:&nbsp;<asp:Label ID="lblminimumDeliveryPurchase" runat="server"></asp:Label>
                                        Delivery Charge:&nbsp;<asp:Label ID="lblDeliveryCharge" runat="server"></asp:Label>
                                    </p>
                                </div>
                                <div class="privacy-section">
                                    <ul>
                                        <li><a href="PrivacyPolicies.aspx">Privacy Policy</a></li>
                                        <li><a href="TermsAndConditions.aspx">Terms & Conditions</a></li>
                                        <li><a href="ContactUs.aspx">Contact Us</a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </footer>
                    <!------------------------footer part ends------------------------------>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
<script>$(document).ready(function (c) {
    $('.product_desc .close').on('click', function (c) {
        //$('.list-group-item1').fadeOut('slow', function (c) {
        //    $('.list-group-item1').remove();
        //});


    });
});
</script>

