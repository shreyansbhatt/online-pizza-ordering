using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class Admin_UploadMenuPdf : System.Web.UI.Page
{
    TP_DatabaseEntities dbEntities = new TP_DatabaseEntities();
    ClsMiscellaneousSettings objClsMiscellaneousSettings = new ClsMiscellaneousSettings();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    GetFileName();
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
    public void GetFileName()
    {
        try
        {
            tp_config objConfig = new tp_config();
            objConfig = objClsMiscellaneousSettings.GetFileName();
            if (objConfig != null)
            {
                lnkMenuFileName.Text = objConfig.tpc_value;
            }
            else
            {
                lnkMenuFileName.Text = "";
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            string filePath = string.Empty;
            tp_config configobj = new tp_config();

            configobj = dbEntities.tp_config.Where(x => x.tpc_key == "TP_MENU_PATH").FirstOrDefault();
            if (configobj != null)
            {
                filePath = configobj.tpc_value;
            }
            string filename = Path.GetFileName(fileUpload1.PostedFile.FileName);
            //Regex regFileName = new Regex(@"^[A-Za-z0-9-_,\s]+[.]{1}[A-Za-z]{3}$");
            //if (!regFileName.IsMatch(filename))
            //{

            //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('FileName is not valid')", true);

            //}
            //else
            //{
            fileUpload1.SaveAs(Server.MapPath(filePath + filename));
            ClsMiscellaneousSettings objClsMiscellaneousSettings = new ClsMiscellaneousSettings();
            string retMsg = string.Empty;

            try
            {
                if (Page.IsValid)
                {
                    tp_config TPConfig = new tp_config();
                    TPConfig.tpc_key = "MENU_FILENAME";
                    TPConfig.tpc_value = filename;


                    retMsg = objClsMiscellaneousSettings.MenuFileUpload(TPConfig);

                    if (retMsg == "SUCCESS")
                    {
                        GetFileName();
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Menu File Upload Successfully')", true);
                    }

                }
            }
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex);
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        //}





    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Write("<script language='javascript'> window.close();</javascript>");
    }

    protected void lnkMenuFileName_Click(object sender, EventArgs e)
    {
        try
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
            //  string filePath = "D:/TomatosPizzeria/TomatosPizzeria/Pdfs/Tomatos-Menu_11x17_3_PRF.pdf";
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=\"" + Path.GetFileName(filePath) + "\"");
            Response.WriteFile(filePath);
            Response.End();
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