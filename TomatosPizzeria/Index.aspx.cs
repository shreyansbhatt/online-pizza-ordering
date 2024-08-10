using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    ClsIndex objClsIndex = new ClsIndex();
    TP_DatabaseEntities dbEntities = new TP_DatabaseEntities();
    ClsMiscellaneousSettings objClsMiscellaneousSettings = new ClsMiscellaneousSettings();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserType"] != null)
            {
                if (Session["UserType"].ToString() == "2")
                {
                    liEditProfile.Visible = false;
                    liOrderHistory.Visible = false;
                }
                else
                {
                    li1.Visible = false;
                }
            }

            SuccessMessageDiv.Style.Add("display", "none");
            if (Request.QueryString["IsRegister"] != null)
           {
               string IsRegister = Request.QueryString["IsRegister"].ToString();
               if(IsRegister=="Yes")
               {
                   SuccessMessageDiv.Style.Add("display", "block");
                  // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Your account has been created successfully')", true);
                  // Request.QueryString["IsRegister"] = null;
                   ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
               }
           }
            if (Session["UserEmail"] != null)
            {
               // SpanEmail.InnerHtml = Session["FirstName"].ToString();
                SignInDiv.Style.Add("display", "none");
                EmailDiv.Style.Add("display", "block");
                AccountDiv.Style.Add("display", "none");
                LogoutDiv.Style.Add("display", "block");
            }

            tp_config objtp_config = new tp_config();
            objtp_config = objClsIndex.GetHomePageImgUrl();

            List<tp_config> lstTPConfig = new List<tp_config>();
            lstTPConfig = objClsIndex.GetHomePageImages();

            List<tp_config> lstTPConfigText = new List<tp_config>();
            lstTPConfigText = objClsIndex.GetHomePageBottomSliderImagesText();


            if (lstTPConfig.Count > 0 && objtp_config != null)
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
                DailySpecialImg.ImageUrl = objtp_config.tpc_value + lstTPConfig[10].tpc_value;

            }

            if (lstTPConfigText.Count > 0)
            {
                lblSlider2Image1Text.Text = lstTPConfigText[0].tpc_value;
                lblSlider2Image2Text.Text = lstTPConfigText[1].tpc_value;
                lblSlider2Image3Text.Text = lstTPConfigText[2].tpc_value;
                lblSlider2Image4Text.Text = lstTPConfigText[3].tpc_value;
                lblSlider2Image5Text.Text = lstTPConfigText[4].tpc_value;
                lblSlider2Image6Text.Text = lstTPConfigText[5].tpc_value;
            }
            if (!IsPostBack)
            {
               
                GetDeliveryChargeConfigSetting();
                GetMinimumDeliveryPurchaseConfigSetting();
                GetAddressDetail();
                GetPhoneDetail();
                GetFaxDetail();
                GetEmailDetail();

                afacebbok.HRef = objClsMiscellaneousSettings.GetFaceBookLink().tpc_value;
                agoogleplus.HRef = objClsMiscellaneousSettings.GetGooglePlusLink().tpc_value;
                alinkedin.HRef = objClsMiscellaneousSettings.GetLinkedInLink().tpc_value;
                ayoutube.HRef = objClsMiscellaneousSettings.GetYouTubeLink().tpc_value;

            }
        }
        catch(Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    public void GetDeliveryChargeConfigSetting()
    {
        try
        {
            tp_config objConfig = new tp_config();
            objConfig = objClsMiscellaneousSettings.GetDeliveryChargeConfigSetting();
            if (objConfig != null)
            {
                lblDeliveryCharge.Text = objConfig.tpc_value;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    public void GetMinimumDeliveryPurchaseConfigSetting()
    {
        try
        {
            tp_config objConfig = new tp_config();
            objConfig = objClsMiscellaneousSettings.GetMinimumDeliveryPurchaseConfigSetting();
            if (objConfig != null)
            {
                lblminimumDeliveryPurchase.Text = objConfig.tpc_value;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    public void GetAddressDetail()
    {
        try
        {
            tp_config objConfig = new tp_config();
            objConfig = objClsMiscellaneousSettings.GetAddressDetail();
            if (objConfig != null)
            {
                lblAddress.Text = "Address: " + objConfig.tpc_value;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    public void GetPhoneDetail()
    {
        try
        {
            tp_config objConfig = new tp_config();
            objConfig = objClsMiscellaneousSettings.GetPhoneDetail();
            if (objConfig != null)
            {
                lblPhone.Text = "Phone: " + objConfig.tpc_value;
               // lblFooterPhone.Text = "Phone: " + objConfig.tpc_value;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    public void GetFaxDetail()
    {
        try
        {
            tp_config objConfig = new tp_config();
            objConfig = objClsMiscellaneousSettings.GetFaxDetail();
            if (objConfig != null)
            {
                lblFax.Text = "Fax: " + objConfig.tpc_value;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    public void GetEmailDetail()
    {
        try
        {
            tp_config objConfig = new tp_config();
            objConfig = objClsMiscellaneousSettings.GetEmailDetail();
            if (objConfig != null)
            {
               // lblSupportEmailOfTP.Text = objConfig.tpc_value;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void lnkMenu_Click(object sender, EventArgs e)
    {
        string filePath = string.Empty;
        tp_config configobj = new tp_config();

        configobj = dbEntities.tp_config.Where(x => x.tpc_key == "TP_MENU_PATH").FirstOrDefault();
        if (configobj != null)
        {
            filePath = configobj.tpc_value;
        }
        configobj = dbEntities.tp_config.Where(x => x.tpc_key == "MENU_FILENAME").FirstOrDefault();
        {
            filePath += configobj.tpc_value;
        }
        Response.ContentType = ContentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=\"" + Path.GetFileName(filePath) + "\"");
        Response.WriteFile(filePath);
        Response.End();
    }

    protected void Logout_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx", false);
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
}