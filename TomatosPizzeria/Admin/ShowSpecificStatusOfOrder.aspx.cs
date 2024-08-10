using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ShowSpecificStatusOfOrder : System.Web.UI.Page
{
    ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();
    string searchtext = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    if (Request.QueryString["OrderStatus"].ToString() == "PlacedOrder")
                    {
                        GetOrderListForPlacedOrder();
                    }
                    else if (Request.QueryString["OrderStatus"].ToString() == "CompletedOrder")
                    {
                        GetOrderListForCompletedOrder();
                    }
                    else if (Request.QueryString["OrderStatus"].ToString() == "CancelledOrder")
                    {
                        GetOrderListForCancelledOrder();
                    }
                    //else if (Request.QueryString["OrderStatus"].ToString() == "DeliveredOrder")
                    //{
                    //    GetOrderListForDeliveredddOrder();
                    //}
                    else if (Request.QueryString["OrderStatus"].ToString() == "TotalOrder")
                    {
                        GetOrderList();
                    }
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
    public void GetOrderListForPlacedOrder()
    {
        try
        {
            DataTable dt = new DataTable();
            DataView dv = null;

            if (txtSearch.Text != "" && txtFromOrderDate.Text != "" && txtToOrderDate.Text != "")
            {
                if ((Convert.ToDateTime(txtFromOrderDate.Text).Date) <= (Convert.ToDateTime(txtToOrderDate.Text).Date))
                {
                    dt = objClsCustomerOrderDetail.GetOrderListForPlacedOrder(Convert.ToDateTime(txtFromOrderDate.Text), Convert.ToDateTime(txtToOrderDate.Text), txtSearch.Text).ListToDataTable();
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
                    dt = objClsCustomerOrderDetail.GetOrderListForPlacedOrder(Convert.ToDateTime(txtFromOrderDate.Text), Convert.ToDateTime(txtToOrderDate.Text)).ListToDataTable();
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
                dt = objClsCustomerOrderDetail.GetOrderListForPlacedOrder(Convert.ToDateTime("1/1/1900 12:00:00 AM"), Convert.ToDateTime("1/1/1900 12:00:00 AM"), txtSearch.Text).ListToDataTable();
            else
                dt = objClsCustomerOrderDetail.GetOrderListForPlacedOrder(Convert.ToDateTime("1/1/1900 12:00:00 AM"), Convert.ToDateTime("1/1/1900 12:00:00 AM"), "").ListToDataTable();

            dv = new DataView(dt);
            if (ViewState["SortExpression"] != null)
            {
                string sortExpression = Convert.ToString(ViewState["SortExpression"]);
                dv.Sort = sortExpression + SortDirection;
            }


            if (dv != null && dv.Count > 0)
            {
                gvOrderInformation.DataSource = dv;
                gvOrderInformation.DataBind();
            }
            else
            {
                gvOrderInformation.DataSource = null;
                gvOrderInformation.DataBind();
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    public void GetOrderListForCompletedOrder()
    {
        try
        {

            DataTable dt = new DataTable();
            DataView dv = null;

            if (txtSearch.Text != "" && txtFromOrderDate.Text != "" && txtToOrderDate.Text != "")
            {
                if ((Convert.ToDateTime(txtFromOrderDate.Text).Date) <= (Convert.ToDateTime(txtToOrderDate.Text).Date))
                {
                    dt = objClsCustomerOrderDetail.GetOrderListForCompletedOrder(Convert.ToDateTime(txtFromOrderDate.Text), Convert.ToDateTime(txtToOrderDate.Text), txtSearch.Text).ListToDataTable();
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
                    dt = objClsCustomerOrderDetail.GetOrderListForCompletedOrder(Convert.ToDateTime(txtFromOrderDate.Text), Convert.ToDateTime(txtToOrderDate.Text)).ListToDataTable();
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
                dt = objClsCustomerOrderDetail.GetOrderListForCompletedOrder(Convert.ToDateTime("1/1/1900 12:00:00 AM"), Convert.ToDateTime("1/1/1900 12:00:00 AM"), txtSearch.Text).ListToDataTable();
            else
                dt = objClsCustomerOrderDetail.GetOrderListForCompletedOrder(Convert.ToDateTime("1/1/1900 12:00:00 AM"), Convert.ToDateTime("1/1/1900 12:00:00 AM"), "").ListToDataTable();

            dv = new DataView(dt);
            if (ViewState["SortExpression"] != null)
            {
                string sortExpression = Convert.ToString(ViewState["SortExpression"]);
                dv.Sort = sortExpression + SortDirection;
            }


            if (dv != null && dv.Count > 0)
            {
                gvOrderInformation.DataSource = dv;
                gvOrderInformation.DataBind();
            }
            else
            {
                gvOrderInformation.DataSource = null;
                gvOrderInformation.DataBind();
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    public void GetOrderListForCancelledOrder()
    {
        try
        {
            DataTable dt = new DataTable();
            DataView dv = null;

            if (txtSearch.Text != "" && txtFromOrderDate.Text != "" && txtToOrderDate.Text != "")
            {
                if ((Convert.ToDateTime(txtFromOrderDate.Text).Date) <= (Convert.ToDateTime(txtToOrderDate.Text).Date))
                {
                    dt = objClsCustomerOrderDetail.GetOrderListForCancelledOrder(Convert.ToDateTime(txtFromOrderDate.Text), Convert.ToDateTime(txtToOrderDate.Text), txtSearch.Text).ListToDataTable();
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
                    dt = objClsCustomerOrderDetail.GetOrderListForCancelledOrder(Convert.ToDateTime(txtFromOrderDate.Text), Convert.ToDateTime(txtToOrderDate.Text)).ListToDataTable();
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
                dt = objClsCustomerOrderDetail.GetOrderListForCancelledOrder(Convert.ToDateTime("1/1/1900 12:00:00 AM"), Convert.ToDateTime("1/1/1900 12:00:00 AM"), txtSearch.Text).ListToDataTable();
            else
                dt = objClsCustomerOrderDetail.GetOrderListForCancelledOrder(Convert.ToDateTime("1/1/1900 12:00:00 AM"), Convert.ToDateTime("1/1/1900 12:00:00 AM"), "").ListToDataTable();

            dv = new DataView(dt);
            if (ViewState["SortExpression"] != null)
            {
                string sortExpression = Convert.ToString(ViewState["SortExpression"]);
                dv.Sort = sortExpression + SortDirection;
            }


            if (dv != null && dv.Count > 0)
            {
                gvOrderInformation.DataSource = dv;
                gvOrderInformation.DataBind();
            }
            else
            {
                gvOrderInformation.DataSource = null;
                gvOrderInformation.DataBind();
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }

    }

    public void GetOrderList()
    {
        try
        {
            DataTable dt = new DataTable();
            DataView dv = null;

            if (txtSearch.Text != "" && txtFromOrderDate.Text != "" && txtToOrderDate.Text != "")
            {
                if ((Convert.ToDateTime(txtFromOrderDate.Text).Date) <= (Convert.ToDateTime(txtToOrderDate.Text).Date))
                {
                    dt = objClsCustomerOrderDetail.GetOrderDatils(Convert.ToDateTime(txtFromOrderDate.Text), Convert.ToDateTime(txtToOrderDate.Text), txtSearch.Text).ListToDataTable();
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
                    dt = objClsCustomerOrderDetail.GetOrderDatils(Convert.ToDateTime(txtFromOrderDate.Text), Convert.ToDateTime(txtToOrderDate.Text)).ListToDataTable();
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
                dt = objClsCustomerOrderDetail.GetOrderDatils(Convert.ToDateTime("1/1/1900 12:00:00 AM"), Convert.ToDateTime("1/1/1900 12:00:00 AM"), txtSearch.Text).ListToDataTable();
            else
                dt = objClsCustomerOrderDetail.GetOrderDatils(Convert.ToDateTime("1/1/1900 12:00:00 AM"), Convert.ToDateTime("1/1/1900 12:00:00 AM"), "").ListToDataTable();

            dv = new DataView(dt);
            if (ViewState["SortExpression"] != null)
            {
                string sortExpression = Convert.ToString(ViewState["SortExpression"]);
                dv.Sort = sortExpression + SortDirection;
            }


            if (dv != null && dv.Count > 0)
            {
                gvOrderInformation.DataSource = dv;
                gvOrderInformation.DataBind();
            }
            else
            {
                gvOrderInformation.DataSource = null;
                gvOrderInformation.DataBind();
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    public string searchOrder()
    {
        string str = string.Empty;
        try
        {
            if (Request.QueryString["OrderStatus"].ToString() == "PlacedOrder")
            {
                GetOrderListForPlacedOrder();
            }
            else if (Request.QueryString["OrderStatus"].ToString() == "CompletedOrder")
            {
                GetOrderListForCompletedOrder();
            }
            else if (Request.QueryString["OrderStatus"].ToString() == "CancelledOrder")
            {
                GetOrderListForCancelledOrder();
            }
            //else if (Request.QueryString["OrderStatus"].ToString() == "DeliveredOrder")
            //{
            //    GetOrderListForDeliveredddOrder();
            //}
            else if (Request.QueryString["OrderStatus"].ToString() == "TotalOrder")
            {
                GetOrderList();
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return null;
    }


    protected void gvOrderInformation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();
            switch (e.CommandName)
            {
                case "First":
                    {
                        gvOrderInformation.PageIndex = 0;
                        if (Request.QueryString["OrderStatus"].ToString() == "PlacedOrder")
                        {
                            GetOrderListForPlacedOrder();
                        }
                        else if (Request.QueryString["OrderStatus"].ToString() == "CompletedOrder")
                        {
                            GetOrderListForCompletedOrder();
                        }
                        else if (Request.QueryString["OrderStatus"].ToString() == "CancelledOrder")
                        {
                            GetOrderListForCancelledOrder();
                        }
                        //else if (Request.QueryString["OrderStatus"].ToString() == "DeliveredOrder")
                        //{
                        //    GetOrderListForDeliveredddOrder();
                        //}
                        else if (Request.QueryString["OrderStatus"].ToString() == "TotalOrder")
                        {
                            GetOrderList();
                        }
                        break;
                    }
                case "Next":
                    {
                        if (gvOrderInformation.PageIndex < (gvOrderInformation.PageCount - 1))
                        {
                            gvOrderInformation.PageIndex++;
                        }
                        if (Request.QueryString["OrderStatus"].ToString() == "PlacedOrder")
                        {
                            GetOrderListForPlacedOrder();
                        }
                        else if (Request.QueryString["OrderStatus"].ToString() == "CompletedOrder")
                        {
                            GetOrderListForCompletedOrder();
                        }
                        else if (Request.QueryString["OrderStatus"].ToString() == "CancelledOrder")
                        {
                            GetOrderListForCancelledOrder();
                        }
                        //else if (Request.QueryString["OrderStatus"].ToString() == "DeliveredOrder")
                        //{
                        //    GetOrderListForDeliveredddOrder();
                        //}
                        else if (Request.QueryString["OrderStatus"].ToString() == "TotalOrder")
                        {
                            GetOrderList();
                        }
                        break;
                    }
                case "Previous":
                    {
                        if (gvOrderInformation.PageIndex > 0)
                        {
                            gvOrderInformation.PageIndex--;
                        }
                        if (Request.QueryString["OrderStatus"].ToString() == "PlacedOrder")
                        {
                            GetOrderListForPlacedOrder();
                        }
                        else if (Request.QueryString["OrderStatus"].ToString() == "CompletedOrder")
                        {
                            GetOrderListForCompletedOrder();
                        }
                        else if (Request.QueryString["OrderStatus"].ToString() == "CancelledOrder")
                        {
                            GetOrderListForCancelledOrder();
                        }
                        //else if (Request.QueryString["OrderStatus"].ToString() == "DeliveredOrder")
                        //{
                        //    GetOrderListForDeliveredddOrder();
                        //}
                        else if (Request.QueryString["OrderStatus"].ToString() == "TotalOrder")
                        {
                            GetOrderList();
                        }
                        break;
                    }

                case "Last":
                    {
                        gvOrderInformation.PageIndex = gvOrderInformation.PageCount - 1;
                        if (Request.QueryString["OrderStatus"].ToString() == "PlacedOrder")
                        {
                            GetOrderListForPlacedOrder();
                        }
                        else if (Request.QueryString["OrderStatus"].ToString() == "CompletedOrder")
                        {
                            GetOrderListForCompletedOrder();
                        }
                        else if (Request.QueryString["OrderStatus"].ToString() == "CancelledOrder")
                        {
                            GetOrderListForCancelledOrder();
                        }
                        //else if (Request.QueryString["OrderStatus"].ToString() == "DeliveredOrder")
                        //{
                        //    GetOrderListForDeliveredddOrder();
                        //}
                        else if (Request.QueryString["OrderStatus"].ToString() == "TotalOrder")
                        {
                            GetOrderList();
                        }
                        break;
                    }
            }


            int orderId = 0;
            string retMsg = string.Empty;
            if (e.CommandName == "EditOrderDetail")
            {
                orderId = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                DropDownList ddlOrderStatus = ((DropDownList)row.FindControl("ddlOrderStatus"));
                if (ddlOrderStatus != null)
                {
                    if (ddlOrderStatus.SelectedIndex == 2)
                    {
                        retMsg = objClsCustomerOrderDetail.UpdateOrderStatus(orderId, "Order Cancelled");
                    }
                }
                if (retMsg == "SUCCESS")
                {
                    if (retMsg == "SUCCESS")
                    {

                        Session["Message"] = "Success";
                        Response.Redirect("~/Admin/DashBoard.aspx?", false);
                    }
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
                gvOrderInformation.PageSize = 10;
                if (Request.QueryString["OrderStatus"].ToString() == "PlacedOrder")
                {
                    GetOrderListForPlacedOrder();
                }
                else if (Request.QueryString["OrderStatus"].ToString() == "CompletedOrder")
                {
                    GetOrderListForCompletedOrder();
                }
                else if (Request.QueryString["OrderStatus"].ToString() == "CancelledOrder")
                {
                    GetOrderListForCancelledOrder();
                }
                //else if (Request.QueryString["OrderStatus"].ToString() == "DeliveredOrder")
                //{
                //    GetOrderListForDeliveredddOrder();
                //}
                else if (Request.QueryString["OrderStatus"].ToString() == "TotalOrder")
                {
                    GetOrderList();
                }
            }
            else if (ddlShowData.SelectedIndex == 1)
            {
                gvOrderInformation.PageSize = 15;
                if (Request.QueryString["OrderStatus"].ToString() == "PlacedOrder")
                {
                    GetOrderListForPlacedOrder();
                }
                else if (Request.QueryString["OrderStatus"].ToString() == "CompletedOrder")
                {
                    GetOrderListForCompletedOrder();
                }
                else if (Request.QueryString["OrderStatus"].ToString() == "CancelledOrder")
                {
                    GetOrderListForCancelledOrder();
                }
                //else if (Request.QueryString["OrderStatus"].ToString() == "DeliveredOrder")
                //{
                //    GetOrderListForDeliveredddOrder();
                //}
                else if (Request.QueryString["OrderStatus"].ToString() == "TotalOrder")
                {
                    GetOrderList();
                }
            }
            else if (ddlShowData.SelectedIndex == 2)
            {
                gvOrderInformation.PageSize = 20;
                if (Request.QueryString["OrderStatus"].ToString() == "PlacedOrder")
                {
                    GetOrderListForPlacedOrder();
                }
                else if (Request.QueryString["OrderStatus"].ToString() == "CompletedOrder")
                {
                    GetOrderListForCompletedOrder();
                }
                else if (Request.QueryString["OrderStatus"].ToString() == "CancelledOrder")
                {
                    GetOrderListForCancelledOrder();
                }
                //else if (Request.QueryString["OrderStatus"].ToString() == "DeliveredOrder")
                //{
                //    GetOrderListForDeliveredddOrder();
                //}
                else if (Request.QueryString["OrderStatus"].ToString() == "TotalOrder")
                {
                    GetOrderList();
                }
            }

        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }


    protected void gvOrderInformation_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            SortExpression = e.SortExpression;
            if (SortDirection == " ASC")
                SortDirection = " DESC";
            else
                SortDirection = " ASC";
            if (Request.QueryString["OrderStatus"].ToString() == "PlacedOrder")
            {
                GetOrderListForPlacedOrder();
            }
            else if (Request.QueryString["OrderStatus"].ToString() == "CompletedOrder")
            {
                GetOrderListForCompletedOrder();
            }
            else if (Request.QueryString["OrderStatus"].ToString() == "CancelledOrder")
            {
                GetOrderListForCancelledOrder();
            }
            //else if (Request.QueryString["OrderStatus"].ToString() == "DeliveredOrder")
            //{
            //    GetOrderListForDeliveredddOrder();
            //}
            else if (Request.QueryString["OrderStatus"].ToString() == "TotalOrder")
            {
                GetOrderList();
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



    //protected void gvProductDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    //{

    //}



    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            searchtext = txtSearch.Text.Trim();
            if (Request.QueryString["OrderStatus"].ToString() == "PlacedOrder")
            {
                GetOrderListForPlacedOrder();
            }
            else if (Request.QueryString["OrderStatus"].ToString() == "CompletedOrder")
            {
                GetOrderListForCompletedOrder();
            }
            else if (Request.QueryString["OrderStatus"].ToString() == "CancelledOrder")
            {
                GetOrderListForCancelledOrder();
            }
            //else if (Request.QueryString["OrderStatus"].ToString() == "DeliveredOrder")
            //{
            //    GetOrderListForDeliveredddOrder();
            //}
            else if (Request.QueryString["OrderStatus"].ToString() == "TotalOrder")
            {
                GetOrderList();
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void gvOrderInformation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlOrderStatus = ((DropDownList)e.Row.FindControl("ddlOrderStatus"));
                Label lblStatus = ((Label)e.Row.FindControl("lblorderstatus"));
                if (lblStatus.Text == "Order Placed")
                {
                    ddlOrderStatus.SelectedValue = "1";
                }
                else if (lblStatus.Text == "Order Completed")
                {
                    ddlOrderStatus.SelectedValue = "2";
                }
                else if (lblStatus.Text == "Order Cancelled")
                {
                    ddlOrderStatus.SelectedValue = "3";
                }
                //else if (lblStatus.Text == "Order Delivered")
                //{
                //    ddlOrderStatus.SelectedValue = "4";
                //}

                // ddlOrderStatus.Items.FindByValue(lblStatus.Text).Selected = true;
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
                gvOrderInformation.DataSource = null;
                gvOrderInformation.DataBind();
            }
            else if (txtFromOrderDate.Text != "" && txtToOrderDate.Text == "")
            {

                string message = "Plese Select From Date And To Date";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                gvOrderInformation.DataSource = null;
                gvOrderInformation.DataBind();
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
                gvOrderInformation.DataSource = null;
                gvOrderInformation.DataBind();
            }
            else
            {
                //DataTable dt = new DataTable();
                //DataView dv = null;

                if (Request.QueryString["OrderStatus"].ToString() == "PlacedOrder")
                {
                    GetOrderListForPlacedOrder();
                }
                else if (Request.QueryString["OrderStatus"].ToString() == "CompletedOrder")
                {
                    GetOrderListForCompletedOrder();
                }
                else if (Request.QueryString["OrderStatus"].ToString() == "CancelledOrder")
                {
                    GetOrderListForCancelledOrder();
                }
                //else if (Request.QueryString["OrderStatus"].ToString() == "DeliveredOrder")
                //{
                //    GetOrderListForDeliveredddOrder();
                //}
                else if (Request.QueryString["OrderStatus"].ToString() == "TotalOrder")
                {
                    GetOrderList();
                }

                //if (txtSearch.Text != "" && txtFromOrderDate.Text != "" && txtToOrderDate.Text != "")
                //    dt = objClsCustomerOrderDetail.GetOrderDatils(Convert.ToDateTime(txtFromOrderDate.Text), Convert.ToDateTime(txtToOrderDate.Text), txtSearch.Text).ListToDataTable();
                //else if ((txtFromOrderDate.Text != "" || txtToOrderDate.Text != "") && txtSearch.Text == "")
                //    dt = objClsCustomerOrderDetail.GetOrderDatils(Convert.ToDateTime(txtFromOrderDate.Text), Convert.ToDateTime(txtToOrderDate.Text)).ListToDataTable();
                //else if (txtSearch.Text != "" && (txtFromOrderDate.Text == "" || txtToOrderDate.Text == ""))
                //    dt = objClsCustomerOrderDetail.GetOrderDatils(Convert.ToDateTime("1/1/1900 12:00:00 AM"), Convert.ToDateTime("1/1/1900 12:00:00 AM"), txtSearch.Text).ListToDataTable();
                //else
                //    dt = objClsCustomerOrderDetail.GetOrderDatils(Convert.ToDateTime("1/1/1900 12:00:00 AM"), Convert.ToDateTime("1/1/1900 12:00:00 AM"), "").ListToDataTable();

                //dv = new DataView(dt);
                ////if (ViewState["SortExpression"] != null)
                ////{
                ////    string sortExpression = Convert.ToString(ViewState["SortExpression"]);
                ////    dv.Sort = sortExpression + SortDirection;
                ////}


                //if (dv != null && dv.Count > 0)
                //{
                //    gvOrderInformation.DataSource = dv;
                //    gvOrderInformation.DataBind();
                //}
                //else
                //{
                //    gvOrderInformation.DataSource = null;
                //    gvOrderInformation.DataBind();
                //}
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    protected void ddlOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

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