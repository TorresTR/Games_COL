using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Logica;
using Utilitarios;
using ASPSnippets.FaceBookAPI;
using System.Web.Script.Serialization;
using System.Net;
using Facebook;
using System.IO;

public partial class View_usuarios : System.Web.UI.Page
{

    string mensaje1;
    string mensaje2;
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Cache.SetNoStore();

        LB_busq.Visible = false;
        Int32 idioma = 1;
        Int32 id_pagina = 74;
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

        string b = Session["id"].ToString();
        Session["parametro"] = ID;

        dat = llamado.verCompletousuarioRegistrado();

        Response.Redirect( dat.Link_observador );
    }

    protected void BT_pc_Click(object sender, EventArgs e)
    {
        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();

        dat = llamado.irPCusuarioregistrado();
        
        Response.Redirect(dat.Link_observador);
    }

    protected void BT_xbox_Click(object sender, EventArgs e)
    {
        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();

        dat = llamado.irXboxusuarioregistrado();

        Response.Redirect(dat.Link_observador);
    }

    protected void BT_ps_Click(object sender, EventArgs e)
    {
        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();


        dat = llamado.irPSusuarioregistrado();

        Response.Redirect(dat.Link_observador );
    }

    protected void BT_android_Click(object sender, EventArgs e)
    {
        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();


        dat = llamado.irAndroidusuarioregistrado();

        Response.Redirect(dat.Link_observador );
    }




    protected void BT_Buscar_Click(object sender, EventArgs e)
    {
        L_Usercs lugar = new L_Usercs();

        U_user dat = new U_user();

        DataTable dato = lugar.Busqueda(TB_buscador.Text.ToString());

        DL_resultado.DataSource = dato;
        DL_resultado.DataBind();

        dat = lugar.busquedaMensaje1(dato,mensaje1,mensaje2);

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
        string b = Session["id"].ToString();
        Session["parametro"] = x;
        envioObservador = data.verNoticiasusuariosregistrados(x);


        Response.Redirect(envioObservador.Link_observador );
    }



    //protected void Button1_Click(object sender, EventArgs e)
    //{

    //    string app_id = "184076195845739";
    //    string app_secret = "a0c8d4f1c27d4d3efdfb3b0ee894e12f";
    //    string scope = "user_posts,manage_pages";

    //    if (Request["code"] == null)
    //    {
    //        Response.Redirect(string.Format("https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}",app_id,Request.Url.AbsoluteUri, scope));

    //}else
    //    {
    //        Dictionary<string, string> tokens = new Dictionary<string, string>();
    //        string url = string.Format("https://graph.facebook.com/oauth/acces_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}", app_id, Request.Url.AbsoluteUri, scope, Request["code"].ToString(), app_secret);
    //        HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

    //        using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
    //        {
    //            StreamReader reader = new StreamReader(response.GetResponseStream());
    //            string vals = reader.ReadToEnd();
    //            foreach (string token in vals.Split('&'))
    //            {

    //                tokens.Add(token.Substring(0, token.IndexOf("=")), token.Substring(token.IndexOf("=") + 1, token.Length - token.IndexOf("=")));
    //            }
    //        }
    //        string access_token = tokens["acces_token"];

    //        var client = new FacebookClient(access_token);
    //        client.Post("/me/feed", new { message = "mensaje a publicar" });

    //    }



    //}

}