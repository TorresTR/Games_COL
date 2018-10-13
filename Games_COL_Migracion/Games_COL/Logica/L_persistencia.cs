using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Data;
using Datos;
using System.Data;
using Persistencia_funciones;

namespace Logica
{
    public class L_persistencia
    {

        public void insertarPost(Entity_post post)
        {
            daoPost dao = new daoPost();
            dao.insertPost(post);

        }

        public List<Entity_post> obtenerPost()
        {
            daoPost dao = new daoPost();
            return dao.obtenerPost();
        }

        public List<Entity_post> obtenerPostpc()
        {
            daoPost dao = new daoPost();
            return dao.obtenerPostpc();
        }

        public List<Entity_post> obtenerPostxbox()
        {
            daoPost dao = new daoPost();
            return dao.obtenerPostxbox();
        }
        public List<Entity_post> obtenerMiPost(int id)
        {
            daoPost dao = new daoPost();
            return dao.obtenerMiPost(id);
        }

        public void actualizarPost(Entity_post post)
        {
            daoPost dao = new daoPost();
            dao.actualizarPost(post);

        }

        public void borrarPost(Entity_post post)
        {
            daoPost dato = new daoPost();
            dato.eliminarPost(post);
        }

        public void insertarUsuario(Entity_usuario usuario)
        {
            daoPost dao = new daoPost();
            dao.insertUsuario(usuario);

        }

        public List<Entity_usuario> obtenerUsuario()
        {
            daoPost dao = new daoPost();
            return dao.obtenerUsuario();
        }

        public List<Entity_usuario> obtenerModerador()
        {
            daoPost dao = new daoPost();
            return dao.obtenerModer();
        }

        public void actualizarUsuario(Entity_usuario usuario)
        {
            daoPost dao = new daoPost();
            dao.actualizarUsuario(usuario);

        }

        public void borrarUsuario(Entity_usuario usuario)
        {
            daoPost dato = new daoPost();
            dato.eliminarUsuario(usuario);
        }

        public void insertarComenatrio(Entity_comentarios comentario)
        {
            daoPost dao = new daoPost();
            dao.insertComentario(comentario);

        }

        public List<Entity_comentarios> obtenerComentario(int post)
        {
            daoPost dao = new daoPost();
            return dao.obtenerComentario(post);
        }

        public void actualizarComentario(Entity_comentarios comentario)
        {
            daoPost dao = new daoPost();
            dao.actualizarComentario(comentario);

        }

        public void borrarComentario(Entity_comentarios comentario)
        {
            daoPost dato = new daoPost();
            dato.eliminarComentario(comentario);
        }

        public void insertarPQR(Entity_pqr pqr)
        {
            daoPost dao = new daoPost();
            dao.insertPQR(pqr);

        }

        public List<Entity_pqr> obtenerPQR()
        {
            daoPost dao = new daoPost();
            return dao.obtenerPQR();
        }

        public void actualizarPQR(Entity_pqr pqr)
        {
            daoPost dao = new daoPost();
            dao.actualizarPQR(pqr);

        }

        public void borrarPQR(Entity_pqr pqr)
        {
            daoPost dato = new daoPost();
            dato.eliminarPQR(pqr);
        }

        public void insertarContato(Entity_contacto contacto)
        {
            daoPost dao = new daoPost();
            dao.insertContacto(contacto);

        }

        public List<Entity_contacto> obtenerContacto()
        {
            daoPost dao = new daoPost();
            return dao.obtenerContactos();
        }

        public void actualizarContacto(Entity_contacto contacto)
        {
            daoPost dao = new daoPost();
            dao.actualizarContacto(contacto);

        }

        public void borrarContacto(Entity_contacto contacto)
        {
            daoPost dato = new daoPost();
            dato.eliminarContacto(contacto);
        }


        public List<Entity_reporte> obtenerReporteuser()
        {
            daoPost dao = new daoPost();
            return dao.obtenerReporteadmin();
        }

