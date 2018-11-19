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


public partial class View_Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        
        Response.Cache.SetNoStore();
        Int32 idioma = 1;
        Int32 id_pagina = 29;
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

        
        Bt_volver.Text = compIdioma["BT_volver"].ToString();
        DL_coment.DataBind();
    }

    protected void DL_coment_RowDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            try
            {
                ((Label)e.Item.FindControl("LB_titMotivo")).Text = ((Hashtable)Session["mensajes"])["LB_titMotivo"].ToString();
                ((Label)e.Item.FindControl("LB_titComent")).Text = ((Hashtable)Session["mensajes"])["LB_titComentario"].ToString();
                ((Label)e.Item.FindControl("LB_titUsuario")).Text = ((Hashtable)Session["mensajes"])["LB_titUser"].ToString();
                ((Button)e.Item.FindControl("BT_bloquear")).Text = ((Hashtable)Session["mensajes"])["BT_bloquear"].ToString();


            }
            catch (Exception exe)
            {

                ((Label)e.Item.FindControl("LB_titMotivo")).Text = ((Hashtable)Session["mensajes"])["LB_titMotivo"].ToString();
                ((Label)e.Item.FindControl("LB_titComent")).Text = ((Hashtable)Session["mensajes"])["LB_titComentario"].ToString();
                ((Label)e.Item.FindControl("LB_titUsuario")).Text = ((Hashtable)Session["mensajes"])["LB_titUser"].ToString();
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
        Entity_comentarios coment = new Entity_comentarios();
        Entity_comentarios coment1 = new Entity_comentarios();
        L_persistencia logica = new L_persistencia();


        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");
        string ID = lblid.Text;
        Session["IdRecogido"] = ID;
        int b = int.Parse(Session["id"].ToString());
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

        dato.eliminarComent(h);


        U_user data = new U_user();
        L_Usercs llamado = new L_Usercs();

        data = llamado.moderadoradmincoment();
        Response.Redirect(data.Link_observador);
        
    }

    protected void Bt_volver_Click(object sender, EventArgs e)
    {

        int t = int.Parse(Session["id"].ToString());

        string dat = t.ToString();



        U_user data = new U_user();
        L_Usercs llamado = new L_Usercs();

        data = llamado.irHomeModerador();
        Response.Redirect(data.Link_observador);
    }
}