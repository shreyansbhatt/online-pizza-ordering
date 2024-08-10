<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>


<!DOCTYPE html>
<html lang="en">
<head>
    <link runat="server" rel="shortcut icon" href="/images/logo.ico" type="image/x-icon" />
    <link runat="server" rel="icon" href="/images/logo.ico" type="image/ico" />
    <title>Login</title>
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
        /*.apply_btn:hover {
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
        }*/

        .submit-btn:hover {
            border: none;
            border-radius: 0px;
            background-color: #ca3027 !important;
        }

        .nav > li > a:focus, .nav > li > a:hover {
            text-decoration: none;
            background-color: #ca3027 !important;
        }

        #txtLoginPassword::-webkit-input-placeholder {
            color: black;
        }

        #txtLoginPassword:-moz-placeholder {
            color: black;
        }

        #txtLoginPassword::-moz-placeholder {
            color: black;
        }

        #txtLoginPassword:-ms-input-placeholder {
            color: black;
        }
    </style>

    <script type="text/javascript">
        //function DisableBackButton() {
        //    window.history.forward();
        //}
        //setTimeout("DisableBackButton()", 0);
        //window.onunload = function () { null };
        //$(document).load()
        //{
        //    alert("hi");
        //}
        function HideLabel() {
            var seconds = 5;
            setTimeout(function () {


                document.getElementById("<%=ErrorMessageDiv.ClientID %>").style.display = "none";



            }, seconds * 1000);

        };
        document.getElementById("<%=ErrorMsgDiv.ClientID%>").style.display = "none";

        function validateLogin() {

            if (document.getElementById("<%=txtLoginEmail.ClientID%>").value == "Email Address") {
             document.getElementById("<%=txtLoginEmail.ClientID%>").style.borderColor = "red";

                 // return false;
             }
             else {

                 var emailPat = /^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
                 var emailid = document.getElementById("<%=txtLoginEmail.ClientID %>").value;
                 var matchArray = emailid.match(emailPat);
                 if (matchArray == null) {
                     //("Enter Valid Email Address");
                     document.getElementById("<%=txtLoginEmail.ClientID%>").style.borderColor = "red";
                    document.getElementById("<%=ErrorMsgDiv.ClientID%>").style.display = "block";
                    document.getElementById("<%=ErrorMsgDiv.ClientID%>").innerHTML = "Please Enter Valid Email Address.";


                    return false;
                }
                else {
                    document.getElementById("<%=txtLoginEmail.ClientID%>").style.borderColor = "white";
                    document.getElementById("<%=ErrorMsgDiv.ClientID%>").style.display = "none";
                }
            }


            if (document.getElementById("<%=txtLoginPassword.ClientID%>").value == "") {
             document.getElementById("<%=txtLoginPassword.ClientID%>").style.borderColor = "red";
                // return false;
            }
            else {
                document.getElementById("<%=txtLoginPassword.ClientID%>").style.borderColor = "white";
            }
            if (document.getElementById("<%=txtLoginEmail.ClientID%>").value == "Email Address" || document.getElementById("<%=txtLoginPassword.ClientID%>").value == "") {
             return false;
         }
         else {

             return true;
         }

     }

    </script>
    <%--  <script type="text/javascript">


        javascript: window.history.forward(1);
        
    </script>--%>
    <style>
        /*.form-control
        {
           width: 70%;
        }*/
        .register-div .form-group input[ type="text"], .register-div .form-group input[ type="email"], .register-div .form-group input[ type="password"], .register-div .form-group textarea, .register-div .password-section {
            /*width: 70%;*/
            float: left;
            text-transform: none;
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
                margin: 0px;
            }
        }
         @media only screen and (max-width:640px) {
            .login-div {
                padding: 0px;
                margin: 0px;
            }

            .privacy-section ul {
                text-align: left;
                float: left;
                margin-left: -8px;
            }
        }
    </style>
    <div id="ErrorMessageDiv" class="alert alert-warning" runat="server" style="background-color: #ca3027; color: #ffffff; border-color: #ca3027;">
        <strong>Error!</strong> UserName or Password Incorrect.  
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
                                <div class="contact-detail-top" id="TopContactDetail"><span class="phone">
                                    <asp:Label ID="lblPhone" runat="server"></asp:Label></span> <span class="fax">
                                        <asp:Label ID="lblFax" runat="server"></asp:Label></span> </div>
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
                                    <li class="LiLogin"><a href="Login.aspx"><span>sign in</span></a></li>
                                    <li class="liReg"><a href="UserRegistration.aspx"><span class="register">create an account</span></a></li>
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
                            <h3>Sign In</h3>
                            <div class="register-div">
                                <div id="login-form">
                                    <div class="col-md-10">
                                        <div class="form-group">
                                            <label>Email</label>
                                            <%--<input type="text" value="enter your email" required="required" class="form-control" onFocus="this.value=''" onBlur="(this.value=='')? this.value='enter your email':this.value;">--%>
                                            <asp:TextBox ID="txtLoginEmail" runat="server" onfocus="(this.value=='Email Address')? this.value='':this.value;" onblur="(this.value=='')? this.value='Email Address':this.value;" CssClass="form-control">Email Address</asp:TextBox>
                                        </div>

                                        <div class="form-group">
                                            <label>Password</label>
                                            <%--<input type="password" value="password" placeholder="password" required="required" class="form-control" onFocus="this.value=''" onBlur="(this.value=='')? this.value='update your password':this.value;">--%>
                                            <asp:TextBox ID="txtLoginPassword" runat="server" placeholder="Enter Password" onfocus="this.placeholder=''" onblur="this.placeholder='Enter Password'" TextMode="Password" CssClass="form-control"></asp:TextBox>

                                        </div>
                                        <div class="form-group">
                                            <label></label>
                                            <%--<input type="checkbox"> Remember Me--%>
                                            <asp:CheckBox ID="chkRememberMe" runat="server" />
                                            Remember Me

                                        </div>
                                        <div class="form-group">
                                            <label></label>
                                            <%--  <input type="submit" value="Sign In" class="submit-btn">--%>
                                            <asp:Button ID="btnLogin" runat="server" CssClass="submit-btn" Text="Sign In" OnClick="btnLogin_Click" OnClientClick="return validateLogin()" />
                                        </div>
                                        <div class="form-group">
                                            <label></label>
                                            <span>
                                                <asp:LinkButton ID="lnkforgotpassword" runat="server" OnClick="lnkforgotpassword_Click" ForeColor="#ec3e34">Forgot Password</asp:LinkButton>
                                            </span>
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
