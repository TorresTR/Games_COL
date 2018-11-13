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

public partial class View_Administrador_verpqrCompleto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        Int32 idioma = 1;
        Int32 id_pagina = 25;
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


        LB_titAutor.Text = compIdioma["LB_titAutor"].ToString();
        LB_titContenido.Text = compIdioma["LB_titContenido"].ToString();
        LB_comentar.Text = compIdioma["LB_comentar"].ToString();
        BT_responder.Text = compIdioma["BT_responder"].ToString();
        B_volver.Text = compIdioma["BT_volver"].ToString();

        U_Datospqr respuesa = new U_Datospqr();
        L_Usercs logica = new L_Usercs();

        respuesa.Id_pqr = int.Parse(Session["parametro"].ToString());



        DataTable regis = logica.pqr(respuesa);
        respuesa = logica.pqr(regis);

        LB_muestraPag.Text = respuesa.Contenido;
        LB_autor.Text = respuesa.Autor;
    }

    protected void BT_responder_Click(object sender, EventArgs e)
    {
 
        L_Usercs user = new L_Usercs();
        U_Datospqr respuesa = new U_Datospqr();
        L_persistencia pqr = new L_persistencia();
        Entity_pqr ent = new Entity_pqr();


        int b = int.Parse(Session["id"].ToString());
        int q = int.Parse(Session["parametro"].ToString());
        int a = 1;
        DataTable tabla = user.traerPQR(q);

        DateTime dt = DateTime.Now;

        //respuesa.Id_respondedor = b;
        //respuesa.Fecha_respuesta = dt;
        //respuesa.Respuesta = TB_respuestapqr.Text.ToString();
        //respuesa.Id_pqr = q;
        //respuesa.Estado_respuesta = a;

        ent.Id_pqr = q;
        ent.Usuario = int.Parse(tabla.Rows[0]["usuario"].ToString());
        ent.Solicitud = int.Parse(tabla.Rows[0]["solicitud"].ToString());
        ent.Contenido = tabla.Rows[0]["contenido"].ToString();
        ent.Asunto = tabla.Rows[0]["asunto"].ToString();
        ent.Fecha = DateTime.Parse( tabla.Rows[0]["fecha"].ToString());
        ent.Respuesta = TB_respuestapqr.Text.ToString();
        ent.Id_contestador = b;
        ent.Fecha_respuesta = dt;
        ent.Estado_respuesta = 1;

        L_persistencia per = new L_persistencia();
        object objOld = new object();
        objOld = tabla;
        object objNew = new object();
        objNew = ent;
        string schema = "usuario";
        string table = "pqr";
        Entity_usuario us = new Entity_usuario();
        us.Nombre = Session["id"].ToString();
        per.auditoriaModificar(objNew, objOld, us, schema, table);

        pqr.actualizarPQR(ent);

        //user.actualizarpqr(respuesa);
        string par = q.ToString();
        string ui = b.ToString();

        Response.Redirect("Administrador_ver_pqr.aspx");

    }

    protected void B_volver_Click(object sender, EventArgs e)
    {
      
        string q = Session["id"].ToString();
        string z = Session["parametro"].ToString();

        Response.Redirect("Administrador_ver_pqr.aspx" );
    }
}