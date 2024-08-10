using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClsPizzaBaseType
/// </summary>
public class ClsPizzaBaseType
{
    TP_DatabaseEntities dbEntities = new TP_DatabaseEntities();
    public ClsPizzaBaseType()
    {

    }

    #region Properties


    private int m_pizzaBaseTypeId;
    private string m_pizzaBaseTypeName;

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

    public string PizzaBaseTypeName
    {
        get
        {
            return m_pizzaBaseTypeName;
        }

        set
        {
            m_pizzaBaseTypeName = value;
        }
    }

    #endregion

    //Insert New Pizza Base Type
    public string InsertNewPizzaBaseType(string pizzaBaseTypeName, int userId)
    {
        int retValue = 0;
        string retMsg = string.Empty;

        try
        {

            tp_pizza_base_type dbObjInsertPizzaBaseType = new tp_pizza_base_type();
            dbObjInsertPizzaBaseType.pbt_name = pizzaBaseTypeName;
            dbObjInsertPizzaBaseType.pbt_isdeleted = false;

            dbObjInsertPizzaBaseType.createdby = userId;
            dbObjInsertPizzaBaseType.modifiedby = userId;
            dbObjInsertPizzaBaseType.createdon = DateTime.Now;
            dbObjInsertPizzaBaseType.modifiedon = DateTime.Now;


            dbEntities.tp_pizza_base_type.Add(dbObjInsertPizzaBaseType);
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

    //Update Pizza Base Type
    public string UpdatePizzaBaseType(int pizzaBaseTypeId, string pizzaBaseTypeName, int userId)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {
            tp_pizza_base_type dbObjUpdatePizzaBaseType = null;
            dbObjUpdatePizzaBaseType = dbEntities.tp_pizza_base_type.Where(P => P.pbt_id == pizzaBaseTypeId).FirstOrDefault();

            dbObjUpdatePizzaBaseType.pbt_name = pizzaBaseTypeName;
            dbObjUpdatePizzaBaseType.pbt_isdeleted = false;

            dbObjUpdatePizzaBaseType.modifiedby = userId;

            dbObjUpdatePizzaBaseType.modifiedon = DateTime.Now;

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

    //Delete Pizza Base Type
    public string DeletePizzaBaseType(int pizzaBaseTypeId)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {
            tp_pizza_base_type dbObjDeletePizzaBaseType = null;
            dbObjDeletePizzaBaseType = dbEntities.tp_pizza_base_type.Where(P => P.pbt_id == pizzaBaseTypeId).FirstOrDefault();

            dbObjDeletePizzaBaseType.pbt_isdeleted = true;
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

    //Get Pizza Base Type List
    public DataTable GetPizzaBaseTypeList(string searchText = null)
    {
        List<tp_pizza_base_type> lstPizzaBaseTypes = new List<tp_pizza_base_type>();
        List<ClsPizzaBaseType> lstClsPizzaBaseType = new List<ClsPizzaBaseType>();

        try
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                lstPizzaBaseTypes = dbEntities.tp_pizza_base_type.Where(p => p.pbt_name.Contains(searchText) && p.pbt_isdeleted == false).ToList<tp_pizza_base_type>();

                foreach (var item in lstPizzaBaseTypes)
                {
                    ClsPizzaBaseType objClsPizzaBaseType = new ClsPizzaBaseType();
                    objClsPizzaBaseType.PizzaBaseTypeId = item.pbt_id;
                    objClsPizzaBaseType.PizzaBaseTypeName = item.pbt_name;


                    lstClsPizzaBaseType.Add(objClsPizzaBaseType);
                }
            }
            else
            {
                lstPizzaBaseTypes = dbEntities.tp_pizza_base_type.Where(p => p.pbt_isdeleted == false).ToList<tp_pizza_base_type>();

                foreach (var item in lstPizzaBaseTypes)
                {

                    ClsPizzaBaseType objClsPizzaBaseType = new ClsPizzaBaseType();
                    objClsPizzaBaseType.PizzaBaseTypeId = item.pbt_id;
                    objClsPizzaBaseType.PizzaBaseTypeName = item.pbt_name;


                    lstClsPizzaBaseType.Add(objClsPizzaBaseType);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsPizzaBaseType.ListToDataTable();
    }

    //Get Pizza Base Type list by PizzaBaseTypeid
    public tp_pizza_base_type GetpizzaBaseTypeBypizzaBaseTypeId(int pizzaBaseTypeId)
    {

        tp_pizza_base_type objTPpizzaBaseType = new tp_pizza_base_type();
        try
        {
            objTPpizzaBaseType = dbEntities.tp_pizza_base_type.Where(P => P.pbt_id == pizzaBaseTypeId && P.pbt_isdeleted == false).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objTPpizzaBaseType;
    }

    //Check if Pizza Base Type already exists
    public bool isPizzaBaseTypeExist(string pizzaBaseTypeName)
    {
        bool retValue = false;
        try
        {
            tp_pizza_base_type result = dbEntities.tp_pizza_base_type.Where(P => P.pbt_name.ToLower().Equals(pizzaBaseTypeName, StringComparison.InvariantCultureIgnoreCase) && P.pbt_isdeleted == false).FirstOrDefault();

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