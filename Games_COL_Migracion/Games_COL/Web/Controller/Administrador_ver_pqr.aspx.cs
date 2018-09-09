using Logica;
using System;
using System.Collections.Generic;
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
    }



    protected void BT_resolver_Click(object sender, EventArgs e)
    {

        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_muestraId");
        string ID = lblid.Text;
        Session["parametro"] = ID;
        int b = int.Parse(Session["user_id"].ToString());

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
        Label lblid = (Label)item.FindControl("LB_muestraId");
        string ID = lblid.Text;
        Int32 id = int.Parse(lblid.Text);
        int b = int.Parse(Session["user_id"].ToString());

        L_Usercs user = new L_Usercs();
        U_Datospqr pqr = new U_Datospqr();
        pqr.Id_pqr = id;

        user.ignorarPQR(pqr);


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