using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_MenuItemInformation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserId"] != null)
            {
                if (Session["Message"] != null)
                {
                    if (Session["Message"].ToString() == "Add")
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Menu Item Added Successfully.')", true);
                        Session["Message"] = null;
                    }
                    else if (Session["Message"].ToString() == "Update")
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Menu Item Updated Successfully.')", true);
                        Session["Message"] = null;
                    }

                }
                if (!IsPostBack)
                {
                    GetAllMenuItemInformation();
                }
            }
            else
            {
                Response.Redirect("~/Index.aspx", false);
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    public void GetAllMenuItemInformation()
    {
        ClsProductDetail objClsProductDetail = new ClsProductDetail();
        DataTable dt = new DataTable();
        DataView dv = null;

        try
        {
            if (txtSearch.Text == "")
                dt = objClsProductDetail.GetProductList();
            else
                dt = objClsProductDetail.GetProductList(txtSearch.Text.Trim());

            dv = new DataView(dt);
            if (ViewState["SortExpression"] != null)
            {
                string sortExpression = Convert.ToString(ViewState["SortExpression"]);
                dv.Sort = sortExpression + SortDirection;
            }

            if (dv != null && dv.Count > 0)
            {
                gvMenuItemInformation.DataSource = dv;
                gvMenuItemInformation.DataBind();
            }
            else
            {
                gvMenuItemInformation.DataSource = null;
                gvMenuItemInformation.DataBind();
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

    protected void btnAddMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Admin/AddMenuItemInformation.aspx", false);
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
            GetAllMenuItemInformation();
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
                gvMenuItemInformation.PageSize = 10;
                GetAllMenuItemInformation();
            }
            else if (ddlShowData.SelectedIndex == 1)
            {
                gvMenuItemInformation.PageSize = 15;
                GetAllMenuItemInformation();
            }
            else if (ddlShowData.SelectedIndex == 2)
            {
                gvMenuItemInformation.PageSize = 20;
                GetAllMenuItemInformation();
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }



    protected void gvMenuItemInformation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        ClsProductDetail objClsProductDetail = new ClsProductDetail();
        DataTable dt = new DataTable();
        DataView dv = new DataView();
        string Description = "";

        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gvMenuItemDefaultIngeredientInformation = (GridView)e.Row.FindControl("gvMenuItemDefaultIngeredientInformation");
                Label lblProductDetailId = ((Label)e.Row.FindControl("lblProductDetailId"));
                if (lblProductDetailId != null)
                {
                    dt = objClsProductDetail.GetDefaultIngredientsInProduct(Convert.ToInt32(lblProductDetailId.Text));
                }
                dv = new DataView(dt);

                if (ViewState["SortExpressionProperties"] != null)
                {
                    string sortExpression = Convert.ToString(ViewState["SortExpressionProperties"]);
                    dv.Sort = sortExpression + SortDirection;
                }

                if (dv != null && dv.Count > 0)
                {
                    gvMenuItemDefaultIngeredientInformation.DataSource = dv;
                    gvMenuItemDefaultIngeredientInformation.DataBind();
                }
                else
                {
                    gvMenuItemDefaultIngeredientInformation.DataSource = null;
                    gvMenuItemDefaultIngeredientInformation.DataBind();
                }
                GridView gvMenuItemExtraIngeredientInformation = (GridView)e.Row.FindControl("gvMenuItemExtraIngeredientInformation");

                if (lblProductDetailId != null)
                {
                    dt = objClsProductDetail.GetExtraIngredientsForProduct(Convert.ToInt32(lblProductDetailId.Text));
                }
                dv = new DataView(dt);

                if (ViewState["SortExpressionProperties"] != null)
                {
                    string sortExpression = Convert.ToString(ViewState["SortExpressionProperties"]);
                    dv.Sort = sortExpression + SortDirection;
                }

                if (dv != null && dv.Count > 0)
                {
                    gvMenuItemExtraIngeredientInformation.DataSource = dv;
                    gvMenuItemExtraIngeredientInformation.DataBind();
                }
                else
                {
                    gvMenuItemExtraIngeredientInformation.DataSource = null;
                    gvMenuItemExtraIngeredientInformation.DataBind();
                }


                GridView gvMenuItemIngeredientFactInformation = (GridView)e.Row.FindControl("gvMenuItemIngeredientFactInformation");

                if (lblProductDetailId != null)
                {
                    //get ingredient
                    dt = objClsProductDetail.GetIngredientFactOfProduct(Convert.ToInt32(lblProductDetailId.Text));
                }
                dv = new DataView(dt);

                if (ViewState["SortExpressionProperties"] != null)
                {
                    string sortExpression = Convert.ToString(ViewState["SortExpressionProperties"]);
                    dv.Sort = sortExpression + SortDirection;
                }

                if (dv != null && dv.Count > 0)
                {
                    gvMenuItemIngeredientFactInformation.DataSource = dv;
                    gvMenuItemIngeredientFactInformation.DataBind();
                }
                else
                {
                    gvMenuItemIngeredientFactInformation.DataSource = null;
                    gvMenuItemIngeredientFactInformation.DataBind();
                }


                GridView gvMenuItemPropertiesInformation = (GridView)e.Row.FindControl("gvMenuItemPropertiesInformation");

                if (lblProductDetailId != null)
                {
                    dt = objClsProductDetail.GetProductPropertiesByProductId(Convert.ToInt32(lblProductDetailId.Text));
                }
                dv = new DataView(dt);

                if (ViewState["SortExpressionProperties"] != null)
                {
                    string sortExpression = Convert.ToString(ViewState["SortExpressionProperties"]);
                    dv.Sort = sortExpression + SortDirection;
                }

                if (dv != null && dv.Count > 0)
                {
                    gvMenuItemPropertiesInformation.DataSource = dv;
                    gvMenuItemPropertiesInformation.DataBind();
                }
                else
                {
                    gvMenuItemPropertiesInformation.DataSource = null;
                    gvMenuItemPropertiesInformation.DataBind();
                }

                Label txtDescription = ((Label)e.Row.FindControl("lblMenuItemDescription"));
                Description = txtDescription.Text;
                //preg_replace( '[^(<br( \/)?>)*|(<br( \/)?>)*$]', '', Description );
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"(<br />|<br/>|</ br>|</br>)");
                // System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"([^(<br( \/)?>)*|(<br( \/)?>)*$])");
                // Description = Description.Replace(@"([^(<br( \/)?>)*|(<br( \/)?>)*$])", "");
                Description = regex.Replace(Description, "<br/>");
                Description = Description.Replace("<br/>", "\n");
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

    protected void gvMenuItemInformation_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            SortExpression = e.SortExpression;
            if (SortDirection == " ASC")
                SortDirection = " DESC";
            else
                SortDirection = " ASC";
            GetAllMenuItemInformation();

        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void gvMenuItemInformation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int productId = 0;
           
            ClsProductDetail objClsProductDetail = new ClsProductDetail();
            string retMsg = string.Empty;

            switch (e.CommandName)
            {
                case "First":
                    {
                        gvMenuItemInformation.PageIndex = 0;
                        GetAllMenuItemInformation();
                        break;
                    }
                case "Next":
                    {
                        if (gvMenuItemInformation.PageIndex < (gvMenuItemInformation.PageCount - 1))
                        {
                            gvMenuItemInformation.PageIndex++;
                        }
                        GetAllMenuItemInformation();
                        break;
                    }
                case "Previous":
                    {
                        if (gvMenuItemInformation.PageIndex > 0)
                        {
                            gvMenuItemInformation.PageIndex--;
                        }
                        GetAllMenuItemInformation();
                        break;
                    }

                case "Last":
                    {
                        gvMenuItemInformation.PageIndex = gvMenuItemInformation.PageCount - 1;
                        GetAllMenuItemInformation();
                        break;
                    }
            }
            if (e.CommandArgument.ToString() != "")
            {
                productId = Convert.ToInt32(e.CommandArgument);
            }
            if (e.CommandName == "EditMenuItem")
            {
                string url = "~/Admin/AddMenuItemInformation.aspx?ProductId=" + productId;
                Response.Redirect(url, false);
            }
            else if (e.CommandName == "DeleteMenuItem")
            {
                string confirmValue = hdnfldVariable.Value;
                if (confirmValue == "Yes")
                {

                    retMsg = objClsProductDetail.DeleteProduct(productId);
                    if (retMsg == "SUCCESS")
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Menu Item Deleted Successfully')", true);
                    }
                    GetAllMenuItemInformation();
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
            GetAllMenuItemInformation();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
}