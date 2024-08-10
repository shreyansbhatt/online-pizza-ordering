<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserRegistration.aspx.cs" Inherits="UserRegistration" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <link runat="server" rel="shortcut icon" href="/images/logo.ico" type="image/x-icon" />
    <link runat="server" rel="icon" href="/images/logo.ico" type="image/ico" />
    <title>User Regestration</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="X-UA-Compatible" content="IE=9; IE=8; IE=7; IE=Edge,chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8, IE=9, chrome=1" />
    <!-- Latest compiled and minified JavaScript -->
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js"></script>
    <script src="js/jquery-1.11.1.min.js"></script>
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
    <link href="css/style.css" rel='stylesheet' type='text/css' />
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css">
    <style type="text/css">
        .registration-page {
            background: rgba(240, 240, 240, 0.22);
            width: 100%;
            padding: 1em 2em;
            margin-top: 1em;
            overflow: hidden;
        }

        .submit-btn:hover {
            border: none;
            border-radius: 0px;
            background-color: #ca3027 !important;
        }


        .nav > li > a:focus, .nav > li > a:hover {
            text-decoration: none;
            background-color: #ca3027 !important;
        }

        .register-div .form-group input[ type="text"], .register-div .form-group input[ type="email"], .register-div .form-group input[ type="password"], .register-div .form-group textarea, .register-div .password-section {
            /*width: 70%;*/
            float: left;
            text-transform: none;
            color: black;
        }

        #txtPassword::-webkit-input-placeholder,
        #txtConfirmPassword::-webkit-input-placeholder {
            color: black;
        }

        #txtPassword:-moz-placeholder,
        #txtConfirmPassword:-moz-placeholder {
            color: black;
        }

        #txtPassword::-moz-placeholder,
        #txtConfirmPassword::-moz-placeholder {
            color: black;
        }

        #txtPassword:-ms-input-placeholder,
        #txtConfirmPassword:-ms-input-placeholder {
            color: black;
        }

        /*.register-div .span_1_of_2 input[type="password"] {
            width: 89%;
            color: #888888;
            padding-left: 12px;
            
        }*/

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
                margin-left: -40px;
            }

            .liReg {
                margin-left: -15px;
            }
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

        @media only screen and (max-width:405px) {
            #liorderOnline {
                height: 60px;
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
                margin: -2px;
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
    <script type="text/javascript">

        document.getElementById("<%=ErrorMsgDiv.ClientID%>").style.display = "none";
        function SetUniqueRadioButton(nameregex, current) {

            re = new RegExp(nameregex); for (i = 0; i < document.forms[0].elements.length; i++) {

                elm = document.forms[0].elements[i]

                if (elm.type == 'radio') {

                    if (re.test(elm.name)) {

                        elm.checked = false;
                    }
                }
            }
            current.checked = true;
        }

        function HideLabel() {
            var seconds = 5;
            setTimeout(function () {

                document.getElementById("<%=SuccessMessageDiv.ClientID %>").style.display = "none";
                document.getElementById("<%=UserAlreadyExistsDiv.ClientID %>").style.display = "none";

                document.getElementById("<%=txtEmailAddress.ClientID%>").value = "Email Address";
            }, seconds * 1000);

        };


        function validate() {
            var msg = "";
            if (document.getElementById("<%=txtFirstName.ClientID%>").value == "First Name") {
                document.getElementById("<%=txtFirstName.ClientID%>").style.borderColor = "red";

                // return false;
            }
            else {
                document.getElementById("<%=txtFirstName.ClientID%>").style.borderColor = "white";
            }

            if (document.getElementById("<%=txtLastName.ClientID%>").value == "Last Name") {
                document.getElementById("<%=txtLastName.ClientID%>").style.borderColor = "red";

                // return false;
            }
            else {
                document.getElementById("<%=txtLastName.ClientID%>").style.borderColor = "white";
            }

            if (document.getElementById("<%=txtPhone.ClientID%>").value == "Phone") {
                document.getElementById("<%=txtPhone.ClientID%>").style.borderColor = "red";
                // return false;
            }
            else {


                var phone = document.getElementById("<%=txtPhone.ClientID %>").value;

                if (phone.length > 14 || phone.length < 14) {
                    //  alert("Enter Valid Phone Number");
                    msg = "Enter Valid Phone Number,";
                    document.getElementById("<%=ErrorMsgDiv.ClientID%>").style.display = "block";
                    //  document.getElementById("<%=ErrorMsgDiv.ClientID%>").innerHTML = "<strong>Error!</strong> Enter Valid Phone Number.";
                    document.getElementById("<%=txtPhone.ClientID%>").style.borderColor = "red";
                    document.getElementById("<%=ErrorMsgDiv.ClientID%>").innerHTML = msg;
                    //  return false;
                }
                else {

                    document.getElementById("<%=txtPhone.ClientID%>").style.borderColor = "white";
                }
            }


            if (document.getElementById("<%=txtEmailAddress.ClientID%>").value == "Email Address") {
                document.getElementById("<%=txtEmailAddress.ClientID%>").style.borderColor = "red";

                //  return false;
            }
            else {

                var emailPat = /^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
                var emailid = document.getElementById("<%=txtEmailAddress.ClientID %>").value;
                var matchArray = emailid.match(emailPat);
                if (matchArray == null) {
                    //  alert("Enter Valid Email Address");
                    msg = msg + "Please Enter Valid Email Address,";
                    document.getElementById("<%=txtEmailAddress.ClientID%>").style.borderColor = "red";
                    document.getElementById("<%=ErrorMsgDiv.ClientID%>").style.display = "block";
                    // document.getElementById("<%=ErrorMsgDiv.ClientID%>").innerHTML = "<strong>Error!</strong> Enter Valid Email Address.";
                    document.getElementById("<%=ErrorMsgDiv.ClientID%>").innerHTML = msg;
                    // return false;
                }
                else {
                    document.getElementById("<%=txtEmailAddress.ClientID%>").style.borderColor = "white";
                }
            }
            if (document.getElementById("<%=txtPassword.ClientID%>").value == "") {
                document.getElementById("<%=txtPassword.ClientID%>").style.borderColor = "red";
                // return false;
            }
            else {
                document.getElementById("<%=txtPassword.ClientID%>").style.borderColor = "white";
            }
            if (document.getElementById("<%=txtConfirmPassword.ClientID%>").value == "") {
                document.getElementById("<%=txtConfirmPassword.ClientID%>").style.borderColor = "red";
                // return false;
            }
            else {
                document.getElementById("<%=txtConfirmPassword.ClientID%>").style.borderColor = "white";
            }

            if (document.getElementById("<%=txtPassword.ClientID%>").value != "" && document.getElementById("<%=txtConfirmPassword.ClientID%>").value != "") {
                if (document.getElementById("<%=txtPassword.ClientID%>").value != document.getElementById("<%=txtConfirmPassword.ClientID%>").value) {
                    document.getElementById("<%=txtPassword.ClientID%>").style.borderColor = "red";
                    document.getElementById("<%=txtConfirmPassword.ClientID%>").style.borderColor = "red";
                    //alert("Password and Confirm Password do not match");
                    document.getElementById("<%=ErrorMsgDiv.ClientID%>").style.display = "block";
                    // document.getElementById("<%=ErrorMsgDiv.ClientID%>").innerHTML = "<strong>Error!</strong> Password and Confirm Password do not match.";
                    msg = msg + "Password and Confirm Password do not match,";
                    document.getElementById("<%=ErrorMsgDiv.ClientID%>").innerHTML = msg;
                    // return false;
                }
            }


            if (document.getElementById("<%=txtAddress.ClientID%>").value == "Address") {
                document.getElementById("<%=txtAddress.ClientID%>").style.borderColor = "red";
                // return false;
            }
            else {
                document.getElementById("<%=txtAddress.ClientID%>").style.borderColor = "white";
            }
            if (document.getElementById("<%=txtCity.ClientID%>").value == "City") {
                document.getElementById("<%=txtCity.ClientID%>").style.borderColor = "red";
                //return false;
            }
            else {
                document.getElementById("<%=txtCity.ClientID%>").style.borderColor = "white";
            }


            var selectedValue = document.getElementById('<%=DdlState.ClientID%>').value;
            if (selectedValue == "-1") {
                // alert("Please Select State");
                document.getElementById("<%=ErrorMsgDiv.ClientID%>").style.display = "block";
                // document.getElementById("<%=ErrorMsgDiv.ClientID%>").innerHTML = "<strong>Error!</strong> Please Select State.";
                msg = msg + "Please Select State";
                document.getElementById("<%=DdlState.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=ErrorMsgDiv.ClientID%>").innerHTML = msg;
                //return false;
            }
            else {
                document.getElementById("<%=DdlState.ClientID%>").style.borderColor = "white";
            }

            if (document.getElementById("<%=txtPincode.ClientID%>").value == "Zip Code") {
                document.getElementById("<%=txtPincode.ClientID%>").style.borderColor = "red";
                // return false;
            }
            else {
                document.getElementById("<%=txtPincode.ClientID%>").style.borderColor = "white";
            }

            var phone1 = document.getElementById("<%=txtPhone.ClientID %>").value;
            var emailPat = /^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
            var emailid1 = document.getElementById("<%=txtEmailAddress.ClientID %>").value;
            var matchArray1 = emailid1.match(emailPat);
            var selectedValue1 = document.getElementById('<%=DdlState.ClientID%>').value;



            if (document.getElementById("<%=txtFirstName.ClientID%>").value == "First Name" || document.getElementById("<%=txtLastName.ClientID%>").value == "Last Name" || document.getElementById("<%=txtPhone.ClientID%>").value == "Phone" || document.getElementById("<%=txtEmailAddress.ClientID%>").value == "Email Address"
                || document.getElementById("<%=txtPassword.ClientID%>").value == "" || document.getElementById("<%=txtConfirmPassword.ClientID%>").value == "" || document.getElementById("<%=txtAddress.ClientID%>").value == "Address" || document.getElementById("<%=txtCity.ClientID%>").value == "City" || selectedValue == "-1" || document.getElementById("<%=txtPincode.ClientID%>").value == "Zip Code") {
                return false;
            }
            else {
                if (phone1.length > 14 || phone1.length < 14 || matchArray1 == null || document.getElementById("<%=txtPassword.ClientID%>").value != document.getElementById("<%=txtConfirmPassword.ClientID%>").value || selectedValue1 == "-1") {
                  
                    <%--if (phone1.length > 14 || phone1.length < 14) {
                        msg = "Enter Valid Phone Number";
                    }
                    if (matchArray1 == null) {
                        msg = msg + "," + "Enter Valid Email Address";
                    }
                    if (document.getElementById("<%=txtPassword.ClientID%>").value != document.getElementById("<%=txtConfirmPassword.ClientID%>").value) {
                        msg = msg + "," + "Password and Confirm Password do not match";
                    }
                    if (selectedValue1 == "-1") {
                        msg = msg + "," + "Please Select State";
                    }
         document.getElementById("<%=ErrorMsgDiv.ClientID%>").style.display = "block";
                    document.getElementById("<%=ErrorMsgDiv.ClientID%>").innerHTML = msg;--%>
                    return false;
                }
                else {
                    return true;
                }
                // return true;
            }


        }

        function IsNumeric(e) {
            var specialKeys = new Array();
            specialKeys.push(8);
            specialKeys.push(9);//Backspace
            var keyCode = e.which ? e.which : e.keyCode
            var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
            document.getElementById("error").style.display = ret ? "none" : "inline";
            return ret;
        }
        function formatTxtPhoneNumber() {


            var curval = document.getElementById("<%=txtPhone.ClientID%>").value;
            var curchr = curval.length;

            if (curchr == 3) {

                curval = ("(" + curval + ")" + " ");
                document.getElementById("<%=txtPhone.ClientID%>").value = curval;
            } else if (curchr == 9) {

                curval = curval + "-";
                document.getElementById("<%=txtPhone.ClientID%>").value = curval;
            }

    }
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

    <div id="SuccessMessageDiv" class="alert alert-success" runat="server">
        <strong>Success!</strong> You are successfully registered.
        
    </div>

    <div id="UserAlreadyExistsDiv" class="alert alert-warning" runat="server" style="background-color: #ca3027; color: #ffffff; border-color: #ca3027;">
        <strong>Error!</strong>User Already Exists.
    
    </div>
    <div id="ErrorMsgDiv" class="alert alert-warning" runat="server" style="background-color: #ca3027; color: #ffffff; border-color: #ca3027;">
        <strong>Error!</strong>
    </div>
</head>
<body>
    <form runat="server">
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
                                                <li runat="server" id="liOrderHistory"><a href="CustomerOrderDetail.aspx">Order History</a></li>
                                                <li runat="server" id="liResetPassword"><a href="ResetPassword.aspx">Reset Password</a></li>

                                            </ul>
                                        </div>
                                    </li>
                                    <li class="LiLogin">
                                        <div id="SignInDiv" runat="server"><a href="Login.aspx"><span id="SpanSignIn" runat="server">sign in</span></a></div>
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
                    <div class="main">
                        <!------------------------main-part starts------------------------------>
                        <div class="registration-page">
                            <h3>Create an Account</h3>
                            <div class="register-div">
                                <div id="regiter-form">
                                    <div class="form-group">
                                        <label>First Name</label>
                                        <%--<input type="text" value="enter your first name" required="required" class="form-control" onFocus="this.value=''" onBlur="(this.value=='')? this.value='enter your first name':this.value;">--%>
                                        <asp:TextBox ID="txtFirstName" runat="server" onfocus="(this.value=='First Name')? this.value='':this.value;" onblur="(this.value=='')? this.value='First Name':this.value;" CssClass="form-control" TabIndex="1">First Name</asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>Last Name</label>
                                        <%--<input type="text" value="enter your last name" required="required" class="form-control" onFocus="this.value=''" onBlur="(this.value=='')? this.value='enter your last name':this.value;">--%>
                                        <asp:TextBox ID="txtLastName" runat="server" onfocus="(this.value=='Last Name')? this.value='':this.value;" onblur="(this.value=='')? this.value='Last Name':this.value;" CssClass="form-control" TabIndex="2">Last Name</asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>Gender</label>
                                        <%--<input type="radio" name="radio" checked="">--%>

                                        <asp:RadioButton ID="rdbMale" runat="server" GroupName="cmsRadio" TabIndex="3" />
                                        <span>Male </span>
                                        <%-- <input type="radio" name="radio" class="radio-right">--%>

                                        <asp:RadioButton ID="rdbfemale" runat="server" GroupName="cmsRadio" TabIndex="4" />
                                        <span>Female </span>
                                    </div>
                                    <div class="form-group">
                                        <label>Phone</label>
                                        <%--<input type="email" value="enter your contact No" required="required" class="form-control" onFocus="this.value=''" onBlur="(this.value=='')? this.value='enter your contact No':this.value;">--%>
                                        <asp:TextBox ID="txtPhone" runat="server" onfocus="(this.value=='Phone')? this.value='':this.value;" onblur="(this.value=='')? this.value='Phone':this.value;" onkeyup="formatTxtPhoneNumber();" ClientIDMode="Static" onkeypress="return IsNumeric(event);" CssClass="form-control" TabIndex="5">Phone</asp:TextBox>
                                        <span id="error" style="color: Red; display: none; margin-left: 35px;">*Input digits (0 - 9)</span>
                                    </div>
                                    <div class="form-group">
                                        <label>Email</label>
                                        <%--<input type="email" value="enter your email" required="required" class="form-control" onFocus="this.value=''" onBlur="(this.value=='')? this.value='enter your email':this.value;">--%>
                                        <asp:TextBox ID="txtEmailAddress" runat="server" onfocus="(this.value=='Email Address')? this.value='':this.value;" onblur="(this.value=='')? this.value='Email Address':this.value;" CssClass="form-control" TabIndex="6">Email Address</asp:TextBox>
                                    </div>
                                    <%--<div class="form-group">
                                        <label style="margin-top: 25px;">Create Password</label>
                                        <div class="span_1_of_2">
                                            <span>Type Password</span>
                                            <asp:TextBox ID="txtPassword" style="color:black;" runat="server" placeholder="Enter Password" onfocus="this.placeholder=''" onblur="this.placeholder='Enter Password'" TextMode="Password" CssClass="form-control" TabIndex="7"></asp:TextBox>
                                        </div>
                                        <div class="span_1_of_2">
                                            <span >confirm password</span>
                                           
                                            <asp:TextBox ID="txtConfirmPassword" style="color:black;" runat="server" placeholder="Enter Password" onfocus="this.placeholder=''" onblur="this.placeholder='Enter Password'" TextMode="Password" CssClass="form-control" TabIndex="8"></asp:TextBox>
                                        </div>
                                    </div>--%>
                                    <div class="form-group">
                                        <label>Password</label>
                                        <div class="span_1_of_2">

                                            <asp:TextBox ID="txtPassword" Style="color: black;" runat="server" placeholder="Enter Password" onfocus="this.placeholder=''" onblur="this.placeholder='Enter Password'" TextMode="Password" CssClass="form-control" TabIndex="7"></asp:TextBox>
                                        </div>
                                        <div class="span_1_of_2">

                                            <asp:TextBox ID="txtConfirmPassword" Style="color: black;" runat="server" placeholder="Confirm Password" onfocus="this.placeholder=''" onblur="this.placeholder='Confirm Password'" TextMode="Password" CssClass="form-control" TabIndex="8"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label>Address</label>
                                        <%--<textarea cols="8" rows="2"></textarea>--%>
                                        <asp:TextBox ID="txtAddress" runat="server" onfocus="(this.value=='Address')? this.value='':this.value;" onblur="(this.value=='')? this.value='Address':this.value;" CssClass="form-control" TextMode="MultiLine" TabIndex="9">Address</asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>City</label>
                                        <div class="span_1_of_2">
                                            <asp:TextBox ID="txtCity" runat="server" Style="color: black;" onfocus="(this.value=='City')? this.value='':this.value;" onblur="(this.value=='')? this.value='City':this.value;" CssClass="form-control" TabIndex="10">City</asp:TextBox>

                                        </div>
                                        <div class="span_1_of_2">
                                            <label>State</label>

                                            <asp:DropDownList Style="color: black;" ID="DdlState" runat="server" AutoPostBack="False" AppendDataBoundItems="True" CssClass="form-control" TabIndex="11">
                                                <asp:ListItem Value="-1">Select State</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label>Zip Code</label>

                                        <asp:TextBox ID="txtPincode" runat="server" Style="color: black;" onfocus="(this.value=='Zip Code')? this.value='':this.value;" onblur="(this.value=='')? this.value='Zip Code':this.value;" onkeypress="return validateCustomerZipCode(event)" MaxLength="6" CssClass="form-control" TabIndex="10">Zip Code</asp:TextBox>

                                    </div>
                                    <div class="form-group">
                                        <label></label>
                                        <%--<input type="submit" value="submit" class="submit-btn">--%>
                                        <asp:Button ID="btnRegister" CssClass="submit-btn" runat="server" Text="Submit" OnClick="btnRegister_Click" OnClientClick="return validate()" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
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
                                <div class="copyright-section"><span>Copyright © 2016 Tomatos Pizzeria</div>
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

