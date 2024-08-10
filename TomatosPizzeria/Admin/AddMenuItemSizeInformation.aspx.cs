using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddMenuItemSizeInformation : System.Web.UI.Page
{
    int sizeId = 0;
    ClsProductSizes objClsProductSizes = new ClsProductSizes();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    if (Request.QueryString["SizeId"] != null)
                    {
                        btnAddSize.Text = "Update Size";
                        sizeId = Convert.ToInt32(Request.QueryString["SizeId"]);

                        GetAllIngredients();
                        GetSizeInformationById();

                    }
                    else
                    {
                        btnAddSize.Text = "Add Size";
                        GetAllIngredients();
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
    public void GetSizeInformationById()
    {
        ClsProductSizes objClsProductSizes = new ClsProductSizes();
        tp_product_sizes objTPSizeInformation = new tp_product_sizes();
        try
        {
            objTPSizeInformation = objClsProductSizes.GetSizeInformationBySizeId(Convert.ToInt32(Request.QueryString["SizeId"]));
            if (objTPSizeInformation != null)
            {
                txtSizeName.Text = objTPSizeInformation.ps_name;
                txtSizeDescription.Text = objTPSizeInformation.ps_description;
            }

            List<ClsProductSizes> lstClsProductSizes = new List<ClsProductSizes>();
            lstClsProductSizes = objClsProductSizes.GetAllIngredientMappingInformation(Convert.ToInt32(Request.QueryString["SizeId"].ToString()));
            if (lstClsProductSizes.Count > 0)
            {
                foreach (var item in lstClsProductSizes)
                {
                    foreach (GridViewRow gvrow in gvMenuSizeIngredientInformation.Rows)
                    {
                        CheckBox chkingredient = (CheckBox)gvrow.FindControl("chkingredient");
                        if (chkingredient != null)
                        {

                            Label ingredientName = (Label)gvrow.FindControl("lblIngredientName");
                            if (ingredientName != null)
                            {
                                if (item.IngredientName == ingredientName.Text)
                                {
                                    chkingredient.Checked = true;
                                    TextBox txtprice = (TextBox)gvrow.FindControl("txtIngredientPrice");
                                    if (txtprice != null)
                                    {
                                        txtprice.Text = item.IngredientPrice.ToString();
                                    }

                                }
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    public void GetAllIngredients()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objClsProductSizes.GetAllIngredients();
            if (dt != null)
            {
                gvMenuSizeIngredientInformation.DataSource = dt;
                gvMenuSizeIngredientInformation.DataBind();
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void btnAddSize_Click(object sender, EventArgs e)
    {
        ClsProductSizes objClsProductSizes = new ClsProductSizes();
        string retMsg = string.Empty;
        bool isSizeExists = false;

        try
        {
            if (Page.IsValid)
            {
                if (btnAddSize.Text == "Add Size")
                {
                    isSizeExists = objClsProductSizes.isProductSizeExist(txtSizeName.Text);
                    if (isSizeExists == true)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Menu Item Size Already exists')", true);
                    }
                    else
                    {
                        List<ClsSizeIngredientMapping> lstClsSizeIngredientMapping = new List<ClsSizeIngredientMapping>();
                        foreach (GridViewRow gvrow in gvMenuSizeIngredientInformation.Rows)
                        {
                            CheckBox chkingredient = (CheckBox)gvrow.FindControl("chkingredient");
                            if (chkingredient != null)
                            {
                                if (chkingredient.Checked == true)
                                {
                                    ClsSizeIngredientMapping objClsSizeIngredientMapping = new ClsSizeIngredientMapping();

                                    Label ingredientId = (Label)gvrow.FindControl("lblIngredientId");
                                    if (ingredientId != null)
                                    {
                                        objClsSizeIngredientMapping.IngredientId = Convert.ToInt32(ingredientId.Text);
                                    }

                                    TextBox txtprice = (TextBox)gvrow.FindControl("txtIngredientPrice");
                                    if (txtprice != null)
                                    {
                                        objClsSizeIngredientMapping.IngredientSizePrice = txtprice.Text;
                                    }
                                    lstClsSizeIngredientMapping.Add(objClsSizeIngredientMapping);
                                }
                            }
                        }

                        retMsg = objClsProductSizes.InsertNewProductSize(txtSizeName.Text.Trim(), txtSizeDescription.Text.Trim(), lstClsSizeIngredientMapping.ToList(), Convert.ToInt32(Session["UserId"]));

                        if (retMsg == "SUCCESS")
                        {
                            string message = "Menu Item Size Added Successfully.";
                            string url = "MenuItemSizeInformation.aspx";
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
                else if (btnAddSize.Text == "Update Size")
                {
                    List<ClsSizeIngredientMapping> lstClsSizeIngredientMapping = new List<ClsSizeIngredientMapping>();
                    foreach (GridViewRow gvrow in gvMenuSizeIngredientInformation.Rows)
                    {
                        CheckBox chkingredient = (CheckBox)gvrow.FindControl("chkingredient");
                        if (chkingredient != null)
                        {

                            if (chkingredient.Checked == true)
                            {
                                ClsSizeIngredientMapping objClsSizeIngredientMapping = new ClsSizeIngredientMapping();

                                Label ingredientId = (Label)gvrow.FindControl("lblIngredientId");
                                if (ingredientId != null)
                                {
                                    objClsSizeIngredientMapping.IngredientId = Convert.ToInt32(ingredientId.Text);
                                }

                                TextBox txtprice = (TextBox)gvrow.FindControl("txtIngredientPrice");
                                if (txtprice != null)
                                {
                                    objClsSizeIngredientMapping.IngredientSizePrice = txtprice.Text;
                                }
                                lstClsSizeIngredientMapping.Add(objClsSizeIngredientMapping);
                            }
                        }
                    }

                    List<ClsSizeIngredientMapping> lstClsSizeIngredientMappingAll = new List<ClsSizeIngredientMapping>();
                    foreach (GridViewRow gvrow in gvMenuSizeIngredientInformation.Rows)
                    {
                        CheckBox chkingredient = (CheckBox)gvrow.FindControl("chkingredient");
                        if (chkingredient != null)
                        {

                            ClsSizeIngredientMapping objClsSizeIngredientMapping = new ClsSizeIngredientMapping();

                            Label ingredientId = (Label)gvrow.FindControl("lblIngredientId");
                            if (ingredientId != null)
                            {
                                objClsSizeIngredientMapping.IngredientId = Convert.ToInt32(ingredientId.Text);
                            }

                            TextBox txtprice = (TextBox)gvrow.FindControl("txtIngredientPrice");
                            if (txtprice != null)
                            {
                                objClsSizeIngredientMapping.IngredientSizePrice = txtprice.Text;
                            }
                            lstClsSizeIngredientMappingAll.Add(objClsSizeIngredientMapping);

                        }
                    }


                    retMsg = objClsProductSizes.UpdateProductSize(Convert.ToInt32(Request.QueryString["SizeId"]), txtSizeName.Text.Trim(), txtSizeDescription.Text.Trim(), lstClsSizeIngredientMappingAll.ToList(), lstClsSizeIngredientMapping.ToList(), Convert.ToInt32(Session["UserId"]));

                    if (retMsg == "SUCCESS")
                    {
                        string message = "Menu Item Size Updated Successfully.";
                        string url = "MenuItemSizeInformation.aspx";
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
            Response.Redirect("~/Admin/MenuItemSizeInformation.aspx", false);
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