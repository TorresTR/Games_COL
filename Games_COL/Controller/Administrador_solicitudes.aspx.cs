using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BT_ascender_Click(object sender, EventArgs e)
    {
        DAOUsuario dato = new DAOUsuario();
        ClientScriptManager cm = this.ClientScript;

        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");
        string ID = lblid.Text;
        int b = int.Parse(Request.Params["userid"]);
        int h = int.Parse(ID);

        dato.Ascenso(h);
        cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Usuario Ascendido');</script>");
        Response.Redirect("Administrador_solicitudes.aspx?userid=" + b);
    }

    protected void BT_ignorar_Click(object sender, EventArgs e)
    {
        DAOUsuario dato = new DAOUsuario();
        ClientScriptManager cm = this.ClientScript;

        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");
        string ID = lblid.Text;
        int b = int.Parse(Request.Params["userid"]);
        int h = int.Parse(ID);

        dato.IgnorarSolicitud(h);
        cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Solicitud Ignorada');</script>");
        Response.Redirect("Administrador_solicitudes.aspx?userid=" + b);
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("Administrador.aspx?userid=" + b);
    }
}