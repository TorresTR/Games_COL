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
    public DataTable etiquetas()
    {
        L_persistencia per = new L_persistencia();
        DataTable dato = per.obtenerEtiquetas();
        return dato;
    }
    [WebMethod]
    public DataTable postpc()
    {
        L_persistencia per = new L_persistencia();
        L_Usercs user = new L_Usercs();
        DataTable data = new DataTable();
      
        data = user.ToDataTable(per.obtenerPostpc());
             
        
        return data;
    }
    [WebMethod]
    public DataTable postxbox()
    {
        L_persistencia per = new L_persistencia();
        L_Usercs user = new L_Usercs();
        DataTable data = new DataTable();

        data = user.ToDataTable(per.obtenerPostxbox());


        return data;
    }
    [WebMethod]
    public DataTable postps()
    {
        L_persistencia per = new L_persistencia();
        L_Usercs user = new L_Usercs();
        DataTable data = new DataTable();

        data = user.ToDataTable(per.obtenerPostpS());


        return data;
    }
    [WebMethod]
    public DataTable postandroid()
    {
        L_persistencia per = new L_persistencia();
        L_Usercs user = new L_Usercs();
        DataTable data = new DataTable();

        data = user.ToDataTable(per.obtenerPostAndroid());


        return data;
    }
    
}
