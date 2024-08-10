using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PlaceOrder : System.Web.UI.Page
{
    ClsUserInformation objClsUserInformation = new ClsUserInformation();
    ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();
    ClsMiscellaneousSettings objClsMiscellaneousSettings = new ClsMiscellaneousSettings();
    decimal Total = 0;
    private string m_MinimumPurchase;

    public string MinimumPurchase
    {
        get { return m_MinimumPurchase; }
        set { m_MinimumPurchase = value; }
    }

    private string m_DeliveryCharge;

    public string DeliveryCharge
    {
        get { return m_DeliveryCharge; }
        set { m_DeliveryCharge = value; }
    }

    private string m_StoreStartTime;

    public string StoreStartTime
    {
        get { return m_StoreStartTime; }
        set { m_StoreStartTime = value; }
    }

    private string m_StoreEndTime;

    public string StoreEndTime
    {
        get { return m_StoreEndTime; }
        set { m_StoreEndTime = value; }
    }

    tp_config objtp_config = new tp_config();
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


            UserAlreadyExistsDiv.Style.Add("display", "none");
            StoreClosedDiv.Style.Add("display", "none");
            StoreInvalidTime.Style.Add("display", "none");
            ClsMiscellaneousSettings objClsMiscellaneousSettings = new ClsMiscellaneousSettings();


            objtp_config = objClsMiscellaneousSettings.GetMinimumDeliveryPurchaseConfigSetting();
            MinimumPurchase = objtp_config.tpc_value;
            DeliveryCharge = objClsMiscellaneousSettings.GetDeliveryChargeConfigSetting().tpc_value;
            ErrorMsgDiv.Style.Add("display", "none");

            datepicker.Text = DateTime.Now.ToString("MM/dd/yyyy");

            if (Session["UserEmail"] != null)
            {
                //SpanEmail.InnerHtml = Session["FirstName"].ToString();
                SignInDiv.Style.Add("display", "none");
                EmailDiv.Style.Add("display", "block");
                AccountDiv.Style.Add("display", "none");
                LogoutDiv.Style.Add("display", "block");
                h4LoginLabel.Visible = false;
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
                //  GetUserDetailsById();
                //GetUserCartDetail();

                afacebbok.HRef = objClsMiscellaneousSettings.GetFaceBookLink().tpc_value;
                agoogleplus.HRef = objClsMiscellaneousSettings.GetGooglePlusLink().tpc_value;
                alinkedin.HRef = objClsMiscellaneousSettings.GetLinkedInLink().tpc_value;
                ayoutube.HRef = objClsMiscellaneousSettings.GetYouTubeLink().tpc_value;

                lblSalesPrice.Text = objClsMiscellaneousSettings.GetTaxConfigSetting().tpc_value;
                if (Session["isChecked"] != null)
                {
                    if (Session["isChecked"].ToString() == "true")
                    {
                        chkPickOrder.Checked = true;
                        // datepicker.Enabled = false;
                        //// ddlHour.Enabled = false;
                        // DdlMinute.Enabled = false;
                        // DdlTime.Enabled = false;
                        txtaddress.Enabled = false;
                        txtCity.Enabled = false;
                        DdlState.Enabled = false;
                        txtzip.Enabled = false;
                        txtDeliveryInstructions.Enabled = false;
                        lblDeliveryCharges.Text = "$0";
                    }
                    else
                    {
                        lblDeliveryCharges.Text = objClsMiscellaneousSettings.GetDeliveryChargeConfigSetting().tpc_value;
                    }
                }
                else
                {
                    lblDeliveryCharges.Text = objClsMiscellaneousSettings.GetDeliveryChargeConfigSetting().tpc_value;
                }

                if (Session["UserId"] != null || Session["RandomNumber"] != null)
                {

                    GetUserDetailsById();
                    GetUserCartDetail();
                }

                Total = 0;
                if (Session["OfferAmount"] != null)
                {
                    lblDiscount.Text = Session["OfferAmount"].ToString();
                }
                else
                {
                    lblDiscount.Text = "$0";
                }
                //foreach (RepeaterItem items in rptOrderDetail.Items)
                //{
                //    Label lblPrice = (Label)items.FindControl("lblPrice");
                //    if (lblPrice != null)
                //    {
                //        Total = Total + Convert.ToDecimal(lblPrice.Text.ToString().Replace("$", ""));
                //    }
                //}

                //LblTotal.Text = Total.ToString();
                //decimal tax = (Convert.ToDecimal(lblSalesPrice.Text.ToString().Replace("%", "")) * Convert.ToDecimal(Total)) / 100;
                //LblTotalPrice.Text = "$" + (Total + tax + Convert.ToDecimal(lblDeliveryCharges.Text.Replace("$", ""))).ToString();
                //LblTotal.Text = "$" + (LblTotal.Text.Replace("$", ""));

            }
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
                //  lblSupportEmailOfTP.Text = objConfig.tpc_value;
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


    public void GetUserDetailsById()
    {
        try
        {
            tp_user_information dbObjUserLoginResult = new tp_user_information();
            dbObjUserLoginResult = objClsUserInformation.GetUserDetailsById(Convert.ToInt32(Session["UserId"]));
            //dbObjUserLoginResult = objClsUserInformation.GetUserDetailsById(1);
            if (dbObjUserLoginResult != null)
            {
                txtaddress.Text = dbObjUserLoginResult.ui_addressLine1 + " " + dbObjUserLoginResult.ui_addressLine2;
                txtCity.Text = dbObjUserLoginResult.ui_city;
                txtemail.Text = dbObjUserLoginResult.ui_email;
                txtName.Text = dbObjUserLoginResult.ui_firstName + " " + dbObjUserLoginResult.ui_lastName;
                txtTelephone.Text = dbObjUserLoginResult.ui_telephone;
                txtzip.Text = dbObjUserLoginResult.ui_pincode;
                DdlState.SelectedValue = dbObjUserLoginResult.ui_state_id.ToString();
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    public void GetUserCartDetail()
    {
        string retMsg = string.Empty;
        try
        {
            List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();

            if (Session["UserId"] != null)
            {
                lstClsProductDetail = objClsCustomerOrderDetail.GetUserCartDetail(Convert.ToInt32(Session["UserId"]), "0");
            }
            else
            {
                // lstClsProductDetail = objClsCustomerOrderDetail.GetUserCartDetail(1, "0");
                lstClsProductDetail = objClsCustomerOrderDetail.GetUserCartDetail(0, Session["RandomNumber"].ToString());
            }
            if (lstClsProductDetail.Count > 0)
            {
                lblOpenOrderNoSource.Visible = false;
                PriceDiv.Visible = true;
                OfferDiv.Visible = true;
                rptOrderDetail.Visible = true;

                rptOrderDetail.DataSource = lstClsProductDetail;
                rptOrderDetail.DataBind();
                Total = 0;
                foreach (RepeaterItem items in rptOrderDetail.Items)
                {
                    Label lblPrice = (Label)items.FindControl("lblPrice");
                    if (lblPrice != null)
                    {
                        Total = Total + Convert.ToDecimal(lblPrice.Text.ToString().Replace("$", ""));
                    }

                    Label lblCommentCart = (Label)items.FindControl("lblComment");
                    if (lblCommentCart != null)
                    {
                        if (lblCommentCart.Text == "Comment:-")
                        {
                            lblCommentCart.Visible = false;
                        }
                    }

                }
                lblSalesPrice.Text = objClsMiscellaneousSettings.GetTaxConfigSetting().tpc_value;
                LblTotal.Text = Total.ToString();
                decimal tax = (Convert.ToDecimal(lblSalesPrice.Text.ToString().Replace("%", "")) * Convert.ToDecimal(Total)) / 100;
                lblSalesPrice.Text = "$" + tax.ToString().Replace("$", "");

                decimal DisplaysalesTax = (Math.Floor(Convert.ToDecimal(lblSalesPrice.Text.Replace("$", "")) * 100) / 100);
                lblSalesPrice.Text = string.Format("{0:N2}", DisplaysalesTax);


                lblSalesPrice.Text = "$" + lblSalesPrice.Text.ToString().Replace("$", "");
                LblTotalPrice.Text = "$" + (Convert.ToDecimal(LblTotal.Text.ToString().Replace("$", "")) + tax + Convert.ToDecimal(lblDeliveryCharges.Text.Replace("$", ""))).ToString();
                decimal DisplayTotalPrice = ((Math.Floor(Convert.ToDecimal(LblTotalPrice.Text.Replace("$", "")) * 100) / 100));
                LblTotalPrice.Text = string.Format("{0:N2}", DisplayTotalPrice);

                LblTotalPrice.Text = "$" + LblTotalPrice.Text.Replace("$", "");
                LblTotal.Text = "$" + (LblTotal.Text.Replace("$", ""));

                if (Session["OfferApplied"] != null)
                {
                    if (Session["OfferCode"] != null)
                    {
                        txtOfferCode.Text = Session["OfferCode"].ToString();
                    }
                    if (Session["OfferApplied"].ToString().Contains("Applied"))
                    {
                        try
                        {
                            string RandomNumber = "0", OrderType = string.Empty;
                            int userId = 0;
                            List<ClsProductDetail> lstProductDetail = new List<ClsProductDetail>();

                            foreach (RepeaterItem items in rptOrderDetail.Items)
                            {
                                Label lblCartId = (Label)items.FindControl("lblCartId");
                                Label lblProductdetailId = (Label)items.FindControl("lblProductdetailId");
                                Label lblPropertyId = (Label)items.FindControl("lblPropertyId");
                                Label lblProductIngredientFactId = (Label)items.FindControl("lblProductIngredientFactId");
                                Label lblExtraIngredientId = (Label)items.FindControl("lblExtraIngredientId");
                                Label lblSizeId = (Label)items.FindControl("lblSizeId");
                                Label lblPrice = (Label)items.FindControl("lblPrice");
                                TextBox textboxQuantity = (TextBox)items.FindControl("txtQuantity");
                                Label lblSizeName = (Label)items.FindControl("lblSizeName");

                                if (lblCartId != null && lblProductdetailId != null && lblPropertyId != null && lblProductIngredientFactId != null && lblExtraIngredientId != null
                                    && lblSizeId != null && lblPrice != null && textboxQuantity != null)
                                {
                                    ClsProductDetail objClsProductDetail = new ClsProductDetail();
                                    objClsProductDetail.CartId = Convert.ToInt32(lblCartId.Text);
                                    objClsProductDetail.ProductdetailId = Convert.ToInt32(lblProductdetailId.Text);
                                    objClsProductDetail.PropertiesId = Convert.ToInt32(lblPropertyId.Text);
                                    objClsProductDetail.IngredientFactId = Convert.ToInt32(lblProductIngredientFactId.Text);
                                    objClsProductDetail.ExtraIngredientId = lblExtraIngredientId.Text;
                                    objClsProductDetail.SizeId = Convert.ToInt32(lblSizeId.Text);
                                    objClsProductDetail.Quantity = Convert.ToInt32(textboxQuantity.Text);
                                    objClsProductDetail.Price = Convert.ToDecimal(lblPrice.Text.Replace("$", ""));
                                    objClsProductDetail.SizeName = lblSizeName.Text;
                                    lstProductDetail.Add(objClsProductDetail);
                                }
                            }
                            //userId = 3;
                            if (Session["UserId"] != null)
                            {
                                userId = Convert.ToInt32(Session["UserId"]);
                            }
                            if (Session["RandomNumber"] != null)
                            {
                                RandomNumber = Session["RandomNumber"].ToString();
                            }
                            if (chkPickOrder.Checked == true)
                            {
                                OrderType = "Pick up";
                            }
                            else
                            {
                                OrderType = "Online";
                            }
                            ClsDailySpecialsOffer objClsDailySpecialsOffer = new ClsDailySpecialsOffer();
                            if (Session["OfferApplied"] != null)
                            {
                                ClsProductDetail ClsProductDetailobj = new ClsProductDetail();
                                ClsProductDetailobj = objClsDailySpecialsOffer.GetOfferAmountByOfferCode(txtOfferCode.Text, lstProductDetail);
                                if (ClsProductDetailobj.ProductdetailId != 0)
                                {
                                    Session["OfferApplied"] = "Applied";
                                    ClsCartDetail objCartDetail = new ClsCartDetail();
                                    if (Session["UserId"] != null)
                                    {
                                        // if (ClsProductDetailobj.CombineSizeId != "0")
                                        // {
                                        // int SizeId = Convert.ToInt32(ClsProductDetailobj.CombineSizeId.Split(',')[1]);
                                        ClsProductDetail objOfClsProductDetail = new ClsProductDetail();
                                        objOfClsProductDetail = lstClsProductDetail.Where(x => x.ProductdetailId == ClsProductDetailobj.ProductdetailId && x.SizeId == ClsProductDetailobj.SizeId && ClsProductDetailobj.PropertiesId == x.PropertiesId && x.IngredientFactId == ClsProductDetailobj.IngredientFactId && x.Price == 0).FirstOrDefault();

                                        if (objOfClsProductDetail.ProductdetailId != null)
                                        {
                                            retMsg = objCartDetail.UpdateCartDetail(Convert.ToInt32(objOfClsProductDetail.CartId), Convert.ToInt32(objOfClsProductDetail.ProductdetailId), Convert.ToInt32(Session["UserId"]), Convert.ToInt32(ClsProductDetailobj.SizeId), Convert.ToInt32(objOfClsProductDetail.PropertiesId), Convert.ToInt32(ClsProductDetailobj.Quantity), "0", Convert.ToInt32(objOfClsProductDetail.IngredientFactId), "0");
                                        }
                                        else
                                        {
                                            retMsg = objCartDetail.InsertCartDetail(ClsProductDetailobj.ProductdetailId, Convert.ToInt32(Session["UserId"]), ClsProductDetailobj.SizeId, ClsProductDetailobj.PropertiesId, ClsProductDetailobj.Quantity, "0", ClsProductDetailobj.IngredientFactId, "0", null, null);
                                        }
                                        // }
                                        // retMsg = objCartDetail.InsertCartDetail(ClsProductDetailobj.ProductdetailId, Convert.ToInt32(Session["UserId"]), ClsProductDetailobj.SizeId, ClsProductDetailobj.PropertiesId, 1, "0", ClsProductDetailobj.IngredientFactId, "0", null);
                                        //retMsg = objCartDetail.InsertCartDetail(ClsProductDetailobj.ProductdetailId, 1, ClsProductDetailobj.SizeId, ClsProductDetailobj.PropertiesId, 1, "0", ClsProductDetailobj.IngredientFactId, "0", lstClsCartDetail);
                                    }
                                    else
                                    {
                                        ClsProductDetail objOfClsProductDetail = new ClsProductDetail();
                                        objOfClsProductDetail = lstClsProductDetail.Where(x => x.ProductdetailId == ClsProductDetailobj.ProductdetailId && x.SizeId == ClsProductDetailobj.SizeId && ClsProductDetailobj.PropertiesId == x.PropertiesId && x.IngredientFactId == ClsProductDetailobj.IngredientFactId && x.Price == 0).FirstOrDefault();

                                        if (objOfClsProductDetail.ProductdetailId != null)
                                        {
                                            retMsg = objCartDetail.UpdateCartDetail(Convert.ToInt32(objOfClsProductDetail.CartId), Convert.ToInt32(objOfClsProductDetail.ProductdetailId), 0, Convert.ToInt32(ClsProductDetailobj.SizeId), Convert.ToInt32(objOfClsProductDetail.PropertiesId), Convert.ToInt32(ClsProductDetailobj.Quantity), "0", Convert.ToInt32(objOfClsProductDetail.IngredientFactId), Session["RandomNumber"].ToString());
                                        }
                                        else
                                        {
                                            retMsg = objCartDetail.InsertCartDetail(ClsProductDetailobj.ProductdetailId, 0, ClsProductDetailobj.SizeId, ClsProductDetailobj.PropertiesId, ClsProductDetailobj.Quantity, "0", ClsProductDetailobj.IngredientFactId, Session["RandomNumber"].ToString(), null, null);
                                        }
                                        //retMsg = objCartDetail.InsertCartDetail(ClsProductDetailobj.ProductdetailId, 0, ClsProductDetailobj.SizeId, ClsProductDetailobj.PropertiesId, 1, "0", ClsProductDetailobj.IngredientFactId, Session["RandomNumber"].ToString(), null);
                                    }
                                    List<ClsProductDetail> ClsProductDetaillst = new List<ClsProductDetail>();
                                    if (Session["UserId"] != null)
                                    {
                                        ClsProductDetaillst = objClsCustomerOrderDetail.GetUserCartDetail(Convert.ToInt32(Session["UserId"]), "0");
                                    }
                                    else
                                    {
                                        // lstClsProductDetail = objClsCustomerOrderDetail.GetUserCartDetail(1, "0");
                                        ClsProductDetaillst = objClsCustomerOrderDetail.GetUserCartDetail(0, Session["RandomNumber"].ToString());
                                    }

                                    if (ClsProductDetaillst.Count > 0)
                                    {
                                        rptOrderDetail.DataSource = ClsProductDetaillst;
                                        rptOrderDetail.DataBind();
                                    }
                                    lblDiscount.Text = "$0";
                                    txtOfferCode.Text = "";

                                }
                                else
                                {
                                    Total = 0;
                                    foreach (RepeaterItem items in rptOrderDetail.Items)
                                    {
                                        Label lblPrice = (Label)items.FindControl("lblPrice");
                                        if (lblPrice != null)
                                        {
                                            Total = Total + Convert.ToDecimal(lblPrice.Text.ToString().Replace("$", ""));
                                        }
                                    }
                                    LblTotal.Text = Total.ToString();
                                    lblDiscount.Text = "$" + ClsProductDetailobj.OfferAmount.ToString();
                                    decimal SubTotalAfterDis = (Convert.ToDecimal(Total) - Convert.ToDecimal(lblDiscount.Text.Replace("$", "")));
                                    decimal tax1 = (Convert.ToDecimal(lblSalesPrice.Text.ToString().Replace("%", "")) * Convert.ToDecimal(SubTotalAfterDis)) / 100;
                                    decimal DisplaysalesTax1 = (Math.Floor(Convert.ToDecimal(lblSalesPrice.Text.Replace("$", "")) * 100) / 100);
                                    lblSalesPrice.Text = string.Format("{0:N2}", DisplaysalesTax1);

                                    lblSalesPrice.Text = "$" + lblSalesPrice.Text.ToString().Replace("$", "");
                                    LblTotalPrice.Text = "$" + (Convert.ToDecimal(SubTotalAfterDis) + Convert.ToDecimal(lblSalesPrice.Text.ToString().Replace("$", "")) + Convert.ToDecimal(lblDeliveryCharges.Text.Replace("$", ""))).ToString();
                                    decimal DisplayTotalPrice1 = (Math.Floor(Convert.ToDecimal(LblTotalPrice.Text.Replace("$", "")) * 100) / 100);
                                    LblTotalPrice.Text = string.Format("{0:N2}", DisplayTotalPrice1);

                                    LblTotalPrice.Text = "$" + LblTotalPrice.Text.Replace("$", "");
                                    lblSalesPrice.Text = "$" + lblSalesPrice.Text.ToString().Replace("$", "");


                                    Session["OfferApplied"] = "Applied";
                                    Session["OfferAmount"] = lblDiscount.Text;
                                    txtOfferCode.Text = "";
                                    //LblTotal.Text = Total.ToString();
                                    //decimal tax1 = (Convert.ToDecimal(lblSalesPrice.Text.ToString().Replace("%", "")) * Convert.ToDecimal(Total)) / 100;

                                    //LblTotalPrice.Text = "$" + (Total + tax1 + Convert.ToDecimal(lblDeliveryCharges.Text.Replace("$", ""))).ToString();
                                    //LblTotal.Text = "$" + (LblTotal.Text.Replace("$", ""));

                                    //Session["OfferApplied"] = "Applied";
                                    //LblTotalPrice.Text = "$" + (Convert.ToDecimal(LblTotalPrice.Text.Replace("$", "")) - ClsProductDetailobj.OfferAmount).ToString();
                                    //lblDiscount.Text = "$" + ClsProductDetailobj.OfferAmount.ToString();
                                    //Session["OfferAmount"] = lblDiscount.Text;
                                    //txtOfferCode.Text = "";
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            ErrorHandler.WriteError(ex);
                        }
                    }
                }
            }
            else
            {
                rptOrderDetail.Visible = false;
                lblOpenOrderNoSource.Visible = true;
                // PriceDiv.Visible = false;
                OfferDiv.Visible = false;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {

    }
    protected void txtPrice_TextChanged(object sender, EventArgs e)
    {
        ClsCartDetail objClsCartDetail = new ClsCartDetail();
        try
        {
            try
            {
                Total = 0;
                string retMsg = string.Empty;
                if (Session["UserEmail"] != null)
                {
                    foreach (RepeaterItem items in rptOrderDetail.Items)
                    {
                        Label lblCartId = (Label)items.FindControl("lblCartId");
                        Label lblProductdetailId = (Label)items.FindControl("lblProductdetailId");
                        Label lblSizeId = (Label)items.FindControl("lblSizeId");
                        Label lblPropertyId = (Label)items.FindControl("lblPropertyId");
                        Label lblProductIngredientFactId = (Label)items.FindControl("lblProductIngredientFactId");
                        Label lblPrice = (Label)items.FindControl("lblPrice");
                        Label lblOneQuantityPrice = (Label)items.FindControl("lblOneQuantityPrice");
                        TextBox txtQuantity = (TextBox)items.FindControl("txtQuantity");
                        if (txtQuantity != null && lblPrice != null && lblOneQuantityPrice != null)
                        {
                            lblPrice.Text = (Convert.ToDecimal(lblOneQuantityPrice.Text) * Convert.ToDecimal(txtQuantity.Text)).ToString();
                        }

                        Label labelPrice = (Label)items.FindControl("lblPrice");
                        if (labelPrice != null)
                        {
                            Total = Total + Convert.ToDecimal(labelPrice.Text.ToString().Replace("$", ""));
                        }

                        retMsg = objClsCartDetail.UpdateCartDetail(Convert.ToInt32(lblCartId.Text.Trim()), Convert.ToInt32(lblProductdetailId.Text.Trim()), Convert.ToInt32(Session["UserId"]), Convert.ToInt32(lblSizeId.Text.Trim()), Convert.ToInt32(lblPropertyId.Text.Trim()), Convert.ToInt32(txtQuantity.Text.Trim()), lblPrice.Text.ToString(), Convert.ToInt32(lblProductIngredientFactId.Text.Trim()), "0");
                        //retMsg = objClsCartDetail.UpdateCartDetail(Convert.ToInt32(lblCartId.Text.Trim()), Convert.ToInt32(lblProductdetailId.Text.Trim()), 1, Convert.ToInt32(lblSizeId.Text.Trim()), Convert.ToInt32(lblPropertyId.Text.Trim()), Convert.ToInt32(txtQuantity.Text.Trim()), lblPrice.Text.ToString(), Convert.ToInt32(lblProductIngredientFactId.Text.Trim()), "0");
                    }

                    lblSalesPrice.Text = objClsMiscellaneousSettings.GetTaxConfigSetting().tpc_value;
                    LblTotal.Text = Total.ToString();
                    decimal tax = (Convert.ToDecimal(lblSalesPrice.Text.ToString().Replace("%", "")) * Convert.ToDecimal(Total)) / 100;
                    lblSalesPrice.Text = "$" + tax.ToString().Replace("$", "");
                    decimal DisplaysalesTax = (Math.Floor(Convert.ToDecimal(lblSalesPrice.Text.Replace("$", "")) * 100) / 100);
                    lblSalesPrice.Text = string.Format("{0:N2}", DisplaysalesTax);

                    lblSalesPrice.Text = "$" + lblSalesPrice.Text.ToString().Replace("$", "");
                    LblTotalPrice.Text = "$" + (Total + Convert.ToDecimal(lblSalesPrice.Text.ToString().Replace("$", "")) + Convert.ToDecimal(lblDeliveryCharges.Text.Replace("$", ""))).ToString();
                    decimal DisplayTotalPrice = (Math.Floor(Convert.ToDecimal(LblTotalPrice.Text.Replace("$", "")) * 100) / 100);
                    LblTotalPrice.Text = string.Format("{0:N2}", DisplayTotalPrice);

                    LblTotalPrice.Text = "$" + LblTotalPrice.Text.Replace("$", "");
                    LblTotal.Text = "$" + (LblTotal.Text);
                }
                else
                {
                    foreach (RepeaterItem items in rptOrderDetail.Items)
                    {
                        Label lblCartId = (Label)items.FindControl("lblCartId");
                        Label lblProductdetailId = (Label)items.FindControl("lblProductdetailId");
                        Label lblSizeId = (Label)items.FindControl("lblSizeId");
                        Label lblPropertyId = (Label)items.FindControl("lblPropertyId");
                        Label lblProductIngredientFactId = (Label)items.FindControl("lblProductIngredientFactId");
                        Label lblPrice = (Label)items.FindControl("lblPrice");
                        Label lblOneQuantityPrice = (Label)items.FindControl("lblOneQuantityPrice");
                        TextBox txtQuantity = (TextBox)items.FindControl("txtQuantity");
                        if (txtQuantity != null && lblPrice != null && lblOneQuantityPrice != null)
                        {
                            lblPrice.Text = (Convert.ToDecimal(lblOneQuantityPrice.Text) * Convert.ToDecimal(txtQuantity.Text)).ToString();
                        }

                        Label labelPrice = (Label)items.FindControl("lblPrice");
                        if (labelPrice != null)
                        {
                            Total = Total + Convert.ToDecimal(labelPrice.Text.ToString().Replace("$", ""));
                        }

                        //  retMsg = objClsCartDetail.UpdateCartDetail(Convert.ToInt32(lblCartId.Text.Trim()), Convert.ToInt32(lblProductdetailId.Text.Trim()), 0, Convert.ToInt32(lblSizeId.Text.Trim()), Convert.ToInt32(lblPropertyId.Text.Trim()), Convert.ToInt32(txtQuantity.Text.Trim()), lblPrice.Text.ToString(), Convert.ToInt32(lblProductIngredientFactId.Text.Trim()), "0");

                        retMsg = objClsCartDetail.UpdateCartDetail(Convert.ToInt32(lblCartId.Text.Trim()), Convert.ToInt32(lblProductdetailId.Text.Trim()), 0, Convert.ToInt32(lblSizeId.Text.Trim()), Convert.ToInt32(lblPropertyId.Text.Trim()), Convert.ToInt32(txtQuantity.Text.Trim()), lblPrice.Text.ToString(), Convert.ToInt32(lblProductIngredientFactId.Text.Trim()), Session["RandomNumber"].ToString());
                    }


                    lblSalesPrice.Text = objClsMiscellaneousSettings.GetTaxConfigSetting().tpc_value;
                    LblTotal.Text = Total.ToString();
                    decimal tax = (Convert.ToDecimal(lblSalesPrice.Text.ToString().Replace("%", "")) * Convert.ToDecimal(Total)) / 100;
                    lblSalesPrice.Text = "$" + tax.ToString().Replace("$", "");
                    decimal DisplaysalesTax = (Math.Floor(Convert.ToDecimal(lblSalesPrice.Text.Replace("$", "")) * 100) / 100);
                    lblSalesPrice.Text = string.Format("{0:N2}", DisplaysalesTax);

                    lblSalesPrice.Text = "$" + lblSalesPrice.Text.ToString().Replace("$", "");

                    LblTotalPrice.Text = "$" + (Total + Convert.ToDecimal(lblSalesPrice.Text.ToString().Replace("$", "")) + Convert.ToDecimal(lblDeliveryCharges.Text.Replace("$", ""))).ToString();
                    decimal DisplayTotalPrice = (Math.Floor(Convert.ToDecimal(LblTotalPrice.Text.Replace("$", "")) * 100) / 100);
                    LblTotalPrice.Text = string.Format("{0:N2}", DisplayTotalPrice);

                    LblTotalPrice.Text = "$" + LblTotalPrice.Text.Replace("$", "");
                    LblTotal.Text = "$" + (LblTotal.Text);
                }


            }
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex);
            }

            if (Session["OfferApplied"] != null)
            {
                if (Session["OfferApplied"].ToString().Contains("Applied"))
                {
                    try
                    {
                        string retMsg = string.Empty, RandomNumber = "0", OrderType = string.Empty;
                        int userId = 0;
                        List<ClsProductDetail> lstProductDetail = new List<ClsProductDetail>();

                        foreach (RepeaterItem items in rptOrderDetail.Items)
                        {
                            Label lblCartId = (Label)items.FindControl("lblCartId");
                            Label lblProductdetailId = (Label)items.FindControl("lblProductdetailId");
                            Label lblPropertyId = (Label)items.FindControl("lblPropertyId");
                            Label lblProductIngredientFactId = (Label)items.FindControl("lblProductIngredientFactId");
                            Label lblExtraIngredientId = (Label)items.FindControl("lblExtraIngredientId");
                            Label lblSizeId = (Label)items.FindControl("lblSizeId");
                            Label lblPrice = (Label)items.FindControl("lblPrice");
                            TextBox textboxQuantity = (TextBox)items.FindControl("txtQuantity");
                            Label lblSizeName = (Label)items.FindControl("lblSizeName");

                            if (lblCartId != null && lblProductdetailId != null && lblPropertyId != null && lblProductIngredientFactId != null && lblExtraIngredientId != null
                                && lblSizeId != null && lblPrice != null && textboxQuantity != null)
                            {
                                ClsProductDetail objClsProductDetail = new ClsProductDetail();
                                objClsProductDetail.CartId = Convert.ToInt32(lblCartId.Text);
                                objClsProductDetail.ProductdetailId = Convert.ToInt32(lblProductdetailId.Text);
                                objClsProductDetail.PropertiesId = Convert.ToInt32(lblPropertyId.Text);
                                objClsProductDetail.IngredientFactId = Convert.ToInt32(lblProductIngredientFactId.Text);
                                objClsProductDetail.ExtraIngredientId = lblExtraIngredientId.Text;
                                objClsProductDetail.SizeId = Convert.ToInt32(lblSizeId.Text);
                                objClsProductDetail.Quantity = Convert.ToInt32(textboxQuantity.Text);
                                objClsProductDetail.SizeName = lblSizeName.Text;
                                objClsProductDetail.Price = Convert.ToDecimal(lblPrice.Text.Replace("$", ""));
                                lstProductDetail.Add(objClsProductDetail);
                            }
                        }
                        //userId = 3;
                        if (Session["UserId"] != null)
                        {
                            userId = Convert.ToInt32(Session["UserId"]);
                        }
                        if (Session["RandomNumber"] != null)
                        {
                            RandomNumber = Session["RandomNumber"].ToString();
                        }
                        if (chkPickOrder.Checked == true)
                        {
                            OrderType = "Pick up";
                        }
                        else
                        {
                            OrderType = "Online";
                        }
                        ClsDailySpecialsOffer objClsDailySpecialsOffer = new ClsDailySpecialsOffer();
                        if (Session["OfferApplied"] != null)
                        {
                            if (Session["OfferCode"] != null)
                            {
                                txtOfferCode.Text = Session["OfferCode"].ToString();
                            }
                            ClsProductDetail ClsProductDetailobj = new ClsProductDetail();
                            ClsProductDetailobj = objClsDailySpecialsOffer.GetOfferAmountByOfferCode(txtOfferCode.Text, lstProductDetail);
                            if (ClsProductDetailobj.ProductdetailId != 0)
                            {
                                Session["OfferApplied"] = "Applied";
                                List<ClsProductDetail> listOfClsProductDetail = new List<ClsProductDetail>();

                                if (Session["UserId"] != null)
                                {
                                    listOfClsProductDetail = objClsCustomerOrderDetail.GetUserCartDetail(Convert.ToInt32(Session["UserId"]), "0");
                                }
                                else
                                {
                                    // lstClsProductDetail = objClsCustomerOrderDetail.GetUserCartDetail(1, "0");
                                    listOfClsProductDetail = objClsCustomerOrderDetail.GetUserCartDetail(0, Session["RandomNumber"].ToString());
                                }
                                ClsCartDetail objCartDetail = new ClsCartDetail();
                                if (Session["UserId"] != null)
                                {
                                    // if (ClsProductDetailobj.CombineSizeId != "0")
                                    // {
                                    // int SizeId = Convert.ToInt32(ClsProductDetailobj.CombineSizeId.Split(',')[1]);
                                    ClsProductDetail objOfClsProductDetail = new ClsProductDetail();
                                    objOfClsProductDetail = listOfClsProductDetail.Where(x => x.ProductdetailId == ClsProductDetailobj.ProductdetailId && x.SizeId == ClsProductDetailobj.SizeId && ClsProductDetailobj.PropertiesId == x.PropertiesId && x.IngredientFactId == ClsProductDetailobj.IngredientFactId && x.Price == 0).FirstOrDefault();

                                    if (objOfClsProductDetail.ProductdetailId != null)
                                    {
                                        retMsg = objCartDetail.UpdateCartDetail(Convert.ToInt32(objOfClsProductDetail.CartId), Convert.ToInt32(objOfClsProductDetail.ProductdetailId), Convert.ToInt32(Session["UserId"]), Convert.ToInt32(ClsProductDetailobj.SizeId), Convert.ToInt32(objOfClsProductDetail.PropertiesId), Convert.ToInt32(ClsProductDetailobj.Quantity), "0", Convert.ToInt32(objOfClsProductDetail.IngredientFactId), "0");
                                    }
                                    else
                                    {
                                        retMsg = objCartDetail.InsertCartDetail(ClsProductDetailobj.ProductdetailId, Convert.ToInt32(Session["UserId"]), ClsProductDetailobj.SizeId, ClsProductDetailobj.PropertiesId, ClsProductDetailobj.Quantity, "0", ClsProductDetailobj.IngredientFactId, "0", null, null);
                                    }
                                    // }
                                    // retMsg = objCartDetail.InsertCartDetail(ClsProductDetailobj.ProductdetailId, Convert.ToInt32(Session["UserId"]), ClsProductDetailobj.SizeId, ClsProductDetailobj.PropertiesId, 1, "0", ClsProductDetailobj.IngredientFactId, "0", null);
                                    //retMsg = objCartDetail.InsertCartDetail(ClsProductDetailobj.ProductdetailId, 1, ClsProductDetailobj.SizeId, ClsProductDetailobj.PropertiesId, 1, "0", ClsProductDetailobj.IngredientFactId, "0", lstClsCartDetail);
                                }
                                else
                                {
                                    ClsProductDetail objOfClsProductDetail = new ClsProductDetail();
                                    objOfClsProductDetail = listOfClsProductDetail.Where(x => x.ProductdetailId == ClsProductDetailobj.ProductdetailId && x.SizeId == ClsProductDetailobj.SizeId && ClsProductDetailobj.PropertiesId == x.PropertiesId && x.IngredientFactId == ClsProductDetailobj.IngredientFactId && x.Price == 0).FirstOrDefault();

                                    if (objOfClsProductDetail.ProductdetailId != null)
                                    {
                                        retMsg = objCartDetail.UpdateCartDetail(Convert.ToInt32(objOfClsProductDetail.CartId), Convert.ToInt32(objOfClsProductDetail.ProductdetailId), 0, Convert.ToInt32(ClsProductDetailobj.SizeId), Convert.ToInt32(objOfClsProductDetail.PropertiesId), Convert.ToInt32(ClsProductDetailobj.Quantity), "0", Convert.ToInt32(objOfClsProductDetail.IngredientFactId), Session["RandomNumber"].ToString());
                                    }
                                    else
                                    {
                                        retMsg = objCartDetail.InsertCartDetail(ClsProductDetailobj.ProductdetailId, 0, ClsProductDetailobj.SizeId, ClsProductDetailobj.PropertiesId, ClsProductDetailobj.Quantity, "0", ClsProductDetailobj.IngredientFactId, Session["RandomNumber"].ToString(), null, null);
                                    }
                                    //retMsg = objCartDetail.InsertCartDetail(ClsProductDetailobj.ProductdetailId, 0, ClsProductDetailobj.SizeId, ClsProductDetailobj.PropertiesId, 1, "0", ClsProductDetailobj.IngredientFactId, Session["RandomNumber"].ToString(), null);
                                }
                                List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
                                if (Session["UserId"] != null)
                                {
                                    lstClsProductDetail = objClsCustomerOrderDetail.GetUserCartDetail(Convert.ToInt32(Session["UserId"]), "0");
                                }
                                else
                                {
                                    // lstClsProductDetail = objClsCustomerOrderDetail.GetUserCartDetail(1, "0");
                                    lstClsProductDetail = objClsCustomerOrderDetail.GetUserCartDetail(0, Session["RandomNumber"].ToString());
                                }
                                //lstClsProductDetail.Add(ClsProductDetailobj);
                                if (lstClsProductDetail.Count > 0)
                                {
                                    rptOrderDetail.DataSource = lstClsProductDetail;
                                    rptOrderDetail.DataBind();
                                }
                                lblDiscount.Text = "$0";
                                txtOfferCode.Text = "";
                            }
                            else
                            {
                                LblTotal.Text = Total.ToString();
                                lblDiscount.Text = "$" + ClsProductDetailobj.OfferAmount.ToString();
                                decimal SubTotalAfterDis = (Convert.ToDecimal(Total) - Convert.ToDecimal(lblDiscount.Text.Replace("$", "")));
                                decimal tax = (Convert.ToDecimal(lblSalesPrice.Text.ToString().Replace("%", "")) * Convert.ToDecimal(SubTotalAfterDis)) / 100;
                                lblSalesPrice.Text = "$" + tax.ToString().Replace("$", "");
                                decimal DisplaysalesTax = (Math.Floor(Convert.ToDecimal(lblSalesPrice.Text.Replace("$", "")) * 100) / 100);
                                lblSalesPrice.Text = string.Format("{0:N2}", DisplaysalesTax);

                                lblSalesPrice.Text = "$" + lblSalesPrice.Text.ToString().Replace("$", "");
                                LblTotalPrice.Text = "$" + (Convert.ToDecimal(SubTotalAfterDis) + Convert.ToDecimal(lblSalesPrice.Text.ToString().Replace("$", "")) + Convert.ToDecimal(lblDeliveryCharges.Text.Replace("$", ""))).ToString();
                                decimal DisplayTotalPrice = (Math.Floor(Convert.ToDecimal(LblTotalPrice.Text.Replace("$", "")) * 100) / 100);
                                LblTotalPrice.Text = string.Format("{0:N2}", DisplayTotalPrice);

                                LblTotalPrice.Text = "$" + LblTotalPrice.Text.Replace("$", "");

                                Session["OfferApplied"] = "Applied";
                                Session["OfferAmount"] = lblDiscount.Text;
                                txtOfferCode.Text = "";
                                //Session["OfferApplied"] = "Applied";
                                //LblTotalPrice.Text = "$" + (Convert.ToDecimal(LblTotalPrice.Text.Replace("$", "")) - ClsProductDetailobj.OfferAmount).ToString();
                                //lblDiscount.Text = "$" + ClsProductDetailobj.OfferAmount.ToString();
                                //Session["OfferAmount"] = lblDiscount.Text;
                                //txtOfferCode.Text = "";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorHandler.WriteError(ex);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    protected void btnApplyCoupn_Click(object sender, EventArgs e)
    {
        try
        {
            string retMsg = string.Empty, RandomNumber = "0", OrderType = string.Empty;
            int userId = 0;
            List<ClsProductDetail> lstProductDetail = new List<ClsProductDetail>();

            foreach (RepeaterItem items in rptOrderDetail.Items)
            {
                Label lblCartId = (Label)items.FindControl("lblCartId");
                Label lblProductdetailId = (Label)items.FindControl("lblProductdetailId");
                Label lblPropertyId = (Label)items.FindControl("lblPropertyId");
                Label lblProductIngredientFactId = (Label)items.FindControl("lblProductIngredientFactId");
                Label lblExtraIngredientId = (Label)items.FindControl("lblExtraIngredientId");
                Label lblSizeId = (Label)items.FindControl("lblSizeId");
                Label lblPrice = (Label)items.FindControl("lblPrice");
                TextBox textboxQuantity = (TextBox)items.FindControl("txtQuantity");
                Label lblSizeName = (Label)items.FindControl("lblSizeName");

                if (lblCartId != null && lblProductdetailId != null && lblPropertyId != null && lblProductIngredientFactId != null && lblExtraIngredientId != null
                    && lblSizeId != null && lblPrice != null && textboxQuantity != null)
                {
                    ClsProductDetail objClsProductDetail = new ClsProductDetail();
                    objClsProductDetail.CartId = Convert.ToInt32(lblCartId.Text);
                    objClsProductDetail.ProductdetailId = Convert.ToInt32(lblProductdetailId.Text);
                    objClsProductDetail.PropertiesId = Convert.ToInt32(lblPropertyId.Text);
                    objClsProductDetail.IngredientFactId = Convert.ToInt32(lblProductIngredientFactId.Text);
                    objClsProductDetail.ExtraIngredientId = lblExtraIngredientId.Text;
                    objClsProductDetail.SizeId = Convert.ToInt32(lblSizeId.Text);
                    objClsProductDetail.Quantity = Convert.ToInt32(textboxQuantity.Text);
                    objClsProductDetail.Price = Convert.ToDecimal(lblPrice.Text.Replace("$", ""));
                    objClsProductDetail.SizeName = lblSizeName.Text;
                    lstProductDetail.Add(objClsProductDetail);
                }
            }

            //userId = 3;
            if (Session["UserId"] != null)
            {
                userId = Convert.ToInt32(Session["UserId"]);
            }
            if (Session["RandomNumber"] != null)
            {
                RandomNumber = Session["RandomNumber"].ToString();
            }
            if (chkPickOrder.Checked == true)
            {
                OrderType = "Pick up";
            }
            else
            {
                OrderType = "Online";
            }
            ClsDailySpecialsOffer objClsDailySpecialsOffer = new ClsDailySpecialsOffer();
            if (Session["OfferApplied"] == null)
            {
                Session["OfferCode"] = txtOfferCode.Text;
                ClsProductDetail ClsProductDetailobj = new ClsProductDetail();
                ClsProductDetailobj = objClsDailySpecialsOffer.GetOfferAmountByOfferCode(txtOfferCode.Text, lstProductDetail);
                if (ClsProductDetailobj.ProductdetailId != 0)
                {
                    Session["OfferApplied"] = "Applied";
                    ClsCartDetail objCartDetail = new ClsCartDetail();
                    if (Session["UserId"] != null)
                    {
                        // List<ClsCartDetail> lstClsCartDetail = new List<ClsCartDetail>();
                        // if (ClsProductDetailobj.CombineSizeId != "0")
                        // {
                        //  int SizeId = Convert.ToInt32(ClsProductDetailobj.CombineSizeId.Split(',')[1]);
                        retMsg = objCartDetail.InsertCartDetail(ClsProductDetailobj.ProductdetailId, Convert.ToInt32(Session["UserId"]), ClsProductDetailobj.SizeId, ClsProductDetailobj.PropertiesId, ClsProductDetailobj.Quantity, "0", ClsProductDetailobj.IngredientFactId, "0", null, null);
                        // }
                        // else
                        // {
                        //retMsg = objCartDetail.InsertCartDetail(ClsProductDetailobj.ProductdetailId, Convert.ToInt32(Session["UserId"]), ClsProductDetailobj.SizeId, ClsProductDetailobj.PropertiesId, 1, "0", ClsProductDetailobj.IngredientFactId, "0", null);

                        // }
                        //retMsg = objCartDetail.InsertCartDetail(ClsProductDetailobj.ProductdetailId, 1, ClsProductDetailobj.SizeId, ClsProductDetailobj.PropertiesId, 1, "0", ClsProductDetailobj.IngredientFactId, "0", lstClsCartDetail);
                    }
                    else
                    {
                        //if (ClsProductDetailobj.CombineSizeId != "0")
                        // {
                        //int SizeId = Convert.ToInt32(ClsProductDetailobj.CombineSizeId.Split(',')[1]);
                        retMsg = objCartDetail.InsertCartDetail(ClsProductDetailobj.ProductdetailId, 0, ClsProductDetailobj.SizeId, ClsProductDetailobj.PropertiesId, ClsProductDetailobj.Quantity, "0", ClsProductDetailobj.IngredientFactId, Session["RandomNumber"].ToString(), null, null);
                        // }
                        //  else
                        //  {
                        //retMsg = objCartDetail.InsertCartDetail(ClsProductDetailobj.ProductdetailId, 0, ClsProductDetailobj.SizeId, ClsProductDetailobj.PropertiesId, 1, "0", ClsProductDetailobj.IngredientFactId, Session["RandomNumber"].ToString(), null);

                        // }
                        // retMsg = objCartDetail.InsertCartDetail(ClsProductDetailobj.ProductdetailId, 0, ClsProductDetailobj.SizeId, ClsProductDetailobj.PropertiesId, 1, "0", ClsProductDetailobj.IngredientFactId, Session["RandomNumber"].ToString(), null);
                    }
                    List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
                    if (Session["UserId"] != null)
                    {
                        lstClsProductDetail = objClsCustomerOrderDetail.GetUserCartDetail(Convert.ToInt32(Session["UserId"]), "0");
                    }
                    else
                    {
                        // lstClsProductDetail = objClsCustomerOrderDetail.GetUserCartDetail(1, "0");
                        lstClsProductDetail = objClsCustomerOrderDetail.GetUserCartDetail(0, Session["RandomNumber"].ToString());
                    }
                    //lstClsProductDetail.Add(ClsProductDetailobj);
                    if (lstClsProductDetail.Count > 0)
                    {
                        rptOrderDetail.DataSource = lstClsProductDetail;
                        rptOrderDetail.DataBind();
                    }
                    lblDiscount.Text = "$0";
                    txtOfferCode.Text = "";
                }
                else
                {
                    foreach (RepeaterItem items in rptOrderDetail.Items)
                    {
                        Label lblPrice = (Label)items.FindControl("lblPrice");
                        if (lblPrice != null)
                        {
                            Total = Total + Convert.ToDecimal(lblPrice.Text.ToString().Replace("$", ""));
                        }
                    }

                    LblTotal.Text = Total.ToString();
                    lblDiscount.Text = "$" + ClsProductDetailobj.OfferAmount.ToString();
                    decimal SubTotalAfterDis = (Convert.ToDecimal(Total) - Convert.ToDecimal(lblDiscount.Text.Replace("$", "")));
                    decimal tax = (Convert.ToDecimal(lblSalesPrice.Text.ToString().Replace("%", "")) * Convert.ToDecimal(SubTotalAfterDis)) / 100;
                    lblSalesPrice.Text = "$" + tax.ToString().Replace("$", "");
                    decimal DisplaysalesTax = (Math.Floor(Convert.ToDecimal(lblSalesPrice.Text.Replace("$", "")) * 100) / 100);
                    lblSalesPrice.Text = string.Format("{0:N2}", DisplaysalesTax);

                    lblSalesPrice.Text = "$" + lblSalesPrice.Text.ToString().Replace("$", "");

                    LblTotalPrice.Text = "$" + (Convert.ToDecimal(SubTotalAfterDis) + Convert.ToDecimal(lblSalesPrice.Text.ToString().Replace("$", "")) + Convert.ToDecimal(lblDeliveryCharges.Text.Replace("$", ""))).ToString();
                    decimal DisplayTotalPrice = (Math.Floor(Convert.ToDecimal(LblTotalPrice.Text.Replace("$", "")) * 100) / 100);
                    LblTotalPrice.Text = string.Format("{0:N2}", DisplayTotalPrice);
                    LblTotalPrice.Text = "$" + LblTotalPrice.Text.Replace("$", "");

                    Session["OfferApplied"] = "Applied";
                    Session["OfferAmount"] = lblDiscount.Text;
                    txtOfferCode.Text = "";
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    public string GetOnlinePaymentConfigSetting()
    {
        string OnlinePayment = "";
        try
        {
            tp_config objConfig = new tp_config();
            objConfig = objClsMiscellaneousSettings.GetOnlinePaymentConfigSetting();
            if (objConfig != null)
            {
                OnlinePayment = objConfig.tpc_value;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return OnlinePayment;
    }

    protected void btnPlaceOrder_Click(object sender, EventArgs e)
    {
        try
        {
            bool flag = false;

            txtaddress.BorderColor = System.Drawing.Color.White;
            txtCity.BorderColor = System.Drawing.Color.White;
            DdlState.BorderColor = System.Drawing.Color.White;
            txtzip.BorderColor = System.Drawing.Color.White;
            datepicker.BorderColor = System.Drawing.Color.White;
            ddlHour.BorderColor = System.Drawing.Color.White;
            DdlMinute.BorderColor = System.Drawing.Color.White;

            Session["Address"] = txtaddress.Text;
            Session["City"] = txtCity.Text;
            Session["Name"] = txtName.Text;
            Session["Zip"] = txtzip.Text;

            DateTime currentTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, TimeZoneInfo.Local.Id, "Central Standard Time");
            DateTime selectedDate = Convert.ToDateTime(datepicker.Text);

            if (chkPickOrder.Checked == false)
            {
                if (txtaddress.Text == "Address" || txtCity.Text == "City" || DdlState.SelectedValue.ToString() == "-1" || txtzip.Text == "Zip" || datepicker.Text == "Order Wish Date" ||
                    ddlHour.Text == "Select Hour" || DdlMinute.Text == "Select Minute" || txtaddress.Text == "" || txtCity.Text == "" || txtzip.Text == "")
                {
                    flag = true;
                    if (txtaddress.Text == "Address" || txtaddress.Text == "")
                    {
                        txtaddress.BorderColor = System.Drawing.Color.Red;
                    }
                    if (txtCity.Text == "City" || txtCity.Text == "")
                    {
                        txtCity.BorderColor = System.Drawing.Color.Red;
                    }
                    if (DdlState.SelectedValue.ToString() == "-1")
                    {
                        DdlState.BorderColor = System.Drawing.Color.Red;
                    }
                    if (txtzip.Text == "Zip" || txtzip.Text == "")
                    {
                        txtzip.BorderColor = System.Drawing.Color.Red;
                    }
                    if (datepicker.Text == "Order Wish Date" || datepicker.Text == "")
                    {
                        datepicker.BorderColor = System.Drawing.Color.Red;
                    }
                    if (ddlHour.Text == "Select Hour")
                    {
                        ddlHour.BorderColor = System.Drawing.Color.Red;
                    }
                    if (DdlMinute.Text == "Select Minute")
                    {
                        DdlMinute.BorderColor = System.Drawing.Color.Red;
                    }

                }
            }
            else
            {
                if (datepicker.Text == "Order Wish Date" || datepicker.Text == "")
                {
                    flag = true;
                    datepicker.BorderColor = System.Drawing.Color.Red;
                }
                if (ddlHour.Text == "Select Hour")
                {
                    flag = true;
                    ddlHour.BorderColor = System.Drawing.Color.Red;
                }
                if (DdlMinute.Text == "Select Minute")
                {
                    flag = true;
                    DdlMinute.BorderColor = System.Drawing.Color.Red;
                }
            }
            if (flag == false)
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "PlaceOrderConfirmation();", true);

                //string confirmValue = hdnfldVariablePlaceOrder.Value;
                //if (confirmValue == "Yes")
                //{
                string retMsg = string.Empty, RandomNumber = "0", OrderType = string.Empty;
                int userId = 0;
                List<ClsProductDetail> lstProductDetail = new List<ClsProductDetail>();
                if (txtDeliveryInstructions.Text == "Delivery Instructions")
                {
                    txtDeliveryInstructions.Text = "";
                }
                foreach (RepeaterItem items in rptOrderDetail.Items)
                {
                    Label lblCartId = (Label)items.FindControl("lblCartId");
                    Label lblProductdetailId = (Label)items.FindControl("lblProductdetailId");
                    Label lblPropertyId = (Label)items.FindControl("lblPropertyId");
                    Label lblProductIngredientFactId = (Label)items.FindControl("lblProductIngredientFactId");
                    Label lblExtraIngredientId = (Label)items.FindControl("lblExtraIngredientId");
                    Label lblExtraIngredientName = (Label)items.FindControl("lblExtraIngredientName");
                    Label lblSizeId = (Label)items.FindControl("lblSizeId");
                    Label lblPrice = (Label)items.FindControl("lblPrice");
                    Label lblProductName = (Label)items.FindControl("lblProductName");
                    TextBox textboxQuantity = (TextBox)items.FindControl("txtQuantity");
                    Label lblComment = (Label)items.FindControl("lblComment");
                    Label lblSizeName = (Label)items.FindControl("lblSizeName");
                    if (lblCartId != null && lblProductdetailId != null && lblPropertyId != null && lblProductIngredientFactId != null && lblExtraIngredientId != null
                        && lblSizeId != null && lblPrice != null && textboxQuantity != null && lblComment != null && lblSizeName != null)
                    {
                        ClsProductDetail objClsProductDetail = new ClsProductDetail();
                        objClsProductDetail.CartId = Convert.ToInt32(lblCartId.Text);
                        objClsProductDetail.ProductdetailId = Convert.ToInt32(lblProductdetailId.Text);
                        objClsProductDetail.PropertiesId = Convert.ToInt32(lblPropertyId.Text);
                        objClsProductDetail.IngredientFactId = Convert.ToInt32(lblProductIngredientFactId.Text);
                        objClsProductDetail.ExtraIngredientId = lblExtraIngredientId.Text;
                        objClsProductDetail.SizeId = Convert.ToInt32(lblSizeId.Text);
                        objClsProductDetail.Quantity = Convert.ToInt32(textboxQuantity.Text);
                        objClsProductDetail.Price = Convert.ToDecimal(lblPrice.Text.Replace("$", ""));
                        objClsProductDetail.ProductName = lblProductName.Text;
                        objClsProductDetail.ExtraIngredient = lblExtraIngredientName.Text;
                        objClsProductDetail.SizeName = lblSizeName.Text;
                        objClsProductDetail.Comment = lblComment.Text.ToString().Replace("Comment:", "");
                        lstProductDetail.Add(objClsProductDetail);
                    }
                }
                //userId = 3;
                if (Session["UserId"] != null)
                {
                    userId = Convert.ToInt32(Session["UserId"]);
                }
                if (Session["RandomNumber"] != null)
                {
                    RandomNumber = Session["RandomNumber"].ToString();
                }
                if (chkPickOrder.Checked == true)
                {
                    Session["PickupOrder"] = true;
                    OrderType = "Pick up";
                }
                else
                {
                    OrderType = "Online";
                }

                //if (Convert.ToDecimal(LblTotal.Text.Replace("$", "")) >= Convert.ToDecimal(objtp_config.tpc_value.Replace("$", "")))
                //{

                if (chkPickOrder.Checked == true)
                {
                    Session["PickupOrder"] = true;
                    if (datepicker.Text == "Order Wish Date" || datepicker.Text == "" || ddlHour.Text == "Select Hour" || DdlMinute.Text == "Select Minute")
                    {
                        if (datepicker.Text == "Order Wish Date" || datepicker.Text == "")
                        {
                            datepicker.BorderColor = System.Drawing.Color.Red;
                        }
                        if (ddlHour.Text == "Select Hour")
                        {
                            ddlHour.BorderColor = System.Drawing.Color.Red;
                        }
                        if (DdlMinute.Text == "Select Minute")
                        {
                            DdlMinute.BorderColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {

                        int day = (int)DateTime.Now.DayOfWeek;
                        //  DateTime date = DateTime.Now;
                        DateTime date = Convert.ToDateTime(Convert.ToDateTime(datepicker.Text).ToShortDateString() + " " + ddlHour.Text + ":" + DdlMinute.Text + ":00" + " " + DdlTime.Text);

                        ClsStoreDetail objClsStoreDetail = new ClsStoreDetail();
                        ClsStoreDetail ClsStoreDetail = new ClsStoreDetail();
                        objClsStoreDetail = ClsStoreDetail.GetStoreTimeByDayId(day);

                        DateTime startDate = Convert.ToDateTime(objClsStoreDetail.StoreWorkingStartTime);
                        DateTime EndDate = Convert.ToDateTime(objClsStoreDetail.StoreWorkingEndTime);
                        if (startDate.TimeOfDay <= EndDate.TimeOfDay)
                        {
                            if (date.TimeOfDay >= startDate.TimeOfDay && date.TimeOfDay <= EndDate.TimeOfDay)
                            {
                                if (currentTime.Date == date.Date && date.TimeOfDay < currentTime.TimeOfDay)
                                {
                                    StoreInvalidTime.Style.Add("display", "block");
                                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
                                }
                                else
                                {
                                    retMsg = objClsCustomerOrderDetail.PlaceOrder(txtName.Text, "", txtemail.Text, "", 0, "", txtTelephone.Text, txtDeliveryInstructions.Text, lstProductDetail, 1, LblTotalPrice.Text.Replace("$", ""), Convert.ToInt32(Session["UserId"]), Convert.ToDateTime(date), OrderType, RandomNumber, lblSalesPrice.Text, lblDeliveryCharges.Text);

                                    //retMsg = objClsCustomerOrderDetail.PlaceOrder(txtName.Text, txtaddress.Text, txtemail.Text, txtCity.Text, Convert.ToInt32(DdlState.SelectedValue), txtzip.Text, txtTelephone.Text, txtDeliveryInstructions.Text, lstProductDetail, 1, LblTotalPrice.Text.Replace("$", ""), Convert.ToInt32(Session["UserId"]), Convert.ToDateTime("1/1/1900 12:00:00 AM"), OrderType, RandomNumber);
                                    string[] splitstr = retMsg.Split(':');
                                    string orderID = splitstr[1].ToString();
                                    if (splitstr[0] == "SUCCESS")
                                    {
                                        string PaymentType = GetOnlinePaymentConfigSetting();
                                        if (PaymentType.Contains("true") || PaymentType.Contains("True"))
                                        {
                                            Session["CartIdList"] = lstProductDetail.ToList();
                                            string url = "PaymentDetail.aspx?";
                                            string Amount = LblTotalPrice.Text.Replace("$", "");
                                            string QueryString = string.Empty;

                                            decimal DisplayTotalPrice1 = (Math.Floor(Convert.ToDecimal(Amount.Replace("$", "")) * 100) / 100);
                                            string Totalamount = string.Format("{0:N2}", DisplayTotalPrice1);


                                            string totalAmount = HttpUtility.UrlEncode(EncryptString(Totalamount));
                                            string orderId = HttpUtility.UrlEncode(EncryptString(orderID));
                                            string SubTotal = HttpUtility.UrlEncode(EncryptString(LblTotal.Text));
                                            string discount = HttpUtility.UrlEncode(EncryptString(lblDiscount.Text));
                                            string PlaceOrderOrderType = HttpUtility.UrlEncode(EncryptString(OrderType));
                                            QueryString = string.Format("TotalAmount={0}&OrderId={1}&SubTotal={2}&discount={3}&OrderType={4}", totalAmount, orderId, SubTotal, discount, PlaceOrderOrderType);
                                            url += QueryString;
                                            Response.Redirect(url, false);
                                        }
                                        else
                                        {
                                            Session["TransactionCount"] = "1";
                                            Session["CartIdList"] = lstProductDetail.ToList();
                                            Session["OfferApplied"] = null;
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
                                                objClsCustomerOrderDetail.UpdateOrdertyepByOrderId(Convert.ToInt32(orderID), "Pick up Order With Cash On Delivery");
                                                retMsg = objClsCustomerOrderDetail.UpdateTransactionHistory(Convert.ToInt32(orderID), 3, null);
                                                string orderNumber = objClsCustomerOrderDetail.GetOrderNumberByOrderId(Convert.ToInt32(orderID));
                                                string url = "TransactionDetail.aspx?";

                                                string QueryString = string.Empty;
                                                string TransactionId = HttpUtility.UrlEncode(EncryptString(""));
                                                string Message = HttpUtility.UrlEncode(EncryptString("SUCCESS"));
                                                string Amounttotal = LblTotalPrice.Text.Replace("$", "");

                                                decimal DisplayTotalPrice1 = (Math.Floor(Convert.ToDecimal(Amounttotal.Replace("$", "")) * 100) / 100);
                                                string Totalamount = string.Format("{0:N2}", DisplayTotalPrice1);


                                                string Amount = HttpUtility.UrlEncode(EncryptString(Totalamount));

                                                string OrderNumber = HttpUtility.UrlEncode(EncryptString(orderNumber));
                                                string Orderid = HttpUtility.UrlEncode(EncryptString(orderID.ToString()));
                                                string SubTotal = HttpUtility.UrlEncode(EncryptString(LblTotal.Text));
                                                string Discount = HttpUtility.UrlEncode(EncryptString(lblDiscount.Text.ToString()));
                                                string CardNumber = "";

                                                QueryString = string.Format("TotalAmount={0}&Message={1}&TransactionId={2}&OrderNumber={3}&OrderId={4}&SubTotal={5}&Discount={6}&CardNumber={7}&PaymentType={8}", Amount, Message, TransactionId, OrderNumber, Orderid, SubTotal, Discount, CardNumber, PaymentType);
                                                url += QueryString;
                                                Response.Redirect(url, false);
                                            }
                                            //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Detail Added Successfully", true);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                StoreStartTime = startDate.ToShortTimeString();
                                StoreEndTime = EndDate.ToShortTimeString();
                                StoreClosedDiv.Style.Add("display", "block");
                                ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
                            }

                        }
                        else if (startDate.TimeOfDay >= EndDate.TimeOfDay)
                        {
                            if (date.TimeOfDay >= startDate.TimeOfDay || date.TimeOfDay <= EndDate.TimeOfDay)
                            {
                                if (currentTime.Date == date.Date && date.TimeOfDay < currentTime.TimeOfDay)
                                {
                                    StoreInvalidTime.Style.Add("display", "block");
                                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
                                }
                                else
                                {
                                    retMsg = objClsCustomerOrderDetail.PlaceOrder(txtName.Text, "", txtemail.Text, "", 0, "", txtTelephone.Text, txtDeliveryInstructions.Text, lstProductDetail, 1, LblTotalPrice.Text.Replace("$", ""), Convert.ToInt32(Session["UserId"]), Convert.ToDateTime(date), OrderType, RandomNumber, lblSalesPrice.Text, lblDeliveryCharges.Text);

                                    //retMsg = objClsCustomerOrderDetail.PlaceOrder(txtName.Text, txtaddress.Text, txtemail.Text, txtCity.Text, Convert.ToInt32(DdlState.SelectedValue), txtzip.Text, txtTelephone.Text, txtDeliveryInstructions.Text, lstProductDetail, 1, LblTotalPrice.Text.Replace("$", ""), Convert.ToInt32(Session["UserId"]), Convert.ToDateTime("1/1/1900 12:00:00 AM"), OrderType, RandomNumber);
                                    string[] splitstr = retMsg.Split(':');
                                    string orderID = splitstr[1].ToString();
                                    if (splitstr[0] == "SUCCESS")
                                    {
                                        string PaymentType = GetOnlinePaymentConfigSetting();
                                        if (PaymentType.Contains("true") || PaymentType.Contains("True"))
                                        {
                                            Session["CartIdList"] = lstProductDetail.ToList();
                                            string url = "PaymentDetail.aspx?";
                                            string Amount = LblTotalPrice.Text.Replace("$", "");
                                            string QueryString = string.Empty;
                                            // string Totalamount = (Math.Floor(Convert.ToDecimal(Amount.Replace("$", "")) * 100) / 100).ToString().Replace("$", "");

                                            decimal DisplayTotalPrice1 = (Math.Floor(Convert.ToDecimal(Amount.Replace("$", "")) * 100) / 100);
                                            string Totalamount = string.Format("{0:N2}", DisplayTotalPrice1);


                                            string totalAmount = HttpUtility.UrlEncode(EncryptString(Totalamount));
                                            string orderId = HttpUtility.UrlEncode(EncryptString(orderID));
                                            string SubTotal = HttpUtility.UrlEncode(EncryptString(LblTotal.Text));
                                            string discount = HttpUtility.UrlEncode(EncryptString(lblDiscount.Text));
                                            string PlaceOrderOrderType = HttpUtility.UrlEncode(EncryptString(OrderType));
                                            QueryString = string.Format("TotalAmount={0}&OrderId={1}&SubTotal={2}&discount={3}&OrderType={4}", totalAmount, orderId, SubTotal, discount, PlaceOrderOrderType);
                                            url += QueryString;
                                            Response.Redirect(url, false);
                                        }
                                        else
                                        {
                                            Session["TransactionCount"] = "1";
                                            Session["CartIdList"] = lstProductDetail.ToList();
                                            Session["OfferApplied"] = null;
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
                                                objClsCustomerOrderDetail.UpdateOrdertyepByOrderId(Convert.ToInt32(orderID), "Pick up Order With Cash On Delivery");

                                                retMsg = objClsCustomerOrderDetail.UpdateTransactionHistory(Convert.ToInt32(orderID), 3, null);
                                                string orderNumber = objClsCustomerOrderDetail.GetOrderNumberByOrderId(Convert.ToInt32(orderID));
                                                string url = "TransactionDetail.aspx?";

                                                string QueryString = string.Empty;
                                                string TransactionId = HttpUtility.UrlEncode(EncryptString(""));
                                                string Message = HttpUtility.UrlEncode(EncryptString("SUCCESS"));
                                                string Amounttotal = LblTotalPrice.Text.Replace("$", "");
                                                // string Totalamount = (Math.Floor(Convert.ToDecimal(Amounttotal.Replace("$", "")) * 100) / 100).ToString().Replace("$", "");

                                                decimal DisplayTotalPrice1 = (Math.Floor(Convert.ToDecimal(Amounttotal.Replace("$", "")) * 100) / 100);
                                                string Totalamount = string.Format("{0:N2}", DisplayTotalPrice1);

                                                string Amount = HttpUtility.UrlEncode(EncryptString(Totalamount));

                                                string OrderNumber = HttpUtility.UrlEncode(EncryptString(orderNumber));
                                                string Orderid = HttpUtility.UrlEncode(EncryptString(orderID.ToString()));
                                                string SubTotal = HttpUtility.UrlEncode(EncryptString(LblTotal.Text));
                                                string Discount = HttpUtility.UrlEncode(EncryptString(lblDiscount.Text.ToString()));
                                                string CardNumber = "";

                                                QueryString = string.Format("TotalAmount={0}&Message={1}&TransactionId={2}&OrderNumber={3}&OrderId={4}&SubTotal={5}&Discount={6}&CardNumber={7}&PaymentType={8}", Amount, Message, TransactionId, OrderNumber, Orderid, SubTotal, Discount, CardNumber, PaymentType);
                                                url += QueryString;
                                                Response.Redirect(url, false);
                                            }
                                            //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Detail Added Successfully", true);
                                        }
                                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Detail Added Successfully", true);
                                    }
                                }
                            }
                            else
                            {
                                StoreStartTime = startDate.ToShortTimeString();
                                StoreEndTime = EndDate.ToShortTimeString();
                                StoreClosedDiv.Style.Add("display", "block");
                                ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
                            }
                        }
                    }
                }
                else
                {
                    if (Convert.ToDecimal(LblTotal.Text.Replace("$", "")) >= Convert.ToDecimal(objtp_config.tpc_value.Replace("$", "")))
                    {
                        //Session["PickupOrder"] = true;
                        Session["PickupOrder"] = null;
                        int day = (int)DateTime.Now.DayOfWeek;
                        DateTime date = Convert.ToDateTime(Convert.ToDateTime(datepicker.Text).ToShortDateString() + " " + ddlHour.Text + ":" + DdlMinute.Text + ":00" + " " + DdlTime.Text);

                        ClsStoreDetail objClsStoreDetail = new ClsStoreDetail();
                        ClsStoreDetail ClsStoreDetail = new ClsStoreDetail();
                        objClsStoreDetail = ClsStoreDetail.GetStoreTimeByDayId(day);

                        DateTime startDate = Convert.ToDateTime(objClsStoreDetail.StoreWorkingStartTime);
                        DateTime EndDate = Convert.ToDateTime(objClsStoreDetail.StoreWorkingEndTime);
                        if (startDate.TimeOfDay <= EndDate.TimeOfDay)
                        {
                            if (date.TimeOfDay >= startDate.TimeOfDay && date.TimeOfDay <= EndDate.TimeOfDay)
                            {
                                if (currentTime.Date == date.Date && date.TimeOfDay < currentTime.TimeOfDay)
                                {
                                    StoreInvalidTime.Style.Add("display", "block");
                                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
                                }
                                else
                                {


                                    retMsg = objClsCustomerOrderDetail.PlaceOrder(txtName.Text, txtaddress.Text, txtemail.Text, txtCity.Text, Convert.ToInt32(DdlState.SelectedValue), txtzip.Text, txtTelephone.Text, txtDeliveryInstructions.Text, lstProductDetail, 1, LblTotalPrice.Text.Replace("$", ""), Convert.ToInt32(Session["UserId"]), Convert.ToDateTime(date), OrderType, RandomNumber, lblSalesPrice.Text, lblDeliveryCharges.Text);
                                    // retMsg = objClsCustomerOrderDetail.PlaceOrder(txtName.Text, txtaddress.Text, txtemail.Text, txtCity.Text, Convert.ToInt32(DdlState.SelectedValue), txtzip.Text, txtTelephone.Text, txtDeliveryInstructions.Text, lstProductDetail, 1, LblTotalPrice.Text.Replace("$", ""), 1, Convert.ToDateTime(date), OrderType, RandomNumber);
                                    string[] splitstr = retMsg.Split(':');
                                    string orderID = splitstr[1].ToString();
                                    if (splitstr[0] == "SUCCESS")
                                    {
                                        string PaymentType = GetOnlinePaymentConfigSetting();
                                        if (PaymentType.Contains("true") || PaymentType.Contains("True"))
                                        {
                                            Session["CartIdList"] = lstProductDetail.ToList();
                                            string url = "PaymentDetail.aspx?";
                                            string Amount = LblTotalPrice.Text.Replace("$", "");
                                            string QueryString = string.Empty;
                                            // string Totalamount = (Math.Floor(Convert.ToDecimal(Amount.Replace("$", "")) * 100) / 100).ToString().Replace("$", "");
                                            decimal DisplayTotalPrice1 = (Math.Floor(Convert.ToDecimal(Amount.Replace("$", "")) * 100) / 100);
                                            string Totalamount = string.Format("{0:N2}", DisplayTotalPrice1);


                                            string totalAmount = HttpUtility.UrlEncode(EncryptString(Totalamount));
                                            string orderId = HttpUtility.UrlEncode(EncryptString(orderID));
                                            string SubTotal = HttpUtility.UrlEncode(EncryptString(LblTotal.Text));
                                            string discount = HttpUtility.UrlEncode(EncryptString(lblDiscount.Text));
                                            string PlaceOrderOrderType = HttpUtility.UrlEncode(EncryptString(OrderType));
                                            QueryString = string.Format("TotalAmount={0}&OrderId={1}&SubTotal={2}&discount={3}&OrderType={4}", totalAmount, orderId, SubTotal, discount, PlaceOrderOrderType);
                                            url += QueryString;
                                            Response.Redirect(url, false);
                                        }
                                        else
                                        {
                                            Session["TransactionCount"] = "1";
                                            Session["CartIdList"] = lstProductDetail.ToList();
                                            Session["OfferApplied"] = null;
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
                                                objClsCustomerOrderDetail.UpdateOrdertyepByOrderId(Convert.ToInt32(orderID), "Online Order With Cash On Delivery");
                                                retMsg = objClsCustomerOrderDetail.UpdateTransactionHistory(Convert.ToInt32(orderID), 3, null);
                                                string orderNumber = objClsCustomerOrderDetail.GetOrderNumberByOrderId(Convert.ToInt32(orderID));
                                                string url = "TransactionDetail.aspx?";

                                                string QueryString = string.Empty;
                                                string TransactionId = HttpUtility.UrlEncode(EncryptString(""));
                                                string Message = HttpUtility.UrlEncode(EncryptString("SUCCESS"));
                                                string Amounttotal = LblTotalPrice.Text.Replace("$", "");
                                                // string Totalamount = (Math.Floor(Convert.ToDecimal(Amounttotal.Replace("$", "")) * 100) / 100).ToString().Replace("$", "");

                                                decimal DisplayTotalPrice1 = (Math.Floor(Convert.ToDecimal(Amounttotal.Replace("$", "")) * 100) / 100);
                                                string Totalamount = string.Format("{0:N2}", DisplayTotalPrice1);

                                                string Amount = HttpUtility.UrlEncode(EncryptString(Totalamount));

                                                string OrderNumber = HttpUtility.UrlEncode(EncryptString(orderNumber));
                                                string Orderid = HttpUtility.UrlEncode(EncryptString(orderID.ToString()));
                                                string SubTotal = HttpUtility.UrlEncode(EncryptString(LblTotal.Text));
                                                string Discount = HttpUtility.UrlEncode(EncryptString(lblDiscount.Text.ToString()));
                                                string CardNumber = "";

                                                QueryString = string.Format("TotalAmount={0}&Message={1}&TransactionId={2}&OrderNumber={3}&OrderId={4}&SubTotal={5}&Discount={6}&CardNumber={7}&PaymentType={8}", Amount, Message, TransactionId, OrderNumber, Orderid, SubTotal, Discount, CardNumber, PaymentType);
                                                url += QueryString;
                                                Response.Redirect(url, false);
                                            }
                                            //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Detail Added Successfully", true);
                                        }
                                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Detail Added Successfully", true);
                                    }
                                }
                            }
                            else
                            {
                                StoreStartTime = startDate.ToShortTimeString();
                                StoreEndTime = EndDate.ToShortTimeString();
                                StoreClosedDiv.Style.Add("display", "block");
                                ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
                            }

                        }
                        else if (startDate.TimeOfDay >= EndDate.TimeOfDay)
                        {
                            if (date.TimeOfDay >= startDate.TimeOfDay || date.TimeOfDay <= EndDate.TimeOfDay)
                            {
                                if (currentTime.Date == date.Date && date.TimeOfDay < currentTime.TimeOfDay)
                                {
                                    StoreInvalidTime.Style.Add("display", "block");
                                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
                                }
                                else
                                {
                                    retMsg = objClsCustomerOrderDetail.PlaceOrder(txtName.Text, txtaddress.Text, txtemail.Text, txtCity.Text, Convert.ToInt32(DdlState.SelectedValue), txtzip.Text, txtTelephone.Text, txtDeliveryInstructions.Text, lstProductDetail, 1, LblTotalPrice.Text.Replace("$", ""), Convert.ToInt32(Session["UserId"]), Convert.ToDateTime(date), OrderType, RandomNumber, lblSalesPrice.Text, lblDeliveryCharges.Text);
                                    // retMsg = objClsCustomerOrderDetail.PlaceOrder(txtName.Text, txtaddress.Text, txtemail.Text, txtCity.Text, Convert.ToInt32(DdlState.SelectedValue), txtzip.Text, txtTelephone.Text, txtDeliveryInstructions.Text, lstProductDetail, 1, LblTotalPrice.Text.Replace("$", ""), 1, Convert.ToDateTime(date), OrderType, RandomNumber);
                                    string[] splitstr = retMsg.Split(':');
                                    string orderID = splitstr[1].ToString();
                                    if (splitstr[0] == "SUCCESS")
                                    {
                                        string PaymentType = GetOnlinePaymentConfigSetting();
                                        if (PaymentType.Contains("true") || PaymentType.Contains("True"))
                                        {
                                            Session["CartIdList"] = lstProductDetail.ToList();
                                            string url = "PaymentDetail.aspx?";
                                            string Amount = LblTotalPrice.Text.Replace("$", "");
                                            string QueryString = string.Empty;
                                            //  string Totalamount = (Math.Floor(Convert.ToDecimal(Amount.Replace("$", "")) * 100) / 100).ToString().Replace("$", "");

                                            decimal DisplayTotalPrice1 = (Math.Floor(Convert.ToDecimal(Amount.Replace("$", "")) * 100) / 100);
                                            string Totalamount = string.Format("{0:N2}", DisplayTotalPrice1);

                                            string totalAmount = HttpUtility.UrlEncode(EncryptString(Totalamount));
                                            string orderId = HttpUtility.UrlEncode(EncryptString(orderID));
                                            string SubTotal = HttpUtility.UrlEncode(EncryptString(LblTotal.Text));
                                            string discount = HttpUtility.UrlEncode(EncryptString(lblDiscount.Text));
                                            string PlaceOrderOrderType = HttpUtility.UrlEncode(EncryptString(OrderType));
                                            QueryString = string.Format("TotalAmount={0}&OrderId={1}&SubTotal={2}&discount={3}&OrderType={4}", totalAmount, orderId, SubTotal, discount, PlaceOrderOrderType);
                                            url += QueryString;
                                            Response.Redirect(url, false);
                                        }
                                        else
                                        {
                                            Session["TransactionCount"] = "1";
                                            Session["CartIdList"] = lstProductDetail.ToList();
                                            Session["OfferApplied"] = null;
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
                                                objClsCustomerOrderDetail.UpdateOrdertyepByOrderId(Convert.ToInt32(orderID), "Online Order With Cash On Delivery");

                                                retMsg = objClsCustomerOrderDetail.UpdateTransactionHistory(Convert.ToInt32(orderID), 3, null);
                                                string orderNumber = objClsCustomerOrderDetail.GetOrderNumberByOrderId(Convert.ToInt32(orderID));
                                                string url = "TransactionDetail.aspx?";

                                                string QueryString = string.Empty;
                                                string TransactionId = HttpUtility.UrlEncode(EncryptString(""));
                                                string Message = HttpUtility.UrlEncode(EncryptString("SUCCESS"));
                                                string Amounttotal = LblTotalPrice.Text.Replace("$", "");
                                                // string Totalamount = (Math.Floor(Convert.ToDecimal(Amounttotal.Replace("$", "")) * 100) / 100).ToString().Replace("$", "");
                                                decimal DisplayTotalPrice1 = (Math.Floor(Convert.ToDecimal(Amounttotal.Replace("$", "")) * 100) / 100);
                                                string Totalamount = string.Format("{0:N2}", DisplayTotalPrice1);


                                                string Amount = HttpUtility.UrlEncode(EncryptString(Totalamount));

                                                string OrderNumber = HttpUtility.UrlEncode(EncryptString(orderNumber));
                                                string Orderid = HttpUtility.UrlEncode(EncryptString(orderID.ToString()));
                                                string SubTotal = HttpUtility.UrlEncode(EncryptString(LblTotal.Text));
                                                string Discount = HttpUtility.UrlEncode(EncryptString(lblDiscount.Text.ToString()));
                                                string CardNumber = "";

                                                QueryString = string.Format("TotalAmount={0}&Message={1}&TransactionId={2}&OrderNumber={3}&OrderId={4}&SubTotal={5}&Discount={6}&CardNumber={7}&PaymentType={8}", Amount, Message, TransactionId, OrderNumber, Orderid, SubTotal, Discount, CardNumber, PaymentType);
                                                url += QueryString;
                                                Response.Redirect(url, false);
                                            }
                                            //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Detail Added Successfully", true);
                                        }
                                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Detail Added Successfully", true);
                                    }
                                }
                            }

                            else
                            {
                                StoreStartTime = startDate.ToShortTimeString();
                                StoreEndTime = EndDate.ToShortTimeString();
                                StoreClosedDiv.Style.Add("display", "block");
                                ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
                            }
                        }
                    }
                    else
                    {
                        UserAlreadyExistsDiv.Style.Add("display", "block");
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
                    }
                }

            }
            // }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    protected void rptOrderDetail_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string retMsg = string.Empty;

        try
        {
            if (e.CommandName == "DeleteItem")
            {
                int CartId = Convert.ToInt32(e.CommandArgument);
                string confirmValue = hdnfldVariable.Value;
                if (confirmValue == "Yes")
                {
                    ClsCartDetail objClsCartDetail = new ClsCartDetail();
                    retMsg = objClsCartDetail.DeleteItemFromCart(CartId);

                    if (retMsg == "SUCCESS")
                    {
                        GetUserCartDetail();
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('SuccessFully Deleted')", true);
                        Total = 0;

                        foreach (RepeaterItem items in rptOrderDetail.Items)
                        {
                            Label lblPrice = (Label)items.FindControl("lblPrice");
                            if (lblPrice != null)
                            {
                                Total = Total + Convert.ToDecimal(lblPrice.Text.ToString().Replace("$", ""));
                            }
                        }
                        if (Session["isChecked"] != null)
                        {
                            if (Session["isChecked"].ToString() == "true")
                            {
                                lblDeliveryCharges.Text = "$0";
                            }
                            else
                            {
                                lblDeliveryCharges.Text = objClsMiscellaneousSettings.GetDeliveryChargeConfigSetting().tpc_value;
                            }
                        }
                        lblSalesPrice.Text = objClsMiscellaneousSettings.GetTaxConfigSetting().tpc_value;
                        LblTotal.Text = Total.ToString();
                        decimal tax = (Convert.ToDecimal(lblSalesPrice.Text.ToString().Replace("%", "")) * Convert.ToDecimal(Total)) / 100;
                        lblSalesPrice.Text = "$" + tax.ToString().Replace("$", "");
                        decimal DisplaysalesTax = (Math.Floor(Convert.ToDecimal(lblSalesPrice.Text.Replace("$", "")) * 100) / 100);
                        lblSalesPrice.Text = string.Format("{0:N2}", DisplaysalesTax);

                        lblSalesPrice.Text = "$" + lblSalesPrice.Text.ToString().Replace("$", "");
                        LblTotalPrice.Text = "$" + (Total + Convert.ToDecimal(lblSalesPrice.Text.ToString().Replace("$", "")) + Convert.ToDecimal(lblDeliveryCharges.Text.Replace("$", ""))).ToString();
                        decimal DisplayTotalPrice = (Math.Floor(Convert.ToDecimal(LblTotalPrice.Text.Replace("$", "")) * 100) / 100);
                        LblTotalPrice.Text = string.Format("{0:N2}", DisplayTotalPrice);

                        LblTotalPrice.Text = "$" + LblTotalPrice.Text.Replace("$", "");
                        LblTotal.Text = "$" + (LblTotal.Text);
                        if (Session["OfferAmount"] != null)
                        {
                            lblDiscount.Text = Session["OfferAmount"].ToString();
                        }

                        if (Session["OfferApplied"] != null)
                        {
                            if (Session["OfferCode"] != null)
                            {
                                txtOfferCode.Text = Session["OfferCode"].ToString();
                            }
                            if (Session["OfferApplied"].ToString().Contains("Applied"))
                            {
                                try
                                {
                                    string RandomNumber = "0", OrderType = string.Empty;
                                    int userId = 0;
                                    List<ClsProductDetail> lstProductDetail = new List<ClsProductDetail>();

                                    foreach (RepeaterItem items in rptOrderDetail.Items)
                                    {
                                        Label lblCartId = (Label)items.FindControl("lblCartId");
                                        Label lblProductdetailId = (Label)items.FindControl("lblProductdetailId");
                                        Label lblPropertyId = (Label)items.FindControl("lblPropertyId");
                                        Label lblProductIngredientFactId = (Label)items.FindControl("lblProductIngredientFactId");
                                        Label lblExtraIngredientId = (Label)items.FindControl("lblExtraIngredientId");
                                        Label lblSizeId = (Label)items.FindControl("lblSizeId");
                                        Label lblPrice = (Label)items.FindControl("lblPrice");
                                        TextBox textboxQuantity = (TextBox)items.FindControl("txtQuantity");
                                        Label lblSizeName = (Label)items.FindControl("lblSizeName");
                                        if (lblCartId != null && lblProductdetailId != null && lblPropertyId != null && lblProductIngredientFactId != null && lblExtraIngredientId != null
                                            && lblSizeId != null && lblPrice != null && textboxQuantity != null)
                                        {
                                            ClsProductDetail objClsProductDetail = new ClsProductDetail();
                                            objClsProductDetail.CartId = Convert.ToInt32(lblCartId.Text);
                                            objClsProductDetail.ProductdetailId = Convert.ToInt32(lblProductdetailId.Text);
                                            objClsProductDetail.PropertiesId = Convert.ToInt32(lblPropertyId.Text);
                                            objClsProductDetail.IngredientFactId = Convert.ToInt32(lblProductIngredientFactId.Text);
                                            objClsProductDetail.ExtraIngredientId = lblExtraIngredientId.Text;
                                            objClsProductDetail.SizeId = Convert.ToInt32(lblSizeId.Text);
                                            objClsProductDetail.Quantity = Convert.ToInt32(textboxQuantity.Text);
                                            objClsProductDetail.SizeName = lblSizeName.Text;
                                            objClsProductDetail.Price = Convert.ToDecimal(lblPrice.Text.Replace("$", ""));
                                            lstProductDetail.Add(objClsProductDetail);
                                        }
                                    }
                                    //userId = 3;
                                    if (Session["UserId"] != null)
                                    {
                                        userId = Convert.ToInt32(Session["UserId"]);
                                    }
                                    if (Session["RandomNumber"] != null)
                                    {
                                        RandomNumber = Session["RandomNumber"].ToString();
                                    }
                                    if (chkPickOrder.Checked == true)
                                    {
                                        OrderType = "Pick up";
                                    }
                                    else
                                    {
                                        OrderType = "Online";
                                    }
                                    ClsDailySpecialsOffer objClsDailySpecialsOffer = new ClsDailySpecialsOffer();
                                    if (Session["OfferApplied"] != null)
                                    {
                                        ClsProductDetail ClsProductDetailobj = new ClsProductDetail();
                                        ClsProductDetailobj = objClsDailySpecialsOffer.GetOfferAmountByOfferCode(txtOfferCode.Text, lstProductDetail);
                                        if (ClsProductDetailobj.ProductdetailId != 0)
                                        {
                                            Session["OfferApplied"] = "Applied";
                                            ClsCartDetail objCartDetail = new ClsCartDetail();
                                            if (Session["UserId"] != null)
                                            {
                                                List<ClsCartDetail> lstClsCartDetail = new List<ClsCartDetail>();
                                                if (ClsProductDetailobj.CombineSizeId != "0")
                                                {
                                                    int SizeId = Convert.ToInt32(ClsProductDetailobj.CombineSizeId.Split(',')[1]);
                                                    retMsg = objCartDetail.InsertCartDetail(ClsProductDetailobj.ProductdetailId, Convert.ToInt32(Session["UserId"]), SizeId, ClsProductDetailobj.PropertiesId, 1, "0", ClsProductDetailobj.IngredientFactId, "0", null, null);
                                                }
                                                retMsg = objCartDetail.InsertCartDetail(ClsProductDetailobj.ProductdetailId, Convert.ToInt32(Session["UserId"]), ClsProductDetailobj.SizeId, ClsProductDetailobj.PropertiesId, 1, "0", ClsProductDetailobj.IngredientFactId, "0", null, null);
                                                //retMsg = objCartDetail.InsertCartDetail(ClsProductDetailobj.ProductdetailId, 1, ClsProductDetailobj.SizeId, ClsProductDetailobj.PropertiesId, 1, "0", ClsProductDetailobj.IngredientFactId, "0", lstClsCartDetail);
                                            }
                                            else
                                            {
                                                retMsg = objCartDetail.InsertCartDetail(ClsProductDetailobj.ProductdetailId, 0, ClsProductDetailobj.SizeId, ClsProductDetailobj.PropertiesId, 1, "0", ClsProductDetailobj.IngredientFactId, Session["RandomNumber"].ToString(), null, null);
                                            }
                                            List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
                                            if (Session["UserId"] != null)
                                            {
                                                lstClsProductDetail = objClsCustomerOrderDetail.GetUserCartDetail(Convert.ToInt32(Session["UserId"]), "0");
                                            }
                                            else
                                            {
                                                // lstClsProductDetail = objClsCustomerOrderDetail.GetUserCartDetail(1, "0");
                                                lstClsProductDetail = objClsCustomerOrderDetail.GetUserCartDetail(0, Session["RandomNumber"].ToString());
                                            }
                                            //lstClsProductDetail.Add(ClsProductDetailobj);
                                            if (lstClsProductDetail.Count > 0)
                                            {
                                                rptOrderDetail.DataSource = lstClsProductDetail;
                                                rptOrderDetail.DataBind();
                                            }
                                            lblDiscount.Text = "$0";
                                            txtOfferCode.Text = "";
                                        }
                                        else
                                        {
                                            Session["OfferApplied"] = "Applied";
                                            LblTotalPrice.Text = "$" + (Convert.ToDecimal(LblTotalPrice.Text.Replace("$", "")) - ClsProductDetailobj.OfferAmount).ToString();
                                            decimal DisplayTotalPrice1 = (Math.Floor(Convert.ToDecimal(LblTotalPrice.Text.Replace("$", "")) * 100) / 100);
                                            LblTotalPrice.Text = string.Format("{0:N2}", DisplayTotalPrice1);
                                            LblTotalPrice.Text = "$" + LblTotalPrice.Text.Replace("$", "");
                                            lblDiscount.Text = "$" + ClsProductDetailobj.OfferAmount.ToString();
                                            Session["OfferAmount"] = lblDiscount.Text;
                                            txtOfferCode.Text = "";
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    ErrorHandler.WriteError(ex);
                                }
                            }
                        }
                    }

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
    protected void rptOrderDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            Label lblExtraIngredientName = (Label)e.Item.FindControl("lblExtraIngredientName");
            if (lblExtraIngredientName != null)
            {
                if (lblExtraIngredientName.Text == null || lblExtraIngredientName.Text == "")
                {
                    lblExtraIngredientName.Text = "";
                    Label Label1 = (Label)e.Item.FindControl("Label1");
                    if (Label1 != null)
                    {
                        Label1.Visible = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void chkPickOrder_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkPickOrder.Checked == true)
            {
                Session["isChecked"] = "true";
                //  datepicker.Enabled = false;
                // ddlHour.Enabled = false;
                // DdlMinute.Enabled = false;
                // DdlTime.Enabled = false;
                txtaddress.BorderColor = System.Drawing.Color.White;
                txtCity.BorderColor = System.Drawing.Color.White;
                DdlState.BorderColor = System.Drawing.Color.White;
                txtzip.BorderColor = System.Drawing.Color.White;
                txtaddress.Enabled = false;
                txtCity.Enabled = false;
                txtzip.Enabled = false;
                DdlState.Enabled = false;
                txtDeliveryInstructions.Enabled = false;
                Total = 0;
                if (Session["OfferAmount"] != null)
                {
                    lblDiscount.Text = Session["OfferAmount"].ToString();
                }
                else
                {
                    lblDiscount.Text = "$0";
                }
                foreach (RepeaterItem items in rptOrderDetail.Items)
                {
                    Label lblPrice = (Label)items.FindControl("lblPrice");
                    if (lblPrice != null)
                    {
                        Total = Total + Convert.ToDecimal(lblPrice.Text.ToString().Replace("$", ""));
                    }
                }
                lblDeliveryCharges.Text = "$0";
                LblTotal.Text = Total.ToString();
                lblSalesPrice.Text = objClsMiscellaneousSettings.GetTaxConfigSetting().tpc_value;
                decimal tax = (Convert.ToDecimal(lblSalesPrice.Text.ToString().Replace("%", "")) * Convert.ToDecimal(Total)) / 100;
                lblSalesPrice.Text = "$" + tax.ToString().Replace("$", "");
                decimal DisplaysalesTax = (Math.Floor(Convert.ToDecimal(lblSalesPrice.Text.Replace("$", "")) * 100) / 100);
                lblSalesPrice.Text = string.Format("{0:N2}", DisplaysalesTax);

                lblSalesPrice.Text = "$" + lblSalesPrice.Text.ToString().Replace("$", "");

                LblTotalPrice.Text = "$" + (Total + Convert.ToDecimal(lblSalesPrice.Text.ToString().Replace("$", "")) + Convert.ToDecimal(lblDeliveryCharges.Text.Replace("$", ""))).ToString();
                decimal DisplayTotalPrice = (Math.Floor(Convert.ToDecimal(LblTotalPrice.Text.Replace("$", "")) * 100) / 100);
                LblTotalPrice.Text = string.Format("{0:N2}", DisplayTotalPrice);

                LblTotalPrice.Text = "$" + LblTotalPrice.Text.Replace("$", "");
                LblTotal.Text = "$" + (LblTotal.Text);
            }
            else
            {
                Session["isChecked"] = "False";
                datepicker.Enabled = true;
                ddlHour.Enabled = true;
                DdlMinute.Enabled = true;
                DdlTime.Enabled = true;
                txtaddress.Enabled = true;
                txtCity.Enabled = true;
                txtzip.Enabled = true;
                DdlState.Enabled = true;
                txtDeliveryInstructions.Enabled = true;
                Total = 0;
                if (Session["OfferAmount"] != null)
                {
                    lblDiscount.Text = Session["OfferAmount"].ToString();
                }
                else
                {
                    lblDiscount.Text = "$0";
                }
                foreach (RepeaterItem items in rptOrderDetail.Items)
                {
                    Label lblPrice = (Label)items.FindControl("lblPrice");
                    if (lblPrice != null)
                    {
                        Total = Total + Convert.ToDecimal(lblPrice.Text.ToString().Replace("$", ""));
                    }
                }
                lblSalesPrice.Text = objClsMiscellaneousSettings.GetTaxConfigSetting().tpc_value;
                lblDeliveryCharges.Text = objClsMiscellaneousSettings.GetDeliveryChargeConfigSetting().tpc_value;
                LblTotal.Text = Total.ToString();
                decimal tax = (Convert.ToDecimal(lblSalesPrice.Text.ToString().Replace("%", "")) * Convert.ToDecimal(Total)) / 100;
                lblSalesPrice.Text = "$" + tax.ToString().Replace("$", "");
                decimal DisplaysalesTax = (Math.Floor(Convert.ToDecimal(lblSalesPrice.Text.Replace("$", "")) * 100) / 100);
                lblSalesPrice.Text = string.Format("{0:N2}", DisplaysalesTax);
                lblSalesPrice.Text = "$" + lblSalesPrice.Text.ToString().Replace("$", "");

                LblTotalPrice.Text = "$" + (Total + Convert.ToDecimal(lblSalesPrice.Text.ToString().Replace("$", "")) + Convert.ToDecimal(lblDeliveryCharges.Text.Replace("$", ""))).ToString();
                decimal DisplayTotalPrice = (Math.Floor(Convert.ToDecimal(LblTotalPrice.Text.Replace("$", "")) * 100) / 100);
                LblTotalPrice.Text = string.Format("{0:N2}", DisplayTotalPrice);
                LblTotalPrice.Text = "$" + LblTotalPrice.Text.Replace("$", "");
                LblTotal.Text = "$" + (LblTotal.Text);
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    protected void datepicker_TextChanged(object sender, EventArgs e)
    {
        //datepicker.Text = "05/27/2016";
        DateTime currentTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, TimeZoneInfo.Local.Id, "Central Standard Time");
        DateTime selectedDate = Convert.ToDateTime(datepicker.Text);
        if (currentTime.Date.Day == selectedDate.Date.Day)
        {
            int currentHour = currentTime.Hour;
            if (currentHour == 1)
            {
                ddlHour.Items.Remove(ddlHour.Items.FindByValue("01"));
            }
            else if (currentHour == 2)
            {
                ddlHour.Items.Remove(ddlHour.Items.FindByValue("01"));
            }
            if (currentHour == 3)
            {
                ddlHour.Items.Remove(ddlHour.Items.FindByValue("01"));
            }
            if (currentHour == 4)
            {
                ddlHour.Items.Remove(ddlHour.Items.FindByValue("01"));
            }
        }
    }
    protected void datepicker_DataBinding(object sender, EventArgs e)
    {

    }
}