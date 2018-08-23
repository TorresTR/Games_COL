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

        public U_Datos insertarUsuarionuevo(U_Datos datos)
        {

            D_User dat = new D_User();
            U_Datos dato = new U_Datos();

            

            if (datos.Pass == datos.Confirma)
            {


                DataTable validez = dat.validarNickusuario(datos);
                if (int.Parse(validez.Rows[0]["id"].ToString()) > 0)
                {

                    dat.insertarUsuario(datos);
                    dato.Mensaje1=  "<script type='text/javascript'>alert('Usuario registrado con exito');</script>";
                    dato.Link = "Ingresar.aspx";

                }
                else
                {
                    dato.Mensaje1 = "<script type='text/javascript'>alert('Nick o correo ya existente');</script>";
                    dato.Link = "registo.aspx";
                }

            }
            else
            {
                dato.Mensaje1= "<script type='text/javascript'>alert('Las contraseñas no coinciden');</script>";
                dato.Link = "registro.aspx";
            }

            return dato;
        }


        public DataTable obtenerPostObservador() {

            D_User datos = new D_User();
            DataTable data = new DataTable();

            data = datos.obtenerPostobser();

            return data; 

        }

        public U_Sugerencia sugerenciasUsuarios(U_Sugerencia sugere)
        {
            D_User dato = new D_User();
            U_Sugerencia dat = new U_Sugerencia();

            dato.insertarSugerenciaUsuario(sugere);
            dat.Mensaje = "<script type='text/javascript'>alert('Solicitud registrada con exito');</script>";
            dat.Link = "observador.aspx";

            return dat;
        }


        public U_user Vermas(string x) {

            U_user dat = new U_user();

            dat.Link_observador = "VerPostCompleto.aspx?parametro=";
            dat.ID_vermasObservador1 = x;

            return dat;
        }

        public U_user verNoticias(string x)
        {

            U_user dat = new U_user();

            dat.Link_observador = "Observador_ver_noticia.aspx?parametro=";
            dat.ID_vermasObservador1 = x;

            return dat;
        }

        public DataTable obtenerPostNoticia()
        {

            D_User datos = new D_User();
            DataTable data = new DataTable();

            data = datos.ObtenerNoti();

            return data;

        }

        public DataTable obtenerPostpc()
        {

            D_User datos = new D_User();
            DataTable data = new DataTable();

            data = datos.obtenerPostpc();

            return data;

        }

        public DataTable obtenerPostps()
        {

            D_User datos = new D_User();
            DataTable data = new DataTable();

            data = datos.ObtenerpostPS();

            return data;

        }

        public DataTable obtenerPostxbox()
        {

            D_User datos = new D_User();
            DataTable data = new DataTable();

            data = datos.ObtenerpostXbox();

            return data;

        }

        public DataTable obtenerPostandroid()
        {

            D_User datos = new D_User();
            DataTable data = new DataTable();

            data = datos.ObtenerpostAndroid();

            return data;

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

        public U_userCrearpost postObservadorNoticias(U_userCrearpost doc)
        {

            D_User data = new D_User();
            U_userCrearpost user = new U_userCrearpost();

            DataTable dat = data.verNoticia(doc);


            if (dat.Rows.Count > 0)
            {
                user.Contenido1 = dat.Rows[0]["contenido"].ToString();
                user.Autor1 = dat.Rows[0]["autor"].ToString();
            }

            
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

        public U_user  irPC()
        {
            U_user dat = new U_user();

            dat.Link_demas = "Observador_pc.aspx";
            return dat;
        }

        public U_user irxbox()
        {
            U_user dat = new U_user();

            dat.Link_demas = "Observador_xbox.aspx";
            return dat;
        }

        public U_user irInicio()
        {
            U_user dat = new U_user();

            dat.Link_demas = "Observador.aspx";
            return dat;
        }
        public U_user irPS()
        {
            U_user dat = new U_user();

            dat.Link_demas = "Observar_playstation.aspx";
            return dat;
        }

        public U_user irAndroid()
        {
            U_user dat = new U_user();

            dat.Link_demas = "Observador_androidt.aspx";
            return dat;
        }


        public DataTable Busqueda(string busqueda) {

            D_User data = new D_User();
            U_user bus = new U_user();

            bus.Busqueda_Dato = busqueda;
            DataTable busq = data.buscarPost(bus);

            busquedaMensaje(busq);

            return busq;
        }


        public U_user busquedaMensaje(DataTable busq) {

            U_user bus = new U_user();
            int x = busq.Rows.Count;

            if (x == 0)
            {
                bus.Estado = true;
                bus.Mensaje_Alertaobservador1 = "No existe el post a buscar";
            }
            else
            {
                bus.Estado = true;
                bus.Mensaje_Alertaobservador1 = "El Resultado de La Busqueda es:";

            }

            return bus;
        }


    }
}
