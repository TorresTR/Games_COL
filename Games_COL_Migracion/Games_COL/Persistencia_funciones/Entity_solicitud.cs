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
    [Table("solicitud", Schema = "usuario")]
    public class Entity_solicitud
    {
        private Int32 id;
        private Nullable<Int32> id_user;
        private Int32 puntos;
        private String nick;
        private DateTime fecha;


        
        [Column("id_user")]
        public int? Id_user { get => id_user; set => id_user = value; }
        [Column("puntos")]
        public int Puntos { get => puntos; set => puntos = value; }
        [Column("nick")]
        public string Nick { get => nick; set => nick = value; }
        [Column("fecha")]
        public DateTime Fecha { get => fecha; set => fecha = value; }
        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
    }
}
