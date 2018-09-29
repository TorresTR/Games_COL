using Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;

namespace Datos
{
    public class daoPost
    {

        public void insertPost(Entity_post post)
        {
            using (var db = new Mapeo("usuario"))
            {
                
                    db.post.Add(post);
                    db.SaveChanges();

               
            }
        }

        public List<Entity_post> obtenerPost()
        {
            using (var db = new Mapeo("usuario"))
            {

                var a = db.post.ToList<Entity_post>().Where(x => x.Estado_bloqueo.Equals(1));
                return a.ToList<Entity_post>();
            }
        }

        public void actualizarPost(Entity_post post)
        {
            using (var db = new Mapeo("usuario"))
            {
                db.post.Attach(post);
                var entry = db.Entry(post);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }


        public void eliminarPost(Entity_post post)
        {
            using (var db = new Mapeo("usuario"))
            {
                db.post.Attach(post);
                db.Entry(post).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void insertUsuario(Entity_usuario usuario)
        {
            using (var db = new Mapeo("usuario"))
            {

                db.usuario.Add(usuario);
                db.SaveChanges();


            }
        }

        public List<Entity_usuario> obtenerUsuario()
        {
            using (var db = new Mapeo("usuario"))
            {

                var a = db.usuario.ToList<Entity_usuario>().Where(x => x.Id_rol.Equals(1));
                return a.ToList<Entity_usuario>();
            }
        }

        public void actualizarUsuario(Entity_usuario usuario)
        {
            using (var db = new Mapeo("usuario"))
            {
                db.usuario.Attach(usuario);
                var entry = db.Entry(usuario);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }


        public void eliminarUsuario(Entity_usuario usuario)
        {
            using (var db = new Mapeo("usuario"))
            {
                db.usuario.Attach(usuario);
                db.Entry(usuario).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

    }
}
