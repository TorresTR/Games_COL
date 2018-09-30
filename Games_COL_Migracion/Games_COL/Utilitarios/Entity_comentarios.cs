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
    [Table("comentarios", Schema = "usuario")]
    public class Entity_comentarios
    {

        private int id_comentario;
        private string comentario;
        private int id_post;
        private int id_user;
        private int estado;

        [Key]
        [Column("id_comentario")]
        public int Id_comentario { get => id_comentario; set => id_comentario = value; }
        [Column("comentario")]
        public string Comentario { get => comentario; set => comentario = value; }
        [Column("id_post")]
        public int Id_post { get => id_post; set => id_post = value; }
        [Column("id_user")]
        public int Id_user { get => id_user; set => id_user = value; }
        [Column("estado")]
        public int Estado { get => estado; set => estado = value; }
        
    }
}
