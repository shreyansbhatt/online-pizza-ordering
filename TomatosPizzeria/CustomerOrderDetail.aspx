<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerOrderDetail.aspx.cs" Inherits="CustomerOrderDetail" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <link runat="server" rel="shortcut icon" href="/images/logo.ico" type="image/x-icon" />
    <link runat="server" rel="icon" href="/images/logo.ico" type="image/ico" />
    <title>Customer Order Online</title>
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
    <link href="css/StyleSheetForCustomerOrder.css" rel="stylesheet" type="text/css">

    <script type="text/javascript">
        function HelloAlert() {

            document.getElementById('<%=btnCurrentOrder.ClientID%>').click();
        }

        //function ChnageColor()
        //{
        //    alert("hi");
        //    var ul = $("#OrderTab");
        //    ul.on('focus', 'li', function () {

        //        $(this)
        //            .css("background-color", "#FFFF00");
        //    });
        //}
    </script>
    <script type="text/javascript">
        function HideLabel() {
            var seconds = 5;
            setTimeout(function () {

                document.getElementById("<%=CancelOrderdDiv.ClientID %>").style.display = "none";
                document.getElementById("<%=OrderCancelSuccess.ClientID %>").style.display = "none";
            }, seconds * 1000);

            // alert("You Can Not Cancel Order Because Order Wish Time is not more than hour or later.");
        };

    </script>
    <style type="text/css">
        .apply_btn:hover {
            border: none;
            border-radius: 0px;
            color: #ffffff;
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
          .btn-danger.active.focus, .btn-danger.active:focus, .btn-danger.active:hover, .btn-danger:active.focus, .btn-danger:active:focus, .btn-danger:active:hover, .open > .dropdown-toggle.btn-danger.focus, .open > .dropdown-toggle.btn-danger:focus, .open > .dropdown-toggle.btn-danger:hover {
            color: #fff;
            background-color: #ca3027 !important;
            border-color: #ca3027 !important;
            border-radius: 0px;
        }
        .nav-tabs > li.active > a, .nav-tabs > li.active > a:hover, .nav-tabs > li.active > a:focus {
            color: #ffffff;
        }

        .nav > li > #lnkHome:focus, .nav > li > #lnkHome:hover {
            text-decoration: none;
            background-color: #ca3027 !important;
        }

        .nav > li > #lnkOrderOnline:focus, .nav > li > #lnkOrderOnline:hover {
            text-decoration: none;
            background-color: #ca3027 !important;
        }

        .nav > li > #lnkMenu:focus, .nav > li > #lnkMenu:hover {
            text-decoration: none;
            background-color: #ca3027 !important;
        }

        .nav > li > #lnkOffers:focus, .nav > li > #lnkOffers:hover {
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

        .product_detail .heading {
            padding: 1em 0px;
            background: rgb(255, 255, 255) none repeat scroll 0% 0%;
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
                margin: 0px;
            }

            .privacy-section ul {
                text-align: left;
                float: left;
                margin-left: -8px;
            }
        }
    </style>
    <div id="CancelOrderdDiv" class="alert alert-warning" runat="server" style="background-color: #ca3027; color: #ffffff; border-color: #ca3027;">
        <strong>Error!</strong>You Can Not Cancel Order Because Order Wish Time is not more than hour or later.
    </div>
    <div id="OrderCancelSuccess" class="alert alert-success" runat="server">
        <strong>Error!</strong>Order Cancel Successfully.
    </div>
