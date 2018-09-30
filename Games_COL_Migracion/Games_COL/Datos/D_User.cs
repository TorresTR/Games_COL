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

        public DataTable comparaerror(int id)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("seguridad.f_traer_errores", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_usuario", NpgsqlDbType.Integer).Value = id;

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


        public DataTable traerPQR(int id)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_traer_pqr", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = id;

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


        public DataTable ObtenerComentRepor()
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_coment_report", conection);
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

        public DataTable ObtenerpsotReportados()
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_posr_reportado", conection);
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


        public DataTable ObtenerSolicitudes()
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_solicitudes_usuarios", conection);
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

        public DataTable actualizarNoticia(U_userCrearpost post)
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_actualizar_mi_noticia", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id_post", NpgsqlDbType.Integer).Value = post.Id;
                dataAdapter.SelectCommand.Parameters.Add("_contenido", NpgsqlDbType.Text).Value = post.Contenido1;
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




        public DataTable eliminarNoticia(U_userCrearpost dato)
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_eliminar_minoticia", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id_post", NpgsqlDbType.Integer).Value = dato.Id;
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


        public DataTable ObtenermisNoticia(U_userCrearpost dato)
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_minoticia", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = dato.Id;

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


        public void insertarNoticias(U_userCrearpost datos)
        {
            DataTable Documentos = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.insertar_noticia", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


                dataAdapter.SelectCommand.Parameters.Add("_titulo", NpgsqlDbType.Text).Value = datos.Titulo;
                dataAdapter.SelectCommand.Parameters.Add("_contenido", NpgsqlDbType.Text).Value = datos.Contenido1;
                dataAdapter.SelectCommand.Parameters.Add("_fecha", NpgsqlDbType.Date).Value = datos.Fecha;
                dataAdapter.SelectCommand.Parameters.Add("_autor", NpgsqlDbType.Integer).Value = datos.Id_user;




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

        }

        public DataTable bloquearComentario(U_user id)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_bloquear_comentario", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_comentario", NpgsqlDbType.Integer).Value = id.Id;

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

        public DataTable eliminarComentario(U_user id)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_eliminar_comentario", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_comentario", NpgsqlDbType.Integer).Value = id.Id;

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

        public void actualizarBloqueo(U_actualizarBloqueo data)
        {
            DataTable Documentos = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.actualizar_estado_bloqueo", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


                dataAdapter.SelectCommand.Parameters.Add("_id_post", NpgsqlDbType.Integer).Value = data.Id_post;
                dataAdapter.SelectCommand.Parameters.Add("_id_user_bloqueador", NpgsqlDbType.Integer).Value = data.User_bloqueador;
                dataAdapter.SelectCommand.Parameters.Add("_estado_bloqueo", NpgsqlDbType.Integer).Value = data.Estado_bloqueo;
                dataAdapter.SelectCommand.Parameters.Add("_respuesta", NpgsqlDbType.Integer).Value = data.Respuesta;



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

        }

        public void bloqueoPost(U_actualizarBloqueo data)
        {
            DataTable Documentos = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.bloqueo_post", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


                dataAdapter.SelectCommand.Parameters.Add("_id_post", NpgsqlDbType.Integer).Value = data.Id_post;

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

        }


        public DataTable ListarUsuariosR()
        {

            DataTable usuarios = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_infoR_usuarios", conection);

                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                conection.Open();
                dataAdapter.Fill(usuarios);
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

            return usuarios;

        }



        public DataTable ObtenerVerRes(U_respuestasPqr dato)
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_pqr_ver", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = dato.Id_respuesta;



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

        public DataTable ObtenerRespuesta(U_respuestasPqr dato)
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_respuesta", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = dato.Id_respuesta;



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

        public DataTable ObtenerPostE(U_misPost id)
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_postC", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = id.Dato1;
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


        public DataTable EliminarComent(U_misPost dato)
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_eliminar_Coment", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = dato.Dato1;



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


        public DataTable ObtenerComentUS(U_misPost dat)
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_Coment_us", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = dat.Dato1;
                dataAdapter.SelectCommand.Parameters.Add("_id_user", NpgsqlDbType.Integer).Value = dat.Dato2;



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




        public DataTable actualizarMipost(U_userCrearpost post)
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_actualizar_mi_post", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id_post", NpgsqlDbType.Integer).Value = post.Id;
                dataAdapter.SelectCommand.Parameters.Add("_contenido", NpgsqlDbType.Text).Value = post.Contenido1;
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


        public DataTable obtenerMipost(int id, int user)
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_miPost", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = id;
                dataAdapter.SelectCommand.Parameters.Add("_id_user", NpgsqlDbType.Integer).Value = user;
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

        public DataTable obtenerUser(int id)
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_usuario", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = id;
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


        public DataTable verEditar(U_misPost datos)
        {
            DataTable Documentos = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.vermipost", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = datos.Id_mipost;
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




        public DataTable eliminarMiPost(U_misPost dato)
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_eliminar_mipost", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id_post", NpgsqlDbType.Integer).Value = dato.Id_mipost;
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


        public DataTable ObtenerPostR(U_misPost id)
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_mipostR", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = id.Id_mipost;


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


        public DataTable ObtenermisPost(U_misPost dato)
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_mipost", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = dato.Id_mipost;



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




        public DataTable ObtenerComentariouserreporte(U_comentarios dato)
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_Coment1", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = dato.Id;



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

        public DataTable ListarUsuarios( )
        {

            DataTable usuarios = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_listar_usuarios", conection);
               
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                conection.Open();
                dataAdapter.Fill(usuarios);
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

            return usuarios;

        }


        public DataTable ListarComent(int id)
        {

            DataTable usuarios = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_comentario", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = id;
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                conection.Open();
                dataAdapter.Fill(usuarios);
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

            return usuarios;

        }


        public DataTable eliminarUsuario(U_user dato)
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_eliminar_usuario", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = dato.Id;
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
        public DataTable Obtenerpqr()
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_pqr", conection);
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

        


        public DataTable ObtenerPqrdatatable()
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_pqr", conection);
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

        public void insertarPQR(U_Datospqr datos)
        {
            DataTable Documentos = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.insertar_pqr", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


                dataAdapter.SelectCommand.Parameters.Add("_asunto", NpgsqlDbType.Text).Value = datos.Asunto;
                dataAdapter.SelectCommand.Parameters.Add("_estado", NpgsqlDbType.Integer).Value = datos.Id_pqrestado;
                dataAdapter.SelectCommand.Parameters.Add("_contenido", NpgsqlDbType.Text).Value = datos.Contenido;
                dataAdapter.SelectCommand.Parameters.Add("_fecha", NpgsqlDbType.Date).Value = datos.Fecha;
                dataAdapter.SelectCommand.Parameters.Add("_id_user", NpgsqlDbType.Integer).Value = datos.Id_user;



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

        }


        public DataTable ObtenerDdl()
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_etiquetas", conection);
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

        public void insertarPost(U_userCrearpost datos)
        {
            DataTable Documentos = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.insertar_post", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


                dataAdapter.SelectCommand.Parameters.Add("_titulo", NpgsqlDbType.Text).Value = datos.Titulo;
                dataAdapter.SelectCommand.Parameters.Add("_contenido", NpgsqlDbType.Text).Value = datos.Contenido1;
                dataAdapter.SelectCommand.Parameters.Add("_fecha", NpgsqlDbType.Date).Value = datos.Fecha;
                dataAdapter.SelectCommand.Parameters.Add("_autor", NpgsqlDbType.Integer).Value = datos.Id_user;
                dataAdapter.SelectCommand.Parameters.Add("_etiqueta", NpgsqlDbType.Integer).Value = datos.Id_etiqueta;
                dataAdapter.SelectCommand.Parameters.Add("_interacciones", NpgsqlDbType.Integer).Value = datos.Interacciones;



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

        }

        public DataTable actualizarpuntoUser(U_Interaccion dato)
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_actualizar_puntopost", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = dato.Id;
                dataAdapter.SelectCommand.Parameters.Add("_puntos", NpgsqlDbType.Integer).Value = dato.Puntos;

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

        public DataTable obtenerUsercrear(U_userCrearpost id)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_usuario_puntosact", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = id.Id;
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


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

        public DataTable ObtenerInteraccion(int dato)
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_interaccion", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = dato;



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


        public DataTable insertarSugerenciaUsuario(U_Sugerencia datos)
        {
            DataTable Documentos = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.insertar_sugerencia", conection);
                dataAdapter.SelectCommand.Parameters.Add("_correo", NpgsqlDbType.Text).Value = datos.Correo;
                dataAdapter.SelectCommand.Parameters.Add("_contenido", NpgsqlDbType.Text).Value = datos.Sugerencia;

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

        public DataTable validarNickusuario(U_Datos dat)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_validar_nick", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_user_name", NpgsqlDbType.Text).Value = dat.Nick;
                dataAdapter.SelectCommand.Parameters.Add("_correo", NpgsqlDbType.Text).Value = dat.Correo;

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

        public DataTable validarIdioma(int idioma)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_validar_idioma", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_idioma", NpgsqlDbType.Integer).Value = idioma;
                

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

        public void insertarUsuario(U_Datos datos)
        {
            DataTable archivo = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_insertar_usuario", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlDbType.Text).Value = datos.Nombre;
                dataAdapter.SelectCommand.Parameters.Add("_nick", NpgsqlDbType.Text).Value = datos.Nick;
                dataAdapter.SelectCommand.Parameters.Add("_correo", NpgsqlDbType.Text).Value = datos.Correo;
                dataAdapter.SelectCommand.Parameters.Add("_pass", NpgsqlDbType.Text).Value = datos.Pass;
                dataAdapter.SelectCommand.Parameters.Add("_puntos", NpgsqlDbType.Integer).Value = datos.Puntos;
                dataAdapter.SelectCommand.Parameters.Add("_rol", NpgsqlDbType.Integer).Value = datos.Rol;
                dataAdapter.SelectCommand.Parameters.Add("_rango", NpgsqlDbType.Integer).Value = datos.Rango;
                dataAdapter.SelectCommand.Parameters.Add("_estado", NpgsqlDbType.Integer).Value = datos.Estado;
                dataAdapter.SelectCommand.Parameters.Add("_fecha", NpgsqlDbType.Date).Value = datos.Fecha;

                conection.Open();
                dataAdapter.Fill(archivo);
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

        }

 

        public void actualizarPQR(U_Datospqr datos)
        {
            DataTable Documentos = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.actualizar_pqr", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


                dataAdapter.SelectCommand.Parameters.Add("_id_pqr", NpgsqlDbType.Integer).Value = datos.Id_pqr;
                dataAdapter.SelectCommand.Parameters.Add("_id_user", NpgsqlDbType.Integer).Value = datos.Id_respondedor;
                dataAdapter.SelectCommand.Parameters.Add("_respuesta", NpgsqlDbType.Text).Value = datos.Respuesta;
                dataAdapter.SelectCommand.Parameters.Add("_fecha", NpgsqlDbType.Date).Value = datos.Fecha_respuesta;
                dataAdapter.SelectCommand.Parameters.Add("_estado_respuesta", NpgsqlDbType.Integer).Value = datos.Estado_respuesta;



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

        }

        public void insertarSesion(int id_user)
        {
            DataTable Documentos = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("seguridad.f_insertar_sesion", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


                dataAdapter.SelectCommand.Parameters.Add("_id_usuario", NpgsqlDbType.Integer).Value = id_user;




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

        }

        public DataTable verpqr(U_Datospqr datos)
        {
            DataTable Documentos = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.verpqr", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = datos.Id_pqr;
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

        public DataTable ignorarpqr(U_Datospqr dato)
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.ignorar_pqr", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = dato.Id_pqr;
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

        public DataTable consultaUsuario(string nick)
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("seguridad.f_traer_usuario", conection);
                dataAdapter.SelectCommand.Parameters.Add("_nick", NpgsqlDbType.Text).Value = nick;
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



        public DataTable ObtenerNoti()
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_noticias", conection);
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

        public DataTable ObtenerpostXbox()
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_post_xbox", conection);
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


        public DataTable ObtenerpostPS()
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_post_ps", conection);
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

        public DataTable ObtenerpostAndroid()
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_post_android", conection);
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

        public DataTable obtenerPostpc()
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_post_pc", conection);
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


        public DataTable verNoticia(U_userCrearpost datos)
        {
            DataTable Documentos = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.ver_noticia", conection);
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


        public DataTable buscarPost(U_user nombre)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_buscar_post", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_titulo", NpgsqlDbType.Text).Value = nombre.Busqueda_Dato;

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


        public DataTable ObtenerComent1(U_comentarios dato)
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_Coment1", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = dato.Id;



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

        public DataTable insertarreporteComentariosUser(U_comentarios datos)
        {
            DataTable Documentos = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.insertar_reporte_coment", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id_coment", NpgsqlDbType.Integer).Value = datos.Id_com_reportado1;
                dataAdapter.SelectCommand.Parameters.Add("_contenido", NpgsqlDbType.Text).Value = datos.Contenido1;
                dataAdapter.SelectCommand.Parameters.Add("_fecha", NpgsqlDbType.Date).Value = datos.Fecha;
                dataAdapter.SelectCommand.Parameters.Add("_id_user", NpgsqlDbType.Integer).Value = datos.Id_user;

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


        public DataTable insertarreporte(U_Datosreporte datos)
        {
            DataTable Documentos = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.insertar_reporte", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id_post", NpgsqlDbType.Integer).Value = datos.Id_post_reportado;
                dataAdapter.SelectCommand.Parameters.Add("_contenido", NpgsqlDbType.Text).Value = datos.Contido_reporte;
                dataAdapter.SelectCommand.Parameters.Add("_fecha", NpgsqlDbType.Date).Value = datos.Fecha_reporte;
                dataAdapter.SelectCommand.Parameters.Add("_id_user", NpgsqlDbType.Integer).Value = datos.User_reportador;

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

        public DataTable loggin(U_logueo datos)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("seguridad.f_loggin", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_nick", NpgsqlDbType.Text).Value = datos.Nick;
                dataAdapter.SelectCommand.Parameters.Add("_contra", NpgsqlDbType.Text).Value = datos.Pass;
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

        public DataTable validaBloqueo(int id)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("seguridad.f_validar_bloqueo", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_usuario", NpgsqlDbType.Integer).Value = id;
                
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


        public DataTable validaSesion(int id)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("seguridad.f_actualizar_sesion", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_user_id", NpgsqlDbType.Integer).Value = id;

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

        public DataTable cerradoSesion(int id)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("seguridad.f_actualizar_cerrar_sesion", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_user_id", NpgsqlDbType.Integer).Value = id;

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

        public DataTable validarErroneo(int id)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("seguridad.f_insertar_erroneo1", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_usuario", NpgsqlDbType.Integer).Value = id;
                
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

        public DataTable guardadoSession(U_session datos)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("seguridad.f_guardado_session1", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_usuario", NpgsqlDbType.Integer).Value = datos.UserId;
                dataAdapter.SelectCommand.Parameters.Add("_ip", NpgsqlDbType.Text).Value = datos.Ip;
                dataAdapter.SelectCommand.Parameters.Add("_mac", NpgsqlDbType.Text).Value = datos.Mac;
                // dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = datos.Session;

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

        public DataTable CargarUsusarios(int b)
        {

            DataTable usuarios = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_listar_usuarios_carga", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = b;
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                conection.Open();
                dataAdapter.Fill(usuarios);
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

            return usuarios;

        }
        public DataTable actualizarRango(U_Datos us)
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_actualizar_rango", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = us.Id;
                dataAdapter.SelectCommand.Parameters.Add("_idr", NpgsqlDbType.Integer).Value = us.Rango;

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

        public DataTable cerrarSession(U_user datos)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("seguridad.f_cerrar_session", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = datos.Session;

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

        public DataTable obtenerpuntsval(Int32 id)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_puntuacionvalida", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = id;
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


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

        public DataTable obtenerUss(Int32 id)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_usuario_puntosact", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = id;
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


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

        public DataTable ObtenerPuntos(Int32 b)
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_puntos", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = b;
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

        public DataTable guardaPuntos(U_userCrearpost datos)
        {
            DataTable Documentos = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.insertar_puntos", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = datos.Id;
                dataAdapter.SelectCommand.Parameters.Add("_puntos", NpgsqlDbType.Integer).Value = datos.Puntos;
                dataAdapter.SelectCommand.Parameters.Add("_puntosa", NpgsqlDbType.Integer).Value = datos.PuntosA;
                dataAdapter.SelectCommand.Parameters.Add("_nump", NpgsqlDbType.Integer).Value = datos.Nump;
                dataAdapter.SelectCommand.Parameters.Add("_id_user", NpgsqlDbType.Integer).Value = datos.Id_user;
                dataAdapter.SelectCommand.Parameters.Add("_interacciones", NpgsqlDbType.Integer).Value = datos.Interacciones;
                dataAdapter.SelectCommand.Parameters.Add("_fecha", NpgsqlDbType.Date).Value = datos.Fecha;


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

        public DataTable actualizarpuntoUser(Int32 id, Int32 puntos)
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_actualizar_puntopost", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = id;
                dataAdapter.SelectCommand.Parameters.Add("_puntos", NpgsqlDbType.Integer).Value = puntos;

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

        public DataTable ValidarPuntuacion(Int32 id_usuario, Int32 id_post)
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_insertar_puntos_us", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id_usuario", NpgsqlDbType.Integer).Value = id_usuario;
                dataAdapter.SelectCommand.Parameters.Add("_id_post", NpgsqlDbType.Integer).Value = id_post;

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

        public DataTable insertarComentarios(U_comentarios datos)
        {
            DataTable Documentos = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.insertar_Comentario", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id_post", NpgsqlDbType.Integer).Value = datos.Id_post;
                dataAdapter.SelectCommand.Parameters.Add("_contenido", NpgsqlDbType.Text).Value = datos.Conetinido1;
                dataAdapter.SelectCommand.Parameters.Add("_id_user", NpgsqlDbType.Integer).Value = datos.Id_user;
                dataAdapter.SelectCommand.Parameters.Add("_interacciones", NpgsqlDbType.Integer).Value = datos.Interaccion;
                dataAdapter.SelectCommand.Parameters.Add("_fecha", NpgsqlDbType.Date).Value = datos.Fecha;

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
        public DataTable SolicitudAscenso(U_Datos datos)
        {

            DataTable puntos = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_validarpuntosuser", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = datos.Id;
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                conection.Open();
                dataAdapter.Fill(puntos);
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

            return puntos;

        }
        public void insertarSolicitud(U_Datos datos)
        {
            DataTable Documentos = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_insertar_solicitud", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = datos.Id;
                dataAdapter.SelectCommand.Parameters.Add("_puntos", NpgsqlDbType.Integer).Value = datos.Puntos;
                dataAdapter.SelectCommand.Parameters.Add("_nick", NpgsqlDbType.Text).Value = datos.Nick;
                dataAdapter.SelectCommand.Parameters.Add("_fecha", NpgsqlDbType.Date).Value = datos.Fecha;



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

        }

        public DataTable Obtenerpqrmoderador()
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_pqrmoderador", conection);
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

        public DataTable almacenarToken(String token, Int32 userId)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_almacenar_token", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_token", NpgsqlDbType.Text).Value = token;
                dataAdapter.SelectCommand.Parameters.Add("_id_usuario", NpgsqlDbType.Integer).Value = userId;

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

        public DataTable generarToken(String user_name)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_validar_usuario", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_user_name", NpgsqlDbType.Text).Value = user_name;

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

        public DataTable obtenerUsusarioToken(String token)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_usuario_token", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_token", NpgsqlDbType.Text).Value = token;

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

        public DataTable actualziarContrasena(U_Datos datos)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_actualizar_contrasena", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_user_id", NpgsqlDbType.Integer).Value = datos.Id;
                dataAdapter.SelectCommand.Parameters.Add("_clave", NpgsqlDbType.Varchar).Value = datos.Pass;

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

        public DataTable eliminarUsuario(Int32 dato)
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_eliminar_usuario", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = dato;
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

        public DataTable bloquearComentario(int id)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_bloquear_comentario", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_comentario", NpgsqlDbType.Integer).Value = id;

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

        public void actualizarBloqueo(Int32 id_post, Int32 user_bloqueador, Int32 estado_bloqueo, Int32 respuesta)
        {
            DataTable Documentos = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.actualizar_estado_bloqueo", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


                dataAdapter.SelectCommand.Parameters.Add("_id_post", NpgsqlDbType.Integer).Value = id_post;
                dataAdapter.SelectCommand.Parameters.Add("_id_user_bloqueador", NpgsqlDbType.Integer).Value = user_bloqueador;
                dataAdapter.SelectCommand.Parameters.Add("_estado_bloqueo", NpgsqlDbType.Integer).Value = estado_bloqueo;
                dataAdapter.SelectCommand.Parameters.Add("_respuesta", NpgsqlDbType.Integer).Value = respuesta;



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

        }

        public DataTable VerUser(Int32 dato)
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_ver_usuarios", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = dato;
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

        public DataTable actualizarUser(U_Datos user)
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_actualizar_usuario", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = user.Id;
                dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlDbType.Text).Value = user.Nombre;
                dataAdapter.SelectCommand.Parameters.Add("_nick", NpgsqlDbType.Text).Value = user.Nick;
                dataAdapter.SelectCommand.Parameters.Add("_puntos", NpgsqlDbType.Integer).Value = user.Puntos;
                dataAdapter.SelectCommand.Parameters.Add("_rango", NpgsqlDbType.Integer).Value = user.Rango;
                dataAdapter.SelectCommand.Parameters.Add("_correo", NpgsqlDbType.Text).Value = user.Correo;
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

        public DataTable ListarUsuariosAdmin()
        {

            DataTable usuarios = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_listar_usuarios_admin", conection);

                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                conection.Open();
                dataAdapter.Fill(usuarios);
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

            return usuarios;

        }

        public DataTable ListarModeradoresAdmin()
        {

            DataTable usuarios = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_listar_moderadores_admin", conection);

                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                conection.Open();
                dataAdapter.Fill(usuarios);
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

            return usuarios;

        }

        public DataTable ListarAdministradoresAdmin()
        {

            DataTable usuarios = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_listar_Administradores_admin", conection);

                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                conection.Open();
                dataAdapter.Fill(usuarios);
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

            return usuarios;

        }
        public DataTable Ascenso(int id)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_ascender", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = id;

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
        public DataTable IgnorarSolicitud(int id)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_ignorar_solicitud", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = id;

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

        public DataTable obtenerRangoUser()
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_rango_user", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


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

        public DataTable obtenerRangomoder()
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_rango_moder", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


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

        public DataTable ObtenerIdio()
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_obtener_idio", conection);
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

        public DataTable obtenerIdioma(Int32 formulario, int idioma)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_obtener_idioma_formulario", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_formulario_id", NpgsqlDbType.Integer).Value = formulario;
                dataAdapter.SelectCommand.Parameters.Add("_idioma_id", NpgsqlDbType.Integer).Value = idioma;

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

        public DataTable idiomas()
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_obtener_idio", conection);
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

        public DataTable cambiarEstado(int id)
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_editar_estado", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = id;


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

        public DataTable idiomasactivos()
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_obtener_idio_activo", conection);
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

        public DataTable formularios()
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_obtener_form", conection);
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

        public DataTable controles(int idioma,int form)
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_obtener_contenido", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_idioma", NpgsqlDbType.Integer).Value = idioma;
                dataAdapter.SelectCommand.Parameters.Add("_formulario", NpgsqlDbType.Integer).Value = form;



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

      

        public DataTable eliminarIdioma(int idioma)
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_eliminar_idioma", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_idioma", NpgsqlDbType.Integer).Value = idioma;



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

        public DataTable modificarControles(string con,int id )
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_editar_controles", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_cont", NpgsqlDbType.Text).Value = con;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = id;



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

        public DataTable insertarIdioma(string idioma,string terminacion)
        {
            DataTable Documentos = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_insertar_idioma", conection);
                dataAdapter.SelectCommand.Parameters.Add("_idioma", NpgsqlDbType.Text).Value = idioma;
                dataAdapter.SelectCommand.Parameters.Add("_terminacion", NpgsqlDbType.Text).Value = terminacion;
                

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

        public DataTable ObtenerIdiomaEsp(string idioma)
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_obtener_idio_esp", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_idioma", NpgsqlDbType.Text).Value = idioma;

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

          public DataTable insertarControles(U_control datos)
        {
            DataTable Documentos = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            { 
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_insertar_control", conection);
                dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlDbType.Text).Value = datos.Nombre;
                dataAdapter.SelectCommand.Parameters.Add("_id_form", NpgsqlDbType.Integer).Value = datos.Id_form;
                dataAdapter.SelectCommand.Parameters.Add("_id_idioma", NpgsqlDbType.Integer).Value = datos.Idioma;
                dataAdapter.SelectCommand.Parameters.Add("_contenido", NpgsqlDbType.Text).Value = datos.Contenido;
 

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

        public DataTable insertaSesiones(int id)
        {
            DataTable Post = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("seguridad.f_insertar_sesion", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id_usuario", NpgsqlDbType.Integer).Value = id;
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

    }
}
