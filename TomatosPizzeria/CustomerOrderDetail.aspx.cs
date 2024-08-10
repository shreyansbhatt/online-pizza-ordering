using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerOrderDetail : System.Web.UI.Page
{
    ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();
    ClsMiscellaneousSettings objClsMiscellaneousSettings = new ClsMiscellaneousSettings();

    private string m_OrderNumber;

    public string OrderNumber
    {
        get { return m_OrderNumber; }
        set { m_OrderNumber = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserType"] != null)
            {
                if (Session["UserType"].ToString() == "2")
                {
                    liEditProfile.Visible = false;
                    liOrderHistory.Visible = false;
                }
                else
                {
                    li1.Visible = false;
                }
            }

            if (Session["UserEmail"] != null)
            {
               // SpanEmail.InnerHtml = Session["FirstName"].ToString();
                SignInDiv.Style.Add("display", "none");
                EmailDiv.Style.Add("display", "block");
                AccountDiv.Style.Add("display", "none");
                LogoutDiv.Style.Add("display", "block");
            }

            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    GetDeliveryChargeConfigSetting();
                    GetMinimumDeliveryPurchaseConfigSetting();
                    GetAddressDetail();
                    GetPhoneDetail();
                    GetFaxDetail();
                    GetEmailDetail();
                    GetAllRecentOrder();
                    GetLatestPreviousOrder();
                }
                else
                {
                    Response.Redirect("~/Index.aspx", false);
                }

            }
            CancelOrderdDiv.Style.Add("display", "none");
            OrderCancelSuccess.Style.Add("display", "none");
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    public void GetDeliveryChargeConfigSetting()
    {
        try
        {
            tp_config objConfig = new tp_config();
            objConfig = objClsMiscellaneousSettings.GetDeliveryChargeConfigSetting();
            if (objConfig != null)
            {
                lblDeliveryCharge.Text = objConfig.tpc_value;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    public void GetMinimumDeliveryPurchaseConfigSetting()
    {
        try
        {
            tp_config objConfig = new tp_config();
            objConfig = objClsMiscellaneousSettings.GetMinimumDeliveryPurchaseConfigSetting();
            if (objConfig != null)
            {
                lblminimumDeliveryPurchase.Text = objConfig.tpc_value;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    public void GetAddressDetail()
    {
        try
        {
            tp_config objConfig = new tp_config();
            objConfig = objClsMiscellaneousSettings.GetAddressDetail();
            if (objConfig != null)
            {
                lblAddress.Text = "Address: " + objConfig.tpc_value;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    public void GetPhoneDetail()
    {
        try
        {
            tp_config objConfig = new tp_config();
            objConfig = objClsMiscellaneousSettings.GetPhoneDetail();
            if (objConfig != null)
            {
                lblPhone.Text = "Phone: " + objConfig.tpc_value;
               // lblFooterPhone.Text = "Phone: " + objConfig.tpc_value;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    public void GetFaxDetail()
    {
        try
        {
            tp_config objConfig = new tp_config();
            objConfig = objClsMiscellaneousSettings.GetFaxDetail();
            if (objConfig != null)
            {
                lblFax.Text = "Fax: " + objConfig.tpc_value;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    public void GetEmailDetail()
    {
        try
        {
            tp_config objConfig = new tp_config();
            objConfig = objClsMiscellaneousSettings.GetEmailDetail();
            if (objConfig != null)
            {
               // lblSupportEmailOfTP.Text = objConfig.tpc_value;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    public void GetAllRecentOrder()
    {
        try
        {

            List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
            if (Session["UserId"] != null)
            {
                lstClsProductDetail = objClsCustomerOrderDetail.GetRecentOrderListByUserId(Convert.ToInt32(Session["UserId"]));
            }
            // lstClsProductDetail = objClsCustomerOrderDetail.GetRecentOrderListByUserId(1);
        // lstClsProductDetail.Clear();
            if (lstClsProductDetail.Count > 0)
            {
               
                lblOpenOrderNoSource.Visible = false;
                rptOpenOrderListOfUSer.Visible = true;
                rptOpenOrderListOfUSer.DataSource = lstClsProductDetail;
                rptOpenOrderListOfUSer.DataBind();
            }
            else
            {
                rptOpenOrderListOfUSer.Visible = false;
                lblOpenOrderNoSource.Visible = true;
                RowHeadingCurrent.Visible = true;
            }

        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    public void GetLatestPreviousOrder()
    {

        try
        {

            List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
            if (Session["UserId"] != null)
            {

                lstClsProductDetail = objClsCustomerOrderDetail.GetLatestPreviousOrderCount(Convert.ToInt32(Session["UserId"]));
               
                // lstClsProductDetail = objClsCustomerOrderDetail.GetLatestPreviousOrder(3);
                //lstClsProductDetail.Clear();
            }
            if (lstClsProductDetail.Count > 0)
            {
                OrderNumber = lstClsProductDetail[0].OrderNumber;
                if (OrderNumber != null)
                {
                    //lblOpenOrderNoSource.Visible = false;
                    rptPreviousOrder.Visible = true;
                   // PastOrderNumber.Visible = true;
                    lblPastOrder.Visible = false;
                    rptPreviousOrder.DataSource = lstClsProductDetail;
                    rptPreviousOrder.DataBind();
                }
                else
                {
                    //lblOpenOrderNoSource.Visible = false;
                    lblPastOrder.Visible = true;
                    rptPreviousOrder.Visible = false;
                    RowHeadingPast.Visible = true;
                   // PastOrderNumber.Visible = false;
                }
            }
            else
            {
                RowHeadingPast.Visible = true;

                lblPastOrder.Visible = true;
                rptPreviousOrder.Visible = false;
              //  PastOrderNumber.Visible = false;
            }

        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void lnkMenu_Click(object sender, EventArgs e)
    {
        try
        {
            TP_DatabaseEntities dbEntities = new TP_DatabaseEntities();
            string filePath = string.Empty;
            tp_config configobj = new tp_config();

            configobj = dbEntities.tp_config.Where(x => x.tpc_key == "TP_MENU_PATH").FirstOrDefault();
            if (configobj != null)
            {
                filePath = configobj.tpc_value;
            }
            configobj = dbEntities.tp_config.Where(x => x.tpc_key == "MENU_FILENAME").FirstOrDefault();
            {
                filePath += configobj.tpc_value;
            }
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=\"" + Path.GetFileName(filePath) + "\"");
            Response.WriteFile(filePath);
            Response.End();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }



    protected void rptPreviousOrder_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            Repeater rptPreviousOrderItem = (Repeater)e.Item.FindControl("rptPreviousOrderItem");

            
                List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();

                lstClsProductDetail = objClsCustomerOrderDetail.GetLatestPreviousOrder(Convert.ToInt32(Session["UserId"]));
                // lstClsProductDetail = objClsCustomerOrderDetail.GetRecentOrder(1, Convert.ToInt32(lblOrderId.Text.Trim()));

                if (lstClsProductDetail != null)
                {
                    rptPreviousOrderItem.DataSource = lstClsProductDetail;
                    rptPreviousOrderItem.DataBind();
                }          
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void rptPreviousOrderItem_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            Label lblOrderId = (Label)e.Item.FindControl("lblOrderId");
            Label lblProductdetailId = (Label)e.Item.FindControl("lblProductdetailId");
            if (lblOrderId != null && lblProductdetailId != null)
            {
                GridView gvExtraIngeredient = (GridView)e.Item.FindControl("gvExtraIngeredient");
                if (gvExtraIngeredient != null)
                {
                    DataTable dt = new DataTable();
                    dt = objClsCustomerOrderDetail.GetExtraIngredient(Convert.ToInt32(lblProductdetailId.Text.Trim()), Convert.ToInt32(lblOrderId.Text.Trim())).ListToDataTable();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        gvExtraIngeredient.DataSource = dt;
                        gvExtraIngeredient.DataBind();
                    }

                }

            }


        }
        catch(Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void rptOpenOrderListOfUSer_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            Label lblOrderId = (Label)e.Item.FindControl("lblOrderId");

            Repeater rptOpenOrder = (Repeater)e.Item.FindControl("rptOpenOrder");

            if (lblOrderId != null)
            {
                List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();

                lstClsProductDetail = objClsCustomerOrderDetail.GetRecentOrder(Convert.ToInt32(Session["UserId"]), Convert.ToInt32(lblOrderId.Text.Trim()));
                // lstClsProductDetail = objClsCustomerOrderDetail.GetRecentOrder(1, Convert.ToInt32(lblOrderId.Text.Trim()));

                if (lstClsProductDetail != null)
                {
                    rptOpenOrder.DataSource = lstClsProductDetail;
                    rptOpenOrder.DataBind();
                }

                foreach (RepeaterItem Items in rptOpenOrder.Items)
                {

                    Label lblProductdetailId = (Label)Items.FindControl("lblProductdetailId");
                    if (lblOrderId != null && lblProductdetailId != null)
                    {
                        GridView gvExtraIngeredient = (GridView)Items.FindControl("gvExtraIngeredient");
                        if (gvExtraIngeredient != null)
                        {
                            DataTable dt = new DataTable();
                            List<ClsProductDetail> lstofClsProductDetail = new List<ClsProductDetail>();
                            lstofClsProductDetail = objClsCustomerOrderDetail.GetExtraIngredient(Convert.ToInt32(lblProductdetailId.Text.Trim()), Convert.ToInt32(lblOrderId.Text.Trim()));
                            dt = lstofClsProductDetail.ListToDataTable();
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                gvExtraIngeredient.DataSource = dt;
                                gvExtraIngeredient.DataBind();
                            }

                        }
                    }
                }

            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    int OrderId = 0;
    protected void btnCurrentOrder_Click(object sender, EventArgs e)
    {
        try
        {
            GetAllRecentOrder();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void rptOpenOrderListOfUSer_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "CancelOrder")
            {
                OrderId = Convert.ToInt32(e.CommandArgument);
                DateTime OrderWishTime = objClsCustomerOrderDetail.GetOrderWishTimeByOrderId(OrderId).cod_order_wish_time.Value;
                if (OrderWishTime != Convert.ToDateTime("1/1/1900 12:00:00 AM"))
                {
                    DateTime CurrentTime = DateTime.Now;
                    TimeSpan timediff = OrderWishTime - CurrentTime;
                    if (timediff.Days >= 1)
                    {
                        string retMsg = objClsCustomerOrderDetail.CancelOrderByOrderId(OrderId);
                        if (retMsg == "SUCCESS")
                        {
                            OrderCancelSuccess.Style.Add("display", "block");
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
                            // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Order Cancel Successfully')", true);
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Order Cancel Successfully')", true);

                            GetAllRecentOrder();
                        }
                        GetAllRecentOrder();
                    }
                    else if (timediff.Hours >= 1)
                    {
                        string retMsg = objClsCustomerOrderDetail.CancelOrderByOrderId(OrderId);
                        if (retMsg == "SUCCESS")
                        {
                            OrderCancelSuccess.Style.Add("display", "block");
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
                            // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Order Cancel Successfully')", true);
                            GetAllRecentOrder();
                        }
                    }
                    else
                    {
                        CancelOrderdDiv.Style.Add("display", "block");
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);

                        // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "You Can Not Cancel Order Because Order Wish Time is not more than hour or later.", true);
                    }
                }
                else
                {
                    CancelOrderdDiv.Style.Add("display", "block");
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);

                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void Logout_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx", false);
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void rptOpenOrder_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }
    protected void lnkHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Index.aspx", false);
    }
    protected void lnkOffers_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Offers.aspx", false);
    }
    protected void lnkOrderOnline_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/OrderOnline.aspx", false);
    }

    //protected void btnPastOrder_Click(object sender, EventArgs e)
    //{
    //    GetLatestPreviousOrder();
    //}
   
}