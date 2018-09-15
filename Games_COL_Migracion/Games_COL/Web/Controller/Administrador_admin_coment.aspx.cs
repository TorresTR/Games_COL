﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Administrador_admin_coment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        Int32 idioma = 1;
        Int32 id_pagina = 2;
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


        LB_mensaje.Text = compIdioma["LB_mensaje"].ToString();
        DL_coment.DataBind();
        Bt_volver.Text = compIdioma["BT_volver"].ToString();

    }


    protected void DL_admin_coment_RowDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            try
            {
                ((Label)e.Item.FindControl("LB_titComentario")).Text = ((Hashtable)Session["mensajes"])["LB_titComentario"].ToString();
                ((Label)e.Item.FindControl("LB_titMotivo")).Text = ((Hashtable)Session["mensajes"])["LB_titMotivo"].ToString();
                ((Label)e.Item.FindControl("LB_titUser")).Text = ((Hashtable)Session["mensajes"])["LB_titUser"].ToString();
                ((Button)e.Item.FindControl("BT_bloquear")).Text = ((Hashtable)Session["mensajes"])["BT_bloquear"].ToString();
            }
            catch (Exception exe)
            {

                ((Button)e.Item.FindControl("BT_bloquear")).Text = ((Hashtable)Session["mensajes"])["BT_bloquear"].ToString();
            }
        }
        catch (Exception exx)
        {
        }

    }

    protected void BT_bloquear_Click(object sender, EventArgs e)
    {
        L_Usercs dato = new L_Usercs();
        ClientScriptManager cm = this.ClientScript;
        

        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");
        string ID = lblid.Text;
        int h = int.Parse(ID);

        dato.eliminarComent(h);
        LB_mensaje.Text = "Comentario Bloqueado";

        U_user dat = dato.administrarComentario();

        Response.Redirect(dat.Link_observador);
    }

    protected void Bt_volver_Click(object sender, EventArgs e)
    {
        
        L_Usercs dato = new L_Usercs();
        U_user dat = dato.retornoAdmin();

        Response.Redirect(dat.Link_observador);
    }
}