using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Moderador : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        LB_busq.Visible = false;
    }

    protected void datalist_command(object sender, DataListCommandEventArgs e)
    {

        DAOUsuario archivo = new DAOUsuario();
        EDatosCrearPost datos = new EDatosCrearPost();

        DataTable registro = archivo.Obtenerpsot();

        if (e.CommandName.Equals("vermas"))
        {

            int res = Convert.ToInt32(DataList1.DataKeys[e.Item.ItemIndex].ToString());

            Response.Redirect("Moderador_verCompleto.aspx?parametro=" + res);
        }
    }


    protected void BT_vermas_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");
        string ID = lblid.Text;

        int b = int.Parse(Request.Params["userid"]);


        Response.Redirect("Moderador_verCompleto.aspx?parametro=" + ID.Trim() + "&userid=" + b);
    }

    protected void BT_pc_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("Moderador_pc.aspx?userid=" + b);
    }

    protected void BT_xbox_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("Moderador_xbox.aspx?userid=" + b);
    }

    protected void BT_ps_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("Moderador_playstation.aspx?userid=" + b);
    }

    protected void BT_android_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("Moderador_android.aspx?userid=" + b);
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
            LB_busq.Visible = true;
            LB_busq.Text = "No existe el post a buscar";
        }
        else
        {
            LB_busq.Visible = true;
            LB_busq.Text = "El Resultado de La Busqueda es:";

        }
    }

    protected void BT_verNoticas_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");
        string ID = lblid.Text;
        int b = int.Parse(Request.Params["userid"]);

        Response.Redirect("Moderador_ver_noticias.aspx?parametro=" + ID.Trim()+"&userid="+b);
    }
}