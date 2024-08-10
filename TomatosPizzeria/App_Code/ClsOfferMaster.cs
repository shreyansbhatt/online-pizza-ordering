using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;

/// <summary>
/// Summary description for ClsOfferMaster
/// </summary>
public class ClsOfferMaster
{
    TP_DatabaseEntities dbEntities = new TP_DatabaseEntities();
    public ClsOfferMaster()
    {

    }
    #region Properties

    private string m_offerName;
    private string m_offerCode;
    private string m_offerDescription;
    private string m_offerExpirationDate;
    private int m_offerType;
    private int m_offerValue;


    public string OfferName
    {
        get
        {
            return m_offerName;
        }

        set
        {
            m_offerName = value;
        }
    }

    public int OfferType
    {
        get
        {
            return m_offerType;
        }

        set
        {
            m_offerType = value;
        }
    }

    public int OfferValue
    {
        get
        {
            return m_offerValue;
        }

        set
        {
            m_offerValue = value;
        }
    }

    public string OfferCode
    {
        get
        {
            return m_offerCode;
        }

        set
        {
            m_offerCode = value;
        }
    }

    public string OfferDescription
    {
        get
        {
            return m_offerDescription;
        }

        set
        {
            m_offerDescription = value;
        }
    }

    public string OfferExpirationDate
    {
        get
        {
            return m_offerExpirationDate;
        }

        set
        {
            m_offerExpirationDate = value;
        }
    }


    #endregion

