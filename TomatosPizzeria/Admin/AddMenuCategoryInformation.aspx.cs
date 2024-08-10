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

public partial class Admin_AddMenuCategoryInformation : System.Web.UI.Page
{
    int menuCategoryId;

    ClsProductCategory objClsProductCategory = new ClsProductCategory();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Form.Attributes.Add("enctype", "multipart/form-data");
        try
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    if (Request.QueryString["CategoryId"] != null)
                    {
                        btnAddCategory.Text = "Update Category";
                        menuCategoryId = Convert.ToInt32(Request.QueryString["CategoryId"]);

                        GetAllIngredients();
                        GetAllMenuCategoryInformation();

                        btnImg1.Visible = true;

                    }
                    else
                    {
                        btnAddCategory.Text = "Add Category";

                        GetAllIngredients();

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

    public void GetAllMenuCategoryInformation()
    {
        ClsProductCategory ClsProductCategoryobj = new ClsProductCategory();
        try
        {
            ClsProductCategoryobj = objClsProductCategory.GetCategoryInformation(Convert.ToInt32(Request.QueryString["CategoryId"].ToString()));
            if (ClsProductCategoryobj != null)
            {
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"(<br />|<br/>|</ br>|</br>)");

                CKeditorDescription.Text = regex.Replace(ClsProductCategoryobj.Description, "<br/>");
               
                txtSquenceNo.Text = ClsProductCategoryobj.SeqNo.ToString();
                txtCategoryName.Text = ClsProductCategoryobj.ProductCategoryName.ToString();
                // txtCategoryParent.Text = Convert.ToInt32(ClsProductCategoryobj.Parent).ToString();


                ImgfuImage1.ImageUrl = ClsProductCategoryobj.ImageUrl;

                if (ImgfuImage1.ImageUrl == "")
                {
                    btnImg1.Visible = false;
                    ImgfuImage1.Visible = false;
                }



            }

            List<ClsProductCategory> lstClsProductCategory = new List<ClsProductCategory>();
            lstClsProductCategory = objClsProductCategory.GetAllIngredientMappingInformation(Convert.ToInt32(Request.QueryString["CategoryId"].ToString()));
            if (lstClsProductCategory.Count > 0)
            {
                foreach (var item in lstClsProductCategory)
                {
                    foreach (GridViewRow gvrow in gvMenuIngredientInformation.Rows)
                    {
                        CheckBox chkingredient = (CheckBox)gvrow.FindControl("chkingredient");
                        if (chkingredient != null)
                        {

                            Label ingredientName = (Label)gvrow.FindControl("lblIngredientName");
                            if (ingredientName != null)
                            {
                                if (item.IngredientName == ingredientName.Text)
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
            dt = objClsProductCategory.GetAllIngredients();

            if (dt != null)
            {
                gvMenuIngredientInformation.DataSource = dt;
                gvMenuIngredientInformation.DataBind();
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void btnAddCategory_Click(object sender, EventArgs e)
    {
        string retMsg = string.Empty;
        bool isProductCategoryExist = false;

        try
        {
            if (Page.IsValid)
            {
                //if (fuImage1.PostedFile.FileName == "" && ImgfuImage1.ImageUrl == "")
                //{
                //    lblErrorMsg.InnerHtml = "One Image Required";
                //    // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('One Image Required')", true);
                //}
                //else
                //{
                if (txtSquenceNo.Text == "")
                {
                    txtSquenceNo.Text = "0";
                }
                if (btnAddCategory.Text == "Add Category")
                {

                    isProductCategoryExist = objClsProductCategory.isProductCategoryExist(txtCategoryName.Text);
                    if (isProductCategoryExist == true)
                    {
                        lblErrorMsg.InnerHtml = "Category Already exists";
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Category Already exists')", true);
                    }
                    else
                    {

                        List<ClsCategoryIngredientMapping> lstClsCategoryIngredientMapping = new List<ClsCategoryIngredientMapping>();
                        foreach (GridViewRow gvrow in gvMenuIngredientInformation.Rows)
                        {
                            CheckBox chkingredient = (CheckBox)gvrow.FindControl("chkingredient");
                            if (chkingredient != null)
                            {
                                if (chkingredient.Checked == true)
                                {
                                    ClsCategoryIngredientMapping objClsCategoryIngredientMapping = new ClsCategoryIngredientMapping();

                                    Label ingredientId = (Label)gvrow.FindControl("lblIngredientId");
                                    if (ingredientId != null)
                                    {
                                        objClsCategoryIngredientMapping.IngredientId = Convert.ToInt32(ingredientId.Text);
                                    }

                                    //TextBox txtprice = (TextBox)gvrow.FindControl("txtIngredientPrice");
                                    //if (txtprice != null)
                                    //{
                                    //    objClsCategoryIngredientMapping.IngredientPrice = txtprice.Text;
                                    //}
                                    lstClsCategoryIngredientMapping.Add(objClsCategoryIngredientMapping);
                                }
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
                            string ProductImgUrl = objClsProductCategory.GetMenuCategoryImgUrl().tpc_value;

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

                                    objClsProductCategory.FileUpload(outputBytes, filename1, ProductImgUrl);
                                }
                            }
                        }
                        else
                        {
                            if (ImgfuImage1.ImageUrl != "")
                            {
                                filename1 = ImgfuImage1.ImageUrl.Replace("/ProjectImages/MenuCategoryImages/", "");
                            }
                        }

                        //category parent static value given is 0
                        //sequencno parent static value given is 0
                        retMsg = objClsProductCategory.InsertNewProductCategory(1, txtSquenceNo.Text, txtCategoryName.Text.Trim(), Convert.ToInt32(0), Description, filename1, lstClsCategoryIngredientMapping.ToList(), Convert.ToInt32(Session["UserId"]));

                        if (retMsg == "SUCCESS")
                        {
                            Session["Message"] = "Add";
                            Response.Redirect("~/Admin/MenuCategoryInformation.aspx?", false);
                            //string message = "Category Added Successfully.";
                            //string url = "MenuCategoryInformation.aspx";
                            //string script = "window.onload = function(){ alert('";
                            //script += message;
                            //script += "');";
                            //script += "window.location = '";
                            //script += url;
                            //script += "'; }";
                            //ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);

                        }
                    }
                }
                else if (btnAddCategory.Text == "Update Category")
                {

                    List<ClsCategoryIngredientMapping> lstClsCategoryIngredientMapping = new List<ClsCategoryIngredientMapping>();
                    foreach (GridViewRow gvrow in gvMenuIngredientInformation.Rows)
                    {
                        CheckBox chkingredient = (CheckBox)gvrow.FindControl("chkingredient");
                        if (chkingredient != null)
                        {

                            if (chkingredient.Checked == true)
                            {
                                ClsCategoryIngredientMapping objClsCategoryIngredientMapping = new ClsCategoryIngredientMapping();

                                Label ingredientId = (Label)gvrow.FindControl("lblIngredientId");
                                if (ingredientId != null)
                                {
                                    objClsCategoryIngredientMapping.IngredientId = Convert.ToInt32(ingredientId.Text);
                                }

                                //TextBox txtprice = (TextBox)gvrow.FindControl("txtIngredientPrice");
                                //if (txtprice != null)
                                //{
                                //    objClsCategoryIngredientMapping.IngredientPrice = txtprice.Text;
                                //}
                                lstClsCategoryIngredientMapping.Add(objClsCategoryIngredientMapping);
                            }
                        }
                    }

                    List<ClsCategoryIngredientMapping> lstClsCategoryIngredientMappingAll = new List<ClsCategoryIngredientMapping>();
                    foreach (GridViewRow gvrow in gvMenuIngredientInformation.Rows)
                    {
                        CheckBox chkingredient = (CheckBox)gvrow.FindControl("chkingredient");
                        if (chkingredient != null)
                        {

                            ClsCategoryIngredientMapping objClsCategoryIngredientMapping = new ClsCategoryIngredientMapping();

                            Label ingredientId = (Label)gvrow.FindControl("lblIngredientId");
                            if (ingredientId != null)
                            {
                                objClsCategoryIngredientMapping.IngredientId = Convert.ToInt32(ingredientId.Text);
                            }

                            //TextBox txtprice = (TextBox)gvrow.FindControl("txtIngredientPrice");
                            //if (txtprice != null)
                            //{
                            //    objClsCategoryIngredientMapping.IngredientPrice = txtprice.Text;
                            //}
                            lstClsCategoryIngredientMappingAll.Add(objClsCategoryIngredientMapping);

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
                        string ProductImgUrl = objClsProductCategory.GetMenuCategoryImgUrl().tpc_value;

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

                                objClsProductCategory.FileUpload(outputBytes, filename1, ProductImgUrl);
                            }
                        }
                    }
                    else
                    {
                        if (ImgfuImage1.ImageUrl != "")
                        {
                            filename1 = ImgfuImage1.ImageUrl.Replace("/ProjectImages/MenuCategoryImages/", "");
                        }
                    }

                    //category parent static value given is 0
                    //sequencno parent static value given is 0
                    retMsg = objClsProductCategory.UpdateProductCategory(Convert.ToInt32(Request.QueryString["CategoryId"].ToString()), 1, txtSquenceNo.Text, txtCategoryName.Text.Trim(), Convert.ToInt32(0), Description, filename1, lstClsCategoryIngredientMappingAll.ToList(), lstClsCategoryIngredientMapping.ToList(), Convert.ToInt32(Session["UserId"]));

                    if (retMsg == "SUCCESS")
                    {

                        Session["Message"] = "Update";
                        Response.Redirect("~/Admin/MenuCategoryInformation.aspx?", false);
                        //string message = "Category Updated Successfully.";
                        //string url = "MenuCategoryInformation.aspx";
                        //string script = "window.onload = function(){ alert('";
                        //script += message;
                        //script += "');";
                        //script += "window.location = '";
                        //script += url;
                        //script += "'; }";
                        //ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);


                    }
                }

                // Response.Redirect("~/Admin/MenuCategoryInformation.aspx?", false);
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
            Response.Redirect("~/Admin/MenuCategoryInformation.aspx", false);
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

    protected void BtnLogOut_Click(object sender, EventArgs e)
    {
        try
        {
            string confirmValue = hdnfldVariable.Value;
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