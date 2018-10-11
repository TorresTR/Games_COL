using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Data;
using Datos;
using System.Data;

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

    }
}
