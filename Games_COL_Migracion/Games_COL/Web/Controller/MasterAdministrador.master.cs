using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Logica;
using Utilitarios;

public partial class View_MasterAdministrador : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        if (Session["user_id"] == null)
        {
            Response.Redirect("ingresar.aspx");
        }

        D_User us = new D_User();
        L_Usercs log = new L_Usercs();
        U_Datos dato = new U_Datos();



        int b = int.Parse(obQueryString["userid"].ToString());


        DataTable data = us.CargarUsusarios(b);
        DataTable dat = us.CargarUsusarios(b);
        dato = log.cargaDatos(dat, b);

        LB_nickMuestra.Text = dato.Nick;
        LB_muestraPuntos.Text = dato.Puntos.ToString();
        LB_muestraRango.Text = dato.Mensaje1;
        LB_muestraID.Text = dato.Id.ToString();

    }

    protected void BT_crear_port_Click(object sender, EventArgs e)
    {
        

        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        Response.Redirect("Administrador_crear_post.aspx" + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());
    }



    protected void BT_verPqr_Click(object sender, EventArgs e)
    {
       

        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        Response.Redirect("Administrador_ver_pqr.aspx" + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());
    }

    protected void BT_listaUser_Click(object sender, EventArgs e)
    {
 

        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        Response.Redirect("Administrador_listado_user.aspx" + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());
    }

    protected void BT_misPost_Click(object sender, EventArgs e)
    {

        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        Response.Redirect("Administrador_miPost.aspx" + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());
    }

    protected void BT_atencionReportePost_Click(object sender, EventArgs e)
    {

     

        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        Response.Redirect("Administrador_atencion_bloquer_post.aspx" + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());
    }

    protected void BT_reporte_coment_Click(object sender, EventArgs e)
    {

        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        Response.Redirect("Administrador_admin_coment.aspx" + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());
    }

    protected void BT_cerrar_Click(object sender, EventArgs e)
    {
        Session["user_id"] = null;
        Session["nombre"] = null;





        D_User dc = new D_User();
        U_user inicio = new U_user();
        L_Usercs llamado = new L_Usercs();
        U_user datos = new U_user();

        inicio.Session = Session.SessionID;
        dc.cerrarSession(datos);



        inicio = llamado.ingresar();
        Response.Redirect(inicio.Link_demas);
    }

    protected void BT_solicitudes_Click(object sender, EventArgs e)
    {

        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        Response.Redirect("Administrador_solicitudes.aspx" + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());
    }

    protected void BT_crear_noticia_Click(object sender, EventArgs e)
    {

        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        Response.Redirect("Administrador_noticia.aspx" + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());
    }

    protected void BT_mi_noticia_Click(object sender, EventArgs e)
    {

        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        Response.Redirect("Administrador_miNoticia.aspx" + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());
    }
}
