using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Administrador_noticia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
    }

    protected void BT_vistaPrevia_Click(object sender, EventArgs e)
    {
        LB_vistaPrev.Text = Ckeditor1.Text;
    }

    protected void BT_guardar_Click(object sender, EventArgs e)
    {
        EDatosCrearPost datos_creartPost = new EDatosCrearPost();
        DAOUsuario data_userPost = new DAOUsuario();

        int b = int.Parse(Request.Params["userid"]);
        int g = 1;
        DateTime dt = DateTime.Now;

        datos_creartPost.Titulo = TB_titulo.Text.ToString();
        datos_creartPost.Contenido1 = Ckeditor1.Text.ToString();
        datos_creartPost.Fecha = dt;
        datos_creartPost.Id_user = b;


        data_userPost.insertarNoticias(datos_creartPost);

        TB_titulo.Text = "";
        Ckeditor1.Text = "";
        Response.Redirect("Administrador.aspx?userid=" + b);

    }

    protected void B_volver_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        TB_titulo.Text = "";
        Ckeditor1.Text = "";
        Response.Redirect("Administrador.aspx?userid=" + b);
    }
}