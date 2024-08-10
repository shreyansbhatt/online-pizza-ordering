using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClsCustomerOrderDetail
/// </summary>
public class ClsCustomerOrderDetail
{
    TP_DatabaseEntities dbEntities = new TP_DatabaseEntities();
    public ClsCustomerOrderDetail()
    {

    }

    #region Properties



    private string m_orderNumber;
    private int m_userId;
    private int m_storeId;
    private DateTime m_orderPlaceTime;
    private DateTime m_orderWishTime;
    private DateTime m_orderDeliveredTime;

    private string m_totalAmount;
    private string m_orderType;
    private string m_comment;

    //for Mapping
    private string m_productName;
    private string m_sizeName;
    private string m_pizzaBaseTypeName;
    private string m_productMakingMethodName;

    private string m_ingredientName;
    private string m_UserName;
    private int m_OrderId;
    private decimal m_TotalOrderAmount;
    private int m_ProductId;
    private int m_Quantity;
    private string m_OrderPlaceString;

    public string OrderPlaceString
    {
        get { return m_OrderPlaceString; }
        set { m_OrderPlaceString = value; }
    }

    public int Quantity
    {
        get { return m_Quantity; }
        set { m_Quantity = value; }
    }
    public int ProductId
    {
        get { return m_ProductId; }
        set { m_ProductId = value; }
    }

    private string m_Price;

    public string Price
    {
        get { return m_Price; }
        set { m_Price = value; }
    }
    public decimal TotalOrderAmount
    {
        get { return m_TotalOrderAmount; }
        set { m_TotalOrderAmount = value; }
    }
    public int OrderId
    {
        get { return m_OrderId; }
        set { m_OrderId = value; }
    }
    public string UserName
    {
        get { return m_UserName; }
        set { m_UserName = value; }
    }
    private string m_StoreName;

    public string StoreName
    {
        get { return m_StoreName; }
        set { m_StoreName = value; }
    }
    private string m_OrderStatus;

    public string OrderStatus
    {
        get { return m_OrderStatus; }
        set { m_OrderStatus = value; }
    }
    public string OrderNumber
    {
        get
        {
            return m_orderNumber;
        }

        set
        {
            m_orderNumber = value;
        }
    }

    public int UserId
    {
        get
        {
            return m_userId;
        }

        set
        {
            m_userId = value;
        }
    }

