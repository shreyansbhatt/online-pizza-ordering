<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderOnline.aspx.cs" Inherits="OrderOnline" EnableEventValidation="false" ClientIDMode="Static" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <link runat="server" rel="shortcut icon" href="/images/logo.ico" type="image/x-icon" />
    <link runat="server" rel="icon" href="/images/logo.ico" type="image/ico" />
    <title>Order Online</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="X-UA-Compatible" content="IE=9; IE=8; IE=7; IE=Edge,chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8, IE=9, chrome=1" />
    <!-- Latest compiled and minified JavaScript -->
    <script src="js/jquery-1.11.1.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
    <link href="css/bootstrap.min.css" rel='stylesheet' type='text/css' />
    <link href="css/style.css" rel='stylesheet' type='text/css' />
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css">
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">


    <script type="text/javascript">
        function ValidatePopUp()
        {
            var selectedQuantity = document.getElementById("ddlQuantityPop");
            var selectedValue = selectedQuantity.options[selectedQuantity.selectedIndex].value;
            if (selectedValue == "-1") {
                alert('Please select quantity before adding to cart');
                return false;
            }

            //var selectedSauce = document.getElementById("ddlWingSouce");
            //alert(selectedSauce.visible);
            //if(selectedSauce.style.visibility == "visible" && selectedSauce.options[selectedSauce.selectedIndex].value == "-1")
            //{
            //    alert('Please select Buffalo wing sauce from the list');
            //    return false;
            //}


        }
    </script>

    <script type="text/javascript">
        function Confirm() {

            var hdnfldVariable = document.getElementById("<%=hdnfldVariable.ClientID %>");

            if (confirm("Are you sure you want to delete Item From Cart?")) {

                hdnfldVariable.value = "Yes";

            } else {

                hdnfldVariable.value = "No";
            }

        }
        function DisableBackButton() {
            window.history.forward();
        }
        setTimeout("DisableBackButton()", 0);
        window.onunload = function () { null };
        $(document).ready(function () {
            $(document).keyup(function (e) {

                if (e.keyCode == 27) {

                    $("#btnclose.close").click();


                }
            });
        });
    </script>

    <script type="text/javascript">
        function dopostback() {
            __doPostBack('lnkSize', '')
        }
    </script>

    <script type="text/javascript">
        function GetClientID(asp_net_id) {
            //  alert(asp_net_id);
            var splitId = asp_net_id.toString().split('_');

            var idIndex = splitId[4].toString();
            var dataListIndex = splitId[2].toString();

            var requiredDiv = document.getElementById("rptIngredients_dlIngredientList_" + dataListIndex + "_toppingDiv_" + idIndex);
            //  alert(requiredDiv);
           
            var clickedCB = document.getElementById(asp_net_id);
            if (clickedCB.checked) {
                requiredDiv.style.visibility = "visible";
                if (document.getElementById("lblModalHeader").innerText.startsWith("Fresh Salads"))
                {
                    requiredDiv.style.visibility = "collapse";
                }
            }
            else
                requiredDiv.style.visibility = "collapse";
            // return $("[id$=" + asp_net_id + "]").attr("id");
            //alert(document.getElementById(asp_net_id).outerHTML);
        }
    </script>

    <script type="text/javascript">
        function cip(val) {
            try {
                var splitVal = val.toString().split('_')
                var ingPriceIndex = splitVal[2].toString();
                alert(ingPriceIndex);
                var getPriceToCalc = document.getElementById("rptIngredients_divIngredientGroupPrice_" + ingPriceIndex).innerText;
                alert(getPriceToCalc);
                var priceToCalc = getPriceToCalc.substring(getPriceToCalc.indexOf("$") + 1, getPriceToCalc.length);
                alert(priceToCalc);
                alert(parseFloat(priceToCalc));
                var result = 0;
                if (parseFloat(priceToCalc) != null) {

                    if (splitVal[3].toString() == "radioFull") {
                        result = parseFloat(priceToCalc) * 1;
                        //alert(result);
                    }
                    else if (splitVal[3].toString() == "radioFhalf") {
                        result = parseFloat(priceToCalc) * 0.5;
                        //alert(result);
                    }
                    else if (splitVal[3].toString() == "radioShalf") {
                        result = parseFloat(priceToCalc) * 0.5;
                    }
                }

                // Instead pass the values directly to cart.
                //var headerString = document.getElementById("lblSelectedPizzaHeader").innerText;

                //var pizzaPrice = headerString.substring(headerString.indexOf("$") + 1, headerString.length);
                //alert(pizzaPrice);

                //var newPrice = parseFloat(parseFloat(result) + parseFloat(pizzaPrice));
                //alert(newPrice);

                //var splitHeaderString = headerString.split('-');
                //var newHeaderString = splitHeaderString[0].trim() + " - " + "$" + newPrice;
                ////alert(newHeaderString);
                //alert(newHeaderString);
                //document.getElementById("lblSelectedPizzaHeader").innerText = newHeaderString;

            }
            catch (e) {
                alert(e.toString());
            }
            //alert(val);
            //alert(document.getElementById("rptIngredients_divIngredientGroupPrice").innerText);
            //alert(val);
        }
    </script>

    <script type="text/javascript">
        history.pushState(null, null, 'OrderOnline');
        window.addEventListener('popstate', function (event) {
            history.pushState(null, null, 'OrderOnline');
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            //alert(window.innerHeight);
            //alert(window.innerWidth);
            document.getElementById('<%= myHiddenField.ClientID %>').value = window.innerWidth;
        })

    </script>

    <script type="text/javascript">
        $(document).on("click", ".open-AddBookDialog", function () {
            var myBookId = $(this).data('id');
            $(".modal-body #hdnSizeInfo").val(myBookId);
            var myBookId2 = $(this).data('id2');
            $(".modal-body #lblSelectedPizzaHeader").text(myBookId2);

            //var myBookId3 = $(this).data('id3');
            //$(".modal-body #txtEmail").val(myBookId3);

        });
    </script>

    <script type="text/javascript">
        function openModal(a, b) {
            $('#size-modal').modal({
                backdrop: 'static',
                keyboard: false
            })
            $('#size-modal').modal('show');
            
            if (b.toString() == "price") {
                var varprice = a.toString().split(',');
                for (var i = 0; i < varprice.length; i++) {
                    var headerString = document.getElementById("lblSelectedPizzaHeader").innerText;
                    headerString = headerString + " - " + "$" + varprice[0];
                    document.getElementById("lblSelectedPizzaHeader").innerText = headerString;
                    document.getElementById("<%= hdnPizzaPrice.ClientID %>").value = headerString;
                }
            }
            else {
                var select = document.getElementById("ddlSizePop");
                var options = [];
                var option = document.createElement('option');
                // alert(a);
                //var a = document.getElementById("hdnPassValue");
                var idValue = a.toString().split(',');

                for (var i = 0; i < idValue.length; i++) {
                    var abstractidValue = idValue[i].toString().split(':');

                    //   alert(abstractidValue);
                    option.text = abstractidValue[1].toString();
                    option.value = abstractidValue[0];
                    options.push(option.outerHTML);

                    if (i == 0) {
                        var firstSizePrice = abstractidValue[0].toString().split('#');
                        var headerString = document.getElementById("lblSelectedPizzaHeader").innerText;
                        headerString = headerString + " - " + "$" + firstSizePrice[1];

                        document.getElementById("<%= hdnSelectedSize.ClientID %>").value = firstSizePrice[0].toString();
                        document.getElementById("lblSelectedPizzaHeader").innerText = headerString;
                        document.getElementById("<%= hdnPizzaPrice.ClientID %>").value = headerString;
                    }
                }
                select.insertAdjacentHTML('beforeEnd', options.join('\n'));

            }


        }
    </script>

    <script type="text/javascript">
        function ddlSizePopOnChange(val) {

            // alert(val);
            var sizePrice = val.toString().split('#');
            document.getElementById("<%= hdnSelectedSize.ClientID %>").value = sizePrice[0];

            var headerString = document.getElementById("lblSelectedPizzaHeader").innerText;
            var splitHeaderString = headerString.split('-');
            // alert(splitHeaderString);
            var newHeaderString = splitHeaderString[0].trim() + " - " + "$" + sizePrice[1];
            //alert(newHeaderString);
            document.getElementById("lblSelectedPizzaHeader").innerText = newHeaderString;
            document.getElementById("<%= hdnPizzaPrice.ClientID %>").value = newHeaderString;
        }
    </script>

    <script type="text/javascript">
        function ddlWingSouceChange(val)
        {
            if (val.options[val.selectedIndex].text != "Select Wing Souce") {
                document.getElementById("<%= txtComment.ClientID %>").value = "Selected Buffalo wing souce: " + val.options[val.selectedIndex].text;
            }
        }
    </script>

    <style type="text/css">
        /*@media screen and (max-width:1960px) and (min-width:991px) {
             table#dlIngredientList{
                margin-left:30px;
                table-layout: fixed; width: auto;
        }
            
            }
        @media screen and (max-width:992px) and (min-width:650px) {
            table#dlIngredientList{
                margin-left:-20px;
                table-layout: fixed; width: auto;
            }
           table#dlIngredientList td{
               max-height:61px;
           }
        }*/
    </style>
    <style type="text/css">
        /*.navbar {
    background-color: rgba(255, 255, 255, 0.19);background-image: url(../images/bg.jpg) !important;
    
}*/
        .category_details .ingredients_option_list {
            height: 380px;
            overflow: scroll;
            /*overflow-x:hidden;
            overflow-y:scroll;*/
        }

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
            width: 20%;
        }

        .add_cart:hover {
            border: none;
            border-radius: 0px;
        }

        .add_cart {
            border-radius: 5px;
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

        .order-onlie-section .nav-pills > li > a:hover {
            background: #ffffff !important;
            color: red;
            border-radius: 0px !important;
        }

        .nav-pills > li > a {
            color: red;
        }

        a:hover, a:focus {
            color: red;
            text-decoration: underline;
        }

        .navbar-nav > li.order a {
            text-transform: uppercase;
            font-size: 14px;
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

        /*.header {
            position: fixed;
            float: left;
            z-index: 9999;
            background: rgba(35, 35, 39, 0.94) none repeat scroll 0% 0%;
            width: 76%;
            height: 200px;
            top: 0px;
        }

        @media only screen and (min-width:1680px) {
            .header {
                width: 54%;
            }
        }

        @media only screen and (min-width:1580px) and (max-width:1660px) {
            .header {
                width: 65%;
            }
        }


        @media only screen and (min-width:1400px) and (max-width:1570px) {
            .header {
                width: 70%;
            }
        }

        @media only screen and (min-width:1300px) and (max-width:1400px) {
            .header {
                width: 75%;
            }
        }

        @media only screen and (max-width:1024px) {
            .header {
                width: 82%;
            }
        }

        @media only screen and (max-width:980px) {
            .header {
                width: 75%;
                height: 135px;
            }
        }

        @media only screen and (max-width:800px) {
            .header {
                width: 82%;
                height: 160px;
            }
        }

        @media only screen and (max-width:768px) {
            .header {
                width: 85%;
            }
        }*/
        @media only screen and (min-width:1025px) and (max-width:1199px) {
            .header {
                width: 76%;
            }
        }

        #ingredient_list .add_cart {
            background: #ca3027;
            color: #ffffff;
            padding: 0.6em 1em;
            border: none;
            float: right;
        }

        @media only screen and (min-width:769px) and (max-width:800px) {
            #ingredient_list .add_cart {
                float: left;
            }
        }

        @media only screen and (min-width:982px) and (max-width:1200px) {
            #ingredient_list .add_cart {
                float: left;
            }
        }

        @media only screen and (max-width:616px) {
            #ingredient_list .add_cart {
                float: left;
            }

            #liorderOnline {
                height: 60px;
                width: 157px;
            }
        }

        @media only screen and (max-width:480px) {
            #ingredient_list .add_cart {
                padding: 0.6em;
            }
        }

        @media only screen and (max-width:360px) {
            #ingredient_list .add_cart {
                float: left;
            }
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

            #txtQuantity {
                margin-top: 10px;
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

        @media only screen and (max-width:1247px) {
            #TopContactDetail {
                width: 133%;
            }
        }

        @media only screen and (max-width:854px) {
            #TopContactDetail {
                width: 134%;
            }
        }

        @media only screen and (max-width:845px) {
            #TopContactDetail {
                width: 135%;
            }
        }

        @media only screen and (max-width:845px) {
            #TopContactDetail {
                width: 139%;
            }
        }

        @media only screen and (max-width:825px) {
            #TopContactDetail {
                width: 140%;
            }
        }

        @media only screen and (max-width:819px) {
            #TopContactDetail {
                width: 141%;
            }
        }

        @media only screen and (max-width:814px) {
            #TopContactDetail {
                width: 142%;
            }
        }

        @media only screen and (max-width:809px) {
            #TopContactDetail {
                width: 143%;
            }
        }

        @media only screen and (max-width:804px) {
            #TopContactDetail {
                width: 145%;
            }
        }

        @media only screen and (max-width:480px) and (min-width:359px) {
            #TopContactDetail {
                width: 100%;
            }
        }

        @media only screen and (max-width:360px) and (min-width:347px) {
            #TopContactDetail {
                width: 113%;
                margin-left: -2px;
            }
        }

        @media only screen and (max-width:346px) and (min-width:345px) {
            #TopContactDetail {
                width: 114%;
                margin-left: -4px;
            }
        }

        @media only screen and (max-width:344px) and (min-width:342px) {
            #TopContactDetail {
                width: 116%;
                margin-left: -4px;
            }
        }

        @media only screen and (max-width:341px) and (min-width:341px) {
            #TopContactDetail {
                width: 116%;
                margin-left: -4px;
            }
        }

        @media only screen and (max-width:340px) and (min-width:339px) {
            #TopContactDetail {
                width: 117%;
                margin-left: -4px;
            }
        }

        @media only screen and (max-width:338px) and (min-width:334px) {
            #TopContactDetail {
                width: 119%;
                margin-left: -4px;
            }

            .navbar-nav > li.order a {
                text-transform: uppercase;
                font-size: 12px;
                padding: 15px 30px;
            }
        }

        @media only screen and (max-width:333px) and (min-width:332px) {
            #TopContactDetail {
                width: 120%;
                margin-left: -4px;
            }

            .navbar-nav > li.order a {
                text-transform: uppercase;
                font-size: 12px;
                padding: 15px 30px;
            }
        }

        @media only screen and (max-width:331px) and (min-width:330px) {
            #TopContactDetail {
                width: 121%;
                margin-left: -4px;
            }

            .navbar-nav > li.order a {
                text-transform: uppercase;
                font-size: 12px;
                padding: 15px 30px;
            }
        }

        @media only screen and (max-width:329px) and (min-width:327px) {
            #TopContactDetail {
                width: 122%;
                margin-left: -4px;
            }

            .navbar-nav > li.order a {
                text-transform: uppercase;
                font-size: 12px;
                padding: 15px 30px;
            }
        }

        @media only screen and (max-width:326px) {
            #TopContactDetail {
                width: 122%;
                margin-left: -4px;
            }

            .navbar-nav > li.order a {
                text-transform: uppercase;
                font-size: 12px;
                padding: 15px 30px;
            }
        }

        @media only screen and (max-width:325px) {
            #TopContactDetail {
                width: 123%;
                margin-left: -4px;
            }

            .navbar-nav > li.order a {
                text-transform: uppercase;
                font-size: 12px;
                padding: 15px 30px;
            }
        }

        @media only screen and (max-width:324px) {
            #TopContactDetail {
                width: 123%;
                margin-left: -4px;
            }

            .navbar-nav > li.order a {
                text-transform: uppercase;
                font-size: 12px;
                padding: 15px 30px;
            }
        }

        @media only screen and (max-width:323px) {
            #TopContactDetail {
                width: 124%;
                margin-left: -4px;
            }

            .navbar-nav > li.order a {
                text-transform: uppercase;
                font-size: 12px;
                padding: 15px 30px;
            }
        }

        @media only screen and (max-width:405px) {
            #liorderOnline {
                height: 60px;
                width: 126px;
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
                margin: 8px 8px 8px 40px;
            }

            .privacy-section ul {
                text-align: left;
                float: left;
                margin-left: -8px;
            }
        }

        #btnNo {
            margin-left: 35px;
        }

        @media only screen and (max-width:1023px) {
            #btnNo {
                margin-left: 10px;
            }
        }

        @media only screen and (max-width:992px) {
            #btnNo {
                margin-left: 20px;
            }

            #btnYes {
                margin-left: -68px;
            }
        }

        @media only screen and (max-width:483px) {
            #btnNo {
                margin-left: 22px;
            }

            #btnYes {
                margin-left: 21px;
            }
        }

        @media only screen and (max-width:464px) {
            #btnNo {
                margin-left: 8px;
            }

            #btnYes {
                margin-left: 8px;
            }
        }

        @media only screen and (max-width:433px) {
            #btnNo {
                margin-left: -7px;
            }

            #btnYes {
                margin-left: -7px;
            }
        }

        @media only screen and (max-width:373px) {
            #btnNo {
                margin-left: -30px;
            }

            #btnYes {
                margin-left: -30px;
            }
        }

        @media only screen and (max-width:314px) {
            #btnNo {
                margin-left: -45px;
            }

            #btnYes {
                margin-left: -45px;
            }
        }

        @media only screen and (max-width:2500px) {
            #lblMessage1 {
                margin-left: -65px;
            }
        }

        @media only screen and (max-width:1200px) {
            #lblMessage1 {
                margin-left: 19px;
            }
        }

        @media only screen and (max-width:1022px) {
            #lblMessage1 {
                margin-left: 112px;
            }
        }

        @media only screen and (max-width:992px) {

            #lblMessage1 {
                margin-left: -22px;
            }
        }

        @media only screen and (max-width:978px) {

            #lblMessage1 {
                margin-left: -67px;
            }
        }

        @media only screen and (max-width:731px) {

            #lblMessage1 {
                margin-left: -32px;
            }
        }

        @media only screen and (max-width:680px) {

            #lblMessage1 {
                margin-left: -32px;
            }
        }

        @media only screen and (max-width:483px) {
            #lblMessage1 {
                margin-left: 16px;
            }
        }

        @media only screen and (max-width:424px) {

            #lblMessage1 {
                margin-left: 48px;
            }
        }

        @media only screen and (max-width:404px) {

            #lblMessage1 {
                margin-left: -12px;
            }
        }

        @media only screen and (max-width:338px) {

            #lblMessage1 {
                margin-left: 18px;
            }
        }
        /*@media only screen and (max-width:480px) {
            .category_details .ingredients_option_list {
                height: 150px;
                width: 500px;
            }

            .order-onlie-section .category_details {
                height: 200px;
                overflow: scroll;
                width: 100%;
            }
        }*/
    </style>
    <script type="text/javascript">
        var myInput = document.getElementById("txtComment");
        if (myInput != null) {
            myInput.onfocus = function () {
                this.style.backgroundColor = "red";
            }
        }
    </script>

    <script type="text/javascript">
        //$(document).ready(function () {
        //    $("#lnkSize").click(function () {
        //        alert("Hi from Linksize");
        //        $('html,body').animate({
        //            scrollTop: $("#factDiv").offset().top
        //        },
        //            'slow');
        //    });
        //})
        //$(document).ready(function () {
        //    $("#lnkSize").click(function (event) {
        //        alert("Hi from Linksize");
        //        //$('html,body').animate({ scrollTop: $(this.hash).offset().top }, 3500);
        //        $(document.body).animate({
        //            'scrollTop': $('#factDiv').offset().top
        //        }, 3500);
        //    });
        //});

        function goto() {
            //window.scrollTo(10, 1100);
            //alert(document.getElementById('pname').textContent);
            document.getElementById('pname').textContent = 'Getting product details. Please wait...';
            //document.getElementById('pname').textContent.italics();
            var locationToScroll = window.location.href + "#" + "divFactScroll";
            //alert(window.location.href + "#" + "factDiv");
            window.location.assign(locationToScroll);
            locationToScroll = "";
        }

        function checkFilled() {
            var inputVal = document.getElementById("txtComment");
            //alert(inputVal.value);
            if (inputVal.value == "") {
                // inputVal.style.color = "yellow";
            }
            else {
                inputVal.style.color = "Black";
            }
        }

    </script>



    <%-- <div id="SuccessMsgDiv" class="alert alert-success" runat="server" style="opacity:1;">
        <strong>Success!</strong> Successfully Deleted.     
    </div>--%>
