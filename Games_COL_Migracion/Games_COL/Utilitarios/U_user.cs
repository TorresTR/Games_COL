using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class U_user
    {

        private String  ID_vermasObservador;
        private String link_observador;
        private String link_demas;
        private String busqueda_Dato;
        private bool estado;
        private String Mensaje_Alertaobservador;
        private Int32 id;

        public string ID_vermasObservador1 { get => ID_vermasObservador; set => ID_vermasObservador = value; }
        public string Link_observador { get => link_observador; set => link_observador = value; }
        public string Link_demas { get => link_demas; set => link_demas = value; }
        public string Busqueda_Dato { get => busqueda_Dato; set => busqueda_Dato = value; }
        public bool Estado { get => estado; set => estado = value; }
        public string Mensaje_Alertaobservador1 { get => Mensaje_Alertaobservador; set => Mensaje_Alertaobservador = value; }
        public int Id { get => id; set => id = value; }
    }
}
