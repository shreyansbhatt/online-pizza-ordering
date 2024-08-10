<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <link runat="server" rel="shortcut icon" href="/images/logo.ico" type="image/x-icon" />
    <link runat="server" rel="icon" href="/images/logo.ico" type="image/ico" />
    <title>Tomatos Pizzeria</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="X-UA-Compatible" content="IE=9; IE=8; IE=7; IE=Edge,chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8, IE=9, chrome=1" />
    <!-- Latest compiled and minified JavaScript -->
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js"></script>
    <script src="js/jquery-1.11.1.min.js"></script>

    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
    <link href="css/style.css" rel='stylesheet' type='text/css' />
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css">
    <link rel="stylesheet" type="text/css" media="all" href="css/slider.css">
    <script type="text/javascript">
        function HideLabel() {
            var seconds = 5;
            setTimeout(function () {

                document.getElementById("<%=SuccessMessageDiv.ClientID %>").style.display = "none";

            }, seconds * 1000);

        };
    </script>
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
                margin-left: 10px;
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
                /*margin-left: -10px;*/
            }
        }

        @media only screen and (max-width:360px) and (min-width:347px) {
            #TopContactDetail {
                width: 105%;
            }
            .login-div {
                padding: 0px;
                margin: 8px 8px 8px 40px;
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

        @media only screen and (max-width:320px){
            .login-div {
                padding: 0px;
                margin: 8px 8px 8px 40px;
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
            #ContctDiv
             {
                 margin-left:-14px;
             }
        }
         @media only screen and (max-width:640px) {
            .login-div {
                padding: 0px;
                margin: -4px -4px -4px 34px;
            }

            .privacy-section ul {
                text-align: left;
                float: left;
                margin-left: -8px;
            }
        }
    </style>


    <div id="SuccessMessageDiv" class="alert alert-success" runat="server">
        <strong>Success!</strong> Your account has been created successfully
        
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
                                    <li><a id="afacebbok" runat="server" target="_blank" href=""><span class="facebook"></span></a></li>
                                    <li><a id="agoogleplus" runat="server" target="_blank" href=""><span class="google-plus"></span></a></li>
                                    <li><a id="alinkedin" runat="server" target="_blank" href=""><span class="linkedin"></span></a></li>
                                    <li><a id="ayoutube" runat="server" target="_blank" href=""><span class="youtube"></span></a></li>
                                </ul>
                                <ul class="login-div">
                                    <li class="dropdown" style="margin-left:3px;">
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
                                        <div id="SignInDiv" runat="server"><a href="Login.aspx?PageName=Index.aspx"><span id="SpanSignIn" runat="server">sign in</span></a></div>
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
                        <div class="top-slider">
                            <div class="col-md-8 col-sm-8 top-left-slider">
                                <!------------------------top-left slider starts------------------------------>
                                <div id="jssor_1" style="position: relative; margin: 0 auto; top: 0px; left: 0px; width: 600px; height: 300px; overflow: hidden; visibility: hidden;">
                                    <!-- Loading Screen -->
                                    <div data-u="loading" style="position: absolute; top: 0px; left: 0px;">
                                        <div style="filter: alpha(opacity=70); opacity: 0.7; position: absolute; display: block; top: 0px; left: 0px; width: 100%; height: 100%;"></div>
                                    </div>
                                    <div data-u="slides" style="cursor: default; position: relative; top: 0px; left: 0px; width: 600px; height: 300px; overflow: hidden;">
                                        <div data-p="112.50" style="display: none;">
                                            <asp:Image alt="" ID="Slider1Img1" runat="server" data-u="image"></asp:Image>
                                            <%-- <img data-u="image" src="images/slide1.jpg" /> --%>
                                        </div>
                                        <div data-p="112.50" style="display: none;">
                                            <asp:Image alt="" ID="Slider1Img2" runat="server" data-u="image"></asp:Image>
                                            <%-- <img data-u="image" src="images/slide2.jpg" /> --%>
                                        </div>
                                        <div data-p="112.50" style="display: none;">
                                            <asp:Image alt="" ID="Slider1Img3" runat="server" data-u="image"></asp:Image>
                                            <%--<img data-u="image" src="images/slide3.jpg" /> --%>
                                        </div>
                                        <div data-p="112.50" style="display: none;">
                                            <asp:Image alt="" ID="Slider1Img4" runat="server" data-u="image"></asp:Image>
                                            <%--  <img data-u="image" src="images/slide1.jpg" />--%>
                                        </div>
                                    </div>
                                    <!-- Bullet Navigator -->
                                    <div data-u="navigator" class="jssorb05" style="bottom: 16px; right: 16px;" data-autocenter="1">
                                        <!-- bullet navigator item prototype -->
                                        <div data-u="prototype" style="width: 16px; height: 16px;"></div>
                                    </div>
                                    <!-- Arrow Navigator -->
                                    <span data-u="arrowleft" class="jssora12l" style="top: 0px; left: 0px; width: 30px; height: 46px;" data-autocenter="2"></span><span data-u="arrowright" class="jssora12r" style="top: 0px; right: 0px; width: 30px; height: 46px;" data-autocenter="2"></span>
                                </div>
                            </div>
                            <!------------------------daily-special Section starts------------------------------>
                            <div class="col-md-4 col-sm-4 top-right-slider">
                                <div class="daily-special">
                                    <div class="title-daily-special">
                                        <img src="images/daily-spcl.png" class="img-responsive">
                                    </div>
                                    <div class="dynamic-img">
                                        <%-- <img src="images/spcl.jpg" class="img-responsive">--%>
                                        <asp:Image alt="" ID="DailySpecialImg" runat="server" CssClass="img-responsive" Height="342px"></asp:Image>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!------------------------bottom slider starts------------------------------>
                        <%--    <div class="bottom-slider" style="width: 100.6%; margin-left: -3px;">
                          

                           

                    </div>--%>

                        <%--<div id="NAV-ID" class="crsl-nav">
                            <a href="#" class="previous">Previous</a>
                            <a href="#" class="next">Next</a>
                        </div>--%>
                        <div class="bottom-slider" style="width: 100.2%; margin-left: -1px;" data-interval="3000">
                            <div class="crsl-items" data-navigation="NAV-ID" data-crsl='{ "speed": 1000, "autoRotate": 4000 }'>
                                <div class="crsl-wrap">
                                    <figure class="crsl-item">
                                        <%--<img src="people.jpg">--%>
                                        <%-- <img src="images/thumb2.jpg" alt="nyc subway">--%>
                                        <asp:Image alt="" ID="Slider2Img1" runat="server" Height="250px" Width="400px"></asp:Image>
                                        <h3>
                                            <%--<figcaption style="color: white;">--%>
                                            <asp:Label runat="server" ID="lblSlider2Image1Text"></asp:Label>

                                            <%-- </figcaption>--%>
                                        </h3>
                                    </figure>
                                    <figure class="crsl-item">
                                        <%--<img src="nature.jpg">--%>
                                        <%--<img src="images/thumb2.jpg" alt="nyc subway">--%>
                                        <asp:Image alt="" ID="Slider2Img2" runat="server" Height="250px" Width="400px"></asp:Image>
                                        <%--  <figcaption style="color: white;">--%>
                                        <h3>
                                            <asp:Label runat="server" ID="lblSlider2Image2Text"></asp:Label>
                                        </h3>
                                        <%-- </figcaption>--%>
                                    </figure>
                                    <figure class="crsl-item">
                                        <%-- <img src="food.jpg">--%>
                                        <asp:Image alt="" ID="Slider2Img3" runat="server" Height="250px" Width="400px"></asp:Image>
                                        <%--<figcaption style="color: white;">--%>
                                        <h3>
                                            <asp:Label runat="server" ID="lblSlider2Image3Text"></asp:Label>
                                        </h3>
                                        <%-- </figcaption>--%>
                                    </figure>
                                    <figure class="crsl-item">
                                        <%--<img src="sports.jpg">--%>
                                        <asp:Image alt="" ID="Slider2Img4" runat="server" Height="250px" Width="400px"></asp:Image>
                                        <%-- <figcaption style="color: white;">--%>
                                        <h3>
                                            <asp:Label runat="server" ID="lblSlider2Image4Text"></asp:Label>
                                        </h3>
                                        <%-- </figcaption>--%>
                                    </figure>
                                    <figure class="crsl-item">
                                        <%--<img src="abstract.jpg">--%>
                                        <asp:Image alt="" ID="Slider2Img5" runat="server" Height="250px" Width="400px"></asp:Image>
                                        <%-- <figcaption style="color: white;">--%>
                                        <h3>
                                            <asp:Label runat="server" ID="lblSlider2Image5Text"></asp:Label>
                                        </h3>

                                        <%--</figcaption>--%>
                                    </figure>
                                    <figure class="crsl-item">
                                        <%--<img src="abstract.jpg">--%>
                                        <asp:Image alt="" ID="Slider2Img6" runat="server" Height="250px" Width="400px"></asp:Image>
                                        <%-- <figcaption style="color: white;">--%>
                                        <h3>
                                            <asp:Label runat="server" ID="lblSlider2Image6Text"></asp:Label>
                                        </h3>

                                        <%--</figcaption>--%>
                                    </figure>
                                </div>
                            </div>
                        </div>
                        <nav class="slidernav">
                            <div id="NAV-ID" class="crsl-nav">
                                <a href="#" class="previous"></a>
                                <a href="#" class="next"></a>
                                <a href="#" class="next"></a>
                            </div>
                        </nav>
                    </div>




                    <script type="text/javascript">
                        $(function () {
                            $('.crsl-items').carousel({
                                visible: 3,
                                autoPlay: 1000,
                                itemMinWidth: 180,
                                itemEqualHeight: 370,
                            });

                            $("a[href=#]").on('click', function (e) {
                                e.preventDefault();
                            });
                        });
                    </script>
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
                </div>
                <!------------------------footer part ends------------------------------>
            </div>
        </div>
    </form>
</body>
</html>
<!-- #region Jssor Slider Begin -->
<!-- Generated by Jssor Slider Maker Online. -->
<!-- This demo works with jquery library -->
<script type="text/javascript" src="js/jquery-1.9.1.min.js"></script>
<script type="text/javascript" src="js/jssor.slider.mini.js"></script>
<!-- use jssor.slider.debug.js instead for debug -->
<script>
    jQuery(document).ready(function ($) {

        var jssor_1_SlideshowTransitions = [
          { $Duration: 1200, $Opacity: 2 }
        ];

        var jssor_1_options = {
            $AutoPlay: true,
            $SlideshowOptions: {
                $Class: $JssorSlideshowRunner$,
                $Transitions: jssor_1_SlideshowTransitions,
                $TransitionsOrder: 1
            },
            $ArrowNavigatorOptions: {
                $Class: $JssorArrowNavigator$
            },
            $BulletNavigatorOptions: {
                $Class: $JssorBulletNavigator$
            }
        };

        var jssor_1_slider = new $JssorSlider$("jssor_1", jssor_1_options);

        //responsive code begin
        //you can remove responsive code if you don't want the slider scales while window resizing
        function ScaleSlider() {
            var refSize = jssor_1_slider.$Elmt.parentNode.clientWidth;
            if (refSize) {
                refSize = Math.min(refSize, 800);
                jssor_1_slider.$ScaleWidth(refSize);
            }
            else {
                window.setTimeout(ScaleSlider, 30);
            }
        }
        ScaleSlider();
        $(window).bind("load", ScaleSlider);
        $(window).bind("resize", ScaleSlider);
        $(window).bind("orientationchange", ScaleSlider);
        //responsive code end
    });
</script>

<script type="text/javascript" src="js/jquery-1.11.0.min.js"></script>
<script type="text/javascript" src="js/responsiveCarousel.min.js"></script>