    //Insert New OfferDetail
    public string InsertNewOfferDetail(string offerName, int offerType, int offerValue, string offerCode, int userId)
    {
        int retValue = 0;
        string retMsg = string.Empty;

        try
        {

            tp_offer_master dbObjInsertOfferDetail = new tp_offer_master();
            dbObjInsertOfferDetail.om_name = offerName;
            dbObjInsertOfferDetail.om_type = offerType;
            dbObjInsertOfferDetail.om_value = offerValue;
            dbObjInsertOfferDetail.om_offer_code = offerCode;
            dbObjInsertOfferDetail.om_isdeleted = false;
            dbObjInsertOfferDetail.createdby = userId;
            dbObjInsertOfferDetail.modifiedby = userId;
            dbObjInsertOfferDetail.createdon = DateTime.Now;
            dbObjInsertOfferDetail.modifiedon = DateTime.Now;




            dbEntities.tp_offer_master.Add(dbObjInsertOfferDetail);
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


    //Update Offer Detail

    public string UpdateOfferDetail(int offerId, string offerName, int offerType, int offerValue, string offerCode, int userId)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {
            tp_offer_master dbObjUpdateOfferDetail = null;
            dbObjUpdateOfferDetail = dbEntities.tp_offer_master.Where(P => P.om_id == offerId).FirstOrDefault();

            dbObjUpdateOfferDetail.om_name = offerName;
            dbObjUpdateOfferDetail.om_type = offerType;
            dbObjUpdateOfferDetail.om_value = offerValue;
            dbObjUpdateOfferDetail.om_offer_code = offerCode;
            dbObjUpdateOfferDetail.om_isdeleted = false;

            dbObjUpdateOfferDetail.modifiedby = userId;

            dbObjUpdateOfferDetail.modifiedon = DateTime.Now;


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

    //Delete Offer Detail
    public string DeleteOfferDetail(int offerId)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {
            tp_offer_master dbObjDeleteOfferDetail = null;
            dbObjDeleteOfferDetail = dbEntities.tp_offer_master.Where(P => P.om_id == offerId).FirstOrDefault();

            dbObjDeleteOfferDetail.om_isdeleted = true;
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

    //Get Offer List
    public DataTable GetOfferDetailList()
    {
        List<tp_offer_master> lstOfferDetail = new List<tp_offer_master>();
        List<ClsOfferMaster> lstClsOfferMaster = new List<ClsOfferMaster>();

        List<ClsFreePizzaOffer> lstClsFreePizzaOffer = new List<ClsFreePizzaOffer>();
        List<ClsDollarsOffer> lstClsDollarsOffer = new List<ClsDollarsOffer>();
        List<ClsFeastForFiveOffer> lstClsFeastForFiveOffer = new List<ClsFeastForFiveOffer>();
        List<ClsDailySpecialsOffer> lstClsDailySpecialsOffer = new List<ClsDailySpecialsOffer>();


        try
        {
            var resultFreePizzaOffer = (from fpo in dbEntities.tp_free_pizza_offer
                                        where fpo.fpo_isdeleted == false
                                        select fpo).ToList();
            resultFreePizzaOffer = resultFreePizzaOffer.GroupBy(x => x.fpo_offer_code).Select(g => g.First()).ToList();
            foreach (var item in resultFreePizzaOffer)
            {
                ClsOfferMaster objClsOfferMaster = new ClsOfferMaster();
                objClsOfferMaster.OfferName = item.fpo_name;
                objClsOfferMaster.OfferDescription = item.fpo_description;
                string desc = objClsOfferMaster.OfferDescription;
                string txt = WebUtility.HtmlDecode(desc);

                txt = txt.Replace("<br />", string.Empty);

                objClsOfferMaster.OfferDescription = txt;
                objClsOfferMaster.OfferCode = item.fpo_offer_code;

                DateTime endDate = Convert.ToDateTime(item.fpo_end_date);
                objClsOfferMaster.OfferExpirationDate = string.Format("{0:dd-MMM-yyyy}", endDate);

                lstClsOfferMaster.Add(objClsOfferMaster);

            }
            var resultDollarsOffer = (from dollarsoffer in dbEntities.tp_dollars_offer
                                      where dollarsoffer.do_isdeleted == false
                                      select dollarsoffer).ToList();
            resultDollarsOffer = resultDollarsOffer.GroupBy(x => x.do_offer_code).Select(g => g.First()).ToList();
            foreach (var item in resultDollarsOffer)
            {
                ClsOfferMaster objClsOfferMaster = new ClsOfferMaster();
                objClsOfferMaster.OfferName = item.do_name;
                objClsOfferMaster.OfferDescription = item.do_description;
                string desc = objClsOfferMaster.OfferDescription;
                string txt = WebUtility.HtmlDecode(desc);

                txt = txt.Replace("<br />", string.Empty);

                objClsOfferMaster.OfferDescription = txt;
                objClsOfferMaster.OfferCode = item.do_offer_code;
                DateTime endDate = Convert.ToDateTime(item.do_end_date);
                objClsOfferMaster.OfferExpirationDate = string.Format("{0:dd-MMM-yyyy}", endDate);

                lstClsOfferMaster.Add(objClsOfferMaster);

            }
            var resultFeastForFiveOffer = (from ffo in dbEntities.tp_feast_forfive_offer
                                           where ffo.ffo_isdeleted == false
                                           select ffo).ToList();
            resultFeastForFiveOffer = resultFeastForFiveOffer.GroupBy(x => x.ffo_offer_code).Select(g => g.First()).ToList();
            foreach (var item in resultFeastForFiveOffer)
            {
                ClsOfferMaster objClsOfferMaster = new ClsOfferMaster();
                objClsOfferMaster.OfferName = item.ffo_name;
                objClsOfferMaster.OfferDescription = item.ffo_description;
                string desc = objClsOfferMaster.OfferDescription;
                string txt = WebUtility.HtmlDecode(desc);

                txt = txt.Replace("<br />", string.Empty);

                objClsOfferMaster.OfferDescription = txt;
                objClsOfferMaster.OfferCode = item.ffo_offer_code;
                DateTime endDate = Convert.ToDateTime(item.ffo_end_date);
                objClsOfferMaster.OfferExpirationDate = string.Format("{0:dd-MMM-yyyy}", endDate);

                lstClsOfferMaster.Add(objClsOfferMaster);

            }
            var resultDailySpecialsOffer = (from dso in dbEntities.tp_dailyspecials_offer
                                            where dso.dso_isdeleted == false
                                            select dso).ToList();
            resultDailySpecialsOffer = resultDailySpecialsOffer.GroupBy(x => x.dso_Offer_code).Select(g => g.First()).ToList();
            foreach (var item in resultDailySpecialsOffer)
            {
                ClsOfferMaster objClsOfferMaster = new ClsOfferMaster();
                objClsOfferMaster.OfferName = item.dso_name;
                objClsOfferMaster.OfferDescription = item.dso_description;
                string desc = objClsOfferMaster.OfferDescription;
                string txt = WebUtility.HtmlDecode(desc);

                txt = txt.Replace("<br />", string.Empty);

                objClsOfferMaster.OfferDescription = txt;
                objClsOfferMaster.OfferCode = item.dso_Offer_code;
                DateTime endDate = Convert.ToDateTime(item.dso_end_date);
                objClsOfferMaster.OfferExpirationDate = string.Format("{0:dd-MMM-yyyy}", endDate);

                lstClsOfferMaster.Add(objClsOfferMaster);

            }


        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsOfferMaster.ListToDataTable();
    }

    //Get Offer list by offerid
    public tp_offer_master GetOfferDetailByOfferId(int offerId)
    {

        tp_offer_master objTPOfferDetail = new tp_offer_master();
        try
        {
            objTPOfferDetail = dbEntities.tp_offer_master.Where(P => P.om_id == offerId && P.om_isdeleted == false).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objTPOfferDetail;
    }

    //Check if Offer Detail already exists
    public bool isOfferDetailExist(string OfferName)
    {
        bool retValue = false;
        try
        {
            tp_offer_master result = dbEntities.tp_offer_master.Where(P => P.om_name.ToLower().Equals(OfferName, StringComparison.InvariantCultureIgnoreCase) && P.om_isdeleted == false).FirstOrDefault();

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