using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Moderador_ver_pqr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
    }

    

    protected void BT_resolver_Click(object sender, EventArgs e)
    {

        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_muestraId");
        string ID = lblid.Text;

        int b = int.Parse(Request.Params["userid"]);


        Response.Redirect("Moderador_verpqrCompleto.aspx?parametro=" + ID.Trim() + "&userid=" + b);
    }

    protected void BT_ignorar_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_muestraId");
        string ID = lblid.Text;
        Int32 id = int.Parse(lblid.Text);
        int b = int.Parse(Request.Params["userid"]);

        DAOUsuario user = new DAOUsuario();

        user.ignorarpqr(id);
        Response.Redirect("Moderador_ver_pqr.aspx?userid=" + b);

    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("Moderador.aspx?userid=" + b);
    }
}