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

public partial class View_usuarios_pqr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Cache.SetNoStore();

        Int32 idioma = 1;
        Int32 id_pagina = 78;
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


        B_volver.Text = compIdioma["B_volver"].ToString();
        LB_solicitud.Text = compIdioma["LB_solicitud"].ToString();
        BT_envio.Text = compIdioma["BT_envio"].ToString();
        LB_solicitud.Text = compIdioma["LB_solicitud"].ToString();
        LB_tipoSolicitud.Text = compIdioma["LB_tipoSolicitud"].ToString();

    }

    protected void BT_envio_Click(object sender, EventArgs e)
    {


        U_Datospqr pqr = new U_Datospqr();
        L_Usercs dao = new L_Usercs();
        L_persistencia log = new L_persistencia();
        Entity_pqr ent = new Entity_pqr();

        int b = int.Parse(Session["user_id"].ToString());

        DateTime dt = DateTime.Now;

        pqr.Asunto = TB_asunto.Text.ToString();
        pqr.Id_pqrestado = int.Parse(DDL_tipoSolicitud.SelectedValue.ToString());
        pqr.Contenido = TB_solicitud.Text.ToString();
        pqr.Fecha = dt;
        pqr.Id_user = b;

        ent.Usuario = b;
        ent.Solicitud = int.Parse(DDL_tipoSolicitud.SelectedValue.ToString());
        ent.Contenido = TB_solicitud.Text.ToString();
        ent.Asunto = TB_asunto.Text.ToString();
        ent.Fecha = dt;
        ent.Respuesta = "";
        ent.Id_contestador = 0;
        ent.Fecha_respuesta = DateTime.Parse("1990-01-01" );
        ent.Estado_respuesta = 0;

        log.insertarPQR(ent);

       // dao.insertarPqr(pqr);

        U_user retorno = new U_user();
        L_Usercs llamado = new L_Usercs();

        retorno = llamado.retornoUsuario();
        Response.Redirect(retorno.Link_observador);
        

    }

    protected void B_volver_Click(object sender, EventArgs e)
    {


        U_user retorno = new U_user();
        L_Usercs llamado = new L_Usercs();

        retorno = llamado.retornoUsuario();
        Response.Redirect(retorno.Link_observador );

    }
}