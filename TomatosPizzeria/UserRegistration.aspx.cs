using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserRegistration : System.Web.UI.Page
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

            if (Session["UserEmail"] != null)
            {
                //SpanEmail.InnerHtml = Session["FirstName"].ToString();
                SignInDiv.Style.Add("display", "none");
                EmailDiv.Style.Add("display", "block");
                AccountDiv.Style.Add("display", "none");
                LogoutDiv.Style.Add("display", "block");
            }
            ErrorMsgDiv.Style.Add("display", "none");
            txtPassword.Attributes["type"] = "password";
            txtConfirmPassword.Attributes["type"] = "password";
            txtPassword.ForeColor = Color.Black;
            SuccessMessageDiv.Style.Add("display", "none");
            UserAlreadyExistsDiv.Style.Add("display", "none");



            if (!IsPostBack)
            {
                txtPassword.Attributes["type"] = "password";

                GetAllStates();
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
              //  lblFooterPhone.Text = "Phone: " + objConfig.tpc_value;
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
    protected void btnRegister_Click(object sender, EventArgs e)
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

            retMsg = objClsUserInformation.UserRegistrationmethod(txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtEmailAddress.Text.Trim(), txtPassword.Text.Trim(), txtAddress.Text.Trim(), txtCity.Text.Trim(), Convert.ToInt32(DdlState.SelectedValue), gender, txtPhone.Text.Trim(),txtPincode.Text.Trim());
            string[] response = retMsg.Split(':');
            if (response.Length > 1)
            {
                if (response[0] == "SUCCESS")
                {
                    SuccessMessageDiv.Style.Add("display", "block");
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);

        //            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You are successfully registered')", true);
                    //string message = "You are successfully registered.";
                    //string url = "Index.aspx";
                    //string script = "window.onload = function(){ alert('";
                    //script += message;
                    //script += "');";
                    //script += "window.location = '";
                    //script += url;
                    //script += "'; }";
                    //ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
                    if (response[1] != "")
                    {
                        Session["UserId"] = Convert.ToInt32(response[1]);
                        Session["UserEmail"] = objClsUserInformation.GetUserDetailsById(Convert.ToInt32(Session["UserId"])).ui_email;
                        Session["UserType"] = objClsUserInformation.GetUserDetailsById(Convert.ToInt32(Session["UserId"])).ui_usertype;
                    }
                    Response.Redirect("~/Index.aspx?IsRegister=Yes", false);
                }
                else if (retMsg == "FAIL")
                {
                    UserAlreadyExistsDiv.Style.Add("display", "block");
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);

                }
            }
            if (retMsg == "FAIL")
            {
                UserAlreadyExistsDiv.Style.Add("display", "block");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);

            }
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

            DdlState.Items.FindByText("Illinois-(IL)").Selected = true;
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }



    //protected void lnkLogin_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        Response.Redirect("~/Login.aspx", false);
    //    }
    //    catch (Exception ex)
    //    {
    //        ErrorHandler.WriteError(ex);
    //    }
    //}

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
