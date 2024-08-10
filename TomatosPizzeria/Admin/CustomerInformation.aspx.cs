using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_CustomerInformation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    GetCustomerList();
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

    ClsUserInformation objClsUserInformation = new ClsUserInformation();
    List<tp_user_information> lstUserInformation = new List<tp_user_information>();


    public void GetCustomerList()
    {

        try
        {
            DataTable dt = new DataTable();
            DataView dv = null;

            if (txtSearch.Text == "")
                dt = objClsUserInformation.GetUserList();
            else
                dt = objClsUserInformation.GetUserList(txtSearch.Text.Trim());

            dv = new DataView(dt);
            if (ViewState["SortExpression"] != null)
            {
                string sortExpression = Convert.ToString(ViewState["SortExpression"]);
                dv.Sort = sortExpression + SortDirection;
            }


            if (dv != null && dv.Count > 0)
            {
                gvCustomerInfo.DataSource = dv;
                gvCustomerInfo.DataBind();
            }
            else
            {
                gvCustomerInfo.DataSource = null;
                gvCustomerInfo.DataBind();
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void gvCustomerInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int customerId = 0;
        try
        {

            string retMsg = string.Empty;

            switch (e.CommandName)
            {
                case "First":
                    {
                        gvCustomerInfo.PageIndex = 0;
                        GetCustomerList();
                        break;
                    }
                case "Next":
                    {
                        if (gvCustomerInfo.PageIndex < (gvCustomerInfo.PageCount - 1))
                        {
                            gvCustomerInfo.PageIndex++;
                        }
                        GetCustomerList();
                        break;
                    }
                case "Previous":
                    {
                        if (gvCustomerInfo.PageIndex > 0)
                        {
                            gvCustomerInfo.PageIndex--;
                        }
                        GetCustomerList();
                        break;
                    }

                case "Last":
                    {
                        gvCustomerInfo.PageIndex = gvCustomerInfo.PageCount - 1;
                        GetCustomerList();
                        break;
                    }
            }
            if (e.CommandName == "DeleteCustomer")
            {
                customerId = Convert.ToInt32(e.CommandArgument);

                string confirmValue = hdnfldVariable.Value;
                if (confirmValue == "Yes")
                {

                    retMsg = objClsUserInformation.DeleteUserByID(customerId);
                    if (retMsg == "SUCCESS")
                    {

                        GetCustomerList();

                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('SuccessFully Deleted')", true);
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

    protected void gvCustomerInfo_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            SortExpression = e.SortExpression;
            if (SortDirection == " ASC")
                SortDirection = " DESC";
            else
                SortDirection = " ASC";
            GetCustomerList();
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
            GetCustomerList();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }


    protected void ddlShowData_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlShowData.SelectedIndex == 0)
            {
                gvCustomerInfo.PageSize = 10;
                GetCustomerList();
            }
            else if (ddlShowData.SelectedIndex == 1)
            {
                gvCustomerInfo.PageSize = 15;
                GetCustomerList();
            }
            else if (ddlShowData.SelectedIndex == 2)
            {
                gvCustomerInfo.PageSize = 20;
                GetCustomerList();
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
    protected void btnReset_Click(object sender, EventArgs e)
    {
        try
        {
            txtSearch.Text = "";
            GetCustomerList();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
}