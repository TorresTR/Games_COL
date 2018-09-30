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
    [Table("contato_usuarios", Schema = "usuario")]
    public class Entity_contacto
    {
        private int id_sugerencia;
        private string correo;
        private string sugerencia;

        [Key]
        [Column("id_sugerencia")]
        public int Id_sugerencia { get => id_sugerencia; set => id_sugerencia = value; }
        [Column("correo")]
        public string Correo { get => correo; set => correo = value; }
        [Column("sugerencia")]
        public string Sugerencia { get => sugerencia; set => sugerencia = value; }
        
    }
}
