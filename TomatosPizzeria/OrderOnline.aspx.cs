using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class OrderOnline : System.Web.UI.Page, IPostBackEventHandler
{
    private string m_categoryName;
    private string m_CategoryDescription;
    private string m_productName;
    private string m_ingredientPrice;

    ClsProductDetail objClsProductDetail = new ClsProductDetail();
    ClsCartDetail objClsCartDetail = new ClsCartDetail();
    ClsMiscellaneousSettings objClsMiscellaneousSettings = new ClsMiscellaneousSettings();
    decimal Total = 0;
    static bool isSingleIngredients = true;

    public string CategoryName
    {
        get
        {
            return m_categoryName;
        }

        set
        {
            m_categoryName = value;
        }
    }
    public string CategoryDescription
    {
        get
        {
            return m_CategoryDescription;
        }

        set
        {
            m_CategoryDescription = value;
        }
    }
    public string ProductName
    {
        get
        {
            return m_productName;
        }

        set
        {
            m_productName = value;
        }
    }

    public string IngredientPrice
    {
        get
        {
            return m_ingredientPrice;
        }

        set
        {
            m_ingredientPrice = value;
        }
    }
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
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!IsPostBack)
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

                foreach (DataListItem item in dlCategory.Items)
                {

                    LinkButton lnkCategoryName = (LinkButton)item.FindControl("lnkCategoryName");
                    lnkCategoryName.CssClass = lnkCategoryName.CssClass.Replace("highlight", "");
                }

                tp_config objtp_config = new tp_config();
                ClsMiscellaneousSettings objClsMiscellaneousSettings = new ClsMiscellaneousSettings();
                objtp_config = objClsMiscellaneousSettings.GetMinimumDeliveryPurchaseConfigSetting();
                MinimumPurchase = objtp_config.tpc_value;
                DeliveryCharge = objClsMiscellaneousSettings.GetDeliveryChargeConfigSetting().tpc_value;

                //  SuccessMsgDiv.Style.Add("display", "none");
                if (Session["UserEmail"] != null)
                {
                    // SpanEmail.InnerHtml = Session["FirstName"].ToString();
                    SignInDiv.Style.Add("display", "none");
                    EmailDiv.Style.Add("display", "block");
                    AccountDiv.Style.Add("display", "none");
                    LogoutDiv.Style.Add("display", "block");
                }
                if (Session["CartItem"] != null)
                {
                    item_no.InnerHtml = Session["CartItem"].ToString() + " Items";
                }
                else
                {
                    item_no.InnerHtml = "0" + " Item";
                }


                if (Request.QueryString["CategoryId"] != null)
                {
                    string categoryId = DecryptString(HttpUtility.UrlDecode(Request.QueryString["CategoryId"].ToString()));
                    GetDeliveryChargeConfigSetting();
                    GetMinimumDeliveryPurchaseConfigSetting();
                    GetAddressDetail();
                    GetPhoneDetail();
                    GetFaxDetail();
                    GetEmailDetail();
                    BindCategory();

                    afacebbok.HRef = objClsMiscellaneousSettings.GetFaceBookLink().tpc_value;
                    agoogleplus.HRef = objClsMiscellaneousSettings.GetGooglePlusLink().tpc_value;
                    alinkedin.HRef = objClsMiscellaneousSettings.GetLinkedInLink().tpc_value;
                    ayoutube.HRef = objClsMiscellaneousSettings.GetYouTubeLink().tpc_value;

                    productDetail.Style.Add("display", "block");

                    foreach (DataListItem item in dlCategory.Items)
                    {
                        Label lblCategoryId = (Label)item.FindControl("lblCategoryId");
                        if (lblCategoryId.Text.Trim() == categoryId)
                        {

                            LinkButton lnkCategoryName = (LinkButton)item.FindControl("lnkCategoryName");
                            lnkCategoryName.CssClass = "highlight";
                            ViewState["CategoryName"] = lnkCategoryName.Text;
                        }
                    }

                    BindProductList(Convert.ToInt32(categoryId));
                    // factDiv.Style.Add("display", "none");
                    //ingredient_list.Style.Add("display", "none");
                    GetUserCartDetail();

                    lblSalesPrice.Text = objClsMiscellaneousSettings.GetTaxConfigSetting().tpc_value;
                    lblDeliveryCharges.Text = objClsMiscellaneousSettings.GetDeliveryChargeConfigSetting().tpc_value;
                    Total = 0;

                    foreach (RepeaterItem items in rptCartDetail.Items)
                    {
                        Label lblPrice = (Label)items.FindControl("lblPrice");
                        if (lblPrice != null)
                        {
                            Total = Total + Convert.ToDecimal(lblPrice.Text.ToString().Replace("$", ""));
                        }
                    }

                    LblTotal.Text = Total.ToString();
                    decimal tax = (Convert.ToDecimal(lblSalesPrice.Text.ToString().Replace("%", "")) * Convert.ToDecimal(Total)) / 100;
                    lblSalesPrice.Text = "$" + tax.ToString().Replace("$", "");

                    decimal DisplaysalesTax = (Math.Floor(Convert.ToDecimal(lblSalesPrice.Text.Replace("$", "")) * 100) / 100);
                    lblSalesPrice.Text = string.Format("{0:N2}", DisplaysalesTax);
                    lblSalesPrice.Text = "$" + lblSalesPrice.Text.ToString().Replace("$", "");
                    //lblSalesPrice.Text = (Math.Round(Convert.ToDecimal(lblSalesPrice.Text.Replace("$", "")), 2).ToString().Replace("$", ""));
                    LblTotalPrice.Text = "$" + (Total + Convert.ToDecimal(lblSalesPrice.Text.ToString().Replace("$", "")) + Convert.ToDecimal(lblDeliveryCharges.Text.Replace("$", ""))).ToString();
                    decimal DisplayTotalPrice = ((Math.Floor(Convert.ToDecimal(LblTotalPrice.Text.Replace("$", "")) * 100) / 100));
                    LblTotalPrice.Text = string.Format("{0:N2}", DisplayTotalPrice);
                    LblTotalPrice.Text = "$" + LblTotalPrice.Text.Replace("$", "");
                    LblTotal.Text = "$" + (LblTotal.Text.Replace("$", ""));

                }
                else
                {
                    GetDeliveryChargeConfigSetting();
                    GetMinimumDeliveryPurchaseConfigSetting();
                    GetAddressDetail();
                    GetPhoneDetail();
                    GetFaxDetail();
                    GetEmailDetail();
                    BindCategory();
                    productDetail.Style.Add("display", "block");
                    int categoryId = Convert.ToInt32(ViewState["CategoryId"]);

                    foreach (DataListItem item in dlCategory.Items)
                    {
                        Label lblCategoryId = (Label)item.FindControl("lblCategoryId");
                        if (lblCategoryId.Text.Trim() == categoryId.ToString())
                        {

                            LinkButton lnkCategoryName = (LinkButton)item.FindControl("lnkCategoryName");
                            lnkCategoryName.CssClass = "highlight";
                            ViewState["CategoryName"] = lnkCategoryName.Text;
                        }
                    }

                    BindProductList(Convert.ToInt32(ViewState["CategoryId"]));
                    //factDiv.Style.Add("display", "none");
                    //ingredient_list.Style.Add("display", "none");
                    GetUserCartDetail();

                    lblSalesPrice.Text = objClsMiscellaneousSettings.GetTaxConfigSetting().tpc_value;
                    lblDeliveryCharges.Text = objClsMiscellaneousSettings.GetDeliveryChargeConfigSetting().tpc_value;
                    Total = 0;

                    foreach (RepeaterItem items in rptCartDetail.Items)
                    {
                        Label lblPrice = (Label)items.FindControl("lblPrice");
                        if (lblPrice != null)
                        {
                            Total = Total + Convert.ToDecimal(lblPrice.Text.ToString().Replace("$", ""));
                        }
                    }

                    LblTotal.Text = Total.ToString();
                    decimal tax = (Convert.ToDecimal(lblSalesPrice.Text.ToString().Replace("%", "")) * Convert.ToDecimal(Total)) / 100;
                    lblSalesPrice.Text = "$" + tax.ToString().Replace("$", "");

                    decimal DisplaysalesTax = (Math.Floor(Convert.ToDecimal(lblSalesPrice.Text.Replace("$", "")) * 100) / 100);
                    lblSalesPrice.Text = string.Format("{0:N2}", DisplaysalesTax);

                    lblSalesPrice.Text = "$" + lblSalesPrice.Text.ToString().Replace("$", "");
                    //lblSalesPrice.Text = (Math.Round(Convert.ToDecimal(lblSalesPrice.Text.Replace("$", "")), 2).ToString().Replace("$", ""));
                    LblTotalPrice.Text = "$" + (Total + Convert.ToDecimal(lblSalesPrice.Text.ToString().Replace("$", "")) + Convert.ToDecimal(lblDeliveryCharges.Text.Replace("$", ""))).ToString();

                    decimal DisplayTotalPrice = ((Math.Floor(Convert.ToDecimal(LblTotalPrice.Text.Replace("$", "")) * 100) / 100));
                    LblTotalPrice.Text = string.Format("{0:N2}", DisplayTotalPrice);
                    LblTotalPrice.Text = "$" + LblTotalPrice.Text.Replace("$", "");
                    LblTotal.Text = "$" + (LblTotal.Text.Replace("$", ""));

                }

            }

        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    //protected override void Render(HtmlTextWriter writer)
    //{
    //    // .... render using the provided writer
    //    //ClientScript.RegisterForEventValidation("");
    //}

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

    public void BindCategory()
    {
        try
        {
            List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
            lstClsProductDetail = objClsProductDetail.GetAllCategoryForOrderOnline();

            for (int i = 0; i < lstClsProductDetail.Count; i++)
            {
                ViewState["CategoryId"] = lstClsProductDetail[0].CategotyId;
            }
            dlCategory.DataSource = lstClsProductDetail;
            dlCategory.DataBind();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void BindProductList(int categoryId)
    {
        try
        {
            List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
            DataTable dt = new DataTable();
            // dt = objClsProductDetail.GetAllProductByCategoryId(10);
            dt = objClsProductDetail.GetAllProductByCategoryId(categoryId);
            // ViewState["ProductDetailList"] = dt;
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CategoryName = dr["CategoryName"].ToString();
                    CategoryDescription = dr["CategoryDescription"].ToString();
                }
                title.InnerHtml = CategoryName;
                Description.InnerHtml = CategoryDescription;
            }
            else
            {
                if (ViewState["CategoryName"] != null)
                {
                    title.InnerHtml = ViewState["CategoryName"].ToString();
                }
                if (ViewState["CategoryDescription"] != null)
                {
                    Description.InnerHtml = ViewState["CategoryDescription"].ToString();
                }
            }

            if (dt != null && dt.Rows.Count > 0)
            {


                rptProductList.DataSource = dt;
                rptProductList.DataBind();


            }
            else
            {


                rptProductList.DataSource = null;
                rptProductList.DataBind();
            }

        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void dlCategory_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            Label lblCategoryId = (Label)e.Item.FindControl("lblCategoryId");
            LinkButton lnkCategoryName = (LinkButton)e.Item.FindControl("lnkCategoryName");

            //ViewState["Category"] = lnkCategoryName.Text;


            if (lblCategoryId != null)
            {

                BindProductList(Convert.ToInt32(lblCategoryId.Text.Trim()));

            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void dlCategory_ItemCommand(object source, DataListCommandEventArgs e)
    {
        try
        {
            string[] arg = new string[3];
            arg = e.CommandArgument.ToString().Split(':');
            int categoryId = Convert.ToInt32(arg[0]);
            string categoryName = arg[1];
            string Categorydesciption = arg[2];
            ViewState["CategoryName"] = categoryName;
            ViewState["CategoryId"] = categoryId;
            ViewState["CategoryDescription"] = Categorydesciption;
            BindProductList(Convert.ToInt32(categoryId));
            productDetail.Style.Add("display", "block");
            //factDiv.Style.Add("display", "none");
            //ingredient_list.Style.Add("display", "none");

            DataList currentDataList = source as DataList;

            foreach (DataListItem dli in currentDataList.Items)
            {
                LinkButton lnk = (LinkButton)dli.FindControl("lnkCategoryName");
                lnk.BackColor = System.Drawing.Color.Transparent;
                lnk.CssClass = "";
            }

            LinkButton lnkCategoryName = (LinkButton)e.Item.FindControl("lnkCategoryName");
            lnkCategoryName.CssClass = "highlight";



            //Label lblCategoryId = (Label)e.Item.FindControl("lblCategoryId");
            //lblCategoryId.CssClass= "highlight";
            //ScriptManager.RegisterStartupScript(this, GetType(), "myFunction", "click();", true);
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }

    }
    protected void rptProductList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            Label lblProductID = (Label)e.Item.FindControl("lblProductID");
            Label lblProductPrice = (Label)e.Item.FindControl("lblProductPrice");
            Label lblProductName = (Label)e.Item.FindControl("lblProductName");
            LinkButton lnkProductPrice = (LinkButton)e.Item.FindControl("lnkProductPrice");
            if (lblProductID != null)
            {

                try
                {
                    List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();

                    lstClsProductDetail = objClsProductDetail.GetProductSizeDetailByProductId(Convert.ToInt32(lblProductID.Text.Trim()));
                    DataTable dt = lstClsProductDetail.ListToDataTable();
                    ViewState["ProductSizeList"] = dt;


                    if (ViewState["ProductSizeList"] != null && ((DataTable)(ViewState["ProductSizeList"])).Rows.Count > 0)
                    {
                        //  DataRow [] firstRow = ((DataTable)(ViewState["ProductSizeList"]));
                        DataTable dtAssign = ((DataTable)(ViewState["ProductSizeList"])).Clone();
                        foreach (DataRow row in ((DataTable)(ViewState["ProductSizeList"])).Rows)
                        {
                            dtAssign.ImportRow(row);
                            break;
                        }

                        rptSize.DataSource = dtAssign;
                        // rptSize.DataSource = (DataTable)(ViewState["ProductSizeList"]);
                        rptSize.DataBind();
                        rptPrice.Visible = false;
                    }
                    else
                    {
                        lstClsProductDetail = objClsProductDetail.GetProdcutPriceByProductId(Convert.ToInt32(lblProductID.Text.Trim()));

                        rptPrice.DataSource = lstClsProductDetail;
                        rptPrice.DataBind();
                        rptSize.Visible = false;
                    }

                }
                catch (Exception ex)
                {
                    ErrorHandler.WriteError(ex);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }



    protected void rptPrice_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            ddlSizePop.Visible = false;
            string selectedCategoryName = "";
            foreach (DataListItem item in dlCategory.Items)
            {
                Label lblCategoryId = (Label)item.FindControl("lblCategoryId");
                if (lblCategoryId.Text.Trim() == ViewState["CategoryId"].ToString())
                {

                    LinkButton lnkCategoryName = (LinkButton)item.FindControl("lnkCategoryName");
                    lnkCategoryName.CssClass = "highlight";
                    selectedCategoryName = lnkCategoryName.Text;
                }
            }

            if (ViewState["CategoryName"] == "Fresh Salads")
            {

            }

            isSingleIngredients = true;

            int productId = Convert.ToInt32(e.CommandArgument);
            ViewState["ProductId"] = productId;
            ViewState["ProductId"] = productId;
            ViewState["SizeId"] = 0;
            ProductName = objClsProductDetail.GetProductNameByProductId(productId);

            lblModalHeader.Text = selectedCategoryName + " - " + ProductName;
            lblSelectedPizzaHeader.Text = ProductName;

            List<ClsProductDetail> lstClsProductDetail1 = new List<ClsProductDetail>();

            lstClsProductDetail1 = objClsProductDetail.GetProdcutPriceByProductId(Convert.ToInt32(hdnSizeInfo.Value));
            DataTable dt1 = lstClsProductDetail1.ListToDataTable();

            string param = "";
            foreach (DataRow dr in dt1.Rows)
            {
                param += dr["BasePrice"] + ",";
            }
            param = param.Replace("'", "");
            param = param.TrimEnd(',');

            ViewState["param"] = param;


            if (e.CommandName == "AddIngredientByPrice")
            {
                //  pnameForNotIngredient.Visible = false;
                //   Pnameh4.Visible = true;
                //  Btndiv.Visible = true;
                DataTable dt = new DataTable();
                dt = objClsProductDetail.GetExtraIngredientsForProduct(productId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    ProductName = objClsProductDetail.GetProductNameByProductId(productId);
                    //     pname.InnerHtml = ProductName;
                    //     factDiv.Style.Add("display", "block");
                    //ingredient_list.Style.Add("display", "none");
                    List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
                    //change to ingredient
                    lstClsProductDetail = objClsProductDetail.GetIndredientFactDetailByProductId(productId);
                    if (lstClsProductDetail.Count > 0)
                    {
                        btnYes.Visible = false;
                        btnNo.Visible = false;
                        btnJustAddToCart.Visible = true;
                        //      lblMessage.Visible = true;
                        //      lblMessage1.Visible = false;
                        //      btnFact1.Visible = false;
                        //      btnFact2.Visible = false;
                        if (ViewState["CategoryName"].ToString() == "Fresh Salads")
                        {
                            //         lblMessage.Text = "How would you like your Dressings?";
                        }
                        //else if (ViewState["CategoryName"].ToString() == "Gourmet Pizza" || ViewState["CategoryName"].ToString() == "Tomato’s Pizza")
                        else
                        {
                            //         lblMessage.Text = "How would you like your toppings?";
                        }

                        IngredientDiv.Style.Add("display", "block");
                        foreach (var item in lstClsProductDetail)
                        {
                            //         if (btnFact1.Text == item.IngredientFactName.Trim())
                            //         {
                            //             btnFact1.Visible = true;

                            //          }
                            //          else if (btnFact2.Text == item.IngredientFactName.Trim())
                            //         {
                            //            btnFact2.Visible = true;

                            //        }

                        }

                    }
                    else
                    {

                        //  btnFact1.Visible = false;
                        //  btnFact2.Visible = false;
                        btnJustAddToCart.Visible = false;
                        bool? CanComment = objClsProductDetail.GetCanCommentValueByProductId(Convert.ToInt32(ViewState["ProductId"].ToString()));

                        if (CanComment == true)
                        {
                            txtComment.Visible = true;
                            txtComment.Enabled = true;
                            //    factDiv.Style.Add("display", "block");
                            //     factDiv.Visible = true;
                            ProductName = objClsProductDetail.GetProductNameByProductId(productId);
                            //    pnameForNotIngredient.Visible = true;
                            //    Pnameh4.Visible = false;
                            //    pnameForNotIngredient.InnerHtml = ProductName;
                            //ingredient_list.Style.Add("display", "block");
                            //ingredient_list.Visible = true;
                            btnJustAddToCart.Visible = false;
                            //btnYes.Visible = true;
                            //btnNo.Visible = true;
                            //   btnFact1.Visible = false;
                            //   btnFact2.Visible = false;
                            //   lblMessage.Visible = false;
                            //   lblMessage1.Visible = false;
                            IngredientDiv.Style.Add("display", "none");
                            IngredientDiv.Visible = false;
                            //   Btndiv.Visible = false;
                            // lblMessage.Visible = true;
                            // lblMessage.Text = "Are you sure you want to add item to cart?";
                        }
                        else
                        {
                            txtComment.Visible = true;
                            txtComment.Enabled = false;
                            //   factDiv.Style.Add("display", "block");
                            //   factDiv.Visible = true;
                            ProductName = objClsProductDetail.GetProductNameByProductId(productId);
                            //   pnameForNotIngredient.Visible = true;
                            //   Pnameh4.Visible = false;
                            //   pnameForNotIngredient.InnerHtml = ProductName;
                            //ingredient_list.Style.Add("display", "block");
                            //ingredient_list.Visible = true;
                            btnJustAddToCart.Visible = false;
                            //btnYes.Visible = true;
                            //btnNo.Visible = true;
                            //   btnFact1.Visible = false;
                            //  btnFact2.Visible = false;
                            //   lblMessage.Visible = false;
                            //   lblMessage1.Visible = false;
                            IngredientDiv.Style.Add("display", "none");
                            IngredientDiv.Visible = false;
                            //    Btndiv.Visible = false;

                        }
                        BindIngredientList(rptIngredients);
                    }
                }
                else
                {
                    ProductName = objClsProductDetail.GetProductNameByProductId(productId);
                    //   pname.InnerHtml = ProductName;
                    //   factDiv.Style.Add("display", "block");
                    //ingredient_list.Style.Add("display", "none");
                    List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
                    //change to ingredient
                    lstClsProductDetail = objClsProductDetail.GetIndredientFactDetailByProductId(productId);
                    if (lstClsProductDetail.Count > 0)
                    {
                        //    lblMessage.Visible = true;
                        btnYes.Visible = false;
                        btnNo.Visible = false;
                        btnJustAddToCart.Visible = true;
                        //    lblMessage1.Visible = false;
                        //    btnFact1.Visible = false;
                        //    btnFact2.Visible = false;
                        if (ViewState["CategoryName"].ToString() == "Fresh Salads")
                        {
                            //      lblMessage.Text = "How would you like your Dressings?";
                        }
                        else if (ViewState["CategoryName"].ToString() == "Gourmet Pizza" || ViewState["CategoryName"].ToString() == "Tomato’s Pizza")
                        {
                            //       lblMessage.Text = "How would you like your toppings?";
                        }
                        else
                        {
                            //        lblMessage.Text = "How would you like your Ingredients?";
                        }
                        // lblMessage.Text = "How would you like your Ingredients?";
                        foreach (var item in lstClsProductDetail)
                        {
                            //        if (btnFact1.Text == item.IngredientFactName.Trim())
                            //        {
                            //            btnFact1.Visible = true;

                            //        }
                            //else if (btnFact2.Text == item.IngredientFactName.Trim())
                            //{
                            //    btnFact2.Visible = true;

                            //}

                        }
                    }
                    else
                    {
                        //btnFact1.Visible = false;
                        //btnFact2.Visible = false;
                        btnJustAddToCart.Visible = false;
                        bool? CanComment = objClsProductDetail.GetCanCommentValueByProductId(Convert.ToInt32(ViewState["ProductId"].ToString()));

                        if (CanComment == true)
                        {
                            txtComment.Visible = true;
                            txtComment.Enabled = true;
                            //factDiv.Style.Add("display", "block");
                            //factDiv.Visible = true;
                            ProductName = objClsProductDetail.GetProductNameByProductId(productId);
                            //pnameForNotIngredient.Visible = true;
                            //Pnameh4.Visible = false;
                            //pnameForNotIngredient.InnerHtml = ProductName;
                            //ingredient_list.Style.Add("display", "block");
                            //ingredient_list.Visible = true;
                            btnJustAddToCart.Visible = false;
                            //btnYes.Visible = true;
                            //btnNo.Visible = true;
                            //btnFact1.Visible = false;
                            //btnFact2.Visible = false;
                            //lblMessage.Visible = false;
                            //lblMessage1.Visible = false;
                            IngredientDiv.Style.Add("display", "none");
                            IngredientDiv.Visible = false;
                            //  Btndiv.Visible = false;
                            // lblMessage.Visible = true;
                            // lblMessage.Text = "Are you sure you want to add item to cart?";
                        }
                        else
                        {
                            //factDiv.Style.Add("display", "block");
                            //Btndiv.Style.Add("display", "block");
                            //factDiv.Visible = true;
                            //Btndiv.Visible = true;
                            btnYes.Style.Add("display", "block");
                            btnNo.Style.Add("display", "block");

                            txtComment.Visible = true;
                            txtComment.Enabled = false;
                            btnYes.Visible = true;
                            btnNo.Visible = true;
                            //lblMessage.Visible = false;
                            //lblMessage1.Visible = true;
                            //lblMessage1.Text = "Add to Cart?";
                            //btnFact1.Visible = false;
                            //btnFact2.Visible = false;
                            btnJustAddToCart.Visible = false;
                        }
                    }
                }

            }

            bool? IsCommentAllowed = objClsProductDetail.GetCanCommentValueByProductId(Convert.ToInt32(ViewState["ProductId"].ToString()));
            txtComment.Visible = IsCommentAllowed.Value;
            if (IsCommentAllowed.HasValue && !IsCommentAllowed.Value) txtComment.Text = "";

            ddlWingSouce.Visible = lblSelectedPizzaHeader.Text.StartsWith("Buffalo Wings");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal('" + param + "', 'price');", true);
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void rptSize_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            ddlSizePop.Visible = true;
            string selectedCategoryName = "";
            foreach (DataListItem item in dlCategory.Items)
            {
                Label lblCategoryId = (Label)item.FindControl("lblCategoryId");
                if (lblCategoryId.Text.Trim() == ViewState["CategoryId"].ToString())
                {

                    LinkButton lnkCategoryName = (LinkButton)item.FindControl("lnkCategoryName");
                    lnkCategoryName.CssClass = "highlight";
                    selectedCategoryName = lnkCategoryName.Text;
                }
            }
            LinkButton lnkSize = (LinkButton)e.Item.FindControl("lnkSize");
            isSingleIngredients = true;
            //ingredient_list.Style.Add("display", "none");
            string[] arg = new string[2];
            arg = e.CommandArgument.ToString().Split(':');
            int productId = Convert.ToInt32(arg[0]);
            ViewState["ProductId"] = productId;
            int sizeId = Convert.ToInt32(arg[1]);

            ViewState["ProductId"] = productId;
            ViewState["SizeId"] = sizeId;
            ProductName = objClsProductDetail.GetProductNameByProductId(productId);

            lblModalHeader.Text = selectedCategoryName + " - " + ProductName;
            lblSelectedPizzaHeader.Text = ProductName;

            List<ClsProductDetail> lstClsProductDetail1 = new List<ClsProductDetail>();

            lstClsProductDetail1 = objClsProductDetail.GetProductSizeDetailByProductId(Convert.ToInt32(hdnSizeInfo.Value));
            DataTable dt1 = lstClsProductDetail1.ListToDataTable();

            string param = "";
            foreach (DataRow dr in dt1.Rows)
            {
                param += dr["SizeId"] + "#" + dr["Price"] + ":" + dr["SizeName"] + ",";
            }
            param = param.Replace("'", "");
            param = param.TrimEnd(',');

            ViewState["param"] = param;

            if (e.CommandName == "AddIngredientBySize")
            {
                DataTable dt = new DataTable();
                dt = objClsProductDetail.GetExtraIngredientsForProduct(productId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    //ingredient_list.Visible = true;
                    BindIngredientList(rptIngredients);
                    List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
                    //change to ingredient
                    lstClsProductDetail = objClsProductDetail.GetIndredientFactDetailByProductId(productId);
                    if (lstClsProductDetail.Count > 0)
                    {

                        btnYes.Visible = false;
                        btnNo.Visible = false;
                        btnJustAddToCart.Visible = true;
                        if (ViewState["CategoryName"].ToString() == "Fresh Salads")
                        {
                        }
                        else if (ViewState["CategoryName"].ToString() == "Gourmet Pizza" || ViewState["CategoryName"].ToString() == "Tomato’s Pizza")
                        {
                        }
                        else
                        {
                        }
                        foreach (var item in lstClsProductDetail)
                        {

                        }

                    }
                    else
                    {
                        btnJustAddToCart.Visible = false;
                        bool? CanComment = objClsProductDetail.GetCanCommentValueByProductId(Convert.ToInt32(ViewState["ProductId"].ToString()));

                        if (CanComment == true)
                        {
                            txtComment.Visible = true;
                            txtComment.Enabled = true;
                            ProductName = objClsProductDetail.GetProductNameByProductId(productId);
                            //ingredient_list.Style.Add("display", "block");
                            //ingredient_list.Visible = true;
                            btnJustAddToCart.Visible = false;
                            IngredientDiv.Style.Add("display", "none");
                            IngredientDiv.Visible = false;

                        }
                        else
                        {
                            txtComment.Visible = true;
                            txtComment.Enabled = false;
                            ProductName = objClsProductDetail.GetProductNameByProductId(productId);
                            //ingredient_list.Style.Add("display", "block");
                            //ingredient_list.Visible = true;
                            btnJustAddToCart.Visible = false;
                            IngredientDiv.Style.Add("display", "none");
                            IngredientDiv.Visible = false;
                        }

                    }
                }
                else
                {
                    ProductName = objClsProductDetail.GetProductNameByProductId(productId);

                    List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
                    //change to ingredient
                    lstClsProductDetail = objClsProductDetail.GetIndredientFactDetailByProductId(productId);
                    if (lstClsProductDetail.Count > 0)
                    {
                        //ingredient_list.Style.Add("display", "none");
                        btnJustAddToCart.Visible = true;
                        btnYes.Visible = false;
                        btnNo.Visible = false;
                        if (ViewState["CategoryName"].ToString() == "Fresh Salads")
                        {
                        }
                        else if (ViewState["CategoryName"].ToString() == "Gourmet Pizza" || ViewState["CategoryName"].ToString() == "Tomato’s Pizza")
                        {
                        }
                        else
                        {
                        }

                        foreach (var item in lstClsProductDetail)
                        {

                        }
                    }
                    else
                    {
                        bool? CanComment = objClsProductDetail.GetCanCommentValueByProductId(Convert.ToInt32(ViewState["ProductId"].ToString()));

                        if (CanComment == true)
                        {
                            txtComment.Visible = true;
                            txtComment.Enabled = true;
                            ProductName = objClsProductDetail.GetProductNameByProductId(productId);
                            //ingredient_list.Style.Add("display", "block");
                            //ingredient_list.Visible = true;
                            btnJustAddToCart.Visible = false;
                            IngredientDiv.Style.Add("display", "none");
                            IngredientDiv.Visible = false;
                        }
                        else
                        {
                            btnYes.Style.Add("display", "block");
                            btnNo.Style.Add("display", "block");

                            txtComment.Visible = true;
                            txtComment.Enabled = false;
                            btnYes.Visible = true;
                            btnNo.Visible = true;
                            btnJustAddToCart.Visible = false;
                        }
                    }
                }

            }

            bool? IsCommentAllowed = objClsProductDetail.GetCanCommentValueByProductId(Convert.ToInt32(ViewState["ProductId"].ToString()));
            txtComment.Visible = IsCommentAllowed.Value;
            if (IsCommentAllowed.HasValue && !IsCommentAllowed.Value) txtComment.Text = "";

            ddlWingSouce.Visible = lblSelectedPizzaHeader.Text.StartsWith("Buffalo Wings");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal('" + param + "','size');", true);

        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {

        if (Page.IsCallback)
        {
            if (IsPostBackEventControlRegistered)
            {

            }
        }

    }

    protected void btnFact1_Click(object sender, EventArgs e)
    {
        try
        {
            txtComment.BorderColor = System.Drawing.Color.White;
            IngredientDiv.Visible = true;
            IngredientDiv.Style.Add("display", "block");
            foreach (DataListItem item in dlCategory.Items)
            {
                Label lblCategoryId = (Label)item.FindControl("lblCategoryId");
                if (lblCategoryId.Text.Trim() == ViewState["CategoryId"].ToString())
                {

                    LinkButton lnkCategoryName = (LinkButton)item.FindControl("lnkCategoryName");
                    lnkCategoryName.CssClass = "highlight";
                }
            }
            if (ViewState["ProductId"] != null)
            {
                bool? CanComment = objClsProductDetail.GetCanCommentValueByProductId(Convert.ToInt32(ViewState["ProductId"].ToString()));

                if (CanComment == true)
                {
                    txtComment.Visible = true;
                    txtComment.Enabled = true;
                }
                else
                {
                    txtComment.Visible = true;
                    txtComment.Enabled = false;
                }
            }
            string factName = "";
            int factId = objClsProductDetail.GetFactIdByFactName(factName);
            ViewState["FactId"] = factId;
            IngredientDiv.Visible = false;
            //ingredient_list.Style.Add("display", "block");
            rptIngredients.Visible = true;
            BindIngredientList(rptIngredients);

        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void btnFact2_Click(object sender, EventArgs e)
    {
        try
        {
            txtComment.BorderColor = System.Drawing.Color.White;
            IngredientDiv.Visible = true;
            IngredientDiv.Style.Add("display", "block");
            foreach (DataListItem item in dlCategory.Items)
            {
                Label lblCategoryId = (Label)item.FindControl("lblCategoryId");
                if (lblCategoryId.Text.Trim() == ViewState["CategoryId"].ToString())
                {

                    LinkButton lnkCategoryName = (LinkButton)item.FindControl("lnkCategoryName");
                    lnkCategoryName.CssClass = "highlight";
                }
            }
            if (ViewState["ProductId"] != null)
            {
                bool? CanComment = objClsProductDetail.GetCanCommentValueByProductId(Convert.ToInt32(ViewState["ProductId"].ToString()));

                if (CanComment == true)
                {
                    txtComment.Visible = true;
                    txtComment.Enabled = true;
                }
                else
                {
                    txtComment.Visible = true;
                    txtComment.Enabled = false;
                }
            }
            string factName = "";
            int factId = objClsProductDetail.GetFactIdByFactName(factName);
            ViewState["FactId"] = factId;
            IngredientDiv.Visible = true;
            IngredientDiv.Style.Add("display", "block");
            //ingredient_list.Style.Add("display", "block");
            BindIngredientList(rptIngredients);
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void rptIngredients_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        ClsProductSizes objClsProductSize = new ClsProductSizes();
        try
        {
            Label lblIngredientPrice = (Label)e.Item.FindControl("lblIngredientPrice");
            //Button btning = (Button)e.Item.FindControl("btning");
            //btning.Visible = true;
            //string ingredientsGrouptext = btning.Text;

            HtmlGenericControl divbting = (HtmlGenericControl)e.Item.FindControl("divbting");
            divbting.Style.Add("display", "block");

            if (lblIngredientPrice != null && divbting != null)
            {
                DataList dlIngredientList = (DataList)e.Item.FindControl("dlIngredientList");

                if (dlIngredientList != null)
                {
                    BindIngredientByPrice(dlIngredientList, lblIngredientPrice.Text);
                }
            }
            //}
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void BindIngredientList(Repeater rptIngredients)
    {
        int productId = 0;
        try
        {
            if (ViewState["ProductId"] != null)
            {
                productId = Convert.ToInt32(ViewState["ProductId"]);
            }
            List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();



            // dt = objClsProductDetail.GetDistinctPriceOfIngredients(productId);
            if (ViewState["CategoryName"].ToString() == "Tomato’s Pizza" || ViewState["CategoryName"].ToString() == "Gourmet Pizza")
            {
                ClsProductSizes objClsProductSize = new ClsProductSizes();
                tp_product_properties objtpProductProperties = new tp_product_properties();

                objtpProductProperties = objClsProductSize.GetIngredientPriceBySizeId(Convert.ToInt32(ViewState["ProductId"]), Convert.ToInt32(ViewState["SizeId"].ToString()));

                if (objtpProductProperties != null)
                {
                    DataTable dt = new DataTable();

                    DataColumn dc = new DataColumn("IngredientPrice");
                    dt.Columns.Add(dc);
                    DataRow dr1 = dt.NewRow();

                    dr1["IngredientPrice"] = objtpProductProperties.pp_single_ingredients_price;
                    dt.Rows.Add(dr1);

                    lstClsProductDetail = objClsProductDetail.GetAllIngredientByPrice(string.Empty, Convert.ToInt32(ViewState["ProductId"]), false);

                    if (lstClsProductDetail.Count > 0)
                    {
                        DataRow dr2 = dt.NewRow();
                        dr2["IngredientPrice"] = objtpProductProperties.pp_double_ingredients_price;
                        dt.Rows.Add(dr2);
                    }


                    if (dt != null && dt.Rows.Count > 0)
                    {

                        IngredientDiv.Style.Add("display", "block");
                        IngredientDiv.Visible = true;
                        rptIngredients.DataSource = dt;
                        rptIngredients.DataBind();

                    }
                    else
                    {


                        rptIngredients.DataSource = null;
                        rptIngredients.DataBind();
                        rptIngredients.Visible = false;
                    }
                }
            }

            else if (ViewState["CategoryName"].ToString() == "Fresh Salads")
            {
                ClsProductSizes objClsProductSize = new ClsProductSizes();
                tp_product_details objtpProductDetails = new tp_product_details();

                objtpProductDetails = objClsProductSize.GetIngredientPriceByProductId(Convert.ToInt32(ViewState["ProductId"]));

                if (objtpProductDetails != null)
                {
                    DataTable dt = new DataTable();

                    DataColumn dc = new DataColumn("IngredientPrice");
                    dt.Columns.Add(dc);
                    DataRow dr1 = dt.NewRow();

                    dr1["IngredientPrice"] = objtpProductDetails.pp_base_single_ingredients_price;
                    dt.Rows.Add(dr1);

                    lstClsProductDetail = objClsProductDetail.GetAllIngredientByPrice(string.Empty, Convert.ToInt32(ViewState["ProductId"]), false);

                    if (lstClsProductDetail.Count > 0)
                    {
                        DataRow dr2 = dt.NewRow();
                        dr2["IngredientPrice"] = objtpProductDetails.pp_base_double_ingredients_price;
                        dt.Rows.Add(dr2);
                    }

                    if (dt != null && dt.Rows.Count > 0)
                    {

                        IngredientDiv.Style.Add("display", "block");
                        IngredientDiv.Visible = true;
                        rptIngredients.DataSource = dt;
                        rptIngredients.DataBind();

                    }
                    else
                    {
                        rptIngredients.DataSource = null;
                        rptIngredients.DataBind();
                        rptIngredients.Visible = false;
                    }
                }
            }
            else
            {
                ClsProductSizes objClsProductSize = new ClsProductSizes();
                tp_product_details objtpProductDetails = new tp_product_details();

                objtpProductDetails = objClsProductSize.GetIngredientPriceByProductId(Convert.ToInt32(ViewState["ProductId"]));

                if (objtpProductDetails != null)
                {
                    DataTable dt = new DataTable();

                    DataColumn dc = new DataColumn("IngredientPrice");
                    dt.Columns.Add(dc);
                    DataRow dr1 = dt.NewRow();

                    dr1["IngredientPrice"] = objtpProductDetails.pp_base_single_ingredients_price;
                    dt.Rows.Add(dr1);

                    if (objtpProductDetails.pp_base_single_ingredients_price != objtpProductDetails.pp_base_double_ingredients_price)
                    {
                        //DataRow dr2 = dt.NewRow();
                        //dr2["IngredientPrice"] = objtpProductDetails.pp_base_double_ingredients_price;
                        //dt.Rows.Add(dr2);
                        lstClsProductDetail = objClsProductDetail.GetAllIngredientByPrice(string.Empty, Convert.ToInt32(ViewState["ProductId"]), false);

                        if (lstClsProductDetail.Count > 0)
                        {
                            DataRow dr2 = dt.NewRow();
                            dr2["IngredientPrice"] = objtpProductDetails.pp_base_double_ingredients_price;
                            dt.Rows.Add(dr2);
                        }
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {

                        IngredientDiv.Style.Add("display", "block");
                        IngredientDiv.Visible = true;
                        rptIngredients.DataSource = dt;
                        rptIngredients.DataBind();

                    }
                    else
                    {


                        rptIngredients.DataSource = null;
                        rptIngredients.DataBind();
                        rptIngredients.Visible = false;
                    }
                }

            }

        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }



    protected void BindIngredientByPrice(DataList dlIngredientList, string price)
    {
        try
        {
            if (ViewState["ProductId"] != null)
            {
                int productId = Convert.ToInt32(ViewState["ProductId"]);
                List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();

                //if(ViewState["CategoryName"].ToString() == "Tomato’s Pizza" || ViewState["CategoryName"].ToString() == "Gourmet Pizza")
                //{
                if (isSingleIngredients == true)
                {
                    lstClsProductDetail = objClsProductDetail.GetAllIngredientByPrice(price, productId, true);
                    isSingleIngredients = false;
                }
                else if (isSingleIngredients == false)
                {
                    lstClsProductDetail = objClsProductDetail.GetAllIngredientByPrice(price, productId, false);
                    isSingleIngredients = true;
                }

                //}
                //else
                //{
                //    lstClsProductDetail = objClsProductDetail.GetAllIngredientByPrice(price, productId, true);
                //}

                if (lstClsProductDetail.Count > 0)
                {
                    int screenWidth = Convert.ToInt32(myHiddenField.Value);
                    if (screenWidth >= 992 && screenWidth <= 1960)
                    {
                        dlIngredientList.RepeatColumns = 3;
                    }

                    else if (screenWidth >= 600 && screenWidth <= 991)
                    {

                        dlIngredientList.RepeatColumns = 2;

                    }
                    else if (screenWidth >= 240 && screenWidth <= 599)
                    {

                        dlIngredientList.RepeatColumns = 1;

                    }

                    dlIngredientList.DataSource = lstClsProductDetail;
                    dlIngredientList.DataBind();

                }


            }



        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void BindDoubleChargeIngredientByPrice(DataList dlIngredientList, string price)
    {
        try
        {

        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }


    //Cart section Start

    public void GetUserCartDetail()
    {
        ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();
        string sizeName = string.Empty;
        try
        {
            List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
            if (Session["UserId"] != null)
            {
                lstClsProductDetail = objClsCartDetail.GetCartDetail(Convert.ToInt32(Session["UserId"]), "0");
                if (lstClsProductDetail.Count > 0)
                {
                    rptCartDetail.DataSource = lstClsProductDetail;
                    rptCartDetail.DataBind();

                    foreach (RepeaterItem rptItem in rptCartDetail.Items)
                    {
                        Label spancommnet = (Label)rptItem.FindControl("lblComment");
                        Label spanDash = (Label)rptItem.FindControl("lbldash");
                        Label lblCommentCart = (Label)rptItem.FindControl("lblCommentCart");
                        if (lblCommentCart != null)
                        {
                            if (lblCommentCart.Text == "")
                            {
                                if (spancommnet != null)
                                {
                                    spancommnet.Visible = false;
                                }
                                if (spanDash != null)
                                {
                                    spanDash.Visible = false;
                                }
                            }
                        }
                    }
                    int QuantityOfCart = 0;
                    // Session["CartItem"] = lstClsProductDetail.Count.ToString();
                    foreach (var item in lstClsProductDetail)
                    {
                        QuantityOfCart = QuantityOfCart + item.Quantity;
                    }
                    Session["CartItem"] = QuantityOfCart;
                    item_no.InnerHtml = Session["CartItem"].ToString() + " Items";
                }
                else
                {
                    rptCartDetail.DataSource = null;
                    rptCartDetail.DataBind();
                    lblNoSource.Visible = true;
                    footerLabels.Style.Add("display", "none");
                    Session["CartItem"] = "0";
                    item_no.InnerHtml = Session["CartItem"].ToString() + " Items";
                }
                //foreach(RepeaterItem item in rptCartDetail)
                //{
                //    Label
                //}

            }
            else if (Session["RandomNumber"] != null)
            {
                //lstClsProductDetail = objClsCartDetail.GetCartDetail(1, "0");

                //lstClsProductDetail = objClsCartDetail.GetCartDetail(1, "791012");
                lstClsProductDetail = objClsCartDetail.GetCartDetail(0, Session["RandomNumber"].ToString());
                if (lstClsProductDetail.Count > 0)
                {
                    rptCartDetail.DataSource = lstClsProductDetail;
                    rptCartDetail.DataBind();

                    foreach (RepeaterItem rptItem in rptCartDetail.Items)
                    {
                        Label spancommnet = (Label)rptItem.FindControl("lblComment");
                        Label spanDash = (Label)rptItem.FindControl("lbldash");
                        Label lblCommentCart = (Label)rptItem.FindControl("lblCommentCart");
                        if (lblCommentCart != null)
                        {
                            if (lblCommentCart.Text == "")
                            {
                                if (spancommnet != null)
                                {
                                    spancommnet.Visible = false;
                                }
                                if (spanDash != null)
                                {
                                    spanDash.Visible = false;
                                }
                            }
                        }
                    }
                    int QuantityOfCart = 0;
                    // Session["CartItem"] = lstClsProductDetail.Count.ToString();
                    foreach (var item in lstClsProductDetail)
                    {
                        QuantityOfCart = QuantityOfCart + item.Quantity;
                    }
                    Session["CartItem"] = QuantityOfCart;
                    item_no.InnerHtml = Session["CartItem"].ToString() + " Items";

                }
                else
                {
                    rptCartDetail.DataSource = null;
                    rptCartDetail.DataBind();
                    lblNoSource.Visible = true;
                    footerLabels.Style.Add("display", "none");
                    Session["CartItem"] = "0";
                    item_no.InnerHtml = Session["CartItem"].ToString() + " Items";
                }



            }
            else
            {
                rptCartDetail.DataSource = null;
                rptCartDetail.DataBind();
                lblNoSource.Visible = true;
                footerLabels.Style.Add("display", "none");
                Session["CartItem"] = "0";
                item_no.InnerHtml = Session["CartItem"].ToString() + " Items";
            }

        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        try
        {
            txtComment.BorderColor = System.Drawing.Color.White;
            bool FlagComment = false;
            bool? IsCommentCompulsary = objClsProductDetail.GetCommentCompulsoryValueByProductId(Convert.ToInt32(ViewState["ProductId"]));
            if (IsCommentCompulsary == true)
            {
                if (txtComment.Text == "Please provide details for this item" || txtComment.Text == "")
                {
                    txtComment.BorderColor = System.Drawing.Color.Red;
                    txtComment.ForeColor = System.Drawing.Color.Red;
                    FlagComment = true;
                }
            }
            else
            {
                if (txtComment.Text == "Please provide details for this item")
                {
                    txtComment.Text = "";
                }
                FlagComment = false;
            }

            if (FlagComment == false)
            {
                int productId = 0, sizeId = 0, propertyId = 0, updatedQuantity = 0, factId = 0, count = 0;
                string randomNumber = null, totalPrice = null, retMsg = null, categoryId = null, updatedprice = null;
                decimal updatedPrice = 0, ingredientPrice = 0, productPrice = 0;
                bool flag = false;
                //int productId = 0, sizeId = 0, propertyId = 0, factId = 0;
                //string randomNumber = null, totalPrice = null, retMsg = null, categoryId = null;
                //decimal ingredientPrice = 0, productPrice = 0;


                if (Session["UserEmail"] != null)
                {
                    List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
                    if (ViewState["ProductId"] != null)
                    {
                        productId = Convert.ToInt32(ViewState["ProductId"]);
                        if (ViewState["SizeId"] != null)
                        {
                            sizeId = Convert.ToInt32(ViewState["SizeId"]);
                        }
                        if (productId != 0 && sizeId != 0)
                        {
                            lstClsProductDetail = objClsProductDetail.GetPropertyId(productId, sizeId);
                            if (lstClsProductDetail.Count > 0)
                            {
                                foreach (var item in lstClsProductDetail)
                                {
                                    propertyId = item.PropertiesId;
                                    productPrice = Convert.ToDecimal(item.PropertiesPrice);

                                }
                            }

                        }
                        else
                        {
                            propertyId = 0;
                            productPrice = Convert.ToDecimal(objClsProductDetail.GetProductPriceByProductId(productId));
                        }
                        if (ViewState["FactId"] != null)
                        {
                            factId = Convert.ToInt32(ViewState["FactId"]);
                        }
                        List<ClsCartDetail> lstExtraIngredients = new List<ClsCartDetail>();
                        foreach (RepeaterItem rptitems in rptIngredients.Items)
                        {
                            DataList dlIngredientList = (DataList)rptitems.FindControl("dlIngredientList");
                            if (dlIngredientList != null)
                            {
                                foreach (DataListItem dlrowitems in dlIngredientList.Items)
                                {
                                    CheckBox chkIngredient = (CheckBox)dlrowitems.FindControl("chkIngredient");
                                    if (chkIngredient != null)
                                    {
                                        if (chkIngredient.Checked == true)
                                        {
                                            ClsCartDetail ClsCartDetailobj = new ClsCartDetail();

                                            Label lblIngredientId = (Label)dlrowitems.FindControl("lblIngredientId");
                                            Label lblIngredientPrice = (Label)rptitems.FindControl("lblIngredientPrice");
                                            if (lblIngredientId != null)
                                            {
                                                ClsCartDetailobj.IngredientId = Convert.ToInt32(lblIngredientId.Text);
                                                ClsCartDetailobj.IngredientPrice = lblIngredientPrice.Text.Trim();

                                                string FactName = objClsProductDetail.GetFactNameByFactId(Convert.ToInt32(ViewState["FactId"]));
                                                if (FactName == "Half & half")
                                                {
                                                    ingredientPrice = ingredientPrice + (Convert.ToDecimal(ClsCartDetailobj.IngredientPrice) / 2);
                                                }
                                                else
                                                {
                                                    ingredientPrice = ingredientPrice + Convert.ToDecimal(ClsCartDetailobj.IngredientPrice);
                                                }
                                            }


                                            lstExtraIngredients.Add(ClsCartDetailobj);
                                        }
                                    }
                                }
                            }
                        }
                        lstClsProductDetail = objClsCartDetail.GetCartDetail(Convert.ToInt32(Session["UserId"]), "0");
                        if (lstClsProductDetail.Count > 0)
                        {
                            foreach (var item in lstClsProductDetail)
                            {
                                if (productId == item.ProductdetailId && sizeId == item.SizeId && factId == item.IngredientFactId)
                                {
                                    flag = true;
                                    ViewState["CartId"] = Convert.ToInt32(item.CartId);
                                    ViewState["Quantity"] = Convert.ToInt32(item.Quantity);
                                    ViewState["Price"] = Convert.ToDecimal(item.Price);
                                }

                            }


                            if (flag == true)
                            {
                                DataTable dt = new DataTable();
                                dt = objClsCartDetail.GetExtraIngredientsForCart(Convert.ToInt32(ViewState["CartId"]));
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dt.Rows)
                                    {
                                        foreach (var items in lstExtraIngredients)
                                        {
                                            if (Convert.ToInt32(items.IngredientId) == Convert.ToInt32(dr["IngredientId"]))
                                            {
                                                count = count + 1;
                                            }
                                        }
                                    }
                                    if (count == lstExtraIngredients.Count)
                                    {
                                        updatedQuantity = Convert.ToInt32(ViewState["Quantity"]) + 1;
                                        updatedPrice = Convert.ToDecimal(updatedQuantity) * Convert.ToDecimal(ViewState["Price"]);
                                        updatedprice = Convert.ToString(updatedPrice);
                                        retMsg = objClsCartDetail.UpdateCommentByCartId(Convert.ToInt32(ViewState["CartId"]), txtComment.Text);
                                        retMsg = objClsCartDetail.UpdateCartDetail(Convert.ToInt32(ViewState["CartId"]), productId, Convert.ToInt32(Session["UserId"]), sizeId, propertyId, updatedQuantity, updatedprice, 0, "0");
                                        if (retMsg == "SUCCESS")
                                        {
                                            categoryId = ViewState["CategoryId"].ToString();
                                            string url = "~/OrderOnline.aspx?CategoryId=" + HttpUtility.UrlEncode(EncryptString(categoryId));
                                            Response.Redirect(url, false);
                                        }

                                    }
                                    else
                                    {
                                        totalPrice = Convert.ToString(productPrice + ingredientPrice);
                                        retMsg = objClsCartDetail.InsertCartDetail(productId, Convert.ToInt32(Session["UserId"]), sizeId, propertyId, 1, totalPrice, factId, "0", lstExtraIngredients.ToList(), txtComment.Text);
                                        if (retMsg == "SUCCESS")
                                        {
                                            if (Session["CartItem"] == null)
                                            {
                                                Session["CartItem"] = "1";
                                            }
                                            else
                                            {
                                                Session["CartItem"] = Convert.ToInt32(Session["CartItem"].ToString()) + 1;
                                            }
                                            item_no.InnerHtml = Session["CartItem"].ToString() + " Items";
                                            categoryId = ViewState["CategoryId"].ToString();
                                            string url = "~/OrderOnline.aspx?CategoryId=" + HttpUtility.UrlEncode(EncryptString(categoryId));
                                            Response.Redirect(url, false);
                                        }
                                    }
                                }
                            }
                            else if (flag == false)
                            {
                                totalPrice = Convert.ToString(productPrice + ingredientPrice);
                                retMsg = objClsCartDetail.InsertCartDetail(productId, Convert.ToInt32(Session["UserId"]), sizeId, propertyId, 1, totalPrice, factId, "0", lstExtraIngredients.ToList(), txtComment.Text);
                                if (retMsg == "SUCCESS")
                                {
                                    if (Session["CartItem"] == null)
                                    {
                                        Session["CartItem"] = "1";
                                    }
                                    else
                                    {
                                        Session["CartItem"] = Convert.ToInt32(Session["CartItem"].ToString()) + 1;
                                    }
                                    item_no.InnerHtml = Session["CartItem"].ToString() + " Items";
                                    categoryId = ViewState["CategoryId"].ToString();
                                    string url = "~/OrderOnline.aspx?CategoryId=" + HttpUtility.UrlEncode(EncryptString(categoryId));
                                    Response.Redirect(url, false);
                                }
                            }
                        }
                        else
                        {
                            totalPrice = Convert.ToString(productPrice + ingredientPrice);
                            retMsg = objClsCartDetail.InsertCartDetail(productId, Convert.ToInt32(Session["UserId"]), sizeId, propertyId, 1, totalPrice, factId, "0", lstExtraIngredients.ToList(), txtComment.Text);
                            if (retMsg == "SUCCESS")
                            {
                                if (Session["CartItem"] == null)
                                {
                                    Session["CartItem"] = "1";
                                }
                                else
                                {
                                    Session["CartItem"] = Convert.ToInt32(Session["CartItem"].ToString()) + 1;
                                }
                                item_no.InnerHtml = Session["CartItem"].ToString() + " Items";
                                categoryId = ViewState["CategoryId"].ToString();
                                string url = "~/OrderOnline.aspx?CategoryId=" + HttpUtility.UrlEncode(EncryptString(categoryId));
                                Response.Redirect(url, false);
                            }
                        }


                    }
                }
                else
                {
                    List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();



                    if (ViewState["ProductId"] != null)
                    {
                        productId = Convert.ToInt32(ViewState["ProductId"]);
                        if (ViewState["SizeId"] != null)
                        {
                            sizeId = Convert.ToInt32(ViewState["SizeId"]);
                        }
                        if (productId != 0 && sizeId != 0)
                        {
                            lstClsProductDetail = objClsProductDetail.GetPropertyId(productId, sizeId);
                            if (lstClsProductDetail.Count > 0)
                            {
                                foreach (var item in lstClsProductDetail)
                                {
                                    propertyId = item.PropertiesId;
                                    productPrice = Convert.ToDecimal(item.PropertiesPrice);

                                }
                            }

                        }
                        else
                        {
                            propertyId = 0;
                            productPrice = Convert.ToDecimal(objClsProductDetail.GetProductPriceByProductId(productId));
                        }
                        if (Session["RandomNumber"] == null)
                        {
                            Random generator = new Random();
                            randomNumber = generator.Next(0, 1000000).ToString("D6");
                            Session["RandomNumber"] = randomNumber;
                        }
                        else
                        {
                            randomNumber = Session["RandomNumber"].ToString();
                        }
                        if (ViewState["FactId"] != null)
                        {
                            factId = Convert.ToInt32(ViewState["FactId"]);
                        }
                        List<ClsCartDetail> lstExtraIngredients = new List<ClsCartDetail>();
                        foreach (RepeaterItem rptitems in rptIngredients.Items)
                        {
                            //Label lblIngredientPrice = (Label)rptitems.FindControl("lblIngredientPrice");
                            DataList dlIngredientList = (DataList)rptitems.FindControl("dlIngredientList");
                            if (dlIngredientList != null)
                            {
                                foreach (DataListItem dlrowitems in dlIngredientList.Items)
                                {
                                    CheckBox chkIngredient = (CheckBox)dlrowitems.FindControl("chkIngredient");

                                    if (chkIngredient != null)
                                    {
                                        if (chkIngredient.Checked == true)
                                        {
                                            ClsCartDetail ClsCartDetailobj = new ClsCartDetail();

                                            Label lblIngredientId = (Label)dlrowitems.FindControl("lblIngredientId");
                                            Label lblIngredientPrice = (Label)rptitems.FindControl("lblIngredientPrice");
                                            if (lblIngredientId != null)
                                            {
                                                ClsCartDetailobj.IngredientId = Convert.ToInt32(lblIngredientId.Text);
                                                ClsCartDetailobj.IngredientPrice = lblIngredientPrice.Text.Trim();
                                                // ingredientPrice = ingredientPrice + Convert.ToDecimal(ClsCartDetailobj.IngredientPrice);
                                                string FactName = objClsProductDetail.GetFactNameByFactId(Convert.ToInt32(ViewState["FactId"]));
                                                if (FactName == "Half & half")
                                                {
                                                    ingredientPrice = ingredientPrice + (Convert.ToDecimal(ClsCartDetailobj.IngredientPrice) / 2);
                                                }
                                                else
                                                {
                                                    ingredientPrice = ingredientPrice + Convert.ToDecimal(ClsCartDetailobj.IngredientPrice);
                                                }
                                            }


                                            lstExtraIngredients.Add(ClsCartDetailobj);
                                        }
                                    }
                                }
                            }
                        }

                        lstClsProductDetail = objClsCartDetail.GetCartDetail(0, Session["RandomNumber"].ToString());
                        if (lstClsProductDetail.Count > 0)
                        {
                            foreach (var item in lstClsProductDetail)
                            {
                                if (productId == item.ProductdetailId && sizeId == item.SizeId && factId == item.IngredientFactId)
                                {
                                    flag = true;
                                    ViewState["CartId"] = Convert.ToInt32(item.CartId);
                                    ViewState["Quantity"] = Convert.ToInt32(item.Quantity);
                                    ViewState["Price"] = Convert.ToDecimal(item.Price);
                                }

                            }

                            if (flag == true)
                            {
                                DataTable dt = new DataTable();
                                dt = objClsCartDetail.GetExtraIngredientsForCart(Convert.ToInt32(ViewState["CartId"]));
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dt.Rows)
                                    {
                                        foreach (var items in lstExtraIngredients)
                                        {
                                            if (Convert.ToInt32(items.IngredientId) == Convert.ToInt32(dr["IngredientId"]))
                                            {
                                                count = count + 1;
                                            }
                                        }
                                    }
                                    if (count == lstExtraIngredients.Count)
                                    {
                                        updatedQuantity = Convert.ToInt32(ViewState["Quantity"]) + 1;
                                        updatedPrice = Convert.ToDecimal(updatedQuantity) * Convert.ToDecimal(ViewState["Price"]);
                                        updatedprice = Convert.ToString(updatedPrice);
                                        retMsg = objClsCartDetail.UpdateCommentByCartId(Convert.ToInt32(ViewState["CartId"]), txtComment.Text);
                                        retMsg = objClsCartDetail.UpdateCartDetail(Convert.ToInt32(ViewState["CartId"]), productId, 0, sizeId, propertyId, updatedQuantity, updatedprice, 0, randomNumber);
                                        if (retMsg == "SUCCESS")
                                        {
                                            categoryId = ViewState["CategoryId"].ToString();
                                            string url = "~/OrderOnline.aspx?CategoryId=" + HttpUtility.UrlEncode(EncryptString(categoryId));
                                            Response.Redirect(url, false);
                                        }

                                    }
                                    else
                                    {
                                        totalPrice = Convert.ToString(productPrice + ingredientPrice);
                                        retMsg = objClsCartDetail.InsertCartDetail(productId, 0, sizeId, propertyId, 1, totalPrice, factId, randomNumber, lstExtraIngredients.ToList(), txtComment.Text);
                                        if (retMsg == "SUCCESS")
                                        {
                                            if (Session["CartItem"] == null)
                                            {
                                                Session["CartItem"] = "1";
                                            }
                                            else
                                            {
                                                Session["CartItem"] = Convert.ToInt32(Session["CartItem"].ToString()) + 1;
                                            }
                                            item_no.InnerHtml = Session["CartItem"].ToString() + " Items";
                                            categoryId = ViewState["CategoryId"].ToString();
                                            string url = "~/OrderOnline.aspx?CategoryId=" + HttpUtility.UrlEncode(EncryptString(categoryId));
                                            Response.Redirect(url, false);
                                        }
                                    }
                                }
                            }
                            else if (flag == false)
                            {
                                totalPrice = Convert.ToString(productPrice + ingredientPrice);
                                retMsg = objClsCartDetail.InsertCartDetail(productId, 0, sizeId, propertyId, 1, totalPrice, factId, randomNumber, lstExtraIngredients.ToList(), txtComment.Text);
                                if (retMsg == "SUCCESS")
                                {
                                    if (Session["CartItem"] == null)
                                    {
                                        Session["CartItem"] = "1";
                                    }
                                    else
                                    {
                                        Session["CartItem"] = Convert.ToInt32(Session["CartItem"].ToString()) + 1;
                                    }
                                    item_no.InnerHtml = Session["CartItem"].ToString() + " Items";
                                    categoryId = ViewState["CategoryId"].ToString();
                                    string url = "~/OrderOnline.aspx?CategoryId=" + HttpUtility.UrlEncode(EncryptString(categoryId));
                                    Response.Redirect(url, false);
                                }
                            }
                        }
                        else
                        {
                            totalPrice = Convert.ToString(productPrice + ingredientPrice);
                            retMsg = objClsCartDetail.InsertCartDetail(productId, 0, sizeId, propertyId, 1, totalPrice, factId, randomNumber, lstExtraIngredients.ToList(), txtComment.Text);
                            if (retMsg == "SUCCESS")
                            {
                                if (Session["CartItem"] == null)
                                {
                                    Session["CartItem"] = "1";
                                }
                                else
                                {
                                    Session["CartItem"] = Convert.ToInt32(Session["CartItem"].ToString()) + 1;
                                }
                                item_no.InnerHtml = Session["CartItem"].ToString() + " Items";
                                categoryId = ViewState["CategoryId"].ToString();
                                string url = "~/OrderOnline.aspx?CategoryId=" + HttpUtility.UrlEncode(EncryptString(categoryId));
                                Response.Redirect(url, false);
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
    protected void btnYes_Click(object sender, EventArgs e)
    {
        try
        {
            txtComment.BorderColor = System.Drawing.Color.White;
            bool FlagComment = false;
            bool? IsCommentCompulsary = objClsProductDetail.GetCommentCompulsoryValueByProductId(Convert.ToInt32(ViewState["ProductId"]));
            if (IsCommentCompulsary == true)
            {
                if (txtComment.Text == "Please provide details for this item" || txtComment.Text == "")
                {
                    txtComment.BorderColor = System.Drawing.Color.Red;
                    txtComment.ForeColor = System.Drawing.Color.Red;
                    FlagComment = true;
                }
            }
            else
            {
                if (txtComment.Text == "Please provide details for this item")
                {
                    txtComment.Text = "";
                }
                FlagComment = false;
            }

            if (FlagComment == false)
            {
                int productId = 0, sizeId = 0, propertyId = 0, updatedQuantity = 0;
                string randomNumber = null, price = null, retMsg = null, categoryId = null, updatedprice = null;
                decimal updatedPrice = 0;
                bool flag = false;

                if (Session["UserEmail"] != null)
                {
                    List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
                    if (ViewState["ProductId"] != null)
                    {
                        productId = Convert.ToInt32(ViewState["ProductId"]);
                        if (ViewState["SizeId"] != null)
                        {
                            sizeId = Convert.ToInt32(ViewState["SizeId"]);
                        }
                        if (productId != 0 && sizeId != 0)
                        {
                            lstClsProductDetail = objClsProductDetail.GetPropertyId(productId, sizeId);
                            if (lstClsProductDetail.Count > 0)
                            {
                                foreach (var item in lstClsProductDetail)
                                {
                                    propertyId = item.PropertiesId;
                                    price = item.PropertiesPrice;

                                }
                            }

                        }
                        else
                        {
                            propertyId = 0;
                            price = objClsProductDetail.GetProductPriceByProductId(productId);
                        }

                        lstClsProductDetail = objClsCartDetail.GetCartDetail(Convert.ToInt32(Session["UserId"]), "0");
                        if (lstClsProductDetail.Count > 0)
                        {
                            foreach (var item in lstClsProductDetail)
                            {
                                if (productId == item.ProductdetailId && sizeId == item.SizeId)
                                {

                                    flag = true;
                                    ViewState["CartId"] = Convert.ToInt32(item.CartId);
                                    ViewState["Quantity"] = Convert.ToInt32(item.Quantity);
                                    ViewState["Price"] = Convert.ToDecimal(item.Price);
                                }

                            }


                            if (flag == true)
                            {
                                updatedQuantity = Convert.ToInt32(ViewState["Quantity"]) + 1;
                                updatedPrice = Convert.ToDecimal(updatedQuantity) * Convert.ToDecimal(ViewState["Price"]);
                                updatedprice = Convert.ToString(updatedPrice);
                                if (ViewState["CartId"] != null)
                                {
                                    retMsg = objClsCartDetail.UpdateCartDetail(Convert.ToInt32(ViewState["CartId"]), productId, Convert.ToInt32(Session["UserId"]), sizeId, propertyId, updatedQuantity, updatedprice, 0, "0");
                                }
                                if (retMsg == "SUCCESS")
                                {
                                    if (ViewState["CategoryId"] != null)
                                    {
                                        categoryId = ViewState["CategoryId"].ToString();
                                    }
                                    string url = "~/OrderOnline.aspx?CategoryId=" + HttpUtility.UrlEncode(EncryptString(categoryId));
                                    Response.Redirect(url, false);
                                }
                            }
                            else if (flag == false)
                            {
                                retMsg = objClsCartDetail.InsertCartDetail(productId, Convert.ToInt32(Session["UserId"]), sizeId, propertyId, 1, price, 0, "0", null, txtComment.Text);
                                if (retMsg == "SUCCESS")
                                {
                                    if (Session["CartItem"] == null)
                                    {
                                        Session["CartItem"] = "1";
                                    }
                                    else
                                    {
                                        Session["CartItem"] = Convert.ToInt32(Session["CartItem"].ToString()) + 1;
                                    }
                                    item_no.InnerHtml = Session["CartItem"].ToString() + " Items";
                                    if (ViewState["CategoryId"] != null)
                                    {
                                        categoryId = ViewState["CategoryId"].ToString();
                                    }
                                    string url = "~/OrderOnline.aspx?CategoryId=" + HttpUtility.UrlEncode(EncryptString(categoryId));
                                    Response.Redirect(url, false);
                                }
                            }

                        }
                        else
                        {
                            retMsg = objClsCartDetail.InsertCartDetail(productId, Convert.ToInt32(Session["UserId"]), sizeId, propertyId, 1, price, 0, "0", null, txtComment.Text);
                            if (retMsg == "SUCCESS")
                            {
                                if (Session["CartItem"] == null)
                                {
                                    Session["CartItem"] = "1";
                                }
                                else
                                {
                                    Session["CartItem"] = Convert.ToInt32(Session["CartItem"].ToString()) + 1;
                                }
                                item_no.InnerHtml = Session["CartItem"].ToString() + " Items";
                                if (ViewState["CategoryId"] != null)
                                {
                                    categoryId = ViewState["CategoryId"].ToString();
                                }
                                string url = "~/OrderOnline.aspx?CategoryId=" + HttpUtility.UrlEncode(EncryptString(categoryId));
                                Response.Redirect(url, false);
                            }
                        }




                    }
                }
                else
                {
                    List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
                    if (ViewState["ProductId"] != null)
                    {
                        productId = Convert.ToInt32(ViewState["ProductId"]);
                        if (ViewState["SizeId"] != null)
                        {
                            sizeId = Convert.ToInt32(ViewState["SizeId"]);
                        }
                        if (productId != 0 && sizeId != 0)
                        {
                            lstClsProductDetail = objClsProductDetail.GetPropertyId(productId, sizeId);
                            if (lstClsProductDetail.Count > 0)
                            {
                                foreach (var item in lstClsProductDetail)
                                {
                                    propertyId = item.PropertiesId;
                                    price = item.PropertiesPrice;

                                }
                            }

                        }
                        else
                        {
                            propertyId = 0;
                            price = objClsProductDetail.GetProductPriceByProductId(productId);
                        }
                        if (Session["RandomNumber"] == null)
                        {
                            Random generator = new Random();
                            randomNumber = generator.Next(0, 1000000).ToString("D6");
                            Session["RandomNumber"] = randomNumber;
                        }
                        else
                        {
                            randomNumber = Session["RandomNumber"].ToString();
                        }

                        lstClsProductDetail = objClsCartDetail.GetCartDetail(0, Session["RandomNumber"].ToString());
                        if (lstClsProductDetail.Count > 0)
                        {
                            foreach (var item in lstClsProductDetail)
                            {
                                if (productId == item.ProductdetailId && sizeId == item.SizeId)
                                {

                                    flag = true;
                                    ViewState["CartId"] = Convert.ToInt32(item.CartId);
                                    ViewState["Quantity"] = Convert.ToInt32(item.Quantity);
                                    ViewState["Price"] = Convert.ToDecimal(item.Price);
                                }

                            }


                            if (flag == true)
                            {
                                updatedQuantity = Convert.ToInt32(ViewState["Quantity"]) + 1;
                                updatedPrice = Convert.ToDecimal(updatedQuantity) * Convert.ToDecimal(ViewState["Price"]);
                                updatedprice = Convert.ToString(updatedPrice);
                                if (ViewState["CartId"] != null)
                                {
                                    retMsg = objClsCartDetail.UpdateCartDetail(Convert.ToInt32(ViewState["CartId"]), productId, 0, sizeId, propertyId, updatedQuantity, updatedprice, 0, randomNumber);
                                }
                                if (retMsg == "SUCCESS")
                                {
                                    if (ViewState["CategoryId"] != null)
                                    {
                                        categoryId = ViewState["CategoryId"].ToString();
                                    }
                                    string url = "~/OrderOnline.aspx?CategoryId=" + HttpUtility.UrlEncode(EncryptString(categoryId));
                                    Response.Redirect(url, false);
                                }
                            }
                            else if (flag == false)
                            {
                                retMsg = objClsCartDetail.InsertCartDetail(productId, 0, sizeId, propertyId, 1, price, 0, randomNumber, null, txtComment.Text);
                                if (retMsg == "SUCCESS")
                                {
                                    if (Session["CartItem"] == null)
                                    {
                                        Session["CartItem"] = "1";
                                    }
                                    else
                                    {
                                        Session["CartItem"] = Convert.ToInt32(Session["CartItem"].ToString()) + 1;
                                    }
                                    item_no.InnerHtml = Session["CartItem"].ToString() + " Items";
                                    if (ViewState["CategoryId"] != null)
                                    {
                                        categoryId = ViewState["CategoryId"].ToString();
                                    }
                                    string url = "~/OrderOnline.aspx?CategoryId=" + HttpUtility.UrlEncode(EncryptString(categoryId));
                                    Response.Redirect(url, false);
                                }
                            }

                        }
                        else
                        {
                            retMsg = objClsCartDetail.InsertCartDetail(productId, 0, sizeId, propertyId, 1, price, 0, randomNumber, null, txtComment.Text);
                            if (retMsg == "SUCCESS")
                            {
                                if (Session["CartItem"] == null)
                                {
                                    Session["CartItem"] = "1";
                                }
                                else
                                {
                                    Session["CartItem"] = Convert.ToInt32(Session["CartItem"].ToString()) + 1;
                                }
                                item_no.InnerHtml = Session["CartItem"].ToString() + " Items";
                                categoryId = ViewState["CategoryId"].ToString();
                                string url = "~/OrderOnline.aspx?CategoryId=" + HttpUtility.UrlEncode(EncryptString(categoryId));
                                Response.Redirect(url, false);
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

    protected void btnNo_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (DataListItem item in dlCategory.Items)
            {
                Label lblCategoryId = (Label)item.FindControl("lblCategoryId");
                if (lblCategoryId.Text.Trim() == ViewState["CategoryId"].ToString())
                {

                    LinkButton lnkCategoryName = (LinkButton)item.FindControl("lnkCategoryName");
                    lnkCategoryName.CssClass = "highlight";
                }
            }
            //factDiv.Style.Add("display", "none");
            //    ingredient_list.Style.Add("display", "none");
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }



    protected void btnJustAddToCart_Click(object sender, EventArgs e)
    {

        try
        {
            txtComment.BorderColor = System.Drawing.Color.White;
            ProductName = objClsProductDetail.GetProductNameByProductId(Convert.ToInt32(ViewState["ProductId"]));
            //pname.InnerHtml = ProductName;
            bool? CanComment = objClsProductDetail.GetCanCommentValueByProductId(Convert.ToInt32(ViewState["ProductId"].ToString()));

            if (CanComment == true)
            {
                List<ClsProductDetail> lstClsProductDetail1 = new List<ClsProductDetail>();
                //change to ingredient
                lstClsProductDetail1 = objClsProductDetail.GetIndredientFactDetailByProductId(Convert.ToInt32(ViewState["ProductId"]));
                if (lstClsProductDetail1.Count > 0)
                {
                    //factDiv.Style.Add("display", "block");
                    //ingredient_list.Style.Add("display", "block");
                    btnJustAddToCart.Visible = true;
                    //    btnFact1.Visible = false;
                    //   btnFact2.Visible = false;
                    btnYes.Visible = false;
                    btnNo.Visible = false;
                    //     Btndiv.Visible = true;
                    //ingredient_list.Visible = true;
                    IngredientDiv.Visible = false;
                    if (ViewState["CategoryName"] == "Fresh Salads")
                    {
                        //         lblMessage.Text = "How would you like your Dressings?";
                    }
                    else if (ViewState["CategoryName"].ToString() == "Gourmet Pizza" || ViewState["CategoryName"].ToString() == "Tomato’s Pizza")
                    {
                        //        lblMessage.Text = "How would you like your toppings?";
                    }
                    else
                    {
                        //        lblMessage.Text = "How would you like your Ingredients?";
                    }

                    // lblMessage.Text = "How would you like your Ingredients?";
                    foreach (var item in lstClsProductDetail1)
                    {
                        //if (btnFact1.Text == item.IngredientFactName.Trim())
                        //{
                        //    btnFact1.Visible = true;
                        //}
                        //else if (btnFact2.Text == item.IngredientFactName.Trim())
                        //{
                        //    btnFact2.Visible = true;
                        //}

                    }
                }
            }
            bool FlagComment = false;
            bool? IsCommentCompulsary = objClsProductDetail.GetCommentCompulsoryValueByProductId(Convert.ToInt32(ViewState["ProductId"]));
            if (IsCommentCompulsary == true)
            {
                if (txtComment.Text == "Please provide details for this item" || txtComment.Text == "")
                {
                    // txtComment.BorderColor = System.Drawing.Color.Red;
                    FlagComment = true;
                }
            }
            else
            {
                if (txtComment.Text == "Please provide details for this item")
                {
                    txtComment.Text = "";
                }
                FlagComment = false;
            }

            if (FlagComment == false)
            {
                int productId = 0, sizeId = 0, propertyId = 0, updatedQuantity = 0, factId = 0;
                string randomNumber = null, price = null, retMsg = null, categoryId = null, updatedprice = null;
                decimal updatedPrice = 0;
                bool flag = false;

                if (Session["UserEmail"] != null)
                {
                    List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
                    if (ViewState["ProductId"] != null)
                    {
                        productId = Convert.ToInt32(ViewState["ProductId"]);
                        if (ViewState["SizeId"] != null)
                        {
                            sizeId = Convert.ToInt32(ViewState["SizeId"]);
                        }
                        if (productId != 0 && sizeId != 0)
                        {
                            lstClsProductDetail = objClsProductDetail.GetPropertyId(productId, sizeId);
                            if (lstClsProductDetail.Count > 0)
                            {
                                foreach (var item in lstClsProductDetail)
                                {
                                    propertyId = item.PropertiesId;
                                    price = item.PropertiesPrice;

                                }
                            }

                        }
                        else
                        {
                            propertyId = 0;
                            price = objClsProductDetail.GetProductPriceByProductId(productId);
                        }
                        lstClsProductDetail = objClsCartDetail.GetCartDetail(Convert.ToInt32(Session["UserId"]), "0");
                        if (lstClsProductDetail.Count > 0)
                        {
                            foreach (var item in lstClsProductDetail)
                            {
                                if (productId == item.ProductdetailId && sizeId == item.SizeId && factId == item.IngredientFactId)
                                {

                                    flag = true;
                                    ViewState["CartId"] = Convert.ToInt32(item.CartId);
                                    ViewState["Quantity"] = Convert.ToInt32(item.Quantity);
                                    ViewState["Price"] = Convert.ToDecimal(item.Price);
                                }

                            }


                            if (flag == true)
                            {
                                updatedQuantity = Convert.ToInt32(ViewState["Quantity"]) + 1;
                                updatedPrice = Convert.ToDecimal(updatedQuantity) * Convert.ToDecimal(ViewState["Price"]);
                                updatedprice = Convert.ToString(updatedPrice);
                                retMsg = objClsCartDetail.UpdateCommentByCartId(Convert.ToInt32(ViewState["CartId"]), txtComment.Text);
                                retMsg = objClsCartDetail.UpdateCartDetail(Convert.ToInt32(ViewState["CartId"]), productId, Convert.ToInt32(Session["UserId"]), sizeId, propertyId, updatedQuantity, updatedprice, 0, "0");
                                if (retMsg == "SUCCESS")
                                {
                                    categoryId = ViewState["CategoryId"].ToString();
                                    string url = "~/OrderOnline.aspx?CategoryId=" + HttpUtility.UrlEncode(EncryptString(categoryId));
                                    Response.Redirect(url, false);
                                }
                            }
                            else if (flag == false)
                            {
                                retMsg = objClsCartDetail.InsertCartDetail(productId, Convert.ToInt32(Session["UserId"]), sizeId, propertyId, 1, price, 0, "0", null, txtComment.Text);
                                if (retMsg == "SUCCESS")
                                {
                                    if (Session["CartItem"] == null)
                                    {
                                        Session["CartItem"] = "1";
                                    }
                                    else
                                    {
                                        Session["CartItem"] = Convert.ToInt32(Session["CartItem"].ToString()) + 1;
                                    }
                                    item_no.InnerHtml = Session["CartItem"].ToString() + " Items";
                                    categoryId = ViewState["CategoryId"].ToString();
                                    string url = "~/OrderOnline.aspx?CategoryId=" + HttpUtility.UrlEncode(EncryptString(categoryId));
                                    Response.Redirect(url, false);
                                }
                            }

                        }
                        else
                        {
                            retMsg = objClsCartDetail.InsertCartDetail(productId, Convert.ToInt32(Session["UserId"]), sizeId, propertyId, 1, price, 0, "0", null, txtComment.Text);
                            if (retMsg == "SUCCESS")
                            {
                                if (Session["CartItem"] == null)
                                {
                                    Session["CartItem"] = "1";
                                }
                                else
                                {
                                    Session["CartItem"] = Convert.ToInt32(Session["CartItem"].ToString()) + 1;
                                }
                                item_no.InnerHtml = Session["CartItem"].ToString() + " Items";
                                categoryId = ViewState["CategoryId"].ToString();
                                string url = "~/OrderOnline.aspx?CategoryId=" + HttpUtility.UrlEncode(EncryptString(categoryId));
                                Response.Redirect(url, false);
                            }
                        }


                    }

                }
                else
                {
                    List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
                    if (ViewState["ProductId"] != null)
                    {
                        productId = Convert.ToInt32(ViewState["ProductId"]);
                        if (ViewState["SizeId"] != null)
                        {
                            sizeId = Convert.ToInt32(ViewState["SizeId"]);
                        }
                        if (productId != 0 && sizeId != 0)
                        {
                            lstClsProductDetail = objClsProductDetail.GetPropertyId(productId, sizeId);
                            if (lstClsProductDetail.Count > 0)
                            {
                                foreach (var item in lstClsProductDetail)
                                {
                                    propertyId = item.PropertiesId;
                                    price = item.PropertiesPrice;

                                }
                            }
                        }
                        else
                        {
                            propertyId = 0;
                            price = objClsProductDetail.GetProductPriceByProductId(productId);
                        }
                        if (Session["RandomNumber"] == null)
                        {
                            Random generator = new Random();
                            randomNumber = generator.Next(0, 1000000).ToString("D6");
                            Session["RandomNumber"] = randomNumber;
                        }
                        else
                        {
                            randomNumber = Session["RandomNumber"].ToString();
                        }

                        lstClsProductDetail = objClsCartDetail.GetCartDetail(0, Session["RandomNumber"].ToString());
                        if (lstClsProductDetail.Count > 0)
                        {
                            foreach (var item in lstClsProductDetail)
                            {
                                if (productId == item.ProductdetailId && sizeId == item.SizeId && factId == item.IngredientFactId)
                                {

                                    flag = true;
                                    ViewState["CartId"] = Convert.ToInt32(item.CartId);
                                    ViewState["Quantity"] = Convert.ToInt32(item.Quantity);
                                    ViewState["Price"] = Convert.ToDecimal(item.Price);
                                }

                            }


                            if (flag == true)
                            {
                                updatedQuantity = Convert.ToInt32(ViewState["Quantity"]) + 1;
                                updatedPrice = Convert.ToDecimal(updatedQuantity) * Convert.ToDecimal(ViewState["Price"]);
                                updatedprice = Convert.ToString(updatedPrice);
                                retMsg = objClsCartDetail.UpdateCommentByCartId(Convert.ToInt32(ViewState["CartId"]), txtComment.Text);
                                retMsg = objClsCartDetail.UpdateCartDetail(Convert.ToInt32(ViewState["CartId"]), productId, 0, sizeId, propertyId, updatedQuantity, updatedprice, 0, randomNumber);
                                if (retMsg == "SUCCESS")
                                {
                                    categoryId = ViewState["CategoryId"].ToString();
                                    string url = "~/OrderOnline.aspx?CategoryId=" + HttpUtility.UrlEncode(EncryptString(categoryId));
                                    Response.Redirect(url, false);
                                }
                            }
                            else if (flag == false)
                            {
                                retMsg = objClsCartDetail.InsertCartDetail(productId, 0, sizeId, propertyId, 1, price, 0, randomNumber, null, txtComment.Text);
                                if (retMsg == "SUCCESS")
                                {
                                    if (Session["CartItem"] == null)
                                    {
                                        Session["CartItem"] = "1";
                                    }
                                    else
                                    {
                                        Session["CartItem"] = Convert.ToInt32(Session["CartItem"].ToString()) + 1;
                                    }
                                    item_no.InnerHtml = Session["CartItem"].ToString() + " Items";
                                    categoryId = ViewState["CategoryId"].ToString();
                                    string url = "~/OrderOnline.aspx?CategoryId=" + HttpUtility.UrlEncode(EncryptString(categoryId));
                                    Response.Redirect(url, false);
                                }
                            }

                        }
                        else
                        {
                            retMsg = objClsCartDetail.InsertCartDetail(productId, 0, sizeId, propertyId, 1, price, 0, randomNumber, null, txtComment.Text);
                            if (retMsg == "SUCCESS")
                            {
                                if (Session["CartItem"] == null)
                                {
                                    Session["CartItem"] = "1";
                                }
                                else
                                {
                                    Session["CartItem"] = Convert.ToInt32(Session["CartItem"].ToString()) + 1;
                                }
                                item_no.InnerHtml = Session["CartItem"].ToString() + " Items";
                                categoryId = ViewState["CategoryId"].ToString();
                                string url = "~/OrderOnline.aspx?CategoryId=" + HttpUtility.UrlEncode(EncryptString(categoryId));
                                Response.Redirect(url, false);
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

    protected void txtQuantity_TextChanged(object sender, EventArgs e)
    {
        try
        {
            Total = 0;
            string retMsg = string.Empty;
            int QuantityOfCart = 0;
            if (Session["UserEmail"] != null)
            {
                foreach (RepeaterItem items in rptCartDetail.Items)
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
                        lblPrice.Text = "$" + (Convert.ToDecimal(lblOneQuantityPrice.Text) * Convert.ToDecimal(txtQuantity.Text)).ToString();
                        if (txtQuantity.Text != "")
                        {
                            QuantityOfCart = QuantityOfCart + Convert.ToInt32(txtQuantity.Text);
                        }
                        Session["CartItem"] = QuantityOfCart;
                        item_no.InnerHtml = Session["CartItem"].ToString() + " Items";
                    }

                    Label labelPrice = (Label)items.FindControl("lblPrice");
                    if (labelPrice != null)
                    {
                        Total = Total + Convert.ToDecimal(labelPrice.Text.ToString().Replace("$", ""));
                    }

                    retMsg = objClsCartDetail.UpdateCartDetail(Convert.ToInt32(lblCartId.Text.Trim()), Convert.ToInt32(lblProductdetailId.Text.Trim()), Convert.ToInt32(Session["UserId"]), Convert.ToInt32(lblSizeId.Text.Trim()), Convert.ToInt32(lblPropertyId.Text.Trim()), Convert.ToInt32(txtQuantity.Text.Trim()), lblPrice.Text.Replace("$", ""), Convert.ToInt32(lblProductIngredientFactId.Text.Trim()), "0");
                }



                LblTotal.Text = "$" + Total.ToString();
                lblSalesPrice.Text = objClsMiscellaneousSettings.GetTaxConfigSetting().tpc_value;

                decimal tax = (Convert.ToDecimal(lblSalesPrice.Text.ToString().Replace("%", "")) * Convert.ToDecimal(Total)) / 100;

                lblSalesPrice.Text = "$" + tax.ToString().Replace("$", "");
                decimal DisplaysalesTax = (Math.Floor(Convert.ToDecimal(lblSalesPrice.Text.Replace("$", "")) * 100) / 100);

                lblSalesPrice.Text = string.Format("{0:N2}", DisplaysalesTax);
                lblSalesPrice.Text = "$" + lblSalesPrice.Text.ToString().Replace("$", "");
                LblTotalPrice.Text = "$" + (Total + tax + Convert.ToDecimal(lblDeliveryCharges.Text.Replace("$", ""))).ToString();
                decimal DisplayTotalPrice = (Math.Floor(Convert.ToDecimal(LblTotalPrice.Text.Replace("$", "")) * 100) / 100);
                LblTotalPrice.Text = string.Format("{0:N2}", DisplayTotalPrice);
                LblTotalPrice.Text = "$" + LblTotalPrice.Text.Replace("$", "");
                LblTotal.Text = "$" + (LblTotal.Text.Replace("$", ""));

            }
            else
            {
                foreach (RepeaterItem items in rptCartDetail.Items)
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
                        lblPrice.Text = "$" + (Convert.ToDecimal(lblOneQuantityPrice.Text) * Convert.ToDecimal(txtQuantity.Text)).ToString();
                        if (txtQuantity.Text != "")
                        {
                            QuantityOfCart = QuantityOfCart + Convert.ToInt32(txtQuantity.Text);
                        }
                        Session["CartItem"] = QuantityOfCart;
                        item_no.InnerHtml = Session["CartItem"].ToString() + " Items";
                    }

                    Label labelPrice = (Label)items.FindControl("lblPrice");
                    if (labelPrice != null)
                    {
                        Total = Total + Convert.ToDecimal(labelPrice.Text.ToString().Replace("$", ""));
                    }

                    retMsg = objClsCartDetail.UpdateCartDetail(Convert.ToInt32(lblCartId.Text.Trim()), Convert.ToInt32(lblProductdetailId.Text.Trim()), 0, Convert.ToInt32(lblSizeId.Text.Trim()), Convert.ToInt32(lblPropertyId.Text.Trim()), Convert.ToInt32(txtQuantity.Text.Trim()), lblPrice.Text.Replace("$", ""), Convert.ToInt32(lblProductIngredientFactId.Text.Trim()), Session["RandomNumber"].ToString());
                }



                LblTotal.Text = Total.ToString();
                lblSalesPrice.Text = objClsMiscellaneousSettings.GetTaxConfigSetting().tpc_value;

                decimal tax = (Convert.ToDecimal(lblSalesPrice.Text.ToString().Replace("%", "")) * Convert.ToDecimal(Total)) / 100;

                lblSalesPrice.Text = "$" + tax.ToString().Replace("$", "");
                decimal DisplaysalesTax = (Math.Floor(Convert.ToDecimal(lblSalesPrice.Text.Replace("$", "")) * 100) / 100);
                lblSalesPrice.Text = string.Format("{0:N2}", DisplaysalesTax);

                lblSalesPrice.Text = "$" + lblSalesPrice.Text.ToString().Replace("$", "");
                LblTotalPrice.Text = "$" + (Total + tax + Convert.ToDecimal(lblDeliveryCharges.Text.Replace("$", ""))).ToString();
                decimal DisplayTotalPrice = (Math.Floor(Convert.ToDecimal(LblTotalPrice.Text.Replace("$", "")) * 100) / 100);
                LblTotalPrice.Text = string.Format("{0:N2}", DisplayTotalPrice);

                LblTotalPrice.Text = "$" + LblTotalPrice.Text.Replace("$", "");

                LblTotal.Text = "$" + (LblTotal.Text.Replace("$", ""));

            }


        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void rptCartDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            Label lblCartId = (Label)e.Item.FindControl("lblCartId");
            Label lblSpan = (Label)e.Item.FindControl("lblSpan");
            HtmlGenericControl spanText = (HtmlGenericControl)e.Item.FindControl("spanText");
            Label lblProductdetailId = (Label)e.Item.FindControl("lblProductdetailId");
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                string categoryname = objClsCartDetail.GetCategoryByProductId(Convert.ToInt32(lblProductdetailId.Text));

                if (categoryname == "Fresh Salads")
                {
                    spanText.InnerHtml = "Dressings";
                }
                //else if (ViewState["CategoryName"].ToString() == "Gourmet Pizza" || ViewState["CategoryName"].ToString() == "Tomato’s Pizza")
                else
                {
                    spanText.InnerHtml = "Toppings";
                }
            }

            if (lblCartId != null)
            {
                GridView gvExtraIngeredient = (GridView)e.Item.FindControl("gvExtraIngeredient");
                if (gvExtraIngeredient != null)
                {
                    DataTable dt = new DataTable();
                    dt = objClsCartDetail.GetExtraIngredientsForCart(Convert.ToInt32(lblCartId.Text.Trim()));
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        spanText.Style.Add("display", "none");
                        gvExtraIngeredient.DataSource = dt;
                        gvExtraIngeredient.DataBind();
                    }
                    else
                    {
                        spanText.Style.Add("display", "none");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }


    protected void rptCartDetail_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                    //if (retMsg == "SUCCESS")
                    //{
                    //    GetUserCartDetail();
                    //    // GetCustomerList();

                    //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('SuccessFully Deleted')", true);
                    //}
                    if (retMsg == "SUCCESS")
                    {
                        GetUserCartDetail();
                        //SuccessMsgDiv.Style.Add("display", "block");
                        //ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('SuccessFully Deleted')", true);
                        Total = 0;

                        foreach (RepeaterItem items in rptCartDetail.Items)
                        {
                            Label lblPrice = (Label)items.FindControl("lblPrice");
                            if (lblPrice != null)
                            {
                                Total = Total + Convert.ToDecimal(lblPrice.Text.ToString().Replace("$", ""));
                            }
                        }

                        LblTotal.Text = Total.ToString();
                        lblSalesPrice.Text = objClsMiscellaneousSettings.GetTaxConfigSetting().tpc_value;
                        decimal tax = (Convert.ToDecimal(lblSalesPrice.Text.ToString().Replace("%", "")) * Convert.ToDecimal(Total)) / 100;
                        lblSalesPrice.Text = "$" + tax.ToString().Replace("$", "");
                        decimal DisplaysalesTax = (Math.Floor(Convert.ToDecimal(lblSalesPrice.Text.Replace("$", "")) * 100) / 100);
                        lblSalesPrice.Text = string.Format("{0:N2}", DisplaysalesTax);

                        lblSalesPrice.Text = "$" + lblSalesPrice.Text.ToString().Replace("$", "");
                        LblTotalPrice.Text = "$" + (Total + tax + Convert.ToDecimal(lblDeliveryCharges.Text.Replace("$", ""))).ToString();
                        decimal DisplayTotalPrice = (Math.Floor(Convert.ToDecimal(LblTotalPrice.Text.Replace("$", "")) * 100) / 100);
                        LblTotalPrice.Text = string.Format("{0:N2}", DisplayTotalPrice);

                        LblTotalPrice.Text = "$" + LblTotalPrice.Text.Replace("$", "");
                        LblTotal.Text = "$" + (LblTotal.Text.Replace("$", ""));

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
    protected void btnPlaceOrder_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("PlaceOrder.aspx", false);
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
        try
        {
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
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
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
    protected void ddlSizePop_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void rptSize_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {

            if (e.Item.DataItem != null)
            {

                LinkButton lnkClick = (LinkButton)e.Item.FindControl("lnkSize");

                //lnkClick.Attributes["data-toggle"] = "modal";
                //lnkClick.Attributes["data-target"] = "#size-modal";
                lnkClick.Attributes["data-id"] = ((DataRowView)e.Item.DataItem).Row["ProductdetailId"].ToString();
                lnkClick.Attributes["data-id2"] = Convert.ToString(((DataRowView)e.Item.DataItem).Row["ProductName"]);
                //  lnkClick.Attributes["onClick"] = "lnkSize_Click";


            }
        }

        //ddlSizePop.DataSource = ((DataTable)(ViewState["ProductSizeList"]));
        //   ddlSizePop.DataValueField = "SizeId";
        //  ddlSizePop.DataTextField = "SizeName";

    }
    protected void rptProductList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    public void RaisePostBackEvent(string eventArgument)
    {
        throw new NotImplementedException();
    }

    [WebMethod]
    public static string testMethod()
    {

        return "some";
    }

    protected void chkIngredient_CheckedChanged(object sender, EventArgs e)
    {
        var id = ((CheckBox)sender).InputAttributes["value"];

        List<ClsProductDetail> lstClsIngredientDetail = new List<ClsProductDetail>();
        //change to ingredient
        lstClsIngredientDetail = objClsProductDetail.GetIndredientFactDetailByIngredientId(Convert.ToInt32(id));

        // dlIngFactList.DataSource = lstClsIngredientDetail;
        //  dlIngFactList.DataBind();

        if (ViewState["param"] == null || string.IsNullOrEmpty(Convert.ToString(ViewState["param"])))
        {
            List<ClsProductDetail> lstClsProductDetail1 = new List<ClsProductDetail>();
            lstClsProductDetail1 = objClsProductDetail.GetProductSizeDetailByProductId(Convert.ToInt32(hdnSizeInfo.Value));
            DataTable dt1 = lstClsProductDetail1.ListToDataTable();
            string param = "";
            foreach (DataRow dr in dt1.Rows)
            {
                param += dr["SizeId"] + ":" + dr["SizeName"] + ",";
            }
            param = param.Replace("'", "");
            param = param.TrimEnd(',');
            ViewState["param"] = param;
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal('" + ViewState["param"].ToString() + "');", true);
    }

    protected void dlIngredientList_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var item = e.Item.DataItem as ClsProductDetail;
            if (item != null)
            {
                var chk = e.Item.FindControl("chkIngredient") as CheckBox;
                if (chk != null)
                {
                    //chk.Text = item.Name;
                    chk.InputAttributes.Add("value", item.IngredientId.ToString());
                }
            }
        }
    }
    protected void btnPopSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            ddlQuantityPop.BorderColor = System.Drawing.Color.White;
            txtComment.BorderColor = System.Drawing.Color.White;
            if (ddlQuantityPop.SelectedItem.Value == "-1")
            {
                ddlQuantityPop.BorderColor = System.Drawing.Color.Red;
                return;
            }
            //if (txtComment.Visible && (string.IsNullOrEmpty(txtComment.Text) || txtComment.Text == "Please provide details for this item"))
            //{
            //    txtComment.BorderColor = System.Drawing.Color.Red;
            //    return;
            //}
            if (txtComment.Visible && txtComment.Text == "Please provide details for this item")
            {
                txtComment.Text = "";
            }

            int productId = 0, sizeId = 0, propertyId = 0, updatedQuantity = 0, factId = 0, count = 0;
            string randomNumber = "0", s_totalPrice = null, retMsg = null, categoryId = null, updatedprice = null;
            decimal updatedPrice = 0, ingredientPrice = 0, productPrice = 0;
            bool flag = false;
            //int productId = 0, sizeId = 0, propertyId = 0, factId = 0;
            //string randomNumber = null, totalPrice = null, retMsg = null, categoryId = null;
            //decimal ingredientPrice = 0, productPrice = 0;


            if (Session["UserEmail"] != null)
            {
                ExecuteAddingCart(ref productId, ref sizeId, ref propertyId, ref updatedQuantity, ref factId, ref count, ref s_totalPrice, ref retMsg, ref categoryId, ref updatedprice, ref updatedPrice,
                    ref productPrice, ref flag, ref randomNumber);
            }
            else
            {
                if (Session["RandomNumber"] == null)
                {
                    Random generator = new Random();
                    randomNumber = generator.Next(0, 1000000).ToString("D6");
                    Session["RandomNumber"] = randomNumber;
                }
                else
                {
                    randomNumber = Session["RandomNumber"].ToString();
                }
                ExecuteAddingCart(ref productId, ref sizeId, ref propertyId, ref updatedQuantity, ref factId, ref count, ref s_totalPrice, ref retMsg, ref categoryId, ref updatedprice, ref updatedPrice,
                    ref productPrice, ref flag, ref randomNumber);
            }
        }
        catch (Exception ex)
        {

        }

    }

    private void ExecuteAddingCart(ref int productId, ref int sizeId, ref int propertyId, ref int updatedQuantity, ref int factId, ref int count, ref string s_totalPrice, ref string retMsg,
        ref string categoryId, ref string updatedprice, ref decimal updatedPrice, ref decimal productPrice, ref bool flag, ref string randomNumber)
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        if (ViewState["ProductId"] != null)
        {
            productId = Convert.ToInt32(ViewState["ProductId"]);
            if (hdnSelectedSize.Value != null && !string.IsNullOrEmpty(hdnSelectedSize.Value))
            {
                ViewState["SizeId"] = sizeId = Convert.ToInt32(hdnSelectedSize.Value);
            }
            if (productId != 0 && sizeId != 0)
            {
                lstClsProductDetail = objClsProductDetail.GetPropertyId(productId, sizeId);
                if (lstClsProductDetail.Count > 0)
                {
                    foreach (var item in lstClsProductDetail)
                    {
                        propertyId = item.PropertiesId;
                        productPrice = Convert.ToDecimal(item.PropertiesPrice);

                    }
                }

            }
            else
            {
                propertyId = 0;
                productPrice = Convert.ToDecimal(objClsProductDetail.GetProductPriceByProductId(productId));
            }
            //if (ViewState["FactId"] != null)
            //{
            //    factId = Convert.ToInt32(ViewState["FactId"]);
            //}

            List<ClsCartDetail> lstExtraIngredients = new List<ClsCartDetail>();

            ControlCollection repeaterControls = rptIngredients.Controls;

            float totalIngredientPrice = 0.0F;
            foreach (Control ctrl in repeaterControls)
            {
                RepeaterItem ctrlRepeaterItem = ctrl as RepeaterItem;

                DataList dlIngredients = (DataList)ctrlRepeaterItem.FindControl("dlIngredientList");
                HtmlGenericControl lblIngGroupPriceLiteral = (HtmlGenericControl)ctrlRepeaterItem.FindControl("divIngredientGroupPrice");

                string groupPrice = lblIngGroupPriceLiteral.InnerText.Substring(lblIngGroupPriceLiteral.InnerText.IndexOf("$") + 1);

                int noOfFreeIngredients = objClsCartDetail.GetNumberOfFreeIngredient(productId);
                int count1 = 0;

                foreach (DataListItem dli in dlIngredients.Items)
                {
                    CheckBox chkIngredient = dli.FindControl("chkIngredient") as CheckBox;
                    float multiplier = 1.0F;
                    if (chkIngredient.Checked)
                    {
                        HtmlInputRadioButton rbFacetsFull = dli.FindControl("radioFull") as HtmlInputRadioButton;
                        HtmlInputRadioButton rbFacetsFHalf = dli.FindControl("radioFhalf") as HtmlInputRadioButton;
                        HtmlInputRadioButton rbFacetsSHalf = dli.FindControl("radioShalf") as HtmlInputRadioButton;
                        HtmlInputCheckBox chkExtraIng = dli.FindControl("chkExtra") as HtmlInputCheckBox;

                        ClsCartDetail ClsCartDetailobj = new ClsCartDetail();
                        Label lblIngredientId = (Label)dli.FindControl("lblIngredientId");


                        if (rbFacetsFull.Checked)
                        {
                            multiplier = 1.0F;
                            ViewState["FactId"] = factId = ClsCartDetailobj.ProductIngredientFatDetail_id = 1;

                        }
                        else if (rbFacetsFHalf.Checked)
                        {
                            multiplier = 0.5F;
                            ViewState["FactId"] = factId = ClsCartDetailobj.ProductIngredientFatDetail_id = 2;
                        }
                        else if (rbFacetsSHalf.Checked)
                        {
                            multiplier = 0.5F;
                            ViewState["FactId"] = factId = ClsCartDetailobj.ProductIngredientFatDetail_id = 3;
                        }
                        else if (Convert.ToString(ViewState["CategoryName"]) == "Fresh Salads")
                        {
                            multiplier = 1.0F;
                            ViewState["FactId"] = factId = ClsCartDetailobj.ProductIngredientFatDetail_id = 1;
                        }
                        else
                        {
                            multiplier = 1.0F;
                            ViewState["FactId"] = factId = ClsCartDetailobj.ProductIngredientFatDetail_id = 1;
                        }

                        if (chkExtraIng.Checked)
                        {
                            multiplier = multiplier * 2.0F;
                            ViewState["FactId"] = factId = ClsCartDetailobj.ProductIngredientFatDetail_id = factId + 3;
                        }
                        else if(noOfFreeIngredients > count1)
                        {
                            multiplier = 0.0F;
                            count1++;
                        }

                        


                        totalIngredientPrice += (float.Parse(groupPrice) * multiplier);

                        ClsCartDetailobj.IngredientId = Convert.ToInt32(lblIngredientId.Text);
                        ClsCartDetailobj.IngredientPrice = (float.Parse(groupPrice) * multiplier).ToString();
                        lstExtraIngredients.Add(ClsCartDetailobj);
                    }
                }
            }


            float pizzaPrice = 0.0F;

            float.TryParse(hdnPizzaPrice.Value.Substring(hdnPizzaPrice.Value.IndexOf("$") + 1), out pizzaPrice);

            int quantityPop = Convert.ToInt32(ddlQuantityPop.SelectedValue);

            float totalPrice = (pizzaPrice + totalIngredientPrice) * quantityPop;

            lstClsProductDetail = objClsCartDetail.GetCartDetail(Convert.ToInt32(Session["UserId"]), randomNumber);

            if (lstClsProductDetail.Count > 0)
            {
                foreach (var item in lstClsProductDetail)
                {
                    if (productId == item.ProductdetailId && sizeId == item.SizeId && factId == item.IngredientFactId)
                    {
                        flag = true;
                        ViewState["CartId"] = Convert.ToInt32(item.CartId);
                        ViewState["Quantity"] = Convert.ToInt32(item.Quantity);
                        ViewState["Price"] = Convert.ToDecimal(item.Price);
                    }

                }


                if (flag == true)
                {
                    DataTable dt = new DataTable();
                    dt = objClsCartDetail.GetExtraIngredientsForCart(Convert.ToInt32(ViewState["CartId"]));
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            foreach (var items in lstExtraIngredients)
                            {
                                if (Convert.ToInt32(items.IngredientId) == Convert.ToInt32(dr["IngredientId"]))
                                {
                                    count = count + 1;
                                }
                            }
                        }
                        if (count == lstExtraIngredients.Count)
                        {
                            updatedQuantity = Convert.ToInt32(ViewState["Quantity"]) + 1;
                            updatedPrice = Convert.ToDecimal(updatedQuantity) * Convert.ToDecimal(ViewState["Price"]);
                            updatedprice = Convert.ToString(updatedPrice);
                            retMsg = objClsCartDetail.UpdateCommentByCartId(Convert.ToInt32(ViewState["CartId"]), txtComment.Text);
                            retMsg = objClsCartDetail.UpdateCartDetail(Convert.ToInt32(ViewState["CartId"]), productId, Convert.ToInt32(Session["UserId"]), sizeId, propertyId, updatedQuantity, updatedprice, 0, randomNumber);
                            if (retMsg == "SUCCESS")
                            {
                                categoryId = ViewState["CategoryId"].ToString();
                                string url = "~/OrderOnline.aspx?CategoryId=" + HttpUtility.UrlEncode(EncryptString(categoryId));
                                Response.Redirect(url, false);
                            }

                        }
                        else
                        {
                            s_totalPrice = totalPrice.ToString();
                            retMsg = objClsCartDetail.InsertCartDetail(productId, Convert.ToInt32(Session["UserId"]), sizeId, propertyId, quantityPop, s_totalPrice, factId, randomNumber, lstExtraIngredients.ToList(), txtComment.Text);
                            if (retMsg == "SUCCESS")
                            {
                                if (Session["CartItem"] == null)
                                {
                                    Session["CartItem"] = "1";
                                }
                                else
                                {
                                    Session["CartItem"] = Convert.ToInt32(Session["CartItem"].ToString()) + 1;
                                }
                                item_no.InnerHtml = Session["CartItem"].ToString() + " Items";
                                categoryId = ViewState["CategoryId"].ToString();
                                string url = "~/OrderOnline.aspx?CategoryId=" + HttpUtility.UrlEncode(EncryptString(categoryId));
                                Response.Redirect(url, false);
                            }
                        }
                    }
                }
                else if (flag == false)
                {
                    s_totalPrice = totalPrice.ToString();
                    retMsg = objClsCartDetail.InsertCartDetail(productId, Convert.ToInt32(Session["UserId"]), sizeId, propertyId, quantityPop, s_totalPrice, factId, randomNumber, lstExtraIngredients.ToList(), txtComment.Text);
                    if (retMsg == "SUCCESS")
                    {
                        if (Session["CartItem"] == null)
                        {
                            Session["CartItem"] = "1";
                        }
                        else
                        {
                            Session["CartItem"] = Convert.ToInt32(Session["CartItem"].ToString()) + 1;
                        }
                        item_no.InnerHtml = Session["CartItem"].ToString() + " Items";
                        categoryId = ViewState["CategoryId"].ToString();
                        string url = "~/OrderOnline.aspx?CategoryId=" + HttpUtility.UrlEncode(EncryptString(categoryId));
                        Response.Redirect(url, false);
                    }
                }
            }
            else
            {
                s_totalPrice = totalPrice.ToString();
                retMsg = objClsCartDetail.InsertCartDetail(productId, Convert.ToInt32(Session["UserId"]), sizeId, propertyId, quantityPop, s_totalPrice, factId, randomNumber, lstExtraIngredients.ToList(), txtComment.Text);
                if (retMsg == "SUCCESS")
                {
                    if (Session["CartItem"] == null)
                    {
                        Session["CartItem"] = "1";
                    }
                    else
                    {
                        Session["CartItem"] = Convert.ToInt32(Session["CartItem"].ToString()) + 1;
                    }
                    item_no.InnerHtml = Session["CartItem"].ToString() + " Items";
                    categoryId = ViewState["CategoryId"].ToString();
                    string url = "~/OrderOnline.aspx?CategoryId=" + HttpUtility.UrlEncode(EncryptString(categoryId));
                    Response.Redirect(url, false);
                }
            }

        }
    }
    protected void rptPrice_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {

            if (e.Item.DataItem != null)
            {

                LinkButton lnkClick = (LinkButton)e.Item.FindControl("lnkProductPrice");

                //lnkClick.Attributes["data-toggle"] = "modal";
                //lnkClick.Attributes["data-target"] = "#size-modal";
                lnkClick.Attributes["data-id"] = ((ClsProductDetail)e.Item.DataItem).ProductdetailId.ToString();
                lnkClick.Attributes["data-id2"] = Convert.ToString(((ClsProductDetail)e.Item.DataItem).ProductName);
                //  lnkClick.Attributes["onClick"] = "lnkSize_Click";


            }
        }
    }
}