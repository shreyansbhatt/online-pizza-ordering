using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_SendNewsLatterInformation : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (Session["UserId"] != null)
        {
        }
        else
        {
            Response.Redirect("~/Index.aspx", false);
        }
    }
    protected void btnSendEmail_Click(object sender, EventArgs e)
    {
        try
        {
            ClsNewsLetterInformation objClsNewsLetterInformation = new ClsNewsLetterInformation();
            string retMsg = string.Empty;
            string text = CKeditorDescription.Text;
            text = text.Replace("\n", "<br />");
            text = text.Replace("\t", "\n");
            string Description = string.Empty;
            Regex tagRemove = new Regex(@"<[^>]*(>|$)");
            Regex compressSpaces = new Regex(@"[\s\r]+");
            Description = tagRemove.Replace(text, string.Empty);
            Description = Description.Replace("\n", "<br />");
            Description = compressSpaces.Replace(Description, " ");
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"(<br />|<br/>|</ br>|</br>)");
            // System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"([^(<br( \/)?>)*|(<br( \/)?>)*$])");
            // Description = Description.Replace(@"([^(<br( \/)?>)*|(<br( \/)?>)*$])", "");
            Description = regex.Replace(Description, "<br/>");
            Description = Description.Replace("\n", System.Environment.NewLine);
            Description = Description.Replace("&nbsp;", "");

            List<ClsNewsLetterInformation> lstClsNewsLetterInformation = new List<ClsNewsLetterInformation>();
            lstClsNewsLetterInformation = objClsNewsLetterInformation.SendMailToAllSubscibeUser(txtSubject.Text, Description);

           
            foreach (var item in lstClsNewsLetterInformation)
            {
                sendemail(item.Email, Description);
                 
            }
            lblErrorMsg.InnerHtml = "Email Send Successfully To All Subscribe User";
            txtSubject.Text = "";
            CKeditorDescription.Text = "";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
           // retMsg = objClsNewsLetterInformation.SendMailToAllSubscibeUser(txtSubject.Text, Description, FileUpload1.PostedFile.FileName, FileUpload1.PostedFile.InputStream);
            
        }
        catch(Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    ClsMiscellaneousSettings objClsMiscellaneousSettings = new ClsMiscellaneousSettings();
    public Boolean sendemail(string Email, string Description)
    {
        TP_DatabaseEntities dbEntities = new TP_DatabaseEntities();
        List<tp_config> lstconfig = new List<tp_config>();
        
        string email = string.Empty;
        string emailpassword = string.Empty;
        string servername = string.Empty;
        string companyEmail = string.Empty;
       
        lstconfig = (from x in dbEntities.tp_config
                     select x).ToList();
        foreach (var item in lstconfig)
        {
            if (item.tpc_key == "TP_UserName")
            {
                email = item.tpc_value;
            }
            else if (item.tpc_key == "TP_Password")
            {
                emailpassword = item.tpc_value;
            }
            else if (item.tpc_key == "TP_ServerName")
            {
                servername = item.tpc_value;
            }
            else if (item.tpc_key == "SEND_EMAIL_TO")
            {
                companyEmail = item.tpc_value;
            }
           
        }
             
        Array arrToArray;
        char[] splitter = { ';' };
        arrToArray = Email.Split(splitter);
        MailMessage mm = new MailMessage();
        mm.From = new MailAddress(email);
        mm.Subject = txtSubject.Text;
        mm.Body = Description;
        mm.IsBodyHtml = true;

        mm.ReplyTo = new MailAddress(Email);
        foreach (string s in arrToArray)
        {
            mm.To.Add(new MailAddress(s));
        }
        if (FileUpload1.PostedFile != null)
        {
            try
            {
                string strFileName =
                System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                Attachment attachFile =
                new Attachment(FileUpload1.PostedFile.InputStream, strFileName);
                mm.Attachments.Add(attachFile);
            }
            catch
            {

            }
        }

        Array arrToArrayCompany;
        char[] splitterCompany = { ';' };
        arrToArrayCompany = companyEmail.Split(splitterCompany);
        MailMessage mmCompany = new MailMessage();
        mmCompany.From = new MailAddress(email);
        mmCompany.Subject = txtSubject.Text;
        mmCompany.Body = Description;
        mmCompany.IsBodyHtml = true;

        mmCompany.ReplyTo = new MailAddress(companyEmail);
        foreach (string s in arrToArrayCompany)
        {
            mmCompany.To.Add(new MailAddress(s));
        }
        if (FileUpload1.PostedFile != null)
        {
            try
            {
                string strFileName =
                System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                Attachment attachFile =
                new Attachment(FileUpload1.PostedFile.InputStream, strFileName);
                mmCompany.Attachments.Add(attachFile);
            }
            catch
            {

            }
        }

        SmtpClient smtp = new SmtpClient();
        try
        {
            smtp.Host = servername;
            smtp.EnableSsl = true; //Depending on server SSL Settings true/false
            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
            NetworkCred.UserName = email;
            NetworkCred.Password = emailpassword;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;//Specify your port No;
            smtp.Send(mm);
            smtp.Send(mmCompany);
            return true;

        }
        catch
        {
            mm.Dispose(); mmCompany.Dispose();
            smtp = null;
            return false;
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

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