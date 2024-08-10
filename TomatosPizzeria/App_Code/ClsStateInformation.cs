using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClsStateInformation
/// </summary>
public class ClsStateInformation
{
    TP_DatabaseEntities dbEntities = new TP_DatabaseEntities();
    public ClsStateInformation()
    {
       
    }

    #region Properties

    private int m_stateId;
    private int m_stateName;

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

    public int StateName
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

    #endregion

    //Get All State
    public List<tp_state> GetAllState()
    {
        List<tp_state> lstStates = new List<tp_state>();
       
        try
        {
            lstStates = (from tps in dbEntities.tp_state
                         join tpc in dbEntities.tp_country
                         on tps.tps_tpc_id equals tpc.tpc_id
                         select tps).ToList();

            foreach (var item in lstStates)
            {
                tp_state objStateInformation = new tp_state();
                objStateInformation.tps_id = item.tps_id;
                objStateInformation.tps_state_name = item.tps_state_name;

                lstStates.Add(objStateInformation);
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lstStates;

    }
}