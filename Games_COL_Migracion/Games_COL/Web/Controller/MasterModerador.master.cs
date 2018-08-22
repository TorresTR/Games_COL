using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_MasterModerador : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_id"] == null)
        {
            Response.Redirect("ingresar.aspx");
        }
        Response.Cache.SetNoStore();

        DAOUsuario us = new DAOUsuario();

        int b = int.Parse(Request.Params["userid"]);

        
        DataTable data = us.CargarUsusarios(b);

        if (data.Rows.Count > 0)
        {

            if (int.Parse(data.Rows[0]["id"].ToString()) == b)
            {

                int puntos = int.Parse(data.Rows[0]["puntos"].ToString());
                if (puntos > 3700 && puntos < 5800)
                {
                    us.actualizarRango(b, 7);
                }
                else if (puntos > 5800 && puntos < 7900)
                {
                    us.actualizarRango(b, 8);
                }
                else if (puntos > 7900 )
                {
                    us.actualizarRango(b, 9);
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
        Response.Redirect("Moderador_crear_post.aspx?userid=" + b);
    }



    protected void BT_verPqr_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("Moderador_ver_pqr.aspx?userid=" + b);
    }

    protected void BT_listaUser_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("Moderador_listado_user.aspx?userid=" + b);
    }

    protected void BT_misPost_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("Moderador_miPost.aspx?userid=" + b);
    }

    protected void BT_atencionReportePost_Click(object sender, EventArgs e)
    {

        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("Moderador_atencion_bloquer_post.aspx?userid=" + b); 
    }

    protected void BT_reporte_coment_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("Moderador_admin_coment.aspx?userid=" + b);
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

    protected void BT_crear_noticia_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("Moderador_noticia.aspx?userid=" + b);
    }

    protected void BT_mi_noticia_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("Moderador_miNoticia.aspx?userid=" + b);
    }

    protected void BT_informacion_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("Moderador_informacion.aspx?userid=" + b);
    }
}
