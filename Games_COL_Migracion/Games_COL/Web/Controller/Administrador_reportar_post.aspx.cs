using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        ClientScriptManager cm = this.ClientScript;
        EDatosCrearPost doc = new EDatosCrearPost();
        DAOUsuario dac = new DAOUsuario();

        int c = int.Parse(Request.Params["parametro"]);
        int u = int.Parse(Request.Params["userid"]);
        DataTable regis = dac.Obtenerpsot();

        int contcolum = regis.Columns.Count;


        for (int i = 0; i <= contcolum; i++)
        {


            if (regis.Rows.Count > 0)
            {
                if (c == int.Parse(regis.Rows[i]["id"].ToString()))
                {
                    LB_tituloReportar.Text = regis.Rows[i]["titulo"].ToString();
                }


            }
        }



    }

    protected void BT_enviarReporte_Click(object sender, EventArgs e)
    {

        ClientScriptManager cm = this.ClientScript;
        EDatosreporte reporte = new EDatosreporte();
        DAOUsuario envio = new DAOUsuario();

        int b = int.Parse(Request.Params["parametro"]);
        DateTime dt = DateTime.Now;

        int u = int.Parse(Request.Params["userid"]);


        DataTable regis = envio.Obtenerpsot();


        reporte.Id_post_reportado = b;
        reporte.Contido_reporte = TB_reporte.Text.ToString();
        reporte.Fecha_reporte = dt;
        reporte.User_reportador = u;

        envio.insertarreporte(reporte);

        Response.Redirect("Administrador_verCompleto.aspx?parametro=" + b + "&userid=" + u);
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["parametro"]);
        int u = int.Parse(Request.Params["userid"]);
        Response.Redirect("Administrador_verCompleto.aspx?parametro=" + b + "&userid=" + u);
    }
}