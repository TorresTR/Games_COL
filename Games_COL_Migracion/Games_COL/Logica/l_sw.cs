using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Newtonsoft.Json;
using Utilitarios;

namespace Logica
{
    public class l_sw
    {

       
        public int llave(string llave)
        {

            Dsql dat = new Dsql();

             DataTable d = dat.comparaLlave(llave);

            int valida = int.Parse(d.Rows[0]["id"].ToString());
            return valida;
        }

        public string Invitaruser(string correol)
        {

            Dsql dao = new Dsql();
            string men = "invitacion enviada";
           
                U_token token = new U_token();
               token.Correo = correol;

                D_correo correo = new D_correo();


                String mensaje = "Si te interesa Sobre de los videos juegos visitanos en: " + "http://gamescol.ddns.net/View/Observador.aspx";
            correo.enviarCorreoinvitado(token.Correo, mensaje);

             
            return men;
        }


        public string Respuesta(string correol,string respuesta)
        {

            Dsql dao = new Dsql();
            string men = "respuesta enviada";

            U_token token = new U_token();
            token.Correo = correol;

            D_correo correo = new D_correo();


            String mensaje = "Tu sugerencia fue contestada: " + respuesta;
            correo.enviarCorreoinvitado(token.Correo, mensaje);


            return men;
        }


        private string encriptar(string input)
        {
            SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = provider.ComputeHash(inputBytes);

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
                output.Append(hashedBytes[i].ToString("x2").ToLower());

            return output.ToString();
        }


    }//class
}
