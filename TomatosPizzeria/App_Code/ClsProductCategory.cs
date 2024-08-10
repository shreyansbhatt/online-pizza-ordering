using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClsProductCategory
/// </summary>
public class ClsProductCategory
{
    TP_DatabaseEntities dbEntities = new TP_DatabaseEntities();
    public ClsProductCategory()
    {

    }
    #region Properties

    private int m_productCategoryId;
    private int m_pcStoreId;
    private int m_seqNo;
    private string m_productCategoryName;
    private int m_parent;
    private string m_description;
    private string m_imageUrl;

    private int m_ingredientId;
    private string m_ingredientName;
    private string m_ingredientPrice;


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

    public string ProductCategoryName
    {
        get
        {
            return m_productCategoryName;
        }

        set
        {
            m_productCategoryName = value;
        }
    }

    public int Parent
    {
        get
        {
            return m_parent;
        }

        set
        {
            m_parent = value;
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

    public int PcStoreId
    {
        get
        {
            return m_pcStoreId;
        }

        set
        {
            m_pcStoreId = value;
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

    //Insert New Product category
    public string InsertNewProductCategory(int storeId,string seqNo, string productCategoryName, int parent, string description, string imageUrl, List<ClsCategoryIngredientMapping> lstCategoryIngredientMapping, int userId)
    {
        int retValue = 0;
        int productCategoryId = 0;
        string retMsg = "FAIL";

        try
        {

            tp_product_category dbObjInsertProductCategory = new tp_product_category();
            dbObjInsertProductCategory.pc_sd_id = storeId;
            dbObjInsertProductCategory.pc_seqno = seqNo;
            dbObjInsertProductCategory.pc_name = productCategoryName;
            dbObjInsertProductCategory.pc_parent = parent;
            dbObjInsertProductCategory.pc_description1 = description;
            dbObjInsertProductCategory.pc_image_url = imageUrl;
            dbObjInsertProductCategory.pc_isdeleted = false;

            dbObjInsertProductCategory.createdby = userId;
            dbObjInsertProductCategory.modifiedby = userId;
            dbObjInsertProductCategory.createdon = DateTime.Now;
            dbObjInsertProductCategory.modifiedon = DateTime.Now;


            dbEntities.tp_product_category.Add(dbObjInsertProductCategory);
          
            retValue = dbEntities.SaveChanges();

            if (retValue == 1)
            {
                retMsg = "SUCCESS";

                productCategoryId = dbObjInsertProductCategory.pc_id;

                foreach (var item in lstCategoryIngredientMapping)
                {
                    tp_ingredient_category_mapping objTPIngredientCategoryInformation = new tp_ingredient_category_mapping();
                    objTPIngredientCategoryInformation.pc_id = productCategoryId;
                    objTPIngredientCategoryInformation.id_id = item.IngredientId;
                    objTPIngredientCategoryInformation.icm_isdeleted = false;
                    objTPIngredientCategoryInformation.createdby = userId;
                    objTPIngredientCategoryInformation.modifiedby = userId;
                    objTPIngredientCategoryInformation.createdon = DateTime.Now;
                    objTPIngredientCategoryInformation.modifiedon = DateTime.Now;


                    dbEntities.tp_ingredient_category_mapping.Add(objTPIngredientCategoryInformation);
                    retValue = dbEntities.SaveChanges();


                    //tp_ingredient_details objIngredientDetail = new tp_ingredient_details();
                    //objIngredientDetail = dbEntities.tp_ingredient_details.Where(x => x.id_id == item.IngredientId).FirstOrDefault();
                    //objIngredientDetail.id_price = item.IngredientPrice;
                    //dbEntities.SaveChanges();
                }
            }

        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }

        return retMsg;
    }


    //Update Product Category
    public string UpdateProductCategory(int productCategoryId, int storeId, string seqNo, string productCategoryName, int parent, string description, string imageUrl, List<ClsCategoryIngredientMapping> lstCategoryIngredientMappingAll, List<ClsCategoryIngredientMapping> lstCategoryIngredientMapping, int userId)
    {
        int retValue = 0;
        int CategoryId = 0;
        string retMsg = "FAIL";

        try
        {
            tp_product_category dbObjUpdateProductCategory = null;
            dbObjUpdateProductCategory = dbEntities.tp_product_category.Where(P => P.pc_id == productCategoryId).FirstOrDefault();

            dbObjUpdateProductCategory.pc_sd_id = storeId;
            dbObjUpdateProductCategory.pc_seqno = seqNo;
            dbObjUpdateProductCategory.pc_name = productCategoryName;
            dbObjUpdateProductCategory.pc_parent = parent;
            dbObjUpdateProductCategory.pc_description1 = description;
            dbObjUpdateProductCategory.pc_image_url = imageUrl;
            dbObjUpdateProductCategory.pc_isdeleted = false;


            dbObjUpdateProductCategory.modifiedby = userId;

            dbObjUpdateProductCategory.modifiedon = DateTime.Now;

            retValue = dbEntities.SaveChanges();
            //if (retValue == 1)
            //{
                retMsg = "SUCCESS";



                CategoryId = dbObjUpdateProductCategory.pc_id;

                foreach (var item in lstCategoryIngredientMappingAll)
                {
                    tp_ingredient_category_mapping objTPIngredientCategoryInformation = new tp_ingredient_category_mapping();
                    objTPIngredientCategoryInformation = dbEntities.tp_ingredient_category_mapping.Where(x => x.pc_id == productCategoryId && x.id_id == item.IngredientId).FirstOrDefault();
                    if (objTPIngredientCategoryInformation != null)
                    {
                        objTPIngredientCategoryInformation.icm_isdeleted = true;
                        retValue = dbEntities.SaveChanges();
                    }
                }

                foreach (var item in lstCategoryIngredientMapping)
                {
                    tp_ingredient_category_mapping objTPIngredientCategoryInformation = new tp_ingredient_category_mapping();
                    objTPIngredientCategoryInformation = dbEntities.tp_ingredient_category_mapping.Where(x => x.pc_id == productCategoryId && x.id_id == item.IngredientId).FirstOrDefault();
                    if (objTPIngredientCategoryInformation != null)
                    {
                        objTPIngredientCategoryInformation.pc_id = CategoryId;
                        objTPIngredientCategoryInformation.id_id = item.IngredientId;
                        objTPIngredientCategoryInformation.icm_isdeleted = false;
                        objTPIngredientCategoryInformation.createdby = userId;
                        objTPIngredientCategoryInformation.modifiedby = userId;
                        objTPIngredientCategoryInformation.createdon = DateTime.Now;
                        objTPIngredientCategoryInformation.modifiedon = DateTime.Now;

                        retValue = dbEntities.SaveChanges();

                    //    tp_ingredient_details objIngredientDetail = new tp_ingredient_details();
                    //    objIngredientDetail = dbEntities.tp_ingredient_details.Where(x => x.id_id == item.IngredientId).FirstOrDefault();
                    //    objIngredientDetail.id_price = item.IngredientPrice;
                    //dbEntities.SaveChanges();

                    }
                    else
                    {
                    tp_ingredient_category_mapping TPIngredientCategoryInformation = new tp_ingredient_category_mapping();
                    TPIngredientCategoryInformation.pc_id = productCategoryId;
                    TPIngredientCategoryInformation.id_id = item.IngredientId;
                    TPIngredientCategoryInformation.icm_isdeleted = false;
                    TPIngredientCategoryInformation.createdby = userId;
                    TPIngredientCategoryInformation.modifiedby = userId;
                    TPIngredientCategoryInformation.createdon = DateTime.Now;
                    TPIngredientCategoryInformation.modifiedon = DateTime.Now;


                    dbEntities.tp_ingredient_category_mapping.Add(TPIngredientCategoryInformation);
                    retValue = dbEntities.SaveChanges();


                    //tp_ingredient_details objIngredientDetail = new tp_ingredient_details();
                    //objIngredientDetail = dbEntities.tp_ingredient_details.Where(x => x.id_id == item.IngredientId).FirstOrDefault();
                    //objIngredientDetail.id_price = item.IngredientPrice;
                    //dbEntities.SaveChanges();
                }
                }
           // }

        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }

        return retMsg;
    }

    //Delete Product Category
    public string DeleteProductCategory(int productCategoryId)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {
            tp_product_category dbObjDeleteProductCategory = null;
            dbObjDeleteProductCategory = dbEntities.tp_product_category.Where(P => P.pc_id == productCategoryId).FirstOrDefault();

            dbObjDeleteProductCategory.pc_isdeleted = true;
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


    //Check if Product Category already exits
    public bool isProductCategoryExist(string productCategoryName)
    {
        bool retValue = false;
        try
        {
            tp_product_category result = dbEntities.tp_product_category.Where(P => P.pc_name.ToLower().Equals(productCategoryName, StringComparison.InvariantCultureIgnoreCase) && P.pc_isdeleted == false).FirstOrDefault();
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

    //Get ProductCategoryList by productCategoryId
    public List<tp_product_category> GetProductCategoryListByProductCategoryId(int productCategoryId)
    {
        List<tp_product_category> lstProductCategoryList = new List<tp_product_category>();

        try
        {
            lstProductCategoryList = dbEntities.tp_product_category.Where(P => P.pc_id == productCategoryId && P.pc_isdeleted == false).ToList<tp_product_category>();

        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }

        return lstProductCategoryList;
    }

    //Get ProductCategoryList by productCategoryName
    public DataTable GetProductCategoryList(string searchText = null)
    {


        List<tp_product_category> lstProductCategoryList = new List<tp_product_category>();
        List<ClsProductCategory> lstClsProductCategory = new List<ClsProductCategory>();
        try
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                lstProductCategoryList = dbEntities.tp_product_category.Where(P => P.pc_name.Contains(searchText) && P.pc_isdeleted == false).ToList<tp_product_category>();

                foreach (var item in lstProductCategoryList)
                {
                    ClsProductCategory objClsProductCategory = new ClsProductCategory();
                    objClsProductCategory.ProductCategoryId = item.pc_id;
                    if (item.pc_seqno != "" && item.pc_seqno != null)
                    {
                        objClsProductCategory.SeqNo =Convert.ToInt32 (item.pc_seqno);
                    }
                    objClsProductCategory.ProductCategoryName = item.pc_name;
                    objClsProductCategory.Description = item.pc_description1;
                    objClsProductCategory.Parent = Convert.ToInt32(item.pc_parent);
                     objClsProductCategory.ImageUrl = dbEntities.tp_config.Where(x => x.tpc_key == "MENU_CATEGORY_IMAGE_URL").FirstOrDefault().tpc_value.Replace("~", "") + item.pc_image_url;

                    lstClsProductCategory.Add(objClsProductCategory);
                }
            }
            else
            {
                lstProductCategoryList = dbEntities.tp_product_category.Where(P => P.pc_isdeleted == false).ToList<tp_product_category>();
                foreach (var item in lstProductCategoryList)
                {
                    ClsProductCategory objClsProductCategory = new ClsProductCategory();
                    objClsProductCategory.ProductCategoryId = item.pc_id;
                    if (item.pc_seqno != "" && item.pc_seqno != null)
                    {
                        objClsProductCategory.SeqNo = Convert.ToInt32(item.pc_seqno);
                    }
                    objClsProductCategory.ProductCategoryName = item.pc_name;
                    objClsProductCategory.Description = item.pc_description1;
                    objClsProductCategory.Parent = Convert.ToInt32(item.pc_parent);
                    objClsProductCategory.ImageUrl = dbEntities.tp_config.Where(x => x.tpc_key == "MENU_CATEGORY_IMAGE_URL").FirstOrDefault().tpc_value.Replace("~", "") + item.pc_image_url;

                    lstClsProductCategory.Add(objClsProductCategory);
                }
            }
            lstClsProductCategory = lstClsProductCategory.OrderBy(x => x.SeqNo).ToList();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductCategory.ListToDataTable();
    }

    //Get Ingredient Details of Product Category

    public DataTable GetProductCategoryListByIngredient(int productCategoryId)
    {
       

        List<ClsProductCategory> lstClsProductCategory = new List<ClsProductCategory>();

        try
        {
            var result = (from icm in dbEntities.tp_ingredient_category_mapping
                          join id in dbEntities.tp_ingredient_details
                          on icm.id_id equals id.id_id
                          where icm.pc_id==productCategoryId && id.id_isdeleted==false && icm.icm_isdeleted==false
                          select new
                          {
                             id.id_name,
                             id.id_price
                          }).ToList();

            foreach (var item in result)
            {
                ClsProductCategory objClsProductCategory = new ClsProductCategory();
                objClsProductCategory.IngredientName = item.id_name;
                objClsProductCategory.IngredientPrice = item.id_price;

                lstClsProductCategory.Add(objClsProductCategory);
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductCategory.ListToDataTable();

       
    }
    public ClsProductCategory GetCategoryInformation(int productCategoryId)
    {
        ClsProductCategory objClsProductCategory = new ClsProductCategory();
        try
        {
            //var result=(from icm in dbEntities.tp_ingredient_category_mapping
            //            join id in dbEntities.tp_ingredient_details
            //            on icm.id_id equals id.id_id
            //            join pc in dbEntities.tp_product_category
            //            on icm.pc_id equals pc.pc_id
            //            where icm.pc_id == productCategoryId && id.id_isdeleted == false && icm.icm_isdeleted==false
            //            select new
            //            {
            //                pc,
            //                id.id_id,
            //                id.id_name,
            //                id.id_price
            //            }).FirstOrDefault();
            var result = dbEntities.tp_product_category.Where(x => x.pc_id == productCategoryId && x.pc_isdeleted == false).FirstOrDefault();

            if (result!=null)
            {
                if (result.pc_seqno != "" && result.pc_seqno != null)
                {
                    objClsProductCategory.SeqNo = Convert.ToInt32(result.pc_seqno);
                }
                objClsProductCategory.ProductCategoryName = result.pc_name;
                objClsProductCategory.Description = result.pc_description1;
                objClsProductCategory.Parent = Convert.ToInt32(result.pc_parent);
                objClsProductCategory.ImageUrl = dbEntities.tp_config.Where(x => x.tpc_key == "MENU_CATEGORY_IMAGE_URL").FirstOrDefault().tpc_value.Replace("~", "") + result.pc_image_url;

                //objClsProductCategory.IngredientId = result.id_id;
                //objClsProductCategory.IngredientName = result.id_name;
                //objClsProductCategory.IngredientPrice = result.id_price;

            }
        }
        catch(Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objClsProductCategory;
    }

    public List<ClsProductCategory> GetAllIngredientMappingInformation(int Id)
    {
        List<ClsProductCategory> lstClsProductCategory = new List<ClsProductCategory>();
        try
        {
            var result = (from icm in dbEntities.tp_ingredient_category_mapping
                          join id in dbEntities.tp_ingredient_details
                          on icm.id_id equals id.id_id
                          where icm.pc_id == Id && id.id_isdeleted == false && icm.icm_isdeleted==false
                          select new
                          {
                              id.id_price,
                             id.id_name,
                             icm.id_id
                          }).ToList();

            if (result != null)
            {
                foreach (var item in result)
                {
                    ClsProductCategory objClsProductCategory = new ClsProductCategory();
                    objClsProductCategory.IngredientId = item.id_id.Value;
                    objClsProductCategory.IngredientName = item.id_name;
                    objClsProductCategory.IngredientPrice = item.id_price;
                    lstClsProductCategory.Add(objClsProductCategory);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductCategory;
    }

    public DataTable GetAllIngredients()
    {
        List<ClsProductCategory> lstClsProductCategory = new List<ClsProductCategory>();
        List<tp_ingredient_details> lsttp_ingredient_details = new List<tp_ingredient_details>();
        try
        {
            lsttp_ingredient_details = dbEntities.tp_ingredient_details.Where(x => x.id_isdeleted == false).ToList();
            if (lsttp_ingredient_details.Count > 0)
            {
                foreach (var item in lsttp_ingredient_details)
                {
                    ClsProductCategory objClsProductCategory = new ClsProductCategory();
                    objClsProductCategory.IngredientId = item.id_id;
                    objClsProductCategory.IngredientName = item.id_name;
                    objClsProductCategory.IngredientPrice = item.id_price;
                    lstClsProductCategory.Add(objClsProductCategory);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductCategory.ListToDataTable();
    }
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
    public tp_config GetMenuCategoryImgUrl()
    {
        tp_config objfda_config = new tp_config();
        try
        {

            objfda_config = dbEntities.tp_config.Where(x => x.tpc_key == "MENU_CATEGORY_IMAGE_URL").FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objfda_config;
    }
}