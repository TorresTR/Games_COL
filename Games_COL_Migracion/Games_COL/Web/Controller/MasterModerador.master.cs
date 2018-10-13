using System;
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
using Persistencia_funciones;

public partial class View_MasterModerador : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        Int32 idioma = 1;
        Int32 id_pagina = 64;
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
        BT_crear_noticia.Text = compIdioma["BT_crear_noticia"].ToString();
        BT_informacion.Text = compIdioma["BT_informacion"].ToString();
        LB_nick.Text = compIdioma["LB_nick"].ToString();
        LB_puntos.Text = compIdioma["LB_puntos"].ToString();
        LB_rango.Text = compIdioma["LB_rango"].ToString();
        BT_cerrar.Text = compIdioma["BT_cerrar"].ToString();
        BT_mi_noticia.Text = compIdioma["BT_mi_noticia"].ToString();
        Session["nick"] = LB_nickMuestra.Text;

        D_User us = new D_User();
        L_Usercs log = new L_Usercs();
        U_Datos dato = new U_Datos();

        try
        {
            dato.Sesion = Session["user_id"].ToString();
            dato = log.validarCerrarsesion(dato);
            dato.Sesion = Session["user_id"].ToString();
        }
        catch (Exception)
        {

            dato = log.validarCerrarsesion(dato);
            Response.Redirect(dato.Link);
        }
        
        int b = int.Parse(Session["user_id"].ToString());

        L_persistencia per = new L_persistencia();

        DataTable data = log.ToDataTable(per.obtenerCarga(b));
        log.ActualizarRango(data, b);
        DataTable dat = log.ToDataTable(per.obtenerCarga(b));
        dato = log.cargaDatos(dat, b);

        LB_nickMuestra.Text = dato.Nick;
        LB_muestraPuntos.Text = dato.Puntos.ToString();
        LB_muestraRango.Text = dato.Mensaje1;
        LB_muestraID.Text = dato.Id.ToString();



    }

    protected void BT_crear_port_Click(object sender, EventArgs e)
    {
        


        Response.Redirect("Moderador_crear_post.aspx");
    }



    protected void BT_verPqr_Click(object sender, EventArgs e)
    {
        

        Response.Redirect("Moderador_ver_pqr.aspx");
    }

    protected void BT_listaUser_Click(object sender, EventArgs e)
    {
        


        Response.Redirect("Moderador_listado_user.aspx");
    }

    protected void BT_misPost_Click(object sender, EventArgs e)
    {


        Response.Redirect("Moderador_miPost.aspx" );

    }

    protected void BT_atencionReportePost_Click(object sender, EventArgs e)
    {


        Response.Redirect("Moderador_atencion_bloquer_post.aspx" );
    }

    protected void BT_reporte_coment_Click(object sender, EventArgs e)
    {


        Response.Redirect("Moderador_admin_coment.aspx");
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

        Session["user_id"] = null;
        



        dac.cerrarSesio(id_user);

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

    protected void BT_crear_noticia_Click(object sender, EventArgs e)
    {

        Response.Redirect("Moderador_noticia.aspx" );
    }

    protected void BT_mi_noticia_Click(object sender, EventArgs e)
    {

        Response.Redirect("Moderador_miNoticia.aspx" );
    }

    protected void BT_informacion_Click(object sender, EventArgs e)
    {


        Response.Redirect("Moderador_informacion.aspx" );
    }
}
