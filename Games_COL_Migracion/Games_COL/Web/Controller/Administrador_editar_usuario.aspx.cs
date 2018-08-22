using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Cache.SetNoStore();

        DAOUsuario dac = new DAOUsuario();
        int a = int.Parse(Request.Params["parametro"]);

        DataTable regis = dac.VerUser(a);

        if (regis.Rows.Count > 0)
        {
            LB_id.Text = regis.Rows[0]["id"].ToString();
            LB_nombre.Text = regis.Rows[0]["nombre"].ToString();
            LB_nick.Text = regis.Rows[0]["nick"].ToString();
            LB_puntos.Text = regis.Rows[0]["puntos"].ToString();
            LB_rango.Text = regis.Rows[0]["tipo"].ToString();
            LB_correo.Text = regis.Rows[0]["correo"].ToString();

            BT_guardar.Visible = false;
            TB_nombre.Visible = false;
            TB_nick.Visible = false;
            TB_puntos.Visible = false;
            DDL_rango.Visible = false;
            TB_correo.Visible = false;
            
        }
    }

    protected void BT_guardar_Click(object sender, EventArgs e)
    {
        DAOUsuario dac = new DAOUsuario();
        Edatos user = new Edatos();
        int b = int.Parse(Request.Params["userid"]);

        user.Id = int.Parse(LB_id.Text.ToString());
        user.Nombre = TB_nombre.Text.ToString();
        user.Nick = TB_nick.Text.ToString();
        user.Puntos = int.Parse(TB_puntos.Text.ToString());
        user.Rango = int.Parse(DDL_rango.SelectedValue.ToString());
        user.Correo = TB_correo.Text.ToString();
        

        dac.actualizarUser(user);
        Response.Redirect("Administrador_listado_user.aspx?userid="+b);
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("Administrador_listado_user.aspx?userid=" + b);
    }

    protected void BT_editar_Click(object sender, EventArgs e)
    {
        TB_nombre.Text = LB_nombre.Text;
        TB_nick.Text = LB_nick.Text;
        TB_puntos.Text = LB_puntos.Text;
        TB_correo.Text = LB_correo.Text;

        BT_guardar.Visible = true;
        TB_nombre.Visible = true;
        TB_nick.Visible = true;
        TB_puntos.Visible = true;
        DDL_rango.Visible = true;
        TB_correo.Visible = true;
    }
}