</head>

<body>

    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="hdnfldVariable" runat="server" />
        <asp:HiddenField ID="myHiddenField" runat="server" />
        <div class="body-wrapper">
            <div class="container">
                <div class="inner-wrapper">
                    <!------------------------header part starts------------------------------>

                    <div class="header">
                        <div class="top-bar">
                            <div class="col-md-4 col-sm-4">
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
                            <div class="col-md-8 col-sm-8">
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
                                            <div id="SignInDiv" runat="server"><a href="Login.aspx?PageName=OrderOnline.aspx"><span id="SpanSignIn" runat="server">sign in</span></a></div>
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

                        <div class="cart_info">
                            <div class="cart">
                                <button type="button" data-toggle="modal" data-target="#cart">
                                    <img src="images/imageedit_2_3508291564.png" id="dagger" height="40" width="40" style="margin-top: -20px;" />
                                </button>
                            </div>
                            <%--<button type="button" class="glyphicon glyphicon-shopping-cart" data-toggle="modal" data-target="#cart" style="background: url(/images/shoppingcart.jpg) no-repeat;cursor:pointer;border: none;"></button>--%>
                            <span class="item_no" id="item_no" runat="server">0</span>
                        </div>


                        <nav class="navbar">
                            <div class="container-fluid">
                                <div class="navbar-header">
                                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#menu"><span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></button>
                                    <div class="collapse navbar-collapse" id="menu">
                                        <ul class="nav navbar-nav navbar-nav1">
                                            <li class="order" id="liorderOnline">
                                                <asp:LinkButton runat="server" ID="lnkOrderOnline" Text="Order Online" OnClick="lnkOrderOnline_Click"></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton runat="server" ID="lnkHome" Text="Home" OnClick="lnkHome_Click"></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton runat="server" ID="lnkMenu" OnClick="lnkMenu_Click" OnClientClick="return true">Menu</asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton runat="server" ID="lnkOffers" Text="Offers" OnClick="lnkOffers_Click"></asp:LinkButton></li>
                                            <%-- <li>
                                                <div class="cart_info">
                                                    <div class="cart">
                                                        <button type="button" class="glyphicon glyphicon-shopping-cart" data-toggle="modal" data-target="#cart"></button>
                                                    </div>--%>
                                            <%--<button type="button" class="glyphicon glyphicon-shopping-cart" data-toggle="modal" data-target="#cart" style="background: url(/images/shoppingcart.jpg) no-repeat;cursor:pointer;border: none;"></button>--%>
                                            <%--  </div>
                                                <span class="item_no" id="item_no" runat="server">0</span></li>--%>
                                        </ul>

                                        <div class="navbar-brand">
                                            <img src="images/logo.png" class="img-responsive">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </nav>
                    </div>
                    <!------------------------header part ends------------------------------>


                    <!------------------------ cart ends----------------------------------->



                    <!------------------------main-part starts------------------------------>

                    <div class="main order-online">

                        <!------------------------------- cart starts------------------------------->

                        <div class="modal fade my_cart" id="cart" role="dialog">
                            <div class="modal-dialog modal-lg">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" id="btnclose" class="close" data-dismiss="modal">&times;</button>
                                        <div class="cart_header">
                                            <h4>My Cart </h4>
                                        </div>
                                    </div>
                                    <div class="product_detail">
                                        <div class="list-group">
                                            <asp:Label ID="lblNoSource" runat="server" Visible="false" Style="color: #ca3027; text-align: center; font-size: 20px; font-weight: bold;">Your cart is Empty!!!</asp:Label>
                                            <asp:Repeater ID="rptCartDetail" runat="server" OnItemDataBound="rptCartDetail_ItemDataBound" OnItemCommand="rptCartDetail_ItemCommand">

                                                <HeaderTemplate>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <div class="alert alert-default">
                                                        <asp:LinkButton CssClass="close" runat="server" OnClientClick="Confirm()" CommandArgument='<%# Eval("CartId") %>' Text="x" CommandName="DeleteItem" Style="font-size: 18px;"></asp:LinkButton>
                                                        <%-- <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>--%>
                                                        <div class="product_desc" id="1123">
                                                            <div class="row row1">
                                                                <div style="display: none">
                                                                    <asp:Label ID="lblCartId" runat="server" Text='<%# Eval("CartId") %>'></asp:Label>
                                                                    <asp:Label ID="lblProductdetailId" runat="server" Text='<%# Eval("ProductdetailId") %>'></asp:Label>
                                                                    <asp:Label ID="lblPropertyId" runat="server" Text='<%# Eval("PropertiesId") %>'></asp:Label>
                                                                    <asp:Label ID="lblProductIngredientFactId" runat="server" Text='<%# Eval("IngredientFactId") %>'></asp:Label>
                                                                    <asp:Label ID="lblDefaultIngredientId" runat="server" Text='<%# Eval("DefaultIngredientId") %>'></asp:Label>
                                                                    <asp:Label ID="lblSizeId" runat="server" Text='<%# Eval("SizeId") %>'></asp:Label>
                                                                    <asp:Label ID="lblOneQuantityPrice" runat="server" Text='<%# Eval("OneQuantityPrice") %>'></asp:Label>

                                                                </div>

                                                                <div class="col-md-8 col-sm-6">
                                                                    <span class="selected_prdct">
                                                                        <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label></span>
                                                                </div>
                                                                <%-- <div class="col-ms-2 col-sm-2"><span id="size"><asp:Label ID="Label2" runat="server"  Text='<%# "["+ Eval("SizeName")+"]" %>'></asp:Label></span></div>--%>
                                                                <div class="col-md-2 col-sm-2">
                                                                    <span class="price_prdct">
                                                                        <asp:Label ID="lblPrice" runat="server" Text='<%# "$"+ Eval("Price") %>'></asp:Label></span>
                                                                </div>
                                                                <div class="col-md-2 col-sm-2">
                                                                    <span class="product_quantity">
                                                                        <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Eval("Quantity") %>' OnTextChanged="txtQuantity_TextChanged" AutoPostBack="true"></asp:TextBox>

                                                                    </span>
                                                                </div>
                                                            </div>
                                                            <div class="row row2">
                                                                <div class="col-md-8 col-sm-6">
                                                                    <div id="ing_spec">
                                                                        <%-- <span class="red_font">Default Ingredients</span> -<asp:Label ID="Label5" runat="server" Text='<%# Eval("DefaultIngredientName") %>'></asp:Label></br>--%>

                                                                        <span class="red_font" id="spanText" runat="server" style="display: none;">Extra Ingredients </span>
                                                                        <%--<span class="red_font" id="spanText" runat="server"><asp:Label ID="lblSpan" CssClass="red_font" runat="server" Text="Extra Ingredients"></asp:Label></span>--%>
                                                                        <div>
                                                                            <%--<asp:GridView ID="gvExtraIngeredient" runat="server" AutoGenerateColumns="false" AllowSorting="true" class="table-bordered extra-ing-list">--%>
                                                                            <asp:GridView ID="gvExtraIngeredient" runat="server" GridLines="None" CellPadding="1" CellSpacing="2" AutoGenerateColumns="false" AllowSorting="true" ShowHeader="false">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="Name">
                                                                                        <ItemStyle Width="225px" />
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblIngredientName" runat="server" Text='<%# Eval("IngredientName") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>

                                                                                    <asp:TemplateField HeaderText="Price">
                                                                                        <ItemStyle Width="135px" />
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblIngredientPrice" runat="server" Font-Size="13px" Text='<%# "$ " + Eval("IngredientPrice") + " - " + Eval("IngredientFactName") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <%-- <EmptyDataTemplate>
                                                                                    No Extra Ingredient Added
                                                                                </EmptyDataTemplate>--%>
                                                                            </asp:GridView>
                                                                        </div>

                                                                    </div>
                                                                </div>
                                                                <div class="col-ms-2 col-sm-2">
                                                                    <span id="size">
                                                                        <asp:Label ID="lblSizeName" runat="server" Text='<%# "["+ Eval("SizeName")+"]" %>'></asp:Label></span>
                                                                </div>

                                                            </div>
                                                            <span class="red_font">
                                                                <asp:Label ID="lblComment" runat="server"></asp:Label><asp:Label ID="lbldash" runat="server"></asp:Label></span><span id="Label1"><asp:Label ID="lblCommentCart" runat="server" Text='<%# Eval("Comment") %>'></asp:Label></span><br>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>


                                            </asp:Repeater>

                                        </div>


                                        <div class="product_charges" id="footerLabels" runat="server">

                                            <div class="product_price"><span style="text-align: right;">Total:</span><span id="price" class="tax_value"><asp:Label runat="server" ID="LblTotal"></asp:Label></span></div>
                                            <div class="sales_tax"><span>Sales Tax:</span><span id="s-tax" class="tax_value"><asp:Label runat="server" ID="lblSalesPrice"></asp:Label></span></div>
                                            <div class="delivery_tax"><span>Delivery Charges:</span><span id="d-tax" class="tax_value"><asp:Label runat="server" ID="lblDeliveryCharges"></asp:Label></span></div>
                                            <div class="total_price"><span><strong>Total Price:</strong></span><span id="t-price" class="tax_value"><asp:Label runat="server" ID="LblTotalPrice"></asp:Label></span></div>
                                            <asp:Button ID="btnPlaceOrder" Text="Check Out" CssClass="place_order_btn pull-right" OnClick="btnPlaceOrder_Click" runat="server" />
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
                    </div>

                    <!------------------------------- cart ends------------------------------->



                    <%--<div id="modalPop">
                        <div id='<%# Eval("OfferCode") %>' class="modal fade" role="dialog">
                            <div class="modal-dialog modal-lg">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <asp:Label ID="lblPopHeader" Text="More Details..." runat="server"></asp:Label>
                                        <asp:Button ID="btnclose" CssClass="close" data-dismiss="modal" Text="&times;" runat="server" />
                                        <button type="button" class="close" data-dismiss="modal" id="btnClosePop">&times;</button>
                                    </div>
                                    <div class="modal-body">
                                        <asp:Label ID="lblQuantityPop" Text="Quantity" runat="server"></asp:Label>
                                        <asp:DropDownList ID="ddlQuantityPop" runat="server">
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Label ID="lblCommentPop" runat="server" Text="Comment"></asp:Label>
                                        <asp:TextBox ID="txtMultilineCommentPop" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Label ID="Label1" Text='<%# Eval("OfferCode") %>' runat="server" CssClass="label label-danger"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>--%>



                    <div class="inner-div order-onlie-section">
                        <div class="col-md-3 col-sm-3">

                            <asp:UpdatePanel runat="server" ID="upCategory">
                                <ContentTemplate>
                                    <asp:DataList ID="dlCategory" runat="server" OnItemDataBound="dlCategory_ItemDataBound" OnItemCommand="dlCategory_ItemCommand">
                                        <HeaderTemplate></HeaderTemplate>

                                        <ItemTemplate>
                                            <ul class="nav nav-pills nav-stacked">

                                                <li class="ing_list">
                                                    <asp:Label ID="lblCategoryId" runat="server" Style="display: none;" Text='<%# Eval("CategotyId") %>'></asp:Label>
                                                    <asp:Label ID="lblCategoryDescription" runat="server" Style="display: none;" Text='<%# Eval("CategoryDescription") %>'></asp:Label>
                                                    <asp:LinkButton ID="lnkCategoryName" runat="server" Text='<%# Eval("CategoryName") %>' CommandArgument='<%# Eval("CategotyId")+":"+Eval("CategoryName")+":"+Eval("CategoryDescription") %>'
                                                        Style="margin-bottom: -10px; color: red;" OnClientClick="return true;" CausesValidation="false"></asp:LinkButton>
                                                    <%--<asp:Label ID="lblCategoryName" runat="server" Text='<%# Eval("CategoryName") %>' CssClass="ing_list"></asp:Label>--%>

                                                </li>
                                            </ul>


                                        </ItemTemplate>
                                    </asp:DataList>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                        <script type="text/javascript">
                            //function highlight(id)
                            //{
                            //    alert("hii");
                            //     click(e, id);

                            //    //});
                            //}

                            //$(document).ready(function () {
                            //    var classHighlight = 'highlight';
                            //    var $thumbs = $('a#lnkCategoryName').click(function (e) {
                            //        alert("hii");
                            //        e.preventDefault();

                            //        $thumbs.removeClass('highlight');

                            //        $(this).addClass('highlight');

                            //        return true;




                            //    });
                            //    //return false;
                            //});

                        </script>


                        <div class="col-md-9 col-sm-9">
                            <div class="row">
                                <!-----------------------Category-details starts------------------------------>
                                <div class="category_details">
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="upSize">
                                        <ProgressTemplate>
                                            <div class="modal">
                                                <div class="center">
                                                    <img alt="" src="http://www.windowsphoneapplist.com/images/WindowsPhoneProgressbar.gif" />
                                                </div>
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    <asp:UpdatePanel ID="upSize" runat="server">
                                        <ContentTemplate>
                                            <div id="productDetail" runat="server">
                                                <div class="product_summary">
                                                    <div class="col-md-12 product_desc">
                                                        <div class="product_title" id="product_title" runat="server">
                                                            <h1 id="title" runat="server"><%# CategoryName %></h1>
                                                            <h4 id="Description" runat="server"><%# CategoryDescription %></h4>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="ingredients_option_list">
                                                    <div>
                                                        <table class="table" id="ingredient_table">
                                                            <asp:Repeater ID="rptProductList" runat="server" OnItemDataBound="rptProductList_ItemDataBound">

                                                                <ItemTemplate>

                                                                    <tr class="thick-crust-size">
                                                                        <asp:Label ID="lblProductID" runat="server" Text='<%# Eval("ProductdetailId") %>' Style="display: none;"></asp:Label>

                                                                        <th style="width: 270px; height: 58px;">
                                                                            <%--<th>--%>
                                                                            <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("ProductName") %> '></asp:Label>
                                                                            <span style="font-weight: normal; color: black"></span>
                                                                            <br />
                                                                            <asp:Label ID="lblProductDescription" runat="server" Text='<%# Eval("Description") %>' Style="color: #333333;"></asp:Label>
                                                                        </th>



                                                                        <asp:UpdatePanel runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Repeater ID="rptSize" runat="server" OnItemCommand="rptSize_ItemCommand" OnItemDataBound="rptSize_ItemDataBound">
                                                                                    <ItemTemplate>
                                                                                        <td style="width: 82px;">
                                                                                            <asp:UpdatePanel ID="upSize" runat="server" UpdateMode="Always">
                                                                                                <ContentTemplate>

                                                                                                    <asp:Label ID="lblSizeID" runat="server" Text='<%# Eval("SizeId") %>' Style="display: none;"></asp:Label>
                                                                                                    <span class="size">
                                                                                                        <asp:LinkButton ID="lnkSize" runat="server" Text='<%# Eval("SizeName") %>' CommandName="AddIngredientBySize"
                                                                                                            CommandArgument='<%# Eval("ProductdetailId")+":"+Eval("SizeId") %>' class="open-AddBookDialog a size"></asp:LinkButton>
                                                                                                        <%--'<%# Eval("ProductdetailId")+":"+Eval("SizeId") %>'--%>
                                                                                                        <%--'<%# Eval("ProductdetailId")+":"+Eval("SizeId") %>'--%>
                                                                                                        <%--'<%# Eval("ProductdetailId") %>'--%>
                                                                                                    </span>
                                                                                                    <span class="price">
                                                                                                        <asp:Label ID="lblPropertiesPrice" runat="server" Text='<%# "$"+Eval("Price") %>' CssClass="price" Style="align-content: flex-start"></asp:Label>
                                                                                                        <%--"starting from " + "$"+Eval("Price") %>--%>
                                                                                                    </span>
                                                                                                </ContentTemplate>
                                                                                            </asp:UpdatePanel>
                                                                                        </td>
                                                                                    </ItemTemplate>
                                                                                </asp:Repeater>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                        <asp:UpdatePanel ID="upPrice" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Repeater ID="rptPrice" runat="server" OnItemCommand="rptPrice_ItemCommand" OnItemDataBound="rptPrice_ItemDataBound">
                                                                                    <ItemTemplate>
                                                                                        <td>
                                                                                            <asp:Label ID="lblProductID" runat="server" Text='<%# Eval("ProductdetailId") %>' Style="display: none;"></asp:Label>
                                                                                            <span class="size" style="margin-top: 12px;">
                                                                                                <asp:LinkButton ID="lnkProductPrice" runat="server" Text='<%# "$"+Eval("BasePrice") %>' CommandName="AddIngredientByPrice" 
                                                                                                    CommandArgument='<%# Eval("ProductdetailId" ) %>'  class="open-AddBookDialog a size"></asp:LinkButton>
                                                                                            </span>
                                                                                        </td>
                                                                                    </ItemTemplate>
                                                                                </asp:Repeater>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>

                                                                    </tr>



                                                                </ItemTemplate>

                                                            </asp:Repeater>
                                                        </table>
                                                    </div>

                                                </div>
                                            </div>
                                        </ContentTemplate>


                                    </asp:UpdatePanel>
                                </div>
                            </div>

                            <!--------------------New Modal Pop up- Start------------------------>

                            <asp:UpdatePanel ID="upSizePop" runat="server" UpdateMode="Always">
                                <ContentTemplate>


                                    <div class="main order-online">
                                        <div class="modal fade size-popup" id="size-modal" role="dialog">
                                            <div class="modal-dialog modal-lg" style="overflow-y: initial !important">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                        <h4 class="price">
                                                            <asp:Label ID="lblModalHeader" runat="server" Text=""></asp:Label></h4>
                                                    </div>
                                                    <div class="modal-body" style="height: 450px; overflow-y: auto;">
                                                        <asp:HiddenField ID="hdnSizeInfo" Value='<%# Eval("ProductdetailId")+":"+Eval("SizeId") %>' runat="server" />
                                                        <h4 class="popup-title">
                                                            <asp:Label ID="lblSelectedPizzaHeader" runat="server" Text="Header"></asp:Label>
                                                            <asp:HiddenField ID="hdnPizzaPrice" runat="server" />
                                                        </h4>



                                                        <div class="selected_ingredient">
                                                            <div class="ingredients_option">
                                                                <div class="additional_comments" style="height: 30px;">
                                                                    <div class="quantity-div">
                                                                        <asp:DropDownList ID="ddlQuantityPop" runat="server">
                                                                            <asp:ListItem Text="Quantity" Value="-1"></asp:ListItem>
                                                                            <asp:ListItem Text="1" Value="1">  </asp:ListItem>
                                                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                    <div class="size-div">
                                                                        <asp:HiddenField ID="hdnSelectedSize" runat="server" />
                                                                        <asp:DropDownList ID="ddlSizePop" runat="server" onchange="ddlSizePopOnChange(this.value)" OnSelectedIndexChanged="ddlSizePop_SelectedIndexChanged"></asp:DropDownList>
                                                                    </div>
                                                                </div>

                                                                <%--<div class="crust-div">
                                                            <select>
                                                                <option>Crust</option>
                                                                <option>Regular Crust </option>
                                                                <option>Thick Crust</option>
                                                                <option>Thin Crust</option>
                                                            </select>
                                                        </div>--%>
                                                                <div class="additional_comments">
                                                                    <%--<textarea rows="2" cols="8" style="visibility:hidden" placeholder="additional comments" onfocus="this.placeholder=''" onblur="this.placeholder='additional comments'"></textarea>--%>
                                                                    <div class="quantity-div">
                                                                        <asp:DropDownList ID="ddlWingSouce" runat="server" Visible="false" onchange="ddlWingSouceChange(this)">
                                                                            <asp:ListItem Text="Select Wing Souce" Value="-1"></asp:ListItem>
                                                                            <asp:ListItem Text="BBQ" Value="1">  </asp:ListItem>
                                                                            <asp:ListItem Text="Hot" Value="2"></asp:ListItem>
                                                                            <asp:ListItem Text="Mild" Value="3"></asp:ListItem>
                                                                            
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                    <asp:TextBox ID="txtComment" runat="server" Visible="true" onfocus="(this.value=='Please provide details for this item')? this.value='':this.value;"
                                                                        onblur="(this.value=='')? this.value='Please provide details for this item':this.value;" TextMode="MultiLine" Rows="2" MaxLength="1000" ClientIDMode="Static"
                                                                        onkeypress="checkFilled();">Please provide details for this item</asp:TextBox>
                                                                </div>

                                                                <%--<button class="btn topping-btn" data-toggle="collapse" data-target="#topping_list">Toppings</button>--%>

                                                                <div id="topping_list">
                                                                    <div class="ing_details">
                                                                        <div id="ingredient_list_pop" runat="server">
                                                                            <div class="sub-total">
                                                                                <%-- <asp:TextBox runat="server" ID="txtComment" MaxLength="100"></asp:TextBox>--%>
                                                                                <div class="additional_comments" id="CommentDiv" runat="server">

                                                                                    <%--<asp:TextBox ID="txtComment" CssClass="comment" runat="server" Visible="false" onfocus="(this.value=='Please provide details for this item')? this.value='':this.value;" onblur="(this.value=='')? this.value='Please provide details for this item':this.value;" TextMode="MultiLine" Rows="2" MaxLength="1000" ClientIDMode="Static" onkeypress="checkFilled();">Please provide details for this item</asp:TextBox>--%>
                                                                                    <asp:Button ID="btnAddToCart" runat="server" Visible="false" Text="Add To Cart" OnClick="btnAddToCart_Click" CssClass="add_cart" />
                                                                                </div>
                                                                            </div>

                                                                            <br />
                                                                            <div class="ing_details" id="IngredientDiv" runat="server">
                                                                                <%--<div class="panel panel-default" id="IngredientDiv" runat="server">--%>
                                                                                <asp:Repeater ID="rptIngredients" runat="server" ClientIDMode="Predictable" OnItemDataBound="rptIngredients_ItemDataBound">

                                                                                    <ItemTemplate>
                                                                                        <%--<a href='#<%# Eval("IngredientPrice") %>'>--%>
                                                                                        <asp:Label runat="server" ID="lblIngredientPrice" Style="display: none" Text='<%# Eval("IngredientPrice") %>'></asp:Label>
                                                                                        <%-- <asp:Button ID="btning" runat="server" Text='<%# "Add for $"+Eval("IngredientPrice") %>' class="btn btn-lg btn-default" OnClientClick="return false;" CommandArgument='<%# Eval("IngredientPrice") %>'></asp:Button>--%>
                                                                                        <div id="divbting" runat="server" class="panel panel-default">
                                                                                            <div class="panel panel-heading" id="divIngredientGroupPrice" runat="server" style="font-weight: bold;"><%# "Add for $"+Eval("IngredientPrice") %></div>
                                                                                            <%--</a>--%>
                                                                                            <%-- <asp:UpdatePanel runat="server" ID="upIngredientList">
                                                                <ContentTemplate>--%>
                                                                                            <div class="panel panel-body sub-ing-option" id="divIngredientsList" runat="server">

                                                                                                <asp:DataList ID="dlIngredientList" runat="server" HorizontalAlign="Left" ClientIDMode="Predictable" RepeatDirection="Horizontal" CellPadding="0" Style="margin-left: 20px;"
                                                                                                     OnItemDataBound="dlIngredientList_ItemDataBound">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:UpdatePanel ID="upIngredients" runat="server" UpdateMode="Conditional">
                                                                                                            <ContentTemplate>
                                                                                                                <ul>
                                                                                                                    <li>
                                                                                                                        <asp:Label runat="server" ID="lblIngredientId" Style="display: none" Text='<%# Eval("IngredientId") %>'></asp:Label>
                                                                                                                        <asp:Label runat="server" ID="lblIngredientPrice" Style="display: none" Text='<%# Eval("IngredientPrice") %>'></asp:Label>
                                                                                                                        <asp:CheckBox runat="server" ID="chkIngredient" AutoPostBack="false"
                                                                                                                            OnCheckedChanged="chkIngredient_CheckedChanged" OnClick="GetClientID(this.id);" /><%--data-toggle="collapse" data-target="#toppingDiv"  --%>
                                                                                                                        <i></i>
                                                                                                                        <asp:Label ID="lblIngredientName" runat="server" Text='<%# Eval("IngredientName") %>' Style="color: #555;"></asp:Label>

                                                                                                                        <div id="toppingDiv" runat="server" style="font-size: x-small; visibility: collapse">
                                                                                                                            <div class="topping-size" id="topping-option">
                                                                                                                                <%-- <asp:DataList ID="dlIngFactList" runat="server" HorizontalAlign="Left" CssClass="topping-size" RepeatDirection="Horizontal" CellPadding="5" >
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:RadioButton runat="server" ID="rbFacts" Text='<%# Eval("IngredientFactName") %>' CssClass="topping-btn" />
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:DataList>--%>
                                                                                                                                <input type="radio" runat="server" value="full" name="topping-btn" title="Full" checked="true" id="radioFull">
                                                                                                                                Full
                                                                                                                                <input type="radio" runat="server" value="f-half" name="topping-btn" id="radioFhalf">
                                                                                                                                1<sup>st</sup> Half
						                                                                                                        <input type="radio" runat="server" value="s-half" name="topping-btn" id="radioShalf">
                                                                                                                                2<sup>nd</sup> Half
						                                                                                                        <input type="checkbox" runat="server" value="extra" name="topping-btn" id="chkExtra">
                                                                                                                                Extra
                                                                                                                            </div>

                                                                                                                        </div>


                                                                                                                    </li>
                                                                                                                </ul>

                                                                                                            </ContentTemplate>
                                                                                                            <Triggers>
                                                                                                                <asp:AsyncPostBackTrigger ControlID="chkIngredient" EventName="CheckedChanged" />
                                                                                                            </Triggers>
                                                                                                        </asp:UpdatePanel>
                                                                                                    </ItemTemplate>


                                                                                                </asp:DataList>


                                                                                            </div>
                                                                                        </div>
                                                                                        <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                                                    </ItemTemplate>
                                                                                </asp:Repeater>
                                                                            </div>

                                                                        </div>

                                                                    </div>
                                                                </div>

                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="modal-footer">
                                                        <asp:Button ID="btnPopCancel" ClientIDMode="Static" runat="server" CssClass="cancel-btn" Text="Cancel"></asp:Button>
                                                        <asp:Button ID="btnPopSubmit" ClientIDMode="Static" OnClientClick="return ValidatePopUp();" OnClick="btnPopSubmit_Click" runat="server" type="submit" CssClass="add_cart" Text="Add to Cart"></asp:Button>
                                                    </div>

                                                </div>
                                                <script type="text/javascript">
                                                    $(document).ready(function () {
                                                        $("#ingredient_table tr").click(function () {
                                                            var selected = $(this).hasClass("highlight");
                                                            $("#ingredient_table tr td").removeClass("highlight");
                                                            if (!selected)
                                                                $(this).addClass("highlight");
                                                        });
                                                    });
                                                </script>
                                                <%-- <script>
                                $(document).ready(function () {
                                    $('.modal-header').click(function () {
                                        $('.affix').remove();
                                    });
                                });
                            </script>
                            <script>
                                $(document).ready(function () {
                                    $('.modal-header .close').click(function () {
                                        $('.collapse').hide();
                                        location.reload();
                                    });
                                });
                            </script>--%>
                                            </div>

                                        </div>
                                    </div>

                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="btnPopCancel" />
                                    <asp:PostBackTrigger ControlID="btnPopSubmit" />

                                </Triggers>

                            </asp:UpdatePanel>
                            <!--------------------New Modal Pop up- End------------------------>


                            <asp:UpdatePanel runat="server" ID="upFact" class="row">
                                <ContentTemplate>




                                    <div id="divFactScroll"></div>

                                    <%-- <div class="size-popup" id="factDiv" runat="server">
                                            <div class="selected_ingredient">
                                                <h4 id="Pnameh4" runat="server"><span id="pname" runat="server"><%# ProductName %></span></h4>
                                                <h4><span id="pnameForNotIngredient" runat="server" visible="false"><%# ProductName %></span></h4>
                                                <span class="close" onclick="hide();">X</span>
                                            </div>
                                            <div class="ingredients_option">

                                                <h2>
                                                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                                    <asp:Label ID="lblMessage1" runat="server"></asp:Label>
                                                </h2>

                                                <div class="btn-div" id="Btndiv" runat="server">
                                                    <ul class="select_btn center-block">
                                                        <li>
                                                            <asp:LinkButton ID="btnFact1" runat="server" Text="Everywhere" data-toggle="collapse" data-target="#ingredient_list" OnClick="btnFact1_Click" CssClass="apply_btn" /></li>
                                                        <li>
                                                            <asp:LinkButton ID="btnFact2" runat="server" Text="Half & half" data-toggle="collapse" data-target="#ingredient_list" OnClick="btnFact2_Click" CssClass="apply_btn" /></li>
                                                        <%--<li>
                                                        <asp:LinkButton ID="btnFact3" runat="server" Text="Four Quarters" data-toggle="collapse" data-target="#ingredient_list" OnClick="btnFact1_Click" Style="margin-left: 12px;" CommandArgument="Four Quarters" /></li>--%>
                                    <li style="visibility: hidden">
                                        <asp:LinkButton ID="btnJustAddToCart" runat="server" Visible="false" Text="Just Add To Cart" data-toggle="collapse" data-target="#ingredient_list" OnClick="btnJustAddToCart_Click" CssClass="apply_btn" /></li>
                                    <li style="visibility: hidden">
                                        <asp:LinkButton ID="btnYes" runat="server" Text="Yes" Visible="false" Width="100px" Style="text-align: center; display: none;" OnClick="btnYes_Click" CssClass="apply_btn" /></li>
                                    <li style="visibility: hidden">
                                        <asp:LinkButton ID="btnNo" runat="server" Text="No" Visible="false" Width="100px" Style="text-align: center; display: none;" OnClick="btnNo_Click" CssClass="apply_btn" /></li>
                                    </ul>
                                                </div>

                                                <%-- <asp:UpdatePanel runat="server" ID="upIngredients">
                                                <ContentTemplate>--%>


                                    <%--</ContentTemplate>
                                            </asp:UpdatePanel>--%>
                                            </div>



                                        </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>


                            <script type="text/javascript">
                                function hide() {
                                    //alert("ji");
                                    $('#factDiv').hide();

                                }
                            </script>

                            <script type="text/javascript">
                                $('#factDiv .close').click(function () {
                                    $('#factDiv').hide();
                                });
                            </script>


                            <script type="text/javascript">
                                $(document).ready(function () {
                                    $("#ingredient_table tr").click(function () {
                                        var selected = $(this).hasClass("highlight");
                                        $("#ingredient_table tr td").removeClass("highlight");
                                        if (!selected)
                                            $(this).addClass("highlight");
                                    });
                                });
                            </script>
                            <!-----------------------Category-details ends------------------------------>
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