        public List<Entity_reporteModer> obtenerReportModer()
        {
            daoPost dao = new daoPost();
            return dao.obtenerReporteModeradmin();
        }


        public List<Entity_idioma> obteneridiomaactivo()
        {
            daoPost dao = new daoPost();
            return dao.obtenerIdiomaActivo();
        }

        public List<Entity_controlesIdioma> obtenerControles(int i, int form)
        {
            daoPost dao = new daoPost();
            return dao.obtenerControles(i,form);
        }

        public void insertarIdioma(Entity_idioma idioma)
        {
            daoPost dao = new daoPost();
            dao.insertIdioma(idioma);

        }

        public List<Entity_idioma> obtenerIdiomaEspe(String idi)
        {
            daoPost dao = new daoPost();
            return dao.obtenerIdiomaEsp(idi);
        }

        public void insertarControlTraducido(Entity_controlesIdioma control)
        {
            daoPost dao = new daoPost();
            dao.insertControlTraducido(control);

        }


        public List<Entity_controlesIdioma> obtenerIdiomacontroles(int idi,int form)
        {
            daoPost dao = new daoPost();
            return dao.obtenerIdiomaformu(idi,form);
        }


        public void borrarActualizar(actualizar_estado_bloqueo post)
        {
            daoPost dato = new daoPost();
            dato.eliminarActualizar(post);
        }

        public void borrarRecuperarcontra(Entity_token_recuperacion_user token)
        {
            daoPost dato = new daoPost();
            dato.eliminarTokenrecuperarcontra(token);
        }


        public void borrarSolicitud(Entity_solicitud sol)
        {
            daoPost dato = new daoPost();
            dato.eliminarSolicitud(sol);
        }


        public U_Interaccion insertarSolicitud(Entity_solicitud sol, System.Data.DataTable validez, string r1, string r2)
        {
            daoPost dao = new daoPost();
            
            U_Interaccion inter = new U_Interaccion();

            if (int.Parse(validez.Rows[0]["puntos"].ToString()) >= 3700)
            {
                dao.insertSolicitud(sol);
                inter.Mensaje = r1;
                inter.Estado = false;
            }
            else
            {
                inter.Mensaje = r2;
                inter.Estado = false;
            }
            return inter;

        }


        public List<Entity_usuario> obtenerCarga(int id)
        {
            daoPost dao = new daoPost();
            return dao.obtenerCarga(id);
        }

        public List<Entity_comentarios> obtenerComentarioesp(int id)
        {
            daoPost dao = new daoPost();
            return dao.obtenerComentesp(id);
        }


        public List<Entity_noticias> obtenerMinoticia(int id)
        {
            daoPost dao = new daoPost();
            return dao.obtenerMinoticia(id);
        }


        public List<Entity_post> obtenerMipostmio(int post, int id)
        {
            daoPost dao = new daoPost();
            return dao.obtenerPostmioeditar(post,id);
        }

        public List<Entity_puntuacion> obtenerPuntos(int id)
        {
            daoPost dao = new daoPost();
            return dao.obtenerPuntos(id);
        }


        public DataTable obtenerRangousuario()
        {
            daoPost dao = new daoPost();
            L_Usercs user = new L_Usercs();
           DataTable dat = user.ToDataTable(dao.obtenerRangouser());
            return dat;
        }


        public DataTable obtenerDatasolicitudesuser()
        {
            daoPost dao = new daoPost();
            L_Usercs user = new L_Usercs();
            DataTable dat = user.ToDataTable(dao.obtenerSolicituddata());
            return dat;
        }


        public List<Entity_usuario> obtenerUser(int id)
        {
            daoPost dao = new daoPost();
            return dao.obtenerUser(id);
        }


        public void insertarReportecomentar(Entity_reporte_comentarios post)
        {
            daoPost dao = new daoPost();
            dao.insertReportecoment(post);

        }
        //public List<Entity_idioma_agregar> obtenerPrueba(int form,int idio)
        //{
        //    daoPost dao = new daoPost();
        //    return dao.obtenerContolesprueba(form,idio);
        //}



    }
}
