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
    [Table("vista_moder_admin", Schema = "usuario")]

    public class Entity_reporteModer
    {
        private Int32 id;
        private String nombre;
        private String nick;
        private String correo;
        private Int32 puntos;
        private String tipo;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("nombre")]
        public string Nombre { get => nombre; set => nombre = value; }
        [Column("nick")]
        public string Nick { get => nick; set => nick = value; }
        [Column("correo")]
        public string Correo { get => correo; set => correo = value; }
        [Column("puntos")]
        public int Puntos { get => puntos; set => puntos = value; }
        [Column("tipo")]
        public string Tipo { get => tipo; set => tipo = value; }

    }
}
