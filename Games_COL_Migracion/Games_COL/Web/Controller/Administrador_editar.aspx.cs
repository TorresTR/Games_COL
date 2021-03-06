﻿using Logica;
using Utilitarios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class View_Adminsitrador_editar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();


        Int32 idioma = 1;
        Int32 id_pagina = 6;
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


        
        Bt_editarCk.Text = compIdioma["Bt_editarCk"].ToString(); 
        BT_editar.Text = compIdioma["BT_editar"].ToString();
        BT_volver.Text = compIdioma["BT_volver"].ToString();
        LB_autor.Text= compIdioma["LB_autor"].ToString();

        L_Usercs dac = new L_Usercs();
        U_misPost dato = new U_misPost();

        int a = int.Parse(Session["IdRecogido"].ToString());


        dato.Id_mipost = a;

        dato = dac.VerMisdatosaeditar(dato);

        LB_muestraContenido.Text = dato.Contenido;
        LB_verAutor.Text = dato.Autor;
        Ck_editar.Visible = dato.EstadoCK;
        BT_editar.Visible = dato.EstadoBT;
    }

    protected void BT_editar_Click(object sender, EventArgs e)
    {


        L_Usercs dac = new L_Usercs();
        Entity_post post = new Entity_post();
        //U_userCrearpost post = new U_userCrearpost();
        int a = int.Parse(Session["IdRecogido"].ToString());
        int user = int.Parse(Session["id"].ToString());
        L_persistencia log = new L_persistencia();

        DataTable dato = dac.ToDataTable(log.obtenerMipostmio(a, user));


        post.Id = int.Parse(Session["IdRecogido"].ToString());
        post.Contenido = Ck_editar.Text.ToString();
        post.Autor = int.Parse(Session["id"].ToString());
        post.Titulo = dato.Rows[0]["titulo"].ToString();
        post.Fecha = DateTime.Parse(dato.Rows[0]["fecha"].ToString());
        post.Puntos = int.Parse(dato.Rows[0]["puntos"].ToString());
        post.Etiqueta = int.Parse(dato.Rows[0]["etiqueta"].ToString());
        post.Estado_bloqueo = int.Parse(dato.Rows[0]["estado_bloqueo"].ToString());
        post.Num_puntos = int.Parse(dato.Rows[0]["num_puntos"].ToString());

        Entity_post post1 = new Entity_post();
        post1.Id = int.Parse(dato.Rows[0]["id"].ToString());
        post1.Contenido = dato.Rows[0]["contenido"].ToString();
        post1.Autor = int.Parse(dato.Rows[0]["autor"].ToString());
        post1.Titulo = dato.Rows[0]["titulo"].ToString();
        post1.Fecha = DateTime.Parse( dato.Rows[0]["fecha"].ToString());
        post1.Puntos = int.Parse(dato.Rows[0]["puntos"].ToString());
        post1.Etiqueta = int.Parse(dato.Rows[0]["etiqueta"].ToString());
        post1.Estado_bloqueo = int.Parse(dato.Rows[0]["estado_bloqueo"].ToString());
        post1.Num_puntos = int.Parse(dato.Rows[0]["num_puntos"].ToString());

        object objOld = new object();
        objOld = post1;
        object objNew = new object();
        objNew = post;
        string schema = "usuario";
        string tabla = "post";
        Entity_usuario us = new Entity_usuario();
        us.Nombre = Session["id"].ToString();
        log.auditoriaModificar(objNew,objOld,us,schema,tabla);


        log.actualizarPost(post);
        //dac.actualizarMispost(post);
    }

    protected void Bt_editarCk_Click(object sender, EventArgs e)
    {
        Ck_editar.Text = LB_muestraContenido.Text;
        Ck_editar.Visible = true;
        BT_editar.Visible = true;
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {


        U_user data = new U_user();
        L_Usercs llamado = new L_Usercs();

        data = llamado.administrarMiPost();


        Response.Redirect(data.Link_observador );
    }
}