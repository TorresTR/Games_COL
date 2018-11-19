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
using Datos;
using System.Collections;
using Persistencia_funciones;

public partial class Plantilla_Administrador_verCompleto : System.Web.UI.Page
{
    int x, puntos = 0, num = 0, tot = 0;
    int h = 0;
    int puntos_total = 0;
    int val, pun;

    protected void Page_Load(object sender, EventArgs e) 
    {


        Response.Cache.SetNoStore();

        Int32 idioma = 1;
        Int32 id_pagina = 23;
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


        LB_titAutor.Text = compIdioma["LB_titAutor"].ToString();
        LB_titCont.Text = compIdioma["LB_titCont"].ToString();
        LB_puntos.Text = compIdioma["LB_titAutor"].ToString();
        LB_comentar.Text = compIdioma["LB_comentar"].ToString();
        BT_reporte.Text = compIdioma["BT_reporte"].ToString();
        BT_comentar.Text = compIdioma["BT_comentar"].ToString();
        B_volver.Text = compIdioma["BT_volver"].ToString();


        U_userCrearpost doc = new U_userCrearpost();
        L_Usercs log = new L_Usercs();
        Dsql dac = new Dsql();
        Entity_puntuacion punto_per = new Entity_puntuacion();
        L_persistencia logica = new L_persistencia();

        int comparador_idpost = int.Parse(Session["parametro"].ToString());
        int comparador_iduser = int.Parse(Session["id"].ToString());


        DataTable regisval = log.ToDataTable(logica.obtenerPuntos(comparador_iduser));

        DataTable data = dac.ObtenerInteraccion(comparador_iduser);
        int inter = int.Parse(data.Rows[0]["interacciones"].ToString());
        U_Interaccion inte = new U_Interaccion();
        inte.Iteraccion = inter;
        inte = log.validarInteraccion(inte);


        LB_mensaje.Text = inte.Mensaje;
        Response.Write("<Script Language='JavaScript'>parent.alert('"+ inte.Mensaje + "');</Script>");
        TB_comentarios.Visible = inte.Estado;
        LB_comentar.Visible = inte.Estado;
        BT_comentar.Visible = inte.Estado;
        UpdatePanel1.Visible = inte.Estado;



        ClientScriptManager cm = this.ClientScript;
        doc.Id = int.Parse(Session["parametro"].ToString());
        int dato = int.Parse(Session["id"].ToString());



        DataTable regis = dac.verpag(doc);

        int contadordatos = regisval.Rows.Count;
        int contcolum = regisval.Columns.Count;

        Boolean estado = log.comparaPropioP(regisval, comparador_idpost, comparador_iduser);


        UpdatePanel1.Visible = estado;
        L_persistencia per = new L_persistencia();//agregar

        int b = int.Parse(Session["id"].ToString());
        DataTable regis2 = per.obtenerUs(b);//agregar
        string x, z;
        try
        {
            x = regis2.Rows[0]["nick"].ToString();
            z = regis.Rows[0]["nick"].ToString();
        }
        catch (Exception)
        {

            x = regis2.Rows[0]["nick"].ToString();
            z = "";
        }


        BT_reporte.Visible = true;

        Boolean est = log.compara(z, x);

        BT_reporte.Visible = est;
        UpdatePanel1.Visible = est;



        U_userCrearpost datos = new U_userCrearpost();

        datos = log.comp(regis);

        LB_muestraPag.Text = datos.Contenido1;
        LB_autor.Text = datos.Autor1;

        

        DataTable punt = dac.verpuntos(doc);
        datos = log.promedioPunt(punt);
        puntos = datos.PuntosA;
        num = datos.Nump;
        tot = puntos ;
        LB_motrarPuntos.Text = tot.ToString();

        datos.Comentarios1 = dato;
        GV_comentariosuser.DataSource = logica.obtenerComentario(comparador_idpost);
        GV_comentariosuser.DataBind();



    }

