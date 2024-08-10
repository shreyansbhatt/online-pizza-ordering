using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClsIngredientDetails
/// </summary>
public class ClsIngredientDetails
{
    TP_DatabaseEntities dbEntities = new TP_DatabaseEntities();
    public ClsIngredientDetails()
    {

    }

    #region Properties

    private int m_ingredientId;
    private string m_ingredientName;
    private string m_description;
    private string m_price;
    private int m_ProductId;
    private int m_ingredientFactId;
    private int m_ProductPropertyId;

    public int ProductPropertyId
    {
        get { return m_ProductPropertyId; }
        set { m_ProductPropertyId = value; }
    }
    public int IngredientFactId
    {
        get { return m_ingredientFactId; }
        set { m_ingredientFactId = value; }
    }

    public int ProductId
    {
        get { return m_ProductId; }
        set { m_ProductId = value; }
    }
    public string IngredientName
    {
        get
        {
            return m_ingredientName;
        }

        set
        {
            m_ingredientName = value;
        }
    }

    public string Description
    {
        get
        {
            return m_description;
        }

        set
        {
            m_description = value;
        }
    }

    public string Price
    {
        get
        {
            return m_price;
        }

        set
        {
            m_price = value;
        }
    }

    public int IngredientId
    {
        get
        {
            return m_ingredientId;
        }

        set
        {
            m_ingredientId = value;
        }
    }

    #endregion

    //Insert New Ingredient Detail
    public string InsertNewIngredientDetail(string ingredientName, string description, string price, int userId, List<ClsProductIngredientFactMapping> lstProductIngredientFactMapping = null)
    {
        int retValue = 0;
        string retMsg = string.Empty;

        try
        {
            tp_ingredient_details dbObjInsertIngredientDetail = new tp_ingredient_details();
            dbObjInsertIngredientDetail.id_name = ingredientName;
            dbObjInsertIngredientDetail.id_description = description;
            dbObjInsertIngredientDetail.id_price = price;
            dbObjInsertIngredientDetail.id_isdeleted = false;

            dbObjInsertIngredientDetail.createdby = userId;
            dbObjInsertIngredientDetail.modifiedby = userId;
            dbObjInsertIngredientDetail.createdon = DateTime.Now;
            dbObjInsertIngredientDetail.modifiedon = DateTime.Now;


            dbEntities.tp_ingredient_details.Add(dbObjInsertIngredientDetail);
            retValue = dbEntities.SaveChanges();

            if (retValue > 0)
            {
                retMsg = "SUCCESS";

                foreach (var item in lstProductIngredientFactMapping)
                {
                    tp_product_ingredient_fact_mapping objTPProductIngredientFactInformation = new tp_product_ingredient_fact_mapping();
                    objTPProductIngredientFactInformation.pd_id = 0;
                    objTPProductIngredientFactInformation.pifd_id = item.IngredientFactId;
                    objTPProductIngredientFactInformation.pifm_isdeleted = false;
                    objTPProductIngredientFactInformation.createdby = userId;
                    objTPProductIngredientFactInformation.modifiedby = userId;
                    objTPProductIngredientFactInformation.createdon = DateTime.Now;
                    objTPProductIngredientFactInformation.modifiedon = DateTime.Now;


                    dbEntities.tp_product_ingredient_fact_mapping.Add(objTPProductIngredientFactInformation);
                    retValue = dbEntities.SaveChanges();

                }

            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }

        return retMsg;
    }


    //Update Ingredient Detail

    public string UpdateIngredientDetail(int ingredientId, string ingredientName, string description, string price, int userId)//, List<ClsProductIngredientFactMapping> lstProductIngredientFactMapping, List<ClsProductIngredientFactMapping> lstProductIngredientFactMappingAll = null)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {
            tp_ingredient_details dbObjUpdateIngredientDetail = null;
            dbObjUpdateIngredientDetail = dbEntities.tp_ingredient_details.Where(P => P.id_id == ingredientId).FirstOrDefault();

            dbObjUpdateIngredientDetail.id_name = ingredientName;
            dbObjUpdateIngredientDetail.id_description = description;
            dbObjUpdateIngredientDetail.id_price = price;
            dbObjUpdateIngredientDetail.id_isdeleted = false;

            dbObjUpdateIngredientDetail.modifiedby = userId;

            dbObjUpdateIngredientDetail.modifiedon = DateTime.Now;

            retValue = dbEntities.SaveChanges();

            if (retValue > 0)
            {
                retMsg = "SUCCESS";

                //foreach (var item in lstProductIngredientFactMapping)
                //{
                //    tp_product_ingredient_fact_mapping objTPProductIngredientFactInformation = new tp_product_ingredient_fact_mapping();
                //    objTPProductIngredientFactInformation = dbEntities.tp_product_ingredient_fact_mapping.Where(x => x.id_id == ingredientId && x.pifd_id == item.IngredientFactId).FirstOrDefault();
                //    if (objTPProductIngredientFactInformation != null)
                //    {
                //        objTPProductIngredientFactInformation.id_id = ingredientId;
                //        objTPProductIngredientFactInformation.pd_id = 0;
                //        objTPProductIngredientFactInformation.pifd_id = item.IngredientFactId;
                //        objTPProductIngredientFactInformation.pifm_isdeleted = false;
                //        objTPProductIngredientFactInformation.createdby = userId;
                //        objTPProductIngredientFactInformation.modifiedby = userId;
                //        objTPProductIngredientFactInformation.createdon = DateTime.Now;
                //        objTPProductIngredientFactInformation.modifiedon = DateTime.Now;

                //        retValue = dbEntities.SaveChanges();


                //    }
                //    else
                //    {
                //        tp_product_ingredient_fact_mapping TPProductIngredientFactInformation = new tp_product_ingredient_fact_mapping();
                //        TPProductIngredientFactInformation.id_id = ingredientId;
                //        TPProductIngredientFactInformation.pd_id = 0;
                //        TPProductIngredientFactInformation.pifd_id = item.IngredientFactId;
                //        TPProductIngredientFactInformation.pifm_isdeleted = false;
                //        TPProductIngredientFactInformation.createdby = userId;
                //        TPProductIngredientFactInformation.modifiedby = userId;
                //        TPProductIngredientFactInformation.createdon = DateTime.Now;
                //        TPProductIngredientFactInformation.modifiedon = DateTime.Now;


                //        dbEntities.tp_product_ingredient_fact_mapping.Add(TPProductIngredientFactInformation);
                //        retValue = dbEntities.SaveChanges();

                //    }

                //}
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }

        return retMsg;
    }

