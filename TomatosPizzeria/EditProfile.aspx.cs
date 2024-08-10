using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditProfile : System.Web.UI.Page
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

            ClsUserInformation objClsUserInformation = new ClsUserInformation();
            if (Session["UserEmail"] != null)
            {
                // SpanEmail.InnerHtml = Session["FirstName"].ToString();
                EmailDiv.Style.Add("display", "block");


            }
            //txtPassword.Attributes["type"] = "password";
            //txtConfirmPassword.Attributes["type"] = "password";

            ErrorMessageDiv.Style.Add("display", "none");
            SuccessMessageDiv.Style.Add("display", "none");
            ErrorMsgDiv.Style.Add("display", "none");

            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    GetAllStates();
                    FillUserDetails();
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
                //lblSupportEmailOfTP.Text = objConfig.tpc_value;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void btnEditProfile_Click(object sender, EventArgs e)
    {

        string retMsg = string.Empty;
        int gender = 0;

        try
        {
            ClsUserInformation objClsUserInformation = new ClsUserInformation();
            if (rdbMale.Checked)
            {
                gender = 0;
            }
            if (rdbfemale.Checked)
            {
                gender = 1;
            }
            //if (txtFirstName.Text.Equals("FirstName"))
            //{
            //    txtFirstName.Text = "";

            //}
            //if (txtLastName.Text.Equals("LastName"))
            //{
            //    txtLastName.Text = "";
            //}
            //string userName = txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim();
            //if (txtMobile.Text.Equals("Mobile"))
            //{
            //    txtMobile.Text = "";
            //}
            //if (txtAddress1.Text.Equals("AddressLine1"))
            //{
            //    txtAddress1.Text = "";
            //}
            //if (txtAddress2.Text.Equals("AddressLine2"))
            //{
            //    txtAddress2.Text = "";
            //}

            //if (txtHouseNo.Text.Equals("House Name/No."))
            //{
            //    txtHouseNo.Text = "";
            //}
            //if (txtStreetName.Text.Equals("Street Name"))
            //{
            //    txtStreetName.Text = "";
            //}
            //if (txtMobile.Text.Equals("Mobile"))
            //{
            //    txtMobile.Text = "";
            //}
            retMsg = objClsUserInformation.UpdateUser(Convert.ToInt32(Session["UserId"]), string.Empty, txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtEmailAddress.Text.Trim(), txtEmailAddress.Text.Trim(), txtPassword.Text.Trim(), string.Empty, txtPhone.Text.Trim(), 0, Convert.ToInt32(DdlState.SelectedValue), txtCity.Text.Trim(), string.Empty, gender, txtAddress.Text.Trim(), string.Empty, string.Empty, string.Empty, txtPincode.Text);

            if (retMsg == "SUCCESS")
            {
                SuccessMessageDiv.Style.Add("display", "block");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
            }
            else if (retMsg == "FAIL")
            {
                ErrorMessageDiv.Style.Add("display", "block");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    public void FillUserDetails()
    {

        try
        {
            ClsUserInformation objClsUserInformation = new ClsUserInformation();
            tp_user_information dbObjUserLoginResult = new tp_user_information();

            dbObjUserLoginResult = objClsUserInformation.GetUserDetailsById(Convert.ToInt32(Session["UserId"]));

            if (dbObjUserLoginResult.ui_firstName == null || dbObjUserLoginResult.ui_firstName.Equals(""))
            {
                txtFirstName.Text = "First Name";

            }
            else
            {
                txtFirstName.Text = dbObjUserLoginResult.ui_firstName;

            }
            if (dbObjUserLoginResult.ui_lastName == null || dbObjUserLoginResult.ui_lastName.Equals(""))
            {
                txtLastName.Text = "Last Name";

            }
            else
            {
                txtLastName.Text = dbObjUserLoginResult.ui_lastName;

            }

            txtEmailAddress.Text = dbObjUserLoginResult.ui_email;
            txtPassword.Attributes.Add("value", dbObjUserLoginResult.ui_password);
            txtConfirmPassword.Attributes.Add("value", dbObjUserLoginResult.ui_password);
            //txtPassword.Text = dbObjUserLoginResult.ui_password;
            //txtConfirmPassword.Text = dbObjUserLoginResult.ui_password;

            if (dbObjUserLoginResult.ui_gender == 0)
                rdbMale.Checked = true;
            else if (dbObjUserLoginResult.ui_gender == 1)
                rdbfemale.Checked = true;
            if (dbObjUserLoginResult.ui_addressLine1 == null || dbObjUserLoginResult.ui_addressLine1.Equals(""))
            {
                txtAddress.Text = "Address";
            }
            else
            {
                txtAddress.Text = dbObjUserLoginResult.ui_addressLine1;
            }
            //if (dbObjUserLoginResult.ui_street == null || dbObjUserLoginResult.ui_street.Equals(""))
            //{
            //    txtStreetName.Text = "Street Name";
            //}
            //else
            //{
            //    txtStreetName.Text = dbObjUserLoginResult.ui_street;
            //}
            //if (dbObjUserLoginResult.ui_addressLine1 == null || dbObjUserLoginResult.ui_addressLine1.Equals(""))
            //{
            //    txtAddress1.Text = "AddressLine1";
            //}
            //else
            //{
            //    txtAddress1.Text = dbObjUserLoginResult.ui_addressLine1;
            //}
            //if (dbObjUserLoginResult.ui_addressLine2 == null || dbObjUserLoginResult.ui_addressLine2.Equals(""))
            //{
            //    txtAddress2.Text = "AddressLine2";
            //}
            //else
            //{
            //    txtAddress2.Text = dbObjUserLoginResult.ui_addressLine2;
            //}
            if (dbObjUserLoginResult.ui_city == null || dbObjUserLoginResult.ui_city.Equals(""))
            {
                txtCity.Text = "City";
            }
            else
            {
                txtCity.Text = dbObjUserLoginResult.ui_city;
            }

            DdlState.SelectedValue = Convert.ToString(dbObjUserLoginResult.ui_state_id);
            if (dbObjUserLoginResult.ui_pincode == null || dbObjUserLoginResult.ui_pincode.Equals(""))
            {
                txtPincode.Text = "ZipCode";
            }
            else
            {
                txtPincode.Text = dbObjUserLoginResult.ui_pincode;
            }
            if (dbObjUserLoginResult.ui_telephone == null || dbObjUserLoginResult.ui_telephone.Equals(""))
            {
                txtPhone.Text = "Phone";
            }
            else
            {
                txtPhone.Text = dbObjUserLoginResult.ui_telephone;
            }
            //if (dbObjUserLoginResult.ui_mobile == null || dbObjUserLoginResult.ui_mobile.Equals(""))
            //{
            //    txtMobile.Text = "Mobile";
            //}
            //else
            //{
            //    txtMobile.Text = dbObjUserLoginResult.ui_mobile;
            //}

        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    public void GetAllStates()
    {
        try
        {
            ClsUserInformation objClsUserInformation = new ClsUserInformation();
            List<tp_state> lstFdaStateInformation = new List<tp_state>();

            lstFdaStateInformation = objClsUserInformation.GetAllStates();
            DdlState.DataSource = lstFdaStateInformation;
            DdlState.DataValueField = "tps_id";
            DdlState.DataTextField = "tps_state_name";
            DdlState.DataBind();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void lnkChangePassword_Click(object sender, EventArgs e)
    {

        try
        {
            Response.Redirect("~/ResetPassword.aspx", false);
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