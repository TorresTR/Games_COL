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

public partial class View_registro : System.Web.UI.Page
{
    
    U_Datos datos = new U_Datos();
    L_Usercs dat = new L_Usercs();
    

    

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        Int32 idioma = 1;
        Int32 id_pagina = 57;
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


        LB_titReg.Text = compIdioma["LB_titReg"].ToString();
        LB_nombre.Text = compIdioma["LB_nombre"].ToString();
        LB_nick.Text = compIdioma["LB_nick"].ToString();
        LB_correo.Text = compIdioma["LB_correo"].ToString();
        LB_contra.Text = compIdioma["LB_contra"].ToString();
        LB_confirma.Text = compIdioma["LB_confirma"].ToString();
        B_registrar.Text = compIdioma["B_registrar"].ToString();
        B_volver.Text = compIdioma["B_volver"].ToString();


        try
        {
            if (Session["band"].Equals(true))
            {
                TB_nombre.Text = Session["user_name"].ToString();
                TB_email.Text = Session["correo"].ToString();

            }
           
        }
        catch (Exception)
        {

           
        }
       
        



    }

    protected void B_registrar_Click(object sender, EventArgs e)
    {
        Entity_usuario dato = new Entity_usuario();
        L_persistencia log = new L_persistencia();
        ClientScriptManager cm = this.ClientScript;
        try
        {
            if (Session["band"].Equals(true))
            {
                dato.Nombre = Session["user_name"].ToString();
                dato.Correo = Session["correo"].ToString();
                Session["band"] = false;
            }
            else
            {
                dato.Nombre = TB_nombre.Text.ToString();
                dato.Correo = TB_email.Text.ToString();
            }
        }
        catch (Exception)
        {

            dato.Nombre = TB_nombre.Text.ToString();
            dato.Correo = TB_email.Text.ToString();
        }
       
        dato.Nick = TB_nick.Text.ToString();
        dato.Contra = TB_pass.Text.ToString();
        string Confirma = TB_confirmapass.Text.ToString();
        dato.Puntos = 0;
        dato.Id_rol = 1;
        dato.Id_rango = 1;
        dato.Estado = 1;
        dato.Fecha_interaccion = DateTime.Now;
        dato.Puntos = 1;
        dato.Estado = 1;
        dato.Session = "prueba";

        Session["band"] = false;
        Entity_usuario us = new Entity_usuario();
        us.Nombre = TB_nombre.Text.ToString();
        object segurity = new object();
        segurity = dato;
        string schema = "usuario";
        string tabla = "usuario";
        log.auditoriaInsertar(segurity, us, schema, tabla);

        log.insertarUsuario(dato);


        //datos = dat.insertarUsuarionuevo(datos);
        int id = dat.consultaUsuario(dato.Nick);
        //dat.insertarSesion(id);
        cm.RegisterClientScriptBlock(this.GetType(), "", datos.Mensaje1);
        //LB_mensaje.Text = datos.Mensaje1.ToString();
        Session["band2"] = true;
        Response.Redirect("Ingresar.aspx");
        
    }


    protected void B_volver_Click(object sender, EventArgs e)
    {

        U_user inicio = new U_user();
        L_Usercs llamado = new L_Usercs();

        inicio = llamado.irInicio();
        Response.Redirect(inicio.Link_demas);
        Session["band"] = false;
    }
}