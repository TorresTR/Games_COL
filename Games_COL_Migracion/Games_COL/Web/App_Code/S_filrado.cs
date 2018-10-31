using Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Descripción breve de S_filrado
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class S_filrado : System.Web.Services.WebService
{

    public S_filrado()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        CKEditor.NET.CKEditorControlDesigner ck = new CKEditor.NET.CKEditorControlDesigner();

        return "";
    }
    [WebMethod]
    public DataTable etiquetas()
    {
        L_persistencia per = new L_persistencia();
        DataTable dato = per.obtenerEtiquetas();
        return dato;
    }
    [WebMethod]
    public DataTable post(int etiqueta)
    {
        L_persistencia per = new L_persistencia();
        L_Usercs user = new L_Usercs();
        DataTable data = new DataTable();
       
        switch (etiqueta)
        {
            case 2:
                {
                    data = user.ToDataTable( per.obtenerPostxbox());
                    break;
                }
            case 3:
                {
                    data =user.ToDataTable( per.obtenerPostpS());
                    break;
                }
            case 4:
                {
                    data = user.ToDataTable( per.obtenerPostAndroid());
                    break;
                }
            case 5:
                {
                    data =user.ToDataTable( per.obtenerPostpc());
                    break;
                }
            default:
                break;
        }
        return data;
    }

}
