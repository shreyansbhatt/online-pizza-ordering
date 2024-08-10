using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClsProductProperties
/// </summary>
public class ClsProductProperties
{
    TP_DatabaseEntities dbEntities = new TP_DatabaseEntities();
    public ClsProductProperties()
    {
      
    }
    #region Properties

    private int m_propertiesId;
    private int m_productSizeId;
    private int m_productDetailId;
    private int m_pizzaBaseTypeId;
    private int m_productMakingMethodId;
    private string m_propertiesPrice;
    private string m_singleIngredientsPrice;

    public string SingleIngredientsPrice
    {
        get { return m_singleIngredientsPrice; }
        set { m_singleIngredientsPrice = value; }
    }
    private string m_doubleIngredientsPrice;

    public string DoubleIngredientsPrice
    {
        get { return m_doubleIngredientsPrice; }
        set { m_doubleIngredientsPrice = value; }
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

    public int ProductDetailId
    {
        get
        {
            return m_productDetailId;
        }

        set
        {
            m_productDetailId = value;
        }
    }

    public int PizzaBaseTypeId
    {
        get
        {
            return m_pizzaBaseTypeId;
        }

        set
        {
            m_pizzaBaseTypeId = value;
        }
    }

    public int ProductMakingMethodId
    {
        get
        {
            return m_productMakingMethodId;
        }

        set
        {
            m_productMakingMethodId = value;
        }
    }

    public string PropertiesPrice
    {
        get
        {
            return m_propertiesPrice;
        }

        set
        {
            m_propertiesPrice = value;
        }
    }

    public int PropertiesId
    {
        get
        {
            return m_propertiesId;
        }

        set
        {
            m_propertiesId = value;
        }
    }

    #endregion

    //Insert Product Properties
    public string InsertProductProperties(int productSizeId,int productDetailId,int pizzaBaseTypeId,int productMakingMethodId,string propertiesPrice,string singleIngredientsPrice,string doubleIngredientsPrice, int userId)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {

            tp_product_properties dbObjInsertProductProperties = new tp_product_properties();
            dbObjInsertProductProperties.ps_id = productSizeId;
            dbObjInsertProductProperties.pd_id = productDetailId;
            dbObjInsertProductProperties.pbt_id = pizzaBaseTypeId;
            dbObjInsertProductProperties.pmm_id = productMakingMethodId;
            dbObjInsertProductProperties.pp_price = propertiesPrice;
            dbObjInsertProductProperties.pp_single_ingredients_price = singleIngredientsPrice;
            dbObjInsertProductProperties.pp_double_ingredients_price = doubleIngredientsPrice;

            dbObjInsertProductProperties.pp_isdeleted = false;

            dbObjInsertProductProperties.createdby = userId;
            dbObjInsertProductProperties.modifiedby = userId;
            dbObjInsertProductProperties.createdon = DateTime.Now;
            dbObjInsertProductProperties.modifiedon = DateTime.Now;


            dbEntities.tp_product_properties.Add(dbObjInsertProductProperties);
            
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


    //Update ProductProperties
    public string UpdateProductProperties(int productPropertiesId, int productSizeId, int productDetailId, int pizzaBaseTypeId, int productMakingMethodId, string propertiesPrice, int userId,string singleIngredientsPrice,string doubleIngredientsPrice)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {
            tp_product_properties dbObjUpdateProductProperties = null;
            dbObjUpdateProductProperties = dbEntities.tp_product_properties.Where(P => P.pp_id == productPropertiesId).FirstOrDefault();

            dbObjUpdateProductProperties.ps_id = productSizeId;
            dbObjUpdateProductProperties.pd_id = productDetailId;
            dbObjUpdateProductProperties.pbt_id = pizzaBaseTypeId;
            dbObjUpdateProductProperties.pmm_id = productMakingMethodId;
            dbObjUpdateProductProperties.pp_price = propertiesPrice;
            dbObjUpdateProductProperties.pp_single_ingredients_price = singleIngredientsPrice;
            dbObjUpdateProductProperties.pp_double_ingredients_price = doubleIngredientsPrice;
            dbObjUpdateProductProperties.pp_isdeleted = false;

            dbObjUpdateProductProperties.modifiedby = userId;

            dbObjUpdateProductProperties.modifiedon = DateTime.Now;


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

    //Delete ProductProperties
    public string DeleteProductProperties(int productPropertiesId)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {
            tp_product_properties dbObjDeleteProductProperties = null;
            dbObjDeleteProductProperties = dbEntities.tp_product_properties.Where(P => P.pp_id == productPropertiesId).FirstOrDefault();

            dbObjDeleteProductProperties.pp_isdeleted = true;
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

    //GeProductProperties list by ProductPropertiesId
    public tp_product_properties GetProductPropertiesByProductPropertiesId(int productPropertiesId)
    {
        tp_product_properties objTPProductProperties = new tp_product_properties();

        try
        {
            objTPProductProperties = dbEntities.tp_product_properties.Where(P => P.pp_id == productPropertiesId && P.pp_isdeleted==false).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objTPProductProperties;
    }



}