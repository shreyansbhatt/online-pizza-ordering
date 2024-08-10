<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentDetail.aspx.cs" Inherits="PaymentDetail" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <link runat="server" rel="shortcut icon" href="/images/logo.ico" type="image/x-icon" />
    <link runat="server" rel="icon" href="/images/logo.ico" type="image/ico" />
    <title>Payment Detail</title>
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

        #txtCreditCardNumber {
            text-transform: none;
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
    <%--<script type="text/javascript">
        function validate() {
            var msg = "";
            if (document.getElementById("<%=txtFirstName.ClientID%>").value == "First Name") {
            document.getElementById("<%=txtFirstName.ClientID%>").style.borderColor = "red";

            //return false;
        }
        else {
            document.getElementById("<%=txtFirstName.ClientID%>").style.borderColor = "white";
            }

            if (document.getElementById("<%=txtLastName.ClientID%>").value == "Last Name") {
                document.getElementById("<%=txtLastName.ClientID%>").style.borderColor = "red";

                //return false;
            }
            else {
                document.getElementById("<%=txtLastName.ClientID%>").style.borderColor = "white";
            }

            
            if (document.getElementById("<%=txtaddress.ClientID%>").value == "Address") {
                document.getElementById("<%=txtaddress.ClientID%>").style.borderColor = "red";

                 //return false;
             }
             else {
                 document.getElementById("<%=txtaddress.ClientID%>").style.borderColor = "white";
            }

            if (document.getElementById("<%=txtCity.ClientID%>").value == "City") {
                document.getElementById("<%=txtCity.ClientID%>").style.borderColor = "red";

                //return false;
            }
            else {
                document.getElementById("<%=txtCity.ClientID%>").style.borderColor = "white";
            }

            if (document.getElementById("<%=txtzip.ClientID%>").value == "Zip") {
                document.getElementById("<%=txtzip.ClientID%>").style.borderColor = "red";

                //return false;
            }
            else {
                document.getElementById("<%=txtzip.ClientID%>").style.borderColor = "white";
            }
        }
    </script>--%>
    <%--    <script type="text/javascript">
        document.getElementById("<%=ErrorMsgDiv.ClientID%>").style.display = "none";
        
        function validate() {
            var msg = "<strong>Error!</strong>";
            if (document.getElementById("<%=txtCreditCardNumber.ClientID%>").value == "Credit Card Number") {
                document.getElementById("<%=txtCreditCardNumber.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=ErrorMsgDiv.ClientID%>").style.display = "block";
                msg = "Please Enter Credit Card Number,";
                document.getElementById("<%=ErrorMsgDiv.ClientID%>").innerHTML = msg;
              
            }
            else {

                document.getElementById("<%=txtCreditCardNumber.ClientID%>").style.borderColor = "white";

            }

            var selectedMonthValue = document.getElementById('<%=DdlMonth.ClientID%>').value;
            
            if (selectedMonthValue == "-1") {
               
                document.getElementById("<%=DdlMonth.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=ErrorMsgDiv.ClientID%>").style.display = "block";
                msg = msg+"Please Select Month,";
                document.getElementById("<%=ErrorMsgDiv.ClientID%>").innerHTML = msg;
                    
           
         } else {
                document.getElementById("<%=DdlMonth.ClientID%>").style.borderColor = "white";
                document.getElementById("<%=ErrorMsgDiv.ClientID%>").style.display = "none";
            }

            var selectedYearValue = document.getElementById('<%=DdlYear.ClientID%>').value;
            if (selectedYearValue == "-1") {
               
                msg = msg+"Please Select Year";
                document.getElementById("<%=DdlYear.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=ErrorMsgDiv.ClientID%>").style.display = "block";
                document.getElementById("<%=ErrorMsgDiv.ClientID%>").innerHTML = msg;
                    
            
         } else {
                document.getElementById("<%=DdlYear.ClientID%>").style.borderColor = "white";
                document.getElementById("<%=ErrorMsgDiv.ClientID%>").style.display = "none";
            }
            if (document.getElementById("<%=txtCreditCardNumber.ClientID%>").value == "Credit Card Number" || selectedMonthValue == "-1" || selectedYearValue == "-1") {
                return false;
            }
            else {
                return true;
            }


        }
    </script>--%>
    <div id="ErrorMsgDiv" class="alert alert-warning" runat="server" style="background-color: #ca3027; color: #ffffff; border-color: #ca3027;">
        <strong>Error!</strong>
    </div>
    <%--<div id="ErrorMsgDivYear" class="alert alert-warning" runat="server" style="background-color:#ca3027;color:#ffffff;border-color:#ca3027;">
      <strong>Error!</strong> 
    </div>--%>
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
                                        <div id="SignInDiv" runat="server"><a href="Login.aspx?PageName=PaymentDetail.aspx"><span id="SpanSignIn" runat="server">sign in</span></a></div>
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
                            <h3>Payment Details</h3>
                            <div class="register-div">
                                <div class="col-md-12">
                                    <div id="login-form">
                                        <div class="form-group">
                                            <label>Payment Options</label>
                                            <%--<input type="radio" name="radio" checked="">--%>
                                            <div class="span_1_of_2">
                                                <asp:RadioButton ID="rdbCOD" runat="server" GroupName="cmsRadio" AutoPostBack="true" OnCheckedChanged="rdbCOD_CheckedChanged" />
                                                <span>Cash</span>
                                            </div>
                                            <%-- <input type="radio" name="radio" class="radio-right">--%>
                                            <div class="span_1_of_2">
                                                <asp:RadioButton ID="rdbCard" runat="server" GroupName="cmsRadio" Checked="true" AutoPostBack="true" OnCheckedChanged="rdbCOD_CheckedChanged" />
                                                <span>Credit Card </span>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                            <asp:Label ID="lblTransType" runat="server"></asp:Label>
                                            <label>Credit Card Number</label>
                                            <%--<input type="text" value="Credit card No" required="required" class="form-control" onFocus="this.value=''" onBlur="(this.value=='')? this.value='Credit card No':this.value;">--%>
                                            <asp:TextBox ID="txtCreditCardNumber" onfocus="(this.value=='Credit Card Number')? this.value='':this.value;" onblur="(this.value=='')? this.value='Credit Card Number':this.value;" runat="server" CssClass="form-control" Style="color: black;">Credit Card Number</asp:TextBox>

                                        </div>
                                        <div class="form-group">
                                            <label>Month</label>
                                            <div class="span_1_of_2">
                                                <asp:DropDownList ID="DdlMonth" runat="server" AutoPostBack="false" AppendDataBoundItems="True" CssClass="form-control" Style="color: black;">
                                                    <asp:ListItem Value="-1">Expiry Month</asp:ListItem>
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
                                                <label>Year</label>

                                                <asp:DropDownList ID="DdlYear" runat="server" AutoPostBack="false" AppendDataBoundItems="True" CssClass="form-control" Style="color: black;">
                                                    <asp:ListItem Value="-1">Expiry Year</asp:ListItem>
                                                    <asp:ListItem>2016</asp:ListItem>
                                                    <asp:ListItem>2017</asp:ListItem>
                                                    <asp:ListItem>2018</asp:ListItem>
                                                    <asp:ListItem>2019</asp:ListItem>
                                                    <asp:ListItem>2020</asp:ListItem>
                                                    <asp:ListItem>2021</asp:ListItem>
                                                    <asp:ListItem>2022</asp:ListItem>
                                                    <asp:ListItem>2023</asp:ListItem>
                                                    <asp:ListItem>2024</asp:ListItem>
                                                    <asp:ListItem>2025</asp:ListItem>
                                                    <asp:ListItem>2026</asp:ListItem>

                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label>CVV Number:</label>
                                            <%--<input type="text" value="Credit card No" required="required" class="form-control" onFocus="this.value=''" onBlur="(this.value=='')? this.value='Credit card No':this.value;">--%>
                                            <asp:TextBox ID="txtcvvnumber" placeholder="CVV Number" onfocus="this.placeholder=''" onblur="this.placeholder='CVV Number'" runat="server" CssClass="form-control" Style="color: black;" TextMode="Password">CVV Number</asp:TextBox>

                                        </div>

                                        <div class="form-group">
                                            <label>First Name:</label>
                                            <%--              <asp:TextBox ID="txtFirstName" onfocus="(this.value=='First Name')? this.value='':this.value;" onblur="(this.value=='')? this.value='Credit Card Number':this.value;" runat="server" CssClass="form-control" Style="color: black;">First Name</asp:TextBox>--%>
                                            <asp:TextBox ID="txtFirstName" runat="server" onfocus="(this.value=='First Name')? this.value='':this.value;" onblur="(this.value=='')? this.value='First Name':this.value;" CssClass="form-control" TabIndex="1" Style="color: black;">First Name</asp:TextBox>

                                        </div>

                                        <div class="form-group">
                                            <label>Last Name:</label>
                                            <asp:TextBox ID="txtLastName" onfocus="(this.value=='Last Name')? this.value='':this.value;" onblur="(this.value=='')? this.value='Last Name':this.value;" runat="server" CssClass="form-control" Style="color: black;">Last Name</asp:TextBox>

                                        </div>

                                        <div class="form-group">
                                            <label>Address:</label>
                                            <asp:TextBox ID="txtaddress" runat="server" CssClass="form-control" onfocus="(this.value=='Address')? this.value='':this.value;" onblur="(this.value=='')? this.value='Address':this.value;" Style="color: black;">Address</asp:TextBox>
                                        </div>

                                        <div class="form-group">
                                            <label>City:</label>
                                            <div class="span_1_of_2">
                                                <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" onfocus="(this.value=='City')? this.value='':this.value;" onblur="(this.value=='')? this.value='City':this.value;" Height="38px" Style="color: black;">City</asp:TextBox>
                                            </div>

                                            <div class="span_1_of_2">
                                                <label>State</label>

                                                <asp:DropDownList Style="color: black;" ID="DdlState" runat="server" AutoPostBack="False" AppendDataBoundItems="True" CssClass="form-control" TabIndex="11">
                                                    <asp:ListItem Value="-1">Select State</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label>Zip:</label>
                                            <asp:TextBox ID="txtzip" runat="server" MaxLength="7" CssClass="form-control" onfocus="(this.value=='Zip')? this.value='':this.value;" onblur="(this.value=='')? this.value='Zip':this.value;" Height="38px" Style="color: black;">Zip</asp:TextBox>
                                        </div>

                                        <%--<div class="form-group">
			<label>Amount</label>
             <input type="text" value="Amount" required="required" class="form-control" onFocus="this.value=''" onBlur="(this.value=='')? this.value='Amount':this.value;">
                
            </div>--%>

                                        <div class="form-group">
                                            <label></label>
                                            <asp:Button ID="btnSubmit" CssClass="submit-btn" runat="server" Text="submit" OnClick="btnSubmit_Click" OnClientClick="return validate()" />
                                            <%-- <input type="submit" value="submit" class="submit-btn">--%>
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
