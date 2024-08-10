<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrivacyPolicies.aspx.cs" Inherits="PrivacyPolicies" %>


<!DOCTYPE html>
<html lang="en">
<head>
    <link runat="server" rel="shortcut icon" href="/images/logo.ico" type="image/x-icon" />
    <link runat="server" rel="icon" href="/images/logo.ico" type="image/ico" />
    <title>Privacy Policies</title>
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
        #CateringContact
          {
              font-size: 15px;
          }
           @media only screen and (max-width:480px) {
             #CateringContact
          {
              font-size: 14px;
          }
              #ContctDiv
             {
                 margin-left:-14px;
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
                                    <li class="dropdown"style="margin-left:3px;">
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
                                        <div id="SignInDiv" runat="server"><a href="Login.aspx?PageName=ContactUs.aspx"><span id="SpanSignIn" runat="server">sign in</span></a></div>
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
                        <div class="registration-page">
                            <h3>Privacy Policy</h3>
                            <div class="register-div">
                                <div id="regiter-form">
                                    <p style="color: white; text-align: justify;">
                                        <strong style="font-size: medium;">What information do we collect?</strong>
                                        <br />
                                        <br />
                                        We collect information from you when you order or register on our site, as appropriate, you may be asked to enter your: name, e-mail address, mailing address and phone number. You may, however, visit our site anonymously.
                                        <br />
                                        <br />

                                        <strong style="font-size: medium;">What do we use your information for?</strong>
                                        <br />
                                        <br />
                                        Any of the information we collect from you may be used in one of the following ways:
                                        <br />

                                        <ul style="color: white;">
                                            <li>To personalize your experience</li>
                                            <li>To improve our website</li>
                                            <li>To improve customer service</li>
                                            <li>To process transactions</li>
                                        </ul>


                                    </p>
                                    <p style="color: white; text-align: justify;">
                                        Your information, whether public or private, will not be sold, exchanged, transferred, or given to any other company for any reason whatsoever, without your consent, other than for the express purpose of delivering the purchased product or service requested.
                                            <br />
                                        <ul style="color: white;">
                                            <li>To administer a contest, promotion, survey 
                                            </li>
                                            <li>To send periodic emails
                                            </li>
                                        </ul>
                                    </p>
                                    <p style="color: white; text-align: justify;">
                                        The email address you provide for order processing, will only be used to send you information and updates pertaining to your order.
                                        <br />
                                        <br />
                                        <strong style="font-size: medium;">How do we protect your information?</strong>
                                        <br />
                                        <br />
                                        We implement a variety of security measures to maintain the safety of your personal information when you enter, submit, or access your personal information.
                                         <br />
                                        <br />
                                        <strong style="font-size: medium;">Do we use cookies?</strong>
                                        <br />
                                        <br />
                                        Yes (Cookies are small files that a site or its service provider transfers to your computers hard drive through your Web browser (if you allow) that enables the sites or service providers systems to recognize your browser and capture and remember certain information
                                        
                                        <br />
                                        <br />
                                        We use cookies to help us remember and process the items in your shopping cart, understand and save your preferences for future visits, keep track of advertisements and compile aggregate data about site traffic and site interaction so that we can offer better site experiences and tools in the future. We may contract with third-party service providers to assist us in better understanding our site visitors. These service providers are not permitted to use the information collected on our behalf except to help us conduct and improve our business.
                                        <br />
                                        <br />
                                        If you prefer, you can choose to have your computer warn you each time a cookie is being sent, or you can choose to turn off all cookies via your browser settings. Like most websites, if you turn your cookies off, some of our services may not function properly. However, you can still place orders over the telephone or by contacting customer service.
                                        <br />
                                        <br />
                                        <strong style="font-size: medium;">Do we disclose any information to outside parties?</strong>
                                        <br />
                                        <br />
                                        We do not sell, trade, or otherwise transfer to outside parties your personally identifiable information. This does not include trusted third parties who assist us in operating our website, conducting our business, or servicing you, so long as those parties agree to keep this information confidential. We may also release your information when we believe release is appropriate to comply with the law, enforce our site policies, or protect ours or others rights, property, or safety. However, non-personally identifiable visitor information may be provided to other parties for marketing, advertising, or other uses.
                                        <br />
                                        <br />
                                        <strong style="font-size: medium;">Online Privacy Policy Only</strong>
                                        <br />
                                        <br />
                                        This online privacy policy applies only to information collected through our website.
                                        <br />
                                        <br />
                                        <strong style="font-size: medium;">Your Consent</strong>
                                        <br />
                                        <br />
                                        By using our site, you consent to our website privacy policy.
                                        <br />
                                        <br />
                                        <strong style="font-size: medium;">Contacting Us</strong>
                                        <br />
                                        <br />
                                        If there are any questions or concerns regarding this privacy policy you may contact us using the information below.
                                        <br />
                                        <br />
                                        <a href="http://www.tomatospizzeria.com" style="color: #ca3027; font-size: medium;">http://www.tomatospizzeria.com.</a>
                                        <br />

                                        720 W Irving Park Rd, Bensenville, IL 60106
                                        
                                        <br />
                                        (630) 766-2221


                                        
                                    </p>
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

