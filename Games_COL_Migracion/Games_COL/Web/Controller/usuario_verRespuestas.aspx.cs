﻿using System;
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