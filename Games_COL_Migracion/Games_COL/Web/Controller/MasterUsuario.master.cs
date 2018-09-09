using System;
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

public partial class View_MasterUsuario : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();


        D_User us = new D_User();
        L_Usercs log = new L_Usercs();
        U_Datos dato = new U_Datos();

        try
        {
            dato.Sesion = Session["user_id"].ToString();
            dato = log.validarCerrarsesion(dato);
            dato.Sesion = Session["user_id"].ToString();
        }
        catch (Exception) {

            dato = log.validarCerrarsesion(dato);
            Response.Redirect(dato.Link);
        }
        
        int b = int.Parse(Session["user_id"].ToString());


        DataTable data = us.CargarUsusarios(b);
        LB_mensaje.Text= log.ActualizarRango(data, b);
        DataTable dat = us.CargarUsusarios(b);
        dato = log.cargaDatos(dat, b);

        LB_nickMuestra.Text = dato.Nick;
        LB_muestraPuntos.Text = dato.Puntos.ToString();
        LB_muestraRango.Text = dato.Mensaje1;
        LB_muestraID.Text = dato.Id.ToString();


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

        datos.Session = Session.SessionID;
        datos = dac.cerrarse(datos);

        Session["user_id"] = null;
        

        val.Sesion = null;
        dac.validarCerrarsesion(val);

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
