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
    [Table("puntuacion", Schema = "usuario")]
    public class Entity_puntuacion
    {

        
        private Int32 id_puntuacion;
        private Int32 id_usuario;
        private Int32 id_post;

       
        [Column("id_puntuacion")]
        public int Id_puntuacion { get => id_puntuacion; set => id_puntuacion = value; }
        [Key]
        [Column("id_usuario")]
        public int Id_usuario { get => id_usuario; set => id_usuario = value; }
        [Column("id_post")]
        public int Id_post { get => id_post; set => id_post = value; }
    }
}
