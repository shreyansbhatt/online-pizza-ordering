using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClsSizeIngredientMapping
/// </summary>
public class ClsSizeIngredientMapping
{
    public ClsSizeIngredientMapping()
    {
    }
    #region Properties
    private int m_ingredientId;


    private int m_sizeId;


    private string m_ingredientSizePrice;

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

    public string IngredientSizePrice
    {
        get
        {
            return m_ingredientSizePrice;
        }

        set
        {
            m_ingredientSizePrice = value;
        }
    }

    #endregion
}