using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

public partial class TransactionDetail : System.Web.UI.Page
{
    TP_DatabaseEntities dbEntities = new TP_DatabaseEntities();
    ClsMiscellaneousSettings objClsMiscellaneousSettings = new ClsMiscellaneousSettings();
    ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();

    string Message = null, TransactionID = null, TotalAmount = null, TransactionStatus = null, TransactionDate = null, OrderNumber = null, SubTotal = null, Discount = null;
    int OrderId = 0;
    string OrderWishTime = "";
    string CARD_NUMBER = "", PaymentType = "";
    string Tax = "";
    string OrderType = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["TransactionCount"] != null)
        {
            if (Session["TransactionCount"].ToString() == "1")
            {
                SuccessMessageDiv.Style.Add("display", "none");
                ErrorMessageDiv.Style.Add("display", "none");
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
                    GetDeliveryChargeConfigSetting();
                    GetMinimumDeliveryPurchaseConfigSetting();
                    GetAddressDetail();
                    GetPhoneDetail();
                    GetFaxDetail();
                    GetEmailDetail();
                    GetTaxConfigSetting();

                    afacebbok.HRef = objClsMiscellaneousSettings.GetFaceBookLink().tpc_value;
                    agoogleplus.HRef = objClsMiscellaneousSettings.GetGooglePlusLink().tpc_value;
                    alinkedin.HRef = objClsMiscellaneousSettings.GetLinkedInLink().tpc_value;
                    ayoutube.HRef = objClsMiscellaneousSettings.GetYouTubeLink().tpc_value;

                }

                if (Session["PaymentGateway"] == "Yes")
                {

                    if (!string.IsNullOrEmpty(Request.QueryString.ToString()))
                    {
                        Message = DecryptString(HttpUtility.UrlDecode(Request.QueryString["Message"].ToString()));
                        if (Message == "SUCCESS")
                        {
                            SuccessMessageDiv.Style.Add("display", "block");
                            Session["PaymentGateway"] = "No";
                            TransactionID = DecryptString(HttpUtility.UrlDecode(Request.QueryString["TransactionId"].ToString()));
                            TotalAmount = DecryptString(HttpUtility.UrlDecode(Request.QueryString["TotalAmount"].ToString()));
                            OrderNumber = DecryptString(HttpUtility.UrlDecode(Request.QueryString["OrderNumber"].ToString()));
                            OrderId = Convert.ToInt32(DecryptString(HttpUtility.UrlDecode(Request.QueryString["OrderId"].ToString())));
                            SubTotal = DecryptString(HttpUtility.UrlDecode(Request.QueryString["SubTotal"].ToString()));
                            Discount = DecryptString(HttpUtility.UrlDecode(Request.QueryString["Discount"].ToString()));
                            CARD_NUMBER = DecryptString(HttpUtility.UrlDecode(Request.QueryString["CardNumber"].ToString()));
                            if (Request.QueryString["PaymentType"] != null)
                            {
                                PaymentType = Request.QueryString["PaymentType"].ToString();
                            }
                            TransactionStatus = "Success";
                            TransactionDate = DateTime.Now.ToString();

                            resultOrderNumber.Text = OrderNumber.ToString();
                            resultAmount.Text = "$" + TotalAmount.ToString();
                            resultTransactionId.Text = TransactionID.ToString();
                            resultStatus.Text = TransactionStatus;
                            resultPaymentType.Text = "Online";
                            resultTransactionDate.Text = TransactionDate;
                            objClsCustomerOrderDetail.UpdateOrderStatus(OrderId, "Order Completed");
                            List<ClsProductDetail> lstProductDetail = new List<ClsProductDetail>();
                            lstProductDetail = (List<ClsProductDetail>)Session["CartIdList"];
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
                            if (Request.QueryString["PaymentType"] == null)
                            {

                                ClsUserInformation objClsUderInformation = new ClsUserInformation();

                                OrderWishTime = Convert.ToDateTime(objClsCustomerOrderDetail.GetOrderWishTimeByOrderId(OrderId).cod_order_wish_time).ToString();
                                OrderType = objClsCustomerOrderDetail.GetOrderWishTimeByOrderId(OrderId).cod_order_type;
                                SendPDFEmail(lstProductDetail, OrderNumber, CARD_NUMBER);
                            }
                            else
                            {
                                if (PaymentType == "Cash On Delivery")
                                {
                                    resultPaymentType.Text = "Cash On Delivery";
                                }
                                else
                                {
                                    resultPaymentType.Text = "Offline";
                                }
                                OrderWishTime = Convert.ToDateTime(objClsCustomerOrderDetail.GetOrderWishTimeByOrderId(OrderId).cod_order_wish_time).ToString();
                                OrderType = objClsCustomerOrderDetail.GetOrderWishTimeByOrderId(OrderId).cod_order_type;
                                resultTransactionId.Text = "-";
                                resultStatus.Text = "-";
                                SendPDFEmail(lstProductDetail, OrderNumber, CARD_NUMBER);
                            }
                        }
                        else if (Message == "FAIL")
                        {
                            ErrorMessageDiv.Style.Add("display", "block");
                            Session["PaymentGateway"] = "No";
                            ErrorMessageDiv.InnerHtml = Convert.ToString(Session["PaymentGatewayMesage"]);
                            TotalAmount = DecryptString(HttpUtility.UrlDecode(Request.QueryString["TotalAmount"].ToString()));
                            OrderNumber = DecryptString(HttpUtility.UrlDecode(Request.QueryString["OrderNumber"].ToString()));
                            TransactionStatus = "Fail";
                            TransactionDate = DateTime.Now.ToString();

                            //resultOrderNumber.Text = OrderNumber.ToString();
                            resultOrderNumber.Text = "-";
                            resultAmount.Text = "$" + TotalAmount.ToString();
                            resultTransactionId.Text = "-";
                            resultStatus.Text = TransactionStatus;
                            resultTransactionDate.Text = TransactionDate;

                        }
                    }

                }
                else
                {
                    if (!string.IsNullOrEmpty(Request.QueryString.ToString()))
                    {
                        Message = DecryptString(HttpUtility.UrlDecode(Request.QueryString["Message"].ToString()));
                        if (Message == "SUCCESS")
                        {
                            SuccessMessageDiv.Style.Add("display", "block");

                            TransactionID = DecryptString(HttpUtility.UrlDecode(Request.QueryString["TransactionId"].ToString()));
                            TotalAmount = DecryptString(HttpUtility.UrlDecode(Request.QueryString["TotalAmount"].ToString()));
                            OrderNumber = DecryptString(HttpUtility.UrlDecode(Request.QueryString["OrderNumber"].ToString()));
                            OrderId = Convert.ToInt32(DecryptString(HttpUtility.UrlDecode(Request.QueryString["OrderId"].ToString())));
                            SubTotal = DecryptString(HttpUtility.UrlDecode(Request.QueryString["SubTotal"].ToString()));
                            Discount = DecryptString(HttpUtility.UrlDecode(Request.QueryString["Discount"].ToString()));
                            if (Request.QueryString["CardNumber"] != null)
                            {
                                CARD_NUMBER = DecryptString(HttpUtility.UrlDecode(Request.QueryString["CardNumber"].ToString()));
                            }
                            if (Request.QueryString["PaymentType"] != null)
                            {
                                PaymentType = Request.QueryString["PaymentType"].ToString();
                            }
                            TransactionStatus = "Success";
                            TransactionDate = DateTime.Now.ToString();

                            resultOrderNumber.Text = OrderNumber.ToString();
                            resultAmount.Text = "$" + TotalAmount.ToString();
                            resultTransactionId.Text = TransactionID.ToString();
                            resultStatus.Text = TransactionStatus;
                            resultPaymentType.Text = "Offline";
                            resultTransactionDate.Text = TransactionDate;
                            objClsCustomerOrderDetail.UpdateOrderStatus(OrderId, "Order Completed");
                            List<ClsProductDetail> lstProductDetail = new List<ClsProductDetail>();
                            lstProductDetail = (List<ClsProductDetail>)Session["CartIdList"];
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
                            if (Request.QueryString["PaymentType"] == null)
                            {

                                ClsUserInformation objClsUderInformation = new ClsUserInformation();

                                if (objClsCustomerOrderDetail.GetOrderWishTimeByOrderId(OrderId).cod_order_wish_time != Convert.ToDateTime("1/1/1900 12:00:00 AM"))

                                    OrderWishTime = Convert.ToDateTime(objClsCustomerOrderDetail.GetOrderWishTimeByOrderId(OrderId).cod_order_wish_time).ToString();
                                OrderType = objClsCustomerOrderDetail.GetOrderWishTimeByOrderId(OrderId).cod_order_type;

                                SendPDFEmail(lstProductDetail, OrderNumber, CARD_NUMBER);
                            }
                            else
                            {
                                if (PaymentType == "Cash On Delivery")
                                {
                                    resultPaymentType.Text = "Cash On Delivery";
                                }
                                else
                                {
                                    resultPaymentType.Text = "Offline";
                                }
                                OrderWishTime = Convert.ToDateTime(objClsCustomerOrderDetail.GetOrderWishTimeByOrderId(OrderId).cod_order_wish_time).ToString();
                                OrderType = objClsCustomerOrderDetail.GetOrderWishTimeByOrderId(OrderId).cod_order_type;
                                resultTransactionId.Text = "-";
                                resultStatus.Text = "-";
                                SendPDFEmail(lstProductDetail, OrderNumber, CARD_NUMBER);
                            }
                        }
                        else if (Message == "FAIL")
                        {
                            ErrorMessageDiv.Style.Add("display", "block");
                            Session["PaymentGateway"] = "No";
                            ErrorMessageDiv.InnerHtml = Convert.ToString(Session["PaymentGatewayMesage"]);
                            TotalAmount = DecryptString(HttpUtility.UrlDecode(Request.QueryString["TotalAmount"].ToString()));
                            OrderNumber = DecryptString(HttpUtility.UrlDecode(Request.QueryString["OrderNumber"].ToString()));
                            TransactionStatus = "Fail";
                            TransactionDate = DateTime.Now.ToString();

                           // resultOrderNumber.Text = OrderNumber.ToString();
                            resultOrderNumber.Text = "-";
                            resultAmount.Text = "$" + TotalAmount.ToString();
                            resultTransactionId.Text = "-";
                            resultStatus.Text = TransactionStatus;
                            resultTransactionDate.Text = TransactionDate;

                        }
                    }

                }
                Session["TransactionCount"] = null;
            }
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


    private void SendPDFEmail(List<ClsProductDetail> lstProductDetail, string OrderNumber, string CardNumber)
    {
        string CustomerAddress = "";
        string Email = objClsCustomerOrderDetail.GetUserInfoIdByOrderId(OrderId).Email;
        string CustomerName = objClsCustomerOrderDetail.GetUserInfoIdByOrderId(OrderId).CustomerName;
        string Telephone = objClsCustomerOrderDetail.GetUserInfoIdByOrderId(OrderId).TelephoneNo;
        string ComapnyAddress = objClsMiscellaneousSettings.GetAddressDetail().tpc_value;
        string ComapnyPhone = objClsMiscellaneousSettings.GetPhoneDetail().tpc_value;
        string SupportEmail = objClsMiscellaneousSettings.GetEmailDetail().tpc_value;
        string CustomerCity = objClsCustomerOrderDetail.GetUserInfoIdByOrderId(OrderId).CityName;
        string CustomerState = objClsCustomerOrderDetail.GetUserInfoIdByOrderId(OrderId).StateName;
        string CustomerZipCode = objClsCustomerOrderDetail.GetUserInfoIdByOrderId(OrderId).Pincode;
        string DeliveryInstruction = objClsCustomerOrderDetail.GetUserInfoIdByOrderId(OrderId).DeliveryInstruction;
        if (DeliveryInstruction == "" || DeliveryInstruction == null)
        {
            DeliveryInstruction = "None";
        }
        if (objClsCustomerOrderDetail.GetUserInfoIdByOrderId(OrderId).Addressline1 != null && objClsCustomerOrderDetail.GetUserInfoIdByOrderId(OrderId).Addressline1 != "")
        {
            string[] address = objClsCustomerOrderDetail.GetUserInfoIdByOrderId(OrderId).Addressline1.Split(',');
            for (int i = 0; i < address.Length; i++)
            {
                CustomerAddress = CustomerAddress + address[i] + "," + "<br/>";
            }
            CustomerAddress = CustomerAddress + CustomerCity + "," + CustomerState + " " + CustomerZipCode;
        }
        else
        {
            CustomerAddress = "";
        }
        string myString = string.Empty;
        string body22 = "";
        myString = myString + body22;
        string body11 = "<!DOCTYPE html><html><head><meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1' /><meta name='viewport' content='width=device-width, initial-scale=1'><meta name='viewport' content='width=device-width, initial-scale=1'><link rel='stylesheet' href='http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css'><script src='https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js'></script><script src='http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js'></script></head><body style='font-family:Geneva, Arial, Helvetica, sans-serif;width:600px;margin-top:300px;'></div><div class='wrapper' style='background:rgb(248, 248, 248);overflow:hidden;width:600px;text-align:center;'><div style='height:400px;width: 100%;'></div><div style='margin-top:400px;'><center></div><div class='address' style='border-bottom:1px solid #888888;'><h2 style='font-size: 16px;'>Tomato's Pizza</h2><h4>720 W. Irving Park Road,<br />Bensenville, IL 60106</h4><h4>$$ComapnyPhone$$</h4></div><div class='order-details' style='border-bottom:1px solid #888888;'> <h4 style='color:#d61717'<b><strong>ORDER NUMBER:$$OrderNumber$$</strong></b></h4></div><div class='delivery-order'><h3 style='font-size: 14px;'><b>Order placed on $$OrderDate$$</b></h3><h3 style='font-weight: normal;font-size: 14px;'><b>$$OrderFor$$ Order for $$OrderWishTime$$</b></h1></div><br />";
        myString = myString + body11;

        string bd1 = " <div class='table-responsive'><table border='0' style='border:none;width:100%; text-align:left; table-layout:auto;border-collapse: collapse;'><tbody><tr><td valign='top'><strong>Customer Details:</strong><br /><p style='color:#26752A;font-size: 14px;'><strong>$$CustomerName$$<br /></strong></p><strong>$$CustomerTelephone$$<br />$$CustomerAddress$$</strong></td><td valign='top'><strong>Delivery Instructions:$$DeliveryInstruction$$</strong></td></tr></tbody> </table></div><br />";
        myString = myString + bd1;

        if (OrderType.Contains("Pick up"))
        {
            myString = myString.Replace("$$OrderFor$$", "PICK UP");
        }
        else
        {
            myString = myString.Replace("$$OrderFor$$", "DELIVERY");
        }
        myString = myString.Replace("$$OrderNumber$$", OrderNumber);
        myString = myString.Replace("$$OrderDate$$", DateTime.Now.ToLongDateString());
        myString = myString.Replace("$$CustomerName$$", CustomerName);
        myString = myString.Replace("$$CustomerAddress$$", CustomerAddress);
        myString = myString.Replace("$$CustomerTelephone$$", Telephone);
        myString = myString.Replace("$$ComapnyAddress$$", ComapnyAddress);
        myString = myString.Replace("$$ComapnyPhone$$", ComapnyPhone);
        myString = myString.Replace("$$DeliveryInstruction$$", DeliveryInstruction);


        //if (OrderWishTime != "")
        //{
            myString = myString.Replace("$$OrderWishTime$$", OrderWishTime);
       // }
        //else
        //{
        //    myString = myString.Replace("$$OrderWishTime$$", "ASAP");
        //}

        string body1 = "<div class='table-responsive' style='padding:10px 20px;text-align:center;'><table border='1' bordercolor='#4B924E' style='padding:5px; border:1px solid #4B924E;width:100%; text-align:center; table-layout:auto;border-collapse: collapse;'><thead style='background-color: #4B924E;color: #ffffff;'><tr><th style='padding: 10px;background-color: #4B924E;text-align:left;width:50%;' width='70%'>ITEM</th><th style='padding: 10px;background-color: #4B924E;text-align:center;width:25%;' width='15%'>QTY</th><th style='padding: 10px;background-color: #4B924E;text-align:right;width:25%;' width='15%'>PRICE</th></tr></thead><tbody>";
        myString = myString + body1;
        foreach (var item in lstProductDetail)
        {
            string body2 = "<tr rowspan='2' style='text-align:center;'><td id='CS' style='padding: 10px;text-align:left;width:70%;' width='70%'><strong>{ProductName}</strong><br><span class='ing_name' id='MZC'>{ExtraIngredient}</span><br><span class='ing_name' id='MZC'>Comment:{Comment}</span></td><td style='padding: 10px;width:15%;' width='15%'>{Quantity}</td><td style='padding: 10px;text-align:right;width:15%;' width='15%'>{Price}</td></tr>";
            myString = myString + body2;
            myString = myString.Replace("{ProductName}", item.ProductName+" "+item.SizeName);
            if (item.ExtraIngredient == "No Extra Ingredient Found")
            {
                item.ExtraIngredient = "";
            }
            myString = myString.Replace("{ExtraIngredient}", item.ExtraIngredient.ToString());
            myString = myString.Replace("{Quantity}", item.Quantity.ToString());

            myString = myString.Replace("{Comment}", item.Comment.ToString());
            if (item.Comment == "-")
            {
                myString = myString.Replace("Comment:-", "");
            }
           
                decimal DisplayTotalPrice= (Math.Floor(Convert.ToDecimal(item.Price.ToString().Replace("$", "")) * 100) / 100);
                string Price = string.Format("{0:N2}", DisplayTotalPrice);

                Price = "$" + Price.ToString().Replace("$", "");
            myString = myString.Replace("{Price}", Price);
        }
        string body3 = "<tr style='text-align:right;'><td style='padding: 10px;background: #ffffff;'></td><td style='padding: 10px;background: #ffffff;text-align:right;'>Subtotal:</td><td style='padding: 10px;background: #ffffff;text-align:right;'>{Subtotal}</td></tr><tr style='text-align:right;'><td style='padding: 10px;background: #ffffff;'></td><td style='padding: 10px;background: #ffffff;text-align:right;'>Delivery:</td><td style='padding: 10px;background: #ffffff;'>{DeliveryCharge}</td></tr style='text-align:right;'><tr><td style='padding: 10px;background: #ffffff;'></td><td style='padding: 10px;background: #ffffff;text-align:right;'>Tax:</td><td style='padding: 10px;background: #ffffff;text-align:right;''>{TaxDetail}</td></tr><tr style='text-align:right;'><td style='padding: 10px;background: #ffffff;'></td><td style='padding: 10px;background: #ffffff;text-align:right;'>Discount:</td><td style='padding: 10px;background: #ffffff;'>{Discount}</td></tr><tr style='font-weight:600;text-align:right;'><td rowspan='2' style='padding: 10px;background: #ffffff;text-align:left;'><em>Payment Method:$$PaymentMethod$$ <br>ending with -$$CardNumber$$</em> <td rowspan='2' style='padding: 10px;background: #ffffff;text-align:right;'>Total:</td><td rowspan='2' style='padding: 10px;background: #ffffff;text-align:right;'>{TotalAmount}</td></tr></tbody></table></div>";

       
            decimal DisplayTotalPrice1=(Math.Floor(Convert.ToDecimal(TotalAmount.Replace("$", "")) * 100) / 100);
            string Totalamount = string.Format("{0:N2}", DisplayTotalPrice1);

            Totalamount = "$" + Totalamount.ToString().Replace("$", "");
            //string Totalamount = "$" + DisplayTotalPrice1.ToString().Replace("$", "");
        Tax = Tax.Replace("%", "");
        if (Tax != "" && Tax != null && SubTotal != "" && SubTotal != null)
        {
            decimal salestax = ((Convert.ToDecimal(Tax)) * Convert.ToDecimal(SubTotal.Replace("$", ""))) / 100;
            Tax = "$" + salestax.ToString().Replace("$", "");
            decimal DisplaysalesTax = (Math.Floor(Convert.ToDecimal(Tax.Replace("$", "")) * 100) / 100);
            Tax = string.Format("{0:N2}", DisplaysalesTax);
            Tax = "$" + Tax.ToString().Replace("$", "");
            
        }
        string deliverycharge = "0";
        if (Session["PickupOrder"]!=null)
        {
            deliverycharge = "0";
        }
        else
        {
            deliverycharge = lblDeliveryCharge.Text;
        }
        myString = myString + body3;
        myString = myString.Replace("{Subtotal}", SubTotal);
        myString = myString.Replace("{DeliveryCharge}", deliverycharge);
        myString = myString.Replace("{TaxDetail}", Tax);
        myString = myString.Replace("{Discount}", Discount);
        myString = myString.Replace("$$CardNumber$$", CardNumber);
        if (OrderType.Contains("Cash"))
        {
            myString = myString.Replace("$$PaymentMethod$$", "CASH");
            myString = myString.Replace("ending with -", "");
           
        }
        else
        {
            myString = myString.Replace("$$PaymentMethod$$", "CREDIT");
            myString = myString.Replace("$$CardNumber$$", CARD_NUMBER);
            
        }

        myString = myString.Replace("{TotalAmount}", Totalamount);
        myString = myString.Replace("$$SupportEmail$$", SupportEmail);
        myString = myString.Replace("$$CustomerTelephone$$", Telephone);

        StreamReader reader;
        string readFile;
        string myString1 = string.Empty;
        reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplateCustomerOrder.html"));
        readFile = reader.ReadToEnd();
        reader.Dispose();
        myString1 = readFile;
        myString1 = myString1.Replace("$$OrderNumber$$", OrderNumber);
        myString1 = myString1.Replace("$$OrderDate$$", DateTime.Now.ToLongDateString());
        myString1 = myString1.Replace("$$CustomerName$$", CustomerName);
        myString1 = myString1.Replace("$$CustomerAddress$$", CustomerAddress);
        myString1 = myString1.Replace("$$CustomerTelephone$$", Telephone);
        myString1 = myString1.Replace("$$ComapnyAddress$$", ComapnyAddress);
        myString1 = myString1.Replace("$$ComapnyPhone$$", ComapnyPhone);
        myString1 = myString1.Replace("$$DeliveryInstruction$$", DeliveryInstruction);

        if (OrderType.Contains("Pick up"))
        {
            myString1 = myString1.Replace("$$OrderFor$$", "PICK UP");
        }
        else
        {
            myString1 = myString1.Replace("$$OrderFor$$", "DELIVERY");
        }

       // if (OrderWishTime != "")
      //  {
            myString1 = myString1.Replace("$$OrderWishTime$$", OrderWishTime);
      //  }
       // else
       // {
        //    myString1 = myString1.Replace("$$OrderWishTime$$", "ASAP");
       // }


        string body12 = "<div class='table-responsive' style='padding:10px 20px;'><table border='1' bordercolor='#D3D3D3' style='padding:5px; border:0.5px solid #D3D3D3;width:100%; text-align:left; table-layout:auto;border-collapse: collapse;'><thead style='background:#4B924E;color: #ffffff;'><tr style='background-color:#4B924E;color: #ffffff;text-align:center;'><th style='padding: 10px;width:50%'>ITEM</th><th style='padding: 10px;width:25%'>QTY</th><th style='padding: 10px;text-align:right;width:25%'>PRICE</th></tr></thead><tbody>";
        myString1 = myString1 + body12;
        foreach (var item in lstProductDetail)
        {
            string body2 = "<tr rowspan='2' style='text-align:center;'><td id='CS' style='padding: 10px;background: #ffffff;text-align:left;width:50%'><strong>{ProductName}</strong><br><span class='ing_name' id='MZC'>{ExtraIngredient}</span><br><span class='ing_name' id='MZC'>Comment:{Comment}</span></td><td style='padding: 10px;background: #ffffff;width:25%'>{Quantity}</td><td style='padding: 10px;background: #ffffff;text-align:right;width:25%'>{Price}</td></tr>";
            myString1 = myString1 + body2;
            myString1 = myString1.Replace("{ProductName}", item.ProductName + " " + item.SizeName);
            if (item.ExtraIngredient == "No Extra Ingredient Found")
            {
                item.ExtraIngredient = "";
            }
            myString1 = myString1.Replace("{ExtraIngredient}", item.ExtraIngredient.ToString());
            myString1 = myString1.Replace("{Quantity}", item.Quantity.ToString());
            myString1 = myString1.Replace("{Comment}", item.Comment.ToString());
            if (item.Comment == "-")
            {
                myString1 = myString1.Replace("Comment:-", "");
            }
           
                decimal DisplayTotalPrice = (Math.Floor(Convert.ToDecimal(item.Price.ToString().Replace("$", "")) * 100) / 100);
                string Price = string.Format("{0:N2}", DisplayTotalPrice);
                Price = "$" + Price.ToString().Replace("$", "");
                

            myString1 = myString1.Replace("{Price}", Price);
        }
        string body32 = "<tr style='text-align:right;'><td style='padding: 10px;background: #ffffff;'></td><td style='padding: 10px;background: #ffffff;text-align:right;'>Subtotal:</td><td style='padding: 10px;background: #ffffff;text-align:right;'>{Subtotal}</td></tr><tr style='text-align:right;'><td style='padding: 10px;background: #ffffff;'></td><td style='padding: 10px;background: #ffffff;text-align:right;'>Delivery:</td><td style='padding: 10px;background: #ffffff;'>{DeliveryCharge}</td></tr style='text-align:right;'><tr><td style='padding: 10px;background: #ffffff;'></td><td style='padding: 10px;background: #ffffff;text-align:right;'>Tax:</td><td style='padding: 10px;background: #ffffff;text-align:right;''>{TaxDetail}</td></tr><tr style='text-align:right;'><td style='padding: 10px;background: #ffffff;'></td><td style='padding: 10px;background: #ffffff;text-align:right;'>Discount:</td><td style='padding: 10px;background: #ffffff;'>{Discount}</td></tr><tr style='font-weight:600;text-align:right;'><td rowspan='2' style='padding: 10px;background: #ffffff;text-align:left;'><em>Payment Method:$$PaymentMethod$$ <br>ending with -$$CardNumber$$</em> <td rowspan='2' style='padding: 10px;background: #ffffff;text-align:right;'>Total:</td><td rowspan='2' style='padding: 10px;background: #ffffff;text-align:right;'>{TotalAmount}</td></tr></tbody></table></div>";
        myString1 = myString1 + body32;
        myString1 = myString1.Replace("{Subtotal}", SubTotal);
        myString1 = myString1.Replace("{DeliveryCharge}", deliverycharge);
        myString1 = myString1.Replace("{TaxDetail}", Tax);
        myString1 = myString1.Replace("{Discount}", Discount);
        myString1 = myString1.Replace("{TotalAmount}", Totalamount);
        myString1 = myString1.Replace("$$CustomerTelephone$$", Telephone);
        myString1 = myString1.Replace("$$CardNumber$$", CardNumber);
        if (OrderType.Contains("Cash"))
        {
            myString1 = myString1.Replace("$$PaymentMethod$$", "CASH");
            myString1 = myString1.Replace("ending with -", "");
        }
        else
        {
            myString1 = myString1.Replace("$$PaymentMethod$$", "CREDIT");
        }


        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);

        StringReader sr = new StringReader(myString);

        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        using (MemoryStream memoryStream = new MemoryStream())
        {
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            byte[] bytes = memoryStream.ToArray();
            memoryStream.Close();

            ClsConfiguration objClsConfiguration = new ClsConfiguration();
            string UserName = objClsConfiguration.GetUsernmConfigSetting().tpc_value;
            string Password = objClsConfiguration.GetPasswordConfigSetting().tpc_value;
            string ServerName = objClsConfiguration.GetServerNameConfigSetting().tpc_value;
            //Development
           // MailMessage mm = new MailMessage(UserName, "16304770778@efaxsend.com");
            //Live
            MailMessage mm = new MailMessage(UserName, "16307662688@efaxsend.com");
            mm.Subject = OrderNumber;
            mm.Body = myString1;
            mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "OrderDetail.pdf"));
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = ServerName;
            smtp.EnableSsl = false;
            NetworkCredential NetworkCred = new NetworkCredential();
            NetworkCred.UserName = UserName;

            NetworkCred.Password = Password;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);

            MailMessage mm1 = new MailMessage(UserName, Email);
            mm1.Subject = OrderNumber;
            mm1.Body = myString1;
            mm1.Attachments.Add(new Attachment(new MemoryStream(bytes), "OrderDetail.pdf"));
            mm1.IsBodyHtml = true;
            SmtpClient smtp1 = new SmtpClient();
            smtp1.Host = ServerName;
            smtp1.EnableSsl = false;
            NetworkCredential NetworkCred1 = new NetworkCredential();
            NetworkCred1.UserName = UserName;

            NetworkCred1.Password = Password;
            smtp1.UseDefaultCredentials = true;
            smtp1.Credentials = NetworkCred1;
            smtp1.Port = 587;
            smtp1.Send(mm1);

            MailMessage mm2 = new MailMessage(UserName, UserName);
            mm2.Subject = OrderNumber;
            mm2.Body = myString1;
            mm2.Attachments.Add(new Attachment(new MemoryStream(bytes), "OrderDetail.pdf"));
            mm2.IsBodyHtml = true;
            SmtpClient smtp2 = new SmtpClient();
            smtp2.Host = ServerName;
            smtp2.EnableSsl = false;
            NetworkCredential NetworkCred2 = new NetworkCredential();
            NetworkCred2.UserName = UserName;

            NetworkCred2.Password = Password;
            smtp2.UseDefaultCredentials = true;
            smtp2.Credentials = NetworkCred1;
            smtp2.Port = 587;
            smtp2.Send(mm2);

        }
    }

    public void GetTaxConfigSetting()
    {
        tp_config objConfig = new tp_config();
        objConfig = objClsMiscellaneousSettings.GetTaxConfigSetting();
        if (objConfig != null)
        {
            Tax = objConfig.tpc_value;

        }
    }

    private string DecryptString(string cipherText)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        cipherText = cipherText.Replace(" ", "+");
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return cipherText;
    }

    protected void lnkMenu_Click(object sender, EventArgs e)
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

    protected void btnHome_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Index.aspx", false);
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
}