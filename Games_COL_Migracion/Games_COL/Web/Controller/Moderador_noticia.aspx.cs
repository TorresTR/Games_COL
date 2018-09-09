using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Moderador_noticia : System.Web.UI.Page
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


        U_userCrearpost datos_creartPost = new U_userCrearpost();
        L_Usercs data_userPost = new L_Usercs();

        int b = int.Parse(Session["user_id"].ToString());
        int g = 1;
        DateTime dt = DateTime.Now;

        datos_creartPost.Titulo = TB_titulo.Text.ToString();
        datos_creartPost.Contenido1 = Ckeditor1.Text.ToString();
        datos_creartPost.Fecha = dt;
        datos_creartPost.Id_user = b;
        

        data_userPost.insertarNoticias(datos_creartPost);

        TB_titulo.Text = "";
        Ckeditor1.Text = "";
        U_user link = new U_user();
        link = data_userPost.irHomeModerador();
        Response.Redirect(link.Link_observador );

    }

    protected void B_volver_Click(object sender, EventArgs e)
    {

        TB_titulo.Text = "";
        Ckeditor1.Text = "";
        L_Usercs data = new L_Usercs();
        U_user link = new U_user();
        link = data.irHomeModerador();
        Response.Redirect(link.Link_observador );
    }
}