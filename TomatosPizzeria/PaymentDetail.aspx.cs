using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers.Bases;

public partial class PaymentDetail : System.Web.UI.Page
{
    TP_DatabaseEntities dbEntities = new TP_DatabaseEntities();
    ClsMiscellaneousSettings objClsMiscellaneousSettings = new ClsMiscellaneousSettings();
    tp_config objtp_config = new tp_config();
    string TEST_TRANSACTION_KEY = string.Empty;
    string TEST_LOGINID = string.Empty;

    string LIVE_TRANSACTION_KEY = string.Empty;
    string LIVE_LOGINID = string.Empty;
    string CREDITCARD_NUMBER = string.Empty;
    string CARD_EXPIRATION_DATE = string.Empty;
    decimal totalAmount = 0;
    static int OrderID = 0;
    string amount = null, orderId = null, Subtotal = null, discount = null, OrderType = null;

    string TransationID = null;

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

            lblTransType.Visible = false;
            lblMessage.Visible = false;
            ErrorMsgDiv.Style.Add("display", "none");
            //ErrorMsgDivYear.Style.Add("display", "none");

            if (Session["UserEmail"] != null)
            {
                //  SpanEmail.InnerHtml = Session["FirstName"].ToString();
                SignInDiv.Style.Add("display", "none");
                EmailDiv.Style.Add("display", "block");
                AccountDiv.Style.Add("display", "none");
                LogoutDiv.Style.Add("display", "block");
            }
            if (!string.IsNullOrEmpty(Request.QueryString.ToString()))
            {

                amount = DecryptString(HttpUtility.UrlDecode(Request.QueryString["TotalAmount"].ToString()));
                totalAmount = Convert.ToDecimal(amount);
                orderId = DecryptString(HttpUtility.UrlDecode(Request.QueryString["OrderId"].ToString()));
                OrderID = Convert.ToInt32(orderId);
                Subtotal = DecryptString(HttpUtility.UrlDecode(Request.QueryString["SubTotal"].ToString()));
                discount = DecryptString(HttpUtility.UrlDecode(Request.QueryString["discount"].ToString()));
                OrderType = DecryptString(HttpUtility.UrlDecode(Request.QueryString["OrderType"].ToString()));
            }


