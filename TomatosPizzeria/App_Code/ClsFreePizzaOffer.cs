using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClsFreePizzaOffer
/// </summary>
public class ClsFreePizzaOffer
{
    TP_DatabaseEntities dbEntities = new TP_DatabaseEntities();
    public ClsFreePizzaOffer()
    {
    }
    #region Properties

    private int m_freePizzaOfferId;
    private string m_freePizzaOfferName;
    private string m_freePizzaOfferDescription;
    private string m_freePizzaOfferCode;

    private int m_freeProductId;
    private int m_freeProductSizeId;
    private int m_validateProductId;
    private int m_validateIngredientId;
    private int m_validateProductSizeId;

    private string m_freeProductName;
    private string m_freeProductSizeName;
    private string m_validateProductName;
    private string m_validateProductIngredientName;
    private string m_validateProductSizeName;
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

    public string FreePizzaOfferName
    {
        get
        {
            return m_freePizzaOfferName;
        }

        set
        {
            m_freePizzaOfferName = value;
        }
    }

    public int FreeProductSizeId
    {
        get
        {
            return m_freeProductSizeId;
        }

        set
        {
            m_freeProductSizeId = value;
        }
    }

    public int ValidateProductSizeId
    {
        get
        {
            return m_validateProductSizeId;
        }

        set
        {
            m_validateProductSizeId = value;
        }
    }

    public string FreeProductName
    {
        get
        {
            return m_freeProductName;
        }

        set
        {
            m_freeProductName = value;
        }
    }

    public string FreeProductSizeName
    {
        get
        {
            return m_freeProductSizeName;
        }

        set
        {
            m_freeProductSizeName = value;
        }
    }

    public string ValidateProductName
    {
        get
        {
            return m_validateProductName;
        }

        set
        {
            m_validateProductName = value;
        }
    }

    public string ValidateProductIngredientName
    {
        get
        {
            return m_validateProductIngredientName;
        }

        set
        {
            m_validateProductIngredientName = value;
        }
    }

    public string ValidateProductSizeName
    {
        get
        {
            return m_validateProductSizeName;
        }

        set
        {
            m_validateProductSizeName = value;
        }
    }

    public string FreePizzaOfferCode
    {
        get
        {
            return m_freePizzaOfferCode;
        }

        set
        {
            m_freePizzaOfferCode = value;
        }
    }

    public int FreePizzaOfferId
    {
        get
        {
            return m_freePizzaOfferId;
        }

        set
        {
            m_freePizzaOfferId = value;
        }
    }

    public int FreeProductId
    {
        get
        {
            return m_freeProductId;
        }

        set
        {
            m_freeProductId = value;
        }
    }

    public int ValidateProductId
    {
        get
        {
            return m_validateProductId;
        }

        set
        {
            m_validateProductId = value;
        }
    }

    public int ValidateIngredientId
    {
        get
        {
            return m_validateIngredientId;
        }

        set
        {
            m_validateIngredientId = value;
        }
    }

    public string FreePizzaOfferDescription
    {
        get
        {
            return m_freePizzaOfferDescription;
        }

        set
        {
            m_freePizzaOfferDescription = value;
        }
    }




    #endregion

