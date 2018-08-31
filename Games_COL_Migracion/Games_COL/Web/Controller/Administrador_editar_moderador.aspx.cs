using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        L_Usercs dac = new L_Usercs();
        int a = int.Parse(Request.Params["parametro"]);

        DataTable regis = dac.verUser(a);
        U_Datos moder = dac.datosModerador(regis);
        
            LB_id.Text = moder.Id;
            LB_nombre.Text = moder.Nombre;
            LB_nick.Text = moder.Nick;
            LB_puntos.Text = moder.Puntos;
            LB_rango.Text = moder.Confirma;
            LB_correo.Text = moder.Correo;

            BT_guardar.Visible = moder.Bin;
            TB_nombre.Visible = moder.Bin;
            TB_nick.Visible = moder.Bin;
            TB_puntos.Visible = moder.Bin;
            DDL_rango.Visible = moder.Bin;
            TB_correo.Visible = moder.Bin;

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
        Response.Redirect("Administrador_listado_user.aspx?userid=" + b);
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