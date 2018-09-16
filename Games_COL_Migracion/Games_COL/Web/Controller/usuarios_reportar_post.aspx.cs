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


public partial class View_usuarios_reportar_post : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        Int32 idioma = 1;
        Int32 id_pagina = 79;
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


        LB_titilo.Text = compIdioma["LB_titulo"].ToString();
        LB_motivo.Text = compIdioma["LB_motivo"].ToString();
        BT_volver.Text = compIdioma["BT_volver"].ToString();
        BT_enviarReporte.Text = compIdioma["BT_enviarReporte"].ToString();


        U_user doc = new U_user();
        L_Usercs dac = new L_Usercs();

        int c = int.Parse(Session["parametro"].ToString());
        int u = int.Parse(Session["user_id"].ToString());

        doc = dac.obtenerPostparareportar(c);

        LB_tituloReportar.Text = doc.Mensaje_Alertaobservador1;



    }

    protected void BT_enviarReporte_Click(object sender, EventArgs e)
    {


        U_Datosreporte reporte = new U_Datosreporte();
        L_Usercs envio = new L_Usercs();

        int b = int.Parse(Session["parametro"].ToString());
        DateTime dt = DateTime.Now;

        int u = int.Parse(Session["user_id"].ToString());


        DataTable regis = envio.obtenerPostObservador();

       
            reporte.Id_post_reportado = b;
            reporte.Contido_reporte = TB_reporte.Text.ToString();
            reporte.Fecha_reporte = dt;
            reporte.User_reportador = u;

        envio.insertarPostaReportar(reporte);

        envio.bloquear_Post(b);

        L_Usercs data = new L_Usercs();
        U_user dat = new U_user();

        dat = data.redirigirCompletousuarioregistrado();

        Response.Redirect(dat.Link_observador);
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {




        L_Usercs data = new L_Usercs();
        U_user dat = new U_user();

        dat = data.redirigirCompletousuarioregistrado();

        Response.Redirect(dat.Link_observador );
    }
}