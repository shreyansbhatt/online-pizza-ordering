using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

/// <summary>
/// Summary description for ClsProductDetail
/// </summary>
public class ClsProductDetail
{
    TP_DatabaseEntities dbEntities = new TP_DatabaseEntities();
    public ClsProductDetail()
    {
    }

    #region Properties

    private int m_productdetailId;
    private int m_seqNo;
    private string m_productName;
    private int m_productCategoryId;
    private string m_description;
    private decimal m_basePrice;
    private string m_imageUrl;
    private string m_CategoryDescription;
    private int m_FreeIngredients;

    public int FreeIngredients
    {
        get { return m_FreeIngredients; }
        set { m_FreeIngredients = value; }
    }


    private bool m_isActive;
    private string m_active;
    private bool m_isDelivered;
    private bool m_isMarkedNew;
    private bool m_isMarkedSpeciality;
    private bool? m_canComment;
    private bool? m_CommentCompulsory;

    public bool? CommentCompulsory
    {
        get { return m_CommentCompulsory; }
        set { m_CommentCompulsory = value; }
    }

    //For mapping

    private int m_categotyId;
    private string m_categoryName;
    private int m_ingredientId;
    private string m_ingredientName;
    private string m_ingredientPrice;
    private string m_priceOfIngredients;

    private int m_propertiesId;

    private int m_sizeId;
    private int m_pizzaBaseTypeId;
    private int m_makingMethodId;
    private string m_sizeName;
    private string m_pizzaBaseType;
    private string m_makingMethodName;
    private string m_propertiesPrice;

    private int m_ingredientFactId;
    private string m_ingredientFactName;
    private string m_Comment;
    private decimal m_Price;
    private int m_Quantity;
    private int m_OrderId;
    private string m_ExtraIngredient;
    private DateTime m_orderPlaceTime;
    private string m_CartIngredientId;
    private decimal m_ExtraIngredientPrice;
    private string m_ExtraIngredientId;
    private int m_CartId;
    private decimal m_offerAmount;
    private decimal m_OneQuantityPrice;

    private string m_defaultIngredientName;
    private string m_defaultIngredientId;
    private string m_CombineSizeId;
    private string m_OrderNumber;

    private string m_SingleIngredientsPrice;

    public string SingleIngredientsPrice
    {
        get { return m_SingleIngredientsPrice; }
        set { m_SingleIngredientsPrice = value; }
    }
    private string m_DoubleIngredientsPrice;

    public string DoubleIngredientsPrice
    {
        get { return m_DoubleIngredientsPrice; }
        set { m_DoubleIngredientsPrice = value; }
    }

    private decimal m_BaseSingleIngredientPrice;

    public decimal BaseSingleIngredientPrice
    {
        get { return m_BaseSingleIngredientPrice; }
        set { m_BaseSingleIngredientPrice = value; }
    }
    private decimal m_BaseDoubleIngredientPrice;

    public decimal BaseDoubleIngredientPrice
    {
        get { return m_BaseDoubleIngredientPrice; }
        set { m_BaseDoubleIngredientPrice = value; }
    }

    private bool? m_IsSingleIngredient;

    public bool? IsSingleIngredient
    {
        get { return m_IsSingleIngredient; }
        set { m_IsSingleIngredient = value; }
    }

    public string CategoryDescription
    {
        get { return m_CategoryDescription; }
        set { m_CategoryDescription = value; }
    }
    public string OrderNumber
    {
        get { return m_OrderNumber; }
        set { m_OrderNumber = value; }
    }

    public string CombineSizeId
    {
        get { return m_CombineSizeId; }
        set { m_CombineSizeId = value; }
    }

    public decimal OneQuantityPrice
    {
        get { return m_OneQuantityPrice; }
        set { m_OneQuantityPrice = value; }
    }

    public decimal OfferAmount
    {
        get { return m_offerAmount; }
        set { m_offerAmount = value; }
    }
    public int CartId
    {
        get { return m_CartId; }
        set { m_CartId = value; }
    }

    public string ExtraIngredientId
    {
        get { return m_ExtraIngredientId; }
        set { m_ExtraIngredientId = value; }
    }

    public decimal ExtraIngredientPrice
    {
        get { return m_ExtraIngredientPrice; }
        set { m_ExtraIngredientPrice = value; }
    }

    public string CartIngredientId
    {
        get { return m_CartIngredientId; }
        set { m_CartIngredientId = value; }
    }



    public DateTime OrderPlaceTime
    {
        get
        {
            return m_orderPlaceTime;
        }

        set
        {
            m_orderPlaceTime = value;
        }
    }

    public string ExtraIngredient
    {
        get { return m_ExtraIngredient; }
        set { m_ExtraIngredient = value; }
    }

    public int OrderId
    {
        get { return m_OrderId; }
        set { m_OrderId = value; }
    }

    public int Quantity
    {
        get { return m_Quantity; }
        set { m_Quantity = value; }
    }

    public decimal Price
    {
        get { return m_Price; }
        set { m_Price = value; }
    }

    public string Comment
    {
        get { return m_Comment; }
        set { m_Comment = value; }
    }

    public int SeqNo
    {
        get
        {
            return m_seqNo;
        }

        set
        {
            m_seqNo = value;
        }
    }

