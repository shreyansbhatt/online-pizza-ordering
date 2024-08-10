using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddPizzaBaseTypeInformation : System.Web.UI.Page
{
    int pizzaBaseTypeId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    if (Request.QueryString["PizzaBaseTypeId"] != null)
                    {
                        btnAddPizzaBaseType.Text = "Update Pizza Base Type";
                        pizzaBaseTypeId = Convert.ToInt32(Request.QueryString["PizzaBaseTypeId"]);

                        GetPizzaBaseTypeInformationById();
                    }
                    else
                    {
                        btnAddPizzaBaseType.Text = "Add Pizza Base Type";
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

    public void GetPizzaBaseTypeInformationById()
    {
        ClsPizzaBaseType objClsPizzaBaseType = new ClsPizzaBaseType();
        tp_pizza_base_type objTPPizzaBaseTypeInformation = new tp_pizza_base_type();
        try
        {
            objTPPizzaBaseTypeInformation = objClsPizzaBaseType.GetpizzaBaseTypeBypizzaBaseTypeId(Convert.ToInt32(Request.QueryString["PizzaBaseTypeId"]));

            txtPizzaBaseTypeName.Text = objTPPizzaBaseTypeInformation.pbt_name;
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }

    }

    protected void btnAddPizzaBaseType_Click(object sender, EventArgs e)
    {
        ClsPizzaBaseType objClsPizzaBaseType = new ClsPizzaBaseType();
        string retMsg = string.Empty;
        bool isPizzaBaseTypeExists = false;

        try
        {
            if (Page.IsValid)
            {
                if (btnAddPizzaBaseType.Text == "Add Pizza Base Type")
                {
                    isPizzaBaseTypeExists = objClsPizzaBaseType.isPizzaBaseTypeExist(txtPizzaBaseTypeName.Text);
                    if (isPizzaBaseTypeExists == true)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Pizza Base Type Already exists')", true);
                    }
                    else
                    {
                        retMsg = objClsPizzaBaseType.InsertNewPizzaBaseType(txtPizzaBaseTypeName.Text.Trim(), Convert.ToInt32(Session["UserId"]));

                        if (retMsg == "SUCCESS")
                        {
                            string message = "Pizza Base Type Added Successfully.";
                            string url = "PizzaBaseTypeInformation.aspx";
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
                else if (btnAddPizzaBaseType.Text == "Update Pizza Base Type")
                {
                    retMsg = objClsPizzaBaseType.UpdatePizzaBaseType(Convert.ToInt32(Request.QueryString["PizzaBaseTypeId"]), txtPizzaBaseTypeName.Text.Trim(), Convert.ToInt32(Session["UserId"]));

                    if (retMsg == "SUCCESS")
                    {
                        string message = "Pizza Base Type Updated Successfully.";
                        string url = "PizzaBaseTypeInformation.aspx";
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
            Response.Redirect("~/Admin/PizzaBaseTypeInformation.aspx", false);
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