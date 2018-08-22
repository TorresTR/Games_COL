using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_MasterUsuario : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        if (Session["user_id"] == null)
        {
            Response.Redirect("ingresar.aspx");
        }
        DAOUsuario us = new DAOUsuario();

        int b = int.Parse(Request.Params["userid"]);


        DataTable data = us.CargarUsusarios(b);

        if (data.Rows.Count > 0) {

            if (int.Parse(data.Rows[0]["id"].ToString()) == b)
            {
                
                int puntos = int.Parse(data.Rows[0]["puntos"].ToString());
                if (puntos > 150 && puntos < 300)
                {
                    us.actualizarRango(b, 2);
                }
                else if (puntos > 300 && puntos < 700)
                {
                    us.actualizarRango(b, 3);
                }
                else if (puntos > 700 && puntos < 1700)
                {
                    us.actualizarRango(b, 4);
                }
                else if (puntos > 1700 && puntos < 2700)
                {
                    us.actualizarRango(b, 5);
                }
                else if (puntos > 2700)
                {
                    us.actualizarRango(b, 6);
                    LB_mensaje.Visible = true;
                    LB_mensaje.Text = "Puedes solicitar tu ascenso a moderador";
                }
                DataTable dat = us.CargarUsusarios(b);
                if (dat.Rows.Count > 0)
                {

                    if (int.Parse(dat.Rows[0]["id"].ToString()) == b)
                    {
                        LB_nickMuestra.Text = dat.Rows[0]["nick"].ToString();
                        LB_muestraPuntos.Text = dat.Rows[0]["puntos"].ToString();
                        LB_muestraRango.Text = dat.Rows[0]["tipo"].ToString();
                        LB_muestraID.Text = dat.Rows[0]["id"].ToString();
                        
                    }
                }
            }

        }


    }

    protected void BT_crear_port_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("Crear_post.aspx?userid=" + b);
    }

    protected void BT_PQR_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("usuarios_pqr.aspx?userid=" + b);
    }

    protected void B_solicitud_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("solicitud_moderador.aspx?userid=" + b);
    }

    protected void BT_inicio_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("usuarios.aspx?userid=" + b);
    }

    protected void BT_misPost_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("usuario_miPost.aspx?userid=" + b);
    }

    protected void BT_comentarios_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("usuario_comentarios.aspx?userid=" + b);
    }





    protected void BT_cerrar_Click(object sender, EventArgs e)
    {
        Session["user_id"] = null;
        Session["nombre"] = null;




        DAOUsuario dac = new DAOUsuario();
        EUsuario datos = new EUsuario();

        datos.Session = Session.SessionID;
        dac.cerrarSession(datos);

        Response.Redirect("Ingresar.aspx");
    }



    protected void BT_respuestas_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("usuarios_Respuestas.aspx?userid=" + b);
    }

    protected void BT_verinfo_Click(object sender, EventArgs e)
    {
       
            int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("usuario_informacion.aspx?userid=" + b);
    }
}
