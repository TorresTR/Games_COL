﻿using Logica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;

public partial class View_Administrador_miNoticia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        Int32 idioma = 1;
        Int32 id_pagina = 11;
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
        GV_miPost.DataBind();

        L_Usercs dac = new L_Usercs();


        int dato = int.Parse(Session["user_id"].ToString());

        GV_miPost.DataSource = dac.minoticiagv(dato);
        GV_miPost.DataBind();

    }

    protected void GV_mipost_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            try
            {
                ((Label)e.Row.FindControl("LB_editar")).Text = ((Hashtable)Session["mensajes"])["LB_editar"].ToString();
                ((Label)e.Row.FindControl("LB_eliminar")).Text = ((Hashtable)Session["mensajes"])["LB_eliminar"].ToString();
                ((Label)e.Row.FindControl("LB_tit")).Text = ((Hashtable)Session["mensajes"])["LB_tit"].ToString();


            }
            catch (Exception exe)
            {
                ((Button)e.Row.FindControl("BT_editar")).Text = ((Hashtable)Session["mensajes"])["BT_editar"].ToString();
                ((Button)e.Row.FindControl("BT_eliminar")).Text = ((Hashtable)Session["mensajes"])["BT_eliminar"].ToString();
                ((Button)e.Row.FindControl("BT_volver")).Text = ((Hashtable)Session["mensajes"])["BT_volver"].ToString();
               
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
        Session["parametro"] = IdRecogido;
        U_user dat = new U_user();
        L_Usercs llamar = new L_Usercs();

        string c = b.ToString();
        


        dat = llamar.recargaminoticiaAdmin();


        Response.Redirect(dat.Link_observador );
     
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
        Session["IdRecogido"] = IdRecogido;
        int x = int.Parse(IdRecogido);

        L_Usercs dac = new L_Usercs();
        dac.eliminarminoticia(x);

        U_user dat = new U_user();
        L_Usercs llamar = new L_Usercs();

        string c = b.ToString();


        dat = llamar.recargapgnotiAdmin();
        Response.Redirect(dat.Link_observador);

    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();


        dat = llamado.retornoAdmin();

        Response.Redirect(dat.Link_observador );
    }
}