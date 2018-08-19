using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Moderador_verMasPostReportado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        DAOUsuario dac = new DAOUsuario();
        EDatosCrearPost doc = new EDatosCrearPost();

        doc.Id = int.Parse(Request.Params["parametro"]);

        DataTable regis = dac.verpag(doc);




        if (regis.Rows.Count > 0)
        {

            LB_contenido.Text = regis.Rows[0]["contenido"].ToString();
            LB_mostrarAutor.Text = regis.Rows[0]["autor"].ToString();

        }
    }





    protected void BT_volver_Click(object sender, EventArgs e)
    {
      int b = int.Parse(Request.Params["userid"]);
      Response.Redirect("Moderador_atencion_bloquer_post.aspx?userid=" + b);
    }
}