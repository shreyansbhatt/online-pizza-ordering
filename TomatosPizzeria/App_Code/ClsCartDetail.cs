using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClsCartDetail
/// </summary>
public class ClsCartDetail
{
    TP_DatabaseEntities dbEntities = new TP_DatabaseEntities();
    public ClsCartDetail()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private int m_CartId;
    private int m_ProductId;
    private int m_ui_id;
    private int m_productIngredientFatDetail_id;
    private int m_SizeId;
    private int m_Quantity;
    private decimal m_TakeAwayPrice;
    private int m_IngredientId;
    private string m_ProductName;
    private string m_IngredientName;
    private string m_ingredientPrice;
    private string m_IngredientFactName;
    private string m_SizeName;
    private string m_UserName;

    public int CartId
    {
        get { return m_CartId; }
        set { m_CartId = value; }
    }

    public int ProductId
    {
        get { return m_ProductId; }
        set { m_ProductId = value; }
    }

    public int Ui_id
    {
        get { return m_ui_id; }
        set { m_ui_id = value; }
    }

    public int ProductIngredientFatDetail_id
    {
        get { return m_productIngredientFatDetail_id; }
        set { m_productIngredientFatDetail_id = value; }
    }

    public int SizeId
    {
        get { return m_SizeId; }
        set { m_SizeId = value; }
    }

    public int Quantity
    {
        get { return m_Quantity; }
        set { m_Quantity = value; }
    }

    public decimal TakeAwayPrice
    {
        get { return m_TakeAwayPrice; }
        set { m_TakeAwayPrice = value; }
    }

    public int IngredientId
    {
        get { return m_IngredientId; }
        set { m_IngredientId = value; }
    }

    public string ProductName
    {
        get { return m_ProductName; }
        set { m_ProductName = value; }
    }

    public string IngredientName
    {
        get { return m_IngredientName; }
        set { m_IngredientName = value; }
    }

    public string IngredientFactName
    {
        get { return m_IngredientFactName; }
        set { m_IngredientFactName = value; }
    }

    public string SizeName
    {
        get { return m_SizeName; }
        set { m_SizeName = value; }
    }

