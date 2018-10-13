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
    [Table("token_recuperacion_user", Schema = "usuario")]
    public class Entity_token_recuperacion_user
    {
        private Int32 id;
        private Int32 id_usuario;
        private String token;
        private DateTime fecha_creado;
        private DateTime fecha_vigencia;

        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Key]
        [Column("id_usuario")]
        public int Id_usuario { get => id_usuario; set => id_usuario = value; }
        [Column("token")]
        public string Token { get => token; set => token = value; }
        [Column("fecha_creado")]
        public DateTime Fecha_creado { get => fecha_creado; set => fecha_creado = value; }
        [Column("fecha_vigencia")]
        public DateTime Fecha_vigencia { get => fecha_vigencia; set => fecha_vigencia = value; }
    }
}
