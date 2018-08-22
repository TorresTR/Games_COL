using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Utilitarios;

namespace Logica
{
    public class L_Usercs
    {

        public DataTable obtenerPostObservador() {

            D_User datos = new D_User();
            DataTable data = new DataTable();

            data = datos.obtenerPostobser();

            return data; 

        }

        public U_user Vermas(string x) {

            U_user dat = new U_user();

            dat.Link_observador = "VerPostCompleto.aspx?parametro=";
            dat.ID_vermasObservador1 = x;

            return dat;
        }


        public U_userCrearpost postObservador(U_userCrearpost doc) {

            D_User data = new D_User();
            U_userCrearpost user = new U_userCrearpost();

            DataTable dat = data.verpag(doc);


            if (dat.Rows.Count > 0)
            {
                user.Contenido1 = dat.Rows[0]["contenido"].ToString();
                user.Autor1 = dat.Rows[0]["autor"].ToString();
            }

            DataTable punt = data.verpuntos(doc);


            if (punt.Rows.Count > 0)
            {

                int puntos = 0, num = 0, tot = 0;
                puntos = int.Parse(punt.Rows[0]["puntos"].ToString());
                num = int.Parse(punt.Rows[0]["nump"].ToString());
                tot = puntos / num;
                user.Totpunt = tot.ToString();
            }


            return user;
        }


        public U_userCrearpost puntosObservador(U_userCrearpost doc)
        {

            D_User data = new D_User();
            U_userCrearpost user = new U_userCrearpost();

            

            return user;
        }


        public DataTable obtenerComentario(int x)
        {

            D_User data = new D_User();
            U_userCrearpost comentario = new U_userCrearpost();

            comentario.Comentarios1 = x;

            DataTable punt = data.ObtenerComent(comentario);

            return punt;
        }

        public U_userCrearpost retornoObservador()
        {
            U_userCrearpost dat = new U_userCrearpost();

            dat.Link = "observador.aspx";
            return dat;
        }

    }
}