    protected void GV_comentarios_RowDataBound(object sender, GridViewRowEventArgs e)
    {
     
        try
        {
            try
            {
                ((Label)e.Row.FindControl("LB_reportar")).Text = ((Hashtable)Session["mensajes"])["LB_reportar"].ToString();
                ((Label)e.Row.FindControl("LB_comentar")).Text = ((Hashtable)Session["mensajes"])["LB_com"].ToString();
                ((Button)e.Row.FindControl("BT_reportar")).Text = ((Hashtable)Session["mensajes"])["BT_reportar"].ToString();

            }
            catch (Exception exe)
            {
                ((Button)e.Row.FindControl("BT_reportar")).Text = ((Hashtable)Session["mensajes"])["LB_reportar"].ToString();
                

            }
        }
        catch (Exception exx)
        {
        }

    }


    protected void Bt_uno_Click(object sender, EventArgs e)
    {


        ClientScriptManager cm = this.ClientScript;
        Dsql dac = new Dsql();
        U_userCrearpost puntot = new U_userCrearpost();
        

        int b = int.Parse(Session["id"].ToString());
        int bn = int.Parse(Session["parametro"].ToString());
        L_Usercs dec = new L_Usercs();//agregar
        L_persistencia per = new L_persistencia();//agregar
        DataTable punt = dec.ToDataTable(per.obtenerPostEsp(bn));//agregar
        DataTable us = per.obtenerUs(b);//agregar
        //DataTable punt = dac.ObtenerPuntos(bn);
        DateTime dt = DateTime.Now;
        puntot.Id = int.Parse(Session["parametro"].ToString());
        puntot.Id_user = int.Parse(Session["id"].ToString());
        puntot.Fecha = dt;

        U_userCrearpost doc = new U_userCrearpost();
        doc.Id = int.Parse(Session["parametro"].ToString());
        Int32 v = int.Parse(Session["parametro"].ToString());

        DataTable regis = dac.verpag(doc);


        DataTable regis2 = per.obtenerUs(b);//agregar

        puntot.Nick = regis2.Rows[0]["nick"].ToString();
        puntot.Autor1 = regis.Rows[0]["nick"].ToString();

        DataTable data = dac.ObtenerInteraccion(b);
        int inter = int.Parse(data.Rows[0]["interacciones"].ToString());

        L_Usercs llamado = new L_Usercs();

        llamado.puntosBoton(punt, inter, puntot, us);//AGREGAR




        int z = int.Parse(Session["parametro"].ToString());


        DataTable regis3 = per.obtenerUs(b);//agregar
        int x = int.Parse(regis3.Rows[0]["puntos"].ToString());
        int f = int.Parse(regis3.Rows[0]["id"].ToString());
        Entity_puntuacion pun = new Entity_puntuacion();//agregar
        pun.Id_usuario = b;//agregar
        pun.Id_post = z;//agregar


        Entity_usuario usw = new Entity_usuario();
        usw.Nombre = Session["id"].ToString();
        object segurity = new object();
        segurity = pun;
        string schema = "usuario";
        string tabla = "puntuacion";
        per.auditoriaInsertar(segurity, usw, schema, tabla);

        per.insertarPuntuacion(pun);//agregar
        x = x + 1;


        L_Usercs data_userPost = new L_Usercs();
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

        Entity_usuario user_ent1 = new Entity_usuario();
        user_ent1.Id = b;
        user_ent1.Nombre = datat.Rows[0]["nombre"].ToString();
        user_ent1.Nick = datat.Rows[0]["nick"].ToString();
        user_ent1.Correo = datat.Rows[0]["correo"].ToString();
        user_ent.Contra = datat.Rows[0]["contra"].ToString();
        user_ent1.Puntos = int.Parse(datat.Rows[0]["puntos"].ToString());
        user_ent1.Id_rol = int.Parse(datat.Rows[0]["id_rol"].ToString());
        user_ent1.Id_rango = int.Parse(datat.Rows[0]["id_rango"].ToString());
        user_ent1.Estado = int.Parse(datat.Rows[0]["estado"].ToString());
        user_ent1.Session = datat.Rows[0]["session"].ToString();
        user_ent1.Interacciones = int.Parse(datat.Rows[0]["interacciones"].ToString());
        user_ent1.Fecha_interaccion = DateTime.Parse(datat.Rows[0]["fecha_interaccion"].ToString());

        object objOld = new object();
        objOld = user_ent1;
        object objNew = new object();
        objNew = user_ent;
        string table = "usuario";
       // per.auditoriaModificar(objNew, objOld, usw, schema, table);

        per.actualizarUsuario(user_ent);

        //dac.actualizarpuntoUser(b, x);

        dac.ValidarPuntuacion(b, z);
        string ui = Session["id"].ToString();
        string par = Session["parametro"].ToString();

       



        U_user dat = new U_user();
        L_Usercs llamar = new L_Usercs();

        dat = llamar.redirigirCompletoAdmin();

        Response.Redirect(dat.Link_observador );

    }

