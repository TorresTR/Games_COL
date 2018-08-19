using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Administrador_admin_coment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
    }

    protected void BT_bloquear_Click(object sender, EventArgs e)
    {
        DAOUsuario dato = new DAOUsuario();
        ClientScriptManager cm = this.ClientScript;

        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");
        string ID = lblid.Text;
        int b = int.Parse(Request.Params["userid"]);
        int h = int.Parse(ID);

        dato.bloquearComentario(h);
        cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Comentario Bloqueado');</script>");
        Response.Redirect("Administrador_admin_coment.aspx?userid=" + b);
    }

    protected void Bt_volver_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("Administrador.aspx?userid=" + b);
    }
}