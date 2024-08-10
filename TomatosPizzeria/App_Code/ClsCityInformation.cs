using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClsCityInformation
/// </summary>
public class ClsCityInformation
{
    TP_DatabaseEntities dbEntities = new TP_DatabaseEntities();
    public ClsCityInformation()
    {
       
    }
    #region Properties

    private int m_cityId;
    private int m_cityName;

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

    public int CityName
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

    #endregion

    //Get All Cities
    public List<tp_city> GetAllCity()
    {
        List<tp_city> lstCities = new List<tp_city>();

        try
        {
            lstCities = (from tpci in dbEntities.tp_city
                         join tps in dbEntities.tp_state
                         on tpci.tpci_tps_id equals tps.tps_id
                         select tpci).ToList();

            foreach (var item in lstCities)
            {
                tp_city objCityInformation = new tp_city();
                objCityInformation.tpci_id = item.tpci_id;
                objCityInformation.tpci_city_name = item.tpci_city_name;

                lstCities.Add(objCityInformation);
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstCities;

    }
}