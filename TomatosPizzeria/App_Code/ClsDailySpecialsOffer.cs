using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClsDailySpecialsOffer
/// </summary>
public class ClsDailySpecialsOffer
{
    TP_DatabaseEntities dbEntities = new TP_DatabaseEntities();
    public ClsDailySpecialsOffer()
    {

    }
    #region Properties

    private int m_dailySpecialsOfferId;
    private string m_dailySpecialOfferName;
    private string m_dailySpecialOfferDescription;
    private string m_dailySpecialOfferCode;

    private int m_dailySpecialDay;
    private string m_dailySpecialDayName;

    private int m_product1Id;
    private int m_product1Quantity;
    private int m_product1SizeId;

    private string m_product1Name;
    private string m_product1SizeName;

    private int m_product2Id;
    private int m_product2Quantity;
    private int m_product2SizeId;

    private string m_product2Name;
    private string m_product2SizeName;

    private string m_offerAmount;

    private string m_offerstartdatestring;
    private string m_offerenddatestring;
    private DateTime m_offerstartdate;
    private DateTime m_offerenddate;

    public DateTime Offerenddate
    {
        get { return m_offerenddate; }
        set { m_offerenddate = value; }
    }

    public DateTime Offerstartdate
    {
        get { return m_offerstartdate; }
        set { m_offerstartdate = value; }
    }

    public string Offerenddatestring
    {
        get { return m_offerenddatestring; }
        set { m_offerenddatestring = value; }
    }

    public string Offerstartdatestring
    {
        get { return m_offerstartdatestring; }
        set { m_offerstartdatestring = value; }
    }


    public string DailySpecialOfferName
    {
        get
        {
            return m_dailySpecialOfferName;
        }

        set
        {
            m_dailySpecialOfferName = value;
        }
    }

    public string DailySpecialOfferCode
    {
        get
        {
            return m_dailySpecialOfferCode;
        }

        set
        {
            m_dailySpecialOfferCode = value;
        }
    }



    public int Product1Id
    {
        get
        {
            return m_product1Id;
        }

        set
        {
            m_product1Id = value;
        }
    }

    public int Product1Quantity
    {
        get
        {
            return m_product1Quantity;
        }

        set
        {
            m_product1Quantity = value;
        }
    }

    public int Product1SizeId
    {
        get
        {
            return m_product1SizeId;
        }

        set
        {
            m_product1SizeId = value;
        }
    }

    public string Product1Name
    {
        get
        {
            return m_product1Name;
        }

        set
        {
            m_product1Name = value;
        }
    }

    public string Product1SizeName
    {
        get
        {
            return m_product1SizeName;
        }

        set
        {
            m_product1SizeName = value;
        }
    }

    public int Product2Id
    {
        get
        {
            return m_product2Id;
        }

        set
        {
            m_product2Id = value;
        }
    }

    public int Product2Quantity
    {
        get
        {
            return m_product2Quantity;
        }

        set
        {
            m_product2Quantity = value;
        }
    }

    public int Product2SizeId
    {
        get
        {
            return m_product2SizeId;
        }

        set
        {
            m_product2SizeId = value;
        }
    }

    public string Product2Name
    {
        get
        {
            return m_product2Name;
        }

        set
        {
            m_product2Name = value;
        }
    }

    public string Product2SizeName
    {
        get
        {
            return m_product2SizeName;
        }

        set
        {
            m_product2SizeName = value;
        }
    }

    public string OfferAmount
    {
        get
        {
            return m_offerAmount;
        }

        set
        {
            m_offerAmount = value;
        }
    }

    public string DailySpecialOfferDescription
    {
        get
        {
            return m_dailySpecialOfferDescription;
        }

        set
        {
            m_dailySpecialOfferDescription = value;
        }
    }

    public int DailySpecialsOfferId
    {
        get
        {
            return m_dailySpecialsOfferId;
        }

        set
        {
            m_dailySpecialsOfferId = value;
        }
    }

    public int DailySpecialDay
    {
        get
        {
            return m_dailySpecialDay;
        }

        set
        {
            m_dailySpecialDay = value;
        }
    }

    public string DailySpecialDayName
    {
        get
        {
            return m_dailySpecialDayName;
        }

        set
        {
            m_dailySpecialDayName = value;
        }
    }

    #endregion

