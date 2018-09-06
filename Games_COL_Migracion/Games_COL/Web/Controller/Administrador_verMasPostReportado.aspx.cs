using Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;

public partial class View_Administrador_verMasPostReportado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        U_userCrearpost doc = new U_userCrearpost();
        L_Usercs dac = new L_Usercs();


        doc.Id = int.Parse(obQueryString["parametro"].ToString());
        int x = int.Parse(obQueryString["parametro"].ToString());

        doc = dac.obtenerPostObservadorreportadomoder(doc);


        LB_contenido.Text = doc.Contenido1.ToString();
        LB_mostrarAutor.Text = doc.Autor1.ToString();
    }





    protected void BT_volver_Click(object sender, EventArgs e)
    {
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        int t = int.Parse(obQueryString["userid"].ToString());

        string dat = t.ToString();
        obQueryString.Add("userid", dat);


        U_user data = new U_user();
        L_Usercs llamado = new L_Usercs();

        data = llamado.admindbloauearpost();
        Response.Redirect(data.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());
    }
}