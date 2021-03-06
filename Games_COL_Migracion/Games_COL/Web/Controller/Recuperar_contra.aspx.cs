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
using Persistencia_funciones;


public partial class View_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        L_Usercs log = new L_Usercs();
        int cont = Request.QueryString.Count;
        string var = Request.QueryString[0];

        U_token inicio = log.validaToken(cont,var);

        LB_mensaje.Text = inicio.Nombre;
        Session["id"] = inicio.Id;
        Int32 idioma = 1;
        Int32 id_pagina = 56;
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

        try
        {

            LB_titulo.Text = compIdioma["LB_titulo"].ToString();
            L_digite_nueva.Text = compIdioma["L_digite_nueva"].ToString();
            L_Repita_Contraseña.Text = compIdioma["L_Repita_Contraseña"].ToString();
            LB_mensaje.Text = compIdioma["LB_mensaje"].ToString();
            BT_cambiar_contraseña.Text = compIdioma["BT_cambiar_contraseña"].ToString();

        }
        catch {
        }




    }

    protected void BT_cambiar_contraseña_Click(object sender, EventArgs e)
    {

        L_persistencia per = new L_persistencia();
        Entity_token_recuperacion_user token = new Entity_token_recuperacion_user();
        Entity_usuario user_ent = new Entity_usuario();
        Entity_usuario user_ent1 = new Entity_usuario();

        L_Usercs user = new L_Usercs();
        U_Datos eUser = new U_Datos();


        int Id = int.Parse(Session["id"].ToString());
        eUser.Pass = TB_digite_nueva_contraseña.Text;

        token.Id_usuario = int.Parse(Session["id"].ToString());

        Entity_usuario us = new Entity_usuario();
        object obj = new object();
        obj = token;
        string schema = "usuario";
        string tabla = "token_recuperacon_user";
        us.Nombre = Session["id"].ToString();
        per.auditoriaEliminar(obj, us, schema, tabla);

        per.borrarRecuperarcontra(token);
        //user.contraseña(eUser);

        DataTable data = user.obtenerUsuario(Id);

        user_ent.Id = int.Parse(data.Rows[0]["id"].ToString());
        user_ent.Nombre = data.Rows[0]["nombre"].ToString();
        user_ent.Nick = data.Rows[0]["nick"].ToString();
        user_ent.Correo = data.Rows[0]["correo"].ToString();
        user_ent.Contra = TB_digite_nueva_contraseña.Text;
        user_ent.Puntos = int.Parse(data.Rows[0]["puntos"].ToString());
        user_ent.Id_rol = int.Parse(data.Rows[0]["id_rol"].ToString());
        user_ent.Id_rango = int.Parse(data.Rows[0]["id_rango"].ToString());
        user_ent.Estado = 1;
        user_ent.Session= data.Rows[0]["session"].ToString();
        user_ent.Interacciones = int.Parse(data.Rows[0]["interacciones"].ToString());
        user_ent.Fecha_interaccion = DateTime.Parse(data.Rows[0]["fecha_interaccion"].ToString());

        user_ent1.Id = int.Parse(data.Rows[0]["id"].ToString());
        user_ent1.Nombre = data.Rows[0]["nombre"].ToString();
        user_ent1.Nick = data.Rows[0]["nick"].ToString();
        user_ent1.Correo = data.Rows[0]["correo"].ToString();
        user_ent1.Contra = TB_digite_nueva_contraseña.Text;
        user_ent1.Puntos = int.Parse(data.Rows[0]["puntos"].ToString());
        user_ent1.Id_rol = int.Parse(data.Rows[0]["id_rol"].ToString());
        user_ent1.Id_rango = int.Parse(data.Rows[0]["id_rango"].ToString());
        user_ent1.Estado = int.Parse(data.Rows[0]["estado"].ToString());
        user_ent1.Session = data.Rows[0]["session"].ToString();
        user_ent1.Interacciones = int.Parse(data.Rows[0]["interacciones"].ToString());
        user_ent1.Fecha_interaccion = DateTime.Parse(data.Rows[0]["fecha_interaccion"].ToString());

        object objOld = new object();
        objOld = user_ent1;
        object objNew = new object();
        objNew = user_ent;
        string table = "usuario";
        us.Nombre = Session["id"].ToString();
        per.auditoriaModificar(objNew, objOld, us, schema, table);

        per.actualizarUsuario(user_ent);
        Response.Write("<Script Language='JavaScript'>parent.alert('Su Contraseña ha sido actualizada');</Script>");
        //LB_mensaje.Text = "Su Contraseña ha sido actualizada";
        
    }
}