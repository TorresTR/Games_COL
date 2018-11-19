using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    [Serializable]
    [Table("post", Schema = "usuario")]
    public class Entity_post
    {

        private int id;
        private string titulo;
        private string contenido;
        private DateTime fecha;
        private int puntos;
        private int autor;
        private int etiqueta;
        private int estado_bloqueo;
        private int? user_bloqueador;
        private int num_puntos;
      

        [Key]
        [Column("id_post")]
        public int Id { get => id; set => id = value; }
        [Column("titulo")]
        public string Titulo { get => titulo; set => titulo = value; }
        [Column("contenido")]
        public string Contenido { get => contenido; set => contenido = value; }
        [Column("fecha")]
        public DateTime Fecha { get => fecha; set => fecha = value; }
        [Column("puntos")]
        public int Puntos { get => puntos; set => puntos = value; }
        [Column("autor")]
        public int Autor { get => autor; set => autor = value; }
        [Column("etiqueta")]
        public int Etiqueta { get => etiqueta; set => etiqueta = value; }
        [Column("estado_bloqueo")]
        public int Estado_bloqueo { get => estado_bloqueo; set => estado_bloqueo = value; }
        [Column("user_bloqueador")]
        public int? User_bloqueador { get => user_bloqueador; set => user_bloqueador = value; }
        [Column("num_puntos")]
        public int Num_puntos { get => num_puntos; set => num_puntos = value; }
        
    }
}
