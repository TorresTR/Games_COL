using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;

public partial class View_Administrador_atencion_bloquer_post : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Cache.SetNoStore();
    }

    protected void BT_vermas_Click(object sender, EventArgs e)
    {
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_idPost");
        string ID = lblid.Text;

        int b = int.Parse(obQueryString["userid"].ToString());

        string dat = b.ToString();
        obQueryString.Add("userid", dat);
        obQueryString.Add("parametro", ID);

        U_user data = new U_user();
        L_Usercs llamado = new L_Usercs();

        data = llamado.verPostRepor();
        Response.Redirect(data.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());

        
    }

    protected void BT_bloquear_Click(object sender, EventArgs e)
    {
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);
        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_idPost");
        string ID = lblid.Text;

        int b = int.Parse(obQueryString["userid"].ToString());
        int x = 2;
        int h = int.Parse(ID);
        int z = 1;

        L_Usercs dac = new L_Usercs();

        dac.bloquearPost(h, b, x, z);

        


        U_user dat = dac.atencionBloquearPost();

        Response.Redirect(dat.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());
    }

    protected void Bt_volver_Click(object sender, EventArgs e)
    {

        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);
        L_Usercs dac = new L_Usercs();
        U_user dat = dac.retornoAdmin();

        Response.Redirect(dat.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());

    }
}