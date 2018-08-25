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

public partial class View_usuarios : System.Web.UI.Page
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

        QueryString obQueryString = new QueryString();
        

        string ID = lblid.Text;



        string b = Request.Params["userid"].ToString();

        obQueryString.Add("parametro", ID);
        obQueryString.Add("userid", b);

        Response.Redirect("verCompletoUserregistrado.aspx" + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());
    }

    protected void BT_pc_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("usuarios_pc.aspx?userid=" + b);
    }

    protected void BT_xbox_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("usuarios_xbox.aspx?userid=" + b);
    }

    protected void BT_ps_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("usuarios_playstation.aspx?userid=" + b);
    }

    protected void BT_android_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("usuarios_android.aspx?userid=" + b);
    }



    protected void Button3_Click(object sender, EventArgs e)
    {
        DAOUsuario lugar = new DAOUsuario();
        L_Usercs buscar = new L_Usercs();
        DataTable datos = lugar.buscarPost(TB_buscador.Text.ToString());

        DL_resultado.DataSource = datos;
        DL_resultado.DataBind();

        DataTable regis = datos;
       
        int x = regis.Rows.Count;

        LB_busq.Visible = true;
        LB_busq.Text = buscar.buscar(x);


    }

    protected void BT_verNoticas_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");
        string ID = lblid.Text;

        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("usuarios_ver_noticias.aspx?parametro=" + ID.Trim() + "&userid=" + b);
    }

    
}