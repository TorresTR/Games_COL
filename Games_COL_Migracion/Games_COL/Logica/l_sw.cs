using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Logica
{
    public class l_sw
    {

        public bool valida(string sToken)
        {
            if (sToken == DateTime.Now.ToString("yyyyMMdd"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool validaSoap(object so,bool soh,object http)
        {
            if (so == null)
            {
                return false;
            }
            else
            {
                if (!soh)
                {
                    return (http !=null);
                }
            }
            return false;
        }

    }
}
