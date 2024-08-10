using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddMenuItemMakingMethodInformation : System.Web.UI.Page
{
    int makingMethodId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    if (Request.QueryString["MakingMethodId"] != null)
                    {
                        btnAddMakingMethod.Text = "Update Making Method";
                        makingMethodId = Convert.ToInt32(Request.QueryString["MakingMethodId"]);

                        GetMakingMethodInformationById();
                    }
                    else
                    {
                        btnAddMakingMethod.Text = "Add Making Method";
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
    public void GetMakingMethodInformationById()
    {
        ClsProductMakingMethod objClsProductMakingMethod = new ClsProductMakingMethod();
        try
        {
            tp_product_making_method objTPMakingMethodInformation = new tp_product_making_method();

            objTPMakingMethodInformation = objClsProductMakingMethod.GetProductMakingMethodByProductMakingMethodId(Convert.ToInt32(Request.QueryString["MakingMethodId"]));

            txtmakingMethodName.Text = objTPMakingMethodInformation.pmm_name;
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }

    }

    protected void btnAddMakingMethod_Click(object sender, EventArgs e)
    {

        ClsProductMakingMethod objClsProductMakingMethod = new ClsProductMakingMethod();
        string retMsg = string.Empty;
        bool isMakingMethodExists = false;

        try
        {
            if (Page.IsValid)
            {
                if (btnAddMakingMethod.Text == "Add Making Method")
                {
                    isMakingMethodExists = objClsProductMakingMethod.isProductMakingMethodExist(txtmakingMethodName.Text);
                    if (isMakingMethodExists == true)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Making Method Already exists')", true);
                    }
                    else
                    {
                        retMsg = objClsProductMakingMethod.InsertNewProductMakingMethod(txtmakingMethodName.Text.Trim(), Convert.ToInt32(Session["UserId"]));

                        if (retMsg == "SUCCESS")
                        {
                            string message = "Making Method Added Successfully.";
                            string url = "MenuItemMakingMethodInformation.aspx";
                            string script = "window.onload = function(){ alert('";
                            script += message;
                            script += "');";
                            script += "window.location = '";
                            script += url;
                            script += "'; }";
                            ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);

                        }
                    }
                }
                else if (btnAddMakingMethod.Text == "Update Making Method")
                {
                    retMsg = objClsProductMakingMethod.UpdateProductMakingMethod(Convert.ToInt32(Request.QueryString["MakingMethodId"]), txtmakingMethodName.Text.Trim(), Convert.ToInt32(Session["UserId"]));

                    if (retMsg == "SUCCESS")
                    {
                        string message = "Making Method Updated Successfully.";
                        string url = "MenuItemMakingMethodInformation.aspx";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "');";
                        script += "window.location = '";
                        script += url;
                        script += "'; }";
                        ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);


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
        try
        {
            Response.Redirect("~/Admin/MenuItemMakingMethodInformation.aspx", false);
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
}