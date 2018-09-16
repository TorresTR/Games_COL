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

public partial class View_Observador_pc : System.Web.UI.Page
{
    string mensaje1;
    string mensaje2;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["user_id"] = 1;
        Response.Cache.SetNoStore();
        //LB_resulbusq.Visible = false;
        Int32 idioma = 1;
        Int32 id_pagina = 52;
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


        BT_buscar.Text = compIdioma["BT_buscar"].ToString();
        DL_noticias.DataBind();
        DL_post.DataBind();
        DL_resultado.DataBind();

    }

    protected void DL_noticias_RowDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            try
            {
                ((Label)e.Item.FindControl("LB_titulo")).Text = ((Hashtable)Session["mensajes"])["LB_titulo"].ToString();
                ((Label)e.Item.FindControl("LB_autor")).Text = ((Hashtable)Session["mensajes"])["LB_autor"].ToString();
                ((Label)e.Item.FindControl("LB_etiqueta")).Text = ((Hashtable)Session["mensajes"])["LB_etiqueta"].ToString();
                ((Button)e.Item.FindControl("BT_verNoticias")).Text = ((Hashtable)Session["mensajes"])["BT_verNoticias"].ToString();
                mensaje1 = ((Hashtable)Session["mensajes"])["no_existe"].ToString();
                mensaje2 = ((Hashtable)Session["mensajes"])["resultado"].ToString();
            }
            catch (Exception exe)
            {

                ((Button)e.Item.FindControl("BT_verNoticias")).Text = ((Hashtable)Session["mensajes"])["BT_verNoticias"].ToString();
            }
        }
        catch (Exception exx)
        {
        }

    }

    protected void DL_resul_RowDataBound(object sender, DataListItemEventArgs e)
    {
       
        try
        {
            try
            {

                ((Label)e.Item.FindControl("LB_titulo")).Text = ((Hashtable)Session["mensajes"])["LB_titulo"].ToString();
                ((Label)e.Item.FindControl("LB_autor")).Text = ((Hashtable)Session["mensajes"])["LB_autor"].ToString();
                ((Label)e.Item.FindControl("LB_eti")).Text = ((Hashtable)Session["mensajes"])["LB_etiqueta"].ToString();
                ((Button)e.Item.FindControl("BT_vermas")).Text = ((Hashtable)Session["mensajes"])["BT_verNoticias"].ToString();
            }
            catch (Exception exe)
            {

                ((Label)e.Item.FindControl("LB_titulo")).Text = ((Hashtable)Session["mensajes"])["LB_titulo"].ToString();
                ((Label)e.Item.FindControl("LB_autor")).Text = ((Hashtable)Session["mensajes"])["LB_autor"].ToString();
                ((Label)e.Item.FindControl("LB_eti")).Text = ((Hashtable)Session["mensajes"])["LB_etiqueta"].ToString();
                ((Button)e.Item.FindControl("BT_vermas")).Text = ((Hashtable)Session["mensajes"])["BT_verNoticias"].ToString();
            }
        }
        catch (Exception exx)
        {
        }

    }

    protected void DL_post_RowDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            try
            {
                ((Label)e.Item.FindControl("LB_titulo")).Text = ((Hashtable)Session["mensajes"])["LB_titulo"].ToString();
                ((Label)e.Item.FindControl("LB_autor")).Text = ((Hashtable)Session["mensajes"])["LB_autor"].ToString();
                ((Label)e.Item.FindControl("LB_etiqueta")).Text = ((Hashtable)Session["mensajes"])["LB_etiqueta"].ToString();
                ((Button)e.Item.FindControl("BT_vermas")).Text = ((Hashtable)Session["mensajes"])["BT_verNoticias"].ToString();
            }
            catch (Exception exe)
            {

                ((Button)e.Item.FindControl("BT_vermas")).Text = ((Hashtable)Session["mensajes"])["BT_verNoticias"].ToString();
            }
        }
        catch (Exception exx)
        {
        }

    }





    protected void BT_vermas_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");

        L_Usercs data = new L_Usercs();
        U_user envioObservador = new U_user();
        
        string x = lblid.Text.ToString();


        envioObservador = data.Vermas(x);

        Session["parametro"] = x;
        Response.Redirect(envioObservador.Link_observador );
    }


    protected void BT_homre_Click(object sender, EventArgs e)
    {
        U_user inicio = new U_user();
        L_Usercs llamado = new L_Usercs();

        inicio = llamado.irInicio();
        Response.Redirect(inicio.Link_demas);
    }

    protected void BT_xbox_Click(object sender, EventArgs e)
    {
        U_user xbox = new U_user();
        L_Usercs llamado = new L_Usercs();

        xbox = llamado.irxbox();
        Response.Redirect(xbox.Link_demas);
    }

    protected void BT_plasyStation_Click(object sender, EventArgs e)
    {
        U_user PS = new U_user();
        L_Usercs llamado = new L_Usercs();

        PS = llamado.irPS();
        Response.Redirect(PS.Link_demas);
    }

    protected void BT_andrioid_Click(object sender, EventArgs e)
    {
        U_user Android = new U_user();
        L_Usercs llamado = new L_Usercs();

        Android = llamado.irAndroid();
        Response.Redirect(Android.Link_demas);
    }


    protected void BT_Buscar_Click(object sender, EventArgs e)
    {
        L_Usercs lugar = new L_Usercs();

        U_user dat = new U_user();

        DataTable dato = lugar.Busqueda(TB_buscador.Text.ToString());

        DL_resultado.DataSource = dato;
        DL_resultado.DataBind();

        dat = lugar.busquedaMensaje1(dato,mensaje1,mensaje2);

        LB_resulbusq.Visible = dat.Estado;
        LB_resulbusq.Text = dat.Mensaje_Alertaobservador1;

       
    }



    protected void BT_verNoticas_Click(object sender, EventArgs e)
    {

        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");

        L_Usercs data = new L_Usercs();
        U_user envioObservador = new U_user();
        


        string x = lblid.Text.ToString();

        envioObservador = data.verNoticias(x);

        Session["parametro"] = x;

        Response.Redirect(envioObservador.Link_observador );
    }
}