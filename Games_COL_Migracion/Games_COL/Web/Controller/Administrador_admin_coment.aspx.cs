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

public partial class View_Administrador_admin_coment : System.Web.UI.Page
{
    string mensaje;
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


        mensaje = compIdioma["LB_mensaje"].ToString();
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
        Entity_comentarios coment = new Entity_comentarios();
        Entity_comentarios coment1 = new Entity_comentarios();
        L_persistencia logica = new L_persistencia();

        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");
        string ID = lblid.Text;
        int h = int.Parse(ID);

        DataTable com = dato.ToDataTable(logica.obtenerComentarioesp(h));

        coment1.Id_comentario = h;
        coment1.Comentario = com.Rows[0]["comentario"].ToString();
        coment1.Id_post = int.Parse(com.Rows[0]["id_post"].ToString());
        coment1.Id_user = int.Parse(com.Rows[0]["id_user"].ToString());
        coment1.Estado = int.Parse(com.Rows[0]["estado"].ToString()); ;


        coment.Id_comentario = h;
        coment.Comentario = com.Rows[0]["comentario"].ToString();
        coment.Id_post = int.Parse(com.Rows[0]["id_post"].ToString());
        coment.Id_user = int.Parse(com.Rows[0]["id_user"].ToString());
        coment.Estado = 3;

        object objOld = new object();
        objOld = coment1;
        object objNew = new object();
        objNew = coment;
        string schema = "usuario";
        string tabla = "comentarios";
        Entity_usuario us = new Entity_usuario();
        us.Nombre = Session["id"].ToString();
        logica.auditoriaModificar(objNew, objOld, us, schema, tabla);

        logica.actualizarComentario(coment);


        object obj = new object();
        obj = com;
        us.Nombre = Session["id"].ToString();
        string table = "reporte_comentarios";
        logica.auditoriaEliminar(obj, us, schema, table);

        dato.eliminarComent(h);
        Response.Write("<Script Language='JavaScript'>parent.alert('"+mensaje+"');</Script>");

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