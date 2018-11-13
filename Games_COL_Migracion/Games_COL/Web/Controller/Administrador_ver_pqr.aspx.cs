using Logica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;

public partial class View_Administrador_ver_pqr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        Int32 idioma = 1;
        Int32 id_pagina = 22;
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
    }

    protected void DL_verPQR_RowDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            try
            {
                ((Label)e.Item.FindControl("LB_autor")).Text = ((Hashtable)Session["mensajes"])["LB_autor"].ToString();
                ((Label)e.Item.FindControl("LB_idPQR")).Text = ((Hashtable)Session["mensajes"])["LB_idPQR"].ToString();
                ((Label)e.Item.FindControl("LB_tipoSolicitud")).Text = ((Hashtable)Session["mensajes"])["LB_tipoSolicitud"].ToString();
                ((Label)e.Item.FindControl("LB_tituloPost")).Text = ((Hashtable)Session["mensajes"])["LB_tituloPost"].ToString();
                ((Button)e.Item.FindControl("BT_resolver")).Text = ((Hashtable)Session["mensajes"])["BT_resolver"].ToString();
                ((Button)e.Item.FindControl("BT_ignorar")).Text = ((Hashtable)Session["mensajes"])["BT_ignorar"].ToString();
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

    protected void BT_resolver_Click(object sender, EventArgs e)
    {

        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_muestraId");
        string ID = lblid.Text;
        Session["parametro"] = ID;
        int b = int.Parse(Session["id"].ToString());

        string ui = b.ToString();
        string par = ID;


        U_user dat = new U_user();
        L_Usercs llamar = new L_Usercs();

        dat = llamar.verPQRCompleto();

        Response.Redirect(dat.Link_observador );

 
    }

    protected void BT_ignorar_Click(object sender, EventArgs e)
    {

        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        L_persistencia per = new L_persistencia();
        Entity_pqr ent = new Entity_pqr();

        Label lblid = (Label)item.FindControl("LB_muestraId");
        string ID = lblid.Text;
        Int32 id = int.Parse(lblid.Text);
        int b = int.Parse(Session["id"].ToString());

        L_Usercs user = new L_Usercs();
        U_Datospqr pqr = new U_Datospqr();
        pqr.Id_pqr = id;

        ent.Id_pqr = id;


        Entity_usuario us = new Entity_usuario();
        object obj = new object();
        obj = ent;
        string schema = "usuario";
        string tabla = "pqr";
        us.Nombre = Session["id"].ToString();
        per.auditoriaEliminar(obj, us, schema, tabla);

        per.borrarPQR(ent);

        //user.ignorarPQR(pqr);


        U_user dat = new U_user();
        L_Usercs llamar = new L_Usercs();

        dat = llamar.verPQR();

        Response.Redirect(dat.Link_observador);
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {

        U_user dat = new U_user();
        L_Usercs llamar = new L_Usercs();

        dat = llamar.retornoAdmin();

        Response.Redirect(dat.Link_observador);

    }
}