using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_MenuItemMakingMethodInformation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    GetAllMakingMethods();
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
    ClsProductMakingMethod objClsProductMakingMethod = new ClsProductMakingMethod();
    List<tp_product_making_method> lstMakingMethodInformation = new List<tp_product_making_method>();
    public void GetAllMakingMethods()
    {

        DataTable dt = new DataTable();
        DataView dv = null;

        try
        {
            if (txtSearch.Text == "")
                dt = objClsProductMakingMethod.GetProductMakingMethodList();
            else
                dt = objClsProductMakingMethod.GetProductMakingMethodList(txtSearch.Text.Trim());

            dv = new DataView(dt);
            if (ViewState["SortExpression"] != null)
            {
                string sortExpression = Convert.ToString(ViewState["SortExpression"]);
                dv.Sort = sortExpression + SortDirection;
            }

            if (dv != null && dv.Count > 0)
            {
                gvMakingMethodInformation.DataSource = dv;
                gvMakingMethodInformation.DataBind();
            }
            else
            {
                gvMakingMethodInformation.DataSource = null;
                gvMakingMethodInformation.DataBind();
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

    protected void gvMakingMethodInformation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int makingMethodId = 0;
        try
        {

            string retMsg = string.Empty;

            switch (e.CommandName)
            {
                case "First":
                    {
                        gvMakingMethodInformation.PageIndex = 0;
                        GetAllMakingMethods();
                        break;
                    }
                case "Next":
                    {
                        if (gvMakingMethodInformation.PageIndex < (gvMakingMethodInformation.PageCount - 1))
                        {
                            gvMakingMethodInformation.PageIndex++;
                        }
                        GetAllMakingMethods();
                        break;
                    }
                case "Previous":
                    {
                        if (gvMakingMethodInformation.PageIndex > 0)
                        {
                            gvMakingMethodInformation.PageIndex--;
                        }
                        GetAllMakingMethods();
                        break;
                    }

                case "Last":
                    {
                        gvMakingMethodInformation.PageIndex = gvMakingMethodInformation.PageCount - 1;
                        GetAllMakingMethods();
                        break;
                    }
            }
            makingMethodId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "EditMakingMethod")
            {
                string url = "~/Admin/AddMenuItemMakingMethodInformation.aspx?MakingMethodId=" + makingMethodId;
                Response.Redirect(url, false);
            }
            else if (e.CommandName == "DeleteMakingMethod")
            {
                string confirmValue = hdnfldVariable.Value;
                if (confirmValue == "Yes")
                {

                    retMsg = objClsProductMakingMethod.DeleteProductMakingMethod(makingMethodId);
                    if (retMsg == "SUCCESS")
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Making Method Deleted Successfully')", true);
                    }
                    GetAllMakingMethods();
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

    protected void gvMakingMethodInformation_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            SortExpression = e.SortExpression;
            if (SortDirection == " ASC")
                SortDirection = " DESC";
            else
                SortDirection = " ASC";
            GetAllMakingMethods();
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
            GetAllMakingMethods();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void btnAddMakingMethod_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Admin/AddMenuItemMakingMethodInformation.aspx", false);
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
                gvMakingMethodInformation.PageSize = 10;
                GetAllMakingMethods();
            }
            else if (ddlShowData.SelectedIndex == 1)
            {
                gvMakingMethodInformation.PageSize = 15;
                GetAllMakingMethods();
            }
            else if (ddlShowData.SelectedIndex == 2)
            {
                gvMakingMethodInformation.PageSize = 20;
                GetAllMakingMethods();
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
            GetAllMakingMethods();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
}