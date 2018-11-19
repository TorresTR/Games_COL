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
public partial class View_Moderador_editar_Noticia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Cache.SetNoStore();
        Int32 idioma = 1;
        Int32 id_pagina = 34;
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


        Bt_editarCk.Text = compIdioma["Bt_editarCk"].ToString();
        BT_editar.Text = compIdioma["BT_editar"].ToString();
        BT_volver.Text = compIdioma["BT_volver"].ToString();
        LB_autor.Text = compIdioma["LB_autor"].ToString();


        U_userCrearpost doc = new U_userCrearpost();
        L_Usercs dac = new L_Usercs();


        doc.Id = int.Parse(Session["IdRecogido"].ToString());
        int x = int.Parse(Session["id"].ToString());

        doc = dac.postObservadorNoticias(doc);


        LB_muestraContenido.Text = doc.Contenido1.ToString();
        LB_verAutor.Text = doc.Autor1.ToString();
        Ck_editar.Visible = false;
        BT_editar.Visible = false;
        

    }

    protected void BT_editar_Click(object sender, EventArgs e)
    {


        L_Usercs dac = new L_Usercs();
        U_userCrearpost post = new U_userCrearpost();
        L_persistencia per = new L_persistencia();//agregar
        Entity_noticias noti = new Entity_noticias();//agregar
        Entity_noticias noti2 = new Entity_noticias();//agregar

        post.Id = int.Parse(Session["IdRecogido"].ToString());
        post.Contenido1 = Ck_editar.Text.ToString();

        DataTable data = dac.traerNoticia(int.Parse(Session["IdRecogido"].ToString()));//agregar

        noti2.Id_noticia = int.Parse(Session["IdRecogido"].ToString());
        noti2.Titulo = data.Rows[0]["titulo"].ToString();//agregar
        noti2.Contenido = data.Rows[0]["contenido"].ToString();
        noti2.Fecha = DateTime.Parse(data.Rows[0]["fecha"].ToString());//agregar
        noti2.Autor = int.Parse(data.Rows[0]["autor"].ToString());//agregar

        noti.Id_noticia = int.Parse(Session["IdRecogido"].ToString());//agregar
        noti.Titulo = data.Rows[0]["titulo"].ToString();//agregar
        noti.Contenido = Ck_editar.Text.ToString();//agregar
        noti.Fecha = DateTime.Parse(data.Rows[0]["fecha"].ToString());//agregar
        noti.Autor = int.Parse(data.Rows[0]["autor"].ToString());//agregar


        object objOld = new object();
        objOld = noti2;
        object objNew = new object();
        objNew = noti;
        string schema = "usuario";
        string tabla = "noticia";
        Entity_usuario us = new Entity_usuario();
        us.Nombre = Session["id"].ToString();
        per.auditoriaModificar(objNew, objOld, us, schema, tabla);

        per.actualizarMiNoticia(noti);//agregar


        //dac.actualizaModernoticia(post);

    }

    protected void Bt_editarCk_Click(object sender, EventArgs e)
    {
        Ck_editar.Text = LB_muestraContenido.Text;
        Ck_editar.Visible = true;
        BT_editar.Visible = true;
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();

        dat = llamado.recargapgnotimoder();

        Response.Redirect(dat.Link_observador);
    }
}