using Logica;
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

public partial class View_Moderador_ver_pqr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
    }

    

    protected void BT_resolver_Click(object sender, EventArgs e)
    {

        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);
        string b = obQueryString["userid"].ToString();
        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_muestraId");
        string ID = lblid.Text;

        obQueryString.Add("parametro", ID);
        obQueryString.Add("userid", b);
        

        Response.Redirect("Moderador_verpqrCompleto.aspx" + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());


    }

    protected void BT_ignorar_Click(object sender, EventArgs e)
    {
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);
        string q = obQueryString["userid"].ToString();
        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_muestraId");
        string ID = lblid.Text;
        Int32 id = int.Parse(lblid.Text);
        int b = int.Parse(q);
        D_User user = new D_User();


        user.ignorarpqr(id);
        Response.Redirect("Moderador_ver_pqr.aspx" + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());


    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);
        Response.Redirect("Moderador.aspx" + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());

      
    }
}