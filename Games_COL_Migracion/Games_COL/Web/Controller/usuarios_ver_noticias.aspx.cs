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

public partial class View_usuarios_ver_noticias : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        Int32 idioma = 1;
        Int32 id_pagina = 81;
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


        LB_titAutor.Text = compIdioma["LB_titAutor"].ToString();
        B_volver.Text = compIdioma["B_volver"].ToString();
        LB_titCont.Text = compIdioma["LB_titCont"].ToString();


        U_userCrearpost doc = new U_userCrearpost();
        L_Usercs dac = new L_Usercs();


        doc.Id = int.Parse(Session["parametro"].ToString());
        int x = int.Parse(Session["parametro"].ToString());

        doc = dac.postObservadorNoticias(doc);


        LB_verPost.Text = doc.Contenido1.ToString();
        LB_autor.Text = doc.Autor1.ToString();




    }



    protected void B_volver_Click(object sender, EventArgs e)
    {
        U_user dat = new U_user();
        L_Usercs llamar = new L_Usercs();

        dat = llamar.volverUsuariosRegistrado();

        Response.Redirect(dat.Link_observador);

    }
}