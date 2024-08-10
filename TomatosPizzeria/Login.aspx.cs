using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    TP_DatabaseEntities dbEntities = new TP_DatabaseEntities();
    ClsMiscellaneousSettings objClsMiscellaneousSettings = new ClsMiscellaneousSettings();
    protected void Page_Load(object sender, EventArgs e)
    {

        ErrorMsgDiv.Style.Add("display", "none");
        ErrorMessageDiv.Style.Add("display", "none");
        if (Session["UserEmail"] != null)
        {
            Response.Redirect("~/Index.aspx", false);
        }
        if (!IsPostBack)
        {
            if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
            {
                txtLoginEmail.Text = Request.Cookies["UserName"].Value;
                txtLoginPassword.Attributes["value"] = Request.Cookies["Password"].Value;
            }
            GetDeliveryChargeConfigSetting();
            GetMinimumDeliveryPurchaseConfigSetting();
            GetAddressDetail();
            GetPhoneDetail();
            GetFaxDetail();
            GetEmailDetail();

            afacebbok.HRef = objClsMiscellaneousSettings.GetFaceBookLink().tpc_value;
            agoogleplus.HRef = objClsMiscellaneousSettings.GetGooglePlusLink().tpc_value;
            alinkedin.HRef = objClsMiscellaneousSettings.GetLinkedInLink().tpc_value;
            ayoutube.HRef = objClsMiscellaneousSettings.GetYouTubeLink().tpc_value;

        }

    }
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
                //  lblSupportEmailOfTP.Text = objConfig.tpc_value;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string retMsg = string.Empty;

        try
        {
            ClsUserInformation objClsUserInformation = new ClsUserInformation();
            tp_user_information dbObjUserLoginResult = new tp_user_information();

            dbObjUserLoginResult = objClsUserInformation.UserLogin(txtLoginEmail.Text.Trim(), txtLoginPassword.Text.Trim());


            if (dbObjUserLoginResult != null)
            {
                Session["UserEmail"] = dbObjUserLoginResult.ui_email;
                Session["FirstName"] = dbObjUserLoginResult.ui_firstName;

                Session["UserId"] = dbObjUserLoginResult.ui_id;
                Session["UserType"] = dbObjUserLoginResult.ui_usertype;
                if (dbObjUserLoginResult.ui_usertype == 1)
                {
                    ClsCartDetail objClsCartDetail = new ClsCartDetail();

                    if (Session["RandomNumber"] != null)
                    {
                        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
                        lstClsProductDetail = objClsCartDetail.GetCartDetail(0, Session["RandomNumber"].ToString());

                        List<ClsProductDetail> ListOfClsProductDetail = new List<ClsProductDetail>();
                        ListOfClsProductDetail = objClsCartDetail.GetCartDetail(Convert.ToInt32(Session["UserId"]), "0");

                        foreach (var itemlst in ListOfClsProductDetail)
                        {
                            foreach (var item in lstClsProductDetail)
                            {
                                if (item.ProductdetailId == itemlst.ProductdetailId && item.SizeId == itemlst.SizeId && item.IngredientFactId == itemlst.IngredientFactId)
                                {
                                    var result1 = (from cim in dbEntities.tp_cart_ingredient_mapping
                                                   join id in dbEntities.tp_ingredient_details
                                                      on cim.cim_id_id equals id.id_id
                                                   where cim.cim_isdeleted == false && id.id_isdeleted == false && cim.cim_cd_id == item.CartId
                                                   select new
                                                   {
                                                       id.id_id,
                                                       id.id_name,
                                                       id.id_price
                                                   }).ToList();
                                    ClsProductDetail objitemClsProductDetail = new ClsProductDetail();
                                    foreach (var item1 in result1)
                                    {

                                        if (objitemClsProductDetail.ExtraIngredientId == null)
                                        {
                                            objitemClsProductDetail.ExtraIngredientId = item1.id_id.ToString();
                                        }
                                        else
                                        {
                                            objitemClsProductDetail.ExtraIngredientId = objitemClsProductDetail.ExtraIngredientId + "," + item1.id_id;
                                        }
                                    }

                                    var result11 = (from cim in dbEntities.tp_cart_ingredient_mapping
                                                    join id in dbEntities.tp_ingredient_details
                                                       on cim.cim_id_id equals id.id_id
                                                    where cim.cim_isdeleted == false && id.id_isdeleted == false && cim.cim_cd_id == itemlst.CartId
                                                    select new
                                                    {
                                                        id.id_id,
                                                        id.id_name,
                                                        id.id_price
                                                    }).ToList();
                                    ClsProductDetail objitemlstClsProductDetail = new ClsProductDetail();
                                    foreach (var item11 in result11)
                                    {

                                        if (objitemlstClsProductDetail.ExtraIngredientId == null)
                                        {
                                            objitemlstClsProductDetail.ExtraIngredientId = item11.id_id.ToString();
                                        }
                                        else
                                        {
                                            objitemlstClsProductDetail.ExtraIngredientId = objitemlstClsProductDetail.ExtraIngredientId + "," + item11.id_id;
                                        }
                                    }

                                    if (objitemClsProductDetail.ExtraIngredientId == objitemlstClsProductDetail.ExtraIngredientId)
                                    {
                                        int Quantity = itemlst.Quantity + item.Quantity;
                                        decimal price = Convert.ToDecimal(item.Price.ToString().Replace("$", "")) + Convert.ToDecimal(itemlst.Price.ToString().Replace("$", ""));
                                        objClsCartDetail.UpdateCartDetail(itemlst.CartId, itemlst.ProductdetailId, Convert.ToInt32(Session["UserId"]), itemlst.SizeId, itemlst.PropertiesId, Quantity, price.ToString(), itemlst.IngredientFactId, Session["RandomNumber"].ToString());

                                        objClsCartDetail.DeleteItemFromCart(item.CartId);
                                    }
                                }


                            }



                        }


                        objClsCartDetail.UpdateUserIdInCartDetail(Session["RandomNumber"].ToString(), Convert.ToInt32(Session["UserId"]));
                    }
                    string PageName = "";
                    if (Request.QueryString["PageName"] != null)
                    {
                        PageName = Request.QueryString["PageName"];
                    }
                    if (PageName != "" && PageName != null)
                    {
                        Response.Redirect("~/" + PageName, false);
                    }
                    else
                    {
                        //Redirect to User's Inner Page

                        Response.Redirect("~/EditProfile.aspx", false);
                    }
                }

                else if (dbObjUserLoginResult.ui_usertype == 2)
                {
                    //Redirect to Admin's Page
                    // ClientScript.RegisterStartupScript(this.GetType(), "alert", "OpenNewTab();", true);
                    Response.Redirect("~/index.aspx", false);
                    //string url = "index.aspx";
                    //StringBuilder sb = new StringBuilder();
                    //sb.Append("<script type = 'text/javascript'>");
                    //sb.Append("window.open('");
                    //sb.Append(url);
                    //sb.Append("');");
                    //sb.Append("</script>");
                    //ClientScript.RegisterStartupScript(this.GetType(),
                    //        "script", sb.ToString());

                }
                if (chkRememberMe.Checked)
                {
                    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                }
                else
                {
                    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);

                }
                Response.Cookies["UserName"].Value = txtLoginEmail.Text.Trim();
                Response.Cookies["Password"].Value = txtLoginPassword.Text.Trim();


            }
            else
            {
                ErrorMessageDiv.Style.Add("display", "block");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void lnkforgotpassword_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/ForgetPassword.aspx", false);
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }





    protected void lnkMenu_Click(object sender, EventArgs e)
    {
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
}