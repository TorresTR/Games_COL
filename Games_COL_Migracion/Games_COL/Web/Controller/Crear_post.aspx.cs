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

public partial class View_Crear_post : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Int32 idioma = 1;
        Int32 id_pagina = 5;
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
        L_persistencia per = new L_persistencia();//agregar

        U_Datos udato = new U_Datos();

        try
        {
            udato.Sesion = Session["id"].ToString();
            udato = Idio.validarCerrarsesion(udato);
            udato.Sesion = Session["id"].ToString();
        }
        catch (Exception)
        {

            udato = Idio.validarCerrarsesion(udato);
            Response.Redirect(udato.Link);
        }

        Hashtable compIdioma = new Hashtable();
        Session["mensajes"] = compIdioma;
        compIdioma = Idio.hastableIdioma(info, compIdioma);


        LB_etiqueta.Text = compIdioma["LB_etiqueta"].ToString();
        LB_Contenido.Text = compIdioma["LB_contenido"].ToString();
        BT_guardar.Text = compIdioma["BT_guardar"].ToString();
        BT_vistaPrevia.Text = compIdioma["BT_vistaPrevia"].ToString();
        B_volver.Text = compIdioma["B_volver"].ToString();
        LB_tiitulo.Text = compIdioma["LB_titulo"].ToString();

        Response.Cache.SetNoStore();
        L_Usercs dac = new L_Usercs();
        int b = int.Parse(Session["id"].ToString());
        //DataTable data = dac.obtenerInteraccion(b);
        DataTable datos = per.obtenerUs(b);//agregar
        U_Interaccion iter = new U_Interaccion();

        


        
        iter.Iteraccion = int.Parse(datos.Rows[0]["interacciones"].ToString());//agregar
        //iter.Iteraccion = int.Parse(data.Rows[0]["id"].ToString());

        iter = dac.validarInteraccion(iter);

        
            LB_tiitulo.Visible = iter.Estado;
            TB_titulo.Visible = iter.Estado;
            LB_etiqueta.Visible = iter.Estado;
            DDL_etiquetas.Visible = iter.Estado;
            Ckeditor1.Visible = iter.Estado;
            LB_Contenido.Visible = iter.Estado;
            BT_guardar.Visible = iter.Estado;
            BT_vistaPrevia.Visible = iter.Estado;
            LB_mensaje.Text = iter.Mensaje;
        
    }

    protected void BT_vistaPrevia_Click(object sender, EventArgs e)
    {
        LB_vistaPrev.Text = Ckeditor1.Text ;
    }

    protected void BT_guardar_Click(object sender, EventArgs e)
    {
        Entity_post datos_creartPost = new Entity_post();
        L_Usercs data_userPost = new L_Usercs();
        L_persistencia log = new L_persistencia();

        int b = int.Parse(Session["id"].ToString());
        

        DataTable regis = log.obtenerUs(b);//agregar
        //DataTable regis = data_userPost.obtenerUsercrear(b);

        int x = int.Parse(regis.Rows[0]["puntos"].ToString());


        DateTime dt = DateTime.Now;
        ClientScriptManager cm = this.ClientScript;
        DataTable data = data_userPost.obtenerInteraccion(b);

        U_Interaccion iter = new U_Interaccion();

        iter.Iteraccion = int.Parse(data.Rows[0]["interacciones"].ToString());

        iter = data_userPost.validarInteraccion(iter);

        datos_creartPost.Titulo = TB_titulo.Text.ToString();
        datos_creartPost.Contenido = Ckeditor1.Text.ToString();
        datos_creartPost.Fecha = dt;
        datos_creartPost.Autor = b;
        datos_creartPost.Etiqueta = int.Parse(DDL_etiquetas.SelectedValue.ToString());
        datos_creartPost.Puntos = 1;
        datos_creartPost.Estado_bloqueo = 1;
        datos_creartPost.Num_puntos = 1;
            
            //datos_creartPost. = iter.Contador;

            x = x + 1;
       
        L_persistencia per = new L_persistencia();
        Entity_usuario user_ent = new Entity_usuario();

        DataTable datat = data_userPost.obtenerUsuario(b);

        user_ent.Id = b;
        user_ent.Nombre = datat.Rows[0]["nombre"].ToString();
        user_ent.Nick = datat.Rows[0]["nick"].ToString();
        user_ent.Correo = datat.Rows[0]["correo"].ToString();
        user_ent.Contra = datat.Rows[0]["contra"].ToString();
        user_ent.Puntos = x;
        user_ent.Id_rol = int.Parse(datat.Rows[0]["id_rol"].ToString());
        user_ent.Id_rango = int.Parse(datat.Rows[0]["id_rango"].ToString());
        user_ent.Estado = int.Parse(datat.Rows[0]["estado"].ToString());
        user_ent.Session = datat.Rows[0]["session"].ToString();
        user_ent.Interacciones = int.Parse(datat.Rows[0]["interacciones"].ToString());
        user_ent.Fecha_interaccion = DateTime.Parse(datat.Rows[0]["fecha_interaccion"].ToString());

        per.actualizarUsuario(user_ent);
        //data_userPost.actualizarpuntoUser(b, x);
        Entity_usuario us = new Entity_usuario();
        us.Nombre = Session["id"].ToString();
        object post = new object();
        post = datos_creartPost;
        string schema = "usuario";
        string tabla = "post";
        log.auditoriaInsertar(post, us,schema,tabla);

        log.insertarPost(datos_creartPost);

        
            cm.RegisterClientScriptBlock(this.GetType(), "",iter.Mensaje);
       

        TB_titulo.Text = "";
        Ckeditor1.Text = "";
        U_user link = new U_user();
        link = data_userPost.retornoUsuario();
        Response.Redirect( link.Link_observador );

    }

    protected void B_volver_Click(object sender, EventArgs e)
    {
 
        TB_titulo.Text = "";
        Ckeditor1.Text = "";
        L_Usercs data = new L_Usercs();
        U_user link = new U_user();
        link = data.retornoUsuario();
        Response.Redirect(link.Link_observador);
    }
}