using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClsTransactionDetail
/// </summary>
public class ClsTransactionDetail
{
    TP_DatabaseEntities dbEntities = new TP_DatabaseEntities();
    public ClsTransactionDetail()
    {

    }
    #region Properties
    private int? m_transaction_order_id;
    private DateTime m_transactionDate;
    private int? m_payment_status;
    private string m_payment_amount;
    private string m_PG_transaction_id;
    private string m_orderNumber;
    private int m_transactionId;
    private string m_paymentStatusString;
    private string m_paymentAmount;
    private decimal m_transactionPaymentAmount;
    private string m_TransactionDateString;

    public string TransactionDateString
    {
        get { return m_TransactionDateString; }
        set { m_TransactionDateString = value; }
    }

    public string PaymentStatusString
    {
        get { return m_paymentStatusString; }
        set { m_paymentStatusString = value; }
    }

    public int TransactionId
    {
        get { return m_transactionId; }
        set { m_transactionId = value; }
    }

    public string OrderNumber
    {
        get { return m_orderNumber; }
        set { m_orderNumber = value; }
    }


    public int? Transaction_order_id
    {
        get
        {
            return m_transaction_order_id;
        }

        set
        {
            m_transaction_order_id = value;
        }
    }



    public int? Payment_status
    {
        get
        {
            return m_payment_status;
        }

        set
        {
            m_payment_status = value;
        }
    }

    public string Payment_amount
    {
        get
        {
            return m_payment_amount;
        }

        set
        {
            m_payment_amount = value;
        }
    }

    public string PG_transaction_id
    {
        get
        {
            return m_PG_transaction_id;
        }

        set
        {
            m_PG_transaction_id = value;
        }
    }

    public DateTime TransactionDate
    {
        get
        {
            return m_transactionDate;
        }

        set
        {
            m_transactionDate = value;
        }
    }

    public string PaymentAmount
    {
        get
        {
            return m_paymentAmount;
        }

        set
        {
            m_paymentAmount = value;
        }
    }

    public decimal TransactionPaymentAmount
    {
        get
        {
            return m_transactionPaymentAmount;
        }

        set
        {
            m_transactionPaymentAmount = value;
        }
    }


    #endregion


    // payment status

    // 1 for in Progress
    // 2 for success
    //  3 for failed

