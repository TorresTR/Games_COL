using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Observador : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
            Int32 idioma = 1;
            Int32 id_pagina = 50;



            Session["valor_ddl"] = DDL_Idioma.SelectedValue.ToString();


            L_Usercs Idio = new L_Usercs();
            DataTable info = Idio.traducir(id_pagina, idioma);
            Hashtable compIdioma = new Hashtable();
            Session["mensajes"] = compIdioma;
            compIdioma = Idio.hastableIdioma(info, compIdioma);
        if (!this.IsPostBack)
        {
            BT_Buscar.Text = compIdioma["BT_buscar"].ToString();
            DL_noticias.DataBind();
            DL_post.DataBind();
            DL_resultado.DataBind();

            
        }

        Session["user_id"] = 1;
        Response.Cache.SetNoStore();
        LB_resulbusq.Visible = false;
        DL_resultado.Visible = true;
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
            }
            catch (Exception exe)
            {

                ((Button)e.Item.FindControl("BT_verNoticias")).Text =((Hashtable)Session["mensajes"])["BT_verNoticias"].ToString();
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
                ((Label)e.Item.FindControl("LB_etiqueta")).Text = ((Hashtable)Session["mensajes"])["LB_etiqueta"].ToString();
                ((Button)e.Item.FindControl("BT_vermas")).Text = ((Hashtable)Session["mensajes"])["BT_vermas"].ToString();
            }
            catch (Exception exe)
            {

                ((Button)e.Item.FindControl("BT_vermas")).Text = ((Hashtable)Session["mensajes"])["BT_vermas"].ToString();
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
                ((Button)e.Item.FindControl("BT_vermas")).Text = ((Hashtable)Session["mensajes"])["BT_vermas"].ToString();
            }
            catch (Exception exe)
            {

                ((Button)e.Item.FindControl("BT_vermas")).Text = ((Hashtable)Session["mensajes"])["BT_vermas"].ToString();
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
       

        Response.Redirect(envioObservador.Link_observador);
    }

    protected void BT_pc_Click(object sender, EventArgs e)
    {
        U_user pc = new U_user();
        L_Usercs llamado = new L_Usercs();

            pc = llamado.irPC();
        Response.Redirect(pc.Link_demas);
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

        Response.Redirect(envioObservador.Link_observador);    
    }



    protected void BT_Buscar_Click(object sender, EventArgs e)
    {
        L_Usercs lugar = new L_Usercs();
    
        U_user dat = new U_user();

        DataTable dato = lugar.Busqueda(TB_buscador.Text.ToString());

        DL_resultado.DataSource = dato;
        DL_resultado.DataBind();

        dat = lugar.busquedaMensaje(dato);
        
        LB_resulbusq.Visible = dat.Estado;
        LB_resulbusq.Text = dat.Mensaje_Alertaobservador1;


    }



    protected void DDL_lenguaje_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 index = Int32.Parse(DDL_Idioma.SelectedValue.ToString());
        L_Usercs cambiar_cultura = new L_Usercs();
        String cultura = cambiar_cultura.select_idioma(index);
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultura);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultura);
        Session["mensajes"] = index;
        Int32 id_pagina = 50;
        try
        {
            

            L_Usercs Idio = new L_Usercs();
            DataTable info = Idio.traducir(id_pagina, index);
            Hashtable compIdioma = new Hashtable();

            Session["mensajes"] = compIdioma;
            compIdioma = Idio.hastableIdioma(info, compIdioma);
            BT_Buscar.Text = compIdioma["BT_buscar"].ToString();
            DL_noticias.DataBind();
            DL_post.DataBind();
            DL_resultado.DataBind();


        }
        catch
        {

        }


    }





}