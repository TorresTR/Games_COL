using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_usuario_editar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        Int32 idioma = 1;
        Int32 id_pagina = 68;
        try
        {
            idioma = Int32.Parse(Session["valor_ddl"].ToString());
        }
        catch
        {
            idioma = 1;
        }

        L_Usercs Idio = new L_Usercs();
        DataTable info = Idio.traducir(id_pagina, idioma);

        Hashtable compIdioma = new Hashtable();
        Session["mensajes"] = compIdioma;
        compIdioma = Idio.hastableIdioma(info, compIdioma);



        Bt_editarCk.Text = compIdioma["BT_editarck"].ToString();
        BT_editar.Text = compIdioma["BT_editar"].ToString();
        BT_volver.Text = compIdioma["BT_volver"].ToString();
        LB_autor.Text = compIdioma["LB_autor"].ToString();


        L_Usercs dac = new L_Usercs();
        U_misPost dato = new U_misPost();
        
        int a = int.Parse(Session["IdRecogido"].ToString());


        dato.Id_mipost = a;

        dato = dac.VerMisdatosaeditar(dato);

        LB_muestraContenido.Text= dato.Contenido;
        LB_verAutor.Text=dato.Autor;
        Ck_editar.Visible=dato.EstadoCK;
        BT_editar.Visible=dato.EstadoBT;

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


        int a = int.Parse(Session["user_id"].ToString());

        string dat = a.ToString();


        U_user data = new U_user();
        L_Usercs llamado = new L_Usercs();

        data = llamado.redireccionMispost();


        Response.Redirect(data.Link_observador );
    }
}