    public string ProductName
    {
        get
        {
            return m_productName;
        }

        set
        {
            m_productName = value;
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

    public decimal BasePrice
    {
        get
        {
            return m_basePrice;
        }

        set
        {
            m_basePrice = value;
        }
    }

    public string ImageUrl
    {
        get
        {
            return m_imageUrl;
        }

        set
        {
            m_imageUrl = value;
        }
    }

    public bool IsDelivered
    {
        get
        {
            return m_isDelivered;
        }

        set
        {
            m_isDelivered = value;
        }
    }

    public bool IsMarkedNew
    {
        get
        {
            return m_isMarkedNew;
        }

        set
        {
            m_isMarkedNew = value;
        }
    }

    public bool IsMarkedSpeciality
    {
        get
        {
            return m_isMarkedSpeciality;
        }

        set
        {
            m_isMarkedSpeciality = value;
        }
    }

    public bool? CanComment
    {
        get
        {
            return m_canComment;
        }

        set
        {
            m_canComment = value;
        }
    }

    public int ProductdetailId
    {
        get
        {
            return m_productdetailId;
        }

        set
        {
            m_productdetailId = value;
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

    public string CategoryName
    {
        get
        {
            return m_categoryName;
        }

        set
        {
            m_categoryName = value;
        }
    }

    public int CategotyId
    {
        get
        {
            return m_categotyId;
        }

        set
        {
            m_categotyId = value;
        }
    }

    public string SizeName
    {
        get
        {
            return m_sizeName;
        }

        set
        {
            m_sizeName = value;
        }
    }

    public string PizzaBaseType
    {
        get
        {
            return m_pizzaBaseType;
        }

        set
        {
            m_pizzaBaseType = value;
        }
    }

    public string MakingMethodName
    {
        get
        {
            return m_makingMethodName;
        }

        set
        {
            m_makingMethodName = value;
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

    public int MakingMethodId
    {
        get
        {
            return m_makingMethodId;
        }

        set
        {
            m_makingMethodId = value;
        }
    }

    public bool IsActive
    {
        get
        {
            return m_isActive;
        }

        set
        {
            m_isActive = value;
        }
    }

    public string Active
    {
        get
        {
            return m_active;
        }

        set
        {
            m_active = value;
        }
    }

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

    public string PriceOfIngredients
    {
        get
        {
            return m_priceOfIngredients;
        }

        set
        {
            m_priceOfIngredients = value;
        }
    }

    public string DefaultIngredientName
    {
        get
        {
            return m_defaultIngredientName;
        }

        set
        {
            m_defaultIngredientName = value;
        }
    }

    public string DefaultIngredientId
    {
        get
        {
            return m_defaultIngredientId;
        }

        set
        {
            m_defaultIngredientId = value;
        }
    }




    #endregion

    //Insert New Product
    public string InsertNewProduct(string seqNo, string productName, int productCategoryId, string description, string basePrice, string singleIngredientsPrice, string doubleIngredientsPrice, string imageUrl,
        bool isActive, bool isDelivered, bool isMarkedNew, bool isMarkedSpeciality, bool canComment, bool CommentCompulsory, List<ClsProductIngredientMapping> lstDefaultProductIngredientMapping,
        List<ClsProductIngredientMapping> lstExtraProductIngredientMapping, List<ClsProductIngredientFactMapping> lstProductIngredientFactMapping, List<ClsProductProperties> lstProductProperties,
        int userId, int storeId, List<ClsProductIngredientMapping> lstAddSingleIngredientColumn, int numberFreeIngredients = 0)
    {
        int retValue = 0;
        int productId = 0;
        string retMsg = "FAIL";

        try
        {

            tp_product_details dbObjInsertProductDetail = new tp_product_details();
            dbObjInsertProductDetail.pd_seqno = seqNo;
            dbObjInsertProductDetail.pd_name = productName;
            dbObjInsertProductDetail.pd_pc_id = productCategoryId;
            dbObjInsertProductDetail.pd_description1 = description;
            dbObjInsertProductDetail.pd_base_price = basePrice;
            dbObjInsertProductDetail.pp_base_single_ingredients_price = singleIngredientsPrice;
            dbObjInsertProductDetail.pp_base_double_ingredients_price = doubleIngredientsPrice;

            dbObjInsertProductDetail.pd_image_url = imageUrl;

            dbObjInsertProductDetail.pd_is_active = isActive;
            dbObjInsertProductDetail.pd_is_delivered = isDelivered;
            dbObjInsertProductDetail.pd_is_marked_new = isMarkedNew;
            dbObjInsertProductDetail.pd_is_marked_speciality = isMarkedSpeciality;
            dbObjInsertProductDetail.pd_can_comment = canComment;
            dbObjInsertProductDetail.pd_isdeleted = false;
            dbObjInsertProductDetail.pd_Is_Commant_Compulsary = CommentCompulsory;
            dbObjInsertProductDetail.createdby = userId;
            dbObjInsertProductDetail.modifiedby = userId;
            dbObjInsertProductDetail.createdon = DateTime.Now;
            dbObjInsertProductDetail.modifiedon = DateTime.Now;
            dbObjInsertProductDetail.pd_sd_id = storeId;
            dbObjInsertProductDetail.no_free_ingredients = numberFreeIngredients;


            dbEntities.tp_product_details.Add(dbObjInsertProductDetail);

            retValue = dbEntities.SaveChanges();

            if (retValue == 1)
            {
                retMsg = "SUCCESS";
                productId = dbObjInsertProductDetail.pd_id;
                foreach (var item in lstProductProperties)
                {
                    tp_product_properties objTPProductPropertiesInformation = new tp_product_properties();
                    objTPProductPropertiesInformation.ps_id = item.ProductSizeId;
                    objTPProductPropertiesInformation.pd_id = productId;
                    objTPProductPropertiesInformation.pbt_id = item.PizzaBaseTypeId;
                    objTPProductPropertiesInformation.pmm_id = item.ProductMakingMethodId;
                    objTPProductPropertiesInformation.pp_price = item.PropertiesPrice;
                    objTPProductPropertiesInformation.pp_single_ingredients_price = item.SingleIngredientsPrice;
                    objTPProductPropertiesInformation.pp_double_ingredients_price = item.DoubleIngredientsPrice;

                    objTPProductPropertiesInformation.pp_isdeleted = false;
                    objTPProductPropertiesInformation.createdby = userId;
                    objTPProductPropertiesInformation.modifiedby = userId;
                    objTPProductPropertiesInformation.createdon = DateTime.Now;
                    objTPProductPropertiesInformation.modifiedon = DateTime.Now;


                    dbEntities.tp_product_properties.Add(objTPProductPropertiesInformation);
                    retValue = dbEntities.SaveChanges();


                }

                //Adding Values of IsSingle Ingredients Column
                foreach (var item in lstAddSingleIngredientColumn)
                {
                    tp_ingredient_product_mapping objTPIngredientProductInformation = new tp_ingredient_product_mapping();
                    objTPIngredientProductInformation = dbEntities.tp_ingredient_product_mapping.Where(x => x.pd_id == productId && x.id_id == item.IngredientId).FirstOrDefault();
                    if (objTPIngredientProductInformation != null)
                    {
                        objTPIngredientProductInformation.pd_id = productId;
                        objTPIngredientProductInformation.id_id = item.IngredientId;
                        objTPIngredientProductInformation.iipm_IsSingleIngredient = item.IsSingleIngredient;
                        objTPIngredientProductInformation.iipm_isDefault = true;
                        objTPIngredientProductInformation.ipm_isdeleted = false;
                        objTPIngredientProductInformation.createdby = userId;
                        objTPIngredientProductInformation.modifiedby = userId;
                        objTPIngredientProductInformation.createdon = DateTime.Now;
                        objTPIngredientProductInformation.modifiedon = DateTime.Now;

                        retValue = dbEntities.SaveChanges();



                    }
                    else
                    {
                        tp_ingredient_product_mapping TPIngredientProductInformation = new tp_ingredient_product_mapping();
                        TPIngredientProductInformation.pd_id = productId;
                        TPIngredientProductInformation.id_id = item.IngredientId;
                        TPIngredientProductInformation.iipm_IsSingleIngredient = item.IsSingleIngredient;
                        TPIngredientProductInformation.iipm_isDefault = true;
                        TPIngredientProductInformation.ipm_isdeleted = false;
                        TPIngredientProductInformation.createdby = userId;
                        TPIngredientProductInformation.modifiedby = userId;
                        TPIngredientProductInformation.createdon = DateTime.Now;
                        TPIngredientProductInformation.modifiedon = DateTime.Now;


                        dbEntities.tp_ingredient_product_mapping.Add(TPIngredientProductInformation);
                        retValue = dbEntities.SaveChanges();


                    }

                }


                //foreach (var item in lstDefaultProductIngredientMapping)
                //{
                //    tp_ingredient_product_mapping objTPIngredientProductInformation = new tp_ingredient_product_mapping();
                //    objTPIngredientProductInformation.pd_id = productId;
                //    objTPIngredientProductInformation.id_id = item.IngredientId;
                //    objTPIngredientProductInformation.iipm_isDefault = true;
                //    objTPIngredientProductInformation.ipm_isdeleted = false;
                //    objTPIngredientProductInformation.createdby = userId;
                //    objTPIngredientProductInformation.modifiedby = userId;
                //    objTPIngredientProductInformation.createdon = DateTime.Now;
                //    objTPIngredientProductInformation.modifiedon = DateTime.Now;


                //    dbEntities.tp_ingredient_product_mapping.Add(objTPIngredientProductInformation);
                //    retValue = dbEntities.SaveChanges();


                //    //tp_ingredient_details objIngredientDetail = new tp_ingredient_details();
                //    //objIngredientDetail = dbEntities.tp_ingredient_details.Where(x => x.id_id == item.IngredientId).FirstOrDefault();
                //    //objIngredientDetail.id_price = item.IngredientPrice;
                //    //dbEntities.SaveChanges();
                //}

                //foreach (var item in lstExtraProductIngredientMapping)
                //{
                //    tp_ingredient_product_mapping objTPIngredientProductInformation = new tp_ingredient_product_mapping();
                //    objTPIngredientProductInformation.pd_id = productId;
                //    objTPIngredientProductInformation.id_id = item.IngredientId;
                //    objTPIngredientProductInformation.iipm_isDefault = false;
                //    objTPIngredientProductInformation.ipm_isdeleted = false;
                //    objTPIngredientProductInformation.createdby = userId;
                //    objTPIngredientProductInformation.modifiedby = userId;
                //    objTPIngredientProductInformation.createdon = DateTime.Now;
                //    objTPIngredientProductInformation.modifiedon = DateTime.Now;


                //    dbEntities.tp_ingredient_product_mapping.Add(objTPIngredientProductInformation);
                //    retValue = dbEntities.SaveChanges();

                //}

                //foreach (var item in lstProductIngredientFactMapping)
                //{
                //    tp_product_ingredient_fact_mapping objTPProductIngredientFactInformation = new tp_product_ingredient_fact_mapping();
                //    objTPProductIngredientFactInformation.pd_id = productId;
                //    objTPProductIngredientFactInformation.pifd_id = item.IngredientFactId;
                //    objTPProductIngredientFactInformation.pifm_isdeleted = false;
                //    objTPProductIngredientFactInformation.createdby = userId;
                //    objTPProductIngredientFactInformation.modifiedby = userId;
                //    objTPProductIngredientFactInformation.createdon = DateTime.Now;
                //    objTPProductIngredientFactInformation.modifiedon = DateTime.Now;


                //    dbEntities.tp_product_ingredient_fact_mapping.Add(objTPProductIngredientFactInformation);
                //    retValue = dbEntities.SaveChanges();

                //}
            }


        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }

        return retMsg;
    }


    //Update Product Detail
    public string UpdateProduct(int productId, string seqNo, string productName, int productCategoryId, string description, string basePrice, string singleIngredientsPrice, string doubleIngredientsPrice, 
        string imageUrl, bool isActive, bool isDelivered, bool isMarkedNew, bool isMarkedSpeciality, bool canComment, bool commentCompulsary, List<ClsProductIngredientMapping> lstProductIngredientMappingAll, 
        List<ClsProductIngredientMapping> lstDefaultProductIngredientMapping, List<ClsProductIngredientMapping> lstExtraProductIngredientMapping, 
        List<ClsProductIngredientFactMapping> lstProductIngredientFactMappingAll, List<ClsProductIngredientFactMapping> lstProductIngredientFactMapping, List<ClsProductProperties> lstProductProperties, 
        int userId, int storeId, List<ClsProductIngredientMapping> lstAddSingleIngredientColumn, int numberFreeIngredients = 0)
    {
        int retValue = 0;
        int productDetailId = 0;
        string retMsg = "FAIL";

        try
        {
            tp_product_details dbObjUpdateProductDetail = null;
            dbObjUpdateProductDetail = dbEntities.tp_product_details.Where(P => P.pd_id == productId).FirstOrDefault();

            dbObjUpdateProductDetail.pd_seqno = seqNo;
            dbObjUpdateProductDetail.pd_name = productName;
            dbObjUpdateProductDetail.pd_pc_id = productCategoryId;
            dbObjUpdateProductDetail.pd_description1 = description;
            dbObjUpdateProductDetail.pd_base_price = basePrice;

            dbObjUpdateProductDetail.pp_base_single_ingredients_price = singleIngredientsPrice;
            dbObjUpdateProductDetail.pp_base_double_ingredients_price = doubleIngredientsPrice;

            dbObjUpdateProductDetail.pd_image_url = imageUrl;
            dbObjUpdateProductDetail.pd_Is_Commant_Compulsary = commentCompulsary;
            dbObjUpdateProductDetail.pd_is_active = isActive;
            dbObjUpdateProductDetail.pd_is_delivered = isDelivered;
            dbObjUpdateProductDetail.pd_is_marked_new = isMarkedNew;
            dbObjUpdateProductDetail.pd_is_marked_speciality = isMarkedSpeciality;
            dbObjUpdateProductDetail.pd_can_comment = canComment;
            dbObjUpdateProductDetail.pd_isdeleted = false;

            dbObjUpdateProductDetail.modifiedby = userId;

            dbObjUpdateProductDetail.modifiedon = DateTime.Now;
            dbObjUpdateProductDetail.pd_sd_id = storeId;
            dbObjUpdateProductDetail.no_free_ingredients = numberFreeIngredients;
            retValue = dbEntities.SaveChanges();

            //if (retValue == 1)
            //{
            retMsg = "SUCCESS";
            productDetailId = dbObjUpdateProductDetail.pd_id;
            foreach (var item in lstProductProperties)
            {
                tp_product_properties objTPProductPropertiesInformation = new tp_product_properties();
                objTPProductPropertiesInformation = dbEntities.tp_product_properties.Where(x => x.pp_id == item.PropertiesId && x.pp_isdeleted == false).FirstOrDefault();
                if (objTPProductPropertiesInformation != null)
                {
                    objTPProductPropertiesInformation.ps_id = item.ProductSizeId;
                    objTPProductPropertiesInformation.pd_id = productId;
                    objTPProductPropertiesInformation.pbt_id = item.PizzaBaseTypeId;
                    objTPProductPropertiesInformation.pmm_id = item.ProductMakingMethodId;
                    objTPProductPropertiesInformation.pp_price = item.PropertiesPrice;

                    objTPProductPropertiesInformation.pp_single_ingredients_price = item.SingleIngredientsPrice;
                    objTPProductPropertiesInformation.pp_double_ingredients_price = item.DoubleIngredientsPrice;

                    objTPProductPropertiesInformation.pp_isdeleted = false;
                    objTPProductPropertiesInformation.createdby = userId;
                    objTPProductPropertiesInformation.modifiedby = userId;
                    objTPProductPropertiesInformation.createdon = DateTime.Now;
                    objTPProductPropertiesInformation.modifiedon = DateTime.Now;


                    // dbEntities.tp_product_properties.Add(objTPProductPropertiesInformation);
                    retValue = dbEntities.SaveChanges();
                }
                else
                {
                    tp_product_properties TPProductPropertiesInformation = new tp_product_properties();
                    TPProductPropertiesInformation.ps_id = item.ProductSizeId;
                    TPProductPropertiesInformation.pd_id = productId;
                    TPProductPropertiesInformation.pbt_id = item.PizzaBaseTypeId;
                    TPProductPropertiesInformation.pmm_id = item.ProductMakingMethodId;
                    TPProductPropertiesInformation.pp_price = item.PropertiesPrice;
                    TPProductPropertiesInformation.pp_isdeleted = false;
                    TPProductPropertiesInformation.createdby = userId;
                    TPProductPropertiesInformation.modifiedby = userId;
                    TPProductPropertiesInformation.createdon = DateTime.Now;
                    TPProductPropertiesInformation.modifiedon = DateTime.Now;


                    dbEntities.tp_product_properties.Add(TPProductPropertiesInformation);
                    retValue = dbEntities.SaveChanges();
                }


            }

            foreach (var item in lstProductIngredientMappingAll)
            {

                tp_ingredient_product_mapping objTPIngredientProductInformation = new tp_ingredient_product_mapping();
                objTPIngredientProductInformation = dbEntities.tp_ingredient_product_mapping.Where(x => x.pd_id == productId && x.id_id == item.IngredientId).FirstOrDefault();
                if (objTPIngredientProductInformation != null)
                {
                    objTPIngredientProductInformation.ipm_isdeleted = true;
                    retValue = dbEntities.SaveChanges();
                }
            }

            //Adding Values of IsSingle Ingredients Column
            foreach (var item in lstAddSingleIngredientColumn)
            {
                tp_ingredient_product_mapping objTPIngredientProductInformation = new tp_ingredient_product_mapping();
                objTPIngredientProductInformation = dbEntities.tp_ingredient_product_mapping.Where(x => x.pd_id == productId && x.id_id == item.IngredientId).FirstOrDefault();
                if (objTPIngredientProductInformation != null)
                {
                    objTPIngredientProductInformation.pd_id = productId;
                    objTPIngredientProductInformation.id_id = item.IngredientId;
                    objTPIngredientProductInformation.iipm_IsSingleIngredient = item.IsSingleIngredient;
                    objTPIngredientProductInformation.iipm_isDefault = true;
                    objTPIngredientProductInformation.ipm_isdeleted = false;
                    objTPIngredientProductInformation.createdby = userId;
                    objTPIngredientProductInformation.modifiedby = userId;
                    objTPIngredientProductInformation.createdon = DateTime.Now;
                    objTPIngredientProductInformation.modifiedon = DateTime.Now;

                    retValue = dbEntities.SaveChanges();



                }
                else
                {
                    tp_ingredient_product_mapping TPIngredientProductInformation = new tp_ingredient_product_mapping();
                    TPIngredientProductInformation.pd_id = productId;
                    TPIngredientProductInformation.id_id = item.IngredientId;
                    TPIngredientProductInformation.iipm_IsSingleIngredient = item.IsSingleIngredient;
                    TPIngredientProductInformation.iipm_isDefault = true;
                    TPIngredientProductInformation.ipm_isdeleted = false;
                    TPIngredientProductInformation.createdby = userId;
                    TPIngredientProductInformation.modifiedby = userId;
                    TPIngredientProductInformation.createdon = DateTime.Now;
                    TPIngredientProductInformation.modifiedon = DateTime.Now;


                    dbEntities.tp_ingredient_product_mapping.Add(TPIngredientProductInformation);
                    retValue = dbEntities.SaveChanges();


                }

            }


            //foreach (var item in lstDefaultProductIngredientMapping)
            //{
            //    tp_ingredient_product_mapping objTPIngredientProductInformation = new tp_ingredient_product_mapping();
            //    objTPIngredientProductInformation = dbEntities.tp_ingredient_product_mapping.Where(x => x.pd_id == productId && x.id_id == item.IngredientId).FirstOrDefault();
            //    if (objTPIngredientProductInformation != null)
            //    {
            //        objTPIngredientProductInformation.pd_id = productId;
            //        objTPIngredientProductInformation.id_id = item.IngredientId;
            //        objTPIngredientProductInformation.iipm_isDefault = true;
            //        objTPIngredientProductInformation.ipm_isdeleted = false;
            //        objTPIngredientProductInformation.createdby = userId;
            //        objTPIngredientProductInformation.modifiedby = userId;
            //        objTPIngredientProductInformation.createdon = DateTime.Now;
            //        objTPIngredientProductInformation.modifiedon = DateTime.Now;

            //        retValue = dbEntities.SaveChanges();



            //    }
            //    else
            //    {
            //        tp_ingredient_product_mapping TPIngredientProductInformation = new tp_ingredient_product_mapping();
            //        TPIngredientProductInformation.pd_id = productId;
            //        TPIngredientProductInformation.id_id = item.IngredientId;
            //        TPIngredientProductInformation.iipm_isDefault = true;
            //        TPIngredientProductInformation.ipm_isdeleted = false;
            //        TPIngredientProductInformation.createdby = userId;
            //        TPIngredientProductInformation.modifiedby = userId;
            //        TPIngredientProductInformation.createdon = DateTime.Now;
            //        TPIngredientProductInformation.modifiedon = DateTime.Now;


            //        dbEntities.tp_ingredient_product_mapping.Add(TPIngredientProductInformation);
            //        retValue = dbEntities.SaveChanges();


            //    }

            //}


            //foreach (var item in lstExtraProductIngredientMapping)
            //{
            //    tp_ingredient_product_mapping objTPIngredientProductInformation = new tp_ingredient_product_mapping();
            //    objTPIngredientProductInformation = dbEntities.tp_ingredient_product_mapping.Where(x => x.pd_id == productId && x.id_id == item.IngredientId).FirstOrDefault();
            //    if (objTPIngredientProductInformation != null)
            //    {
            //        objTPIngredientProductInformation.pd_id = productId;
            //        objTPIngredientProductInformation.id_id = item.IngredientId;
            //        objTPIngredientProductInformation.iipm_isDefault = false;
            //        objTPIngredientProductInformation.ipm_isdeleted = false;
            //        objTPIngredientProductInformation.createdby = userId;
            //        objTPIngredientProductInformation.modifiedby = userId;
            //        objTPIngredientProductInformation.createdon = DateTime.Now;
            //        objTPIngredientProductInformation.modifiedon = DateTime.Now;

            //        retValue = dbEntities.SaveChanges();


            //    }
            //    else
            //    {
            //        tp_ingredient_product_mapping TPIngredientProductInformation = new tp_ingredient_product_mapping();
            //        TPIngredientProductInformation.pd_id = productId;
            //        TPIngredientProductInformation.id_id = item.IngredientId;
            //        TPIngredientProductInformation.iipm_isDefault = false;
            //        TPIngredientProductInformation.ipm_isdeleted = false;
            //        TPIngredientProductInformation.createdby = userId;
            //        TPIngredientProductInformation.modifiedby = userId;
            //        TPIngredientProductInformation.createdon = DateTime.Now;
            //        TPIngredientProductInformation.modifiedon = DateTime.Now;


            //        dbEntities.tp_ingredient_product_mapping.Add(TPIngredientProductInformation);
            //        retValue = dbEntities.SaveChanges();

            //    }

            //}


            //foreach (var item in lstProductIngredientFactMappingAll)
            //{

            //    tp_product_ingredient_fact_mapping objTPProductIngredientFactInformation = new tp_product_ingredient_fact_mapping();
            //    objTPProductIngredientFactInformation = dbEntities.tp_product_ingredient_fact_mapping.Where(x => x.pd_id == productId && x.pifd_id == item.IngredientFactId).FirstOrDefault();
            //    if (objTPProductIngredientFactInformation != null)
            //    {
            //        objTPProductIngredientFactInformation.pifm_isdeleted = true;
            //        retValue = dbEntities.SaveChanges();
            //    }
            //}


            //foreach (var item in lstProductIngredientFactMapping)
            //{
            //    tp_product_ingredient_fact_mapping objTPProductIngredientFactInformation = new tp_product_ingredient_fact_mapping();
            //    objTPProductIngredientFactInformation = dbEntities.tp_product_ingredient_fact_mapping.Where(x => x.pd_id == productId && x.pifd_id == item.IngredientFactId).FirstOrDefault();
            //    if (objTPProductIngredientFactInformation != null)
            //    {
            //        objTPProductIngredientFactInformation.pd_id = productId;
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
            //        TPProductIngredientFactInformation.pd_id = productId;
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
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }

        return retMsg;
    }

    //Delete Product
    public string DeleteProduct(int productId)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {
            tp_product_details dbObjDeleteProductDetail = null;
            dbObjDeleteProductDetail = dbEntities.tp_product_details.Where(P => P.pd_id == productId).FirstOrDefault();

            dbObjDeleteProductDetail.pd_isdeleted = true;
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


    //Check if Product already exits
    public bool isProductExist(string productName, int CategoryId)
    {
        bool retValue = false;
        try
        {
            tp_product_details result = dbEntities.tp_product_details.Where(P => P.pd_name.ToLower().Equals(productName, StringComparison.InvariantCultureIgnoreCase) && P.pd_isdeleted == false && P.pd_pc_id == CategoryId).FirstOrDefault();
            if (result == null)
            {
                retValue = false;
            }
            else
            {
                retValue = true;
            }
        }
        catch (Exception)
        {
            retValue = false;
        }
        return retValue;
    }

    //Get ProductList by productName
    public DataTable GetProductList(string searchText = null)
    {


        List<tp_product_details> lstProductList = new List<tp_product_details>();
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        try
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                var result = (from pd in dbEntities.tp_product_details
                              join pc in dbEntities.tp_product_category
                              on pd.pd_pc_id equals pc.pc_id

                              where (pd.pd_isdeleted == false && pc.pc_isdeleted == false && (pd.pd_name.Contains(searchText)))

                              select new
                              {
                                  pd,
                                  pc.pc_name

                              }).ToList();

                // result = result.GroupBy(i => new { i.pc_name }).Select(g => g.First()).OrderBy(x=>x.pd.pd_seqno).ToList();

                foreach (var item in result)
                {
                    ClsProductDetail objClsProductDetail = new ClsProductDetail();
                    objClsProductDetail.ProductdetailId = item.pd.pd_id;
                    if (item.pd.pd_seqno != "" && item.pd.pd_seqno != null)
                    {
                        objClsProductDetail.SeqNo = Convert.ToInt32(item.pd.pd_seqno);
                    }
                    objClsProductDetail.ProductName = item.pd.pd_name;
                    objClsProductDetail.Description = item.pd.pd_description1;
                    objClsProductDetail.CategoryName = item.pc_name;
                    objClsProductDetail.BasePrice = Convert.ToDecimal(item.pd.pd_base_price);
                    objClsProductDetail.ImageUrl = dbEntities.tp_config.Where(x => x.tpc_key == "MENU_ITEM_IMAGE_URL").FirstOrDefault().tpc_value.Replace("~", "") + item.pd.pd_image_url;

                    objClsProductDetail.IsActive = item.pd.pd_is_active.Value;
                    if (objClsProductDetail.IsActive == true)
                    {
                        objClsProductDetail.Active = "Yes";
                    }
                    else
                    {
                        objClsProductDetail.Active = "No";
                    }

                    lstClsProductDetail.Add(objClsProductDetail);
                }
            }
            else
            {
                var result = (from pd in dbEntities.tp_product_details
                              join pc in dbEntities.tp_product_category
                              on pd.pd_pc_id equals pc.pc_id

                              where (pd.pd_isdeleted == false && pc.pc_isdeleted == false)

                              select new
                              {
                                  pd,
                                  pc.pc_name

                              }).ToList();


                foreach (var item in result)
                {
                    ClsProductDetail objClsProductDetail = new ClsProductDetail();
                    objClsProductDetail.ProductdetailId = item.pd.pd_id;
                    if (item.pd.pd_seqno != "" && item.pd.pd_seqno != null)
                    {
                        objClsProductDetail.SeqNo = Convert.ToInt32(item.pd.pd_seqno);
                    }
                    objClsProductDetail.ProductName = item.pd.pd_name;
                    objClsProductDetail.Description = item.pd.pd_description1;
                    objClsProductDetail.CategoryName = item.pc_name;
                    objClsProductDetail.BasePrice = Convert.ToDecimal(item.pd.pd_base_price);
                    objClsProductDetail.ImageUrl = dbEntities.tp_config.Where(x => x.tpc_key == "MENU_ITEM_IMAGE_URL").FirstOrDefault().tpc_value.Replace("~", "") + item.pd.pd_image_url;

                    objClsProductDetail.IsActive = item.pd.pd_is_active.Value;
                    if (objClsProductDetail.IsActive == true)
                    {
                        objClsProductDetail.Active = "Yes";
                    }
                    else
                    {
                        objClsProductDetail.Active = "No";
                    }

                    lstClsProductDetail.Add(objClsProductDetail);
                }
            }
            lstClsProductDetail = lstClsProductDetail.OrderBy(item => item.SeqNo)
           .GroupBy(item => item.CategoryName)
           .SelectMany(group => group)
           .ToList();

        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductDetail.ListToDataTable();
    }
    public DataTable GetProductListByOrderNumber(string OrderNumber, string searchText = null)
    {


        List<tp_product_details> lstProductList = new List<tp_product_details>();
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        try
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                var result = (from a in dbEntities.tp_customer_order_details
                              join b in dbEntities.tp_order_product_mapping
                              on a.cod_id equals b.opm_cod_id
                              join c in dbEntities.tp_product_details
                              on b.opm_pd_id equals c.pd_id
                              join d in dbEntities.tp_product_category
                              on c.pd_pc_id equals d.pc_id

                              where a.cod_isdeleted == false && c.pd_isdeleted == false && d.pc_isdeleted == false &&
                              a.cod_order_number == OrderNumber && c.pd_name.Contains(searchText)

                              select new
                              {
                                  a.cod_order_number,
                                  b.opm_Comment,
                                  b.opm_price,
                                  b.opm_quantity,
                                  c.pd_id,
                                  c.pd_name,
                                  c.pd_base_price,
                                  c.pd_can_comment,
                                  c.pd_description1,
                                  c.pd_image_url,
                                  c.pd_is_active,
                                  c.pd_is_delivered,
                                  c.pd_is_marked_new,
                                  c.pd_is_marked_speciality,
                                  c.pd_seqno,
                                  d.pc_description1,
                                  d.pc_image_url,
                                  d.pc_name,
                                  d.pc_parent,
                                  d.pc_sd_id,
                                  d.pc_seqno,
                                  b.opm_pp_id

                              }).ToList();


                foreach (var item in result)
                {
                    ClsProductDetail objClsProductDetail = new ClsProductDetail();
                    objClsProductDetail.ProductdetailId = item.pd_id;
                    objClsProductDetail.SeqNo = Convert.ToInt32(item.pd_seqno);
                    objClsProductDetail.ProductName = item.pd_name;
                    objClsProductDetail.Description = item.pd_description1;
                    objClsProductDetail.CategoryName = item.pc_name;
                    if (item.opm_pp_id.ToString() != "" && item.opm_pp_id != null)
                    {
                        objClsProductDetail.PropertiesId = item.opm_pp_id.Value;
                        tp_product_properties objtp_product_properties = new tp_product_properties();
                        objtp_product_properties = dbEntities.tp_product_properties.Where(x => x.pp_id == objClsProductDetail.PropertiesId && x.pd_id == objClsProductDetail.ProductdetailId && x.pp_isdeleted == false).FirstOrDefault();
                        if (objtp_product_properties != null)
                        {
                            objClsProductDetail.BasePrice = Convert.ToDecimal(objtp_product_properties.pp_price);
                        }
                        else
                        {
                            objClsProductDetail.BasePrice = Convert.ToDecimal(item.pd_base_price);
                        }
                    }
                    else
                    {
                        objClsProductDetail.PropertiesId =0;
                        objClsProductDetail.BasePrice = Convert.ToDecimal(item.pd_base_price);
                    }
                    objClsProductDetail.ImageUrl = dbEntities.tp_config.Where(x => x.tpc_key == "MENU_ITEM_IMAGE_URL").FirstOrDefault().tpc_value.Replace("~", "") + item.pd_image_url;

                    objClsProductDetail.IsActive = item.pd_is_active.Value;
                    objClsProductDetail.Comment = item.opm_Comment;
                    objClsProductDetail.Price = Convert.ToDecimal(item.opm_price);
                    objClsProductDetail.Quantity = item.opm_quantity.Value;
                    if (objClsProductDetail.IsActive == true)
                    {
                        objClsProductDetail.Active = "Yes";
                    }
                    else
                    {
                        objClsProductDetail.Active = "No";
                    }

                    lstClsProductDetail.Add(objClsProductDetail);
                }
            }
            else
            {
                var result = (from a in dbEntities.tp_customer_order_details
                              join b in dbEntities.tp_order_product_mapping
                              on a.cod_id equals b.opm_cod_id
                              join c in dbEntities.tp_product_details
                              on b.opm_pd_id equals c.pd_id
                              join d in dbEntities.tp_product_category
                              on c.pd_pc_id equals d.pc_id

                              where a.cod_isdeleted == false && c.pd_isdeleted == false && d.pc_isdeleted == false &&
                              a.cod_order_number == OrderNumber

                              select new
                              {
                                  a.cod_order_number,
                                  b.opm_pp_id,
                                  b.opm_Comment,
                                  b.opm_price,
                                  b.opm_quantity,
                                  c.pd_id,
                                  c.pd_name,
                                  c.pd_base_price,
                                  c.pd_can_comment,
                                  c.pd_description1,
                                  c.pd_image_url,
                                  c.pd_is_active,
                                  c.pd_is_delivered,
                                  c.pd_is_marked_new,
                                  c.pd_is_marked_speciality,
                                  c.pd_seqno,
                                  d.pc_description1,
                                  d.pc_image_url,
                                  d.pc_name,
                                  d.pc_parent,
                                  d.pc_sd_id,
                                  d.pc_seqno

                              }).ToList();

                foreach (var item in result)
                {
                    ClsProductDetail objClsProductDetail = new ClsProductDetail();
                    objClsProductDetail.ProductdetailId = item.pd_id;
                    objClsProductDetail.SeqNo = Convert.ToInt32(item.pd_seqno);
                    objClsProductDetail.ProductName = item.pd_name;
                    objClsProductDetail.Description = item.pd_description1;
                    objClsProductDetail.CategoryName = item.pc_name;
                    if (item.opm_pp_id.ToString() != "" && item.opm_pp_id != null)
                    {
                        objClsProductDetail.PropertiesId = item.opm_pp_id.Value;
                        tp_product_properties objtp_product_properties = new tp_product_properties();
                        objtp_product_properties = dbEntities.tp_product_properties.Where(x => x.pp_id == objClsProductDetail.PropertiesId && x.pd_id == objClsProductDetail.ProductdetailId && x.pp_isdeleted == false).FirstOrDefault();
                        if (objtp_product_properties != null)
                        {
                            objClsProductDetail.BasePrice = Convert.ToDecimal(objtp_product_properties.pp_price);
                        }
                        else
                        {
                            objClsProductDetail.BasePrice = Convert.ToDecimal(item.pd_base_price);
                        }
                    }
                    else
                    {
                        objClsProductDetail.PropertiesId =0;
                        objClsProductDetail.BasePrice = Convert.ToDecimal(item.pd_base_price);
                    }
                    objClsProductDetail.ImageUrl = dbEntities.tp_config.Where(x => x.tpc_key == "MENU_ITEM_IMAGE_URL").FirstOrDefault().tpc_value.Replace("~", "") + item.pd_image_url;

                    objClsProductDetail.IsActive = item.pd_is_active.Value;
                    objClsProductDetail.Comment = item.opm_Comment;
                    objClsProductDetail.Price = Convert.ToDecimal(item.opm_price);
                    objClsProductDetail.Quantity = item.opm_quantity.Value;
                    if (objClsProductDetail.IsActive == true)
                    {
                        objClsProductDetail.Active = "Yes";
                    }
                    else
                    {
                        objClsProductDetail.Active = "No";
                    }

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


    //Get Product Detail by category

    public List<tp_product_details> GetProductListByCategoryId()
    {
        List<tp_product_details> lstProductList = new List<tp_product_details>();
        var result = (from pd in dbEntities.tp_product_details
                      join pc in dbEntities.tp_product_category
                      on pd.pd_pc_id equals pc.pc_id
                      where pd.pd_isdeleted == false
                      select pd).ToList();
        foreach (var item in result)
        {
            tp_product_details dbObjProductList = new tp_product_details();
            dbObjProductList.pd_name = item.pd_name;
            lstProductList.Add(dbObjProductList);
        }

        return lstProductList;
    }

    //Get product Detail by order id

    public List<tp_product_details> GetProductListByOrderId()
    {
        List<tp_product_details> lstProductList = new List<tp_product_details>();
        try
        {
            var result = (from pd in dbEntities.tp_product_details
                          join opm in dbEntities.tp_order_product_mapping
                          on pd.pd_id equals opm.opm_pd_id
                          join cod in dbEntities.tp_customer_order_details
                          on opm.opm_id equals cod.cod_id
                          where pd.pd_isdeleted == false
                          select new
                          {
                              pd.pd_name,
                              cod.cod_order_number,
                              opm.opm_price
                          }).ToList();
            foreach (var item in result)
            {
                tp_product_details dbObjProductList = new tp_product_details();
                dbObjProductList.pd_name = item.pd_name;
                lstProductList.Add(dbObjProductList);
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstProductList;
    }

    //Get Product Detail by ingredient
    public DataTable GetExtraOrderProductListByIngredient(int productId, string OrderNumber)
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        try
        {
            var result = (from a in dbEntities.tp_order_product_ingredients_specification
                          join b in dbEntities.tp_customer_order_details
                          on a.opis_cod_id equals b.cod_id
                          join c in dbEntities.tp_product_details
                          on a.opis_pd_id equals c.pd_id
                          join d in dbEntities.tp_ingredient_details
                          on a.opis_id_id equals d.id_id
                          join e in dbEntities.tp_ingredient_product_mapping
                          on d.id_id equals e.id_id
                          where b.cod_isdeleted == false && d.id_isdeleted == false && c.pd_isdeleted == false &&
                         e.ipm_isdeleted == false && b.cod_order_number == OrderNumber && a.opis_pd_id == productId
                          select new
                          {
                              d.id_id,
                              d.id_name,
                              d.id_price
                          }).ToList();

            foreach (var item in result)
            {
                ClsProductDetail objClsProductDetail = new ClsProductDetail();
                objClsProductDetail.IngredientName = item.id_name;
                objClsProductDetail.IngredientPrice = item.id_price;
                objClsProductDetail.IngredientId = item.id_id;

                lstClsProductDetail.Add(objClsProductDetail);
            }
            lstClsProductDetail = lstClsProductDetail.GroupBy(i => i.IngredientId).Select(g => g.First()).ToList();
        }

        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductDetail.ListToDataTable();
    }

    public DataTable GetDefaultOrderProductListByIngredient(int productId, string OrderNumber)
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        try
        {
            var result = (from ipm in dbEntities.tp_ingredient_product_mapping
                          join id in dbEntities.tp_ingredient_details
                          on ipm.id_id equals id.id_id
                          where ipm.pd_id == productId && id.id_isdeleted == false && ipm.ipm_isdeleted == false && ipm.iipm_isDefault == true
                          select new
                          {
                              id.id_id,
                              id.id_name,
                              id.id_price
                          }).ToList();

            foreach (var item in result)
            {
                ClsProductDetail objClsProductDetail = new ClsProductDetail();
                objClsProductDetail.IngredientName = item.id_name;
                objClsProductDetail.IngredientPrice = item.id_price;
                objClsProductDetail.IngredientId = item.id_id;

                lstClsProductDetail.Add(objClsProductDetail);
            }

            lstClsProductDetail = lstClsProductDetail.GroupBy(i => i.IngredientId).Select(g => g.First()).ToList();
        }

        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductDetail.ListToDataTable();
    }

    public string GetProductNameByProductId(int productId)
    {
        string productName = string.Empty;
        try
        {
            productName = dbEntities.tp_product_details.Where(x => x.pd_id == productId && x.pd_isdeleted == false).FirstOrDefault().pd_name;
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return productName;
    }

    public string GetProductPriceByProductId(int productId)
    {
        string productPrice = string.Empty;
        try
        {
            productPrice = dbEntities.tp_product_details.Where(x => x.pd_id == productId && x.pd_isdeleted == false).FirstOrDefault().pd_base_price;
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return productPrice;
    }
    //Default Ingredients in product
    public DataTable GetDefaultIngredientsInProduct(int productId)
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        try
        {
            var result = (from ipm in dbEntities.tp_ingredient_product_mapping
                          join id in dbEntities.tp_ingredient_details
                          on ipm.id_id equals id.id_id
                          where ipm.pd_id == productId && id.id_isdeleted == false && ipm.ipm_isdeleted == false
                          && ipm.iipm_isDefault == true
                          select new
                          {
                              id.id_name,
                              id.id_price
                          }).ToList();

            foreach (var item in result)
            {
                ClsProductDetail objClsProductDetail = new ClsProductDetail();
                objClsProductDetail.IngredientName = item.id_name;
                objClsProductDetail.IngredientPrice = item.id_price;

                lstClsProductDetail.Add(objClsProductDetail);
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductDetail.ListToDataTable();
    }

    //Extra Ingredients For product
    public DataTable GetExtraIngredientsForProduct(int productId)
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        try
        {
            var result = (from ipm in dbEntities.tp_ingredient_product_mapping
                          join id in dbEntities.tp_ingredient_details
                          on ipm.id_id equals id.id_id
                          where ipm.pd_id == productId && id.id_isdeleted == false && ipm.ipm_isdeleted == false
                          select new
                          {
                              id.id_name,
                              id.id_price
                          }).ToList();

            foreach (var item in result)
            {
                ClsProductDetail objClsProductDetail = new ClsProductDetail();
                objClsProductDetail.IngredientName = item.id_name;
                objClsProductDetail.IngredientPrice = item.id_price;

                lstClsProductDetail.Add(objClsProductDetail);
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductDetail.ListToDataTable();
    }

    public DataTable GetOrderIngredientFactOfProduct(int productId, string OrderNumber)
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        try
        {
            var result = (from a in dbEntities.tp_order_product_ingredients_specification
                          join b in dbEntities.tp_customer_order_details
                          on a.opis_cod_id equals b.cod_id
                          join c in dbEntities.tp_product_details
                          on a.opis_pd_id equals c.pd_id
                          join d in dbEntities.tp_product_ingredient_fact_detail
                          on a.opis_pifd_id equals d.pifd_id
                          join e in dbEntities.tp_product_ingredient_fact_mapping
                          on d.pifd_id equals e.pifd_id
                          where b.cod_isdeleted == false && c.pd_isdeleted == false && d.pifd_isdeleted == false
                          && e.pifm_isdeleted == false && b.cod_order_number == OrderNumber && a.opis_pd_id == productId && e.pd_id == productId
                          select new
                          {
                              d.pifd_name,
                              d.pifd_id
                          }).ToList();
            result = result.GroupBy(i => i.pifd_id).Select(g => g.First()).ToList();
            if (result.Count > 0)
            {
                foreach (var item in result)
                {
                    ClsProductDetail objClsProductDetail = new ClsProductDetail();
                    objClsProductDetail.IngredientFactName = item.pifd_name;
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

    public DataTable GetOrderIngredientFactOfIngredient(int productId, int ingredientId, string OrderNumber)
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        try
        {
            var result = (from a in dbEntities.tp_order_product_ingredients_specification
                          join b in dbEntities.tp_customer_order_details
                          on a.opis_cod_id equals b.cod_id
                          join c in dbEntities.tp_product_details
                          on a.opis_pd_id equals c.pd_id
                          join d in dbEntities.tp_product_ingredient_fact_detail
                          on a.opis_pifd_id equals d.pifd_id
                          join e in dbEntities.tp_product_ingredient_fact_mapping
                          on d.pifd_id equals e.pifd_id
                          where b.cod_isdeleted == false && c.pd_isdeleted == false && d.pifd_isdeleted == false
                          && e.pifm_isdeleted == false && b.cod_order_number == OrderNumber && a.opis_pd_id == productId && e.id_id == ingredientId
                          select new
                          {
                              d.pifd_name,
                              d.pifd_id
                          }).ToList();
            result = result.GroupBy(i => i.pifd_id).Select(g => g.First()).ToList();
            if (result.Count > 0)
            {
                foreach (var item in result)
                {
                    ClsProductDetail objClsProductDetail = new ClsProductDetail();
                    objClsProductDetail.IngredientFactName = item.pifd_name;
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

    //Get ingredient fact detail of product

    public DataTable GetIngredientFactOfProduct(int productId)
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        try
        {
            var result = (from pifm in dbEntities.tp_product_ingredient_fact_mapping
                          join pifd in dbEntities.tp_product_ingredient_fact_detail
                          on pifm.pifd_id equals pifd.pifd_id
                          where pifm.pd_id == productId && pifd.pifd_isdeleted == false && pifm.pifm_isdeleted == false
                          select new
                          {
                              pifd.pifd_name
                          }).ToList();

            foreach (var item in result)
            {
                ClsProductDetail objClsProductDetail = new ClsProductDetail();
                objClsProductDetail.IngredientFactName = item.pifd_name;


                lstClsProductDetail.Add(objClsProductDetail);
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductDetail.ListToDataTable();
    }

    //Get ingredient fact detail of ingredient

    public DataTable GetIngredientFactOfIngredient(int ingredientId)
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        try
        {
            var result = (from pifm in dbEntities.tp_product_ingredient_fact_mapping
                          join pifd in dbEntities.tp_product_ingredient_fact_detail
                          on pifm.pifd_id equals pifd.pifd_id
                          where pifm.pd_id == ingredientId && pifd.pifd_isdeleted == false && pifm.pifm_isdeleted == false
                          select new
                          {
                              pifd.pifd_name
                          }).ToList();

            foreach (var item in result)
            {
                ClsProductDetail objClsProductDetail = new ClsProductDetail();
                objClsProductDetail.IngredientFactName = item.pifd_name;


                lstClsProductDetail.Add(objClsProductDetail);
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductDetail.ListToDataTable();
    }


    //Get Product Properties by product id
    //public List<ClsProductDetail> GetProductPropertiesById(int productId)
    //{
    //    List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
    //    try
    //    {
    //        var result = (from pp in dbEntities.tp_product_properties
    //                      join ps in dbEntities.tp_product_sizes
    //                      on pp.ps_id equals ps.ps_id
    //                      join pbt in dbEntities.tp_pizza_base_type
    //                      on pp.pbt_id equals pbt.pbt_id
    //                      join pmm in dbEntities.tp_product_making_method
    //                      on pp.pmm_id equals pmm.pmm_id
    //                      where pp.pd_id == productId && ps.ps_isdeleted == false && pbt.pbt_isdeleted == false && pmm.pmm_isdeleted == false && pp.pp_isdeleted == false
    //                      select new
    //                      {
    //                          ps.ps_name,
    //                          pbt.pbt_name,
    //                          pmm.pmm_name,
    //                          pp
    //                      }).ToList();

    //        foreach (var item in result)
    //        {
    //            ClsProductDetail objClsProductDetail = new ClsProductDetail();
    //            objClsProductDetail.PropertiesId = item.pp.pp_id;
    //            objClsProductDetail.SizeId = item.pp.ps_id.Value;
    //            objClsProductDetail.SizeName = item.ps_name;
    //            objClsProductDetail.PizzaBaseTypeId = item.pp.pbt_id.Value;
    //            objClsProductDetail.PizzaBaseType = item.pbt_name;
    //            objClsProductDetail.MakingMethodId = item.pp.pmm_id.Value;
    //            objClsProductDetail.MakingMethodName = item.pmm_name;
    //            objClsProductDetail.PropertiesPrice = item.pp.pp_price;

    //            lstClsProductDetail.Add(objClsProductDetail);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        ErrorHandler.WriteError(ex);
    //    }
    //    //return lstClsProductDetail.ToDataTable();
    //    return lstClsProductDetail;
    //}

    public DataTable GetOrderProductPropertiesByProductId(int productId, string OrderNumber)
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        try
        {
            var result = (from a in dbEntities.tp_order_product_ingredients_specification
                          join b in dbEntities.tp_customer_order_details
                          on a.opis_cod_id equals b.cod_id
                          join c in dbEntities.tp_product_details
                          on a.opis_pd_id equals c.pd_id
                          join d in dbEntities.tp_product_properties
                          on a.opis_pp_id equals d.pp_id
                          join e in dbEntities.tp_product_sizes
                          on d.ps_id equals e.ps_id
                          where b.cod_isdeleted == false && c.pd_isdeleted == false && d.pp_isdeleted == false
                          && e.ps_isdeleted == false && b.cod_order_number == OrderNumber && a.opis_pd_id == productId && d.pd_id == productId


                          select new
                          {
                              d.pp_id,
                              a.opis_pd_id,
                              e.ps_name,
                              e.ps_id,
                              d.pp_price

                          }).ToList();
            result = result.GroupBy(i => i.ps_id).Select(g => g.First()).ToList();
            //result = result.GroupBy(i => i.pp_id).Select(g => g.First()).ToList();
            foreach (var item in result)
            {
                if (item.ps_id != 0)
                {
                    ClsProductDetail objClsProductDetail = new ClsProductDetail();
                    objClsProductDetail.PropertiesId = item.pp_id;
                    objClsProductDetail.SizeId = item.ps_id;
                    objClsProductDetail.SizeName = item.ps_name;
                    objClsProductDetail.PropertiesPrice = item.pp_price;

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

    public DataTable GetOrderProductPropertiesByPropertyId(int propertyId)
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        try
        {
            var result = (from a in dbEntities.tp_product_properties
                          join b in dbEntities.tp_product_sizes
                          on a.ps_id equals b.ps_id
                          where a.pp_isdeleted==false && b.ps_isdeleted==false && a.pp_id==propertyId
                         
                          select new
                          {
                             a.pp_id,
                             a.ps_id,
                             b.ps_name,
                             a.pp_price
                          }).ToList();
           
            foreach (var item in result)
            {
                if (item.ps_id != 0)
                {
                    ClsProductDetail objClsProductDetail = new ClsProductDetail();
                    objClsProductDetail.PropertiesId = item.pp_id;
                    objClsProductDetail.SizeId = item.ps_id.Value;
                    objClsProductDetail.SizeName = item.ps_name;
                    objClsProductDetail.PropertiesPrice = item.pp_price;

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

    //Get Product Properties by product id
    public DataTable GetProductPropertiesByProductId(int productId)
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        try
        {
            var result = (from pp in dbEntities.tp_product_properties
                          join ps in dbEntities.tp_product_sizes
                          on pp.ps_id equals ps.ps_id
                          into JoinedPsid
                          from sizedetail in JoinedPsid.DefaultIfEmpty()
                          join pbt in dbEntities.tp_pizza_base_type
                           on pp.pbt_id equals pbt.pbt_id
                           into JoinedPbtid
                          from basetypedetail in JoinedPbtid.DefaultIfEmpty()
                          join pmm in dbEntities.tp_product_making_method
                            on pp.pmm_id equals pmm.pmm_id
                             into JoinedPmmid
                          from makingmethoddetail in JoinedPmmid.DefaultIfEmpty()
                          where pp.pd_id == productId && pp.pp_isdeleted == false
                          select new
                          {
                              SizeId = (sizedetail == null ? 0 : sizedetail.ps_id),
                              SizeName = (sizedetail == null ? String.Empty : sizedetail.ps_name),
                              BaseTypeId = (basetypedetail == null ? 0 : basetypedetail.pbt_id),
                              BaseTypeName = (basetypedetail == null ? String.Empty : basetypedetail.pbt_name),
                              MakingMethodId = (makingmethoddetail == null ? 0 : makingmethoddetail.pmm_id),
                              MakingMethodName = (makingmethoddetail == null ? String.Empty : makingmethoddetail.pmm_name),
                              pp
                          }).ToList();
            //var result = (from pp in dbEntities.tp_product_properties
            //               join ps in dbEntities.tp_product_sizes
            //              on pp.ps_id equals ps.ps_id
            //              join pbt in dbEntities.tp_pizza_base_type
            //              on pp.pbt_id equals pbt.pbt_id
            //              join pmm in dbEntities.tp_product_making_method
            //              on pp.pmm_id equals pmm.pmm_id
            //              where pp.pd_id == productId && ps.ps_isdeleted==false && pbt.pbt_isdeleted==false && pmm.pmm_isdeleted==false && pp.pp_isdeleted==false
            //              select new
            //              {
            //                  ps.ps_name,
            //                  pbt.pbt_name,
            //                  pmm.pmm_name,
            //                  pp
            //              }).ToList();

            foreach (var item in result)
            {
                if (item.SizeId != 0 || item.BaseTypeId != 0 || item.MakingMethodId != 0)
                {
                    ClsProductDetail objClsProductDetail = new ClsProductDetail();
                    objClsProductDetail.PropertiesId = item.pp.pp_id;
                    objClsProductDetail.SizeId = item.SizeId;
                    objClsProductDetail.SizeName = item.SizeName;
                    objClsProductDetail.PizzaBaseTypeId = item.BaseTypeId;
                    objClsProductDetail.PizzaBaseType = item.BaseTypeName;
                    objClsProductDetail.MakingMethodId = item.MakingMethodId;
                    objClsProductDetail.MakingMethodName = item.MakingMethodName;
                    objClsProductDetail.PropertiesPrice = item.pp.pp_price;

                    objClsProductDetail.SingleIngredientsPrice = item.pp.pp_single_ingredients_price;
                    objClsProductDetail.DoubleIngredientsPrice = item.pp.pp_double_ingredients_price;

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

    public List<ClsProductDetail> GetAllFactDetailByProductId(int ProductId)
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        try
        {
            var result = (from a in dbEntities.tp_product_ingredient_fact_mapping
                          join b in dbEntities.tp_product_ingredient_fact_detail
                          on a.pifd_id equals b.pifd_id
                          where a.pd_id == ProductId && a.pifm_isdeleted == false && b.pifd_isdeleted == false
                          select new
                          {
                              b.pifd_name
                          }).ToList();
            if (result != null)
            {
                foreach (var item in result)
                {
                    ClsProductDetail objClsProductDetail = new ClsProductDetail();
                    objClsProductDetail.IngredientFactName = item.pifd_name;
                    lstClsProductDetail.Add(objClsProductDetail);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductDetail;
    }

    public List<ClsProductDetail> GetAllFactDetailByIngredientId(int ingredientId)
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        try
        {
            var result = (from a in dbEntities.tp_product_ingredient_fact_mapping
                          join b in dbEntities.tp_product_ingredient_fact_detail
                          on a.pifd_id equals b.pifd_id
                          where a.pd_id == ingredientId && a.pifm_isdeleted == false && b.pifd_isdeleted == false
                          select new
                          {
                              b.pifd_name
                          }).ToList();
            if (result != null)
            {
                foreach (var item in result)
                {
                    ClsProductDetail objClsProductDetail = new ClsProductDetail();
                    objClsProductDetail.IngredientFactName = item.pifd_name;
                    lstClsProductDetail.Add(objClsProductDetail);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductDetail;
    }

    //Get Product Information for Edit 
    public ClsProductDetail GetProductInformation(int productId)
    {
        ClsProductDetail objClsProductDetail = new ClsProductDetail();
        try
        {
            //var result = (from ipm in dbEntities.tp_ingredient_product_mapping
            //              join id in dbEntities.tp_ingredient_details
            //              on ipm.id_id equals id.id_id
            //              join pd in dbEntities.tp_product_details
            //              on ipm.pd_id equals pd.pd_id
            //              join pc in dbEntities.tp_product_category
            //              on pd.pd_pc_id equals pc.pc_id
            //              where ipm.pd_id == productId && id.id_isdeleted == false && ipm.ipm_isdeleted == false && pc.pc_isdeleted==false
            //              select new
            //              {
            //                  pd,
            //                  id.id_id,
            //                  id.id_name,
            //                  id.id_price,
            //                  pc.pc_id
            //              }).FirstOrDefault();
            var result = (from pd in dbEntities.tp_product_details
                          join pc in dbEntities.tp_product_category
                          on pd.pd_pc_id equals pc.pc_id
                          where pd.pd_id == productId && pc.pc_isdeleted == false
                          select new
                          {
                              pd,

                              pc.pc_id,
                              pc.pc_name
                          }).FirstOrDefault();

            if (result != null)
            {
                objClsProductDetail.SeqNo = Convert.ToInt32(result.pd.pd_seqno);
                objClsProductDetail.ProductName = result.pd.pd_name;
                objClsProductDetail.Description = result.pd.pd_description1;
                objClsProductDetail.BasePrice = Convert.ToDecimal(result.pd.pd_base_price);
                objClsProductDetail.BaseSingleIngredientPrice = Convert.ToDecimal(result.pd.pp_base_single_ingredients_price);
                objClsProductDetail.BaseDoubleIngredientPrice = Convert.ToDecimal(result.pd.pp_base_double_ingredients_price);

                objClsProductDetail.ImageUrl = dbEntities.tp_config.Where(x => x.tpc_key == "MENU_ITEM_IMAGE_URL").FirstOrDefault().tpc_value.Replace("~", "") + result.pd.pd_image_url;
                objClsProductDetail.IsActive = result.pd.pd_is_active.Value;
                objClsProductDetail.IsDelivered = result.pd.pd_is_delivered.Value;
                objClsProductDetail.IsMarkedNew = result.pd.pd_is_marked_new.Value;
                objClsProductDetail.IsMarkedSpeciality = result.pd.pd_is_marked_speciality.Value;
                objClsProductDetail.CanComment = result.pd.pd_can_comment.Value;

                objClsProductDetail.CommentCompulsory = result.pd.pd_Is_Commant_Compulsary;
                //objClsProductDetail.IngredientId = result.id_id;
                //objClsProductDetail.IngredientName = result.id_name;
                //objClsProductDetail.IngredientPrice = result.id_price;
                objClsProductDetail.CategotyId = result.pc_id;
                objClsProductDetail.CategoryName = result.pc_name;
                objClsProductDetail.FreeIngredients = result.pd.no_free_ingredients;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objClsProductDetail;
    }
    //Get All Ingredient use in Product(Menu Item)
    public List<ClsProductDetail> GetAllDefaultIngredientMappingInformation(int Id)
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        try
        {
            var result = (from ipm in dbEntities.tp_ingredient_product_mapping
                          join id in dbEntities.tp_ingredient_details
                          on ipm.id_id equals id.id_id
                          where ipm.pd_id == Id && id.id_isdeleted == false && ipm.ipm_isdeleted == false
                          && ipm.iipm_isDefault == true
                          select new
                          {
                              id.id_price,
                              id.id_name,
                              ipm.id_id
                          }).ToList();

            if (result != null)
            {
                foreach (var item in result)
                {
                    ClsProductDetail objClsProductDetail = new ClsProductDetail();
                    objClsProductDetail.IngredientId = item.id_id.Value;
                    objClsProductDetail.IngredientName = item.id_name;
                    objClsProductDetail.IngredientPrice = item.id_price;
                    lstClsProductDetail.Add(objClsProductDetail);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductDetail;
    }



    //Get All Extra Ingredient use in Product(Menu Item)
    public List<ClsProductDetail> GetAllExtraIngredientMappingInformation(int Id)
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        try
        {
            var result = (from ipm in dbEntities.tp_ingredient_product_mapping
                          join id in dbEntities.tp_ingredient_details
                          on ipm.id_id equals id.id_id
                          where ipm.pd_id == Id && id.id_isdeleted == false && ipm.ipm_isdeleted == false
                          && ipm.iipm_isDefault == false
                          select new
                          {
                              id.id_price,
                              id.id_name,
                              ipm.id_id
                          }).ToList();

            if (result != null)
            {
                foreach (var item in result)
                {
                    ClsProductDetail objClsProductDetail = new ClsProductDetail();
                    objClsProductDetail.IngredientId = item.id_id.Value;
                    objClsProductDetail.IngredientName = item.id_name;
                    objClsProductDetail.IngredientPrice = item.id_price;
                    lstClsProductDetail.Add(objClsProductDetail);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductDetail;
    }

    //Get All Properties use in Product

    public List<ClsProductDetail> GetAllPropertiesMappingInformation(int Id)
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        try
        {
            var result = (from pp in dbEntities.tp_product_properties
                          join ps in dbEntities.tp_product_sizes
                          on pp.ps_id equals ps.ps_id
                          join pbt in dbEntities.tp_pizza_base_type
                          on pp.pbt_id equals pbt.pbt_id
                          join pmm in dbEntities.tp_product_making_method
                          on pp.pmm_id equals pmm.pmm_id
                          where pp.pd_id == Id && ps.ps_isdeleted == false && pbt.pbt_isdeleted == false && pmm.pmm_isdeleted == false
                          select new
                          {
                              ps.ps_name,
                              pbt.pbt_name,
                              pmm.pmm_name,
                              pp.pp_price
                          }).ToList();

            if (result != null)
            {
                foreach (var item in result)
                {
                    ClsProductDetail objClsProductDetail = new ClsProductDetail();
                    objClsProductDetail.SizeName = item.ps_name;
                    objClsProductDetail.PizzaBaseType = item.pbt_name;
                    objClsProductDetail.MakingMethodName = item.pmm_name;
                    objClsProductDetail.PropertiesPrice = item.pp_price;
                    lstClsProductDetail.Add(objClsProductDetail);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductDetail;
    }


    //Get All Ingredients 
    public DataTable GetAllIngredients()
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        List<tp_ingredient_details> lsttp_ingredient_details = new List<tp_ingredient_details>();
        try
        {
            lsttp_ingredient_details = dbEntities.tp_ingredient_details.Where(x => x.id_isdeleted == false).ToList();
            if (lsttp_ingredient_details.Count > 0)
            {
                foreach (var item in lsttp_ingredient_details)
                {
                    ClsProductDetail objClsProductDetail = new ClsProductDetail();
                    objClsProductDetail.IngredientId = item.id_id;
                    objClsProductDetail.IngredientName = item.id_name;
                    objClsProductDetail.IngredientPrice = item.id_price;
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

    //Get All Ingredients 
    public DataTable GetAllIngredientFactDetails()
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        List<tp_product_ingredient_fact_detail> lsttp_product_ingredient_fact_detail = new List<tp_product_ingredient_fact_detail>();
        try
        {
            lsttp_product_ingredient_fact_detail = dbEntities.tp_product_ingredient_fact_detail.Where(x => x.pifd_isdeleted == false).ToList();
            if (lsttp_product_ingredient_fact_detail.Count > 0)
            {
                foreach (var item in lsttp_product_ingredient_fact_detail)
                {
                    ClsProductDetail objClsProductDetail = new ClsProductDetail();
                    objClsProductDetail.IngredientFactId = item.pifd_id;
                    objClsProductDetail.IngredientFactName = item.pifd_name;

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


    //Get All Properties
    //public DataTable GetAllProperties()
    //{
    //    List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
    //  //  List<tp_ingredient_details> lsttp_ingredient_details = new List<tp_ingredient_details>();
    //    try
    //    {
    //        var result = (from pp in dbEntities.tp_product_properties
    //                      join ps in dbEntities.tp_product_sizes
    //                      on pp.ps_id equals ps.ps_id
    //                      join pbt in dbEntities.tp_pizza_base_type
    //                      on pp.pbt_id equals pbt.pbt_id
    //                      join pmm in dbEntities.tp_product_making_method
    //                      on pp.pmm_id equals pmm.pmm_id

    //                      where ps.ps_isdeleted == false && pbt.pbt_isdeleted == false && pmm.pmm_isdeleted == false
    //                      select new
    //                      {
    //                          ps.ps_name,
    //                          pbt.pbt_name,
    //                          pmm.pmm_name,
    //                          pp.pp_price
    //                      }).ToList();

    //        if (result.Count > 0)
    //        {
    //            foreach (var item in result)
    //            {
    //                ClsProductDetail objClsProductDetail = new ClsProductDetail();
    //                objClsProductDetail.IngredientId = item.id_id;
    //                objClsProductDetail.IngredientName = item.id_name;
    //                objClsProductDetail.IngredientPrice = item.id_price;
    //                lstClsProductDetail.Add(objClsProductDetail);
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        ErrorHandler.WriteError(ex);
    //    }
    //    return lstClsProductDetail.ListToDataTable();
    //}

    //Image Upload
    public string FileUpload(byte[] fileStream, string fileName, string filePath = "")
    {
        string retmsg = "";
        try
        {
            using (MemoryStream ms = new MemoryStream(fileStream))
            {
                FileStream fs = new FileStream(System.Web.Hosting.HostingEnvironment.MapPath(filePath) + fileName, FileMode.Create);

                ms.WriteTo(fs);

                // clean up
                ms.Close();
                fs.Close();
                fs.Dispose();
            }

            // FileStream fs = new FileStream(System.Web.Hosting.HostingEnvironment.MapPath("~\\ProjectImages\\ProductImages\\") + fileName + ".png", FileMode.Create);
            retmsg = "SUCCESS";
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return retmsg;
    }

    //Get Menu Item Image Url
    public tp_config GetMenuItemImgUrl()
    {
        tp_config objfda_config = new tp_config();
        try
        {

            objfda_config = dbEntities.tp_config.Where(x => x.tpc_key == "MENU_ITEM_IMAGE_URL").FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objfda_config;
    }

    public List<tp_product_category> GetAllCategory()
    {
        List<tp_product_category> lsttp_product_category = new List<tp_product_category>();
        try
        {
            lsttp_product_category = dbEntities.tp_product_category.Where(x => x.pc_isdeleted == false).ToList();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lsttp_product_category;
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

    public List<tp_pizza_base_type> GetAllPizzaBaseType()
    {
        List<tp_pizza_base_type> lsttp_pizza_base_type = new List<tp_pizza_base_type>();
        try
        {
            lsttp_pizza_base_type = dbEntities.tp_pizza_base_type.Where(x => x.pbt_isdeleted == false).ToList();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lsttp_pizza_base_type;
    }

    public List<tp_product_making_method> GetAllMakingMethods()
    {
        List<tp_product_making_method> lsttp_product_making_method = new List<tp_product_making_method>();
        try
        {
            lsttp_product_making_method = dbEntities.tp_product_making_method.Where(x => x.pmm_isdeleted == false).ToList();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lsttp_product_making_method;
    }

    public List<ClsProductDetail> GetAllCategoryForOrderOnline()
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();

        var result = (from pc in dbEntities.tp_product_category.Where(P => P.pc_isdeleted == false)
                      select new
                      {
                          pc.pc_id,
                          pc.pc_name,
                          pc.pc_description1,
                          pc.pc_seqno
                      }).ToList();

        foreach (var item in result)
        {
            ClsProductDetail objClsProductDetail = new ClsProductDetail();
            objClsProductDetail.CategotyId = item.pc_id;
            objClsProductDetail.CategoryName = item.pc_name;
            objClsProductDetail.CategoryDescription = item.pc_description1;
            if (item.pc_seqno != "" && item.pc_seqno != null)
            {
                objClsProductDetail.SeqNo = Convert.ToInt32(item.pc_seqno);
            }
            lstClsProductDetail.Add(objClsProductDetail);
        }
        lstClsProductDetail = lstClsProductDetail.OrderBy(x => x.SeqNo).ToList();

        return lstClsProductDetail;
    }


    public DataTable GetAllProductByCategoryId(int CategoryId)
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        try
        {
            var result = (from a in dbEntities.tp_product_details
                          join b in dbEntities.tp_product_category
                          on a.pd_pc_id equals b.pc_id

                          where a.pd_pc_id == CategoryId && a.pd_isdeleted == false && b.pc_isdeleted == false
                          select new
                          {
                              a.pd_id,
                              a.pd_name,
                              a.pd_pc_id,
                              a.pd_isdeleted,
                              a.pd_base_price,
                              a.pd_description1,
                              b.pc_description1,
                              a.pd_seqno,
                              b.pc_name,
                          }).ToList();

            if (result != null)
            {
                foreach (var item in result)
                {
                    ClsProductDetail objClsProductDetail = new ClsProductDetail();
                    objClsProductDetail.ProductdetailId = item.pd_id;
                    objClsProductDetail.ProductName = item.pd_name;

                    string description = Regex.Replace(item.pd_description1, @"\<\s*br\s*\/?\s*\>", "");
                    description = description.TrimEnd();
                    objClsProductDetail.Description = description.TrimStart();
                    objClsProductDetail.CategotyId = item.pd_pc_id.Value;
                    objClsProductDetail.CategoryName = item.pc_name;
                    objClsProductDetail.CategoryDescription = item.pc_description1;
                    if (item.pd_seqno != "" && item.pd_seqno != null)
                    {
                        objClsProductDetail.SeqNo = Convert.ToInt32(item.pd_seqno);
                    }
                    objClsProductDetail.Price = Convert.ToDecimal(item.pd_base_price);

                    lstClsProductDetail.Add(objClsProductDetail);
                }
                lstClsProductDetail = lstClsProductDetail.OrderBy(x => x.SeqNo).ToList();
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductDetail.ListToDataTable();
    }

    public List<ClsProductDetail> GetProdcutPriceByProductId(int productId)
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        try
        {
            var result = (from a in dbEntities.tp_product_details
                          where a.pd_id == productId && a.pd_isdeleted == false
                          select new
                          {
                              a.pd_base_price,
                          }).ToList();
            foreach (var item in result)
            {
                ClsProductDetail objClsProductDetail = new ClsProductDetail();
                objClsProductDetail.ProductdetailId = productId;
                objClsProductDetail.BasePrice = Convert.ToDecimal(item.pd_base_price);
                lstClsProductDetail.Add(objClsProductDetail);
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductDetail;
    }

    public List<ClsProductDetail> GetProductSizeDetailByProductId(int ProductId)
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        try
        {
            var result = (from a in dbEntities.tp_product_properties
                          join b in dbEntities.tp_product_details
                          on a.pd_id equals b.pd_id
                          join c in dbEntities.tp_product_sizes
                          on a.ps_id equals c.ps_id
                          where a.pd_id == ProductId && b.pd_isdeleted == false && a.pp_isdeleted == false && c.ps_isdeleted == false
                          select new
                          {
                              a.pp_id,
                              a.ps_id,
                              a.pd_id,
                              c.ps_name,
                              a.pp_price,
                              b.pd_name
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
                    objClsProductDetail.ProductName = item.pd_name;
                    lstClsProductDetail.Add(objClsProductDetail);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductDetail;
    }

   

    //public List<ClsProductDetail> GetProductSizeDetailByProductId(int ProductId)
    //{
    //    List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
    //    try
    //    {
    //        var result = (from a in dbEntities.tp_product_details
    //                      join b in dbEntities.tp_product_properties
    //                      on a.pd_id equals b.pd_id
    //                      into JoinedPdid
    //                      from productproperties in JoinedPdid.DefaultIfEmpty()
    //                      join c in dbEntities.tp_product_sizes
    //                      on productproperties.ps_id equals c.ps_id
    //                      into JoinedPsid
    //                      from sizedetail in JoinedPsid.DefaultIfEmpty()
    //                      where a.pd_id == ProductId && a.pd_isdeleted==false && productproperties.pp_isdeleted==false
    //                      select new
    //                      {
    //                        ProductPropertiesId=(productproperties==null?0:productproperties.pp_id),


    //                          a.pd_id,

    //                          SizeId = (sizedetail == null ? 0 : sizedetail.ps_id),
    //                          SizeName = (sizedetail == null ? String.Empty : sizedetail.ps_name),
    //                         PropertiesPrice=(productproperties==null?String.Empty:productproperties.pp_price),
    //                          a.pd_base_price,

    //                      }).ToList();

    //        result = result.GroupBy(x => x.SizeId).Select(g=>g.First()).ToList();
    //        if(result!=null)
    //        {
    //            foreach(var item in result)
    //            {

    //                ClsProductDetail objClsProductDetail = new ClsProductDetail();
    //                objClsProductDetail.ProductdetailId = item.pd_id;
    //                objClsProductDetail.PropertiesId = item.ProductPropertiesId;
    //                objClsProductDetail.SizeId = item.SizeId;
    //                objClsProductDetail.SizeName=item.SizeName;
    //                if (item.SizeId == 0)
    //                {
    //                    objClsProductDetail.Price = Convert.ToDecimal(item.pd_base_price);
    //                }
    //                else
    //                {
    //                    objClsProductDetail.Price = Convert.ToDecimal(item.PropertiesPrice);
    //                }
    //                lstClsProductDetail.Add(objClsProductDetail);
    //            }
    //        }
    //    }
    //    catch(Exception ex)
    //    {
    //        ErrorHandler.WriteError(ex);
    //    }
    //    return lstClsProductDetail;
    //}

    public List<ClsProductDetail> GetIndredientFactDetailByProductId(int productId)
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        try
        {
            var result = (from a in dbEntities.tp_product_ingredient_fact_mapping
                          join b in dbEntities.tp_product_ingredient_fact_detail
                          on a.pifd_id equals b.pifd_id
                          where a.pifm_isdeleted == false && a.pd_id == productId && b.pifd_isdeleted == false
                          select new
                          {
                              a.pd_id,
                              a.pifd_id,
                              a.pifm_id,
                              b.pifd_name
                          }).ToList();

            if (result != null)
            {
                foreach (var item in result)
                {
                    ClsProductDetail objClsProductDetail = new ClsProductDetail();
                    objClsProductDetail.IngredientFactId = item.pifd_id.Value;
                    objClsProductDetail.IngredientFactName = item.pifd_name;
                    objClsProductDetail.ProductdetailId = item.pd_id.Value;
                    lstClsProductDetail.Add(objClsProductDetail);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductDetail;
    }

    public List<ClsProductDetail> GetIndredientFactDetailByIngredientId(int ingredientId)
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        try
        {
            var result = (from a in dbEntities.tp_product_ingredient_fact_mapping
                          join b in dbEntities.tp_product_ingredient_fact_detail
                          on a.pifd_id equals b.pifd_id
                          where a.pifm_isdeleted == false && a.id_id == ingredientId && b.pifd_isdeleted == false
                          select new
                          {
                              a.pd_id,
                              a.pifd_id,
                              a.pifm_id,
                              b.pifd_name
                          }).ToList();

            if (result != null)
            {
                foreach (var item in result)
                {
                    ClsProductDetail objClsProductDetail = new ClsProductDetail();
                    objClsProductDetail.IngredientFactId = item.pifd_id.Value;
                    objClsProductDetail.IngredientFactName = item.pifd_name;
                    objClsProductDetail.ProductdetailId = item.pd_id.Value;
                    lstClsProductDetail.Add(objClsProductDetail);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductDetail;
    }

    public List<ClsProductDetail> GetAllIngredient()
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        try
        {
            var result = (from a in dbEntities.tp_ingredient_details
                          where a.id_isdeleted == false
                          select new
                          {
                              a.id_id,
                              a.id_name,
                              a.id_description,
                              a.id_price
                          }).ToList();

            result = result.GroupBy(x => x.id_price).Select(x => x.First()).ToList();
            if (result != null)
            {
                foreach (var item in result)
                {
                    ClsProductDetail objClsProductDetail = new ClsProductDetail();
                    objClsProductDetail.IngredientId = item.id_id;
                    objClsProductDetail.IngredientName = item.id_name;
                    objClsProductDetail.Price = Convert.ToDecimal(item.id_price);
                    lstClsProductDetail.Add(objClsProductDetail);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductDetail;
    }

    public List<ClsProductDetail> GetAllIngredientByPrice(string price, int productId,bool isSingleIngredients)
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        try
        {
            var result = (from a in dbEntities.tp_ingredient_details
                          join b in dbEntities.tp_ingredient_product_mapping
                          on a.id_id equals b.id_id
                          where a.id_isdeleted == false && b.pd_id == productId && b.ipm_isdeleted == false && b.iipm_IsSingleIngredient == isSingleIngredients
                          select new
                          {
                              a.id_id,
                              a.id_name,
                              a.id_description,
                              a.id_price
                          }).ToList();

            if (result != null)
            {
                foreach (var item in result)
                {
                    ClsProductDetail objClsProductDetail = new ClsProductDetail();
                    objClsProductDetail.IngredientId = item.id_id;
                    objClsProductDetail.IngredientName = item.id_name;
                    objClsProductDetail.IngredientPrice = item.id_price;
                    lstClsProductDetail.Add(objClsProductDetail);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductDetail;
    }

    //Ger DISTINCT price of Ingredients
    public DataTable GetDistinctPriceOfIngredients(int productId)
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        try
        {
            var result = (from pd in dbEntities.tp_product_details
                          join ipm in dbEntities.tp_ingredient_product_mapping
                          on pd.pd_id equals ipm.pd_id
                          join id in dbEntities.tp_ingredient_details
                          on ipm.id_id equals id.id_id

                          where (pd.pd_id == productId && id.id_isdeleted == false && ipm.iipm_isDefault == false && ipm.ipm_isdeleted == false)
                          select id).ToList();
            var Result1 = result.GroupBy(x => x.id_price).Select(y => new
            {
                price = y.Key,
            }).ToList();
            foreach (var item in Result1)
            {
                ClsProductDetail objClsProductDetail = new ClsProductDetail();
                objClsProductDetail.IngredientPrice = item.price;
                objClsProductDetail.PriceOfIngredients = item.price.Replace(".", "_");

                lstClsProductDetail.Add(objClsProductDetail);
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductDetail.ListToDataTable();
    }
    //Get Product PropertyId by product id and size id
    public List<ClsProductDetail> GetPropertyId(int productId, int sizeId)
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        try
        {
            var result = (from pp in dbEntities.tp_product_properties
                          where (pp.pd_id == productId && pp.ps_id == sizeId && pp.pp_isdeleted == false)
                          select new
                          {
                              pp.pp_id,
                              pp.pp_price,

                          }).ToList();
            foreach (var item in result)
            {
                ClsProductDetail objClsProductDetail = new ClsProductDetail();
                objClsProductDetail.PropertiesId = item.pp_id;
                objClsProductDetail.PropertiesPrice = item.pp_price;
                lstClsProductDetail.Add(objClsProductDetail);
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }

        return lstClsProductDetail;
    }

    public int GetFactIdByFactName(string factName)
    {
        int factId = 0;
        try
        {
            factId = dbEntities.tp_product_ingredient_fact_detail.Where(x => x.pifd_name == factName && x.pifd_isdeleted == false).FirstOrDefault().pifd_id;
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return factId;
    }
    public string GetFactNameByFactId(int FactId)
    {
        string factName = "";
        try
        {
            factName = dbEntities.tp_product_ingredient_fact_detail.Where(x => x.pifd_id == FactId && x.pifd_isdeleted == false).FirstOrDefault().pifd_name;
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return factName;
    }
    //public List<ClsProductDetail> GetAllIngredient()
    //{
    //    List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
    //    try
    //    {
    //        var result = (from a in dbEntities.tp_ingredient_details
    //                      where a.id_isdeleted == false
    //                      select new
    //                      {
    //                          a.id_id,
    //                          a.id_name,
    //                          a.id_description,
    //                          a.id_price
    //                      }).GroupBy(x=>x.id_price).Select(x=>x.First()).ToList();
    //        if(result!=null)
    //        {
    //            foreach(var item in result)
    //            {
    //                ClsProductDetail objClsProductDetail = new ClsProductDetail();
    //                objClsProductDetail.IngredientId = item.id_id;
    //                objClsProductDetail.IngredientName = item.id_name;
    //                objClsProductDetail.Price=Convert.ToDecimal(item.id_price);
    //                lstClsProductDetail.Add(objClsProductDetail);
    //            }
    //        }           
    //    }
    //    catch(Exception ex)
    //    {
    //        ErrorHandler.WriteError(ex);
    //    }
    //    return lstClsProductDetail;
    //}

    public bool? GetCanCommentValueByProductId(int ProductId)
    {
        bool? CanComment = false;
        try
        {
            CanComment = dbEntities.tp_product_details.Where(x => x.pd_id == ProductId && x.pd_isdeleted == false).FirstOrDefault().pd_can_comment;
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return CanComment;
    }

    public bool? GetCommentCompulsoryValueByProductId(int ProductId)
    {
        bool? CanComment = false;
        try
        {
            CanComment = dbEntities.tp_product_details.Where(x => x.pd_id == ProductId && x.pd_isdeleted == false).FirstOrDefault().pd_Is_Commant_Compulsary;
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return CanComment;
    }

    //Get All Ingredient use in Product(Menu Item)
    public List<ClsProductDetail> GetAllSingleIngredientMappingInformation(int Id)
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        try
        {
            var result = (from ipm in dbEntities.tp_ingredient_product_mapping
                          join id in dbEntities.tp_ingredient_details
                          on ipm.id_id equals id.id_id
                          where ipm.pd_id == Id && id.id_isdeleted == false && ipm.ipm_isdeleted == false
                          select new
                          {
                              ipm.iipm_IsSingleIngredient,
                              id.id_name,
                              ipm.id_id
                          }).ToList();

            if (result != null)
            {
                foreach (var item in result)
                {
                    ClsProductDetail objClsProductDetail = new ClsProductDetail();
                    objClsProductDetail.IngredientId = item.id_id.Value;
                    objClsProductDetail.IngredientName = item.id_name;
                    objClsProductDetail.IsSingleIngredient = item.iipm_IsSingleIngredient;
                    lstClsProductDetail.Add(objClsProductDetail);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductDetail;
    }

    public tp_ingredient_product_mapping GetSingleIngredientInformation(int productId, int ingredientId)
    {
        tp_ingredient_product_mapping objtpIngredientInformation = new tp_ingredient_product_mapping();

        try
        {
            objtpIngredientInformation = dbEntities.tp_ingredient_product_mapping.Where(x => x.id_id == ingredientId && x.pd_id == productId).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objtpIngredientInformation;
    }
}