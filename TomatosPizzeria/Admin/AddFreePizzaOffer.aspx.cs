using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddFreePizzaOffer : System.Web.UI.Page
{
    int freePizzaOfferId;

    ClsFreePizzaOffer objClsFreePizzaOffer = new ClsFreePizzaOffer();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    if (Request.QueryString["FreePizzaOfferId"] != null)
                    {
                        btnAddFreePizzaOffer.Text = "Update Free Pizza Offer";
                        freePizzaOfferId = Convert.ToInt32(Request.QueryString["FreePizzaOfferId"]);


                        GetAllIngredients();

                       // GetAllSizeFreeProduct();
                        GetAllSizeValidateProduct();
                        GetAllValidateProduct();
                        GetAllFreeProduct();
                        GetAllFreePizzaOfferDetail();

                    }
                    else
                    {
                        btnAddFreePizzaOffer.Text = "Add Free Pizza Offer";


                        GetAllIngredients();

                        GetAllSizeFreeProduct();
                        GetAllSizeValidateProduct();
                        GetAllValidateProduct();
                        GetAllFreeProduct();


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

    public void GetAllFreePizzaOfferDetail()
    {
        ClsFreePizzaOffer ClsFreePizzaOfferobj = new ClsFreePizzaOffer();
        try
        {
            ClsFreePizzaOfferobj = objClsFreePizzaOffer.GetFreePizzaOffer(Convert.ToInt32(Request.QueryString["FreePizzaOfferId"].ToString()));
            if (ClsFreePizzaOfferobj != null)
            {
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"(<br />|<br/>|</ br>|</br>)");

                CKeditorDescription.Text = regex.Replace(ClsFreePizzaOfferobj.FreePizzaOfferDescription, "<br/>");
                txtOfferName.Text = ClsFreePizzaOfferobj.FreePizzaOfferName;
                txtOfferCode.Text = ClsFreePizzaOfferobj.FreePizzaOfferCode.ToString();

                DdlFreeProduct.SelectedValue = ClsFreePizzaOfferobj.FreeProductId.ToString();
                DdlFreeProductSize.SelectedValue = ClsFreePizzaOfferobj.FreeProductSizeId.ToString();

                DdlValidateProduct.SelectedValue = ClsFreePizzaOfferobj.ValidateProductId.ToString();
                if (ClsFreePizzaOfferobj.ValidateIngredientId.ToString() == "0")
                {
                    DdlValidateProductIngredient.SelectedValue = "-1";
                }
                else
                {
                    DdlValidateProductIngredient.SelectedValue = ClsFreePizzaOfferobj.ValidateIngredientId.ToString();
                }
                DdlValidateProductSize.SelectedValue = ClsFreePizzaOfferobj.ValidateProductSizeId.ToString();

                txtOfferStartDate.Text = ClsFreePizzaOfferobj.Offerstartdatestring;
                txtOfferEndDate.Text = ClsFreePizzaOfferobj.Offerenddatestring;
            }

        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }


    public void GetAllIngredients()
    {
        List<tp_ingredient_details> lsttp_ingredient_details = new List<tp_ingredient_details>();
        try
        {
            lsttp_ingredient_details = objClsFreePizzaOffer.GetAllIngredient();
            if (lsttp_ingredient_details != null)
            {
                DdlValidateProductIngredient.DataSource = lsttp_ingredient_details;
                DdlValidateProductIngredient.DataValueField = "id_id";
                DdlValidateProductIngredient.DataTextField = "id_name";

                DdlValidateProductIngredient.DataBind();
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    public void GetAllSizeFreeProduct()
    {
        List<tp_product_sizes> lsttp_product_sizes = new List<tp_product_sizes>();
        DataTable dt = new DataTable();

        try
        {
            //lsttp_product_sizes = objClsFreePizzaOffer.GetAllSize();
            dt = objClsFreePizzaOffer.GetSizeByProductId(Convert.ToInt32(DdlFreeProduct.SelectedValue));
            DdlFreeProductSize.DataSource = dt;
            DdlFreeProductSize.DataValueField = "SizeId";
            DdlFreeProductSize.DataTextField = "SizeName";
            DdlFreeProductSize.DataBind();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    public void GetAllSizeValidateProduct()
    {
        List<tp_product_sizes> lsttp_product_sizes = new List<tp_product_sizes>();
        DataTable dt = new DataTable();

        try
        {
            dt = objClsFreePizzaOffer.GetSizeByProductId(Convert.ToInt32(DdlValidateProduct.SelectedValue));

            DdlValidateProductSize.DataSource = dt;
            DdlValidateProductSize.DataValueField = "SizeId";
            DdlValidateProductSize.DataTextField = "SizeName";
            DdlValidateProductSize.DataBind();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    public void GetAllFreeProduct()
    {
        List<tp_product_details> lsttp_product_details = new List<tp_product_details>();
        try
        {
            lsttp_product_details = objClsFreePizzaOffer.GetAllProduct();

            DdlFreeProduct.DataSource = lsttp_product_details;
            DdlFreeProduct.DataValueField = "pd_id";
            DdlFreeProduct.DataTextField = "pd_name";
            DdlFreeProduct.DataBind();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    public void GetAllValidateProduct()
    {
        List<tp_product_details> lsttp_product_details = new List<tp_product_details>();
        try
        {
            lsttp_product_details = objClsFreePizzaOffer.GetAllProduct();

            DdlValidateProduct.DataSource = lsttp_product_details;
            DdlValidateProduct.DataValueField = "pd_id";
            DdlValidateProduct.DataTextField = "pd_name";
            DdlValidateProduct.DataBind();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    protected void btnAddFreePizzaOffer_Click(object sender, EventArgs e)
    {
        string retMsg = string.Empty;
        int validateIngredientId = 0;


        try
        {
            if (Page.IsValid)
            {

                if (btnAddFreePizzaOffer.Text == "Add Free Pizza Offer")
                {

                    string text = CKeditorDescription.Text;
                    text = text.Replace("\n", "<br />");
                    text = text.Replace("\t", "\n");
                    string Description = string.Empty;
                    Regex tagRemove = new Regex(@"<[^>]*(>|$)");
                    Regex compressSpaces = new Regex(@"[\s\r]+");
                    Description = tagRemove.Replace(text, string.Empty);
                    Description = Description.Replace("\n", "<br />");
                    Description = compressSpaces.Replace(Description, " ");
                    if (DdlValidateProductIngredient.SelectedValue == "-1")
                    {
                        validateIngredientId = 0;
                    }
                    else
                    {
                        validateIngredientId = Convert.ToInt32(DdlValidateProductIngredient.SelectedValue);
                    }

                    retMsg = objClsFreePizzaOffer.InsertFreePizzaOfferDetail(txtOfferName.Text.Trim(), Description, txtOfferCode.Text.Trim(), Convert.ToInt32(DdlFreeProduct.SelectedValue), Convert.ToInt32(DdlFreeProductSize.SelectedValue), Convert.ToInt32(DdlValidateProduct.SelectedValue), Convert.ToInt32(validateIngredientId), Convert.ToInt32(DdlValidateProductSize.SelectedValue), Convert.ToInt32(Session["UserId"]), Convert.ToDateTime(txtOfferStartDate.Text), Convert.ToDateTime(txtOfferEndDate.Text));

                    if (retMsg == "SUCCESS")
                    {
                        Session["Message"] = "AddFreePizza";
                        Response.Redirect("~/Admin/OfferDetail.aspx?", false);

                    }

                }
                else if (btnAddFreePizzaOffer.Text == "Update Free Pizza Offer")
                {

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
                    if (DdlValidateProductIngredient.SelectedValue == "-1")
                    {
                        validateIngredientId = 0;
                    }
                    else
                    {
                        validateIngredientId = Convert.ToInt32(DdlValidateProductIngredient.SelectedValue);
                    }

                    retMsg = objClsFreePizzaOffer.UpdateFreePizzaOfferDetail(Convert.ToInt32(Request.QueryString["FreePizzaOfferId"].ToString()), txtOfferName.Text.Trim(), Description, txtOfferCode.Text.Trim(), Convert.ToInt32(DdlFreeProduct.SelectedValue), Convert.ToInt32(DdlFreeProductSize.SelectedValue), Convert.ToInt32(DdlValidateProduct.SelectedValue), Convert.ToInt32(validateIngredientId), Convert.ToInt32(DdlValidateProductSize.SelectedValue), Convert.ToInt32(Session["UserId"]), Convert.ToDateTime(txtOfferStartDate.Text), Convert.ToDateTime(txtOfferEndDate.Text));

                    if (retMsg == "SUCCESS")
                    {
                        Session["Message"] = "UpdateFreePizza";
                        Response.Redirect("~/Admin/OfferDetail.aspx?", false);



                    }
                }


            }

        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Admin/OfferDetail.aspx", false);
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
    protected void DdlFreeProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GetAllSizeFreeProduct();
        }
        catch(Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    protected void DdlValidateProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GetAllSizeValidateProduct();
        }
        catch(Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
}