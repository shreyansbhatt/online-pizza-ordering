using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddHomePageImages : System.Web.UI.Page
{
    ClsIndex objClsIndex = new ClsIndex();
    ClsProductDetail objClsProductDetail = new ClsProductDetail();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserId"] != null)
            {
                List<tp_config> lstTPConfig = new List<tp_config>();
                lstTPConfig = objClsIndex.GetHomePageImages();
                if (lstTPConfig.Count == 0)
                {

                    btnAddHomeImages.Text = "Add Images";
                }
                else
                {

                    btnAddHomeImages.Text = "Update Images";

                    tp_config objtp_config = new tp_config();
                    objtp_config = objClsIndex.GetHomePageImgUrl();

                    Slider1Img1.ImageUrl = objtp_config.tpc_value + lstTPConfig[0].tpc_value;
                    Slider1Img2.ImageUrl = objtp_config.tpc_value + lstTPConfig[1].tpc_value;
                    Slider1Img3.ImageUrl = objtp_config.tpc_value + lstTPConfig[2].tpc_value;
                    Slider1Img4.ImageUrl = objtp_config.tpc_value + lstTPConfig[3].tpc_value;
                    Slider2Img1.ImageUrl = objtp_config.tpc_value + lstTPConfig[4].tpc_value;
                    Slider2Img2.ImageUrl = objtp_config.tpc_value + lstTPConfig[5].tpc_value;
                    Slider2Img3.ImageUrl = objtp_config.tpc_value + lstTPConfig[6].tpc_value;
                    Slider2Img4.ImageUrl = objtp_config.tpc_value + lstTPConfig[7].tpc_value;
                    Slider2Img5.ImageUrl = objtp_config.tpc_value + lstTPConfig[8].tpc_value;
                    Slider2Img6.ImageUrl = objtp_config.tpc_value + lstTPConfig[9].tpc_value;
                    DailySpecialImage.ImageUrl = objtp_config.tpc_value + lstTPConfig[10].tpc_value;

                    List<tp_config> lstTPConfigText = new List<tp_config>();
                    lstTPConfigText = objClsIndex.GetHomePageBottomSliderImagesText();


                    if (lstTPConfigText.Count > 0)
                    {
                        txtImage1.Text = lstTPConfigText[0].tpc_value;
                        txtImage2.Text = lstTPConfigText[1].tpc_value;
                        txtImage3.Text = lstTPConfigText[2].tpc_value;
                        txtImage4.Text = lstTPConfigText[3].tpc_value;
                        txtImage5.Text = lstTPConfigText[4].tpc_value;
                        txtImage6.Text = lstTPConfigText[5].tpc_value;
                    }
                    if (lstTPConfig[0].tpc_value == "")
                    {
                        BtnSlider1Remove1.Visible = false;
                        fuSlider1Image1.Visible = false;
                    }
                    if (lstTPConfig[1].tpc_value == "")
                    {
                        BtnSlider1Remove2.Visible = false;
                        fuSlider1Image2.Visible = false;
                    }
                    if (lstTPConfig[2].tpc_value == "")
                    {
                        BtnSlider1Remove3.Visible = false;
                        fuSlider1Image3.Visible = false;
                    }
                    if (lstTPConfig[3].tpc_value == "")
                    {
                        BtnSlider1Remove4.Visible = false;
                        fuSlider1Image4.Visible = false;
                    }
                    if (lstTPConfig[4].tpc_value == "")
                    {
                        BtnSlider2Remove1.Visible = false;
                        fuSlider2Image1.Visible = false;
                    }
                    if (lstTPConfig[5].tpc_value == "")
                    {
                        BtnSlider2Remove2.Visible = false;
                        fuSlider2Image2.Visible = false;
                    }
                    if (lstTPConfig[6].tpc_value == "")
                    {
                        BtnSlider2Remove3.Visible = false;
                        fuSlider2Image3.Visible = false;
                    }
                    if (lstTPConfig[7].tpc_value == "")
                    {
                        BtnSlider2Remove4.Visible = false;
                        fuSlider2Image4.Visible = false;
                    }
                    if (lstTPConfig[8].tpc_value == "")
                    {
                        BtnSlider2Remove5.Visible = false;
                        fuSlider2Image5.Visible = false;
                    }
                    if (lstTPConfig[9].tpc_value == "")
                    {
                        BtnSlider2Remove6.Visible = false;
                        fuSlider2Image6.Visible = false;
                    }
                    if (lstTPConfig[10].tpc_value == "")
                    {
                        DailySpecialRemove.Visible = false;
                        FuDailySpecialImg.Visible = false;
                    }

                }
            }
            else
            {
                Response.Redirect("~/Index.aspx", false);
            }

        }
    }

    protected void BtnSlider1Remove1_Click(object sender, EventArgs e)
    {
        try
        {
            Slider1Img1.ImageUrl = "";
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void BtnSlider1Remove2_Click(object sender, EventArgs e)
    {
        try
        {
            Slider1Img2.ImageUrl = "";
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void BtnSlider1Remove3_Click(object sender, EventArgs e)
    {
        try
        {
            Slider1Img3.ImageUrl = "";
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void BtnSlider1Remove4_Click(object sender, EventArgs e)
    {
        try
        {
            Slider1Img4.ImageUrl = "";
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void BtnSlider2Remove1_Click(object sender, EventArgs e)
    {
        try
        {
            Slider2Img1.ImageUrl = "";
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void BtnSlider2Remove2_Click(object sender, EventArgs e)
    {
        try
        {
            Slider2Img2.ImageUrl = "";
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void BtnSlider2Remove3_Click(object sender, EventArgs e)
    {
        try
        {
            Slider2Img3.ImageUrl = "";
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void BtnSlider2Remove4_Click(object sender, EventArgs e)
    {
        try
        {
            Slider2Img4.ImageUrl = "";
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void BtnSlider2Remove5_Click(object sender, EventArgs e)
    {
        try
        {
            Slider2Img5.ImageUrl = "";
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void BtnSlider2Remove6_Click(object sender, EventArgs e)
    {
        try
        {
            Slider2Img6.ImageUrl = "";
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void DailySpecialRemove_Click(object sender, EventArgs e)
    {
        try
        {
            DailySpecialImage.ImageUrl = "";
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void btnAddHomeImages_Click(object sender, EventArgs e)
    {
        try
        {
            if (fuSlider1Image1.HasFile == false && Slider1Img1.ImageUrl == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('All Images Are Required')", true);
            }
            else if (fuSlider1Image2.HasFile == false && Slider1Img2.ImageUrl == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('All Images Are Required')", true);
            }

            else if (fuSlider1Image3.HasFile == false && Slider1Img3.ImageUrl == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('All Images Are Required')", true);
            }
            else if (fuSlider1Image4.HasFile == false && Slider1Img4.ImageUrl == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('All Images Are Required')", true);
            }
            else if (fuSlider2Image1.HasFile == false && Slider2Img1.ImageUrl == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('All Images Are Required')", true);
            }
            else if (fuSlider2Image2.HasFile == false && Slider2Img2.ImageUrl == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('All Images Are Required')", true);
            }
            else if (fuSlider2Image3.HasFile == false && Slider2Img3.ImageUrl == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('All Images Are Required')", true);
            }
            else if (fuSlider2Image4.HasFile == false && Slider2Img4.ImageUrl == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('All Images Are Required')", true);
            }
            else if (fuSlider2Image5.HasFile == false && Slider2Img5.ImageUrl == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('All Images Are Required')", true);
            }
            else if (fuSlider2Image6.HasFile == false && Slider2Img6.ImageUrl == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('All Images Are Required')", true);
            }
            else if (FuDailySpecialImg.HasFile == false && DailySpecialImage.ImageUrl == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('All Images Are Required')", true);
            }
            else if (txtImage1.Text == "" || txtImage2.Text == "" || txtImage3.Text == "" || txtImage4.Text == "" || txtImage5.Text == "" || txtImage6.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Text For All Images Are Required')", true);
            }
            else
            {
                if (Page.IsValid)
                {
                    string filename1 = Path.GetFileNameWithoutExtension(fuSlider1Image1.PostedFile.FileName);
                    if (filename1 != "")
                    {
                        string ProductImgUrl = objClsIndex.GetHomePageImgUrl().tpc_value;

                        Guid gid = Guid.NewGuid();
                        filename1 = Convert.ToString(gid) + ".png";
                        Stream fs = fuSlider1Image1.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                        var jpegQuality = 50;
                        System.Drawing.Image image;
                        using (var inputStream = new MemoryStream(bytes))
                        {
                            image = System.Drawing.Image.FromStream(inputStream);
                            var jpegEncoder = ImageCodecInfo.GetImageDecoders()
                              .First(c => c.FormatID == ImageFormat.Jpeg.Guid);
                            var encoderParameters = new EncoderParameters(1);
                            encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, jpegQuality);
                            Byte[] outputBytes;
                            using (var outputStream = new MemoryStream())
                            {
                                image.Save(outputStream, jpegEncoder, encoderParameters);
                                outputBytes = outputStream.ToArray();

                                objClsProductDetail.FileUpload(outputBytes, filename1, ProductImgUrl);
                            }
                        }
                    }
                    else
                    {
                        if (Slider1Img1.ImageUrl != "")
                        {
                            filename1 = Slider1Img1.ImageUrl.Replace("/ProjectImages/HomePageImages/", "");
                        }
                    }

                    string filename2 = Path.GetFileNameWithoutExtension(fuSlider1Image2.PostedFile.FileName);
                    if (filename2 != "")
                    {

                        string ProductImgUrl = objClsIndex.GetHomePageImgUrl().tpc_value;

                        Guid gid = Guid.NewGuid();
                        filename2 = Convert.ToString(gid) + ".png";
                        Stream fs = fuSlider1Image2.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                        var jpegQuality = 50;
                        System.Drawing.Image image;
                        using (var inputStream = new MemoryStream(bytes))
                        {
                            image = System.Drawing.Image.FromStream(inputStream);
                            var jpegEncoder = ImageCodecInfo.GetImageDecoders()
                              .First(c => c.FormatID == ImageFormat.Jpeg.Guid);
                            var encoderParameters = new EncoderParameters(1);
                            encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, jpegQuality);
                            Byte[] outputBytes;
                            using (var outputStream = new MemoryStream())
                            {
                                image.Save(outputStream, jpegEncoder, encoderParameters);
                                outputBytes = outputStream.ToArray();

                                objClsProductDetail.FileUpload(outputBytes, filename2, ProductImgUrl);
                            }
                        }
                    }
                    else
                    {
                        if (Slider1Img2.ImageUrl != "")
                        {
                            filename2 = Slider1Img2.ImageUrl.Replace("/ProjectImages/HomePageImages/", "");
                        }
                    }

                    string filename3 = Path.GetFileNameWithoutExtension(fuSlider1Image3.PostedFile.FileName);
                    if (filename3 != "")
                    {

                        string ProductImgUrl = objClsIndex.GetHomePageImgUrl().tpc_value;

                        Guid gid = Guid.NewGuid();
                        filename3 = Convert.ToString(gid) + ".png";
                        Stream fs = fuSlider1Image3.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                        var jpegQuality = 50;
                        System.Drawing.Image image;
                        using (var inputStream = new MemoryStream(bytes))
                        {
                            image = System.Drawing.Image.FromStream(inputStream);
                            var jpegEncoder = ImageCodecInfo.GetImageDecoders()
                              .First(c => c.FormatID == ImageFormat.Jpeg.Guid);
                            var encoderParameters = new EncoderParameters(1);
                            encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, jpegQuality);
                            Byte[] outputBytes;
                            using (var outputStream = new MemoryStream())
                            {
                                image.Save(outputStream, jpegEncoder, encoderParameters);
                                outputBytes = outputStream.ToArray();

                                objClsProductDetail.FileUpload(outputBytes, filename3, ProductImgUrl);
                            }
                        }
                    }
                    else
                    {
                        if (Slider1Img3.ImageUrl != "")
                        {
                            filename3 = Slider1Img3.ImageUrl.Replace("/ProjectImages/HomePageImages/", "");
                        }
                    }

                    string filename4 = Path.GetFileNameWithoutExtension(fuSlider1Image4.PostedFile.FileName);
                    if (filename4 != "")
                    {

                        string ProductImgUrl = objClsIndex.GetHomePageImgUrl().tpc_value;

                        Guid gid = Guid.NewGuid();
                        filename4 = Convert.ToString(gid) + ".png";
                        Stream fs = fuSlider1Image4.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                        var jpegQuality = 50;
                        System.Drawing.Image image;
                        using (var inputStream = new MemoryStream(bytes))
                        {
                            image = System.Drawing.Image.FromStream(inputStream);
                            var jpegEncoder = ImageCodecInfo.GetImageDecoders()
                              .First(c => c.FormatID == ImageFormat.Jpeg.Guid);
                            var encoderParameters = new EncoderParameters(1);
                            encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, jpegQuality);
                            Byte[] outputBytes;
                            using (var outputStream = new MemoryStream())
                            {
                                image.Save(outputStream, jpegEncoder, encoderParameters);
                                outputBytes = outputStream.ToArray();

                                objClsProductDetail.FileUpload(outputBytes, filename4, ProductImgUrl);
                            }
                        }
                    }
                    else
                    {
                        if (Slider1Img4.ImageUrl != "")
                        {
                            filename4 = Slider1Img4.ImageUrl.Replace("/ProjectImages/HomePageImages/", "");
                        }
                    }

                    string filename5 = Path.GetFileNameWithoutExtension(fuSlider2Image1.PostedFile.FileName);
                    if (filename5 != "")
                    {
                        string ProductImgUrl = objClsIndex.GetHomePageImgUrl().tpc_value;

                        Guid gid = Guid.NewGuid();
                        filename5 = Convert.ToString(gid) + ".png";
                        Stream fs = fuSlider2Image1.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                        var jpegQuality = 50;
                        System.Drawing.Image image;
                        using (var inputStream = new MemoryStream(bytes))
                        {
                            image = System.Drawing.Image.FromStream(inputStream);
                            var jpegEncoder = ImageCodecInfo.GetImageDecoders()
                              .First(c => c.FormatID == ImageFormat.Jpeg.Guid);
                            var encoderParameters = new EncoderParameters(1);
                            encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, jpegQuality);
                            Byte[] outputBytes;
                            using (var outputStream = new MemoryStream())
                            {
                                image.Save(outputStream, jpegEncoder, encoderParameters);
                                outputBytes = outputStream.ToArray();

                                objClsProductDetail.FileUpload(outputBytes, filename5, ProductImgUrl);
                            }
                        }
                    }
                    else
                    {
                        if (Slider2Img1.ImageUrl != "")
                        {
                            filename5 = Slider2Img1.ImageUrl.Replace("/ProjectImages/HomePageImages/", "");
                        }
                    }

                    string filename6 = Path.GetFileNameWithoutExtension(fuSlider2Image2.PostedFile.FileName);
                    if (filename6 != "")
                    {
                        string ProductImgUrl = objClsIndex.GetHomePageImgUrl().tpc_value;

                        Guid gid = Guid.NewGuid();
                        filename6 = Convert.ToString(gid) + ".png";
                        Stream fs = fuSlider2Image2.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                        var jpegQuality = 50;
                        System.Drawing.Image image;
                        using (var inputStream = new MemoryStream(bytes))
                        {
                            image = System.Drawing.Image.FromStream(inputStream);
                            var jpegEncoder = ImageCodecInfo.GetImageDecoders()
                              .First(c => c.FormatID == ImageFormat.Jpeg.Guid);
                            var encoderParameters = new EncoderParameters(1);
                            encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, jpegQuality);
                            Byte[] outputBytes;
                            using (var outputStream = new MemoryStream())
                            {
                                image.Save(outputStream, jpegEncoder, encoderParameters);
                                outputBytes = outputStream.ToArray();

                                objClsProductDetail.FileUpload(outputBytes, filename6, ProductImgUrl);
                            }
                        }
                    }
                    else
                    {
                        if (Slider2Img2.ImageUrl != "")
                        {
                            filename6 = Slider2Img2.ImageUrl.Replace("/ProjectImages/HomePageImages/", "");
                        }
                    }

                    string filename7 = Path.GetFileNameWithoutExtension(fuSlider2Image3.PostedFile.FileName);
                    if (filename7 != "")
                    {
                        string ProductImgUrl = objClsIndex.GetHomePageImgUrl().tpc_value;

                        Guid gid = Guid.NewGuid();
                        filename7 = Convert.ToString(gid) + ".png";
                        Stream fs = fuSlider2Image3.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                        var jpegQuality = 50;
                        System.Drawing.Image image;
                        using (var inputStream = new MemoryStream(bytes))
                        {
                            image = System.Drawing.Image.FromStream(inputStream);
                            var jpegEncoder = ImageCodecInfo.GetImageDecoders()
                              .First(c => c.FormatID == ImageFormat.Jpeg.Guid);
                            var encoderParameters = new EncoderParameters(1);
                            encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, jpegQuality);
                            Byte[] outputBytes;
                            using (var outputStream = new MemoryStream())
                            {
                                image.Save(outputStream, jpegEncoder, encoderParameters);
                                outputBytes = outputStream.ToArray();

                                objClsProductDetail.FileUpload(outputBytes, filename7, ProductImgUrl);
                            }
                        }
                    }
                    else
                    {
                        if (Slider2Img3.ImageUrl != "")
                        {
                            filename7 = Slider2Img3.ImageUrl.Replace("/ProjectImages/HomePageImages/", "");
                        }
                    }

                    string filename8 = Path.GetFileNameWithoutExtension(fuSlider2Image4.PostedFile.FileName);
                    if (filename8 != "")
                    {
                        string ProductImgUrl = objClsIndex.GetHomePageImgUrl().tpc_value;

                        Guid gid = Guid.NewGuid();
                        filename8 = Convert.ToString(gid) + ".png";
                        Stream fs = fuSlider2Image4.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                        var jpegQuality = 50;
                        System.Drawing.Image image;
                        using (var inputStream = new MemoryStream(bytes))
                        {
                            image = System.Drawing.Image.FromStream(inputStream);
                            var jpegEncoder = ImageCodecInfo.GetImageDecoders()
                              .First(c => c.FormatID == ImageFormat.Jpeg.Guid);
                            var encoderParameters = new EncoderParameters(1);
                            encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, jpegQuality);
                            Byte[] outputBytes;
                            using (var outputStream = new MemoryStream())
                            {
                                image.Save(outputStream, jpegEncoder, encoderParameters);
                                outputBytes = outputStream.ToArray();

                                objClsProductDetail.FileUpload(outputBytes, filename8, ProductImgUrl);
                            }
                        }
                    }
                    else
                    {
                        if (Slider2Img4.ImageUrl != "")
                        {
                            filename8 = Slider2Img4.ImageUrl.Replace("/ProjectImages/HomePageImages/", "");
                        }
                    }

                    string filename9 = Path.GetFileNameWithoutExtension(fuSlider2Image5.PostedFile.FileName);
                    if (filename9 != "")
                    {
                        string ProductImgUrl = objClsIndex.GetHomePageImgUrl().tpc_value;

                        Guid gid = Guid.NewGuid();
                        filename9 = Convert.ToString(gid) + ".png";
                        Stream fs = fuSlider2Image5.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                        var jpegQuality = 50;
                        System.Drawing.Image image;
                        using (var inputStream = new MemoryStream(bytes))
                        {
                            image = System.Drawing.Image.FromStream(inputStream);
                            var jpegEncoder = ImageCodecInfo.GetImageDecoders()
                              .First(c => c.FormatID == ImageFormat.Jpeg.Guid);
                            var encoderParameters = new EncoderParameters(1);
                            encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, jpegQuality);
                            Byte[] outputBytes;
                            using (var outputStream = new MemoryStream())
                            {
                                image.Save(outputStream, jpegEncoder, encoderParameters);
                                outputBytes = outputStream.ToArray();

                                objClsProductDetail.FileUpload(outputBytes, filename9, ProductImgUrl);
                            }
                        }
                    }
                    else
                    {
                        if (Slider2Img5.ImageUrl != "")
                        {
                            filename9 = Slider2Img5.ImageUrl.Replace("/ProjectImages/HomePageImages/", "");
                        }
                    }

                    string filename10 = Path.GetFileNameWithoutExtension(fuSlider2Image6.PostedFile.FileName);
                    if (filename10 != "")
                    {
                        string ProductImgUrl = objClsIndex.GetHomePageImgUrl().tpc_value;

                        Guid gid = Guid.NewGuid();
                        filename10 = Convert.ToString(gid) + ".png";
                        Stream fs = fuSlider2Image6.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                        var jpegQuality = 50;
                        System.Drawing.Image image;
                        using (var inputStream = new MemoryStream(bytes))
                        {
                            image = System.Drawing.Image.FromStream(inputStream);
                            var jpegEncoder = ImageCodecInfo.GetImageDecoders()
                              .First(c => c.FormatID == ImageFormat.Jpeg.Guid);
                            var encoderParameters = new EncoderParameters(1);
                            encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, jpegQuality);
                            Byte[] outputBytes;
                            using (var outputStream = new MemoryStream())
                            {
                                image.Save(outputStream, jpegEncoder, encoderParameters);
                                outputBytes = outputStream.ToArray();

                                objClsProductDetail.FileUpload(outputBytes, filename10, ProductImgUrl);
                            }
                        }
                    }
                    else
                    {
                        if (Slider2Img6.ImageUrl != "")
                        {
                            filename10 = Slider2Img6.ImageUrl.Replace("/ProjectImages/HomePageImages/", "");
                        }
                    }

                    string filename11 = Path.GetFileNameWithoutExtension(FuDailySpecialImg.PostedFile.FileName);
                    if (filename11 != "")
                    {
                        string ProductImgUrl = objClsIndex.GetHomePageImgUrl().tpc_value;

                        Guid gid = Guid.NewGuid();
                        filename11 = Convert.ToString(gid) + ".png";
                        Stream fs = FuDailySpecialImg.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                        var jpegQuality = 50;
                        System.Drawing.Image image;
                        using (var inputStream = new MemoryStream(bytes))
                        {
                            image = System.Drawing.Image.FromStream(inputStream);
                            var jpegEncoder = ImageCodecInfo.GetImageDecoders()
                              .First(c => c.FormatID == ImageFormat.Jpeg.Guid);
                            var encoderParameters = new EncoderParameters(1);
                            encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, jpegQuality);
                            Byte[] outputBytes;
                            using (var outputStream = new MemoryStream())
                            {
                                image.Save(outputStream, jpegEncoder, encoderParameters);
                                outputBytes = outputStream.ToArray();

                                objClsProductDetail.FileUpload(outputBytes, filename11, ProductImgUrl);
                            }
                        }
                    }
                    else
                    {
                        if (DailySpecialImage.ImageUrl != "")
                        {
                            filename11 = DailySpecialImage.ImageUrl.Replace("/ProjectImages/HomePageImages/", "");
                        }
                    }


                    tp_config objtp_config1 = new tp_config();
                    objtp_config1.tpc_key = "SLIDER1_IMAGE1";
                    objtp_config1.tpc_value = filename1.Replace("~", "");

                    tp_config objtp_config2 = new tp_config();
                    objtp_config2.tpc_key = "SLIDER1_IMAGE2";
                    objtp_config2.tpc_value = filename2.Replace("~", "");

                    tp_config objtp_config3 = new tp_config();
                    objtp_config3.tpc_key = "SLIDER1_IMAGE3";
                    objtp_config3.tpc_value = filename3.Replace("~", "");

                    tp_config objtp_config4 = new tp_config();
                    objtp_config4.tpc_key = "SLIDER1_IMAGE4";
                    objtp_config4.tpc_value = filename4.Replace("~", "");

                    tp_config objtp_config5 = new tp_config();
                    objtp_config5.tpc_key = "SLIDER2_IMAGE1";
                    objtp_config5.tpc_value = filename5.Replace("~", "");

                    tp_config objtp_config6 = new tp_config();
                    objtp_config6.tpc_key = "SLIDER2_IMAGE2";
                    objtp_config6.tpc_value = filename6.Replace("~", "");

                    tp_config objtp_config7 = new tp_config();
                    objtp_config7.tpc_key = "SLIDER2_IMAGE3";
                    objtp_config7.tpc_value = filename7.Replace("~", "");

                    tp_config objtp_config8 = new tp_config();
                    objtp_config8.tpc_key = "SLIDER2_IMAGE4";
                    objtp_config8.tpc_value = filename8.Replace("~", "");

                    tp_config objtp_config9 = new tp_config();
                    objtp_config9.tpc_key = "SLIDER2_IMAGE5";
                    objtp_config9.tpc_value = filename9.Replace("~", "");

                    tp_config objtp_config10 = new tp_config();
                    objtp_config10.tpc_key = "SLIDER2_IMAGE6";
                    objtp_config10.tpc_value = filename10.Replace("~", "");

                    tp_config objtp_config11 = new tp_config();
                    objtp_config11.tpc_key = "DAILY_SPECIAL_IMAGE";
                    objtp_config11.tpc_value = filename11.Replace("~", "");

                    tp_config objtp_config12 = new tp_config();
                    objtp_config12.tpc_key = "SLIDER2_IMAGE1_TEXT";
                    objtp_config12.tpc_value = txtImage1.Text.Trim();

                    tp_config objtp_config13 = new tp_config();
                    objtp_config13.tpc_key = "SLIDER2_IMAGE2_TEXT";
                    objtp_config13.tpc_value = txtImage2.Text.Trim();

                    tp_config objtp_config14 = new tp_config();
                    objtp_config14.tpc_key = "SLIDER2_IMAGE3_TEXT";
                    objtp_config14.tpc_value = txtImage3.Text.Trim();

                    tp_config objtp_config15 = new tp_config();
                    objtp_config15.tpc_key = "SLIDER2_IMAGE4_TEXT";
                    objtp_config15.tpc_value = txtImage4.Text.Trim();

                    tp_config objtp_config16 = new tp_config();
                    objtp_config16.tpc_key = "SLIDER2_IMAGE5_TEXT";
                    objtp_config16.tpc_value = txtImage5.Text.Trim();

                    tp_config objtp_config17 = new tp_config();
                    objtp_config17.tpc_key = "SLIDER2_IMAGE6_TEXT";
                    objtp_config17.tpc_value = txtImage6.Text.Trim();

                    string retMsg = objClsIndex.AddUpdateHomePageImages(objtp_config1, objtp_config2, objtp_config3, objtp_config4, objtp_config5, objtp_config6, objtp_config7, objtp_config8, objtp_config9, objtp_config10, objtp_config11,objtp_config12,objtp_config13,objtp_config14,objtp_config15,objtp_config16,objtp_config17);
                    if (retMsg == "SUCCESS")
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Home page changed successfully')", true);

                        tp_config objtp_config = new tp_config();
                        objtp_config = objClsIndex.GetHomePageImgUrl();

                        List<tp_config> lstTPConfig = new List<tp_config>();
                        lstTPConfig = objClsIndex.GetHomePageImages();

                        List<tp_config> lstTPConfigText = new List<tp_config>();
                        lstTPConfigText = objClsIndex.GetHomePageBottomSliderImagesText();

                        if (lstTPConfig.Count > 0)
                        {
                            Slider1Img1.ImageUrl = objtp_config.tpc_value + lstTPConfig[0].tpc_value;
                            Slider1Img2.ImageUrl = objtp_config.tpc_value + lstTPConfig[1].tpc_value;
                            Slider1Img3.ImageUrl = objtp_config.tpc_value + lstTPConfig[2].tpc_value;
                            Slider1Img4.ImageUrl = objtp_config.tpc_value + lstTPConfig[3].tpc_value;
                            Slider2Img1.ImageUrl = objtp_config.tpc_value + lstTPConfig[4].tpc_value;
                            Slider2Img2.ImageUrl = objtp_config.tpc_value + lstTPConfig[5].tpc_value;
                            Slider2Img3.ImageUrl = objtp_config.tpc_value + lstTPConfig[6].tpc_value;
                            Slider2Img4.ImageUrl = objtp_config.tpc_value + lstTPConfig[7].tpc_value;
                            Slider2Img5.ImageUrl = objtp_config.tpc_value + lstTPConfig[8].tpc_value;
                            Slider2Img6.ImageUrl = objtp_config.tpc_value + lstTPConfig[9].tpc_value;
                            DailySpecialImage.ImageUrl = objtp_config.tpc_value + lstTPConfig[10].tpc_value;

                            if (lstTPConfig[0].tpc_value == "")
                            {
                                BtnSlider1Remove1.Visible = false;
                                Slider1Img1.Visible = false;
                            }
                            if (lstTPConfig[1].tpc_value == "")
                            {
                                BtnSlider1Remove2.Visible = false;
                                Slider1Img2.Visible = false;
                            }
                            if (lstTPConfig[2].tpc_value == "")
                            {
                                BtnSlider1Remove3.Visible = false;
                                Slider1Img3.Visible = false;
                            }
                            if (lstTPConfig[3].tpc_value == "")
                            {
                                BtnSlider1Remove4.Visible = false;
                                Slider1Img4.Visible = false;
                            }
                            if (lstTPConfig[4].tpc_value == "")
                            {
                                BtnSlider2Remove1.Visible = false;
                                Slider2Img1.Visible = false;
                            }
                            if (lstTPConfig[5].tpc_value == "")
                            {
                                BtnSlider2Remove2.Visible = false;
                                Slider2Img2.Visible = false;
                            }
                            if (lstTPConfig[6].tpc_value == "")
                            {
                                BtnSlider2Remove3.Visible = false;
                                Slider2Img3.Visible = false;
                            }
                            if (lstTPConfig[7].tpc_value == "")
                            {
                                BtnSlider2Remove4.Visible = false;
                                Slider2Img4.Visible = false;
                            }
                            if (lstTPConfig[8].tpc_value == "")
                            {
                                BtnSlider2Remove5.Visible = false;
                                Slider2Img5.Visible = false;
                            }
                            if (lstTPConfig[9].tpc_value == "")
                            {
                                BtnSlider2Remove6.Visible = false;
                                Slider2Img6.Visible = false;
                            }
                            if (lstTPConfig[10].tpc_value == "")
                            {
                                DailySpecialRemove.Visible = false;
                                DailySpecialImage.Visible = false;
                            }


                        }

                        if(lstTPConfigText.Count>0)
                        {
                            txtImage1.Text = lstTPConfigText[0].tpc_value;
                            txtImage2.Text = lstTPConfigText[1].tpc_value;
                            txtImage3.Text = lstTPConfigText[2].tpc_value;
                            txtImage4.Text = lstTPConfigText[3].tpc_value;
                            txtImage5.Text = lstTPConfigText[4].tpc_value;
                            txtImage6.Text = lstTPConfigText[5].tpc_value;
                        }
                        //Response.Redirect("~/Admin/AddHomePageImages.aspx", false);
                        //btnImg1.Visible = false;
                        //btnImg2.Visible = false;
                        //btnImg3.Visible = false;
                        //btnImg4.Visible = false;
                        //btnImg5.Visible = false;
                        //BtnBannerRemove1.Visible = false;
                        //BtnBannerRemove2.Visible = false;
                    }
                }

            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Write("<script language='javascript'> window.close();</javascript>");
    }

    protected void BtnLogOut_Click(object sender, EventArgs e)
    {
        try
        {
            string confirmValue = hdnfldVariable.Value;
            if (confirmValue == "Yes")
            {
                Session.Abandon();
                Response.Redirect("~/Login.aspx", false);
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
}