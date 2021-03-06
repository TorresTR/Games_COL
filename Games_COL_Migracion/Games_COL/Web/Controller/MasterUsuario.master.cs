﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Utilitarios;
using Logica;
using System.Collections;
using Persistencia_funciones;

public partial class View_MasterUsuario : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        Int32 idioma = 1;
        Int32 id_pagina = 63;
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


        BT_inicio.Text = compIdioma["BT_inicio"].ToString();
        BT_crearPost.Text = compIdioma["BT_crearPost"].ToString();
        BT_PQR.Text = compIdioma["BT_PQR"].ToString();
        B_solicitud.Text = compIdioma["B_solicitud"].ToString();
        BT_misPost.Text = compIdioma["BT_misPost"].ToString();
        BT_comentarios.Text = compIdioma["BT_comentarios"].ToString();
        BT_respuestas.Text = compIdioma["BT_respuestas"].ToString();
        BT_verinfo.Text = compIdioma["BT_verinfo"].ToString();
        LB_nick.Text = compIdioma["LB_nick"].ToString();
        LB_puntos.Text = compIdioma["LB_puntos"].ToString();
        LB_rango.Text = compIdioma["LB_rango"].ToString();
        string mensaje = compIdioma["LB_mensaje"].ToString();
        BT_cerrar.Text = compIdioma["BT_cerrar"].ToString();
        Session["nick"]= LB_nickMuestra.Text;


        D_User us = new D_User();
        L_Usercs log = new L_Usercs();
        U_Datos dato = new U_Datos();

        try
        {
            dato.Sesion = Session["id"].ToString();
            dato = log.validarCerrarsesion(dato);
            dato.Sesion = Session["id"].ToString();
        }
        catch (Exception) {

            dato = log.validarCerrarsesion(dato);
            Response.Redirect(dato.Link);
        }
        
        int b = int.Parse(Session["id"].ToString());


        L_persistencia per = new L_persistencia();

        DataTable data = log.ToDataTable(per.obtenerCarga(b));
        mensaje = log.ActualizarRango(data, b, mensaje);
        DataTable dat = log.ToDataTable(per.obtenerCarga(b));
        dato = log.cargaDatos(dat, b);

        LB_nickMuestra.Text = dato.Nick;
        LB_muestraPuntos.Text = dato.Puntos.ToString();
        LB_muestraRango.Text = dato.Mensaje1;
        LB_muestraID.Text = dato.Id.ToString();
        LB_mensaje.Text = mensaje;

    }

    protected void BT_crear_port_Click(object sender, EventArgs e)
    {
 
        
        Response.Redirect("Crear_post.aspx");
    }

    protected void BT_PQR_Click(object sender, EventArgs e)
    {
        
        Response.Redirect("usuarios_pqr.aspx");
    }

    protected void B_solicitud_Click(object sender, EventArgs e)
    {

       
        Response.Redirect("solicitud_moderador.aspx");
    }

    protected void BT_inicio_Click(object sender, EventArgs e)
    {
        
        Response.Redirect("usuarios.aspx");
    }

    protected void BT_misPost_Click(object sender, EventArgs e)
    {
        
        Response.Redirect("usuario_miPost.aspx");
    }

    protected void BT_comentarios_Click(object sender, EventArgs e)
    {
        
        Response.Redirect("usuario_comentarios.aspx" );
    }





    protected void BT_cerrar_Click(object sender, EventArgs e)
    {
        L_Usercs dac = new L_Usercs();
        U_user datos = new U_user();
        U_Datos val = new U_Datos();
        string nick = LB_nickMuestra.Text;
        int id_user = dac.consultaid(nick);
       

        datos.Session = Session.SessionID;
        datos = dac.cerrarse(datos);
        dac.cerrarSesio(id_user);
        Session["id"] = null;
        

        val.Sesion = null;
        dac.validarCerrarsesion(val);
        try
        {
            Session.Abandon();
            Response.Redirect("Ingresar.aspx");

        }
        catch
        {

        }
        Response.Redirect(datos.Link_observador);
    }



    protected void BT_respuestas_Click(object sender, EventArgs e)
    {
        
        Response.Redirect("usuarios_Respuestas.aspx");
    }

    protected void BT_verinfo_Click(object sender, EventArgs e)
    {

        
        Response.Redirect("usuario_informacion.aspx");
    }
}
