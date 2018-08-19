using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_registro : System.Web.UI.Page
{
    DAOUsuario archivo = new DAOUsuario();
    Edatos datos = new Edatos();
    private String confirma;

    DAOUsuario dao = new DAOUsuario();

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
    }

    protected void B_registrar_Click(object sender, EventArgs e)
    {
        
        ClientScriptManager cm = this.ClientScript;
        datos.Nombre = TB_nombre.Text.ToString();
        datos.Nick = TB_nick.Text.ToString();
        datos.Pass = TB_pass.Text.ToString();
        datos.Correo = TB_email.Text.ToString();
        confirma = TB_confirmapass.Text.ToString();
        datos.Puntos = 0;
        datos.Rol = 1;
        datos.Rango = 1;
        datos.Estado = 1;
        datos.Fecha = DateTime.Now;


        if (datos.Pass == confirma)
        {


            System.Data.DataTable validez = archivo.validarNick(datos.Nick, datos.Correo);
            if (int.Parse(validez.Rows[0]["id"].ToString()) > 0)
            {
                
                    archivo.insertarUsuario(datos);
                    cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Usuario registrado con exito');</script>");
                    Response.Redirect("Ingresar.aspx");
                
            }
            else
            {
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Nick o correo ya existente');</script>");
            }

        }
        else
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Las contraseñas no coinciden');</script>");
        }

    }


    protected void B_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("observador.aspx");
    }
}