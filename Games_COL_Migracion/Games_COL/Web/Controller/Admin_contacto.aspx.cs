using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

public partial class View_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        L_Usercs llamando = new L_Usercs();



        GV_contactenos.DataSource = llamando.traerContactenos();
        GV_contactenos.DataBind();
        BT_respuestaContacto.Visible = false;
        TB_respuesta.Visible = false;
    }

    protected void BT_respuestaContacto_Click(object sender, EventArgs e)
    {

        L_Usercs llamado = new L_Usercs();
        l_sw corre = new l_sw();

        string men = corre.Respuesta(LB_corr.Text,TB_respuesta.Text);
        llamado.cambiaestadoRespuestacontacto(LB_corr.Text, LB_cargaSugere.Text);

        TB_respuesta.Text = "";
        BT_respuestaContacto.Visible = false;
        TB_respuesta.Visible = false;
        LB_cargaSugere.Text = "";
        GV_contactenos.DataSource = llamado.traerContactenos();
        GV_contactenos.DataBind();
        Response.Write("<Script Languaje='JavaScript'>parent.alert('" + men + "');</Script>");

    }

    protected void BT_responder_Click(object sender, EventArgs e)
    {
        Button bt = sender as Button;
        GridViewRow grid = (GridViewRow)bt.NamingContainer;
        string sugerencia = ((Label)grid.FindControl("LB_sugerencia")).Text;
        string correo = ((Label)grid.FindControl("LB_correo")).Text;

        LB_cargaSugere.Text = sugerencia;
        LB_corr.Text = correo;
        BT_respuestaContacto.Visible = true;
        TB_respuesta.Visible = true;
    }
}