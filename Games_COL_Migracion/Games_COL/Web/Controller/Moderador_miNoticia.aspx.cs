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
using Persistencia_funciones;

public partial class View_Moderador_miNoticia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        Int32 idioma = 1;
        Int32 id_pagina = 37;
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


        BT_volver.Text = compIdioma["BT_volver"].ToString();
        L_Usercs dac = new L_Usercs();

        
        int dato = int.Parse(Session["id"].ToString());
        DataTable dt = dac.minoticiagv(dato);

        L_persistencia per = new L_persistencia();
        Entity_noticias not = new Entity_noticias();

        try
        {
            int dtr = int.Parse(dt.Rows[0]["id_noticia"].ToString());
            DataTable data = dac.ToDataTable(per.obtenerMinoticia(dato));
            GV_miPost.DataSource = data;
            GV_miPost.DataBind();
        }
        catch (Exception)
        {


        }

    }

    protected void GV_Idioma_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            try
            {
                ((Label)e.Row.FindControl("LB_tit")).Text = ((Hashtable)Session["mensajes"])["LB_tit"].ToString();
                ((Label)e.Row.FindControl("LB_eliminar")).Text = ((Hashtable)Session["mensajes"])["LB_eliminar"].ToString();
                ((Label)e.Row.FindControl("LB_editar")).Text = ((Hashtable)Session["mensajes"])["LB_editar"].ToString();




            }
            catch (Exception exe)
            {
               
                ((Button)e.Row.FindControl("BT_editar")).Text = ((Hashtable)Session["mensajes"])["LB_editar"].ToString();
                ((Button)e.Row.FindControl("BT_eliminar")).Text = ((Hashtable)Session["mensajes"])["LB_eliminar"].ToString();
        
            }
        }
        catch (Exception exx)
        {
        }

    }

    protected void BT_editar_Click(object sender, EventArgs e)
    {



        int b = int.Parse(Session["id"].ToString());
        Button bt = sender as Button;
        GridViewRow grid = (GridViewRow)bt.NamingContainer;
        string IdRecogido = ((Label)grid.FindControl("LB_id")).Text;
        Session["IdRecogido"] = IdRecogido;
        U_user dat = new U_user();
        L_Usercs llamar = new L_Usercs();

        string c = b.ToString();


        dat = llamar.recargaminoticia();

       
        Response.Redirect(dat.Link_observador);
       
    }

    protected void BT_eliminar_Click(object sender, EventArgs e)
    {


      
        Entity_noticias noti = new Entity_noticias();//agregar
        L_persistencia per = new L_persistencia();//agregar
        L_Usercs log = new L_Usercs();


        int b = int.Parse(Session["id"].ToString());
        Button bt = sender as Button;
        GridViewRow grid = (GridViewRow)bt.NamingContainer;
        string IdRecogido = ((Label)grid.FindControl("LB_id")).Text;
        U_userCrearpost post = new U_userCrearpost();
        int x = int.Parse(IdRecogido);
        post.Id = x;
        
        DataTable noticia = log.traerNoticia(x);
        L_Usercs dac = new L_Usercs();
        noti.Id_noticia = x;//agregar
        noti.Titulo = noticia.Rows[0]["titulo"].ToString();
        noti.Contenido = noticia.Rows[0]["contenido"].ToString();
        noti.Fecha = DateTime.Parse(noticia.Rows[0]["fecha"].ToString()) ;
        noti.Autor = int.Parse(noticia.Rows[0]["autor"].ToString());
        Entity_usuario us = new Entity_usuario();
        object obj = new object();
        obj = noti;
        string schema = "usuario";
        string tabla = "noticia";
        us.Nombre = Session["id"].ToString();
        per.auditoriaEliminar(obj, us, schema, tabla);

        per.borrarNoticia(noti);//agregar
        //dac.eliminarminoticia(x);

        U_user dat = new U_user();
        L_Usercs llamar = new L_Usercs();

        string c = b.ToString();


        dat = llamar.recargapgnotimoder();
        Response.Redirect(dat.Link_observador);
        
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();

        dat = llamado.irHomeModerador();

        Response.Redirect(dat.Link_observador );
    }
}