    //Delete Ingredient Detail
    public string DeleteIngredientDetail(int ingredientId)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {
            tp_ingredient_details dbObjDeleteIngredientDetail = null;
            dbObjDeleteIngredientDetail = dbEntities.tp_ingredient_details.Where(P => P.id_id == ingredientId).FirstOrDefault();

            dbObjDeleteIngredientDetail.id_isdeleted = true;
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

    //GetIngredient Detail List
    public DataTable GetIngredientList(string searchText = null)
    {
        List<tp_ingredient_details> lstIngredients = new List<tp_ingredient_details>();
        List<ClsIngredientDetails> lstClsIngredientDetail = new List<ClsIngredientDetails>();

        try
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                lstIngredients = dbEntities.tp_ingredient_details.Where(p => p.id_name.Contains(searchText) && p.id_isdeleted == false).ToList<tp_ingredient_details>();

                foreach (var item in lstIngredients)
                {
                    ClsIngredientDetails objClsIngredientDetails = new ClsIngredientDetails();
                    objClsIngredientDetails.IngredientId = item.id_id;
                    objClsIngredientDetails.IngredientName = item.id_name;
                    objClsIngredientDetails.Description = item.id_description;
                    objClsIngredientDetails.Price = item.id_price;

                    lstClsIngredientDetail.Add(objClsIngredientDetails);
                }
            }
            else
            {
                lstIngredients = dbEntities.tp_ingredient_details.Where(P => P.id_isdeleted == false).ToList<tp_ingredient_details>();

                foreach (var item in lstIngredients)
                {

                    ClsIngredientDetails objClsIngredientDetails = new ClsIngredientDetails();
                    objClsIngredientDetails.IngredientId = item.id_id;
                    objClsIngredientDetails.IngredientName = item.id_name;
                    objClsIngredientDetails.Description = item.id_description;
                    objClsIngredientDetails.Price = item.id_price;

                    lstClsIngredientDetail.Add(objClsIngredientDetails);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsIngredientDetail.ListToDataTable();
    }

    //Get Ingredient Detail list by Ingredientid
    public tp_ingredient_details GetIngredientDetailByIngredientid(int ingredientId)
    {
        tp_ingredient_details objTPIngredientDetail = new tp_ingredient_details();
        try
        {
            objTPIngredientDetail = dbEntities.tp_ingredient_details.Where(P => P.id_id == ingredientId && P.id_isdeleted == false).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objTPIngredientDetail;
    }

    //Check if Ingredient already exits
    public bool isIngredientExist(string ingredientName,string price)
    {
        bool retValue = false;
        try
        {
            tp_ingredient_details result = dbEntities.tp_ingredient_details.Where(P => P.id_name.ToLower().Equals(ingredientName, StringComparison.InvariantCultureIgnoreCase) && P.id_isdeleted == false && P.id_price==price).FirstOrDefault();

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

    //Get Ingredient Detail by size

    public List<tp_ingredient_details> GetIngredientListBySize()
    {
        List<tp_ingredient_details> lstIngredientList = new List<tp_ingredient_details>();
        try
        {

            lstIngredientList = (from id in dbEntities.tp_ingredient_details
                                 join ipsm in dbEntities.tp_ingredients_product_size_mapping
                                 on id.id_id equals ipsm.ipsm_id_id
                                 join ps in dbEntities.tp_product_sizes
                                 on ipsm.ipsm_ps_id equals ps.ps_id
                                 select id).ToList();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstIngredientList;

    }

    //Get Product ingredient by Category

    public List<tp_ingredient_details> GetProductIngredientListByCategory()
    {
        List<tp_ingredient_details> lstProductIngredientList = new List<tp_ingredient_details>();
        try
        {
            lstProductIngredientList = (from id in dbEntities.tp_ingredient_details
                                        join icm in dbEntities.tp_ingredient_category_mapping
                                        on id.id_id equals icm.id_id
                                        join pc in dbEntities.tp_product_category
                                        on icm.pc_id equals pc.pc_id
                                        select id).ToList();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstProductIngredientList;
    }

    //Get Product ingredient by ProductDetail

    public List<tp_ingredient_details> GetProductIngredientListByProductDetail()
    {
        List<tp_ingredient_details> lstIngredientList = new List<tp_ingredient_details>();
        try
        {
            lstIngredientList = (from id in dbEntities.tp_ingredient_details
                                 join ipm in dbEntities.tp_ingredient_product_mapping
                              on id.id_id equals ipm.id_id
                                 join pd in dbEntities.tp_product_details
                                 on ipm.pd_id equals pd.pd_id
                                 select id).ToList();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstIngredientList;
    }


}