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
    [Table("usuario", Schema = "usuario")]
    public class Entity_usuario
    {

        private int id;
        private string nombre;
        private string contra;
        private string nick;
        private string correo;
        private int puntos;
        private int id_rol;
        private int id_rango;
        private int estado;
        private string session;
        private DateTime? ultima_modificacion;
        private int interacciones;
        private DateTime fecha_interaccion;

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
        [Column("id_rol")]
        public int Id_rol { get => id_rol; set => id_rol = value; }
        [Column("id_rango")]
        public int Id_rango { get => id_rango; set => id_rango = value; }
        [Column("estado")]
        public int Estado { get => estado; set => estado = value; }
        [Column("session")]
        public string Session { get => session; set => session = value; }
        [Column("ultima_modificacion")]
        public DateTime? Ultima_modificacion { get => ultima_modificacion; set => ultima_modificacion = value; }
        [Column("interacciones")]
        public int Interacciones { get => interacciones; set => interacciones = value; }
        [Column("fecha_interaccion")]
        public DateTime Fecha_interaccion { get => fecha_interaccion; set => fecha_interaccion = value; }
        [Column("contra")]
        public string Contra { get => contra; set => contra = value; }
    }
}
