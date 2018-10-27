using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using Logica;
using Utilitarios;
using System.Web.UI.WebControls;
using System.Collections;
using Persistencia_funciones;

public partial class View_Administrador_editar_noticia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        Response.Cache.SetNoStore();


        Int32 idioma = 1;
        Int32 id_pagina = 8;
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



        LB_autor.Text = compIdioma["LB_autor"].ToString();
        Bt_editarCk.Text = compIdioma["Bt_editarCk"].ToString();
        BT_volver.Text = compIdioma["BT_volver"].ToString();
        BT_editar.Text = compIdioma["BT_editar"].ToString();
       



        U_userCrearpost doc = new U_userCrearpost();
        L_Usercs dac = new L_Usercs();


        doc.Id = int.Parse(Session["parametro"].ToString());
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
        U_user link = new U_user();
        L_persistencia per = new L_persistencia();//agregar
        Entity_noticias noti = new Entity_noticias();//agregar

        post.Id = int.Parse(Session["parametro"].ToString());
        post.Contenido1 = Ck_editar.Text.ToString();

        DataTable data = dac.traerNoticia(int.Parse(Session["parametro"].ToString()));//agregar

        noti.Id_noticia = int.Parse(Session["parametro"].ToString());//agregar
        noti.Titulo = data.Rows[0]["titulo"].ToString();//agregar
        noti.Contenido = Ck_editar.Text.ToString();//agregar
        noti.Fecha = DateTime.Parse(data.Rows[0]["fecha"].ToString());//agregar
        noti.Autor = int.Parse(data.Rows[0]["autor"].ToString());//agregar

        per.actualizarMiNoticia(noti);//agregar


        //dac.actualizaModernoticia(post);
        link = dac.miNoticia();

        Response.Redirect(link.Link_observador);

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


        dat = llamado.miNoticia();

        Response.Redirect(dat.Link_observador);

    }

  
}