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

        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        ClientScriptManager cm = this.ClientScript;
        U_comentarios reporte = new U_comentarios();
        L_Usercs envio = new L_Usercs();

        int b = int.Parse(obQueryString["idcoment"].ToString());
        int p = int.Parse(obQueryString["parametro"].ToString());
        DateTime dt = DateTime.Now;

        int u = int.Parse(obQueryString["userid"].ToString());


        DataTable regis = envio.obtenerComentario1(b);


        reporte.Id_com_reportado1 = b;
        reporte.Contenido1 = TB_motivoR.Text.ToString();
        reporte.Fecha = dt;
        reporte.Id_user = u;

        envio.insertarComentarioReportado(reporte);

        string ID = obQueryString["parametro"].ToString();
        string z = obQueryString["userid"].ToString();

        obQueryString.Add("parametro", ID);
        obQueryString.Add("userid", z);

        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();

        dat = llamado.redirigirCompletoModerador();

        Response.Redirect(dat.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        string z = obQueryString["userid"].ToString();


        obQueryString.Add("userid", z);

        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();

        dat = llamado.irHomeModerador();

        Response.Redirect(dat.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());
    }
}