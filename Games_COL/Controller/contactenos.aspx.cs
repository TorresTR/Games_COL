using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_contactenos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
    }

    protected void BT_envioContacto_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        EDatossugerencia sugere = new EDatossugerencia();
        DAOUsuario user = new DAOUsuario();

        sugere.Correo = TB_correo.Text.ToString();
        sugere.Sugerencia = TB_sugerencias.Text.ToString();

        user.insertarSugerencia(sugere);
        cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Solicitud registrada con exito');</script>");
        Response.Redirect("observador.aspx");
        
        
    }

    protected void B_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("observador.aspx");
    }
}