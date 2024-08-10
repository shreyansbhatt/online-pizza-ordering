using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddFeastForFiveOffer : System.Web.UI.Page
{
    int feastForFiveOfferId;

    ClsFeastForFiveOffer objClsFeastForFiveOffer = new ClsFeastForFiveOffer();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    if (Request.QueryString["FeastForFiveOfferId"] != null)
                    {
                        btnAddFeastForFiveOffer.Text = "Update Feast For Five Offer";
                        feastForFiveOfferId = Convert.ToInt32(Request.QueryString["FeastForFiveOfferId"]);
                        GetAllSize();
                        GetAllProduct();
                        GetAllFeastForFiveOfferDetail();
                    }
                    else
                    {
                        btnAddFeastForFiveOffer.Text = "Add Feast For Five Offer";

                        GetAllSize();
                        GetAllProduct();

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

    public void GetAllFeastForFiveOfferDetail()
    {
        ClsFeastForFiveOffer ClsFeastForFiveOfferobj = new ClsFeastForFiveOffer();
        try
        { 
        ClsFeastForFiveOfferobj = objClsFeastForFiveOffer.GetFeastForFiveOffer(Convert.ToInt32(Request.QueryString["FeastForFiveOfferId"].ToString()));
        if (ClsFeastForFiveOfferobj != null)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"(<br />|<br/>|</ br>|</br>)");

            CKeditorDescription.Text = regex.Replace(ClsFeastForFiveOfferobj.FeastForFiveDescription, "<br/>");
            txtOfferName.Text = ClsFeastForFiveOfferobj.FeastForFiveOfferName;
            txtOfferCode.Text = ClsFeastForFiveOfferobj.FeastForFiveOfferCode.ToString();

            DdlProduct1.SelectedValue = ClsFeastForFiveOfferobj.Product1Id.ToString();
            if (ClsFeastForFiveOfferobj.Product1SizeId.ToString() == "0")
            {
                DdlProduct1Size.SelectedValue = "-1";
            }
            else
            {
                DdlProduct1Size.SelectedValue = ClsFeastForFiveOfferobj.Product1SizeId.ToString(); 
            }
            
            txtProduct1Quantity.Text = ClsFeastForFiveOfferobj.Product1Quantity.ToString();

            DdlProduct2.SelectedValue = ClsFeastForFiveOfferobj.Product2Id.ToString();
            txtProduct2Quantity.Text = ClsFeastForFiveOfferobj.Product2Quantity.ToString();
            DdlProduct3.SelectedValue = ClsFeastForFiveOfferobj.Product3Id.ToString();
            txtProduct3Quantity.Text = ClsFeastForFiveOfferobj.Prodcut3Quantity.ToString();
            txtOfferAmount.Text = ClsFeastForFiveOfferobj.OfferAmount.ToString();
            txtOfferStartDate.Text = ClsFeastForFiveOfferobj.Offerstartdatestring;
            txtOfferEndDate.Text = ClsFeastForFiveOfferobj.Offerenddatestring;

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
        lsttp_product_sizes = objClsFeastForFiveOffer.GetAllSize();

        DdlProduct1Size.DataSource = lsttp_product_sizes;
        DdlProduct1Size.DataValueField = "ps_id";
        DdlProduct1Size.DataTextField = "ps_name";
        DdlProduct1Size.DataBind();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    public void GetAllProduct()
    {
        List<tp_product_details> lsttp_product_details = new List<tp_product_details>();
        try
        { 
        lsttp_product_details = objClsFeastForFiveOffer.GetAllProduct();

        DdlProduct1.DataSource = lsttp_product_details;
        DdlProduct1.DataValueField = "pd_id";
        DdlProduct1.DataTextField = "pd_name";
        DdlProduct1.DataBind();

        DdlProduct2.DataSource = lsttp_product_details;
        DdlProduct2.DataValueField = "pd_id";
        DdlProduct2.DataTextField = "pd_name";
        DdlProduct2.DataBind();

        DdlProduct3.DataSource = lsttp_product_details;
        DdlProduct3.DataValueField = "pd_id";
        DdlProduct3.DataTextField = "pd_name";
        DdlProduct3.DataBind();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }

    }
    protected void btnAddFeastForFiveOffer_Click(object sender, EventArgs e)
    {
        string retMsg = string.Empty;
        int product1SizeId = 0;

        try
        {
            if (Page.IsValid)
            {

                if (btnAddFeastForFiveOffer.Text == "Add Feast For Five Offer")
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

                    if (DdlProduct1Size.SelectedValue == "-1")
                    {
                        product1SizeId = 0;
                    }
                    else
                    {
                        product1SizeId = Convert.ToInt32(DdlProduct1Size.SelectedValue);
                    }

                    retMsg = objClsFeastForFiveOffer.InsertFeastForFiveOfferDetail(txtOfferName.Text.Trim(), Description, txtOfferCode.Text.Trim(), Convert.ToInt32(DdlProduct1.SelectedValue), Convert.ToInt32(txtProduct1Quantity.Text.Trim()), Convert.ToInt32(product1SizeId), Convert.ToInt32(DdlProduct2.SelectedValue), Convert.ToInt32(txtProduct2Quantity.Text.Trim()), Convert.ToInt32(DdlProduct3.SelectedValue), Convert.ToInt32(txtProduct3Quantity.Text.Trim()), txtOfferAmount.Text.Trim(), Convert.ToInt32(Session["UserId"]), Convert.ToDateTime(txtOfferStartDate.Text), Convert.ToDateTime(txtOfferEndDate.Text));

                    if (retMsg == "SUCCESS")
                    {
                        Session["Message"] = "AddFeastForFive";
                        Response.Redirect("~/Admin/OfferDetail.aspx?", false);

                    }

                }
                else if (btnAddFeastForFiveOffer.Text == "Update Feast For Five Offer")
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

                    if (DdlProduct1Size.SelectedValue == "-1")
                    {
                        product1SizeId = 0;
                    }
                    else
                    {
                        product1SizeId = Convert.ToInt32(DdlProduct1Size.SelectedValue);
                    }

                    retMsg = objClsFeastForFiveOffer.UpdateFeastForFiveOfferDetail(Convert.ToInt32(Request.QueryString["FeastForFiveOfferId"].ToString()), txtOfferName.Text.Trim(), Description, txtOfferCode.Text.Trim(), Convert.ToInt32(DdlProduct1.SelectedValue), Convert.ToInt32(txtProduct1Quantity.Text.Trim()), Convert.ToInt32(product1SizeId), Convert.ToInt32(DdlProduct2.SelectedValue), Convert.ToInt32(txtProduct2Quantity.Text.Trim()), Convert.ToInt32(DdlProduct3.SelectedValue), Convert.ToInt32(txtProduct3Quantity.Text.Trim()), txtOfferAmount.Text.Trim(), Convert.ToInt32(Session["UserId"]), Convert.ToDateTime(txtOfferStartDate.Text), Convert.ToDateTime(txtOfferEndDate.Text));

                    if (retMsg == "SUCCESS")
                    {
                        Session["Message"] = "UpdateFeastForFive";
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
}