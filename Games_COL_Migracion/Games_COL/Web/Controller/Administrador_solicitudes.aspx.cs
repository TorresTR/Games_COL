using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;

public partial class View_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BT_ascender_Click(object sender, EventArgs e)
    {
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);
        L_Usercs dato = new L_Usercs();
        U_user user = new U_user();
        ClientScriptManager cm = this.ClientScript;

        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");
        string ID = lblid.Text;
        int b = int.Parse(obQueryString["userid"].ToString());
        int h = int.Parse(ID);

        dato.Ascenso(h);
        cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Usuario Ascendido');</script>");
        user = dato.retornoAdmin();

        Response.Redirect(user.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());
        
    }

    protected void BT_ignorar_Click(object sender, EventArgs e)
    {
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);
        L_Usercs dato = new L_Usercs();
        U_user user = new U_user();
        ClientScriptManager cm = this.ClientScript;

        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");
        string ID = lblid.Text;
        int b = int.Parse(obQueryString["userid"].ToString());
        int h = int.Parse(ID);

        dato.ignorarAscenso(h);
        cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Solicitud Ignorada');</script>");
        user = dato.retornoAdmin();

        Response.Redirect(user.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);
        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();

        dat = llamado.retornoAdmin();

        Response.Redirect(dat.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());
    }
}