using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_usuarios_pqr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
    }

    protected void BT_envio_Click(object sender, EventArgs e)
    {
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);


        U_Datospqr pqr = new U_Datospqr();
        L_Usercs dao = new L_Usercs();

        int b = int.Parse(obQueryString["userid"].ToString());

        DateTime dt = DateTime.Now;

        pqr.Asunto = TB_asunto.Text.ToString();
        pqr.Id_pqrestado = int.Parse(DDL_tipoSolicitud.SelectedValue.ToString());
        pqr.Contenido = TB_solicitud.Text.ToString();
        pqr.Fecha = dt;
        pqr.Id_user = b;

        dao.insertarPqr(pqr);

        U_user retorno = new U_user();
        L_Usercs llamado = new L_Usercs();

        retorno = llamado.retornoUsuario();
        Response.Redirect(retorno.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());
        

    }

    protected void B_volver_Click(object sender, EventArgs e)
    {
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        U_user retorno = new U_user();
        L_Usercs llamado = new L_Usercs();

        retorno = llamado.retornoUsuario();
        Response.Redirect(retorno.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());

    }
}