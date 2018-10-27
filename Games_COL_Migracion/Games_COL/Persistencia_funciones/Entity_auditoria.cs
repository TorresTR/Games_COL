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
    [Table("auditoria", Schema = "seguridad")]
    public class Entity_auditoria
    {
        private int id;
        private DateTime fecha;
        private String accion;
        private String schema;
        private String tabla;
        private String session;
        private String user_bd;
        private String data;
        private String pk;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("fecha")]
        public DateTime Fecha { get => fecha; set => fecha = value; }
        [Column("accion")]
        public string Accion { get => accion; set => accion = value; }
        [Column("schema")]
        public string Schema { get => schema; set => schema = value; }
        [Column("tabla")]
        public string Tabla { get => tabla; set => tabla = value; }
        [Column("session")]
        public string Session { get => session; set => session = value; }
        [Column("user_bd")]
        public string User_bd { get => user_bd; set => user_bd = value; }
        [Column("data")]
        public string Data { get => data; set => data = value; }
        [Column("pk")]
        public string Pk { get => pk; set => pk = value; }

        public static Entity_auditoria newEmpty()
        {
            Entity_auditoria aud = new Entity_auditoria();
            return aud;
        }

    }
}
