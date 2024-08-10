using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_TransactionDetail : System.Web.UI.Page
{
    ClsTransactionDetail objClsTransactionDetail = new ClsTransactionDetail();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserId"] != null)
            {
                GetAllTransactions();
            }
            else
            {
                Response.Redirect("~/Index.aspx", false);
            }
        }
    }

    public void GetAllTransactions()
    {

        DataTable dt = new DataTable();
        DataView dv = null;

        try
        {
            if (txtSearch.Text != "" && txtFromOrderDate.Text != "" && txtToOrderDate.Text != "")
                dt = objClsTransactionDetail.GetTransactionDetailList(Convert.ToDateTime(txtFromOrderDate.Text), Convert.ToDateTime(txtToOrderDate.Text), txtSearch.Text);
            else if ((txtFromOrderDate.Text != "" || txtToOrderDate.Text != "") && txtSearch.Text == "")
                dt = objClsTransactionDetail.GetTransactionDetailList(Convert.ToDateTime(txtFromOrderDate.Text), Convert.ToDateTime(txtToOrderDate.Text));
            else if (txtSearch.Text != "" && (txtFromOrderDate.Text == "" || txtToOrderDate.Text == ""))
                dt = objClsTransactionDetail.GetTransactionDetailList(Convert.ToDateTime("1/1/1900 12:00:00 AM"), Convert.ToDateTime("1/1/1900 12:00:00 AM"), txtSearch.Text);
            else
                dt = objClsTransactionDetail.GetTransactionDetailList(Convert.ToDateTime("1/1/1900 12:00:00 AM"), Convert.ToDateTime("1/1/1900 12:00:00 AM"), "");


            dv = new DataView(dt);
            if (ViewState["SortExpression"] != null)
            {
                string sortExpression = Convert.ToString(ViewState["SortExpression"]);
                dv.Sort = sortExpression + SortDirection;
            }

            if (dv != null && dv.Count > 0)
            {
                gvTransactionDetails.DataSource = dv;
                gvTransactionDetails.DataBind();
            }
            else
            {
                gvTransactionDetails.DataSource = null;
                gvTransactionDetails.DataBind();
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {

        GetAllTransactions();
    }

    protected void ddlShowData_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlShowData.SelectedIndex == 0)
            {
                gvTransactionDetails.PageSize = 10;
                GetAllTransactions();
            }
            else if (ddlShowData.SelectedIndex == 1)
            {
                gvTransactionDetails.PageSize = 15;
                GetAllTransactions();
            }
            else if (ddlShowData.SelectedIndex == 2)
            {
                gvTransactionDetails.PageSize = 20;
                GetAllTransactions();
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void gvTransactionDetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            SortExpression = e.SortExpression;
            if (SortDirection == " ASC")
                SortDirection = " DESC";
            else
                SortDirection = " ASC";
            GetAllTransactions();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void gvTransactionDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {


            string retMsg = string.Empty;

            switch (e.CommandName)
            {
                case "First":
                    {
                        gvTransactionDetails.PageIndex = 0;
                        GetAllTransactions();
                        break;
                    }
                case "Next":
                    {
                        if (gvTransactionDetails.PageIndex < (gvTransactionDetails.PageCount - 1))
                        {
                            gvTransactionDetails.PageIndex++;
                        }
                        GetAllTransactions();
                        break;
                    }
                case "Previous":
                    {
                        if (gvTransactionDetails.PageIndex > 0)
                        {
                            gvTransactionDetails.PageIndex--;
                        }
                        GetAllTransactions();
                        break;
                    }

                case "Last":
                    {
                        gvTransactionDetails.PageIndex = gvTransactionDetails.PageCount - 1;
                        GetAllTransactions();
                        break;
                    }
            }

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
                gvTransactionDetails.DataSource = null;
                gvTransactionDetails.DataBind();
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
                gvTransactionDetails.DataSource = null;
                gvTransactionDetails.DataBind();
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
                gvTransactionDetails.DataSource = null;
                gvTransactionDetails.DataBind();
            }
            else
            {
                DataTable dt = new DataTable();
                DataView dv = null;

                if (txtSearch.Text != "" && txtFromOrderDate.Text != "" && txtToOrderDate.Text != "")
                {
                    if ((Convert.ToDateTime(txtFromOrderDate.Text).Date) <= (Convert.ToDateTime(txtToOrderDate.Text).Date))
                    {
                        dt = objClsTransactionDetail.GetTransactionDetailList(Convert.ToDateTime(txtFromOrderDate.Text), Convert.ToDateTime(txtToOrderDate.Text), txtSearch.Text);
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
                else if ((txtFromOrderDate.Text != "" || txtToOrderDate.Text != "") && txtSearch.Text == "")
                {
                    if ((Convert.ToDateTime(txtFromOrderDate.Text).Date) <= (Convert.ToDateTime(txtToOrderDate.Text).Date))
                    {
                        dt = objClsTransactionDetail.GetTransactionDetailList(Convert.ToDateTime(txtFromOrderDate.Text), Convert.ToDateTime(txtToOrderDate.Text));
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
                else if (txtSearch.Text != "" && (txtFromOrderDate.Text == "" || txtToOrderDate.Text == ""))
                    dt = objClsTransactionDetail.GetTransactionDetailList(Convert.ToDateTime("1/1/1900 12:00:00 AM"), Convert.ToDateTime("1/1/1900 12:00:00 AM"), txtSearch.Text);
                else
                    dt = objClsTransactionDetail.GetTransactionDetailList(Convert.ToDateTime("1/1/1900 12:00:00 AM"), Convert.ToDateTime("1/1/1900 12:00:00 AM"), "");

                dv = new DataView(dt);



                if (dv != null && dv.Count > 0)
                {
                    gvTransactionDetails.DataSource = dv;
                    gvTransactionDetails.DataBind();
                }
                else
                {
                    gvTransactionDetails.DataSource = null;
                    gvTransactionDetails.DataBind();
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
            GetAllTransactions();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
}