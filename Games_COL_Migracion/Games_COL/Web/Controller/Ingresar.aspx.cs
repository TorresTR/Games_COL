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

    }




    protected void BT_Ingresar_Click(object sender, EventArgs e)
    {

        EUsuario usuario = new EUsuario();
        DAOUsuario datos = new DAOUsuario();
        usuario.user_name1 = TB_UserName.Text.ToString();
        usuario.Clave = TB_Contraseña.Text.ToString();

        DataTable registros = datos.loggin(usuario);

        if (registros.Rows.Count > 0)
        {

            switch (int.Parse(registros.Rows[0]["rol"].ToString()))
            {
                case 1:
                    Session["nombre"] = registros.Rows[0]["nombre"].ToString();
                    Session["user_id"] = registros.Rows[0]["user_id"].ToString();

                    int b = Convert.ToInt32(registros.Rows[0]["user_id"].ToString());

                    EUsuario datosUsuario = new EUsuario();
                    MAC datosConexion = new MAC();

                    datosUsuario.UserId = int.Parse(Session["user_id"].ToString());
                    datosUsuario.Ip = datosConexion.ip();
                    datosUsuario.Mac = datosConexion.mac();
                    datosUsuario.Session = Session.SessionID;

                    datos.guardadoSession(datosUsuario);

                    Response.Redirect("usuarios.aspx?userid="+b);
                    break;

                case 2:
                    Session["nombre"] = registros.Rows[0]["nombre"].ToString();
                    Session["user_id"] = registros.Rows[0]["user_id"].ToString();


                    int bmod = Convert.ToInt32(registros.Rows[0]["user_id"].ToString());

                    EUsuario datosUsuariomod = new EUsuario();
                    MAC datosConexionMod = new MAC();

                    datosUsuariomod.UserId = int.Parse(Session["user_id"].ToString());
                    datosUsuariomod.Ip = datosConexionMod.ip();
                    datosUsuariomod.Mac = datosConexionMod.mac();
                    datosUsuariomod.Session = Session.SessionID;

                    datos.guardadoSession(datosUsuariomod);

                    Response.Redirect("Moderador.aspx?userid=" + bmod);
                    break;

                case 3:
                    Session["nombre"] = registros.Rows[0]["nombre"].ToString();
                    Session["user_id"] = registros.Rows[0]["user_id"].ToString();


                    int badmon = Convert.ToInt32(registros.Rows[0]["user_id"].ToString());

                    EUsuario datosUsuariadmon = new EUsuario();
                    MAC datosConexionadmon = new MAC();

                    datosUsuariadmon.UserId = int.Parse(Session["user_id"].ToString());
                    datosUsuariadmon.Ip = datosConexionadmon.ip();
                    datosUsuariadmon.Mac = datosConexionadmon.mac();
                    datosUsuariadmon.Session = Session.SessionID;

                    datos.guardadoSession(datosUsuariadmon);

                    Response.Redirect("Administrador.aspx?userid=" + badmon);
                    break;
                default:
                     L_error.Text = "Usuario no existe";
                    break;
            }
        }
        else{
            L_error.Text = "Usuario o Clave Incorrecta";
        }
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
