﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Logica;
using Utilitarios;

public partial class View_MasterAdministrador : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

         

        Int32 idioma = 1;
        Int32 id_pagina = 65;
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


        BT_crearPost.Text = compIdioma["BT_crearPost"].ToString();
        BT_verPqr.Text = compIdioma["BT_verPqr"].ToString();
        BT_listaUser.Text = compIdioma["BT_listaUSer"].ToString();
        BT_misPost.Text = compIdioma["BT_misPost"].ToString();
        BT_atencionReportePost.Text = compIdioma["BT_atencionReportePost"].ToString();
        BT_reporte_coment.Text = compIdioma["BT_reporte_coment"].ToString();
        BT_solicitudes.Text = compIdioma["BT_solicitudes"].ToString();
        BT_crear_noticia.Text = compIdioma["BT_crear_noticia"].ToString();
        BT_mi_noticia.Text = compIdioma["BT_mi_noticia"].ToString();
        LB_nick.Text = compIdioma["LB_nick"].ToString();
        LB_puntos.Text = compIdioma["LB_puntos"].ToString();
        LB_rango.Text = compIdioma["LB_rango"].ToString();
        BT_cerrar.Text = compIdioma["BT_cerrar"].ToString();
        BT_idioma.Text = compIdioma["BT_idioma"].ToString();
        Session["nick"] = LB_nickMuestra.Text;

        D_User us = new D_User();
        L_Usercs log = new L_Usercs();
        U_Datos dato = new U_Datos();
        U_Datos llamado = new U_Datos();

        try
        {
            dato.Sesion = Session["id"].ToString();
            dato = log.validarCerrarsesion(dato);
            dato.Sesion = Session["id"].ToString();
        }
        catch (Exception)
        {

            dato = log.validarCerrarsesion(dato);
            Response.Redirect(dato.Link);
        }


        int b = int.Parse(Session["id"].ToString());


        //DataTable data = us.CargarUsusarios(b);

        L_persistencia per = new L_persistencia();
        

        DataTable dat = log.ToDataTable(per.obtenerCarga(b));
        dato = log.cargaDatos(dat, b);

        LB_nickMuestra.Text = dato.Nick;
        LB_muestraPuntos.Text = dato.Puntos.ToString();
        LB_muestraRango.Text = dato.Mensaje1;
        LB_muestraID.Text = dato.Id.ToString();

    }

    protected void BT_crear_port_Click(object sender, EventArgs e)
    {
        Response.Redirect("Administrador_crear_post.aspx" );
    }



    protected void BT_verPqr_Click(object sender, EventArgs e)
    {
       

        

        Response.Redirect("Administrador_ver_pqr.aspx" );
    }

    protected void BT_listaUser_Click(object sender, EventArgs e)
    {
 

        
        Response.Redirect("Administrador_listado_user.aspx" );
    }

    protected void BT_misPost_Click(object sender, EventArgs e)
    {

       
        Response.Redirect("Administrador_miPost.aspx" );
    }

    protected void BT_atencionReportePost_Click(object sender, EventArgs e)
    {

     

       

        Response.Redirect("Administrador_atencion_bloquer_post.aspx" );
    }

    protected void BT_reporte_coment_Click(object sender, EventArgs e)
    {

       

        Response.Redirect("Administrador_admin_coment.aspx" );
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

    protected void BT_solicitudes_Click(object sender, EventArgs e)
    {


        Response.Redirect("Administrador_solicitudes.aspx" );
    }

    protected void BT_crear_noticia_Click(object sender, EventArgs e)
    {

        

        Response.Redirect("Administrador_noticia.aspx");
    }

    protected void BT_mi_noticia_Click(object sender, EventArgs e)
    {

        

        Response.Redirect("Administrador_miNoticia.aspx");
    }

    protected void BT_idioma_Click(object sender, EventArgs e)
    {
        Response.Redirect("Administrador-idioma.aspx");
    }

    protected void BT_invitar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Administrador_SWcolegio.aspx");
    }

    protected void BT_contactenos_Click(object sender, EventArgs e)
    {
        Response.Redirect("Admin_contacto.aspx");
    }
}
