using Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;

public partial class View_Administrador_listado_user : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void BT_editar_Click(object sender, EventArgs e)
    {

        L_Usercs log = new L_Usercs();
        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");
        string ID = lblid.Text;
        int h = int.Parse(ID);
        U_user dat = new U_user();

        string ui = Session["user_id"].ToString();
        Session["parametro"] = ID;


        dat = log.editarListadoAdmin();

        Response.Redirect(dat.Link_observador);
    }

    protected void BT_eliminar_Click(object sender, EventArgs e)
    {
       
        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");
        string ID = lblid.Text;
        int h = int.Parse(ID);


        
        

       

        L_Usercs dac = new L_Usercs();
        U_user dat = dac.retornoAdmin();

        Response.Redirect(dat.Link_observador );
    }

    protected void BT_reporUser_Click(object sender, EventArgs e)
    {
        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();


        dat = llamado.reporteUser();

        Response.Redirect(dat.Link_observador );

    }

    protected void BT_reporModer_Click(object sender, EventArgs e)
    {
        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();


        dat = llamado.reporteModer();

        Response.Redirect(dat.Link_observador);
    }

    protected void BT_reporAdmin_Click(object sender, EventArgs e)
    {
        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();
 

        dat = llamado.reporteAdmin();

        Response.Redirect(dat.Link_observador );
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();

        dat = llamado.retornoAdmin();

        Response.Redirect(dat.Link_observador);
    }
}