    //Insert New FeastForFive OfferDetail
    public string InsertDailySpecialsOfferDetail(string dailySpecialsOfferName, string dailySpecialsOfferDescription, string dailySpecialsOfferCode, int day, int product1Id, int product1Quantity, int product1SizeId, int product2Id, int product2Quantity, int product2SizeId, string offerAmount, int userId, DateTime offerStartDate, DateTime offerEndDate)
    {
        int retValue = 0;
        string retMsg = string.Empty;

        try
        {

            tp_dailyspecials_offer dbObjInsertDailySpecialsOfferDetail = new tp_dailyspecials_offer();
            dbObjInsertDailySpecialsOfferDetail.dso_name = dailySpecialsOfferName;
            dbObjInsertDailySpecialsOfferDetail.dso_description = dailySpecialsOfferDescription;
            dbObjInsertDailySpecialsOfferDetail.dso_Offer_code = dailySpecialsOfferCode;
            dbObjInsertDailySpecialsOfferDetail.dso_day = day;
            dbObjInsertDailySpecialsOfferDetail.dso_product1_pd_id = product1Id;
            dbObjInsertDailySpecialsOfferDetail.dso_product1_quantity = product1Quantity;
            dbObjInsertDailySpecialsOfferDetail.dso_product1_ps_id = product1SizeId;

            dbObjInsertDailySpecialsOfferDetail.dso_product2_pd_id = product2Id;
            dbObjInsertDailySpecialsOfferDetail.dso_product2_quantity = product2Quantity;
            dbObjInsertDailySpecialsOfferDetail.dso_product2_ps_id = product2SizeId;

            dbObjInsertDailySpecialsOfferDetail.dso_amount = offerAmount;
            dbObjInsertDailySpecialsOfferDetail.dso_start_date = offerStartDate;
            dbObjInsertDailySpecialsOfferDetail.dso_end_date = offerEndDate;

            dbObjInsertDailySpecialsOfferDetail.dso_isdeleted = false;
            dbObjInsertDailySpecialsOfferDetail.createdby = userId;
            dbObjInsertDailySpecialsOfferDetail.modifiedby = userId;
            dbObjInsertDailySpecialsOfferDetail.createdon = DateTime.Now;
            dbObjInsertDailySpecialsOfferDetail.modifiedon = DateTime.Now;




            dbEntities.tp_dailyspecials_offer.Add(dbObjInsertDailySpecialsOfferDetail);
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


    //Update FeastForFive Offer Detail

    public string UpdateDailySpecialsOfferDetail(int dailySpecialsOfferId, string dailySpecialsOfferName, string dailySpecialsOfferDescription, string dailySpecialsOfferCode, int day, int product1Id, int product1Quantity, int product1SizeId, int product2Id, int product2Quantity, int product2SizeId, string offerAmount, int userId, DateTime offerStartDate, DateTime offerEndDate)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {
            tp_dailyspecials_offer dbObjUpdateDailySpecialsOfferDetail = null;
            dbObjUpdateDailySpecialsOfferDetail = dbEntities.tp_dailyspecials_offer.Where(P => P.dso_id == dailySpecialsOfferId).FirstOrDefault();

            dbObjUpdateDailySpecialsOfferDetail.dso_name = dailySpecialsOfferName;
            dbObjUpdateDailySpecialsOfferDetail.dso_description = dailySpecialsOfferDescription;
            dbObjUpdateDailySpecialsOfferDetail.dso_Offer_code = dailySpecialsOfferCode;
            dbObjUpdateDailySpecialsOfferDetail.dso_day = day;
            dbObjUpdateDailySpecialsOfferDetail.dso_product1_pd_id = product1Id;
            dbObjUpdateDailySpecialsOfferDetail.dso_product1_quantity = product1Quantity;
            dbObjUpdateDailySpecialsOfferDetail.dso_product1_ps_id = product1SizeId;

            dbObjUpdateDailySpecialsOfferDetail.dso_product2_pd_id = product2Id;
            dbObjUpdateDailySpecialsOfferDetail.dso_product2_quantity = product2Quantity;
            dbObjUpdateDailySpecialsOfferDetail.dso_product2_ps_id = product2SizeId;

            dbObjUpdateDailySpecialsOfferDetail.dso_amount = offerAmount;
            dbObjUpdateDailySpecialsOfferDetail.dso_start_date = offerStartDate;
            dbObjUpdateDailySpecialsOfferDetail.dso_end_date = offerEndDate;

            dbObjUpdateDailySpecialsOfferDetail.dso_isdeleted = false;
            dbObjUpdateDailySpecialsOfferDetail.modifiedby = userId;

            dbObjUpdateDailySpecialsOfferDetail.modifiedon = DateTime.Now;


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

    //Delete FeastForFive Offer Detail
    public string DeleteDailySpecialsOfferDetail(int dailySpecialsOfferId)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {
            tp_dailyspecials_offer dbObjDailySpecialsOfferDetail = null;
            dbObjDailySpecialsOfferDetail = dbEntities.tp_dailyspecials_offer.Where(P => P.dso_id == dailySpecialsOfferId).FirstOrDefault();

            dbObjDailySpecialsOfferDetail.dso_isdeleted = true;
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

    //Check if FeastForFive Offer Detail already exists
    public bool isDailySpecialsOfferDetailExist(string dailySpecialsOfferName)
    {
        bool retValue = false;
        try
        {
            tp_dailyspecials_offer result = dbEntities.tp_dailyspecials_offer.Where(P => P.dso_name.ToLower().Equals(dailySpecialsOfferName, StringComparison.InvariantCultureIgnoreCase) && P.dso_isdeleted == false).FirstOrDefault();

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

    //Get Feast For Five Offer List
    public DataTable GetDailySpecialOfferDetailList(string searchText = null)
    {

        List<ClsDailySpecialsOffer> lstClsDailySpecialsOffer = new List<ClsDailySpecialsOffer>();

        try
        {
            if (!string.IsNullOrEmpty(searchText))
            {

                var result = (from dso in dbEntities.tp_dailyspecials_offer
                              join pd1 in dbEntities.tp_product_details
                              on dso.dso_product1_pd_id equals pd1.pd_id into pd1id
                              from product1detail in pd1id.DefaultIfEmpty()
                              join ps1 in dbEntities.tp_product_sizes
                              on dso.dso_product1_ps_id equals ps1.ps_id into ps1id
                              from product1sizedetail in ps1id.DefaultIfEmpty()
                              join pd2 in dbEntities.tp_product_details
                              on dso.dso_product2_pd_id equals pd2.pd_id into pdid
                              from prodcutdetail in pdid.DefaultIfEmpty()
                              join ps2 in dbEntities.tp_product_sizes
                              on dso.dso_product2_ps_id equals ps2.ps_id into ps2id
                              from product2sizedetail in ps2id.DefaultIfEmpty()

                              where (dso.dso_isdeleted == false
                              && (dso.dso_name.Contains(searchText) || dso.dso_description.Contains(searchText)))
                              select new
                              {
                                  dso,
                                  //pd1,
                                  Product1Id = (product1detail == null ? 0 : product1detail.pd_id),
                                  Product1Name = (product1detail == null ? String.Empty : product1detail.pd_name),
                                  Product1SizeId = (product1sizedetail == null ? 0 : product1sizedetail.ps_id),
                                  Product1SizeName = (product1sizedetail == null ? String.Empty : product1sizedetail.ps_name),
                                  Product2Id = (prodcutdetail == null ? 0 : prodcutdetail.pd_id),
                                  Product2Name = (prodcutdetail == null ? String.Empty : prodcutdetail.pd_name),
                                  Product2SizeId = (product2sizedetail == null ? 0 : product2sizedetail.ps_id),
                                  Product2SizeName = (product2sizedetail == null ? String.Empty : product2sizedetail.ps_name),


                              }).ToList();
                foreach (var item in result)
                {
                    ClsDailySpecialsOffer objClsDailySpecialsOffer = new ClsDailySpecialsOffer();
                    objClsDailySpecialsOffer.DailySpecialsOfferId = item.dso.dso_id;
                    objClsDailySpecialsOffer.DailySpecialOfferName = item.dso.dso_name;
                    objClsDailySpecialsOffer.DailySpecialOfferDescription = item.dso.dso_description;
                    objClsDailySpecialsOffer.DailySpecialOfferCode = item.dso.dso_Offer_code;
                    objClsDailySpecialsOffer.DailySpecialDay = item.dso.dso_day.Value;
                    if (objClsDailySpecialsOffer.DailySpecialDay == 1)
                    {
                        objClsDailySpecialsOffer.DailySpecialDayName = "Monday";
                    }
                    if (objClsDailySpecialsOffer.DailySpecialDay == 2)
                    {
                        objClsDailySpecialsOffer.DailySpecialDayName = "Tuesday";
                    }
                    if (objClsDailySpecialsOffer.DailySpecialDay == 3)
                    {
                        objClsDailySpecialsOffer.DailySpecialDayName = "Wenesday";
                    }
                    if (objClsDailySpecialsOffer.DailySpecialDay == 4)
                    {
                        objClsDailySpecialsOffer.DailySpecialDayName = "Thursday";
                    }
                    if (objClsDailySpecialsOffer.DailySpecialDay == 5)
                    {
                        objClsDailySpecialsOffer.DailySpecialDayName = "Friday";
                    }
                    if (objClsDailySpecialsOffer.DailySpecialDay == 6)
                    {
                        objClsDailySpecialsOffer.DailySpecialDayName = "Saturday";
                    }
                    if (objClsDailySpecialsOffer.DailySpecialDay == 7)
                    {
                        objClsDailySpecialsOffer.DailySpecialDayName = "Sunday";
                    }

                    objClsDailySpecialsOffer.Product1Id = Convert.ToInt32(item.Product1Id);
                    objClsDailySpecialsOffer.Product1Name = item.Product1Name;
                    objClsDailySpecialsOffer.Product1SizeId = Convert.ToInt32(item.Product1SizeId);
                    objClsDailySpecialsOffer.Product1SizeName = item.Product1SizeName;
                    objClsDailySpecialsOffer.Product1Quantity = Convert.ToInt32(item.dso.dso_product1_quantity);
                    objClsDailySpecialsOffer.Product2Id = Convert.ToInt32(item.Product2Id);
                    objClsDailySpecialsOffer.Product2Name = item.Product2Name;
                    objClsDailySpecialsOffer.Product2SizeId = Convert.ToInt32(item.Product2SizeId);
                    objClsDailySpecialsOffer.Product2SizeName = item.Product2SizeName;
                    objClsDailySpecialsOffer.Product2Quantity = Convert.ToInt32(item.dso.dso_product2_quantity);

                    objClsDailySpecialsOffer.OfferAmount = item.dso.dso_amount;
                    objClsDailySpecialsOffer.Offerstartdatestring = item.dso.dso_start_date.Value.ToString("MM/dd/yyyy");
                    objClsDailySpecialsOffer.Offerenddatestring = item.dso.dso_end_date.Value.ToString("MM/dd/yyyy");

                    lstClsDailySpecialsOffer.Add(objClsDailySpecialsOffer);
                }
            }
            else
            {
                var result = (from dso in dbEntities.tp_dailyspecials_offer
                              join pd1 in dbEntities.tp_product_details
                              on dso.dso_product1_pd_id equals pd1.pd_id into pd1id
                              from product1detail in pd1id.DefaultIfEmpty()
                              join ps1 in dbEntities.tp_product_sizes
                              on dso.dso_product1_ps_id equals ps1.ps_id into ps1id
                              from product1sizedetail in ps1id.DefaultIfEmpty()
                              join pd2 in dbEntities.tp_product_details
                              on dso.dso_product2_pd_id equals pd2.pd_id into pdid
                              from prodcutdetail in pdid.DefaultIfEmpty()
                              join ps2 in dbEntities.tp_product_sizes
                              on dso.dso_product2_ps_id equals ps2.ps_id into ps2id
                              from product2sizedetail in ps2id.DefaultIfEmpty()

                              where (dso.dso_isdeleted == false)
                              select new
                              {
                                  dso,
                                  Product1Id = (product1detail == null ? 0 : product1detail.pd_id),
                                  Product1Name = (product1detail == null ? String.Empty : product1detail.pd_name),
                                  Product1SizeId = (product1sizedetail == null ? 0 : product1sizedetail.ps_id),
                                  Product1SizeName = (product1sizedetail == null ? String.Empty : product1sizedetail.ps_name),
                                  Product2Id = (prodcutdetail == null ? 0 : prodcutdetail.pd_id),
                                  Product2Name = (prodcutdetail == null ? String.Empty : prodcutdetail.pd_name),
                                  Product2SizeId = (product2sizedetail == null ? 0 : product2sizedetail.ps_id),
                                  Product2SizeName = (product2sizedetail == null ? String.Empty : product2sizedetail.ps_name),


                              }).ToList();
                foreach (var item in result)
                {
                    ClsDailySpecialsOffer objClsDailySpecialsOffer = new ClsDailySpecialsOffer();
                    objClsDailySpecialsOffer.DailySpecialsOfferId = item.dso.dso_id;
                    objClsDailySpecialsOffer.DailySpecialOfferName = item.dso.dso_name;
                    objClsDailySpecialsOffer.DailySpecialOfferDescription = item.dso.dso_description;
                    objClsDailySpecialsOffer.DailySpecialOfferCode = item.dso.dso_Offer_code;
                    objClsDailySpecialsOffer.DailySpecialDay = item.dso.dso_day.Value;
                    if (objClsDailySpecialsOffer.DailySpecialDay == 1)
                    {
                        objClsDailySpecialsOffer.DailySpecialDayName = "Monday";
                    }
                    if (objClsDailySpecialsOffer.DailySpecialDay == 2)
                    {
                        objClsDailySpecialsOffer.DailySpecialDayName = "Tuesday";
                    }
                    if (objClsDailySpecialsOffer.DailySpecialDay == 3)
                    {
                        objClsDailySpecialsOffer.DailySpecialDayName = "Wenesday";
                    }
                    if (objClsDailySpecialsOffer.DailySpecialDay == 4)
                    {
                        objClsDailySpecialsOffer.DailySpecialDayName = "Thursday";
                    }
                    if (objClsDailySpecialsOffer.DailySpecialDay == 5)
                    {
                        objClsDailySpecialsOffer.DailySpecialDayName = "Friday";
                    }
                    if (objClsDailySpecialsOffer.DailySpecialDay == 6)
                    {
                        objClsDailySpecialsOffer.DailySpecialDayName = "Saturday";
                    }
                    if (objClsDailySpecialsOffer.DailySpecialDay == 7)
                    {
                        objClsDailySpecialsOffer.DailySpecialDayName = "Sunday";
                    }

                    objClsDailySpecialsOffer.Product1Id = Convert.ToInt32(item.Product1Id);
                    objClsDailySpecialsOffer.Product1Name = item.Product1Name;
                    objClsDailySpecialsOffer.Product1SizeId = Convert.ToInt32(item.Product1SizeId);
                    objClsDailySpecialsOffer.Product1SizeName = item.Product1SizeName;
                    objClsDailySpecialsOffer.Product1Quantity = Convert.ToInt32(item.dso.dso_product1_quantity);
                    objClsDailySpecialsOffer.Product2Id = Convert.ToInt32(item.Product2Id);
                    objClsDailySpecialsOffer.Product2Name = item.Product2Name;
                    objClsDailySpecialsOffer.Product2SizeId = Convert.ToInt32(item.Product2SizeId);
                    objClsDailySpecialsOffer.Product2SizeName = item.Product2SizeName;
                    objClsDailySpecialsOffer.Product2Quantity = Convert.ToInt32(item.dso.dso_product2_quantity);

                    objClsDailySpecialsOffer.OfferAmount = item.dso.dso_amount;
                    objClsDailySpecialsOffer.Offerstartdatestring = item.dso.dso_start_date.Value.ToString("MM/dd/yyyy");
                    objClsDailySpecialsOffer.Offerenddatestring = item.dso.dso_end_date.Value.ToString("MM/dd/yyyy");

                    lstClsDailySpecialsOffer.Add(objClsDailySpecialsOffer);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsDailySpecialsOffer.ListToDataTable();
    }


    //Get Daily Special Offer list for Edit 
    public ClsDailySpecialsOffer GetDailySpecialOffer(int DailySpecialOfferId)
    {
        ClsDailySpecialsOffer objClsDailySpecialsOffer = new ClsDailySpecialsOffer();
        try
        {

            var result = (from dso in dbEntities.tp_dailyspecials_offer
                          join pd1 in dbEntities.tp_product_details
                          on dso.dso_product1_pd_id equals pd1.pd_id into pd1id
                          from product1detail in pd1id.DefaultIfEmpty()
                          join ps1 in dbEntities.tp_product_sizes
                          on dso.dso_product1_ps_id equals ps1.ps_id into ps1id
                          from product1sizedetail in ps1id.DefaultIfEmpty()
                          join pd2 in dbEntities.tp_product_details
                          on dso.dso_product2_pd_id equals pd2.pd_id into pdid
                          from prodcutdetail in pdid.DefaultIfEmpty()
                          join ps2 in dbEntities.tp_product_sizes
                          on dso.dso_product2_ps_id equals ps2.ps_id into ps2id
                          from product2sizedetail in ps2id.DefaultIfEmpty()

                          where (dso.dso_isdeleted == false  && dso.dso_id == DailySpecialOfferId)
                          select new
                          {
                              dso,
                              Product1Id = (product1detail == null ? 0 : product1detail.pd_id),
                              Product1Name = (product1detail == null ? String.Empty : product1detail.pd_name),
                              Product1SizeId = (product1sizedetail == null ? 0 : product1sizedetail.ps_id),
                              Product1SizeName = (product1sizedetail == null ? String.Empty : product1sizedetail.ps_name),
                              Product2Id = (prodcutdetail == null ? 0 : prodcutdetail.pd_id),
                              Product2Name = (prodcutdetail == null ? String.Empty : prodcutdetail.pd_name),
                              Product2SizeId = (product2sizedetail == null ? 0 : product2sizedetail.ps_id),
                              Product2SizeName = (product2sizedetail == null ? String.Empty : product2sizedetail.ps_name),


                          }).FirstOrDefault();

            if (result != null)
            {

                objClsDailySpecialsOffer.DailySpecialsOfferId = result.dso.dso_id;
                objClsDailySpecialsOffer.DailySpecialOfferName = result.dso.dso_name;
                objClsDailySpecialsOffer.DailySpecialOfferDescription = result.dso.dso_description;
                objClsDailySpecialsOffer.DailySpecialOfferCode = result.dso.dso_Offer_code;
                objClsDailySpecialsOffer.DailySpecialDay = result.dso.dso_day.Value;
                if (objClsDailySpecialsOffer.DailySpecialDay == 1)
                {
                    objClsDailySpecialsOffer.DailySpecialDayName = "Monday";
                }
                if (objClsDailySpecialsOffer.DailySpecialDay == 2)
                {
                    objClsDailySpecialsOffer.DailySpecialDayName = "Tuesday";
                }
                if (objClsDailySpecialsOffer.DailySpecialDay == 3)
                {
                    objClsDailySpecialsOffer.DailySpecialDayName = "Wenesday";
                }
                if (objClsDailySpecialsOffer.DailySpecialDay == 4)
                {
                    objClsDailySpecialsOffer.DailySpecialDayName = "Thursday";
                }
                if (objClsDailySpecialsOffer.DailySpecialDay == 5)
                {
                    objClsDailySpecialsOffer.DailySpecialDayName = "Friday";
                }
                if (objClsDailySpecialsOffer.DailySpecialDay == 6)
                {
                    objClsDailySpecialsOffer.DailySpecialDayName = "Saturday";
                }
                if (objClsDailySpecialsOffer.DailySpecialDay == 7)
                {
                    objClsDailySpecialsOffer.DailySpecialDayName = "Sunday";
                }

                objClsDailySpecialsOffer.Product1Id = Convert.ToInt32(result.Product1Id);
                objClsDailySpecialsOffer.Product1Name = result.Product1Name;
                objClsDailySpecialsOffer.Product1SizeId = Convert.ToInt32(result.Product1SizeId);
                objClsDailySpecialsOffer.Product1SizeName = result.Product1SizeName;
                objClsDailySpecialsOffer.Product1Quantity = Convert.ToInt32(result.dso.dso_product1_quantity);
                objClsDailySpecialsOffer.Product2Id = Convert.ToInt32(result.Product2Id);
                objClsDailySpecialsOffer.Product2Name = result.Product2Name;
                objClsDailySpecialsOffer.Product2SizeId = Convert.ToInt32(result.Product2SizeId);
                objClsDailySpecialsOffer.Product2SizeName = result.Product2SizeName;
                objClsDailySpecialsOffer.Product2Quantity = Convert.ToInt32(result.dso.dso_product2_quantity);
                objClsDailySpecialsOffer.Offerstartdatestring = result.dso.dso_start_date.Value.ToString("MM/dd/yyyy");
                objClsDailySpecialsOffer.Offerenddatestring = result.dso.dso_end_date.Value.ToString("MM/dd/yyyy");

                objClsDailySpecialsOffer.OfferAmount = result.dso.dso_amount;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objClsDailySpecialsOffer;
    }

    public List<tp_product_sizes> GetAllSize()
    {
        List<tp_product_sizes> lsttp_product_sizes = new List<tp_product_sizes>();
        try
        {
            lsttp_product_sizes = dbEntities.tp_product_sizes.Where(x => x.ps_isdeleted == false).ToList();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lsttp_product_sizes;
    }

    public List<tp_product_details> GetAllProduct()
    {
        List<tp_product_details> lsttp_product_details = new List<tp_product_details>();
        try
        {
            lsttp_product_details = dbEntities.tp_product_details.Where(x => x.pd_isdeleted == false).ToList();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lsttp_product_details;
    }

    public ClsProductDetail GetOfferAmountByOfferCode(string OfferCode, List<ClsProductDetail> lstProductDetail)
    {
        ClsProductDetail ClsProductDetailobj = new ClsProductDetail();
        int day = 0;
        decimal OfferPrice = 0;
        decimal ProductTotalPrice = 0;
        try
        {

            List<tp_dailyspecials_offer> lsttp_dailyspecials_offer = new List<tp_dailyspecials_offer>();
            lsttp_dailyspecials_offer = dbEntities.tp_dailyspecials_offer.Where(x => x.dso_Offer_code == OfferCode && x.dso_start_date <= EntityFunctions.TruncateTime(DateTime.Now) && x.dso_end_date >= EntityFunctions.TruncateTime(DateTime.Now)).ToList();

            List<tp_dollars_offer> lsttp_dollars_offer = new List<tp_dollars_offer>();
            lsttp_dollars_offer = dbEntities.tp_dollars_offer.Where(x => x.do_offer_code == OfferCode && x.do_start_date <= EntityFunctions.TruncateTime(DateTime.Now) && x.do_end_date >= EntityFunctions.TruncateTime(DateTime.Now)).ToList();

            tp_feast_forfive_offer objtp_feast_forfive_offer = new tp_feast_forfive_offer();
            objtp_feast_forfive_offer = dbEntities.tp_feast_forfive_offer.Where(x => x.ffo_offer_code == OfferCode && x.ffo_start_date <= EntityFunctions.TruncateTime(DateTime.Now) && x.ffo_end_date >= EntityFunctions.TruncateTime(DateTime.Now)).FirstOrDefault();

            List<tp_free_pizza_offer> lsttp_free_pizza_offer = new List<tp_free_pizza_offer>();
            lsttp_free_pizza_offer = dbEntities.tp_free_pizza_offer.Where(x => x.fpo_offer_code == OfferCode && x.fpo_start_date <= EntityFunctions.TruncateTime(DateTime.Now) && x.fpo_end_date >= EntityFunctions.TruncateTime(DateTime.Now)).ToList();

            day = (int)DateTime.Now.DayOfWeek;

            ClsMiscellaneousSettings objClsMiscellaneousSettings = new ClsMiscellaneousSettings();
            decimal Tax = Convert.ToDecimal(objClsMiscellaneousSettings.GetTaxConfigSetting().tpc_value.Replace("%", ""));
            decimal DEliveryCharge = Convert.ToDecimal(objClsMiscellaneousSettings.GetDeliveryChargeConfigSetting().tpc_value.Replace("$", ""));
            if (lsttp_dailyspecials_offer.Count > 0)
            {
                bool ConatainsProduct1 = false, ConatainsProduct2 = false, ConatainsProduct3 = false;
                int Product1Qty = 0, Product2Qty = 0, Product3Qty = 0;
                decimal Product1Price = 0, Product2Price = 0, Product3Price = 0;
                decimal price1 = 0, price2 = 0, price3 = 0;
                if (day == 1)
                {
                    if (lsttp_dailyspecials_offer[0].dso_day == day)
                    {
                        int Product1Id = lsttp_dailyspecials_offer[0].dso_product1_pd_id.Value;
                        int ProductId21 = lsttp_dailyspecials_offer[0].dso_product2_pd_id.Value;
                        int productId22 = 0;
                        if (lsttp_dailyspecials_offer.Count > 1)
                        {
                            productId22 = lsttp_dailyspecials_offer[1].dso_product2_pd_id.Value;
                        }
                        if (Product1Id != 0 && ProductId21 != 0 && productId22 != 0)
                        {
                            foreach (var item in lstProductDetail)
                            {
                                if (item.ProductdetailId == Product1Id && item.Quantity > 0)
                                {
                                    ConatainsProduct1 = true;
                                    Product1Qty = item.Quantity;
                                    Product1Price = item.Price;
                                }
                                if (item.ProductdetailId == ProductId21 && item.Quantity > 0)
                                {
                                    ConatainsProduct2 = true;
                                    Product2Qty = item.Quantity;
                                    Product2Price = item.Price;
                                }
                                if (item.ProductdetailId == productId22 && item.Quantity > 0)
                                {
                                    ConatainsProduct3 = true;
                                    Product3Qty = item.Quantity;
                                    Product3Price = item.Price;
                                }
                            }
                            if (ConatainsProduct1 == true && (ConatainsProduct2 == true || ConatainsProduct3 == true))
                            {
                                int qty = 0;

                                if (Product1Qty <= Product2Qty + Product3Qty)
                                {
                                    qty = Product1Qty;
                                }
                                else if (Product1Qty >= Product2Qty + Product3Qty)
                                {
                                    qty = Product2Qty + Product3Qty;
                                }
                                if (Product1Qty > 0)
                                {
                                    price1 = (Product1Price / Product1Qty);
                                }
                                if (Product2Qty > 0)
                                {
                                    price2 = (Product2Price / Product2Qty);
                                }
                                if (Product3Qty > 0)
                                {
                                    price3 = (Product3Price / Product3Qty);
                                }
                                if (Product3Qty > 0 && Product2Qty > 0)
                                {
                                    if (Product1Qty >= Product2Qty + Product3Qty)
                                    {
                                        ProductTotalPrice = (price1 * qty) + (price2 * Product2Qty) + (price3 * Product3Qty);
                                    }
                                    else
                                    {
                                        if (Product2Qty >= qty)
                                        {
                                            ProductTotalPrice = (price1 * qty) + (price2 * qty);
                                        }
                                        else if (Product3Qty >= qty)
                                        {
                                            ProductTotalPrice = (price1 * qty) + (price3 * qty);
                                        }
                                        else
                                        {
                                            ProductTotalPrice = (price1 * qty) + (price2 * Product2Qty) + (price3 * (qty - Product2Qty));
                                        }
                                    }
                                }
                                else if (Product2Qty > 0)
                                {
                                    ProductTotalPrice = (price1 * qty) + (price2 * qty);
                                }
                                else if (Product3Qty > 0)
                                {
                                    ProductTotalPrice = (price1 * qty) + (price3 * qty);
                                }
                                //OfferPrice = (Convert.ToDecimal(lsttp_dailyspecials_offer[0].dso_amount)) * qty;
                                OfferPrice = ProductTotalPrice - (Convert.ToDecimal(lsttp_dailyspecials_offer[0].dso_amount)) * qty;
                            }
                        }

                        else
                        {
                            foreach (var item in lstProductDetail)
                            {
                                if (item.ProductdetailId == Product1Id && item.Quantity > 0 && item.SizeId == lsttp_dailyspecials_offer[0].dso_product1_ps_id)
                                {
                                    ConatainsProduct1 = true;
                                    Product1Qty = item.Quantity;
                                    Product1Price = item.Price;
                                }
                            }
                            if (ConatainsProduct1 == true)
                            {
                                OfferPrice = Product1Price - (Convert.ToDecimal(lsttp_dailyspecials_offer[0].dso_amount)) * Product1Qty;
                            }
                        }
                    }
                }
                if (day == 2)
                {
                    if (lsttp_dailyspecials_offer[0].dso_day == day)
                    {
                        int Product1Id = lsttp_dailyspecials_offer[0].dso_product1_pd_id.Value;
                        foreach (var item in lstProductDetail)
                        {
                            if (item.ProductdetailId == Product1Id && item.Quantity > 0)
                            {
                                ConatainsProduct1 = true;
                                Product1Qty = item.Quantity;
                                Product1Price = item.Price;
                            }
                        }
                        if (ConatainsProduct1 == true)
                        {
                            OfferPrice = Product1Price - (Convert.ToDecimal(lsttp_dailyspecials_offer[0].dso_amount)) * Product1Qty;
                        }
                    }
                }
                if (day == 3)
                {
                    if (lsttp_dailyspecials_offer[0].dso_day == day)
                    {
                        int Product1Id = lsttp_dailyspecials_offer[0].dso_product1_pd_id.Value;
                        int Product2Id = lsttp_dailyspecials_offer[0].dso_product2_pd_id.Value;
                        int product3Id = 0;

                        if (lsttp_dailyspecials_offer.Count > 1)
                        {
                            product3Id = lsttp_dailyspecials_offer[1].dso_product2_pd_id.Value;
                        }
                        if (Product1Id != 0 && Product2Id != 0 && product3Id != 0)
                        {
                            foreach (var item in lstProductDetail)
                            {
                                if (item.ProductdetailId == Product1Id && item.Quantity >= lsttp_dailyspecials_offer[0].dso_product1_quantity)
                                {
                                    ConatainsProduct1 = true;
                                    Product1Qty = item.Quantity;
                                    Product1Price = item.Price;
                                }
                                if (item.ProductdetailId == Product2Id && item.Quantity >= lsttp_dailyspecials_offer[0].dso_product2_quantity)
                                {
                                    ConatainsProduct2 = true;
                                    Product2Qty = item.Quantity;
                                    Product2Price = item.Price;
                                }
                                if (item.ProductdetailId == product3Id && item.Quantity >= lsttp_dailyspecials_offer[1].dso_product2_quantity)
                                {
                                    ConatainsProduct3 = true;
                                    Product3Qty = item.Quantity;
                                    Product3Price = item.Price;
                                }
                            }
                            if (ConatainsProduct1 == true && (ConatainsProduct2 == true || ConatainsProduct3 == true))
                            {
                                int qty = 0;
                                if (lsttp_dailyspecials_offer[1].dso_product2_quantity == 4 || (lsttp_dailyspecials_offer[0].dso_product2_quantity == 4))
                                {
                                    if (Product1Qty > 0)
                                    {
                                        price1 = (Product1Price / Product1Qty);
                                    }
                                    if (Product2Qty > 0)
                                    {
                                        price2 = (Product2Price / Product2Qty);
                                    }
                                    if (Product3Qty > 0)
                                    {
                                        price3 = (Product3Price / Product3Qty);
                                    }

                                    Product2Qty = Product2Qty / 4;
                                    if (Product1Qty <= Product2Qty + Product3Qty)
                                    {
                                        qty = Product1Qty;
                                    }
                                    if (Product1Qty >= Product2Qty + Product3Qty)
                                    {
                                        qty = Product2Qty + Product3Qty;
                                    }


                                    if (Product3Qty > 0 && Product2Qty > 0)
                                    {
                                        if (Product1Qty >= Product2Qty + Product3Qty)
                                        {
                                            ProductTotalPrice = (price1 * qty) + (price2 * Product2Qty * 4) + (price3 * Product3Qty);
                                        }
                                        else
                                        {
                                            if (Product2Qty >= qty)
                                            {
                                                ProductTotalPrice = (price1 * qty) + (price2 * qty * 4);
                                            }
                                            else if (Product3Qty >= qty)
                                            {
                                                ProductTotalPrice = (price1 * qty) + (price3 * qty);
                                            }
                                            else
                                            {
                                                ProductTotalPrice = (price1 * qty) + (price2 * Product2Qty * 4) + (price3 * (qty - Product2Qty));
                                            }

                                        }
                                    }
                                    else if (Product2Qty > 0)
                                    {
                                        ProductTotalPrice = (price1 * qty) + (price2 * qty * 4);
                                    }
                                    else if (Product3Qty > 0)
                                    {
                                        ProductTotalPrice = (price1 * qty) + (price3 * qty);
                                    }

                                    OfferPrice = ProductTotalPrice - (Convert.ToDecimal(lsttp_dailyspecials_offer[0].dso_amount)) * qty;
                                }
                                else
                                {
                                    if (Product1Qty <= Product2Qty + Product3Qty)
                                    {
                                        qty = Product1Qty;
                                    }
                                    else if (Product1Qty >= Product2Qty + Product3Qty)
                                    {
                                        qty = Product2Qty + Product3Qty;
                                    }
                                    if (Product1Qty > 0)
                                    {
                                        price1 = (Product1Price / Product1Qty);
                                    }
                                    if (Product2Qty > 0)
                                    {
                                        price2 = (Product2Price / Product2Qty);
                                    }
                                    if (Product3Qty > 0)
                                    {
                                        price3 = (Product3Price / Product3Qty);
                                    }
                                    if (Product3Qty > 0 && Product2Qty > 0)
                                    {
                                        if (Product1Qty >= Product2Qty + Product3Qty)
                                        {
                                            ProductTotalPrice = (price1 * qty) + (price2 * Product2Qty) + (price3 * Product3Qty);
                                        }
                                        else
                                        {
                                            if (Product2Qty >= qty)
                                            {
                                                ProductTotalPrice = (price1 * qty) + (price2 * qty);
                                            }
                                            else if (Product3Qty >= qty)
                                            {
                                                ProductTotalPrice = (price1 * qty) + (price3 * qty);
                                            }
                                            else
                                            {
                                                ProductTotalPrice = (price1 * qty) + (price2 * Product2Qty) + (price3 * (qty - Product2Qty));
                                            }
                                        }
                                    }
                                    else if (Product2Qty > 0)
                                    {
                                        ProductTotalPrice = (price1 * qty) + (price2 * qty);
                                    }
                                    else if (Product3Qty > 0)
                                    {
                                        ProductTotalPrice = (price1 * qty) + (price3 * qty);
                                    }
                                    //OfferPrice = (Convert.ToDecimal(lsttp_dailyspecials_offer[0].dso_amount)) * qty;
                                    OfferPrice = ProductTotalPrice - (Convert.ToDecimal(lsttp_dailyspecials_offer[0].dso_amount)) * qty;
                                }

                            }
                        }
                        else if(lsttp_dailyspecials_offer[0].dso_product2_pd_id==0 && ConatainsProduct1==true)
                        {
                            OfferPrice = Product1Price - (Convert.ToDecimal(lsttp_dailyspecials_offer[0].dso_amount)) * Product1Qty;
                        }
                    }
                }
                if (day == 4)
                {
                    if (lsttp_dailyspecials_offer[0].dso_day == day)
                    {
                        int Product1Id = lsttp_dailyspecials_offer[0].dso_product1_pd_id.Value;

                        foreach (var item in lstProductDetail)
                        {
                            if (item.ProductdetailId == Product1Id && item.Quantity > 0)
                            {
                                ConatainsProduct1 = true;
                                Product1Qty = item.Quantity;
                                Product1Price = item.Price;
                            }
                        }
                        if (ConatainsProduct1 == true)
                        {
                            OfferPrice = Product1Price - (Convert.ToDecimal(lsttp_dailyspecials_offer[0].dso_amount)) * Product1Qty;
                        }
                    }
                }
                if (day == 5)
                {
                    if (lsttp_dailyspecials_offer[0].dso_day == day)
                    {
                        int Product1Id = lsttp_dailyspecials_offer[0].dso_product1_pd_id.Value;

                        foreach (var item in lstProductDetail)
                        {
                            if (item.ProductdetailId == Product1Id && item.Quantity >= lsttp_dailyspecials_offer[0].dso_product1_quantity.Value)
                            {
                                ConatainsProduct1 = true;
                                Product1Qty = item.Quantity;
                                Product1Price = item.Price;
                            }
                        }
                        if (ConatainsProduct1 == true)
                        {
                            if (lsttp_dailyspecials_offer[0].dso_product1_quantity.Value == 14)
                            {
                                Product1Qty = Product1Qty / 14;
                                OfferPrice = Product1Price - (Convert.ToDecimal(lsttp_dailyspecials_offer[0].dso_amount)) * Product1Qty;
                            }
                            else
                            {
                                OfferPrice = Product1Price - (Convert.ToDecimal(lsttp_dailyspecials_offer[0].dso_amount)) * Product1Qty;
                            }
                        }
                    }
                }
                if (day == 6)
                {
                    if (lsttp_dailyspecials_offer[0].dso_day == day)
                    {
                        int Product1Id = lsttp_dailyspecials_offer[0].dso_product1_pd_id.Value;
                        if (lsttp_dailyspecials_offer[0].dso_product2_pd_id == 0)
                        {
                            foreach (var item in lstProductDetail)
                            {
                                if (item.ProductdetailId == Product1Id && item.Quantity > 0)
                                {
                                    ConatainsProduct1 = true;
                                    Product1Qty = item.Quantity;
                                    Product1Price = item.Price;
                                }
                            }
                            if (ConatainsProduct1 == true)
                            {
                                OfferPrice = Product1Price - (Convert.ToDecimal(lsttp_dailyspecials_offer[0].dso_amount)) * Product1Qty;
                            }
                        }
                        else
                        {
                            int qty = 0;
                            int Product2Id = lsttp_dailyspecials_offer[0].dso_product2_pd_id.Value;
                            foreach (var item in lstProductDetail)
                            {
                                if (item.ProductdetailId == Product1Id && item.Quantity > 0)
                                {
                                    ConatainsProduct1 = true;
                                    Product1Qty = item.Quantity;
                                    Product1Price = item.Price;
                                }
                                if (item.ProductdetailId == Product2Id && item.Quantity > 0)
                                {
                                    ConatainsProduct2 = true;
                                    Product2Qty = item.Quantity;
                                    Product2Price = item.Price;
                                }
                            }
                            if (ConatainsProduct1 == true && ConatainsProduct2 == true)
                            {
                                if (Product1Qty <= Product2Qty)
                                {
                                    qty = Product1Qty;
                                }
                                else if (Product1Qty >= Product2Qty)
                                {
                                    qty = Product2Qty;
                                }
                                if (Product1Qty > 0)
                                {
                                    price1 = (Product1Price / Product1Qty);
                                }
                                if (Product2Qty > 0)
                                {
                                    price2 = (Product2Price / Product2Qty);
                                }
                                ProductTotalPrice = (price1 * qty) + (price2 * qty);
                                OfferPrice = ProductTotalPrice - (Convert.ToDecimal(lsttp_dailyspecials_offer[0].dso_amount)) * qty;
                            }
                        }
                    }
                }
                if (day == 7)
                {
                    if (lsttp_dailyspecials_offer[0].dso_day == day)
                    {
                        int Product1Id = lsttp_dailyspecials_offer[0].dso_product1_pd_id.Value;
                        if (Product1Id == 0)
                        {
                            foreach (var item in lstProductDetail)
                            {
                                if (lsttp_dailyspecials_offer[0].dso_product1_ps_id == item.SizeId && (item.ExtraIngredientId != "" || item.ExtraIngredientId != null))
                                {
                                    OfferPrice = OfferPrice +( Convert.ToDecimal(lsttp_dailyspecials_offer[0].dso_amount))*item.Quantity;
                                }
                            }
                        }
                        else
                        {
                            int Product2Id = 0;
                            if (lsttp_dailyspecials_offer.Count > 1)
                            {
                                Product2Id = lsttp_dailyspecials_offer[1].dso_product1_pd_id.Value;
                            }
                            foreach (var item in lstProductDetail)
                            {
                                if (item.ProductdetailId == Product1Id && item.Quantity >= lsttp_dailyspecials_offer[0].dso_product1_quantity.Value)
                                {
                                    ConatainsProduct1 = true;
                                    Product1Qty = item.Quantity;
                                    Product1Price = item.Price;
                                }
                                if (item.ProductdetailId == Product2Id && item.Quantity >= lsttp_dailyspecials_offer[1].dso_product1_quantity.Value)
                                {
                                    ConatainsProduct2 = true;
                                    Product2Qty = item.Quantity;
                                    Product2Price = item.Price;
                                }
                            }
                            if (ConatainsProduct1 == true && ConatainsProduct2 == true)
                            {
                                if (lsttp_dailyspecials_offer[0].dso_product1_quantity.Value == 4)
                                {
                                    Product1Qty = Product1Qty / 4;
                                }
                                if (lsttp_dailyspecials_offer[0].dso_product1_quantity.Value == 2)
                                {
                                    Product1Qty = Product1Qty / 2;
                                }
                                if (lsttp_dailyspecials_offer[1].dso_product1_quantity.Value == 4)
                                {
                                    Product2Qty = Product2Qty / 4;
                                }
                                if (lsttp_dailyspecials_offer[1].dso_product1_quantity.Value == 2)
                                {
                                    Product2Qty = Product2Qty / 2;
                                }
                                OfferPrice = Product1Price - (Convert.ToDecimal(lsttp_dailyspecials_offer[0].dso_amount)) * Product1Qty;
                                OfferPrice = OfferPrice + (Product2Price - (Convert.ToDecimal(lsttp_dailyspecials_offer[1].dso_amount)) * Product2Qty);
                            }
                            else if (ConatainsProduct1 == true)
                            {
                                if (lsttp_dailyspecials_offer[0].dso_product1_quantity.Value == 4)
                                {
                                    Product1Qty = Product1Qty / 4;
                                }
                                if (lsttp_dailyspecials_offer[0].dso_product1_quantity.Value == 2)
                                {
                                    Product1Qty = Product1Qty / 2;
                                }
                                OfferPrice = Product1Price - (Convert.ToDecimal(lsttp_dailyspecials_offer[0].dso_amount)) * Product1Qty;
                            }
                            else if (ConatainsProduct2 == true)
                            {
                                if (lsttp_dailyspecials_offer[1].dso_product1_quantity.Value == 4)
                                {
                                    Product2Qty = Product2Qty / 4;
                                }
                                if (lsttp_dailyspecials_offer[1].dso_product1_quantity.Value == 2)
                                {
                                    Product2Qty = Product2Qty / 2;
                                }
                                OfferPrice = Product2Price - (Convert.ToDecimal(lsttp_dailyspecials_offer[1].dso_amount)) * Product2Qty;
                            }
                        }
                    }
                }
                ClsProductDetailobj.ProductdetailId = 0;
                ClsProductDetailobj.OfferAmount = OfferPrice ;
            }
            else if (lsttp_dollars_offer.Count > 0)
            {
                bool ConatainsProduct1 = false, ConatainsProduct2 = false;
                int Product1Qty = 0, Product2Qty = 0;

                int size1Id = lsttp_dollars_offer[0].do_ps_id.Value;
                int size2Id = 0;
                if (lsttp_dollars_offer.Count > 1)
                {
                    size2Id = lsttp_dollars_offer[1].do_ps_id.Value;
                }
                foreach (var item in lstProductDetail)
                {
                    ConatainsProduct1 = false;
                    ConatainsProduct2 = false;
                    if (item.SizeId == size1Id)
                    {
                        Product1Qty = item.Quantity;
                        ConatainsProduct1 = true;
                    }
                    if (item.SizeId == size2Id)
                    {
                        Product2Qty = item.Quantity;
                        ConatainsProduct2 = true;
                    }

                    if (ConatainsProduct1 == true && ConatainsProduct2 == true)
                    {
                        OfferPrice = OfferPrice + (Convert.ToDecimal(lsttp_dollars_offer[0].do_amount) * Product1Qty) + (Convert.ToDecimal(lsttp_dollars_offer[1].do_amount) * Product2Qty);
                    }
                    else if (ConatainsProduct1 == true)
                    {
                        OfferPrice = OfferPrice + (Convert.ToDecimal(lsttp_dollars_offer[0].do_amount) * Product1Qty);
                    }
                    else if (ConatainsProduct2 == true)
                    {
                        if (lsttp_dollars_offer.Count > 1)
                        {
                            OfferPrice = OfferPrice + (Convert.ToDecimal(lsttp_dollars_offer[1].do_amount) * Product2Qty);
                        }
                    }
                }
                ClsProductDetailobj.ProductdetailId = 0;
                ClsProductDetailobj.OfferAmount = OfferPrice;
            }
            else if (objtp_feast_forfive_offer != null)
            {
                bool ConatainsProduct1 = false, ConatainsProduct2 = false, ConatainsProduct3 = false;
                int Product1Qty = 0, Product2Qty = 0, Product3Qty = 0;
                decimal product1Price = 0, product2Price = 0, product3Price = 0;
                decimal price1 = 0, price2 = 0, price3 = 0;
                int qty = 0;

                int size1Id = objtp_feast_forfive_offer.ffo_product1_ps_id.Value;

                foreach (var item in lstProductDetail)
                {
                    string extraingredient = item.ExtraIngredientId;
                    string[] id = extraingredient.Split(',');
                    if (item.SizeId == size1Id && id.Length == 2)
                    {
                        ConatainsProduct1 = true;
                        product1Price = item.Price;
                        Product1Qty = item.Quantity;
                    }
                    if (item.ProductdetailId == objtp_feast_forfive_offer.ffo_product2_pd_id && item.Quantity >= objtp_feast_forfive_offer.ffo_product2_quantity)
                    {
                        ConatainsProduct2 = true;
                        product2Price = item.Price;
                        Product2Qty = item.Quantity;
                    }
                    if (item.ProductdetailId == objtp_feast_forfive_offer.ffo_product3_pd_id && item.Quantity >= objtp_feast_forfive_offer.ffo_product3_quantity)
                    {
                        ConatainsProduct3 = true;
                        product3Price = item.Price;
                        Product3Qty = item.Quantity;
                    }
                }
                if (ConatainsProduct1 == true && (ConatainsProduct2 == true || ConatainsProduct3 == true))
                {
                    if (Product1Qty > 0)
                    {
                        price1 = (product1Price / Product1Qty);
                    }
                    if (Product2Qty > 0)
                    {
                        price2 = (product2Price / Product2Qty);
                    }
                    if (Product3Qty > 0)
                    {
                        price3 = (product3Price / Product3Qty);
                    }
                    if (Product1Qty <= Product3Qty)
                    {
                        if (Product2Qty >= Product1Qty * 8)
                        {
                            qty = Product1Qty;
                        }
                    }
                    if (Product1Qty > Product3Qty)
                    {
                        if (Product2Qty >= Product3Qty * 8)
                        {
                            qty = Product3Qty;
                        }
                    }
                    //if (Product2Qty > 0)
                    //{
                    //    Product2Qty = Product2Qty / 8;
                    //}
                    ProductTotalPrice = (price1 * 1) + (price2 * 8) + (price3 * 1);
                    ProductTotalPrice = ProductTotalPrice + (price1 * (Product1Qty - 1));
                    ProductTotalPrice = ProductTotalPrice + (price2 * (Product2Qty - 8));
                    ProductTotalPrice = ProductTotalPrice + (price3 * (Product3Qty - 1));
                    //if (Product1Qty <= Product2Qty + Product3Qty)
                    //{
                    //    qty = Product1Qty;
                    //}
                    //else if (Product1Qty >= Product2Qty + Product3Qty)
                    //{
                    //    qty = Product2Qty + Product3Qty;
                    //}

                    //if (Product3Qty > 0 && Product2Qty > 0)
                    //{
                    //    if (Product1Qty >= Product2Qty + Product3Qty)
                    //    {
                    //        ProductTotalPrice = (price1 * qty) + (price2 * Product2Qty*8) + (price3 * Product3Qty);
                    //    }
                    //    else
                    //    {
                    //        if (Product2Qty >= qty)
                    //        {
                    //            ProductTotalPrice = (price1 * qty) + (price2 * qty*8);
                    //        }
                    //        else if (Product3Qty >= qty)
                    //        {
                    //            ProductTotalPrice = (price1 * qty) + (price3 * qty);
                    //        }
                    //        else
                    //        {
                    //            ProductTotalPrice = (price1 * qty) + (price2 * Product2Qty*8) + (price3 * (qty - Product2Qty));
                    //        }
                    //    }
                    //}
                    //else if (Product2Qty > 0)
                    //{
                    //    ProductTotalPrice = (price1 * qty) + (price2 * qty*8);
                    //}
                    //else if (Product3Qty > 0)
                    //{
                    //    ProductTotalPrice = (price1 * qty) + (price3 * qty);
                    //}
                    OfferPrice = ProductTotalPrice - (Convert.ToDecimal(objtp_feast_forfive_offer.ffo_amount)) * qty;
                    ClsProductDetailobj.ProductdetailId = 0;
                    ClsProductDetailobj.OfferAmount = OfferPrice ;
                    //ClsProductDetailobj.OfferAmount = OfferPrice+((OfferPrice*Tax)/100) + DEliveryCharge;
                }
            }
            if (lsttp_free_pizza_offer.Count > 0)
            {
                bool ConatainsProduct1 = false, ConatainsProduct2 = false;
                int Product1Qty = 0, product2Qty = 0;
                decimal product1Price = 0;

                int size1Id = lsttp_free_pizza_offer[0].fpo_validate_ps_id.Value;
                int size2Id = 0;
                if (lsttp_free_pizza_offer.Count > 1)
                {
                    size2Id = lsttp_free_pizza_offer[1].fpo_validate_ps_id.Value;
                }

                foreach (var item in lstProductDetail)
                {
                    ConatainsProduct1 = false;
                    ConatainsProduct2 = false;
                    string extraingredient = item.ExtraIngredientId;
                    string[] id = extraingredient.Split(',');
                    if (id[0] != "")
                    {
                        if (item.SizeId == size1Id)
                        {
                            ConatainsProduct1 = true;
                            product1Price = item.Price;
                            Product1Qty = item.Quantity;
                        }
                        if (size2Id != 0)
                        {
                            if (item.SizeId == size2Id)
                            {
                                ConatainsProduct2 = true;
                                product2Qty = item.Quantity;
                            }
                        }
                        if (ConatainsProduct1 == true && ConatainsProduct2 == true)
                        {
                            ClsProductDetailobj.ProductdetailId = lsttp_free_pizza_offer[0].fpo_free_product.Value;
                            ClsProductDetailobj.SizeId = lsttp_free_pizza_offer[0].fpo_free_ps_id.Value;
                            if (ConatainsProduct2 == true)
                            {
                                ClsProductDetailobj.CombineSizeId = ClsProductDetailobj.SizeId + "," + lsttp_free_pizza_offer[1].fpo_free_ps_id.Value;
                            }
                            else
                            {
                                ClsProductDetailobj.CombineSizeId = "0";
                            }
                            tp_product_details objtp_product_details = new tp_product_details();
                            objtp_product_details = dbEntities.tp_product_details.Where(x => x.pd_id == ClsProductDetailobj.ProductdetailId && x.pd_isdeleted == false).FirstOrDefault();
                            if (objtp_product_details != null)
                            {
                                ClsProductDetailobj.ProductName = objtp_product_details.pd_name;
                                ClsProductDetailobj.Price = 0;
                            }

                            tp_product_sizes objtp_product_sizes = new tp_product_sizes();
                            objtp_product_sizes = dbEntities.tp_product_sizes.Where(x => x.ps_id == ClsProductDetailobj.SizeId && x.ps_isdeleted == false).FirstOrDefault();
                            if (objtp_product_sizes != null)
                            {
                                ClsProductDetailobj.SizeName = objtp_product_sizes.ps_name;
                            }

                            tp_product_properties objtp_product_properties = new tp_product_properties();
                            objtp_product_properties = dbEntities.tp_product_properties.Where(x => x.pd_id == ClsProductDetailobj.ProductdetailId && x.ps_id == ClsProductDetailobj.SizeId && x.pp_isdeleted == false).FirstOrDefault();
                            if (objtp_product_properties != null)
                            {
                                ClsProductDetailobj.PropertiesId = objtp_product_properties.pp_id;
                            }

                            ClsProductDetailobj.ExtraIngredientId = "0";
                            ClsProductDetailobj.OneQuantityPrice = 0;
                            ClsProductDetailobj.IngredientFactId = 0;
                            ClsProductDetailobj.OfferAmount = 0;
                            ClsProductDetailobj.Quantity = ClsProductDetailobj.Quantity + Product1Qty + product2Qty;
                        }
                        else if ((ConatainsProduct1 == true && ConatainsProduct2 == false) || (ConatainsProduct1 == false && ConatainsProduct2 == true))
                        {
                            ClsProductDetailobj.ProductdetailId = lsttp_free_pizza_offer[0].fpo_free_product.Value;
                            ClsProductDetailobj.SizeId = lsttp_free_pizza_offer[0].fpo_free_ps_id.Value;
                            tp_product_details objtp_product_details = new tp_product_details();
                            objtp_product_details = dbEntities.tp_product_details.Where(x => x.pd_id == ClsProductDetailobj.ProductdetailId && x.pd_isdeleted == false).FirstOrDefault();
                            if (objtp_product_details != null)
                            {
                                ClsProductDetailobj.ProductName = objtp_product_details.pd_name;
                                ClsProductDetailobj.Price = 0;
                            }

                            tp_product_sizes objtp_product_sizes = new tp_product_sizes();
                            objtp_product_sizes = dbEntities.tp_product_sizes.Where(x => x.ps_id == ClsProductDetailobj.SizeId && x.ps_isdeleted == false).FirstOrDefault();
                            if (objtp_product_sizes != null)
                            {
                                ClsProductDetailobj.SizeName = objtp_product_sizes.ps_name;
                            }

                            tp_product_properties objtp_product_properties = new tp_product_properties();
                            objtp_product_properties = dbEntities.tp_product_properties.Where(x => x.pd_id == ClsProductDetailobj.ProductdetailId && x.ps_id == ClsProductDetailobj.SizeId && x.pp_isdeleted == false).FirstOrDefault();
                            if (objtp_product_properties != null)
                            {
                                ClsProductDetailobj.PropertiesId = objtp_product_properties.pp_id;
                            }
                            ClsProductDetailobj.CombineSizeId = "0";
                            ClsProductDetailobj.ExtraIngredientId = "0";
                            ClsProductDetailobj.OneQuantityPrice = 0;
                            ClsProductDetailobj.IngredientFactId = 0;
                            ClsProductDetailobj.OfferAmount = 0;
                            if (ConatainsProduct1 == true)
                            {
                                ClsProductDetailobj.Quantity = ClsProductDetailobj.Quantity + Product1Qty;
                            }
                            if (ConatainsProduct2 == true)
                            {
                                ClsProductDetailobj.Quantity = ClsProductDetailobj.Quantity + product2Qty;
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return ClsProductDetailobj;
    }
}