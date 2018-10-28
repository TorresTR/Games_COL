using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia_funciones
{
    public class GoogleProfile
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public Image Image { get; set; }
        public List<Email> Emails { get; set; }
        public string Gender { get; set; }
        public string ObjectType { get; set; }
    }

}
