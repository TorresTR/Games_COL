using Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;

public partial class View_Adminsitrador_ver_noticias : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();


        U_userCrearpost doc = new U_userCrearpost();
        L_Usercs dac = new L_Usercs();


        doc.Id = int.Parse(Session["parametro"].ToString());
        int x = int.Parse(Session["parametro"].ToString());

        doc = dac.postObservadorNoticias(doc);


        LB_verPost.Text = doc.Contenido1.ToString();
        LB_autor.Text = doc.Autor1.ToString();

        GV_comentarios.DataSource = dac.obtenerComentario(x);
        GV_comentarios.DataBind();


    }



    protected void B_volver_Click(object sender, EventArgs e)
    {

        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();

        dat = llamado.retornoAdmin();

        Response.Redirect(dat.Link_observador);

    }
}