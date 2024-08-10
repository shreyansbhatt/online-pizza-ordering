using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_MenuItemSizeInformation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    GetAllSize();
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

    ClsProductSizes objClsProductSizes = new ClsProductSizes();
    List<tp_product_sizes> lstSizeInformation = new List<tp_product_sizes>();
    public void GetAllSize()
    {

        DataTable dt = new DataTable();
        DataView dv = null;

        try
        {
            if (txtSearch.Text == "")
                dt = objClsProductSizes.GetSizeList();
            else
                dt = objClsProductSizes.GetSizeList(txtSearch.Text.Trim());

            dv = new DataView(dt);
            if (ViewState["SortExpression"] != null)
            {
                string sortExpression = Convert.ToString(ViewState["SortExpression"]);
                dv.Sort = sortExpression + SortDirection;
            }

            if (dv != null && dv.Count > 0)
            {
                gvSizeInformation.DataSource = dv;
                gvSizeInformation.DataBind();
            }
            else
            {
                gvSizeInformation.DataSource = null;
                gvSizeInformation.DataBind();
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

    protected void gvSizeInformation_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        int sizeId = 0;
        try
        {

            string retMsg = string.Empty;

            switch (e.CommandName)
            {
                case "First":
                    {
                        gvSizeInformation.PageIndex = 0;
                        GetAllSize();
                        break;
                    }
                case "Next":
                    {
                        if (gvSizeInformation.PageIndex < (gvSizeInformation.PageCount - 1))
                        {
                            gvSizeInformation.PageIndex++;
                        }
                        GetAllSize();
                        break;
                    }
                case "Previous":
                    {
                        if (gvSizeInformation.PageIndex > 0)
                        {
                            gvSizeInformation.PageIndex--;
                        }
                        GetAllSize();
                        break;
                    }

                case "Last":
                    {
                        gvSizeInformation.PageIndex = gvSizeInformation.PageCount - 1;
                        GetAllSize();
                        break;
                    }
            }
            if (e.CommandArgument != "")
            {
                sizeId = Convert.ToInt32(e.CommandArgument);
            }
            if (e.CommandName == "EditSize")
            {
                string url = "~/Admin/AddMenuItemSizeInformation.aspx?SizeId=" + sizeId;
                Response.Redirect(url, false);
            }
            else if (e.CommandName == "DeleteSize")
            {
                string confirmValue = hdnfldVariable.Value;
                if (confirmValue == "Yes")
                {

                    retMsg = objClsProductSizes.DeleteProductSize(sizeId);
                    if (retMsg == "SUCCESS")
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Size Deleted Successfully')", true);
                    }
                    GetAllSize();
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

    protected void gvSizeInformation_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            SortExpression = e.SortExpression;
            if (SortDirection == " ASC")
                SortDirection = " DESC";
            else
                SortDirection = " ASC";
            GetAllSize();
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
                gvSizeInformation.PageSize = 10;
                GetAllSize();
            }
            else if (ddlShowData.SelectedIndex == 1)
            {
                gvSizeInformation.PageSize = 15;
                GetAllSize();
            }
            else if (ddlShowData.SelectedIndex == 2)
            {
                gvSizeInformation.PageSize = 20;
                GetAllSize();
            }

        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void btnAddSize_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Admin/AddMenuItemSizeInformation.aspx", false);
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
            GetAllSize();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void gvSizeInformation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        ClsProductSizes objClsProductSizes = new ClsProductSizes();
        DataTable dt = new DataTable();
        DataView dv = new DataView();
        string Description = "";

        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gvMenuItemSizeIngeredientInformation = (GridView)e.Row.FindControl("gvMenuItemSizeIngeredientInformation");
                Label SizeId = ((Label)e.Row.FindControl("lblSizeID"));

                dt = objClsProductSizes.GetProductSizeListByIngredient(Convert.ToInt32(SizeId.Text));

                dv = new DataView(dt);

                if (ViewState["SortExpressionSize"] != null)
                {
                    string sortExpression = Convert.ToString(ViewState["SortExpressionSize"]);
                    dv.Sort = sortExpression + SortDirection;
                }

                if (dv != null && dv.Count > 0)
                {
                    gvMenuItemSizeIngeredientInformation.DataSource = dv;
                    gvMenuItemSizeIngeredientInformation.DataBind();
                }
                else
                {
                    gvMenuItemSizeIngeredientInformation.DataSource = null;
                    gvMenuItemSizeIngeredientInformation.DataBind();
                }

                Label txtDescription = ((Label)e.Row.FindControl("lblDescription"));
                Description = txtDescription.Text;
                //preg_replace( '[^(<br( \/)?>)*|(<br( \/)?>)*$]', '', Description );
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"(<br />|<br/>|</ br>|</br>)");
                // System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"([^(<br( \/)?>)*|(<br( \/)?>)*$])");
                // Description = Description.Replace(@"([^(<br( \/)?>)*|(<br( \/)?>)*$])", "");
                Description = regex.Replace(Description, "<br/>");
                Description = Description.Replace("\n", System.Environment.NewLine);
                Description = Description.Replace("&nbsp;", "");
                if (Description != null)
                {
                    if (Description.Length > 25)
                    {
                        txtDescription.Text = Description.Substring(0, 25);
                    }
                    else
                    {
                        txtDescription.Text = Description;
                    }
                    txtDescription.ToolTip = Description.Replace("<br/>", System.Environment.NewLine);
                }

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
            GetAllSize();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
}