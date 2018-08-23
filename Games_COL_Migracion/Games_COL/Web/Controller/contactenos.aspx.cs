using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_contactenos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
    }

    protected void BT_envioContacto_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        U_Sugerencia sugere = new U_Sugerencia();
        L_Usercs user = new L_Usercs();

        sugere.Correo = TB_correo.Text.ToString();
        sugere.Sugerencia = TB_sugerencias.Text.ToString();

       sugere = user.sugerenciasUsuarios(sugere);

        cm.RegisterClientScriptBlock(this.GetType(), "",sugere.Mensaje );
        Response.Redirect(sugere.Link);
        
        
    }

    protected void B_volver_Click(object sender, EventArgs e)
    {
        U_user inicio = new U_user();
        L_Usercs llamado = new L_Usercs();

        inicio = llamado.irInicio();
        Response.Redirect(inicio.Link_demas);
    }
}