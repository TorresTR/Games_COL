using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Data;
using Datos;

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

    }
}
