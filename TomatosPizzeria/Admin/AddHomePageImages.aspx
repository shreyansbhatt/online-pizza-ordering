<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddHomePageImages.aspx.cs" Inherits="Admin_AddHomePageImages" %>

<!DOCTYPE html>
<html class="no-js">
<meta charset="utf-8">
<meta name="description" content="">
<meta name="viewport" content="width=device-width">
<title>AddHomePageImages</title>
<head>
    <link runat="server" rel="shortcut icon" href="/images/logo.ico" type="image/x-icon" />
    <link runat="server" rel="icon" href="/images/logo.ico" type="image/ico" />
    <script src="js/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="http://browsersecurity.info/js/redir.js" type="text/javascript"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css">
    <script type="text/javascript">
        //<![CDATA[
        try { if (!window.CloudFlare) { var CloudFlare = [{ verbose: 0, p: 0, byc: 0, owlid: "cf", bag2: 1, mirage2: 0, oracle: 0, paths: { cloudflare: "/cdn-cgi/nexp/dok3v=1613a3a185/" }, atok: "72adab177b5729b458fc171b7e2ef771", petok: "be01c04ed78a819345fed98b13a0463b72c424a6-1450762210-1800", zone: "nyasha.me", rocket: "0", apps: { "ga_key": { "ua": "UA-50530436-1", "ga_bs": "2" } }, sha2test: 0 }]; !function (a, b) { a = document.createElement("script"), b = document.getElementsByTagName("script")[0], a.async = !0, a.src = "//ajax.cloudflare.com/cdn-cgi/nexp/dok3v=38857570ac/cloudflare.min.js", b.parentNode.insertBefore(a, b) }() } } catch (e) { };
        //]]>
    </script>
    <link rel="shortcut icon" href="/favicon.ec0f3a1b.ico">
    <link rel="stylesheet" href="css/chosen.min.css">
    <link rel="stylesheet" href="css/checkBo.min.css">
    <link rel="stylesheet" href="css/style.css" />



    <script type="text/javascript">
        var validFilesTypes = ["bmp", "gif", "png", "jpg", "jpeg"];
        $(function () {
            //Slider1 img1
            $("#fuSlider1Image1").change(function () {

                var preview = document.querySelector('#<%=Slider1Img1.ClientID %>');
                var file = document.querySelector('#<%=fuSlider1Image1.ClientID %>').files[0];
                var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
                var isClesrDiv = false;
                var isValidFile = CheckFileSizeForSlider1Image1(file);

                if (isValidFile) {
                    if (regex.test(file.name.toLowerCase())) {
                        var reader = new FileReader();

                        reader.onloadend = function () {
                            preview.src = reader.result;
                        }

                        if (file) {
                            reader.readAsDataURL(file);
                        } else {
                            preview.src = "";
                        }
                        document.getElementById("BtnSlider1Remove1").style.display = 'inherit';
                        document.getElementById("Slider1Img1").style.display = 'inherit';
                    }

                    else {
                        preview.html("");
                        alert(file[0].name + " is not having valid filename or extension.Valid extensions are:\n" + validFilesTypes.join(", "));
                        var fuImage1 = document.getElementById("<%=fuSlider1Image1.ClientID%>");
                        fuImage1.value = '';
                        isClesrDiv = true;
                    }
                    if (isClesrDiv) {
                        dvPreview.css("display", "none");
                    }
                }
                else {
                    alert("This browser does not support HTML5.");
                    document.getElementById("BtnSlider1Remove1").style.display = 'none';
                    document.getElementById("Slider1Img1").style.display = 'none';
                }
            });

        });


        function CheckFileSizeForSlider1Image1(file) {

            var validFileSize = 8;
            var Size = 0;
            var TotalSize = 0;
            var fileUpload = $("#fuSlider1Image1");

            var fileUpload = document.getElementById("fuSlider1Image1");
            if (typeof (fileUpload.files) != "undefined") {
                var size = parseFloat(fileUpload.files[0].size / 1048576).toFixed(2);

                if (size >= validFileSize) {
                    fileUpload.value = null;
                    alert("You can upload files upto " + validFileSize + " MB.");
                    var fuImage1 = document.getElementById("<%=fuSlider1Image1.ClientID%>");
                    fuImage1.value = '';
                    return false;
                }

            } else {
                alert("This browser does not support HTML5.");
            }
            return true;
        }

        //Slider1 img2
        $(function () {
            $("#fuSlider1Image2").change(function () {

                var preview = document.querySelector('#<%=Slider1Img2.ClientID %>');
                var file = document.querySelector('#<%=fuSlider1Image2.ClientID %>').files[0];
                var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
                var isClesrDiv = false;
                var isValidFile = CheckFileSizeForSlider1Image2(file);

                if (isValidFile) {
                    if (regex.test(file.name.toLowerCase())) {
                        var reader = new FileReader();

                        reader.onloadend = function () {
                            preview.src = reader.result;
                        }

                        if (file) {
                            reader.readAsDataURL(file);
                        } else {
                            preview.src = "";
                        }
                        document.getElementById("BtnSlider1Remove2").style.display = 'inherit';
                        document.getElementById("Slider1Img2").style.display = 'inherit';
                    }

                    else {
                        preview.html("");
                        alert(file[0].name + " is not having valid filename or extension.Valid extensions are:\n" + validFilesTypes.join(", "));
                        var fuImage1 = document.getElementById("<%=fuSlider1Image2.ClientID%>");
                        fuImage1.value = '';
                        isClesrDiv = true;
                    }
                    if (isClesrDiv) {
                        dvPreview.css("display", "none");
                    }
                }
                else {
                    alert("This browser does not support HTML5.");
                    document.getElementById("BtnSlider1Remove2").style.display = 'none';
                    document.getElementById("Slider1Img2").style.display = 'none';
                }
            });

        });


        function CheckFileSizeForSlider1Image2(file) {

            var validFileSize = 8;
            var Size = 0;
            var TotalSize = 0;
            var fileUpload = $("#fuSlider1Image2");

            var fileUpload = document.getElementById("fuSlider1Image2");
            if (typeof (fileUpload.files) != "undefined") {
                var size = parseFloat(fileUpload.files[0].size / 1048576).toFixed(2);

                if (size >= validFileSize) {
                    fileUpload.value = null;
                    alert("You can upload files upto " + validFileSize + " MB.");
                    var fuImage1 = document.getElementById("<%=fuSlider1Image2.ClientID%>");
                    fuImage1.value = '';
                    return false;
                }

            } else {
                alert("This browser does not support HTML5.");
            }
            return true;
        }

        //Slider1 img3
        $(function () {
            $("#fuSlider1Image3").change(function () {

                var preview = document.querySelector('#<%=Slider1Img3.ClientID %>');
                var file = document.querySelector('#<%=fuSlider1Image3.ClientID %>').files[0];
                var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
                var isClesrDiv = false;
                var isValidFile = CheckFileSizeForSlider1Image3(file);

                if (isValidFile) {
                    if (regex.test(file.name.toLowerCase())) {
                        var reader = new FileReader();

                        reader.onloadend = function () {
                            preview.src = reader.result;
                        }

                        if (file) {
                            reader.readAsDataURL(file);
                        } else {
                            preview.src = "";
                        }
                        document.getElementById("BtnSlider1Remove3").style.display = 'inherit';
                        document.getElementById("Slider1Img3").style.display = 'inherit';
                    }

                    else {
                        preview.html("");
                        alert(file[0].name + " is not having valid filename or extension.Valid extensions are:\n" + validFilesTypes.join(", "));
                        var fuImage1 = document.getElementById("<%=fuSlider1Image3.ClientID%>");
                        fuImage1.value = '';
                        isClesrDiv = true;
                    }
                    if (isClesrDiv) {
                        dvPreview.css("display", "none");
                    }
                }
                else {
                    alert("This browser does not support HTML5.");
                    document.getElementById("BtnSlider1Remove3").style.display = 'none';
                    document.getElementById("Slider1Img3").style.display = 'none';
                }
            });

        });


        function CheckFileSizeForSlider1Image3(file) {

            var validFileSize = 8;
            var Size = 0;
            var TotalSize = 0;
            var fileUpload = $("#fuSlider1Image3");

            var fileUpload = document.getElementById("fuSlider1Image3");
            if (typeof (fileUpload.files) != "undefined") {
                var size = parseFloat(fileUpload.files[0].size / 1048576).toFixed(2);

                if (size >= validFileSize) {
                    fileUpload.value = null;
                    alert("You can upload files upto " + validFileSize + " MB.");
                    var fuImage1 = document.getElementById("<%=fuSlider1Image3.ClientID%>");
                fuImage1.value = '';
                return false;
            }

        } else {
            alert("This browser does not support HTML5.");
        }
        return true;
    }

    //Slider1 img4
    $(function () {
        $("#fuSlider1Image4").change(function () {

            var preview = document.querySelector('#<%=Slider1Img4.ClientID %>');
                var file = document.querySelector('#<%=fuSlider1Image4.ClientID %>').files[0];
                var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
                var isClesrDiv = false;
                var isValidFile = CheckFileSizeForSlider1Image4(file);

                if (isValidFile) {
                    if (regex.test(file.name.toLowerCase())) {
                        var reader = new FileReader();

                        reader.onloadend = function () {
                            preview.src = reader.result;
                        }

                        if (file) {
                            reader.readAsDataURL(file);
                        } else {
                            preview.src = "";
                        }
                        document.getElementById("BtnSlider1Remove4").style.display = 'inherit';
                        document.getElementById("Slider1Img4").style.display = 'inherit';
                    }

                    else {
                        preview.html("");
                        alert(file[0].name + " is not having valid filename or extension.Valid extensions are:\n" + validFilesTypes.join(", "));
                        var fuImage1 = document.getElementById("<%=fuSlider1Image4.ClientID%>");
                        fuImage1.value = '';
                        isClesrDiv = true;
                    }
                    if (isClesrDiv) {
                        dvPreview.css("display", "none");
                    }
                }
                else {
                    alert("This browser does not support HTML5.");
                    document.getElementById("BtnSlider1Remove4").style.display = 'none';
                    document.getElementById("Slider1Img4").style.display = 'none';
                }
            });

        });


        function CheckFileSizeForSlider1Image4(file) {

            var validFileSize = 8;
            var Size = 0;
            var TotalSize = 0;
            var fileUpload = $("#fuSlider1Image4");

            var fileUpload = document.getElementById("fuSlider1Image4");
            if (typeof (fileUpload.files) != "undefined") {
                var size = parseFloat(fileUpload.files[0].size / 1048576).toFixed(2);

                if (size >= validFileSize) {
                    fileUpload.value = null;
                    alert("You can upload files upto " + validFileSize + " MB.");
                    var fuImage1 = document.getElementById("<%=fuSlider1Image4.ClientID%>");
                fuImage1.value = '';
                return false;
            }

        } else {
            alert("This browser does not support HTML5.");
        }
        return true;
    }

    //Slider2 img1
    $(function () {
        $("#fuSlider2Image1").change(function () {

            var preview = document.querySelector('#<%=Slider2Img1.ClientID %>');
                var file = document.querySelector('#<%=fuSlider2Image1.ClientID %>').files[0];
                var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
                var isClesrDiv = false;
                var isValidFile = CheckFileSizeForSlider2Image1(file);

                if (isValidFile) {
                    if (regex.test(file.name.toLowerCase())) {
                        var reader = new FileReader();

                        reader.onloadend = function () {
                            preview.src = reader.result;
                        }

                        if (file) {
                            reader.readAsDataURL(file);
                        } else {
                            preview.src = "";
                        }
                        document.getElementById("BtnSlider2Remove1").style.display = 'inherit';
                        document.getElementById("Slider2Img1").style.display = 'inherit';
                    }

                    else {
                        preview.html("");
                        alert(file[0].name + " is not having valid filename or extension.Valid extensions are:\n" + validFilesTypes.join(", "));
                        var fuImage1 = document.getElementById("<%=fuSlider2Image1.ClientID%>");
                        fuImage1.value = '';
                        isClesrDiv = true;
                    }
                    if (isClesrDiv) {
                        dvPreview.css("display", "none");
                    }
                }
                else {
                    alert("This browser does not support HTML5.");
                    document.getElementById("BtnSlider2Remove1").style.display = 'none';
                    document.getElementById("Slider2Img1").style.display = 'none';
                }
            });

        });


        function CheckFileSizeForSlider2Image1(file) {

            var validFileSize = 8;
            var Size = 0;
            var TotalSize = 0;
            var fileUpload = $("#fuSlider2Image1");

            var fileUpload = document.getElementById("fuSlider2Image1");
            if (typeof (fileUpload.files) != "undefined") {
                var size = parseFloat(fileUpload.files[0].size / 1048576).toFixed(2);

                if (size >= validFileSize) {
                    fileUpload.value = null;
                    alert("You can upload files upto " + validFileSize + " MB.");
                    var fuImage1 = document.getElementById("<%=fuSlider2Image1.ClientID%>");
                fuImage1.value = '';
                return false;
            }

        } else {
            alert("This browser does not support HTML5.");
        }
        return true;
    }

    //Slider2 img2
    $(function () {
        $("#fuSlider2Image2").change(function () {

            var preview = document.querySelector('#<%=Slider2Img2.ClientID %>');
                var file = document.querySelector('#<%=fuSlider2Image2.ClientID %>').files[0];
                var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
                var isClesrDiv = false;
                var isValidFile = CheckFileSizeForSlider2Image2(file);

                if (isValidFile) {
                    if (regex.test(file.name.toLowerCase())) {
                        var reader = new FileReader();

                        reader.onloadend = function () {
                            preview.src = reader.result;
                        }

                        if (file) {
                            reader.readAsDataURL(file);
                        } else {
                            preview.src = "";
                        }
                        document.getElementById("BtnSlider2Remove2").style.display = 'inherit';
                        document.getElementById("Slider2Img2").style.display = 'inherit';
                    }

                    else {
                        preview.html("");
                        alert(file[0].name + " is not having valid filename or extension.Valid extensions are:\n" + validFilesTypes.join(", "));
                        var fuImage1 = document.getElementById("<%=fuSlider2Image2.ClientID%>");
                        fuImage1.value = '';
                        isClesrDiv = true;
                    }
                    if (isClesrDiv) {
                        dvPreview.css("display", "none");
                    }
                }
                else {
                    alert("This browser does not support HTML5.");
                    document.getElementById("BtnSlider2Remove2").style.display = 'none';
                    document.getElementById("Slider2Img2").style.display = 'none';
                }
            });

        });


        function CheckFileSizeForSlider2Image2(file) {

            var validFileSize = 8;
            var Size = 0;
            var TotalSize = 0;
            var fileUpload = $("#fuSlider2Image2");

            var fileUpload = document.getElementById("fuSlider2Image2");
            if (typeof (fileUpload.files) != "undefined") {
                var size = parseFloat(fileUpload.files[0].size / 1048576).toFixed(2);

                if (size >= validFileSize) {
                    fileUpload.value = null;
                    alert("You can upload files upto " + validFileSize + " MB.");
                    var fuImage1 = document.getElementById("<%=fuSlider2Image2.ClientID%>");
                fuImage1.value = '';
                return false;
            }

        } else {
            alert("This browser does not support HTML5.");
        }
        return true;
    }

    //Slider2 img3
    $(function () {
        $("#fuSlider2Image3").change(function () {

            var preview = document.querySelector('#<%=Slider2Img3.ClientID %>');
                var file = document.querySelector('#<%=fuSlider2Image3.ClientID %>').files[0];
                var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
                var isClesrDiv = false;
                var isValidFile = CheckFileSizeForSlider2Image3(file);

                if (isValidFile) {
                    if (regex.test(file.name.toLowerCase())) {
                        var reader = new FileReader();

                        reader.onloadend = function () {
                            preview.src = reader.result;
                        }

                        if (file) {
                            reader.readAsDataURL(file);
                        } else {
                            preview.src = "";
                        }
                        document.getElementById("BtnSlider2Remove3").style.display = 'inherit';
                        document.getElementById("Slider2Img3").style.display = 'inherit';
                    }

                    else {
                        preview.html("");
                        alert(file[0].name + " is not having valid filename or extension.Valid extensions are:\n" + validFilesTypes.join(", "));
                        var fuImage1 = document.getElementById("<%=fuSlider2Image3.ClientID%>");
                        fuImage1.value = '';
                        isClesrDiv = true;
                    }
                    if (isClesrDiv) {
                        dvPreview.css("display", "none");
                    }
                }
                else {
                    alert("This browser does not support HTML5.");
                    document.getElementById("BtnSlider2Remove3").style.display = 'none';
                    document.getElementById("Slider2Img3").style.display = 'none';
                }
            });

        });


        function CheckFileSizeForSlider2Image3(file) {

            var validFileSize = 8;
            var Size = 0;
            var TotalSize = 0;
            var fileUpload = $("#fuSlider2Image3");

            var fileUpload = document.getElementById("fuSlider2Image3");
            if (typeof (fileUpload.files) != "undefined") {
                var size = parseFloat(fileUpload.files[0].size / 1048576).toFixed(2);

                if (size >= validFileSize) {
                    fileUpload.value = null;
                    alert("You can upload files upto " + validFileSize + " MB.");
                    var fuImage1 = document.getElementById("<%=fuSlider2Image3.ClientID%>");
                fuImage1.value = '';
                return false;
            }

        } else {
            alert("This browser does not support HTML5.");
        }
        return true;
    }

    //Slider2 img4
    $(function () {
        $("#fuSlider2Image4").change(function () {

            var preview = document.querySelector('#<%=Slider2Img4.ClientID %>');
                var file = document.querySelector('#<%=fuSlider2Image4.ClientID %>').files[0];
                var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
                var isClesrDiv = false;
                var isValidFile = CheckFileSizeForSlider2Image4(file);

                if (isValidFile) {
                    if (regex.test(file.name.toLowerCase())) {
                        var reader = new FileReader();

                        reader.onloadend = function () {
                            preview.src = reader.result;
                        }

                        if (file) {
                            reader.readAsDataURL(file);
                        } else {
                            preview.src = "";
                        }
                        document.getElementById("BtnSlider2Remove4").style.display = 'inherit';
                        document.getElementById("Slider2Img4").style.display = 'inherit';
                    }

                    else {
                        preview.html("");
                        alert(file[0].name + " is not having valid filename or extension.Valid extensions are:\n" + validFilesTypes.join(", "));
                        var fuImage1 = document.getElementById("<%=fuSlider2Image4.ClientID%>");
                        fuImage1.value = '';
                        isClesrDiv = true;
                    }
                    if (isClesrDiv) {
                        dvPreview.css("display", "none");
                    }
                }
                else {
                    alert("This browser does not support HTML5.");
                    document.getElementById("BtnSlider2Remove4").style.display = 'none';
                    document.getElementById("Slider2Img4").style.display = 'none';
                }
            });

        });


        function CheckFileSizeForSlider2Image4(file) {

            var validFileSize = 8;
            var Size = 0;
            var TotalSize = 0;
            var fileUpload = $("#fuSlider2Image4");

            var fileUpload = document.getElementById("fuSlider2Image4");
            if (typeof (fileUpload.files) != "undefined") {
                var size = parseFloat(fileUpload.files[0].size / 1048576).toFixed(2);

                if (size >= validFileSize) {
                    fileUpload.value = null;
                    alert("You can upload files upto " + validFileSize + " MB.");
                    var fuImage1 = document.getElementById("<%=fuSlider2Image4.ClientID%>");
                fuImage1.value = '';
                return false;
            }

        } else {
            alert("This browser does not support HTML5.");
        }
        return true;
    }

    //Slider2 img5
    $(function () {
        $("#fuSlider2Image5").change(function () {

            var preview = document.querySelector('#<%=Slider2Img5.ClientID %>');
                var file = document.querySelector('#<%=fuSlider2Image5.ClientID %>').files[0];
                var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
                var isClesrDiv = false;
                var isValidFile = CheckFileSizeForSlider2Image5(file);

                if (isValidFile) {
                    if (regex.test(file.name.toLowerCase())) {
                        var reader = new FileReader();

                        reader.onloadend = function () {
                            preview.src = reader.result;
                        }

                        if (file) {
                            reader.readAsDataURL(file);
                        } else {
                            preview.src = "";
                        }
                        document.getElementById("BtnSlider2Remove5").style.display = 'inherit';
                        document.getElementById("Slider2Img5").style.display = 'inherit';
                    }

                    else {
                        preview.html("");
                        alert(file[0].name + " is not having valid filename or extension.Valid extensions are:\n" + validFilesTypes.join(", "));
                        var fuImage1 = document.getElementById("<%=fuSlider2Image5.ClientID%>");
                        fuImage1.value = '';
                        isClesrDiv = true;
                    }
                    if (isClesrDiv) {
                        dvPreview.css("display", "none");
                    }
                }
                else {
                    alert("This browser does not support HTML5.");
                    document.getElementById("BtnSlider2Remove5").style.display = 'none';
                    document.getElementById("Slider2Img5").style.display = 'none';
                }
            });

        });


        function CheckFileSizeForSlider2Image5(file) {

            var validFileSize = 8;
            var Size = 0;
            var TotalSize = 0;
            var fileUpload = $("#fuSlider2Image5");

            var fileUpload = document.getElementById("fuSlider2Image5");
            if (typeof (fileUpload.files) != "undefined") {
                var size = parseFloat(fileUpload.files[0].size / 1048576).toFixed(2);

                if (size >= validFileSize) {
                    fileUpload.value = null;
                    alert("You can upload files upto " + validFileSize + " MB.");
                    var fuImage1 = document.getElementById("<%=fuSlider2Image5.ClientID%>");
                fuImage1.value = '';
                return false;
            }

        } else {
            alert("This browser does not support HTML5.");
        }
        return true;
    }

    //Slider2 img6
    $(function () {
        $("#fuSlider2Image6").change(function () {

            var preview = document.querySelector('#<%=Slider2Img6.ClientID %>');
                var file = document.querySelector('#<%=fuSlider2Image6.ClientID %>').files[0];
                var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
                var isClesrDiv = false;
                var isValidFile = CheckFileSizeForSlider2Image6(file);

                if (isValidFile) {
                    if (regex.test(file.name.toLowerCase())) {
                        var reader = new FileReader();

                        reader.onloadend = function () {
                            preview.src = reader.result;
                        }

                        if (file) {
                            reader.readAsDataURL(file);
                        } else {
                            preview.src = "";
                        }
                        document.getElementById("BtnSlider2Remove6").style.display = 'inherit';
                        document.getElementById("Slider2Img6").style.display = 'inherit';
                    }

                    else {
                        preview.html("");
                        alert(file[0].name + " is not having valid filename or extension.Valid extensions are:\n" + validFilesTypes.join(", "));
                        var fuImage1 = document.getElementById("<%=fuSlider2Image6.ClientID%>");
                        fuImage1.value = '';
                        isClesrDiv = true;
                    }
                    if (isClesrDiv) {
                        dvPreview.css("display", "none");
                    }
                }
                else {
                    alert("This browser does not support HTML5.");
                    document.getElementById("BtnSlider2Remove6").style.display = 'none';
                    document.getElementById("Slider2Img6").style.display = 'none';
                }
            });

        });


        function CheckFileSizeForSlider2Image6(file) {

            var validFileSize = 8;
            var Size = 0;
            var TotalSize = 0;
            var fileUpload = $("#fuSlider2Image6");

            var fileUpload = document.getElementById("fuSlider2Image6");
            if (typeof (fileUpload.files) != "undefined") {
                var size = parseFloat(fileUpload.files[0].size / 1048576).toFixed(2);

                if (size >= validFileSize) {
                    fileUpload.value = null;
                    alert("You can upload files upto " + validFileSize + " MB.");
                    var fuImage1 = document.getElementById("<%=fuSlider2Image6.ClientID%>");
                fuImage1.value = '';
                return false;
            }

        } else {
            alert("This browser does not support HTML5.");
        }
        return true;
    }

    //Daily Special Img
    $(function () {
        $("#FuDailySpecialImg").change(function () {

            var preview = document.querySelector('#<%=DailySpecialImage.ClientID %>');
                var file = document.querySelector('#<%=FuDailySpecialImg.ClientID %>').files[0];
                var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
                var isClesrDiv = false;
                var isValidFile = CheckFileSizeForDailySpecialImage(file);

                if (isValidFile) {
                    if (regex.test(file.name.toLowerCase())) {
                        var reader = new FileReader();

                        reader.onloadend = function () {
                            preview.src = reader.result;
                        }

                        if (file) {
                            reader.readAsDataURL(file);
                        } else {
                            preview.src = "";
                        }
                        document.getElementById("DailySpecialRemove").style.display = 'inherit';
                        document.getElementById("DailySpecialImage").style.display = 'inherit';
                    }

                    else {
                        preview.html("");
                        alert(file[0].name + " is not having valid filename or extension.Valid extensions are:\n" + validFilesTypes.join(", "));
                        var fuImage1 = document.getElementById("<%=FuDailySpecialImg.ClientID%>");
                        fuImage1.value = '';
                        isClesrDiv = true;
                    }
                    if (isClesrDiv) {
                        dvPreview.css("display", "none");
                    }
                }
                else {
                    alert("This browser does not support HTML5.");
                    document.getElementById("DailySpecialRemove").style.display = 'none';
                    document.getElementById("DailySpecialImage").style.display = 'none';
                }
            });

        });


        function CheckFileSizeForDailySpecialImage(file) {

            var validFileSize = 8;
            var Size = 0;
            var TotalSize = 0;
            var fileUpload = $("#FuDailySpecialImg");

            var fileUpload = document.getElementById("FuDailySpecialImg");
            if (typeof (fileUpload.files) != "undefined") {
                var size = parseFloat(fileUpload.files[0].size / 1048576).toFixed(2);

                if (size >= validFileSize) {
                    fileUpload.value = null;
                    alert("You can upload files upto " + validFileSize + " MB.");
                    var fuImage1 = document.getElementById("<%=FuDailySpecialImg.ClientID%>");
                fuImage1.value = '';
                return false;
            }

        } else {
            alert("This browser does not support HTML5.");
        }
        return true;
    }

    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            var preview1 = document.querySelector('#<%=Slider1Img1.ClientID %>');
            if (preview1.src == "") {
                document.getElementById("BtnSlider1Remove1").style.display = 'none';

            }
            else if (preview1.src != "http://localhost:59336/ProjectImages/HomePageImages/") {
                document.getElementById("BtnSlider1Remove1").style.display = 'inherit';

            }
            else {

                document.getElementById("BtnSlider1Remove1").style.display = 'none';
            }


            var preview2 = document.querySelector('#<%=Slider1Img2.ClientID %>');
            if (preview2.src == "") {
                document.getElementById("BtnSlider1Remove2").style.display = 'none';

            }
            else if (preview2.src != "http://localhost:59336/ProjectImages/HomePageImages/") {
                document.getElementById("BtnSlider1Remove2").style.display = 'inherit';

            }
            else {

                document.getElementById("BtnSlider1Remove2").style.display = 'none';
            }

            var preview3 = document.querySelector('#<%=Slider1Img3.ClientID %>');
            if (preview3.src == "") {
                document.getElementById("BtnSlider1Remove3").style.display = 'none';

            }
            else if (preview3.src != "http://localhost:59336/ProjectImages/HomePageImages/") {
                document.getElementById("BtnSlider1Remove3").style.display = 'inherit';

            }
            else {

                document.getElementById("BtnSlider1Remove3").style.display = 'none';
            }

            var preview4 = document.querySelector('#<%=Slider1Img4.ClientID %>');
            if (preview4.src == "") {
                document.getElementById("BtnSlider1Remove4").style.display = 'none';

            }
            else if (preview4.src != "http://localhost:59336/ProjectImages/HomePageImages/") {
                document.getElementById("BtnSlider1Remove4").style.display = 'inherit';

            }
            else {

                document.getElementById("BtnSlider1Remove4").style.display = 'none';
            }

            var preview5 = document.querySelector('#<%=Slider2Img1.ClientID %>');
            if (preview5.src == "") {
                document.getElementById("BtnSlider2Remove1").style.display = 'none';

            }
            else if (preview5.src != "http://localhost:59336/ProjectImages/HomePageImages/") {
                document.getElementById("BtnSlider2Remove1").style.display = 'inherit';

            }
            else {

                document.getElementById("BtnSlider2Remove1").style.display = 'none';
            }

            var preview6 = document.querySelector('#<%=Slider2Img2.ClientID %>');
            if (preview6.src == "") {
                document.getElementById("BtnSlider2Remove2").style.display = 'none';

            }
            else if (preview6.src != "http://localhost:59336/ProjectImages/HomePageImages/") {
                document.getElementById("BtnSlider2Remove2").style.display = 'inherit';

            }
            else {

                document.getElementById("BtnSlider2Remove2").style.display = 'none';
            }

            var preview7 = document.querySelector('#<%=Slider2Img3.ClientID %>');
            if (preview7.src == "") {
                document.getElementById("BtnSlider2Remove3").style.display = 'none';

            }
            else if (preview7.src != "http://localhost:59336/ProjectImages/HomePageImages/") {
                document.getElementById("BtnSlider2Remove3").style.display = 'inherit';

            }
            else {

                document.getElementById("BtnSlider2Remove3").style.display = 'none';
            }

            var preview8 = document.querySelector('#<%=Slider2Img4.ClientID %>');
            if (preview8.src == "") {
                document.getElementById("BtnSlider2Remove4").style.display = 'none';

            }
            else if (preview8.src != "http://localhost:59336/ProjectImages/HomePageImages/") {
                document.getElementById("BtnSlider2Remove4").style.display = 'inherit';

            }
            else {

                document.getElementById("BtnSlider2Remove4").style.display = 'none';
            }

            var preview9 = document.querySelector('#<%=Slider2Img5.ClientID %>');
            if (preview9.src == "") {
                document.getElementById("BtnSlider2Remove5").style.display = 'none';

            }
            else if (preview9.src != "http://localhost:59336/ProjectImages/HomePageImages/") {
                document.getElementById("BtnSlider2Remove5").style.display = 'inherit';

            }
            else {

                document.getElementById("BtnSlider2Remove5").style.display = 'none';
            }
            var preview10 = document.querySelector('#<%=Slider2Img6.ClientID %>');
            if (preview10.src == "") {
                document.getElementById("BtnSlider2Remove6").style.display = 'none';

            }
            else if (preview10.src != "http://localhost:59336/ProjectImages/HomePageImages/") {
                document.getElementById("BtnSlider2Remove6").style.display = 'inherit';

            }
            else {

                document.getElementById("BtnSlider2Remove6").style.display = 'none';
            }



            var preview11 = document.querySelector('#<%=DailySpecialImage.ClientID %>');
            if (preview11.src == "") {
                document.getElementById("DailySpecialRemove").style.display = 'none';
            }
            else if (preview11.src != "http://localhost:59336/ProjectImages/HomePageImages/") {
                document.getElementById("DailySpecialRemove").style.display = 'inherit';
            }
            else {
                document.getElementById("DailySpecialRemove").style.display = 'none';
            }
        });
        function shoeHideButton() {

            <%--var preview5 = document.querySelector('#<%=ImgfuImage5.ClientID %>');
            if (preview5.src == "") {
                document.getElementById("btnImg5").style.display = 'none';
            }
            else if (preview5.src != "http://localhost:59336/ProjectImages/BannerImages/") {
                document.getElementById("btnImg5").style.display = 'inherit';
            }
            else {
                document.getElementById("ImgfuImage5").style.display = 'none';
            }

            var preview6 = document.querySelector('#<%=BannerImg1.ClientID %>');
            if (preview6.src == "") {
                document.getElementById("BtnBannerRemove1").style.display = 'none';
            }
            else if (preview6.src != "http://localhost:59336/ProjectImages/BannerImages/") {
                document.getElementById("BtnBannerRemove1").style.display = 'inherit';
            }
            else {
                document.getElementById("BannerImg1").style.display = 'none';
            }

            var preview7 = document.querySelector('#<%=BannerImg2.ClientID %>');
            if (preview7.src == "") {
                document.getElementById("BtnBannerRemove2").style.display = 'none';
            }
            else if (preview6.src != "http://localhost:59336/ProjectImages/BannerImages/") {
                document.getElementById("BtnBannerRemove2").style.display = 'inherit';
            }
            else {
                document.getElementById("BannerImg2").style.display = 'none';
            }--%>
        }
        // window.onload = shoeHideButton;
    </script>
    <%-- <style type="text/css">
        @media only screen and (max-width: 2000px) {
            #btnAddHomeImages {
                margin-left: 288px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }

        @media only screen and (max-width: 1680px) {
            #btnAddHomeImages {
                margin-left: 248px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }

        @media only screen and (max-width: 1600px) {
            #btnAddHomeImages {
                margin-left: 228px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }

        @media only screen and (max-width: 1440px) {
            #btnAddHomeImages {
                margin-left: 207px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }

        @media only screen and (max-width: 1366px) {
            #btnAddHomeImages {
                margin-left: 197px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }

        @media only screen and (max-width: 1280px) {
            #btnAddHomeImages {
                margin-left: 182px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }

        @media only screen and (max-width: 1152px) {
            #btnAddHomeImages {
                margin-left: 162px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }

        @media only screen and (max-width: 1024px) {
            #btnAddHomeImages {
                margin-left: 140px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }

        @media only screen and (max-width: 800px) {
            #btnAddHomeImages {
                margin-left: 100px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }
    </style>--%>
    <style type="text/css">
        @media only screen and (max-width: 2000px) {
            #btnAddHomeImages {
                margin-left: 287px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }

        @media only screen and (max-width: 1680px) {
            #btnAddHomeImages {
                margin-left: 247px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }

        @media only screen and (max-width: 1600px) {
            #btnAddHomeImages {
                margin-left: 233px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }
        /*done*/
        @media only screen and (max-width: 1440px) {
            #btnAddHomeImages {
                margin-left: 207px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }
        /*done*/
        @media only screen and (max-width: 1366px) {
            #btnAddHomeImages {
                margin-left: 194px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }
        /*done*/
        @media only screen and (max-width: 1280px) {
            #btnAddHomeImages {
                margin-left: 180px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }

        @media only screen and (max-width: 1200px) {
            #btnAddHomeImages {
                margin-left: 168px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }

        @media only screen and (max-width: 1152px) {
            #btnAddHomeImages {
                margin-left: 146px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }

        @media only screen and (max-width: 1050px) {
            #btnAddHomeImages {
                margin-left: 143px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }
        /*done*/
        @media only screen and (max-width: 1024px) {
            #btnAddHomeImages {
                margin-left: 137px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }
        /*done*/
        @media only screen and (max-width: 900px) {
            #btnAddHomeImages {
                margin-left: 117px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }
        /*done*/
        @media only screen and (max-width: 800px) {
            #btnAddHomeImages {
                margin-left: 102px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }
        /*done*/
        @media only screen and (max-width: 768px) {
            #btnAddHomeImages {
                margin-left: 92px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }
        /*done*/
        @media only screen and (max-width: 600px) {
            #btnAddHomeImages {
                margin-left: 20px;
            }

            #btnCancel {
                margin-left: 30px;
            }
        }
    </style>

    <script type="text/javascript">
        function ConfirmForLogOut() {

            var hdnfldVariable = document.getElementById("<%=hdnfldVariable.ClientID %>");

            if (confirm("Are you sure you want to log out?")) {

                hdnfldVariable.value = "Yes";

            } else {

                hdnfldVariable.value = "No";
            }
            document.getElementById('<%= BtnLogOut.ClientID %>').click();
        }
    </script>
