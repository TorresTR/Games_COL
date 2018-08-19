using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();


        EDatosCrearPost doc = new EDatosCrearPost();
        EDatosComenatrio comenta = new EDatosComenatrio();
        DAOUsuario dac = new DAOUsuario();
        ClientScriptManager cm = this.ClientScript;
        doc.Id = int.Parse(Request.Params["parametro"]);
        int dato = int.Parse(Request.Params["parametro"]);
        int dato2 = int.Parse(Request.Params["userid"]);


        DataTable regis = dac.verpag(doc);




        if (regis.Rows.Count > 0)
        {

            LB_muestraPag.Text = regis.Rows[0]["contenido"].ToString();
            LB_autor.Text = regis.Rows[0]["autor"].ToString();

        }


        DataTable punt = dac.verpuntos(doc);
       

        GV_comentariosuser.DataSource = dac.ObtenerComentUS(dato,dato2);
        GV_comentariosuser.DataBind();
    }

    protected void BT_eliminar_Click(object sender, EventArgs e)
    {
        DAOUsuario dac = new DAOUsuario();
        Button bt = (Button)sender;
        TableCell tableCell = (TableCell)bt.Parent;
        GridViewRow row = (GridViewRow)tableCell.Parent;
        GV_comentariosuser.SelectedIndex = row.RowIndex;
        int fila = row.RowIndex;

        int h = int.Parse(Request.Params["parametro"]);
        int b = int.Parse(Request.Params["userid"]);
        int IdRecogido = int.Parse(((Label)row.Cells[fila].FindControl("Label1")).Text);

        
        dac.EliminarComent(IdRecogido);
        Response.Redirect("Usuario_misComents.aspx?parametro=" + h + "&userid=" + b);

    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("Usuario_comentarios.aspx?userid=" + b);
    }
}