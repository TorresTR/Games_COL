using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Logica;
using Utilitarios;

public partial class View_Default : System.Web.UI.Page
{
    D_User dao = new D_User();
    
    U_Datos datos = new U_Datos();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);
        string b = obQueryString["userid"].ToString();


    }

    protected void B_volver_Click(object sender, EventArgs e)
    {
        
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);
        string q = obQueryString["userid"].ToString();
        Response.Redirect("usuarios.aspx" + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());

    }

    protected void B_solicitud_Click(object sender, EventArgs e)
    {
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        ClientScriptManager cm = this.ClientScript;
        int b = int.Parse(obQueryString["userid"].ToString());
        L_Usercs log = new L_Usercs();

        
        datos.Id = b;
        System.Data.DataTable validez = dao.SolicitudAscenso(datos);
        datos.Nick = validez.Rows[0]["nick"].ToString();
        datos.Puntos = int.Parse(validez.Rows[0]["puntos"].ToString());
        datos.Fecha = DateTime.Now;
        U_Interaccion inter = log.solicitudModer(datos,validez);
      
        LB_mensaje.Text = inter.Mensaje;
        B_solicitud.Visible = inter.Estado;
       
        
        
    }
}