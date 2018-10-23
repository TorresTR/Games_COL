using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Dsql
    {

        public DataTable obtenerIdioma(Int32 formulario, int idioma)
        {
            DataTable Usuario = new DataTable();
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("idioma.f_obtener_idioma_formulario", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("@formulario_id", SqlDbType.Int).Value = formulario;
                dataAdapter.SelectCommand.Parameters.Add("@idioma_id", SqlDbType.Int).Value = idioma;

                conection.Open();
                dataAdapter.Fill(Usuario);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return Usuario;
        }
    }
}
