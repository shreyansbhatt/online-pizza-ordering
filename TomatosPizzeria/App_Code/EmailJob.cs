using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
/// <summary>
/// Summary description for EmailJob
/// </summary>
public class EmailJob : IJob
{
	public EmailJob()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    TP_DatabaseEntities dbEntities = new TP_DatabaseEntities();
    public void Execute(IJobExecutionContext context)
    {
        try
        {            
            List<tp_customer_order_details> lsttp_customer_order_details = new List<tp_customer_order_details>();
            lsttp_customer_order_details = dbEntities.tp_customer_order_details.Where(x => x.cod_order_placed_time == DateTime.Today && x.cod_isdeleted == false).ToList();

            foreach(var item in lsttp_customer_order_details)
            {
                tp_customer_order_details objtp_customer_order_details = new tp_customer_order_details();
                objtp_customer_order_details = dbEntities.tp_customer_order_details.Where(x => x.cod_id == item.cod_id).FirstOrDefault();
                if(objtp_customer_order_details!=null)
                {
                    objtp_customer_order_details.cod_order_status = "Order Completed";
                    dbEntities.SaveChanges();
                }
            }
        }
        catch(Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
}