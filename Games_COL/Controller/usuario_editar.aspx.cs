using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_usuario_editar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        DAOUsuario dac = new DAOUsuario();
        int a =  int.Parse(Request.Params["parametro"]);

        DataTable regis = dac.verEditar(a);

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
        post.Contenido1 = Ck_editar.Text.ToString();

        dac.actualizarMipost(post);

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
        Response.Redirect("usuario_miPost.aspx?userid=" + a);
    }
}