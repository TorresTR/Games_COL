using System;
using System.Collections.Generic;
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


        L_Usercs dac = new L_Usercs();
        U_misPost dat = new U_misPost();


        int dato = int.Parse(obQueryString["userid"].ToString());

        dat.Dato1 = dato;

        DL_post.DataSource = dac.misPostcomentados(dat);
        DL_post.DataBind();
    }



    protected void BT_vermas_Click(object sender, EventArgs e)
    {

        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");
        string ID = lblid.Text;

        int b = int.Parse(obQueryString["userid"].ToString());

        string x = b.ToString();
        obQueryString.Add("parametro", ID);
        obQueryString.Add("userid", x);

        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();

        dat = llamado.redireccionMiscoment();

        Response.Redirect(dat.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());

       
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();

        dat = llamado.volverUsuariosRegistrado();

        Response.Redirect(dat.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());
    }
}