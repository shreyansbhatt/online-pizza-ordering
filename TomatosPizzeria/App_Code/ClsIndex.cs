using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClsIndex
/// </summary>
public class ClsIndex
{
    public ClsIndex()
    {
        
    }

    TP_DatabaseEntities dbEntities = new TP_DatabaseEntities();

    public string AddUpdateHomePageImages(tp_config objfdaConfigSlider1Img1, tp_config objfdaConfigSlider1Img2, tp_config objfdaConfigSlider1Img3, tp_config objfdaConfigSlider1Img4, tp_config objfdaConfigSlider2Img1, tp_config objfdaConfigSlider2Img2, tp_config objfdaConfigSlider2Img3, tp_config objfdaConfigSlider2Img4, tp_config objfdaConfigSlider2Img5, tp_config objfdaConfigSlider2Img6, tp_config objfdaConfigDailySpeicalImg,tp_config objConfigImage1Text,tp_config objConfigImage2Text,tp_config objConfigImage3Text,tp_config objConfigImage4Text,tp_config objConfigImage5Text,tp_config objConfigImage6Text)
    {
        int retValue1 = 0, retValue2 = 0, retValue3 = 0, retValue4 = 0, retValue5 = 0, retValue6 = 0, retValue7 = 0, retValue8 = 0, retValue9 = 0, retValue10 = 0, retValue11 = 0, retValue12 = 0, retValue13 = 0, retValue14 = 0, retValue15 = 0, retValue16 = 0, retValue17 = 0;
        string retMsg = "FAIL";
        try
        {
            tp_config objtpConfig = new tp_config();
            objtpConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains(objfdaConfigSlider1Img1.tpc_key)).FirstOrDefault();
            if (objtpConfig != null)
            {
                objtpConfig.tpc_value = objfdaConfigSlider1Img1.tpc_value;
                retValue1 = dbEntities.SaveChanges();
            }
            else
            {
                tp_config tpconfig = new tp_config();
                tpconfig.tpc_key = objfdaConfigSlider1Img1.tpc_key;
                tpconfig.tpc_value = objfdaConfigSlider1Img1.tpc_value;
                dbEntities.tp_config.Add(tpconfig);
                retValue1 = dbEntities.SaveChanges();
            }

            objtpConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains(objfdaConfigSlider1Img2.tpc_key)).FirstOrDefault();
            if (objtpConfig != null)
            {
                objtpConfig.tpc_value = objfdaConfigSlider1Img2.tpc_value;
                retValue2 = dbEntities.SaveChanges();
            }
            else
            {
                tp_config tpconfig = new tp_config();
                tpconfig.tpc_key = objfdaConfigSlider1Img2.tpc_key;
                tpconfig.tpc_value = objfdaConfigSlider1Img2.tpc_value;
                dbEntities.tp_config.Add(tpconfig);
                retValue2 = dbEntities.SaveChanges();
            }

            objtpConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains(objfdaConfigSlider1Img3.tpc_key)).FirstOrDefault();
            if (objtpConfig != null)
            {
                objtpConfig.tpc_value = objfdaConfigSlider1Img3.tpc_value;
                retValue3 = dbEntities.SaveChanges();
            }
            else
            {
                tp_config tpconfig = new tp_config();
                tpconfig.tpc_key = objfdaConfigSlider1Img3.tpc_key;
                tpconfig.tpc_value = objfdaConfigSlider1Img3.tpc_value;
                dbEntities.tp_config.Add(tpconfig);
                retValue3 = dbEntities.SaveChanges();
            }

            objtpConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains(objfdaConfigSlider1Img4.tpc_key)).FirstOrDefault();
            if (objtpConfig != null)
            {
                objtpConfig.tpc_value = objfdaConfigSlider1Img4.tpc_value;
                retValue4 = dbEntities.SaveChanges();
            }
            else
            {
                tp_config tpconfig = new tp_config();
                tpconfig.tpc_key = objfdaConfigSlider1Img4.tpc_key;
                tpconfig.tpc_value = objfdaConfigSlider1Img4.tpc_value;
                dbEntities.tp_config.Add(tpconfig);
                retValue4 = dbEntities.SaveChanges();
            }

            objtpConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains(objfdaConfigSlider2Img1.tpc_key)).FirstOrDefault();
            if (objtpConfig != null)
            {
                objtpConfig.tpc_value = objfdaConfigSlider2Img1.tpc_value;
                retValue5 = dbEntities.SaveChanges();
            }
            else
            {
                tp_config tpconfig = new tp_config();
                tpconfig.tpc_key = objfdaConfigSlider2Img1.tpc_key;
                tpconfig.tpc_value = objfdaConfigSlider2Img1.tpc_value;
                dbEntities.tp_config.Add(tpconfig);
                retValue5 = dbEntities.SaveChanges();
            }

            objtpConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains(objfdaConfigSlider2Img2.tpc_key)).FirstOrDefault();
            if (objtpConfig != null)
            {
                objtpConfig.tpc_value = objfdaConfigSlider2Img2.tpc_value;
                retValue6 = dbEntities.SaveChanges();
            }
            else
            {
                tp_config tpconfig = new tp_config();
                tpconfig.tpc_key = objfdaConfigSlider2Img2.tpc_key;
                tpconfig.tpc_value = objfdaConfigSlider2Img2.tpc_value;
                dbEntities.tp_config.Add(tpconfig);
                retValue6 = dbEntities.SaveChanges();
            }

            objtpConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains(objfdaConfigSlider2Img3.tpc_key)).FirstOrDefault();
            if (objtpConfig != null)
            {
                objtpConfig.tpc_value = objfdaConfigSlider2Img3.tpc_value;
                retValue7 = dbEntities.SaveChanges();
            }
            else
            {
                tp_config tpconfig = new tp_config();
                tpconfig.tpc_key = objfdaConfigSlider2Img3.tpc_key;
                tpconfig.tpc_value = objfdaConfigSlider2Img3.tpc_value;
                dbEntities.tp_config.Add(tpconfig);
                retValue7 = dbEntities.SaveChanges();
            }

            objtpConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains(objfdaConfigSlider2Img4.tpc_key)).FirstOrDefault();
            if (objtpConfig != null)
            {
                objtpConfig.tpc_value = objfdaConfigSlider2Img4.tpc_value;
                retValue8 = dbEntities.SaveChanges();
            }
            else
            {
                tp_config tpconfig = new tp_config();
                tpconfig.tpc_key = objfdaConfigSlider2Img4.tpc_key;
                tpconfig.tpc_value = objfdaConfigSlider2Img4.tpc_value;
                dbEntities.tp_config.Add(tpconfig);
                retValue8 = dbEntities.SaveChanges();
            }

            objtpConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains(objfdaConfigSlider2Img5.tpc_key)).FirstOrDefault();
            if (objtpConfig != null)
            {
                objtpConfig.tpc_value = objfdaConfigSlider2Img5.tpc_value;
                retValue9 = dbEntities.SaveChanges();
            }
            else
            {
                tp_config tpconfig = new tp_config();
                tpconfig.tpc_key = objfdaConfigSlider2Img5.tpc_key;
                tpconfig.tpc_value = objfdaConfigSlider2Img5.tpc_value;
                dbEntities.tp_config.Add(tpconfig);
                retValue9 = dbEntities.SaveChanges();
            }

            objtpConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains(objfdaConfigSlider2Img6.tpc_key)).FirstOrDefault();
            if (objtpConfig != null)
            {
                objtpConfig.tpc_value = objfdaConfigSlider2Img6.tpc_value;
                retValue10 = dbEntities.SaveChanges();
            }
            else
            {
                tp_config tpconfig = new tp_config();
                tpconfig.tpc_key = objfdaConfigSlider2Img6.tpc_key;
                tpconfig.tpc_value = objfdaConfigSlider2Img6.tpc_value;
                dbEntities.tp_config.Add(tpconfig);
                retValue10 = dbEntities.SaveChanges();
            }

            objtpConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains(objfdaConfigDailySpeicalImg.tpc_key)).FirstOrDefault();
            if (objtpConfig != null)
            {
                objtpConfig.tpc_value = objfdaConfigDailySpeicalImg.tpc_value;
                retValue11 = dbEntities.SaveChanges();
            }
            else
            {
                tp_config tpconfig = new tp_config();
                tpconfig.tpc_key = objfdaConfigDailySpeicalImg.tpc_key;
                tpconfig.tpc_value = objfdaConfigDailySpeicalImg.tpc_value;
                dbEntities.tp_config.Add(tpconfig);
                retValue11 = dbEntities.SaveChanges();
            }

            objtpConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains(objConfigImage1Text.tpc_key)).FirstOrDefault();
            if (objtpConfig != null)
            {
                objtpConfig.tpc_value = objConfigImage1Text.tpc_value;
                retValue12 = dbEntities.SaveChanges();
            }
            else
            {
                tp_config tpconfig = new tp_config();
                tpconfig.tpc_key = objConfigImage1Text.tpc_key;
                tpconfig.tpc_value = objConfigImage1Text.tpc_value;
                dbEntities.tp_config.Add(tpconfig);
                retValue12 = dbEntities.SaveChanges();
            }

            objtpConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains(objConfigImage2Text.tpc_key)).FirstOrDefault();
            if (objtpConfig != null)
            {
                objtpConfig.tpc_value = objConfigImage2Text.tpc_value;
                retValue13 = dbEntities.SaveChanges();
            }
            else
            {
                tp_config tpconfig = new tp_config();
                tpconfig.tpc_key = objConfigImage2Text.tpc_key;
                tpconfig.tpc_value = objConfigImage2Text.tpc_value;
                dbEntities.tp_config.Add(tpconfig);
                retValue13 = dbEntities.SaveChanges();
            }

            objtpConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains(objConfigImage3Text.tpc_key)).FirstOrDefault();
            if (objtpConfig != null)
            {
                objtpConfig.tpc_value = objConfigImage3Text.tpc_value;
                retValue14 = dbEntities.SaveChanges();
            }
            else
            {
                tp_config tpconfig = new tp_config();
                tpconfig.tpc_key = objConfigImage3Text.tpc_key;
                tpconfig.tpc_value = objConfigImage3Text.tpc_value;
                dbEntities.tp_config.Add(tpconfig);
                retValue14 = dbEntities.SaveChanges();
            }

            objtpConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains(objConfigImage4Text.tpc_key)).FirstOrDefault();
            if (objtpConfig != null)
            {
                objtpConfig.tpc_value = objConfigImage4Text.tpc_value;
                retValue15 = dbEntities.SaveChanges();
            }
            else
            {
                tp_config tpconfig = new tp_config();
                tpconfig.tpc_key = objConfigImage4Text.tpc_key;
                tpconfig.tpc_value = objConfigImage4Text.tpc_value;
                dbEntities.tp_config.Add(tpconfig);
                retValue15 = dbEntities.SaveChanges();
            }

            objtpConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains(objConfigImage5Text.tpc_key)).FirstOrDefault();
            if (objtpConfig != null)
            {
                objtpConfig.tpc_value = objConfigImage5Text.tpc_value;
                retValue16 = dbEntities.SaveChanges();
            }
            else
            {
                tp_config tpconfig = new tp_config();
                tpconfig.tpc_key = objConfigImage5Text.tpc_key;
                tpconfig.tpc_value = objConfigImage5Text.tpc_value;
                dbEntities.tp_config.Add(tpconfig);
                retValue16 = dbEntities.SaveChanges();
            }

            objtpConfig = dbEntities.tp_config.Where(x => x.tpc_key.Contains(objConfigImage6Text.tpc_key)).FirstOrDefault();
            if (objtpConfig != null)
            {
                objtpConfig.tpc_value = objConfigImage6Text.tpc_value;
                retValue17 = dbEntities.SaveChanges();
            }
            else
            {
                tp_config tpconfig = new tp_config();
                tpconfig.tpc_key = objConfigImage6Text.tpc_key;
                tpconfig.tpc_value = objConfigImage6Text.tpc_value;
                dbEntities.tp_config.Add(tpconfig);
                retValue17 = dbEntities.SaveChanges();
            }

            if (retValue1 > 0 || retValue2 > 0 || retValue3 > 0 || retValue4 > 0 || retValue5 > 0 || retValue6 > 0 || retValue7 > 0 || retValue8 > 0 || retValue9 > 0 || retValue10 > 0 || retValue11 > 0 || retValue12 > 0 || retValue13 > 0 || retValue14 > 0 || retValue15 > 0 || retValue16 > 0 || retValue17 > 0)
            {
                retMsg = "SUCCESS";
            }
            else
            {
                retMsg = "FAIL";
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return retMsg;
    }


    public tp_config GetHomePageImgUrl()
    {
        tp_config objtp_config = new tp_config();
        try
        {

            objtp_config = dbEntities.tp_config.Where(x => x.tpc_key == "HOMEPAGE_IMAGES_PATH").FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return objtp_config;
    }



    public List<tp_config> GetHomePageImages()
    {
        List<tp_config> lsTpConfig = new List<tp_config>();

        try
        {
            tp_config objtp_config1 = new tp_config();
            objtp_config1 = dbEntities.tp_config.Where(x => x.tpc_key == "SLIDER1_IMAGE1").FirstOrDefault();

            tp_config objtp_config2 = new tp_config();
            objtp_config2 = dbEntities.tp_config.Where(x => x.tpc_key == "SLIDER1_IMAGE2").FirstOrDefault();

            tp_config objtp_config3 = new tp_config();
            objtp_config3 = dbEntities.tp_config.Where(x => x.tpc_key == "SLIDER1_IMAGE3").FirstOrDefault();

            tp_config objtp_config4 = new tp_config();
            objtp_config4 = dbEntities.tp_config.Where(x => x.tpc_key == "SLIDER1_IMAGE4").FirstOrDefault();

            tp_config objtp_config5 = new tp_config();
            objtp_config5 = dbEntities.tp_config.Where(x => x.tpc_key == "SLIDER2_IMAGE1").FirstOrDefault();

            tp_config objtp_config6 = new tp_config();
            objtp_config6 = dbEntities.tp_config.Where(x => x.tpc_key == "SLIDER2_IMAGE2").FirstOrDefault();

            tp_config objtp_config7 = new tp_config();
            objtp_config7 = dbEntities.tp_config.Where(x => x.tpc_key == "SLIDER2_IMAGE3").FirstOrDefault();

            tp_config objtp_config8 = new tp_config();
            objtp_config8 = dbEntities.tp_config.Where(x => x.tpc_key == "SLIDER2_IMAGE4").FirstOrDefault();

            tp_config objtp_config9 = new tp_config();
            objtp_config9 = dbEntities.tp_config.Where(x => x.tpc_key == "SLIDER2_IMAGE5").FirstOrDefault();

            tp_config objtp_config10 = new tp_config();
            objtp_config10 = dbEntities.tp_config.Where(x => x.tpc_key == "SLIDER2_IMAGE6").FirstOrDefault();

            tp_config objtp_config11 = new tp_config();
            objtp_config11 = dbEntities.tp_config.Where(x => x.tpc_key == "DAILY_SPECIAL_IMAGE").FirstOrDefault();

            if (objtp_config1 != null && objtp_config2 != null && objtp_config3 != null && objtp_config4 != null && objtp_config5 != null && objtp_config6 != null && objtp_config7 != null && objtp_config8 != null && objtp_config9 != null && objtp_config10 != null && objtp_config11 != null)
            {
                lsTpConfig.Add(objtp_config1);
                lsTpConfig.Add(objtp_config2);
                lsTpConfig.Add(objtp_config3);
                lsTpConfig.Add(objtp_config4);
                lsTpConfig.Add(objtp_config5);
                lsTpConfig.Add(objtp_config6);
                lsTpConfig.Add(objtp_config7);
                lsTpConfig.Add(objtp_config8);
                lsTpConfig.Add(objtp_config9);
                lsTpConfig.Add(objtp_config10);
                lsTpConfig.Add(objtp_config11);
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lsTpConfig;
    }

    public List<tp_config> GetHomePageBottomSliderImagesText()
    {
        List<tp_config> lsTpConfig = new List<tp_config>();

        try
        {            
            tp_config objtp_config5 = new tp_config();
            objtp_config5 = dbEntities.tp_config.Where(x => x.tpc_key == "SLIDER2_IMAGE1_TEXT").FirstOrDefault();

            tp_config objtp_config6 = new tp_config();
            objtp_config6 = dbEntities.tp_config.Where(x => x.tpc_key == "SLIDER2_IMAGE2_TEXT").FirstOrDefault();

            tp_config objtp_config7 = new tp_config();
            objtp_config7 = dbEntities.tp_config.Where(x => x.tpc_key == "SLIDER2_IMAGE3_TEXT").FirstOrDefault();

            tp_config objtp_config8 = new tp_config();
            objtp_config8 = dbEntities.tp_config.Where(x => x.tpc_key == "SLIDER2_IMAGE4_TEXT").FirstOrDefault();

            tp_config objtp_config9 = new tp_config();
            objtp_config9 = dbEntities.tp_config.Where(x => x.tpc_key == "SLIDER2_IMAGE5_TEXT").FirstOrDefault();

            tp_config objtp_config10 = new tp_config();
            objtp_config10 = dbEntities.tp_config.Where(x => x.tpc_key == "SLIDER2_IMAGE6_TEXT").FirstOrDefault();

           
            if (objtp_config5 != null && objtp_config6 != null && objtp_config7 != null && objtp_config8 != null && objtp_config9 != null && objtp_config10 != null)
            {                
                lsTpConfig.Add(objtp_config5);
                lsTpConfig.Add(objtp_config6);
                lsTpConfig.Add(objtp_config7);
                lsTpConfig.Add(objtp_config8);
                lsTpConfig.Add(objtp_config9);
                lsTpConfig.Add(objtp_config10);
               
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
        return lsTpConfig;
    }
}