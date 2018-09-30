using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;
using Datos;
using System.Collections;

public partial class View_verCompletoUserregistrado : System.Web.UI.Page
{
    int x,puntos=0,num=0,tot=0;
    int h = 0;
    int puntos_total=0;
    int val,pun;

    protected void Page_Load(object sender, EventArgs e)
    {


        Response.Cache.SetNoStore();
        Int32 idioma = 1;
        Int32 id_pagina = 83;
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


        LB_titCont.Text = compIdioma["LB_titContenido"].ToString();
        LB_comentar.Text = compIdioma["LB_comentar"].ToString();
        LB_mensaje.Text = compIdioma["LB_mensaje"].ToString();
        LB_titAutor.Text = compIdioma["LB_titAutor"].ToString();
        B_volver.Text = compIdioma["BT_volver"].ToString();
        BT_comentar.Text = compIdioma["BT_comentar"].ToString();
        BT_reporte.Text = compIdioma["BT_reporte"].ToString();
        LB_puntos.Text = compIdioma["LB_puntos"].ToString();



        U_userCrearpost doc = new U_userCrearpost();
      
        L_Usercs log = new L_Usercs();
        D_User dac = new D_User();
        

        int comparador_idpost = int.Parse(Session["parametro"].ToString());
        int comparador_iduser = int.Parse(Session["user_id"].ToString());

        DataTable regisval = dac.obtenerpuntsval(comparador_iduser);

        DataTable data = dac.ObtenerInteraccion(comparador_iduser);
        int inter = int.Parse(data.Rows[0]["id"].ToString());
        U_Interaccion inte = new U_Interaccion();
        inte.Iteraccion = inter;
        inte = log.validarInteraccion(inte);

        
        LB_mensaje.Text = inte.Mensaje;
        TB_comentarios.Visible = inte.Estado;
        LB_comentar.Visible = inte.Estado;
        BT_comentar.Visible = inte.Estado;
        UpdatePanel1.Visible = inte.Estado;
       


        ClientScriptManager cm = this.ClientScript;
        doc.Id = int.Parse(Session["parametro"].ToString());
        int dato = int.Parse(Session["user_id"].ToString());



        DataTable regis = dac.verpag(doc);

        int contadordatos = regisval.Rows.Count;
        int contcolum = regisval.Columns.Count;

        Boolean estado = log.comparaPropioP(regisval, comparador_idpost, comparador_iduser);
       
       
        UpdatePanel1.Visible = estado;


        int b = int.Parse(Session["user_id"].ToString());
        DataTable regis2 = dac.obtenerUss(b);
        String x = regis2.Rows[0]["nick"].ToString();
        String z = regis.Rows[0]["autor"].ToString();


        BT_reporte.Visible = true;

        Boolean est = log.compara(z, x);
        
        BT_reporte.Visible = est;
        UpdatePanel1.Visible = est;



        U_userCrearpost datos = new U_userCrearpost();

        datos = log.comp(regis);
        
        LB_muestraPag.Text = datos.Contenido1;
        LB_autor.Text = datos.Autor1;

        
        
        DataTable punt = dac.verpuntos(doc);
        L_persistencia logica = new L_persistencia();
        datos = log.promedioPunt(punt);
        puntos = datos.PuntosA;
        num = datos.Nump;
        tot = puntos / num;
        LB_motrarPuntos.Text = tot.ToString();

        datos.Comentarios1 = dato;
        GV_comentariosuser.DataSource = logica.obtenerComentario(comparador_idpost);
        GV_comentariosuser.DataBind();



    }
    protected void GV_Idioma_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            try
            {
                ((Label)e.Row.FindControl("LB_reportar")).Text = ((Hashtable)Session["mensajes"])["LB_reportar"].ToString();
                ((Label)e.Row.FindControl("LB_coment")).Text = ((Hashtable)Session["mensajes"])["LB_coment"].ToString();
            }
            catch (Exception exe)
            {

                ((Button)e.Row.FindControl("BT_reportar")).Text = ((Hashtable)Session["mensajes"])["BT_reportar"].ToString();
            }
        }
        catch (Exception exx)
        {
        }

    }

    protected void Bt_uno_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        D_User dac = new D_User();
        U_userCrearpost puntot = new U_userCrearpost();

        int b = int.Parse(Session["user_id"].ToString());
        int bn = int.Parse(Session["parametro"].ToString());
        DataTable punt = dac.ObtenerPuntos(bn);
        DateTime dt = DateTime.Now;
        puntot.Id = int.Parse(Session["parametro"].ToString());
        puntot.Id_user = int.Parse(Session["user_id"].ToString());
        puntot.Fecha = dt;

        U_userCrearpost doc = new U_userCrearpost();
        doc.Id = int.Parse(Session["parametro"].ToString());
        Int32 v = int.Parse(Session["parametro"].ToString());

        DataTable regis = dac.verpag(doc);


        DataTable regis2 = dac.obtenerUss(b);

        puntot.Nick = regis2.Rows[0]["nick"].ToString();
        puntot.Autor1 = regis.Rows[0]["autor"].ToString();

        DataTable data = dac.ObtenerInteraccion(b);
        int inter = int.Parse(data.Rows[0]["id"].ToString());

        L_Usercs llamado = new L_Usercs();

        llamado.puntosBoton(punt, inter, puntot);




        int z = int.Parse(Session["parametro"].ToString());


        DataTable regis3 = dac.obtenerUss(b);
        int x = int.Parse(regis3.Rows[0]["puntos"].ToString());
        int f = int.Parse(regis3.Rows[0]["id"].ToString());

        x = x + 1;





        dac.actualizarpuntoUser(b, x);

        dac.ValidarPuntuacion(b, z);
        string ui = Session["user_id"].ToString();
        string par = Session["parametro"].ToString();


        U_user dat = new U_user();
        L_Usercs llamar = new L_Usercs();

        dat = llamar.redirigirCompletousuarioregistrado();

        Response.Redirect(dat.Link_observador);

    }

    protected void BT_dos_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        D_User dac = new D_User();
        U_userCrearpost puntot = new U_userCrearpost();

        int b = int.Parse(Session["user_id"].ToString());
        int bn = int.Parse(Session["parametro"].ToString());
        DataTable punt = dac.ObtenerPuntos(bn);
        DateTime dt = DateTime.Now;
        puntot.Id = int.Parse(Session["parametro"].ToString());
        puntot.Id_user = int.Parse(Session["user_id"].ToString());
        puntot.Fecha = dt;

        U_userCrearpost doc = new U_userCrearpost();
        doc.Id = int.Parse(Session["parametro"].ToString());
        Int32 v = int.Parse(Session["parametro"].ToString());

        DataTable regis = dac.verpag(doc);


        DataTable regis2 = dac.obtenerUss(b);

        puntot.Nick = regis2.Rows[0]["nick"].ToString();
        puntot.Autor1 = regis.Rows[0]["autor"].ToString();

        DataTable data = dac.ObtenerInteraccion(b);
        int inter = int.Parse(data.Rows[0]["id"].ToString());

        L_Usercs llamado = new L_Usercs();

        llamado.puntosBotonDos(punt, inter, puntot);




        int z = int.Parse(Session["parametro"].ToString());


        DataTable regis3 = dac.obtenerUss(b);
        int x = int.Parse(regis3.Rows[0]["puntos"].ToString());
        int f = int.Parse(regis3.Rows[0]["id"].ToString());

        x = x + 1;





        dac.actualizarpuntoUser(b, x);

        dac.ValidarPuntuacion(b, z);
        string ui = Session["user_id"].ToString();
        string par = Session["parametro"].ToString();


        U_user dat = new U_user();
        L_Usercs llamar = new L_Usercs();

        dat = llamar.redirigirCompletousuarioregistrado();

        Response.Redirect(dat.Link_observador);

    }

    protected void BT_tres_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        D_User dac = new D_User();
        U_userCrearpost puntot = new U_userCrearpost();

        int b = int.Parse(Session["user_id"].ToString());
        int bn = int.Parse(Session["parametro"].ToString());
        DataTable punt = dac.ObtenerPuntos(bn);
        DateTime dt = DateTime.Now;
        puntot.Id = int.Parse(Session["parametro"].ToString());
        puntot.Id_user = int.Parse(Session["user_id"].ToString());
        puntot.Fecha = dt;

        U_userCrearpost doc = new U_userCrearpost();
        doc.Id = int.Parse(Session["parametro"].ToString());
        Int32 v = int.Parse(Session["parametro"].ToString());

        DataTable regis = dac.verpag(doc);


        DataTable regis2 = dac.obtenerUss(b);

        puntot.Nick = regis2.Rows[0]["nick"].ToString();
        puntot.Autor1 = regis.Rows[0]["autor"].ToString();

        DataTable data = dac.ObtenerInteraccion(b);
        int inter = int.Parse(data.Rows[0]["id"].ToString());

        L_Usercs llamado = new L_Usercs();

        llamado.puntosBotonTres(punt, inter, puntot);




        int z = int.Parse(Session["parametro"].ToString());


        DataTable regis3 = dac.obtenerUss(b);
        int x = int.Parse(regis3.Rows[0]["puntos"].ToString());
        int f = int.Parse(regis3.Rows[0]["id"].ToString());

        x = x + 1;





        dac.actualizarpuntoUser(b, x);

        dac.ValidarPuntuacion(b, z);
        string ui = Session["user_id"].ToString();
        string par = Session["parametro"].ToString();


        U_user dat = new U_user();
        L_Usercs llamar = new L_Usercs();

        dat = llamar.redirigirCompletousuarioregistrado();

        Response.Redirect(dat.Link_observador);

    }

    protected void BT_cuatro_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        D_User dac = new D_User();
        U_userCrearpost puntot = new U_userCrearpost();

        int b = int.Parse(Session["user_id"].ToString());
        int bn = int.Parse(Session["parametro"].ToString());
        DataTable punt = dac.ObtenerPuntos(bn);
        DateTime dt = DateTime.Now;
        puntot.Id = int.Parse(Session["parametro"].ToString());
        puntot.Id_user = int.Parse(Session["user_id"].ToString());
        puntot.Fecha = dt;

        U_userCrearpost doc = new U_userCrearpost();
        doc.Id = int.Parse(Session["parametro"].ToString());
        Int32 v = int.Parse(Session["parametro"].ToString());

        DataTable regis = dac.verpag(doc);


        DataTable regis2 = dac.obtenerUss(b);

        puntot.Nick = regis2.Rows[0]["nick"].ToString();
        puntot.Autor1 = regis.Rows[0]["autor"].ToString();

        DataTable data = dac.ObtenerInteraccion(b);
        int inter = int.Parse(data.Rows[0]["id"].ToString());

        L_Usercs llamado = new L_Usercs();

        llamado.puntosBotonCuatro(punt, inter, puntot);




        int z = int.Parse(Session["parametro"].ToString());


        DataTable regis3 = dac.obtenerUss(b);
        int x = int.Parse(regis3.Rows[0]["puntos"].ToString());
        int f = int.Parse(regis3.Rows[0]["id"].ToString());

        x = x + 1;





        dac.actualizarpuntoUser(b, x);

        dac.ValidarPuntuacion(b, z);
        string ui = Session["user_id"].ToString();
        string par = Session["parametro"].ToString();


        U_user dat = new U_user();
        L_Usercs llamar = new L_Usercs();

        dat = llamar.redirigirCompletousuarioregistrado();

        Response.Redirect(dat.Link_observador);


    }

    protected void BT_cinco_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        D_User dac = new D_User();
        U_userCrearpost puntot = new U_userCrearpost();


        int b = int.Parse(Session["user_id"].ToString());
        int bn = int.Parse(Session["parametro"].ToString());
        DataTable punt = dac.ObtenerPuntos(bn);
        DateTime dt = DateTime.Now;
        puntot.Id = int.Parse(Session["parametro"].ToString());
        puntot.Id_user = int.Parse(Session["user_id"].ToString());
        puntot.Fecha = dt;

        U_userCrearpost doc = new U_userCrearpost();
        doc.Id = int.Parse(Session["parametro"].ToString());
        Int32 v = int.Parse(Session["parametro"].ToString());

        DataTable regis = dac.verpag(doc);


        DataTable regis2 = dac.obtenerUss(b);

        puntot.Nick = regis2.Rows[0]["nick"].ToString();
        puntot.Autor1 = regis.Rows[0]["autor"].ToString();

        DataTable data = dac.ObtenerInteraccion(b);
        int inter = int.Parse(data.Rows[0]["id"].ToString());

        L_Usercs llamado = new L_Usercs();

        llamado.puntosBotonCinco(punt, inter, puntot);




        int z = int.Parse(Session["parametro"].ToString());


        DataTable regis3 = dac.obtenerUss(b);
        int x = int.Parse(regis3.Rows[0]["puntos"].ToString());
        int f = int.Parse(regis3.Rows[0]["id"].ToString());

        x = x + 1;





        dac.actualizarpuntoUser(b, x);

        dac.ValidarPuntuacion(b, z);
        string ui = Session["user_id"].ToString();
        string par = Session["parametro"].ToString();





        U_user dat = new U_user();
        L_Usercs llamar = new L_Usercs();

        dat = llamar.redirigirCompletousuarioregistrado();

        Response.Redirect(dat.Link_observador);

    }


    protected void BT_comentar_Click(object sender, EventArgs e)
    {
        L_Usercs log = new L_Usercs();
        U_comentarios coment = new U_comentarios();
        D_User dac = new D_User();
        Entity_comentarios comentario = new Entity_comentarios();
        L_persistencia logica = new L_persistencia();


        int b = int.Parse(Session["user_id"].ToString());
        DateTime dt = DateTime.Now;

        coment.Id_user = int.Parse(Session["user_id"].ToString());

        comentario.Comentario = TB_comentarios.Text.ToString();
        comentario.Id_post = int.Parse(Session["parametro"].ToString());
        comentario.Id_user = int.Parse(Session["user_id"].ToString());
        comentario.Estado = 1;

        logica.insertarComenatrio(comentario);

        DataTable data =dac.ObtenerInteraccion(b);
        int inter = int.Parse(data.Rows[0]["id"].ToString());

        string mensaje = log.comentar(inter, coment );
        
            LB_mensaje.Text =mensaje;
        
        

        string q = Session["user_id"].ToString();
        string z = Session["parametro"].ToString();
        

        U_user dat = new U_user();
        L_Usercs llamar = new L_Usercs();

        dat = llamar.redirigirCompletousuarioregistrado();

        Response.Redirect(dat.Link_observador);

    }



    protected void B_volver_Click(object sender, EventArgs e)
    {

        string z = Session["user_id"].ToString();


        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();

        dat = llamado.volverUsuariosRegistrado();

        Response.Redirect(dat.Link_observador);

    }

    protected void BT_reporte_Click(object sender, EventArgs e)
    {

        string q = Session["user_id"].ToString();
        string z = Session["parametro"].ToString();

        

        L_Usercs data = new L_Usercs();
        U_user dat = new U_user();

        dat = data.reporteUsuariopost();

        Response.Redirect( dat.Link_observador );

    }
   
    protected void BT_reportar_Click(object sender, EventArgs e)
    {

        Button bt = (Button)sender;
        TableCell tableCell = (TableCell)bt.Parent;
        GridViewRow row = (GridViewRow)tableCell.Parent;
        GV_comentariosuser.SelectedIndex = row.RowIndex;
        int fila = row.RowIndex;

       
        string q = Session["user_id"].ToString();
        string z = Session["parametro"].ToString();

        string IdRecogido = ((Label)row.Cells[fila].FindControl("Label1")).Text.ToString();
        Session["IdRecogido"] = IdRecogido;
        

        L_Usercs data = new L_Usercs();
        U_user dat = new U_user();

        dat = data.reporteUsuariocoment();

        Response.Redirect(dat.Link_observador);


    }



}