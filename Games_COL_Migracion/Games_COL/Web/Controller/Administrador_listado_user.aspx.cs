using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Administrador_listado_user : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void BT_editar_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");
        string ID = lblid.Text;
        int h = int.Parse(ID);


        int b = int.Parse(Request.Params["userid"]);
        

        Response.Redirect("Administrador_editar_usuario.aspx?userid=" + b + "&parametro=" + h);
    }

    protected void BT_eliminar_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");
        string ID = lblid.Text;
        int h = int.Parse(ID);


        int b = int.Parse(Request.Params["userid"]);
        

       

        DAOUsuario dac = new DAOUsuario();
        dac.eliminarUsuario(h);

        Response.Redirect("Administrador_listado_user.aspx?userid=" + b);
    }

    protected void BT_reporUser_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("Administrador_reporteUser.aspx?userid=" + b);
    }

    protected void BT_reporModer_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("Administrador_reporte_Moder.aspx?userid=" + b);
    }

    protected void BT_reporAdmin_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("Administrador_reporte_admin.aspx?userid=" + b);
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("Administrador.aspx?userid=" + b);
    }
}