    //Insert New Free Pizza OfferDetail
    public string InsertFreePizzaOfferDetail(string freePizzaOfferName, string freePizzaOfferDescription, string freePizzaOfferCode, int freeProudctId, int freeProductSizeId, int validateProductId, int validateIngredientId, int validateProductSizeId, int userId, DateTime offerStartDate, DateTime offerEndDate)
    {
        int retValue = 0;
        string retMsg = string.Empty;

        try
        {

            tp_free_pizza_offer dbObjInsertFreePizzaOfferDetail = new tp_free_pizza_offer();
            dbObjInsertFreePizzaOfferDetail.fpo_name = freePizzaOfferName;
            dbObjInsertFreePizzaOfferDetail.fpo_description = freePizzaOfferDescription;
            dbObjInsertFreePizzaOfferDetail.fpo_offer_code = freePizzaOfferCode;
            dbObjInsertFreePizzaOfferDetail.fpo_free_product = freeProudctId;
            dbObjInsertFreePizzaOfferDetail.fpo_free_ps_id = freeProductSizeId;
            dbObjInsertFreePizzaOfferDetail.fpo_validate_product = validateProductId;
            dbObjInsertFreePizzaOfferDetail.fpo_validate_ingredients = validateIngredientId;
            dbObjInsertFreePizzaOfferDetail.fpo_validate_ps_id = validateProductSizeId;
            dbObjInsertFreePizzaOfferDetail.fpo_start_date = offerStartDate;
            dbObjInsertFreePizzaOfferDetail.fpo_end_date = offerEndDate;
            dbObjInsertFreePizzaOfferDetail.fpo_isdeleted = false;
            dbObjInsertFreePizzaOfferDetail.createdby = userId;
            dbObjInsertFreePizzaOfferDetail.modifiedby = userId;
            dbObjInsertFreePizzaOfferDetail.createdon = DateTime.Now;
            dbObjInsertFreePizzaOfferDetail.modifiedon = DateTime.Now;




            dbEntities.tp_free_pizza_offer.Add(dbObjInsertFreePizzaOfferDetail);
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


    //Update Free Pizza Offer Detail

    public string UpdateFreePizzaOfferDetail(int freePizzaOfferId, string freePizzaOfferName, string freePizzaOfferDescription, string freePizzaOfferCode, int freeProudctId, int freeProductSizeId, int validateProductId, int validateIngredientId, int validateProductSizeId, int userId, DateTime offerStartDate, DateTime offerEndDate)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {
            tp_free_pizza_offer dbObjUpdateFreePizzaOfferDetail = null;
            dbObjUpdateFreePizzaOfferDetail = dbEntities.tp_free_pizza_offer.Where(P => P.fpo_id == freePizzaOfferId).FirstOrDefault();

            dbObjUpdateFreePizzaOfferDetail.fpo_name = freePizzaOfferName;
            dbObjUpdateFreePizzaOfferDetail.fpo_description = freePizzaOfferDescription;
            dbObjUpdateFreePizzaOfferDetail.fpo_offer_code = freePizzaOfferCode;
            dbObjUpdateFreePizzaOfferDetail.fpo_free_product = freeProudctId;
            dbObjUpdateFreePizzaOfferDetail.fpo_free_ps_id = freeProductSizeId;
            dbObjUpdateFreePizzaOfferDetail.fpo_validate_product = validateProductId;
            dbObjUpdateFreePizzaOfferDetail.fpo_validate_ingredients = validateIngredientId;
            dbObjUpdateFreePizzaOfferDetail.fpo_validate_ps_id = validateProductSizeId;
            dbObjUpdateFreePizzaOfferDetail.fpo_start_date = offerStartDate;
            dbObjUpdateFreePizzaOfferDetail.fpo_end_date = offerEndDate;
            dbObjUpdateFreePizzaOfferDetail.fpo_isdeleted = false;

            dbObjUpdateFreePizzaOfferDetail.modifiedby = userId;

            dbObjUpdateFreePizzaOfferDetail.modifiedon = DateTime.Now;


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

    //Delete Free Pizza Offer Detail
    public string DeleteFreePizzaOfferDetail(int freePizzaOfferId)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {
            tp_free_pizza_offer dbObjDeleteFreePizzaOfferDetail = null;
            dbObjDeleteFreePizzaOfferDetail = dbEntities.tp_free_pizza_offer.Where(P => P.fpo_id == freePizzaOfferId).FirstOrDefault();

            dbObjDeleteFreePizzaOfferDetail.fpo_isdeleted = true;
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

    //Check if Free Pizza Offer Detail already exists
    public bool isFreePizzaOfferDetailExist(string freePizzaOfferName)
    {
        bool retValue = false;
        try
        {
            tp_free_pizza_offer result = dbEntities.tp_free_pizza_offer.Where(P => P.fpo_name.ToLower().Equals(freePizzaOfferName, StringComparison.InvariantCultureIgnoreCase) && P.fpo_isdeleted == false).FirstOrDefault();

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


    //Get Free Pizza Offer List
    public DataTable GetFreePizzaOfferDetailList(string searchText = null)
    {
        List<tp_free_pizza_offer> lstFreePizzaOfferDetail = new List<tp_free_pizza_offer>();
        List<ClsFreePizzaOffer> lstClsFreePizzaOffer = new List<ClsFreePizzaOffer>();

        try
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                var result = (from fpo in dbEntities.tp_free_pizza_offer
                              join freepd in dbEntities.tp_product_details
                              on fpo.fpo_free_product equals freepd.pd_id
                              join freeps in dbEntities.tp_product_sizes
                              on fpo.fpo_free_ps_id equals freeps.ps_id
                              join validatepd in dbEntities.tp_product_details
                              on fpo.fpo_validate_product equals validatepd.pd_id
                              join validateps in dbEntities.tp_product_sizes
                              on fpo.fpo_validate_ps_id equals validateps.ps_id
                              join validateid in dbEntities.tp_ingredient_details
                              on fpo.fpo_validate_ingredients equals validateid.id_id into validateid
                              from ingredientdetails in validateid.DefaultIfEmpty()

                              where (fpo.fpo_isdeleted == false && freepd.pd_isdeleted == false && freeps.ps_isdeleted == false
                              && validatepd.pd_isdeleted == false  && validateps.ps_isdeleted == false && (fpo.fpo_name.Contains(searchText) || fpo.fpo_description.Contains(searchText)))
                              select new
                              {
                                  fpo,
                                  freepd,
                                  freeps,
                                  validatepd,
                                  validateps,
                                  validateIngredientId = (ingredientdetails == null ? 0 : ingredientdetails.id_id),
                                  validateIngredientName = (ingredientdetails == null ? String.Empty : ingredientdetails.id_name),


                              }).ToList();
                foreach (var item in result)
                {
                    ClsFreePizzaOffer objClsFreePizzaOffer = new ClsFreePizzaOffer();
                    objClsFreePizzaOffer.FreePizzaOfferId = item.fpo.fpo_id;
                    objClsFreePizzaOffer.FreePizzaOfferName = item.fpo.fpo_name;
                    objClsFreePizzaOffer.FreePizzaOfferDescription = item.fpo.fpo_description;
                    objClsFreePizzaOffer.FreePizzaOfferCode = item.fpo.fpo_offer_code;
                    objClsFreePizzaOffer.FreeProductId = Convert.ToInt32(item.freepd.pd_id);
                    objClsFreePizzaOffer.FreeProductName = item.freepd.pd_name;
                    objClsFreePizzaOffer.FreeProductSizeId = Convert.ToInt32(item.freeps.ps_id);
                    objClsFreePizzaOffer.FreeProductSizeName = item.freeps.ps_name;
                    objClsFreePizzaOffer.ValidateProductId = Convert.ToInt32(item.validatepd.pd_id);
                    objClsFreePizzaOffer.ValidateProductName = item.validatepd.pd_name;
                    objClsFreePizzaOffer.ValidateProductSizeId = item.validateps.ps_id;
                    objClsFreePizzaOffer.ValidateProductSizeName = item.validateps.ps_name;
                    objClsFreePizzaOffer.ValidateIngredientId = Convert.ToInt32(item.validateIngredientId);
                    objClsFreePizzaOffer.ValidateProductIngredientName = item.validateIngredientName;
                    objClsFreePizzaOffer.Offerstartdatestring = item.fpo.fpo_start_date.Value.ToString("MM/dd/yyyy");
                    objClsFreePizzaOffer.Offerenddatestring = item.fpo.fpo_end_date.Value.ToString("MM/dd/yyyy");

                    lstClsFreePizzaOffer.Add(objClsFreePizzaOffer);
                }
            }
            else
            {
                var result = (from fpo in dbEntities.tp_free_pizza_offer
                              join freepd in dbEntities.tp_product_details
                              on fpo.fpo_free_product equals freepd.pd_id
                              join freeps in dbEntities.tp_product_sizes
                              on fpo.fpo_free_ps_id equals freeps.ps_id
                              join validatepd in dbEntities.tp_product_details
                              on fpo.fpo_validate_product equals validatepd.pd_id
                              join validateps in dbEntities.tp_product_sizes
                              on fpo.fpo_validate_ps_id equals validateps.ps_id
                              join validateid in dbEntities.tp_ingredient_details
                              on fpo.fpo_validate_ingredients equals validateid.id_id into validateid
                              from ingredientdetails in validateid.DefaultIfEmpty()

                              where (fpo.fpo_isdeleted == false && freepd.pd_isdeleted == false  && freeps.ps_isdeleted == false
                              && validatepd.pd_isdeleted == false  && validateps.ps_isdeleted == false)
                              select new
                              {
                                  fpo,
                                  freepd,
                                  freeps,
                                  validatepd,
                                  validateps,
                                  validateIngredientId = (ingredientdetails == null ? 0 : ingredientdetails.id_id),
                                  validateIngredientName = (ingredientdetails == null ? String.Empty : ingredientdetails.id_name),


                              }).ToList();
                foreach (var item in result)
                {
                    ClsFreePizzaOffer objClsFreePizzaOffer = new ClsFreePizzaOffer();
                    objClsFreePizzaOffer.FreePizzaOfferId = item.fpo.fpo_id;
                    objClsFreePizzaOffer.FreePizzaOfferName = item.fpo.fpo_name;
                    objClsFreePizzaOffer.FreePizzaOfferDescription = item.fpo.fpo_description;
                    objClsFreePizzaOffer.FreePizzaOfferCode = item.fpo.fpo_offer_code;
                    objClsFreePizzaOffer.FreeProductId = Convert.ToInt32(item.freepd.pd_id);
                    objClsFreePizzaOffer.FreeProductName = item.freepd.pd_name;
                    objClsFreePizzaOffer.FreeProductSizeId = Convert.ToInt32(item.freeps.ps_id);
                    objClsFreePizzaOffer.FreeProductSizeName = item.freeps.ps_name;
                    objClsFreePizzaOffer.ValidateProductId = Convert.ToInt32(item.validatepd.pd_id);
                    objClsFreePizzaOffer.ValidateProductName = item.validatepd.pd_name;
                    objClsFreePizzaOffer.ValidateProductSizeId = item.validateps.ps_id;
                    objClsFreePizzaOffer.ValidateProductSizeName = item.validateps.ps_name;
                    objClsFreePizzaOffer.ValidateIngredientId = Convert.ToInt32(item.validateIngredientId);
                    objClsFreePizzaOffer.ValidateProductIngredientName = item.validateIngredientName;
                    objClsFreePizzaOffer.Offerstartdatestring = item.fpo.fpo_start_date.Value.ToString("MM/dd/yyyy");
                    objClsFreePizzaOffer.Offerenddatestring = item.fpo.fpo_end_date.Value.ToString("MM/dd/yyyy");

                    lstClsFreePizzaOffer.Add(objClsFreePizzaOffer);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsFreePizzaOffer.ListToDataTable();
    }


    //Get Free Pizza Offer list for Edit 
    public ClsFreePizzaOffer GetFreePizzaOffer(int freePizzaOfferId)
    {
        ClsFreePizzaOffer objClsFreePizzaOffer = new ClsFreePizzaOffer();
        try
        {

            var result = (from fpo in dbEntities.tp_free_pizza_offer
                          join freepd in dbEntities.tp_product_details
                          on fpo.fpo_free_product equals freepd.pd_id
                          join freeps in dbEntities.tp_product_sizes
                          on fpo.fpo_free_ps_id equals freeps.ps_id
                          join validatepd in dbEntities.tp_product_details
                          on fpo.fpo_validate_product equals validatepd.pd_id
                          join validateps in dbEntities.tp_product_sizes
                          on fpo.fpo_validate_ps_id equals validateps.ps_id
                          join validateid in dbEntities.tp_ingredient_details
                          on fpo.fpo_validate_ingredients equals validateid.id_id into validateid
                          from ingredientdetails in validateid.DefaultIfEmpty()

                          where (fpo.fpo_isdeleted == false && freepd.pd_isdeleted == false  && freeps.ps_isdeleted == false
                          && validatepd.pd_isdeleted == false  && validateps.ps_isdeleted == false
                          && fpo.fpo_id == freePizzaOfferId)
                          select new
                          {
                              fpo,
                              freepd,
                              freeps,
                              validatepd,
                              validateps,
                              validateIngredientId = (ingredientdetails == null ? 0 : ingredientdetails.id_id),
                              validateIngredientName = (ingredientdetails == null ? String.Empty : ingredientdetails.id_name),


                          }).FirstOrDefault();

            if (result != null)
            {

                objClsFreePizzaOffer.FreePizzaOfferId = result.fpo.fpo_id;
                objClsFreePizzaOffer.FreePizzaOfferName = result.fpo.fpo_name;
                objClsFreePizzaOffer.FreePizzaOfferDescription = result.fpo.fpo_description;
                objClsFreePizzaOffer.FreePizzaOfferCode = result.fpo.fpo_offer_code;
                objClsFreePizzaOffer.FreeProductId = Convert.ToInt32(result.freepd.pd_id);
                objClsFreePizzaOffer.FreeProductName = result.freepd.pd_name;
                objClsFreePizzaOffer.FreeProductSizeId = Convert.ToInt32(result.freeps.ps_id);
                objClsFreePizzaOffer.FreeProductSizeName = result.freeps.ps_name;
                objClsFreePizzaOffer.ValidateProductId = Convert.ToInt32(result.validatepd.pd_id);
                objClsFreePizzaOffer.ValidateProductName = result.validatepd.pd_name;
                objClsFreePizzaOffer.ValidateProductSizeId = result.validateps.ps_id;
                objClsFreePizzaOffer.ValidateProductSizeName = result.validateps.ps_name;
                objClsFreePizzaOffer.ValidateIngredientId = Convert.ToInt32(result.validateIngredientId);
                objClsFreePizzaOffer.ValidateProductIngredientName = result.validateIngredientName;
                objClsFreePizzaOffer.Offerstartdatestring = result.fpo.fpo_start_date.Value.ToString("MM/dd/yyyy");
                objClsFreePizzaOffer.Offerenddatestring = result.fpo.fpo_end_date.Value.ToString("MM/dd/yyyy");


            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objClsFreePizzaOffer;
    }




    //Get Free Pizza Offer list by FreePizzaofferid
    public tp_free_pizza_offer GetFreePizzaOfferDetailByFreePizzaOfferId(int freePizzaOfferId)
    {

        tp_free_pizza_offer objTPFreePizzaOfferDetail = new tp_free_pizza_offer();
        try
        { 
        objTPFreePizzaOfferDetail = dbEntities.tp_free_pizza_offer.Where(P => P.fpo_id == freePizzaOfferId && P.fpo_isdeleted == false).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
            return objTPFreePizzaOfferDetail;
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

    public DataTable GetSizeByProductId(int productid)
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        DataTable dt = new DataTable();

        try
        {
            var result = (from a in dbEntities.tp_product_properties
                          join b in dbEntities.tp_product_details
                          on a.pd_id equals b.pd_id
                          join c in dbEntities.tp_product_sizes
                          on a.ps_id equals c.ps_id
                          where a.pd_id == productid && b.pd_isdeleted == false && a.pp_isdeleted == false && c.ps_isdeleted == false
                          select new
                          {
                              a.pp_id,
                              a.ps_id,
                              a.pd_id,
                              c.ps_name,
                              a.pp_price
                          }).ToList();

            result = result.GroupBy(x => x.ps_id).Select(g => g.First()).ToList();
            if (result != null)
            {
                foreach (var item in result)
                {
                    ClsProductDetail objClsProductDetail = new ClsProductDetail();
                    objClsProductDetail.ProductdetailId = item.pd_id.Value;
                    objClsProductDetail.PropertiesId = item.pp_id;
                    objClsProductDetail.SizeId = item.ps_id.Value;
                    objClsProductDetail.SizeName = item.ps_name;
                    objClsProductDetail.Price = Convert.ToDecimal(item.pp_price);
                    lstClsProductDetail.Add(objClsProductDetail);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductDetail.ListToDataTable();
    }

    public List<tp_ingredient_details> GetAllIngredient()
    {
        List<tp_ingredient_details> lsttp_ingredient_details = new List<tp_ingredient_details>();
        try
        {
            lsttp_ingredient_details = dbEntities.tp_ingredient_details.Where(x => x.id_isdeleted == false).ToList();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lsttp_ingredient_details;
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