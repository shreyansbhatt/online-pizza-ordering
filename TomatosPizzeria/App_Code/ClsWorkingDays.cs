using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClsWorkingDays
/// </summary>
public class ClsWorkingDays
{
    TP_DatabaseEntities dbEntities = new TP_DatabaseEntities();
    public ClsWorkingDays()
    {
    }

    #region Properties


    private int m_workingDayId;
    private string m_workingDayName;

    public int WorkingDayId
    {
        get
        {
            return m_workingDayId;
        }

        set
        {
            m_workingDayId = value;
        }
    }

    public string WorkingDayName
    {
        get
        {
            return m_workingDayName;
        }

        set
        {
            m_workingDayName = value;
        }
    }



    #endregion

    //Insert New Working Days
    public string InsertWorkingDays(string workingDayName, int userId)
    {
        int retValue = 0;
        string retMsg = string.Empty;

        try
        {

            tp_working_days dbObjInsertWorkingDays = new tp_working_days();
            dbObjInsertWorkingDays.wd_name = workingDayName;
            dbObjInsertWorkingDays.wd_isdeleted = false;

            dbObjInsertWorkingDays.createdby = userId;
            dbObjInsertWorkingDays.modifiedby = userId;
            dbObjInsertWorkingDays.createdon = DateTime.Now;
            dbObjInsertWorkingDays.modifiedon = DateTime.Now;


            dbEntities.tp_working_days.Add(dbObjInsertWorkingDays);
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

    //Update Working Days
    public string UpdateWorkingDays(int workingDayId, string workingDayName, int userId)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {
            tp_working_days dbObjUpdateWorkingDays = null;
            dbObjUpdateWorkingDays = dbEntities.tp_working_days.Where(P => P.wd_id == workingDayId).FirstOrDefault();

            dbObjUpdateWorkingDays.wd_name = workingDayName;
            dbObjUpdateWorkingDays.wd_isdeleted = false;

            dbObjUpdateWorkingDays.modifiedby = userId;

            dbObjUpdateWorkingDays.modifiedon = DateTime.Now;

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

    //Delete Working Day
    public string DeleteWorkingDays(int workingDayId)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {
            tp_working_days dbObjWorkingDays = null;
            dbObjWorkingDays = dbEntities.tp_working_days.Where(P => P.wd_id == workingDayId).FirstOrDefault();

            dbObjWorkingDays.wd_isdeleted = true;
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

    //Get Working Day List
    public DataTable GetWorkingDaysList(string searchText = null)
    {
        List<tp_working_days> lstWorkingDays = new List<tp_working_days>();
        List<ClsWorkingDays> lstClsWorkingDays = new List<ClsWorkingDays>();

        try
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                lstWorkingDays = dbEntities.tp_working_days.Where(p => p.wd_name.Contains(searchText) && p.wd_isdeleted == false).ToList<tp_working_days>();

                foreach (var item in lstWorkingDays)
                {
                    ClsWorkingDays objClsWorkingDays = new ClsWorkingDays();
                    objClsWorkingDays.WorkingDayName = item.wd_name;


                    lstClsWorkingDays.Add(objClsWorkingDays);
                }
            }
            else
            {
                lstWorkingDays = dbEntities.tp_working_days.Where(p => p.wd_isdeleted == false).ToList<tp_working_days>();

                foreach (var item in lstWorkingDays)
                {
                    ClsWorkingDays objClsWorkingDays = new ClsWorkingDays();
                    objClsWorkingDays.WorkingDayName = item.wd_name;


                    lstClsWorkingDays.Add(objClsWorkingDays);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsWorkingDays.ListToDataTable();
    }

    //GetWorking day list by WorkingDayId
    public tp_working_days GetWorkingDaysByWorkingDaysId(int workingDayId)
    {

        tp_working_days objTPWorkingDays = new tp_working_days();
        try
        {
            objTPWorkingDays = dbEntities.tp_working_days.Where(P => P.wd_id == workingDayId && P.wd_isdeleted == false).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objTPWorkingDays;
    }

    //Check if Working Day already exists
    public bool isWorkingDaysExist(string workingDayName)
    {
        bool retValue = false;
        try
        {
            tp_working_days result = dbEntities.tp_working_days.Where(P => P.wd_name.ToLower().Equals(workingDayName, StringComparison.InvariantCultureIgnoreCase) && P.wd_isdeleted == false).FirstOrDefault();

            if (result == null)
            {
                retValue = false;
            }
            else
            {
                retValue = true;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return retValue;
    }


}