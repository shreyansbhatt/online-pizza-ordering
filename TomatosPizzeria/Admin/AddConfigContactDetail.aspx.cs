using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddConfigContactDetail : System.Web.UI.Page
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
                    bool IsContactKeyExist = objClsMiscellaneousSettings.IsContactKeyExist();
                    if (IsContactKeyExist == true)
                    {
                        btnAddContactDetail.Text = "Update Contact Detail";
                        GetAddressDetail();
                        GetPhoneDetail();
                        GetFaxDetail();
                        GetEmailDetail();
                    }
                    else
                    {
                        btnAddContactDetail.Text = "Add Contact Detail";
                    }

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
    public void GetAddressDetail()
    {
        try
        {
            tp_config objConfig = new tp_config();
            objConfig = objClsMiscellaneousSettings.GetAddressDetail();
            if (objConfig != null)
            {
                txtAddress.Text = objConfig.tpc_value;
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
                txtPhoneNo.Text = objConfig.tpc_value;
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
                txtFaxNo.Text = objConfig.tpc_value;
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
                txtEmailId.Text = objConfig.tpc_value;
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



    protected void btnAddContactDetail_Click(object sender, EventArgs e)
    {
        ClsMiscellaneousSettings objClsMiscellaneousSettings = new ClsMiscellaneousSettings();
        string retMsgAddress = string.Empty;
        string retMsgPhone = string.Empty;
        string retMsgFax = string.Empty;
        string retMsgEmail = string.Empty;

        try
        {
            if (Page.IsValid)
            {
                if (btnAddContactDetail.Text == "Add Contact Detail")
                {
                    //.................Address.....................................
                    tp_config objTPAddressConfig = new tp_config();
                    objTPAddressConfig.tpc_key = "TP_ADDRESS_DETAIL";

                    objTPAddressConfig.tpc_value = txtAddress.Text;
                    retMsgAddress = objClsMiscellaneousSettings.AddressSetting(objTPAddressConfig);
                    //.................Phone.....................................
                    tp_config objTPPhoneConfig = new tp_config();
                    objTPPhoneConfig.tpc_key = "TP_PHONE_DETAIL";

                    objTPPhoneConfig.tpc_value = txtPhoneNo.Text;

                    retMsgPhone = objClsMiscellaneousSettings.PhoneSetting(objTPPhoneConfig);

                    //.................Fax.....................................
                    tp_config objTPFaxConfig = new tp_config();
                    objTPFaxConfig.tpc_key = "TP_FAX_DETAIL";

                    objTPFaxConfig.tpc_value = txtFaxNo.Text;

                    retMsgFax = objClsMiscellaneousSettings.FaxSetting(objTPFaxConfig);

                    //.................Email.....................................
                    tp_config objTPEmailConfig = new tp_config();
                    objTPEmailConfig.tpc_key = "TP_SUPPORT_EMAIL_DETAIL";

                    objTPEmailConfig.tpc_value = txtEmailId.Text;

                    retMsgEmail = objClsMiscellaneousSettings.EmailSetting(objTPEmailConfig);

                    if (retMsgAddress == "SUCCESS" && retMsgPhone == "SUCCESS" && retMsgFax == "SUCCESS" && retMsgEmail == "SUCCESS")
                    {
                        //txtAddress.Text = "";
                        //txtPhoneNo.Text = "";
                        //txtFaxNo.Text = "";

                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Contact Settings Add Successfully')", true);
                    }

                }
                else if (btnAddContactDetail.Text == "Update Contact Detail")
                {
                    //.................Address.....................................
                    tp_config objTPAddressConfig = new tp_config();
                    objTPAddressConfig.tpc_key = "TP_ADDRESS_DETAIL";

                    objTPAddressConfig.tpc_value = txtAddress.Text;
                    retMsgAddress = objClsMiscellaneousSettings.AddressSetting(objTPAddressConfig);
                    //.................Phone.....................................
                    tp_config objTPPhoneConfig = new tp_config();
                    objTPPhoneConfig.tpc_key = "TP_PHONE_DETAIL";

                    objTPPhoneConfig.tpc_value = txtPhoneNo.Text;

                    retMsgPhone = objClsMiscellaneousSettings.PhoneSetting(objTPPhoneConfig);

                    //.................Fax.....................................
                    tp_config objTPFaxConfig = new tp_config();
                    objTPFaxConfig.tpc_key = "TP_FAX_DETAIL";

                    objTPFaxConfig.tpc_value = txtFaxNo.Text;

                    retMsgFax = objClsMiscellaneousSettings.FaxSetting(objTPFaxConfig);

                    //.................Email.....................................
                    tp_config objTPEmailConfig = new tp_config();
                    objTPEmailConfig.tpc_key = "TP_SUPPORT_EMAIL_DETAIL";

                    objTPEmailConfig.tpc_value = txtEmailId.Text;

                    retMsgEmail = objClsMiscellaneousSettings.EmailSetting(objTPEmailConfig);

                    if (retMsgAddress == "SUCCESS" || retMsgPhone == "SUCCESS" || retMsgFax == "SUCCESS" || retMsgEmail == "SUCCESS")
                    {
                        //txtAddress.Text = "";
                        //txtPhoneNo.Text = "";
                        //txtFaxNo.Text = "";

                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Contact Settings Updated Successfully')", true);
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
}