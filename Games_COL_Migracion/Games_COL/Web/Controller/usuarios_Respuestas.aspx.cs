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

public partial class View_usuarios_Respuestas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();


        L_Usercs dac = new L_Usercs();
        U_respuestasPqr dat = new U_respuestasPqr();
        Int32 idioma = 1;
        Int32 id_pagina = 80;
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


        BT_volver.Text = compIdioma["BT_volver"].ToString();



        L_persistencia per = new L_persistencia();//agregar

        int dato = int.Parse(Session["user_id"].ToString());

        dat.Id_respuesta = dato;

        GV_comentariosuser.DataSource = per.obtenerRespuesta(dato);//agregar
        GV_comentariosuser.DataBind();
    }

    protected void GV_Idioma_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            try
            {
                ((Label)e.Row.FindControl("LB_verMas")).Text = ((Hashtable)Session["mensajes"])["LB_verMas"].ToString();
                ((Label)e.Row.FindControl("LB_titautor")).Text = ((Hashtable)Session["mensajes"])["LB_autor"].ToString();
                ((Label)e.Row.FindControl("LB_titSol")).Text = ((Hashtable)Session["mensajes"])["LB_titSol"].ToString();
            }
            catch (Exception exe)
            {

                ((Button)e.Row.FindControl("BT_reportar")).Text  = ((Hashtable)Session["mensajes"])["BT_reportar"].ToString();
            }
        }
        catch (Exception exx)
        {
        }

    }

    protected void BT_reportar_Click(object sender, EventArgs e)
    {


        Button bt = (Button)sender;
        TableCell tableCell = (TableCell)bt.Parent;
        GridViewRow row = (GridViewRow)tableCell.Parent;
        GV_comentariosuser.SelectedIndex = row.RowIndex;
        int fila = row.RowIndex;

      
        int b = int.Parse(Session["user_id"].ToString());
        string IdRecogido = ((Label)row.Cells[fila].FindControl("Label1")).Text;

        Session["IdRecogido"] = IdRecogido;

        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();

        dat = llamado.redireccionMisrespuestaspqr();

        Response.Redirect(dat.Link_observador);
        

    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {


        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();

        dat = llamado.volverUsuariosRegistrado();

        Response.Redirect(dat.Link_observador);
    }
}