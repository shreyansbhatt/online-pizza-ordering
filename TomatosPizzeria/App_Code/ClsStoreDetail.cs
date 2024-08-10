using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClsStoreDetail
/// </summary>
public class ClsStoreDetail
{
    TP_DatabaseEntities dbEntities = new TP_DatabaseEntities();
    public ClsStoreDetail()
    {

    }

    #region Properties

    private int m_StoreId;

    public int StoreId
    {
        get { return m_StoreId; }
        set { m_StoreId = value; }
    }
    private string m_storeName;
    private int m_storeCountryId;
    private int m_storeStateId;
    private int m_storeCityId;
    private string m_storeAddress;
    private string m_contactNumber1;
    private string m_contactNumber2;
    private string m_contactNumber3;
    private string m_contactNumber4;
    private string m_faxNumber;
    private int m_WorkingDayId;

    public int WorkingDayId
    {
        get { return m_WorkingDayId; }
        set { m_WorkingDayId = value; }
    }
    private string m_workingDayName;

    private string m_storeWorkingStartTime;
    private string m_storeWorkingEndTime;


    public string StoreName
    {
        get
        {
            return m_storeName;
        }

        set
        {
            m_storeName = value;
        }
    }

    public int StoreCountryId
    {
        get
        {
            return m_storeCountryId;
        }

        set
        {
            m_storeCountryId = value;
        }
    }

    public int StoreStateId
    {
        get
        {
            return m_storeStateId;
        }

        set
        {
            m_storeStateId = value;
        }
    }

    public int StoreCityId
    {
        get
        {
            return m_storeCityId;
        }

        set
        {
            m_storeCityId = value;
        }
    }

    public string StoreAddress
    {
        get
        {
            return m_storeAddress;
        }

        set
        {
            m_storeAddress = value;
        }
    }

    public string ContactNumber1
    {
        get
        {
            return m_contactNumber1;
        }

        set
        {
            m_contactNumber1 = value;
        }
    }

    public string ContactNumber2
    {
        get
        {
            return m_contactNumber2;
        }

        set
        {
            m_contactNumber2 = value;
        }
    }

    public string ContactNumber3
    {
        get
        {
            return m_contactNumber3;
        }

        set
        {
            m_contactNumber3 = value;
        }
    }

    public string ContactNumber4
    {
        get
        {
            return m_contactNumber4;
        }

        set
        {
            m_contactNumber4 = value;
        }
    }

