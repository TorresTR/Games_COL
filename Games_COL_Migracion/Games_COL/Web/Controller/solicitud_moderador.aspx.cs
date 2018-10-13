using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Logica;
using Utilitarios;
using System.Collections;
using System.Data;
using Persistencia_funciones;

public partial class View_Default : System.Web.UI.Page
{
    D_User dao = new D_User();
    
    U_Datos datos = new U_Datos();
    string mensaje;
    string mensaje2;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        string b = Session["user_id"].ToString();
        Int32 idioma = 1;
        Int32 id_pagina = 66;
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


        LB_titulo.Text = compIdioma["LB_titulo"].ToString();
        LB_info.Text = compIdioma["LB_info"].ToString();
        B_solicitud.Text = compIdioma["B_solicitud"].ToString();
        B_volver.Text = compIdioma["B_volver"].ToString();
        mensaje = compIdioma["solicitud_enviada"].ToString();
        mensaje2 = compIdioma["requisitos_necesarios"].ToString();


    }

    protected void B_volver_Click(object sender, EventArgs e)
    {
        
        string q = Session["user_id"].ToString();
        Response.Redirect("usuarios.aspx" );

    }

    protected void B_solicitud_Click(object sender, EventArgs e)
    {


        ClientScriptManager cm = this.ClientScript;
        int b = int.Parse(Session["user_id"].ToString());
        L_Usercs log = new L_Usercs();
        L_persistencia per = new L_persistencia();
        Entity_solicitud sol = new Entity_solicitud();
        
        datos.Id = b;
        System.Data.DataTable validez = dao.SolicitudAscenso(datos);
        datos.Nick = validez.Rows[0]["nick"].ToString();
        datos.Puntos = int.Parse(validez.Rows[0]["puntos"].ToString());
        datos.Fecha = DateTime.Now;

        sol.Id_user = int.Parse(Session["user_id"].ToString());
        sol.Nick = validez.Rows[0]["nick"].ToString();
        sol.Puntos = int.Parse(validez.Rows[0]["puntos"].ToString());
        sol.Fecha= DateTime.Now;

        U_Interaccion inter = per.insertarSolicitud(sol, validez, mensaje, mensaje2); 

        //log.solicitudModer(datos, validez, mensaje, mensaje2);
        LB_mensaje.Text = inter.Mensaje;
        B_solicitud.Visible = inter.Estado;
       
        
        
    }
}