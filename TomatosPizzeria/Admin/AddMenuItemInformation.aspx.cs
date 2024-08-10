using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddMenuItemInformation : System.Web.UI.Page
{
    int menuItemId;
    DataTable dtp = new DataTable();
    DataTable dtup = new DataTable();
    ClsProductDetail objClsProductDetail = new ClsProductDetail();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Form.Attributes.Add("enctype", "multipart/form-data");
        try
        {

            if (!IsPostBack)
            {

                if (Session["UserId"] != null)
                {

                    if (Request.QueryString["ProductId"] != null)
                    {
                        btnAddMenuItem.Text = "Update Menu Item";
                        menuItemId = Convert.ToInt32(Request.QueryString["ProductId"]);

                        GetAllCategory();
                        GetAllIngredients();
                        GetAllIngredientFactDetails();
                        GetAllProperties();
                        GetAllSize();
                        GetAllPizzaBaseType();
                        GetAllMakingMethod();
                        GetAllMenuItemInformation();


                        btnImg1.Visible = true;

                    }
                    else
                    {
                        btnAddMenuItem.Text = "Add Menu Item";

                        GetAllCategory();
                        GetAllIngredients();
                        GetAllIngredientFactDetails();
                        GetAllProperties();
                        GetAllSize();
                        GetAllPizzaBaseType();
                        GetAllMakingMethod();


                        if (ViewState["AddDetails"] == null)
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Columns.Add("PropertiesId");
                            dataTable.Columns.Add("SizeId");
                            dataTable.Columns.Add("SizeName");
                            dataTable.Columns.Add("PizzaBaseTypeId");
                            dataTable.Columns.Add("PizzaBaseType");
                            dataTable.Columns.Add("MakingMethodId");
                            dataTable.Columns.Add("MakingMethodName");
                            dataTable.Columns.Add("PropertiesPrice");

                            ViewState["AddDetails"] = dataTable;

                        }
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



    public void GetAllMenuItemInformation()
    {
        ClsProductDetail ClsProductDetailobj = new ClsProductDetail();
        try
        {
            ClsProductDetailobj = objClsProductDetail.GetProductInformation(Convert.ToInt32(Request.QueryString["ProductId"].ToString()));
            if (ClsProductDetailobj != null)
            {
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"(<br />|<br/>|</ br>|</br>)");

                CKeditorDescription.Text = regex.Replace(ClsProductDetailobj.Description, "<br/>");
                txtSquenceNo.Text = ClsProductDetailobj.SeqNo.ToString();
                txtMenuItemName.Text = ClsProductDetailobj.ProductName.ToString();
                txtMenuItemPrice.Text = ClsProductDetailobj.BasePrice.ToString();
                txtBaseSingleIngredientsPrice.Text = Convert.ToString(ClsProductDetailobj.BaseSingleIngredientPrice);
                txtBaseDoubleIngredientsPrice.Text = Convert.ToString(ClsProductDetailobj.BaseDoubleIngredientPrice);
                txtFreeIngredients.Text = Convert.ToString(ClsProductDetailobj.FreeIngredients);

                DdlCategory.SelectedValue = ClsProductDetailobj.CategotyId.ToString();
                ViewState["Category"] = ClsProductDetailobj.CategoryName;
                if (ClsProductDetailobj.IsActive == true)
                {
                    chkIsActive.Checked = true;
                }

                if (ClsProductDetailobj.IsDelivered == true)
                {
                    chkIsDelivered.Checked = true;
                }
                if (ClsProductDetailobj.IsMarkedNew == true)
                {
                    chkIsMarkedNew.Checked = true;
                }
                if (ClsProductDetailobj.IsMarkedSpeciality == true)
                {
                    chkIsMarkedSpeciality.Checked = true;
                }
                if (ClsProductDetailobj.CanComment == true)
                {
                    chkCancomment.Checked = true;
                }
                if (ClsProductDetailobj.CommentCompulsory == true)
                {
                    chkCommentCompulsory.Checked = true;
                }
                ImgfuImage1.ImageUrl = ClsProductDetailobj.ImageUrl;

                if (ImgfuImage1.ImageUrl == "")
                {
                    btnImg1.Visible = false;
                    ImgfuImage1.Visible = false;
                }

                if (ViewState["Category"] != null)
                {
                    if (ViewState["Category"].ToString() == "Fresh Salads")
                    {
                        lblIngredientDressingHeader.Text = "Dressing Details";
                    }
                    else
                    {
                        lblIngredientDressingHeader.Text = "Topping Details";
                    }
                }
            }

            //Default Ingredients
            List<ClsProductDetail> lstDefaultClsProductDetail = new List<ClsProductDetail>();
            lstDefaultClsProductDetail = objClsProductDetail.GetAllDefaultIngredientMappingInformation(Convert.ToInt32(Request.QueryString["ProductId"].ToString()));
            if (lstDefaultClsProductDetail.Count > 0)
            {
                foreach (var item in lstDefaultClsProductDetail)
                {
                    foreach (GridViewRow gvrow in gvMenuItemIngredientInformation.Rows)
                    {
                        CheckBox chkingredient = (CheckBox)gvrow.FindControl("chkDefultIngredient");
                        if (chkingredient != null)
                        {

                            Label ingredientName = (Label)gvrow.FindControl("lblIngredientName");
                            Label lblIngredientId = (Label)gvrow.FindControl("lblIngredientId");

                            if (ingredientName != null && lblIngredientId != null)
                            {
                                if (lblIngredientId.Text != "" && lblIngredientId.Text != null)
                                {
                                    if (item.IngredientName == ingredientName.Text && item.IngredientId == Convert.ToInt32(lblIngredientId.Text))
                                    {
                                        chkingredient.Checked = true;
                                        TextBox txtprice = (TextBox)gvrow.FindControl("txtIngredientPrice");
                                        if (txtprice != null)
                                        {
                                            txtprice.Text = item.IngredientPrice.ToString();
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            }

            //Extra Ingredients

            List<ClsProductDetail> lstExtraClsProductDetail = new List<ClsProductDetail>();
            lstDefaultClsProductDetail = objClsProductDetail.GetAllExtraIngredientMappingInformation(Convert.ToInt32(Request.QueryString["ProductId"].ToString()));
            if (lstDefaultClsProductDetail.Count > 0)
            {
                foreach (var item in lstDefaultClsProductDetail)
                {
                    foreach (GridViewRow gvrow in gvMenuItemIngredientInformation.Rows)
                    {
                        CheckBox chkingredient = (CheckBox)gvrow.FindControl("chkExtraIngredient");
                        if (chkingredient != null)
                        {

                            Label ingredientName = (Label)gvrow.FindControl("lblIngredientName");
                            Label lblIngredientId = (Label)gvrow.FindControl("lblIngredientId");

                            if (ingredientName != null && lblIngredientId != null)
                            {
                                if (lblIngredientId.Text != "" && lblIngredientId.Text != null)
                                {
                                    if (item.IngredientName == ingredientName.Text && item.IngredientId == Convert.ToInt32(lblIngredientId.Text))
                                    {
                                        chkingredient.Checked = true;
                                        TextBox txtprice = (TextBox)gvrow.FindControl("txtIngredientPrice");
                                        if (txtprice != null)
                                        {
                                            txtprice.Text = item.IngredientPrice.ToString();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            //Single Ingredients
            //List<ClsProductDetail> lstSingleClsProductDetail = new List<ClsProductDetail>();

            // lstSingleClsProductDetail = objClsProductDetail.GetAllSingleIngredientMappingInformation(Convert.ToInt32(Request.QueryString["ProductId"].ToString()));
            //if (lstSingleClsProductDetail.Count > 0)
            //{
            //    foreach (var item in lstSingleClsProductDetail)
            //    {
            foreach (GridViewRow gvrow in gvMenuItemIngredientInformation.Rows)
            {
                CheckBox rdbSingleIngredients = (CheckBox)gvrow.FindControl("rdbSingleIngredients");
                CheckBox rdbDoubleIngredients = (CheckBox)gvrow.FindControl("rdbDoubleIngredients");
                Label lblIngredientId = (Label)gvrow.FindControl("lblIngredientId");

                tp_ingredient_product_mapping objtpIngredientInformation = new tp_ingredient_product_mapping();

                objtpIngredientInformation = objClsProductDetail.GetSingleIngredientInformation(Convert.ToInt32(Request.QueryString["ProductId"].ToString()), Convert.ToInt32(lblIngredientId.Text));

                if (objtpIngredientInformation != null)
                {
                    if (objtpIngredientInformation.iipm_IsSingleIngredient == true)
                    {
                        rdbSingleIngredients.Checked = true;
                        rdbDoubleIngredients.Checked = false;
                    }

                    else
                    {
                        rdbSingleIngredients.Checked = false;
                        rdbDoubleIngredients.Checked = true;
                    }
                }

            }
            //    }
            //}

            //Change Grid Header Text
            for (int i = 0; i < gvMenuItemIngredientInformation.Columns.Count; i++)
            {
                string IngredientNameHeader = gvMenuItemIngredientInformation.Columns[i].HeaderText;

                if (ViewState["Category"] != null)
                {
                    if (ViewState["Category"].ToString() == "Fresh Salads")
                    {
                        lblIngredientDressingHeader.Text = "Dressing Details";

                        if (i == 1)
                            this.gvMenuItemIngredientInformation.HeaderRow.Cells[1].Text = "Dressing Name";
                        else if (i == 2)
                            this.gvMenuItemIngredientInformation.HeaderRow.Cells[2].Text = "Dressing Price";
                        else if (i == 3)
                            this.gvMenuItemIngredientInformation.HeaderRow.Cells[3].Text = "Default Dressing";
                        else if (i == 4)
                            this.gvMenuItemIngredientInformation.HeaderRow.Cells[4].Text = "Extra Dressing";
                    }
                    else
                    {
                        lblIngredientDressingHeader.Text = "Topping Details";

                        if (i == 1)
                            this.gvMenuItemIngredientInformation.HeaderRow.Cells[1].Text = "Toppings Name";
                        else if (i == 2)
                            this.gvMenuItemIngredientInformation.HeaderRow.Cells[2].Text = "Toppings Price";
                        else if (i == 3)
                            this.gvMenuItemIngredientInformation.HeaderRow.Cells[3].Text = "Default Toppings";
                        else if (i == 4)
                            this.gvMenuItemIngredientInformation.HeaderRow.Cells[4].Text = "Extra Toppings";
                    }
                }
            }

            //fact
            List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
            //change to ingredient
            lstClsProductDetail = objClsProductDetail.GetAllFactDetailByProductId(Convert.ToInt32(Request.QueryString["ProductId"].ToString()));
            if (lstClsProductDetail.Count > 0)
            {
                foreach (var item in lstClsProductDetail)
                {
                    foreach (GridViewRow gvrow in gvIngredientFactDetail.Rows)
                    {
                        CheckBox chkingredientfact = (CheckBox)gvrow.FindControl("chkingredientfact");
                        if (chkingredientfact != null)
                        {

                            Label lblIngredientFactName = (Label)gvrow.FindControl("lblIngredientFactName");
                            if (lblIngredientFactName != null)
                            {
                                if (item.IngredientFactName == lblIngredientFactName.Text)
                                {
                                    chkingredientfact.Checked = true;
                                }
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
        //Properties
        //lstClsProductDetail = objClsProductDetail.GetAllPropertiesMappingInformation(Convert.ToInt32(Request.QueryString["ProductId"].ToString()));
        //if (lstClsProductDetail.Count > 0)
        //{
        //    foreach (var item in lstClsProductDetail)
        //    {
        //        foreach (GridViewRow gvrow in gvMenuItemPropertiesInformation.Rows)
        //        {
        //            Label sizeName = (Label)gvrow.FindControl("lblMenuItemSize");
        //            if (sizeName != null)
        //            {
        //                if (item.SizeName == sizeName.Text)
        //                {

        //                    TextBox txtprice = (TextBox)gvrow.FindControl("txtPropertiesPrice");
        //                    if (txtprice != null)
        //                    {
        //                        txtprice.Text = item.PropertiesPrice.ToString();
        //                    }

        //                }
        //            }



        //        }
        //    }
        //}

    }
    public void GetAllCategory()
    {
        List<tp_product_category> lsttp_product_category = new List<tp_product_category>();
        try
        {
            lsttp_product_category = objClsProductDetail.GetAllCategory();

            DdlCategory.DataSource = lsttp_product_category;
            DdlCategory.DataValueField = "pc_id";
            DdlCategory.DataTextField = "pc_name";
            DdlCategory.DataBind();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    public void GetAllIngredients()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objClsProductDetail.GetAllIngredients();
            if (dt != null)
            {
                gvMenuItemIngredientInformation.DataSource = dt;
                gvMenuItemIngredientInformation.DataBind();
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }


    public void GetAllIngredientFactDetails()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objClsProductDetail.GetAllIngredientFactDetails();
            if (dt != null)
            {
                gvIngredientFactDetail.DataSource = dt;
                gvIngredientFactDetail.DataBind();
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    public void GetAllProperties()
    {
        try
        {
            dtup = objClsProductDetail.GetProductPropertiesByProductId(Convert.ToInt32(Request.QueryString["ProductId"]));

            if (dtup != null)
            {


                dtup.Columns.Remove("SeqNo");
                dtup.Columns.Remove("ProductName");
                dtup.Columns.Remove("ProductCategoryId");
                dtup.Columns.Remove("Description");
                dtup.Columns.Remove("BasePrice");
                dtup.Columns.Remove("ImageUrl");
                dtup.Columns.Remove("IsDelivered");
                dtup.Columns.Remove("IsMarkedNew");
                dtup.Columns.Remove("IsMarkedSpeciality");
                dtup.Columns.Remove("CanComment");
                dtup.Columns.Remove("ProductdetailId");
                dtup.Columns.Remove("IngredientId");
                dtup.Columns.Remove("IngredientName");
                dtup.Columns.Remove("IngredientPrice");
                dtup.Columns.Remove("CategoryName");
                dtup.Columns.Remove("CategotyId");
                // dtup.Columns.Remove("PropertiesId");


                gvMenuItemPropertiesInformation.DataSource = dtup;
                gvMenuItemPropertiesInformation.DataBind();

                ViewState["UpdateDetails"] = dtup;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    public void GetAllSize()
    {
        List<tp_product_sizes> lsttp_product_sizes = new List<tp_product_sizes>();
        try
        {
            lsttp_product_sizes = objClsProductDetail.GetAllSize();

            DdlSize.DataSource = lsttp_product_sizes;
            DdlSize.DataValueField = "ps_id";
            DdlSize.DataTextField = "ps_name";
            DdlSize.DataBind();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    public void GetAllPizzaBaseType()
    {
        List<tp_pizza_base_type> lsttp_pizza_base_type = new List<tp_pizza_base_type>();
        try
        {
            lsttp_pizza_base_type = objClsProductDetail.GetAllPizzaBaseType();


            DdlPizzaBaseType.DataSource = lsttp_pizza_base_type;
            DdlPizzaBaseType.DataValueField = "pbt_id";
            DdlPizzaBaseType.DataTextField = "pbt_name";
            DdlPizzaBaseType.DataBind();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    public void GetAllMakingMethod()
    {
        List<tp_product_making_method> lsttp_product_making_method = new List<tp_product_making_method>();
        try
        {
            lsttp_product_making_method = objClsProductDetail.GetAllMakingMethods();

            DdlMakingMethod.DataSource = lsttp_product_making_method;
            DdlMakingMethod.DataValueField = "pmm_id";
            DdlMakingMethod.DataTextField = "pmm_name";
            DdlMakingMethod.DataBind();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }


    protected void btnAddMenuItem_Click(object sender, EventArgs e)
    {
        string retMsg = string.Empty;
        bool isProductExist = false;

        try
        {
            if (Page.IsValid)
            {
                //if (fuImage1.PostedFile.FileName == "" && ImgfuImage1.ImageUrl == "")
                //{
                //    lblErrorMsg.InnerHtml = "One Image Required";
                //    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('One Image Required')", true);
                //}
                //else
                //{
                if (txtSquenceNo.Text == "")
                {
                    txtSquenceNo.Text = "0";
                }
                if (btnAddMenuItem.Text == "Add Menu Item")
                {

                    isProductExist = objClsProductDetail.isProductExist(txtMenuItemName.Text, Convert.ToInt32(DdlCategory.SelectedValue));
                    if (isProductExist == true)
                    {
                        lblErrorMsg.InnerHtml = "Menu Item Already exists";
                        //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Your Message');", true);

                    }
                    else
                    {

                        List<ClsProductIngredientMapping> lstDefaultClsProductIngredientMapping = new List<ClsProductIngredientMapping>();
                        foreach (GridViewRow gvrow in gvMenuItemIngredientInformation.Rows)
                        {
                            CheckBox chkingredient = (CheckBox)gvrow.FindControl("chkDefultIngredient");
                            if (chkingredient != null)
                            {
                                if (chkingredient.Checked == true)
                                {
                                    ClsProductIngredientMapping objClsProductIngredientMapping = new ClsProductIngredientMapping();

                                    Label ingredientId = (Label)gvrow.FindControl("lblIngredientId");
                                    if (ingredientId != null)
                                    {
                                        objClsProductIngredientMapping.IngredientId = Convert.ToInt32(ingredientId.Text);
                                    }


                                    lstDefaultClsProductIngredientMapping.Add(objClsProductIngredientMapping);
                                }
                            }
                        }

                        List<ClsProductIngredientMapping> lstExtraClsProductIngredientMapping = new List<ClsProductIngredientMapping>();
                        foreach (GridViewRow gvrow in gvMenuItemIngredientInformation.Rows)
                        {
                            CheckBox chkingredient = (CheckBox)gvrow.FindControl("chkExtraIngredient");
                            if (chkingredient != null)
                            {
                                if (chkingredient.Checked == true)
                                {
                                    ClsProductIngredientMapping objClsProductIngredientMapping = new ClsProductIngredientMapping();

                                    Label ingredientId = (Label)gvrow.FindControl("lblIngredientId");
                                    if (ingredientId != null)
                                    {
                                        objClsProductIngredientMapping.IngredientId = Convert.ToInt32(ingredientId.Text);
                                    }


                                    lstExtraClsProductIngredientMapping.Add(objClsProductIngredientMapping);
                                }
                            }
                        }

                        //Add IsSingleIngredients Column Value
                        List<ClsProductIngredientMapping> lstAddSingleIngredientColumn = new List<ClsProductIngredientMapping>();
                        foreach (GridViewRow gvrow in gvMenuItemIngredientInformation.Rows)
                        {
                            CheckBox rdbSingleIngredients = (CheckBox)gvrow.FindControl("rdbSingleIngredients");
                            CheckBox rdbDoubleIngredients = (CheckBox)gvrow.FindControl("rdbDoubleIngredients");



                            if (rdbSingleIngredients.Checked == true)
                            {
                                ClsProductIngredientMapping objClsProductIngredientMapping = new ClsProductIngredientMapping();

                                Label ingredientId = (Label)gvrow.FindControl("lblIngredientId");
                                if (ingredientId != null)
                                {
                                    objClsProductIngredientMapping.IngredientId = Convert.ToInt32(ingredientId.Text);
                                    objClsProductIngredientMapping.ProductId = Convert.ToInt32(Request.QueryString["ProductId"]);
                                }
                                objClsProductIngredientMapping.IsSingleIngredient = true;

                                lstAddSingleIngredientColumn.Add(objClsProductIngredientMapping);
                            }
                            else if (rdbDoubleIngredients.Checked == true)
                            {
                                ClsProductIngredientMapping objClsProductIngredientMapping = new ClsProductIngredientMapping();

                                Label ingredientId = (Label)gvrow.FindControl("lblIngredientId");
                                if (ingredientId != null)
                                {
                                    objClsProductIngredientMapping.IngredientId = Convert.ToInt32(ingredientId.Text);
                                    objClsProductIngredientMapping.ProductId = Convert.ToInt32(Request.QueryString["ProductId"]);
                                }

                                objClsProductIngredientMapping.IsSingleIngredient = false;
                                lstAddSingleIngredientColumn.Add(objClsProductIngredientMapping);
                            }
                        }

                        List<ClsProductIngredientFactMapping> lstClsProductIngredientFactMapping = new List<ClsProductIngredientFactMapping>();
                        foreach (GridViewRow gvrow in gvIngredientFactDetail.Rows)
                        {
                            CheckBox chkingredientfact = (CheckBox)gvrow.FindControl("chkingredientfact");
                            if (chkingredientfact != null)
                            {
                                if (chkingredientfact.Checked == true)
                                {
                                    ClsProductIngredientFactMapping objClsProductIngredientFactMapping = new ClsProductIngredientFactMapping();

                                    Label ingredientFactId = (Label)gvrow.FindControl("lblIngredientFactId");
                                    if (ingredientFactId != null)
                                    {
                                        objClsProductIngredientFactMapping.IngredientFactId = Convert.ToInt32(ingredientFactId.Text);
                                    }

                                    lstClsProductIngredientFactMapping.Add(objClsProductIngredientFactMapping);
                                }
                            }
                        }


                        List<ClsProductProperties> lstClsProductProperties = new List<ClsProductProperties>();
                        foreach (GridViewRow gvrow in gvMenuItemPropertiesInformation.Rows)
                        {

                            ClsProductProperties objClsProductProperties = new ClsProductProperties();

                            Label sizeId = (Label)gvrow.FindControl("lblSizeId");
                            Label sizeName = (Label)gvrow.FindControl("lblMenuItemSize");
                            Label pizzaBaseTypeId = (Label)gvrow.FindControl("lblPizzaBaseTypeId");
                            Label pizzaBaseTypeName = (Label)gvrow.FindControl("lblPizzaBaseType");
                            Label makingMethodId = (Label)gvrow.FindControl("lblMakingMethodId");
                            Label makingMethodName = (Label)gvrow.FindControl("lblMenuItemMakingMethod");
                            Label propertiesPrice = (Label)gvrow.FindControl("lblPropertiesPrice");

                            Label SingleToppingsPrice = (Label)gvrow.FindControl("lblSingleToppingsPrice");
                            Label DoubleToppingsPrice = (Label)gvrow.FindControl("lblDoubleTopingsPrice");

                            string pp = propertiesPrice.Text.Replace("$ ", "");

                            string singleIngredients = SingleToppingsPrice.Text.Replace("$ ", "");
                            string doubleIngredients = DoubleToppingsPrice.Text.Replace("$ ", "");

                            if (sizeId != null && pizzaBaseTypeId != null && makingMethodId != null && propertiesPrice != null)
                            {
                                objClsProductProperties.ProductSizeId = Convert.ToInt32(sizeId.Text);
                                objClsProductProperties.PizzaBaseTypeId = Convert.ToInt32(pizzaBaseTypeId.Text);
                                objClsProductProperties.ProductMakingMethodId = Convert.ToInt32(makingMethodId.Text);
                                objClsProductProperties.PropertiesPrice = pp.ToString();
                                objClsProductProperties.SingleIngredientsPrice = singleIngredients;
                                objClsProductProperties.DoubleIngredientsPrice = doubleIngredients;

                                lstClsProductProperties.Add(objClsProductProperties);

                            }




                        }
                        string text = CKeditorDescription.Text;
                        text = text.Replace("\n", "<br />");
                        text = text.Replace("\t", "\n");
                        string Description = string.Empty;
                        Regex tagRemove = new Regex(@"<[^>]*(>|$)");
                        Regex compressSpaces = new Regex(@"[\s\r]+");
                        Description = tagRemove.Replace(text, string.Empty);
                        Description = Description.Replace("\n", "<br />");
                        Description = compressSpaces.Replace(Description, " ");
                        Description = Regex.Replace(Description, @"\<\s*br\s*\/?\s*\>", "");

                        string filename1 = Path.GetFileNameWithoutExtension(fuImage1.PostedFile.FileName);
                        if (filename1 != "")
                        {
                            //objClsProductInformation.FileUpload( filename1);
                            string ProductImgUrl = objClsProductDetail.GetMenuItemImgUrl().tpc_value;

                            Guid gid = Guid.NewGuid();
                            filename1 = Convert.ToString(gid) + ".png";
                            Stream fs = fuImage1.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs);
                            Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                            var jpegQuality = 50;
                            System.Drawing.Image image;
                            using (var inputStream = new MemoryStream(bytes))
                            {
                                image = System.Drawing.Image.FromStream(inputStream);
                                var jpegEncoder = ImageCodecInfo.GetImageDecoders()
                                  .First(c => c.FormatID == ImageFormat.Jpeg.Guid);
                                var encoderParameters = new EncoderParameters(1);
                                encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, jpegQuality);
                                Byte[] outputBytes;
                                using (var outputStream = new MemoryStream())
                                {
                                    image.Save(outputStream, jpegEncoder, encoderParameters);
                                    outputBytes = outputStream.ToArray();

                                    objClsProductDetail.FileUpload(outputBytes, filename1, ProductImgUrl);
                                }
                            }
                        }
                        else
                        {
                            if (ImgfuImage1.ImageUrl != "")
                            {
                                filename1 = ImgfuImage1.ImageUrl.Replace("/ProjectImages/MenuItemImages/", "");
                            }
                        }

                        bool chkActive = chkIsActive.Checked;
                        bool chkDelivered = chkIsDelivered.Checked;
                        bool chkMarkedNew = chkIsMarkedNew.Checked;
                        bool chkMarkedSpeciality = chkIsMarkedSpeciality.Checked;
                        bool chkComment = chkCancomment.Checked;

                        retMsg = objClsProductDetail.InsertNewProduct(txtSquenceNo.Text, txtMenuItemName.Text.Trim(), Convert.ToInt32(DdlCategory.SelectedValue), Description, txtMenuItemPrice.Text.Trim(), 
                            txtBaseSingleIngredientsPrice.Text, txtBaseDoubleIngredientsPrice.Text, filename1, chkActive, chkDelivered, chkMarkedNew, chkMarkedSpeciality, chkComment, 
                            chkCommentCompulsory.Checked, lstDefaultClsProductIngredientMapping.ToList(), lstExtraClsProductIngredientMapping.ToList(), lstClsProductIngredientFactMapping.ToList(), 
                            lstClsProductProperties.ToList(), Convert.ToInt32(Session["UserId"]), 1, lstAddSingleIngredientColumn, Convert.ToInt32(txtFreeIngredients.Text));

                        if (retMsg == "SUCCESS")
                        {
                            Session["Message"] = "Add";
                            Response.Redirect("~/Admin/MenuItemInformation.aspx?", false);


                        }
                    }
                }
                else if (btnAddMenuItem.Text == "Update Menu Item")
                {

                    List<ClsProductIngredientMapping> lstDefaultClsProductIngredientMapping = new List<ClsProductIngredientMapping>();
                    foreach (GridViewRow gvrow in gvMenuItemIngredientInformation.Rows)
                    {
                        CheckBox chkDefultIngredient = (CheckBox)gvrow.FindControl("chkDefultIngredient");
                        if (chkDefultIngredient != null)
                        {

                            if (chkDefultIngredient.Checked == true)
                            {
                                ClsProductIngredientMapping objClsProductIngredientMapping = new ClsProductIngredientMapping();

                                Label ingredientId = (Label)gvrow.FindControl("lblIngredientId");
                                if (ingredientId != null)
                                {
                                    objClsProductIngredientMapping.IngredientId = Convert.ToInt32(ingredientId.Text);
                                }


                                lstDefaultClsProductIngredientMapping.Add(objClsProductIngredientMapping);
                            }
                        }
                    }

                    List<ClsProductIngredientMapping> lstClsProductIngredientMappingAll = new List<ClsProductIngredientMapping>();
                    foreach (GridViewRow gvrow in gvMenuItemIngredientInformation.Rows)
                    {
                        CheckBox chkDefultIngredient = (CheckBox)gvrow.FindControl("chkDefultIngredient");
                        CheckBox chkExtraIngredient = (CheckBox)gvrow.FindControl("chkExtraIngredient");
                        if (chkDefultIngredient != null && chkExtraIngredient != null)
                        {

                            if (chkDefultIngredient.Checked == false && chkExtraIngredient.Checked == false)
                            {
                                ClsProductIngredientMapping objClsProductIngredientMapping = new ClsProductIngredientMapping();

                                Label ingredientId = (Label)gvrow.FindControl("lblIngredientId");
                                if (ingredientId != null)
                                {
                                    objClsProductIngredientMapping.IngredientId = Convert.ToInt32(ingredientId.Text);
                                }


                                lstClsProductIngredientMappingAll.Add(objClsProductIngredientMapping);
                            }

                        }
                    }


                    List<ClsProductIngredientMapping> lstExtraClsProductIngredientMapping = new List<ClsProductIngredientMapping>();
                    foreach (GridViewRow gvrow in gvMenuItemIngredientInformation.Rows)
                    {
                        CheckBox chkExtraIngredient = (CheckBox)gvrow.FindControl("chkExtraIngredient");
                        if (chkExtraIngredient != null)
                        {

                            if (chkExtraIngredient.Checked == true)
                            {
                                ClsProductIngredientMapping objClsProductIngredientMapping = new ClsProductIngredientMapping();

                                Label ingredientId = (Label)gvrow.FindControl("lblIngredientId");
                                if (ingredientId != null)
                                {
                                    objClsProductIngredientMapping.IngredientId = Convert.ToInt32(ingredientId.Text);
                                }


                                lstExtraClsProductIngredientMapping.Add(objClsProductIngredientMapping);
                            }
                        }
                    }

                    //Adding IsSingleIngredient Column Value
                    List<ClsProductIngredientMapping> lstAddSingleIngredientColumn = new List<ClsProductIngredientMapping>();
                    foreach (GridViewRow gvrow in gvMenuItemIngredientInformation.Rows)
                    {
                        CheckBox rdbSingleIngredients = (CheckBox)gvrow.FindControl("rdbSingleIngredients");
                        CheckBox rdbDoubleIngredients = (CheckBox)gvrow.FindControl("rdbDoubleIngredients");



                        if (rdbSingleIngredients.Checked == true)
                        {
                            ClsProductIngredientMapping objClsProductIngredientMapping = new ClsProductIngredientMapping();

                            Label ingredientId = (Label)gvrow.FindControl("lblIngredientId");
                            if (ingredientId != null)
                            {
                                objClsProductIngredientMapping.IngredientId = Convert.ToInt32(ingredientId.Text);
                                objClsProductIngredientMapping.ProductId = Convert.ToInt32(Request.QueryString["ProductId"]);
                            }
                            objClsProductIngredientMapping.IsSingleIngredient = true;

                            lstAddSingleIngredientColumn.Add(objClsProductIngredientMapping);
                        }
                        else if(rdbDoubleIngredients.Checked == true)
                        {
                            ClsProductIngredientMapping objClsProductIngredientMapping = new ClsProductIngredientMapping();

                            Label ingredientId = (Label)gvrow.FindControl("lblIngredientId");
                            if (ingredientId != null)
                            {
                                objClsProductIngredientMapping.IngredientId = Convert.ToInt32(ingredientId.Text);
                                objClsProductIngredientMapping.ProductId = Convert.ToInt32(Request.QueryString["ProductId"]);
                            }

                            objClsProductIngredientMapping.IsSingleIngredient = false;
                            lstAddSingleIngredientColumn.Add(objClsProductIngredientMapping);
                        }
                    }

                    //List<ClsProductIngredientMapping> lstExtraClsProductIngredientMappingAll = new List<ClsProductIngredientMapping>();
                    //foreach (GridViewRow gvrow in gvMenuItemIngredientInformation.Rows)
                    //{
                    //    CheckBox chkingredient = (CheckBox)gvrow.FindControl("chkExtraIngredient");
                    //    if (chkingredient != null)
                    //    {

                    //        ClsProductIngredientMapping objClsProductIngredientMapping = new ClsProductIngredientMapping();

                    //        Label ingredientId = (Label)gvrow.FindControl("lblIngredientId");
                    //        if (ingredientId != null)
                    //        {
                    //            objClsProductIngredientMapping.IngredientId = Convert.ToInt32(ingredientId.Text);
                    //        }


                    //        lstExtraClsProductIngredientMappingAll.Add(objClsProductIngredientMapping);

                    //    }
                    //}

                    List<ClsProductIngredientFactMapping> lstClsProductIngredientFactMapping = new List<ClsProductIngredientFactMapping>();
                    foreach (GridViewRow gvrow in gvIngredientFactDetail.Rows)
                    {
                        CheckBox chkingredientfac = (CheckBox)gvrow.FindControl("chkingredientfact");
                        if (chkingredientfac != null)
                        {

                            if (chkingredientfac.Checked == true)
                            {
                                ClsProductIngredientFactMapping objClsProductIngredientFactMapping = new ClsProductIngredientFactMapping();

                                Label ingredientFactId = (Label)gvrow.FindControl("lblIngredientFactId");
                                if (ingredientFactId != null)
                                {
                                    objClsProductIngredientFactMapping.IngredientFactId = Convert.ToInt32(ingredientFactId.Text);
                                }


                                lstClsProductIngredientFactMapping.Add(objClsProductIngredientFactMapping);
                            }
                        }
                    }

                    List<ClsProductIngredientFactMapping> lstClsProductIngredientFactMappingAll = new List<ClsProductIngredientFactMapping>();
                    foreach (GridViewRow gvrow in gvIngredientFactDetail.Rows)
                    {
                        CheckBox chkingredientfact = (CheckBox)gvrow.FindControl("chkingredientfact");
                        if (chkingredientfact != null)
                        {

                            ClsProductIngredientFactMapping objClsProductIngredientFactMapping = new ClsProductIngredientFactMapping();

                            Label ingredientFactId = (Label)gvrow.FindControl("lblIngredientFactId");
                            if (ingredientFactId != null)
                            {
                                objClsProductIngredientFactMapping.IngredientFactId = Convert.ToInt32(ingredientFactId.Text);
                            }


                            lstClsProductIngredientFactMappingAll.Add(objClsProductIngredientFactMapping);

                        }
                    }

                    List<ClsProductProperties> lstClsProductProperties = new List<ClsProductProperties>();
                    foreach (GridViewRow gvrow in gvMenuItemPropertiesInformation.Rows)
                    {

                        ClsProductProperties objClsProductProperties = new ClsProductProperties();
                        Label propertiesId = (Label)gvrow.FindControl("lblPropertiesId");
                        Label sizeId = (Label)gvrow.FindControl("lblSizeId");
                        Label sizeName = (Label)gvrow.FindControl("lblMenuItemSize");
                        Label pizzaBaseTypeId = (Label)gvrow.FindControl("lblPizzaBaseTypeId");
                        Label pizzaBaseTypeName = (Label)gvrow.FindControl("lblPizzaBaseType");
                        Label makingMethodId = (Label)gvrow.FindControl("lblMakingMethodId");
                        Label makingMethodName = (Label)gvrow.FindControl("lblMenuItemMakingMethod");
                        Label propertiesPrice = (Label)gvrow.FindControl("lblPropertiesPrice");

                        Label SingleToppingsPrice = (Label)gvrow.FindControl("lblSingleToppingsPrice");
                        Label DoubleToppingsPrice = (Label)gvrow.FindControl("lblDoubleTopingsPrice");

                        string pp = propertiesPrice.Text.Replace("$ ", "");
                        string singleIngredients = SingleToppingsPrice.Text.Replace("$ ", "");
                        string doubleIngredients = DoubleToppingsPrice.Text.Replace("$ ", "");

                        if (sizeId != null && pizzaBaseTypeId != null && makingMethodId != null && propertiesPrice != null)
                        {
                            objClsProductProperties.PropertiesId = Convert.ToInt32(propertiesId.Text);
                            objClsProductProperties.ProductSizeId = Convert.ToInt32(sizeId.Text);
                            objClsProductProperties.PizzaBaseTypeId = Convert.ToInt32(pizzaBaseTypeId.Text);
                            objClsProductProperties.ProductMakingMethodId = Convert.ToInt32(makingMethodId.Text);
                            objClsProductProperties.PropertiesPrice = pp.ToString();

                            objClsProductProperties.SingleIngredientsPrice = singleIngredients;
                            objClsProductProperties.DoubleIngredientsPrice = doubleIngredients;

                            lstClsProductProperties.Add(objClsProductProperties);

                        }
                    }

                    string text = CKeditorDescription.Text;
                    text = text.Replace("\n", "<br />");
                    text = text.Replace("&nbsp;", "");
                    text = text.Replace("\t", "\n");
                    string Description = string.Empty;
                    Regex tagRemove = new Regex(@"<[^>]*(>|$)");
                    Regex compressSpaces = new Regex(@"[\s\r]+");
                    Description = tagRemove.Replace(text, string.Empty);
                    Description = Description.Replace("\n", "<br />");
                    Description = compressSpaces.Replace(Description, " ");
                    Description = Regex.Replace(Description, @"\<\s*br\s*\/?\s*\>", "");

                    string filename1 = Path.GetFileNameWithoutExtension(fuImage1.PostedFile.FileName);
                    if (filename1 != "")
                    {
                        //objClsProductInformation.FileUpload( filename1);
                        string ProductImgUrl = objClsProductDetail.GetMenuItemImgUrl().tpc_value;

                        Guid gid = Guid.NewGuid();
                        filename1 = Convert.ToString(gid) + ".png";
                        Stream fs = fuImage1.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                        var jpegQuality = 50;
                        System.Drawing.Image image;
                        using (var inputStream = new MemoryStream(bytes))
                        {
                            image = System.Drawing.Image.FromStream(inputStream);
                            var jpegEncoder = ImageCodecInfo.GetImageDecoders()
                              .First(c => c.FormatID == ImageFormat.Jpeg.Guid);
                            var encoderParameters = new EncoderParameters(1);
                            encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, jpegQuality);
                            Byte[] outputBytes;
                            using (var outputStream = new MemoryStream())
                            {
                                image.Save(outputStream, jpegEncoder, encoderParameters);
                                outputBytes = outputStream.ToArray();

                                objClsProductDetail.FileUpload(outputBytes, filename1, ProductImgUrl);
                            }
                        }
                    }
                    else
                    {
                        if (ImgfuImage1.ImageUrl != "")
                        {
                            filename1 = ImgfuImage1.ImageUrl.Replace("/ProjectImages/MenuItemImages/", "");
                        }
                    }
                    bool chkActive = chkIsActive.Checked;
                    bool chkDelivered = chkIsDelivered.Checked;
                    bool chkMarkedNew = chkIsMarkedNew.Checked;
                    bool chkMarkedSpeciality = chkIsMarkedSpeciality.Checked;
                    bool chkComment = chkCancomment.Checked;

                    retMsg = objClsProductDetail.UpdateProduct(Convert.ToInt32(Request.QueryString["ProductId"].ToString()), txtSquenceNo.Text, txtMenuItemName.Text.Trim(), Convert.ToInt32(DdlCategory.SelectedValue), Description, 
                        txtMenuItemPrice.Text.Trim(), txtBaseSingleIngredientsPrice.Text.Trim(), txtBaseDoubleIngredientsPrice.Text.Trim(), filename1, chkActive, chkDelivered, chkMarkedNew, 
                        chkMarkedSpeciality, chkComment, chkCommentCompulsory.Checked, lstClsProductIngredientMappingAll.ToList(), lstDefaultClsProductIngredientMapping.ToList(), 
                        lstExtraClsProductIngredientMapping.ToList(), lstClsProductIngredientFactMappingAll.ToList(), lstClsProductIngredientFactMapping.ToList(), lstClsProductProperties.ToList(), 
                        Convert.ToInt32(Session["UserId"]), 1, lstAddSingleIngredientColumn, Convert.ToInt32(txtFreeIngredients.Text));

                    if (retMsg == "SUCCESS")
                    {
                        Session["Message"] = "Update";
                        Response.Redirect("~/Admin/MenuItemInformation.aspx?", false);

                    }
                }


            }
        }
        // }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Admin/MenuItemInformation.aspx", false);
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void btnImg1_Click(object sender, EventArgs e)
    {
        try
        {
            ImgfuImage1.ImageUrl = "";
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }


    protected void BtnAddProperties_Click(object sender, EventArgs e)
    {
        try
        {
            if (btnAddMenuItem.Text == "Add Menu Item")
            {
                if (BtnAddProperties.Text == "Add Properties")
                {
                    string SizeName, PizzaBaseType, MakingMethodName, PropertiesPrice, SingleIngredientsPrice, DoubleIngredientsPrice;
                    int SizeId = Convert.ToInt32(DdlSize.SelectedValue);
                    if (SizeId == -1)
                    {
                        SizeId = 0;
                        SizeName = "";
                    }
                    else
                    {
                        SizeName = DdlSize.SelectedItem.ToString();
                    }
                    int PizzaBaseTypeId = Convert.ToInt32(DdlPizzaBaseType.SelectedValue);
                    if (PizzaBaseTypeId == -1)
                    {
                        PizzaBaseTypeId = 0;
                        PizzaBaseType = "";
                    }
                    else
                    {
                        PizzaBaseType = DdlPizzaBaseType.SelectedItem.ToString();
                    }
                    int MakingMethodId = Convert.ToInt32(DdlMakingMethod.SelectedValue);
                    if (MakingMethodId == -1)
                    {
                        MakingMethodId = 0;
                        MakingMethodName = "";
                    }
                    else
                    {
                        MakingMethodName = DdlMakingMethod.SelectedItem.ToString();
                    }
                    PropertiesPrice = txtPopupPropertiesPrice.Text.ToString();

                    SingleIngredientsPrice = txtSingleIngredientsPrice.Text.Trim();
                    DoubleIngredientsPrice = txtDoubleIngredientsPrice.Text.Trim();

                    if (SizeId != 0 || PizzaBaseTypeId != 0 || MakingMethodId != 0)
                    {
                        dtp = (DataTable)ViewState["AddDetails"];

                        //dtp.Rows.Add(0, SizeId, SizeName, PizzaBaseTypeId, PizzaBaseType, MakingMethodId, MakingMethodName, PropertiesPrice);

                        dtp.Rows.Add(0, SizeId, SizeName, PizzaBaseTypeId, PizzaBaseType, MakingMethodId, MakingMethodName, PropertiesPrice, SingleIngredientsPrice, DoubleIngredientsPrice);

                        ViewState["AddDetails"] = dtp;
                        gvMenuItemPropertiesInformation.DataSource = dtp;

                        gvMenuItemPropertiesInformation.DataBind();

                        DdlSize.SelectedValue = "-1";
                        DdlPizzaBaseType.SelectedValue = "-1";
                        DdlMakingMethod.SelectedValue = "-1";
                        txtPopupPropertiesPrice.Text = "";
                        PropertiesDiv.Style.Add("display", "none");
                    }
                    else
                    {
                        dtp = (DataTable)ViewState["AddDetails"];
                        gvMenuItemPropertiesInformation.DataSource = dtp;

                        gvMenuItemPropertiesInformation.DataBind();
                        gvMenuItemPropertiesInformation.ShowHeader = true;
                        gvMenuItemPropertiesInformation.ShowHeaderWhenEmpty = true;
                        DdlSize.SelectedValue = "-1";
                        DdlPizzaBaseType.SelectedValue = "-1";
                        DdlMakingMethod.SelectedValue = "-1";
                        txtPopupPropertiesPrice.Text = "";
                        //ModalPopupExtender1.Hide();
                        PropertiesDiv.Style.Add("display", "none");
                    }
                }
                else if (BtnAddProperties.Text == "Update Properties")
                {
                    GridViewRow row = (GridViewRow)gvMenuItemPropertiesInformation.Rows[Convert.ToInt32(ViewState["rowindex"])];
                    string SizeName, PizzaBaseType, MakingMethodName, PropertiesPrice, SingleIngredientsPrice, DoubleIngredientsPrice;
                    int SizeId = Convert.ToInt32(DdlSize.SelectedValue);
                    if (SizeId == -1)
                    {
                        SizeId = 0;
                        SizeName = "";
                    }
                    else
                    {
                        SizeName = DdlSize.SelectedItem.ToString();
                    }
                    int PizzaBaseTypeId = Convert.ToInt32(DdlPizzaBaseType.SelectedValue);
                    if (PizzaBaseTypeId == -1)
                    {
                        PizzaBaseTypeId = 0;
                        PizzaBaseType = "";
                    }
                    else
                    {
                        PizzaBaseType = DdlPizzaBaseType.SelectedItem.ToString();
                    }
                    int MakingMethodId = Convert.ToInt32(DdlMakingMethod.SelectedValue);
                    if (MakingMethodId == -1)
                    {
                        MakingMethodId = 0;
                        MakingMethodName = "";
                    }
                    else
                    {
                        MakingMethodName = DdlMakingMethod.SelectedItem.ToString();
                    }
                    PropertiesPrice = txtPopupPropertiesPrice.Text.ToString();

                    SingleIngredientsPrice = txtSingleIngredientsPrice.Text.Trim();
                    DoubleIngredientsPrice = txtDoubleIngredientsPrice.Text.Trim();

                    if (SizeId != 0 || PizzaBaseTypeId != 0 || MakingMethodId != 0)
                    {
                        DataTable dt = (DataTable)ViewState["AddDetails"];

                        dt.Rows[row.RowIndex]["SizeId"] = SizeId;
                        dt.Rows[row.RowIndex]["SizeName"] = SizeName;
                        dt.Rows[row.RowIndex]["PizzaBaseTypeId"] = PizzaBaseTypeId;
                        dt.Rows[row.RowIndex]["PizzaBaseType"] = PizzaBaseType;
                        dt.Rows[row.RowIndex]["MakingMethodId"] = MakingMethodId;
                        dt.Rows[row.RowIndex]["MakingMethodName"] = MakingMethodName;
                        dt.Rows[row.RowIndex]["PropertiesPrice"] = PropertiesPrice;
                        dt.Rows[row.RowIndex]["SingleIngredientsPrice"] = SingleIngredientsPrice;
                        dt.Rows[row.RowIndex]["DoubleIngredientsPrice"] = DoubleIngredientsPrice;

                        ViewState["AddDetails"] = dt;
                        gvMenuItemPropertiesInformation.EditIndex = -1;

                        gvMenuItemPropertiesInformation.DataSource = dt;

                        gvMenuItemPropertiesInformation.DataBind();
                        DdlSize.SelectedValue = "-1";
                        DdlPizzaBaseType.SelectedValue = "-1";
                        DdlMakingMethod.SelectedValue = "-1";
                        txtPopupPropertiesPrice.Text = "";
                        //ModalPopupExtender1.Hide();
                        PropertiesDiv.Style.Add("display", "none");
                        BtnAddProperties.Text = "Add Properties";
                    }
                    else
                    {
                        DataTable dt = (DataTable)ViewState["AddDetails"];
                        dt.Rows[row.RowIndex].Delete();
                        ViewState["AddDetails"] = dt;

                        gvMenuItemPropertiesInformation.DataSource = dt;

                        gvMenuItemPropertiesInformation.DataBind();
                        DdlSize.SelectedValue = "-1";
                        DdlPizzaBaseType.SelectedValue = "-1";
                        DdlMakingMethod.SelectedValue = "-1";
                        txtPopupPropertiesPrice.Text = "";
                        PropertiesDiv.Style.Add("display", "none");
                        BtnAddProperties.Text = "Add Properties";
                    }

                }
            }
            else if (btnAddMenuItem.Text == "Update Menu Item")
            {
                string retMsg = string.Empty;
                if (BtnAddProperties.Text == "Add Properties")
                {
                    string SizeName, PizzaBaseType, MakingMethodName, PropertiesPrice, SingleIngredientsPrice, DoubleIngredientsPrice;
                    int SizeId = Convert.ToInt32(DdlSize.SelectedValue);
                    if (SizeId == -1)
                    {
                        SizeId = 0;
                        SizeName = "";
                    }
                    else
                    {
                        SizeName = DdlSize.SelectedItem.ToString();
                    }
                    int PizzaBaseTypeId = Convert.ToInt32(DdlPizzaBaseType.SelectedValue);
                    if (PizzaBaseTypeId == -1)
                    {
                        PizzaBaseTypeId = 0;
                        PizzaBaseType = "";
                    }
                    else
                    {
                        PizzaBaseType = DdlPizzaBaseType.SelectedItem.ToString();
                    }
                    int MakingMethodId = Convert.ToInt32(DdlMakingMethod.SelectedValue);
                    if (MakingMethodId == -1)
                    {
                        MakingMethodId = 0;
                        MakingMethodName = "";
                    }
                    else
                    {
                        MakingMethodName = DdlMakingMethod.SelectedItem.ToString();
                    }
                    PropertiesPrice = txtPopupPropertiesPrice.Text.ToString();
                    SingleIngredientsPrice = txtSingleIngredientsPrice.Text.ToString();
                    DoubleIngredientsPrice = txtDoubleIngredientsPrice.Text.ToString();

                    ClsProductProperties objClsProductProperties = new ClsProductProperties();
                    if (SizeId != 0 || PizzaBaseTypeId != 0 || MakingMethodId != 0)
                    {
                        retMsg = objClsProductProperties.InsertProductProperties(SizeId, Convert.ToInt32(Request.QueryString["ProductId"]), PizzaBaseTypeId, MakingMethodId, PropertiesPrice, SingleIngredientsPrice, DoubleIngredientsPrice, Convert.ToInt32(Session["UserId"]));
                        if (retMsg == "SUCCESS")
                        {
                            GetAllProperties();
                        }
                    }
                    else
                    {
                        GetAllProperties();
                    }



                    DdlSize.SelectedValue = "-1";
                    DdlPizzaBaseType.SelectedValue = "-1";
                    DdlMakingMethod.SelectedValue = "-1";
                    txtPopupPropertiesPrice.Text = "";

                    PropertiesDiv.Style.Add("display", "none");
                }
                else if (BtnAddProperties.Text == "Update Properties")
                {
                    int PropertiesId = Convert.ToInt32(ViewState["propertiesid"]);
                    string SizeName, PizzaBaseType, MakingMethodName, PropertiesPrice, SingleIngredientsPrice, DoubleIngredientsPrice;
                    int SizeId = Convert.ToInt32(DdlSize.SelectedValue);
                    if (SizeId == -1)
                    {
                        SizeId = 0;
                        SizeName = "";
                    }
                    else
                    {
                        SizeName = DdlSize.SelectedItem.ToString();
                    }
                    int PizzaBaseTypeId = Convert.ToInt32(DdlPizzaBaseType.SelectedValue);
                    if (PizzaBaseTypeId == -1)
                    {
                        PizzaBaseTypeId = 0;
                        PizzaBaseType = "";
                    }
                    else
                    {
                        PizzaBaseType = DdlPizzaBaseType.SelectedItem.ToString();
                    }
                    int MakingMethodId = Convert.ToInt32(DdlMakingMethod.SelectedValue);
                    if (MakingMethodId == -1)
                    {
                        MakingMethodId = 0;
                        MakingMethodName = "";
                    }
                    else
                    {
                        MakingMethodName = DdlMakingMethod.SelectedItem.ToString();
                    }
                    PropertiesPrice = txtPopupPropertiesPrice.Text.ToString();

                    SingleIngredientsPrice = txtSingleIngredientsPrice.Text.Trim();
                    DoubleIngredientsPrice = txtDoubleIngredientsPrice.Text.Trim();

                    ClsProductProperties objClsProductProperties = new ClsProductProperties();
                    retMsg = objClsProductProperties.UpdateProductProperties(PropertiesId, SizeId, Convert.ToInt32(Request.QueryString["ProductId"]), PizzaBaseTypeId, MakingMethodId, PropertiesPrice, Convert.ToInt32(Session["UserId"]), SingleIngredientsPrice, DoubleIngredientsPrice);
                    if (retMsg == "SUCCESS")
                    {
                        GetAllProperties();
                    }
                    DdlSize.SelectedValue = "-1";
                    DdlPizzaBaseType.SelectedValue = "-1";
                    DdlMakingMethod.SelectedValue = "-1";
                    txtPopupPropertiesPrice.Text = "";
                    txtSingleIngredientsPrice.Text = "";
                    txtDoubleIngredientsPrice.Text = "";
                    //ModalPopupExtender1.Hide();
                    PropertiesDiv.Style.Add("display", "none");
                    BtnAddProperties.Text = "Add Properties";
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }



    protected void gvMenuItemPropertiesInformation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (btnAddMenuItem.Text == "Add Menu Item")
            {

                GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                int rowindex = gvr.RowIndex;
                ViewState["rowindex"] = rowindex;
                if (e.CommandName == "EditProperties")
                {
                    PropertiesDiv.Style.Add("display", "block");
                    BtnAddProperties.Text = "Update Properties";
                    GridViewRow row = (GridViewRow)gvMenuItemPropertiesInformation.Rows[rowindex];

                    Label sizeId = (Label)row.FindControl("lblSizeId");
                    Label sizeName = (Label)row.FindControl("lblMenuItemSize");
                    Label pizzaBaseTypeId = (Label)row.FindControl("lblPizzaBaseTypeId");
                    Label pizzaBaseTypeName = (Label)row.FindControl("lblPizzaBaseType");
                    Label makingMethodId = (Label)row.FindControl("lblMakingMethodId");
                    Label makingMethodName = (Label)row.FindControl("lblMenuItemMakingMethod");
                    Label propertiesPrice = (Label)row.FindControl("lblPropertiesPrice");
                    string pp = propertiesPrice.Text.Replace("$ ", "");
                    string sizeid, sizename, pbtid, pbtname, mmid, mmname;
                    if (sizeId.Text == "0")
                    {
                        sizeid = "-1";
                    }
                    else
                    {
                        sizeid = sizeId.Text;
                    }
                    sizename = sizeName.Text;
                    DdlSize.SelectedValue = sizeid;
                    if (pizzaBaseTypeId.Text == "0")
                    {
                        pbtid = "-1";
                    }
                    else
                    {
                        pbtid = pizzaBaseTypeId.Text;
                    }
                    pbtname = pizzaBaseTypeName.Text;
                    DdlPizzaBaseType.SelectedValue = pbtid;
                    if (makingMethodId.Text == "0")
                    {
                        mmid = "-1";
                    }
                    else
                    {
                        mmid = makingMethodId.Text;
                    }
                    mmname = makingMethodName.Text;
                    DdlMakingMethod.SelectedValue = mmid;
                    txtPopupPropertiesPrice.Text = pp.ToString();
                    PropertiesDiv.Style.Add("display", "block");


                }
                if (e.CommandName == "DeleteProperties")
                {
                    string confirmValue = hdnfldVariable.Value;
                    if (confirmValue == "Yes")
                    {
                        DataTable dt = (DataTable)ViewState["AddDetails"];
                        dt.Rows[rowindex].Delete();
                        ViewState["AddDetails"] = dt;

                        gvMenuItemPropertiesInformation.DataSource = dt;

                        gvMenuItemPropertiesInformation.DataBind();
                        DdlSize.SelectedValue = "-1";
                        DdlPizzaBaseType.SelectedValue = "-1";
                        DdlMakingMethod.SelectedValue = "-1";
                        txtPopupPropertiesPrice.Text = "";
                        PropertiesDiv.Style.Add("display", "none");
                        BtnAddProperties.Text = "Add Properties";
                    }
                }
            }
            else if (btnAddMenuItem.Text == "Update Menu Item")
            {
                GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);


                int rowindex = gvr.RowIndex;
                int propertiesId = Convert.ToInt32(e.CommandArgument);
                ViewState["propertiesid"] = propertiesId;
                if (e.CommandName == "EditProperties")
                {

                    BtnAddProperties.Text = "Update Properties";
                    GridViewRow row = (GridViewRow)gvMenuItemPropertiesInformation.Rows[rowindex];

                    Label sizeId = (Label)row.FindControl("lblSizeId");
                    Label sizeName = (Label)row.FindControl("lblMenuItemSize");
                    Label pizzaBaseTypeId = (Label)row.FindControl("lblPizzaBaseTypeId");
                    Label pizzaBaseTypeName = (Label)row.FindControl("lblPizzaBaseType");
                    Label makingMethodId = (Label)row.FindControl("lblMakingMethodId");
                    Label makingMethodName = (Label)row.FindControl("lblMenuItemMakingMethod");
                    Label propertiesPrice = (Label)row.FindControl("lblPropertiesPrice");

                    Label lblSingleToppingsPrice = (Label)row.FindControl("lblSingleToppingsPrice");
                    Label lblDoubleTopingsPrice = (Label)row.FindControl("lblDoubleTopingsPrice");

                    string pp = propertiesPrice.Text.Replace("$ ", "");

                    string singleIngredientsPrice = lblSingleToppingsPrice.Text.Replace("$ ", "");
                    string doubleIngredientsPrice = lblDoubleTopingsPrice.Text.Replace("$ ", "");

                    string sizeid, sizename, pbtid, pbtname, mmid, mmname;
                    if (sizeId.Text == "0")
                    {
                        sizeid = "-1";
                    }
                    else
                    {
                        sizeid = sizeId.Text;
                    }
                    sizename = sizeName.Text;
                    DdlSize.SelectedValue = sizeid;
                    if (pizzaBaseTypeId.Text == "0")
                    {
                        pbtid = "-1";
                    }
                    else
                    {
                        pbtid = pizzaBaseTypeId.Text;
                    }
                    pbtname = pizzaBaseTypeName.Text;
                    DdlPizzaBaseType.SelectedValue = pbtid;
                    if (makingMethodId.Text == "0")
                    {
                        mmid = "-1";
                    }
                    else
                    {
                        mmid = makingMethodId.Text;
                    }
                    mmname = makingMethodName.Text;
                    DdlMakingMethod.SelectedValue = mmid;
                    txtPopupPropertiesPrice.Text = pp.ToString();

                    txtSingleIngredientsPrice.Text = singleIngredientsPrice;
                    txtDoubleIngredientsPrice.Text = doubleIngredientsPrice;

                    PropertiesDiv.Style.Add("display", "block");
                    // ModalPopupExtender1.Show();




                }
                if (e.CommandName == "DeleteProperties")
                {
                    string retMsg = string.Empty;
                    string confirmValue = hdnfldVariable.Value;
                    if (confirmValue == "Yes")
                    {
                        int PropertiesId = Convert.ToInt32(e.CommandArgument);
                        ClsProductProperties objClsProductProperties = new ClsProductProperties();
                        retMsg = objClsProductProperties.DeleteProductProperties(PropertiesId);
                        if (retMsg == "SUCCESS")
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Menu Item Properties Deleted Successfully')", true);
                        }
                        GetAllProperties();
                        DdlSize.SelectedValue = "-1";
                        DdlPizzaBaseType.SelectedValue = "-1";
                        DdlMakingMethod.SelectedValue = "-1";
                        txtPopupPropertiesPrice.Text = "";
                        PropertiesDiv.Style.Add("display", "none");
                        BtnAddProperties.Text = "Add Properties";
                        // int propertiesId = Convert.ToInt32(e.CommandArgument);
                        //DataTable dt = (DataTable)ViewState["UpdateDetails"];
                        //dt.Rows[rowindex].Delete();
                        //ViewState["AddDetails"] = dt;

                        //gvMenuItemPropertiesInformation.DataSource = dt;

                        //gvMenuItemPropertiesInformation.DataBind();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }



    protected void btnClose_Click(object sender, EventArgs e)
    {
        try
        {
            PropertiesDiv.Style.Add("display", "none");
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void btnNewAddProperties_Click(object sender, EventArgs e)
    {
        try
        {
            PropertiesDiv.Style.Add("display", "block");
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

    protected void gvMenuItemIngredientInformation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            Label lblIngredientNameHeader = (Label)e.Row.FindControl("lblIngredientNameHeader");
            Label lblIngredientPriceHeader = (Label)e.Row.FindControl("lblIngredientPriceHeader");
            Label lblIngredientDefaultHeader = (Label)e.Row.FindControl("lblIngredientDefaultHeader");
            Label lblIngredientExtraHeader = (Label)e.Row.FindControl("lblIngredientExtraHeader");

            if (ViewState["Category"] != null)
            {
                if (ViewState["Category"].ToString() == "Fresh Salads")
                {
                    lblIngredientDressingHeader.Text = "Dressing Details";
                    lblIngredientNameHeader.Text = "Dressing Name";
                    lblIngredientPriceHeader.Text = "Dressing Price";
                    lblIngredientDefaultHeader.Text = "Default Dressing";
                    lblIngredientExtraHeader.Text = "Extra Dressing";
                }
                else
                {
                    lblIngredientDressingHeader.Text = "Topping Details";
                    lblIngredientNameHeader.Text = "Topping Name";
                    lblIngredientPriceHeader.Text = "Topping Price";
                    lblIngredientDefaultHeader.Text = "Default Topping";
                    lblIngredientExtraHeader.Text = "Extra Topping";
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    protected void DdlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < gvMenuItemIngredientInformation.Columns.Count; i++)
            {
                string IngredientNameHeader = gvMenuItemIngredientInformation.Columns[i].HeaderText;


                if (DdlCategory.SelectedItem.Text == "Fresh Salads")
                {
                    lblIngredientDressingHeader.Text = "Dressing Details";

                    if (i == 1)
                        this.gvMenuItemIngredientInformation.HeaderRow.Cells[1].Text = "Dressing Name";
                    else if (i == 2)
                        this.gvMenuItemIngredientInformation.HeaderRow.Cells[2].Text = "Dressing Price";
                    else if (i == 3)
                        this.gvMenuItemIngredientInformation.HeaderRow.Cells[3].Text = "Default Dressing";
                    else if (i == 4)
                        this.gvMenuItemIngredientInformation.HeaderRow.Cells[4].Text = "Extra Dressing";
                }
                else
                {
                    lblIngredientDressingHeader.Text = "Topping Details";

                    if (i == 1)
                        this.gvMenuItemIngredientInformation.HeaderRow.Cells[1].Text = "Toppings Name";
                    else if (i == 2)
                        this.gvMenuItemIngredientInformation.HeaderRow.Cells[2].Text = "Toppings Price";
                    else if (i == 3)
                        this.gvMenuItemIngredientInformation.HeaderRow.Cells[3].Text = "Default Toppings";
                    else if (i == 4)
                        this.gvMenuItemIngredientInformation.HeaderRow.Cells[4].Text = "Extra Toppings";
                }
            }

        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    protected void rdbSingleIngredients_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow gvrow in gvMenuItemIngredientInformation.Rows)
            {
                CheckBox rdbSingleIngredients = (CheckBox)gvrow.FindControl("rdbSingleIngredients");
                CheckBox rdbDoubleIngredients = (CheckBox)gvrow.FindControl("rdbDoubleIngredients");

                if (rdbSingleIngredients.Checked == true)
                    rdbDoubleIngredients.Checked = false;

                else if (rdbDoubleIngredients.Checked == true)
                    rdbSingleIngredients.Checked = false;
            }
        }
        catch(Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    protected void rdbDoubleIngredients_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow gvrow in gvMenuItemIngredientInformation.Rows)
            {
                CheckBox rdbSingleIngredients = (CheckBox)gvrow.FindControl("rdbSingleIngredients");
                CheckBox rdbDoubleIngredients = (CheckBox)gvrow.FindControl("rdbDoubleIngredients");

                if (rdbDoubleIngredients.Checked == true)
                    rdbSingleIngredients.Checked = false;

                else if (rdbSingleIngredients.Checked == true)
                    rdbDoubleIngredients.Checked = false;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
}