using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_DashBoard : System.Web.UI.Page
{
    ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();

   
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserId"] != null)
            {
                //ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "alert('Your Massage');", true);
                if (Session["Message"] != null)
                {
                    if (Session["Message"].ToString() == "Success")
                    {
                        Response.Write("<script>alert('Order Status Updated Successfully');</script>");
                        Session["Message"] = null;
                    }
                }
                List<tp_customer_order_details> lstOrderTotalorder = new List<tp_customer_order_details>();

                lstOrderTotalorder = objClsCustomerOrderDetail.GetAllOrder();

                int TotalOrder = lstOrderTotalorder.Count;
                spantotalorder.InnerHtml = TotalOrder.ToString();

                List<tp_customer_order_details> lstOrderTotalPlacedorder = new List<tp_customer_order_details>();

                lstOrderTotalPlacedorder = objClsCustomerOrderDetail.GetAllPlacedOrder();

                int TotalPlaced = lstOrderTotalPlacedorder.Count;
                spanplacedorder.InnerHtml = TotalPlaced.ToString();

                List<tp_customer_order_details> lstOrderTotalConfirmorder = new List<tp_customer_order_details>();

                lstOrderTotalConfirmorder = objClsCustomerOrderDetail.GetAllCompletedOrder();

                int TotalConfirmOrder = lstOrderTotalConfirmorder.Count;
                spanCompletedorder.InnerHtml = TotalConfirmOrder.ToString();

                List<tp_customer_order_details> lstOrderTotalShippedorder = new List<tp_customer_order_details>();

                lstOrderTotalShippedorder = objClsCustomerOrderDetail.GetAllCancelledOrder();

                int TotalShippedOrder = lstOrderTotalShippedorder.Count;
                spanCancelledorder.InnerHtml = TotalShippedOrder.ToString();

                //List<fda_order_details> lstOrderTotalDeliverdorder = new List<fda_order_details>();

                //lstOrderTotalDeliverdorder = objClsOrderDetail.GetAllDeliverdOrder();

                //int TotalDeliverdOrder = lstOrderTotalDeliverdorder.Count;
                //spanDeliverdorder.InnerHtml = TotalDeliverdOrder.ToString();
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
