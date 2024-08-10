using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClsProductMakingMethod
/// </summary>
public class ClsProductMakingMethod
{
    TP_DatabaseEntities dbEntities = new TP_DatabaseEntities();
    public ClsProductMakingMethod()
    {

    }
    #region Properties


    private int m_productMakingMethodId;
    private string m_productMakingMethodName;

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

    public string ProductMakingMethodName
    {
        get
        {
            return m_productMakingMethodName;
        }

        set
        {
            m_productMakingMethodName = value;
        }
    }

    #endregion

    //Insert New Product Making Method
    public string InsertNewProductMakingMethod(string productMakingMethodName, int userId)
    {
        int retValue = 0;
        string retMsg = string.Empty;

        try
        {

            tp_product_making_method dbObjInsertProductMakingMethod = new tp_product_making_method();
            dbObjInsertProductMakingMethod.pmm_name = productMakingMethodName;
            dbObjInsertProductMakingMethod.pmm_isdeleted = false;

            dbObjInsertProductMakingMethod.createdby = userId;
            dbObjInsertProductMakingMethod.modifiedby = userId;
            dbObjInsertProductMakingMethod.createdon = DateTime.Now;
            dbObjInsertProductMakingMethod.modifiedon = DateTime.Now;


            dbEntities.tp_product_making_method.Add(dbObjInsertProductMakingMethod);
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

    //Update  Product Making Method
    public string UpdateProductMakingMethod(int productMakingMethodId, string productMakingMethodName, int userId)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {
            tp_product_making_method dbObjUpdateProductMakingMethod = null;
            dbObjUpdateProductMakingMethod = dbEntities.tp_product_making_method.Where(P => P.pmm_id == productMakingMethodId).FirstOrDefault();

            dbObjUpdateProductMakingMethod.pmm_name = productMakingMethodName;
            dbObjUpdateProductMakingMethod.pmm_isdeleted = false;

            dbObjUpdateProductMakingMethod.modifiedby = userId;

            dbObjUpdateProductMakingMethod.modifiedon = DateTime.Now;


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

    //Delete  Product Making Method
    public string DeleteProductMakingMethod(int productMakingMethodId)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {
            tp_product_making_method dbObjDeleteProductMakingMethod = null;
            dbObjDeleteProductMakingMethod = dbEntities.tp_product_making_method.Where(P => P.pmm_id == productMakingMethodId).FirstOrDefault();

            dbObjDeleteProductMakingMethod.pmm_isdeleted = true;
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

    //Get  Product Making Method List
    public DataTable GetProductMakingMethodList(string searchText = null)
    {
        List<tp_product_making_method> lstProductMakingMethod = new List<tp_product_making_method>();
        List<ClsProductMakingMethod> lstClsProductMakingMethod = new List<ClsProductMakingMethod>();

        try
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                lstProductMakingMethod = dbEntities.tp_product_making_method.Where(p => p.pmm_name.Contains(searchText) && p.pmm_isdeleted == false).ToList<tp_product_making_method>();

                foreach (var item in lstProductMakingMethod)
                {
                    ClsProductMakingMethod objClsProductMakingMethod = new ClsProductMakingMethod();
                    objClsProductMakingMethod.ProductMakingMethodId = item.pmm_id;
                    objClsProductMakingMethod.ProductMakingMethodName = item.pmm_name;


                    lstClsProductMakingMethod.Add(objClsProductMakingMethod);
                }
            }
            else
            {
                lstProductMakingMethod = dbEntities.tp_product_making_method.Where(p => p.pmm_isdeleted == false).ToList<tp_product_making_method>();

                foreach (var item in lstProductMakingMethod)
                {

                    ClsProductMakingMethod objClsProductMakingMethod = new ClsProductMakingMethod();
                    objClsProductMakingMethod.ProductMakingMethodId = item.pmm_id;
                    objClsProductMakingMethod.ProductMakingMethodName = item.pmm_name;


                    lstClsProductMakingMethod.Add(objClsProductMakingMethod);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductMakingMethod.ListToDataTable();
    }

    //Get  Product Making Method list by productMakingMethodId
    public tp_product_making_method GetProductMakingMethodByProductMakingMethodId(int productMakingMethodId)
    {

        tp_product_making_method objTPProductMakingMethod = new tp_product_making_method();
        try
        {
            objTPProductMakingMethod = dbEntities.tp_product_making_method.Where(P => P.pmm_id == productMakingMethodId && P.pmm_isdeleted == false).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objTPProductMakingMethod;
    }

    //Check if  Product Making Method already exists
    public bool isProductMakingMethodExist(string productMakingMethodName)
    {
        bool retValue = false;
        try
        {
            tp_product_making_method result = dbEntities.tp_product_making_method.Where(P => P.pmm_name.ToLower().Equals(productMakingMethodName, StringComparison.InvariantCultureIgnoreCase) && P.pmm_isdeleted == false).FirstOrDefault();

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