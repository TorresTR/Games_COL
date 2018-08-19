using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Administrador_verpqrCompleto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        DAOUsuario user = new DAOUsuario();
        EDatospqr respuesa = new EDatospqr();

        respuesa.Id_pqr = int.Parse(Request.Params["parametro"]);



        DataTable regis = user.verpqr(respuesa);

        if (regis.Rows.Count > 0)
        {

            LB_muestraPag.Text = regis.Rows[0]["contenido"].ToString();
            LB_autor.Text = regis.Rows[0]["autor"].ToString();


        }
    }

    protected void BT_responder_Click(object sender, EventArgs e)
    {
        DAOUsuario user = new DAOUsuario();
        EDatospqr respuesa = new EDatospqr();

        int b = int.Parse(Request.Params["userid"]);
        int q = int.Parse(Request.Params["parametro"]);
        int a = 1;
        DateTime dt = DateTime.Now;

        respuesa.Id_respondedor = b;
        respuesa.Fecha_respuesta = dt;
        respuesa.Respuesta = TB_respuestapqr.Text.ToString();
        respuesa.Id_pqr = q;
        respuesa.Estado_respuesta = a;

        user.actualizarPQR(respuesa);
        Response.Redirect("Administrador_ver_pqr.aspx?parametro=" + q + "&userid=" + b);
    }

    protected void B_volver_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        int c = int.Parse(Request.Params["parametro"]);
        Response.Redirect("Administrador_ver_pqr.aspx?parametro=" + c + "&userid=" + b);
    }
}