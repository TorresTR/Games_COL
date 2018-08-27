using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Datos;
using Utilitarios;

public partial class View_Moderador_verpqrCompleto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);
        D_User user = new D_User();
        U_Datospqr respuesa = new U_Datospqr();
        L_Usercs logica = new L_Usercs();

        respuesa.Id_pqr = int.Parse(obQueryString["parametro"].ToString());

        

        DataTable regis = user.verpqr(respuesa);
        respuesa = logica.pqr(regis);

        LB_muestraPag.Text = respuesa.Contenido;
        LB_autor.Text = respuesa.Autor;
            
    }

    protected void BT_responder_Click(object sender, EventArgs e)
    {
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);
        D_User user = new D_User();
        U_Datospqr respuesa = new U_Datospqr();


        int b = int.Parse(obQueryString["userid"].ToString());
        int q = int.Parse(obQueryString["parametro"].ToString());
        int a =1;
        DateTime dt = DateTime.Now;

        respuesa.Id_respondedor = b;
        respuesa.Fecha_respuesta = dt;
        respuesa.Respuesta = TB_respuestapqr.Text.ToString();
        respuesa.Id_pqr = q;
        respuesa.Estado_respuesta = a;

        user.actualizarPQR(respuesa);
        string par = q.ToString();
        string ui = b.ToString();
        obQueryString.Add("parametro", par);
        obQueryString.Add("userid", ui);
        Response.Redirect("Moderador_ver_pqr.aspx" + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());

        
    }

    protected void B_volver_Click(object sender, EventArgs e)
    {
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);
        string q = obQueryString["userid"].ToString();
        string z = obQueryString["parametro"].ToString();
        obQueryString.Add("parametro", z);
        obQueryString.Add("userid", q);
        Response.Redirect("Moderador_ver_pqr.aspx" + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());

        
    }
}