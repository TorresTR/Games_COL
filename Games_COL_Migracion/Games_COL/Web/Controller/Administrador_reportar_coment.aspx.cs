﻿using Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;

public partial class View_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();


        ClientScriptManager cm = this.ClientScript;
        U_comentarios doc = new U_comentarios();
        L_Usercs dac = new L_Usercs();

        int c = int.Parse(Session["IdRecogido"].ToString());
        int u = int.Parse(Session["user_id"].ToString());

        doc = dac.ObtenerComentarioreportar(c);


        LB_Id_comentario.Text = doc.Coment;
    }

    protected void BT_reportar_Click(object sender, EventArgs e)
    {
       

        ClientScriptManager cm = this.ClientScript;
        U_comentarios reporte = new U_comentarios();
        L_Usercs envio = new L_Usercs();

        int b = int.Parse(Session["IdRecogido"].ToString());
        int p = int.Parse(Session["parametro"].ToString());
        DateTime dt = DateTime.Now;

        int u = int.Parse(Session["user_id"].ToString());


        DataTable regis = envio.obtenerComentario1(b);


        reporte.Id_com_reportado1 = b;
        reporte.Contenido1 = TB_motivoR.Text.ToString();
        reporte.Fecha = dt;
        reporte.Id_user = u;

        envio.insertarComentarioReportado(reporte);

        string ID = Session["parametro"].ToString();
        string z = Session["user_id"].ToString();

       
        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();

        dat = llamado.redirigirCompletoAdmin();

        Response.Redirect(dat.Link_observador);

    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
       
       

        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();

        dat = llamado.retornoAdmin();

        Response.Redirect(dat.Link_observador );
    }
}