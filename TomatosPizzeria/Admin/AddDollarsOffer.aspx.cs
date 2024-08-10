using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddDollarsOffer : System.Web.UI.Page
{
    int dollarsOfferId;

    ClsDollarsOffer objClsDollarsOffer = new ClsDollarsOffer();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    if (Request.QueryString["DollarsOfferId"] != null)
                    {
                        btnAddDollarsOffer.Text = "Update Dollars Offer";
                        dollarsOfferId = Convert.ToInt32(Request.QueryString["DollarsOfferId"]);
                        GetAllSize();
                        GetAllDollarsOfferDetail();

                    }
                    else
                    {
                        btnAddDollarsOffer.Text = "Add Dollars Offer";

                        GetAllSize();

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

    public void GetAllDollarsOfferDetail()
    {
        ClsDollarsOffer ClsDollarsOfferobj = new ClsDollarsOffer();
        try
        {
            ClsDollarsOfferobj = objClsDollarsOffer.GetDollarsOffer(Convert.ToInt32(Request.QueryString["DollarsOfferId"].ToString()));
            if (ClsDollarsOfferobj != null)
            {
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"(<br />|<br/>|</ br>|</br>)");

                CKeditorDescription.Text = regex.Replace(ClsDollarsOfferobj.DollarsOfferDescription, "<br/>");
                txtOfferName.Text = ClsDollarsOfferobj.DollarsOfferName;
                txtOfferCode.Text = ClsDollarsOfferobj.DollarsOfferCode.ToString();

                DdlProductSize.SelectedValue = ClsDollarsOfferobj.ProductSizeId.ToString();
                txtOfferAmount.Text = ClsDollarsOfferobj.OfferAmount.ToString();

                txtOfferStartDate.Text = ClsDollarsOfferobj.Offerstartdatestring;
                txtOfferEndDate.Text = ClsDollarsOfferobj.Offerenddatestring;
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
            lsttp_product_sizes = objClsDollarsOffer.GetAllSize();

            DdlProductSize.DataSource = lsttp_product_sizes;
            DdlProductSize.DataValueField = "ps_id";
            DdlProductSize.DataTextField = "ps_name";
            DdlProductSize.DataBind();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    protected void btnAddDollarsOffer_Click(object sender, EventArgs e)
    {
        string retMsg = string.Empty;

        try
        {
            if (Page.IsValid)
            {

                if (btnAddDollarsOffer.Text == "Add Dollars Offer")
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

                    retMsg = objClsDollarsOffer.InsertDollarsOfferDetail(txtOfferName.Text.Trim(), Description, txtOfferCode.Text.Trim(), Convert.ToInt32(DdlProductSize.SelectedValue), txtOfferAmount.Text.Trim(), Convert.ToInt32(Session["UserId"]), Convert.ToDateTime(txtOfferStartDate.Text), Convert.ToDateTime(txtOfferEndDate.Text));

                    if (retMsg == "SUCCESS")
                    {
                        Session["Message"] = "AddDollars";
                        Response.Redirect("~/Admin/OfferDetail.aspx?", false);

                    }

                }
                else if (btnAddDollarsOffer.Text == "Update Dollars Offer")
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


                    retMsg = objClsDollarsOffer.UpdateDollarsOfferDetail(Convert.ToInt32(Request.QueryString["DollarsOfferId"].ToString()), txtOfferName.Text.Trim(), Description, txtOfferCode.Text.Trim(), Convert.ToInt32(DdlProductSize.SelectedValue), txtOfferAmount.Text.Trim(), Convert.ToInt32(Session["UserId"]), Convert.ToDateTime(txtOfferStartDate.Text), Convert.ToDateTime(txtOfferEndDate.Text));

                    if (retMsg == "SUCCESS")
                    {
                        Session["Message"] = "UpdateDollars";
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