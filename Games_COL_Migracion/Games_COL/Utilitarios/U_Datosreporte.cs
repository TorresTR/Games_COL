using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class U_Datosreporte
    {

        private Int32 id_post_reportado;
        private String contido_reporte;
        private DateTime fecha_reporte;
        private Int32 user_reportador;

        public int Id_post_reportado { get => id_post_reportado; set => id_post_reportado = value; }
        public string Contido_reporte { get => contido_reporte; set => contido_reporte = value; }
        public DateTime Fecha_reporte { get => fecha_reporte; set => fecha_reporte = value; }
        public int User_reportador { get => user_reportador; set => user_reportador = value; }
    }
}
