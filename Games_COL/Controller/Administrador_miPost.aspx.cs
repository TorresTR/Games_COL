using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Administrador_miPost : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        DAOUsuario dac = new DAOUsuario();


        int dato = int.Parse(Request.Params["userid"]);

        GV_miPost.DataSource = dac.ObtenermisPost(dato);
        GV_miPost.DataBind();

    }

    protected void BT_editar_Click(object sender, EventArgs e)
    {
        Button bt = (Button)sender;
        TableCell tableCell = (TableCell)bt.Parent;
        GridViewRow row = (GridViewRow)tableCell.Parent;
        GV_miPost.SelectedIndex = row.RowIndex;
        int fila = row.RowIndex;


        int b = int.Parse(Request.Params["userid"]);
        string IdRecogido = ((Label)row.Cells[fila].FindControl("LB_id")).Text;

        Response.Redirect("Administrador_editar.aspx?userid=" + b + "&parametro=" + IdRecogido);
    }

    protected void BT_eliminar_Click(object sender, EventArgs e)
    {
        Button bt = (Button)sender;
        TableCell tableCell = (TableCell)bt.Parent;
        GridViewRow row = (GridViewRow)tableCell.Parent;
        GV_miPost.SelectedIndex = row.RowIndex;
        int fila = row.RowIndex;


        int b = int.Parse(Request.Params["userid"]);
        string IdRecogido = ((Label)row.Cells[fila].FindControl("LB_id")).Text;

        int x = int.Parse(IdRecogido);

        DAOUsuario dac = new DAOUsuario();
        dac.eliminarMiPost(x);

        Response.Redirect("Administrador_miPost.aspx?userid=" + b);
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("Administrador.aspx?userid=" + b);
    }
}