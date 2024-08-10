using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddIngredientInformation : System.Web.UI.Page
{
    int ingredientId;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    if (Request.QueryString["IngredientId"] != null)
                    {
                        btnAddIngredient.Text = "Update Ingredient";
                        ingredientId = Convert.ToInt32(Request.QueryString["IngredientId"]);

                        GetIngredientInformationById();
                    }
                    else
                    {
                        btnAddIngredient.Text = "Add Ingredient";
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

    public void GetIngredientInformationById()
    {
        ClsIngredientDetails objClsIngredientDetails = new ClsIngredientDetails();
        tp_ingredient_details objTPIngredientInformation = new tp_ingredient_details();
        try
        {
            objTPIngredientInformation = objClsIngredientDetails.GetIngredientDetailByIngredientid(Convert.ToInt32(Request.QueryString["IngredientId"]));

            txtIngredientName.Text = objTPIngredientInformation.id_name;
            txtIngredientDescription.Text = objTPIngredientInformation.id_description;
            txtIngredientPrice.Text = objTPIngredientInformation.id_price;
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }


    protected void btnAddIngredient_Click(object sender, EventArgs e)
    {
        ClsIngredientDetails objClsIngredientDetails = new ClsIngredientDetails();
        string retMsg = string.Empty;
        bool isIngredientExist = false;

        try
        {
            if (Page.IsValid)
            {
                if (btnAddIngredient.Text == "Add Ingredient")
                {
                    isIngredientExist = objClsIngredientDetails.isIngredientExist(txtIngredientName.Text,txtIngredientPrice.Text);
                    if (isIngredientExist == true)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ingredient Already exists')", true);
                    }
                    else
                    {
                        retMsg = objClsIngredientDetails.InsertNewIngredientDetail(txtIngredientName.Text.Trim(), txtIngredientDescription.Text.Trim(), txtIngredientPrice.Text.Trim(), Convert.ToInt32(Session["UserId"]));

                        if (retMsg == "SUCCESS")
                        {
                            string message = "Ingredient Added Successfully.";
                            string url = "IngredientInformation.aspx";
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
                else if (btnAddIngredient.Text == "Update Ingredient")
                {
                    retMsg = objClsIngredientDetails.UpdateIngredientDetail(Convert.ToInt32(Request.QueryString["IngredientId"]), txtIngredientName.Text.Trim(), txtIngredientDescription.Text.Trim(), txtIngredientPrice.Text.Trim(), Convert.ToInt32(Session["UserId"]));

                    if (retMsg == "SUCCESS")
                    {
                        string message = "Ingredient Updated Successfully.";
                        string url = "IngredientInformation.aspx";
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
            Response.Redirect("~/Admin/IngredientInformation.aspx", false);
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