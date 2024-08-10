using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClsNewsLetterInformation
/// </summary>
public class ClsNewsLetterInformation
{
    TP_DatabaseEntities dbEntities = new TP_DatabaseEntities();
    public ClsNewsLetterInformation()
    {
    }

    #region Properties
    private string m_email;
    private bool m_issubscribed;

    public string Email
    {
        get
        {
            return m_email;
        }

        set
        {
            m_email = value;
        }
    }

    public bool Issubscribed
    {
        get
        {
            return m_issubscribed;
        }

        set
        {
            m_issubscribed = value;
        }
    }

    #endregion

    //insert NewsLetter information
    public string InsertNewsLetterDetail(string email,bool isSubscribed,int userId)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {

            tp_newsletter_information dbObjInsertNewsLetterDetail = new tp_newsletter_information();
            dbObjInsertNewsLetterDetail.nl_email = email;
            dbObjInsertNewsLetterDetail.nl_issubscribed = isSubscribed;
            
            dbObjInsertNewsLetterDetail.nl_isdeleted = false;
            dbObjInsertNewsLetterDetail.createdby = userId;
            dbObjInsertNewsLetterDetail.modifiedby = userId;
            dbObjInsertNewsLetterDetail.createdon = DateTime.Now;
            dbObjInsertNewsLetterDetail.modifiedon = DateTime.Now;


            dbEntities.tp_newsletter_information.Add(dbObjInsertNewsLetterDetail);
            retValue = dbEntities.SaveChanges();

            if (retValue == 1)
            {
                retMsg = "SUCCESS";
            }

        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }

        return retMsg;
    }

    //public string SendMailToAllSubscibeUser(string Subject,string Body)
    //{
    //    string retMessage = "FAIL";
    //    ClsUserInformation objClsUserInformation = new ClsUserInformation();
    //    try
    //    {

    //        List<tp_newsletter_information> lsttp_newsletter_information = new List<tp_newsletter_information>();
    //        lsttp_newsletter_information = dbEntities.tp_newsletter_information.Where(x => x.nl_issubscribed == true && x.nl_isdeleted==false).ToList();
    //        foreach(var item in lsttp_newsletter_information)
    //        {

    //            objClsUserInformation.SendMail(item.nl_email, Subject, Body, "", string.Empty, 10, string.Empty, string.Empty, string.Empty, string.Empty, null, string.Empty, string.Empty, string.Empty, string.Empty);
    //            retMessage = "SUCCESS";
    //        }
    //    }
    //    catch(Exception ex)
    //    {
    //        ErrorHandler.WriteError(ex);
    //    }
    //    return retMessage;
    //}

    public List<ClsNewsLetterInformation> SendMailToAllSubscibeUser(string Subject, string Body)
    {
        string retMessage = "FAIL";
        List<ClsNewsLetterInformation> lstClsNewsLetterInformation = new List<ClsNewsLetterInformation>();
        ClsUserInformation objClsUserInformation = new ClsUserInformation();
        try
        {

            List<tp_newsletter_information> lsttp_newsletter_information = new List<tp_newsletter_information>();
            lsttp_newsletter_information = dbEntities.tp_newsletter_information.Where(x => x.nl_issubscribed == true && x.nl_isdeleted == false).ToList();
            foreach (var item in lsttp_newsletter_information)
            {
                ClsNewsLetterInformation objClsNewsLetterInformation = new ClsNewsLetterInformation();
                objClsNewsLetterInformation.Email = item.nl_email;
                lstClsNewsLetterInformation.Add(objClsNewsLetterInformation);
               // objClsUserInformation.SendMail(item.nl_email, Subject, Body, "", string.Empty, 10, string.Empty, string.Empty, string.Empty, string.Empty, null, string.Empty, string.Empty, string.Empty, string.Empty);
                retMessage = "SUCCESS";
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsNewsLetterInformation;
    }
}