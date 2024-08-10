using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_IngredientInformation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    GetAllIngredients();
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
    ClsIngredientDetails objClsIngredientDetails = new ClsIngredientDetails();
    List<tp_ingredient_details> lstIngredientInformation = new List<tp_ingredient_details>();
    public void GetAllIngredients()
    {

        DataTable dt = new DataTable();
        DataView dv = null;

        try
        {
            if (txtSearch.Text == "")
                dt = objClsIngredientDetails.GetIngredientList();
            else
                dt = objClsIngredientDetails.GetIngredientList(txtSearch.Text.Trim());

            dv = new DataView(dt);
            if (ViewState["SortExpression"] != null)
            {
                string sortExpression = Convert.ToString(ViewState["SortExpression"]);
                dv.Sort = sortExpression + SortDirection;
            }

            if (dv != null && dv.Count > 0)
            {
                gvIngredientInformation.DataSource = dv;
                gvIngredientInformation.DataBind();
            }
            else
            {
                gvIngredientInformation.DataSource = null;
                gvIngredientInformation.DataBind();
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


    protected void btnAddIngredient_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Admin/AddIngredientInformation.aspx", false);
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
                gvIngredientInformation.PageSize = 10;
                GetAllIngredients();
            }
            else if (ddlShowData.SelectedIndex == 1)
            {
                gvIngredientInformation.PageSize = 15;
                GetAllIngredients();
            }
            else if (ddlShowData.SelectedIndex == 2)
            {
                gvIngredientInformation.PageSize = 20;
                GetAllIngredients();
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
            GetAllIngredients();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void gvIngredientInformation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int ingredientId = 0;
        try
        {

            string retMsg = string.Empty;

            switch (e.CommandName)
            {
                case "First":
                    {
                        gvIngredientInformation.PageIndex = 0;
                        GetAllIngredients();
                        break;
                    }
                case "Next":
                    {
                        if (gvIngredientInformation.PageIndex < (gvIngredientInformation.PageCount - 1))
                        {
                            gvIngredientInformation.PageIndex++;
                        }
                        GetAllIngredients();
                        break;
                    }
                case "Previous":
                    {
                        if (gvIngredientInformation.PageIndex > 0)
                        {
                            gvIngredientInformation.PageIndex--;
                        }
                        GetAllIngredients();
                        break;
                    }

                case "Last":
                    {
                        gvIngredientInformation.PageIndex = gvIngredientInformation.PageCount - 1;
                        GetAllIngredients();
                        break;
                    }
            }
            ingredientId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "EditIngredient")
            {
                string url = "~/Admin/AddIngredientInformation.aspx?IngredientId=" + ingredientId;
                Response.Redirect(url, false);
            }
            else if (e.CommandName == "DeleteIngredient")
            {
                string confirmValue = hdnfldVariable.Value;
                if (confirmValue == "Yes")
                {

                    retMsg = objClsIngredientDetails.DeleteIngredientDetail(ingredientId);
                    if (retMsg == "SUCCESS")
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ingredient Deleted Successfully')", true);
                    }
                    GetAllIngredients();
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

    protected void gvIngredientInformation_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            SortExpression = e.SortExpression;
            if (SortDirection == " ASC")
                SortDirection = " DESC";
            else
                SortDirection = " ASC";
            GetAllIngredients();
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
            GetAllIngredients();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
}