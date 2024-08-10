using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for ClsUserInformation
/// </summary>
public class ClsUserInformation
{
    TP_DatabaseEntities dbEntities = new TP_DatabaseEntities();
    public ClsUserInformation()
    {

    }

    #region Properties
    private int m_userId;
    private string m_seqNo;
    private string m_firstName;
    private string m_lastName;
    private string m_userName;
    private string m_email;
    private string m_password;
    private string m_mobileNo;
    private string m_telephoneNo;
    private int m_countryId;
    private int m_stateId;
    private int m_cityId;
    private string m_pincode;
    private int m_userType;


    private string m_addressline1;
    private string m_addressLine2;
    private string m_street;
    private string m_houseNo;

    private string m_countryName;
    private string m_stateName;
    private string m_cityName;
    private string m_gender;
    private string m_CustomerName;
    private string m_DeliveryInstruction;
    private string m_OrderType;
    private string m_OrderTotalAmount;
    private DateTime? m_CreatedOn;
    private string m_salesTax;
    private string m_deliveryCharges;

    public string DeliveryCharges
    {
        get { return m_deliveryCharges; }
        set { m_deliveryCharges = value; }
    }
    public string SalesTax
    {
        get { return m_salesTax; }
        set { m_salesTax = value; }
    }

    public DateTime? CreatedOn
    {
        get { return m_CreatedOn; }
        set { m_CreatedOn = value; }
    }
    public string OrderTotalAmount
    {
        get { return m_OrderTotalAmount; }
        set { m_OrderTotalAmount = value; }
    }

    public string OrderType
    {
        get { return m_OrderType; }
        set { m_OrderType = value; }
    }
    public string DeliveryInstruction
    {
        get { return m_DeliveryInstruction; }
        set { m_DeliveryInstruction = value; }
    }
    public string CustomerName
    {
        get { return m_CustomerName; }
        set { m_CustomerName = value; }
    }
    public string SeqNo
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

    public string UserName
    {
        get
        {
            return m_userName;
        }

        set
        {
            m_userName = value;
        }
    }

    public string Email
    {
        get
        {
            return m_email;
        }

        set
        {
            m_email = value;
        }
    }

    public string MobileNo
    {
        get
        {
            return m_mobileNo;
        }

        set
        {
            m_mobileNo = value;
        }
    }

    public string TelephoneNo
    {
        get
        {
            return m_telephoneNo;
        }

        set
        {
            m_telephoneNo = value;
        }
    }

    public int CountryId
    {
        get
        {
            return m_countryId;
        }

        set
        {
            m_countryId = value;
        }
    }

    public int StateId
    {
        get
        {
            return m_stateId;
        }

        set
        {
            m_stateId = value;
        }
    }

    public int CityId
    {
        get
        {
            return m_cityId;
        }

        set
        {
            m_cityId = value;
        }
    }

    public string Pincode
    {
        get
        {
            return m_pincode;
        }

        set
        {
            m_pincode = value;
        }
    }

    public int UserType
    {
        get
        {
            return m_userType;
        }

        set
        {
            m_userType = value;
        }
    }

    public string Addressline1
    {
        get
        {
            return m_addressline1;
        }

        set
        {
            m_addressline1 = value;
        }
    }

    public string AddressLine2
    {
        get
        {
            return m_addressLine2;
        }

        set
        {
            m_addressLine2 = value;
        }
    }

    public string Street
    {
        get
        {
            return m_street;
        }

        set
        {
            m_street = value;
        }
    }

    public string HouseNo
    {
        get
        {
            return m_houseNo;
        }

        set
        {
            m_houseNo = value;
        }
    }

