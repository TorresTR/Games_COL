using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Administrador_reporte_admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            InforR_administrador reporte = ObtenerInforme();
            CRS_admin.ReportDocument.SetDataSource(reporte);
            CRV_administrador.ReportSource = CRS_admin;
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected InforR_administrador ObtenerInforme()
    {
        DataRow fila;  //dr
        DataTable informacion = new DataTable(); //dt
        InforR_administrador datos = new InforR_administrador();
        DAOUsuario persona = new DAOUsuario();

        informacion = datos.Tables["Admin"];

        DataTable intermedio = persona.ListarAdministradoresAdmin();

        for (int i = 0; i < intermedio.Rows.Count; i++)
        {
            fila = informacion.NewRow();

            fila["Nick"] = intermedio.Rows[i]["nick"].ToString();
            fila["Puntos"] = int.Parse(intermedio.Rows[i]["puntos"].ToString());
            fila["Rango"] = intermedio.Rows[i]["tipo"].ToString();



            informacion.Rows.Add(fila);
        }
        return datos;
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("Administrador_listado_user.aspx?userid=" + b);
    }
}