using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MenuCategoryInformation : System.Web.UI.Page
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
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Category Added Successfully')", true);
                        Session["Message"] = null;
                    }
                    else if (Session["Message"].ToString() == "Update")
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Category Updated Successfully.')", true);
                        Session["Message"] = null;
                    }

                }

               
                    GetAllMenuCategoryInformation();
               
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

    public void GetAllMenuCategoryInformation()
    {
        ClsProductCategory objClsProductCategory = new ClsProductCategory();
        DataTable dt = new DataTable();
        DataView dv = null;

        try
        {
            if (txtSearch.Text == "")
                dt = objClsProductCategory.GetProductCategoryList();
            else
                dt = objClsProductCategory.GetProductCategoryList(txtSearch.Text.Trim());

            dv = new DataView(dt);
            if (ViewState["SortExpression"] != null)
            {
                string sortExpression = Convert.ToString(ViewState["SortExpression"]);
                dv.Sort = sortExpression + SortDirection;
            }

            if (dv != null && dv.Count > 0)
            {
                gvCategoryInformation.DataSource = dv;
                gvCategoryInformation.DataBind();
            }
            else
            {
                gvCategoryInformation.DataSource = null;
                gvCategoryInformation.DataBind();
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

    protected void btnAddCategory_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Admin/AddMenuCategoryInformation.aspx", false);
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
            GetAllMenuCategoryInformation();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void gvCategoryInformation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int categoryId = 0;
            ClsProductCategory objClsProductCategory = new ClsProductCategory();
            string retMsg = string.Empty;

            switch (e.CommandName)
            {
                case "First":
                    {
                        gvCategoryInformation.PageIndex = 0;
                        GetAllMenuCategoryInformation();
                        break;
                    }
                case "Next":
                    {
                        if (gvCategoryInformation.PageIndex < (gvCategoryInformation.PageCount - 1))
                        {
                            gvCategoryInformation.PageIndex++;
                        }
                        GetAllMenuCategoryInformation();
                        break;
                    }
                case "Previous":
                    {
                        if (gvCategoryInformation.PageIndex > 0)
                        {
                            gvCategoryInformation.PageIndex--;
                        }
                        GetAllMenuCategoryInformation();
                        break;
                    }

                case "Last":
                    {
                        gvCategoryInformation.PageIndex = gvCategoryInformation.PageCount - 1;
                        GetAllMenuCategoryInformation();
                        break;
                    }
            }

            categoryId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "EditMenuCategory")
            {
                string url = "~/Admin/AddMenuCategoryInformation.aspx?CategoryId=" + categoryId;
                Response.Redirect(url, false);
            }
            else if (e.CommandName == "DeleteMenuCategory")
            {
                string confirmValue = hdnfldVariable.Value;
                if (confirmValue == "Yes")
                {
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);
                    retMsg = objClsProductCategory.DeleteProductCategory(categoryId);
                    if (retMsg == "SUCCESS")
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Category Deleted Successfully')", true);
                    }
                    GetAllMenuCategoryInformation();
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void gvCategoryInformation_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            SortExpression = e.SortExpression;
            if (SortDirection == " ASC")
                SortDirection = " DESC";
            else
                SortDirection = " ASC";
            GetAllMenuCategoryInformation();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void gvCategoryInformation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        ClsProductCategory objClsProductCategory = new ClsProductCategory();
        DataTable dt = new DataTable();
        DataView dv = new DataView();
        string Description = "";

        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gvMenuIngeredientInformation = (GridView)e.Row.FindControl("gvMenuIngeredientInformation");
                Label lblProductCategoryId = ((Label)e.Row.FindControl("lblProductCategoryId"));

                dt = objClsProductCategory.GetProductCategoryListByIngredient(Convert.ToInt32(lblProductCategoryId.Text));

                dv = new DataView(dt);

                if (ViewState["SortExpressionSize"] != null)
                {
                    string sortExpression = Convert.ToString(ViewState["SortExpressionSize"]);
                    dv.Sort = sortExpression + SortDirection;
                }

                if (dv != null && dv.Count > 0)
                {
                    gvMenuIngeredientInformation.DataSource = dv;
                    gvMenuIngeredientInformation.DataBind();
                }
                else
                {
                    gvMenuIngeredientInformation.DataSource = null;
                    gvMenuIngeredientInformation.DataBind();
                }

                Label txtDescription = ((Label)e.Row.FindControl("lblCategotyDescription"));
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

    public string SortDirectionSize
    {
        get
        {
            if (ViewState["SortDirectionSize"] == null)
                ViewState["SortDirectionSize"] = " ASC";

            return (string)ViewState["SortDirectionSize"];
        }
        set { ViewState["SortDirectionSize"] = value; }
    }

    public string SortExpressionSize
    {
        get
        {
            if (ViewState["SortExpressionSize"] == null)
                ViewState["SortExpressionSize"] = "Name";

            return (string)ViewState["SortExpressionSize"];
        }
        set { ViewState["SortExpressionSize"] = value; }
    }



    protected void ddlShowData_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlShowData.SelectedIndex == 0)
            {
                gvCategoryInformation.PageSize = 10;
                GetAllMenuCategoryInformation();
            }
            else if (ddlShowData.SelectedIndex == 1)
            {
                gvCategoryInformation.PageSize = 15;
                GetAllMenuCategoryInformation();
            }
            else if (ddlShowData.SelectedIndex == 2)
            {
                gvCategoryInformation.PageSize = 20;
                GetAllMenuCategoryInformation();
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
            GetAllMenuCategoryInformation();
        }
        catch(Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
}