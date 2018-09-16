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

public partial class View_usuario_verRespuestas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        Int32 idioma = 1;
        Int32 id_pagina = 73;
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


        L_Usercs dac = new L_Usercs();
        U_respuestasPqr doc = new U_respuestasPqr();

        int dato = int.Parse(Session["IdRecogido"].ToString());

             doc   =   dac.misRespuestaspqr(dato);

        LB_verRespuesta.Text = doc.Respuesta;
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {


        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();

        dat = llamado.volverUsuariosRegistrado();

        Response.Redirect(dat.Link_observador );
    }
}