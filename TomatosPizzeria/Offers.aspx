<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Offers.aspx.cs" Inherits="Offers" EnableEventValidation="false" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <link runat="server" rel="shortcut icon" href="/images/logo.ico" type="image/x-icon" />
    <link runat="server" rel="icon" href="/images/logo.ico" type="image/ico" />
    <title>Offers</title>
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

        #btnView {
            border-radius: 5px;
        }

        .btn-danger.active.focus, .btn-danger.active:focus, .btn-danger.active:hover, .btn-danger:active.focus, .btn-danger:active:focus, .btn-danger:active:hover, .open > .dropdown-toggle.btn-danger.focus, .open > .dropdown-toggle.btn-danger:focus, .open > .dropdown-toggle.btn-danger:hover {
            color: #fff;
            background-color: #ca3027 !important;
            border-color: #ca3027 !important;
            border-radius: 0px;
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

        #btnSubscribe {
            border-radius: 5px;
            /*background-color: #ca3027 !important;*/
            color: #ffffff;
            border: none;
            padding: 8px;
            width: 100px;
            margin-left:5px;
        }

            #btnSubscribe:hover {
                border: none;
                border-radius: 0px; background-color: #ca3027 !important;
            border-color: #ca3027 !important;
                /*background-color: #ca3027 !important;*/
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

        .offers-section {
            padding: 1em;
        }

        .panel-default > .panel-heading {
            color: #333;
            background-color: #f5f5f5;
            border-color: #ddd;
        }

        .panel-group .panel-heading {
            border-bottom: 0;
        }

        .offers-section .panel-heading {
            overflow: hidden;
            color: #ca3027;
            font-weight: 600;
            color: #504F4F !important;
        }

        .panel-default > .panel-heading {
            color: #333;
            background-color: #f5f5f5;
            border-color: #ddd;
        }

        .panel-group .panel-heading {
            border-bottom: 0;
        }

        .panel-heading {
            padding: 10px 15px;
            border-bottom: 1px solid transparent;
            border-top-left-radius: 3px;
            border-top-right-radius: 3px;
        }

        .panel-heading {
            padding: 10px 15px;
            border-bottom: 1px solid transparent;
            border-top-left-radius: 3px;
            border-top-right-radius: 3px;
        }

        .offer-header {
            background: rgb(255, 255, 255) none repeat scroll 0% 0%;
            padding: 1em;
            overflow: hidden;
            width: 97%;
            margin: 0px auto;
        }

        #txtEmailAddress {
            width: 55%;
            float: left;
            border-top-right-radius: 0px;
            border-bottom-right-radius: 0px;
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

    <script type="text/javascript">
        function HideLabel() {
            var seconds = 5;
            setTimeout(function () {


                document.getElementById("<%=SuccessMessageDiv.ClientID %>").style.display = "none";

                document.getElementById("<%=txtEmailAddress.ClientID%>").value == "Enter your email";

            }, seconds * 1000);

        };
        $(document).ready(function () {
            $(document).keyup(function (e) {

                if (e.keyCode == 27) {

                    $("#btnclose.close").click();


                }
            });
        });
        function validate() {
            if (document.getElementById("<%=txtEmailAddress.ClientID%>").value == "Enter your email") {
                document.getElementById("<%=txtEmailAddress.ClientID%>").style.borderColor = "red";

                return false;
            }
            else {

                var emailPat = /^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
                var emailid = document.getElementById("<%=txtEmailAddress.ClientID %>").value;
                var matchArray = emailid.match(emailPat);
                if (matchArray == null) {
                    // alert("Enter Valid Email Address");
                    document.getElementById("<%=txtEmailAddress.ClientID%>").style.borderColor = "red";
                    document.getElementById("<%=ErrorMsgDiv.ClientID%>").style.display = "block";
                    document.getElementById("<%=ErrorMsgDiv.ClientID%>").innerHTML = "Please Enter Valid Email Address.";

                    return false;
                }
                else {
                    document.getElementById("<%=txtEmailAddress.ClientID%>").style.borderColor = "white";
                    document.getElementById("<%=ErrorMsgDiv.ClientID%>").style.display = "none";
                }
            }
        }
    </script>
    <div id="SuccessMessageDiv" class="alert alert-success" runat="server">
        <strong>Success!</strong> Successfully Subscribed.
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
                                        <div id="SignInDiv" runat="server"><a href="Login.aspx?PageName=Offers.aspx"><span id="SpanSignIn" runat="server">sign in</span></a></div>
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
                                        <li class="order"><a href="OrderOnline.aspx">Order Online</a></li>
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
                        <div class="inner-div">
                            <h1 style="color: #FFFFFF;float:left;margin-left:12px;">
                                Offers
                            </h1>
                            <div class="offer-header">
                                <div class="offer_subscribe_section">
                                    <h2>Subscribe to receive our offers</h2>

                                    <div id="subscribe_form">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtEmailAddress" runat="server" onfocus="(this.value=='Enter your email')? this.value='':this.value;" onblur="(this.value=='')? this.value='Enter your email':this.value;" CssClass="form-control">Enter your email</asp:TextBox>
                                            <asp:Button ID="btnSubscribe" runat="server" CssClass="btn btn-danger active" Text="Subscribe" OnClick="btnSubscribe_Click" OnClientClick="return validate()" Style="background-color: rgb(202, 48, 39);" />
                                            <%--<input class="form-control" value="Enter your Email id" onFocus="this.value=''" onBlur="(this.value=='')? this.value='email address':this.value;" type="email">
                                        <button type="submit" class="btn btn-danger active">Subscribe</button>--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="offers-section">
                                <div class="panel-group">

                                    <asp:Repeater ID="rptOfferList" runat="server">



                                        <ItemTemplate>
                                            <div class="panel panel-default">
                                                <div class="panel-heading">
                                                    <div class="col-md-2 col-sm-2">Offer Name</div>
                                                    <div class="col-md-4 col-sm-4 hidden-xs">Offer Description</div>
                                                    <div class="col-md-2 col-sm-2 hidden-xs">Offer Code</div>
                                                    <div class="col-md-2 col-sm-2 hidden-xs">Offer Expires on</div>
                                                    <div class="col-md-2 col-sm-2 hidden-xs">View</div>
                                                </div>

                                                <div class="panel-body" id="offer111">
                                                    <div class="col-md-2 col-sm-2">
                                                        <asp:Label ID="lblOfferName" Text='<%# Eval("OfferName") %>' runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-md-4 col-sm-4">
                                                        <asp:Label ID="lblOfferDescription" Text='<%# Eval("OfferDescription") %>' runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-md-2 col-sm-2">
                                                        <asp:Label ID="lblOfferCode" Text='<%# Eval("OfferCode") %>' runat="server" CssClass="label label-primary"></asp:Label>
                                                    </div>
                                                    <div class="col-md-2 col-sm-2">
                                                        <asp:Label ID="lblOfferExpirationDate" Text='<%# Eval("OfferExpirationDate") %>' runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-md-2 col-sm-2">
                                                        <asp:Button ID="btnView" runat="server" CssClass="btn btn-danger active" Text="View Detail" data-toggle="modal" data-target='<%# "#"+Eval("OfferCode") %>' OnClientClick="return false" />
                                                        <%--<button type="button" class="btn btn-danger active" data-toggle="modal" data-target="#offer1">View Detail</button>--%>
                                                    </div>
                                                    <div id="modal">
                                                        <div id='<%# Eval("OfferCode") %>' class="modal fade" role="dialog">
                                                            <div class="modal-dialog modal-lg">
                                                                <div class="modal-content">
                                                                    <div class="modal-header">
                                                                        <asp:Label ID="Label2" Text='<%# Eval("OfferName") %>' runat="server"></asp:Label>
                                                                        <%--<asp:Button ID="btnclose" CssClass="close" data-dismiss="modal" Text="&times;" runat="server" />--%>
                                                                        <button type="button" class="close" data-dismiss="modal" id="btnclose">&times;</button>
                                                                    </div>
                                                                    <div class="modal-body">
                                                                        <asp:Label ID="Label3" Text='<%# Eval("OfferDescription") %>' runat="server"></asp:Label>
                                                                    </div>
                                                                    <div class="modal-footer">
                                                                        <asp:Label ID="Label1" Text='<%# Eval("OfferCode") %>' runat="server" CssClass="label label-danger"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                </div>
                                <%-- <div class="panel panel-default">
                                       
                                        <div class="panel-body" id="offer111">
                                            <div class="col-md-2 col-sm-2"><span id="offer-name">Offer1</span></div>
                                            <div class="col-md-4 col-sm-4"><span id="offer-desc">Lorem Ipsum is simply dummy text of the printing and typesetting industry.</span></div>
                                            <div class="col-md-2 col-sm-2"><span class="label label-primary" id="offer-code">C6-11092</span></div>
                                            <div class="col-md-2 col-sm-2">19-Apr-2016</div>
                                            <div class="col-md-2 col-sm-2">
                                                <button type="button" class="btn btn-danger active" data-toggle="modal" data-target="#offer1">View Detail</button>
                                            </div>

                                            <div id="offer1" class="modal fade" role="dialog">
                                                <div class="modal-dialog modal-lg">
                                                    <div class="modal-content">
                                                        <div class="modal-header">
                                                            <span id="offer-name">Offer Name</span>
                                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                        </div>
                                                        <div class="modal-body">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.</div>
                                                        <div class="modal-footer"><span class="label label-danger" id="offer-code">C6-11092</span></div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>



                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <div class="col-md-2 col-sm-2">Offer Name</div>
                                            <div class="col-md-4 col-sm-4 hidden-xs">Offer Description</div>
                                            <div class="col-md-2 col-sm-2 hidden-xs">Offer Code</div>
                                            <div class="col-md-2 col-sm-2 hidden-xs">Offer Expires on</div>
                                            <div class="col-md-2 col-sm-2 hidden-xs">View</div>
                                        </div>
                                        <div class="panel-body" id="offer222">
                                            <div class="col-md-2 col-sm-2"><span id="offer-name">Offer2</span></div>
                                            <div class="col-md-4 col-sm-4"><span id="offer-desc">Lorem Ipsum is simply dummy text of the printing and typesetting industry.</span></div>
                                            <div class="col-md-2 col-sm-2"><span class="label label-primary" id="offer-code">C6-11092</span></div>
                                            <div class="col-md-2 col-sm-2">19-Apr-2016</div>
                                            <div class="col-md-2 col-sm-2">
                                                <button type="button" class="btn btn-danger active" data-toggle="modal" data-target="#offer2">View Detail</button>
                                            </div>

                                            <div id="offer2" class="modal fade" role="dialog">
                                                <div class="modal-dialog modal-lg">
                                                    <div class="modal-content">
                                                        <div class="modal-header">
                                                            <span id="offer-name">Offer Name</span>
                                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                        </div>
                                                        <div class="modal-body">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.</div>
                                                        <div class="modal-footer"><span class="label label-danger" id="offer-code">C6-11092</span></div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>


                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <div class="col-md-2 col-sm-2">Offer Name</div>
                                            <div class="col-md-4 col-sm-4 hidden-xs">Offer Description</div>
                                            <div class="col-md-2 col-sm-2 hidden-xs">Offer Code</div>
                                            <div class="col-md-2 col-sm-2 hidden-xs">Offer Expires on</div>
                                            <div class="col-md-2 col-sm-2 hidden-xs">View</div>
                                        </div>
                                        <div class="panel-body" id="offer333">
                                            <div class="col-md-2 col-sm-2"><span id="offer-name">Offer3</span></div>
                                            <div class="col-md-4 col-sm-4"><span id="offer-desc">Lorem Ipsum is simply dummy text of the printing and typesetting industry.</span></div>
                                            <div class="col-md-2 col-sm-2"><span class="label label-primary" id="offer-code">C6-11092</span></div>
                                            <div class="col-md-2 col-sm-2">19-Apr-2016</div>
                                            <div class="col-md-2 col-sm-2">
                                                <button type="button" class="btn btn-danger active" data-toggle="modal" data-target="#offer3">View Detail</button>
                                            </div>

                                            <div id="offer3" class="modal fade" role="dialog">
                                                <div class="modal-dialog modal-lg">
                                                    <div class="modal-content">
                                                        <div class="modal-header">
                                                            <span id="offer-name">Offer Name</span>
                                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                        </div>
                                                        <div class="modal-body">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.</div>
                                                        <div class="modal-footer"><span class="label label-danger" id="offer-code">C6-11092</span></div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>--%>



                                <!------------------------panel group ends------------------------------>


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
                                  <span class="contact-phone" id="CateringContact">For catering please call 630-766-2221</span> 
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
<script>$(document).ready(function (c) {
    $('.product_desc .close').on('click', function (c) {
        $('.list-group-item1').fadeOut('slow', function (c) {
            $('.list-group-item1').remove();
        });
    });
});
</script>
