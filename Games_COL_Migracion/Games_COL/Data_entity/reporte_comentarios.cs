//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data_entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class reporte_comentarios
    {
        public long id_reporte_coment { get; set; }
        public Nullable<int> id_com_reportado { get; set; }
        public string contenido { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<int> id_user { get; set; }
    
        public virtual comentarios comentarios { get; set; }
        public virtual usuario usuario { get; set; }
    }
}
