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


public partial class View_usuarios_reportar_post : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        Int32 idioma = 1;
        Int32 id_pagina = 79;
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


        LB_titilo.Text = compIdioma["LB_titulo"].ToString();
        LB_motivo.Text = compIdioma["LB_motivo"].ToString();
        BT_volver.Text = compIdioma["BT_volver"].ToString();
        BT_enviarReporte.Text = compIdioma["BT_enviarReporte"].ToString();


        U_user doc = new U_user();
        L_Usercs dac = new L_Usercs();

        int c = int.Parse(Session["parametro"].ToString());
        int u = int.Parse(Session["id"].ToString());

        doc = dac.obtenerPostparareportar(c);

        LB_tituloReportar.Text = doc.Mensaje_Alertaobservador1;



    }

    protected void BT_enviarReporte_Click(object sender, EventArgs e)
    {


        U_Datosreporte reporte = new U_Datosreporte();
        L_Usercs envio = new L_Usercs();
        L_persistencia per = new L_persistencia();//AGREGAR
        Entity_post post = new Entity_post();//AGREGAR

        int b = int.Parse(Session["parametro"].ToString());
        DateTime dt = DateTime.Now;

        int u = int.Parse(Session["id"].ToString());


        DataTable regis = envio.obtenerPostObservador();
        DataTable dato = envio.traerPost(b);//AGREGAR
        actualizar_estado_bloqueo report = new actualizar_estado_bloqueo();//agregar


        reporte.Id_post_reportado = b;
            reporte.Contido_reporte = TB_reporte.Text.ToString();
            reporte.Fecha_reporte = dt;
            reporte.User_reportador = u;
        report.Id_post_reportador = b;//agregar
        report.Contenido_reporte = TB_reporte.Text.ToString();//agregar
        report.Fecha_reporte = dt;//agregar
        report.User_reportador = u;//agregar
        report.Estado_resuelto = 1;//agregar

        post.Id = b;//AGREGAR
        post.Contenido = dato.Rows[0]["contenido"].ToString();//AGREGAR
        post.Autor = int.Parse(dato.Rows[0]["autor"].ToString());//AGREGAR
        post.Titulo = dato.Rows[0]["titulo"].ToString();//AGREGAR
        post.Fecha = DateTime.Parse(dato.Rows[0]["fecha"].ToString());//AGREGAR
        post.Puntos = int.Parse(dato.Rows[0]["puntos"].ToString());//AGREGAR
        post.Etiqueta = int.Parse(dato.Rows[0]["etiqueta"].ToString());//AGREGAR
        post.Estado_bloqueo = 2;//AGREGAR
        post.Num_puntos = int.Parse(dato.Rows[0]["num_puntos"].ToString());//AGREGAR


        Entity_usuario us = new Entity_usuario();
        us.Nombre = Session["id"].ToString();
        object segurity = new object();
        segurity = post;
        string schema = "usuario";
        string tabla = "reporte_post";
        per.auditoriaInsertar(segurity, us, schema, tabla);

        per.insertarReportePost(report);//agregar
                                        //envio.insertarPostaReportar(reporte);

        object objOld = new object();
        objOld = dato;
        object objNew = new object();
        objNew = post;
        string table = "post";
        us.Nombre = Session["id"].ToString();
        per.auditoriaModificar(objNew, objOld, us, schema, table);

        per.actualizarBloqueoPost(post);//AGREGAR
       // envio.bloquear_Post(b);

        L_Usercs data = new L_Usercs();
        U_user dat = new U_user();

        dat = data.redirigirCompletousuarioregistrado();

        Response.Redirect(dat.Link_observador);
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {




        L_Usercs data = new L_Usercs();
        U_user dat = new U_user();

        dat = data.redirigirCompletousuarioregistrado();

        Response.Redirect(dat.Link_observador );
    }
}