using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_DayToDaySellingInformation : System.Web.UI.Page
{
    ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    GetDailyTotalSales();
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

    public void GetDailyTotalSales()
    {
        try
        {
            DataTable dt = new DataTable();
            DataView dv = null;

            if (txtFromOrderDate.Text != "" && txtToOrderDate.Text != "")
                dt = objClsCustomerOrderDetail.GetDailyTotalSales(Convert.ToDateTime(txtFromOrderDate.Text), Convert.ToDateTime(txtToOrderDate.Text)).ListToDataTable();
            else
                dt = objClsCustomerOrderDetail.GetDailyTotalSales(Convert.ToDateTime("1/1/1900 12:00:00 AM"), Convert.ToDateTime("1/1/1900 12:00:00 AM")).ListToDataTable();

            dv = new DataView(dt);
            if (ViewState["SortExpression"] != null)
            {
                string sortExpression = Convert.ToString(ViewState["SortExpression"]);
                dv.Sort = sortExpression + SortDirection;
            }


            if (dv != null && dv.Count > 0)
            {
                gvDayToDaySellingInformation.DataSource = dv;
                gvDayToDaySellingInformation.DataBind();
            }
            else
            {
                gvDayToDaySellingInformation.DataSource = null;
                gvDayToDaySellingInformation.DataBind();
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
    protected void gvDayToDaySellingInformation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();
            switch (e.CommandName)
            {
                case "First":
                    {
                        gvDayToDaySellingInformation.PageIndex = 0;
                        GetDailyTotalSales();
                        break;
                    }
                case "Next":
                    {
                        if (gvDayToDaySellingInformation.PageIndex < (gvDayToDaySellingInformation.PageCount - 1))
                        {
                            gvDayToDaySellingInformation.PageIndex++;
                        }
                        GetDailyTotalSales();
                        break;
                    }
                case "Previous":
                    {
                        if (gvDayToDaySellingInformation.PageIndex > 0)
                        {
                            gvDayToDaySellingInformation.PageIndex--;
                        }
                        GetDailyTotalSales();
                        break;
                    }

                case "Last":
                    {
                        gvDayToDaySellingInformation.PageIndex = gvDayToDaySellingInformation.PageCount - 1;
                        GetDailyTotalSales();
                        break;
                    }
            }

        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    protected void gvDayToDaySellingInformation_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            SortExpression = e.SortExpression;
            if (SortDirection == " ASC")
                SortDirection = " DESC";
            else
                SortDirection = " ASC";
            GetDailyTotalSales();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    protected void BtnFilter_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            DataView dv = null;

            if (txtFromOrderDate.Text == "" && txtToOrderDate.Text == "")
            {
                //Response.Write("<script>alert('Hello');</script>");
                // ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "Plese Select From Date And To Date", true);
                string message = "Plese Select From Date And To Date";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                gvDayToDaySellingInformation.DataSource = null;
                gvDayToDaySellingInformation.DataBind();
            }
            else if (txtFromOrderDate.Text != "" && txtToOrderDate.Text == "")
            {
                //Response.Write("<script>alert('Hello');</script>");
                // ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "Plese Select From Date And To Date", true);
                string message = "Plese Select From Date And To Date";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                gvDayToDaySellingInformation.DataSource = null;
                gvDayToDaySellingInformation.DataBind();
            }
            else if (txtFromOrderDate.Text == "" && txtToOrderDate.Text != "")
            {
                // ClientScript.RegisterStartupScript(this.GetType(), "Redirect", "Plese Select From Date And To Date", true);
                string message = "Plese Select From Date And To Date";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                gvDayToDaySellingInformation.DataSource = null;
                gvDayToDaySellingInformation.DataBind();
            }
            else
            {
                if (txtFromOrderDate.Text != "" && txtToOrderDate.Text != "")
                {
                    if ((Convert.ToDateTime(txtFromOrderDate.Text).Date) <= (Convert.ToDateTime(txtToOrderDate.Text).Date))
                    {
                        dt = objClsCustomerOrderDetail.GetDailyTotalSales(Convert.ToDateTime(txtFromOrderDate.Text), Convert.ToDateTime(txtToOrderDate.Text)).ListToDataTable();
                    }
                    else
                    {
                        string message = "To Date Never Less Than From Date";
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append("<script type = 'text/javascript'>");
                        sb.Append("window.onload=function(){");
                        sb.Append("alert('");
                        sb.Append(message);
                        sb.Append("')};");
                        sb.Append("</script>");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                    }
                }
                else
                    dt = objClsCustomerOrderDetail.GetDailyTotalSales(Convert.ToDateTime("1/1/1900 12:00:00 AM"), Convert.ToDateTime("1/1/1900 12:00:00 AM")).ListToDataTable();

                dv = new DataView(dt);
                //if (ViewState["SortExpression"] != null)
                //{
                //    string sortExpression = Convert.ToString(ViewState["SortExpression"]);
                //    dv.Sort = sortExpression + SortDirection;
                //}


                if (dv != null && dv.Count > 0)
                {
                    gvDayToDaySellingInformation.DataSource = dv;
                    gvDayToDaySellingInformation.DataBind();
                }
                else
                {
                    gvDayToDaySellingInformation.DataSource = null;
                    gvDayToDaySellingInformation.DataBind();
                }
            }

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
                gvDayToDaySellingInformation.PageSize = 10;
                GetDailyTotalSales();
            }
            else if (ddlShowData.SelectedIndex == 1)
            {
                gvDayToDaySellingInformation.PageSize = 15;
                GetDailyTotalSales();
            }
            else if (ddlShowData.SelectedIndex == 2)
            {
                gvDayToDaySellingInformation.PageSize = 20;
                GetDailyTotalSales();
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

    }
}