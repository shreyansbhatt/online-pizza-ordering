using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_IngredientFactInformation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    GetAllIngredientFactDetails();
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
    ClsProductIngredientFactDetail objClsProductIngredientFactDetail = new ClsProductIngredientFactDetail();
    List<tp_product_ingredient_fact_detail> lstIngredientFactInformation = new List<tp_product_ingredient_fact_detail>();
    public void GetAllIngredientFactDetails()
    {

        DataTable dt = new DataTable();
        DataView dv = null;

        try
        {
            if (txtSearch.Text == "")
                dt = objClsProductIngredientFactDetail.GetIngredientFactDetailList();
            else
                dt = objClsProductIngredientFactDetail.GetIngredientFactDetailList(txtSearch.Text.Trim());

            dv = new DataView(dt);
            if (ViewState["SortExpression"] != null)
            {
                string sortExpression = Convert.ToString(ViewState["SortExpression"]);
                dv.Sort = sortExpression + SortDirection;
            }

            if (dv != null && dv.Count > 0)
            {
                gvIngredientFactInformation.DataSource = dv;
                gvIngredientFactInformation.DataBind();
            }
            else
            {
                gvIngredientFactInformation.DataSource = null;
                gvIngredientFactInformation.DataBind();
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    public string SortDirection
    {
        get
        {
            if (ViewState["SortDirection"] == null)
                ViewState["SortDirection"] = " ASC";

            return (string)ViewState["SortDirection"];
        }
        set { ViewState["SortDirection"] = value; }
    }

    public string SortExpression
    {
        get
        {
            if (ViewState["SortExpression"] == null)
                ViewState["SortExpression"] = "Name";

            return (string)ViewState["SortExpression"];
        }
        set { ViewState["SortExpression"] = value; }
    }

    protected void btnAddIngredientFact_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Admin/AddIngredientFactInformation.aspx", false);
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void ddlShowData_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlShowData.SelectedIndex == 0)
            {
                gvIngredientFactInformation.PageSize = 10;
                GetAllIngredientFactDetails();
            }
            else if (ddlShowData.SelectedIndex == 1)
            {
                gvIngredientFactInformation.PageSize = 15;
                GetAllIngredientFactDetails();
            }
            else if (ddlShowData.SelectedIndex == 2)
            {
                gvIngredientFactInformation.PageSize = 20;
                GetAllIngredientFactDetails();
            }

        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            GetAllIngredientFactDetails();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void gvIngredientFactInformation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int ingredientFactId = 0;
        try
        {

            string retMsg = string.Empty;

            switch (e.CommandName)
            {
                case "First":
                    {
                        gvIngredientFactInformation.PageIndex = 0;
                        GetAllIngredientFactDetails();
                        break;
                    }
                case "Next":
                    {
                        if (gvIngredientFactInformation.PageIndex < (gvIngredientFactInformation.PageCount - 1))
                        {
                            gvIngredientFactInformation.PageIndex++;
                        }
                        GetAllIngredientFactDetails();
                        break;
                    }
                case "Previous":
                    {
                        if (gvIngredientFactInformation.PageIndex > 0)
                        {
                            gvIngredientFactInformation.PageIndex--;
                        }
                        GetAllIngredientFactDetails();
                        break;
                    }

                case "Last":
                    {
                        gvIngredientFactInformation.PageIndex = gvIngredientFactInformation.PageCount - 1;
                        GetAllIngredientFactDetails();
                        break;
                    }
            }
            ingredientFactId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "EditIngredientFact")
            {
                string url = "~/Admin/AddIngredientFactInformation.aspx?IngredientFactId=" + ingredientFactId;
                Response.Redirect(url, false);
            }
            else if (e.CommandName == "DeleteIngredientFact")
            {
                string confirmValue = hdnfldVariable.Value;
                if (confirmValue == "Yes")
                {

                    retMsg = objClsProductIngredientFactDetail.DeleteIngredientFactDetail(ingredientFactId);
                    if (retMsg == "SUCCESS")
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ingredient Fact Deleted Successfully')", true);
                    }
                    GetAllIngredientFactDetails();
                }
                else
                {

                }

            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void gvIngredientFactInformation_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            SortExpression = e.SortExpression;
            if (SortDirection == " ASC")
                SortDirection = " DESC";
            else
                SortDirection = " ASC";
            GetAllIngredientFactDetails();
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
    protected void btnReset_Click(object sender, EventArgs e)
    {
        try
        {
            txtSearch.Text = "";
            GetAllIngredientFactDetails();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
}