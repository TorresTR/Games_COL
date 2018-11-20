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

public partial class View_Moderador_verpqrCompleto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        Int32 idioma = 1;
        Int32 id_pagina = 48;
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
        B_volver.Text = compIdioma["B_volver"].ToString();

        U_Datospqr respuesa = new U_Datospqr();
        L_Usercs logica = new L_Usercs();

        respuesa.Id_pqr = int.Parse(Session["IdRecogido"].ToString());



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
        Entity_pqr ent1 = new Entity_pqr();


        int b = int.Parse(Session["id"].ToString());
        int q = int.Parse(Session["IdRecogido"].ToString());
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
        ent.Fecha = DateTime.Parse(tabla.Rows[0]["fecha"].ToString());
        ent.Respuesta = TB_respuestapqr.Text.ToString();
        ent.Id_contestador = b;
        ent.Fecha_respuesta = dt;
        ent.Estado_respuesta = 1;

        ent1.Id_pqr = q;
        ent1.Usuario = int.Parse(tabla.Rows[0]["usuario"].ToString());
        ent1.Solicitud = int.Parse(tabla.Rows[0]["solicitud"].ToString());
        ent1.Contenido = tabla.Rows[0]["contenido"].ToString();
        ent1.Asunto = tabla.Rows[0]["asunto"].ToString();
        ent1.Fecha = DateTime.Parse(tabla.Rows[0]["fecha"].ToString());
        ent1.Respuesta = TB_respuestapqr.Text.ToString();
        ent1.Id_contestador = int.Parse(tabla.Rows[0]["id_contestador"].ToString());
        ent1.Fecha_respuesta = DateTime.Parse(tabla.Rows[0]["fecha_respuesta"].ToString());
        ent1.Estado_respuesta = int.Parse(tabla.Rows[0]["estado_respuesta"].ToString());

        L_persistencia per = new L_persistencia();
        object objOld = new object();
        objOld = ent1;
        object objNew = new object();
        objNew = ent;
        string schema = "usuario";
        string table = "pqr";
        Entity_usuario us = new Entity_usuario();
        us.Nombre = Session["id"].ToString();
        per.auditoriaModificar(objNew, objOld, us, schema, table);

        pqr.actualizarPQR(ent);
        string par = q.ToString();
        string ui = b.ToString();
 
        Response.Redirect("Moderador_ver_pqr.aspx" );

        
    }

    protected void B_volver_Click(object sender, EventArgs e)
    {

       // string q = Session["id"].ToString();
        //string z = Session["parametro"].ToString();

        Response.Redirect("Moderador_ver_pqr.aspx");

        
    }
}