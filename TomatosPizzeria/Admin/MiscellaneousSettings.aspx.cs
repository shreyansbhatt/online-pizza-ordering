using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_MiscellaneousSettings : System.Web.UI.Page
{
    ClsMiscellaneousSettings objClsMiscellaneousSettings = new ClsMiscellaneousSettings();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    bool IsTaxKeyExist = objClsMiscellaneousSettings.IsTaxKeyExist();
                    if (IsTaxKeyExist == true)
                    {
                        btnAddMiscellaneousTaxSetting.Text = "Update Miscellaneous Tax Setting";
                        GetTaxConfigSetting();
                    }
                    else
                    {
                        btnAddMiscellaneousTaxSetting.Text = "Add Miscellaneous Tax Setting";
                    }

                    bool IsDeliveryChargeKeyExist = objClsMiscellaneousSettings.IsDeliveryChargeKeyExist();
                    if (IsDeliveryChargeKeyExist == true)
                    {
                        btnAddMiscellaneousDeliveryChargesSetting.Text = "Update Miscellaneous Delivery Charge Setting";
                        GetDeliveryChargeConfigSetting();
                    }
                    else
                    {
                        btnAddMiscellaneousDeliveryChargesSetting.Text = "Add Miscellaneous Delivery Charge Setting";
                    }

                    bool IsMinimumDeliveryPurchaseKeyExist = objClsMiscellaneousSettings.isMinimumDeliveryPurchaseKeyExist();
                    if (IsMinimumDeliveryPurchaseKeyExist == true)
                    {
                        btnAddMinimunDliveryPurchase.Text = "Update Miscellaneous Minimum Delivery Purchase Setting";
                        GetMinimumDeliveryPurchaseConfigSetting();
                    }
                    else
                    {
                        btnAddMinimunDliveryPurchase.Text = "Add Miscellaneous Minimum Delivery Purchase Setting";
                    }

                    bool isOnlinePaymentKeyExist = objClsMiscellaneousSettings.isOnlinePaymentKeyExist();
                    if (isOnlinePaymentKeyExist == true)
                    {
                        btnUpdateOnlinePayment.Text = "Update Online Payment Setting";
                        GetOnlinePaymentConfigSetting();
                    }
                    else
                    {
                        btnUpdateOnlinePayment.Text = "Add Online Payment Setting";
                    }

                    txtFaceBookLink.Text = objClsMiscellaneousSettings.GetFaceBookLink().tpc_value;
                    txtGooglePlusLink.Text = objClsMiscellaneousSettings.GetGooglePlusLink().tpc_value;
                    txtLinkedInLink.Text = objClsMiscellaneousSettings.GetLinkedInLink().tpc_value;
                    txtYouTubeLink.Text = objClsMiscellaneousSettings.GetYouTubeLink().tpc_value;
                }
                else
                {
                    Response.Redirect("~/Index.aspx", false);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    public void GetTaxConfigSetting()
    {
        try
        {
            tp_config objConfig = new tp_config();
            objConfig = objClsMiscellaneousSettings.GetTaxConfigSetting();
            if (objConfig != null)
            {
                txttax.Text = objConfig.tpc_value;
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
                txtDeliveryCharge.Text = objConfig.tpc_value;
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
                txtMinimunDeliveryPurchase.Text = objConfig.tpc_value;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    public void GetOnlinePaymentConfigSetting()
    {
        try
        {
            tp_config objConfig = new tp_config();
            objConfig = objClsMiscellaneousSettings.GetOnlinePaymentConfigSetting();
            if (objConfig != null)
            {
                if (objConfig.tpc_value.Contains("True") || objConfig.tpc_value.Contains("true"))
                {
                    rdbOn.Checked = true;
                }
                else
                {
                    rdboff.Checked = true;
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    protected void btnAddMiscellaneousTaxSetting_Click(object sender, EventArgs e)
    {
        ClsMiscellaneousSettings objClsMiscellaneousSettings = new ClsMiscellaneousSettings();
        string retMsg = string.Empty;

        try
        {
            if (Page.IsValid)
            {
                tp_config objTPConfig = new tp_config();
                objTPConfig.tpc_key = "TAX_DETAILS";
                if (txttax.Text.Contains("%"))
                {
                    objTPConfig.tpc_value = txttax.Text;
                }
                else
                {
                    txttax.Text = txttax.Text + "%";
                    objTPConfig.tpc_value = txttax.Text;
                }

                retMsg = objClsMiscellaneousSettings.MiscellaneousTaxSettings(objTPConfig);

                if (retMsg == "SUCCESS")
                {
                    //txtDeliveryCharge.Text = "";
                    //txttax.Text = "";
                    //txtMinimunDeliveryPurchase.Text = "";
                    //rdboff.Checked = false;
                    //rdbOn.Checked = false;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Miscellaneous Tax Settings Done Successfully')", true);
                }

            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }

    }

    protected void btnAddMiscellaneousDeliveryChargesSetting_Click(object sender, EventArgs e)
    {
        ClsMiscellaneousSettings objClsMiscellaneousSettings = new ClsMiscellaneousSettings();
        string retMsg = string.Empty;

        try
        {
            if (Page.IsValid)
            {
                tp_config TPConfig = new tp_config();
                TPConfig.tpc_key = "DELIVERY_CHARGES_DETAILS";
                if (txtDeliveryCharge.Text.Contains("$"))
                {
                    TPConfig.tpc_value = txtDeliveryCharge.Text;
                }
                else
                {
                    txtDeliveryCharge.Text = "$" + txtDeliveryCharge.Text;
                    TPConfig.tpc_value = txtDeliveryCharge.Text;
                }


                retMsg = objClsMiscellaneousSettings.MiscellaneousDeliveryChargeSettings(TPConfig);

                if (retMsg == "SUCCESS")
                {
                    //txtDeliveryCharge.Text = "";
                    //txttax.Text = "";
                    //txtMinimunDeliveryPurchase.Text = "";
                    //rdboff.Checked = false;
                    //rdbOn.Checked = false;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Miscellaneous Delivery Charge Settings Done Successfully')", true);
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

    protected void btnAddMinimunDliveryPurchase_Click(object sender, EventArgs e)
    {
        ClsMiscellaneousSettings objClsMiscellaneousSettings = new ClsMiscellaneousSettings();
        string retMsg = string.Empty;

        try
        {
            if (Page.IsValid)
            {

                tp_config TPConfig = new tp_config();
                TPConfig.tpc_key = "MINIMUM_DELIVERY_PURCHASE";
                if (txtMinimunDeliveryPurchase.Text.Contains("$"))
                {
                    TPConfig.tpc_value = txtMinimunDeliveryPurchase.Text;
                }
                else
                {
                    txtMinimunDeliveryPurchase.Text = "$" + txtMinimunDeliveryPurchase.Text;
                    TPConfig.tpc_value = txtMinimunDeliveryPurchase.Text;
                }


                retMsg = objClsMiscellaneousSettings.MiscellaneousDeliveryChargeSettings(TPConfig);

                if (retMsg == "SUCCESS")
                {
                    //txtDeliveryCharge.Text = "";
                    //txttax.Text = "";
                    //txtMinimunDeliveryPurchase.Text = "";
                    //rdboff.Checked = false;
                    //rdbOn.Checked = false;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Miscellaneous Minimum Delivery Purchase Settings Done Successfully')", true);
                }
            }

        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    protected void btnUpdateOnlinePayment_Click(object sender, EventArgs e)
    {
        ClsMiscellaneousSettings objClsMiscellaneousSettings = new ClsMiscellaneousSettings();
        string retMsg = string.Empty;

        try
        {
            if (Page.IsValid)
            {
                if (rdboff.Checked == false && rdbOn.Checked == false)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You Need To Select Any One RadioButton')", true);
                }
                else
                {
                    tp_config TPConfig = new tp_config();
                    TPConfig.tpc_key = "ONLINE_PAYMENT";
                    if (rdbOn.Checked == true)
                    {
                        TPConfig.tpc_value = "True";
                    }
                    else
                    {
                        TPConfig.tpc_value = "False";
                    }


                    retMsg = objClsMiscellaneousSettings.MiscellaneousOnlinePaymentSetting(TPConfig);

                    if (retMsg == "SUCCESS")
                    {
                        //rdboff.Checked =false;
                        //rdbOn.Checked =false;
                        //txtDeliveryCharge.Text = "";
                        //txttax.Text = "";
                        //txtMinimunDeliveryPurchase.Text = "";
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Miscellaneous Online Payment Settings Done Successfully')", true);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void BtnLogOut_Click(object sender, EventArgs e)
    {
        try
        {
            string confirmValue = hdfLogout.Value;
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
    protected void btnfacebooklink_Click(object sender, EventArgs e)
    {

        ClsMiscellaneousSettings objClsMiscellaneousSettings = new ClsMiscellaneousSettings();
        string retMsg = string.Empty;

        try
        {
            if (Page.IsValid)
            {
                tp_config TPConfig = new tp_config();
                TPConfig.tpc_key = "FACEBOOK_LINK";

                TPConfig.tpc_value = txtFaceBookLink.Text;

                retMsg = objClsMiscellaneousSettings.UpdateSocialNetworkingLink(TPConfig);

                if (retMsg == "SUCCESS")
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Facebook Link Updated Successfully')", true);
                }

            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    protected void btnGooglePlusLink_Click(object sender, EventArgs e)
    {
        ClsMiscellaneousSettings objClsMiscellaneousSettings = new ClsMiscellaneousSettings();
        string retMsg = string.Empty;

        try
        {
            if (Page.IsValid)
            {
                tp_config TPConfig = new tp_config();
                TPConfig.tpc_key = "GOOGLEPLUS_LINK";

                TPConfig.tpc_value = txtGooglePlusLink.Text;

                retMsg = objClsMiscellaneousSettings.UpdateSocialNetworkingLink(TPConfig);

                if (retMsg == "SUCCESS")
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Google Plus Link Updated Successfully')", true);
                }

            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    protected void btnLinkedInLink_Click(object sender, EventArgs e)
    {
        ClsMiscellaneousSettings objClsMiscellaneousSettings = new ClsMiscellaneousSettings();
        string retMsg = string.Empty;

        try
        {
            if (Page.IsValid)
            {
                tp_config TPConfig = new tp_config();
                TPConfig.tpc_key = "LINKEDIN_LINK";

                TPConfig.tpc_value = txtLinkedInLink.Text;

                retMsg = objClsMiscellaneousSettings.UpdateSocialNetworkingLink(TPConfig);

                if (retMsg == "SUCCESS")
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('LinkedIn Link Updated Successfully')", true);
                }

            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    protected void btnYouTubeLink_Click(object sender, EventArgs e)
    {
        ClsMiscellaneousSettings objClsMiscellaneousSettings = new ClsMiscellaneousSettings();
        string retMsg = string.Empty;

        try
        {
            if (Page.IsValid)
            {
                tp_config TPConfig = new tp_config();
                TPConfig.tpc_key = "www.youtube.com";

                TPConfig.tpc_value = txtYouTubeLink.Text;

                retMsg = objClsMiscellaneousSettings.UpdateSocialNetworkingLink(TPConfig);

                if (retMsg == "SUCCESS")
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('YouTube Link Updated Successfully')", true);
                }

            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
}