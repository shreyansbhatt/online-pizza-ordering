<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="ContactUs" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <link runat="server" rel="shortcut icon" href="/images/logo.ico" type="image/x-icon" />
    <link runat="server" rel="icon" href="/images/logo.ico" type="image/ico" />
    <title>contact Us</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="X-UA-Compatible" content="IE=9; IE=8; IE=7; IE=Edge,chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8, IE=9, chrome=1" />
    <!-- Latest compiled and minified JavaScript -->

    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js"></script>
    <script src="js/BootstrapDropdown.js" type="text/javascript"></script>
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
        //alert(window.innerWidth);
        <%--        function validate() {

            if (document.getElementById("<%=txtName.ClientID%>").value == "") {
                document.getElementById("<%=txtName.ClientID%>").style.borderColor = "red";
                if (document.getElementById("<%=txtEmail.ClientID%>").value == "") {
                    document.getElementById("<%=txtEmail.ClientID%>").style.borderColor = "red";
                    if (document.getElementById("<%=txtComments.ClientID%>").value == "") {
                        document.getElementById("<%=txtComments.ClientID%>").style.borderColor = "red";
                    }
                    else {
                        document.getElementById("<%=txtComments.ClientID%>").style.borderColor = "#333232";
                    }
                }
                else {
                    var emailPat = /^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
                    var emailid = document.getElementById("<%=txtEmail.ClientID %>").value;
                    var matchArray = emailid.match(emailPat);
                    if (matchArray == null) {
                        alert("Enter Valid Email Address");
                        document.getElementById("<%=txtEmail.ClientID%>").style.borderColor = "red";
                    }
                    else {
                        document.getElementById("<%=txtEmail.ClientID%>").style.borderColor = "#333232";
                        if (document.getElementById("<%=txtComments.ClientID%>").value == "") {
                            document.getElementById("<%=txtComments.ClientID%>").style.borderColor = "red";
                        }
                        else {
                            document.getElementById("<%=txtComments.ClientID%>").style.borderColor = "#333232";
                        }
                    }
                }
                return false;
            }

            else {
                document.getElementById("<%=txtName.ClientID%>").style.borderColor = "#333232";
            }
        }--%>
       
        document.getElementById("<%=ErrorMsgDiv.ClientID%>").style.display = "none";
        function validate() {

            if (document.getElementById("<%=txtName.ClientID%>").value == "Name") {
                document.getElementById("<%=txtName.ClientID%>").style.borderColor = "red";
                //return false;
            }
            else {
                document.getElementById("<%=txtName.ClientID%>").style.borderColor = "#333232";
            }

            if (document.getElementById("<%=txtEmail.ClientID%>").value == "Email Address") {
                document.getElementById("<%=txtEmail.ClientID%>").style.borderColor = "red";
                //return false;
            }
            else {
                var emailPat = /^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
                var emailid = document.getElementById("<%=txtEmail.ClientID %>").value;
                var matchArray = emailid.match(emailPat);
                if (matchArray == null) {
                    // alert("Enter Valid Email Address");
                    document.getElementById("<%=ErrorMsgDiv.ClientID%>").style.display = "block";
                    document.getElementById("<%=ErrorMsgDiv.ClientID%>").innerHTML = "Please Enter Valid Email Address.";

                    document.getElementById("<%=txtEmail.ClientID%>").style.borderColor = "red";
                    //return false;
                }
                else {
                    document.getElementById("<%=ErrorMsgDiv.ClientID%>").style.display = "none";
                    document.getElementById("<%=txtEmail.ClientID%>").style.borderColor = "#333232";
                }
            }

            if (document.getElementById("<%=txtComments.ClientID%>").value == "Comments") {
                document.getElementById("<%=txtComments.ClientID%>").style.borderColor = "red";
                //return false;
            }
            else {
                document.getElementById("<%=txtComments.ClientID%>").style.borderColor = "#333232";
            }

            if (document.getElementById("<%=txtName.ClientID%>").value == "Name" || document.getElementById("<%=txtEmail.ClientID%>").value == "Email Address" || document.getElementById("<%=txtComments.ClientID%>").value == "Comments") {
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

            }, seconds * 1000);

        };
        $(".dropdown-toggle").attr("data-toggle", "dropdown");
    </script>
    <div id="SuccessMessageDiv" class="alert alert-success" runat="server">
        <strong>Success!</strong>We have received your comments.We will get back to you soon.
         <br />
        &nbsp;
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
                                    <li><a id="afacebbok" runat="server" target="_blank" href=""><span class="facebook"></span></a></li>
                                    <li><a id="agoogleplus" runat="server" target="_blank" href=""><span class="google-plus"></span></a></li>
                                    <li><a id="alinkedin" runat="server" target="_blank" href=""><span class="linkedin"></span></a></li>
                                    <li><a id="ayoutube" runat="server" target="_blank" href=""><span class="youtube"></span></a></li>
                                </ul>
                                <ul class="login-div">
                                    <li class="dropdown" style="margin-left: 3px;">
                                        <div id="EmailDiv" runat="server" style="display: none">
                                            <a class="dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-close-others="false" href="#" id="AccountAnchor"><span id="SpanEmail" runat="server">My Account</span></a>
                                            <ul class="dropdown-menu">
                                                <%--<li runat="server" id="li2"><a href="Admin/DashBoard.aspx" target="_blank">DashBoard</a></li>--%>
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
                            <h3>Contact Us</h3>
                            <div class="register-div">
                                <%--<div class="col-md-10">
                                    <div id="login-form">--%>
                                <div id="regiter-form">
                                    <div class="form-group">
                                        <label>Name</label>
                                        <asp:TextBox ID="txtName" onfocus="(this.value=='Name')? this.value='':this.value;" onblur="(this.value=='')? this.value='Name':this.value;" runat="server" CssClass="form-control">Name</asp:TextBox>
                                        <%--<asp:TextBox placeholder="old password" onfocus="this.placeholder=''" onblur="this.placeholder='enter old password'" ID="txtName" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>--%>
                                        <%-- <asp:TextBox placeholder="old password" ID="txtName" runat="server" onfocus="this.placeholder=''" onblur="this.placeholder='enter name'" TextMode="Password" CssClass="form-control"></asp:TextBox>--%>
                                        <%--<asp:TextBox ID="txtEmailAddress" runat="server" onfocus="(this.value=='Email Address')? this.value='':this.value;" onblur="(this.value=='')? this.value='Email Address':this.value;" CssClass="form-control" TabIndex="6">Email Address</asp:TextBox>--%>
                                    </div>
                                    <div class="form-group">
                                        <label>Email</label>

                                        <asp:TextBox ID="txtEmail" onfocus="(this.value=='Email Address')? this.value='':this.value;" onblur="(this.value=='')? this.value='Email Address':this.value;" runat="server" CssClass="form-control">Email Address</asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>Comments</label>
                                        <%--<input type="password" value="password" placeholder="password" required="required" class="form-control" onfocus="this.value=''" onblur="(this.value=='')? this.value='update your password':this.value;">--%>
                                        <asp:TextBox ID="txtComments" onfocus="(this.value=='Comments')? this.value='':this.value;" onblur="(this.value=='')? this.value='Comments':this.value;" runat="server" TextMode="MultiLine" Rows="2" Columns="8" CssClass="form-control">Comments</asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <label></label>
                                        <%--<input type="submit" value="submit" class="submit-btn">--%>
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClientClick="return validate(); return false;" CssClass="submit-btn" OnClick="btnSubmit_Click" Style="background-color: #ca3027 !important;" />
                                    </div>
                                </div>
                                <%-- </div>
                                </div>--%>
                                <%-- <div class="col-md-10">
                                    <div id="login-form">
                                        <div class="form-group">
                                            <label>Name</label>

                                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Email</label>
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Comments</label>
                                            <asp:TextBox ID="txtComments" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2" Columns="8"></asp:TextBox>
                                          
                                        </div>

                                        <div class="form-group">
                                            <label></label>
                                            <input type="submit" value="submit" class="submit-btn">
                                        </div>
                                    </div>
                                </div>--%>
                                <div class="col-md-12">
                                    <div class="map">
                                        <script src='https://maps.googleapis.com/maps/api/js?v=3.exp'></script>
                                        <div style='overflow: hidden; height: 400px; width: 800px;'>
                                            <div id='gmap_canvas' style='height: 400px; width: 800px;'></div>
                                            <div><small><a href="http://embedgooglemaps.com">embed google map							</a></small></div>
                                            <div><small><a href="http://freedirectorysubmissionsites.com">directory submission sites</a></small></div>
                                            <style>
                                                #gmap_canvas img {
                                                    max-width: none !important;
                                                    background: none !important;
                                                    color: #333333;
                                                }
                                            </style>
                                        </div>
                                        <script type='text/javascript'>function init_map() {
    var myOptions = {
        zoom: 10, center: new google.maps.LatLng(41.9605783, -87.951231), mapTypeId: google.maps.MapTypeId.ROADMAP, zoomControl: false, scrollwheel: false, scaleControl: false, draggable: false, disableDoubleClickZoom: true,
    }; map = new google.maps.Map(document.getElementById('gmap_canvas'), myOptions); marker = new google.maps.Marker({ map: map, position: new google.maps.LatLng(41.9605783, -87.951231) }); infowindow = new google.maps.InfoWindow({ content: '<strong>Tomatos Pizzeria</strong><br>720 W. Irving Park Road, Bensenville IL 60106<br>' }); google.maps.event.addListener(marker, 'click', function () { infowindow.open(map, marker); }); infowindow.open(map, marker);
} google.maps.event.addDomListener(window, 'load', init_map);

                                        </script>
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