    protected void BT_dos_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        Dsql dac = new Dsql();
        U_userCrearpost puntot = new U_userCrearpost();
       

        int b = int.Parse(Session["id"].ToString());
        int bn = int.Parse(Session["parametro"].ToString());
        L_Usercs dec = new L_Usercs();//agregar
        L_persistencia per = new L_persistencia();//agregar
        DataTable punt = dec.ToDataTable(per.obtenerPostEsp(bn));//agregar
        DataTable us = per.obtenerUs(b);//agregar
        //DataTable punt = dac.ObtenerPuntos(bn);
        DateTime dt = DateTime.Now;
        puntot.Id = int.Parse(Session["parametro"].ToString());
        puntot.Id_user = int.Parse(Session["id"].ToString());
        puntot.Fecha = dt;

        U_userCrearpost doc = new U_userCrearpost();
        doc.Id = int.Parse(Session["parametro"].ToString());
        Int32 v = int.Parse(Session["parametro"].ToString());

        DataTable regis = dac.verpag(doc);


        DataTable regis2 = per.obtenerUs(b);//agregar

        puntot.Nick = regis2.Rows[0]["nick"].ToString();
        puntot.Autor1 = regis.Rows[0]["nick"].ToString();

        DataTable data = dac.ObtenerInteraccion(b);
        int inter = int.Parse(data.Rows[0]["interacciones"].ToString());

        L_Usercs llamado = new L_Usercs();

        llamado.puntosBotonDos(punt, inter, puntot, us);//agregar




        int z = int.Parse(Session["parametro"].ToString());


        DataTable regis3 = per.obtenerUs(b);//agregar
        int x = int.Parse(regis3.Rows[0]["puntos"].ToString());
        int f = int.Parse(regis3.Rows[0]["id"].ToString());
        Entity_puntuacion pun = new Entity_puntuacion();//agregar
        pun.Id_usuario = b;//agregar
        pun.Id_post = z;//agregar
        Entity_usuario usw = new Entity_usuario();
        usw.Nombre = Session["id"].ToString();
        object segurity = new object();
        segurity = pun;
        string schema = "usuario";
        string tabla = "puntuacion";
        per.auditoriaInsertar(segurity, usw, schema, tabla);
        per.insertarPuntuacion(pun);//agregar
        x = x + 1;



        L_Usercs data_userPost = new L_Usercs();
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

        Entity_usuario user_ent1 = new Entity_usuario();
        user_ent1.Id = b;
        user_ent1.Nombre = datat.Rows[0]["nombre"].ToString();
        user_ent1.Nick = datat.Rows[0]["nick"].ToString();
        user_ent1.Correo = datat.Rows[0]["correo"].ToString();
        user_ent.Contra = datat.Rows[0]["contra"].ToString();
        user_ent1.Puntos = int.Parse(datat.Rows[0]["puntos"].ToString());
        user_ent1.Id_rol = int.Parse(datat.Rows[0]["id_rol"].ToString());
        user_ent1.Id_rango = int.Parse(datat.Rows[0]["id_rango"].ToString());
        user_ent1.Estado = int.Parse(datat.Rows[0]["estado"].ToString());
        user_ent1.Session = datat.Rows[0]["session"].ToString();
        user_ent1.Interacciones = int.Parse(datat.Rows[0]["interacciones"].ToString());
        user_ent1.Fecha_interaccion = DateTime.Parse(datat.Rows[0]["fecha_interaccion"].ToString());

