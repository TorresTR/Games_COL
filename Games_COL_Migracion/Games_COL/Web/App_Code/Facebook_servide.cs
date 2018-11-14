using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using Persistencia_funciones;
using Utilitarios;
using Logica;
using Data;
using ASPSnippets.FaceBookAPI;
using System.Data;

/// <summary>
/// Descripción breve de Facebook_servide
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class Facebook_servide : System.Web.Services.WebService
{

    public ServiceToken SoapHeader;

    public Facebook_servide()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public void accedefacebook()
    {

    }

    [WebMethod]
    [System.Web.Services.Protocols.SoapHeader("SoapHeader")]
    public string AutenticacionCliente()
    {
        try
        {
            if (SoapHeader == null)
            {
                return "-1";
            }
            if (!SoapHeader.blCredencialesValidas(SoapHeader.sToken))
            {
                return "-1";
            }

            string stToken = Guid.NewGuid().ToString();

            HttpRuntime.Cache.Add(stToken,
                SoapHeader.sToken,
                null,
                System.Web.Caching.Cache.NoAbsoluteExpiration,
                TimeSpan.FromDays(2),
                System.Web.Caching.CacheItemPriority.NotRemovable,
                null);

            return stToken;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    [WebMethod]
    public DataTable etiquetas()
    {
       
            L_persistencia per = new L_persistencia();
            DataTable dato = per.obtenerEtiquetas();
            return dato;
       
       
    }
    [WebMethod]
    [System.Web.Services.Protocols.SoapHeader("SoapHeader")]
    public DataTable postpc()
    {
        try
        {
            if (SoapHeader == null)
            {
                throw new Exception("Requiere validacion");
            }
            if (!SoapHeader.blCredencialesValidas(SoapHeader))
            {
                throw new Exception("Requiere validacion");
            }
            L_persistencia per = new L_persistencia();
            L_Usercs user = new L_Usercs();
            DataTable data = new DataTable();
      
            data = user.ToDataTable(per.obtenerPostpc());
             
        
            return data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
    }
    [WebMethod]
    public DataTable postxbox()
    {
        try
        {
            if (SoapHeader == null)
            {
                throw new Exception("Requiere validacion");
            }
            if (!SoapHeader.blCredencialesValidas(SoapHeader))
            {
                throw new Exception("Requiere validacion");
            }
            L_persistencia per = new L_persistencia();
            L_Usercs user = new L_Usercs();
            DataTable data = new DataTable();

            data = user.ToDataTable(per.obtenerPostxbox());


            return data;

        }
        catch (Exception ex)
        {

            throw ex;
        }
        
    }
    [WebMethod]
    public DataTable postps()
    {
        try
        {
            if (SoapHeader == null)
            {
                throw new Exception("Requiere validacion");
            }
            if (!SoapHeader.blCredencialesValidas(SoapHeader))
            {
                throw new Exception("Requiere validacion");
            }
            L_persistencia per = new L_persistencia();
            L_Usercs user = new L_Usercs();
            DataTable data = new DataTable();

            data = user.ToDataTable(per.obtenerPostpS());


            return data;
        }

        catch (Exception ex)
        {

            throw ex;
        }
    }
    [WebMethod]
    public DataTable postandroid()
    {
        try
        {
            if (SoapHeader == null)
            {
                throw new Exception("Requiere validacion");
            }
            if (!SoapHeader.blCredencialesValidas(SoapHeader))
            {
                throw new Exception("Requiere validacion");
            }
            L_persistencia per = new L_persistencia();
            L_Usercs user = new L_Usercs();
            DataTable data = new DataTable();

            data = user.ToDataTable(per.obtenerPostAndroid());


            return data;
        }
        catch (Exception ex)
        {

            throw ex;
        }
        
    }

    [WebMethod]
    public DataSet loggin(string nick, string contraseña)
    {
        try
        {
            if (SoapHeader == null)
            {
                throw new Exception("Requiere validacion");
            }
            if (!SoapHeader.blCredencialesValidas(SoapHeader))
            {
                throw new Exception("Requiere validacion");
            }
            L_Usercs per = new L_Usercs();
            DataTable dato = new DataTable();
            DataSet dt = new DataSet();
            dato = per.validaWS(nick, contraseña);
            dt.Tables.Add(dato);
            return dt;
        }
        catch (Exception ex)
        {

            throw ex;
        }
       
    }

    [WebMethod]
    public DataSet buscador(string titulo)
    {
        try
        {
            if (SoapHeader == null)
            {
                throw new Exception("Requiere validacion");
            }
            if (!SoapHeader.blCredencialesValidas(SoapHeader))
            {
                throw new Exception("Requiere validacion");
            }
            L_Usercs per = new L_Usercs();
            DataTable dato = new DataTable();
            DataSet dt = new DataSet();
            dato = per.Busqueda(titulo);
            dt.Tables.Add(dato);
            return dt;
        }
        catch (Exception ex)
        {

            throw ex;
        }
        
    }


    [WebMethod]
    public string contactenos(string correo,string sugerencia)
    {
        try
        {
            if (SoapHeader == null)
            {
                throw new Exception("Requiere validacion");
            }
            if (!SoapHeader.blCredencialesValidas(SoapHeader))
            {
                throw new Exception("Requiere validacion");
            }
            L_Usercs per = new L_Usercs();
            per.insertarContacto(correo, sugerencia);
            return "Contacto enviado!";
        }
        catch (Exception ex)
        {

            throw ex;
        }
        
        
    }

    [WebMethod]
    [System.Web.Services.Protocols.SoapHeader("SoapHeader")]
    public DataTable noticias()
    {
        try
        {
            if (SoapHeader == null)
            {
                throw new Exception("Requiere validacion");
            }
            if (!SoapHeader.blCredencialesValidas(SoapHeader))
            {
                throw new Exception("Requiere validacion");
            }
            L_persistencia per = new L_persistencia();
            L_Usercs user = new L_Usercs();
            DataTable dato = new DataTable();
            dato = user.ToDataTable(per.obtenerNoticia());
            return dato;
        }
        catch (Exception ex)
        {

            throw ex;
        }
        

    }

    [WebMethod]
    public DataTable postMas()
    {
        try
        {
            if (SoapHeader == null)
            {
                throw new Exception("Requiere validacion");
            }
            if (!SoapHeader.blCredencialesValidas(SoapHeader))
            {
                throw new Exception("Requiere validacion");
            }
            L_persistencia per = new L_persistencia();
            L_Usercs user = new L_Usercs();
            DataView dato = new DataView();
            dato = user.postPuntuados();
            DataTable dat = dato.ToTable();
            return dat;
        }
        catch (Exception ex)
        {

            throw ex;
        }
      

    }

}
