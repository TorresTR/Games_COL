﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        U_userCrearpost doc = new U_userCrearpost();
        L_Usercs dac = new L_Usercs();
        ClientScriptManager cm = this.ClientScript;

        doc.Id = int.Parse(Session["parametro"].ToString());
        int dato = int.Parse(Session["parametro"].ToString());
        int dato2 = int.Parse(Session["user_id"].ToString());


       doc =  dac.eliminarMiscomentarios(doc);

        LB_muestraPag.Text = doc.Contenido1;
        LB_autor.Text = doc.Autor1;

        //dac.eliminarMiscomentariospuntos(doc);
       

        GV_comentariosuser.DataSource = dac.dataEliminarcoment(dato,dato2);
        GV_comentariosuser.DataBind();
    }

    protected void BT_eliminar_Click(object sender, EventArgs e)
    {
        L_Usercs dac = new L_Usercs();
        Button bt = (Button)sender;
        TableCell tableCell = (TableCell)bt.Parent;
        GridViewRow row = (GridViewRow)tableCell.Parent;
        GV_comentariosuser.SelectedIndex = row.RowIndex;
        int fila = row.RowIndex;

        int h = int.Parse(Session["parametro"].ToString());
        int b = int.Parse(Session["user_id"].ToString());
        int IdRecogido = int.Parse(((Label)row.Cells[fila].FindControl("Label1")).Text);


        dac.dataEliminarcomentaction(IdRecogido);

        U_user data = new U_user();
        L_Usercs llamado = new L_Usercs();

        data = llamado.redireccionMiscoment();

        Response.Redirect(data.Link_observador );
        

    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {

        U_user data = new U_user();
        L_Usercs llamado = new L_Usercs();

        data = llamado.redireccionComentariot();

        Response.Redirect(data.Link_observador);
    }
}