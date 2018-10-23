﻿using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;

namespace Datos
{
    public class Dsql
    {

       

        public DataTable comparaerror(int id)
        {
            DataTable Usuario = new DataTable();
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("seguridad.f_traer_errores", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id;

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_traer_pqr", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_coment_report", conection);
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_posr_reportado", conection);
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_solicitudes_usuarios", conection);
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
           SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_actualizar_mi_noticia", conection);
                dataAdapter.SelectCommand.Parameters.Add("@id_post", SqlDbType.Int).Value = post.Id;
                dataAdapter.SelectCommand.Parameters.Add("@contenido", SqlDbType.Text).Value = post.Contenido1;
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_eliminar_minoticia", conection);
                dataAdapter.SelectCommand.Parameters.Add("@id_post", SqlDbType.Int).Value = dato.Id;
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_minoticia", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = dato.Id;

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.insertar_noticia", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


                dataAdapter.SelectCommand.Parameters.Add("@titulo", SqlDbType.Text).Value = datos.Titulo;
                dataAdapter.SelectCommand.Parameters.Add("@contenido", SqlDbType.Text).Value = datos.Contenido1;
                dataAdapter.SelectCommand.Parameters.Add("@fecha", SqlDbType.Date).Value = datos.Fecha;
                dataAdapter.SelectCommand.Parameters.Add("@autor", SqlDbType.Int).Value = datos.Id_user;




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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_bloquear_comentario", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("@id_comentario", SqlDbType.Int).Value = id.Id;

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_eliminar_comentario", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("@id_comentario", SqlDbType.Int).Value = id.Id;

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.actualizar_estado_bloqueo", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


                dataAdapter.SelectCommand.Parameters.Add("@id_post", SqlDbType.Int).Value = data.Id_post;
                dataAdapter.SelectCommand.Parameters.Add("@id_user_bloqueador", SqlDbType.Int).Value = data.User_bloqueador;
                dataAdapter.SelectCommand.Parameters.Add("_estado_bloqueo", SqlDbType.Int).Value = data.Estado_bloqueo;
                dataAdapter.SelectCommand.Parameters.Add("_respuesta", SqlDbType.Int).Value = data.Respuesta;



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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.bloqueo_post", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


                dataAdapter.SelectCommand.Parameters.Add("@id_post", SqlDbType.Int).Value = data.Id_post;

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_infoR_usuarios", conection);

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_pqr_ver", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = dato.Id_respuesta;



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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_respuesta", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = dato.Id_respuesta;



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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_postC", conection);
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id.Dato1;
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_eliminar_Coment", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = dato.Dato1;



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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_Coment_us", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = dat.Dato1;
                dataAdapter.SelectCommand.Parameters.Add("@id_user", SqlDbType.Int).Value = dat.Dato2;



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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_actualizar_mi_post", conection);
                dataAdapter.SelectCommand.Parameters.Add("@id_post", SqlDbType.Int).Value = post.Id;
                dataAdapter.SelectCommand.Parameters.Add("@contenido", SqlDbType.Text).Value = post.Contenido1;
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_miPost", conection);
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
                dataAdapter.SelectCommand.Parameters.Add("@id_user", SqlDbType.Int).Value = user;
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_usuario", conection);
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.vermipost", conection);
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = datos.Id_mipost;
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_eliminar_mipost", conection);
                dataAdapter.SelectCommand.Parameters.Add("@id_post", SqlDbType.Int).Value = dato.Id_mipost;
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_mipostR", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id.Id_mipost;


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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_mipost", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = dato.Id_mipost;



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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_Coment1", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = dato.Id;



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

        public DataTable ListarUsuarios()
        {

            DataTable usuarios = new DataTable();
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_listar_usuarios", conection);

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_comentario", conection);
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_eliminar_usuario", conection);
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = dato.Id;
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_pqr", conection);
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_pqr", conection);
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.insertar_pqr", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


                dataAdapter.SelectCommand.Parameters.Add("_asunto", SqlDbType.Text).Value = datos.Asunto;
                dataAdapter.SelectCommand.Parameters.Add("_estado", SqlDbType.Int).Value = datos.Id_pqrestado;
                dataAdapter.SelectCommand.Parameters.Add("@contenido", SqlDbType.Text).Value = datos.Contenido;
                dataAdapter.SelectCommand.Parameters.Add("@fecha", SqlDbType.Date).Value = datos.Fecha;
                dataAdapter.SelectCommand.Parameters.Add("@id_user", SqlDbType.Int).Value = datos.Id_user;



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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_etiquetas", conection);
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.insertar_post", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


                dataAdapter.SelectCommand.Parameters.Add("@titulo", SqlDbType.Text).Value = datos.Titulo;
                dataAdapter.SelectCommand.Parameters.Add("@contenido", SqlDbType.Text).Value = datos.Contenido1;
                dataAdapter.SelectCommand.Parameters.Add("@fecha", SqlDbType.Date).Value = datos.Fecha;
                dataAdapter.SelectCommand.Parameters.Add("@autor", SqlDbType.Int).Value = datos.Id_user;
                dataAdapter.SelectCommand.Parameters.Add("_etiqueta", SqlDbType.Int).Value = datos.Id_etiqueta;
                dataAdapter.SelectCommand.Parameters.Add("_interacciones", SqlDbType.Int).Value = datos.Interacciones;



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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_actualizar_puntopost", conection);
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = dato.Id;
                dataAdapter.SelectCommand.Parameters.Add("_puntos", SqlDbType.Int).Value = dato.Puntos;

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_usuario_puntosact", conection);
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id.Id;
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_interaccion", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = dato;



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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.insertar_sugerencia", conection);
                dataAdapter.SelectCommand.Parameters.Add("_correo", SqlDbType.Text).Value = datos.Correo;
                dataAdapter.SelectCommand.Parameters.Add("@contenido", SqlDbType.Text).Value = datos.Sugerencia;

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_validar_nick", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_user_name", SqlDbType.Text).Value = dat.Nick;
                dataAdapter.SelectCommand.Parameters.Add("_correo", SqlDbType.Text).Value = dat.Correo;

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("idioma.f_validar@idioma", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("@id@idioma", SqlDbType.Int).Value = idioma;


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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_insertar_usuario", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                dataAdapter.SelectCommand.Parameters.Add("_nombre", SqlDbType.Text).Value = datos.Nombre;
                dataAdapter.SelectCommand.Parameters.Add("_nick", SqlDbType.Text).Value = datos.Nick;
                dataAdapter.SelectCommand.Parameters.Add("_correo", SqlDbType.Text).Value = datos.Correo;
                dataAdapter.SelectCommand.Parameters.Add("_pass", SqlDbType.Text).Value = datos.Pass;
                dataAdapter.SelectCommand.Parameters.Add("_puntos", SqlDbType.Int).Value = datos.Puntos;
                dataAdapter.SelectCommand.Parameters.Add("_rol", SqlDbType.Int).Value = datos.Rol;
                dataAdapter.SelectCommand.Parameters.Add("_rango", SqlDbType.Int).Value = datos.Rango;
                dataAdapter.SelectCommand.Parameters.Add("_estado", SqlDbType.Int).Value = datos.Estado;
                dataAdapter.SelectCommand.Parameters.Add("@fecha", SqlDbType.Date).Value = datos.Fecha;

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.actualizar_pqr", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


                dataAdapter.SelectCommand.Parameters.Add("@id_pqr", SqlDbType.Int).Value = datos.Id_pqr;
                dataAdapter.SelectCommand.Parameters.Add("@id_user", SqlDbType.Int).Value = datos.Id_respondedor;
                dataAdapter.SelectCommand.Parameters.Add("_respuesta", SqlDbType.Text).Value = datos.Respuesta;
                dataAdapter.SelectCommand.Parameters.Add("@fecha", SqlDbType.Date).Value = datos.Fecha_respuesta;
                dataAdapter.SelectCommand.Parameters.Add("_estado_respuesta", SqlDbType.Int).Value = datos.Estado_respuesta;



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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("seguridad.f_insertar_sesion", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


                dataAdapter.SelectCommand.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id_user;




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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.verpqr", conection);
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = datos.Id_pqr;
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.ignorar_pqr", conection);
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = dato.Id_pqr;
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("seguridad.f_traer_usuario", conection);
                dataAdapter.SelectCommand.Parameters.Add("_nick", SqlDbType.Text).Value = nick;
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_noticias", conection);
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_post", conection);
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_post_xbox", conection);
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_post_ps", conection);
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_post_android", conection);
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_post_pc", conection);
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.ver_noticia", conection);
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = datos.Id;
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_buscar_post", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("@titulo", SqlDbType.Text).Value = nombre.Busqueda_Dato;

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.ver", conection);
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = datos.Id;
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.ver_puntos", conection);
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = datos.Id;
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_Coment1", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = dato.Id;



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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.insertar_reporte_coment", conection);
                dataAdapter.SelectCommand.Parameters.Add("@id_coment", SqlDbType.Int).Value = datos.Id_com_reportado1;
                dataAdapter.SelectCommand.Parameters.Add("@contenido", SqlDbType.Text).Value = datos.Contenido1;
                dataAdapter.SelectCommand.Parameters.Add("@fecha", SqlDbType.Date).Value = datos.Fecha;
                dataAdapter.SelectCommand.Parameters.Add("@id_user", SqlDbType.Int).Value = datos.Id_user;

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.insertar_reporte", conection);
                dataAdapter.SelectCommand.Parameters.Add("@id_post", SqlDbType.Int).Value = datos.Id_post_reportado;
                dataAdapter.SelectCommand.Parameters.Add("@contenido", SqlDbType.Text).Value = datos.Contido_reporte;
                dataAdapter.SelectCommand.Parameters.Add("@fecha", SqlDbType.Date).Value = datos.Fecha_reporte;
                dataAdapter.SelectCommand.Parameters.Add("@id_user", SqlDbType.Int).Value = datos.User_reportador;

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_Coment", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = dato.Comentarios1;



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


        public DataTable ObtenerComentFinal(U_userCrearpost dato)
        {
            DataTable Post = new DataTable();
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_comentario_final", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = dato.Comentarios1;



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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("seguridad.f_loggin", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_nick", SqlDbType.Text).Value = datos.Nick;
                dataAdapter.SelectCommand.Parameters.Add("_contra", SqlDbType.Text).Value = datos.Pass;
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("seguridad.f_validar_bloqueo", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id;

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("seguridad.f_actualizar_sesion", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_user@id", SqlDbType.Int).Value = id;

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("seguridad.f_actualizar_cerrar_sesion", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_user@id", SqlDbType.Int).Value = id;

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("seguridad.f_insertar_erroneo1", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id;

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("seguridad.f_guardado_session1", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("@id_usuario", SqlDbType.Int).Value = datos.UserId;
                dataAdapter.SelectCommand.Parameters.Add("_ip", SqlDbType.Text).Value = datos.Ip;
                dataAdapter.SelectCommand.Parameters.Add("_mac", SqlDbType.Text).Value = datos.Mac;
                // dataAdapter.SelectCommand.Parameters.Add("_session", SqlDbType.Text).Value = datos.Session;

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_listar_usuarios_carga", conection);
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = b;
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_actualizar_rango", conection);
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = us.Id;
                dataAdapter.SelectCommand.Parameters.Add("@idr", SqlDbType.Int).Value = us.Rango;

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("seguridad.f_cerrar_session", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_session", SqlDbType.Text).Value = datos.Session;

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_puntuacionvalida", conection);
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_usuario_puntosact", conection);
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_puntos", conection);
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = b;
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.insertar_puntos", conection);
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = datos.Id;
                dataAdapter.SelectCommand.Parameters.Add("_puntos", SqlDbType.Int).Value = datos.Puntos;
                dataAdapter.SelectCommand.Parameters.Add("_puntosa", SqlDbType.Int).Value = datos.PuntosA;
                dataAdapter.SelectCommand.Parameters.Add("_nump", SqlDbType.Int).Value = datos.Nump;
                dataAdapter.SelectCommand.Parameters.Add("@id_user", SqlDbType.Int).Value = datos.Id_user;
                dataAdapter.SelectCommand.Parameters.Add("_interacciones", SqlDbType.Int).Value = datos.Interacciones;
                dataAdapter.SelectCommand.Parameters.Add("@fecha", SqlDbType.Date).Value = datos.Fecha;


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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_actualizar_puntopost", conection);
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
                dataAdapter.SelectCommand.Parameters.Add("_puntos", SqlDbType.Int).Value = puntos;

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_insertar_puntos_us", conection);
                dataAdapter.SelectCommand.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id_usuario;
                dataAdapter.SelectCommand.Parameters.Add("@id_post", SqlDbType.Int).Value = id_post;

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.insertar_Comentario", conection);
                dataAdapter.SelectCommand.Parameters.Add("@id_post", SqlDbType.Int).Value = datos.Id_post;
                dataAdapter.SelectCommand.Parameters.Add("@contenido", SqlDbType.Text).Value = datos.Conetinido1;
                dataAdapter.SelectCommand.Parameters.Add("@id_user", SqlDbType.Int).Value = datos.Id_user;
                dataAdapter.SelectCommand.Parameters.Add("_interacciones", SqlDbType.Int).Value = datos.Interaccion;
                dataAdapter.SelectCommand.Parameters.Add("@fecha", SqlDbType.Date).Value = datos.Fecha;

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_validarpuntosuser", conection);
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = datos.Id;
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_insertar_solicitud", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = datos.Id;
                dataAdapter.SelectCommand.Parameters.Add("_puntos", SqlDbType.Int).Value = datos.Puntos;
                dataAdapter.SelectCommand.Parameters.Add("_nick", SqlDbType.Text).Value = datos.Nick;
                dataAdapter.SelectCommand.Parameters.Add("@fecha", SqlDbType.Date).Value = datos.Fecha;



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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_pqrmoderador", conection);
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_almacenar_token", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_token", SqlDbType.Text).Value = token;
                dataAdapter.SelectCommand.Parameters.Add("@id_usuario", SqlDbType.Int).Value = userId;

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_validar_usuario", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_user_name", SqlDbType.Text).Value = user_name;

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_usuario_token", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_token", SqlDbType.Text).Value = token;

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_actualizar_contrasena", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_user@id", SqlDbType.Int).Value = datos.Id;
                dataAdapter.SelectCommand.Parameters.Add("_clave", SqlDbType.VarChar).Value = datos.Pass;

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_eliminar_usuario", conection);
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = dato;
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_bloquear_comentario", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("@id_comentario", SqlDbType.Int).Value = id;

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.actualizar_estado_bloqueo", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


                dataAdapter.SelectCommand.Parameters.Add("@id_post", SqlDbType.Int).Value = id_post;
                dataAdapter.SelectCommand.Parameters.Add("@id_user_bloqueador", SqlDbType.Int).Value = user_bloqueador;
                dataAdapter.SelectCommand.Parameters.Add("_estado_bloqueo", SqlDbType.Int).Value = estado_bloqueo;
                dataAdapter.SelectCommand.Parameters.Add("_respuesta", SqlDbType.Int).Value = respuesta;



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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_ver_usuarios", conection);
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = dato;
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_actualizar_usuario", conection);
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = user.Id;
                dataAdapter.SelectCommand.Parameters.Add("_nombre", SqlDbType.Text).Value = user.Nombre;
                dataAdapter.SelectCommand.Parameters.Add("_nick", SqlDbType.Text).Value = user.Nick;
                dataAdapter.SelectCommand.Parameters.Add("_puntos", SqlDbType.Int).Value = user.Puntos;
                dataAdapter.SelectCommand.Parameters.Add("_rango", SqlDbType.Int).Value = user.Rango;
                dataAdapter.SelectCommand.Parameters.Add("_correo", SqlDbType.Text).Value = user.Correo;
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_listar_usuarios_admin", conection);

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_listar_moderadores_admin", conection);

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_listar_Administradores_admin", conection);

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_ascender", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_ignorar_solicitud", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_rango_user", conection);
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_obtener_rango_moder", conection);
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("idioma.f_obtener@idio", conection);
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("idioma.f_obtener@idioma_formulario", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("@formulario@id", SqlDbType.Int).Value = formulario;
                dataAdapter.SelectCommand.Parameters.Add("@idioma@id", SqlDbType.Int).Value = idioma;

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("idioma.f_obtener@idio", conection);
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("idioma.f_editar_estado", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;


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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("idioma.f_obtener@idio_activo", conection);
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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("idioma.f_obtener_form", conection);
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

        public DataTable controles(int idioma, int form)
        {
            DataTable Post = new DataTable();
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("idioma.f_obtener@contenido", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("@idioma", SqlDbType.Int).Value = idioma;
                dataAdapter.SelectCommand.Parameters.Add("_formulario", SqlDbType.Int).Value = form;



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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("idioma.f_eliminar@idioma", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("@idioma", SqlDbType.Int).Value = idioma;



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

        public DataTable modificarControles(string con, int id)
        {
            DataTable Post = new DataTable();
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("idioma.f_editar_controles", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_cont", SqlDbType.Text).Value = con;
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;



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

        public DataTable insertarIdioma(string idioma, string terminacion)
        {
            DataTable Documentos = new DataTable();
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("idioma.f_insertar@idioma", conection);
                dataAdapter.SelectCommand.Parameters.Add("@idioma", SqlDbType.Text).Value = idioma;
                dataAdapter.SelectCommand.Parameters.Add("_terminacion", SqlDbType.Text).Value = terminacion;


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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("idioma.f_obtener@idio_esp", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("@idioma", SqlDbType.Text).Value = idioma;

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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("idioma.f_insertar_control", conection);
                dataAdapter.SelectCommand.Parameters.Add("_nombre", SqlDbType.Text).Value = datos.Nombre;
                dataAdapter.SelectCommand.Parameters.Add("@id_form", SqlDbType.Int).Value = datos.Id_form;
                dataAdapter.SelectCommand.Parameters.Add("@id@idioma", SqlDbType.Int).Value = datos.Idioma;
                dataAdapter.SelectCommand.Parameters.Add("@contenido", SqlDbType.Text).Value = datos.Contenido;


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
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("seguridad.f_insertar_sesion", conection);
                dataAdapter.SelectCommand.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id;
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

        //////agregadas
        ///
        public DataTable traerPost(int id)
        {
            DataTable Usuario = new DataTable();
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_traer_post", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

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

        public DataTable traerNoticia(int id)
        {
            DataTable Usuario = new DataTable();
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["GamesColEntities"].ConnectionString);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("usuario.f_traer_noticia", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

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

