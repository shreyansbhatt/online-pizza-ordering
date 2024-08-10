using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClsDollarsOffer
/// </summary>
public class ClsDollarsOffer
{
    TP_DatabaseEntities dbEntities = new TP_DatabaseEntities();
    public ClsDollarsOffer()
    {

    }
    #region Properties

    private int m_dollarsOfferId;
    private string m_dollarsOfferName;
    private string m_dollarsOfferDescription;
    private string m_dollarsOfferCode;

    private int m_productSizeId;
    private string m_productSizeName;
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

    public int DollarsOfferId
    {
        get
        {
            return m_dollarsOfferId;
        }

        set
        {
            m_dollarsOfferId = value;
        }
    }

    public string DollarsOfferName
    {
        get
        {
            return m_dollarsOfferName;
        }

        set
        {
            m_dollarsOfferName = value;
        }
    }

    public string DollarsOfferDescription
    {
        get
        {
            return m_dollarsOfferDescription;
        }

        set
        {
            m_dollarsOfferDescription = value;
        }
    }

    public string DollarsOfferCode
    {
        get
        {
            return m_dollarsOfferCode;
        }

        set
        {
            m_dollarsOfferCode = value;
        }
    }

    public int ProductSizeId
    {
        get
        {
            return m_productSizeId;
        }

        set
        {
            m_productSizeId = value;
        }
    }

