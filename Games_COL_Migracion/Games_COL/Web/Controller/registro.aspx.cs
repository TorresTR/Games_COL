using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_registro : System.Web.UI.Page
{
    
    U_Datos datos = new U_Datos();
    L_Usercs dat = new L_Usercs();
    

    

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
        datos.Confirma = TB_confirmapass.Text.ToString();
        datos.Puntos = 0;
        datos.Rol = 1;
        datos.Rango = 1;
        datos.Estado = 1;
        datos.Fecha = DateTime.Now;


        datos = dat.insertarUsuarionuevo(datos);
        cm.RegisterClientScriptBlock(this.GetType(), "", datos.Mensaje1);
        Response.Redirect(datos.Link);
    }


    protected void B_volver_Click(object sender, EventArgs e)
    {

        U_user inicio = new U_user();
        L_Usercs llamado = new L_Usercs();

        inicio = llamado.irInicio();
        Response.Redirect(inicio.Link_demas);
    }
}