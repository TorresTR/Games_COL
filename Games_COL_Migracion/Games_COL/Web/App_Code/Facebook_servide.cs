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

    [WebMethod]
    public DataSet loggin(string nick, string contraseña)
    {
        L_Usercs per = new L_Usercs();
        DataTable dato = new DataTable();
        DataSet dt = new DataSet();
        dato = per.validaWS(nick,contraseña);
        dt.Tables.Add(dato);
        return dt;
    }

    [WebMethod]
    public DataSet buscador(string titulo)
    {
        L_Usercs per = new L_Usercs();
        DataTable dato = new DataTable();
        DataSet dt = new DataSet();
        dato = per.Busqueda(titulo);
        dt.Tables.Add(dato);
        return dt;
    }


    [WebMethod]
    public string contactenos(string correo,string sugerencia)
    {
        L_Usercs per = new L_Usercs();
        per.insertarContacto(correo,sugerencia);
        return "Contacto enviado!";
        
    }

    [WebMethod]
    public DataTable noticias()
    {
        L_persistencia per = new L_persistencia();
        L_Usercs user = new L_Usercs();
        DataTable dato = new DataTable();
        dato=user.ToDataTable( per.obtenerNoticia());
        return dato;

    }

    [WebMethod]
    public DataTable postMas()
    {
        L_persistencia per = new L_persistencia();
        L_Usercs user = new L_Usercs();
        DataView dato = new DataView();
        dato = user.postPuntuados();
        DataTable dat = dato.ToTable();
        return dat;

    }

}
