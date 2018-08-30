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
    }

    protected void BT_bloquear_Click(object sender, EventArgs e)
    {

        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        L_Usercs dato = new L_Usercs();
       

        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");
        string ID = lblid.Text;
        int b = int.Parse(obQueryString["userid"].ToString());
        int h = int.Parse(ID);

        dato.bloquearComent(h);

        U_user data = new U_user();
        L_Usercs llamado = new L_Usercs();

        data = llamado.moderadoradmincoment();
        Response.Redirect(data.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());
        
    }

    protected void Bt_volver_Click(object sender, EventArgs e)
    {
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        int t = int.Parse(obQueryString["userid"].ToString());

        string dat = t.ToString();
        obQueryString.Add("userid", dat);


        U_user data = new U_user();
        L_Usercs llamado = new L_Usercs();

        data = llamado.irHomeModerador();
        Response.Redirect(data.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());
    }
}