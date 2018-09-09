using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;


public partial class View_usuarios_pc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Cache.SetNoStore();
        LB_busq.Visible = false;


    }

    protected void BT_vermas_Click(object sender, EventArgs e)
    {

        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");

        string ID = lblid.Text;

        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();

        string b = Session["user_id"].ToString();
        Session["parametro"] = ID;
        dat = llamado.verCompletousuarioRegistrado();

        Response.Redirect(dat.Link_observador );
    }

    protected void BT_home_Click(object sender, EventArgs e)
    {
        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();

        dat = llamado.volverUsuariosRegistrado();

        Response.Redirect(dat.Link_observador);
    }

    protected void BT_xbox_Click(object sender, EventArgs e)
    {
        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();


        dat = llamado.irXboxusuarioregistrado();

        Response.Redirect(dat.Link_observador );
    }

    protected void BT_ps_Click(object sender, EventArgs e)
    {
        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();

        dat = llamado.irPSusuarioregistrado();

        Response.Redirect(dat.Link_observador);
    }

    protected void BT_android_Click(object sender, EventArgs e)
    {
        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();

        dat = llamado.irAndroidusuarioregistrado();

        Response.Redirect(dat.Link_observador );
    }

    protected void BT_Buscar_Click(object sender, EventArgs e)
    {
        L_Usercs lugar = new L_Usercs();

        U_user dat = new U_user();

        DataTable dato = lugar.Busqueda(TB_buscador.Text.ToString());

        DL_resultado.DataSource = dato;
        DL_resultado.DataBind();

        dat = lugar.busquedaMensaje(dato);

        LB_busq.Visible = dat.Estado;
        LB_busq.Text = dat.Mensaje_Alertaobservador1;


    }

    protected void BT_verNoticas_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");

        L_Usercs data = new L_Usercs();
        U_user envioObservador = new U_user();


        string x = lblid.Text.ToString();
        string b = Session["user_id"].ToString();
        Session["parametro"] = x;
        envioObservador = data.verNoticiasusuariosregistrados(x);


        Response.Redirect(envioObservador.Link_observador);
    }
}