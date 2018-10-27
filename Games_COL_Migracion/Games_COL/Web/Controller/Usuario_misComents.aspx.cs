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
        Int32 id_pagina = 71;
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



        LB_titAutor.Text = compIdioma["LB_titAutor"].ToString();
        LB_titContenido.Text = compIdioma["LB_titContenido"].ToString();
        BT_volver.Text = compIdioma["BT_volver"].ToString();


        U_userCrearpost doc = new U_userCrearpost();
        L_Usercs dac = new L_Usercs();
        ClientScriptManager cm = this.ClientScript;

        doc.Id = int.Parse(Session["parametro"].ToString());
        int dato = int.Parse(Session["parametro"].ToString());
        int dato2 = int.Parse(Session["id"].ToString());


       doc =  dac.eliminarMiscomentarios(doc);

        LB_muestraPag.Text = doc.Contenido1;
        LB_autor.Text = doc.Autor1;

        //dac.eliminarMiscomentariospuntos(doc);
        L_persistencia per = new L_persistencia();//agregar

        GV_comentariosuser.DataSource = per.obtenerComentUs(dato, dato2);

        
        GV_comentariosuser.DataBind();
    }

    protected void GV_Idioma_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            try
            {
                ((Label)e.Row.FindControl("LB_eliminar")).Text = ((Hashtable)Session["mensajes"])["LB_eliminar"].ToString();
                ((Label)e.Row.FindControl("LB_coment")).Text = ((Hashtable)Session["mensajes"])["LB_coment"].ToString();
            }
            catch (Exception exe)
            {

                ((Button)e.Row.FindControl("BT_eliminar")).Text  = ((Hashtable)Session["mensajes"])["BT_eliminar"].ToString();
            }
        }
        catch (Exception exx)
        {
        }

    }

    protected void BT_eliminar_Click(object sender, EventArgs e)
    {
        L_Usercs dac = new L_Usercs();
        L_persistencia log = new L_persistencia();
        Entity_comentarios coment = new Entity_comentarios();
        Button bt = (Button)sender;
        TableCell tableCell = (TableCell)bt.Parent;
        GridViewRow row = (GridViewRow)tableCell.Parent;
        GV_comentariosuser.SelectedIndex = row.RowIndex;
        int fila = row.RowIndex;
        coment.Id_comentario = int.Parse(((Label)row.Cells[fila].FindControl("Label1")).Text);
        int h = int.Parse(Session["parametro"].ToString());
        int b = int.Parse(Session["id"].ToString());
        int IdRecogido = int.Parse(((Label)row.Cells[fila].FindControl("Label1")).Text);

        Entity_usuario us = new Entity_usuario();
        object obj = new object();
        obj = log.obtenerComent(h);
        string schema = "usuario";
        string tabla = "comentarios";
        us.Nombre = Session["id"].ToString();
        log.auditoriaEliminar(obj,us,schema,tabla);

        log.borrarComentario(coment);
        //dac.dataEliminarcomentaction(IdRecogido);

        U_user data = new U_user();
        L_Usercs llamado = new L_Usercs();

        data = llamado.redireccionMiscoment();

        Response.Redirect(data.Link_observador );
        

    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {

        U_user data = new U_user();
        L_Usercs llamado = new L_Usercs();

        data = llamado.redireccionComentariot();

        Response.Redirect(data.Link_observador);
    }
}