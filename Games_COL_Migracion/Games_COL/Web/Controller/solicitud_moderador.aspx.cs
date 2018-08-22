using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Default : System.Web.UI.Page
{
    DAOUsuario dao = new DAOUsuario();
    Edatos datos = new Edatos();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        int b = int.Parse(Request.Params["userid"]);

       
    }

    protected void B_volver_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("usuarios.aspx?userid=" + b);
    }

    protected void B_solicitud_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        int b = int.Parse(Request.Params["userid"]);

        //DateTime q = DateTime.Now;
        datos.Id = b;
        System.Data.DataTable validez = dao.SolicitudAscenso(datos);
        datos.Nick = validez.Rows[0]["nick"].ToString();
        datos.Puntos = int.Parse(validez.Rows[0]["puntos"].ToString());
        datos.Fecha = DateTime.Now;
        if (int.Parse(validez.Rows[0]["puntos"].ToString()) >= 3700)
        {
            dao.insertarSolicitud(datos);
            LB_mensaje.Text = "Solicitud enviada con exito";
            B_solicitud.Visible = false;
        }
        else
        {
            LB_mensaje.Text = "No cuenta con los requisitos necesarios para realizar la solicitud";
            B_solicitud.Visible = false;
        }
        
        //Response.Redirect("solicitud_moderador.aspx?userid="+b);
    }
}