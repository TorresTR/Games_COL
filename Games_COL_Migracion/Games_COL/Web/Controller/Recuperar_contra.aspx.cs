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
        L_Usercs log = new L_Usercs();
        int cont = Request.QueryString.Count;
        string var = Request.QueryString[0];

        U_token inicio = log.validaToken(cont,var);

        LB_mensaje.Text = inicio.Nombre;
        Session["user_id"] = inicio.Id;
 

    }

    protected void BT_cambiar_contraseña_Click(object sender, EventArgs e)
    {

        L_Usercs user = new L_Usercs();
        U_Datos eUser = new U_Datos();

        eUser.Id = int.Parse(Session["user_id"].ToString());
        eUser.Pass = TB_digite_nueva_contraseña.Text;

         user.contraseña(eUser);

        LB_mensaje.Text = "Su Contraseña ha sido actualizada";
        
    }
}