    public string ProductSizeName
    {
        get
        {
            return m_productSizeName;
        }

        set
        {
            m_productSizeName = value;
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

    #endregion
    //Insert New Dollars OfferDetail
    public string InsertDollarsOfferDetail(string dollarsOfferName, string dollarsOfferDescription, string dollarsOfferCode, int productSizeId, string offerAmount, int userId, DateTime offerStartDate, DateTime offerEndDate)
    {
        int retValue = 0;
        string retMsg = string.Empty;

        try
        {

            tp_dollars_offer dbObjInsertDollarsOfferDetail = new tp_dollars_offer();
            dbObjInsertDollarsOfferDetail.do_name = dollarsOfferName;
            dbObjInsertDollarsOfferDetail.do_description = dollarsOfferDescription;
            dbObjInsertDollarsOfferDetail.do_offer_code = dollarsOfferCode;
            dbObjInsertDollarsOfferDetail.do_ps_id = productSizeId;
            dbObjInsertDollarsOfferDetail.do_amount = offerAmount;
            dbObjInsertDollarsOfferDetail.do_start_date = offerStartDate;
            dbObjInsertDollarsOfferDetail.do_end_date = offerEndDate;

            dbObjInsertDollarsOfferDetail.do_isdeleted = false;
            dbObjInsertDollarsOfferDetail.createdby = userId;
            dbObjInsertDollarsOfferDetail.modifiedby = userId;
            dbObjInsertDollarsOfferDetail.createdon = DateTime.Now;
            dbObjInsertDollarsOfferDetail.modifiedon = DateTime.Now;




            dbEntities.tp_dollars_offer.Add(dbObjInsertDollarsOfferDetail);
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


    //Update Dollars Offer Detail

    public string UpdateDollarsOfferDetail(int dollarsOfferId, string dollarsOfferName, string dollarsOfferDescription, string dollarsOfferCode, int productSizeId, string offerAmount, int userId, DateTime offerStartDate, DateTime offerEndDate)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {
            tp_dollars_offer dbObjUpdateDollarsOfferDetail = null;
            dbObjUpdateDollarsOfferDetail = dbEntities.tp_dollars_offer.Where(P => P.do_id == dollarsOfferId).FirstOrDefault();

            dbObjUpdateDollarsOfferDetail.do_name = dollarsOfferName;
            dbObjUpdateDollarsOfferDetail.do_description = dollarsOfferDescription;
            dbObjUpdateDollarsOfferDetail.do_offer_code = dollarsOfferCode;
            dbObjUpdateDollarsOfferDetail.do_ps_id = productSizeId;
            dbObjUpdateDollarsOfferDetail.do_amount = offerAmount;
            dbObjUpdateDollarsOfferDetail.do_start_date = offerStartDate;
            dbObjUpdateDollarsOfferDetail.do_end_date = offerEndDate;

            dbObjUpdateDollarsOfferDetail.do_isdeleted = false;

            dbObjUpdateDollarsOfferDetail.modifiedby = userId;

            dbObjUpdateDollarsOfferDetail.modifiedon = DateTime.Now;


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

    //Delete Dollars Offer Detail
    public string DeleteDollarsOfferDetail(int DollarsOfferId)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {
            tp_dollars_offer dbObjDeleteDollarsOfferDetail = null;
            dbObjDeleteDollarsOfferDetail = dbEntities.tp_dollars_offer.Where(P => P.do_id == DollarsOfferId).FirstOrDefault();

            dbObjDeleteDollarsOfferDetail.do_isdeleted = true;
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

    //Check if Dollars Offer Detail already exists
    public bool isDollarsOfferDetailExist(string DollarsOfferName)
    {
        bool retValue = false;
        try
        {
            tp_dollars_offer result = dbEntities.tp_dollars_offer.Where(P => P.do_name.ToLower().Equals(DollarsOfferName, StringComparison.InvariantCultureIgnoreCase) && P.do_isdeleted == false).FirstOrDefault();

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

    //Get Dollars Offer List
    public DataTable GetDollarsOfferDetailList(string searchText = null)
    {
        List<tp_dollars_offer> lstDollarsOfferDetail = new List<tp_dollars_offer>();
        List<ClsDollarsOffer> lstClsDollarsOffer = new List<ClsDollarsOffer>();

        try
        {
            if (!string.IsNullOrEmpty(searchText))
            {

                var result = (from dollarsoffer in dbEntities.tp_dollars_offer
                              join ps in dbEntities.tp_product_sizes
                              on dollarsoffer.do_ps_id equals ps.ps_id


                              where (dollarsoffer.do_isdeleted == false && ps.ps_isdeleted == false && (dollarsoffer.do_name.Contains(searchText) || dollarsoffer.do_description.Contains(searchText)))

                              select new
                              {
                                  dollarsoffer,
                                  ps.ps_id,
                                  ps.ps_name,


                              }).ToList();
                foreach (var item in result)
                {
                    ClsDollarsOffer objClsDollarsOffer = new ClsDollarsOffer();
                    objClsDollarsOffer.DollarsOfferId = item.dollarsoffer.do_id;
                    objClsDollarsOffer.DollarsOfferName = item.dollarsoffer.do_name;
                    objClsDollarsOffer.DollarsOfferDescription = item.dollarsoffer.do_description;
                    objClsDollarsOffer.DollarsOfferCode = item.dollarsoffer.do_offer_code;

                    objClsDollarsOffer.ProductSizeId = Convert.ToInt32(item.ps_id);
                    objClsDollarsOffer.ProductSizeName = item.ps_name;
                    objClsDollarsOffer.OfferAmount = item.dollarsoffer.do_amount;

                    objClsDollarsOffer.Offerstartdatestring = item.dollarsoffer.do_start_date.Value.ToString("MM/dd/yyyy");
                    objClsDollarsOffer.Offerenddatestring = item.dollarsoffer.do_end_date.Value.ToString("MM/dd/yyyy");

                    lstClsDollarsOffer.Add(objClsDollarsOffer);
                }
            }
            else
            {
                var result = (from dollarsoffer in dbEntities.tp_dollars_offer
                              join ps in dbEntities.tp_product_sizes
                              on dollarsoffer.do_ps_id equals ps.ps_id


                              where (dollarsoffer.do_isdeleted == false && ps.ps_isdeleted == false)

                              select new
                              {
                                  dollarsoffer,
                                  ps.ps_id,
                                  ps.ps_name,


                              }).ToList();
                foreach (var item in result)
                {
                    ClsDollarsOffer objClsDollarsOffer = new ClsDollarsOffer();
                    objClsDollarsOffer.DollarsOfferId = item.dollarsoffer.do_id;
                    objClsDollarsOffer.DollarsOfferName = item.dollarsoffer.do_name;
                    objClsDollarsOffer.DollarsOfferDescription = item.dollarsoffer.do_description;
                    objClsDollarsOffer.DollarsOfferCode = item.dollarsoffer.do_offer_code;

                    objClsDollarsOffer.ProductSizeId = Convert.ToInt32(item.ps_id);
                    objClsDollarsOffer.ProductSizeName = item.ps_name;
                    objClsDollarsOffer.OfferAmount = item.dollarsoffer.do_amount;
                    objClsDollarsOffer.Offerstartdatestring = item.dollarsoffer.do_start_date.Value.ToString("MM/dd/yyyy");
                    objClsDollarsOffer.Offerenddatestring = item.dollarsoffer.do_end_date.Value.ToString("MM/dd/yyyy");

                    lstClsDollarsOffer.Add(objClsDollarsOffer);
                }

            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsDollarsOffer.ListToDataTable();
    }


    //Get Free Pizza Offer list for Edit 
    public ClsDollarsOffer GetDollarsOffer(int dollarsOfferId)
    {
        ClsDollarsOffer objClsDollarsOffer = new ClsDollarsOffer();
        try
        {

            var result = (from dollarsoffer in dbEntities.tp_dollars_offer
                          join ps in dbEntities.tp_product_sizes
                          on dollarsoffer.do_ps_id equals ps.ps_id


                          where (dollarsoffer.do_isdeleted == false && ps.ps_isdeleted == false && dollarsoffer.do_id == dollarsOfferId)

                          select new
                          {
                              dollarsoffer,
                              ps.ps_id,
                              ps.ps_name,


                          }).FirstOrDefault();

            if (result != null)
            {

                objClsDollarsOffer.DollarsOfferId = result.dollarsoffer.do_id;
                objClsDollarsOffer.DollarsOfferName = result.dollarsoffer.do_name;
                objClsDollarsOffer.DollarsOfferDescription = result.dollarsoffer.do_description;
                objClsDollarsOffer.DollarsOfferCode = result.dollarsoffer.do_offer_code;

                objClsDollarsOffer.ProductSizeId = Convert.ToInt32(result.ps_id);
                objClsDollarsOffer.ProductSizeName = result.ps_name;
                objClsDollarsOffer.OfferAmount = result.dollarsoffer.do_amount;
                objClsDollarsOffer.Offerstartdatestring = result.dollarsoffer.do_start_date.Value.ToString("MM/dd/yyyy");
                objClsDollarsOffer.Offerenddatestring = result.dollarsoffer.do_end_date.Value.ToString("MM/dd/yyyy");
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objClsDollarsOffer;
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
}