using Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;
using System.Collections;

public partial class View_Administrador_crear_post : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        Response.Cache.SetNoStore();



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

        Hashtable compIdioma = new Hashtable();
        Session["mensajes"] = compIdioma;
        compIdioma = Idio.hastableIdioma(info, compIdioma);


      
        LB_tiitulo.Text = compIdioma["LB_titulo"].ToString();
        LB_Contenido.Text= compIdioma["LB_contenido"].ToString();
        LB_etiqueta.Text = compIdioma["LB_etiqueta"].ToString();
        BT_guardar.Text = compIdioma["BT_guardar"].ToString(); 
        BT_vistaPrevia.Text = compIdioma["BT_vistaPrevia"].ToString(); 
        B_volver.Text = compIdioma["B_volver"].ToString(); 
       
        L_Usercs dac = new L_Usercs();
        int b = int.Parse(Session["user_id"].ToString());
        DataTable data = dac.obtenerInteraccion(b);
        U_Interaccion iter = new U_Interaccion();

        iter.Iteraccion = int.Parse(data.Rows[0]["id"].ToString());

        iter = dac.validarInteraccion(iter);


        LB_tiitulo.Visible = iter.Estado;
        TB_titulo.Visible = iter.Estado;
        LB_etiqueta.Visible = iter.Estado;
        DDL_etiquetas.Visible = iter.Estado;
        Ckeditor1.Visible = iter.Estado;
        LB_Contenido.Visible = iter.Estado;
        BT_guardar.Visible = iter.Estado;
        BT_vistaPrevia.Visible = iter.Estado;
        //LB_mensaje.Text = iter.Mensaje;
    }

    protected void BT_vistaPrevia_Click(object sender, EventArgs e)
    {
        LB_vistaPrev.Text = Ckeditor1.Text;
    }

    protected void BT_guardar_Click(object sender, EventArgs e)
    {
        U_userCrearpost datos_creartPost = new U_userCrearpost();
        L_Usercs data_userPost = new L_Usercs();

       
        int b = int.Parse(Session["user_id"].ToString());


        DataTable regis = data_userPost.obtenerUsercrear(b);

        int x = int.Parse(regis.Rows[0]["puntos"].ToString());


        DateTime dt = DateTime.Now;
        ClientScriptManager cm = this.ClientScript;
        DataTable data = data_userPost.obtenerInteraccion(b);

        U_Interaccion iter = new U_Interaccion();

        iter.Iteraccion = int.Parse(data.Rows[0]["id"].ToString());

        iter = data_userPost.validarInteraccion(iter);

        datos_creartPost.Titulo = TB_titulo.Text.ToString();
        datos_creartPost.Contenido1 = Ckeditor1.Text.ToString();
        datos_creartPost.Fecha = dt;
        datos_creartPost.Id_user = b;
        datos_creartPost.Id_etiqueta = int.Parse(DDL_etiquetas.SelectedValue.ToString());
        datos_creartPost.Interacciones = iter.Contador;

        x = x + 1;

        data_userPost.actualizarpuntoUser(b, x);
        data_userPost.insertarPost(datos_creartPost);

        cm.RegisterClientScriptBlock(this.GetType(), "", iter.Mensaje);




        TB_titulo.Text = "";
        Ckeditor1.Text = "";
        U_user link = new U_user();
        link = data_userPost.retornoAdmin();
        Response.Redirect(link.Link_observador);
    }

    protected void B_volver_Click(object sender, EventArgs e)
    {
        
        TB_titulo.Text = "";
        Ckeditor1.Text = "";
        L_Usercs data = new L_Usercs();
        U_user link = new U_user();
        link = data.retornoAdmin();
        Response.Redirect(link.Link_observador);
    }
}