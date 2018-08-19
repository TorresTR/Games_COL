using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_usuarios_pqr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
    }

    protected void BT_envio_Click(object sender, EventArgs e)
    {

        EDatospqr pqr = new EDatospqr();
        DAOUsuario dao = new DAOUsuario();

        int b = int.Parse(Request.Params["userid"]);

        DateTime dt = DateTime.Now;

        pqr.Asunto = TB_asunto.Text.ToString();
        pqr.Id_pqrestado = int.Parse(DDL_tipoSolicitud.SelectedValue.ToString());
        pqr.Contenido = TB_solicitud.Text.ToString();
        pqr.Fecha = dt;
        pqr.Id_user = b;

        dao.insertarPQR(pqr);
        
        Response.Redirect("usuarios.aspx?userid=" + b);

    }

    protected void B_volver_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("usuarios.aspx?userid=" + b);
    }
}