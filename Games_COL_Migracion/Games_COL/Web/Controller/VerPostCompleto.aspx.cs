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

public partial class View_VerPostCompleto : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        Int32 idioma = 1;
        Int32 id_pagina = 84;
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


        LB_titContenido.Text = compIdioma["LB_titContenido"].ToString();
        LB_titAutor.Text = compIdioma["LB_titAutor"].ToString();
        LB_puntos.Text = compIdioma["LB_puntos"].ToString();
        B_volver.Text = compIdioma["B_volver"].ToString();


        U_userCrearpost doc = new U_userCrearpost();
        L_Usercs dac = new L_Usercs();
        

        doc.Id = int.Parse(Session["parametro"].ToString());
        int x = int.Parse(Session["parametro"].ToString());

        doc = dac.postObservador(doc);


        LB_verPost.Text = doc.Contenido1.ToString();
        LB_autor.Text = doc.Autor1.ToString();

         

        LB_muestraPuntos.Text = doc.Totpunt.ToString();
        
        GV_comentarios.DataSource = dac.obtenerComentario(x);
        GV_comentarios.DataBind();
        

    }
    protected void GV_Idioma_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            try
            {
                ((Label)e.Row.FindControl("LB_coment")).Text = ((Hashtable)Session["mensajes"])["LB_coment"].ToString();
                
            }
            catch (Exception exe)
            {

   
            }
        }
        catch (Exception exx)
        {
        }

    }


    protected void B_volver_Click(object sender, EventArgs e)
    {
        U_userCrearpost retorno = new U_userCrearpost();
        L_Usercs data = new L_Usercs();

        retorno = data.retornoObservador();
        Response.Redirect(retorno.Link);

        
    }
}