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
    [Table("rango", Schema = "usuario")]
    public class Entity_rango
    {
        private Int32 id;
        private String tipo;
        private Int32 identificador;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("tipo")]
        public string Tipo { get => tipo; set => tipo = value; }
        
        [Column("identificador")]
        public int Identificador { get => identificador; set => identificador = value; }
    }
}
