using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClsConfiguration
/// </summary>
public class ClsConfiguration
{
    TP_DatabaseEntities dbEntities = new TP_DatabaseEntities();
    public ClsConfiguration()
    {

    }

    #region Properties
    private string m_key;
    private string m_value;

    public string Key
    {
        get
        {
            return m_key;
        }

        set
        {
            m_key = value;
        }
    }

    public string Value
    {
        get
        {
            return m_value;
        }

        set
        {
            m_value = value;
        }
    }
    #endregion

    //Get All Key Value
    public List<tp_config> GetAllKeyValues()
    {
        List<tp_config> lstConfigInformation = new List<tp_config>();
        try
        {
            var query = (from x in dbEntities.tp_config
                         select x).ToList();
            foreach (var item in query)
            {
                tp_config dbObjConfigInformation = new tp_config();
                dbObjConfigInformation.tpc_key = item.tpc_key;
                dbObjConfigInformation.tpc_value = item.tpc_value;
                lstConfigInformation.Add(dbObjConfigInformation);
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstConfigInformation;
    }


    //Update Key Value
    public string UpdateKeyValues(int configId, string key, string value)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {
            tp_config dbObjUpdateConfigInformation = null;
            dbObjUpdateConfigInformation = dbEntities.tp_config.Where(P => P.tpc_id == configId).FirstOrDefault();

            dbObjUpdateConfigInformation.tpc_key = key;
            dbObjUpdateConfigInformation.tpc_value = value;
            dbEntities.SaveChanges();


            retValue = dbEntities.SaveChanges();

            if (retValue > 0)
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

    public string ConfigSettings(tp_config objconfig1, tp_config objconfig2, tp_config objconfig3)
    {
        string retMsg = string.Empty;
        int retValue1 = 0, retValue2 = 0, retValue3 = 0, retValue = 0;
        try
        {

            tp_config objtp_config1 = new tp_config();
            objtp_config1 = dbEntities.tp_config.Where(x => x.tpc_key.Contains(objconfig1.tpc_key)).FirstOrDefault();
            if (objtp_config1 != null)
            {
                objtp_config1.tpc_value = objconfig1.tpc_value;
                retValue1 = dbEntities.SaveChanges();
            }
            else
            {
                tp_config objtp_config = new tp_config();
                objtp_config.tpc_key = objconfig1.tpc_key;
                objtp_config.tpc_value = objconfig1.tpc_value;
                dbEntities.tp_config.Add(objtp_config);
                retValue1 = dbEntities.SaveChanges();
            }

            tp_config objtp_config2 = new tp_config();
            objtp_config2 = dbEntities.tp_config.Where(x => x.tpc_key.Contains(objconfig2.tpc_key)).FirstOrDefault();
            if (objtp_config2 != null)
            {
                objtp_config2.tpc_value = objconfig2.tpc_value;
                retValue2 = dbEntities.SaveChanges();
            }
            else
            {
                tp_config objtp_config = new tp_config();
                objtp_config.tpc_key = objconfig2.tpc_key;
                objtp_config.tpc_value = objconfig2.tpc_value;
                dbEntities.tp_config.Add(objtp_config);
                retValue2 = dbEntities.SaveChanges();
            }

            tp_config objtp_config3 = new tp_config();
            objtp_config3 = dbEntities.tp_config.Where(x => x.tpc_key.Contains(objconfig3.tpc_key)).FirstOrDefault();
            if (objtp_config3 != null)
            {
                objtp_config3.tpc_value = objconfig3.tpc_value;
                retValue3 = dbEntities.SaveChanges();
            }
            else
            {
                tp_config objtp_config = new tp_config();
                objtp_config.tpc_key = objconfig3.tpc_key;
                objtp_config.tpc_value = objconfig3.tpc_value;
                dbEntities.tp_config.Add(objtp_config);
                retValue3 = dbEntities.SaveChanges();
            }

            if (retValue1 > 0 || retValue2 > 0 || retValue3 > 0)
            {
                retValue = 1;
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
    public tp_config GetUsernmConfigSetting()
    {
        tp_config objtp_config = new tp_config();
        try
        {
            objtp_config = dbEntities.tp_config.Where(x => x.tpc_key.Contains("TP_UserName")).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objtp_config;
    }

    public tp_config GetPasswordConfigSetting()
    {
        tp_config objtp_config = new tp_config();
        try
        {

            objtp_config = dbEntities.tp_config.Where(x => x.tpc_key.Contains("TP_Password")).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objtp_config;
    }
    public tp_config GetServerNameConfigSetting()
    {
        tp_config objtp_config = new tp_config();
        try
        {
            objtp_config = dbEntities.tp_config.Where(x => x.tpc_key.Contains("TP_ServerName")).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objtp_config;
    }
    public bool IsUserNameKeyExist()
    {
        bool IsKeyExist = false;
        try
        {
            tp_config objtp_config = new tp_config();
            objtp_config = dbEntities.tp_config.Where(x => x.tpc_key.Contains("TP_UserName")).FirstOrDefault();
            if (objtp_config != null)
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

    public bool IsPasswordKeyExist()
    {
        bool IsKeyExist = false;
        try
        {
            tp_config objtp_config = new tp_config();
            objtp_config = dbEntities.tp_config.Where(x => x.tpc_key.Contains("TP_Password")).FirstOrDefault();
            if (objtp_config != null)
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

    public bool IsServerNameKeyExist()
    {
        bool IsKeyExist = false;
        try
        {
            tp_config objtp_config = new tp_config();
            objtp_config = dbEntities.tp_config.Where(x => x.tpc_key.Contains("TP_ServerName")).FirstOrDefault();
            if (objtp_config != null)
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
}