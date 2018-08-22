using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_usuario_verRespuestas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        DAOUsuario dac = new DAOUsuario();

        int dato = int.Parse(Request.Params["idresp"]);

        DataTable dt = dac.ObtenerVerRes(dato);

        LB_verRespuesta.Text = dt.Rows[0]["respuesta"].ToString();
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("usuarios.aspx?userid=" + b);
    }
}