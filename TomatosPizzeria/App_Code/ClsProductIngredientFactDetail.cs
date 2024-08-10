using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClsProductIngredientFactDetail
/// </summary>
public class ClsProductIngredientFactDetail
{
    TP_DatabaseEntities dbEntities = new TP_DatabaseEntities();
    public ClsProductIngredientFactDetail()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region Properties

    private int m_ingredientFactId;
    private string m_ingredientFactName;

    public int IngredientFactId
    {
        get
        {
            return m_ingredientFactId;
        }

        set
        {
            m_ingredientFactId = value;
        }
    }

    public string IngredientFactName
    {
        get
        {
            return m_ingredientFactName;
        }

        set
        {
            m_ingredientFactName = value;
        }
    }

    #endregion

    //Insert New Ingredient Fact Detail
    public string InsertIngredientFactDetail(string ingredientFactName, int userId)
    {
        int retValue = 0;
        string retMsg = string.Empty;

        try
        {
            tp_product_ingredient_fact_detail dbObjInsertIngredientFactDetail = new tp_product_ingredient_fact_detail();
            dbObjInsertIngredientFactDetail.pifd_name = ingredientFactName;
            dbObjInsertIngredientFactDetail.pifd_isdeleted = false;
            dbObjInsertIngredientFactDetail.createdby = userId;
            dbObjInsertIngredientFactDetail.modifiedby = userId;
            dbObjInsertIngredientFactDetail.createdon = DateTime.Now;
            dbObjInsertIngredientFactDetail.modifiedon = DateTime.Now;

            dbEntities.tp_product_ingredient_fact_detail.Add(dbObjInsertIngredientFactDetail);
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

    public string UpdateIngredientFactDetail(int ingredientFactId, string ingredientFactName, int userId)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {
            tp_product_ingredient_fact_detail dbObjUpdateIngredientFactDetail = null;
            dbObjUpdateIngredientFactDetail = dbEntities.tp_product_ingredient_fact_detail.Where(P => P.pifd_id == ingredientFactId).FirstOrDefault();

            dbObjUpdateIngredientFactDetail.pifd_name = ingredientFactName;
            dbObjUpdateIngredientFactDetail.pifd_isdeleted = false;

            dbObjUpdateIngredientFactDetail.modifiedby = userId;

            dbObjUpdateIngredientFactDetail.modifiedon = DateTime.Now;


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
    public string DeleteIngredientFactDetail(int ingredientFactId)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {
            tp_product_ingredient_fact_detail dbObjDeleteIngredientFactDetail = null;
            dbObjDeleteIngredientFactDetail = dbEntities.tp_product_ingredient_fact_detail.Where(P => P.pifd_id == ingredientFactId).FirstOrDefault();

            dbObjDeleteIngredientFactDetail.pifd_isdeleted = true;
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
    public bool isIngredientFactDetailExist(string ingredientFactName)
    {
        bool retValue = false;
        try
        {
            tp_product_ingredient_fact_detail result = dbEntities.tp_product_ingredient_fact_detail.Where(P => P.pifd_name.ToLower().Equals(ingredientFactName, StringComparison.InvariantCultureIgnoreCase) && P.pifd_isdeleted == false).FirstOrDefault();

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
    public DataTable GetIngredientFactDetailList(string searchText = null)
    {
        List<tp_product_ingredient_fact_detail> lstIngredientFactDetail = new List<tp_product_ingredient_fact_detail>();
        List<ClsProductIngredientFactDetail> lstClsProductIngredientFactDetail = new List<ClsProductIngredientFactDetail>();

        try
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                lstIngredientFactDetail = dbEntities.tp_product_ingredient_fact_detail.Where(p => p.pifd_name.Contains(searchText) && p.pifd_isdeleted == false).ToList<tp_product_ingredient_fact_detail>();

                foreach (var item in lstIngredientFactDetail)
                {
                    ClsProductIngredientFactDetail objClsProductIngredientFactDetail = new ClsProductIngredientFactDetail();
                    objClsProductIngredientFactDetail.IngredientFactId = item.pifd_id;
                    objClsProductIngredientFactDetail.IngredientFactName = item.pifd_name;

                    lstClsProductIngredientFactDetail.Add(objClsProductIngredientFactDetail);
                }
            }
            else
            {
                lstIngredientFactDetail = dbEntities.tp_product_ingredient_fact_detail.Where(p => p.pifd_isdeleted == false).ToList<tp_product_ingredient_fact_detail>();

                foreach (var item in lstIngredientFactDetail)
                {

                    ClsProductIngredientFactDetail objClsProductIngredientFactDetail = new ClsProductIngredientFactDetail();
                    objClsProductIngredientFactDetail.IngredientFactId = item.pifd_id;
                    objClsProductIngredientFactDetail.IngredientFactName = item.pifd_name;

                    lstClsProductIngredientFactDetail.Add(objClsProductIngredientFactDetail);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductIngredientFactDetail.ListToDataTable();
    }

    //Get Free Pizza Offer list by FreePizzaofferid
    public tp_product_ingredient_fact_detail GetIngredientFactDetailByIngredientFactId(int ingredientFactId)
    {

        tp_product_ingredient_fact_detail objTPIngredientFactDetail = new tp_product_ingredient_fact_detail();
        try
        {
            objTPIngredientFactDetail = dbEntities.tp_product_ingredient_fact_detail.Where(P => P.pifd_id == ingredientFactId && P.pifd_isdeleted == false).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objTPIngredientFactDetail;
    }

}