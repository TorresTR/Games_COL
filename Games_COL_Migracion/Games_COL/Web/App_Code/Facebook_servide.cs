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
        //string se = Session["id_facebook"].ToString();
    }

}