    public int StoreId
    {
        get
        {
            return m_storeId;
        }

        set
        {
            m_storeId = value;
        }
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

    public DateTime OrderWishTime
    {
        get
        {
            return m_orderWishTime;
        }

        set
        {
            m_orderWishTime = value;
        }
    }

    public DateTime OrderDeliveredTime
    {
        get
        {
            return m_orderDeliveredTime;
        }

        set
        {
            m_orderDeliveredTime = value;
        }
    }

    public string TotalAmount
    {
        get
        {
            return m_totalAmount;
        }

        set
        {
            m_totalAmount = value;
        }
    }

    public string OrderType
    {
        get
        {
            return m_orderType;
        }

        set
        {
            m_orderType = value;
        }
    }

    public string Comment
    {
        get
        {
            return m_comment;
        }

        set
        {
            m_comment = value;
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

    #endregion

    //Insert Order Detail
    //List<ClsCustomerOrderDetail> lstCustomerOrderDetail it take list of product in order
    public string InsertOrderDetail(string orderNumber, int userId, int storeId, DateTime orderPlaceTime, DateTime orderWishTime, DateTime orderDeliveredTime, string totalAmount, string orderType, string comment, List<ClsCustomerOrderDetail> lstCustomerOrderDetail, List<ClsIngredientDetails> lstClsIngredientDetails)
    {
        int retValue = 0, retValue1 = 0, retValue2 = 0;
        string retMsg = string.Empty;

        try
        {

            tp_customer_order_details dbObjInsertOrderDetail = new tp_customer_order_details();
            dbObjInsertOrderDetail.cod_order_number = orderNumber;
            dbObjInsertOrderDetail.cod_ui_id = userId;
            dbObjInsertOrderDetail.cod_sd_id = storeId;
            dbObjInsertOrderDetail.cod_order_placed_time = orderPlaceTime;
            dbObjInsertOrderDetail.cod_order_wish_time = orderWishTime;
            dbObjInsertOrderDetail.cod_order_actual_delivered_time = orderDeliveredTime;
            dbObjInsertOrderDetail.cod_total_amount = totalAmount;
            dbObjInsertOrderDetail.cod_order_type = orderType;
            //dbObjInsertOrderDetail.cod_comments = comment;
            dbObjInsertOrderDetail.cod_isdeleted = false;

            dbObjInsertOrderDetail.createdby = userId;
            dbObjInsertOrderDetail.modifiedby = userId;
            dbObjInsertOrderDetail.createdon = DateTime.Now;
            dbObjInsertOrderDetail.modifiedon = DateTime.Now;


            dbEntities.tp_customer_order_details.Add(dbObjInsertOrderDetail);
            retValue = dbEntities.SaveChanges();

            foreach (var item in lstCustomerOrderDetail)
            {
                tp_order_product_mapping dbobjtp_order_product_mapping = new tp_order_product_mapping();
                dbobjtp_order_product_mapping.opm_cod_id = dbObjInsertOrderDetail.cod_id;
                dbobjtp_order_product_mapping.opm_Comment = item.Comment;
                dbobjtp_order_product_mapping.opm_pd_id = item.ProductId;

                List<tp_order_product_ingredients_specification> lsttp_order_product_ingredients_specification = new List<tp_order_product_ingredients_specification>();
                lsttp_order_product_ingredients_specification = dbEntities.tp_order_product_ingredients_specification.Where(x => x.opis_pd_id == item.ProductId && x.opis_cod_id == dbObjInsertOrderDetail.cod_id).ToList();

                foreach (var item1 in lsttp_order_product_ingredients_specification)
                {
                    tp_product_properties objtp_product_properties = new tp_product_properties();
                    objtp_product_properties = dbEntities.tp_product_properties.Where(x => x.pp_id == item1.opis_pp_id && x.pd_id == item1.opis_pd_id).FirstOrDefault();
                    if (objtp_product_properties != null)
                    {
                        dbobjtp_order_product_mapping.opm_price = objtp_product_properties.pp_price;
                    }
                    if (item1.opis_id_id != 0)
                    {
                        tp_ingredient_details objtp_ingredient_details = new tp_ingredient_details();
                        objtp_ingredient_details = dbEntities.tp_ingredient_details.Where(x => x.id_id == item1.opis_id_id && x.id_isdeleted == false).FirstOrDefault();
                        if (objtp_ingredient_details != null)
                        {
                            dbobjtp_order_product_mapping.opm_price = (Convert.ToDecimal(dbobjtp_order_product_mapping.opm_price) + Convert.ToDecimal(objtp_ingredient_details.id_price)).ToString();
                        }
                    }
                    else
                    {
                        dbobjtp_order_product_mapping.opm_price = dbobjtp_order_product_mapping.opm_price;
                    }

                }
                dbobjtp_order_product_mapping.opm_quantity = item.Quantity;

                dbEntities.tp_order_product_mapping.Add(dbobjtp_order_product_mapping);
                retValue1 = dbEntities.SaveChanges();
            }
            foreach (var item in lstClsIngredientDetails)
            {
                tp_order_product_ingredients_specification objtp_order_product_ingredients_specification = new tp_order_product_ingredients_specification();
                objtp_order_product_ingredients_specification.opis_cod_id = dbObjInsertOrderDetail.cod_id;
                objtp_order_product_ingredients_specification.opis_pd_id = item.ProductId;
                objtp_order_product_ingredients_specification.opis_pifd_id = item.IngredientFactId;
                objtp_order_product_ingredients_specification.opis_pp_id = item.ProductPropertyId;
                objtp_order_product_ingredients_specification.opis_id_id = item.IngredientId;
                dbEntities.tp_order_product_ingredients_specification.Add(objtp_order_product_ingredients_specification);
                retValue2 = dbEntities.SaveChanges();

            }
            if (retValue > 0 || retValue1 > 0 || retValue2 > 0)
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

    //Get Product Detail by Order


    public List<ClsCustomerOrderDetail> GetProductListByOrder()
    {
        List<ClsCustomerOrderDetail> lstProductList = new List<ClsCustomerOrderDetail>();

        //var result = (from opm in dbEntities.tp_order_product_mapping
        //              join cod in dbEntities.tp_customer_order_details
        //              on opm.opm_cod_id equals cod.cod_id
        //              join pd in dbEntities.tp_product_details
        //              on opm.opm_pd_id equals pd.pd_id
        //              join pp in dbEntities.tp_product_properties
        //              on opm.opm_pp_id equals pp.pp_id
        //              join ps in dbEntities.tp_product_sizes
        //              on opm.opm_ps_id equals ps.ps_id
        //              join pbt in dbEntities.tp_pizza_base_type
        //              on opm.opm_pbt_id equals pbt.pbt_id
        //              join pmm in dbEntities.tp_product_making_method
        //              on opm.opm_pmm_id equals pmm.pmm_id
        //              select new
        //              {
        //                  cod.cod_order_number,
        //                  pd.pd_name,
        //                  ps.ps_name,
        //                  pbt.pbt_name,
        //                  pmm.pmm_name,
        //                  opm.opm_price
        //              }).ToList();
        //foreach (var item in result)
        //{
        //    ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();
        //    objClsCustomerOrderDetail.OrderNumber = item.cod_order_number;
        //    objClsCustomerOrderDetail.ProductName = item.pd_name;
        //    objClsCustomerOrderDetail.SizeName = item.ps_name;
        //    objClsCustomerOrderDetail.PizzaBaseTypeName = item.pbt_name;
        //    objClsCustomerOrderDetail.ProductMakingMethodName = item.pmm_name;
        //    objClsCustomerOrderDetail.TotalAmount = item.opm_price;

        //    lstProductList.Add(objClsCustomerOrderDetail);

        //}

        return lstProductList;
    }

    //Get Ingredient Detail by Order

    public List<ClsCustomerOrderDetail> GetIngredientListByOrder()
    {
        List<ClsCustomerOrderDetail> lstIngredientList = new List<ClsCustomerOrderDetail>();
        try
        {
            var result = (from opis in dbEntities.tp_order_product_ingredients_specification
                          join cod in dbEntities.tp_customer_order_details
                          on opis.opis_cod_id equals cod.cod_id
                          join pd in dbEntities.tp_product_details
                          on opis.opis_pd_id equals pd.pd_id
                          join id in dbEntities.tp_ingredient_details
                          on opis.opis_id_id equals id.id_id

                          select new
                          {
                              opis,
                              cod,
                              pd,
                              id
                          }).ToList();
            foreach (var item in result)
            {
                ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();
                objClsCustomerOrderDetail.OrderNumber = item.cod.cod_order_number;
                objClsCustomerOrderDetail.ProductName = item.pd.pd_name;
                objClsCustomerOrderDetail.IngredientName = item.id.id_name;

                objClsCustomerOrderDetail.TotalAmount = item.cod.cod_total_amount;

                lstIngredientList.Add(objClsCustomerOrderDetail);

            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstIngredientList;
    }

    public List<ClsCustomerOrderDetail> GetOrderDatils(DateTime FromDate, DateTime ToDate, string SerarchText = null)
    {
        List<ClsCustomerOrderDetail> lstClsCustomerOrderDetail = new List<ClsCustomerOrderDetail>();
        try
        {
            if (SerarchText != null && SerarchText != "" && FromDate != Convert.ToDateTime("1/1/1900 12:00:00 AM") && ToDate != Convert.ToDateTime("1/1/1900 12:00:00 AM"))
            {
                var result = (from a in dbEntities.tp_customer_order_details
                              join b in dbEntities.tp_store_details
                              on a.cod_sd_id equals b.sd_id
                              where a.cod_isdeleted == false && b.sd_isdeleted == false && a.cod_order_number.Contains(SerarchText) &&
                               (System.Data.Entity.DbFunctions.TruncateTime(a.cod_order_placed_time) >= System.Data.Entity.DbFunctions.TruncateTime(FromDate.Date) &&
                                  System.Data.Entity.DbFunctions.TruncateTime(a.cod_order_placed_time) <= System.Data.Entity.DbFunctions.TruncateTime(ToDate.Date))
                              orderby a.cod_order_placed_time descending
                              select new
                              {

                                  a.cod_id,
                                  a.cod_order_actual_delivered_time,
                                  a.cod_order_number,
                                  a.cod_order_placed_time,
                                  a.cod_order_type,
                                  a.cod_order_wish_time,
                                  a.cod_sd_id,
                                  a.cod_total_amount,
                                  a.cod_ui_id,
                                  a.modifiedby,
                                  a.modifiedon,
                                  a.createdby,
                                  a.createdon,
                                  a.cod_order_status,
                                  b.sd_address,
                                  b.sd_name
                              }).ToList();
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();
                        objClsCustomerOrderDetail.OrderId = item.cod_id;
                        objClsCustomerOrderDetail.OrderNumber = item.cod_order_number;
                        if (item.cod_order_placed_time != null)
                        {
                            objClsCustomerOrderDetail.OrderPlaceTime = item.cod_order_placed_time.Value.Date;
                            objClsCustomerOrderDetail.OrderPlaceString = Convert.ToDateTime(item.cod_order_placed_time).ToShortDateString();
                        }
                        if (item.cod_order_actual_delivered_time != null)
                        {
                            objClsCustomerOrderDetail.OrderDeliveredTime = item.cod_order_actual_delivered_time.Value;
                        }
                        if (item.cod_order_wish_time != null)
                        {
                            objClsCustomerOrderDetail.OrderWishTime = item.cod_order_wish_time.Value;
                        }
                        objClsCustomerOrderDetail.TotalAmount = item.cod_total_amount;
                        objClsCustomerOrderDetail.TotalOrderAmount = Convert.ToDecimal(item.cod_total_amount);
                        objClsCustomerOrderDetail.OrderType = item.cod_order_type;
                        objClsCustomerOrderDetail.OrderStatus = item.cod_order_status;
                        objClsCustomerOrderDetail.StoreName = item.sd_name;
                        if (item.cod_ui_id == 0)
                        {
                            var result1 = (from a in dbEntities.tp_customer_order_details
                                           join b in dbEntities.tp_billing_detail
                                           on a.cod_id equals b.tbd_cod_id
                                           where a.cod_isdeleted == false && b.tbd_isdeleted == false && a.cod_order_number == item.cod_order_number
                                           select new
                                           {
                                               b.tbd_name
                                           }).FirstOrDefault();
                            if (result1 != null)
                            {
                                objClsCustomerOrderDetail.UserName = result1.tbd_name;
                                lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                            }
                            //objClsCustomerOrderDetail.UserName = "Guest";
                            //lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                        }
                        else
                        {
                            var result1 = (from a in dbEntities.tp_customer_order_details
                                           join b in dbEntities.tp_user_information
                                           on a.cod_ui_id equals b.ui_id
                                           where a.cod_isdeleted == false && b.ui_isdeleted == false && b.ui_id == item.cod_ui_id && a.cod_order_number == item.cod_order_number
                                           select new
                                           {
                                               b.ui_userName,
                                               b.ui_firstName,
                                               b.ui_lastName
                                           }).FirstOrDefault();
                            if (result1 != null)
                            {
                                objClsCustomerOrderDetail.UserName = result1.ui_firstName + " " + result1.ui_lastName;
                                lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                            }
                        }
                    }
                }
                lstClsCustomerOrderDetail = lstClsCustomerOrderDetail.OrderByDescending(x => x.OrderPlaceTime == DateTime.Now.Date).ThenByDescending(x => x.OrderPlaceTime).ToList();
            }
            else if ((SerarchText == null || SerarchText == "") && FromDate != Convert.ToDateTime("1/1/1900 12:00:00 AM") && ToDate != Convert.ToDateTime("1/1/1900 12:00:00 AM"))
            {

                var result = (from a in dbEntities.tp_customer_order_details
                              join b in dbEntities.tp_store_details
                              on a.cod_sd_id equals b.sd_id
                              where a.cod_isdeleted == false && b.sd_isdeleted == false && (System.Data.Entity.DbFunctions.TruncateTime(a.cod_order_placed_time) >= System.Data.Entity.DbFunctions.TruncateTime(FromDate.Date) &&
                                  System.Data.Entity.DbFunctions.TruncateTime(a.cod_order_placed_time) <= System.Data.Entity.DbFunctions.TruncateTime(ToDate.Date))
                              orderby a.cod_order_placed_time descending
                              select new
                              {

                                  a.cod_id,
                                  a.cod_order_actual_delivered_time,
                                  a.cod_order_number,
                                  a.cod_order_placed_time,
                                  a.cod_order_type,
                                  a.cod_order_wish_time,
                                  a.cod_sd_id,
                                  a.cod_total_amount,
                                  a.cod_ui_id,
                                  a.modifiedby,
                                  a.modifiedon,
                                  a.createdby,
                                  a.createdon,
                                  a.cod_order_status,
                                  b.sd_address,
                                  b.sd_name
                              }).ToList();
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();
                        objClsCustomerOrderDetail.OrderId = item.cod_id;
                        objClsCustomerOrderDetail.OrderNumber = item.cod_order_number;
                        if (item.cod_order_placed_time != null)
                        {
                            objClsCustomerOrderDetail.OrderPlaceTime = item.cod_order_placed_time.Value.Date;
                            objClsCustomerOrderDetail.OrderPlaceString = Convert.ToDateTime(item.cod_order_placed_time).ToShortDateString();
                        }
                        if (item.cod_order_actual_delivered_time != null)
                        {
                            objClsCustomerOrderDetail.OrderDeliveredTime = item.cod_order_actual_delivered_time.Value;
                        }
                        if (item.cod_order_wish_time != null)
                        {
                            objClsCustomerOrderDetail.OrderWishTime = item.cod_order_wish_time.Value;
                        }
                        objClsCustomerOrderDetail.TotalOrderAmount = Convert.ToDecimal(item.cod_total_amount);
                        objClsCustomerOrderDetail.TotalAmount = item.cod_total_amount;
                        objClsCustomerOrderDetail.OrderType = item.cod_order_type;
                        objClsCustomerOrderDetail.OrderStatus = item.cod_order_status;
                        objClsCustomerOrderDetail.StoreName = item.sd_name;
                        if (item.cod_ui_id == 0)
                        {
                            var result1 = (from a in dbEntities.tp_customer_order_details
                                           join b in dbEntities.tp_billing_detail
                                           on a.cod_id equals b.tbd_cod_id
                                           where a.cod_isdeleted == false && b.tbd_isdeleted == false && a.cod_order_number == item.cod_order_number
                                           select new
                                           {
                                               b.tbd_name
                                           }).FirstOrDefault();
                            if (result1 != null)
                            {
                                objClsCustomerOrderDetail.UserName = result1.tbd_name;
                                lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                            }
                            //objClsCustomerOrderDetail.UserName = "Guest";
                            //lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);

                        }
                        else
                        {
                            var result1 = (from a in dbEntities.tp_customer_order_details
                                           join b in dbEntities.tp_user_information
                                           on a.cod_ui_id equals b.ui_id
                                           where a.cod_isdeleted == false && b.ui_isdeleted == false && b.ui_id == item.cod_ui_id && a.cod_order_number == item.cod_order_number
                                           select new
                                           {
                                               b.ui_userName,
                                               b.ui_firstName,
                                               b.ui_lastName
                                           }).FirstOrDefault();
                            if (result1 != null)
                            {
                                objClsCustomerOrderDetail.UserName = result1.ui_firstName + " " + result1.ui_lastName;
                                lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                            }
                        }
                    }
                }
                lstClsCustomerOrderDetail = lstClsCustomerOrderDetail.OrderByDescending(x => x.OrderPlaceTime == DateTime.Now.Date).ThenByDescending(x => x.OrderPlaceTime).ToList();
            }
            else if ((SerarchText != null || SerarchText != "") && FromDate == Convert.ToDateTime("1/1/1900 12:00:00 AM") && ToDate == Convert.ToDateTime("1/1/1900 12:00:00 AM"))
            {

                var result = (from a in dbEntities.tp_customer_order_details
                              join b in dbEntities.tp_store_details
                              on a.cod_sd_id equals b.sd_id
                              where a.cod_isdeleted == false && b.sd_isdeleted == false && a.cod_order_number.Contains(SerarchText)
                              orderby a.cod_order_placed_time descending
                              select new
                              {

                                  a.cod_id,
                                  a.cod_order_actual_delivered_time,
                                  a.cod_order_number,
                                  a.cod_order_placed_time,
                                  a.cod_order_type,
                                  a.cod_order_wish_time,
                                  a.cod_sd_id,
                                  a.cod_total_amount,
                                  a.cod_ui_id,
                                  a.modifiedby,
                                  a.modifiedon,
                                  a.createdby,
                                  a.createdon,
                                  a.cod_order_status,
                                  b.sd_address,
                                  b.sd_name
                              }).ToList();
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();
                        objClsCustomerOrderDetail.OrderId = item.cod_id;
                        objClsCustomerOrderDetail.OrderNumber = item.cod_order_number;
                        if (item.cod_order_placed_time != null)
                        {
                            objClsCustomerOrderDetail.OrderPlaceTime = item.cod_order_placed_time.Value.Date;
                            objClsCustomerOrderDetail.OrderPlaceString = Convert.ToDateTime(item.cod_order_placed_time).ToShortDateString();
                        }
                        if (item.cod_order_actual_delivered_time != null)
                        {
                            objClsCustomerOrderDetail.OrderDeliveredTime = item.cod_order_actual_delivered_time.Value;
                        }
                        if (item.cod_order_wish_time != null)
                        {
                            objClsCustomerOrderDetail.OrderWishTime = item.cod_order_wish_time.Value;
                        }
                        objClsCustomerOrderDetail.TotalAmount = item.cod_total_amount;
                        if (item.cod_total_amount != null)
                        {
                            objClsCustomerOrderDetail.TotalOrderAmount = Convert.ToDecimal(item.cod_total_amount);
                        }
                        objClsCustomerOrderDetail.OrderType = item.cod_order_type;
                        objClsCustomerOrderDetail.OrderStatus = item.cod_order_status;
                        objClsCustomerOrderDetail.StoreName = item.sd_name;
                        if (item.cod_ui_id == 0)
                        {
                            var result1 = (from a in dbEntities.tp_customer_order_details
                                           join b in dbEntities.tp_billing_detail
                                           on a.cod_id equals b.tbd_cod_id
                                           where a.cod_isdeleted == false && b.tbd_isdeleted == false && a.cod_order_number == item.cod_order_number
                                           select new
                                           {
                                               b.tbd_name
                                           }).FirstOrDefault();
                            if (result1 != null)
                            {
                                objClsCustomerOrderDetail.UserName = result1.tbd_name;
                                lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                            }
                            //objClsCustomerOrderDetail.UserName = "Guest";
                            //lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                        }
                        else
                        {
                            var result1 = (from a in dbEntities.tp_customer_order_details
                                           join b in dbEntities.tp_user_information
                                           on a.cod_ui_id equals b.ui_id
                                           where a.cod_isdeleted == false && b.ui_isdeleted == false && b.ui_id == item.cod_ui_id && a.cod_order_number == item.cod_order_number
                                           select new
                                           {
                                               b.ui_userName,
                                               b.ui_firstName,
                                               b.ui_lastName
                                           }).FirstOrDefault();
                            if (result1 != null)
                            {
                                objClsCustomerOrderDetail.UserName = result1.ui_firstName + " " + result1.ui_lastName;
                                lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                            }
                        }
                    }
                }
                lstClsCustomerOrderDetail = lstClsCustomerOrderDetail.OrderByDescending(x => x.OrderPlaceTime == DateTime.Now.Date).ThenByDescending(x => x.OrderPlaceTime).ToList();

            }
            else
            {
                var result = (from a in dbEntities.tp_customer_order_details
                              join b in dbEntities.tp_store_details
                              on a.cod_sd_id equals b.sd_id
                              where a.cod_isdeleted == false && b.sd_isdeleted == false
                              orderby a.cod_order_placed_time descending
                              select new
                              {

                                  a.cod_id,
                                  a.cod_order_actual_delivered_time,
                                  a.cod_order_number,
                                  a.cod_order_placed_time,
                                  a.cod_order_type,
                                  a.cod_order_wish_time,
                                  a.cod_sd_id,
                                  a.cod_total_amount,
                                  a.cod_ui_id,
                                  a.modifiedby,
                                  a.modifiedon,
                                  a.createdby,
                                  a.createdon,
                                  a.cod_order_status,
                                  b.sd_address,
                                  b.sd_name
                              }).ToList();
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();
                        objClsCustomerOrderDetail.OrderId = item.cod_id;
                        objClsCustomerOrderDetail.OrderNumber = item.cod_order_number;
                        if (item.cod_order_placed_time != null)
                        {
                            objClsCustomerOrderDetail.OrderPlaceTime = item.cod_order_placed_time.Value.Date;
                            objClsCustomerOrderDetail.OrderPlaceString = Convert.ToDateTime(item.cod_order_placed_time).ToShortDateString();
                        }
                        if (item.cod_order_actual_delivered_time != null)
                        {
                            objClsCustomerOrderDetail.OrderDeliveredTime = item.cod_order_actual_delivered_time.Value;
                        }
                        if (item.cod_order_wish_time != null)
                        {
                            objClsCustomerOrderDetail.OrderWishTime = item.cod_order_wish_time.Value;
                        }
                        objClsCustomerOrderDetail.TotalAmount = item.cod_total_amount;
                        objClsCustomerOrderDetail.TotalOrderAmount = Convert.ToDecimal(item.cod_total_amount);
                        objClsCustomerOrderDetail.OrderType = item.cod_order_type;
                        objClsCustomerOrderDetail.OrderStatus = item.cod_order_status;
                        objClsCustomerOrderDetail.StoreName = item.sd_name;
                        if (item.cod_ui_id == 0)
                        {
                            var result1 = (from a in dbEntities.tp_customer_order_details
                                           join b in dbEntities.tp_billing_detail
                                           on a.cod_id equals b.tbd_cod_id
                                           where a.cod_isdeleted == false && b.tbd_isdeleted == false && a.cod_order_number == item.cod_order_number
                                           select new
                                           {
                                               b.tbd_name
                                           }).FirstOrDefault();
                            if (result1 != null)
                            {
                                objClsCustomerOrderDetail.UserName = result1.tbd_name;
                                lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                            }

                            //objClsCustomerOrderDetail.UserName = "Guest";
                            //lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                        }
                        else
                        {
                            var result1 = (from a in dbEntities.tp_customer_order_details
                                           join b in dbEntities.tp_user_information
                                           on a.cod_ui_id equals b.ui_id
                                           where a.cod_isdeleted == false && b.ui_isdeleted == false && b.ui_id == item.cod_ui_id && a.cod_order_number == item.cod_order_number
                                           select new
                                           {
                                               b.ui_userName,
                                               b.ui_firstName,
                                               b.ui_lastName
                                           }).FirstOrDefault();
                            if (result1 != null)
                            {
                                objClsCustomerOrderDetail.UserName = result1.ui_firstName + " " + result1.ui_lastName;
                                lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                            }
                        }
                    }
                    lstClsCustomerOrderDetail = lstClsCustomerOrderDetail.OrderByDescending(x => x.OrderPlaceTime == DateTime.Now.Date).ThenByDescending(x => x.OrderPlaceTime).ToList();

                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsCustomerOrderDetail;
    }

    public List<ClsCustomerOrderDetail> GetOrderListForPlacedOrder(DateTime FromDate, DateTime ToDate, string SerarchText = null)
    {
        List<ClsCustomerOrderDetail> lstClsCustomerOrderDetail = new List<ClsCustomerOrderDetail>();
        try
        {
            if (SerarchText != null && SerarchText != "" && FromDate != Convert.ToDateTime("1/1/1900 12:00:00 AM") && ToDate != Convert.ToDateTime("1/1/1900 12:00:00 AM"))
            {
                var result = (from a in dbEntities.tp_customer_order_details
                              join b in dbEntities.tp_store_details
                              on a.cod_sd_id equals b.sd_id
                              where a.cod_isdeleted == false && b.sd_isdeleted == false && a.cod_order_number.Contains(SerarchText) && a.cod_order_status.Contains("Order Placed") &&
                               (System.Data.Entity.DbFunctions.TruncateTime(a.cod_order_placed_time) >= System.Data.Entity.DbFunctions.TruncateTime(FromDate.Date) &&
                                  System.Data.Entity.DbFunctions.TruncateTime(a.cod_order_placed_time) <= System.Data.Entity.DbFunctions.TruncateTime(ToDate.Date))
                              select new
                              {

                                  a.cod_id,
                                  a.cod_order_actual_delivered_time,
                                  a.cod_order_number,
                                  a.cod_order_placed_time,
                                  a.cod_order_type,
                                  a.cod_order_wish_time,
                                  a.cod_sd_id,
                                  a.cod_total_amount,
                                  a.cod_ui_id,
                                  a.modifiedby,
                                  a.modifiedon,
                                  a.createdby,
                                  a.createdon,
                                  a.cod_order_status,
                                  b.sd_address,
                                  b.sd_name
                              }).ToList();
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();
                        objClsCustomerOrderDetail.OrderId = item.cod_id;
                        objClsCustomerOrderDetail.OrderNumber = item.cod_order_number;
                        if (item.cod_order_placed_time != null)
                        {
                            objClsCustomerOrderDetail.OrderPlaceTime = item.cod_order_placed_time.Value.Date;
                            objClsCustomerOrderDetail.OrderPlaceString = Convert.ToDateTime(item.cod_order_placed_time).ToShortDateString();
                        }
                        if (item.cod_order_actual_delivered_time != null)
                        {
                            objClsCustomerOrderDetail.OrderDeliveredTime = item.cod_order_actual_delivered_time.Value;
                        }
                        if (item.cod_order_wish_time != null)
                        {
                            objClsCustomerOrderDetail.OrderWishTime = item.cod_order_wish_time.Value;
                        }
                        if (item.cod_total_amount != null)
                        {
                            objClsCustomerOrderDetail.TotalAmount = item.cod_total_amount;
                        }
                        if (item.cod_total_amount != null)
                        {

                            objClsCustomerOrderDetail.TotalOrderAmount = Convert.ToDecimal(item.cod_total_amount);
                        }
                        else
                        {
                            objClsCustomerOrderDetail.TotalOrderAmount = Convert.ToDecimal(0);
                        }
                        objClsCustomerOrderDetail.OrderType = item.cod_order_type;
                        objClsCustomerOrderDetail.OrderStatus = item.cod_order_status;
                        objClsCustomerOrderDetail.StoreName = item.sd_name;
                        if (item.cod_ui_id == 0)
                        {
                            objClsCustomerOrderDetail.UserName = "Guest";
                            lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                        }
                        else
                        {
                            var result1 = (from a in dbEntities.tp_customer_order_details
                                           join b in dbEntities.tp_user_information
                                           on a.cod_ui_id equals b.ui_id
                                           where a.cod_isdeleted == false && b.ui_isdeleted == false && b.ui_id == item.cod_ui_id
                                           select new
                                           {
                                               b.ui_userName,
                                               b.ui_firstName,
                                               b.ui_lastName
                                           }).FirstOrDefault();
                            if (result1 != null)
                            {
                                objClsCustomerOrderDetail.UserName = result1.ui_firstName + " " + result1.ui_lastName;
                                lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                            }
                        }
                    }
                }
                lstClsCustomerOrderDetail = lstClsCustomerOrderDetail.OrderByDescending(x => x.OrderPlaceTime).ToList();
            }
            else if ((SerarchText == null || SerarchText == "") && FromDate != Convert.ToDateTime("1/1/1900 12:00:00 AM") && ToDate != Convert.ToDateTime("1/1/1900 12:00:00 AM"))
            {

                var result = (from a in dbEntities.tp_customer_order_details
                              join b in dbEntities.tp_store_details
                              on a.cod_sd_id equals b.sd_id
                              where a.cod_isdeleted == false && b.sd_isdeleted == false && a.cod_order_status.Contains("Order Placed") && (System.Data.Entity.DbFunctions.TruncateTime(a.cod_order_placed_time) >= System.Data.Entity.DbFunctions.TruncateTime(FromDate.Date) &&
                                  System.Data.Entity.DbFunctions.TruncateTime(a.cod_order_placed_time) <= System.Data.Entity.DbFunctions.TruncateTime(ToDate.Date))

                              select new
                              {

                                  a.cod_id,
                                  a.cod_order_actual_delivered_time,
                                  a.cod_order_number,
                                  a.cod_order_placed_time,
                                  a.cod_order_type,
                                  a.cod_order_wish_time,
                                  a.cod_sd_id,
                                  a.cod_total_amount,
                                  a.cod_ui_id,
                                  a.modifiedby,
                                  a.modifiedon,
                                  a.createdby,
                                  a.createdon,
                                  a.cod_order_status,
                                  b.sd_address,
                                  b.sd_name
                              }).ToList();
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();
                        objClsCustomerOrderDetail.OrderId = item.cod_id;
                        objClsCustomerOrderDetail.OrderNumber = item.cod_order_number;
                        if (item.cod_order_placed_time != null)
                        {
                            objClsCustomerOrderDetail.OrderPlaceTime = item.cod_order_placed_time.Value.Date;
                            objClsCustomerOrderDetail.OrderPlaceString = Convert.ToDateTime(item.cod_order_placed_time).ToShortDateString();
                        }
                        if (item.cod_order_actual_delivered_time != null)
                        {
                            objClsCustomerOrderDetail.OrderDeliveredTime = item.cod_order_actual_delivered_time.Value;
                        }
                        if (item.cod_order_wish_time != null)
                        {
                            objClsCustomerOrderDetail.OrderWishTime = item.cod_order_wish_time.Value;
                        }
                        if (item.cod_total_amount != null)
                        {
                            objClsCustomerOrderDetail.TotalAmount = item.cod_total_amount;
                        }
                        if (item.cod_total_amount != null)
                        {

                            objClsCustomerOrderDetail.TotalOrderAmount = Convert.ToDecimal(item.cod_total_amount);
                        }
                        else
                        {
                            objClsCustomerOrderDetail.TotalOrderAmount = Convert.ToDecimal(0);
                        }
                        objClsCustomerOrderDetail.OrderType = item.cod_order_type;
                        objClsCustomerOrderDetail.OrderStatus = item.cod_order_status;
                        objClsCustomerOrderDetail.StoreName = item.sd_name;
                        if (item.cod_ui_id == 0)
                        {
                            objClsCustomerOrderDetail.UserName = "Guest";
                            lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                        }
                        else
                        {
                            var result1 = (from a in dbEntities.tp_customer_order_details
                                           join b in dbEntities.tp_user_information
                                           on a.cod_ui_id equals b.ui_id
                                           where a.cod_isdeleted == false && b.ui_isdeleted == false && b.ui_id == item.cod_ui_id
                                           select new
                                           {
                                               b.ui_userName,
                                               b.ui_firstName,
                                               b.ui_lastName
                                           }).FirstOrDefault();
                            if (result1 != null)
                            {
                                objClsCustomerOrderDetail.UserName = result1.ui_firstName + " " + result1.ui_lastName;
                                lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                            }
                        }
                    }
                }
                lstClsCustomerOrderDetail = lstClsCustomerOrderDetail.OrderByDescending(x => x.OrderPlaceTime).ToList();
            }
            else if ((SerarchText != null || SerarchText != "") && FromDate == Convert.ToDateTime("1/1/1900 12:00:00 AM") && ToDate == Convert.ToDateTime("1/1/1900 12:00:00 AM"))
            {

                var result = (from a in dbEntities.tp_customer_order_details
                              join b in dbEntities.tp_store_details
                              on a.cod_sd_id equals b.sd_id
                              where a.cod_isdeleted == false && b.sd_isdeleted == false && a.cod_order_status.Contains("Order Placed") && a.cod_order_number.Contains(SerarchText)
                              select new
                              {

                                  a.cod_id,
                                  a.cod_order_actual_delivered_time,
                                  a.cod_order_number,
                                  a.cod_order_placed_time,
                                  a.cod_order_type,
                                  a.cod_order_wish_time,
                                  a.cod_sd_id,
                                  a.cod_total_amount,
                                  a.cod_ui_id,
                                  a.modifiedby,
                                  a.modifiedon,
                                  a.createdby,
                                  a.createdon,
                                  a.cod_order_status,
                                  b.sd_address,
                                  b.sd_name
                              }).ToList();
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();
                        objClsCustomerOrderDetail.OrderId = item.cod_id;
                        objClsCustomerOrderDetail.OrderNumber = item.cod_order_number;
                        if (item.cod_order_placed_time != null)
                        {
                            objClsCustomerOrderDetail.OrderPlaceTime = item.cod_order_placed_time.Value.Date;
                            objClsCustomerOrderDetail.OrderPlaceString = Convert.ToDateTime(item.cod_order_placed_time).ToShortDateString();
                        }
                        if (item.cod_order_actual_delivered_time != null)
                        {
                            objClsCustomerOrderDetail.OrderDeliveredTime = item.cod_order_actual_delivered_time.Value;
                        }
                        if (item.cod_order_wish_time != null)
                        {
                            objClsCustomerOrderDetail.OrderWishTime = item.cod_order_wish_time.Value;
                        }
                        if (item.cod_total_amount != null)
                        {
                            objClsCustomerOrderDetail.TotalAmount = item.cod_total_amount;
                        }
                        if (item.cod_total_amount != null)
                        {

                            objClsCustomerOrderDetail.TotalOrderAmount = Convert.ToDecimal(item.cod_total_amount);
                        }
                        else
                        {
                            objClsCustomerOrderDetail.TotalOrderAmount = Convert.ToDecimal(0);
                        }
                        objClsCustomerOrderDetail.OrderType = item.cod_order_type;
                        objClsCustomerOrderDetail.OrderStatus = item.cod_order_status;
                        objClsCustomerOrderDetail.StoreName = item.sd_name;
                        if (item.cod_ui_id == 0)
                        {
                            objClsCustomerOrderDetail.UserName = "Guest";
                            lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                        }
                        else
                        {
                            var result1 = (from a in dbEntities.tp_customer_order_details
                                           join b in dbEntities.tp_user_information
                                           on a.cod_ui_id equals b.ui_id
                                           where a.cod_isdeleted == false && b.ui_isdeleted == false && b.ui_id == item.cod_ui_id
                                           select new
                                           {
                                               b.ui_userName,
                                               b.ui_firstName,
                                               b.ui_lastName
                                           }).FirstOrDefault();
                            if (result1 != null)
                            {
                                objClsCustomerOrderDetail.UserName = result1.ui_firstName + " " + result1.ui_lastName;
                                lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                            }
                        }
                    }
                }
                lstClsCustomerOrderDetail = lstClsCustomerOrderDetail.OrderByDescending(x => x.OrderPlaceTime).ToList();

            }
            else
            {
                var result = (from a in dbEntities.tp_customer_order_details
                              join b in dbEntities.tp_store_details
                              on a.cod_sd_id equals b.sd_id
                              where a.cod_isdeleted == false && b.sd_isdeleted == false && a.cod_order_status.Contains("Order Placed")
                              select new
                              {

                                  a.cod_id,
                                  a.cod_order_actual_delivered_time,
                                  a.cod_order_number,
                                  a.cod_order_placed_time,
                                  a.cod_order_type,
                                  a.cod_order_wish_time,
                                  a.cod_sd_id,
                                  a.cod_total_amount,
                                  a.cod_ui_id,
                                  a.modifiedby,
                                  a.modifiedon,
                                  a.createdby,
                                  a.createdon,
                                  a.cod_order_status,
                                  b.sd_address,
                                  b.sd_name
                              }).ToList();
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();
                        objClsCustomerOrderDetail.OrderId = item.cod_id;
                        objClsCustomerOrderDetail.OrderNumber = item.cod_order_number;
                        if (item.cod_order_placed_time != null)
                        {
                            objClsCustomerOrderDetail.OrderPlaceTime = item.cod_order_placed_time.Value.Date;
                            objClsCustomerOrderDetail.OrderPlaceString = Convert.ToDateTime(item.cod_order_placed_time).ToShortDateString();
                        }
                        if (item.cod_order_actual_delivered_time != null)
                        {
                            objClsCustomerOrderDetail.OrderDeliveredTime = item.cod_order_actual_delivered_time.Value;
                        }
                        if (item.cod_order_wish_time != null)
                        {
                            objClsCustomerOrderDetail.OrderWishTime = item.cod_order_wish_time.Value;
                        }
                        if (item.cod_total_amount != null)
                        {
                            objClsCustomerOrderDetail.TotalAmount = item.cod_total_amount;
                        }
                        if (item.cod_total_amount != null)
                        {

                            objClsCustomerOrderDetail.TotalOrderAmount = Convert.ToDecimal(item.cod_total_amount);
                        }
                        else
                        {
                            objClsCustomerOrderDetail.TotalOrderAmount = Convert.ToDecimal(0);
                        }
                        objClsCustomerOrderDetail.OrderType = item.cod_order_type;
                        objClsCustomerOrderDetail.OrderStatus = item.cod_order_status;
                        objClsCustomerOrderDetail.StoreName = item.sd_name;
                        if (item.cod_ui_id == 0)
                        {
                            objClsCustomerOrderDetail.UserName = "Guest";
                            lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                        }
                        else
                        {
                            var result1 = (from a in dbEntities.tp_customer_order_details
                                           join b in dbEntities.tp_user_information
                                           on a.cod_ui_id equals b.ui_id
                                           where a.cod_isdeleted == false && b.ui_isdeleted == false && b.ui_id == item.cod_ui_id
                                           select new
                                           {
                                               b.ui_userName,
                                               b.ui_firstName,
                                               b.ui_lastName
                                           }).FirstOrDefault();
                            if (result1 != null)
                            {
                                objClsCustomerOrderDetail.UserName = result1.ui_firstName + " " + result1.ui_lastName;
                                lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                            }
                        }
                    }
                }
                lstClsCustomerOrderDetail = lstClsCustomerOrderDetail.OrderByDescending(x => x.OrderPlaceTime).ToList();
            }

        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsCustomerOrderDetail;
    }

    public List<ClsCustomerOrderDetail> GetOrderListForCompletedOrder(DateTime FromDate, DateTime ToDate, string SerarchText = null)
    {
        List<ClsCustomerOrderDetail> lstClsCustomerOrderDetail = new List<ClsCustomerOrderDetail>();
        try
        {
            if (SerarchText != null && SerarchText != "" && FromDate != Convert.ToDateTime("1/1/1900 12:00:00 AM") && ToDate != Convert.ToDateTime("1/1/1900 12:00:00 AM"))
            {
                var result = (from a in dbEntities.tp_customer_order_details
                              join b in dbEntities.tp_store_details
                              on a.cod_sd_id equals b.sd_id
                              where a.cod_isdeleted == false && b.sd_isdeleted == false && a.cod_order_number.Contains(SerarchText) && a.cod_order_status.Contains("Order Completed") &&
                               (System.Data.Entity.DbFunctions.TruncateTime(a.cod_order_placed_time) >= System.Data.Entity.DbFunctions.TruncateTime(FromDate.Date) &&
                                  System.Data.Entity.DbFunctions.TruncateTime(a.cod_order_placed_time) <= System.Data.Entity.DbFunctions.TruncateTime(ToDate.Date))
                              select new
                              {

                                  a.cod_id,
                                  a.cod_order_actual_delivered_time,
                                  a.cod_order_number,
                                  a.cod_order_placed_time,
                                  a.cod_order_type,
                                  a.cod_order_wish_time,
                                  a.cod_sd_id,
                                  a.cod_total_amount,
                                  a.cod_ui_id,
                                  a.modifiedby,
                                  a.modifiedon,
                                  a.createdby,
                                  a.createdon,
                                  a.cod_order_status,
                                  b.sd_address,
                                  b.sd_name
                              }).ToList();
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();
                        objClsCustomerOrderDetail.OrderId = item.cod_id;
                        objClsCustomerOrderDetail.OrderNumber = item.cod_order_number;
                        if (item.cod_order_placed_time != null)
                        {
                            objClsCustomerOrderDetail.OrderPlaceTime = item.cod_order_placed_time.Value.Date;
                            objClsCustomerOrderDetail.OrderPlaceString = Convert.ToDateTime(item.cod_order_placed_time).ToShortDateString();
                        }
                        if (item.cod_order_actual_delivered_time != null)
                        {
                            objClsCustomerOrderDetail.OrderDeliveredTime = item.cod_order_actual_delivered_time.Value;
                        }
                        if (item.cod_order_wish_time != null)
                        {
                            objClsCustomerOrderDetail.OrderWishTime = item.cod_order_wish_time.Value;
                        }
                        if (item.cod_total_amount != null)
                        {
                            objClsCustomerOrderDetail.TotalAmount = item.cod_total_amount;
                        }
                        if (item.cod_total_amount != null)
                        {

                            objClsCustomerOrderDetail.TotalOrderAmount = Convert.ToDecimal(item.cod_total_amount);
                        }
                        else
                        {
                            objClsCustomerOrderDetail.TotalOrderAmount = Convert.ToDecimal(0);
                        }
                        objClsCustomerOrderDetail.OrderType = item.cod_order_type;
                        objClsCustomerOrderDetail.OrderStatus = item.cod_order_status;
                        objClsCustomerOrderDetail.StoreName = item.sd_name;
                        if (item.cod_ui_id == 0)
                        {
                            objClsCustomerOrderDetail.UserName = "Guest";
                            lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                        }
                        else
                        {
                            var result1 = (from a in dbEntities.tp_customer_order_details
                                           join b in dbEntities.tp_user_information
                                           on a.cod_ui_id equals b.ui_id
                                           where a.cod_isdeleted == false && b.ui_isdeleted == false && b.ui_id == item.cod_ui_id
                                           select new
                                           {
                                               b.ui_userName,
                                               b.ui_firstName,
                                               b.ui_lastName
                                           }).FirstOrDefault();
                            if (result1 != null)
                            {
                                objClsCustomerOrderDetail.UserName = result1.ui_firstName + " " + result1.ui_lastName;
                                lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                            }
                        }
                    }
                }
                lstClsCustomerOrderDetail = lstClsCustomerOrderDetail.OrderByDescending(x => x.OrderPlaceTime).ToList();
            }
            else if ((SerarchText == null || SerarchText == "") && FromDate != Convert.ToDateTime("1/1/1900 12:00:00 AM") && ToDate != Convert.ToDateTime("1/1/1900 12:00:00 AM"))
            {

                var result = (from a in dbEntities.tp_customer_order_details
                              join b in dbEntities.tp_store_details
                              on a.cod_sd_id equals b.sd_id
                              where a.cod_isdeleted == false && b.sd_isdeleted == false && a.cod_order_status.Contains("Order Completed") && (System.Data.Entity.DbFunctions.TruncateTime(a.cod_order_placed_time) >= System.Data.Entity.DbFunctions.TruncateTime(FromDate.Date) &&
                                  System.Data.Entity.DbFunctions.TruncateTime(a.cod_order_placed_time) <= System.Data.Entity.DbFunctions.TruncateTime(ToDate.Date))

                              select new
                              {

                                  a.cod_id,
                                  a.cod_order_actual_delivered_time,
                                  a.cod_order_number,
                                  a.cod_order_placed_time,
                                  a.cod_order_type,
                                  a.cod_order_wish_time,
                                  a.cod_sd_id,
                                  a.cod_total_amount,
                                  a.cod_ui_id,
                                  a.modifiedby,
                                  a.modifiedon,
                                  a.createdby,
                                  a.createdon,
                                  a.cod_order_status,
                                  b.sd_address,
                                  b.sd_name
                              }).ToList();
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();
                        objClsCustomerOrderDetail.OrderId = item.cod_id;
                        objClsCustomerOrderDetail.OrderNumber = item.cod_order_number;
                        if (item.cod_order_placed_time != null)
                        {
                            objClsCustomerOrderDetail.OrderPlaceTime = item.cod_order_placed_time.Value.Date;
                            objClsCustomerOrderDetail.OrderPlaceString = Convert.ToDateTime(item.cod_order_placed_time).ToShortDateString();
                        }
                        if (item.cod_order_actual_delivered_time != null)
                        {
                            objClsCustomerOrderDetail.OrderDeliveredTime = item.cod_order_actual_delivered_time.Value;
                        }
                        if (item.cod_order_wish_time != null)
                        {
                            objClsCustomerOrderDetail.OrderWishTime = item.cod_order_wish_time.Value;
                        }
                        if (item.cod_total_amount != null)
                        {
                            objClsCustomerOrderDetail.TotalAmount = item.cod_total_amount;
                        }
                        if (item.cod_total_amount != null)
                        {

                            objClsCustomerOrderDetail.TotalOrderAmount = Convert.ToDecimal(item.cod_total_amount);
                        }
                        else
                        {
                            objClsCustomerOrderDetail.TotalOrderAmount = Convert.ToDecimal(0);
                        }
                        objClsCustomerOrderDetail.OrderType = item.cod_order_type;
                        objClsCustomerOrderDetail.OrderStatus = item.cod_order_status;
                        objClsCustomerOrderDetail.StoreName = item.sd_name;
                        if (item.cod_ui_id == 0)
                        {
                            objClsCustomerOrderDetail.UserName = "Guest";
                            lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                        }
                        else
                        {
                            var result1 = (from a in dbEntities.tp_customer_order_details
                                           join b in dbEntities.tp_user_information
                                           on a.cod_ui_id equals b.ui_id
                                           where a.cod_isdeleted == false && b.ui_isdeleted == false && b.ui_id == item.cod_ui_id
                                           select new
                                           {
                                               b.ui_userName,
                                               b.ui_firstName,
                                               b.ui_lastName
                                           }).FirstOrDefault();
                            if (result1 != null)
                            {
                                objClsCustomerOrderDetail.UserName = result1.ui_firstName + " " + result1.ui_lastName;
                                lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                            }
                        }
                    }
                }
                lstClsCustomerOrderDetail = lstClsCustomerOrderDetail.OrderByDescending(x => x.OrderPlaceTime).ToList();
            }
            else if ((SerarchText != null || SerarchText != "") && FromDate == Convert.ToDateTime("1/1/1900 12:00:00 AM") && ToDate == Convert.ToDateTime("1/1/1900 12:00:00 AM"))
            {

                var result = (from a in dbEntities.tp_customer_order_details
                              join b in dbEntities.tp_store_details
                              on a.cod_sd_id equals b.sd_id
                              where a.cod_isdeleted == false && b.sd_isdeleted == false && a.cod_order_status.Contains("Order Completed") && a.cod_order_number.Contains(SerarchText)
                              select new
                              {

                                  a.cod_id,
                                  a.cod_order_actual_delivered_time,
                                  a.cod_order_number,
                                  a.cod_order_placed_time,
                                  a.cod_order_type,
                                  a.cod_order_wish_time,
                                  a.cod_sd_id,
                                  a.cod_total_amount,
                                  a.cod_ui_id,
                                  a.modifiedby,
                                  a.modifiedon,
                                  a.createdby,
                                  a.createdon,
                                  a.cod_order_status,
                                  b.sd_address,
                                  b.sd_name
                              }).ToList();
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();
                        objClsCustomerOrderDetail.OrderId = item.cod_id;
                        objClsCustomerOrderDetail.OrderNumber = item.cod_order_number;
                        if (item.cod_order_placed_time != null)
                        {
                            objClsCustomerOrderDetail.OrderPlaceTime = item.cod_order_placed_time.Value.Date;
                            objClsCustomerOrderDetail.OrderPlaceString = Convert.ToDateTime(item.cod_order_placed_time).ToShortDateString();
                        }
                        if (item.cod_order_actual_delivered_time != null)
                        {
                            objClsCustomerOrderDetail.OrderDeliveredTime = item.cod_order_actual_delivered_time.Value;
                        }
                        if (item.cod_order_wish_time != null)
                        {
                            objClsCustomerOrderDetail.OrderWishTime = item.cod_order_wish_time.Value;
                        }
                        if (item.cod_total_amount != null)
                        {
                            objClsCustomerOrderDetail.TotalAmount = item.cod_total_amount;
                        }
                        if (item.cod_total_amount != null)
                        {

                            objClsCustomerOrderDetail.TotalOrderAmount = Convert.ToDecimal(item.cod_total_amount);
                        }
                        else
                        {
                            objClsCustomerOrderDetail.TotalOrderAmount = Convert.ToDecimal(0);
                        }
                        objClsCustomerOrderDetail.OrderType = item.cod_order_type;
                        objClsCustomerOrderDetail.OrderStatus = item.cod_order_status;
                        objClsCustomerOrderDetail.StoreName = item.sd_name;
                        if (item.cod_ui_id == 0)
                        {
                            objClsCustomerOrderDetail.UserName = "Guest";
                            lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                        }
                        else
                        {
                            var result1 = (from a in dbEntities.tp_customer_order_details
                                           join b in dbEntities.tp_user_information
                                           on a.cod_ui_id equals b.ui_id
                                           where a.cod_isdeleted == false && b.ui_isdeleted == false && b.ui_id == item.cod_ui_id
                                           select new
                                           {
                                               b.ui_userName,
                                               b.ui_firstName,
                                               b.ui_lastName
                                           }).FirstOrDefault();
                            if (result1 != null)
                            {
                                objClsCustomerOrderDetail.UserName = result1.ui_firstName + " " + result1.ui_lastName;
                                lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                            }
                        }
                    }
                }
                lstClsCustomerOrderDetail = lstClsCustomerOrderDetail.OrderByDescending(x => x.OrderPlaceTime).ToList();
            }
            else
            {
                var result = (from a in dbEntities.tp_customer_order_details
                              join b in dbEntities.tp_store_details
                              on a.cod_sd_id equals b.sd_id
                              where a.cod_isdeleted == false && b.sd_isdeleted == false && a.cod_order_status.Contains("Order Completed")
                              select new
                              {

                                  a.cod_id,
                                  a.cod_order_actual_delivered_time,
                                  a.cod_order_number,
                                  a.cod_order_placed_time,
                                  a.cod_order_type,
                                  a.cod_order_wish_time,
                                  a.cod_sd_id,
                                  a.cod_total_amount,
                                  a.cod_ui_id,
                                  a.modifiedby,
                                  a.modifiedon,
                                  a.createdby,
                                  a.createdon,
                                  a.cod_order_status,
                                  b.sd_address,
                                  b.sd_name
                              }).ToList();
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();
                        objClsCustomerOrderDetail.OrderId = item.cod_id;
                        objClsCustomerOrderDetail.OrderNumber = item.cod_order_number;
                        if (item.cod_order_placed_time != null)
                        {
                            objClsCustomerOrderDetail.OrderPlaceTime = item.cod_order_placed_time.Value.Date;
                            objClsCustomerOrderDetail.OrderPlaceString = Convert.ToDateTime(item.cod_order_placed_time).ToShortDateString();
                        }
                        if (item.cod_order_actual_delivered_time != null)
                        {
                            objClsCustomerOrderDetail.OrderDeliveredTime = item.cod_order_actual_delivered_time.Value;
                        }
                        if (item.cod_order_wish_time != null)
                        {
                            objClsCustomerOrderDetail.OrderWishTime = item.cod_order_wish_time.Value;
                        }
                        if (item.cod_total_amount != null)
                        {
                            objClsCustomerOrderDetail.TotalAmount = item.cod_total_amount;
                        }
                        if (item.cod_total_amount != null)
                        {

                            objClsCustomerOrderDetail.TotalOrderAmount = Convert.ToDecimal(item.cod_total_amount);
                        }
                        else
                        {
                            objClsCustomerOrderDetail.TotalOrderAmount = Convert.ToDecimal(0);
                        }
                        objClsCustomerOrderDetail.OrderType = item.cod_order_type;
                        objClsCustomerOrderDetail.OrderStatus = item.cod_order_status;
                        objClsCustomerOrderDetail.StoreName = item.sd_name;
                        if (item.cod_ui_id == 0)
                        {
                            objClsCustomerOrderDetail.UserName = "Guest";
                            lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                        }
                        else
                        {
                            var result1 = (from a in dbEntities.tp_customer_order_details
                                           join b in dbEntities.tp_user_information
                                           on a.cod_ui_id equals b.ui_id
                                           where a.cod_isdeleted == false && b.ui_isdeleted == false && b.ui_id == item.cod_ui_id
                                           select new
                                           {
                                               b.ui_userName,
                                               b.ui_firstName,
                                               b.ui_lastName
                                           }).FirstOrDefault();
                            if (result1 != null)
                            {
                                objClsCustomerOrderDetail.UserName = result1.ui_firstName + " " + result1.ui_lastName;
                                lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                            }
                        }
                    }
                }
                lstClsCustomerOrderDetail = lstClsCustomerOrderDetail.OrderByDescending(x => x.OrderPlaceTime).ToList();
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsCustomerOrderDetail;
    }

    public List<ClsCustomerOrderDetail> GetOrderListForCancelledOrder(DateTime FromDate, DateTime ToDate, string SerarchText = null)
    {
        List<ClsCustomerOrderDetail> lstClsCustomerOrderDetail = new List<ClsCustomerOrderDetail>();
        try
        {
            if (SerarchText != null && SerarchText != "" && FromDate != Convert.ToDateTime("1/1/1900 12:00:00 AM") && ToDate != Convert.ToDateTime("1/1/1900 12:00:00 AM"))
            {
                var result = (from a in dbEntities.tp_customer_order_details
                              join b in dbEntities.tp_store_details
                              on a.cod_sd_id equals b.sd_id
                              where a.cod_isdeleted == false && b.sd_isdeleted == false && a.cod_order_number.Contains(SerarchText) && a.cod_order_status.Contains("Order Cancelled") &&
                               (System.Data.Entity.DbFunctions.TruncateTime(a.cod_order_placed_time) >= System.Data.Entity.DbFunctions.TruncateTime(FromDate.Date) &&
                                  System.Data.Entity.DbFunctions.TruncateTime(a.cod_order_placed_time) <= System.Data.Entity.DbFunctions.TruncateTime(ToDate.Date))
                              select new
                              {

                                  a.cod_id,
                                  a.cod_order_actual_delivered_time,
                                  a.cod_order_number,
                                  a.cod_order_placed_time,
                                  a.cod_order_type,
                                  a.cod_order_wish_time,
                                  a.cod_sd_id,
                                  a.cod_total_amount,
                                  a.cod_ui_id,
                                  a.modifiedby,
                                  a.modifiedon,
                                  a.createdby,
                                  a.createdon,
                                  a.cod_order_status,
                                  b.sd_address,
                                  b.sd_name
                              }).ToList();
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();
                        objClsCustomerOrderDetail.OrderId = item.cod_id;
                        objClsCustomerOrderDetail.OrderNumber = item.cod_order_number;
                        if (item.cod_order_placed_time != null)
                        {
                            objClsCustomerOrderDetail.OrderPlaceTime = item.cod_order_placed_time.Value.Date;
                            objClsCustomerOrderDetail.OrderPlaceString = Convert.ToDateTime(item.cod_order_placed_time).ToShortDateString();
                        }
                        if (item.cod_order_actual_delivered_time != null)
                        {
                            objClsCustomerOrderDetail.OrderDeliveredTime = item.cod_order_actual_delivered_time.Value;
                        }
                        if (item.cod_order_wish_time != null)
                        {
                            objClsCustomerOrderDetail.OrderWishTime = item.cod_order_wish_time.Value;
                        }
                        if (item.cod_total_amount != null)
                        {
                            objClsCustomerOrderDetail.TotalAmount = item.cod_total_amount;
                        }
                        if (item.cod_total_amount != null)
                        {

                            objClsCustomerOrderDetail.TotalOrderAmount = Convert.ToDecimal(item.cod_total_amount);
                        }
                        else
                        {
                            objClsCustomerOrderDetail.TotalOrderAmount = Convert.ToDecimal(0);
                        }
                        objClsCustomerOrderDetail.OrderType = item.cod_order_type;
                        objClsCustomerOrderDetail.OrderStatus = item.cod_order_status;
                        objClsCustomerOrderDetail.StoreName = item.sd_name;
                        if (item.cod_ui_id == 0)
                        {
                            objClsCustomerOrderDetail.UserName = "Guest";
                            lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                        }
                        else
                        {
                            var result1 = (from a in dbEntities.tp_customer_order_details
                                           join b in dbEntities.tp_user_information
                                           on a.cod_ui_id equals b.ui_id
                                           where a.cod_isdeleted == false && b.ui_isdeleted == false && b.ui_id == item.cod_ui_id
                                           select new
                                           {
                                               b.ui_userName,
                                               b.ui_firstName,
                                               b.ui_lastName
                                           }).FirstOrDefault();
                            if (result1 != null)
                            {
                                objClsCustomerOrderDetail.UserName = result1.ui_firstName + " " + result1.ui_lastName;
                                lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                            }
                        }
                    }
                }
                lstClsCustomerOrderDetail = lstClsCustomerOrderDetail.OrderByDescending(x => x.OrderPlaceTime).ToList();
            }
            else if ((SerarchText == null || SerarchText == "") && FromDate != Convert.ToDateTime("1/1/1900 12:00:00 AM") && ToDate != Convert.ToDateTime("1/1/1900 12:00:00 AM"))
            {

                var result = (from a in dbEntities.tp_customer_order_details
                              join b in dbEntities.tp_store_details
                              on a.cod_sd_id equals b.sd_id
                              where a.cod_isdeleted == false && b.sd_isdeleted == false && a.cod_order_status.Contains("Order Cancelled") && (System.Data.Entity.DbFunctions.TruncateTime(a.cod_order_placed_time) >= System.Data.Entity.DbFunctions.TruncateTime(FromDate.Date) &&
                                  System.Data.Entity.DbFunctions.TruncateTime(a.cod_order_placed_time) <= System.Data.Entity.DbFunctions.TruncateTime(ToDate.Date))

                              select new
                              {

                                  a.cod_id,
                                  a.cod_order_actual_delivered_time,
                                  a.cod_order_number,
                                  a.cod_order_placed_time,
                                  a.cod_order_type,
                                  a.cod_order_wish_time,
                                  a.cod_sd_id,
                                  a.cod_total_amount,
                                  a.cod_ui_id,
                                  a.modifiedby,
                                  a.modifiedon,
                                  a.createdby,
                                  a.createdon,
                                  a.cod_order_status,
                                  b.sd_address,
                                  b.sd_name
                              }).ToList();
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();
                        objClsCustomerOrderDetail.OrderId = item.cod_id;
                        objClsCustomerOrderDetail.OrderNumber = item.cod_order_number;
                        if (item.cod_order_placed_time != null)
                        {
                            objClsCustomerOrderDetail.OrderPlaceTime = item.cod_order_placed_time.Value.Date;
                            objClsCustomerOrderDetail.OrderPlaceString = Convert.ToDateTime(item.cod_order_placed_time).ToShortDateString();
                        }
                        if (item.cod_order_actual_delivered_time != null)
                        {
                            objClsCustomerOrderDetail.OrderDeliveredTime = item.cod_order_actual_delivered_time.Value;
                        }
                        if (item.cod_order_wish_time != null)
                        {
                            objClsCustomerOrderDetail.OrderWishTime = item.cod_order_wish_time.Value;
                        }
                        if (item.cod_total_amount != null)
                        {
                            objClsCustomerOrderDetail.TotalAmount = item.cod_total_amount;
                        }
                        if (item.cod_total_amount != null)
                        {

                            objClsCustomerOrderDetail.TotalOrderAmount = Convert.ToDecimal(item.cod_total_amount);
                        }
                        else
                        {
                            objClsCustomerOrderDetail.TotalOrderAmount = Convert.ToDecimal(0);
                        }
                        objClsCustomerOrderDetail.OrderType = item.cod_order_type;
                        objClsCustomerOrderDetail.OrderStatus = item.cod_order_status;
                        objClsCustomerOrderDetail.StoreName = item.sd_name;
                        if (item.cod_ui_id == 0)
                        {
                            objClsCustomerOrderDetail.UserName = "Guest";
                            lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                        }
                        else
                        {
                            var result1 = (from a in dbEntities.tp_customer_order_details
                                           join b in dbEntities.tp_user_information
                                           on a.cod_ui_id equals b.ui_id
                                           where a.cod_isdeleted == false && b.ui_isdeleted == false && b.ui_id == item.cod_ui_id
                                           select new
                                           {
                                               b.ui_userName,
                                               b.ui_firstName,
                                               b.ui_lastName
                                           }).FirstOrDefault();
                            if (result1 != null)
                            {
                                objClsCustomerOrderDetail.UserName = result1.ui_firstName + " " + result1.ui_lastName;
                                lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                            }
                        }
                    }
                }
                lstClsCustomerOrderDetail = lstClsCustomerOrderDetail.OrderByDescending(x => x.OrderPlaceTime).ToList();
            }
            else if ((SerarchText != null || SerarchText != "") && FromDate == Convert.ToDateTime("1/1/1900 12:00:00 AM") && ToDate == Convert.ToDateTime("1/1/1900 12:00:00 AM"))
            {

                var result = (from a in dbEntities.tp_customer_order_details
                              join b in dbEntities.tp_store_details
                              on a.cod_sd_id equals b.sd_id
                              where a.cod_isdeleted == false && b.sd_isdeleted == false && a.cod_order_status.Contains("Order Cancelled") && a.cod_order_number.Contains(SerarchText)
                              select new
                              {

                                  a.cod_id,
                                  a.cod_order_actual_delivered_time,
                                  a.cod_order_number,
                                  a.cod_order_placed_time,
                                  a.cod_order_type,
                                  a.cod_order_wish_time,
                                  a.cod_sd_id,
                                  a.cod_total_amount,
                                  a.cod_ui_id,
                                  a.modifiedby,
                                  a.modifiedon,
                                  a.createdby,
                                  a.createdon,
                                  a.cod_order_status,
                                  b.sd_address,
                                  b.sd_name
                              }).ToList();
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();
                        objClsCustomerOrderDetail.OrderId = item.cod_id;
                        objClsCustomerOrderDetail.OrderNumber = item.cod_order_number;
                        if (item.cod_order_placed_time != null)
                        {
                            objClsCustomerOrderDetail.OrderPlaceTime = item.cod_order_placed_time.Value.Date;
                            objClsCustomerOrderDetail.OrderPlaceString = Convert.ToDateTime(item.cod_order_placed_time).ToShortDateString();
                        }
                        if (item.cod_order_actual_delivered_time != null)
                        {
                            objClsCustomerOrderDetail.OrderDeliveredTime = item.cod_order_actual_delivered_time.Value;
                        }
                        if (item.cod_order_wish_time != null)
                        {
                            objClsCustomerOrderDetail.OrderWishTime = item.cod_order_wish_time.Value;
                        }
                        if (item.cod_total_amount != null)
                        {
                            objClsCustomerOrderDetail.TotalAmount = item.cod_total_amount;
                        }
                        if (item.cod_total_amount != null)
                        {

                            objClsCustomerOrderDetail.TotalOrderAmount = Convert.ToDecimal(item.cod_total_amount);
                        }
                        else
                        {
                            objClsCustomerOrderDetail.TotalOrderAmount = Convert.ToDecimal(0);
                        }
                        objClsCustomerOrderDetail.OrderType = item.cod_order_type;
                        objClsCustomerOrderDetail.OrderStatus = item.cod_order_status;
                        objClsCustomerOrderDetail.StoreName = item.sd_name;
                        if (item.cod_ui_id == 0)
                        {
                            objClsCustomerOrderDetail.UserName = "Guest";
                            lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                        }
                        else
                        {
                            var result1 = (from a in dbEntities.tp_customer_order_details
                                           join b in dbEntities.tp_user_information
                                           on a.cod_ui_id equals b.ui_id
                                           where a.cod_isdeleted == false && b.ui_isdeleted == false && b.ui_id == item.cod_ui_id
                                           select new
                                           {
                                               b.ui_userName,
                                               b.ui_firstName,
                                               b.ui_lastName
                                           }).FirstOrDefault();
                            if (result1 != null)
                            {
                                objClsCustomerOrderDetail.UserName = result1.ui_firstName + " " + result1.ui_lastName;
                                lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                            }
                        }
                    }
                }
                lstClsCustomerOrderDetail = lstClsCustomerOrderDetail.OrderByDescending(x => x.OrderPlaceTime).ToList();
            }
            else
            {
                var result = (from a in dbEntities.tp_customer_order_details
                              join b in dbEntities.tp_store_details
                              on a.cod_sd_id equals b.sd_id
                              where a.cod_isdeleted == false && b.sd_isdeleted == false && a.cod_order_status.Contains("Order Cancelled")
                              select new
                              {

                                  a.cod_id,
                                  a.cod_order_actual_delivered_time,
                                  a.cod_order_number,
                                  a.cod_order_placed_time,
                                  a.cod_order_type,
                                  a.cod_order_wish_time,
                                  a.cod_sd_id,
                                  a.cod_total_amount,
                                  a.cod_ui_id,
                                  a.modifiedby,
                                  a.modifiedon,
                                  a.createdby,
                                  a.createdon,
                                  a.cod_order_status,
                                  b.sd_address,
                                  b.sd_name
                              }).ToList();
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();
                        objClsCustomerOrderDetail.OrderId = item.cod_id;
                        if (item.cod_order_placed_time != null)
                        {
                            objClsCustomerOrderDetail.OrderPlaceTime = item.cod_order_placed_time.Value.Date;
                            objClsCustomerOrderDetail.OrderPlaceString = Convert.ToDateTime(item.cod_order_placed_time).ToShortDateString();
                        }
                        if (item.cod_order_actual_delivered_time != null)
                        {
                            objClsCustomerOrderDetail.OrderDeliveredTime = item.cod_order_actual_delivered_time.Value;
                        }
                        if (item.cod_order_wish_time != null)
                        {
                            objClsCustomerOrderDetail.OrderWishTime = item.cod_order_wish_time.Value;
                        }
                        if (item.cod_total_amount != null)
                        {
                            objClsCustomerOrderDetail.TotalAmount = item.cod_total_amount;
                        }
                        if (item.cod_total_amount != null)
                        {

                            objClsCustomerOrderDetail.TotalOrderAmount = Convert.ToDecimal(item.cod_total_amount);
                        }
                        else
                        {
                            objClsCustomerOrderDetail.TotalOrderAmount = Convert.ToDecimal(0);
                        }
                        objClsCustomerOrderDetail.OrderType = item.cod_order_type;
                        objClsCustomerOrderDetail.OrderStatus = item.cod_order_status;
                        objClsCustomerOrderDetail.StoreName = item.sd_name;
                        if (item.cod_ui_id == 0)
                        {
                            objClsCustomerOrderDetail.UserName = "Guest";
                            lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                        }
                        else
                        {
                            var result1 = (from a in dbEntities.tp_customer_order_details
                                           join b in dbEntities.tp_user_information
                                           on a.cod_ui_id equals b.ui_id
                                           where a.cod_isdeleted == false && b.ui_isdeleted == false && b.ui_id == item.cod_ui_id
                                           select new
                                           {
                                               b.ui_userName,
                                               b.ui_firstName,
                                               b.ui_lastName
                                           }).FirstOrDefault();
                            if (result1 != null)
                            {
                                objClsCustomerOrderDetail.UserName = result1.ui_firstName + " " + result1.ui_lastName;
                                lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                            }
                        }
                    }
                }
                lstClsCustomerOrderDetail = lstClsCustomerOrderDetail.OrderByDescending(x => x.OrderPlaceTime).ToList();
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsCustomerOrderDetail;
    }


    public string UpdateOrderStatus(int OrderId, string OrderStatus)
    {
        int retValue = 0;
        string retMsg = "FAIL";
        try
        {
            tp_customer_order_details objtp_customer_order_details = new tp_customer_order_details();
            objtp_customer_order_details = dbEntities.tp_customer_order_details.Where(x => x.cod_id == OrderId && x.cod_isdeleted == false).FirstOrDefault();
            if (objtp_customer_order_details != null)
            {
                objtp_customer_order_details.cod_order_status = OrderStatus;
                retValue = dbEntities.SaveChanges();
                if (retValue > 0)
                {
                    retMsg = "SUCCESS";
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return retMsg;
    }

    public List<ClsCustomerOrderDetail> GetDailyTotalSales(DateTime FromDate, DateTime ToDate)
    {
        List<ClsCustomerOrderDetail> lstClsCustomerOrderDetail = new List<ClsCustomerOrderDetail>();
        List<ClsCustomerOrderDetail> ClsCustomerOrderDetaillst = new List<ClsCustomerOrderDetail>();
        try
        {
            if (FromDate != Convert.ToDateTime("1/1/1900 12:00:00 AM") && ToDate != Convert.ToDateTime("1/1/1900 12:00:00 AM"))
            {
                var result = (from a in dbEntities.tp_customer_order_details
                              where a.cod_isdeleted == false && (System.Data.Entity.DbFunctions.TruncateTime(a.cod_order_placed_time) >= System.Data.Entity.DbFunctions.TruncateTime(FromDate.Date) &&
                                  System.Data.Entity.DbFunctions.TruncateTime(a.cod_order_placed_time) <= System.Data.Entity.DbFunctions.TruncateTime(ToDate.Date))
                              select new
                              {

                                  a.cod_order_placed_time,
                                  a.cod_total_amount,
                                  a.cod_id
                              }).ToList();


                if (result != null)
                {
                    foreach (var item in result)
                    {
                        ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();
                        objClsCustomerOrderDetail.OrderId = item.cod_id;
                        if (item.cod_order_placed_time != null && item.cod_order_placed_time.ToString() != "")
                        {
                            objClsCustomerOrderDetail.OrderPlaceTime = item.cod_order_placed_time.Value;
                        }
                        objClsCustomerOrderDetail.TotalOrderAmount = Convert.ToDecimal(item.cod_total_amount);
                        lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                    }
                }
                var Result1 = lstClsCustomerOrderDetail.GroupBy(x => x.OrderPlaceTime.Date).Select(y => new
                {
                    placetime = y.Key,
                    TotalSales = y.Sum(w => w.TotalOrderAmount)

                }).ToList();

                if (Result1 != null)
                {
                    foreach (var item in Result1)
                    {
                        ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();

                        if (item.placetime != null && item.placetime.ToString() != "")
                        {
                            objClsCustomerOrderDetail.OrderPlaceTime = item.placetime;
                            objClsCustomerOrderDetail.OrderPlaceString = Convert.ToDateTime(item.placetime).ToShortDateString();
                        }
                        objClsCustomerOrderDetail.TotalOrderAmount = Convert.ToDecimal(item.TotalSales);
                        ClsCustomerOrderDetaillst.Add(objClsCustomerOrderDetail);
                    }
                }
                ClsCustomerOrderDetaillst = ClsCustomerOrderDetaillst.OrderByDescending(x => x.OrderPlaceTime == DateTime.Now.Date).ThenByDescending(x => x.OrderPlaceTime).ToList();
            }
            else
            {
                var result = (from a in dbEntities.tp_customer_order_details
                              where a.cod_isdeleted == false
                              select new
                              {
                                  a.cod_order_placed_time,
                                  a.cod_total_amount,
                                  a.cod_id
                              }).ToList();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();
                        objClsCustomerOrderDetail.OrderId = item.cod_id;
                        if (item.cod_order_placed_time != null && item.cod_order_placed_time.ToString() != "")
                        {
                            objClsCustomerOrderDetail.OrderPlaceTime = item.cod_order_placed_time.Value;
                        }
                        objClsCustomerOrderDetail.TotalOrderAmount = Convert.ToDecimal(item.cod_total_amount);
                        lstClsCustomerOrderDetail.Add(objClsCustomerOrderDetail);
                    }
                }
                var Result1 = lstClsCustomerOrderDetail.GroupBy(x => x.OrderPlaceTime.Date).Select(y => new
                {
                    placetime = y.Key,
                    TotalSales = y.Sum(w => w.TotalOrderAmount)

                }).ToList();

                if (Result1 != null)
                {
                    foreach (var item in Result1)
                    {
                        ClsCustomerOrderDetail objClsCustomerOrderDetail = new ClsCustomerOrderDetail();

                        if (item.placetime != null && item.placetime.ToString() != "")
                        {
                            objClsCustomerOrderDetail.OrderPlaceTime = item.placetime;
                            objClsCustomerOrderDetail.OrderPlaceString = Convert.ToDateTime(item.placetime).ToShortDateString();
                        }
                        objClsCustomerOrderDetail.TotalOrderAmount = Convert.ToDecimal(item.TotalSales);
                        ClsCustomerOrderDetaillst.Add(objClsCustomerOrderDetail);
                    }
                }
            }
            ClsCustomerOrderDetaillst = ClsCustomerOrderDetaillst.OrderByDescending(x => x.OrderPlaceTime == DateTime.Now.Date).ThenByDescending(x => x.OrderPlaceTime).ToList();

        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return ClsCustomerOrderDetaillst;
    }

    public List<tp_customer_order_details> GetAllOrder()
    {
        List<tp_customer_order_details> lsttp_customer_order_details = new List<tp_customer_order_details>();
        try
        {

            lsttp_customer_order_details = dbEntities.tp_customer_order_details.Where(x => x.cod_isdeleted == false).ToList();

        }
        catch (Exception ex)
        {
            ex.GetBaseException();
        }
        return lsttp_customer_order_details;
    }

    public List<tp_customer_order_details> GetAllPlacedOrder()
    {
        List<tp_customer_order_details> lsttp_customer_order_details = new List<tp_customer_order_details>();
        try
        {

            lsttp_customer_order_details = dbEntities.tp_customer_order_details.Where(x => x.cod_isdeleted == false && x.cod_order_status.Contains("Order Placed")).ToList();

        }
        catch (Exception ex)
        {
            ex.GetBaseException();
        }
        return lsttp_customer_order_details;
    }

    public List<tp_customer_order_details> GetAllCompletedOrder()
    {
        List<tp_customer_order_details> lsttp_customer_order_details = new List<tp_customer_order_details>();
        try
        {

            lsttp_customer_order_details = dbEntities.tp_customer_order_details.Where(x => x.cod_isdeleted == false && x.cod_order_status.Contains("Order Completed")).ToList();

        }
        catch (Exception ex)
        {
            ex.GetBaseException();
        }
        return lsttp_customer_order_details;
    }

    public List<tp_customer_order_details> GetAllCancelledOrder()
    {
        List<tp_customer_order_details> lsttp_customer_order_details = new List<tp_customer_order_details>();
        try
        {

            lsttp_customer_order_details = dbEntities.tp_customer_order_details.Where(x => x.cod_isdeleted == false && x.cod_order_status.Contains("Order Cancelled")).ToList();

        }
        catch (Exception ex)
        {
            ex.GetBaseException();
        }
        return lsttp_customer_order_details;
    }

    //Place Order Method


    public string PlaceOrder(string name, string address, string email, string city, int stateid, string zip, string telephone, string DeliveryInstruction, List<ClsProductDetail> lstproduct, int storeId, string totalAmount, int userId, DateTime OrderWishTime, string OrderType, string RandomNumber, string tax, string deliveryCharges)
    {
        int retValue = 0;
        string retMessage = "FAIL";

        tp_customer_order_details dbObjAddOrderDetail = new tp_customer_order_details();
        try
        {


            Random generator = new Random();

            dbObjAddOrderDetail.cod_order_number = "TP" + generator.Next(0, 1000000).ToString("D6");
            dbObjAddOrderDetail.cod_order_status = "Order Placed";
            dbObjAddOrderDetail.cod_ui_id = userId;
            dbObjAddOrderDetail.cod_sd_id = storeId;
            dbObjAddOrderDetail.cod_total_amount = totalAmount;
            dbObjAddOrderDetail.cod_order_placed_time = DateTime.Now;
            dbObjAddOrderDetail.cod_order_wish_time = OrderWishTime;
            dbObjAddOrderDetail.cod_order_type = OrderType;
            dbObjAddOrderDetail.cod_delivery_charge = deliveryCharges;
            dbObjAddOrderDetail.cod_tax = tax;
            dbObjAddOrderDetail.cod_isdeleted = false;
            dbObjAddOrderDetail.createdby = userId;
            dbObjAddOrderDetail.modifiedby = userId;
            dbObjAddOrderDetail.createdon = DateTime.Now;
            dbObjAddOrderDetail.modifiedon = DateTime.Now;
            dbEntities.tp_customer_order_details.Add(dbObjAddOrderDetail);
            retValue = dbEntities.SaveChanges();

            int orderId = dbObjAddOrderDetail.cod_id;

            tp_billing_detail objtp_billing_detail = new tp_billing_detail();
            objtp_billing_detail.tbd_address = address;
            objtp_billing_detail.tbd_city = city;
            objtp_billing_detail.tbd_cod_id = orderId;
            objtp_billing_detail.tbd_delivery_instruction = DeliveryInstruction;
            objtp_billing_detail.tbd_email = email;
            objtp_billing_detail.tbd_isdeleted = false;
            objtp_billing_detail.tbd_name = name;
            objtp_billing_detail.tbd_state_id = stateid;
            objtp_billing_detail.tbd_telephone = telephone;
            objtp_billing_detail.tbd_zipcode = zip;
            objtp_billing_detail.createdby = userId;
            objtp_billing_detail.modifiedby = userId;
            objtp_billing_detail.createdon = DateTime.Now;
            objtp_billing_detail.modifiedon = DateTime.Now;
            dbEntities.tp_billing_detail.Add(objtp_billing_detail);
            retValue = dbEntities.SaveChanges();

            foreach (var item in lstproduct)
            {
                tp_order_product_mapping objtp_order_product_mapping = new tp_order_product_mapping();
                objtp_order_product_mapping.opm_cod_id = orderId;
                objtp_order_product_mapping.opm_pd_id = item.ProductdetailId;
                objtp_order_product_mapping.opm_pp_id = item.PropertiesId;
                objtp_order_product_mapping.opm_price = item.Price.ToString();
                objtp_order_product_mapping.opm_quantity = item.Quantity;
                objtp_order_product_mapping.opm_Comment = item.Comment;
                dbEntities.tp_order_product_mapping.Add(objtp_order_product_mapping);
                retValue = dbEntities.SaveChanges();

                //if (item.SizeName != "-"  && item.SizeId!=0)
                //{
                //    tp_product_properties objtp_product_properties = new tp_product_properties();
                //    objtp_product_properties.pd_id = item.ProductdetailId;
                //    objtp_product_properties.pp_isdeleted = false;
                //    objtp_product_properties.pp_price = item.Price.ToString();
                //    objtp_product_properties.ps_id = item.SizeId;
                //    dbEntities.tp_product_properties.Add(objtp_product_properties);
                //    dbEntities.SaveChanges();
                //}
            }

            foreach (var item in lstproduct)
            {
                tp_cart_detail objtp_cart_detail = new tp_cart_detail();
                //if (userId != 0)
                //{
                //    objtp_cart_detail = dbEntities.tp_cart_detail.Where(x => x.cd_ui_id == userId && x.cd_pi_id == ProductId).FirstOrDefault();
                //}
                //else
                //{
                //    objtp_cart_detail = dbEntities.tp_cart_detail.Where(x => x.cd_random_number == RandomNumber && x.cd_pi_id == ProductId).FirstOrDefault();
                //}
                objtp_cart_detail = dbEntities.tp_cart_detail.Where(x => x.cd_id == item.CartId).FirstOrDefault();
                if (objtp_cart_detail != null)
                {
                    objtp_cart_detail.cd_pi_id = item.ProductdetailId;
                    objtp_cart_detail.cd_pifd_id = item.IngredientFactId;
                    objtp_cart_detail.cd_si_id = item.SizeId;
                    objtp_cart_detail.cd_pp_id = item.PropertiesId;
                    objtp_cart_detail.cd_quantity = item.Quantity;
                    objtp_cart_detail.cd_random_number = RandomNumber;
                    objtp_cart_detail.cd_takeaway_price = item.Price.ToString();
                    objtp_cart_detail.cd_ui_id = userId;
                    objtp_cart_detail.createdby = userId;
                    objtp_cart_detail.createdon = DateTime.Now;
                    objtp_cart_detail.modifiedby = userId;
                    objtp_cart_detail.modifiedon = DateTime.Now;
                    objtp_cart_detail.cd_isdeleted = false;
                    objtp_cart_detail.cd_comment = item.Comment;
                    //dbEntities.tp_cart_detail.Add(objtp_cart_detail);
                    retValue = dbEntities.SaveChanges();
                }
            }

            foreach (var item in lstproduct)
            {
                //List<tp_cart_ingredient_mapping> lsttp_cart_ingredient_mapping = new List<tp_cart_ingredient_mapping>();
                //lsttp_cart_ingredient_mapping = dbEntities.tp_cart_ingredient_mapping.Where(x => x.cim_cd_id == item.CartId).ToList();
                //foreach(var item1 in lsttp_cart_ingredient_mapping)
                //{
                //    tp_cart_ingredient_mapping objtp_cart_ingredient_mapping = new tp_cart_ingredient_mapping();
                //    objtp_cart_ingredient_mapping = dbEntities.tp_cart_ingredient_mapping.Where(x => x.cim_cd_id==item1.cim_cd_id).FirstOrDefault();
                //    objtp_cart_ingredient_mapping.cim_isdeleted = true;
                //    dbEntities.SaveChanges();
                //}
                string[] ExtraIngredientIdArray = item.ExtraIngredientId.Split(',');
                if (ExtraIngredientIdArray.Length > 0)
                {
                    for (int i = 0; i < ExtraIngredientIdArray.Length; i++)
                    {
                        if (ExtraIngredientIdArray[i] != "")
                        {
                            int ExtraIngredientId = Convert.ToInt32(ExtraIngredientIdArray[i]);
                            tp_cart_ingredient_mapping objtp_cart_ingredient_mapping1 = new tp_cart_ingredient_mapping();
                            objtp_cart_ingredient_mapping1 = dbEntities.tp_cart_ingredient_mapping.Where(x => x.cim_cd_id == item.CartId && x.cim_id_id == ExtraIngredientId).FirstOrDefault();
                            if (objtp_cart_ingredient_mapping1 == null)
                            {
                                tp_cart_ingredient_mapping objtp_cart_ingredient_mapping2 = new tp_cart_ingredient_mapping();
                                objtp_cart_ingredient_mapping2.cim_isdeleted = false;
                                objtp_cart_ingredient_mapping2.cim_id_id = ExtraIngredientId;
                                dbEntities.tp_cart_ingredient_mapping.Add(objtp_cart_ingredient_mapping2);
                                retValue = dbEntities.SaveChanges();
                            }
                        }
                    }
                }
            }
            foreach (var item in lstproduct)
            {
                string[] ExtraIngredientIdArray = item.ExtraIngredientId.Split(',');
                if (ExtraIngredientIdArray.Length > 0)
                {
                    for (int i = 0; i < ExtraIngredientIdArray.Length; i++)
                    {
                        if (ExtraIngredientIdArray[i] != "")
                        {
                            int ExtraIngredientId = Convert.ToInt32(ExtraIngredientIdArray[i]);
                            tp_order_product_ingredients_specification objtp_order_product_ingredients_specification = new tp_order_product_ingredients_specification();
                            objtp_order_product_ingredients_specification.opis_cod_id = orderId;
                            objtp_order_product_ingredients_specification.opis_id_id = ExtraIngredientId;
                            objtp_order_product_ingredients_specification.opis_pd_id = item.ProductdetailId;
                            objtp_order_product_ingredients_specification.opis_pifd_id = item.IngredientFactId;
                            objtp_order_product_ingredients_specification.opis_pp_id = item.PropertiesId;
                            dbEntities.tp_order_product_ingredients_specification.Add(objtp_order_product_ingredients_specification);
                            retValue = dbEntities.SaveChanges();
                        }
                    }
                }
            }

            tp_transaction_detail objtp_transaction_detail = new tp_transaction_detail();
            objtp_transaction_detail.Php_Payment_Amount = totalAmount;
            objtp_transaction_detail.Php_Payment_Status = 1;
            objtp_transaction_detail.td_od_id = orderId;
            objtp_transaction_detail.td_transaction_date = DateTime.Now;
            objtp_transaction_detail.createdby = userId;
            objtp_transaction_detail.createdon = DateTime.Now;
            objtp_transaction_detail.modifiedby = userId;
            objtp_transaction_detail.modifiedon = DateTime.Now;
            dbEntities.tp_transaction_detail.Add(objtp_transaction_detail);
            retValue = dbEntities.SaveChanges();

            if (retValue > 0)
            {
                retMessage = "SUCCESS" + ":" + orderId;
            }
            //    }

            //}
        }

        catch (DbEntityValidationException e)
        {
            foreach (var eve in e.EntityValidationErrors)
            {
                Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                    eve.Entry.Entity.GetType().Name, eve.Entry.State);
                foreach (var ve in eve.ValidationErrors)
                {
                    Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                        ve.PropertyName, ve.ErrorMessage);
                }
            }
            throw;

        }
        return retMessage;
        //return dbObjAddOrderDetail;

    }
    public string GetOrderNumberByOrderId(int orderId)
    {
        string orderNumber = null;
        try
        {
            orderNumber = dbEntities.tp_customer_order_details.Where(x => x.cod_id == orderId && x.cod_isdeleted == false).FirstOrDefault().cod_order_number;
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return orderNumber;
    }
    public string UpdateTransactionHistory(int orderId, int paymentstatus, string transactionId)
    {
        int retValue = 0;
        string retMessage = "FAIL";
        try
        {

            tp_transaction_detail dbObjUpdateTransactionDetail = null;
            dbObjUpdateTransactionDetail = dbEntities.tp_transaction_detail.Where(P => P.td_od_id == orderId).FirstOrDefault();

            dbObjUpdateTransactionDetail.Php_Payment_Status = paymentstatus;
            dbObjUpdateTransactionDetail.Php_PG_Transaction_id = transactionId;
            retValue = dbEntities.SaveChanges();
            if (retValue > 0)
            {
                retMessage = "SUCCESS";
            }

        }
        catch (Exception ex)
        {
            ex.GetBaseException();
        }
        return retMessage;
    }

    public string UpdateBillingDetails(int orderId, string customerName, string customerAddress, string city, int state, string zipCode)
    {
        int retValue = 0;
        string retMessage = "FAIL";
        try
        {

            //tp_transaction_detail dbObjUpdateTransactionDetail = null;
            //dbObjUpdateTransactionDetail = dbEntities.tp_transaction_detail.Where(P => P.td_od_id == orderId).FirstOrDefault();

            //dbObjUpdateTransactionDetail.Php_Payment_Status = paymentstatus;
            //dbObjUpdateTransactionDetail.Php_PG_Transaction_id = transactionId;
            //retValue = dbEntities.SaveChanges();
            //if (retValue > 0)
            //{
            //    retMessage = "SUCCESS";
            //}
            tp_billing_detail dbObjBillingDetails = null;
            dbObjBillingDetails = dbEntities.tp_billing_detail.Where(P => P.tbd_cod_id == orderId).FirstOrDefault();

            dbObjBillingDetails.tbd_name = customerName;
            dbObjBillingDetails.tbd_address = customerAddress;
            dbObjBillingDetails.tbd_city = city;
            dbObjBillingDetails.tbd_state_id = state;
            dbObjBillingDetails.tbd_zipcode = zipCode;

            retValue = dbEntities.SaveChanges();
            if (retValue > 0)
            {
                retMessage = "SUCCESS";
            }
        }
        catch (Exception ex)
        {
            ex.GetBaseException();
        }
        return retMessage;
    }

    public List<ClsProductDetail> GetRecentOrderListByUserId(int userId)
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        try
        {
            var result2 = (from a in dbEntities.tp_customer_order_details
                           join b in dbEntities.tp_order_product_mapping
                            on a.cod_id equals b.opm_cod_id
                           where a.cod_order_status.Contains("Order Completed") && a.cod_ui_id == userId && a.cod_isdeleted == false
                           select new
                           {
                               a.cod_id,
                               a.cod_order_number,
                               b.opm_pd_id,
                               b.opm_pp_id,
                               a.cod_order_placed_time
                           }).ToList();
            result2 = result2.Where(x => Convert.ToDateTime(x.cod_order_placed_time).Date == DateTime.Now.Date).ToList();
            if (result2 != null)
            {
                foreach (var item in result2)
                {
                    ClsProductDetail objClsProductDetail = new ClsProductDetail();
                    objClsProductDetail.OrderId = item.cod_id;
                    if (item.opm_pd_id != null && item.opm_pd_id.ToString() != "")
                    {
                        objClsProductDetail.ProductdetailId = item.opm_pd_id.Value;
                    }
                    if (item.opm_pp_id != null && item.opm_pp_id.ToString() != "")
                    {
                        objClsProductDetail.PropertiesId = item.opm_pp_id.Value;
                    }
                    objClsProductDetail.OrderNumber = item.cod_order_number;
                    lstClsProductDetail.Add(objClsProductDetail);
                }
            }
            lstClsProductDetail = lstClsProductDetail.GroupBy(i => new { i.OrderId }).Select(g => g.First()).ToList();

        }
        catch (Exception ex)
        {
            ex.GetBaseException();
        }
        return lstClsProductDetail;
    }

    public List<ClsProductDetail> GetRecentOrder(int userId, int OrderId)
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        try
        {
            var result2 = (from a in dbEntities.tp_customer_order_details
                           join b in dbEntities.tp_order_product_mapping
                            on a.cod_id equals b.opm_cod_id
                           where a.cod_order_status.Contains("Order Completed") && a.cod_ui_id == userId && a.cod_id == OrderId && a.cod_isdeleted == false
                           select new
                           {
                               a.cod_id,
                               b.opm_pd_id,
                               b.opm_pp_id,
                               a.cod_order_placed_time
                           }).ToList();
            result2 = result2.Where(x => Convert.ToDateTime(x.cod_order_placed_time).Date == DateTime.Now.Date).ToList();
            foreach (var item2 in result2)
            {
                var result3 = dbEntities.tp_product_properties.Where(x => x.pd_id == item2.opm_pd_id && x.pp_id == item2.opm_pp_id && x.pp_isdeleted == false).FirstOrDefault();

                if (result3 != null)
                {
                    var result = (from a in dbEntities.tp_customer_order_details
                                  join b in dbEntities.tp_order_product_mapping
                                  on a.cod_id equals b.opm_cod_id
                                  join c in dbEntities.tp_product_details
                                  on b.opm_pd_id equals c.pd_id
                                  join e in dbEntities.tp_product_properties
                                  on b.opm_pp_id equals e.pp_id
                                  join f in dbEntities.tp_product_sizes
                                  on e.ps_id equals f.ps_id
                                  where a.cod_isdeleted == false && c.pd_isdeleted == false && e.pp_isdeleted == false && f.ps_isdeleted == false && a.cod_order_status.Contains("Order Completed") && a.cod_ui_id == userId && b.opm_pd_id == result3.pd_id

                                  select new
                                  {
                                      a.cod_order_number,
                                      a.cod_id,
                                      a.cod_order_placed_time,
                                      c.pd_name,
                                      b.opm_pd_id,
                                      c.pd_description1,
                                      c.pd_base_price,
                                      b.opm_quantity,
                                      f.ps_id,
                                      e.pp_price,
                                      f.ps_name,
                                      b.opm_pp_id
                                  }).ToList();
                    result = result.Where(x => Convert.ToDateTime(x.cod_order_placed_time).Date == DateTime.Now.Date).ToList();
                    //result = result.GroupBy(i => new { i.opm_pd_id,i.ps_id}).Select(g => g.First()).Where(x=>x.pp_id==item2.opm_pp_id).ToList();

                    if (result != null)
                    {
                        var result5 = result.Where(x => x.opm_pp_id == item2.opm_pp_id).GroupBy(i => new { i.opm_pd_id, i.opm_pp_id }).Select(g => g.First()).ToList();

                        foreach (var item in result5)
                        {
                            ClsProductDetail objClsProductDetail = new ClsProductDetail();
                            objClsProductDetail.OrderId = item.cod_id;
                            objClsProductDetail.ProductdetailId = item.opm_pd_id.Value;
                            objClsProductDetail.ProductName = item.pd_name;
                            objClsProductDetail.Description = item.pd_description1;
                            objClsProductDetail.Quantity = item.opm_quantity.Value;
                            objClsProductDetail.Price = Convert.ToDecimal(item.pp_price) * objClsProductDetail.Quantity;
                            objClsProductDetail.SizeName = item.ps_name;
                            ClsProductDetail clsProductDetailobj = new ClsProductDetail();
                            var resullt4 = (from a in dbEntities.tp_ingredient_details
                                            join b in dbEntities.tp_ingredient_product_mapping
                                            on a.id_id equals b.id_id
                                            where b.pd_id == objClsProductDetail.ProductdetailId && b.iipm_isDefault == true && a.id_isdeleted == false && b.ipm_isdeleted == false
                                            select new
                                            {
                                                a.id_price,
                                                a.id_name
                                            }).ToList();

                            if (resullt4 != null)
                            {
                                foreach (var item1 in resullt4)
                                {
                                    //for (int i = 0; i < objClsProductDetail.Quantity; i++)
                                    //{
                                    //    objClsProductDetail.Price = Convert.ToDecimal(objClsProductDetail.Price) + Convert.ToDecimal(item1.id_price);

                                    //}
                                    if (objClsProductDetail.IngredientName == "" || objClsProductDetail.IngredientName == null)
                                    {
                                        objClsProductDetail.IngredientName = item1.id_name;
                                    }
                                    else
                                    {
                                        objClsProductDetail.IngredientName = objClsProductDetail.IngredientName + "," + item1.id_name;
                                    }
                                }
                            }
                            var resullt1 = (from a in dbEntities.tp_order_product_ingredients_specification
                                            join b in dbEntities.tp_ingredient_details
                                            on a.opis_id_id equals b.id_id
                                            where a.opis_cod_id == objClsProductDetail.OrderId && a.opis_pd_id == objClsProductDetail.ProductdetailId && b.id_isdeleted == false
                                            select new
                                            {
                                                b.id_price,
                                                b.id_name
                                            }).ToList();

                            if (resullt1 != null)
                            {
                                foreach (var item1 in resullt1)
                                {
                                    for (int i = 0; i < objClsProductDetail.Quantity; i++)
                                    {
                                        objClsProductDetail.Price = Convert.ToDecimal(objClsProductDetail.Price) + Convert.ToDecimal(item1.id_price);
                                    }
                                    if (objClsProductDetail.ExtraIngredient == "" || objClsProductDetail.ExtraIngredient == null)
                                    {
                                        objClsProductDetail.ExtraIngredient = item1.id_name;
                                    }
                                    else
                                    {
                                        objClsProductDetail.ExtraIngredient = objClsProductDetail.ExtraIngredient + "," + item1.id_name;
                                    }
                                }
                            }

                            lstClsProductDetail.Add(objClsProductDetail);
                        }
                    }
                }
                else
                {
                    var result = (from a in dbEntities.tp_customer_order_details
                                  join b in dbEntities.tp_order_product_mapping
                                  on a.cod_id equals b.opm_cod_id
                                  join c in dbEntities.tp_product_details
                                  on b.opm_pd_id equals c.pd_id
                                  where a.cod_isdeleted == false && c.pd_isdeleted == false && a.cod_order_status.Contains("Order Completed") && a.cod_ui_id == userId && b.opm_pd_id == item2.opm_pd_id
                                  select new
                                  {
                                      a.cod_order_number,
                                      a.cod_id,
                                      a.cod_order_placed_time,
                                      c.pd_name,
                                      b.opm_pd_id,
                                      c.pd_description1,
                                      c.pd_base_price,
                                      b.opm_quantity,

                                  }).ToList();
                    result = result.Where(x => Convert.ToDateTime(x.cod_order_placed_time).Date == DateTime.Now.Date).ToList();
                    result = result.GroupBy(i => i.opm_pd_id).Select(g => g.First()).ToList();

                    if (result != null)
                    {
                        //var result5 = result.GroupBy(i => new { i.opm_pd_id, i.ps_id }).Select(g => g.First()).Where(x => x.pp_id == item2.opm_pp_id).ToList();

                        foreach (var item in result)
                        {
                            ClsProductDetail objClsProductDetail = new ClsProductDetail();
                            objClsProductDetail.OrderId = item.cod_id;
                            objClsProductDetail.ProductdetailId = item.opm_pd_id.Value;
                            objClsProductDetail.ProductName = item.pd_name;
                            objClsProductDetail.Description = item.pd_description1;
                            objClsProductDetail.Quantity = item.opm_quantity.Value;
                            objClsProductDetail.Price = Convert.ToDecimal(item.pd_base_price) * objClsProductDetail.Quantity;
                            objClsProductDetail.SizeName = "-";

                            ClsProductDetail clsProductDetailobj = new ClsProductDetail();
                            var resullt4 = (from a in dbEntities.tp_ingredient_details
                                            join b in dbEntities.tp_ingredient_product_mapping
                                            on a.id_id equals b.id_id
                                            where b.pd_id == objClsProductDetail.ProductdetailId && b.iipm_isDefault == true && a.id_isdeleted == false && b.ipm_isdeleted == false
                                            select new
                                            {
                                                a.id_price,
                                                a.id_name
                                            }).ToList();

                            if (resullt4 != null)
                            {
                                foreach (var item1 in resullt4)
                                {
                                    //for (int i = 0; i < objClsProductDetail.Quantity; i++)
                                    //{
                                    //    objClsProductDetail.Price = Convert.ToDecimal(objClsProductDetail.Price) + Convert.ToDecimal(item1.id_price);
                                    //}
                                    if (objClsProductDetail.IngredientName == "" || objClsProductDetail.IngredientName == null)
                                    {
                                        objClsProductDetail.IngredientName = item1.id_name;
                                    }
                                    else
                                    {
                                        objClsProductDetail.IngredientName = objClsProductDetail.IngredientName + "," + item1.id_name;
                                    }
                                }
                            }
                            var resullt1 = (from a in dbEntities.tp_order_product_ingredients_specification
                                            join b in dbEntities.tp_ingredient_details
                                            on a.opis_id_id equals b.id_id
                                            where b.id_isdeleted == false && a.opis_cod_id == objClsProductDetail.OrderId && a.opis_pd_id == objClsProductDetail.ProductdetailId
                                            select new
                                            {
                                                b.id_price,
                                                b.id_name
                                            }).ToList();

                            if (resullt1 != null)
                            {
                                foreach (var item1 in resullt1)
                                {
                                    for (int i = 0; i < objClsProductDetail.Quantity; i++)
                                    {
                                        objClsProductDetail.Price = Convert.ToDecimal(objClsProductDetail.Price) + Convert.ToDecimal(item1.id_price);
                                    }
                                    if (objClsProductDetail.ExtraIngredient == "" || objClsProductDetail.ExtraIngredient == null)
                                    {
                                        objClsProductDetail.ExtraIngredient = item1.id_name;
                                    }
                                    else
                                    {
                                        objClsProductDetail.ExtraIngredient = objClsProductDetail.ExtraIngredient + "," + item1.id_name;
                                    }
                                }
                            }
                            lstClsProductDetail.Add(objClsProductDetail);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ex.GetBaseException();
        }
        return lstClsProductDetail;
    }

    public List<ClsProductDetail> GetExtraIngredient(int ProductdetailId, int OrderId)
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        try
        {


            var resullt1 = (from a in dbEntities.tp_order_product_ingredients_specification
                            join b in dbEntities.tp_ingredient_details
                            on a.opis_id_id equals b.id_id
                            where a.opis_cod_id == OrderId && a.opis_pd_id == ProductdetailId
                            select new
                            {
                                b.id_price,
                                b.id_name
                            }).ToList();

            if (resullt1 != null)
            {
                foreach (var item1 in resullt1)
                {
                    ClsProductDetail objClsProductDetail = new ClsProductDetail();
                    // for (int i = 0; i < objClsProductDetail.Quantity; i++)
                    // {
                    objClsProductDetail.IngredientPrice = item1.id_price;
                    // }
                    //if (objClsProductDetail.ExtraIngredient == "" || objClsProductDetail.ExtraIngredient == null)
                    // {
                    objClsProductDetail.ExtraIngredient = item1.id_name;
                    // }
                    //else
                    //{
                    //    objClsProductDetail.ExtraIngredient = objClsProductDetail.ExtraIngredient + "," + item1.id_name;
                    //}
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
    //public List<ClsProductDetail> GetRecentOrderExtraIngredientPrice(int OrderId, int ProductId)
    //{
    //    List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
    //    try
    //    {
    //        var resullt1 = (from a in dbEntities.tp_order_product_ingredients_specification
    //                        join b in dbEntities.tp_ingredient_details
    //                        on a.opis_id_id equals b.id_id
    //                        where a.opis_cod_id == OrderId && a.opis_pd_id == ProductId
    //                        select new
    //                        {
    //                            b.id_price,
    //                            b.id_name
    //                        }).ToList();

    //        if (resullt1 != null)
    //        {
    //            foreach (var item1 in resullt1)
    //            {
    //                ClsProductDetail objClsProductDetail = new ClsProductDetail();
    //                objClsProductDetail.ExtraIngredient = item1.id_name;
    //                objClsProductDetail.Price =Convert.ToDecimal(item1.id_price);
    //                lstClsProductDetail.Add(objClsProductDetail);
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        ErrorHandler.WriteError(ex);
    //    }
    //    return lstClsProductDetail;
    //}
    public List<ClsProductDetail> GetLatestPreviousOrderCount(int userId)
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();

        try
        {
            var resu = (from a in dbEntities.tp_customer_order_details
                        where a.cod_order_status.Contains("Order Completed") && a.cod_ui_id == userId && a.cod_isdeleted == false
                        select new
                        {
                            a.cod_id,
                            a.cod_order_number,
                            a.cod_order_placed_time
                        }).ToList();
            if (resu != null)
            {
                resu = resu.Where(x => Convert.ToDateTime(x.cod_order_placed_time).Date != DateTime.Now.Date).ToList();
            }
            var resu11 = resu.OrderByDescending(x => Convert.ToDateTime(x.cod_order_placed_time)).ToList();
            var resul = resu11.FirstOrDefault();
            if (resul != null)
            {
                ClsProductDetail objClsProductDetail = new ClsProductDetail();
                objClsProductDetail.OrderId = resul.cod_id;
                if (resul.cod_id != null && resul.cod_id.ToString() != "")
                {
                    objClsProductDetail.OrderId = resul.cod_id;
                }
                objClsProductDetail.OrderNumber = resul.cod_order_number;
                lstClsProductDetail.Add(objClsProductDetail);
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductDetail;
    }

    public List<ClsProductDetail> GetLatestPreviousOrder(int userId)
    {
        List<ClsProductDetail> lstClsProductDetail = new List<ClsProductDetail>();
        ClsProductDetail ClsProductDetail = new ClsProductDetail();
        try
        {
            var resu = (from a in dbEntities.tp_customer_order_details
                        where a.cod_order_status.Contains("Order Completed") && a.cod_ui_id == userId && a.cod_isdeleted == false
                        select new
                        {
                            a.cod_id,
                            a.cod_order_placed_time
                        }).ToList();
            if (resu != null)
            {
                resu = resu.Where(x => Convert.ToDateTime(x.cod_order_placed_time).Date != DateTime.Now.Date).ToList();
            }
            var resu11 = resu.OrderByDescending(x => Convert.ToDateTime(x.cod_order_placed_time)).ToList();
            var resul = resu11.FirstOrDefault();
            if (resul != null)
            {
                var result2 = (from a in dbEntities.tp_customer_order_details
                               join b in dbEntities.tp_order_product_mapping
                                on a.cod_id equals b.opm_cod_id
                               where a.cod_isdeleted == false && a.cod_order_status.Contains("Order Completed") && a.cod_ui_id == userId && a.cod_id == resul.cod_id
                               select new
                               {
                                   a.cod_id,
                                   b.opm_pd_id,
                                   b.opm_pp_id,
                                   a.cod_order_placed_time
                               }).ToList();
                result2 = result2.Where(x => Convert.ToDateTime(x.cod_order_placed_time).Date != DateTime.Now.Date).ToList();

                foreach (var item2 in result2)
                {
                    var result3 = dbEntities.tp_product_properties.Where(x => x.pd_id == item2.opm_pd_id && x.pp_id == item2.opm_pp_id && x.pp_isdeleted == false).FirstOrDefault();

                    if (result3 != null)
                    {
                        var result = (from a in dbEntities.tp_customer_order_details
                                      join b in dbEntities.tp_order_product_mapping
                                      on a.cod_id equals b.opm_cod_id
                                      join c in dbEntities.tp_product_details
                                      on b.opm_pd_id equals c.pd_id
                                      join e in dbEntities.tp_product_properties
                                      on b.opm_pp_id equals e.pp_id
                                      join f in dbEntities.tp_product_sizes
                                      on e.ps_id equals f.ps_id
                                      where a.cod_isdeleted == false && c.pd_isdeleted == false && e.pp_isdeleted == false && f.ps_isdeleted == false && a.cod_order_status.Contains("Order Completed") && a.cod_ui_id == userId && b.opm_pd_id == result3.pd_id
                                      select new
                                      {
                                          a.cod_order_number,
                                          a.cod_id,
                                          a.cod_order_placed_time,
                                          c.pd_name,
                                          b.opm_pd_id,
                                          c.pd_description1,
                                          c.pd_base_price,
                                          b.opm_quantity,
                                          f.ps_id,
                                          e.pp_price,
                                          f.ps_name,
                                          b.opm_pp_id
                                      }).ToList();

                        //result = result.GroupBy(i => new { i.opm_pd_id,i.ps_id}).Select(g => g.First()).Where(x=>x.pp_id==item2.opm_pp_id).ToList();
                        result = result.Where(x => Convert.ToDateTime(x.cod_order_placed_time).Date != DateTime.Now.Date).ToList();
                        if (result != null)
                        {
                            var result5 = result.Where(x => x.opm_pp_id == item2.opm_pp_id).GroupBy(i => new { i.opm_pd_id, i.opm_pp_id }).Select(g => g.First()).ToList();

                            foreach (var item in result5)
                            {
                                ClsProductDetail objClsProductDetail = new ClsProductDetail();
                                objClsProductDetail.OrderId = item.cod_id;
                                if (item.opm_pd_id != null && item.opm_pd_id.ToString() != "")
                                {
                                    objClsProductDetail.ProductdetailId = item.opm_pd_id.Value;
                                }
                                objClsProductDetail.ProductName = item.pd_name;
                                objClsProductDetail.Description = item.pd_description1;
                                if (item.opm_quantity != null && item.opm_quantity.ToString() != "")
                                {
                                    objClsProductDetail.Quantity = item.opm_quantity.Value;
                                }

                                objClsProductDetail.OrderNumber = item.cod_order_number;
                                if (item.pp_price != null && item.pp_price.ToString() != "")
                                {
                                    objClsProductDetail.Price = Convert.ToDecimal(item.pp_price) * objClsProductDetail.Quantity;
                                }
                                objClsProductDetail.SizeName = item.ps_name;
                                ClsProductDetail clsProductDetailobj = new ClsProductDetail();
                                var resullt4 = (from a in dbEntities.tp_ingredient_details
                                                join b in dbEntities.tp_ingredient_product_mapping
                                                on a.id_id equals b.id_id
                                                where b.pd_id == objClsProductDetail.ProductdetailId && b.iipm_isDefault == true && a.id_isdeleted == false && b.ipm_isdeleted == false
                                                select new
                                                {
                                                    a.id_price,
                                                    a.id_name
                                                }).ToList();

                                if (resullt4 != null)
                                {
                                    foreach (var item1 in resullt4)
                                    {
                                        //for (int i = 0; i < objClsProductDetail.Quantity; i++)
                                        //{
                                        //    objClsProductDetail.Price = Convert.ToDecimal(objClsProductDetail.Price) + Convert.ToDecimal(item1.id_price);

                                        //}
                                        if (objClsProductDetail.IngredientName == "" || objClsProductDetail.IngredientName == null)
                                        {
                                            objClsProductDetail.IngredientName = item1.id_name;
                                        }
                                        else
                                        {
                                            objClsProductDetail.IngredientName = objClsProductDetail.IngredientName + "," + item1.id_name;
                                        }
                                    }
                                }
                                var resullt1 = (from a in dbEntities.tp_order_product_ingredients_specification
                                                join b in dbEntities.tp_ingredient_details
                                                on a.opis_id_id equals b.id_id
                                                where b.id_isdeleted == false && a.opis_cod_id == objClsProductDetail.OrderId && a.opis_pd_id == objClsProductDetail.ProductdetailId
                                                select new
                                                {
                                                    b.id_price,
                                                    b.id_name
                                                }).ToList();

                                if (resullt1 != null)
                                {
                                    foreach (var item1 in resullt1)
                                    {
                                        for (int i = 0; i < objClsProductDetail.Quantity; i++)
                                        {
                                            objClsProductDetail.Price = Convert.ToDecimal(objClsProductDetail.Price) + Convert.ToDecimal(item1.id_price);
                                        }
                                        if (objClsProductDetail.ExtraIngredient == "" || objClsProductDetail.ExtraIngredient == null)
                                        {
                                            objClsProductDetail.ExtraIngredient = item1.id_name;
                                        }
                                        else
                                        {
                                            objClsProductDetail.ExtraIngredient = objClsProductDetail.ExtraIngredient + "," + item1.id_name;
                                        }
                                    }
                                }

                                lstClsProductDetail.Add(objClsProductDetail);


                            }

                        }
                        //ClsProductDetail = lstClsProductDetail.OrderByDescending(x => x.OrderPlaceTime).FirstOrDefault();
                        //lstClsProductDetail.Clear();
                        //lstClsProductDetail.Add(ClsProductDetail);
                    }
                    else
                    {
                        var result = (from a in dbEntities.tp_customer_order_details
                                      join b in dbEntities.tp_order_product_mapping
                                      on a.cod_id equals b.opm_cod_id
                                      join c in dbEntities.tp_product_details
                                      on b.opm_pd_id equals c.pd_id
                                      where a.cod_isdeleted == false && c.pd_isdeleted == false && a.cod_order_status.Contains("Order Completed") && a.cod_ui_id == userId && b.opm_pd_id == item2.opm_pd_id
                                      select new
                                    {
                                        a.cod_order_number,
                                        a.cod_id,
                                        a.cod_order_placed_time,
                                        c.pd_name,
                                        b.opm_pd_id,
                                        c.pd_description1,
                                        c.pd_base_price,
                                        b.opm_quantity,

                                    }).ToList();
                        result = result.GroupBy(i => i.opm_pd_id).Select(g => g.First()).ToList();
                        result = result.Where(x => Convert.ToDateTime(x.cod_order_placed_time).Date != DateTime.Now.Date).ToList();
                        if (result != null)
                        {
                            //var result5 = result.GroupBy(i => new { i.opm_pd_id, i.ps_id }).Select(g => g.First()).Where(x => x.pp_id == item2.opm_pp_id).ToList();

                            foreach (var item in result)
                            {
                                ClsProductDetail objClsProductDetail = new ClsProductDetail();
                                objClsProductDetail.OrderId = item.cod_id;
                                objClsProductDetail.ProductdetailId = item.opm_pd_id.Value;
                                objClsProductDetail.ProductName = item.pd_name;
                                objClsProductDetail.Description = item.pd_description1;
                                objClsProductDetail.Quantity = item.opm_quantity.Value;
                                objClsProductDetail.OrderNumber = item.cod_order_number;
                                objClsProductDetail.Price = Convert.ToDecimal(item.pd_base_price) * objClsProductDetail.Quantity;
                                objClsProductDetail.SizeName = "-";

                                ClsProductDetail clsProductDetailobj = new ClsProductDetail();
                                var resullt4 = (from a in dbEntities.tp_ingredient_details
                                                join b in dbEntities.tp_ingredient_product_mapping
                                                on a.id_id equals b.id_id
                                                where a.id_isdeleted == false && b.ipm_isdeleted == false && b.pd_id == objClsProductDetail.ProductdetailId && b.iipm_isDefault == true
                                                select new
                                                {
                                                    a.id_price,
                                                    a.id_name
                                                }).ToList();

                                if (resullt4 != null)
                                {
                                    foreach (var item1 in resullt4)
                                    {
                                        //for (int i = 0; i < objClsProductDetail.Quantity; i++)
                                        //{
                                        //    objClsProductDetail.Price = Convert.ToDecimal(objClsProductDetail.Price) + Convert.ToDecimal(item1.id_price);
                                        //}
                                        if (objClsProductDetail.IngredientName == "" || objClsProductDetail.IngredientName == null)
                                        {
                                            objClsProductDetail.IngredientName = item1.id_name;
                                        }
                                        else
                                        {
                                            objClsProductDetail.IngredientName = objClsProductDetail.IngredientName + "," + item1.id_name;
                                        }
                                    }
                                }
                                var resullt1 = (from a in dbEntities.tp_order_product_ingredients_specification
                                                join b in dbEntities.tp_ingredient_details
                                                on a.opis_id_id equals b.id_id
                                                where b.id_isdeleted == false && a.opis_cod_id == objClsProductDetail.OrderId && a.opis_pd_id == objClsProductDetail.ProductdetailId
                                                select new
                                                {
                                                    b.id_price,
                                                    b.id_name
                                                }).ToList();

                                if (resullt1 != null)
                                {
                                    foreach (var item1 in resullt1)
                                    {
                                        for (int i = 0; i < objClsProductDetail.Quantity; i++)
                                        {
                                            objClsProductDetail.Price = Convert.ToDecimal(objClsProductDetail.Price) + Convert.ToDecimal(item1.id_price);
                                        }
                                        if (objClsProductDetail.ExtraIngredient == "" || objClsProductDetail.ExtraIngredient == null)
                                        {
                                            objClsProductDetail.ExtraIngredient = item1.id_name;
                                        }
                                        else
                                        {
                                            objClsProductDetail.ExtraIngredient = objClsProductDetail.ExtraIngredient + "," + item1.id_name;
                                        }
                                    }
                                }
                                lstClsProductDetail.Add(objClsProductDetail);

                            }

                        }
                    }
                }
                //ClsProductDetail = lstClsProductDetail.OrderByDescending(x => x.OrderPlaceTime).FirstOrDefault();
                //lstClsProductDetail.Clear();
                //lstClsProductDetail.Add(ClsProductDetail);
                //lstClsProductDetail.Clear();
                //lstClsProductDetail.Add(ClsProductDetail);
            }
        }
        catch (Exception ex)
        {
            ex.GetBaseException();
        }
        return lstClsProductDetail;
    }

    public List<ClsProductDetail> GetUserCartDetail(int UserId, string RandomNumber)
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

                                  a.cd_pp_id,

                              }).ToList();

                if (result != null)
                {
                    // result = result.GroupBy(x => new { x.SizeId, x.cd_pi_id,x.FactId }).Select(g => g.First()).ToList();

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
                            if (item.cd_comment == "" || item.cd_comment == null)
                            {
                                objClsProductDetail.Comment = "-";
                            }
                            else
                            {
                                objClsProductDetail.Comment = item.cd_comment;
                            }
                            objClsProductDetail.OneQuantityPrice = Convert.ToDecimal(item.cd_takeaway_price) / objClsProductDetail.Quantity;
                            if (objClsProductDetail.SizeId == 0)
                            {
                                objClsProductDetail.SizeName = "-";
                            }
                            else
                            {
                                objClsProductDetail.SizeName = item.SizeName;
                            }
                            var result1 = (from a in dbEntities.tp_ingredient_details
                                           join b in dbEntities.tp_cart_ingredient_mapping
                                           on a.id_id equals b.cim_id_id
                                           where b.cim_isdeleted == false && a.id_isdeleted == false && b.cim_cd_id == item.cd_id
                                           select new
                                           {
                                               a.id_id,
                                               a.id_name,
                                               b.cim_id_price
                                           }).ToList();
                            foreach (var item1 in result1)
                            {
                                if (objClsProductDetail.ExtraIngredient == null)
                                {
                                    objClsProductDetail.ExtraIngredient = item1.id_name;
                                }
                                else
                                {
                                    objClsProductDetail.ExtraIngredient = objClsProductDetail.ExtraIngredient + "," + item1.id_name;
                                }

                                if (objClsProductDetail.ExtraIngredientId == null)
                                {
                                    objClsProductDetail.ExtraIngredientId = item1.id_id.ToString();
                                }
                                else
                                {
                                    objClsProductDetail.ExtraIngredientId = objClsProductDetail.ExtraIngredientId.ToString() + "," + item1.id_id;
                                }

                                // objClsProductDetail.OneQuantityPrice = Convert.ToDecimal(item1.id_price) + objClsProductDetail.OneQuantityPrice;
                                if (item.FactName == "Half & half")
                                {
                                    objClsProductDetail.ExtraIngredientPrice = (Convert.ToDecimal(item1.cim_id_price) / 2) + (objClsProductDetail.ExtraIngredientPrice);
                                }
                                else
                                {
                                    objClsProductDetail.ExtraIngredientPrice = (Convert.ToDecimal(item1.cim_id_price)) + objClsProductDetail.ExtraIngredientPrice;
                                }
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
                                                        cim.cim_id_price
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
                                if (item.cd_comment == "" || item.cd_comment == null)
                                {
                                    objClsProductDetail.Comment = "-";
                                }
                                else
                                {
                                    objClsProductDetail.Comment = item.cd_comment;
                                }
                                objClsProductDetail.OneQuantityPrice = Convert.ToDecimal(item.cd_takeaway_price) / objClsProductDetail.Quantity;
                                if (objClsProductDetail.SizeId == 0)
                                {
                                    objClsProductDetail.SizeName = "-";
                                }
                                else
                                {
                                    objClsProductDetail.SizeName = item.SizeName;
                                }

                                var result1 = (from a in dbEntities.tp_ingredient_details
                                               join b in dbEntities.tp_cart_ingredient_mapping
                                               on a.id_id equals b.cim_id_id
                                               where b.cim_isdeleted == false && a.id_isdeleted == false && b.cim_cd_id == item.cd_id
                                               select new
                                               {
                                                   a.id_id,
                                                   a.id_name,
                                                   b.cim_id_price
                                               }).ToList();
                                foreach (var item1 in result1)
                                {
                                    if (objClsProductDetail.ExtraIngredient == null)
                                    {
                                        objClsProductDetail.ExtraIngredient = item1.id_name;
                                    }
                                    else
                                    {
                                        objClsProductDetail.ExtraIngredient = objClsProductDetail.ExtraIngredient + "," + item1.id_name;
                                    }

                                    if (objClsProductDetail.ExtraIngredientId == null)
                                    {
                                        objClsProductDetail.ExtraIngredientId = item1.id_id.ToString();
                                    }
                                    else
                                    {
                                        objClsProductDetail.ExtraIngredientId = objClsProductDetail.ExtraIngredientId.ToString() + "," + item1.id_id;
                                    }
                                    //  objClsProductDetail.OneQuantityPrice = Convert.ToDecimal(item1.id_price) + objClsProductDetail.OneQuantityPrice;

                                    //objClsProductDetail.ExtraIngredientPrice = Convert.ToDecimal(item1.id_price) + objClsProductDetail.ExtraIngredientPrice;
                                    if (item.FactName == "Half & half")
                                    {
                                        objClsProductDetail.ExtraIngredientPrice = (Convert.ToDecimal(item1.cim_id_price) / 2) + (objClsProductDetail.ExtraIngredientPrice);
                                    }
                                    else
                                    {
                                        objClsProductDetail.ExtraIngredientPrice = (Convert.ToDecimal(item1.cim_id_price)) + objClsProductDetail.ExtraIngredientPrice;
                                    }
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
                            if (item.cd_comment == "" || item.cd_comment == null)
                            {
                                objClsProductDetail.Comment = "-";
                            }
                            else
                            {
                                objClsProductDetail.Comment = item.cd_comment;
                            }
                            objClsProductDetail.OneQuantityPrice = Convert.ToDecimal(item.cd_takeaway_price) / objClsProductDetail.Quantity;
                            if (objClsProductDetail.SizeId == 0)
                            {
                                objClsProductDetail.SizeName = "-";
                            }
                            else
                            {
                                objClsProductDetail.SizeName = item.SizeName;
                            }

                            var result1 = (from a in dbEntities.tp_ingredient_details
                                           join b in dbEntities.tp_cart_ingredient_mapping
                                           on a.id_id equals b.cim_id_id
                                           where b.cim_isdeleted == false && a.id_isdeleted == false && b.cim_cd_id == item.cd_id
                                           select new
                                           {
                                               a.id_id,
                                               a.id_name,
                                               b.cim_id_price
                                           }).ToList();
                            foreach (var item1 in result1)
                            {
                                if (objClsProductDetail.ExtraIngredient == null)
                                {
                                    objClsProductDetail.ExtraIngredient = item1.id_name;
                                }
                                else
                                {
                                    objClsProductDetail.ExtraIngredient = objClsProductDetail.ExtraIngredient + "," + item1.id_name;
                                }

                                if (objClsProductDetail.ExtraIngredientId == null)
                                {
                                    objClsProductDetail.ExtraIngredientId = item1.id_id.ToString();
                                }
                                else
                                {
                                    objClsProductDetail.ExtraIngredientId = objClsProductDetail.ExtraIngredientId.ToString() + "," + item1.id_id;
                                }
                                //  objClsProductDetail.OneQuantityPrice = Convert.ToDecimal(item1.id_price) + objClsProductDetail.OneQuantityPrice;
                                // objClsProductDetail.ExtraIngredientPrice = Convert.ToDecimal(item1.id_price) + objClsProductDetail.ExtraIngredientPrice;
                                if (item.FactName == "Half & half")
                                {
                                    objClsProductDetail.ExtraIngredientPrice = (Convert.ToDecimal(item1.cim_id_price) / 2) + (objClsProductDetail.ExtraIngredientPrice);
                                }
                                else
                                {
                                    objClsProductDetail.ExtraIngredientPrice = (Convert.ToDecimal(item1.cim_id_price)) + objClsProductDetail.ExtraIngredientPrice;
                                }
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
                                                       cim.cim_id_price
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
                                                        cim.cim_id_price
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
                                if (item.cd_comment == "" || item.cd_comment == null)
                                {
                                    objClsProductDetail.Comment = "-";
                                }
                                else
                                {
                                    objClsProductDetail.Comment = item.cd_comment;
                                }
                                objClsProductDetail.OneQuantityPrice = Convert.ToDecimal(item.cd_takeaway_price) / objClsProductDetail.Quantity;
                                if (objClsProductDetail.SizeId == 0)
                                {
                                    objClsProductDetail.SizeName = "-";
                                }
                                else
                                {
                                    objClsProductDetail.SizeName = item.SizeName;
                                }

                                var result1 = (from a in dbEntities.tp_ingredient_details
                                               join b in dbEntities.tp_cart_ingredient_mapping
                                               on a.id_id equals b.cim_id_id
                                               where b.cim_isdeleted == false && a.id_isdeleted == false && b.cim_cd_id == item.cd_id
                                               select new
                                               {
                                                   a.id_id,
                                                   a.id_name,
                                                   b.cim_id_price
                                               }).ToList();
                                foreach (var item1 in result1)
                                {
                                    if (objClsProductDetail.ExtraIngredient == null)
                                    {
                                        objClsProductDetail.ExtraIngredient = item1.id_name;
                                    }
                                    else
                                    {
                                        objClsProductDetail.ExtraIngredient = objClsProductDetail.ExtraIngredient + "," + item1.id_name;
                                    }

                                    if (objClsProductDetail.ExtraIngredientId == null)
                                    {
                                        objClsProductDetail.ExtraIngredientId = item1.id_id.ToString();
                                    }
                                    else
                                    {
                                        objClsProductDetail.ExtraIngredientId = objClsProductDetail.ExtraIngredientId.ToString() + "," + item1.id_id;
                                    }
                                    //  objClsProductDetail.OneQuantityPrice = Convert.ToDecimal(item1.id_price) + objClsProductDetail.OneQuantityPrice;
                                    //objClsProductDetail.ExtraIngredientPrice = Convert.ToDecimal(item1.id_price) + objClsProductDetail.ExtraIngredientPrice;
                                    if (item.FactName == "Half & half")
                                    {
                                        objClsProductDetail.ExtraIngredientPrice = (Convert.ToDecimal(item1.cim_id_price) / 2) + (objClsProductDetail.ExtraIngredientPrice);
                                    }
                                    else
                                    {
                                        objClsProductDetail.ExtraIngredientPrice = (Convert.ToDecimal(item1.cim_id_price)) + objClsProductDetail.ExtraIngredientPrice;
                                    }
                                }
                                lstClsProductDetail.Add(objClsProductDetail);
                            }
                        }
                    }
                }
            }
            AddFactInformationToProductList(ref lstClsProductDetail);
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstClsProductDetail;
    }

    private void AddFactInformationToProductList(ref List<ClsProductDetail> lstProIng)
    {
        foreach (ClsProductDetail cpd in lstProIng)
        {
            string[] csIngredientList = cpd.ExtraIngredientId.Split(new char[] { ',' });
            string[] csIngredientName = cpd.ExtraIngredient.Split(new char[] { ',' });

            for (int i = 0; i < csIngredientList.Count(); i++)
            {
                int ingredient = Convert.ToInt32(csIngredientList[i]);
                var result = (from a in dbEntities.tp_cart_ingredient_mapping
                              join b in dbEntities.tp_product_ingredient_fact_detail
                              on a.cim_fact_id equals b.pifd_id
                              where a.cim_id_id == ingredient && a.cim_cd_id == cpd.CartId
                              select new
                              {
                                  b.pifd_name
                              }).ToList();
                foreach (var item1 in result)
                {
                    csIngredientName[i] = csIngredientName[i] + "-" + item1.pifd_name;
                }
            }

            cpd.ExtraIngredient = string.Join(",", csIngredientName);
            //tp_cart_ingredient_mapping objtp_cart_ingredient_mapping = new tp_cart_ingredient_mapping();
            //List<tp_cart_ingredient_mapping> lst = dbEntities.tp_cart_ingredient_mapping.Where(P => P.cim_id_id == Convert.ToInt32(ingId)).ToList<tp_cart_ingredient_mapping>();

        }
    }



    public string CancelOrderByOrderId(int OrderId)
    {
        string retMsg = "FAIL";
        int retValue = 0;
        try
        {
            tp_customer_order_details objtp_customer_order_details = new tp_customer_order_details();
            objtp_customer_order_details = dbEntities.tp_customer_order_details.Where(x => x.cod_id == OrderId && x.cod_isdeleted == false).FirstOrDefault();
            if (objtp_customer_order_details != null)
            {
                objtp_customer_order_details.cod_order_status = "Order Cancelled";
                retValue = dbEntities.SaveChanges();
                if (retValue > 0)
                {
                    retMsg = "SUCCESS";
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return retMsg;
    }

    public tp_customer_order_details GetOrderWishTimeByOrderId(int OrderId)
    {
        tp_customer_order_details objtp_customer_order_details = new tp_customer_order_details();
        try
        {
            objtp_customer_order_details = dbEntities.tp_customer_order_details.Where(x => x.cod_id == OrderId && x.cod_isdeleted == false).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objtp_customer_order_details;
    }

    public ClsUserInformation GetUserInfoIdByOrderId(int orderId)
    {
        ClsUserInformation objClsUserInformation = new ClsUserInformation();


        try
        {
            tp_billing_detail objtp_billing_detail = new tp_billing_detail();
            objtp_billing_detail = dbEntities.tp_billing_detail.Where(x => x.tbd_cod_id == orderId).FirstOrDefault();
            if (objtp_billing_detail != null)
            {
                objClsUserInformation.Email = objtp_billing_detail.tbd_email;
                objClsUserInformation.CustomerName = objtp_billing_detail.tbd_name;
                objClsUserInformation.Addressline1 = objtp_billing_detail.tbd_address;
                objClsUserInformation.TelephoneNo = objtp_billing_detail.tbd_telephone;
                objClsUserInformation.CityName = objtp_billing_detail.tbd_city;
                objClsUserInformation.Pincode = objtp_billing_detail.tbd_zipcode;
                objClsUserInformation.DeliveryInstruction = objtp_billing_detail.tbd_delivery_instruction;

                if (objtp_billing_detail.tbd_state_id != null)
                {
                    objClsUserInformation.StateId = objtp_billing_detail.tbd_state_id.Value;
                }
                tp_state objState = new tp_state();
                objState = dbEntities.tp_state.Where(x => x.tps_id == objClsUserInformation.StateId).FirstOrDefault();
                if (objState != null)
                {
                    objClsUserInformation.StateName = objState.tps_state_name;
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objClsUserInformation;
    }

    public string UpdateOrdertyepByOrderId(int orderId, string OrderType)
    {
        string retMsg = "";
        int retValue = 0;
        try
        {
            tp_customer_order_details objtp_customer_order_details = new tp_customer_order_details();
            objtp_customer_order_details = dbEntities.tp_customer_order_details.Where(x => x.cod_id == orderId && x.cod_isdeleted == false).FirstOrDefault();
            if (objtp_customer_order_details != null)
            {
                objtp_customer_order_details.cod_order_type = OrderType;
                retValue = dbEntities.SaveChanges();
                if (retValue > 0)
                {
                    retMsg = "SUCCESS";
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return retMsg;
    }
}