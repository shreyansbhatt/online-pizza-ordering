using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClsCategoryIngredientMapping
/// </summary>
public class ClsCategoryIngredientMapping
{
    public ClsCategoryIngredientMapping()
    {
    }

    #region Properties
    private int m_ingredientId;

    
    private int m_productCategoryId;

    
    private string m_ingredientPrice;

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

    public int ProductCategoryId
    {
        get
        {
            return m_productCategoryId;
        }

        set
        {
            m_productCategoryId = value;
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



}