using Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Logica;
using Utilitarios;
using System.Collections;

public partial class View_Moderador_ver_pqr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        Int32 idioma = 1;
        Int32 id_pagina = 45;
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
        DL_PQR.DataBind();
    }

    protected void DL_noticias_RowDataBound(object sender, DataListItemEventArgs e)
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

        string b = Session["user_id"].ToString();
        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_muestraId");
        string ID = lblid.Text;
        Session["IdRecogido"] = ID;
        

        Response.Redirect("Moderador_verpqrCompleto.aspx" );


    }

    protected void BT_ignorar_Click(object sender, EventArgs e)
    {
        string q = Session["user_id"].ToString();
        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_muestraId");
        string ID = lblid.Text;
        Int32 id = int.Parse(lblid.Text);
        int b = int.Parse(q);
        U_Datospqr pqr = new U_Datospqr();
        pqr.Id_pqr = id;
        D_User user = new D_User();


        user.ignorarpqr(pqr);
        Response.Redirect("Moderador_ver_pqr.aspx");


    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("Moderador.aspx");

      
    }
}