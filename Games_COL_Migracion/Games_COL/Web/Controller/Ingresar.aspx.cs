using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;
using Datos;


public partial class View_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Response.Cache.SetNoStore();

    }




    protected void BT_Ingresar_Click(object sender, EventArgs e)
    {


        U_logueo usuario = new U_logueo();
        U_user link = new U_user();
        D_User datos = new D_User();
        L_Usercs user = new L_Usercs();
        usuario.Nick = TB_UserName.Text.ToString();
        usuario.Pass = TB_Contraseña.Text.ToString();

        DataTable registros = datos.loggin(usuario);
        

        link = user.loggin(registros);
        int b = Convert.ToInt32(registros.Rows[0]["user_id"].ToString());
        
        Response.Redirect(link.Link_demas);

    }



    protected void BT_registro_Click(object sender, EventArgs e)
    {
        Response.Redirect("registro.aspx");
    }

    protected void B_olvido_Click(object sender, EventArgs e)
    {
        Response.Redirect("Generar_token.aspx");
    }

    protected void B_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("observador.aspx");
    }
}
