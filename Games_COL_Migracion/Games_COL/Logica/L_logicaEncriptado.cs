using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;


namespace Logica
{
    public class L_logicaEncriptado
    {

        public StringBuilder hexconversion(int I,StringBuilder ret,byte[] b) {

            for (I=0; (I <= b.Length - 1); I++)
            {
                // Format as hex
                ret.AppendFormat("{0:X2}", b[I]);
            }
            
            return ret;
        }

       
        public string encrypt(string nm, string val, string h)
        {
            
            U_datosEncriptados llamado = new U_datosEncriptados();

            string newUrl;
            while ((newUrl = Uri.UnescapeDataString(h)) != h)
                h = newUrl;
            return newUrl;

        }

    }
}