    public string FaxNumber
    {
        get
        {
            return m_faxNumber;
        }

        set
        {
            m_faxNumber = value;
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

    public string StoreWorkingStartTime
    {
        get
        {
            return m_storeWorkingStartTime;
        }

        set
        {
            m_storeWorkingStartTime = value;
        }
    }

    public string StoreWorkingEndTime
    {
        get
        {
            return m_storeWorkingEndTime;
        }

        set
        {
            m_storeWorkingEndTime = value;
        }
    }


    #endregion

    //Insert New Store Detail
    public string InsertNewStoreDetail(string storeName, int storeCountryId, int storeStateId, int storeCityId, string storeAddress, string contactNumber1, string contactNumber2, string contactNumber3, string contactNumber4, string faxNumber, int userId)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {

            tp_store_details dbObjInsertStoreDetail = new tp_store_details();
            dbObjInsertStoreDetail.sd_name = storeName;
            dbObjInsertStoreDetail.sd_country_id = storeCountryId;
            dbObjInsertStoreDetail.sd_state_id = storeStateId;
            dbObjInsertStoreDetail.sd_city_id = storeCityId;
            dbObjInsertStoreDetail.sd_address = storeAddress;
            dbObjInsertStoreDetail.sd_contact_number1 = contactNumber1;
            dbObjInsertStoreDetail.sd_contact_number2 = contactNumber2;
            dbObjInsertStoreDetail.sd_contact_number3 = contactNumber3;
            dbObjInsertStoreDetail.sd_contact_number4 = contactNumber4;
            dbObjInsertStoreDetail.sd_fax_number = faxNumber;
            dbObjInsertStoreDetail.sd_isdeleted = false;

            dbObjInsertStoreDetail.createdby = userId;
            dbObjInsertStoreDetail.modifiedby = userId;
            dbObjInsertStoreDetail.createdon = DateTime.Now;
            dbObjInsertStoreDetail.modifiedon = DateTime.Now;


            dbEntities.tp_store_details.Add(dbObjInsertStoreDetail);
            dbEntities.SaveChanges();
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


    //Update  Store Detail
    public string UpdateStoreDetail(int storeId, string storeName, int storeCountryId, int storeStateId, int storeCityId, string storeAddress, string contactNumber1, string contactNumber2, string contactNumber3, string contactNumber4, string faxNumber, string MondatstartHour, string MondayStartMinute, string MondayStartTime, string MondayEndHour, string MondayEndMinute, string MondayEndTime, string TuesdaytstartHour, string TuesdayStartMinute, string TuesdayStartTime, string TuesdayEndHour, string TuesdayEndMinute, string TuesdayEndTime, string WenesdaytstartHour, string WenesdayStartMinute, string WenesdayStartTime, string WenesdayEndHour, string WenesdayEndMinute, string WenesdayEndTime, string ThursdaytstartHour, string ThursdayStartMinute, string ThursdayStartTime, string ThursdayEndHour, string ThursdayEndMinute, string ThursdayEndtTime, string FridaytstartHour, string FridayStartMinute, string FridayStartTime, string FridayEndHour, string FridayEndMinute, string FridayEndTime, string SaturdaytstartHour, string SaturdayStartMinute, string SaturdayStartTime, string SaturdayEndHour, string SaturdayEndMinute, string SaturdayEndTime, string SundaytstartHour, string SundayStartMinute, string SundatStartTime, string SundayEndHour, string SundayEndMinute, string SundayEndTime, int userId)
    {
        int retValue = 0, retValue1 = 0;
        string retMsg = "FAIL";

        try
        {
            tp_store_details dbObjUpdateStoreDetail = null;
            dbObjUpdateStoreDetail = dbEntities.tp_store_details.Where(P => P.sd_id == storeId).FirstOrDefault();
            if (dbObjUpdateStoreDetail != null)
            {
                dbObjUpdateStoreDetail.sd_name = storeName;
                dbObjUpdateStoreDetail.sd_country_id = storeCountryId;
                dbObjUpdateStoreDetail.sd_state_id = storeStateId;
                dbObjUpdateStoreDetail.sd_city_id = storeCityId;
                dbObjUpdateStoreDetail.sd_address = storeAddress;
                dbObjUpdateStoreDetail.sd_contact_number1 = contactNumber1;
                dbObjUpdateStoreDetail.sd_contact_number2 = contactNumber2;
                dbObjUpdateStoreDetail.sd_contact_number3 = contactNumber3;
                dbObjUpdateStoreDetail.sd_contact_number4 = contactNumber4;
                dbObjUpdateStoreDetail.sd_fax_number = faxNumber;
                dbObjUpdateStoreDetail.sd_isdeleted = false;

                dbObjUpdateStoreDetail.modifiedby = userId;

                dbObjUpdateStoreDetail.modifiedon = DateTime.Now;


                retValue = dbEntities.SaveChanges();
            }
            if (retValue > 0 || retValue1 > 0)
            {
                retMsg = "SUCCESS";
            }
            List<tp_store_working_mapping> lsttp_store_working_mapping = new List<tp_store_working_mapping>();
            lsttp_store_working_mapping = dbEntities.tp_store_working_mapping.Where(x => x.swm_sd_id == storeId).ToList();

            if (lsttp_store_working_mapping.Count > 0)
            {
                foreach (var item in lsttp_store_working_mapping)
                {
                    tp_store_working_mapping objtp_store_working_mapping = new tp_store_working_mapping();
                    objtp_store_working_mapping = dbEntities.tp_store_working_mapping.Where(x => x.swm_wd_id == item.swm_wd_id).FirstOrDefault();
                    if (objtp_store_working_mapping != null)
                    {
                        if (objtp_store_working_mapping.swm_wd_id == 1)
                        {
                            objtp_store_working_mapping.swm_start_time = Convert.ToDateTime(MondatstartHour + ":" + MondayStartMinute + "" + MondayStartTime);
                            objtp_store_working_mapping.swm_end_time = Convert.ToDateTime(MondayEndHour + ":" + MondayEndMinute + "" + MondayEndTime);
                        }
                        if (objtp_store_working_mapping.swm_wd_id == 2)
                        {
                            objtp_store_working_mapping.swm_start_time = Convert.ToDateTime(TuesdaytstartHour + ":" + TuesdayStartMinute + "" + TuesdayStartTime);
                            objtp_store_working_mapping.swm_end_time = Convert.ToDateTime(TuesdayEndHour + ":" + TuesdayEndMinute + "" + TuesdayEndTime);
                        }
                        if (objtp_store_working_mapping.swm_wd_id == 3)
                        {
                            objtp_store_working_mapping.swm_start_time = Convert.ToDateTime(WenesdaytstartHour + ":" + WenesdayStartMinute + "" + WenesdayStartTime);
                            objtp_store_working_mapping.swm_end_time = Convert.ToDateTime(WenesdayEndHour + ":" + WenesdayEndMinute + "" + WenesdayEndTime);
                        }
                        if (objtp_store_working_mapping.swm_wd_id == 4)
                        {
                            objtp_store_working_mapping.swm_start_time = Convert.ToDateTime(ThursdaytstartHour + ":" + ThursdayStartMinute + "" + ThursdayStartTime);
                            objtp_store_working_mapping.swm_end_time = Convert.ToDateTime(ThursdayEndHour + ":" + ThursdayEndMinute + "" + ThursdayEndtTime);
                        }
                        if (objtp_store_working_mapping.swm_wd_id == 5)
                        {
                            objtp_store_working_mapping.swm_start_time = Convert.ToDateTime(FridaytstartHour + ":" + FridayStartMinute + "" + FridayStartTime);
                            objtp_store_working_mapping.swm_end_time = Convert.ToDateTime(FridayEndHour + ":" + FridayEndMinute + "" + FridayEndTime);
                        }
                        if (objtp_store_working_mapping.swm_wd_id == 6)
                        {
                            objtp_store_working_mapping.swm_start_time = Convert.ToDateTime(SaturdaytstartHour + ":" + SaturdayStartMinute + "" + SaturdayStartTime);
                            objtp_store_working_mapping.swm_end_time = Convert.ToDateTime(SaturdayEndHour + ":" + SaturdayEndMinute + "" + SaturdayEndTime);
                        }
                        if (objtp_store_working_mapping.swm_wd_id == 7)
                        {
                            objtp_store_working_mapping.swm_start_time = Convert.ToDateTime(SundaytstartHour + ":" + SundayStartMinute + "" + SundatStartTime);
                            objtp_store_working_mapping.swm_end_time = Convert.ToDateTime(SundayEndHour + ":" + SundayEndMinute + "" + SundayEndTime);
                        }
                    }
                    retValue1 = dbEntities.SaveChanges();
                }
            }
            if (retValue > 0 || retValue1 > 0)
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

    //Delete Store Detail
    public string DeleteStoreDetail(int storeId)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {
            tp_store_details dbObjDeleteStoreDetail = null;
            dbObjDeleteStoreDetail = dbEntities.tp_store_details.Where(P => P.sd_id == storeId).FirstOrDefault();

            dbObjDeleteStoreDetail.sd_isdeleted = true;
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


    //Check if  Store Detail already exits
    public bool isStoreDetailExist(string storeName)
    {
        bool retValue = false;
        try
        {
            tp_store_details result = dbEntities.tp_store_details.Where(P => P.sd_name.ToLower().Equals(storeName, StringComparison.InvariantCultureIgnoreCase) && P.sd_isdeleted == false).FirstOrDefault();
            if (result == null)
            {
                retValue = false;
            }
            else
            {
                retValue = true;
            }
        }
        catch (Exception)
        {
            retValue = false;
        }
        return retValue;
    }

    //1 Monday
    //2 tuesday
    //3 wenesday
    //4 thursday
    //5 friday
    //6 saturday
    //7 sunday
    public DataTable GetAllStoreDetails(string searchText = null)
    {
        List<ClsStoreDetail> lstClsStoreDetail = new List<ClsStoreDetail>();
        try
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                var result = (from a in dbEntities.tp_store_details
                              join b in dbEntities.tp_store_working_mapping
                              on a.sd_id equals b.swm_sd_id
                              where a.sd_isdeleted == false && a.sd_name.Contains(searchText)
                              select new
                              {
                                  a.sd_address,
                                  a.sd_contact_number1,
                                  a.sd_contact_number2,
                                  a.sd_contact_number3,
                                  a.sd_contact_number4,
                                  a.sd_fax_number,
                                  a.sd_id,
                                  a.sd_name,
                                  b.swm_start_time,
                                  b.swm_end_time,
                                  b.swm_wd_id
                              }).ToList();
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        ClsStoreDetail objClsStoreDetail = new ClsStoreDetail();
                        objClsStoreDetail.ContactNumber1 = item.sd_contact_number1;
                        objClsStoreDetail.ContactNumber2 = item.sd_contact_number2;
                        objClsStoreDetail.ContactNumber3 = item.sd_contact_number3;
                        objClsStoreDetail.ContactNumber4 = item.sd_contact_number4;
                        objClsStoreDetail.FaxNumber = item.sd_fax_number;
                        objClsStoreDetail.StoreAddress = item.sd_address;
                        objClsStoreDetail.StoreName = item.sd_name;
                        objClsStoreDetail.StoreId = item.sd_id;
                        objClsStoreDetail.StoreWorkingStartTime = Convert.ToDateTime(item.swm_start_time).ToShortTimeString();
                        objClsStoreDetail.StoreWorkingEndTime = Convert.ToDateTime(item.swm_end_time).ToShortTimeString();
                        if (item.swm_wd_id == 1)
                        {
                            objClsStoreDetail.WorkingDayName = "Monday";
                        }
                        if (item.swm_wd_id == 2)
                        {
                            objClsStoreDetail.WorkingDayName = "Tuesday";
                        }
                        if (item.swm_wd_id == 3)
                        {
                            objClsStoreDetail.WorkingDayName = "Wednesday";
                        }
                        if (item.swm_wd_id == 4)
                        {
                            objClsStoreDetail.WorkingDayName = "Thursday";
                        }
                        if (item.swm_wd_id == 5)
                        {
                            objClsStoreDetail.WorkingDayName = "Friday";
                        }
                        if (item.swm_wd_id == 6)
                        {
                            objClsStoreDetail.WorkingDayName = "Saturday";
                        }
                        if (item.swm_wd_id == 7)
                        {
                            objClsStoreDetail.WorkingDayName = "Sunday";
                        }
                        lstClsStoreDetail.Add(objClsStoreDetail);
                    }
                }
            }
            else
            {
                var result = (from a in dbEntities.tp_store_details
                              join b in dbEntities.tp_store_working_mapping
                              on a.sd_id equals b.swm_sd_id
                              where a.sd_isdeleted == false
                              select new
                              {
                                  a.sd_address,
                                  a.sd_contact_number1,
                                  a.sd_contact_number2,
                                  a.sd_contact_number3,
                                  a.sd_contact_number4,
                                  a.sd_fax_number,
                                  a.sd_id,
                                  a.sd_name,
                                  b.swm_start_time,
                                  b.swm_end_time,
                                  b.swm_wd_id
                              }).ToList();
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        ClsStoreDetail objClsStoreDetail = new ClsStoreDetail();
                        objClsStoreDetail.ContactNumber1 = item.sd_contact_number1;
                        objClsStoreDetail.ContactNumber2 = item.sd_contact_number2;
                        objClsStoreDetail.ContactNumber3 = item.sd_contact_number3;
                        objClsStoreDetail.ContactNumber4 = item.sd_contact_number4;
                        objClsStoreDetail.FaxNumber = item.sd_fax_number;
                        objClsStoreDetail.StoreAddress = item.sd_address;
                        objClsStoreDetail.StoreName = item.sd_name;
                        objClsStoreDetail.StoreId = item.sd_id;
                        objClsStoreDetail.StoreWorkingStartTime = Convert.ToDateTime(item.swm_start_time).ToShortTimeString();
                        objClsStoreDetail.StoreWorkingEndTime = Convert.ToDateTime(item.swm_end_time).ToShortTimeString();
                        if (item.swm_wd_id == 1)
                        {
                            objClsStoreDetail.WorkingDayName = "Monday";
                        }
                        if (item.swm_wd_id == 2)
                        {
                            objClsStoreDetail.WorkingDayName = "Tuesday";
                        }
                        if (item.swm_wd_id == 3)
                        {
                            objClsStoreDetail.WorkingDayName = "Wednesday";
                        }
                        if (item.swm_wd_id == 4)
                        {
                            objClsStoreDetail.WorkingDayName = "Thursday";
                        }
                        if (item.swm_wd_id == 5)
                        {
                            objClsStoreDetail.WorkingDayName = "Friday";
                        }
                        if (item.swm_wd_id == 6)
                        {
                            objClsStoreDetail.WorkingDayName = "Saturday";
                        }
                        if (item.swm_wd_id == 7)
                        {
                            objClsStoreDetail.WorkingDayName = "Sunday";
                        }
                        lstClsStoreDetail.Add(objClsStoreDetail);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsStoreDetail.ListToDataTable();
    }

    public ClsStoreDetail GetStoreDetailById(int Id)
    {
        ClsStoreDetail objClsStoreDetail = new ClsStoreDetail();
        try
        {
            var result = (from a in dbEntities.tp_store_details
                          where a.sd_isdeleted == false && a.sd_id == Id
                          select new
                          {
                              a.sd_address,
                              a.sd_city_id,
                              a.sd_contact_number1,
                              a.sd_contact_number2,
                              a.sd_contact_number3,
                              a.sd_contact_number4,
                              a.sd_country_id,
                              a.sd_fax_number,
                              a.sd_id,
                              a.sd_isdeleted,
                              a.sd_name,
                              a.sd_state_id,

                          }).FirstOrDefault();

            if (result != null)
            {
                objClsStoreDetail.StoreName = result.sd_name;
                objClsStoreDetail.ContactNumber1 = result.sd_contact_number1;
                objClsStoreDetail.ContactNumber2 = result.sd_contact_number2;
                objClsStoreDetail.ContactNumber3 = result.sd_contact_number3;
                objClsStoreDetail.ContactNumber4 = result.sd_contact_number4;
                objClsStoreDetail.StoreAddress = result.sd_address;
                objClsStoreDetail.FaxNumber = result.sd_fax_number;

            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objClsStoreDetail;
    }

    public List<ClsStoreDetail> GetStoreMappingDetailById(int id)
    {
        List<ClsStoreDetail> lstClsStoreDetail = new List<ClsStoreDetail>();
        try
        {
            var result = (from a in dbEntities.tp_store_working_mapping
                          where a.swm_sd_id == id
                          select new
                          {
                              a.swm_end_time,
                              a.swm_id,
                              a.swm_sd_id,
                              a.swm_start_time,
                              a.swm_wd_id
                          }).ToList();
            if (result != null)
            {
                foreach (var item in result)
                {
                    ClsStoreDetail objClsStoreDetail = new ClsStoreDetail();

                    if (item.swm_wd_id == 1)
                    {
                        objClsStoreDetail.WorkingDayId = 1;
                        objClsStoreDetail.WorkingDayName = "Monday";

                        objClsStoreDetail.StoreWorkingStartTime = Convert.ToDateTime(item.swm_start_time).ToString("hh:mm tt");

                        objClsStoreDetail.StoreWorkingEndTime = Convert.ToDateTime(item.swm_end_time).ToString("hh:mm tt");


                        // objClsStoreDetail.StoreWorkingEndTime = timeEnd.ToString("hh:mm tt");
                    }
                    if (item.swm_wd_id == 2)
                    {
                        objClsStoreDetail.WorkingDayId = 2;
                        objClsStoreDetail.WorkingDayName = "Tuesday";
                        objClsStoreDetail.StoreWorkingStartTime = Convert.ToDateTime(item.swm_start_time).ToString("hh:mm tt");

                        objClsStoreDetail.StoreWorkingEndTime = Convert.ToDateTime(item.swm_end_time).ToString("hh:mm tt");

                    }
                    if (item.swm_wd_id == 3)
                    {
                        objClsStoreDetail.WorkingDayId = 3;
                        objClsStoreDetail.WorkingDayName = "Wednesday";
                        objClsStoreDetail.StoreWorkingStartTime = Convert.ToDateTime(item.swm_start_time).ToString("hh:mm tt");

                        objClsStoreDetail.StoreWorkingEndTime = Convert.ToDateTime(item.swm_end_time).ToString("hh:mm tt");

                    }
                    if (item.swm_wd_id == 4)
                    {
                        objClsStoreDetail.WorkingDayId = 4;
                        objClsStoreDetail.WorkingDayName = "Thursday";
                        objClsStoreDetail.StoreWorkingStartTime = Convert.ToDateTime(item.swm_start_time).ToString("hh:mm tt");

                        objClsStoreDetail.StoreWorkingEndTime = Convert.ToDateTime(item.swm_end_time).ToString("hh:mm tt");

                    }
                    if (item.swm_wd_id == 5)
                    {
                        objClsStoreDetail.WorkingDayId = 5;
                        objClsStoreDetail.WorkingDayName = "Friday";
                        objClsStoreDetail.StoreWorkingStartTime = Convert.ToDateTime(item.swm_start_time).ToString("hh:mm tt");

                        objClsStoreDetail.StoreWorkingEndTime = Convert.ToDateTime(item.swm_end_time).ToString("hh:mm tt");

                    }
                    if (item.swm_wd_id == 6)
                    {
                        objClsStoreDetail.WorkingDayId = 6;
                        objClsStoreDetail.WorkingDayName = "Saturday";
                        objClsStoreDetail.StoreWorkingStartTime = Convert.ToDateTime(item.swm_start_time).ToString("hh:mm tt");

                        objClsStoreDetail.StoreWorkingEndTime = Convert.ToDateTime(item.swm_end_time).ToString("hh:mm tt");

                    }
                    if (item.swm_wd_id == 7)
                    {
                        objClsStoreDetail.WorkingDayId = 7;
                        objClsStoreDetail.WorkingDayName = "Sunday";
                        objClsStoreDetail.StoreWorkingStartTime = Convert.ToDateTime(item.swm_start_time).ToString("hh:mm tt");

                        objClsStoreDetail.StoreWorkingEndTime = Convert.ToDateTime(item.swm_end_time).ToString("hh:mm tt");

                    }
                    lstClsStoreDetail.Add(objClsStoreDetail);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsStoreDetail;
    }
    //Get  Store Detail List
    public DataTable GetStoreDetailList()
    {
        List<tp_store_details> lstStoreDetail = new List<tp_store_details>();
        List<ClsStoreDetail> lstClsStoreDetail = new List<ClsStoreDetail>();

        try
        {
            //if (!string.IsNullOrEmpty(searchText))
            //{
            //    lstStoreDetail = dbEntities.tp_store_details.Where(p => p.sd_name.Contains(searchText) && p.sd_isdeleted == false).ToList<tp_store_details>();

            //    foreach (var item in lstStoreDetail)
            //    {
            //        ClsStoreDetail objClsStoreDetail = new ClsStoreDetail();
            //        objClsStoreDetail.StoreName = item.sd_name;
            //        objClsStoreDetail.StoreCountryId = Convert.ToInt32(item.sd_country_id);
            //        objClsStoreDetail.StoreStateId = Convert.ToInt32(item.sd_state_id);
            //        objClsStoreDetail.StoreCityId = Convert.ToInt32(item.sd_city_id);
            //        objClsStoreDetail.StoreAddress = item.sd_address;
            //        objClsStoreDetail.ContactNumber1 = item.sd_contact_number1;
            //        objClsStoreDetail.ContactNumber2 = item.sd_contact_number2;
            //        objClsStoreDetail.ContactNumber3 = item.sd_contact_number3;
            //        objClsStoreDetail.ContactNumber4 = item.sd_contact_number4;
            //        objClsStoreDetail.FaxNumber = item.sd_fax_number;
            //        objClsStoreDetail.StoreId = item.sd_id;


            //        lstClsStoreDetail.Add(objClsStoreDetail);
            //    }
            //}
            //else
            //{
            lstStoreDetail = dbEntities.tp_store_details.Where(p => p.sd_isdeleted == false).ToList<tp_store_details>();

            foreach (var item in lstStoreDetail)
            {
                ClsStoreDetail objClsStoreDetail = new ClsStoreDetail();
                objClsStoreDetail.StoreName = item.sd_name;
                objClsStoreDetail.StoreCountryId = Convert.ToInt32(item.sd_country_id);
                objClsStoreDetail.StoreStateId = Convert.ToInt32(item.sd_state_id);
                objClsStoreDetail.StoreCityId = Convert.ToInt32(item.sd_city_id);
                objClsStoreDetail.StoreAddress = item.sd_address;
                objClsStoreDetail.ContactNumber1 = item.sd_contact_number1;
                objClsStoreDetail.ContactNumber2 = item.sd_contact_number2;
                objClsStoreDetail.ContactNumber3 = item.sd_contact_number3;
                objClsStoreDetail.ContactNumber4 = item.sd_contact_number4;
                objClsStoreDetail.FaxNumber = item.sd_fax_number;
                objClsStoreDetail.StoreId = item.sd_id;

                lstClsStoreDetail.Add(objClsStoreDetail);
            }
            // }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsStoreDetail.ListToDataTable();
    }

    //Get  Store Detail list by storeId
    public tp_store_details GetStoreListByStoreId(int storeId)
    {

        tp_store_details objTPStoreDetail = new tp_store_details();
        try
        {
            objTPStoreDetail = dbEntities.tp_store_details.Where(P => P.sd_id == storeId && P.sd_isdeleted == false).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objTPStoreDetail;
    }


    //Get Srote Detail by Working Days

    //public List<ClsStoreDetail> GetStoreListByWorkingDays()
    //{
    //    List<ClsStoreDetail> lstStoreList = new List<ClsStoreDetail>();

    //    var result = (from sd in dbEntities.tp_store_details
    //                  join swm in dbEntities.tp_store_working_mapping
    //                  on sd.sd_id equals swm.swm_sd_id
    //                  join wd in dbEntities.tp_working_days
    //                  on swm.swm_wd_id equals wd.wd_id
    //                  where sd.sd_isdeleted == false && wd.wd_isdeleted == false
    //                  select new
    //                  {
    //                      sd,
    //                      wd,
    //                      swm.swm_start_time,
    //                      swm.swm_end_time
    //                  }).ToList();
    //    foreach (var item in result)
    //    {
    //        ClsStoreDetail objClsStoreDetail = new ClsStoreDetail();
    //        objClsStoreDetail.StoreName = item.sd.sd_name;
    //        objClsStoreDetail.StoreCountryId = Convert.ToInt32(item.sd.sd_country_id);
    //        objClsStoreDetail.StoreStateId = Convert.ToInt32(item.sd.sd_state_id);
    //        objClsStoreDetail.StoreCityId = Convert.ToInt32(item.sd.sd_city_id);
    //        objClsStoreDetail.StoreAddress = item.sd.sd_address;
    //        objClsStoreDetail.ContactNumber1 = item.sd.sd_contact_number1;
    //        objClsStoreDetail.ContactNumber2 = item.sd.sd_contact_number2;
    //        objClsStoreDetail.ContactNumber3 = item.sd.sd_contact_number3;
    //        objClsStoreDetail.ContactNumber4 = item.sd.sd_contact_number4;
    //        objClsStoreDetail.FaxNumber = item.sd.sd_fax_number;
    //        objClsStoreDetail.StoreWorkingStartTime = Convert.ToDateTime(item.swm_start_time);
    //        objClsStoreDetail.StoreWorkingEndTime = Convert.ToDateTime(item.swm_end_time);
    //        objClsStoreDetail.WorkingDayName = item.wd.wd_name;

    //        lstStoreList.Add(objClsStoreDetail);

    //    }

    //    return lstStoreList;
    //}


    public ClsStoreDetail GetStoreTimeByDayId(int DayId)
    {
        ClsStoreDetail objClsStoreDetail = new ClsStoreDetail();
        try
        {
            var result = (from a in dbEntities.tp_store_working_mapping
                          where a.swm_wd_id == DayId
                          select new
                          {
                              a.swm_end_time,
                              a.swm_id,
                              a.swm_sd_id,
                              a.swm_start_time,
                              a.swm_wd_id
                          }).FirstOrDefault();
            if (result != null)
            {
                objClsStoreDetail.StoreWorkingStartTime = result.swm_start_time.ToString();
                objClsStoreDetail.StoreWorkingEndTime = result.swm_end_time.ToString();
                objClsStoreDetail.StoreId = result.swm_sd_id.Value;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }

        return objClsStoreDetail;
    }



}