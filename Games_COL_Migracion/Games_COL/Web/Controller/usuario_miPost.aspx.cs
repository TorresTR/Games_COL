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


public partial class View_usuario_miPost : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        Int32 idioma = 1;
        Int32 id_pagina = 70;
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

        try
        {
           InfoR_usuario reporte = new InfoR_usuario();
            reporte = ObtenerInforme();
            CRS_reporte_usuario.ReportDocument.SetDataSource(reporte);
            CRV_reporteUsuario.ReportSource = CRS_reporte_usuario;
            
        }
        catch (Exception)
        {

            
        }
    }

    protected void GV_Idioma_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            try
            {
                ((Label)e.Row.FindControl("LB_editar")).Text = ((Hashtable)Session["mensajes"])["LB_editar"].ToString();
                ((Label)e.Row.FindControl("LB_eliminar")).Text = ((Hashtable)Session["mensajes"])["LB_eliminar"].ToString();
                ((Label)e.Row.FindControl("LB_tit")).Text = ((Hashtable)Session["mensajes"])["LB_tit"].ToString();
                ((Label)e.Row.FindControl("LB_eti")).Text = ((Hashtable)Session["mensajes"])["LB_eti"].ToString();
                ((Button)e.Row.FindControl("BT_editar")).Text = ((Hashtable)Session["mensajes"])["BT_editar"].ToString();
                ((Button)e.Row.FindControl("BT_eliminar")).Text = ((Hashtable)Session["mensajes"])["BT_eliminar"].ToString();

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

    protected InfoR_usuario ObtenerInforme()
    {
          //dr
        DataTable informacion = new DataTable(); //dt
        InfoR_usuario datos = new InfoR_usuario();

        int dato = int.Parse(Session["id"].ToString());

        informacion = datos.Tables["Post"];

        L_Usercs persona = new L_Usercs();

        persona.misPostCristal(informacion,dato);

        return datos;
    }


    protected void BT_editar_Click(object sender, EventArgs e)
    {

        Button bt = sender as Button;
        GridViewRow grid = (GridViewRow)bt.NamingContainer;
        string IdRecogido = ((Label)grid.FindControl("LB_id")).Text;
        Session["IdRecogido"] = IdRecogido;
         


        U_user data = new U_user();
        L_Usercs llamado = new L_Usercs();

        data = llamado.editarMispost();

        Response.Redirect(data.Link_observador);
    }

    protected void BT_eliminar_Click(object sender, EventArgs e)
    {
        Button bt = sender as Button;
        GridViewRow grid = (GridViewRow)bt.NamingContainer;
        string IdRecogido = ((Label)grid.FindControl("LB_id")).Text;
        L_Usercs dac = new L_Usercs();
        U_misPost dato = new U_misPost();
        Entity_post post = new Entity_post();
        L_persistencia log = new L_persistencia();



        int b = int.Parse(Session["id"].ToString());
       

        int x = int.Parse(IdRecogido);
        DataTable datos = dac.obtenerMiPost(x, b);

        post.Id = x;
        post.Contenido = datos.Rows[0]["contenido"].ToString();
        post.Autor = int.Parse(Session["id"].ToString());
        post.Titulo = datos.Rows[0]["titulo"].ToString();
        post.Fecha = DateTime.Parse(datos.Rows[0]["fecha"].ToString());
        post.Puntos = int.Parse(datos.Rows[0]["puntos"].ToString());
        post.Etiqueta = int.Parse(datos.Rows[0]["etiqueta"].ToString());
        post.Estado_bloqueo = int.Parse(datos.Rows[0]["estado_bloqueo"].ToString());
        post.Num_puntos = int.Parse(datos.Rows[0]["num_puntos"].ToString());

        Entity_usuario us = new Entity_usuario();
        object obj = new object();
        obj = post;
        string schema = "usuario";
        string tabla = "post";
        us.Nombre = Session["id"].ToString();
        log.auditoriaEliminar(obj, us, schema, tabla);

        log.borrarPost(post);
        //dac.eliminarMipost(dato);



        U_user data = new U_user();
        L_Usercs llamado = new L_Usercs();

        data = llamado.redireccionMispost();

        Response.Redirect(data.Link_observador);
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();


        dat = llamado.volverUsuariosRegistrado();

        int b = int.Parse(Session["id"].ToString());
        string data = b.ToString();



        Response.Redirect(dat.Link_observador);
    }
}