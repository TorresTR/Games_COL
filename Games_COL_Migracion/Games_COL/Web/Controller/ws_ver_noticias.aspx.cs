using Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;

public partial class View_ws_ver_noticias : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();


        U_userCrearpost doc = new U_userCrearpost();
        L_Usercs dac = new L_Usercs();

        doc.Id = int.Parse(Request.Params["parametro"]);
        int dato = int.Parse(Request.Params["parametro"]);
        doc = dac.postObservadorNoticias(doc);

        
        LB_verPost.Text = doc.Contenido1.ToString();
        LB_autor.Text = doc.Autor1.ToString();





    }


}