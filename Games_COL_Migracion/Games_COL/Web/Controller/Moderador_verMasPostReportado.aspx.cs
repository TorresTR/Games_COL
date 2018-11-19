using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Moderador_verMasPostReportado : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        Int32 idioma = 1;
        Int32 id_pagina = 47;
        try
        {
            idioma = Int32.Parse(Session["valor_ddl"].ToString());
        }
        catch
        {
            idioma = 1;
        }

        L_Usercs Idio = new L_Usercs();
        DataTable info = Idio.traducir(id_pagina, idioma);

        Hashtable compIdioma = new Hashtable();
        Session["mensajes"] = compIdioma;
        compIdioma = Idio.hastableIdioma(info, compIdioma);


        BT_volver.Text = compIdioma["BT_volver"].ToString();

        U_userCrearpost doc = new U_userCrearpost();
        L_Usercs dac = new L_Usercs();


        doc.Id = int.Parse(Session["IdRecogido"].ToString());
        int x = int.Parse(Session["IdRecogido"].ToString());

        doc=dac.obtenerPostObservadorreportadomoder(doc);


        LB_contenido.Text = doc.Contenido1.ToString();
        LB_mostrarAutor.Text = doc.Autor1.ToString();

       
    }





    protected void BT_volver_Click(object sender, EventArgs e)
    {

        int t = int.Parse(Session["id"].ToString());

        string dat = t.ToString();


        U_user data = new U_user();
        L_Usercs llamado = new L_Usercs();

        data = llamado.recargarationpost();
        Response.Redirect(data.Link_observador);
       
    }
}