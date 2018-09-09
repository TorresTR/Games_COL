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
    }

    protected void BT_bloquear_Click(object sender, EventArgs e)
    {


        L_Usercs dato = new L_Usercs();
       

        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");
        string ID = lblid.Text;
        Session["IdRecogido"] = ID;
        int b = int.Parse(Session["user_id"].ToString());
        int h = int.Parse(ID);

        dato.eliminarComent(h);

        U_user data = new U_user();
        L_Usercs llamado = new L_Usercs();

        data = llamado.moderadoradmincoment();
        Response.Redirect(data.Link_observador);
        
    }

    protected void Bt_volver_Click(object sender, EventArgs e)
    {

        int t = int.Parse(Session["user_id"].ToString());

        string dat = t.ToString();



        U_user data = new U_user();
        L_Usercs llamado = new L_Usercs();

        data = llamado.irHomeModerador();
        Response.Redirect(data.Link_observador);
    }
}