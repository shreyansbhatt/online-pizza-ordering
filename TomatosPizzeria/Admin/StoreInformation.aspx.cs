using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_StoreInformation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    GetAllStoreDetails();
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

    public void GetAllStoreDetails()
    {
        ClsStoreDetail objClsStoreDetail = new ClsStoreDetail();
        DataTable dt = new DataTable();
        DataView dv = null;

        try
        {
            //if (txtSearch.Text == "")
            dt = objClsStoreDetail.GetStoreDetailList();
            //else
            //    dt = objClsStoreDetail.GetStoreDetailList(txtSearch.Text.Trim());

            dv = new DataView(dt);
            if (ViewState["SortExpression"] != null)
            {
                string sortExpression = Convert.ToString(ViewState["SortExpression"]);
                dv.Sort = sortExpression + SortDirection;
            }

            if (dv != null && dv.Count > 0)
            {
                gvStoreInformation.DataSource = dv;
                gvStoreInformation.DataBind();
            }
            else
            {
                gvStoreInformation.DataSource = null;
                gvStoreInformation.DataBind();
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


    protected void gvStoreInformation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int StoreId = 0;
            ClsProductCategory objClsProductCategory = new ClsProductCategory();
            string retMsg = string.Empty;


            StoreId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "EditStoreDetail")
            {
                string url = "~/Admin/AddStoreDetail.aspx?StoreId=" + StoreId;
                Response.Redirect(url, false);
            }

        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    protected void gvStoreInformation_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            SortExpression = e.SortExpression;
            if (SortDirection == " ASC")
                SortDirection = " DESC";
            else
                SortDirection = " ASC";
            GetAllStoreDetails();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void gvWorkingDayInformation_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            GetAllStoreDetails();
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
            //if (ddlShowData.SelectedIndex == 0)
            //{
            //    gvStoreInformation.PageSize = 5;
            //    GetAllStoreDetails();
            //}
            //else if (ddlShowData.SelectedIndex == 1)
            //{
            //    gvStoreInformation.PageSize = 10;
            //    GetAllStoreDetails();
            //}
            //else if (ddlShowData.SelectedIndex == 2)
            //{
            //    gvStoreInformation.PageSize = 15;
            //    GetAllStoreDetails();
            //}

        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    protected void gvStoreInformation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        ClsStoreDetail objClsStoreDetail = new ClsStoreDetail();
        DataTable dt = new DataTable();
        DataView dv = new DataView();

        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gvWorkingDayInformation = (GridView)e.Row.FindControl("gvWorkingDayInformation");
                Label lblStoreId = ((Label)e.Row.FindControl("lblStoreId"));

                dt = objClsStoreDetail.GetStoreMappingDetailById(Convert.ToInt32(lblStoreId.Text)).ListToDataTable();


                dv = new DataView(dt);

                if (ViewState["SortExpressionProperties"] != null)
                {
                    string sortExpression = Convert.ToString(ViewState["SortExpressionProperties"]);
                    dv.Sort = sortExpression + SortDirection;
                }

                if (dv != null && dv.Count > 0)
                {
                    gvWorkingDayInformation.DataSource = dv;
                    gvWorkingDayInformation.DataBind();
                }
                else
                {
                    gvWorkingDayInformation.DataSource = null;
                    gvWorkingDayInformation.DataBind();
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
}