    //Transaction list by PaymentGateway transaction id
    public DataTable GetTransactionDetailList(DateTime fromDate, DateTime toDate, string searchText = null)
    {

        List<ClsTransactionDetail> lstClsTransactionDetail = new List<ClsTransactionDetail>();

        try
        {
            if (searchText != null && searchText != "" && fromDate != Convert.ToDateTime("1/1/1900 12:00:00 AM") && toDate != Convert.ToDateTime("1/1/1900 12:00:00 AM"))
            {
                var result = (from a in dbEntities.tp_transaction_detail
                              join b in dbEntities.tp_customer_order_details
                              on a.td_od_id equals b.cod_id
                              where b.cod_isdeleted == false


                              select new
                              {
                                  a,
                                  b.cod_order_number
                              }).ToList();

                foreach (var item in result)
                {
                    ClsTransactionDetail objClsTransactionDetail = new ClsTransactionDetail();
                    objClsTransactionDetail.TransactionId = item.a.td_id;
                    objClsTransactionDetail.Transaction_order_id = item.a.td_od_id;
                    objClsTransactionDetail.OrderNumber = item.cod_order_number;
                    if (item.a.td_transaction_date != null && item.a.td_transaction_date.ToString() != "")
                    {
                        objClsTransactionDetail.TransactionDate = item.a.td_transaction_date.Value;
                        objClsTransactionDetail.TransactionDateString = Convert.ToDateTime(item.a.td_transaction_date).ToShortDateString();
                    }
                    objClsTransactionDetail.Payment_status = item.a.Php_Payment_Status;
                    objClsTransactionDetail.Payment_amount = item.a.Php_Payment_Amount;
                    objClsTransactionDetail.TransactionPaymentAmount = Convert.ToDecimal(item.a.Php_Payment_Amount);
                    objClsTransactionDetail.PG_transaction_id = item.a.Php_PG_Transaction_id;
                    if (objClsTransactionDetail.Payment_status == 1)
                    {
                        objClsTransactionDetail.PaymentStatusString = "In Progress";
                    }
                    if (objClsTransactionDetail.Payment_status == 2)
                    {
                        objClsTransactionDetail.PaymentStatusString = "Success";
                    }
                    if (objClsTransactionDetail.Payment_status == 3)
                    {
                        objClsTransactionDetail.PaymentStatusString = "Failed";
                    }
                    lstClsTransactionDetail.Add(objClsTransactionDetail);
                }
                lstClsTransactionDetail = lstClsTransactionDetail.Where(P => (P.OrderNumber.Contains(searchText)) || (P.PG_transaction_id.Contains(searchText))).ToList<ClsTransactionDetail>();
                lstClsTransactionDetail = lstClsTransactionDetail.Where(P => (P.TransactionDate.Date >= fromDate.Date &&
                                  P.TransactionDate.Date <= toDate.Date)).ToList<ClsTransactionDetail>();
                lstClsTransactionDetail = lstClsTransactionDetail.OrderByDescending(x => x.TransactionDate == DateTime.Now.Date).ThenByDescending(x => x.TransactionDate).ToList();
            }
            else if ((searchText == null || searchText == "") && fromDate != Convert.ToDateTime("1/1/1900 12:00:00 AM") && toDate != Convert.ToDateTime("1/1/1900 12:00:00 AM"))
            {
                var result = (from a in dbEntities.tp_transaction_detail
                              join b in dbEntities.tp_customer_order_details
                              on a.td_od_id equals b.cod_id
                              where b.cod_isdeleted == false && (System.Data.Entity.DbFunctions.TruncateTime(a.td_transaction_date) >= System.Data.Entity.DbFunctions.TruncateTime(fromDate.Date) &&
                                System.Data.Entity.DbFunctions.TruncateTime(a.td_transaction_date) <= System.Data.Entity.DbFunctions.TruncateTime(toDate.Date))
                              select new
                              {
                                  a,
                                  b.cod_order_number
                              }).ToList();

                foreach (var item in result)
                {
                    ClsTransactionDetail objClsTransactionDetail = new ClsTransactionDetail();
                    objClsTransactionDetail.TransactionId = item.a.td_id;
                    objClsTransactionDetail.Transaction_order_id = item.a.td_od_id;
                    objClsTransactionDetail.OrderNumber = item.cod_order_number;
                    if (item.a.td_transaction_date != null && item.a.td_transaction_date.ToString() != "")
                    {
                        objClsTransactionDetail.TransactionDate = item.a.td_transaction_date.Value;
                        objClsTransactionDetail.TransactionDateString = Convert.ToDateTime(item.a.td_transaction_date).ToShortDateString();
                    }
                    objClsTransactionDetail.Payment_status = item.a.Php_Payment_Status;
                    objClsTransactionDetail.Payment_amount = item.a.Php_Payment_Amount;
                    objClsTransactionDetail.TransactionPaymentAmount = Convert.ToDecimal(item.a.Php_Payment_Amount);
                    objClsTransactionDetail.PG_transaction_id = item.a.Php_PG_Transaction_id;
                    if (objClsTransactionDetail.Payment_status == 1)
                    {
                        objClsTransactionDetail.PaymentStatusString = "In Progress";
                    }
                    if (objClsTransactionDetail.Payment_status == 2)
                    {
                        objClsTransactionDetail.PaymentStatusString = "Success";
                    }
                    if (objClsTransactionDetail.Payment_status == 3)
                    {
                        objClsTransactionDetail.PaymentStatusString = "Failed";
                    }
                    lstClsTransactionDetail.Add(objClsTransactionDetail);
                }
                lstClsTransactionDetail = lstClsTransactionDetail.OrderByDescending(x => x.TransactionDate == DateTime.Now.Date).ThenByDescending(x => x.TransactionDate).ToList();
            }
            else if ((searchText != "") && fromDate == Convert.ToDateTime("1/1/1900 12:00:00 AM") && toDate == Convert.ToDateTime("1/1/1900 12:00:00 AM"))
            {
                var result = (from a in dbEntities.tp_transaction_detail
                              join b in dbEntities.tp_customer_order_details
                              on a.td_od_id equals b.cod_id
                              where b.cod_isdeleted == false && (b.cod_order_number.Contains(searchText)) || (a.Php_PG_Transaction_id.Contains(searchText))
                              select new
                              {
                                  a,
                                  b.cod_order_number
                              }).ToList();

                foreach (var item in result)
                {
                    ClsTransactionDetail objClsTransactionDetail = new ClsTransactionDetail();
                    objClsTransactionDetail.TransactionId = item.a.td_id;
                    objClsTransactionDetail.Transaction_order_id = item.a.td_od_id;
                    objClsTransactionDetail.OrderNumber = item.cod_order_number;
                    if (item.a.td_transaction_date != null && item.a.td_transaction_date.ToString() != "")
                    {
                        objClsTransactionDetail.TransactionDate = item.a.td_transaction_date.Value;
                        objClsTransactionDetail.TransactionDateString = Convert.ToDateTime(item.a.td_transaction_date).ToShortDateString();
                    }
                    objClsTransactionDetail.Payment_status = item.a.Php_Payment_Status;
                    objClsTransactionDetail.Payment_amount = item.a.Php_Payment_Amount;
                    objClsTransactionDetail.TransactionPaymentAmount = Convert.ToDecimal(item.a.Php_Payment_Amount);
                    objClsTransactionDetail.PG_transaction_id = item.a.Php_PG_Transaction_id;
                    if (objClsTransactionDetail.Payment_status == 1)
                    {
                        objClsTransactionDetail.PaymentStatusString = "In Progress";
                    }
                    if (objClsTransactionDetail.Payment_status == 2)
                    {
                        objClsTransactionDetail.PaymentStatusString = "Success";
                    }
                    if (objClsTransactionDetail.Payment_status == 3)
                    {
                        objClsTransactionDetail.PaymentStatusString = "Failed";
                    }
                    lstClsTransactionDetail.Add(objClsTransactionDetail);
                }
                lstClsTransactionDetail = lstClsTransactionDetail.OrderByDescending(x => x.TransactionDate == DateTime.Now.Date).ThenByDescending(x => x.TransactionDate).ToList();
            }
            else
            {
                var result = (from a in dbEntities.tp_transaction_detail
                              join b in dbEntities.tp_customer_order_details
                              on a.td_od_id equals b.cod_id
                              where b.cod_isdeleted == false
                              select new
                              {
                                  a,
                                  b.cod_order_number
                              }).ToList();

                foreach (var item in result)
                {
                    ClsTransactionDetail objClsTransactionDetail = new ClsTransactionDetail();
                    objClsTransactionDetail.TransactionId = item.a.td_id;
                    objClsTransactionDetail.Transaction_order_id = item.a.td_od_id;
                    objClsTransactionDetail.OrderNumber = item.cod_order_number;
                    if (item.a.td_transaction_date != null && item.a.td_transaction_date.ToString() != "")
                    {
                        objClsTransactionDetail.TransactionDate = item.a.td_transaction_date.Value;
                        objClsTransactionDetail.TransactionDateString = Convert.ToDateTime(item.a.td_transaction_date).ToShortDateString();
                    }
                    objClsTransactionDetail.Payment_status = item.a.Php_Payment_Status;
                    objClsTransactionDetail.Payment_amount = item.a.Php_Payment_Amount;
                    objClsTransactionDetail.TransactionPaymentAmount = Convert.ToDecimal(item.a.Php_Payment_Amount);
                    objClsTransactionDetail.PG_transaction_id = item.a.Php_PG_Transaction_id;
                    if (objClsTransactionDetail.Payment_status == 1)
                    {
                        objClsTransactionDetail.PaymentStatusString = "In Progress";
                    }
                    if (objClsTransactionDetail.Payment_status == 2)
                    {
                        objClsTransactionDetail.PaymentStatusString = "Success";
                    }
                    if (objClsTransactionDetail.Payment_status == 3)
                    {
                        objClsTransactionDetail.PaymentStatusString = "Failed";
                    }
                    lstClsTransactionDetail.Add(objClsTransactionDetail);
                }
                lstClsTransactionDetail = lstClsTransactionDetail.OrderByDescending(x => x.TransactionDate == DateTime.Now.Date).ThenByDescending(x => x.TransactionDate).ToList();
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }

        return lstClsTransactionDetail.ListToDataTable();
    }

    //Transaction list by transaction id
    public List<tp_transaction_detail> GetTransactionDetailListByTransactionId(int transactionId)
    {
        List<tp_transaction_detail> lstTransactionList = new List<tp_transaction_detail>();
        try
        {
            lstTransactionList = dbEntities.tp_transaction_detail.Where(P => P.td_id == transactionId).ToList<tp_transaction_detail>();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstTransactionList;
    }

}