    public string UserName
    {
        get { return m_UserName; }
        set { m_UserName = value; }
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

    public int GetNumberOfFreeIngredient(int productID)
    {
        int noOfFreeIngredient = 0;
        noOfFreeIngredient = dbEntities.tp_product_details.Where(P => P.pd_id == productID).FirstOrDefault().no_free_ingredients;
        return noOfFreeIngredient;
    }

    public string InsertCartDetail(int productId, int userId, int sizeId, int propertyId, int quantity, string price, int FactId, string randomNumber, List<ClsCartDetail> lstClsCartDetail, string Comment)
    {
        int retValue = 0, retValue1 = 0;
        // int cartId = 0;
        string retMsg = "FAIL";
       // int numberOfFreeIng = 0;

        try
        {
            // if (isUserExist(userName))
            //return -1;
            //numberOfFreeIng = dbEntities.tp_product_details.Where(P => P.pd_id == productId).FirstOrDefault().no_free_ingredients;
            tp_cart_detail dbObjtp_cart_detail = new tp_cart_detail();
            dbObjtp_cart_detail.cd_pi_id = productId;
            dbObjtp_cart_detail.cd_ui_id = userId;
            dbObjtp_cart_detail.cd_si_id = sizeId;
            dbObjtp_cart_detail.cd_pp_id = propertyId;
            dbObjtp_cart_detail.cd_quantity = quantity;
            dbObjtp_cart_detail.cd_takeaway_price = price;
            dbObjtp_cart_detail.cd_pifd_id = FactId;
            dbObjtp_cart_detail.cd_random_number = randomNumber;
            dbObjtp_cart_detail.cd_comment = Comment;

            dbObjtp_cart_detail.cd_isdeleted = false;

            dbObjtp_cart_detail.createdby = userId;
            dbObjtp_cart_detail.modifiedby = userId;
            dbObjtp_cart_detail.createdon = DateTime.Now;
            dbObjtp_cart_detail.modifiedon = DateTime.Now;

            dbEntities.tp_cart_detail.Add(dbObjtp_cart_detail);
            retValue = dbEntities.SaveChanges();
            if (lstClsCartDetail != null)
            {
                if (lstClsCartDetail.Count > 0)
                {
                    //int count = 0;
                    foreach (var item in lstClsCartDetail)
                    {
                        tp_cart_ingredient_mapping objtp_cart_ingredient_mapping = new tp_cart_ingredient_mapping();
                        objtp_cart_ingredient_mapping.cim_cd_id = dbObjtp_cart_detail.cd_id;
                        objtp_cart_ingredient_mapping.cim_id_id = item.IngredientId;
                        objtp_cart_ingredient_mapping.cim_id_price = item.IngredientPrice;
                        objtp_cart_ingredient_mapping.cim_isdeleted = false;

                        objtp_cart_ingredient_mapping.createdby = userId;
                        objtp_cart_ingredient_mapping.modifiedby = userId;
                        objtp_cart_ingredient_mapping.createdon = DateTime.Now;
                        objtp_cart_ingredient_mapping.modifiedon = DateTime.Now;
                        objtp_cart_ingredient_mapping.cim_fact_id = item.ProductIngredientFatDetail_id;

                        dbEntities.tp_cart_ingredient_mapping.Add(objtp_cart_ingredient_mapping);
                        retValue1 = dbEntities.SaveChanges();
                      //  count++;
                    }
                }
            }
            if (retValue > 0 || retValue1 > 0)
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

    public string UpdateCartDetail(int cartId, int productId, int userId, int sizeId, int propertyId, int quantity, string price, int FactId, string randomNumber)
    {
        int retValue = 0;

        string retMsg = "FAIL";

        try
        {

            tp_cart_detail dbObjtp_cart_detail = null;
            dbObjtp_cart_detail = dbEntities.tp_cart_detail.Where(x => x.cd_id == cartId && x.cd_isdeleted == false).FirstOrDefault();
            if (dbObjtp_cart_detail != null)
            {
                dbObjtp_cart_detail.cd_pi_id = productId;
                dbObjtp_cart_detail.cd_ui_id = userId;
                dbObjtp_cart_detail.cd_si_id = sizeId;
                dbObjtp_cart_detail.cd_pp_id = propertyId;
                dbObjtp_cart_detail.cd_quantity = quantity;
                dbObjtp_cart_detail.cd_takeaway_price = price;
                dbObjtp_cart_detail.cd_pifd_id = FactId;
                dbObjtp_cart_detail.cd_random_number = randomNumber;


                dbObjtp_cart_detail.cd_isdeleted = false;

                dbObjtp_cart_detail.createdby = userId;
                dbObjtp_cart_detail.modifiedby = userId;
                dbObjtp_cart_detail.createdon = DateTime.Now;
                dbObjtp_cart_detail.modifiedon = DateTime.Now;
            }

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

    public string UpdateCommentByCartId(int CartId, string Comment)
    {
        int retValue = 0;
        string retMsg = "FAIL";
        try
        {
            tp_cart_detail dbObjtp_cart_detail = null;
            dbObjtp_cart_detail = dbEntities.tp_cart_detail.Where(x => x.cd_id == CartId && x.cd_isdeleted == false).FirstOrDefault();
            if (dbObjtp_cart_detail != null)
            {
                dbObjtp_cart_detail.cd_comment = Comment;
            }
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
    //public List<ClsCartDetail> GetCartDetail()
    //{
    //    List<ClsCartDetail> lstClsCartDetail = new List<ClsCartDetail>();
    //    try
    //    {
    //        var result = (from a in dbEntities.tp_cart_detail
    //                      join b in dbEntities.tp_product_details
    //                      on a.cd_pi_id equals b.pd_id
    //                      join c in dbEntities.tp_product_ingredient_fact_detail
    //                      on a.cd_pifd_id equals c.pifd_id
    //                      join d in dbEntities.tp_product_sizes
    //                      on a.cd_si_id equals d.ps_id
    //                      join e in dbEntities.tp_cart_ingredient_mapping
    //                      on a.cd_id equals e.cim_cd_id
    //                      join f in dbEntities.tp_ingredient_details
    //                      on e.cim_id_id equals f.id_id
    //                      where a.cd_isdeleted == false && b.pd_isdeleted == false && c.pifd_isdeleted == false && d.ps_isdeleted == false
    //                      && e.cim_isdeleted == false && f.id_isdeleted == false
    //                      select new
    //                      {
    //                          a.cd_id,
    //                          a.cd_quantity,
    //                          a.cd_takeaway_price,
    //                          a.cd_pifd_id,
    //                          a.cd_pi_id,
    //                          a.cd_si_id,
    //                          b.pd_name,
    //                          c.pifd_name,
    //                          d.ps_name,
    //                          e.cim_id,
    //                          f.id_price,
    //                          f.id_name,
    //                          f.id_id
    //                      }).ToList();

    //        foreach (var item in result)
    //        {
    //            ClsCartDetail objClsCartDetail = new ClsCartDetail();
    //            objClsCartDetail.CartId = item.cd_id;
    //            objClsCartDetail.ProductId = item.cd_pi_id.Value;
    //            objClsCartDetail.ProductIngredientFatDetail_id = item.cd_pifd_id.Value;
    //            objClsCartDetail.SizeId = item.cd_si_id.Value;
    //            objClsCartDetail.IngredientFactName = item.pifd_name;
    //            objClsCartDetail.SizeName = item.ps_name;
    //            objClsCartDetail.Quantity = item.cd_quantity.Value;
    //            objClsCartDetail.TakeAwayPrice = Convert.ToDecimal(item.cd_takeaway_price);
    //            objClsCartDetail.ProductName = item.pd_name;
    //            objClsCartDetail.IngredientId = item.id_id;
    //            objClsCartDetail.IngredientName = item.id_name;
    //            lstClsCartDetail.Add(objClsCartDetail);
    //        }

    //        var result1 = lstClsCartDetail.GroupBy(x => new
    //        {
    //            x.CartId,
    //            x.ProductId,
    //            x.ProductIngredientFatDetail_id,
    //            x.Quantity,
    //            x.SizeId,
    //            x.TakeAwayPrice,
    //            x.ProductName,
    //            x.IngredientFactName,
    //            x.SizeName
    //        }).Select(y => new
    //        {
    //            Productid = y.Key.ProductId,
    //            Cartid = y.Key.CartId,
    //            Factid = y.Key.Quantity,
    //            sizeid = y.Key.SizeId,
    //            Price = y.Key.TakeAwayPrice,
    //            quantity = y.Key.Quantity,
    //            ProductName = y.Key.ProductName,
    //            FactName = y.Key.IngredientFactName,
    //            SizeName = y.Key.SizeName,
    //            IngredientName = y.Aggregate((a, b) => new ClsCartDetail { IngredientName = (a.IngredientName + "," + b.IngredientName) }).IngredientName
    //        }).ToList();

    //        foreach (var item in result1)
    //        {
    //            ClsCartDetail objClsCartDetail = new ClsCartDetail();
    //            objClsCartDetail.CartId = item.Cartid;
    //            objClsCartDetail.IngredientName = item.IngredientName;
    //            objClsCartDetail.IngredientFactName = item.FactName;
    //            objClsCartDetail.SizeName = item.SizeName;
    //            objClsCartDetail.Quantity = item.quantity;
    //            objClsCartDetail.TakeAwayPrice = Convert.ToDecimal(item.Price);
    //            objClsCartDetail.ProductName = item.ProductName;
    //            lstClsCartDetail.Add(objClsCartDetail);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        ErrorHandler.WriteError(ex);
    //    }

    //    return lstClsCartDetail;
    //}


    public List<ClsProductDetail> GetCartDetail(int UserId, string RandomNumber)
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        try
        {
            if (UserId != 0)
            {
                var result = (from a in dbEntities.tp_cart_detail
                              join b in dbEntities.tp_product_details
                              on a.cd_pi_id equals b.pd_id
                              join c in dbEntities.tp_product_sizes
                              on a.cd_si_id equals c.ps_id
                               into JoinedPsid
                              from sizedetail in JoinedPsid.DefaultIfEmpty()
                              join f in dbEntities.tp_product_ingredient_fact_detail
                              on a.cd_pifd_id equals f.pifd_id
                              into JoinedPifdid
                              from factdetail in JoinedPifdid.DefaultIfEmpty()
                              where a.cd_ui_id == UserId && a.cd_isdeleted == false && b.pd_isdeleted == false

                              select new
                              {
                                  a.cd_id,
                                  a.cd_pi_id,
                                  a.cd_ui_id,
                                  a.cd_comment,
                                  SizeId = (sizedetail == null ? 0 : sizedetail.ps_id),
                                  SizeName = (sizedetail == null ? String.Empty : sizedetail.ps_name),
                                  a.cd_quantity,
                                  a.cd_takeaway_price,
                                  FactId = (factdetail == null ? 0 : factdetail.pifd_id),
                                  FactName = (factdetail == null ? String.Empty : factdetail.pifd_name),
                                  b.pd_name,
                                  b.pd_base_price,
                                  b.pd_can_comment,
                                  a.cd_pp_id,

                              }).ToList();

                if (result != null)
                {
                    //  result = result.GroupBy(x => new { x.SizeId, x.cd_pi_id,x.FactId }).Select(g => g.First()).ToList();

                    foreach (var item in result)
                    {
                        if (lstClsProductDetail.Count == 0)
                        {
                            ClsProductDetail objClsProductDetail = new ClsProductDetail();
                            objClsProductDetail.CartId = item.cd_id;
                            objClsProductDetail.SizeId = item.SizeId;
                            objClsProductDetail.ProductdetailId = item.cd_pi_id.Value;
                            objClsProductDetail.PropertiesId = item.cd_pp_id.Value;
                            objClsProductDetail.IngredientFactId = item.FactId;
                            objClsProductDetail.ProductName = item.pd_name;
                            objClsProductDetail.Quantity = item.cd_quantity.Value;
                            objClsProductDetail.Price = Convert.ToDecimal(item.cd_takeaway_price);
                            objClsProductDetail.CanComment = item.pd_can_comment;
                            objClsProductDetail.Comment = item.cd_comment;
                            objClsProductDetail.OneQuantityPrice = Convert.ToDecimal(item.cd_takeaway_price) / objClsProductDetail.Quantity;
                            if (item.SizeId == 0)
                            {

                                objClsProductDetail.SizeName = "-";
                            }
                            else
                            {

                                objClsProductDetail.SizeName = item.SizeName;
                            }
                            var result1 = (from a in dbEntities.tp_ingredient_details
                                           join b in dbEntities.tp_ingredient_product_mapping
                                           on a.id_id equals b.id_id
                                           where b.pd_id == item.cd_pi_id && a.id_isdeleted == false && b.iipm_isDefault == true
                                           select new
                                           {
                                               a.id_id,
                                               a.id_name,
                                               a.id_price
                                           }).ToList();
                            foreach (var item1 in result1)
                            {
                                if (objClsProductDetail.DefaultIngredientName == null)
                                {
                                    objClsProductDetail.DefaultIngredientName = item1.id_name;
                                }
                                else
                                {
                                    objClsProductDetail.DefaultIngredientName = objClsProductDetail.DefaultIngredientName + "," + item1.id_name;
                                }

                                if (objClsProductDetail.DefaultIngredientId == null)
                                {
                                    objClsProductDetail.DefaultIngredientId = item1.id_id.ToString();
                                }
                                else
                                {
                                    objClsProductDetail.DefaultIngredientId = objClsProductDetail.DefaultIngredientId.ToString() + "," + item1.id_id;
                                }

                                //objClsProductDetail.OneQuantityPrice = Convert.ToDecimal(item1.id_price) + objClsProductDetail.OneQuantityPrice;
                            }
                            lstClsProductDetail.Add(objClsProductDetail);

                        }

                        else
                        {
                            bool flag = false;
                            foreach (var itemlst in lstClsProductDetail)
                            {
                                if (item.cd_pi_id == itemlst.ProductdetailId && item.SizeId == itemlst.SizeId && item.FactId == itemlst.IngredientFactId)
                                {
                                    var result1 = (from cim in dbEntities.tp_cart_ingredient_mapping
                                                   join id in dbEntities.tp_ingredient_details
                                                      on cim.cim_id_id equals id.id_id
                                                   where cim.cim_isdeleted == false && id.id_isdeleted == false && cim.cim_cd_id == item.cd_id
                                                   select new
                                                   {
                                                       id.id_id,
                                                       id.id_name,
                                                       id.id_price
                                                   }).ToList();
                                    ClsProductDetail objitemClsProductDetail = new ClsProductDetail();
                                    foreach (var item1 in result1)
                                    {

                                        if (objitemClsProductDetail.ExtraIngredientId == null)
                                        {
                                            objitemClsProductDetail.ExtraIngredientId = item1.id_id.ToString();
                                        }
                                        else
                                        {
                                            objitemClsProductDetail.ExtraIngredientId = objitemClsProductDetail.ExtraIngredientId + "," + item1.id_id;
                                        }
                                    }

                                    var result11 = (from cim in dbEntities.tp_cart_ingredient_mapping
                                                    join id in dbEntities.tp_ingredient_details
                                                       on cim.cim_id_id equals id.id_id
                                                    where cim.cim_isdeleted == false && id.id_isdeleted == false && cim.cim_cd_id == itemlst.CartId
                                                    select new
                                                    {
                                                        id.id_id,
                                                        id.id_name,
                                                        id.id_price
                                                    }).ToList();
                                    ClsProductDetail objitemlstClsProductDetail = new ClsProductDetail();
                                    foreach (var item11 in result11)
                                    {

                                        if (objitemlstClsProductDetail.ExtraIngredientId == null)
                                        {
                                            objitemlstClsProductDetail.ExtraIngredientId = item11.id_id.ToString();
                                        }
                                        else
                                        {
                                            objitemlstClsProductDetail.ExtraIngredientId = objitemlstClsProductDetail.ExtraIngredientId + "," + item11.id_id;
                                        }
                                    }

                                    if (objitemClsProductDetail.ExtraIngredientId == objitemlstClsProductDetail.ExtraIngredientId)
                                    {
                                        flag = true;
                                    }
                                }
                            }
                            if (flag == false)
                            {
                                ClsProductDetail objClsProductDetail = new ClsProductDetail();
                                objClsProductDetail.CartId = item.cd_id;
                                objClsProductDetail.SizeId = item.SizeId;
                                objClsProductDetail.ProductdetailId = item.cd_pi_id.Value;
                                objClsProductDetail.PropertiesId = item.cd_pp_id.Value;
                                objClsProductDetail.IngredientFactId = item.FactId;
                                objClsProductDetail.ProductName = item.pd_name;
                                objClsProductDetail.Quantity = item.cd_quantity.Value;
                                objClsProductDetail.Price = Convert.ToDecimal(item.cd_takeaway_price);
                                objClsProductDetail.SizeName = item.SizeName;
                                objClsProductDetail.CanComment = item.pd_can_comment;
                                objClsProductDetail.Comment = item.cd_comment;
                                objClsProductDetail.OneQuantityPrice = Convert.ToDecimal(item.cd_takeaway_price) / objClsProductDetail.Quantity;
                                if (item.SizeId == 0)
                                {

                                    objClsProductDetail.SizeName = "-";
                                }
                                else
                                {

                                    objClsProductDetail.SizeName = item.SizeName;
                                }
                                var result1 = (from a in dbEntities.tp_ingredient_details
                                               join b in dbEntities.tp_ingredient_product_mapping
                                               on a.id_id equals b.id_id
                                               where b.pd_id == item.cd_pi_id && a.id_isdeleted == false && b.iipm_isDefault == true
                                               select new
                                               {
                                                   a.id_id,
                                                   a.id_name,
                                                   a.id_price
                                               }).ToList();
                                foreach (var item1 in result1)
                                {
                                    if (objClsProductDetail.DefaultIngredientName == null)
                                    {
                                        objClsProductDetail.DefaultIngredientName = item1.id_name;
                                    }
                                    else
                                    {
                                        objClsProductDetail.DefaultIngredientName = objClsProductDetail.DefaultIngredientName + "," + item1.id_name;
                                    }

                                    if (objClsProductDetail.DefaultIngredientId == null)
                                    {
                                        objClsProductDetail.DefaultIngredientId = item1.id_id.ToString();
                                    }
                                    else
                                    {
                                        objClsProductDetail.DefaultIngredientId = objClsProductDetail.DefaultIngredientId.ToString() + "," + item1.id_id;
                                    }
                                    //objClsProductDetail.OneQuantityPrice = Convert.ToDecimal(item1.id_price) + objClsProductDetail.OneQuantityPrice;

                                }
                                lstClsProductDetail.Add(objClsProductDetail);
                            }
                        }
                    }
                }
            }
            else
            {
                var result = (from a in dbEntities.tp_cart_detail
                              join b in dbEntities.tp_product_details
                              on a.cd_pi_id equals b.pd_id
                              join c in dbEntities.tp_product_sizes
                              on a.cd_si_id equals c.ps_id
                               into JoinedPsid
                              from sizedetail in JoinedPsid.DefaultIfEmpty()
                              join f in dbEntities.tp_product_ingredient_fact_detail
                              on a.cd_pifd_id equals f.pifd_id
                              into JoinedPifdid
                              from factdetail in JoinedPifdid.DefaultIfEmpty()
                              where a.cd_random_number == RandomNumber && a.cd_isdeleted == false && b.pd_isdeleted == false

                              select new
                              {
                                  a.cd_id,
                                  a.cd_pi_id,
                                  a.cd_ui_id,
                                  a.cd_comment,
                                  SizeId = (sizedetail == null ? 0 : sizedetail.ps_id),
                                  SizeName = (sizedetail == null ? String.Empty : sizedetail.ps_name),
                                  a.cd_quantity,
                                  a.cd_takeaway_price,
                                  FactId = (factdetail == null ? 0 : factdetail.pifd_id),
                                  FactName = (factdetail == null ? String.Empty : factdetail.pifd_name),
                                  b.pd_name,
                                  b.pd_base_price,
                                  b.pd_can_comment,
                                  a.cd_pp_id,

                              }).ToList();

                if (result != null)
                {
                    //result = result.GroupBy(x => new { x.SizeId, x.cd_pi_id,x.FactId }).Select(g => g.First()).ToList();

                    foreach (var item in result)
                    {
                        if (lstClsProductDetail.Count == 0)
                        {
                            ClsProductDetail objClsProductDetail = new ClsProductDetail();
                            objClsProductDetail.CartId = item.cd_id;
                            objClsProductDetail.SizeId = item.SizeId;
                            objClsProductDetail.ProductdetailId = item.cd_pi_id.Value;
                            objClsProductDetail.PropertiesId = item.cd_pp_id.Value;
                            objClsProductDetail.IngredientFactId = item.FactId;
                            objClsProductDetail.ProductName = item.pd_name;
                            objClsProductDetail.Quantity = item.cd_quantity.Value;
                            objClsProductDetail.Price = Convert.ToDecimal(item.cd_takeaway_price);
                            objClsProductDetail.SizeName = item.SizeName;
                            objClsProductDetail.CanComment = item.pd_can_comment;
                            objClsProductDetail.Comment = item.cd_comment;
                            objClsProductDetail.OneQuantityPrice = Convert.ToDecimal(item.cd_takeaway_price) / objClsProductDetail.Quantity;
                            if (item.SizeId == 0)
                            {

                                objClsProductDetail.SizeName = "-";
                            }
                            else
                            {

                                objClsProductDetail.SizeName = item.SizeName;
                            }
                            var result1 = (from a in dbEntities.tp_ingredient_details
                                           join b in dbEntities.tp_ingredient_product_mapping
                                           on a.id_id equals b.id_id
                                           where b.pd_id == item.cd_pi_id && a.id_isdeleted == false && b.iipm_isDefault == true
                                           select new
                                           {
                                               a.id_id,
                                               a.id_name,
                                               a.id_price
                                           }).ToList();
                            foreach (var item1 in result1)
                            {
                                if (objClsProductDetail.DefaultIngredientName == null)
                                {
                                    objClsProductDetail.DefaultIngredientName = item1.id_name;
                                }
                                else
                                {
                                    objClsProductDetail.DefaultIngredientName = objClsProductDetail.DefaultIngredientName + "," + item1.id_name;
                                }

                                if (objClsProductDetail.DefaultIngredientId == null)
                                {
                                    objClsProductDetail.DefaultIngredientId = item1.id_id.ToString();
                                }
                                else
                                {
                                    objClsProductDetail.DefaultIngredientId = objClsProductDetail.DefaultIngredientId.ToString() + "," + item1.id_id;
                                }
                                //objClsProductDetail.OneQuantityPrice = Convert.ToDecimal(item1.id_price) + objClsProductDetail.OneQuantityPrice;

                            }
                            lstClsProductDetail.Add(objClsProductDetail);
                        }
                        else
                        {
                            bool flag = false;
                            foreach (var itemlst in lstClsProductDetail)
                            {
                                if (item.cd_pi_id == itemlst.ProductdetailId && item.SizeId == itemlst.SizeId && item.FactId == itemlst.IngredientFactId)
                                {
                                    var result1 = (from cim in dbEntities.tp_cart_ingredient_mapping
                                                   join id in dbEntities.tp_ingredient_details
                                                      on cim.cim_id_id equals id.id_id
                                                   where cim.cim_isdeleted == false && id.id_isdeleted == false && cim.cim_cd_id == item.cd_id
                                                   select new
                                                   {
                                                       id.id_id,
                                                       id.id_name,
                                                       id.id_price
                                                   }).ToList();
                                    ClsProductDetail objitemClsProductDetail = new ClsProductDetail();
                                    foreach (var item1 in result1)
                                    {

                                        if (objitemClsProductDetail.ExtraIngredientId == null)
                                        {
                                            objitemClsProductDetail.ExtraIngredientId = item1.id_id.ToString();
                                        }
                                        else
                                        {
                                            objitemClsProductDetail.ExtraIngredientId = objitemClsProductDetail.ExtraIngredientId + "," + item1.id_id;
                                        }
                                    }

                                    var result11 = (from cim in dbEntities.tp_cart_ingredient_mapping
                                                    join id in dbEntities.tp_ingredient_details
                                                       on cim.cim_id_id equals id.id_id
                                                    where cim.cim_isdeleted == false && id.id_isdeleted == false && cim.cim_cd_id == itemlst.CartId
                                                    select new
                                                    {
                                                        id.id_id,
                                                        id.id_name,
                                                        id.id_price
                                                    }).ToList();
                                    ClsProductDetail objitemlstClsProductDetail = new ClsProductDetail();
                                    foreach (var item11 in result11)
                                    {

                                        if (objitemlstClsProductDetail.ExtraIngredientId == null)
                                        {
                                            objitemlstClsProductDetail.ExtraIngredientId = item11.id_id.ToString();
                                        }
                                        else
                                        {
                                            objitemlstClsProductDetail.ExtraIngredientId = objitemlstClsProductDetail.ExtraIngredientId + "," + item11.id_id;
                                        }
                                    }

                                    if (objitemClsProductDetail.ExtraIngredientId == objitemlstClsProductDetail.ExtraIngredientId)
                                    {
                                        flag = true;
                                    }
                                }
                            }
                            if (flag == false)
                            {
                                ClsProductDetail objClsProductDetail = new ClsProductDetail();
                                objClsProductDetail.CartId = item.cd_id;
                                objClsProductDetail.SizeId = item.SizeId;
                                objClsProductDetail.ProductdetailId = item.cd_pi_id.Value;
                                objClsProductDetail.PropertiesId = item.cd_pp_id.Value;
                                objClsProductDetail.IngredientFactId = item.FactId;
                                objClsProductDetail.ProductName = item.pd_name;
                                objClsProductDetail.Quantity = item.cd_quantity.Value;
                                objClsProductDetail.Price = Convert.ToDecimal(item.cd_takeaway_price);
                                objClsProductDetail.SizeName = item.SizeName;
                                objClsProductDetail.CanComment = item.pd_can_comment;
                                objClsProductDetail.Comment = item.cd_comment;
                                objClsProductDetail.OneQuantityPrice = Convert.ToDecimal(item.cd_takeaway_price) / objClsProductDetail.Quantity;
                                if (item.SizeId == 0)
                                {

                                    objClsProductDetail.SizeName = "-";
                                }
                                else
                                {

                                    objClsProductDetail.SizeName = item.SizeName;
                                }
                                var result1 = (from a in dbEntities.tp_ingredient_details
                                               join b in dbEntities.tp_ingredient_product_mapping
                                               on a.id_id equals b.id_id
                                               where b.pd_id == item.cd_pi_id && a.id_isdeleted == false && b.iipm_isDefault == true
                                               select new
                                               {
                                                   a.id_id,
                                                   a.id_name,
                                                   a.id_price
                                               }).ToList();
                                foreach (var item1 in result1)
                                {
                                    if (objClsProductDetail.DefaultIngredientName == null)
                                    {
                                        objClsProductDetail.DefaultIngredientName = item1.id_name;
                                    }
                                    else
                                    {
                                        objClsProductDetail.DefaultIngredientName = objClsProductDetail.DefaultIngredientName + "," + item1.id_name;
                                    }

                                    if (objClsProductDetail.DefaultIngredientId == null)
                                    {
                                        objClsProductDetail.DefaultIngredientId = item1.id_id.ToString();
                                    }
                                    else
                                    {
                                        objClsProductDetail.DefaultIngredientId = objClsProductDetail.DefaultIngredientId.ToString() + "," + item1.id_id;
                                    }
                                    //objClsProductDetail.OneQuantityPrice = Convert.ToDecimal(item1.id_price) + objClsProductDetail.OneQuantityPrice;

                                }
                                lstClsProductDetail.Add(objClsProductDetail);
                            }
                        }
                        //objClsProductDetail.CartIngredientId = item.cd_id_id;
                        //if (objClsProductDetail.CartIngredientId != null)
                        //{
                        //    string[] IdArray = objClsProductDetail.CartIngredientId.Split(',');
                        //    for (int i = 0; i < IdArray.Length; i++)
                        //    {
                        //        int id = Convert.ToInt32(IdArray[i]);
                        //        if (objClsProductDetail.IngredientName == null)
                        //        {
                        //            objClsProductDetail.ExtraIngredient = dbEntities.tp_ingredient_details.Where(x => x.id_id == id).FirstOrDefault().id_name;
                        //        }
                        //        else
                        //        {
                        //            objClsProductDetail.ExtraIngredient = objClsProductDetail.ExtraIngredient + "," + dbEntities.tp_ingredient_details.Where(x => x.id_id == id).FirstOrDefault().id_name;
                        //        }
                        //    }
                        //}
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductDetail;
    }

    public DataTable GetExtraIngredientsForCart(int cartId)
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        try
        {

            var result = (from cim in dbEntities.tp_cart_ingredient_mapping
                          join id in dbEntities.tp_ingredient_details
                             on cim.cim_id_id equals id.id_id
                          join pifd in dbEntities.tp_product_ingredient_fact_detail
                             on cim.cim_fact_id equals pifd.pifd_id
                          where cim.cim_isdeleted == false && id.id_isdeleted == false && cim.cim_cd_id == cartId
                          select new
                          {
                              id.id_id,
                              id.id_name,
                              cim.cim_id_price,
                              cim.cim_cd_id,
                              pifd.pifd_name

                          }).ToList();

            foreach (var item in result)
            {
                ClsProductDetail objClsProductDetail = new ClsProductDetail();
                objClsProductDetail.IngredientName = item.id_name;
                objClsProductDetail.IngredientFactName = item.pifd_name;

                var result1 = (from a in dbEntities.tp_cart_detail
                               join b in dbEntities.tp_product_ingredient_fact_detail
                               on a.cd_pifd_id equals b.pifd_id
                               where a.cd_id == cartId && a.cd_isdeleted == false && b.pifd_isdeleted == false
                               select new
                               {
                                   b.pifd_name
                               }).FirstOrDefault();
                if (result1 != null)
                {
                    //  objClsProductDetail.IngredientFactName = result1.pifd_name;
                    objClsProductDetail.IngredientPrice = item.cim_id_price;

                }
                else
                {
                    objClsProductDetail.IngredientPrice = item.cim_id_price;
                }
                objClsProductDetail.IngredientId = item.id_id;
                lstClsProductDetail.Add(objClsProductDetail);
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductDetail.ListToDataTable();
    }



    public string UpdateUserIdInCartDetail(string RandomNumber, int UserId)
    {
        string retMsg = string.Empty;
        int retValue = 0;
        try
        {
            List<tp_cart_detail> lstCartDetail = new List<tp_cart_detail>();
            lstCartDetail = dbEntities.tp_cart_detail.Where(x => x.cd_random_number == RandomNumber && x.cd_isdeleted == false).ToList();
            if (lstCartDetail.Count > 0)
            {
                foreach (var item in lstCartDetail)
                {
                    tp_cart_detail objtp_cart_detail = new tp_cart_detail();
                    objtp_cart_detail = dbEntities.tp_cart_detail.Where(x => x.cd_id == item.cd_id).FirstOrDefault();
                    if (objtp_cart_detail != null)
                    {
                        objtp_cart_detail.cd_ui_id = UserId;
                        retValue = dbEntities.SaveChanges();
                    }
                }
            }
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

    public string DeleteItemFromCart(int CartId)
    {
        string retMsg = string.Empty;
        int retValue = 0, retValue1 = 0;
        try
        {
            List<tp_cart_detail> lstCartDetail = new List<tp_cart_detail>();
            lstCartDetail = dbEntities.tp_cart_detail.Where(x => x.cd_id == CartId && x.cd_isdeleted == false).ToList();
            if (lstCartDetail.Count > 0)
            {
                foreach (var item in lstCartDetail)
                {
                    tp_cart_detail objtp_cart_detail = new tp_cart_detail();
                    objtp_cart_detail = dbEntities.tp_cart_detail.Where(x => x.cd_id == item.cd_id).FirstOrDefault();
                    if (objtp_cart_detail != null)
                    {
                        objtp_cart_detail.cd_isdeleted = true;
                        retValue = dbEntities.SaveChanges();
                    }
                }
            }

            List<tp_cart_ingredient_mapping> lstCartIngredientMapping = new List<tp_cart_ingredient_mapping>();
            lstCartIngredientMapping = dbEntities.tp_cart_ingredient_mapping.Where(x => x.cim_cd_id == CartId).ToList();
            if (lstCartIngredientMapping.Count > 0)
            {
                foreach (var item in lstCartIngredientMapping)
                {
                    tp_cart_ingredient_mapping objtp_cartIngredientMapping = new tp_cart_ingredient_mapping();
                    objtp_cartIngredientMapping = dbEntities.tp_cart_ingredient_mapping.Where(x => x.cim_cd_id == CartId).FirstOrDefault();
                    if (objtp_cartIngredientMapping != null)
                    {
                        objtp_cartIngredientMapping.cim_isdeleted = true;
                        retValue1 = dbEntities.SaveChanges();
                    }
                }
            }
            if (retValue > 0 || retValue1 > 0)
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

    public string GetCategoryByProductId(int productId)
    {

        var result = (from a in dbEntities.tp_product_details
                      join b in dbEntities.tp_product_category
                      on a.pd_pc_id equals b.pc_id
                      where a.pd_id == productId
                      select new
                      {
                          b.pc_name
                      }).FirstOrDefault().pc_name;
        return result;
    }
}