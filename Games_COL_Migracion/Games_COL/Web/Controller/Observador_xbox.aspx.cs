using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;


public partial class View_Observador_xbox : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Session["user_id"] = 1;
        Response.Cache.SetNoStore();
        LB_resulbusq.Visible = false;
    }

    

    protected void BT_vermas_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");

        L_Usercs data = new L_Usercs();
        U_user envioObservador = new U_user();

        string x = lblid.Text.ToString();

        envioObservador = data.Vermas(x);


        Response.Redirect(envioObservador.Link_observador + envioObservador.ID_vermasObservador1.Trim());

    }


    protected void BT_home_Click(object sender, EventArgs e)
    {
        U_user inicio = new U_user();
        L_Usercs llamado = new L_Usercs();

        inicio = llamado.irInicio();
        Response.Redirect(inicio.Link_demas);
    }

    protected void BT_pc_Click(object sender, EventArgs e)
    {
        U_user pc = new U_user();
        L_Usercs llamado = new L_Usercs();

        pc = llamado.irPC();
        Response.Redirect(pc.Link_demas);
    }

    protected void BT_plasyStation_Click(object sender, EventArgs e)
    {
        U_user ps = new U_user();
        L_Usercs llamado = new L_Usercs();

        ps = llamado.irPS();
        Response.Redirect(ps.Link_demas);
    }

    protected void BT_andrioid_Click(object sender, EventArgs e)
    {
        U_user android = new U_user();
        L_Usercs llamado = new L_Usercs();

        android = llamado.irAndroid();
        Response.Redirect(android.Link_demas);
    }

    protected void BT_Buscar_Click(object sender, EventArgs e)
    {
        L_Usercs lugar = new L_Usercs();

        U_user dat = new U_user();

        DataTable dato = lugar.Busqueda(TB_buscador.Text.ToString());

        DL_resultado.DataSource = dato;
        DL_resultado.DataBind();

        dat = lugar.busquedaMensaje(dato);

        LB_resulbusq.Visible = dat.Estado;
        LB_resulbusq.Text = dat.Mensaje_Alertaobservador1;


    }


    protected void BT_verNoticas_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");

        L_Usercs data = new L_Usercs();
        U_user envioObservador = new U_user();

        string x = lblid.Text.ToString();

        envioObservador = data.verNoticias(x);


        Response.Redirect(envioObservador.Link_observador + envioObservador.ID_vermasObservador1.Trim());
    }
}