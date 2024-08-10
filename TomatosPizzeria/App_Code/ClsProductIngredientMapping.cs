using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClsProductIngredientMapping
/// </summary>
public class ClsProductIngredientMapping
{
    public ClsProductIngredientMapping()
    {
      
    }
    #region Properties
    private int m_ingredientId;


    private int m_productCategoryId;


    private string m_ingredientPrice;

    private string m_SingleIngredientPrice;

    public string SingleIngredientPrice
    {
        get { return m_SingleIngredientPrice; }
        set { m_SingleIngredientPrice = value; }
    }
    private string m_DoubleIngredientPrice;

    public string DoubleIngredientPrice
    {
        get { return m_DoubleIngredientPrice; }
        set { m_DoubleIngredientPrice = value; }
    }

    private bool m_IsSingleIngredient;

    public bool IsSingleIngredient
    {
        get { return m_IsSingleIngredient; }
        set { m_IsSingleIngredient = value; }
    }

    private int m_productId;

    public int ProductId
    {
        get { return m_productId; }
        set { m_productId = value; }
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