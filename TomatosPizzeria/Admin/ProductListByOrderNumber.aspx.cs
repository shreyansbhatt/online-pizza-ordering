using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ProductListByOrderNumber : System.Web.UI.Page
{
    string orderNumber;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    if (Request.QueryString["orderNumber"] != null)
                    {

                        orderNumber = (Request.QueryString["orderNumber"]);

                        GetAllMenuItemInformation(orderNumber);
                        lblOrderNumber.Text = orderNumber;
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

    ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();
    public void GetAllMenuItemInformation(string OrderNumber)
    {
        ClsProductDetail objClsProductDetail = new ClsProductDetail();
        DataTable dt = new DataTable();
        DataView dv = null;

        try
        {
            if (txtSearch.Text == "")
                dt = objClsProductDetail.GetProductListByOrderNumber(Request.QueryString["orderNumber"]);
            else
                dt = objClsProductDetail.GetProductListByOrderNumber(Request.QueryString["orderNumber"], txtSearch.Text.Trim());

            ClsUserInformation objClsUserInformation = new ClsUserInformation();
            ClsUserInformation ClsUserInformationobj = new ClsUserInformation();
            objClsUserInformation = ClsUserInformationobj.GetCustomerDetailByOrderId(Request.QueryString["orderNumber"]);
            if (objClsUserInformation != null)
            {
                if (objClsUserInformation.OrderType != null)
                {
                    if (objClsUserInformation.OrderType.Contains("Pick up"))
                    {
                        lbladdress.Visible = false;
                        lblcity.Visible = false;
                        lblstate.Visible = false;
                        lblzipcode.Visible = false;
                        lblDeliveryInstructions.Visible = false;
                        lblCustomerName.Visible = true;
                        lblemail.Visible = true;
                        lblphone.Visible = true;
                        divAddress.Visible = false;
                        divCity.Visible = false;
                        divDeliveryInstruction.Visible = false;
                        divState.Visible = false;
                        divZipcode.Visible = false;
                    }
                    else
                    {
                        lbladdress.Visible = true;
                        lblcity.Visible = true;
                        lblstate.Visible = true;
                        lblzipcode.Visible = true;
                        lblDeliveryInstructions.Visible = true;
                        lblCustomerName.Visible = true;
                        lblemail.Visible = true;
                        lblphone.Visible = true;
                    }
                }
                lblCustomerName.Text = objClsUserInformation.CustomerName;
                lbladdress.Text = objClsUserInformation.Addressline1;
                lblemail.Text = objClsUserInformation.Email;
                lblcity.Text = objClsUserInformation.CityName;
                lblstate.Text = objClsUserInformation.StateName;
                lblzipcode.Text = objClsUserInformation.Pincode;
                lblOrderType.Text = objClsUserInformation.OrderType;
                lblphone.Text = objClsUserInformation.TelephoneNo;
                lblDeliveryInstructions.Text = objClsUserInformation.DeliveryInstruction;
                lblOrderTotalAmount.Text = objClsUserInformation.OrderTotalAmount;
                lblDeliveryCharges.Text = objClsUserInformation.DeliveryCharges;
                lblSalesTax.Text = objClsUserInformation.SalesTax;
            }

            dv = new DataView(dt);
            if (ViewState["SortExpression"] != null)
            {
                string sortExpression = Convert.ToString(ViewState["SortExpression"]);
                dv.Sort = sortExpression + SortDirection;
            }

            if (dv != null && dv.Count > 0)
            {
                gvMenuItemInformation.DataSource = dv;
                gvMenuItemInformation.DataBind();
            }
            else
            {
                gvMenuItemInformation.DataSource = null;
                gvMenuItemInformation.DataBind();
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    public string SortDirection
    {
        get
        {
            if (ViewState["SortDirection"] == null)
                ViewState["SortDirection"] = " ASC";

            return (string)ViewState["SortDirection"];
        }
        set { ViewState["SortDirection"] = value; }
    }

    public string SortExpression
    {
        get
        {
            if (ViewState["SortExpression"] == null)
                ViewState["SortExpression"] = "Name";

            return (string)ViewState["SortExpression"];
        }
        set { ViewState["SortExpression"] = value; }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            GetAllMenuItemInformation(Request.QueryString["orderNumber"]);
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    //protected void ddlShowData_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (ddlShowData.SelectedIndex == 0)
    //        {
    //            gvMenuItemInformation.PageSize = 5;
    //            GetAllMenuItemInformation(Request.QueryString["orderNumber"]);
    //        }
    //        else if (ddlShowData.SelectedIndex == 1)
    //        {
    //            gvMenuItemInformation.PageSize = 10;
    //            GetAllMenuItemInformation(Request.QueryString["orderNumber"]);
    //        }
    //        else if (ddlShowData.SelectedIndex == 2)
    //        {
    //            gvMenuItemInformation.PageSize = 15;
    //            GetAllMenuItemInformation(Request.QueryString["orderNumber"]);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        ErrorHandler.WriteError(ex);
    //    }
    //}



    protected void gvMenuItemInformation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        ClsProductDetail objClsProductDetail = new ClsProductDetail();
        DataTable dt = new DataTable();
        DataView dv = new DataView();
        string Description = "";

        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gvMenuItemIngeredientInformation = (GridView)e.Row.FindControl("gvMenuItemIngeredientInformation");
                Label lblProductDetailId = ((Label)e.Row.FindControl("lblProductDetailId"));

                dt = objClsProductDetail.GetDefaultOrderProductListByIngredient(Convert.ToInt32(lblProductDetailId.Text), Request.QueryString["orderNumber"]);

                dv = new DataView(dt);

                if (ViewState["SortExpressionProperties"] != null)
                {
                    string sortExpression = Convert.ToString(ViewState["SortExpressionProperties"]);
                    dv.Sort = sortExpression + SortDirection;
                }

                if (dv != null && dv.Count > 0)
                {
                    gvMenuItemIngeredientInformation.DataSource = dv;
                    gvMenuItemIngeredientInformation.DataBind();
                }
                else
                {
                    gvMenuItemIngeredientInformation.DataSource = null;
                    gvMenuItemIngeredientInformation.DataBind();
                }

                GridView gvExtraMenuItemIngeredientInformation = (GridView)e.Row.FindControl("gvExtraMenuItemIngeredientInformation");

                dt = objClsProductDetail.GetExtraOrderProductListByIngredient(Convert.ToInt32(lblProductDetailId.Text), Request.QueryString["orderNumber"]);

                dv = new DataView(dt);

                if (ViewState["SortExpressionProperties"] != null)
                {
                    string sortExpression = Convert.ToString(ViewState["SortExpressionProperties"]);
                    dv.Sort = sortExpression + SortDirection;
                }

                if (dv != null && dv.Count > 0)
                {
                    gvExtraMenuItemIngeredientInformation.DataSource = dv;
                    gvExtraMenuItemIngeredientInformation.DataBind();
                }
                else
                {
                    gvExtraMenuItemIngeredientInformation.DataSource = null;
                    gvExtraMenuItemIngeredientInformation.DataBind();
                }

                GridView gvMenuItemIngeredientFactInformation = (GridView)e.Row.FindControl("gvMenuItemIngeredientFactInformation");

                //get ingredient
                dt = objClsProductDetail.GetOrderIngredientFactOfProduct(Convert.ToInt32(lblProductDetailId.Text), Request.QueryString["orderNumber"]);

                dv = new DataView(dt);

                if (ViewState["SortExpressionProperties"] != null)
                {
                    string sortExpression = Convert.ToString(ViewState["SortExpressionProperties"]);
                    dv.Sort = sortExpression + SortDirection;
                }

                if (dv != null && dv.Count > 0)
                {
                    gvMenuItemIngeredientFactInformation.DataSource = dv;
                    gvMenuItemIngeredientFactInformation.DataBind();
                }
                else
                {
                    gvMenuItemIngeredientFactInformation.DataSource = null;
                    gvMenuItemIngeredientFactInformation.DataBind();
                }


                GridView gvMenuItemPropertiesInformation = (GridView)e.Row.FindControl("gvMenuItemPropertiesInformation");

                Label lblPropertiesID = (Label)e.Row.FindControl("lblPropertiesID");
                if (lblPropertiesID != null)
                {

                    int propertiesId = 0;
                    if (lblPropertiesID.Text!="")
                    {
                        propertiesId = Convert.ToInt32(lblPropertiesID.Text);
                    }
                    dt = objClsProductDetail.GetOrderProductPropertiesByPropertyId(Convert.ToInt32(propertiesId));
                    // dt = objClsProductDetail.GetOrderProductPropertiesByProductId(Convert.ToInt32(lblProductDetailId.Text), Request.QueryString["orderNumber"]);

                    dv = new DataView(dt);

                    if (ViewState["SortExpressionProperties"] != null)
                    {
                        string sortExpression = Convert.ToString(ViewState["SortExpressionProperties"]);
                        dv.Sort = sortExpression + SortDirection;
                    }

                    if (dv != null && dv.Count > 0)
                    {
                        gvMenuItemPropertiesInformation.DataSource = dv;
                        gvMenuItemPropertiesInformation.DataBind();
                    }
                    else
                    {
                        gvMenuItemPropertiesInformation.DataSource = null;
                        gvMenuItemPropertiesInformation.DataBind();
                    }
                }
                Label txtDescription = ((Label)e.Row.FindControl("lblMenuItemDescription"));
                Description = txtDescription.Text;
                //preg_replace( '[^(<br( \/)?>)*|(<br( \/)?>)*$]', '', Description );
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"(<br />|<br/>|</ br>|</br>)");
                // System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"([^(<br( \/)?>)*|(<br( \/)?>)*$])");
                // Description = Description.Replace(@"([^(<br( \/)?>)*|(<br( \/)?>)*$])", "");
                Description = regex.Replace(Description, "<br/>");
                Description = Description.Replace("<br/>", "\n");
                Description = Description.Replace("\n", System.Environment.NewLine);
                Description = Description.Replace("&nbsp;", "");
                if (Description != null)
                {
                    if (Description.Length > 25)
                    {
                        txtDescription.Text = Description.Substring(0, 25);
                    }
                    else
                    {
                        txtDescription.Text = Description;
                    }
                    txtDescription.ToolTip = Description.Replace("<br/>", System.Environment.NewLine);
                }

            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void gvMenuItemInformation_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            SortExpression = e.SortExpression;
            if (SortDirection == " ASC")
                SortDirection = " DESC";
            else
                SortDirection = " ASC";
            GetAllMenuItemInformation(Request.QueryString["orderNumber"]);
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void gvMenuItemInformation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            ClsProductDetail objClsProductDetail = new ClsProductDetail();
            string retMsg = string.Empty;

            switch (e.CommandName)
            {
                case "First":
                    {
                        gvMenuItemInformation.PageIndex = 0;
                        GetAllMenuItemInformation(Request.QueryString["orderNumber"]);
                        break;
                    }
                case "Next":
                    {
                        if (gvMenuItemInformation.PageIndex < (gvMenuItemInformation.PageCount - 1))
                        {
                            gvMenuItemInformation.PageIndex++;
                        }
                        GetAllMenuItemInformation(Request.QueryString["orderNumber"]);
                        break;
                    }
                case "Previous":
                    {
                        if (gvMenuItemInformation.PageIndex > 0)
                        {
                            gvMenuItemInformation.PageIndex--;
                        }
                        GetAllMenuItemInformation(Request.QueryString["orderNumber"]);
                        break;
                    }

                case "Last":
                    {
                        gvMenuItemInformation.PageIndex = gvMenuItemInformation.PageCount - 1;
                        GetAllMenuItemInformation(Request.QueryString["orderNumber"]);
                        break;
                    }
            }


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
}