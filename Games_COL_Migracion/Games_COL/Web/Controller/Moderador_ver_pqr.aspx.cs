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

public partial class View_Moderador_ver_pqr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
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