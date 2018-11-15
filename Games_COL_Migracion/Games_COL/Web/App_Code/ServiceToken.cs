using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Logica;
public class ServiceToken : System.Web.Services.Protocols.SoapHeader
{

    public string sToken { get; set; }
    public string AutenticacionToken { get; set; }

    public bool blCredencialesValidas(string sToken)
    {
        try
        {
            l_sw val = new l_sw();

            int dat = val.llave(sToken);

           
            if (dat == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    public bool blCredencialesValidas(ServiceToken SoapHeader)
    {
        try
        {
            if (SoapHeader == null)
            {
                return false;
            }
            if (!string.IsNullOrEmpty(SoapHeader.AutenticacionToken))
            {
                return (HttpRuntime.Cache[SoapHeader.AutenticacionToken] != null);
            }
            return false;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

}