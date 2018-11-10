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
            l_sw log = new l_sw();
            bool valida = log.valida(sToken);
            return valida;
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
            object soap =SoapHeader;
            bool soh = string.IsNullOrEmpty(SoapHeader.AutenticacionToken);
            object http = HttpRuntime.Cache[SoapHeader.AutenticacionToken];
            bool val=true;
            return val;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

}