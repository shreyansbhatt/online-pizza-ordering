<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TermsAndConditions.aspx.cs" Inherits="TermsAndConditions" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <link runat="server" rel="shortcut icon" href="/images/logo.ico" type="image/x-icon"/>
   <link runat="server" rel="icon" href="/images/logo.ico" type="image/ico"/>
    <title>Terms And Conditions</title>
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
                width: 108%;margin-left: -10px;
            }
        }
        @media only screen and (max-width:340px) and (min-width:339px) {
            #TopContactDetail {
                width: 109%;margin-left: -10px;
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
         @media only screen and (max-width:326px)  {
            #TopContactDetail {
                width: 114%;
                margin-left: -20px;
            }
        }
          @media only screen and (max-width:325px)  {
            #TopContactDetail {
                width: 115%;
                margin-left: -20px;
            }
        }
            @media only screen and (max-width:324px)  {
            #TopContactDetail {
                width: 116%;
                margin-left: -20px;
            }
        }
             @media only screen and (max-width:323px)  {
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
                                    <a href="Index.aspx"> <img src="images/logo_text.png" class="img-responsive"></a>  
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
                                     <li class="dropdown" style="margin-left:3px;">
                                        <div id="EmailDiv" runat="server" style="display: none">
                                            <a id="AccountAnchor" class="dropdown-toggle" data-toggle="dropdown" href="#"><span id="SpanEmail" runat="server" >My Account</span></a>
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
                                            <asp:LinkButton runat="server" ID="Logout" OnClick="Logout_Click"><span id="SpanLogout" runat="server" >Log Out</span></asp:LinkButton>
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
                            <h3>Terms & Conditions</h3>
                            <div class="register-div">
                                <div id="regiter-form">
                                    <p style="color: white; text-align: justify;">
                                        <strong style="font-size: medium;">Introduction</strong>
                                        <br />
                                        <br />
                                        Welcome to <a href="http://www.tomatospizzeria.com" style="color:#ca3027;font-size:medium;">http://www.tomatospizzeria.com.</a> This website is owned and operated by Tomatos Pizza, Inc.. By visiting our website and accessing the information, resources, services, products, and tools we provide, you understand and agree to accept and adhere to the following terms and conditions as stated in this policy (hereafter referred to as 'User Agreement'), along with the terms and conditions as stated in our Privacy Policy as specified in the privacy policy link.
                                        <br />
                                        <br />
                                        We reserve the right to change this User Agreement from time to time without notice. You acknowledge and agree that it is your responsibility to review this User Agreement periodically to familiarize yourself with any modifications. Your continued use of this site after such modifications will constitute acknowledgment and agreement of the modified terms and conditions.
                                        <br />
                                        <br />
                                        <strong style="font-size: medium;">Responsible Use and Conduct</strong>
                                        <br />
                                        <br />
                                        By visiting our website and accessing the information, resources, services, products, and tools we provide for you, either directly or indirectly (hereafter referred to as 'Resources'), you agree to use these Resources only for the purposes intended as permitted by (a) the terms of this User Agreement, and (b) applicable laws, regulations and generally accepted online practices or guidelines.
                                        <br />
                                        <br />
                                        Wherein, you understand that:
                                        <br />
                                        <br />
                                        a. In order to access our Resources, you may be required to provide certain information about yourself (such as identification, contact details, etc.) as part of the registration process, or as part of your ability to use the Resources. You agree that any information you provide will always be accurate, correct, and up to date.
                                        <br />
                                        <br />
                                        b. You are responsible for maintaining the confidentiality of any login information associated with any account you use to access our Resources. Accordingly, you are responsible for all activities that occur under your account(s).
                                        <br />
                                        <br />
                                        c. Accessing (or attempting to access) any of our Resources by any means other than through the means we provide, is strictly prohibited. You specifically agree not to access (or attempt to access) any of our Resources through any automated, unethical or unconventional means.
                                        <br />
                                        <br />
                                        d. Engaging in any activity that disrupts or interferes with our Resources, including the servers and/or networks to which our Resources are located or connected, is strictly prohibited.
                                        <br />
                                        <br />
                                        e. Attempting to copy, duplicate, reproduce, sell, trade, or resell our Resources is strictly prohibited.
                                        <br />
                                        <br />
                                        f. You are solely responsible any consequences, losses, or damages that we may directly or indirectly incur or suffer due to any unauthorized activities conducted by you, as explained above, and may incur criminal or civil liability.
                                        <br />
                                        <br />
                                        <strong style="font-size: medium;">Limitation of Warranties</strong>
                                        <br />
                                        <br />
                                        By using our website, you understand and agree that all Resources we provide are "as is" and "as available". This means that we do not represent or warrant to you that:
                                       
                                        <br />
                                        i) the use of our Resources will meet your needs or requirements.
                                       
                                        <br />
                                        ii) the use of our Resources will be uninterrupted, timely, secure or free from errors.
                                       
                                        <br />
                                        iii) the information obtained by using our Resources will be accurate or reliable, and
                                       
                                        <br />
                                        iv) any defects in the operation or functionality of any Resources we provide will be repaired or corrected.
                                        <br />
                                        <br />

                                        Furthermore, you understand and agree that:
                                         <br />
                                        <br />
                                        v) any content downloaded or otherwise obtained through the use of our Resources is done at your own discretion and risk, and that you are solely responsible for any damage to your computer or other devices for any loss of data that may result from the download of such content.
                                       
                                        <br />
                                        vi) no information or advice, whether expressed, implied, oral or written, obtained by you from Tomatos Pizza, Inc. or through any Resources we provide shall create any warranty, guarantee, or conditions of any kind, except for those expressly outlined in this User Agreement.
                                        <br />
                                        <br />
                                        <strong style="font-size: medium;">Limitation of Liability</strong>
                                        <br />
                                        <br />
                                        In conjunction with the Limitation of Warranties as explained above, you expressly understand and agree that any claim against us shall be limited to the amount you paid, if any, for use of products and/or services. Tomatos Pizza, Inc. will not be liable for any direct, indirect, incidental, consequential or exemplary loss or damages which may be incurred by you as a result of using our Resources, or as a result of any changes, data loss or corruption, cancellation, loss of access, or downtime to the full extent that applicable limitation of liability laws apply.
                                        <br />
                                        <br />
                                        <strong style="font-size: medium;">Copyrights/Trademarks</strong>
                                        <br />
                                        <br />
                                        All content and materials available on <a href="http://www.tomatospizzeria.com" style="color:#ca3027;font-size:medium;">http://www.tomatospizzeria.com</a> including but not limited to text, graphics, website name, code, images and logos are the intellectual property of Tomato Pizza, Inc., and are protected by applicable copyright and trademark law. Any inappropriate use, including but not limited to the reproduction, distribution, display or transmission of any content on this site is strictly prohibited, unless specifically authorized by Tomato Pizza, Inc.
                                        <br />
                                        <br />
                                        <strong style="font-size: medium;">Termination of Use</strong>
                                        <br />
                                        <br />
                                        You agree that we may, at our sole discretion, suspend or terminate your access to all or part of our website and Resources with or without notice and for any reason, including, without limitation, breach of this User Agreement. Any suspected illegal, fraudulent or abusive activity may be grounds for terminating your relationship and may be referred to appropriate law enforcement authorities. Upon suspension or termination, your right to use the Resources we provide will immediately cease, and we reserve the right to remove or delete any information that you may have on file with us, including any account or login information.
                                         <br />
                                        <br />
                                        <strong style="font-size: medium;">Governing Law</strong>
                                        <br />
                                        <br />
                                        This website is controlled by Tomato Pizza, Inc. from our offices located in the state of IL, USA. It can be accessed by most countries around the world. As each state and or country has laws that may differ from those of state of IL, by accessing our website, you agree that the statutes and laws of IL, without regard to the conflict of laws and the United Nations Convention on the International Sales of Goods, will apply to all matters relating to the use of this website and the purchase of any products or services through this site.
                                        <br />
                                        <br />
                                        Furthermore, any action to enforce this User Agreement shall be brought in the federal or state courts located in USA, IL You hereby agree to personal jurisdiction by such courts, and waive any jurisdictional, venue, or inconvenient forum objections to such courts.
                                        <br />
                                        <br />
                                        <strong style="font-size: medium;">Guarantee</strong>
                                        <br />
                                        <br />
                                        UNLESS OTHERWISE EXPRESSED, Tomato Pizza, Inc. EXPRESSLY DISCLAIMS ALL WARRANTIES AND CONDITIONS OF ANY KIND, WHETHER EXPRESS OR IMPLIED, INCLUDING, BUT NOT LIMITED TO THE IMPLIED WARRANTIES AND CONDITIONS OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT.
                                         <br />
                                        <br />
                                        <strong style="font-size: medium;">Contact Information</strong>
                                        <br />
                                        <br />
                                        If you have any questions or comments about these our Terms of Service as outlined above, you can contact us at:
                                         <br />
                                        
                                       <strong> Tomato Pizza, Inc.</strong>

                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!------------------------footer part starts------------------------------>
                     <footer>
                    <div class="footer">
                        <!------------------------footer-bottom starts------------------------------>
                        <div class="footer-bottom" id="ContctDiv"><span class="contact"><asp:Label ID="lblAddress" runat="server" ></asp:Label></span>
                           <span class="contact-phone" id="CateringContact">For catering please call 630-766-2221</span> 
                        </div>
                        <div class="bottom-section">
                            <div class="copyright-section"><span>Copyright © 2016 Tomatos Pizzeria</div>
                            <div class="message-section">
                                <p>
                                    We deliver to Bensenville, Wood Dale and Neighboring Areas.
                Minimum Delivery Purchase:&nbsp;<asp:Label ID="lblminimumDeliveryPurchase" runat="server" ></asp:Label>   Delivery Charge:&nbsp;<asp:Label ID="lblDeliveryCharge" runat="server" ></asp:Label>
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


