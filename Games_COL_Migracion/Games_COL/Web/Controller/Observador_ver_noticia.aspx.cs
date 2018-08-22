using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Observador_ver_noticia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();


        EDatosCrearPost doc = new EDatosCrearPost();
        DAOUsuario dac = new DAOUsuario();

        doc.Id = int.Parse(Request.Params["parametro"]);
        int dato = int.Parse(Request.Params["parametro"]);
        DataTable regis = dac.verNoticia(doc);

        if (regis.Rows.Count > 0)
        {

            LB_verPost.Text = regis.Rows[0]["contenido"].ToString();
            LB_autor.Text = regis.Rows[0]["autor"].ToString();

        }

        GV_comentarios.DataSource = dac.ObtenerComent(dato);
        GV_comentarios.DataBind();


    }



    protected void B_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("observador.aspx");


    }
}