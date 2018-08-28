using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Text;
using Utilitarios;
using Logica;

public partial class View_Generar_token : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
    }

    

    protected void B_aceptar_Click(object sender, EventArgs e)
    {
        L_Usercs log = new L_Usercs();
        string valida = TB_nick.Text;
        System.Data.DataTable validez = log.genera(valida);
        string mensaje = log.Token(validez);
        
        L_error.Text =mensaje;
        

    }

    

    protected void B_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("Observador.aspx");
    }
}