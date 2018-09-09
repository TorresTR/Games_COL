using Logica;
using Utilitarios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Adminsitrador_editar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();




        L_Usercs dac = new L_Usercs();
        U_misPost dato = new U_misPost();

        int a = int.Parse(Session["IdRecogido"].ToString());


        dato.Id_mipost = a;

        dato = dac.VerMisdatosaeditar(dato);

        LB_muestraContenido.Text = dato.Contenido;
        LB_verAutor.Text = dato.Autor;
        Ck_editar.Visible = dato.EstadoCK;
        BT_editar.Visible = dato.EstadoBT;
    }

    protected void BT_editar_Click(object sender, EventArgs e)
    {


        L_Usercs dac = new L_Usercs();
        U_userCrearpost post = new U_userCrearpost();

        post.Id = int.Parse(Session["IdRecogido"].ToString());
        post.Contenido1 = Ck_editar.Text.ToString();

        dac.actualizarMispost(post);
    }

    protected void Bt_editarCk_Click(object sender, EventArgs e)
    {
        Ck_editar.Text = LB_muestraContenido.Text;
        Ck_editar.Visible = true;
        BT_editar.Visible = true;
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {


        U_user data = new U_user();
        L_Usercs llamado = new L_Usercs();

        data = llamado.administrarMiPost();


        Response.Redirect(data.Link_observador );
    }
}