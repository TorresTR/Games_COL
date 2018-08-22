using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Moderador_crear_post : System.Web.UI.Page
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


        DataTable regis = data_userPost.obtenerUss(b);

        int x = int.Parse(regis.Rows[0]["puntos"].ToString());

        DateTime dt = DateTime.Now;
        ClientScriptManager cm = this.ClientScript;
        DataTable data = data_userPost.ObtenerInteraccion(b);
        int inter = int.Parse(data.Rows[0]["id"].ToString());
        if (inter < 10)
        {
            inter = inter + 1;
            datos_creartPost.Titulo = TB_titulo.Text.ToString();
            datos_creartPost.Contenido1 = Ckeditor1.Text.ToString();
            datos_creartPost.Fecha = dt;
            datos_creartPost.Id_user = b;
            datos_creartPost.Id_etiqueta = int.Parse(DDL_etiquetas.SelectedValue.ToString());
            datos_creartPost.Interacciones = inter;

            x = x + 1;

            data_userPost.actualizarpuntoUser(b, x);
            data_userPost.insertarPost(datos_creartPost);
        }
        else
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Numero maximo de interacciones por dia alcanzado');</script>");
        }

        TB_titulo.Text = "";
        Ckeditor1.Text = "";
        Response.Redirect("Moderador.aspx?userid=" + b);

    }

    protected void B_volver_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        TB_titulo.Text = "";
        Ckeditor1.Text = "";
        Response.Redirect("Moderador.aspx?userid=" + b);
    }
}