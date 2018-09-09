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

public partial class View_Default : System.Web.UI.Page
{
    D_User dao = new D_User();
    
    U_Datos datos = new U_Datos();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        string b = Session["user_id"].ToString();


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

        
        datos.Id = b;
        System.Data.DataTable validez = dao.SolicitudAscenso(datos);
        datos.Nick = validez.Rows[0]["nick"].ToString();
        datos.Puntos = int.Parse(validez.Rows[0]["puntos"].ToString());
        datos.Fecha = DateTime.Now;
        U_Interaccion inter = log.solicitudModer(datos,validez);
      
        LB_mensaje.Text = inter.Mensaje;
        B_solicitud.Visible = inter.Estado;
       
        
        
    }
}