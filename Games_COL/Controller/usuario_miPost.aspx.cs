using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_usuario_miPost : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        DAOUsuario dac = new DAOUsuario();


        int dato = int.Parse(Request.Params["userid"]);

        GV_miPost.DataSource = dac.ObtenermisPost(dato);
        GV_miPost.DataBind();
        try
        {
            InfoR_usuario reporte = ObtenerInforme();
            CRS_reporte_usuario.ReportDocument.SetDataSource(reporte);
            CRV_reporteUsuario.ReportSource = CRS_reporte_usuario;
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected InfoR_usuario ObtenerInforme()
    {
        DataRow fila;  //dr
        DataTable informacion = new DataTable(); //dt
        InfoR_usuario datos = new InfoR_usuario();
        int dato = int.Parse(Request.Params["userid"]);

        informacion = datos.Tables["Post"];

        DAOUsuario persona = new DAOUsuario();

        DataTable intermedio = persona.ObtenerPostR(dato);

        for (int i = 0; i < intermedio.Rows.Count; i++)
        {
            fila = informacion.NewRow();

            fila["Titulo"] = intermedio.Rows[i]["titulo"].ToString();
            fila["Fecha"] = intermedio.Rows[i]["fecha"].ToString();
            fila["Estado"] = intermedio.Rows[i]["estado"].ToString();
            fila["Etiqueta"] = intermedio.Rows[i]["etiqueta"].ToString();


            informacion.Rows.Add(fila);
        }

        return datos;
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

        Response.Redirect("usuario_editar.aspx?userid=" + b + "&parametro=" + IdRecogido);
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

        Response.Redirect("usuario_miPost.aspx?userid=" + b );
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("usuarios.aspx?userid=" + b);
    }
}