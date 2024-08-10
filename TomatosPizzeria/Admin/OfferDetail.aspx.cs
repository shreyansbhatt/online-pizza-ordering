using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_OfferDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserId"] != null)
            {
                if (Session["Message"] != null)
                {
                    if (Session["Message"].ToString() == "AddFreePizza")
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Free Pizza Offer Detail Added Successfully.')", true);
                        Session["Message"] = null;
                    }
                    else if (Session["Message"].ToString() == "UpdateFreePizza")
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Free Pizza Offer Detail Updated Successfully.')", true);
                        Session["Message"] = null;
                    }

                    else if (Session["Message"].ToString() == "AddDollars")
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Dollars Offer Detail Added Successfully.')", true);
                        Session["Message"] = null;
                    }
                    else if (Session["Message"].ToString() == "UpdateDollars")
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Dollars Offer Detail Updated Successfully.')", true);
                        Session["Message"] = null;
                    }

                    else if (Session["Message"].ToString() == "AddFeastForFive")
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Feast For Five Offer Detail Added Successfully.')", true);
                        Session["Message"] = null;
                    }
                    else if (Session["Message"].ToString() == "UpdateFeastForFive")
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Feast For Five Offer Detail Updated Successfully.')", true);
                        Session["Message"] = null;
                    }

                    else if (Session["Message"].ToString() == "AddDailySpecials")
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Daily Specials Offer Detail Added Successfully.')", true);
                        Session["Message"] = null;
                    }
                    else if (Session["Message"].ToString() == "UpdateDailySpecials")
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Daily Specials Offer Detail Updated Successfully.')", true);
                        Session["Message"] = null;
                    }
                }
                if (!IsPostBack)
                {
                    GetAllFreePizzaOfferDetail();
                    GetAllDollarsOfferDetail();
                    GetAllFeastForFiveOfferDetail();
                    GetAllDailySpecialOfferDetail();
                }
            }
            else
            {
                Response.Redirect("~/Index.aspx", false);
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    public void GetAllFreePizzaOfferDetail()
    {
        ClsFreePizzaOffer objClsFreePizzaOffer = new ClsFreePizzaOffer();
        DataTable dt = new DataTable();
        DataView dv = null;

        try
        {
            if (txtFreePizzaSearch.Text == "")
                dt = objClsFreePizzaOffer.GetFreePizzaOfferDetailList();
            else
                dt = objClsFreePizzaOffer.GetFreePizzaOfferDetailList(txtFreePizzaSearch.Text.Trim().Replace("\"", ""));


            dv = new DataView(dt);

            if (dv != null && dv.Count > 0)
            {
                gvFreePizzaOffer.DataSource = dv;
                gvFreePizzaOffer.DataBind();
            }
            else
            {
                gvFreePizzaOffer.DataSource = null;
                gvFreePizzaOffer.DataBind();
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    public void GetAllDollarsOfferDetail()
    {
        ClsDollarsOffer objClsDollarsOffer = new ClsDollarsOffer();
        DataTable dt = new DataTable();
        DataView dv = null;

        try
        {
            if (txtDollarsSearch.Text == "")
                dt = objClsDollarsOffer.GetDollarsOfferDetailList();
            else

                dt = objClsDollarsOffer.GetDollarsOfferDetailList(txtDollarsSearch.Text.Trim().Replace("\"", ""));


            dv = new DataView(dt);

            if (dv != null && dv.Count > 0)
            {
                gvDollarsOffer.DataSource = dv;
                gvDollarsOffer.DataBind();
            }
            else
            {
                gvDollarsOffer.DataSource = null;
                gvDollarsOffer.DataBind();
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    public void GetAllFeastForFiveOfferDetail()
    {
        ClsFeastForFiveOffer objClsFeastForFiveOffer = new ClsFeastForFiveOffer();
        DataTable dt = new DataTable();
        DataView dv = null;

        try
        {
            if (txtFeastForFiveSearch.Text == "")
                dt = objClsFeastForFiveOffer.GetFeastForFiveOfferDetailList();
            else
                dt = objClsFeastForFiveOffer.GetFeastForFiveOfferDetailList(txtFeastForFiveSearch.Text.Trim().Replace("\"", ""));


            dv = new DataView(dt);

            if (dv != null && dv.Count > 0)
            {
                gvFeastForFiveOffer.DataSource = dv;
                gvFeastForFiveOffer.DataBind();
            }
            else
            {
                gvFeastForFiveOffer.DataSource = null;
                gvFeastForFiveOffer.DataBind();
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    public void GetAllDailySpecialOfferDetail()
    {
        ClsDailySpecialsOffer objClsDailySpecialsOffer = new ClsDailySpecialsOffer();
        DataTable dt = new DataTable();
        DataView dv = null;

        try
        {
            if (txtDailySpecialsSearch.Text == "")
                dt = objClsDailySpecialsOffer.GetDailySpecialOfferDetailList();
            else
                dt = objClsDailySpecialsOffer.GetDailySpecialOfferDetailList(txtDailySpecialsSearch.Text.Trim().Replace("\"", ""));


            dv = new DataView(dt);

            if (dv != null && dv.Count > 0)
            {
                gvDailySpecialsOffer.DataSource = dv;
                gvDailySpecialsOffer.DataBind();
            }
            else
            {
                gvDailySpecialsOffer.DataSource = null;
                gvDailySpecialsOffer.DataBind();
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }


    protected void gvFreePizzaOffer_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int freePizzaOfferId = 0;
            ClsFreePizzaOffer objClsFreePizzaOffer = new ClsFreePizzaOffer();
            string retMsg = string.Empty;
            switch (e.CommandName)
            {
                case "First":
                    {
                        gvFreePizzaOffer.PageIndex = 0;
                        GetAllFreePizzaOfferDetail();
                        break;
                    }
                case "Next":
                    {
                        if (gvFreePizzaOffer.PageIndex < (gvFreePizzaOffer.PageCount - 1))
                        {
                            gvFreePizzaOffer.PageIndex++;
                        }
                        GetAllFreePizzaOfferDetail();
                        break;
                    }
                case "Previous":
                    {
                        if (gvFreePizzaOffer.PageIndex > 0)
                        {
                            gvFreePizzaOffer.PageIndex--;
                        }
                        GetAllFreePizzaOfferDetail();
                        break;
                    }

                case "Last":
                    {
                        gvFreePizzaOffer.PageIndex = gvFreePizzaOffer.PageCount - 1;
                        GetAllFreePizzaOfferDetail();
                        break;
                    }
            }
            freePizzaOfferId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "EditFreePizzaOffer")
            {
                string url = "~/Admin/AddFreePizzaOffer.aspx?FreePizzaOfferId=" + freePizzaOfferId;
                Response.Redirect(url, false);
            }
            else if (e.CommandName == "DeleteFreePizzaOffer")
            {
                string confirmValue = hdnfldVariable.Value;
                if (confirmValue == "Yes")
                {

                    retMsg = objClsFreePizzaOffer.DeleteFreePizzaOfferDetail(freePizzaOfferId);
                    if (retMsg == "SUCCESS")
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Menu Item Deleted Successfully')", true);
                    }
                    GetAllFreePizzaOfferDetail();
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void btnFreePizzaOffer_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Admin/AddFreePizzaOffer.aspx", false);
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void gvDollarsOffer_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int dollarsOfferId = 0;
            ClsDollarsOffer objClsDollarsOffer = new ClsDollarsOffer();
            string retMsg = string.Empty;
            switch (e.CommandName)
            {
                case "First":
                    {
                        gvDollarsOffer.PageIndex = 0;
                        GetAllDollarsOfferDetail();
                        break;
                    }
                case "Next":
                    {
                        if (gvDollarsOffer.PageIndex < (gvDollarsOffer.PageCount - 1))
                        {
                            gvDollarsOffer.PageIndex++;
                        }
                        GetAllDollarsOfferDetail();
                        break;
                    }
                case "Previous":
                    {
                        if (gvDollarsOffer.PageIndex > 0)
                        {
                            gvDollarsOffer.PageIndex--;
                        }
                        GetAllDollarsOfferDetail();
                        break;
                    }

                case "Last":
                    {
                        gvDollarsOffer.PageIndex = gvDollarsOffer.PageCount - 1;
                        GetAllDollarsOfferDetail();
                        break;
                    }
            }
            dollarsOfferId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "EditDollarsOffer")
            {
                string url = "~/Admin/AddDollarsOffer.aspx?DollarsOfferId=" + dollarsOfferId;
                Response.Redirect(url, false);
            }
            else if (e.CommandName == "DeleteDollarsOffer")
            {
                string confirmValue = hdnfldVariable.Value;
                if (confirmValue == "Yes")
                {

                    retMsg = objClsDollarsOffer.DeleteDollarsOfferDetail(dollarsOfferId);
                    if (retMsg == "SUCCESS")
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Menu Item Deleted Successfully')", true);
                    }
                    GetAllDollarsOfferDetail();
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }


    protected void btnDollarsOffer_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Admin/AddDollarsOffer.aspx", false);
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void btnAddFeastForFiveOffer_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Admin/AddFeastForFiveOffer.aspx", false);
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void gvFeastForFiveOffer_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int feastForFiveOfferId = 0;
            ClsFeastForFiveOffer objClsFeastForFiveOffer = new ClsFeastForFiveOffer();
            string retMsg = string.Empty;
            switch (e.CommandName)
            {
                case "First":
                    {
                        gvFeastForFiveOffer.PageIndex = 0;
                        GetAllFeastForFiveOfferDetail();
                        break;
                    }
                case "Next":
                    {
                        if (gvFeastForFiveOffer.PageIndex < (gvFeastForFiveOffer.PageCount - 1))
                        {
                            gvFeastForFiveOffer.PageIndex++;
                        }
                        GetAllFeastForFiveOfferDetail();
                        break;
                    }
                case "Previous":
                    {
                        if (gvFeastForFiveOffer.PageIndex > 0)
                        {
                            gvFeastForFiveOffer.PageIndex--;
                        }
                        GetAllFeastForFiveOfferDetail();
                        break;
                    }

                case "Last":
                    {
                        gvFeastForFiveOffer.PageIndex = gvFeastForFiveOffer.PageCount - 1;
                        GetAllFeastForFiveOfferDetail();
                        break;
                    }
            }
            feastForFiveOfferId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "EditFeastForFiveOffer")
            {
                string url = "~/Admin/AddFeastForFiveOffer.aspx?FeastForFiveOfferId=" + feastForFiveOfferId;
                Response.Redirect(url, false);
            }
            else if (e.CommandName == "DeleteFeastForFiveOffer")
            {
                string confirmValue = hdnfldVariable.Value;
                if (confirmValue == "Yes")
                {

                    retMsg = objClsFeastForFiveOffer.DeleteFeastForFiveOfferDetail(feastForFiveOfferId);
                    if (retMsg == "SUCCESS")
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Menu Item Deleted Successfully')", true);
                    }
                    GetAllFeastForFiveOfferDetail();
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void btnAddDailySpecialsOffer_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Admin/AddDailySpecialOffer.aspx", false);
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void gvDailySpecialsOffer_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int dailySpecialOfferId = 0;
            ClsDailySpecialsOffer objClsDailySpecialsOffer = new ClsDailySpecialsOffer();
            string retMsg = string.Empty;
            switch (e.CommandName)
            {
                case "First":
                    {
                        gvDailySpecialsOffer.PageIndex = 0;
                        GetAllDailySpecialOfferDetail();
                        break;
                    }
                case "Next":
                    {
                        if (gvDailySpecialsOffer.PageIndex < (gvDailySpecialsOffer.PageCount - 1))
                        {
                            gvDailySpecialsOffer.PageIndex++;
                        }
                        GetAllDailySpecialOfferDetail();
                        break;
                    }
                case "Previous":
                    {
                        if (gvDailySpecialsOffer.PageIndex > 0)
                        {
                            gvDailySpecialsOffer.PageIndex--;
                        }
                        GetAllDailySpecialOfferDetail();
                        break;
                    }

                case "Last":
                    {
                        gvDailySpecialsOffer.PageIndex = gvDailySpecialsOffer.PageCount - 1;
                        GetAllDailySpecialOfferDetail();
                        break;
                    }
            }
            dailySpecialOfferId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "EditDailySpecialsOffer")
            {
                string url = "~/Admin/AddDailySpecialOffer.aspx?DailySpecialOfferId=" + dailySpecialOfferId;
                Response.Redirect(url, false);
            }
            else if (e.CommandName == "DeleteDailySpecialsOffer")
            {
                string confirmValue = hdnfldVariable.Value;
                if (confirmValue == "Yes")
                {

                    retMsg = objClsDailySpecialsOffer.DeleteDailySpecialsOfferDetail(dailySpecialOfferId);
                    if (retMsg == "SUCCESS")
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Menu Item Deleted Successfully')", true);
                    }
                    GetAllDailySpecialOfferDetail();
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void gvFreePizzaOffer_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string Description = "";
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label txtDescription = ((Label)e.Row.FindControl("lblFreePizzaOfferDescription"));
                Description = txtDescription.Text;


                //preg_replace( '[^(<br( \/)?>)*|(<br( \/)?>)*$]', '', Description );
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"(<br />|<br/>|</ br>|</br>)");
                // System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"([^(<br( \/)?>)*|(<br( \/)?>)*$])");
                // Description = Description.Replace(@"([^(<br( \/)?>)*|(<br( \/)?>)*$])", "");
                Description = regex.Replace(Description, "<br/>");
                Description = Description.Replace("<br/>", "\n");
                Description = Description.Replace("\n", System.Environment.NewLine);
                Description = Description.Replace("&nbsp;", "");
                Description = Description.Replace("&amp;", "&");
                Description = Description.Replace("&rdquo;", "\""); ;
                if (Description != null)
                {
                    if (Description.Length > 70)
                    {
                        txtDescription.Text = Description.Substring(0, 70);
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

    protected void gvDollarsOffer_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string Description = "";
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label txtDescription = ((Label)e.Row.FindControl("lblDollarsOfferDescription"));
                Description = txtDescription.Text;

                //preg_replace( '[^(<br( \/)?>)*|(<br( \/)?>)*$]', '', Description );
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"(<br />|<br/>|</ br>|</br>)");
                // System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"([^(<br( \/)?>)*|(<br( \/)?>)*$])");
                // Description = Description.Replace(@"([^(<br( \/)?>)*|(<br( \/)?>)*$])", "");
                Description = regex.Replace(Description, "<br/>");
                Description = Description.Replace("<br/>", "\n");
                Description = Description.Replace("\n", System.Environment.NewLine);
                Description = Description.Replace("&nbsp;", "");
                Description = Description.Replace("&amp;", "&");
                Description = Description.Replace("&rdquo;", "\""); ;
                if (Description != null)
                {
                    if (Description.Length > 70)
                    {
                        txtDescription.Text = Description.Substring(0, 70);
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

    protected void gvFeastForFiveOffer_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string Description = "";
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label txtDescription = ((Label)e.Row.FindControl("lblFeastForFiveDescription"));
                Description = txtDescription.Text;

                //preg_replace( '[^(<br( \/)?>)*|(<br( \/)?>)*$]', '', Description );
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"(<br />|<br/>|</ br>|</br>)");
                // System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"([^(<br( \/)?>)*|(<br( \/)?>)*$])");
                // Description = Description.Replace(@"([^(<br( \/)?>)*|(<br( \/)?>)*$])", "");
                Description = regex.Replace(Description, "<br/>");
                Description = Description.Replace("<br/>", "\n");
                Description = Description.Replace("\n", System.Environment.NewLine);
                Description = Description.Replace("&nbsp;", "");
                Description = Description.Replace("&amp;", "&");
                Description = Description.Replace("&rdquo;", "\""); ;
                if (Description != null)
                {
                    if (Description.Length > 70)
                    {
                        txtDescription.Text = Description.Substring(0, 70);
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

    protected void gvDailySpecialsOffer_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string Description = "";
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label txtDescription = ((Label)e.Row.FindControl("lblDailySpecialOfferDescription"));
                Description = txtDescription.Text;

                //preg_replace( '[^(<br( \/)?>)*|(<br( \/)?>)*$]', '', Description );
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"(<br />|<br/>|</ br>|</br>)");
                // System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"([^(<br( \/)?>)*|(<br( \/)?>)*$])");
                // Description = Description.Replace(@"([^(<br( \/)?>)*|(<br( \/)?>)*$])", "");
                Description = regex.Replace(Description, "<br/>");
                Description = Description.Replace("<br/>", "\n");
                Description = Description.Replace("\n", System.Environment.NewLine);
                Description = Description.Replace("&nbsp;", "");
                Description = Description.Replace("&amp;", "&");
                Description = Description.Replace("&rdquo;", "\"");
                if (Description != null)
                {
                    if (Description.Length > 70)
                    {
                        txtDescription.Text = Description.Substring(0, 70);
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

    protected void btnFreePizzaSearch_Click(object sender, EventArgs e)
    {
        try
        {
            GetAllFreePizzaOfferDetail();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void btnDollarsSearch_Click(object sender, EventArgs e)
    {
        try
        {
            GetAllDollarsOfferDetail();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void btnFeastForFiveSearch_Click(object sender, EventArgs e)
    {
        try
        {
            GetAllFeastForFiveOfferDetail();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void btnDailySpecialsSearch_Click(object sender, EventArgs e)
    {
        try
        {
            GetAllDailySpecialOfferDetail();
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

    }
    protected void btnResetFreePizzaSearch_Click(object sender, EventArgs e)
    {
        try
        {
            txtFreePizzaSearch.Text = "";
            GetAllFreePizzaOfferDetail();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void btnResetDollarsSearch_Click(object sender, EventArgs e)
    {
        try
        {
            txtDollarsSearch.Text = "";
            GetAllDollarsOfferDetail();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void btnResetFeastForFiveSearch_Click(object sender, EventArgs e)
    {
        try
        {
            txtFeastForFiveSearch.Text = "";
            GetAllFeastForFiveOfferDetail();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    protected void btnResetDaiySpecialSearch_Click(object sender, EventArgs e)
    {
        try
        {
            txtDailySpecialsSearch.Text = "";
            GetAllDailySpecialOfferDetail();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
}