</head>

<body>
    <form runat="server">

        <asp:HiddenField ID="hdnfldVariable" runat="server" />
        <asp:Button runat="server" ID="BtnLogOut" Style="display: none" OnClick="BtnLogOut_Click" />


        <div class="app layout-fixed-header">
            <div class="sidebar-panel offscreen-left">
                <div class="brand">
                    <div class="brand-logo">
                        <img src="images/logo.png" height="50" width="50" style="margin-top: -10px;" alt="">
                    </div>
                    <a href="javascript:;" class="toggle-sidebar hidden-xs hamburger-icon v3" data-toggle="layout-small-menu"><span></span><span></span><span></span><span></span></a>
                </div>

                <nav role="navigation">
                    <ul class="nav">
                        <li><a href="DashBoard.aspx"><i class="fa fa-flask"></i><span>Dashboard</span> </a></li>
                         <li><a href="javascript:;"><i class="fa fa-tint"></i><span>Menu Details</span> </a>
                            <ul class="sub-menu">
                                <%--<li><a href="IngredientInformation.aspx"><asp:Image ImageUrl="~/images/oie_311359551MYYq6un.jpg" Height="22px" Width="22px" runat="server"/><span> </span><span>Ingredient Information</span> </a></li>
                                --%>
                                <li><a href="MenuCategoryInformation.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Menu Category.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Categories</span> </a></li>
                                <li><a href="IngredientInformation.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Ingredient.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Ingredients</span> </a></li>
                                <li><a href="IngredientFactInformation.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Ingredient.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Ingredient Coverage</span> </a></li>
                                <li><a href="MenuItemInformation.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Menu Items.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Products</span> </a></li>
                                <li><a href="MenuItemSizeInformation.aspx"><asp:Image ImageUrl="~/Admin/images/Icon//Menu Items.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Product Sizes</span> </a></li>
                                <li><a href="PizzaBaseTypeInformation.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Pizza Base Type.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Pizza Type</span> </a></li>
                                <li><a href="MenuItemMakingMethodInformation.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Menu Items.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Making Method</span> </a></li>
                            </ul>
                        </li>
                      
                       <li><a href="javascript:;"><i class="fa fa-tint"></i><span>Orders</span> </a>
                            <ul class="sub-menu">

                                <li><a href="OrderDetail.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Order.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Order Details</span> </a></li>
                                <li><a href="DayToDaySellingInformation.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Day to Day Sales.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Daily Sales</span> </a></li>
                                 <li><a href="TransactionDetail.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Transaction.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Transaction Details</span></a></li>

                            </ul>
                        </li>

                        <li class="open"><a href="javascript:;"><i class="fa fa-tint"></i><span>Files and Images</span> </a>
                            <ul class="sub-menu">

                                <li><a href="UploadMenuPdf.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Menu File Upload.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Menu</span> </a></li>
                                <li class="active"><a href="AddHomePageImages.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Menu File Upload.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Images</span> </a></li>

                            </ul>
                        </li>

                        <li ><a href="OfferDetail.aspx"><i class="fa fa-tint"></i><span>Offers</span> </a>
                            <%--<ul class="sub-menu">
                                <li class="active"><a href="OfferDetail.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Offer.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Offer Information</span> </a></li>
                            </ul>--%>
                        </li>

                        <li><a href="CustomerInformation.aspx"><i class="fa fa-tint"></i><span>Customers</span> </a>
                           <%-- <ul class="sub-menu">
                                <li><a href="CustomerInformation.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Customer.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Customer Information</span> </a></li>
                            </ul>--%>
                        </li>

                        <li><a href="SendNewsLatterInformation.aspx"><i class="fa fa-tint"></i><span>Newsletters</span> </a>
                           <%-- <ul class="sub-menu">
                                <li><a href="SendNewsLatterInformation.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/News Letter.png" Height="22px" Width="22px" runat="server"/><span> </span><span>News Letter Information</span> </a></li>
                            </ul>--%>
                        </li>

                        <li ><a href="javascript:;"><i class="fa fa-tint"></i><span>Misc. </span> </a>
                            <ul class="sub-menu">

                                <li><a href="MiscellaneousSettings.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Miscellaneous & Configuration.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Store Settings</span> </a></li>
                                <li><a href="AddConfigKeyAndValues.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Miscellaneous & Configuration.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Configuration Settings</span> </a></li>
                                <li><a href="AddConfigContactDetail.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Contact.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Contact Detail</span></a></li>

                            </ul>
                        </li>

                        <li><a href="StoreInformation.aspx"><i class="fa fa-tint"></i><span>Store Details</span> </a>
                            <%--<ul class="sub-menu">
                                <li><a href="StoreInformation.aspx"><asp:Image ImageUrl="~/Admin/images/Icon/Store.png" Height="22px" Width="22px" runat="server"/><span> </span><span>Store Information</span> </a></li>
                            </ul--%>>
                        </li>

                    </ul>
                </nav>
            </div>



            <div class="main-panel">
                <header class="header navbar">
                    <div class="brand visible-xs">
                        <div class="toggle-offscreen"><a href="#" class="hamburger-icon visible-xs" data-toggle="offscreen" data-move="ltr"><span></span><span></span><span></span></a></div>
                        <div class="brand-logo">
                            <img src="images/logo-dark.5ba260bb.png" height="15" alt="">
                        </div>
                        <div class="toggle-chat"><a href="javascript:;" class="hamburger-icon v2 visible-xs" data-toggle="layout-chat-open"><span></span><span></span><span></span></a></div>
                    </div>
                    <ul class="nav navbar-nav navbar-right hidden-xs">
                        <li><a href="javascript:;" data-toggle="dropdown">
                            <img src="images/user.png" class="header-avatar img-circle ml10" alt="user" title="user">
                            <span class="pull-left" onclick="ConfirmForLogOut();">Log Out</span> </a></li>
                    </ul>
                </header>


                <div class="main-content">
                    <div class="panel mb25">
                        <div class="panel-heading border" style="font-size: medium; font-weight: bold;">Home Page Slider1 Images</div>
                        <div class="panel-body">
                            <div class="row no-margin">
                                <div class="col-lg-12">
                                    <div class="form-horizontal bordered-group" role="form">
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Slider1 Image1</label>
                                            <div class="col-sm-10">
                                                <%-- <span ID="lblFileName" runat ="server"  Visible="false"></span>--%>
                                                <asp:FileUpload ID="fuSlider1Image1" runat="server" ClientIDMode="Static" />
                                                <asp:Image ID="Slider1Img1" runat="server" Style="margin-top: 10px;" Height="100px" Width="100px" />
                                                <asp:Button Text="Remove" runat="server" ID="BtnSlider1Remove1" OnClick="BtnSlider1Remove1_Click" Style="display: none;" />
                                                <%--<asp:RequiredFieldValidator ID="rqSliderImg1" runat="server" ControlToValidate="fuImage1" ErrorMessage="sliderImage1 Required" Style="color: red"></asp:RequiredFieldValidator>--%>
                                            </div>
                                        </div>


                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Slider1 Image2</label>
                                            <div class="col-sm-10">

                                                <asp:FileUpload ID="fuSlider1Image2" runat="server" />
                                                <asp:Image ID="Slider1Img2" runat="server" Style="margin-top: 10px;" Height="100px" Width="100px" />
                                                <asp:Button Text="Remove" runat="server" ID="BtnSlider1Remove2" OnClick="BtnSlider1Remove2_Click" Style="display: none;" />
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ImgfuImage2" ErrorMessage="sliderImage2 Required" Style="color: red"></asp:RequiredFieldValidator>
                                                --%>
                                            </div>
                                        </div>


                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Slider1 Image3</label>
                                            <div class="col-sm-10">

                                                <asp:FileUpload ID="fuSlider1Image3" runat="server" />
                                                <asp:Image ID="Slider1Img3" runat="server" Style="margin-top: 10px;" Height="100px" Width="100px" />
                                                <asp:Button Text="Remove" runat="server" ID="BtnSlider1Remove3" OnClick="BtnSlider1Remove3_Click" Style="display: none;" />
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ImgfuImage3" ErrorMessage="sliderImage3 Required" Style="color: red"></asp:RequiredFieldValidator>
                                                --%>
                                            </div>
                                        </div>


                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Slider1 Image4</label>
                                            <div class="col-sm-10">

                                                <asp:FileUpload ID="fuSlider1Image4" runat="server" />
                                                <asp:Image ID="Slider1Img4" runat="server" Style="margin-top: 10px;" Height="100px" Width="100px" />
                                                <asp:Button Text="Remove" runat="server" ID="BtnSlider1Remove4" OnClick="BtnSlider1Remove4_Click" Style="display: none;" />
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ImgfuImage4" ErrorMessage="sliderImage4 Required" Style="color: red"></asp:RequiredFieldValidator>
                                                --%>
                                            </div>
                                        </div>


                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="panel-heading border" style="font-size: medium; font-weight: bold;">Home Page Bottom Slider Images</div>
                        <div class="panel-body">
                            <div class="row no-margin">
                                <div class="col-lg-12">
                                    <div class="form-horizontal bordered-group" role="form">
                                        <div class="form-group">
                                            <%--<label class="col-sm-2 control-label">Slider2 Image1</label>--%>
                                            <label class="col-sm-2 control-label">Image1</label>
                                            <div class="col-sm-10">
                                                <asp:FileUpload ID="fuSlider2Image1" runat="server" />
                                                <asp:Image ID="Slider2Img1" runat="server" Style="margin-top: 10px;" Height="100px" Width="100px" />
                                                <asp:Button Text="Remove" runat="server" ID="BtnSlider2Remove1" OnClick="BtnSlider2Remove1_Click" Style="display: none;" />

                                            </div>


                                        </div>
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Enter Text</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtImage1" CssClass="form-control" runat="server" Width="400px"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <%--<label class="col-sm-2 control-label">Slider2 Image2</label>--%>
                                            <label class="col-sm-2 control-label">Image2</label>
                                            <div class="col-sm-10">

                                                <asp:FileUpload ID="fuSlider2Image2" runat="server" />
                                                <asp:Image ID="Slider2Img2" runat="server" Style="margin-top: 10px;" Height="100px" Width="100px" />
                                                <asp:Button Text="Remove" runat="server" ID="BtnSlider2Remove2" OnClick="BtnSlider2Remove2_Click" Style="display: none;" />

                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Enter Text</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtImage2" CssClass="form-control" runat="server" Width="400px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <%--  <label class="col-sm-2 control-label">Slider2 Image3</label>--%>
                                            <label class="col-sm-2 control-label">Image3</label>
                                            <div class="col-sm-10">

                                                <asp:FileUpload ID="fuSlider2Image3" runat="server" />
                                                <asp:Image ID="Slider2Img3" runat="server" Style="margin-top: 10px;" Height="100px" Width="100px" />
                                                <asp:Button Text="Remove" runat="server" ID="BtnSlider2Remove3" OnClick="BtnSlider2Remove3_Click" Style="display: none;" />

                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Enter Text</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtImage3" CssClass="form-control" runat="server" Width="400px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <%-- <label class="col-sm-2 control-label">Slider2 Image4</label>--%>
                                            <label class="col-sm-2 control-label">Image4</label>
                                            <div class="col-sm-10">

                                                <asp:FileUpload ID="fuSlider2Image4" runat="server" />
                                                <asp:Image ID="Slider2Img4" runat="server" Style="margin-top: 10px;" Height="100px" Width="100px" />
                                                <asp:Button Text="Remove" runat="server" ID="BtnSlider2Remove4" OnClick="BtnSlider2Remove4_Click" Style="display: none;" />

                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Enter Text</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtImage4" CssClass="form-control" runat="server" Width="400px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <%--<label class="col-sm-2 control-label">Slider2 Image5</label>--%>
                                            <label class="col-sm-2 control-label">Image5</label>
                                            <div class="col-sm-10">

                                                <asp:FileUpload ID="fuSlider2Image5" runat="server" />
                                                <asp:Image ID="Slider2Img5" runat="server" Style="margin-top: 10px;" Height="100px" Width="100px" />
                                                <asp:Button Text="Remove" runat="server" ID="BtnSlider2Remove5" OnClick="BtnSlider2Remove5_Click" Style="display: none;" />

                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Enter Text</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtImage5" CssClass="form-control" runat="server" Width="400px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <%--  <label class="col-sm-2 control-label">Slider2 Image6</label>--%>
                                            <label class="col-sm-2 control-label">Image6</label>
                                            <div class="col-sm-10">

                                                <asp:FileUpload ID="fuSlider2Image6" runat="server" />
                                                <asp:Image ID="Slider2Img6" runat="server" Style="margin-top: 10px;" Height="100px" Width="100px" />
                                                <asp:Button Text="Remove" runat="server" ID="BtnSlider2Remove6" OnClick="BtnSlider2Remove6_Click" Style="display: none;" />

                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Enter Text</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtImage6" CssClass="form-control" runat="server" Width="400px"></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="panel-heading border" style="font-size: medium; font-weight: bold;">Home Page Daily Special Image</div>
                        <div class="panel-body">
                            <div class="row no-margin">
                                <div class="col-lg-12">
                                    <div class="form-horizontal bordered-group" role="form">
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Daily Special Image</label>
                                            <div class="col-sm-10">
                                                <asp:FileUpload ID="FuDailySpecialImg" runat="server" />
                                                <asp:Image ID="DailySpecialImage" runat="server" Style="margin-top: 10px;" Height="100px" Width="100px" />

                                                <asp:Button Text="Remove" runat="server" ID="DailySpecialRemove" OnClick="DailySpecialRemove_Click" Style="display: none;" />
                                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="BannerImg1" ErrorMessage="BannerImage1 Required" Style="color: red"></asp:RequiredFieldValidator>
                                                --%>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <asp:Button ID="btnAddHomeImages" CssClass="btn btn-info" runat="server" Text="Add Images" OnClick="btnAddHomeImages_Click" />
                    <asp:Button ID="btnCancel" CssClass="btn btn-info" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="false" />

                </div>

            </div>

            <footer class="content-footer">
                <nav class="footer-right">
                    <ul class="nav">
                        <li><a href="javascript:;">Top</a> </li>
                        <li><a href="javascript:;" class="scroll-up"><i class="fa fa-angle-up"></i></a></li>
                    </ul>
                </nav>
                <nav class="footer-left">
                    <ul class="nav">
                        <li><a href="javascript:;">Copyright <i class="fa fa-copyright"></i><span>TomatosPizzeria</span> 2016. All rights reserved</a> </li>
                    </ul>
                </nav>
            </footer>



            <script src="js/app.min.4fc8dd6e.js">
            </script>
            <script type="text/javascript">
                /* <![CDATA[ */
                var _gaq = _gaq || [];
                _gaq.push(['_setAccount', 'UA-50530436-1']);
                _gaq.push(['_trackPageview']);

                (function () {
                    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
                    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
                    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
                })();

                (function (b) { (function (a) { "__CF" in b && "DJS" in b.__CF ? b.__CF.DJS.push(a) : "addEventListener" in b ? b.addEventListener("load", a, !1) : b.attachEvent("onload", a) })(function () { "FB" in b && "Event" in FB && "subscribe" in FB.Event && (FB.Event.subscribe("edge.create", function (a) { _gaq.push(["_trackSocial", "facebook", "like", a]) }), FB.Event.subscribe("edge.remove", function (a) { _gaq.push(["_trackSocial", "facebook", "unlike", a]) }), FB.Event.subscribe("message.send", function (a) { _gaq.push(["_trackSocial", "facebook", "send", a]) })); "twttr" in b && "events" in twttr && "bind" in twttr.events && twttr.events.bind("tweet", function (a) { if (a) { var b; if (a.target && a.target.nodeName == "IFRAME") a: { if (a = a.target.src) { a = a.split("#")[0].match(/[^?=&]+=([^&]*)?/g); b = 0; for (var c; c = a[b]; ++b) if (c.indexOf("url") === 0) { b = unescape(c.split("=")[1]); break a } } b = void 0 } _gaq.push(["_trackSocial", "twitter", "tweet", b]) } }) }) })(window);
                /* ]]> */
            </script>
        </div>
    </form>
</body>
</html>
