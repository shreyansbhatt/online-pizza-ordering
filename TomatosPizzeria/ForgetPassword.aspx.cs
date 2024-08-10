using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ForgetPassword : System.Web.UI.Page
{
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

            ErrorMsgDiv.Style.Add("display", "none");
            if (Session["UserEmail"] != null)
            {
                // SpanEmail.InnerHtml = Session["FirstName"].ToString();
                SignInDiv.Style.Add("display", "none");
                EmailDiv.Style.Add("display", "block");
                AccountDiv.Style.Add("display", "none");
                LogoutDiv.Style.Add("display", "block");
            }
            ErrorMessageDiv.Style.Add("display", "none");
            SuccessMessageDiv.Style.Add("display", "none");
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
        catch (Exception ex)
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
                //lblFooterPhone.Text = "Phone: " + objConfig.tpc_value;
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

    protected void btnResetPassword_Click(object sender, EventArgs e)
    {
        string retmsg = string.Empty;

        try
        {
            ClsUserInformation objClsUserInformation = new ClsUserInformation();

            if (Page.IsValid)
            {
                retmsg = objClsUserInformation.ForgetPassword(txtEmailAddress.Text.Trim());

                if (retmsg == "SUCCESS")
                {
                    SuccessMessageDiv.Style.Add("display", "block");
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);

                }
                else if (retmsg == "FAIL")
                {
                    ErrorMessageDiv.Style.Add("display", "block");
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
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
}