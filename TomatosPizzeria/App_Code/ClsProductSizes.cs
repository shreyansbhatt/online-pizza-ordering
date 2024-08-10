using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClsProductSizes
/// </summary>
public class ClsProductSizes
{
    TP_DatabaseEntities dbEntities = new TP_DatabaseEntities();
    public ClsProductSizes()
    {

    }

    #region Properties

    private int m_sizeId;
    private string m_productSizeName;
    private string m_description;


    //For mapping

    private int m_ingredientId;
    private string m_ingredientName;
    private string m_ingredientPrice;

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

    public int SizeId
    {
        get
        {
            return m_sizeId;
        }

        set
        {
            m_sizeId = value;
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

    public string IngredientPrice
    {
        get
        {
            return m_ingredientPrice;
        }

        set
        {
            m_ingredientPrice = value;
        }
    }

    #endregion

    //Insert New Size of Product
    public string InsertNewProductSize(string productSizeName, string description, List<ClsSizeIngredientMapping> lstSizeIngredientMapping, int userId)
    {
        int retValue = 0;
        int sizeId = 0;
        string retMsg = string.Empty;

        try
        {
            // if (isUserExist(userName))
            //return -1;
            tp_product_sizes dbObjInsertProductSize = new tp_product_sizes();
            dbObjInsertProductSize.ps_name = productSizeName;
            dbObjInsertProductSize.ps_description = description;
            dbObjInsertProductSize.ps_isdeleted = false;

            dbObjInsertProductSize.createdby = userId;
            dbObjInsertProductSize.modifiedby = userId;
            dbObjInsertProductSize.createdon = DateTime.Now;
            dbObjInsertProductSize.modifiedon = DateTime.Now;


            dbEntities.tp_product_sizes.Add(dbObjInsertProductSize);
            retValue = dbEntities.SaveChanges();

            if (retValue > 0)
            {
                retMsg = "SUCCESS";

                sizeId = dbObjInsertProductSize.ps_id;

                foreach (var item in lstSizeIngredientMapping)
                {
                    tp_ingredients_product_size_mapping objTPIngredientSizeInformation = new tp_ingredients_product_size_mapping();
                    objTPIngredientSizeInformation.ipsm_ps_id = sizeId;
                    objTPIngredientSizeInformation.ipsm_id_id = item.IngredientId;
                    objTPIngredientSizeInformation.ipsm_price = item.IngredientSizePrice;
                    objTPIngredientSizeInformation.ipsm_isdeleted = false;
                    objTPIngredientSizeInformation.createdby = userId;
                    objTPIngredientSizeInformation.modifiedby = userId;
                    objTPIngredientSizeInformation.createdon = DateTime.Now;
                    objTPIngredientSizeInformation.modifiedon = DateTime.Now;


                    dbEntities.tp_ingredients_product_size_mapping.Add(objTPIngredientSizeInformation);
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


    //Update SIze of Product

    public string UpdateProductSize(int sizeId, string productSizeName, string description, List<ClsSizeIngredientMapping> lstSizeIngredientMappingAll, List<ClsSizeIngredientMapping> lstSizeIngredientMapping, int userId)
    {
        int retValue = 0;
        int productSizeId = 0;
        string retMsg = "FAIL";

        try
        {
            tp_product_sizes dbObjUpdateProductSize = null;
            dbObjUpdateProductSize = dbEntities.tp_product_sizes.Where(P => P.ps_id == sizeId).FirstOrDefault();

            dbObjUpdateProductSize.ps_name = productSizeName;
            dbObjUpdateProductSize.ps_description = description;
            dbObjUpdateProductSize.ps_isdeleted = false;

            dbObjUpdateProductSize.modifiedby = userId;

            dbObjUpdateProductSize.modifiedon = DateTime.Now;


            retValue = dbEntities.SaveChanges();
            retMsg = "SUCCESS";

            productSizeId = dbObjUpdateProductSize.ps_id;

            foreach (var item in lstSizeIngredientMappingAll)
            {
                tp_ingredients_product_size_mapping objTPIngredientSizeInformation = new tp_ingredients_product_size_mapping();
                objTPIngredientSizeInformation = dbEntities.tp_ingredients_product_size_mapping.Where(x => x.ipsm_ps_id == sizeId && x.ipsm_id_id == item.IngredientId).FirstOrDefault();
                if (objTPIngredientSizeInformation != null)
                {
                    objTPIngredientSizeInformation.ipsm_isdeleted = true;
                    retValue = dbEntities.SaveChanges();
                }
            }

            foreach (var item in lstSizeIngredientMapping)
            {
                tp_ingredients_product_size_mapping objTPIngredientSizeInformation = new tp_ingredients_product_size_mapping();
                objTPIngredientSizeInformation = dbEntities.tp_ingredients_product_size_mapping.Where(x => x.ipsm_ps_id == sizeId && x.ipsm_id_id == item.IngredientId).FirstOrDefault();
                if (objTPIngredientSizeInformation != null)
                {
                    objTPIngredientSizeInformation.ipsm_ps_id = productSizeId;
                    objTPIngredientSizeInformation.ipsm_id_id = item.IngredientId;
                    objTPIngredientSizeInformation.ipsm_price = item.IngredientSizePrice;
                    objTPIngredientSizeInformation.ipsm_isdeleted = false;
                    objTPIngredientSizeInformation.createdby = userId;
                    objTPIngredientSizeInformation.modifiedby = userId;
                    objTPIngredientSizeInformation.createdon = DateTime.Now;
                    objTPIngredientSizeInformation.modifiedon = DateTime.Now;

                    retValue = dbEntities.SaveChanges();


                }
                else
                {
                    tp_ingredients_product_size_mapping TPIngredientSizeInformation = new tp_ingredients_product_size_mapping();
                    TPIngredientSizeInformation.ipsm_ps_id = productSizeId;
                    TPIngredientSizeInformation.ipsm_id_id = item.IngredientId;
                    TPIngredientSizeInformation.ipsm_price = item.IngredientSizePrice;
                    TPIngredientSizeInformation.ipsm_isdeleted = false;
                    TPIngredientSizeInformation.createdby = userId;
                    TPIngredientSizeInformation.modifiedby = userId;
                    TPIngredientSizeInformation.createdon = DateTime.Now;
                    TPIngredientSizeInformation.modifiedon = DateTime.Now;


                    dbEntities.tp_ingredients_product_size_mapping.Add(TPIngredientSizeInformation);
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

    //Delete size of product
    public string DeleteProductSize(int sizeId)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {
            tp_product_sizes dbObjDeleteSizeInformation = null;
            dbObjDeleteSizeInformation = dbEntities.tp_product_sizes.Where(P => P.ps_id == sizeId).FirstOrDefault();

            dbObjDeleteSizeInformation.ps_isdeleted = true;
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

    //Get Size List
    public DataTable GetSizeList(string searchText = null)
    {
        List<tp_product_sizes> lstSizes = new List<tp_product_sizes>();
        List<ClsProductSizes> lstClsSizeInformation = new List<ClsProductSizes>();

        try
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                lstSizes = dbEntities.tp_product_sizes.Where(p => p.ps_name.Contains(searchText) && p.ps_isdeleted == false).ToList<tp_product_sizes>();

                foreach (var item in lstSizes)
                {
                    ClsProductSizes objClsSizeInformation = new ClsProductSizes();
                    objClsSizeInformation.SizeId = item.ps_id;
                    objClsSizeInformation.ProductSizeName = item.ps_name;
                    objClsSizeInformation.Description = item.ps_description;

                    lstClsSizeInformation.Add(objClsSizeInformation);
                }
            }
            else
            {
                lstSizes = dbEntities.tp_product_sizes.Where(p => p.ps_isdeleted == false).ToList<tp_product_sizes>();

                foreach (var item in lstSizes)
                {

                    ClsProductSizes objClsSizeInformation = new ClsProductSizes();
                    objClsSizeInformation.SizeId = item.ps_id;
                    objClsSizeInformation.ProductSizeName = item.ps_name;
                    objClsSizeInformation.Description = item.ps_description;

                    lstClsSizeInformation.Add(objClsSizeInformation);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsSizeInformation.ListToDataTable();
    }

    //Get Size list by sizeid
    public tp_product_sizes GetSizeInformationBySizeId(int sizeId)
    {

        tp_product_sizes objTPSizeInformation = new tp_product_sizes();
        try
        {
            objTPSizeInformation = dbEntities.tp_product_sizes.Where(P => P.ps_id == sizeId && P.ps_isdeleted == false).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objTPSizeInformation;
    }

    //Check if Product size already exists
    public bool isProductSizeExist(string productSizeName)
    {
        bool retValue = false;
        try
        {
            tp_product_sizes result = dbEntities.tp_product_sizes.Where(P => P.ps_name.ToLower().Equals(productSizeName, StringComparison.InvariantCultureIgnoreCase) && P.ps_isdeleted == false).FirstOrDefault();

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

    //Get Ingredient Details of Product Size

    public DataTable GetProductSizeListByIngredient(int sizeId)
    {


        List<ClsProductSizes> lstClsProductSizes = new List<ClsProductSizes>();

        try
        {
            var result = (from ipsm in dbEntities.tp_ingredients_product_size_mapping
                          join id in dbEntities.tp_ingredient_details
                          on ipsm.ipsm_id_id equals id.id_id
                          where ipsm.ipsm_ps_id == sizeId && id.id_isdeleted == false && ipsm.ipsm_isdeleted == false
                          select new
                          {
                              id.id_name,
                              ipsm.ipsm_price
                          }).ToList();

            foreach (var item in result)
            {
                ClsProductSizes objClsProductSizes = new ClsProductSizes();
                objClsProductSizes.IngredientName = item.id_name;
                objClsProductSizes.IngredientPrice = item.ipsm_price;

                lstClsProductSizes.Add(objClsProductSizes);
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductSizes.ListToDataTable();


    }

    public List<ClsProductSizes> GetAllIngredientMappingInformation(int Id)
    {
        List<ClsProductSizes> lstClsProductSizes = new List<ClsProductSizes>();
        try
        {
            var result = (from ipsm in dbEntities.tp_ingredients_product_size_mapping
                          join id in dbEntities.tp_ingredient_details
                          on ipsm.ipsm_id_id equals id.id_id
                          where ipsm.ipsm_ps_id == Id && id.id_isdeleted == false && ipsm.ipsm_isdeleted == false
                          select new
                          {
                              id.id_id,
                              id.id_name,
                              ipsm.ipsm_price
                          }).ToList();

            if (result != null)
            {
                foreach (var item in result)
                {
                    ClsProductSizes objClsProductSizes = new ClsProductSizes();
                    objClsProductSizes.IngredientId = item.id_id;
                    objClsProductSizes.IngredientName = item.id_name;
                    objClsProductSizes.IngredientPrice = item.ipsm_price;
                    lstClsProductSizes.Add(objClsProductSizes);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductSizes;
    }

    public DataTable GetAllIngredients()
    {
        List<ClsProductSizes> lstClsProductSizes = new List<ClsProductSizes>();
        List<tp_ingredient_details> lsttp_ingredient_details = new List<tp_ingredient_details>();
        try
        {
            lsttp_ingredient_details = dbEntities.tp_ingredient_details.Where(x => x.id_isdeleted == false).ToList();
            if (lsttp_ingredient_details.Count > 0)
            {
                foreach (var item in lsttp_ingredient_details)
                {
                    ClsProductSizes objClsProductSizes = new ClsProductSizes();
                    objClsProductSizes.IngredientId = item.id_id;
                    objClsProductSizes.IngredientName = item.id_name;
                    //objClsProductSizes.IngredientPrice = item.id_price;
                    lstClsProductSizes.Add(objClsProductSizes);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductSizes.ListToDataTable();
    }


    public string GetSizeNameBySizeId(int SizeId)
    {
        string SizeName = "";
        try
        {
            tp_product_sizes objtp_Product_size = new tp_product_sizes();
            objtp_Product_size = dbEntities.tp_product_sizes.Where(x => x.ps_id == SizeId && x.ps_isdeleted==false).FirstOrDefault();
            if(objtp_Product_size!=null)
            {
                SizeName = objtp_Product_size.ps_name;
            }
        }
        catch(Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return SizeName;
    }

    public tp_product_properties GetIngredientPriceBySizeId(int productId,int SizeId)
    {
        tp_product_properties objtp_Product_properties = new tp_product_properties();

        try
        {
            objtp_Product_properties = dbEntities.tp_product_properties.Where(x => x.pd_id == productId && x.ps_id == SizeId && x.pp_isdeleted == false).FirstOrDefault();            
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objtp_Product_properties;
    }

    public tp_product_details GetIngredientPriceByProductId(int productId)
    {
        tp_product_details objtp_Product_details = new tp_product_details();

        try
        {
            objtp_Product_details = dbEntities.tp_product_details.Where(x => x.pd_id == productId && x.pd_isdeleted == false).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objtp_Product_details;
    }
}