using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;

public partial class View_Administrador_miNoticia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        
       
        L_Usercs dac = new L_Usercs();


        int dato = int.Parse(Session["user_id"].ToString());

        GV_miPost.DataSource = dac.minoticiagv(dato);
        GV_miPost.DataBind();

    }

    protected void BT_editar_Click(object sender, EventArgs e)
    {


        Button bt = (Button)sender;
        TableCell tableCell = (TableCell)bt.Parent;
        GridViewRow row = (GridViewRow)tableCell.Parent;
        GV_miPost.SelectedIndex = row.RowIndex;
        int fila = row.RowIndex;


        int b = int.Parse(Session["user_id"].ToString());
        string IdRecogido = ((Label)row.Cells[fila].FindControl("LB_id")).Text;
        Session["parametro"] = IdRecogido;
        U_user dat = new U_user();
        L_Usercs llamar = new L_Usercs();

        string c = b.ToString();
        


        dat = llamar.recargaminoticiaAdmin();


        Response.Redirect(dat.Link_observador );
     
    }

    protected void BT_eliminar_Click(object sender, EventArgs e)
    {


        Button bt = (Button)sender;
        TableCell tableCell = (TableCell)bt.Parent;
        GridViewRow row = (GridViewRow)tableCell.Parent;
        GV_miPost.SelectedIndex = row.RowIndex;
        int fila = row.RowIndex;


        int b = int.Parse(Session["user_id"].ToString());
        string IdRecogido = ((Label)row.Cells[fila].FindControl("LB_id")).Text;
        Session["IdRecogido"] = IdRecogido;
        int x = int.Parse(IdRecogido);

        L_Usercs dac = new L_Usercs();
        dac.eliminarminoticia(x);

        U_user dat = new U_user();
        L_Usercs llamar = new L_Usercs();

        string c = b.ToString();


        dat = llamar.recargapgnotiAdmin();
        Response.Redirect(dat.Link_observador);

    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();


        dat = llamado.retornoAdmin();

        Response.Redirect(dat.Link_observador );
    }
}