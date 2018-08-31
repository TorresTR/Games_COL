﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;
public partial class View_Moderador_editar_Noticia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Cache.SetNoStore();
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        U_userCrearpost doc = new U_userCrearpost();
        L_Usercs dac = new L_Usercs();


        doc.Id = int.Parse(obQueryString["parametro"].ToString());
        int x = int.Parse(obQueryString["userid"].ToString());

        doc = dac.postObservadorNoticias(doc);


        LB_muestraContenido.Text = doc.Contenido1.ToString();
        LB_verAutor.Text = doc.Autor1.ToString();
        Ck_editar.Visible = false;
        BT_editar.Visible = false;
        

    }

    protected void BT_editar_Click(object sender, EventArgs e)
    {
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        L_Usercs dac = new L_Usercs();
        U_userCrearpost post = new U_userCrearpost();

        post.Id = int.Parse(obQueryString["parametro"].ToString());
        post.Contenido1 = Ck_editar.Text.ToString();

        dac.actualizaModernoticia(post);

    }

    protected void Bt_editarCk_Click(object sender, EventArgs e)
    {
        Ck_editar.Text = LB_muestraContenido.Text;
        Ck_editar.Visible = true;
        BT_editar.Visible = true;
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        dat = llamado.recargapgnotimoder();

        Response.Redirect(dat.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());
    }
}