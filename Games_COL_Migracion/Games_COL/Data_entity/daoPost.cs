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
               // var e = db.post.Join(Entity_post, (x=>x.Id),(y=));
                var a = db.post.ToList<Entity_post>().Where(x => x.Estado_bloqueo.Equals(1)).;
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

        public void insertComentario(Entity_comentarios coment)
        {
            using (var db = new Mapeo("usuario"))
            {
                db.comentario.Add(coment);
                db.SaveChanges();


            }
        }

        public List<Entity_comentarios> obtenerComentario(int post)
            {
            using (var db = new Mapeo("usuario"))
            {

                var a = db.comentario.ToList<Entity_comentarios>().Where(x => x.Estado.Equals(1)).Where(x=>x.Id_post.Equals(post));
                return a.ToList<Entity_comentarios>();
            }
        }

        public void actualizarComentario(Entity_comentarios comentario)
        {
            using (var db = new Mapeo("usuario"))
            {
                db.comentario.Attach(comentario);
                var entry = db.Entry(comentario);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }


        public void eliminarComentario(Entity_comentarios comentario)
        {
            using (var db = new Mapeo("usuario"))
            {
                db.comentario.Attach(comentario);
                db.Entry(comentario).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void insertPQR(Entity_pqr pqr)
        {
            using (var db = new Mapeo("usuario"))
            {
                db.pqr.Add(pqr);
                db.SaveChanges();


            }
        }

        public List<Entity_pqr> obtenerPQR()
        {
            using (var db = new Mapeo("usuario"))
            {

                var a = db.pqr.ToList<Entity_pqr>().Where(x=>x.Estado_respuesta.Equals(0));
                return a.ToList<Entity_pqr>();
            }
        }

        public void actualizarPQR(Entity_pqr pqr)
        {
            using (var db = new Mapeo("usuario"))
            {
                db.pqr.Attach(pqr);
                var entry = db.Entry(pqr);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }


        public void eliminarPQR(Entity_pqr pqr)
        {
            using (var db = new Mapeo("usuario"))
            {
                db.pqr.Attach(pqr);
                db.Entry(pqr).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void insertContacto(Entity_contacto contacto)
        {
            using (var db = new Mapeo("usuario"))
            {
                db.contacto.Add(contacto);
                db.SaveChanges();


            }
        }

        public List<Entity_contacto> obtenerContactos()
        {
            using (var db = new Mapeo("usuario"))
            {

                var a = db.contacto.ToList<Entity_contacto>();
                return a.ToList<Entity_contacto>();
            }
        }

        public void actualizarContacto(Entity_contacto contacto)
        {
            using (var db = new Mapeo("usuario"))
            {
                db.contacto.Attach(contacto);
                var entry = db.Entry(contacto);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }


        public void eliminarContacto(Entity_contacto contacto)
        {
            using (var db = new Mapeo("usuario"))
            {
                db.contacto.Attach(contacto);
                db.Entry(contacto).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }



        public List<Entity_reporte> obtenerReporteadmin()
        {
            using (var db = new Mapeo("usuario"))
            {

                var a = db.Reporte.ToList<Entity_reporte>();
                return a.ToList<Entity_reporte>();
            }
        }

        public List<Entity_reporteModer> obtenerReporteModeradmin()
        {
            using (var db = new Mapeo("usuario"))
            {

                var a = db.ReporteModer.ToList<Entity_reporteModer>();
                return a.ToList<Entity_reporteModer>();
            }
        }

        public List<Entity_post> obtenerMiPost(int id)
        {
            using (var db = new Mapeo("usuario"))
            {

                var a = db.post.ToList<Entity_post>().Where(x => x.Autor.Equals(id));
                return a.ToList<Entity_post>();
            }
        }

    }

    
}
