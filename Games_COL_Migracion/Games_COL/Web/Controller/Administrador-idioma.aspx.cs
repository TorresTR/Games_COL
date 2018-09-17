using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

public partial class View_Default : System.Web.UI.Page
{

    Int32 idio =1;
    Int32 form = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void DDL_lenguaje_SelectedIndexChanged(object sender, EventArgs e)
    {
        L_Usercs log = new L_Usercs();

        idio = int.Parse(DDL_Idioma.SelectedValue.ToString());
        form = int.Parse(DDL_forms.SelectedValue.ToString());
        DataTable datos= log.controles(idio,form);
        GV_controles.DataSource = datos;
        GV_controles.DataBind();

    }

    protected void changePage(object sender, GridViewPageEventArgs e)
    {
        GridView gv = new GridView();
        gv.PageIndex = e.NewPageIndex;
        

    }

    protected void BT_eliminar_Click(object sender, EventArgs e)
    {
        L_Usercs log = new L_Usercs();
        int i = int.Parse(DDL_Idioma.SelectedValue.ToString());
        log.eliminarIdioma(i);
    }

    protected void BT_editar_Click(object sender, EventArgs e)
    {
        TB_cont.Visible = true;
        BT_guardar.Visible = true;
        Button bt = (Button)sender;
        TableCell tableCell = (TableCell)bt.Parent;
        GridViewRow row = (GridViewRow)tableCell.Parent;
        GV_controles.SelectedIndex = row.RowIndex;
        Int32 fila = row.RowIndex;

        int rowindex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
        int id = Convert.ToInt32(GV_controles.DataKeys[rowindex].Values["id"]);
        string contenido = Convert.ToString(GV_controles.DataKeys[rowindex].Values["contenido"]);

        TB_cont.Text = contenido;
        LB_id.Text = id.ToString();

    }

    protected void BT_guardar_Click(object sender, EventArgs e)
    {
        L_Usercs log = new L_Usercs();
        int id = int.Parse(LB_id.Text);
        string cont = TB_cont.Text;
        log.editarCont(id,cont);
        TB_cont.Visible = false;
        BT_guardar.Visible = false;
        GV_controles.DataBind();
    }
}