using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Administrador_editar_noticia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        DAOUsuario dac = new DAOUsuario();
        int a = int.Parse(Request.Params["parametro"]);

        DataTable regis = dac.verNoticia(a);

        if (regis.Rows.Count > 0)
        {

            LB_muestraContenido.Text = regis.Rows[0]["contenido"].ToString();
            LB_verAutor.Text = regis.Rows[0]["autor"].ToString();
            Ck_editar.Visible = false;
            BT_editar.Visible = false;
        }

    }

    protected void BT_editar_Click(object sender, EventArgs e)
    {
        DAOUsuario dac = new DAOUsuario();
        EDatosCrearPost post = new EDatosCrearPost();

        post.Id = int.Parse(Request.Params["parametro"]);
        int b = int.Parse(Request.Params["userid"]);
        post.Contenido1 = Ck_editar.Text.ToString();

        dac.actualizarNoticia(post);
        Response.Redirect("Administrador_miNoticia.aspx?userid=" + b);

    }

    protected void Bt_editarCk_Click(object sender, EventArgs e)
    {
        Ck_editar.Text = LB_muestraContenido.Text;
        Ck_editar.Visible = true;
        BT_editar.Visible = true;
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        int a = int.Parse(Request.Params["userid"]);
        Response.Redirect("Administrador_miNoticia.aspx?userid=" + a);
    }
}