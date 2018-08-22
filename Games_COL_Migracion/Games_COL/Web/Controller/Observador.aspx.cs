using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Observador : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["user_id"] = 1;
        Response.Cache.SetNoStore();
        LB_resulbusq.Visible = false;

    }


    protected void datalist_command(object sender, DataListCommandEventArgs e)
    {

        L_Usercs data = new L_Usercs();
        data.obtenerPostObservador();
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

    protected void BT_pc_Click(object sender, EventArgs e)
    {
        Response.Redirect("Observador_pc.aspx");
    }

    protected void BT_xbox_Click(object sender, EventArgs e)
    {
        Response.Redirect("Observador_xbox.aspx");
    }

    protected void BT_plasyStation_Click(object sender, EventArgs e)
    {
        Response.Redirect("Observar_playstation.aspx");
    }

    protected void BT_andrioid_Click(object sender, EventArgs e)
    {
        Response.Redirect("Observador_androidt.aspx"); 
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        DAOUsuario lugar = new DAOUsuario();
        DataTable datos = lugar.buscarPost(TB_buscador.Text.ToString());

        DL_resultado.DataSource = datos;
        DL_resultado.DataBind();
        DataTable regis = datos;
        int x = regis.Rows.Count;

        if (x == 0)
        {
            LB_resulbusq.Visible = true;
            LB_resulbusq.Text = "No existe el post a buscar";
        }
        else
        {
            LB_resulbusq.Visible = true;
            LB_resulbusq.Text = "El Resultado de La Busqueda es:";

        }
    }

    protected void BT_verNoticas_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");
        string ID = lblid.Text;

        Response.Redirect("Observador_ver_noticia.aspx?parametro=" + ID.Trim());
    }
}