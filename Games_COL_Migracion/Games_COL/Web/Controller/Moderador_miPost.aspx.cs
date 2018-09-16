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

public partial class View_Moderador_miPost : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        Int32 idioma = 1;
        Int32 id_pagina = 38;
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

        U_misPost mio = new U_misPost();
        L_Usercs dac = new L_Usercs();


        int dato = int.Parse(Session["user_id"].ToString());

        mio.Id_mipost = dato;

        GV_miPost.DataSource = dac.misPost(mio);
        GV_miPost.DataBind();

    }

    protected void GV_Idioma_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            try
            {
                
                ((Label)e.Row.FindControl("LB_editar")).Text = ((Hashtable)Session["mensajes"])["LB_editar"].ToString();
                ((Label)e.Row.FindControl("LB_eliminar")).Text = ((Hashtable)Session["mensajes"])["LB_eliminar"].ToString();
                ((Label)e.Row.FindControl("LB_autor")).Text = ((Hashtable)Session["mensajes"])["LB_autor"].ToString();
                ((Label)e.Row.FindControl("LB_etiqueta")).Text = ((Hashtable)Session["mensajes"])["LB_etiqueta"].ToString();
                ((Label)e.Row.FindControl("LB_titulo")).Text = ((Hashtable)Session["mensajes"])["LB_titulo"].ToString();
                ((Button)e.Row.FindControl("BT_editar")).Text = ((Hashtable)Session["mensajes"])["BT_editar"].ToString();
                ((Button)e.Row.FindControl("BT_eliminar")).Text = ((Hashtable)Session["mensajes"])["BT_eliminar"].ToString();

            }
            catch (Exception exe)
            {
                ((Button)e.Row.FindControl("BT_editar")).Text = ((Hashtable)Session["mensajes"])["BT_editar"].ToString();
                ((Button)e.Row.FindControl("BT_eliminar")).Text = ((Hashtable)Session["mensajes"])["BT_eliminar"].ToString();
               
            }
        }
        catch (Exception exx)
        {
        }

    }

    protected void BT_editar_Click(object sender, EventArgs e)
    {
        Button bt = (Button)sender;
        TableCell tableCell = (TableCell)bt.Parent;
        GridViewRow row = (GridViewRow)tableCell.Parent;
        GV_miPost.SelectedIndex = row.RowIndex;
        int fila = row.RowIndex;


        int b = int.Parse(Session["user_id"].ToString());
        string IdRecogido = ((Label)row.Cells[fila].FindControl("LB_id")).Text;
        Session["IdRecogido"] = IdRecogido;
        string dat = b.ToString();

        U_user data = new U_user();
        L_Usercs llamado = new L_Usercs();

        data = llamado.ModeradorEditarMispost();

        Response.Redirect(data.Link_observador );

       
    }

    protected void BT_eliminar_Click(object sender, EventArgs e)
    {
        Button bt = (Button)sender;
        TableCell tableCell = (TableCell)bt.Parent;
        GridViewRow row = (GridViewRow)tableCell.Parent;
        GV_miPost.SelectedIndex = row.RowIndex;
        int fila = row.RowIndex;



        int b = int.Parse(Session["user_id"].ToString());
        string IdRecogido = ((Label)row.Cells[fila].FindControl("LB_id")).Text;

        int x = int.Parse(IdRecogido);

        L_Usercs dac = new L_Usercs();
        U_misPost dato = new U_misPost();

        dato.Id_mipost = x;

        dac.eliminarMipost(dato);



        U_user data = new U_user();
        L_Usercs llamado = new L_Usercs();

        data = llamado.ModeradorMispost();

        Response.Redirect(data.Link_observador );
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();

        dat = llamado.irHomeModerador();

        Response.Redirect(dat.Link_observador);
    }
}