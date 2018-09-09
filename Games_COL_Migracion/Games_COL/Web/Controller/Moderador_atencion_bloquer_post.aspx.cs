﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Moderador_atencion_bloquer_post : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Cache.SetNoStore();
    }

    protected void BT_vermas_Click(object sender, EventArgs e)
    {


        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_idPost");
        string ID = lblid.Text;
        Session["IdRecogido"] = ID;
        int b = int.Parse(Session["user_id"].ToString());

        string dat = b.ToString();


        U_user data = new U_user();
        L_Usercs llamado = new L_Usercs();

        data = llamado.vermasPostreportadomoder();
        Response.Redirect(data.Link_observador );

       
    }

    protected void BT_bloquear_Click(object sender, EventArgs e)
    {


        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_idPost");
        string ID = lblid.Text;
        
        int b = int.Parse(Session["user_id"].ToString());
        int x = 2;
        int h = int.Parse(ID);
        int z = 1;

        L_Usercs dac = new L_Usercs();

        dac.actualizarmoderPostreportado(h, b, x,z);

        int t = int.Parse(Session["user_id"].ToString());

        string dat = b.ToString();
       

        U_user data = new U_user();
        L_Usercs llamado = new L_Usercs();

        data = llamado.recargarationpost();
        Response.Redirect(data.Link_observador);
        
    }

    protected void Bt_volver_Click(object sender, EventArgs e)
    {


        int t = int.Parse(Session["user_id"].ToString());

        string dat = t.ToString();
 


        U_user data = new U_user();
        L_Usercs llamado = new L_Usercs();

        data = llamado.irHomeModerador();
        Response.Redirect(data.Link_observador );
    }
}