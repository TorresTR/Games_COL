using Logica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Persistencia_funciones;

public partial class View_Administrador_atencion_bloquer_post : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Cache.SetNoStore();


        Int32 idioma = 1;
        Int32 id_pagina = 4;
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

        
        DL_postBloqueado.DataBind();
        BT_volver.Text = compIdioma["BT_volver"].ToString();

    }


    protected void DL_postBloqueado_RowDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            try
            {
                ((Label)e.Item.FindControl("LB_titulo")).Text = ((Hashtable)Session["mensajes"])["LB_titulo"].ToString();
                ((Label)e.Item.FindControl("LB_contenido")).Text = ((Hashtable)Session["mensajes"])["LB_contenido"].ToString();
                ((Label)e.Item.FindControl("LB_userRepo")).Text = ((Hashtable)Session["mensajes"])["LB_userRepo"].ToString();
                ((Button)e.Item.FindControl("BT_vermas")).Text = ((Hashtable)Session["mensajes"])["BT_vermas\t"].ToString();
                ((Button)e.Item.FindControl("BT_bloquear")).Text = ((Hashtable)Session["mensajes"])["BT_bloquear\t"].ToString();
            }
            catch (Exception exe)
            {

                ((Button)e.Item.FindControl("BT_vermas")).Text = ((Hashtable)Session["mensajes"])["BT_vermas\t"].ToString();
                ((Button)e.Item.FindControl("BT_bloquear")).Text = ((Hashtable)Session["mensajes"])["BT_bloquear\t"].ToString();
            }
        }
        catch (Exception exx)
        {
        }

    }

    protected void BT_vermas_Click(object sender, EventArgs e)
    {
      

        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_idPost");
        string ID = lblid.Text;

        Session["parametro"] = ID;
        int b = int.Parse(Session["parametro"].ToString());

        string dat = b.ToString();
        

        U_user data = new U_user();
        L_Usercs llamado = new L_Usercs();

        data = llamado.verPostRepor();
        Response.Redirect(data.Link_observador);

        
    }

    protected void BT_bloquear_Click(object sender, EventArgs e)
    {

        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_idPost");
        string ID = lblid.Text;

        L_persistencia per = new L_persistencia();
        actualizar_estado_bloqueo est = new actualizar_estado_bloqueo();
        Entity_post pot = new Entity_post();
        L_Usercs log = new L_Usercs();

        DataTable post = log.obtenerpostReportEsp(int.Parse(ID));

        est.Id_reporte = int.Parse(post.Rows[0]["id_reporte"].ToString());
        est.Contenido_reporte = post.Rows[0]["contenido_reporte"].ToString();
        est.Estado_resuelto = int.Parse(post.Rows[0]["estado_resuelto"].ToString());
        est.Fecha_reporte = DateTime.Parse(post.Rows[0]["fecha_reporte"].ToString());
        est.User_reportador = int.Parse(post.Rows[0]["user_reportador"].ToString());

        int b = int.Parse(Session["id"].ToString());
        int x = 2;
        int h = int.Parse(ID);
        int z = 1;

        est.Id_post_reportador = int.Parse(ID);
        pot.Id = int.Parse(ID);
        L_Usercs dac = new L_Usercs();

        //dac.actualizarmoderPostreportado(h, b, x,z);

        Entity_usuario us = new Entity_usuario();
        object obj = new object();
        obj = est;
        string schema = "usuario";
        string tabla = "post";
        us.Nombre = Session["id"].ToString();
        per.auditoriaEliminar(obj, us, schema, tabla);

        per.borrarActualizar(est);

        per.borrarPost(pot);


        U_user dat = dac.atencionBloquearPost();

        Response.Redirect(dat.Link_observador);
    }

    protected void Bt_volver_Click(object sender, EventArgs e)
    {

        L_Usercs dac = new L_Usercs();
        U_user dat = dac.retornoAdmin();

        Response.Redirect(dat.Link_observador );

    }
}