using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Administrador_admin_coment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
    }

    protected void BT_bloquear_Click(object sender, EventArgs e)
    {
        L_Usercs dato = new L_Usercs();
        ClientScriptManager cm = this.ClientScript;
        

        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");
        string ID = lblid.Text;
        int h = int.Parse(ID);

        dato.eliminarComent(h);
        LB_mensaje.Text = "Comentario Bloqueado";

        U_user dat = dato.administrarComentario();

        Response.Redirect(dat.Link_observador);
    }

    protected void Bt_volver_Click(object sender, EventArgs e)
    {
        
        L_Usercs dato = new L_Usercs();
        U_user dat = dato.retornoAdmin();

        Response.Redirect(dat.Link_observador);
    }
}