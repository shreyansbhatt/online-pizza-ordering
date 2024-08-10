<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="ResetPassword" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <link runat="server" rel="shortcut icon" href="/images/logo.ico" type="image/x-icon" />
    <link runat="server" rel="icon" href="/images/logo.ico" type="image/ico" />
    <title>Reset Password</title>
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
        .apply_btn:hover {
            border: none;
            border-radius: 0px;
            background-color: #ca3027 !important;
            /*width: 180px;*/
            /*height: 50px;*/
        }

        .submit-btn:hover {
            border: none;
            border-radius: 0px;
            background-color: #ca3027 !important;
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

        .register-div .form-group input[ type="text"], .register-div .form-group input[ type="email"], .register-div .form-group input[ type="password"], .register-div .form-group textarea, .register-div .password-section {
            /*width: 70%;*/
            float: left;
            text-transform: none;
            color: black;
        }

        #txtOldPassword::-webkit-input-placeholder, #txtNewPassword::-webkit-input-placeholder,
        #txtConfirmNewPassword::-webkit-input-placeholder {
            color: black;
        }

        #txtOldPassword:-moz-placeholder, #txtNewPassword:-moz-placeholder,
        #txtConfirmNewPassword:-moz-placeholder {
            color: black;
        }

        #txtOldPassword::-moz-placeholder, #txtNewPassword::-moz-placeholder,
        #txtConfirmNewPassword::-moz-placeholder {
            color: black;
        }

        #txtOldPassword:-ms-input-placeholder, #txtNewPassword:-ms-input-placeholder,
        #txtConfirmNewPassword:-ms-input-placeholder {
            color: black;
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
        function validate() {
            var msg = "";
            if (document.getElementById("<%=txtOldPassword.ClientID%>").value == "") {
                document.getElementById("<%=txtOldPassword.ClientID%>").style.borderColor = "red";
                // return false;
            }
            else {
                document.getElementById("<%=txtOldPassword.ClientID%>").style.borderColor = "white";
            }
            if (document.getElementById("<%=txtNewPassword.ClientID%>").value == "") {
                document.getElementById("<%=txtNewPassword.ClientID%>").style.borderColor = "red";
                // return false;
            }
            else {
                document.getElementById("<%=txtNewPassword.ClientID%>").style.borderColor = "white";
            }
            if (document.getElementById("<%=txtConfirmNewPassword.ClientID%>").value == "") {
                document.getElementById("<%=txtConfirmNewPassword.ClientID%>").style.borderColor = "red";
                // return false;
            }
            else {
                document.getElementById("<%=txtConfirmNewPassword.ClientID%>").style.borderColor = "white";
            }

            if (document.getElementById("<%=txtNewPassword.ClientID%>").value != "" && document.getElementById("<%=txtConfirmNewPassword.ClientID%>").value != "") {
                if (document.getElementById("<%=txtNewPassword.ClientID%>").value != document.getElementById("<%=txtConfirmNewPassword.ClientID%>").value) {
                    document.getElementById("<%=txtNewPassword.ClientID%>").style.borderColor = "red";
                    document.getElementById("<%=txtConfirmNewPassword.ClientID%>").style.borderColor = "red";
                    document.getElementById("<%=ErrorMsgDiv.ClientID%>").style.display = "block";
                    // document.getElementById("<%=ErrorMsgDiv.ClientID%>").innerHTML = "<strong>Error!</strong> Password and Confirm Password do not match.";
                    msg = msg + "Password and Confirm Password do not match";
                    document.getElementById("<%=ErrorMsgDiv.ClientID%>").innerHTML = msg;
                    // alert("Password and Confirm Password do not match");
                    return false;
                }
            }

            if (document.getElementById("<%=txtOldPassword.ClientID%>").value == "" || document.getElementById("<%=txtNewPassword.ClientID%>").value == "" || document.getElementById("<%=txtConfirmNewPassword.ClientID%>").value == "") {
                return false;
            }
            else {
                return true;
            }
        }


        function HideLabel() {
            var seconds = 5;
            setTimeout(function () {
                document.getElementById("<%=SuccessMessageDiv.ClientID %>").style.display = "none";
                document.getElementById("<%=ErrorMessageDiv.ClientID %>").style.display = "none";
            }, seconds * 1000);

        };


    </script>
    <div id="SuccessMessageDiv" class="alert alert-success" runat="server">
        <strong>Success!</strong> Successfully Reset Password.
    </div>
    <div id="ErrorMessageDiv" class="alert alert-warning" runat="server">
        <strong>Error!</strong> Unable to Reset Password.Please try again.
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
                                                <li runat="server" id="liOrderHistory" visible="false"><a href="CustomerOrderDetail.aspx">Order History</a></li>
                                                <li runat="server" id="liResetPassword"><a href="ResetPassword.aspx">Reset Password</a></li>

                                            </ul>
                                        </div>
                                    </li>
                                    <li class="LiLogin">
                                        <div id="SignInDiv" runat="server"><a href="Login.aspx?PageName=ResetPassword.aspx"><span id="SpanSignIn" runat="server">sign in</span></a></div>
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
                            <h3>Reset Password</h3>
                            <div class="register-div">
                                <div class="col-md-10">
                                    <div id="login-form">
                                        <div class="form-group">
                                            <label>Old Password</label>
                                            <%-- <input type="password" value="password" placeholder="password" required="required" class="form-control" onfocus="this.value=''" onblur="(this.value=='')? this.value='update your password':this.value;">--%>
                                            <asp:TextBox placeholder="Old Password" ID="txtOldPassword" runat="server" onfocus="this.placeholder=''" onblur="this.placeholder='Old Password'" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>New Password</label>
                                            <%-- <input type="password" value="password" placeholder="password" required="required" class="form-control" onfocus="this.value=''" onblur="(this.value=='')? this.value='update your password':this.value;">--%>
                                            <asp:TextBox placeholder="New Password" ID="txtNewPassword" runat="server" onfocus="this.placeholder=''" onblur="this.placeholder='New Password'" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Confirm Password</label>
                                            <%--<input type="password" value="password" placeholder="password" required="required" class="form-control" onfocus="this.value=''" onblur="(this.value=='')? this.value='update your password':this.value;">--%>
                                            <asp:TextBox placeholder="Confirm Password" ID="txtConfirmNewPassword" runat="server" onfocus="this.placeholder=''" onblur="this.placeholder='Confirm New Password'" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                        </div>

                                        <div class="form-group">
                                            <label></label>
                                            <%--<input type="submit" value="submit" class="submit-btn">--%>
                                            <asp:Button ID="btnChangePassword" runat="server" Text="Submit" OnClientClick="return validate(); return false;" OnClick="btnChangePassword_Click" CssClass="submit-btn" />
                                        </div>
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
