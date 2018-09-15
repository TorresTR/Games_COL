using Logica;
using System;
using System.Data;
using System.Web.UI.WebControls;
using Datos;
using Utilitarios;
using System.Collections;


public partial class View_Administrador : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        LB_busq.Visible = false;

        Int32 idioma = 1;
        Int32 id_pagina = 1;
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


        string ID = lblid.Text;

        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();

        Session["parametro"] = ID;

        dat = llamado.verCompletoAdmin();

        Response.Redirect(dat.Link_observador );

    }

    protected void BT_pc_Click(object sender, EventArgs e)
    {
        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();
        

        dat = llamado.irPCAdmin();

        Response.Redirect(dat.Link_observador );

    }

    protected void BT_xbox_Click(object sender, EventArgs e)
    {
        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();
       

        dat = llamado.irXboxAdmin();

        Response.Redirect(dat.Link_observador);

    }

    protected void BT_ps_Click(object sender, EventArgs e)
    {
        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();
        

        dat = llamado.irPSAdmin();

        Response.Redirect(dat.Link_observador);

    }

    protected void BT_android_Click(object sender, EventArgs e)
    {
        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();
       

        dat = llamado.irAndroidAdmin();

        Response.Redirect(dat.Link_observador );

    }





    protected void Button3_Click(object sender, EventArgs e)
    {
        L_Usercs lugar = new L_Usercs();

        U_user dat = new U_user();

        DataTable dato = lugar.Busqueda(TB_buscador.Text.ToString());

        DL_resultado.DataSource = dato;
        DL_resultado.DataBind();

        dat = lugar.busquedaMensaje(dato);

        LB_busq.Visible = dat.Estado;
        LB_busq.Text = dat.Mensaje_Alertaobservador1;
    }

    protected void BT_verNoticas_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");

        L_Usercs data = new L_Usercs();
        U_user envioObservador = new U_user();

      

        string x = lblid.Text.ToString();
        

        envioObservador = data.verNoticiasAdmin(x);

        Session["parametro"] = x;

        Response.Redirect(envioObservador.Link_observador );
    }
}