using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddStoreDetail : System.Web.UI.Page
{
    int StoreId;
    ClsStoreDetail objClsStoreDetail = new ClsStoreDetail();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserId"] != null)
            {
                if (Request.QueryString["StoreId"] != null)
                {
                    btnStoreDetail.Text = "Update Store Detail";
                    StoreId = Convert.ToInt32(Request.QueryString["StoreId"]);

                    GetStoreDetailById();

                    //List<string> lstStartHour = new List<string>();
                    //lstStartHour.Add("Select Hour");
                    //lstStartHour.Add("01");
                    //lstStartHour.Add("02");
                    //lstStartHour.Add("03");
                    //lstStartHour.Add("04");
                    //lstStartHour.Add("05");
                    //lstStartHour.Add("06");
                    //lstStartHour.Add("07");
                    //lstStartHour.Add("08");
                    //lstStartHour.Add("09");
                    //lstStartHour.Add("10");
                    //lstStartHour.Add("11");
                    //lstStartHour.Add("12");
                    //lstStartHour.Add("13");
                    //lstStartHour.Add("14");
                    //lstStartHour.Add("15");
                    //lstStartHour.Add("16");
                    //lstStartHour.Add("17");
                    //lstStartHour.Add("18");
                    //lstStartHour.Add("19");
                    //lstStartHour.Add("20");
                    //lstStartHour.Add("21");
                    //lstStartHour.Add("22");
                    //lstStartHour.Add("23");
                    //lstStartHour.Add("24");
                    //DdlMondayStartHour.DataSource = lstStartHour;
                    //DdlTuesdayStartHour.DataSource = lstStartHour;
                    //DdlWensdayStartHour.DataSource = lstStartHour;
                    //DdlThursdayStartHour.DataSource = lstStartHour;
                    //DdlFridayStartHour.DataSource = lstStartHour;
                    //DdlSaturdayStartHour.DataSource = lstStartHour;
                    //DdlSundayStartHour.DataSource = lstStartHour;

                    //List<string> lstEndHour = new List<string>();
                    //lstStartHour.Add("Select Hour");
                    //lstStartHour.Add("01");
                    //lstStartHour.Add("02");
                    //lstStartHour.Add("03");
                    //lstStartHour.Add("04");
                    //lstStartHour.Add("05");
                    //lstStartHour.Add("06");
                    //lstStartHour.Add("07");
                    //lstStartHour.Add("08");
                    //lstStartHour.Add("09");
                    //lstStartHour.Add("10");
                    //lstStartHour.Add("11");
                    //lstStartHour.Add("12");
                    //lstStartHour.Add("13");
                    //lstStartHour.Add("14");
                    //lstStartHour.Add("15");
                    //lstStartHour.Add("16");
                    //lstStartHour.Add("17");
                    //lstStartHour.Add("18");
                    //lstStartHour.Add("19");
                    //lstStartHour.Add("20");
                    //lstStartHour.Add("21");
                    //lstStartHour.Add("22");
                    //lstStartHour.Add("23");
                    //lstStartHour.Add("24");
                    //DdlMondayEndHour.DataSource = lstEndHour;
                    //DdlTuesdayEndHour.DataSource = lstEndHour;
                    //DdlWensdayEndHour.DataSource = lstEndHour;
                    //DdlThursdayEndHour.DataSource = lstEndHour;
                    //DdlFridayEndHour.DataSource = lstEndHour;
                    //DdlSaturdayEndHour.DataSource = lstEndHour;
                    //DdlSundayEndHour.DataSource = lstEndHour;

                    //List<string> lstStartMinute = new List<string>();
                    //lstStartHour.Add("Select Minute");
                    //lstStartHour.Add("00");
                    //lstStartHour.Add("05");
                    //lstStartHour.Add("10");
                    //lstStartHour.Add("15");
                    //lstStartHour.Add("20");
                    //lstStartHour.Add("25");
                    //lstStartHour.Add("30");
                    //lstStartHour.Add("35");
                    //lstStartHour.Add("40");
                    //lstStartHour.Add("45");
                    //lstStartHour.Add("50");
                    //lstStartHour.Add("55");
                    //DdlMondayStartMinute.DataSource = lstStartMinute;
                    //DdlTuesdayStartMinute.DataSource = lstStartMinute;
                    //DdlWensdayStartMinute.DataSource = lstStartMinute;
                    //DdlThursdayStartMinute.DataSource = lstStartMinute;
                    //DdlFridayStartMinute.DataSource = lstStartMinute;
                    //DdlSaturdayStartMinute.DataSource = lstStartMinute;
                    //DdlSundayStartMinute.DataSource = lstStartMinute;

                    //List<string> lstEndMinute = new List<string>();
                    //lstStartHour.Add("Select Minute");
                    //lstStartHour.Add("00");
                    //lstStartHour.Add("05");
                    //lstStartHour.Add("10");
                    //lstStartHour.Add("15");
                    //lstStartHour.Add("20");
                    //lstStartHour.Add("25");
                    //lstStartHour.Add("30");
                    //lstStartHour.Add("35");
                    //lstStartHour.Add("40");
                    //lstStartHour.Add("45");
                    //lstStartHour.Add("50");
                    //lstStartHour.Add("55");
                    //DdlMondayEndMinute.DataSource = lstEndMinute;
                    //DdlTuesdayEndMinute.DataSource = lstEndMinute;
                    //DdlWensdayEndMinute.DataSource = lstEndMinute;
                    //DdlThursdayEndMinute.DataSource = lstEndMinute;
                    //DdlFridayEndMinute.DataSource = lstEndMinute;
                    //DdlSaturdayEndMinute.DataSource = lstEndMinute;
                    //DdlSundayEndMinute.DataSource = lstEndMinute;

                }
                GetStoreDetailById();
            }
            else
            {
                Response.Redirect("~/Index.aspx", false);
            }
        }
    }

    public void GetStoreDetailById()
    {
        try
        {
            ClsStoreDetail ClsStoreDetailobj = new ClsStoreDetail();
            ClsStoreDetailobj = objClsStoreDetail.GetStoreDetailById(Convert.ToInt32(Request.QueryString["StoreId"].ToString()));
            //ClsStoreDetailobj = objClsStoreDetail.GetStoreDetailById(1);

            if (ClsStoreDetailobj != null)
            {
                txtAddress.Text = ClsStoreDetailobj.StoreAddress;
                txtContactNumber1.Text = ClsStoreDetailobj.ContactNumber1;
                txtContactNumber2.Text = ClsStoreDetailobj.ContactNumber2;
                txtContactNumber3.Text = ClsStoreDetailobj.ContactNumber3;
                txtContactNumber4.Text = ClsStoreDetailobj.ContactNumber4;
                txtfaxnumber.Text = ClsStoreDetailobj.FaxNumber;
                txtstoreName.Text = ClsStoreDetailobj.StoreName;

                List<ClsStoreDetail> lstClsStoreDetail = new List<ClsStoreDetail>();
                lstClsStoreDetail = objClsStoreDetail.GetStoreMappingDetailById(Convert.ToInt32(Request.QueryString["StoreId"]));
                //lstClsStoreDetail = objClsStoreDetail.GetStoreMappingDetailById(1);

                if (lstClsStoreDetail.Count > 0)
                {
                    foreach (var item in lstClsStoreDetail)
                    {
                        if (item.WorkingDayId == 1)
                        {
                            string[] MondayStartTime = item.StoreWorkingStartTime.Split(':');
                            if (MondayStartTime[1].Contains("AM"))
                            {
                                DdlMondayStartTime.Items.FindByText("AM").Selected = true;
                            }
                            else
                            {
                                DdlMondayStartTime.Items.FindByText("PM").Selected = true;
                            }
                            MondayStartTime[1] = MondayStartTime[1].Replace("AM", "").Replace("PM", "").Replace(" ", "");
                            if (MondayStartTime.Length > 0)
                            {

                                DdlMondayStartHour.Items.FindByText(MondayStartTime[0]).Selected = true;
                                DdlMondayStartMinute.Items.FindByText(MondayStartTime[1]).Selected = true;

                            }

                            string[] MondayendTime = item.StoreWorkingEndTime.Split(':');
                            if (MondayendTime[1].Contains("AM"))
                            {
                                DdlMondayEndTime.Items.FindByText("AM").Selected = true;
                            }
                            else
                            {
                                DdlMondayEndTime.Items.FindByText("PM").Selected = true;
                            }
                            MondayendTime[1] = MondayendTime[1].Replace("AM", "").Replace("PM", "").Replace(" ", "");
                            if (MondayStartTime.Length > 0)
                            {
                                DdlMondayEndHour.Items.FindByText(MondayendTime[0]).Selected = true;
                                DdlMondayEndMinute.Items.FindByText(MondayendTime[1]).Selected = true;

                            }

                        }
                        if (item.WorkingDayId == 2)
                        {
                            string[] TuesdayStartTime = item.StoreWorkingStartTime.Split(':');
                            if (TuesdayStartTime[1].Contains("AM"))
                            {
                                DdlTuesdayStartTime.Items.FindByText("AM").Selected = true;
                            }
                            else
                            {
                                DdlTuesdayStartTime.Items.FindByText("PM").Selected = true;
                            }
                            TuesdayStartTime[1] = TuesdayStartTime[1].Replace("AM", "").Replace("PM", "").Replace(" ", "");
                            if (TuesdayStartTime.Length > 0)
                            {
                                DdlTuesdayStartHour.Items.FindByText(TuesdayStartTime[0]).Selected = true;
                                DdlTuesdayStartMinute.Items.FindByText(TuesdayStartTime[1]).Selected = true;
                            }

                            string[] TuesdayendTime = item.StoreWorkingEndTime.Split(':');
                            if (TuesdayendTime[1].Contains("AM"))
                            {
                                DdlTuesdayEndTime.Items.FindByText("AM").Selected = true;
                            }
                            else
                            {
                                DdlTuesdayEndTime.Items.FindByText("PM").Selected = true;
                            }
                            TuesdayendTime[1] = TuesdayendTime[1].Replace("AM", "").Replace("PM", "").Replace(" ", "");

                            if (TuesdayendTime.Length > 0)
                            {
                                DdlTuesdayEndHour.Items.FindByText(TuesdayendTime[0]).Selected = true;
                                DdlTuesdayEndMinute.Items.FindByText(TuesdayendTime[1]).Selected = true;

                            }

                        }
                        if (item.WorkingDayId == 3)
                        {
                            string[] WenesdayStartTime = item.StoreWorkingStartTime.Split(':');
                            if (WenesdayStartTime[1].Contains("AM"))
                            {
                                DdlWenesdayStartTime.Items.FindByText("AM").Selected = true;
                            }
                            else
                            {
                                DdlWenesdayStartTime.Items.FindByText("PM").Selected = true;
                            }
                            WenesdayStartTime[1] = WenesdayStartTime[1].Replace("AM", "").Replace("PM", "").Replace(" ", "");

                            if (WenesdayStartTime.Length > 0)
                            {
                                DdlWensdayStartHour.Items.FindByText(WenesdayStartTime[0]).Selected = true;
                                DdlWensdayStartMinute.Items.FindByText(WenesdayStartTime[1]).Selected = true;
                            }

                            string[] WenesdayendTime = item.StoreWorkingEndTime.Split(':');
                            if (WenesdayendTime[1].Contains("AM"))
                            {
                                DdlWenesdayEndTime.Items.FindByText("AM").Selected = true;
                            }
                            else
                            {
                                DdlWenesdayEndTime.Items.FindByText("PM").Selected = true;
                            }
                            WenesdayendTime[1] = WenesdayendTime[1].Replace("AM", "").Replace("PM", "").Replace(" ", "");

                            if (WenesdayendTime.Length > 0)
                            {
                                DdlWensdayEndHour.Items.FindByText(WenesdayendTime[0]).Selected = true;
                                DdlWensdayEndMinute.Items.FindByText(WenesdayendTime[1]).Selected = true;

                            }

                        }
                        if (item.WorkingDayId == 4)
                        {
                            string[] ThursdayStartTime = item.StoreWorkingStartTime.Split(':');
                            if (ThursdayStartTime[1].Contains("AM"))
                            {
                                DdlThursdayStartTime.Items.FindByText("AM").Selected = true;
                            }
                            else
                            {
                                DdlThursdayStartTime.Items.FindByText("PM").Selected = true;
                            }
                            ThursdayStartTime[1] = ThursdayStartTime[1].Replace("AM", "").Replace("PM", "").Replace(" ", "");

                            if (ThursdayStartTime.Length > 0)
                            {
                                DdlThursdayStartHour.Items.FindByText(ThursdayStartTime[0]).Selected = true;
                                DdlThursdayStartMinute.Items.FindByText(ThursdayStartTime[1]).Selected = true;

                            }

                            string[] ThursdayendTime = item.StoreWorkingEndTime.Split(':');
                            if (ThursdayendTime[1].Contains("AM"))
                            {
                                DdlThursdayEndTime.Items.FindByText("AM").Selected = true;
                            }
                            else
                            {
                                DdlThursdayEndTime.Items.FindByText("PM").Selected = true;
                            }
                            ThursdayendTime[1] = ThursdayendTime[1].Replace("AM", "").Replace("PM", "").Replace(" ", "");

                            if (ThursdayendTime.Length > 0)
                            {
                                DdlThursdayEndHour.Items.FindByText(ThursdayendTime[0]).Selected = true;
                                DdlThursdayEndMinute.Items.FindByText(ThursdayendTime[1]).Selected = true;

                            }

                        }

                        if (item.WorkingDayId == 5)
                        {
                            string[] FridayStartTime = item.StoreWorkingStartTime.Split(':');

                            if (FridayStartTime[1].Contains("AM"))
                            {
                                DdlFridayStartTime.Items.FindByText("AM").Selected = true;
                            }
                            else
                            {
                                DdlFridayStartTime.Items.FindByText("PM").Selected = true;
                            }
                            FridayStartTime[1] = FridayStartTime[1].Replace("AM", "").Replace("PM", "").Replace(" ", "");

                            if (FridayStartTime.Length > 0)
                            {
                                DdlFridayStartHour.Items.FindByText(FridayStartTime[0]).Selected = true;
                                DdlFridayStartMinute.Items.FindByText(FridayStartTime[1]).Selected = true;

                            }

                            string[] FridayendTime = item.StoreWorkingEndTime.Split(':');
                            if (FridayendTime[1].Contains("AM"))
                            {
                                DdlFridayEndTime.Items.FindByText("AM").Selected = true;
                            }
                            else
                            {
                                DdlFridayEndTime.Items.FindByText("PM").Selected = true;
                            }
                            FridayendTime[1] = FridayendTime[1].Replace("AM", "").Replace("PM", "").Replace(" ", "");

                            if (FridayendTime.Length > 0)
                            {
                                DdlFridayEndHour.Items.FindByText(FridayendTime[0]).Selected = true;
                                DdlFridayEndMinute.Items.FindByText(FridayendTime[1]).Selected = true;

                            }

                        }

                        if (item.WorkingDayId == 6)
                        {
                            string[] SaturdayStartTime = item.StoreWorkingStartTime.Split(':');
                            if (SaturdayStartTime[1].Contains("AM"))
                            {
                                DdlSaturdayStartTime.Items.FindByText("AM").Selected = true;
                            }
                            else
                            {
                                DdlSaturdayStartTime.Items.FindByText("PM").Selected = true;
                            }
                            SaturdayStartTime[1] = SaturdayStartTime[1].Replace("AM", "").Replace("PM", "").Replace(" ", "");

                            if (SaturdayStartTime.Length > 0)
                            {
                                DdlSaturdayStartHour.Items.FindByText(SaturdayStartTime[0]).Selected = true;
                                DdlSaturdayStartMinute.Items.FindByText(SaturdayStartTime[1]).Selected = true;

                            }

                            string[] SaturdayendTime = item.StoreWorkingEndTime.Split(':');
                            if (SaturdayendTime[1].Contains("AM"))
                            {
                                DdlSaturdayEndTime.Items.FindByText("AM").Selected = true;
                            }
                            else
                            {
                                DdlSaturdayEndTime.Items.FindByText("PM").Selected = true;
                            }
                            SaturdayendTime[1] = SaturdayendTime[1].Replace("AM", "").Replace("PM", "").Replace(" ", "");

                            if (SaturdayendTime.Length > 0)
                            {
                                DdlSaturdayEndHour.Items.FindByText(SaturdayendTime[0]).Selected = true;
                                DdlSaturdayEndMinute.Items.FindByText(SaturdayendTime[1]).Selected = true;

                            }

                        }

                        if (item.WorkingDayId == 7)
                        {
                            string[] SundayStartTime = item.StoreWorkingStartTime.Split(':');
                            if (SundayStartTime[1].Contains("AM"))
                            {
                                DdlSundayStartTime.Items.FindByText("AM").Selected = true;
                            }
                            else
                            {
                                DdlSundayStartTime.Items.FindByText("PM").Selected = true;
                            }
                            SundayStartTime[1] = SundayStartTime[1].Replace("AM", "").Replace("PM", "").Replace(" ", "");

                            if (SundayStartTime.Length > 0)
                            {
                                DdlSundayStartHour.Items.FindByText(SundayStartTime[0]).Selected = true;
                                DdlSundayStartMinute.Items.FindByText(SundayStartTime[1]).Selected = true;
                            }

                            string[] SundayendTime = item.StoreWorkingEndTime.Split(':');
                            if (SundayendTime[1].Contains("AM"))
                            {
                                DdlSundayEndTime.Items.FindByText("AM").Selected = true;
                            }
                            else
                            {
                                DdlSundayEndTime.Items.FindByText("PM").Selected = true;
                            }
                            SundayendTime[1] = SundayendTime[1].Replace("AM", "").Replace("PM", "").Replace(" ", "");

                            if (SundayendTime.Length > 0)
                            {
                                DdlSundayEndHour.Items.FindByText(SundayendTime[0]).Selected = true;
                                DdlSundayEndMinute.Items.FindByText(SundayendTime[1]).Selected = true;

                            }


                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    protected void btnStoreDetail_Click(object sender, EventArgs e)
    {
        try
        {
            if (btnStoreDetail.Text == "Update Store Detail")
            {
                string retMsg = objClsStoreDetail.UpdateStoreDetail(Convert.ToInt32(Request.QueryString["StoreId"]), txtstoreName.Text, 0, 0, 0, txtAddress.Text, txtContactNumber1.Text, txtContactNumber2.Text, txtContactNumber3.Text, txtContactNumber4.Text, txtfaxnumber.Text, DdlMondayStartHour.Text, DdlMondayStartMinute.Text, DdlMondayStartTime.Text, DdlMondayEndHour.Text, DdlMondayEndMinute.Text, DdlMondayEndTime.Text, DdlTuesdayStartHour.Text, DdlTuesdayStartMinute.Text, DdlTuesdayStartTime.Text, DdlTuesdayEndHour.Text, DdlTuesdayEndMinute.Text, DdlTuesdayEndTime.Text, DdlWensdayStartHour.Text, DdlWensdayStartMinute.Text, DdlWenesdayStartTime.Text, DdlWensdayEndHour.Text, DdlWensdayEndMinute.Text, DdlWenesdayEndTime.Text, DdlThursdayStartHour.Text, DdlThursdayStartMinute.Text, DdlThursdayStartTime.Text, DdlThursdayEndHour.Text, DdlThursdayEndMinute.Text, DdlThursdayEndTime.Text, DdlFridayStartHour.Text, DdlFridayStartMinute.Text, DdlFridayStartTime.Text, DdlFridayEndHour.Text, DdlFridayEndMinute.Text, DdlFridayEndTime.Text, DdlSaturdayStartHour.Text, DdlSaturdayStartMinute.Text, DdlSaturdayStartTime.Text, DdlSaturdayEndHour.Text, DdlSaturdayEndMinute.Text, DdlSaturdayEndTime.Text, DdlSundayStartHour.Text, DdlSundayStartMinute.Text, DdlSundayStartTime.Text, DdlSundayEndHour.Text, DdlSundayEndMinute.Text, DdlSundayEndTime.Text, Convert.ToInt32(Session["UserId"]));

                //string retMsg = objClsStoreDetail.UpdateStoreDetail(Convert.ToInt32(1), txtstoreName.Text, 0, 0, 0, txtAddress.Text, txtContactNumber1.Text, txtContactNumber2.Text, txtContactNumber3.Text, txtContactNumber4.Text, txtfaxnumber.Text, DdlMondayStartHour.Text, DdlMondayStartMinute.Text, DdlMondayEndHour.Text, DdlMondayEndMinute.Text, DdlTuesdayStartHour.Text, DdlTuesdayStartMinute.Text, DdlTuesdayEndHour.Text, DdlTuesdayEndMinute.Text, DdlWensdayStartHour.Text, DdlWensdayStartMinute.Text, DdlWensdayEndHour.Text, DdlWensdayEndMinute.Text, DdlThursdayStartHour.Text, DdlThursdayStartMinute.Text, DdlThursdayEndHour.Text, DdlThursdayEndMinute.Text, DdlFridayStartHour.Text, DdlFridayStartMinute.Text, DdlFridayEndHour.Text, DdlFridayEndMinute.Text, DdlSaturdayStartHour.Text, DdlSaturdayStartMinute.Text, DdlSaturdayEndHour.Text, DdlSaturdayEndMinute.Text, DdlSundayStartHour.Text, DdlSundayStartMinute.Text, DdlSundayEndHour.Text, DdlSundayEndMinute.Text, Convert.ToInt32(Session["UserId"]));

                //string retMsg = objClsStoreDetail.UpdateStoreDetail(Convert.ToInt32(1), txtstoreName.Text, 0, 0, 0, txtAddress.Text, txtContactNumber1.Text, txtContactNumber2.Text, txtContactNumber3.Text, txtContactNumber4.Text, txtfaxnumber.Text, DdlMondayStartHour.Text,"","", "", "", "","","", "", "","", "", "", "", "", "", "", "", "", "", "", "", "", "", "","", "", "", Convert.ToInt32(Session["UserId"]));

                if (retMsg == "SUCCESS")
                {
                    string message = "StoreDetail Updated Successfully.";
                    string url = "StoreInformation.aspx";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "');";
                    script += "window.location = '";
                    script += url;
                    script += "'; }";
                    ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);

                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Admin/StoreInformation.aspx", false);
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
    protected void BtnLogOut_Click(object sender, EventArgs e)
    {
        try
        {
            string confirmValue = hdfLogout.Value;
            if (confirmValue == "Yes")
            {
                Session.Abandon();
                Response.Redirect("~/Login.aspx", false);
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
}