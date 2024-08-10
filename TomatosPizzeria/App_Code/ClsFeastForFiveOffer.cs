using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClsFeastForFiveOffer
/// </summary>
public class ClsFeastForFiveOffer
{
    TP_DatabaseEntities dbEntities = new TP_DatabaseEntities();
    public ClsFeastForFiveOffer()
    {
        
    }
    #region Properties

    private int m_feastForFiveOfferId;
    private string m_feastForFiveOfferName;
    private string m_feastForFiveDescription;
    private string m_feastForFiveOfferCode;

    private int m_product1Id;
    private int m_product1Quantity;
    private int m_product1SizeId;

    private string m_product1Name;
    private string m_product1SizeName;

    private int m_product2Id;
    private int m_product2Quantity;

    private string m_product2Name;

    private int m_product3Id;
    private int m_prodcut3Quantity;

    private string m_product3Name;

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


    public string FeastForFiveOfferName
    {
        get
        {
            return m_feastForFiveOfferName;
        }

        set
        {
            m_feastForFiveOfferName = value;
        }
    }

    public string FeastForFiveOfferCode
    {
        get
        {
            return m_feastForFiveOfferCode;
        }

        set
        {
            m_feastForFiveOfferCode = value;
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

    public int Product3Id
    {
        get
        {
            return m_product3Id;
        }

        set
        {
            m_product3Id = value;
        }
    }

    public int Prodcut3Quantity
    {
        get
        {
            return m_prodcut3Quantity;
        }

        set
        {
            m_prodcut3Quantity = value;
        }
    }

    public string Product3Name
    {
        get
        {
            return m_product3Name;
        }

        set
        {
            m_product3Name = value;
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

  

    public int FeastForFiveOfferId
    {
        get
        {
            return m_feastForFiveOfferId;
        }

        set
        {
            m_feastForFiveOfferId = value;
        }
    }

    public string FeastForFiveDescription
    {
        get
        {
            return m_feastForFiveDescription;
        }

        set
        {
            m_feastForFiveDescription = value;
        }
    }

    #endregion

    //Insert New FeastForFive OfferDetail
    public string InsertFeastForFiveOfferDetail(string feastForFiveOfferName, string feastForFiveOfferDescription, string feastForFiveOfferCode, int product1Id, int product1Quantity, int product1SizeId, int product2Id, int product2Quantity, int product3Id, int product3Quantity, string offerAmount, int userId, DateTime offerStartDate, DateTime offerEndDate)
    {
        int retValue = 0;
        string retMsg = string.Empty;

        try
        {

            tp_feast_forfive_offer dbObjFeastForFiveOfferDetail = new tp_feast_forfive_offer();
            dbObjFeastForFiveOfferDetail.ffo_name = feastForFiveOfferName;
            dbObjFeastForFiveOfferDetail.ffo_description = feastForFiveOfferDescription;
            dbObjFeastForFiveOfferDetail.ffo_offer_code = feastForFiveOfferCode;
            dbObjFeastForFiveOfferDetail.ffo_product1_id = product1Id;
            dbObjFeastForFiveOfferDetail.ffo_product1_quantity = product1Quantity;
            dbObjFeastForFiveOfferDetail.ffo_product1_ps_id = product1SizeId;

            dbObjFeastForFiveOfferDetail.ffo_product2_pd_id = product2Id;
            dbObjFeastForFiveOfferDetail.ffo_product2_quantity = product2Quantity;
            dbObjFeastForFiveOfferDetail.ffo_product3_pd_id = product3Id;
            dbObjFeastForFiveOfferDetail.ffo_product3_quantity = product3Quantity;
            dbObjFeastForFiveOfferDetail.ffo_amount = offerAmount;
            dbObjFeastForFiveOfferDetail.ffo_start_date = offerStartDate;
            dbObjFeastForFiveOfferDetail.ffo_end_date = offerEndDate;

            dbObjFeastForFiveOfferDetail.ffo_isdeleted = false;
            dbObjFeastForFiveOfferDetail.createdby = userId;
            dbObjFeastForFiveOfferDetail.modifiedby = userId;
            dbObjFeastForFiveOfferDetail.createdon = DateTime.Now;
            dbObjFeastForFiveOfferDetail.modifiedon = DateTime.Now;




            dbEntities.tp_feast_forfive_offer.Add(dbObjFeastForFiveOfferDetail);
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

    public string UpdateFeastForFiveOfferDetail(int feastForFiveOfferId, string feastForFiveOfferName, string feastForFiveOfferDescription, string feastForFiveOfferCode, int product1Id, int product1Quantity, int product1SizeId, int product2Id, int product2Quantity, int product3Id, int product3Quantity, string offerAmount, int userId, DateTime offerStartDate, DateTime offerEndDate)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {
            tp_feast_forfive_offer dbObjUpdateFeastForFiveOfferDetail = null;
            dbObjUpdateFeastForFiveOfferDetail = dbEntities.tp_feast_forfive_offer.Where(P => P.ffo_id == feastForFiveOfferId).FirstOrDefault();

            dbObjUpdateFeastForFiveOfferDetail.ffo_name = feastForFiveOfferName;
            dbObjUpdateFeastForFiveOfferDetail.ffo_description = feastForFiveOfferDescription;
            dbObjUpdateFeastForFiveOfferDetail.ffo_offer_code = feastForFiveOfferCode;
            dbObjUpdateFeastForFiveOfferDetail.ffo_product1_id = product1Id;
            dbObjUpdateFeastForFiveOfferDetail.ffo_product1_quantity = product1Quantity;
            dbObjUpdateFeastForFiveOfferDetail.ffo_product1_ps_id = product1SizeId;

            dbObjUpdateFeastForFiveOfferDetail.ffo_product2_pd_id = product2Id;
            dbObjUpdateFeastForFiveOfferDetail.ffo_product2_quantity = product2Quantity;
            dbObjUpdateFeastForFiveOfferDetail.ffo_product3_pd_id = product3Id;
            dbObjUpdateFeastForFiveOfferDetail.ffo_product3_quantity = product3Quantity;
            dbObjUpdateFeastForFiveOfferDetail.ffo_amount = offerAmount;
            dbObjUpdateFeastForFiveOfferDetail.ffo_start_date = offerStartDate;
            dbObjUpdateFeastForFiveOfferDetail.ffo_end_date = offerEndDate;

            dbObjUpdateFeastForFiveOfferDetail.ffo_isdeleted = false;
            dbObjUpdateFeastForFiveOfferDetail.modifiedby = userId;

            dbObjUpdateFeastForFiveOfferDetail.modifiedon = DateTime.Now;


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
    public string DeleteFeastForFiveOfferDetail(int feastForFiveOfferId)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {
            tp_feast_forfive_offer dbObjDeleteFeastForFiveOfferDetail = null;
            dbObjDeleteFeastForFiveOfferDetail = dbEntities.tp_feast_forfive_offer.Where(P => P.ffo_id == feastForFiveOfferId).FirstOrDefault();

            dbObjDeleteFeastForFiveOfferDetail.ffo_isdeleted = true;
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
    public bool isFeastForFiveOfferDetailExist(string feastForFiveOfferName)
    {
        bool retValue = false;
        try
        {
            tp_feast_forfive_offer result = dbEntities.tp_feast_forfive_offer.Where(P => P.ffo_name.ToLower().Equals(feastForFiveOfferName, StringComparison.InvariantCultureIgnoreCase) && P.ffo_isdeleted == false).FirstOrDefault();

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
    public DataTable GetFeastForFiveOfferDetailList(string searchText = null)
    {
        List<tp_feast_forfive_offer> lstFeastForFiveOfferDetail = new List<tp_feast_forfive_offer>();
        List<ClsFeastForFiveOffer> lstClsFeastForFiveOffer = new List<ClsFeastForFiveOffer>();

        try
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                
                var result = (from ffo in dbEntities.tp_feast_forfive_offer
                              join pd1 in dbEntities.tp_product_details
                              on ffo.ffo_product1_id equals pd1.pd_id
                              join ps1 in dbEntities.tp_product_sizes
                              on ffo.ffo_product1_ps_id equals ps1.ps_id into ps1id
                              from product1sizedetail in ps1id.DefaultIfEmpty()
                              join pd2 in dbEntities.tp_product_details
                              on ffo.ffo_product2_pd_id equals pd2.pd_id
                              join pd3 in dbEntities.tp_product_details
                              on ffo.ffo_product3_pd_id equals pd3.pd_id

                              where (ffo.ffo_isdeleted == false && pd1.pd_isdeleted == false 
                              && pd2.pd_isdeleted == false  && pd3.pd_isdeleted == false 
                              && (ffo.ffo_name.Contains(searchText) || ffo.ffo_description.Contains(searchText)))
                              select new
                              {
                                  ffo,
                                  pd1,
                                  Product1SizeId = (product1sizedetail == null ? 0 : product1sizedetail.ps_id),
                                  Product1SizeName = (product1sizedetail == null ? String.Empty : product1sizedetail.ps_name),
                                  pd2,
                                  pd3,

                              }).ToList();
                foreach (var item in result)
                {
                    ClsFeastForFiveOffer objClsFeastForFiveOffer = new ClsFeastForFiveOffer();
                    objClsFeastForFiveOffer.FeastForFiveOfferId = item.ffo.ffo_id;
                    objClsFeastForFiveOffer.FeastForFiveOfferName = item.ffo.ffo_name;
                    objClsFeastForFiveOffer.FeastForFiveDescription = item.ffo.ffo_description;
                    objClsFeastForFiveOffer.FeastForFiveOfferCode = item.ffo.ffo_offer_code;
                    objClsFeastForFiveOffer.Product1Id = Convert.ToInt32(item.pd1.pd_id);
                    objClsFeastForFiveOffer.Product1Name = item.pd1.pd_name;
                    objClsFeastForFiveOffer.Product1SizeId = Convert.ToInt32(item.Product1SizeId);
                    objClsFeastForFiveOffer.Product1SizeName = item.Product1SizeName;
                    objClsFeastForFiveOffer.Product1Quantity = Convert.ToInt32(item.ffo.ffo_product1_quantity);
                    objClsFeastForFiveOffer.Product2Id = Convert.ToInt32(item.pd2.pd_id);
                    objClsFeastForFiveOffer.Product2Name = item.pd2.pd_name;
                    objClsFeastForFiveOffer.Product2Quantity = Convert.ToInt32(item.ffo.ffo_product2_quantity);
                    objClsFeastForFiveOffer.Product3Id = Convert.ToInt32(item.pd3.pd_id);
                    objClsFeastForFiveOffer.Product3Name = item.pd3.pd_name;
                    objClsFeastForFiveOffer.Prodcut3Quantity= Convert.ToInt32(item.ffo.ffo_product3_quantity);
                    objClsFeastForFiveOffer.OfferAmount = item.ffo.ffo_amount;
                    objClsFeastForFiveOffer.Offerstartdatestring = item.ffo.ffo_start_date.Value.ToString("MM/dd/yyyy");
                    objClsFeastForFiveOffer.Offerenddatestring = item.ffo.ffo_end_date.Value.ToString("MM/dd/yyyy");

                    lstClsFeastForFiveOffer.Add(objClsFeastForFiveOffer);
                }
            }
            else
            {
                var result = (from ffo in dbEntities.tp_feast_forfive_offer
                              join pd1 in dbEntities.tp_product_details
                              on ffo.ffo_product1_id equals pd1.pd_id
                              join ps1 in dbEntities.tp_product_sizes
                              on ffo.ffo_product1_ps_id equals ps1.ps_id into ps1id
                              from product1sizedetail in ps1id.DefaultIfEmpty()
                              join pd2 in dbEntities.tp_product_details
                              on ffo.ffo_product2_pd_id equals pd2.pd_id
                              join pd3 in dbEntities.tp_product_details
                              on ffo.ffo_product3_pd_id equals pd3.pd_id

                              where (ffo.ffo_isdeleted == false && pd1.pd_isdeleted == false 
                              && pd2.pd_isdeleted == false  && pd3.pd_isdeleted == false )
                              select new
                              {
                                  ffo,
                                  pd1,
                                  Product1SizeId = (product1sizedetail == null ? 0 : product1sizedetail.ps_id),
                                  Product1SizeName = (product1sizedetail == null ? String.Empty : product1sizedetail.ps_name),
                                  pd2,
                                  pd3,

                              }).ToList();
                foreach (var item in result)
                {
                    ClsFeastForFiveOffer objClsFeastForFiveOffer = new ClsFeastForFiveOffer();
                    objClsFeastForFiveOffer.FeastForFiveOfferId = item.ffo.ffo_id;
                    objClsFeastForFiveOffer.FeastForFiveOfferName = item.ffo.ffo_name;
                    objClsFeastForFiveOffer.FeastForFiveDescription = item.ffo.ffo_description;
                    objClsFeastForFiveOffer.FeastForFiveOfferCode = item.ffo.ffo_offer_code;
                    objClsFeastForFiveOffer.Product1Id = Convert.ToInt32(item.pd1.pd_id);
                    objClsFeastForFiveOffer.Product1Name = item.pd1.pd_name;
                    objClsFeastForFiveOffer.Product1SizeId = Convert.ToInt32(item.Product1SizeId);
                    objClsFeastForFiveOffer.Product1SizeName = item.Product1SizeName;
                    objClsFeastForFiveOffer.Product1Quantity = Convert.ToInt32(item.ffo.ffo_product1_quantity);
                    objClsFeastForFiveOffer.Product2Id = Convert.ToInt32(item.pd2.pd_id);
                    objClsFeastForFiveOffer.Product2Name = item.pd2.pd_name;
                    objClsFeastForFiveOffer.Product2Quantity = Convert.ToInt32(item.ffo.ffo_product2_quantity);
                    objClsFeastForFiveOffer.Product3Id = Convert.ToInt32(item.pd3.pd_id);
                    objClsFeastForFiveOffer.Product3Name = item.pd3.pd_name;
                    objClsFeastForFiveOffer.Prodcut3Quantity = Convert.ToInt32(item.ffo.ffo_product3_quantity);
                    objClsFeastForFiveOffer.OfferAmount = item.ffo.ffo_amount;
                    objClsFeastForFiveOffer.Offerstartdatestring = item.ffo.ffo_start_date.Value.ToString("MM/dd/yyyy");
                    objClsFeastForFiveOffer.Offerenddatestring = item.ffo.ffo_end_date.Value.ToString("MM/dd/yyyy");

                    lstClsFeastForFiveOffer.Add(objClsFeastForFiveOffer);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsFeastForFiveOffer.ListToDataTable();
    }


    //Get Feast For Five Offer list for Edit 
    public ClsFeastForFiveOffer GetFeastForFiveOffer(int feastForfiveOfferId)
    {
        ClsFeastForFiveOffer objClsFeastForFiveOffer = new ClsFeastForFiveOffer();
        try
        {

            var result = (from ffo in dbEntities.tp_feast_forfive_offer
                          join pd1 in dbEntities.tp_product_details
                          on ffo.ffo_product1_id equals pd1.pd_id
                          join ps1 in dbEntities.tp_product_sizes
                          on ffo.ffo_product1_ps_id equals ps1.ps_id into ps1id
                          from product1sizedetail in ps1id.DefaultIfEmpty()
                          join pd2 in dbEntities.tp_product_details
                          on ffo.ffo_product2_pd_id equals pd2.pd_id
                          join pd3 in dbEntities.tp_product_details
                          on ffo.ffo_product3_pd_id equals pd3.pd_id

                          where (ffo.ffo_isdeleted == false && pd1.pd_isdeleted == false 
                          && pd2.pd_isdeleted == false  && pd3.pd_isdeleted == false
                          && ffo.ffo_id==feastForfiveOfferId)
                          select new
                          {
                              ffo,
                              pd1,
                              Product1SizeId = (product1sizedetail == null ? 0 : product1sizedetail.ps_id),
                              Product1SizeName = (product1sizedetail == null ? String.Empty : product1sizedetail.ps_name),
                              pd2,
                              pd3,

                          }).FirstOrDefault();

            if (result != null)
            {

                objClsFeastForFiveOffer.FeastForFiveOfferId = result.ffo.ffo_id;
                objClsFeastForFiveOffer.FeastForFiveOfferName = result.ffo.ffo_name;
                objClsFeastForFiveOffer.FeastForFiveDescription = result.ffo.ffo_description;
                objClsFeastForFiveOffer.FeastForFiveOfferCode = result.ffo.ffo_offer_code;
                objClsFeastForFiveOffer.Product1Id = Convert.ToInt32(result.pd1.pd_id);
                objClsFeastForFiveOffer.Product1Name = result.pd1.pd_name;
                objClsFeastForFiveOffer.Product1SizeId = Convert.ToInt32(result.Product1SizeId);
                objClsFeastForFiveOffer.Product1SizeName = result.Product1SizeName;
                objClsFeastForFiveOffer.Product1Quantity = Convert.ToInt32(result.ffo.ffo_product1_quantity);
                objClsFeastForFiveOffer.Product2Id = Convert.ToInt32(result.pd2.pd_id);
                objClsFeastForFiveOffer.Product2Name = result.pd2.pd_name;
                objClsFeastForFiveOffer.Product2Quantity = Convert.ToInt32(result.ffo.ffo_product2_quantity);
                objClsFeastForFiveOffer.Product3Id = Convert.ToInt32(result.pd3.pd_id);
                objClsFeastForFiveOffer.Product3Name = result.pd3.pd_name;
                objClsFeastForFiveOffer.Prodcut3Quantity = Convert.ToInt32(result.ffo.ffo_product3_quantity);
                objClsFeastForFiveOffer.OfferAmount = result.ffo.ffo_amount;
                objClsFeastForFiveOffer.Offerstartdatestring = result.ffo.ffo_start_date.Value.ToString("MM/dd/yyyy");
                objClsFeastForFiveOffer.Offerenddatestring = result.ffo.ffo_end_date.Value.ToString("MM/dd/yyyy");




            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objClsFeastForFiveOffer;
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
}