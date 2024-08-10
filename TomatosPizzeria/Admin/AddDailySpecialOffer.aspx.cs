using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddDailySpecialOffer : System.Web.UI.Page
{
    int feastForFiveOfferId;

    ClsDailySpecialsOffer objClsDailySpecialsOffer = new ClsDailySpecialsOffer();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    if (Request.QueryString["DailySpecialOfferId"] != null)
                    {
                        btnAddDailySpecialOffer.Text = "Update Daily Specials Offer";
                        feastForFiveOfferId = Convert.ToInt32(Request.QueryString["DailySpecialOfferId"]);
                        GetAllSize();
                        GetAllProduct();
                        GetAllDailySpecialOfferDetail();
                    }
                    else
                    {
                        btnAddDailySpecialOffer.Text = "Add Daily Specials Offer";

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


    public void GetAllDailySpecialOfferDetail()
    {
        ClsDailySpecialsOffer ClsDailySpecialsOfferobj = new ClsDailySpecialsOffer();
        try
        {
            ClsDailySpecialsOfferobj = objClsDailySpecialsOffer.GetDailySpecialOffer(Convert.ToInt32(Request.QueryString["DailySpecialOfferId"].ToString()));
            if (ClsDailySpecialsOfferobj != null)
            {
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"(<br />|<br/>|</ br>|</br>)");

                CKeditorDescription.Text = regex.Replace(ClsDailySpecialsOfferobj.DailySpecialOfferDescription, "<br/>");
                txtOfferName.Text = ClsDailySpecialsOfferobj.DailySpecialOfferName;
                txtOfferCode.Text = ClsDailySpecialsOfferobj.DailySpecialOfferCode.ToString();

                DdlDay.SelectedValue = ClsDailySpecialsOfferobj.DailySpecialDay.ToString();

                DdlProduct1.SelectedValue = ClsDailySpecialsOfferobj.Product1Id.ToString();
                if (ClsDailySpecialsOfferobj.Product1SizeId.ToString() == "0")
                {
                    DdlProduct1Size.SelectedValue = "-1";
                }
                else
                {
                    DdlProduct1Size.SelectedValue = ClsDailySpecialsOfferobj.Product1SizeId.ToString();
                }
                txtProduct1Quantity.Text = ClsDailySpecialsOfferobj.Product1Quantity.ToString();
                if (ClsDailySpecialsOfferobj.Product2Id.ToString() == "0")
                {
                    DdlProduct2.SelectedValue = "-1";
                }
                else
                {
                    DdlProduct2.SelectedValue = ClsDailySpecialsOfferobj.Product2Id.ToString();
                }
                if (ClsDailySpecialsOfferobj.Product2SizeId.ToString() == "0")
                {
                    DdlProduct2Size.SelectedValue = "-1";
                }
                else
                {

                    DdlProduct2Size.SelectedValue = ClsDailySpecialsOfferobj.Product2SizeId.ToString();
                }
                txtProduct2Quantity.Text = ClsDailySpecialsOfferobj.Product2Quantity.ToString();

                txtOfferAmount.Text = ClsDailySpecialsOfferobj.OfferAmount.ToString();
                txtOfferStartDate.Text = ClsDailySpecialsOfferobj.Offerstartdatestring;
                txtOfferEndDate.Text = ClsDailySpecialsOfferobj.Offerenddatestring;

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
            lsttp_product_sizes = objClsDailySpecialsOffer.GetAllSize();

            DdlProduct1Size.DataSource = lsttp_product_sizes;
            DdlProduct1Size.DataValueField = "ps_id";
            DdlProduct1Size.DataTextField = "ps_name";
            DdlProduct1Size.DataBind();

            DdlProduct2Size.DataSource = lsttp_product_sizes;
            DdlProduct2Size.DataValueField = "ps_id";
            DdlProduct2Size.DataTextField = "ps_name";
            DdlProduct2Size.DataBind();
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
            lsttp_product_details = objClsDailySpecialsOffer.GetAllProduct();

            DdlProduct1.DataSource = lsttp_product_details;
            DdlProduct1.DataValueField = "pd_id";
            DdlProduct1.DataTextField = "pd_name";
            DdlProduct1.DataBind();

            DdlProduct2.DataSource = lsttp_product_details;
            DdlProduct2.DataValueField = "pd_id";
            DdlProduct2.DataTextField = "pd_name";
            DdlProduct2.DataBind();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    protected void btnAddDailySpecialOffer_Click(object sender, EventArgs e)
    {
        string retMsg = string.Empty;
        int product2Id = 0, product1SizeId = 0, product2SizeId = 0, product1Id = 0;

        try
        {
            if (Page.IsValid)
            {

                if (btnAddDailySpecialOffer.Text == "Add Daily Specials Offer")
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

                    if (DdlProduct1.SelectedValue == "-1")
                    {
                        product1Id = 0;
                    }
                    else
                    {
                        product1Id = Convert.ToInt32(DdlProduct1.SelectedValue);
                    }
                    if (DdlProduct1Size.SelectedValue == "-1")
                    {
                        product1SizeId = 0;
                    }
                    else
                    {
                        product1SizeId = Convert.ToInt32(DdlProduct1Size.SelectedValue);
                    }
                    if (DdlProduct2.SelectedValue == "-1")
                    {
                        product2Id = 0;
                    }
                    else
                    {
                        product2Id = Convert.ToInt32(DdlProduct2.SelectedValue);
                    }
                    if (DdlProduct2Size.SelectedValue == "-1")
                    {
                        product2SizeId = 0;
                    }
                    else
                    {
                        product2SizeId = Convert.ToInt32(DdlProduct2Size.SelectedValue);
                    }
                    if (txtProduct2Quantity.Text.Trim() == "")
                    {
                        txtProduct2Quantity.Text = "0";
                    }

                    retMsg = objClsDailySpecialsOffer.InsertDailySpecialsOfferDetail(txtOfferName.Text.Trim(), Description, txtOfferCode.Text.Trim(), Convert.ToInt32(DdlDay.SelectedValue), Convert.ToInt32(product1Id), Convert.ToInt32(txtProduct1Quantity.Text.Trim()), Convert.ToInt32(product1SizeId), Convert.ToInt32(product2Id), Convert.ToInt32(txtProduct2Quantity.Text.Trim()), Convert.ToInt32(product2SizeId), txtOfferAmount.Text.Trim().ToString(), Convert.ToInt32(Session["UserId"]), Convert.ToDateTime(txtOfferStartDate.Text), Convert.ToDateTime(txtOfferEndDate.Text));

                    if (retMsg == "SUCCESS")
                    {
                        Session["Message"] = "AddDailySpecials";
                        Response.Redirect("~/Admin/OfferDetail.aspx?", false);

                    }

                }
                else if (btnAddDailySpecialOffer.Text == "Update Daily Specials Offer")
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
                    if (DdlProduct1.SelectedValue == "-1")
                    {
                        product1Id = 0;
                    }
                    else
                    {
                        product1Id = Convert.ToInt32(DdlProduct1.SelectedValue);
                    }

                    if (DdlProduct1Size.SelectedValue == "-1")
                    {
                        product1SizeId = 0;
                    }
                    else
                    {
                        product1SizeId = Convert.ToInt32(DdlProduct1Size.SelectedValue);
                    }
                    if (DdlProduct2.SelectedValue == "-1")
                    {
                        product2Id = 0;
                    }
                    else
                    {
                        product2Id = Convert.ToInt32(DdlProduct2.SelectedValue);
                    }
                    if (DdlProduct2Size.SelectedValue == "-1")
                    {
                        product2SizeId = 0;
                    }
                    else
                    {
                        product2SizeId = Convert.ToInt32(DdlProduct2Size.SelectedValue);
                    }
                    if (txtProduct2Quantity.Text.Trim() == "")
                    {
                        txtProduct2Quantity.Text = "0";
                    }

                    retMsg = objClsDailySpecialsOffer.UpdateDailySpecialsOfferDetail(Convert.ToInt32(Request.QueryString["DailySpecialOfferId"].ToString()), txtOfferName.Text.Trim(), Description, txtOfferCode.Text.Trim(), Convert.ToInt32(DdlDay.SelectedValue), Convert.ToInt32(product1Id), Convert.ToInt32(txtProduct1Quantity.Text.Trim()), Convert.ToInt32(product1SizeId), Convert.ToInt32(product2Id), Convert.ToInt32(txtProduct2Quantity.Text.Trim()), Convert.ToInt32(product2SizeId), txtOfferAmount.Text.Trim().ToString(), Convert.ToInt32(Session["UserId"]), Convert.ToDateTime(txtOfferStartDate.Text), Convert.ToDateTime(txtOfferEndDate.Text));

                    if (retMsg == "SUCCESS")
                    {
                        Session["Message"] = "UpdateDailySpecials";
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