using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddIngredientFactInformation : System.Web.UI.Page
{
    int ingredientFactId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserId"] != null)
            {
                if (Request.QueryString["IngredientFactId"] != null)
                {
                    btnAddIngredientFact.Text = "Update Ingredient Fact";
                    ingredientFactId = Convert.ToInt32(Request.QueryString["IngredientFactId"]);

                    GetIngredientFactInformationById();
                }
                else
                {
                    btnAddIngredientFact.Text = "Add Ingredient Fact";
                }
            }
            else
            {
                Response.Redirect("~/Index.aspx", false);
            }

        }
    }
    public void GetIngredientFactInformationById()
    {
        ClsProductIngredientFactDetail objClsProductIngredientFactDetail = new ClsProductIngredientFactDetail();
        tp_product_ingredient_fact_detail objTPIngredientFactInformation = new tp_product_ingredient_fact_detail();
        try
        {
            objTPIngredientFactInformation = objClsProductIngredientFactDetail.GetIngredientFactDetailByIngredientFactId(Convert.ToInt32(Request.QueryString["IngredientFactId"]));

            txtIngredientFactName.Text = objTPIngredientFactInformation.pifd_name;
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void btnAddIngredientFact_Click(object sender, EventArgs e)
    {
        ClsProductIngredientFactDetail objClsProductIngredientFactDetail = new ClsProductIngredientFactDetail();
        string retMsg = string.Empty;
        bool isIngredientFactExist = false;

        try
        {
            if (Page.IsValid)
            {
                if (btnAddIngredientFact.Text == "Add Ingredient Fact")
                {
                    isIngredientFactExist = objClsProductIngredientFactDetail.isIngredientFactDetailExist(txtIngredientFactName.Text);
                    if (isIngredientFactExist == true)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ingredient Already exists')", true);
                    }
                    else
                    {
                        retMsg = objClsProductIngredientFactDetail.InsertIngredientFactDetail(txtIngredientFactName.Text.Trim(), Convert.ToInt32(Session["UserId"]));

                        if (retMsg == "SUCCESS")
                        {
                            string message = "Ingredient Fact Detail Added Successfully.";
                            string url = "IngredientFactInformation.aspx";
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
                else if (btnAddIngredientFact.Text == "Update Ingredient Fact")
                {
                    retMsg = objClsProductIngredientFactDetail.UpdateIngredientFactDetail(Convert.ToInt32(Request.QueryString["IngredientFactId"]), txtIngredientFactName.Text.Trim(), Convert.ToInt32(Session["UserId"]));

                    if (retMsg == "SUCCESS")
                    {
                        string message = "Ingredient Fact Detail Updated Successfully.";
                        string url = "IngredientFactInformation.aspx";
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
            Response.Redirect("~/Admin/IngredientFactInformation.aspx", false);
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