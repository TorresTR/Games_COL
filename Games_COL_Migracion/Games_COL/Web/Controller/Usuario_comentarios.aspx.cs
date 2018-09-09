using System;
using System.Collections.Generic;
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




        L_Usercs dac = new L_Usercs();
        U_misPost dat = new U_misPost();


        int dato = int.Parse(Session["user_id"].ToString());

        dat.Dato1 = dato;

        DL_post.DataSource = dac.misPostcomentados(dat);
        DL_post.DataBind();
    }



    protected void BT_vermas_Click(object sender, EventArgs e)
    {


        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");
        string ID = lblid.Text;

        int b = int.Parse(Session["user_id"].ToString());
        Session["parametro"] = ID;
        string x = b.ToString();


        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();

        dat = llamado.redireccionMiscoment();

        Response.Redirect(dat.Link_observador );

       
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {


        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();

        dat = llamado.volverUsuariosRegistrado();

        Response.Redirect(dat.Link_observador );
    }
}