    public string Password
    {
        get
        {
            return m_password;
        }

        set
        {
            m_password = value;
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

    public string CountryName
    {
        get
        {
            return m_countryName;
        }

        set
        {
            m_countryName = value;
        }
    }

    public string StateName
    {
        get
        {
            return m_stateName;
        }

        set
        {
            m_stateName = value;
        }
    }

    public string CityName
    {
        get
        {
            return m_cityName;
        }

        set
        {
            m_cityName = value;
        }
    }

    public string Gender
    {
        get
        {
            return m_gender;
        }

        set
        {
            m_gender = value;
        }
    }

    public string FirstName
    {
        get
        {
            return m_firstName;
        }

        set
        {
            m_firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return m_lastName;
        }

        set
        {
            m_lastName = value;
        }
    }



    #endregion

    //Insert New User
    public string InsertNewUser(string seqNo, string firstName, string lastName, string userName, string email, string password, string mobileNo, string telephoneNo, int countryId, int stateId, string city, string pincode, int userType, int gender, string addressLine1, string addressLine2, string street, string houseNo)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {

            tp_user_information dbObjInsertUserInformation = new tp_user_information();
            dbObjInsertUserInformation.ui_seqno = seqNo;
            dbObjInsertUserInformation.ui_firstName = firstName;
            dbObjInsertUserInformation.ui_lastName = lastName;
            dbObjInsertUserInformation.ui_userName = userName;
            dbObjInsertUserInformation.ui_email = email;
            dbObjInsertUserInformation.ui_password = password;
            dbObjInsertUserInformation.ui_mobile = mobileNo;
            dbObjInsertUserInformation.ui_telephone = telephoneNo;
            dbObjInsertUserInformation.ui_country_id = countryId;
            dbObjInsertUserInformation.ui_state_id = stateId;
            dbObjInsertUserInformation.ui_city = city;
            dbObjInsertUserInformation.ui_pincode = pincode;
            dbObjInsertUserInformation.ui_usertype = userType;
            dbObjInsertUserInformation.ui_gender = gender;
            dbObjInsertUserInformation.ui_addressLine1 = addressLine1;
            dbObjInsertUserInformation.ui_addressLine2 = addressLine2;
            dbObjInsertUserInformation.ui_street = street;
            dbObjInsertUserInformation.ui_house_no = houseNo;
            dbObjInsertUserInformation.ui_isdeleted = false;
            dbObjInsertUserInformation.createdby = dbObjInsertUserInformation.ui_id;
            dbObjInsertUserInformation.modifiedby = dbObjInsertUserInformation.ui_id;
            dbObjInsertUserInformation.createdon = DateTime.Now;
            dbObjInsertUserInformation.modifiedon = DateTime.Now;


            dbEntities.tp_user_information.Add(dbObjInsertUserInformation);
            retValue = dbEntities.SaveChanges();

            if (retValue == 1)
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

    //Update User Detail
    public string UpdateUser(int userId, string seqNo, string firstName, string lastName, string userName, string email, string password, string mobileNo, string telephoneNo, int countryId, int stateId, string city, string pincode, int gender, string addressLine1, string addressLine2, string street, string houseNo,string ZipCode)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {
            tp_user_information dbObjUpdateUserInformation = null;
            dbObjUpdateUserInformation = dbEntities.tp_user_information.Where(P => P.ui_id == userId).FirstOrDefault();
            if (dbObjUpdateUserInformation != null)
            {
                dbObjUpdateUserInformation.ui_seqno = seqNo;
                dbObjUpdateUserInformation.ui_userName = userName;
                dbObjUpdateUserInformation.ui_email = email;
                dbObjUpdateUserInformation.ui_password = password;
                dbObjUpdateUserInformation.ui_mobile = mobileNo;
                dbObjUpdateUserInformation.ui_telephone = telephoneNo;
                dbObjUpdateUserInformation.ui_country_id = countryId;
                dbObjUpdateUserInformation.ui_state_id = stateId;
                dbObjUpdateUserInformation.ui_city = city;
                dbObjUpdateUserInformation.ui_pincode = pincode;
                //dbObjUpdateUserInformation.ui_usertype = userType;
                dbObjUpdateUserInformation.ui_gender = gender;
                dbObjUpdateUserInformation.ui_addressLine1 = addressLine1;
                dbObjUpdateUserInformation.ui_addressLine2 = addressLine2;
                dbObjUpdateUserInformation.ui_street = street;
                dbObjUpdateUserInformation.ui_house_no = houseNo;
                dbObjUpdateUserInformation.ui_isdeleted = false;
                dbObjUpdateUserInformation.modifiedby = dbObjUpdateUserInformation.ui_id;
                dbObjUpdateUserInformation.modifiedon = DateTime.Now;
                dbObjUpdateUserInformation.ui_pincode = ZipCode;
                retValue = dbEntities.SaveChanges();
            }
            if (retValue == 1)
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

    //Delete User
    public string DeleteUserByID(int userid)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {
            tp_user_information dbObjDeleteUserInformation = null;
            dbObjDeleteUserInformation = dbEntities.tp_user_information.Where(P => P.ui_id == userid).FirstOrDefault();

            dbObjDeleteUserInformation.ui_isdeleted = true;
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

    //Get User Email By UserId
    public string GetUserEmailByUserId(int userId)
    {
        List<tp_user_information> lstUsers = new List<tp_user_information>();
        string userEmail = string.Empty;
        try
        {
            userEmail = dbEntities.tp_user_information.Where(P => P.ui_id == userId && P.ui_isdeleted == false).FirstOrDefault().ui_email;
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return userEmail;
    }

    //Check user already exits
    public bool isUserExist(string userName)
    {
        bool retValue = false;
        try
        {
            tp_user_information result = dbEntities.tp_user_information.Where(P => P.ui_email.ToLower().Equals(userName, StringComparison.InvariantCultureIgnoreCase) && P.ui_isdeleted == false).FirstOrDefault();
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

    //Get User List By User Name or Email Address
    public DataTable GetUserList(string searchText = null)
    {
        List<ClsUserInformation> lstClsUserInformation = new List<ClsUserInformation>();
        try
        {
            if (!string.IsNullOrEmpty(searchText))
            {

                var result = (from ui in dbEntities.tp_user_information
                              join tps in dbEntities.tp_state
                              on ui.ui_state_id equals tps.tps_id
                              //join tpc in dbEntities.tp_country
                              //on ui.ui_country_id equals tpc.tpc_id
                              //join tpci in dbEntities.tp_city
                              //on ui.ui_city equals tpci.tpci_id
                              where (ui.ui_isdeleted == false && (ui.ui_email.Contains(searchText)))

                              select new
                              {
                                  ui,
                                  // tpc.tpc_country_name,
                                  tps.tps_state_name,
                                  //tpci.tpci_city_name
                              }).ToList();

                foreach (var item in result)
                {
                    ClsUserInformation objClsUserInformation = new ClsUserInformation();
                    objClsUserInformation.UserId = item.ui.ui_id;
                    objClsUserInformation.SeqNo = item.ui.ui_seqno;
                    objClsUserInformation.FirstName = item.ui.ui_firstName;
                    objClsUserInformation.LastName = item.ui.ui_lastName;
                    objClsUserInformation.UserName = item.ui.ui_userName;
                    objClsUserInformation.Email = item.ui.ui_email;
                    objClsUserInformation.MobileNo = item.ui.ui_mobile;
                    objClsUserInformation.TelephoneNo = item.ui.ui_telephone;
                    //objClsUserInformation.CountryName = item.tpc_country_name;
                    objClsUserInformation.StateName = item.tps_state_name;
                    objClsUserInformation.CityName = item.ui.ui_city;
                    if(item.ui.createdon.ToString()!="" && item.ui.createdon!=null)
                    {
                        objClsUserInformation.CreatedOn = item.ui.createdon;
                    }
                    objClsUserInformation.Pincode = item.ui.ui_pincode;
                    objClsUserInformation.Addressline1 = item.ui.ui_addressLine1;
                    objClsUserInformation.AddressLine2 = item.ui.ui_addressLine2;
                    objClsUserInformation.Street = item.ui.ui_street;
                    objClsUserInformation.HouseNo = item.ui.ui_house_no;

                    if (item.ui.ui_gender == 0)
                        objClsUserInformation.Gender = "Male";
                    else
                        objClsUserInformation.Gender = "Female";

                    lstClsUserInformation.Add(objClsUserInformation);
                }
                lstClsUserInformation = lstClsUserInformation.OrderByDescending(x => x.CreatedOn).ToList();
            }
            else
            {

                var result = (from ui in dbEntities.tp_user_information
                              join tps in dbEntities.tp_state
                              on ui.ui_state_id equals tps.tps_id
                              //join tpc in dbEntities.tp_country
                              //on ui.ui_country_id equals tpc.tpc_id
                              //join tpci in dbEntities.tp_city
                              //on ui.ui_city_id equals tpci.tpci_id
                              where ui.ui_isdeleted == false

                              select new
                              {
                                  ui,
                                  //tpc.tpc_country_name,
                                  tps.tps_state_name,
                                  //tpci.tpci_city_name
                              }).ToList();

                foreach (var item in result)
                {
                    ClsUserInformation objClsUserInformation = new ClsUserInformation();
                    objClsUserInformation.UserId = item.ui.ui_id;
                    objClsUserInformation.SeqNo = item.ui.ui_seqno;
                    objClsUserInformation.FirstName = item.ui.ui_firstName;
                    objClsUserInformation.LastName = item.ui.ui_lastName;
                    objClsUserInformation.UserName = item.ui.ui_userName;
                    objClsUserInformation.Email = item.ui.ui_email;
                    objClsUserInformation.MobileNo = item.ui.ui_mobile;
                    objClsUserInformation.TelephoneNo = item.ui.ui_telephone;
                    // objClsUserInformation.CountryName = item.tpc_country_name;
                    objClsUserInformation.StateName = item.tps_state_name;
                    objClsUserInformation.CityName = item.ui.ui_city;
                    if (item.ui.createdon.ToString() != "" && item.ui.createdon != null)
                    {
                        objClsUserInformation.CreatedOn = item.ui.createdon;
                    }
                    objClsUserInformation.Pincode = item.ui.ui_pincode;
                    objClsUserInformation.Addressline1 = item.ui.ui_addressLine1;
                    objClsUserInformation.AddressLine2 = item.ui.ui_addressLine2;
                    objClsUserInformation.Street = item.ui.ui_street;
                    objClsUserInformation.HouseNo = item.ui.ui_house_no;

                    if (item.ui.ui_gender == 0)
                        objClsUserInformation.Gender = "Male";
                    else
                        objClsUserInformation.Gender = "Female";

                    lstClsUserInformation.Add(objClsUserInformation);
                }
                lstClsUserInformation = lstClsUserInformation.OrderByDescending(x => x.CreatedOn).ToList();
            }

        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }

        return lstClsUserInformation.ListToDataTable();
    }

    //User Registration Method
    public string UserRegistrationmethod(string firstName, string lastName, string emailAddress, string password, string address, string city, int stateId, int gender, string phone,string ZipCode)
    {

        string resMessage = "FAIL";

        try
        {
            if (isUserExist(emailAddress))
            {
                resMessage = "FAIL";
            }
            else
            {
                tp_user_information dbObjUserRegistration = new tp_user_information();
                dbObjUserRegistration.ui_usertype = 1;
                dbObjUserRegistration.ui_firstName = firstName;
                dbObjUserRegistration.ui_lastName = lastName;
                dbObjUserRegistration.ui_email = emailAddress;
                dbObjUserRegistration.ui_password = password;
                dbObjUserRegistration.ui_isdeleted = false;
                dbObjUserRegistration.ui_addressLine1 = address;
                dbObjUserRegistration.ui_city = city;
                dbObjUserRegistration.ui_state_id = stateId;
                dbObjUserRegistration.ui_gender = gender;
                dbObjUserRegistration.ui_telephone = phone;
                dbObjUserRegistration.createdon = DateTime.Now;
                dbObjUserRegistration.modifiedon = DateTime.Now;
                dbObjUserRegistration.ui_pincode = ZipCode;

                dbEntities.tp_user_information.Add(dbObjUserRegistration);
                if (dbEntities.SaveChanges() > 0)
                {
                    resMessage = "SUCCESS:"+dbObjUserRegistration.ui_id;
                }
                SendMail(emailAddress, "Registration in TomatosPizzeria", string.Empty, string.Empty, string.Empty, 1, string.Empty, string.Empty, string.Empty, string.Empty, null, string.Empty, string.Empty, string.Empty, string.Empty);
            }


        }
        catch (Exception ex)
        {
            ex.GetBaseException();
        }
        return resMessage;
    }

    //User Login Method
    public tp_user_information UserLogin(string email, string password)
    {
        int userInfoType = 0;
        tp_user_information dbObjUserLoginResult = new tp_user_information();

        try
        {

            dbObjUserLoginResult = dbEntities.tp_user_information.Where(P => P.ui_email.ToLower().Equals(email, StringComparison.InvariantCultureIgnoreCase) && P.ui_password.Equals(password) && P.ui_isdeleted == false).FirstOrDefault();

            if (dbObjUserLoginResult != null)
            {
                userInfoType = dbObjUserLoginResult.ui_usertype.Value;
            }

        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return dbObjUserLoginResult;
    }

    //Fill User Details for Edit Profile
    public tp_user_information GetUserDetailsById(int userId)
    {
        int userInfoType = 0;
        tp_user_information dbObjUserLoginResult = new tp_user_information();

        try
        {

            dbObjUserLoginResult = dbEntities.tp_user_information.Where(P => P.ui_id == userId && P.ui_isdeleted == false).FirstOrDefault();

            if (dbObjUserLoginResult != null)
            {
                userInfoType = dbObjUserLoginResult.ui_usertype.Value;
            }

        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return dbObjUserLoginResult;
    }
    //User Forget Password Method
    public string ForgetPassword(string userName)
    {
        string Url = string.Empty;
        string resMessage = "FAIL";

        try
        {
            if (isUserExist(userName))
            {
                List<tp_user_information> lstObjForgetPassword = new List<tp_user_information>();
                tp_user_information dbObjForgetPassword = new tp_user_information();

                var result = (from fp in dbEntities.tp_user_information where fp.ui_email == userName select fp).ToList();
                if (result.Count > 0)
                {

                    foreach (var item in result)
                    {

                        dbObjForgetPassword.ui_email = item.ui_email;
                        dbObjForgetPassword.ui_password = item.ui_password;
                        dbObjForgetPassword.ui_userName = item.ui_userName;
                        dbObjForgetPassword.ui_id = item.ui_id;
                        lstObjForgetPassword.Add(dbObjForgetPassword);
                    }
                    tp_config objConfig = new tp_config();
                    objConfig = dbEntities.tp_config.Where(x => x.tpc_key == "FORGOT_PASSWORD_URL").FirstOrDefault();
                    if (objConfig != null)
                    {
                        Url = objConfig.tpc_value + "ResetPassword.aspx?";
                    }
                    //Url = "http://localhost:59336/PasswordResetMail.aspx?";
                    string userid = HttpUtility.UrlEncode(Encrypt(dbObjForgetPassword.ui_id.ToString()));
                    string QueryString = string.Format("UserId={0}", userid);
                    Url += QueryString;



                    SendMail(userName, "Reset Password", string.Empty, string.Empty, userName, 2, Url, string.Empty, string.Empty, string.Empty, null, string.Empty, string.Empty, string.Empty, string.Empty);
                    resMessage = "SUCCESS";
                }


            }
            else
            {
                resMessage = "FAIL";
            }

        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return resMessage;
    }

    //Change Password Method
    public string ChangePassword(int userId, string password)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {
            tp_user_information dbObjUpdateUserInformation = null;
            dbObjUpdateUserInformation = dbEntities.tp_user_information.Where(P => P.ui_id == userId).FirstOrDefault();

            dbObjUpdateUserInformation.ui_password = password;
            dbObjUpdateUserInformation.ui_isdeleted = false;

            dbObjUpdateUserInformation.modifiedby = dbObjUpdateUserInformation.ui_id;

            dbObjUpdateUserInformation.modifiedon = DateTime.Now;
            retValue = dbEntities.SaveChanges();

            if (retValue == 1)
            {
                retMsg = "SUCCESS";
            }

        }
        catch (Exception)
        {
            retValue = 0;
        }

        return retMsg;
    }

    public string ChangeAdminUserNamePassword(int userId,string email, string password)
    {
        int retValue = 0;
        string retMsg = "FAIL";

        try
        {
            tp_user_information dbObjUpdateUserInformation = null;
            dbObjUpdateUserInformation = dbEntities.tp_user_information.Where(P => P.ui_id == userId).FirstOrDefault();

            dbObjUpdateUserInformation.ui_email = email;

            dbObjUpdateUserInformation.ui_password = password;
            dbObjUpdateUserInformation.ui_isdeleted = false;

            dbObjUpdateUserInformation.modifiedby = dbObjUpdateUserInformation.ui_id;

            dbObjUpdateUserInformation.modifiedon = DateTime.Now;
            retValue = dbEntities.SaveChanges();

            if (retValue == 1)
            {
                retMsg = "SUCCESS";
            }

        }
        catch (Exception)
        {
            retValue = 0;
        }

        return retMsg;
    }

    //Send Mail Method
    public void SendMail(string toadd, string subject, string body, string attachment, string ccaddress, int status, string link, string customerName, string Email, string Comments, List<ClsProductDetail> lstProductDetail, string Subtotal, string Discount, string TotalAmount, string OrderNumber)
    {
        try
        {
            tp_config objconfig = new tp_config();
            List<tp_config> lstconfig = new List<tp_config>();
            StreamReader reader;
            string email = string.Empty;
            string emailpassword = string.Empty;
            string servername = string.Empty;
            string companyEmail = string.Empty;
            string readFile;
            string myString = string.Empty;
            string retMsg = string.Empty;
            string DeliveryCharge = string.Empty;
            string TaxDetail = string.Empty;

            lstconfig = (from x in dbEntities.tp_config
                         select x).ToList();
            foreach (var item in lstconfig)
            {
                if (item.tpc_key == "TP_UserName")
                {
                    email = item.tpc_value;
                }
                else if (item.tpc_key == "TP_Password")
                {
                    emailpassword = item.tpc_value;
                }
                else if (item.tpc_key == "TP_ServerName")
                {
                    servername = item.tpc_value;
                }
                else if (item.tpc_key == "SEND_EMAIL_TO")
                {
                    companyEmail = item.tpc_value;
                }
                else if (item.tpc_key == "TAX_DETAILS")
                {
                    TaxDetail = item.tpc_value;
                }
                else if (item.tpc_key == "DELIVERY_CHARGES_DETAILS")
                {
                    DeliveryCharge = item.tpc_value;
                }
            }

            //status = 0;
            //Email Confirmation after Registration
            if (status == 1)
            {
                //reader = new StreamReader(@"D:\ForeverDiamondsAtlanta\ForeverDiamondsAtlantaWeb\EmailAccountDetails.html");
                reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailAccountDetails.html"));
                readFile = reader.ReadToEnd();
                reader.Dispose();
                myString = readFile;
                //myString = myString.Replace("$$Email$$", toadd);

            }



            //Forgot Password
            else if (status == 2)
            {
                reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailAccountRetrievePassword.html"));
                readFile = reader.ReadToEnd();
                reader.Dispose();
                myString = readFile;
                myString = myString.Replace("$$resetpasswordlink$$", link);

            }

            //Change Password
            else if (status == 3)
            {
                //reader = new StreamReader(@"D:\ForeverDiamondsAtlanta\ForeverDiamondsAtlantaWeb\EmailAccountChangePassword.html");
                ////reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailAccountChangePassword.html"));
                //readFile = reader.ReadToEnd();
                //reader.Dispose();
                //myString = readFile;
                //myString = myString.Replace("$$Details$$", "Your changed password details.");
                //myString = myString.Replace("$$Email$$", toadd);
                //myString = myString.Replace("$$password$$", password);
            }

            //order Placed
            else if (status == 4)
            {
                reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplateCustomerOrder.html"));
                readFile = reader.ReadToEnd();
                reader.Dispose();
                myString = readFile;
                myString = myString.Replace("$$OrderNumber$$", OrderNumber);
                myString = myString.Replace("$$OrderDate$$", DateTime.Now.ToLongDateString());
                string body1 = "<div class='table-responsive' style='padding:10px 20px;'><table border='1' bordercolor='#4B924E' style='padding:5px; border:1px solid #4B924E;width:100%; text-align:left; table-layout:auto;border-collapse: collapse;'><thead style='background: #4B924E;color: #ffffff;'><tr><th>ITEM</th><th>QTY</th><th>PRICE</th></tr></thead><tbody>";
                myString = myString + body1;
                foreach (var item in lstProductDetail)
                {
                    string body2 = "<tr rowspan='2'><td id='CS'><strong>{ProductName}</strong><br><span class='extra' style='font-weight:400; margin-top:5px;'>Add Extra:</span> <br /> <span class='ing_name' id='MZC'>{ExtraIngredient}</span></td><td>{Quantity}</td><td>{Price}</td></tr>";
                    myString = myString + body2;
                    myString = myString.Replace("{ProductName}", item.ProductName);
                    myString = myString.Replace("{ExtraIngredient}", item.ExtraIngredient.ToString());
                    myString = myString.Replace("{Quantity}", item.Quantity.ToString());
                    myString = myString.Replace("{Price}", item.Price.ToString());
                }
                string body3 = "<tr><td></td><td>Subtotal:</td><td>{Subtotal}</td></tr><tr><td></td><td>Delivery:</td><td>{DeliveryCharge}</td></tr><tr><td></td><td>Tax:</td><td>{TaxDetail}</td></tr><tr><td></td><td>Discount:</td><td>{Discount}</td></tr><tr style='font-weight:600;'><td rowspan='2'><em>Payment Method:CREDIT <br>Ordered with Visa, ending with -4662</em> <td rowspan='2'>Total:</td><td rowspan='2'>{TotalAmount}</td></tr></tbody></table></div><div class='contact' style='margin:10px;  border-top:1px solid #888888;border-bottom:1px solid #888888; padding:10px;'>For any questions regarding this order please call MyPizza.com at 1-888-974-9928.</div><div class='button-group' style='margin:10px 0px; padding:10px; width:100%; overflow:hidden;'><a href='http://s3.amazonaws.com/mypizza-faxes/emails/2460995-1435880929.pdf' class='pdf_btn' style='background:#4B924E; color:#FFFFFF;padding:10px 20px;'>View PDF</a><div class='copyright'><p>Copyright © 2016 MyPizza, All rights reserved. <strong> Our email address is:</strong><em> order@mypizza.com</em></p></div>";
                myString = myString + body3;
                myString = myString.Replace("{Subtotal}", Subtotal);
                myString = myString.Replace("{DeliveryCharge}", DeliveryCharge);
                myString = myString.Replace("{TaxDetail}", TaxDetail);
                myString = myString.Replace("{Discount}", Discount);
                myString = myString.Replace("{TotalAmount}", TotalAmount);
            }
            //Order Shipped
            else if (status == 5)
            {
                //reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailAccountChangePassword.html"));
                //readFile = reader.ReadToEnd();
                //reader.Dispose();
                //myString = readFile;
                //myString = myString.Replace("$$Details$$", " Welcome to the most integrated eClinic");
                //myString = myString.Replace("$$Email$$", toadd);
                //myString = myString.Replace("$$password$$", password);
            }
            //Contact Us
            else if (status == 6)
            {
                reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailContactUsTemplate.html"));
                readFile = reader.ReadToEnd();
                reader.Dispose();
                myString = readFile;
                myString = myString.Replace("$$CustomerName$$", customerName);
                myString = myString.Replace("$$Email$$", Email);
                myString = myString.Replace("$$Comments$$", Comments);
                toadd = companyEmail;
            }
            //Loose diamond inquiry response
            else if (status == 7)
            {
                //reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailAccountChangePassword.html"));
                //readFile = reader.ReadToEnd();
                //reader.Dispose();
                //myString = readFile;
                //myString = myString.Replace("$$Details$$", " Welcome to the most integrated eClinic");
                //myString = myString.Replace("$$Email$$", toadd);
                //myString = myString.Replace("$$password$$", password);
            }

            //review the product
            else if (status == 8)
            {
                //reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailDoctorRegistrationDetails.html"));
                //readFile = reader.ReadToEnd();
                //reader.Dispose();
                //myString = readFile;
                //myString = myString.Replace("$$DoctorName$$", doctorname);
                //myString = myString.Replace("$$DoctorEmail$$", patientEmail);
                //myString = myString.Replace("$$DoctorMobile$$", mobileNo);
            }
            else if (status == 9)
            {
                reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailFailedTransation.html"));
                readFile = reader.ReadToEnd();
                reader.Dispose();
                myString = readFile;

            }
            //news latter
            else if (status == 10)
            {

                myString = body;

            }
            NetworkCredential objCred = new NetworkCredential(email, emailpassword);

            SmtpClient objSMTP = new SmtpClient();
            objSMTP.Host = servername;
            objSMTP.Port = 587;
            objSMTP.Credentials = objCred;
            objSMTP.EnableSsl = false;

            MailAddress objMailFrom = new MailAddress(email, "Admin - TomatosPizzeria");
            MailAddress objMailTo = new MailAddress(toadd);
            MailAddress objMailToCompany = new MailAddress(companyEmail);
            MailMessage objMailMsg = new MailMessage();
            objMailMsg.From = objMailFrom;
            objMailMsg.To.Add(objMailTo);
            objMailMsg.To.Add(objMailToCompany);
         
            if (!string.IsNullOrEmpty(attachment))
            {
                using (Attachment at = new Attachment(attachment))
                {
                    objMailMsg.Attachments.Add(at);
                }
            }
            if (!string.IsNullOrEmpty(ccaddress))
            {
                objMailMsg.CC.Add(ccaddress);
            }
            objMailMsg.IsBodyHtml = true;
            
            objMailMsg.Body = myString;

            objSMTP.DeliveryMethod = SmtpDeliveryMethod.Network;
            objMailMsg.Subject = subject;

            try
            {
                if (objMailMsg != null)
                {
                    objSMTP.Send(objMailMsg);
                    retMsg = "SUCCESS";
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex);
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }

    public List<tp_state> GetAllStates()
    {
        List<tp_state> lstStates = new List<tp_state>();
        try
        {

            lstStates = dbEntities.tp_state.ToList<tp_state>();

        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstStates;
    }

    private string Encrypt(string clearText)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        try
        {
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return clearText;
    }


    public ClsUserInformation GetCustomerDetailByOrderId(string orderNumber)
    {

        ClsUserInformation objClsUserInformation = new ClsUserInformation();
        try
        {

            var result = (from a in dbEntities.tp_billing_detail
                          join b in dbEntities.tp_customer_order_details
                          on a.tbd_cod_id equals b.cod_id
                        
                          where a.tbd_isdeleted == false && b.cod_isdeleted == false && b.cod_order_number == orderNumber

                          select new
                          {
                              a,
                              b,
                             
                          }).FirstOrDefault();

            if (result != null)
            {
                objClsUserInformation.CustomerName = result.a.tbd_name;
                objClsUserInformation.Addressline1 = result.a.tbd_address;
                objClsUserInformation.Email = result.a.tbd_email;
                objClsUserInformation.CityName = result.a.tbd_city;
                objClsUserInformation.TelephoneNo = result.a.tbd_telephone;
                objClsUserInformation.Pincode = result.a.tbd_zipcode;
                tp_state objState = dbEntities.tp_state.Where(x => result.a.tbd_state_id == x.tps_id).FirstOrDefault();
                if (objState != null)
                {
                    objClsUserInformation.StateName = objState.tps_state_name;
                }
                objClsUserInformation.DeliveryInstruction = result.a.tbd_delivery_instruction;
                objClsUserInformation.OrderType = result.b.cod_order_type;
                objClsUserInformation.OrderTotalAmount = result.b.cod_total_amount;
                objClsUserInformation.SalesTax = result.b.cod_tax;
                objClsUserInformation.DeliveryCharges = result.b.cod_delivery_charge;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }

        return objClsUserInformation;
    }

}