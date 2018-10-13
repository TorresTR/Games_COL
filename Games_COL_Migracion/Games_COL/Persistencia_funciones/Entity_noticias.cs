using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia_funciones
{
    [Serializable]
    [Table("noticias", Schema = "usuario")]
    public class Entity_noticias
    {

        private Int32 id_noticia;
        private String titulo;
        private String contenido;
        private DateTime fecha;
        private Int32 autor;

        [Key]
        [Column("id_noticia")]
        public int Id_noticia { get => id_noticia; set => id_noticia = value; }
        [Column("titulo")]
        public string Titulo { get => titulo; set => titulo = value; }
        [Column("contenido")]
        public string Contenido { get => contenido; set => contenido = value; }
        [Column("fecha")]
        public DateTime Fecha { get => fecha; set => fecha = value; }
        [Column("autor")]
        public int Autor { get => autor; set => autor = value; }
    }
}
