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

public partial class View_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Int32 idioma = 1;
        Int32 id_pagina = 21;
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
        
    }

    protected void DL_solicitudes_RowDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            try
            {
                ((Label)e.Item.FindControl("LB_titUsuario")).Text = ((Hashtable)Session["mensajes"])["LB_titUsuario"].ToString();
                ((Label)e.Item.FindControl("LB_titulo")).Text = ((Hashtable)Session["mensajes"])["LB_titulo"].ToString();
                ((Label)e.Item.FindControl("LB_titPuntos")).Text = ((Hashtable)Session["mensajes"])["LB_titPuntos"].ToString();
                ((Label)e.Item.FindControl("LB_titNick")).Text = ((Hashtable)Session["mensajes"])["LB_titNick"].ToString();
                ((Button)e.Item.FindControl("BT_ascender")).Text = ((Hashtable)Session["mensajes"])["BT_ascender"].ToString();
                ((Button)e.Item.FindControl("BT_ignorar")).Text = ((Hashtable)Session["mensajes"])["BT_ignorar"].ToString();

            }
            catch (Exception exe)
            {

                
            }
        }
        catch (Exception exx)
        {
        }

    }

    protected void BT_ascender_Click(object sender, EventArgs e)
    {
 
        L_Usercs dato = new L_Usercs();
        U_user user = new U_user();
        ClientScriptManager cm = this.ClientScript;

        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");
        string ID = lblid.Text;

        int b = int.Parse(Session["id"].ToString());
        int h = int.Parse(ID);

        dato.Ascenso(h);
        cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Usuario Ascendido');</script>");
        user = dato.retornoAdmin();

        Response.Redirect(user.Link_observador);
        
    }

    protected void BT_ignorar_Click(object sender, EventArgs e)
    {

        L_Usercs dato = new L_Usercs();
        U_user user = new U_user();
        L_persistencia per = new L_persistencia();
        Entity_solicitud sol = new Entity_solicitud();

        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");
        string ID = lblid.Text;
        int b = int.Parse(Session["id"].ToString());
        int h = int.Parse(ID);

        sol.Id = int.Parse(ID);

        Entity_usuario us = new Entity_usuario();
        object obj = new object();
        obj = sol;
        string schema = "usuario";
        string tabla = "solicitud";
        us.Nombre = Session["id"].ToString();
        per.auditoriaEliminar(obj, us, schema, tabla);
        per.borrarSolicitud(sol);
        //dato.ignorarAscenso(h);
        
        user = dato.retornoAdmin();

        Response.Redirect(user.Link_observador);
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {

        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();

        dat = llamado.retornoAdmin();

        Response.Redirect(dat.Link_observador);
    }
}