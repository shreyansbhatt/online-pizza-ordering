using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddConfigKeyAndValues : System.Web.UI.Page
{
    ClsConfiguration objClsConfiguration = new ClsConfiguration();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    bool IsUserNameKeyExist = objClsConfiguration.IsUserNameKeyExist();
                    bool IsPasswordKeyExist = objClsConfiguration.IsPasswordKeyExist();
                    bool IsServerNameKeyExist = objClsConfiguration.IsServerNameKeyExist();
                    if (IsPasswordKeyExist == true || IsUserNameKeyExist == true || IsServerNameKeyExist == true)
                    {
                        btnConfigValues.Text = "Update Config Values";
                        GetUsernmConfigSetting();
                        GetPasswordConfigSetting();
                        GetServerNameConfigSetting();
                        FillAdminDetails();
                    }
                    else
                    {
                        btnConfigValues.Text = "Add Config Values";
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

    public void GetUsernmConfigSetting()
    {
        try
        {
            tp_config objConfig = new tp_config();
            objConfig = objClsConfiguration.GetUsernmConfigSetting();
            if (objConfig != null)
            {
                txtUserName.Text = objConfig.tpc_value;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    public void GetPasswordConfigSetting()
    {
        try
        {
            tp_config objConfig = new tp_config();
            objConfig = objClsConfiguration.GetPasswordConfigSetting();
            if (objConfig != null)
            {
                txtPassword.Attributes.Add("value", objConfig.tpc_value);
                //txtPassword.Text = objConfig.tpc_value;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    public void GetServerNameConfigSetting()
    {
        try
        {
            tp_config objConfig = new tp_config();
            objConfig = objClsConfiguration.GetServerNameConfigSetting();
            if (objConfig != null)
            {
                txtServerName.Text = objConfig.tpc_value;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    public void FillAdminDetails()
    {
        ClsUserInformation objClsUserInformation = new ClsUserInformation();
        tp_user_information dbObjUserLoginResult = new tp_user_information();

        dbObjUserLoginResult = objClsUserInformation.GetUserDetailsById(Convert.ToInt32(Session["UserId"]));

        txtAdminEmail.Text = dbObjUserLoginResult.ui_email;
        txtAdminPassword.Attributes.Add("value", dbObjUserLoginResult.ui_password);
    }
    protected void btnConfigValues_Click(object sender, EventArgs e)
    {
        string retMsg = string.Empty;
        ClsUserInformation objClsUserInformation = new ClsUserInformation();

        try
        {
            if (Page.IsValid)
            {
                tp_config objFdaConfig1 = new tp_config();
                objFdaConfig1.tpc_key = "TP_UserName";
                objFdaConfig1.tpc_value = txtUserName.Text;

                tp_config objFdaConfig2 = new tp_config();
                objFdaConfig2.tpc_key = "TP_Password";
                objFdaConfig2.tpc_value = txtPassword.Text;

                tp_config objFdaConfig3 = new tp_config();
                objFdaConfig3.tpc_key = "TP_ServerName";
                objFdaConfig3.tpc_value = txtServerName.Text;

                retMsg = objClsConfiguration.ConfigSettings(objFdaConfig1, objFdaConfig2, objFdaConfig3);

                retMsg = objClsUserInformation.ChangeAdminUserNamePassword(Convert.ToInt32(Session["UserId"]),txtAdminEmail.Text, txtAdminPassword.Text.Trim());

                if (retMsg == "SUCCESS")
                {
                    //txtUserName.Text = "";
                    //txtPassword.Text = "";
                    //txtServerName.Text = "";
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Change In Configuration Done Successfully')", true);
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