using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;

namespace Datos
{
    public class D_User
    {
        public DataTable obtenerPostobser()
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_post", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;



                conection.Open();
                dataAdapter.Fill(Post);
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

            return Post;

        }

        public DataTable verpag(U_userCrearpost datos)
        {
            DataTable Documentos = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.ver", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = datos.Id;
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                conection.Open();
                dataAdapter.Fill(Documentos);
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
            return Documentos;
        }

        public DataTable verpuntos(U_userCrearpost datos)
        {
            DataTable Documentos = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.ver_puntos", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = datos.Id;
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                conection.Open();
                dataAdapter.Fill(Documentos);
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
            return Documentos;
        }


        public DataTable ObtenerComent(U_userCrearpost dato)
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_Coment", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = dato.Comentarios1;



                conection.Open();
                dataAdapter.Fill(Post);
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

            return Post;

        }

    }
}