        object objOld = new object();
        objOld = user_ent1;
        object objNew = new object();
        objNew = user_ent;
        string table = "usuario";
       // per.auditoriaModificar(objNew, objOld, usw, schema, table);
        per.actualizarUsuario(user_ent);
        //dac.actualizarpuntoUser(b, x);

        dac.ValidarPuntuacion(b, z);
        string ui = Session["id"].ToString();
        string par = Session["parametro"].ToString();

    
        U_user dat = new U_user();
        L_Usercs llamar = new L_Usercs();

        dat = llamar.redirigirCompletoAdmin();

        Response.Redirect(dat.Link_observador );
    }

    protected void BT_tres_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        Dsql dac = new Dsql();
        U_userCrearpost puntot = new U_userCrearpost();
       

        int b = int.Parse(Session["id"].ToString());
        int bn = int.Parse(Session["parametro"].ToString());
        L_Usercs dec = new L_Usercs();//agregar
        L_persistencia per = new L_persistencia();//agregar
        DataTable punt = dec.ToDataTable(per.obtenerPostEsp(bn));//agregar
        DataTable us = per.obtenerUs(b);//agregar
        //DataTable punt = dac.ObtenerPuntos(bn);
        DateTime dt = DateTime.Now;
        puntot.Id = int.Parse(Session["parametro"].ToString());
        puntot.Id_user = int.Parse(Session["id"].ToString());
        puntot.Fecha = dt;

        U_userCrearpost doc = new U_userCrearpost();
        doc.Id = int.Parse(Session["parametro"].ToString());
        Int32 v = int.Parse(Session["parametro"].ToString());

        DataTable regis = dac.verpag(doc);


        DataTable regis2 = per.obtenerUs(b);//agregar

        puntot.Nick = regis2.Rows[0]["nick"].ToString();
        puntot.Autor1 = regis.Rows[0]["nick"].ToString();

        DataTable data = dac.ObtenerInteraccion(b);
        int inter = int.Parse(data.Rows[0]["interacciones"].ToString());

        L_Usercs llamado = new L_Usercs();

        llamado.puntosBotonTres(punt, inter, puntot, us);//agregar




        int z = int.Parse(Session["parametro"].ToString());


        DataTable regis3 = per.obtenerUs(b);//agregar
        int x = int.Parse(regis3.Rows[0]["puntos"].ToString());
        int f = int.Parse(regis3.Rows[0]["id"].ToString());
        Entity_puntuacion pun = new Entity_puntuacion();//agregar
        pun.Id_usuario = b;//agregar
        pun.Id_post = z;//agregar
        Entity_usuario usw = new Entity_usuario();
        usw.Nombre = Session["id"].ToString();
        object segurity = new object();
        segurity = pun;
        string schema = "usuario";
        string tabla = "puntuacion";
        per.auditoriaInsertar(segurity, usw, schema, tabla);
        per.insertarPuntuacion(pun);//agregar
        x = x + 1;



        L_Usercs data_userPost = new L_Usercs();
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

        Entity_usuario user_ent1 = new Entity_usuario();
        user_ent1.Id = b;
        user_ent1.Nombre = datat.Rows[0]["nombre"].ToString();
        user_ent1.Nick = datat.Rows[0]["nick"].ToString();
        user_ent1.Correo = datat.Rows[0]["correo"].ToString();
        user_ent.Contra = datat.Rows[0]["contra"].ToString();
        user_ent1.Puntos = int.Parse(datat.Rows[0]["puntos"].ToString());
        user_ent1.Id_rol = int.Parse(datat.Rows[0]["id_rol"].ToString());
        user_ent1.Id_rango = int.Parse(datat.Rows[0]["id_rango"].ToString());
        user_ent1.Estado = int.Parse(datat.Rows[0]["estado"].ToString());
        user_ent1.Session = datat.Rows[0]["session"].ToString();
        user_ent1.Interacciones = int.Parse(datat.Rows[0]["interacciones"].ToString());
        user_ent1.Fecha_interaccion = DateTime.Parse(datat.Rows[0]["fecha_interaccion"].ToString());

        object objOld = new object();
        objOld = user_ent1;
        object objNew = new object();
        objNew = user_ent;
        string table = "usuario";
        //per.auditoriaModificar(objNew, objOld, usw, schema, table);
        per.actualizarUsuario(user_ent);
        // dac.actualizarpuntoUser(b, x);

        dac.ValidarPuntuacion(b, z);
        string ui = Session["id"].ToString();
        string par = Session["parametro"].ToString();

      

        U_user dat = new U_user();
        L_Usercs llamar = new L_Usercs();

        dat = llamar.redirigirCompletoAdmin();

        Response.Redirect(dat.Link_observador );

    }

    protected void BT_cuatro_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        Dsql dac = new Dsql();
        U_userCrearpost puntot = new U_userCrearpost();
       

        int b = int.Parse(Session["id"].ToString());
        int bn = int.Parse(Session["parametro"].ToString());
        L_Usercs dec = new L_Usercs();//agregar
        L_persistencia per = new L_persistencia();//agregar
        DataTable punt = dec.ToDataTable(per.obtenerPostEsp(bn));//agregar
        DataTable us = per.obtenerUs(b);//agregar
        //DataTable punt = dac.ObtenerPuntos(bn);
        DateTime dt = DateTime.Now;
        puntot.Id = int.Parse(Session["parametro"].ToString());
        puntot.Id_user = int.Parse(Session["id"].ToString());
        puntot.Fecha = dt;

        U_userCrearpost doc = new U_userCrearpost();
        doc.Id = int.Parse(Session["parametro"].ToString());
        Int32 v = int.Parse(Session["parametro"].ToString());

        DataTable regis = dac.verpag(doc);


        DataTable regis2 = per.obtenerUs(b);//agregar

        puntot.Nick = regis2.Rows[0]["nick"].ToString();
        puntot.Autor1 = regis.Rows[0]["nick"].ToString();

        DataTable data = dac.ObtenerInteraccion(b);
        int inter = int.Parse(data.Rows[0]["interacciones"].ToString());

        L_Usercs llamado = new L_Usercs();

        llamado.puntosBotonCuatro(punt, inter, puntot, us);//agregar




        int z = int.Parse(Session["parametro"].ToString());


        DataTable regis3 = per.obtenerUs(b);//agregar
        int x = int.Parse(regis3.Rows[0]["puntos"].ToString());
        int f = int.Parse(regis3.Rows[0]["id"].ToString());
        Entity_puntuacion pun = new Entity_puntuacion();//agregar
        pun.Id_usuario = b;//agregar
        pun.Id_post = z;//agregar
        Entity_usuario usw = new Entity_usuario();
        usw.Nombre = Session["id"].ToString();
        object segurity = new object();
        segurity = pun;
        string schema = "usuario";
        string tabla = "puntuacion";
        per.auditoriaInsertar(segurity, usw, schema, tabla);
        per.insertarPuntuacion(pun);//agregar
        x = x + 1;



        L_Usercs data_userPost = new L_Usercs();
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

        Entity_usuario user_ent1 = new Entity_usuario();
        user_ent1.Id = b;
        user_ent1.Nombre = datat.Rows[0]["nombre"].ToString();
        user_ent1.Nick = datat.Rows[0]["nick"].ToString();
        user_ent1.Correo = datat.Rows[0]["correo"].ToString();
        user_ent.Contra = datat.Rows[0]["contra"].ToString();
        user_ent1.Puntos = int.Parse(datat.Rows[0]["puntos"].ToString());
        user_ent1.Id_rol = int.Parse(datat.Rows[0]["id_rol"].ToString());
        user_ent1.Id_rango = int.Parse(datat.Rows[0]["id_rango"].ToString());
        user_ent1.Estado = int.Parse(datat.Rows[0]["estado"].ToString());
        user_ent1.Session = datat.Rows[0]["session"].ToString();
        user_ent1.Interacciones = int.Parse(datat.Rows[0]["interacciones"].ToString());
        user_ent1.Fecha_interaccion = DateTime.Parse(datat.Rows[0]["fecha_interaccion"].ToString());

        object objOld = new object();
        objOld = user_ent1;
        object objNew = new object();
        objNew = user_ent;
        string table = "usuario";
        //per.auditoriaModificar(objNew, objOld, usw, schema, table);
        per.actualizarUsuario(user_ent);
        // dac.actualizarpuntoUser(b, x);

        dac.ValidarPuntuacion(b, z);
        string ui = Session["id"].ToString();
        string par = Session["parametro"].ToString();

     
        U_user dat = new U_user();
        L_Usercs llamar = new L_Usercs();

        dat = llamar.redirigirCompletoAdmin();

        Response.Redirect(dat.Link_observador);

    }

    protected void BT_cinco_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        Dsql dac = new Dsql();
        U_userCrearpost puntot = new U_userCrearpost();
       

        int b = int.Parse(Session["id"].ToString());
        int bn = int.Parse(Session["parametro"].ToString());
        L_Usercs dec = new L_Usercs();//agregar
        L_persistencia per = new L_persistencia();//agregar
        DataTable punt = dec.ToDataTable(per.obtenerPostEsp(bn));//agregar
        DataTable us = per.obtenerUs(b);//agregar
        //DataTable punt = dac.ObtenerPuntos(bn);
        DateTime dt = DateTime.Now;
        puntot.Id = int.Parse(Session["parametro"].ToString());
        puntot.Id_user = int.Parse(Session["id"].ToString());
        puntot.Fecha = dt;

        U_userCrearpost doc = new U_userCrearpost();
        doc.Id = int.Parse(Session["parametro"].ToString());
        Int32 v = int.Parse(Session["parametro"].ToString());

        DataTable regis = dac.verpag(doc);


        DataTable regis2 = per.obtenerUs(b);//agregar

        puntot.Nick = regis2.Rows[0]["nick"].ToString();
        puntot.Autor1 = regis.Rows[0]["nick"].ToString();

        DataTable data = dac.ObtenerInteraccion(b);
        int inter = int.Parse(data.Rows[0]["interacciones"].ToString());

        L_Usercs llamado = new L_Usercs();

        llamado.puntosBotonCinco(punt, inter, puntot, us);//agregar




        int z = int.Parse(Session["parametro"].ToString());


        DataTable regis3 = per.obtenerUs(b);//agregar
        int x = int.Parse(regis3.Rows[0]["puntos"].ToString());
        int f = int.Parse(regis3.Rows[0]["id"].ToString());
        Entity_puntuacion pun = new Entity_puntuacion();//agregar
        pun.Id_usuario = b;//agregar
        pun.Id_post = z;//agregar
        Entity_usuario usw = new Entity_usuario();
        usw.Nombre = Session["id"].ToString();
        object segurity = new object();
        segurity = pun;
        string schema = "usuario";
        string tabla = "puntuacion";
        per.auditoriaInsertar(segurity, usw, schema, tabla);
        per.insertarPuntuacion(pun);//agregar
        x = x + 1;



        L_Usercs data_userPost = new L_Usercs();

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

        Entity_usuario user_ent1 = new Entity_usuario();
        user_ent1.Id = b;
        user_ent1.Nombre = datat.Rows[0]["nombre"].ToString();
        user_ent1.Nick = datat.Rows[0]["nick"].ToString();
        user_ent1.Correo = datat.Rows[0]["correo"].ToString();
        user_ent.Contra = datat.Rows[0]["contra"].ToString();
        user_ent1.Puntos = int.Parse(datat.Rows[0]["puntos"].ToString());
        user_ent1.Id_rol = int.Parse(datat.Rows[0]["id_rol"].ToString());
        user_ent1.Id_rango = int.Parse(datat.Rows[0]["id_rango"].ToString());
        user_ent1.Estado = int.Parse(datat.Rows[0]["estado"].ToString());
        user_ent1.Session = datat.Rows[0]["session"].ToString();
        user_ent1.Interacciones = int.Parse(datat.Rows[0]["interacciones"].ToString());
        user_ent1.Fecha_interaccion = DateTime.Parse(datat.Rows[0]["fecha_interaccion"].ToString());

        object objOld = new object();
        objOld = user_ent1;
        object objNew = new object();
        objNew = user_ent;
        string table = "usuario";
       //per.auditoriaModificar(objNew, objOld, usw, schema, table);
        per.actualizarUsuario(user_ent);
        //dac.actualizarpuntoUser(b, x);

        dac.ValidarPuntuacion(b, z);
        string ui = Session["id"].ToString();
        string par = Session["parametro"].ToString();

      

        U_user dat = new U_user();
        L_Usercs llamar = new L_Usercs();

        dat = llamar.redirigirCompletoAdmin();

        Response.Redirect(dat.Link_observador );

    }


    protected void BT_comentar_Click(object sender, EventArgs e)
    {

       
        L_Usercs log = new L_Usercs();
        U_comentarios coment = new U_comentarios();
        Dsql dac = new Dsql();
        L_persistencia logica = new L_persistencia();
        Entity_comentarios comentario = new Entity_comentarios();

        int b = int.Parse(Session["id"].ToString());
        DateTime dt = DateTime.Now;

        coment.Id_user = int.Parse(Session["id"].ToString());

        comentario.Comentario = TB_comentarios.Text.ToString();
        comentario.Id_post = int.Parse(Session["parametro"].ToString());
        comentario.Id_user = int.Parse(Session["id"].ToString());
        comentario.Estado = 1;


        Entity_usuario us = new Entity_usuario();
        us.Nombre = Session["id"].ToString();
        object segurity = new object();
        segurity = comentario;
        string schema = "usuario";
        string tabla = "comentarios";
        logica.auditoriaInsertar(segurity, us, schema, tabla);

        logica.insertarComenatrio(comentario);

        DataTable data = dac.ObtenerInteraccion(b);
        int inter = int.Parse(data.Rows[0]["interacciones"].ToString());

        string mensaje = log.comentar(inter, coment);

        LB_mensaje.Text = mensaje;
        Response.Write("<Script Language='JavaScript'>parent.alert('"+ mensaje + " ');</Script>");



        U_user dat = new U_user();
        L_Usercs llamar = new L_Usercs();

        dat = llamar.redirigirCompletoAdmin();

        Response.Redirect(dat.Link_observador);

    }



    protected void B_volver_Click(object sender, EventArgs e)
    {
        

        
        Response.Redirect("Administrador.aspx" );

    }

    protected void BT_reporte_Click(object sender, EventArgs e)
    {
        
       

        L_Usercs data = new L_Usercs();
        U_user dat = new U_user();

        dat = data.reporteAdminpost();

        Response.Redirect(dat.Link_observador );
    }




    protected void BT_reportar_Click(object sender, EventArgs e)
    {

        Button bt = sender as Button;
        GridViewRow grid = (GridViewRow)bt.NamingContainer;
        string IdRecogido = ((Label)grid.FindControl("Label1")).Text;



        Session["IdRecogido"] = IdRecogido;
        


        L_Usercs data = new L_Usercs();
        U_user dat = new U_user();

        dat = data.reporteAdmincoment();

        Response.Redirect(dat.Link_observador);
    }




}