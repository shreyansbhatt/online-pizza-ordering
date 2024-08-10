using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClsMiscellaneousSettings
/// </summary>
public class ClsMiscellaneousSettings
{
    TP_DatabaseEntities dbEntities = new TP_DatabaseEntities();
    public ClsMiscellaneousSettings()
    {
        
    }
   
    public string MiscellaneousTaxSettings(tp_config objconfig)
    {
        string retMsg = string.Empty;
        int retValue = 0;
        try
        {
            tp_config objTPConfig = new tp_config();
            objTPConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains(objconfig.tpc_key)).FirstOrDefault();
            if (objTPConfig != null)
            {
                objTPConfig.tpc_value = objconfig.tpc_value;
                retValue = dbEntities.SaveChanges();
            }
            else
            {
                tp_config TPconfig = new tp_config();
                TPconfig.tpc_key = objconfig.tpc_key;
                TPconfig.tpc_value = objconfig.tpc_value;
                dbEntities.tp_config.Add(TPconfig);
                retValue = dbEntities.SaveChanges();
            }

            if (retValue > 0)
            {
                retMsg = "SUCCESS";
            }
            else
            {
                retMsg = "FAIL";
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return retMsg;
    }

    public string MiscellaneousDeliveryChargeSettings(tp_config objconfig)
    {
        string retMsg = string.Empty;
        int retValue = 0;
        try
        {
            tp_config objTPConfig = new tp_config();
            objTPConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains(objconfig.tpc_key)).FirstOrDefault();
            if (objTPConfig != null)
            {
                objTPConfig.tpc_value = objconfig.tpc_value;
                retValue = dbEntities.SaveChanges();
            }
            else
            {
                tp_config TPconfig = new tp_config();
                TPconfig.tpc_key = objconfig.tpc_key;
                TPconfig.tpc_value = objconfig.tpc_value;
                dbEntities.tp_config.Add(TPconfig);
                retValue = dbEntities.SaveChanges();
            }

            if (retValue > 0)
            {
                retMsg = "SUCCESS";
            }
            else
            {
                retMsg = "FAIL";
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return retMsg;
    }
    

    public string MiscellaneousMinimumDeliveryPurchaseSetting(tp_config objconfig)
    {
        string retMsg = string.Empty;
        int retValue = 0;
        try
        {
            tp_config objTPConfig = new tp_config();
            objTPConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains(objconfig.tpc_key)).FirstOrDefault();
            if (objTPConfig != null)
            {
                objTPConfig.tpc_value = objconfig.tpc_value;
                retValue = dbEntities.SaveChanges();
            }
            else
            {
                tp_config TPconfig = new tp_config();
                TPconfig.tpc_key = objconfig.tpc_key;
                TPconfig.tpc_value = objconfig.tpc_value;
                dbEntities.tp_config.Add(TPconfig);
                retValue = dbEntities.SaveChanges();
            }

            if (retValue > 0)
            {
                retMsg = "SUCCESS";
            }
            else
            {
                retMsg = "FAIL";
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return retMsg;
    }
    
    public string MiscellaneousOnlinePaymentSetting(tp_config objconfig)
    {
        string retMsg = string.Empty;
        int retValue = 0;
        try
        {
            tp_config objTPConfig = new tp_config();
            objTPConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains(objconfig.tpc_key)).FirstOrDefault();
            if (objTPConfig != null)
            {
                objTPConfig.tpc_value = objconfig.tpc_value;
                retValue = dbEntities.SaveChanges();
            }
            else
            {
                tp_config TPconfig = new tp_config();
                TPconfig.tpc_key = objconfig.tpc_key;
                TPconfig.tpc_value = objconfig.tpc_value;
                dbEntities.tp_config.Add(TPconfig);
                retValue = dbEntities.SaveChanges();
            }

            if (retValue > 0)
            {
                retMsg = "SUCCESS";
            }
            else
            {
                retMsg = "FAIL";
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return retMsg;
    }
    public bool IsTaxKeyExist()
    {
        bool IsKeyExist = false;
        try
        {
            tp_config objTPConfig = new tp_config();
            objTPConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains("TAX_DETAILS")).FirstOrDefault();
            if (objTPConfig != null)
            {
                IsKeyExist = true;
            }
            else
            {
                IsKeyExist = false;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return IsKeyExist;
    }

    public bool IsDeliveryChargeKeyExist()
    {
        bool IsKeyExist = false;
        try
        {
            tp_config objTPConfig = new tp_config();
            objTPConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains("DELIVERY_CHARGES_DETAILS")).FirstOrDefault();
            if (objTPConfig != null)
            {
                IsKeyExist = true;
            }
            else
            {
                IsKeyExist = false;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return IsKeyExist;
    }

    public bool isMinimumDeliveryPurchaseKeyExist()
    {
        bool IsKeyExist = false;
        try
        {
            tp_config objTPConfig = new tp_config();
            objTPConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains("MINIMUM_DELIVERY_PURCHASE")).FirstOrDefault();
            if (objTPConfig != null)
            {
                IsKeyExist = true;
            }
            else
            {
                IsKeyExist = false;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return IsKeyExist;
    }

    public bool isOnlinePaymentKeyExist()
    {
        bool IsKeyExist = false;
        try
        {
            tp_config objTPConfig = new tp_config();
            objTPConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains("ONLINE_PAYMENT")).FirstOrDefault();
            if (objTPConfig != null)
            {
                IsKeyExist = true;
            }
            else
            {
                IsKeyExist = false;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return IsKeyExist;
    }
    public tp_config GetTaxConfigSetting()
    {
        tp_config objtp_config = new tp_config();
        try
        {

            objtp_config = dbEntities.tp_config.Where(x => x.tpc_key.Contains("TAX_DETAILS")).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objtp_config;
    }
    public tp_config GetDeliveryChargeConfigSetting()
    {
        tp_config objtp_config = new tp_config();
        try
        {

            objtp_config = dbEntities.tp_config.Where(x => x.tpc_key.Contains("DELIVERY_CHARGES_DETAILS")).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objtp_config;
    }

    public tp_config GetFaceBookLink()
    {
        tp_config objtp_config = new tp_config();
        try
        {

            objtp_config = dbEntities.tp_config.Where(x => x.tpc_key.Contains("FACEBOOK_LINK")).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objtp_config;
    }

    public tp_config GetGooglePlusLink()
    {
        tp_config objtp_config = new tp_config();
        try
        {

            objtp_config = dbEntities.tp_config.Where(x => x.tpc_key.Contains("GOOGLEPLUS_LINK")).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objtp_config;
    }

    public tp_config GetLinkedInLink()
    {
        tp_config objtp_config = new tp_config();
        try
        {

            objtp_config = dbEntities.tp_config.Where(x => x.tpc_key.Contains("LINKEDIN_LINK")).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objtp_config;
    }


    public tp_config GetYouTubeLink()
    {
        tp_config objtp_config = new tp_config();
        try
        {

            objtp_config = dbEntities.tp_config.Where(x => x.tpc_key.Contains("YOUTUBE_LINK")).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objtp_config;
    }

    public string UpdateSocialNetworkingLink(tp_config objconfig)
    {
        string retMsg = string.Empty;
        int retValue = 0;
        try
        {
            tp_config objTPConfig = new tp_config();
            objTPConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains(objconfig.tpc_key)).FirstOrDefault();
            if (objTPConfig != null)
            {
                objTPConfig.tpc_value = objconfig.tpc_value;
                retValue = dbEntities.SaveChanges();
            }
            if (retValue >= 0)
            {
                retMsg = "SUCCESS";
            }
            else
            {
                retMsg = "FAIL";
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return retMsg;
    }

    public tp_config GetFileName()
    {
        tp_config objtp_config = new tp_config();
        try
        {

            objtp_config = dbEntities.tp_config.Where(x => x.tpc_key.Contains("MENU_FILENAME")).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objtp_config;
    }

    public tp_config GetMinimumDeliveryPurchaseConfigSetting()
    {
        tp_config objtp_config = new tp_config();
        try
        {

            objtp_config = dbEntities.tp_config.Where(x => x.tpc_key.Contains("MINIMUM_DELIVERY_PURCHASE")).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objtp_config;
    }

    public string MenuFileUpload(tp_config objconfig)
    {
        string retMsg = string.Empty;
        int retValue = 0;
        try
        {
            tp_config objTPConfig = new tp_config();
            objTPConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains(objconfig.tpc_key)).FirstOrDefault();
            if (objTPConfig != null)
            {
                objTPConfig.tpc_value = objconfig.tpc_value;
                retValue = dbEntities.SaveChanges();
            }
            else
            {
                tp_config TPconfig = new tp_config();
                TPconfig.tpc_key = objconfig.tpc_key;
                TPconfig.tpc_value = objconfig.tpc_value;
                dbEntities.tp_config.Add(TPconfig);
                retValue = dbEntities.SaveChanges();
            }

            if (retValue > 0)
            {
                retMsg = "SUCCESS";
            }
            else
            {
                retMsg = "FAIL";
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return retMsg;
    }

    public tp_config GetOnlinePaymentConfigSetting()
    {
        tp_config objtp_config = new tp_config();
        try
        {

            objtp_config = dbEntities.tp_config.Where(x => x.tpc_key.Contains("ONLINE_PAYMENT")).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objtp_config;
    }
   

    public tp_config GetTestPaymentUrl()
    {
        tp_config objtp_config = new tp_config();
        string url = string.Empty;
        try
        {

            objtp_config = dbEntities.tp_config.Where(x => x.tpc_key.Contains("TP_PAYMENT_TEST_URL")).FirstOrDefault();
            
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objtp_config;
    }

    public tp_config GetTestTransactionKey()
    {
        tp_config objtp_config = new tp_config();
        string url = string.Empty;
        try
        {

            objtp_config = dbEntities.tp_config.Where(x => x.tpc_key.Contains("TP_TEST_TRANSACTION_KEY")).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objtp_config;
    }

    public tp_config GetTestLoginId()
    {
        tp_config objtp_config = new tp_config();
        string url = string.Empty;
        try
        {

            objtp_config = dbEntities.tp_config.Where(x => x.tpc_key.Contains("TP_TEST_LOGIN_ID")).FirstOrDefault();
            
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objtp_config;
    }

    public bool IsContactKeyExist()
    {
        bool IsContactKeyExist = false;
        try
        {
            tp_config objTPAddressConfig = new tp_config();
            objTPAddressConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains("TP_ADDRESS_DETAIL")).FirstOrDefault();
            tp_config objTPPhoneConfig = new tp_config();
            objTPPhoneConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains("TP_PHONE_DETAIL")).FirstOrDefault();

            tp_config objTPFaxConfig = new tp_config();
            objTPFaxConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains("TP_FAX_DETAIL")).FirstOrDefault();

            tp_config objTPEmailConfig = new tp_config();
            objTPEmailConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains("TP_SUPPORT_EMAIL_DETAIL")).FirstOrDefault();
            if (objTPAddressConfig != null && objTPPhoneConfig!=null && objTPFaxConfig!=null && objTPEmailConfig!=null)
            {
                IsContactKeyExist = true;
            }
            else
            {
                IsContactKeyExist = false;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return IsContactKeyExist;
    }

    public tp_config GetAddressDetail()
    {
        tp_config objtp_config = new tp_config();
        try
        {

            objtp_config = dbEntities.tp_config.Where(x => x.tpc_key.Contains("TP_ADDRESS_DETAIL")).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objtp_config;
    }

    public tp_config GetPhoneDetail()
    {
        tp_config objtp_config = new tp_config();
        try
        {

            objtp_config = dbEntities.tp_config.Where(x => x.tpc_key.Contains("TP_PHONE_DETAIL")).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objtp_config;
    }

    public tp_config GetFaxDetail()
    {
        tp_config objtp_config = new tp_config();
        try
        {

            objtp_config = dbEntities.tp_config.Where(x => x.tpc_key.Contains("TP_FAX_DETAIL")).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objtp_config;
    }

    public tp_config GetEmailDetail()
    {
        tp_config objtp_config = new tp_config();
        try
        {

            objtp_config = dbEntities.tp_config.Where(x => x.tpc_key.Contains("TP_SUPPORT_EMAIL_DETAIL")).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objtp_config;
    }

    public string AddressSetting(tp_config objconfig)
    {
        string retMsg = string.Empty;
        int retValue = 0;
        try
        {
            tp_config objTPConfig = new tp_config();
            objTPConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains(objconfig.tpc_key)).FirstOrDefault();
            if (objTPConfig != null)
            {
                objTPConfig.tpc_value = objconfig.tpc_value;
                retValue = dbEntities.SaveChanges();
            }
            else
            {
                tp_config TPconfig = new tp_config();
                TPconfig.tpc_key = objconfig.tpc_key;
                TPconfig.tpc_value = objconfig.tpc_value;
                dbEntities.tp_config.Add(TPconfig);
                retValue = dbEntities.SaveChanges();
            }

            if (retValue > 0)
            {
                retMsg = "SUCCESS";
            }
            else
            {
                retMsg = "FAIL";
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return retMsg;
    }

    public string PhoneSetting(tp_config objconfig)
    {
        string retMsg = string.Empty;
        int retValue = 0;
        try
        {
            tp_config objTPConfig = new tp_config();
            objTPConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains(objconfig.tpc_key)).FirstOrDefault();
            if (objTPConfig != null)
            {
                objTPConfig.tpc_value = objconfig.tpc_value;
                retValue = dbEntities.SaveChanges();
            }
            else
            {
                tp_config TPconfig = new tp_config();
                TPconfig.tpc_key = objconfig.tpc_key;
                TPconfig.tpc_value = objconfig.tpc_value;
                dbEntities.tp_config.Add(TPconfig);
                retValue = dbEntities.SaveChanges();
            }

            if (retValue > 0)
            {
                retMsg = "SUCCESS";
            }
            else
            {
                retMsg = "FAIL";
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return retMsg;
    }

    public string FaxSetting(tp_config objconfig)
    {
        string retMsg = string.Empty;
        int retValue = 0;
        try
        {
            tp_config objTPConfig = new tp_config();
            objTPConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains(objconfig.tpc_key)).FirstOrDefault();
            if (objTPConfig != null)
            {
                objTPConfig.tpc_value = objconfig.tpc_value;
                retValue = dbEntities.SaveChanges();
            }
            else
            {
                tp_config TPconfig = new tp_config();
                TPconfig.tpc_key = objconfig.tpc_key;
                TPconfig.tpc_value = objconfig.tpc_value;
                dbEntities.tp_config.Add(TPconfig);
                retValue = dbEntities.SaveChanges();
            }

            if (retValue > 0)
            {
                retMsg = "SUCCESS";
            }
            else
            {
                retMsg = "FAIL";
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return retMsg;
    }

    public string EmailSetting(tp_config objconfig)
    {
        string retMsg = string.Empty;
        int retValue = 0;
        try
        {
            tp_config objTPConfig = new tp_config();
            objTPConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains(objconfig.tpc_key)).FirstOrDefault();
            if (objTPConfig != null)
            {
                objTPConfig.tpc_value = objconfig.tpc_value;
                retValue = dbEntities.SaveChanges();
            }
            else
            {
                tp_config TPconfig = new tp_config();
                TPconfig.tpc_key = objconfig.tpc_key;
                TPconfig.tpc_value = objconfig.tpc_value;
                dbEntities.tp_config.Add(TPconfig);
                retValue = dbEntities.SaveChanges();
            }

            if (retValue > 0)
            {
                retMsg = "SUCCESS";
            }
            else
            {
                retMsg = "FAIL";
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return retMsg;
    }


  
    
    public tp_config GetLivePaymentUrl()
    {
        tp_config objtp_config = new tp_config();
        try
        {

            objtp_config = dbEntities.tp_config.Where(x => x.tpc_key.Contains("TP_PAYMENT_LIVE_URL")).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objtp_config;
    }

    public tp_config GetLiveLoginId()
    {
        tp_config objtp_config = new tp_config();
        try
        {

            objtp_config = dbEntities.tp_config.Where(x => x.tpc_key.Contains("TP_PAYMNET_LIVE_LOGIN_ID")).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objtp_config;
    }

    public tp_config GetLiveTransactionKey()
    {
        tp_config objtp_config = new tp_config();
        try
        {

            objtp_config = dbEntities.tp_config.Where(x => x.tpc_key.Contains("TP_PAYMENT_LIVE_TRANSACTION_KEY")).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objtp_config;
    }


    public string UrlSetting(tp_config objconfig)
    {
        string retMsg = string.Empty;
        int retValue = 0;
        try
        {
            tp_config objTPConfig = new tp_config();
            objTPConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains(objconfig.tpc_key)).FirstOrDefault();
            if (objTPConfig != null)
            {
                objTPConfig.tpc_value = objconfig.tpc_value;
                retValue = dbEntities.SaveChanges();
            }
            else
            {
                tp_config TPconfig = new tp_config();
                TPconfig.tpc_key = objconfig.tpc_key;
                TPconfig.tpc_value = objconfig.tpc_value;
                dbEntities.tp_config.Add(TPconfig);
                retValue = dbEntities.SaveChanges();
            }

            if (retValue > 0)
            {
                retMsg = "SUCCESS";
            }
            else
            {
                retMsg = "FAIL";
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return retMsg;
    }

    public string LoginIdSetting(tp_config objconfig)
    {
        string retMsg = string.Empty;
        int retValue = 0;
        try
        {
            tp_config objTPConfig = new tp_config();
            objTPConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains(objconfig.tpc_key)).FirstOrDefault();
            if (objTPConfig != null)
            {
                objTPConfig.tpc_value = objconfig.tpc_value;
                retValue = dbEntities.SaveChanges();
            }
            else
            {
                tp_config TPconfig = new tp_config();
                TPconfig.tpc_key = objconfig.tpc_key;
                TPconfig.tpc_value = objconfig.tpc_value;
                dbEntities.tp_config.Add(TPconfig);
                retValue = dbEntities.SaveChanges();
            }

            if (retValue > 0)
            {
                retMsg = "SUCCESS";
            }
            else
            {
                retMsg = "FAIL";
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return retMsg;
    }

    public string TransactionKeySetting(tp_config objconfig)
    {
        string retMsg = string.Empty;
        int retValue = 0;
        try
        {
            tp_config objTPConfig = new tp_config();
            objTPConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains(objconfig.tpc_key)).FirstOrDefault();
            if (objTPConfig != null)
            {
                objTPConfig.tpc_value = objconfig.tpc_value;
                retValue = dbEntities.SaveChanges();
            }
            else
            {
                tp_config TPconfig = new tp_config();
                TPconfig.tpc_key = objconfig.tpc_key;
                TPconfig.tpc_value = objconfig.tpc_value;
                dbEntities.tp_config.Add(TPconfig);
                retValue = dbEntities.SaveChanges();
            }

            if (retValue > 0)
            {
                retMsg = "SUCCESS";
            }
            else
            {
                retMsg = "FAIL";
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return retMsg;
    }

}