            if (!IsPostBack)
            {
                GetDeliveryChargeConfigSetting();
                GetMinimumDeliveryPurchaseConfigSetting();
                GetAddressDetail();
                GetPhoneDetail();
                GetFaxDetail();
                GetEmailDetail();
                GetAllStates();

                afacebbok.HRef = objClsMiscellaneousSettings.GetFaceBookLink().tpc_value;
                agoogleplus.HRef = objClsMiscellaneousSettings.GetGooglePlusLink().tpc_value;
                alinkedin.HRef = objClsMiscellaneousSettings.GetLinkedInLink().tpc_value;
                ayoutube.HRef = objClsMiscellaneousSettings.GetYouTubeLink().tpc_value;

                if (Session["UserId"] != null)
                {
                    tp_user_information dbObjUserLoginResult = new tp_user_information();
                    ClsUserInformation objClsUserInformation = new ClsUserInformation();
                    dbObjUserLoginResult = objClsUserInformation.GetUserDetailsById(Convert.ToInt32(Session["UserId"]));

                    if (dbObjUserLoginResult != null)
                    {
                        txtFirstName.Text = dbObjUserLoginResult.ui_firstName;
                        txtLastName.Text = dbObjUserLoginResult.ui_lastName;
                        txtaddress.Text = dbObjUserLoginResult.ui_addressLine1 + " " + dbObjUserLoginResult.ui_addressLine2;
                        txtCity.Text = dbObjUserLoginResult.ui_city;
                        txtzip.Text = dbObjUserLoginResult.ui_pincode;
                    }
                }
                else
                {
                    if (Session["Name"] != null)
                        txtFirstName.Text = Convert.ToString(Session["Name"]);

                    //if (Session["Name"] != null)
                    //    txtLastName.Text = Convert.ToString(Session["Name"]);

                    if (Session["Address"] != null || Convert.ToString(Session["Address"]) != "Address")
                        txtaddress.Text = Convert.ToString(Session["Address"]);

                    if (Session["City"] != null || Session["City"] != "City")
                        txtCity.Text = Convert.ToString(Session["City"]);

                    if (Session["Zip"] != null || Session["Zip"] != "Zip")
                        txtzip.Text = Convert.ToString(Session["Zip"]);
                }




            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    public void GetAllStates()
    {
        try
        {
            ClsUserInformation objClsUserInformation = new ClsUserInformation();
            List<tp_state> lstFdaStateInformation = new List<tp_state>();

            lstFdaStateInformation = objClsUserInformation.GetAllStates();
            DdlState.DataSource = lstFdaStateInformation;
            DdlState.DataValueField = "tps_id";
            DdlState.DataTextField = "tps_state_name";
            DdlState.DataBind();

            DdlState.Items.FindByText("Illinois-(IL)").Selected = true;
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
                //lblFooterPhone.Text = "Phone: " + objConfig.tpc_value;
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

    public ANetApiResponse Run(String ApiLoginID, String ApiTransactionKey, decimal totalAmount)
    {
        string retMsg = string.Empty;
        Console.WriteLine("Charge Credit Card Sample");
        string month = DdlMonth.SelectedItem.Text;
        string year = DdlYear.SelectedItem.Text;
        string expirationDate = month + "-" + year;
        string userfirstName = string.Empty;
        string userlastName = string.Empty;
        string useraddress = string.Empty;
        string usercity = string.Empty;
        string userzip = string.Empty;

        ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.PRODUCTION;

        // define the merchant information (authentication / transaction id)
        ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
        {
            name = ApiLoginID,
            //name = "5HBvdBr4G8g",
            ItemElementName = ItemChoiceType.transactionKey,
            Item = ApiTransactionKey,
            // Item = "4Z4p593457SGjexs",
        };

        var creditCard = new creditCardType
        {
            //cardNumber = "4111111111111111",
            //expirationDate = "0718",
            //cardCode = "123"
            cardNumber = txtCreditCardNumber.Text,
            expirationDate = expirationDate,
            cardCode = txtcvvnumber.Text
        };

        //if (Session["UserId"] != null)
        //{
        //    tp_user_information dbObjUserLoginResult = new tp_user_information();
        //    ClsUserInformation objClsUserInformation = new ClsUserInformation();
        //    dbObjUserLoginResult = objClsUserInformation.GetUserDetailsById(Convert.ToInt32(Session["UserId"]));

        //    if (dbObjUserLoginResult != null)
        //    {
        //        useraddress = dbObjUserLoginResult.ui_addressLine1 + " " + dbObjUserLoginResult.ui_addressLine2;
        //        usercity = dbObjUserLoginResult.ui_city;
        //        userfirstName = dbObjUserLoginResult.ui_firstName;
        //        userlastName = dbObjUserLoginResult.ui_lastName;
        //        userzip = dbObjUserLoginResult.ui_pincode;
        //    }
        //}
        //else
        //{

        useraddress = txtaddress.Text;
        usercity = txtCity.Text;
        userfirstName = txtFirstName.Text;
        userlastName = txtLastName.Text;
        userzip = txtzip.Text;
        //}
        var billingAddress = new customerAddressType
        {
            //firstName = "John",
            //lastName = "Doe",
            //address = "123 My St",
            //city = "OurTown",
            //zip = "98004"
            firstName = userfirstName,
            lastName = userlastName,
            address = useraddress,
            city = usercity,
            zip = userzip
        };

        //standard api call to retrieve response
        var paymentType = new paymentType { Item = creditCard };

        // Add line Items
        var lineItems = new lineItemType[2];
        //lineItems[0] = new lineItemType { itemId = "1", name = "t-shirt", quantity = 2, unitPrice = new Decimal(15.00) };
        //lineItems[1] = new lineItemType { itemId = "2", name = "snowboard", quantity = 1, unitPrice = new Decimal(450.00) };

        var transactionRequest = new transactionRequestType
        {
            transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),    // charge the card

            amount = totalAmount,
            payment = paymentType,
            billTo = billingAddress
        };

        var request = new createTransactionRequest { transactionRequest = transactionRequest };

        // instantiate the contoller that will call the service
        var controller = new createTransactionController(request);
        controller.Execute();

        // get the response from the service (errors contained if any)
        var response = controller.GetApiResponse();

        if (response != null && response.messages.resultCode == messageTypeEnum.Ok && response.transactionResponse.responseCode == "1")
        {
            if (response.transactionResponse != null)
            {
                Console.WriteLine("Success, Auth Code : " + response.transactionResponse.authCode);
            }

            string refId = response.transactionResponse.transId;

            ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();
            retMsg = objClsCustomerOrderDetail.UpdateTransactionHistory(OrderID, 2, refId);

            if (retMsg == "SUCCESS")
            {
                Session["OfferApplied"] = null;
                Session["PaymentGateway"] = "Yes";
                if (Session["CartIdList"] != null)
                {
                    List<ClsProductDetail> lstProductDetail = new List<ClsProductDetail>();
                    lstProductDetail = (List<ClsProductDetail>)Session["CartIdList"];
                    foreach (var item in lstProductDetail)
                    {
                        int cartId = item.CartId;
                        ClsCartDetail objClsCartDetail = new ClsCartDetail();
                        retMsg = objClsCartDetail.DeleteItemFromCart(cartId);

                    }
                }


                if (OrderType.Contains("Pick up"))
                {
                    objClsCustomerOrderDetail.UpdateOrdertyepByOrderId(OrderID, "Pick up Order With Online Payment");
                }
                else
                {
                    objClsCustomerOrderDetail.UpdateOrdertyepByOrderId(OrderID, "Online Order With Online Payment");
                }
                string orderNumber = objClsCustomerOrderDetail.GetOrderNumberByOrderId(OrderID);
                string url = "TransactionDetail.aspx?";

                string QueryString = string.Empty;
                string TransactionId = HttpUtility.UrlEncode(EncryptString(refId));
                string Message = HttpUtility.UrlEncode(EncryptString(retMsg));
                string Amount = HttpUtility.UrlEncode(EncryptString(amount));
                string OrderNumber = HttpUtility.UrlEncode(EncryptString(orderNumber));
                string Orderid = HttpUtility.UrlEncode(EncryptString(OrderID.ToString()));
                string SubTotal = HttpUtility.UrlEncode(EncryptString(Subtotal.ToString()));
                string Discount = HttpUtility.UrlEncode(EncryptString(discount.ToString()));
                string CardNumber = "";
                CREDITCARD_NUMBER = txtCreditCardNumber.Text;
                if (CREDITCARD_NUMBER.Length >= 4)
                {
                    string CardNum = CREDITCARD_NUMBER.Substring(CREDITCARD_NUMBER.Length - 4);
                    CardNumber = HttpUtility.UrlEncode(EncryptString(CardNum));
                }
                QueryString = string.Format("TotalAmount={0}&Message={1}&TransactionId={2}&OrderNumber={3}&OrderId={4}&SubTotal={5}&Discount={6}&CardNumber={7}", Amount, Message, TransactionId, OrderNumber, Orderid, SubTotal, Discount, CardNumber);
                url += QueryString;
                Response.Redirect(url, false);
            }
        }
        else if (response != null)
        {
            Console.WriteLine("Error: " + response.messages.message[0].code + "  " + response.messages.message[0].text);
            if (response.transactionResponse != null)
            {
                Session["PaymentGatewayMesage"] = response.transactionResponse.errors[0].errorText;
                //Session["PaymentGatewayMesage"] = response.transactionResponse.errors[0].errorCode + " " + response.transactionResponse.errors[0].errorText;
                Console.WriteLine("Transaction Error : " + response.transactionResponse.errors[0].errorCode + " " + response.transactionResponse.errors[0].errorText);
            }

            ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();
            string refId = response.transactionResponse.transId;
            retMsg = objClsCustomerOrderDetail.UpdateTransactionHistory(OrderID, 3, refId);
            if (retMsg == "SUCCESS")
            {
                Session["PaymentGateway"] = "Yes";

                string orderNumber = objClsCustomerOrderDetail.GetOrderNumberByOrderId(OrderID);
                string url = "TransactionDetail.aspx?";

                string QueryString = string.Empty;

                string Message = HttpUtility.UrlEncode(EncryptString("FAIL"));
                string Amount = HttpUtility.UrlEncode(EncryptString(amount));
                string OrderNumber = HttpUtility.UrlEncode(EncryptString(orderNumber));

                QueryString = string.Format("TotalAmount={0}&Message={1}&OrderNumber={2}", Amount, Message, OrderNumber);
                url += QueryString;
                Response.Redirect(url, false);
            }

        }

        return response;
    }

    //private void DoAuthorizationAndPayment()
    //{
    //    AuthorizeNetRequest objAuthorizeNetRequest = new AuthorizeNetRequest();
    //    CREDITCARD_NUMBER = txtCreditCardNumber.Text.Trim();
    //    string month = DdlMonth.SelectedItem.Text;
    //    string year = DdlYear.SelectedItem.Text;
    //    CARD_EXPIRATION_DATE = month + "-" + year;
    //    // This is the account information for merchant account given by Authorize.Net people in email
    //    // I can see transaction history here.
    //    //objtp_config = objClsMiscellaneousSettings.GetTestLoginId();
    //    //if (objtp_config != null)
    //    //{
    //    //    TEST_LOGINID = objtp_config.tpc_value;
    //    //}

    //    objtp_config = objClsMiscellaneousSettings.GetLiveLoginId();
    //    if (objtp_config != null)
    //    {
    //        LIVE_LOGINID = objtp_config.tpc_value;
    //    }

    //    //objAuthorizeNetRequest.Login = TEST_LOGINID; //For Testing
    //    objAuthorizeNetRequest.Login = LIVE_LOGINID;  //For Live


    //    objAuthorizeNetRequest.Amount = totalAmount;
    //    objAuthorizeNetRequest.CardNumber = CREDITCARD_NUMBER;
    //    objAuthorizeNetRequest.CardExpirationDate = CARD_EXPIRATION_DATE;
    //    objAuthorizeNetRequest.TransactionType = AuthorizeNet.TransactionType.CREDIT;

    //    // Below is the API created by me by registering for test account.
    //    //objtp_config = objClsMiscellaneousSettings.GetTestTransactionKey();
    //    //if (objtp_config != null)
    //    //{
    //    //    TEST_TRANSACTION_KEY = objtp_config.tpc_value;
    //    //}
    //    objtp_config = objClsMiscellaneousSettings.GetLiveTransactionKey();
    //    if (objtp_config != null)
    //    {
    //        LIVE_TRANSACTION_KEY = objtp_config.tpc_value;
    //    }

    //    //objAuthorizeNetRequest.TransactionKey = TEST_TRANSACTION_KEY;//For Testing
    //    objAuthorizeNetRequest.TransactionKey = LIVE_TRANSACTION_KEY; //For Live

    //    AuthorizeNetResponse objAuthorizeNetResponse = AuthorizeNet.CallAuthorizeNetMethod(objAuthorizeNetRequest);

    //    lblTransType.Text = "CREDIT";
    //    string retMsg = string.Empty;
    //    if (objAuthorizeNetResponse.IsSuccess)
    //    {

    //        TransationID = objAuthorizeNetResponse.TransactionId;
    //        ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();
    //        retMsg = objClsCustomerOrderDetail.UpdateTransactionHistory(OrderID, 2, TransationID);
    //        if (retMsg == "SUCCESS")
    //        {
    //            Session["OfferApplied"] = null;
    //            Session["PaymentGateway"] = "Yes";
    //            if (Session["CartIdList"] != null)
    //            {
    //                List<ClsProductDetail> lstProductDetail = new List<ClsProductDetail>();
    //                lstProductDetail = (List<ClsProductDetail>)Session["CartIdList"];
    //                foreach (var item in lstProductDetail)
    //                {
    //                    int cartId = item.CartId;
    //                    ClsCartDetail objClsCartDetail = new ClsCartDetail();
    //                    retMsg = objClsCartDetail.DeleteItemFromCart(cartId);

    //                }
    //            }


    //            if (OrderType.Contains("Pick up"))
    //            {
    //                objClsCustomerOrderDetail.UpdateOrdertyepByOrderId(OrderID, "Pick up Order With Online Payment");
    //            }
    //            else
    //            {
    //                objClsCustomerOrderDetail.UpdateOrdertyepByOrderId(OrderID, "Online Order With Online Payment");
    //            }
    //            string orderNumber = objClsCustomerOrderDetail.GetOrderNumberByOrderId(OrderID);
    //            string url = "TransactionDetail.aspx?";

    //            string QueryString = string.Empty;
    //            string TransactionId = HttpUtility.UrlEncode(EncryptString(TransationID));
    //            string Message = HttpUtility.UrlEncode(EncryptString(retMsg));
    //            string Amount = HttpUtility.UrlEncode(EncryptString(amount));
    //            string OrderNumber = HttpUtility.UrlEncode(EncryptString(orderNumber));
    //            string Orderid = HttpUtility.UrlEncode(EncryptString(OrderID.ToString()));
    //            string SubTotal = HttpUtility.UrlEncode(EncryptString(Subtotal.ToString()));
    //            string Discount = HttpUtility.UrlEncode(EncryptString(discount.ToString()));
    //            string CardNumber = "";
    //            if (CREDITCARD_NUMBER.Length >= 4)
    //            {
    //                string CardNum = CREDITCARD_NUMBER.Substring(CREDITCARD_NUMBER.Length - 4);
    //                CardNumber = HttpUtility.UrlEncode(EncryptString(CardNum));
    //            }
    //            QueryString = string.Format("TotalAmount={0}&Message={1}&TransactionId={2}&OrderNumber={3}&OrderId={4}&SubTotal={5}&Discount={6}&CardNumber={7}", Amount, Message, TransactionId, OrderNumber, Orderid, SubTotal, Discount, CardNumber);
    //            url += QueryString;
    //            Response.Redirect(url, false);


    //        }
    //        //lblMessage.Text = "Success. Transaction ID : " + objAuthorizeNetResponse.TransactionId + "Message" + objAuthorizeNetResponse.SuccessMessage;
    //    }
    //    else
    //    {
    //        ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();
    //        TransationID = objAuthorizeNetResponse.TransactionId;
    //        retMsg = objClsCustomerOrderDetail.UpdateTransactionHistory(OrderID, 3, TransationID);
    //        if (retMsg == "SUCCESS")
    //        {
    //            Session["PaymentGateway"] = "Yes";
    //            Session["PaymentGatewayMesage"] = objAuthorizeNetResponse.Errors + objAuthorizeNetResponse.SuccessMessage;
    //            string orderNumber = objClsCustomerOrderDetail.GetOrderNumberByOrderId(OrderID);
    //            string url = "TransactionDetail.aspx?";

    //            string QueryString = string.Empty;

    //            string Message = HttpUtility.UrlEncode(EncryptString("FAIL"));
    //            string Amount = HttpUtility.UrlEncode(EncryptString(amount));
    //            string OrderNumber = HttpUtility.UrlEncode(EncryptString(orderNumber));

    //            QueryString = string.Format("TotalAmount={0}&Message={1}&OrderNumber={2}", Amount, Message, OrderNumber);
    //            url += QueryString;
    //            Response.Redirect(url, false);
    //        }
    //        // lblMessage.Text = "Error : " + objAuthorizeNetResponse.Errors;
    //    }

    //}

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            //if (txtFirstName.Text == "First Name" || txtLastName.Text == "Last Name" || txtaddress.Text == "Address" || txtCity.Text == "City" || txtzip.Text == "Zip" || txtaddress.Text == "" || txtCity.Text == "" || txtzip.Text == "" || txtFirstName.Text == "" || txtLastName.Text == "")
            //{
            //    if (txtaddress.Text == "Address" || txtaddress.Text == "")
            //    {
            //        txtaddress.BorderColor = System.Drawing.Color.Red;
            //    }
            //    if (txtCity.Text == "City" || txtCity.Text == "")
            //    {
            //        txtCity.BorderColor = System.Drawing.Color.Red;
            //    }
            //    if (txtaddress.Text == "First Name" || txtaddress.Text == "")
            //    {
            //        txtaddress.BorderColor = System.Drawing.Color.Red;
            //    }
            //    if (txtLastName.Text == "Last Name" || txtLastName.Text == "")
            //    {
            //        txtLastName.BorderColor = System.Drawing.Color.Red;
            //    }
            //    if (txtzip.Text == "Zip" || txtzip.Text == "")
            //    {
            //        txtzip.BorderColor = System.Drawing.Color.Red;
            //    }
            //}
            //else
            //{

                Session["TransactionCount"] = "1";
                ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();
                string retMsg = "";
                if (rdbCOD.Checked == true)
                {
                    Session["PaymentGateway"] = "Yes";
                    if (OrderType.Contains("Pick up"))
                    {
                        objClsCustomerOrderDetail.UpdateOrdertyepByOrderId(OrderID, "Pick up Order With Cash On Delivery");
                    }
                    else
                    {
                        objClsCustomerOrderDetail.UpdateOrdertyepByOrderId(OrderID, "Online Order With Cash On Delivery");
                    }
                    if (Session["CartIdList"] != null)
                    {
                        List<ClsProductDetail> lstProductDetail1 = new List<ClsProductDetail>();
                        lstProductDetail1 = (List<ClsProductDetail>)Session["CartIdList"];
                        foreach (var item in lstProductDetail1)
                        {
                            int cartId = item.CartId;
                            ClsCartDetail objClsCartDetail = new ClsCartDetail();
                            retMsg = objClsCartDetail.DeleteItemFromCart(cartId);

                        }
                        retMsg = objClsCustomerOrderDetail.UpdateTransactionHistory(Convert.ToInt32(OrderID), 2, null);
                        string orderNumber = objClsCustomerOrderDetail.GetOrderNumberByOrderId(Convert.ToInt32(OrderID));
                        string url = "TransactionDetail.aspx?";

                        string QueryString = string.Empty;
                        string TransactionId = HttpUtility.UrlEncode(EncryptString(""));
                        string Message = HttpUtility.UrlEncode(EncryptString("SUCCESS"));
                        string Amounttotal = amount.Replace("$", "");
                        decimal DisplayTotalPrice = (Math.Floor(Convert.ToDecimal(Amounttotal.Replace("$", "")) * 100) / 100);
                        string Totalamount = string.Format("{0:N2}", DisplayTotalPrice);

                        string Amount = HttpUtility.UrlEncode(EncryptString(Totalamount));

                        string OrderNumber = HttpUtility.UrlEncode(EncryptString(orderNumber));
                        string Orderid = HttpUtility.UrlEncode(EncryptString(OrderID.ToString()));
                        string SubTotal = HttpUtility.UrlEncode(EncryptString(Subtotal));
                        string Discount = HttpUtility.UrlEncode(EncryptString(discount.ToString()));
                        string CardNumber = "";
                        string PaymentType = HttpUtility.UrlEncode(EncryptString("Cash On Delivery"));
                        QueryString = string.Format("TotalAmount={0}&Message={1}&TransactionId={2}&OrderNumber={3}&OrderId={4}&SubTotal={5}&Discount={6}&CardNumber={7}&PaymentType={8}", Amount, Message, TransactionId, OrderNumber, Orderid, SubTotal, Discount, CardNumber, PaymentType);
                        url += QueryString;
                        Response.Redirect(url, false);
                    }
                }
                else
                {
                    if (txtCreditCardNumber.Text == "Credit Card Number" || txtCreditCardNumber.Text == "" || DdlMonth.Text == "Expiry Month" || DdlMonth.SelectedIndex == -1 || DdlYear.SelectedIndex == -1 || DdlYear.Text == "Expiry Year" || txtcvvnumber.Text == "" || txtcvvnumber.Text == "CVV" || txtFirstName.Text == "First Name" || txtLastName.Text == "Last Name" || txtaddress.Text == "Address" || txtCity.Text == "City" || txtzip.Text == "Zip" || txtaddress.Text == "" || txtCity.Text == "" || txtzip.Text == "" || txtFirstName.Text == "" || txtLastName.Text == "")
                    {
                        if (txtCreditCardNumber.Text == "Credit Card Number" || txtCreditCardNumber.Text == "")
                        {
                            txtCreditCardNumber.BorderColor = System.Drawing.Color.Red;
                        }
                        if (DdlMonth.Text == "Expiry Month" || DdlMonth.SelectedIndex == 0)
                        {
                            DdlMonth.BorderColor = System.Drawing.Color.Red;
                        }
                        if (DdlYear.SelectedIndex == 0 || DdlYear.Text == "Expiry Year")
                        {
                            DdlYear.BorderColor = System.Drawing.Color.Red;
                        }
                        if (txtcvvnumber.Text == "CVV")
                        {
                            txtcvvnumber.BorderColor = System.Drawing.Color.Red;
                        }
                        if (txtaddress.Text == "Address" || txtaddress.Text == "")
                        {
                            txtaddress.BorderColor = System.Drawing.Color.Red;
                        }
                        if (txtCity.Text == "City" || txtCity.Text == "")
                        {
                            txtCity.BorderColor = System.Drawing.Color.Red;
                        }
                        if (txtaddress.Text == "First Name" || txtaddress.Text == "")
                        {
                            txtaddress.BorderColor = System.Drawing.Color.Red;
                        }
                        if (txtLastName.Text == "Last Name" || txtLastName.Text == "")
                        {
                            txtLastName.BorderColor = System.Drawing.Color.Red;
                        }
                        if (txtzip.Text == "Zip" || txtzip.Text == "")
                        {
                            txtzip.BorderColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        // DoAuthorizationAndPayment();

                        //objtp_config = objClsMiscellaneousSettings.GetTestLoginId();
                        //if (objtp_config != null)
                        //{
                        //    TEST_LOGINID = objtp_config.tpc_value;
                        //}

                        objtp_config = objClsMiscellaneousSettings.GetLiveLoginId();
                        if (objtp_config != null)
                        {
                            LIVE_LOGINID = objtp_config.tpc_value;
                        }

                        //objAuthorizeNetRequest.Login = TEST_LOGINID; //For Testing
                        // objAuthorizeNetRequest.Login = LIVE_LOGINID;

                        //objtp_config = objClsMiscellaneousSettings.GetTestTransactionKey();
                        //if (objtp_config != null)
                        //{
                        //    TEST_TRANSACTION_KEY = objtp_config.tpc_value;
                        //}

                        objtp_config = objClsMiscellaneousSettings.GetLiveTransactionKey();
                        if (objtp_config != null)
                        {
                            LIVE_TRANSACTION_KEY = objtp_config.tpc_value;
                        }

                        //    //objAuthorizeNetRequest.TransactionKey = TEST_TRANSACTION_KEY;//For Testing
                        //    objAuthorizeNetRequest.TransactionKey = LIVE_TRANSACTION_KEY; //For Live


                        Run(LIVE_LOGINID, LIVE_TRANSACTION_KEY, totalAmount);
                        //Run(TEST_LOGINID, TEST_TRANSACTION_KEY, totalAmount);

                        //retMsg = objClsCustomerOrderDetail.UpdateBillingDetails(OrderID, txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim(), txtaddress.Text.Trim(), txtCity.Text.Trim(), Convert.ToInt32(DdlState.SelectedValue), txtzip.Text.Trim());
                    }
                }
           // }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    private string EncryptString(string clearText)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        try
        {
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return clearText;
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
    protected void rdbCOD_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (rdbCOD.Checked == true)
            {
                txtCreditCardNumber.Enabled = false;
                DdlMonth.Enabled = false;
                DdlYear.Enabled = false;
                txtCreditCardNumber.BorderColor = System.Drawing.Color.White;
                DdlMonth.BorderColor = System.Drawing.Color.White;
                DdlYear.BorderColor = System.Drawing.Color.White;
                txtcvvnumber.Enabled = false;
                txtFirstName.Enabled = false;
                txtLastName.Enabled = false;
                txtaddress.Enabled = false;
                txtCity.Enabled = false;
                txtzip.Enabled = false;
            }
            else
            {
                txtCreditCardNumber.Enabled = true;
                DdlMonth.Enabled = true;
                DdlYear.Enabled = true;
                txtcvvnumber.Enabled = true;
                txtFirstName.Enabled = true;
                txtLastName.Enabled = true;
                txtaddress.Enabled = true;
                txtCity.Enabled = true;
                txtzip.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }



}