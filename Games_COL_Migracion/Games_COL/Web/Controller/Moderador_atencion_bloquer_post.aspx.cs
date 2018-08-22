using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Moderador_atencion_bloquer_post : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Cache.SetNoStore();
    }

    protected void BT_vermas_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_idPost");
        string ID = lblid.Text;

        int b = int.Parse(Request.Params["userid"]);


        Response.Redirect("Moderador_verMasPostReportado.aspx?parametro=" + ID.Trim() + "&userid=" + b);
    }

    protected void BT_bloquear_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_idPost");
        string ID = lblid.Text;

        int b = int.Parse(Request.Params["userid"]);
        int x = 2;
        int h = int.Parse(ID);
        int z = 1;

        DAOUsuario dac = new DAOUsuario();

        dac.actualizarBloqueo(h, b, x,z);

        int t = int.Parse(Request.Params["userid"]);


        Response.Redirect("Moderador_atencion_bloquer_post.aspx?userid=" + t);
    }

    protected void Bt_volver_Click(object sender, EventArgs e)
    {
        int t = int.Parse(Request.Params["userid"]);
        Response.Redirect("Moderador.aspx?userid=" + t);
    }
}