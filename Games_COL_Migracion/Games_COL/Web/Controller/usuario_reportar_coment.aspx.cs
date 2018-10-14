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

public partial class View_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        Int32 idioma = 1;
        Int32 id_pagina = 72;
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



        LB_titulo.Text = compIdioma["LB_titulo"].ToString();
        LB_titComent.Text = compIdioma["LB_titComent"].ToString();
        LB_motivo.Text = compIdioma["LB_motivo"].ToString();
        BT_reportar.Text = compIdioma["BT_reportar"].ToString();
        BT_volver.Text = compIdioma["BT_volver"].ToString();


        ClientScriptManager cm = this.ClientScript;
        U_comentarios doc = new U_comentarios();
        L_Usercs dac = new L_Usercs();
        
        int c = int.Parse(Session["IdRecogido"].ToString());
        int u = int.Parse(Session["user_id"].ToString());
        L_persistencia per = new L_persistencia();//agregar
        DataTable tabla = dac.ToDataTable(per.obtenerComent(c));//agregar

        //doc = dac.ObtenerComentarioreportar(c);


        LB_Id_comentario.Text = tabla.Rows[0]["comentario"].ToString();//agregar

    }

    protected void BT_reportar_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        U_comentarios reporte = new U_comentarios();
        L_Usercs envio = new L_Usercs();
        U_user coment = new U_user();
        Entity_comentarios comenta = new Entity_comentarios();
        L_persistencia per = new L_persistencia();
        Entity_reporte_comentarios coment_rep = new Entity_reporte_comentarios();

        int b = int.Parse(Session["IdRecogido"].ToString());
        int p = int.Parse(Session["parametro"].ToString());
        DateTime dt = DateTime.Now;

        int u = int.Parse(Session["user_id"].ToString());


        DataTable regis = envio.obtenerComentario1(b);


        coment_rep.Id_com_reportado = b;
        coment_rep.Contendio = TB_motivoR.Text.ToString();
        coment_rep.Fecha = dt;
        coment_rep.Id_user = u;

        per.insertarReportecomentar(coment_rep);
        DataTable com = envio.obtenerComentariofinal(b);
        

        comenta.Id_comentario = int.Parse(com.Rows[0]["id_comentario"].ToString());
        comenta.Id_post = int.Parse(com.Rows[0]["id_post"].ToString());
        comenta.Id_user = int.Parse(com.Rows[0]["id_user"].ToString());
        comenta.Comentario = com.Rows[0]["comentario"].ToString();
        comenta.Estado = 2;
        //envio.bloquearComent(b);
        per.actualizarComentario(comenta);

        string ID = Session["parametro"].ToString();
        string z = Session["user_id"].ToString();


        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();

        dat = llamado.verCompletousuarioRegistrado();

        Response.Redirect(dat.Link_observador);
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {

        string z = Session["user_id"].ToString();


        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();

        dat = llamado.volverUsuariosRegistrado();

        Response.Redirect(dat.Link_observador);
    }
}