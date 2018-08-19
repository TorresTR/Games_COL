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

        int c = int.Parse(Request.Params["idcoment"]);
        int u = int.Parse(Request.Params["userid"]);

        DataTable regis = dac.ObtenerComent1(c);

        int contcolum = regis.Columns.Count;

        int p = int.Parse(regis.Rows[0]["id"].ToString());
        if (c == int.Parse(regis.Rows[0]["id"].ToString()))
        {
            LB_Id_comentario.Text = regis.Rows[0]["comentarios"].ToString();
        }
    }

    protected void BT_reportar_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        EDatosReporteCom reporte = new EDatosReporteCom();
        DAOUsuario envio = new DAOUsuario();

        int b = int.Parse(Request.Params["idcoment"]);
        int p = int.Parse(Request.Params["parametro"]);
        DateTime dt = DateTime.Now;

        int u = int.Parse(Request.Params["userid"]);


        DataTable regis = envio.ObtenerComent1(b);


        reporte.Id_com_reportado = b;
        reporte.Contenido = TB_motivoR.Text.ToString();
        reporte.Fecha = dt;
        reporte.Id_user = u;

        envio.insertarreporteComentarios(reporte);

        Response.Redirect("Administrador_verCompleto.aspx?parametro=" + p + "&userid=" + u);
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        int u = int.Parse(Request.Params["userid"]);
        Response.Redirect("Administrador.aspx?&userid=" + u);
    }
}