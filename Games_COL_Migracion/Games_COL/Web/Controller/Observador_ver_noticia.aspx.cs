using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;

public partial class View_Observador_ver_noticia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
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
        U_userCrearpost retorno = new U_userCrearpost();
        L_Usercs data = new L_Usercs();

        retorno = data.retornoObservador();
        Response.Redirect(retorno.Link);


    }
}