using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        ClientScriptManager cm = this.ClientScript;
        U_comentarios doc = new U_comentarios();
        L_Usercs dac = new L_Usercs();
        
        int c = int.Parse(obQueryString["idcoment"].ToString());
        int u = int.Parse(obQueryString["userid"].ToString());

        doc = dac.ObtenerComentarioreportar(c);


        LB_Id_comentario.Text = doc.Coment;
        
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

        Response.Redirect("verCompletoUserregistrado.aspx?parametro=" + p + "&userid=" + u);
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        int u = int.Parse(Request.Params["userid"]);
        Response.Redirect("usuarios.aspx?&userid=" + u);
    }
}