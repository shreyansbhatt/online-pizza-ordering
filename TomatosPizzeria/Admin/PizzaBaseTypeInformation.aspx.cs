using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_PizzaBaseTypeInformation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    GetAllPizzaBaseType();
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
    ClsPizzaBaseType objClsPizzaBaseType = new ClsPizzaBaseType();
    List<tp_pizza_base_type> lstPizzaBaseTypeInformation = new List<tp_pizza_base_type>();
    public void GetAllPizzaBaseType()
    {

        DataTable dt = new DataTable();
        DataView dv = null;

        try
        {
            if (txtSearch.Text == "")
                dt = objClsPizzaBaseType.GetPizzaBaseTypeList();
            else
                dt = objClsPizzaBaseType.GetPizzaBaseTypeList(txtSearch.Text.Trim());

            dv = new DataView(dt);
            if (ViewState["SortExpression"] != null)
            {
                string sortExpression = Convert.ToString(ViewState["SortExpression"]);
                dv.Sort = sortExpression + SortDirection;
            }

            if (dv != null && dv.Count > 0)
            {
                gvPizzaBaseTypeInformation.DataSource = dv;
                gvPizzaBaseTypeInformation.DataBind();
            }
            else
            {
                gvPizzaBaseTypeInformation.DataSource = null;
                gvPizzaBaseTypeInformation.DataBind();
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


    protected void gvPizzaBaseTypeInformation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int pizzaBaseTypeId = 0;
        try
        {

            string retMsg = string.Empty;

            switch (e.CommandName)
            {
                case "First":
                    {
                        gvPizzaBaseTypeInformation.PageIndex = 0;
                        GetAllPizzaBaseType();
                        break;
                    }
                case "Next":
                    {
                        if (gvPizzaBaseTypeInformation.PageIndex < (gvPizzaBaseTypeInformation.PageCount - 1))
                        {
                            gvPizzaBaseTypeInformation.PageIndex++;
                        }
                        GetAllPizzaBaseType();
                        break;
                    }
                case "Previous":
                    {
                        if (gvPizzaBaseTypeInformation.PageIndex > 0)
                        {
                            gvPizzaBaseTypeInformation.PageIndex--;
                        }
                        GetAllPizzaBaseType();
                        break;
                    }

                case "Last":
                    {
                        gvPizzaBaseTypeInformation.PageIndex = gvPizzaBaseTypeInformation.PageCount - 1;
                        GetAllPizzaBaseType();
                        break;
                    }
            }
            pizzaBaseTypeId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "EditPizzaBaseType")
            {
                string url = "~/Admin/AddPizzaBaseTypeInformation.aspx?PizzaBaseTypeId=" + pizzaBaseTypeId;
                Response.Redirect(url, false);
            }
            else if (e.CommandName == "DeletePizzaBaseType")
            {
                string confirmValue = hdnfldVariable.Value;
                if (confirmValue == "Yes")
                {

                    retMsg = objClsPizzaBaseType.DeletePizzaBaseType(pizzaBaseTypeId);
                    if (retMsg == "SUCCESS")
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Pizza Base Type Deleted Successfully')", true);
                    }
                    GetAllPizzaBaseType();
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

    protected void gvPizzaBaseTypeInformation_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            SortExpression = e.SortExpression;
            if (SortDirection == " ASC")
                SortDirection = " DESC";
            else
                SortDirection = " ASC";
            GetAllPizzaBaseType();
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
            GetAllPizzaBaseType();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void btnAddPizzaBaseType_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Admin/AddPizzaBaseTypeInformation.aspx", false);
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
                gvPizzaBaseTypeInformation.PageSize = 10;
                GetAllPizzaBaseType();
            }
            else if (ddlShowData.SelectedIndex == 1)
            {
                gvPizzaBaseTypeInformation.PageSize = 15;
                GetAllPizzaBaseType();
            }
            else if (ddlShowData.SelectedIndex == 2)
            {
                gvPizzaBaseTypeInformation.PageSize = 20;
                GetAllPizzaBaseType();
            }

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
            GetAllPizzaBaseType();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
}