</head>

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
                                    <li><a href=""><span class="facebook"></span></a></li>
                                    <li><a href=""><span class="google-plus"></span></a></li>
                                    <li><a href=""><span class="linkedin"></span></a></li>
                                    <li><a href=""><span class="youtube"></span></a></li>
                                </ul>
                                <ul class="login-div">
                                    <li class="dropdown" style="margin-left:3px;">
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
                                        <div id="SignInDiv" runat="server"><a href="Login.aspx?PageName=ResetPassword.aspx"><span id="SpanSignIn" runat="server">sign in</span></a></div>
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
                                        <li class="order" id="liorderOnline">
                                            <asp:LinkButton runat="server" ID="lnkOrderOnline" Text="Order Online" OnClick="lnkOrderOnline_Click"></asp:LinkButton></li>
                                        <li>
                                            <asp:LinkButton runat="server" ID="lnkHome" Text="Home" OnClick="lnkHome_Click"></asp:LinkButton></li>
                                        <li>
                                            <asp:LinkButton runat="server" ID="lnkMenu" OnClick="lnkMenu_Click" OnClientClick="return true">Menu</asp:LinkButton></li>
                                        <li>
                                            <asp:LinkButton runat="server" ID="lnkOffers" Text="Offers" OnClick="lnkOffers_Click"></asp:LinkButton></li>

                                    </ul>
                                </div>
                                <div class="navbar-brand">
                                    <img src="images/logo.png" class="img-responsive">
                                </div>
                            </div>
                        </div>
                    </nav>



                    <%--<div class="main order-online">

                        <!------------------------------- cart starts------------------------------->

                        <div class="modal fade my_cart" id="cart" role="dialog">
                            <div class="modal-dialog modal-lg">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                        <div class="cart_header">
                                            <h4>My Cart </h4>
                                        </div>
                                    </div>
                                    <div class="product_detail">
                                        <div class="list-group">
                                            <div class="alert alert-default">
                                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                                <div class="product_desc" id="1123">
                                                    <div class="row row1">
                                                        <div class="col-md-8 col-sm-6"><span class="selected_prdct">Pizza</span></div>
                                                        <div class="col-md-2 col-sm-2"><span class="price_prdct">$39</span></div>
                                                        <div class="col-md-2 col-sm-2">
                                                            <span class="product_quantity">
                                                                <input type="number" value="1" maxlength="5">
                                                            </span>
                                                        </div>
                                                    </div>
                                                    <div class="row row2">
                                                        <div class="col-md-8 col-sm-6">
                                                            <div id="ing_spec">
                                                                <span class="red_font">Default Ingredients</span> -<span id="default_ing"> Jalapeno </span></br>
						
						<span class="red_font">Extra Ingredients </span>
                                                                <div class="table-responsive">
                                                                    <table class="table-bordered extra-ing-list">
                                                                        <tr>
                                                                            <th class="cell">Name</th>
                                                                            <th class="cell">Price</th>
                                                                        </tr>
                                                                        <tr id="112">
                                                                            <td class="cell" id="t11">Tomato</td>
                                                                            <td class="cell" id="p11">$1.50</td>
                                                                        </tr>
                                                                        <tr id="113">
                                                                            <td class="cell" id="c11">Cabbage</td>
                                                                            <td class="cell" id="p22">$2.50</td>
                                                                        </tr>
                                                                        <tr id="114">
                                                                            <td class="cell" id="c22">Cheese</td>
                                                                            <td class="cell" id="p331">$3.00</td>
                                                                        </tr>
                                                                        <tr id="115">
                                                                            <td class="cell" id="c33">Corn</td>
                                                                            <td class="cell" id="p44">$1.00</td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-2 col-sm-2"><span id="size">[14'']</span></div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="alert alert-default">
                                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                                <div class="product_desc" id="1123">
                                                    <div class="row row1">
                                                        <div class="col-md-8 col-sm-6"><span class="selected_prdct">Pizza</span></div>
                                                        <div class="col-md-2 col-sm-2"><span class="price_prdct">$39</span></div>
                                                        <div class="col-md-2 col-sm-2">
                                                            <span class="product_quantity">
                                                                <input type="number" value="1" maxlength="5">
                                                            </span>
                                                        </div>
                                                    </div>
                                                    <div class="row row2">
                                                        <div class="col-md-8 col-sm-6">
                                                            <div id="ing_spec">
                                                                <span class="red_font">Default Ingredients</span> -<span id="default_ing"> Jalapeno </span></br>
						
						<span class="red_font">Extra Ingredients </span>
                                                                <div class="table-responsive">
                                                                    <table class="table-bordered extra-ing-list">
                                                                        <tr>
                                                                            <th class="cell">Name</th>
                                                                            <th class="cell">Price</th>
                                                                        </tr>
                                                                        <tr id="112">
                                                                            <td class="cell" id="t11">Tomato</td>
                                                                            <td class="cell" id="p11">$1.50</td>
                                                                        </tr>
                                                                        <tr id="113">
                                                                            <td class="cell" id="c11">Cabbage</td>
                                                                            <td class="cell" id="p22">$2.50</td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-2 col-sm-2"><span id="size">[14'']</span></div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="product_charges">
                                            <div class="product_price"><span>Total: </span><span id="price" class="tax_value">$56.00</span></div>
                                            <div class="sales_tax"><span>Sales Tax: </span><span id="s-tax" class="tax_value">$5.00</span></div>
                                            <div class="delivery_tax"><span>delivery Charges: </span><span id="d-tax" class="tax_value">$6.00</span></div>
                                            <div class="total_price"><span><strong>Total Price: </strong></span><span id="t-price" class="tax_value">$67.00</span></div>
                                            <button type="button" class="place_order_btn pull-right">Place Order</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <script>
                            $(document).ready(function () {
                                $('.cart_header').click(function () {
                                    $('.affix').remove();
                                });
                            });
                        </script>
                        <script>
                            $(document).ready(function () {
                                $('.cart_header .close').click(function () {
                                    $('.collapse').hide();
                                    location.reload();
                                });
                            });
                        </script>
                        <div class="clearfix"></div>
                    </div>--%>
                    <div class="inner-div customer-order">
                        <ul class="nav nav-tabs">
                            <li style="background-color:white;color:red;" class="active" onclick="HelloAlert();" runat="server" id="IdCur"><a href="#current" data-toggle="tab">Current Orders</a></li>
                            <li style="background-color:white;color:red;"><a href="#past" data-toggle="tab">Past Orders</a></li>
                        </ul>
                        <asp:Button ID="btnCurrentOrder" Style="display: none" runat="server" OnClick="btnCurrentOrder_Click" />
                        <div class="user-login">

                            <div class="tab-content">

                                <!------------------------ Current Orders tab------------------------------------>
                                <div class="tab-pane fade in active" id="current">
                                    <div class="product_detail">
                                        <div class="list-group">
                                            <div class="row heading" id="RowHeadingCurrent" runat="server" visible="false" style="margin-left:5px;">
                                                <asp:Label ID="lblOpenOrderNoSource" runat="server" Visible="false" CssClass="nodataFound" Text="No  Order Found!!!" Style="color: red;float:left;"></asp:Label>
                                            </div>
                                            <asp:Repeater ID="rptOpenOrderListOfUSer" runat="server" OnItemDataBound="rptOpenOrderListOfUSer_ItemDataBound" OnItemCommand="rptOpenOrderListOfUSer_ItemCommand">
                                                <ItemTemplate>
                                                    <div class="alert alert-default">
                                                        <asp:Label ID="lblOrderId" runat="server" Text='<%# Eval("OrderId") %>' Style="display: none"></asp:Label>



                                                        <div class="row heading">
                                                            <div class="col-md-10">
                                                                <asp:Label ID="lblOrderNumber" runat="server" Text='<%# "Order No:"+Eval("OrderNumber") %>'></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <asp:LinkButton ID="BtnCancelOrder" runat="server" class="btn btn-danger active" Text="Cancel Order" CommandArgument='<%# Eval("OrderId") %>' CommandName="CancelOrder"></asp:LinkButton>
                                                                <%--<button type="submit" class="btn btn-danger active">Cancel Order</button>--%>
                                                            </div>
                                                        </div>

                                                        <asp:Repeater ID="rptOpenOrder" runat="server" OnItemDataBound="rptOpenOrder_ItemDataBound">

                                                            <HeaderTemplate>
                                                            </HeaderTemplate>

                                                            <ItemTemplate>

                                                                <asp:Label ID="lblProductdetailId" runat="server" Text='<%# Eval("ProductdetailId") %>' Style="display: none"></asp:Label>

                                                                <div class="product_desc" id="1123">
                                                                    <div class="row row1">
                                                                        <div class="col-md-8 col-sm-6">
                                                                            <span class="selected_prdct">
                                                                                <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label></span>
                                                                        </div>
                                                                        <div class="col-md-2 col-sm-2">
                                                                            <span class="price_prdct">
                                                                                <asp:Label ID="Label3" runat="server" Text='<%#"$"+ Eval("Price") %>'></asp:Label></span>
                                                                        </div>
                                                                        <div class="col-md-2 col-sm-2">
                                                                            <span class="product_quantity">
                                                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                                                                            </span>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row row2">
                                                                        <div class="col-md-8 col-sm-6">
                                                                            <div id="ing_spec">
                                                                                <span class="red_font">Default Ingredients</span> -<span id="default_ing">
                                                                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("IngredientName") %>'></asp:Label></span></br>
						
						                                                <span class="red_font">Extra Ingredients </span>
                                                                                <div class="table-responsive">
                                                                                    <asp:GridView ID="gvExtraIngeredient" runat="server" AutoGenerateColumns="false" AllowSorting="true" class="table-bordered extra-ing-list">

                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="Name">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblIngredientName" runat="server" Text='<%# Eval("ExtraIngredient") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>

                                                                                            <asp:TemplateField HeaderText="Price">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblIngredientPrice" runat="server" Text='<%# "$ " + Eval("IngredientPrice")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <EmptyDataTemplate>
                                                                                            No Extra Ingredient Added
                                                                                        </EmptyDataTemplate>
                                                                                    </asp:GridView>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-2 col-sm-2">
                                                                            <span id="size">
                                                                                <asp:Label ID="Label2" runat="server" Text='<%#"["+ Eval("SizeName")+"]" %>'></asp:Label></span>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                            </ItemTemplate>

                                                        </asp:Repeater>

                                                    </div>

                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>

                                    </div>
                                </div>
                                <!------------------------ Past Orders tab------------------------------------>


                            <div class="tab-pane fade" id="past">
                                    <div class="product_detail">
                                        <div class="list-group">
                                            <div class="row heading" id="RowHeadingPast" runat="server" visible="false" style="margin-left:5px;">
                                                <asp:Label ID="lblPastOrder" runat="server" Visible="false" CssClass="nodataFound" Text="No  Past Found!!!" Style="color: red;float:left;"></asp:Label>
                                            </div>
                                            <asp:Repeater ID="rptPreviousOrder" runat="server" OnItemDataBound="rptPreviousOrder_ItemDataBound" >
                                                <ItemTemplate>
                                                    <div class="alert alert-default">
                                                        <asp:Label ID="lblOrderId" runat="server" Text='<%# Eval("OrderId") %>' Style="display: none"></asp:Label>



                                                        <div class="row heading">
                                                            <div class="col-md-10">
                                                                <asp:Label ID="lblOrderNumberPast" runat="server" Text='<%# "Order No:"+Eval("OrderNumber") %>'></asp:Label>
                                                            </div>
                                                           <%-- <div class="col-md-2">
                                                                <asp:LinkButton ID="BtnCancelOrder" runat="server" class="btn btn-danger active" Text="Cancel Order" CommandArgument='<%# Eval("OrderId") %>' CommandName="CancelOrder"></asp:LinkButton>
                                                                 </div>--%>
                                                        </div>

                                                        <asp:Repeater ID="rptPreviousOrderItem" runat="server" OnItemDataBound="rptPreviousOrderItem_ItemDataBound">

                                                            <HeaderTemplate>
                                                            </HeaderTemplate>

                                                            <ItemTemplate>

                                                                <asp:Label ID="lblProductdetailId" runat="server" Text='<%# Eval("ProductdetailId") %>' Style="display: none"></asp:Label>

                                                                <div class="product_desc" id="1123">
                                                                    <div class="row row1">
                                                                        <div class="col-md-8 col-sm-6">
                                                                            <span class="selected_prdct">
                                                                                <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label></span>
                                                                        </div>
                                                                        <div class="col-md-2 col-sm-2">
                                                                            <span class="price_prdct">
                                                                                <asp:Label ID="Label3" runat="server" Text='<%#"$"+ Eval("Price") %>'></asp:Label></span>
                                                                        </div>
                                                                        <div class="col-md-2 col-sm-2">
                                                                            <span class="product_quantity">
                                                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                                                                            </span>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row row2">
                                                                        <div class="col-md-8 col-sm-6">
                                                                            <div id="ing_spec">
                                                                                <span class="red_font">Default Ingredients</span> -<span id="default_ing">
                                                                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("IngredientName") %>'></asp:Label></span></br>
						
						                                                <span class="red_font">Extra Ingredients </span>
                                                                                <div class="table-responsive">
                                                                                    <asp:GridView ID="gvExtraIngeredient" runat="server" AutoGenerateColumns="false" AllowSorting="true" class="table-bordered extra-ing-list">

                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="Name">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblIngredientName" runat="server" Text='<%# Eval("ExtraIngredient") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>

                                                                                            <asp:TemplateField HeaderText="Price">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblIngredientPrice" runat="server" Text='<%# "$ " + Eval("IngredientPrice")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <EmptyDataTemplate>
                                                                                            No Extra Ingredient Added
                                                                                        </EmptyDataTemplate>
                                                                                    </asp:GridView>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-2 col-sm-2">
                                                                            <span id="size">
                                                                                <asp:Label ID="Label2" runat="server" Text='<%#"["+ Eval("SizeName")+"]" %>'></asp:Label></span>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                            </ItemTemplate>

                                                        </asp:Repeater>

                                                    </div>

                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>

                                    </div>
                                </div>

                            </div>
                        </div>
                        <!-----------------------Category-details ends------------------------------>

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

                <%--  </div>--%>
    </form>
</body>
</html>
