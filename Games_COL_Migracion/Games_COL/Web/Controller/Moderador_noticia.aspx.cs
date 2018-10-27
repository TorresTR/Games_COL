using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Persistencia_funciones;
using Utilitarios;

public partial class View_Moderador_noticia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        Int32 idioma = 1;
        Int32 id_pagina =39 ;
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


        LB_tiitulo.Text = compIdioma["LB_titulo"].ToString();
        LB_Contenido.Text = compIdioma["LB_Contenido"].ToString();
        BT_vistaPrevia.Text = compIdioma["BT_vistaPrevia"].ToString();
        BT_guardar.Text = compIdioma["BT_guardar"].ToString();
        B_volver.Text = compIdioma["B_volver"].ToString();
    }

    protected void BT_vistaPrevia_Click(object sender, EventArgs e)
    {
        LB_vistaPrev.Text = Ckeditor1.Text;
    }

    protected void BT_guardar_Click(object sender, EventArgs e)
    {


        U_userCrearpost datos_creartPost = new U_userCrearpost();
        L_Usercs data_userPost = new L_Usercs();
        L_persistencia per = new L_persistencia();//agregar
        Entity_noticias noti = new Entity_noticias();//agregar

        int b = int.Parse(Session["id"].ToString());
        int g = 1;
        DateTime dt = DateTime.Now;

        datos_creartPost.Titulo = TB_titulo.Text.ToString();
        datos_creartPost.Contenido1 = Ckeditor1.Text.ToString();
        datos_creartPost.Fecha = dt;
        datos_creartPost.Id_user = b;

        noti.Titulo = TB_titulo.Text.ToString();//AGREGAR
        noti.Contenido = Ckeditor1.Text.ToString();//AGREGAR
        noti.Fecha = dt;//AGREGAR
        noti.Autor = b;//AGREGAR


        Entity_usuario us = new Entity_usuario();
        us.Nombre = Session["id"].ToString();
        object segurity = new object();
        segurity = noti;
        string schema = "usuario";
        string tabla = "noticias";
        per.auditoriaInsertar(segurity, us, schema, tabla);

        per.insertarNoticia(noti);//AGREGAR

        //data_userPost.insertarNoticias(datos_creartPost);

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