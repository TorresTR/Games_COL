﻿using Logica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;

public partial class View_Administrador_miPost : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        Int32 idioma = 1;
        Int32 id_pagina = 12;
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
        
        BT_volver.Text = compIdioma["BT_volve"].ToString();
        U_misPost mio = new U_misPost();
        L_Usercs dac = new L_Usercs();


        int dato = int.Parse(Session["id"].ToString());

        mio.Id_mipost = dato;
        try
        {
            L_persistencia log = new L_persistencia();//agregar
            DataTable data = dac.ToDataTable(log.obtenerMiPost(dato));//agregar
            GV_miPost.DataSource = data;//agregar
            GV_miPost.DataBind();
        }
        catch (Exception)
        {

        }
        
    }

    protected void GV_miPost_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            try
            {
                ((Label)e.Row.FindControl("LB_editar")).Text = ((Hashtable)Session["mensajes"])["LB_editar"].ToString();
                ((Label)e.Row.FindControl("LB_eliminar")).Text = ((Hashtable)Session["mensajes"])["LB_eliminar"].ToString();
                ((Label)e.Row.FindControl("LB_tit")).Text = ((Hashtable)Session["mensajes"])["LB_tit"].ToString();
                ((Label)e.Row.FindControl("LB_eti")).Text = ((Hashtable)Session["mensajes"])["LB_eti"].ToString();
            }
            catch (Exception exe)
            {

                ((Button)e.Row.FindControl("BT_editar")).Text = ((Hashtable)Session["mensajes"])["BT_editar"].ToString();
                ((Button)e.Row.FindControl("BT_eliminar")).Text = ((Hashtable)Session["mensajes"])["BT_eliminar"].ToString();
            }
        }
        catch (Exception exx)
        {
        }

    }

    protected void BT_editar_Click(object sender, EventArgs e)
    {
        Button bt = (Button)sender;
        TableCell tableCell = (TableCell)bt.Parent;
        GridViewRow row = (GridViewRow)tableCell.Parent;
        GV_miPost.SelectedIndex = row.RowIndex;
        int fila = row.RowIndex;




        int b = int.Parse(Session["id"].ToString());
        string IdRecogido = ((Label)row.Cells[fila].FindControl("LB_id")).Text;
        Session["IdRecogido"] = IdRecogido;
        string dat = b.ToString();


        U_user data = new U_user();
        L_Usercs llamado = new L_Usercs();

        data = llamado.AdminEditarMispost();

        Response.Redirect(data.Link_observador );

    }

    protected void BT_eliminar_Click(object sender, EventArgs e)
    {
        Button bt = (Button)sender;
        TableCell tableCell = (TableCell)bt.Parent;
        GridViewRow row = (GridViewRow)tableCell.Parent;
        GV_miPost.SelectedIndex = row.RowIndex;
        int fila = row.RowIndex;
        Entity_post post = new Entity_post();

        L_persistencia log = new L_persistencia();
        int b = int.Parse(Session["id"].ToString());
        //int a = int.Parse(Session["IdRecogido"].ToString());
        int user = int.Parse(Session["id"].ToString());
        string IdRecogido = ((Label)row.Cells[fila].FindControl("LB_id")).Text;
        Session["IdRecogido"] = IdRecogido;
        int x = int.Parse(IdRecogido);

        L_Usercs dac = new L_Usercs();
        U_misPost dato = new U_misPost();

        DataTable datos = dac.ToDataTable(log.obtenerMipostmio(x, user));


        //post.Id = int.Parse(Session["IdRecogido"].ToString());
        post.Contenido = datos.Rows[0]["contenido"].ToString();
        post.Autor = int.Parse(Session["id"].ToString());
        post.Titulo = datos.Rows[0]["titulo"].ToString();
        post.Fecha = DateTime.Parse(datos.Rows[0]["fecha"].ToString());
        post.Puntos = int.Parse(datos.Rows[0]["puntos"].ToString());
        post.Etiqueta = int.Parse(datos.Rows[0]["etiqueta"].ToString());
        post.Estado_bloqueo = int.Parse(datos.Rows[0]["estado_bloqueo"].ToString());
        post.Num_puntos = int.Parse(datos.Rows[0]["num_puntos"].ToString());

        dato.Id_mipost = x;

        L_persistencia per = new L_persistencia();
        Entity_usuario us = new Entity_usuario();
        object obj = new object();
        obj = post;
        string schema = "usuario";
        string tabla = "post";
        us.Nombre = Session["id"].ToString();
        per.auditoriaEliminar(obj, us, schema, tabla);

        dac.eliminarMipost(dato);



        U_user data = new U_user();
        L_Usercs llamado = new L_Usercs();

        data = llamado.AdminMispost();

        Response.Redirect(data.Link_observador);
        
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();


        dat = llamado.retornoAdmin();

        Response.Redirect(dat.Link_observador);
    }
}