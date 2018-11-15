using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            
            ServicioColegio.WSEstudiantesOnceSoapClient obwsClienteSoap = new ServicioColegio.WSEstudiantesOnceSoapClient();


            ServicioColegio.clsSeguridadOnce obclsSeguridad = new ServicioColegio.clsSeguridadOnce()
            {
                stToken = "once" 
            };

            string stToken = obwsClienteSoap.AutenticacionUsuario(obclsSeguridad);

            if (stToken.Equals("-1")) throw new Exception("Requiere Validacion");

            obclsSeguridad.AutenticacionToken = stToken;


           
            GV_estudiantes.DataSource = obwsClienteSoap.Datospersonales(obclsSeguridad);
            GV_estudiantes.DataBind();

            

        }
        catch (Exception ex)
        {
            Response.Write("<Script Languaje='JavaScript'>parent.alert('" + ex.Message + "');</Script>");
        }

    }

    protected void BT_voler_Click(object sender, EventArgs e)
    {
        Response.Redirect("Administrador.aspx");
    }

    protected void BT_invitar_Click(object sender, EventArgs e)
    {
        Button bt = sender as Button;
        GridViewRow grid = (GridViewRow)bt.NamingContainer;
        string correoinv = ((Label)grid.FindControl("Label1")).Text;

        l_sw corre = new l_sw();

        string men = corre.Invitaruser(correoinv);

        Response.Write("<Script Languaje='JavaScript'>parent.alert('" + men + "');</Script>");
    }
}