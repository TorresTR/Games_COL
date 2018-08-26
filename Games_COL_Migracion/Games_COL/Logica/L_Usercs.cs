using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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
                    dato.Mensaje1 = "<script type='text/javascript'>alert('Usuario registrado con exito');</script>";
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
                dato.Mensaje1 = "<script type='text/javascript'>alert('Las contraseñas no coinciden');</script>";
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

            dat.Link_observador = "VerPostCompleto.aspx";
            dat.ID_vermasObservador1 = x;

            return dat;
        }

        public U_user verNoticias(string x)
        {

            U_user dat = new U_user();

            dat.Link_observador = "Observador_ver_noticia.aspx";
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

        public U_user irPC()
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
        public U_user sesion(int rol, int b)
        {

            U_user dat = new U_user();

            if (rol == 1)
            {
                dat.Link_demas = "usuarios.aspx";
                return dat;
            }
            else
            {
                if (rol == 2)
                {
                    dat.Link_demas = "Moderador.aspx";
                    return dat;
                }
                else
                {
                    if (rol == 3)
                    {
                        dat.Link_demas = "Administrador.aspx";
                        return dat;
                    }
                    else
                    {
                        dat.Link_demas = "Ingresar.aspx";
                        return dat;
                    }
                }
            }
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

        public U_user loggin(DataTable registros)
        {
            D_User datos = new D_User();
            U_user link = new U_user();
            int rol = int.Parse(registros.Rows[0]["rol"].ToString());


            if (registros.Rows.Count > 0)
            {

                switch (rol)
                {
                    case 1:
                        string nombre = registros.Rows[0]["nombre"].ToString();
                        //string user = registros.Rows[0]["user_id"].ToString();

                        int b = Convert.ToInt32(registros.Rows[0]["user_id"].ToString());

                        U_session datosUsuario = new U_session();
                        L_mac datosConexion = new L_mac();

                        datosUsuario.UserId = b;
                        datosUsuario.Ip = datosConexion.ip();
                        datosUsuario.Mac = datosConexion.mac();
                        //datosUsuario.Session = Session.SessionID;

                        datos.guardadoSession(datosUsuario);
                        link = sesion(rol, b);
                        return link;

                    case 2:
                        nombre = registros.Rows[0]["nombre"].ToString();
                        //Session["user_id"] = registros.Rows[0]["user_id"].ToString();


                        int bmod = Convert.ToInt32(registros.Rows[0]["user_id"].ToString());

                        U_session datosUsuariom = new U_session();
                        L_mac datosConexionMod = new L_mac();

                        datosUsuariom.UserId = bmod;
                        datosUsuariom.Ip = datosConexionMod.ip();
                        datosUsuariom.Mac = datosConexionMod.mac();
                        //datosUsuariom.Session = Session.SessionID;

                        datos.guardadoSession(datosUsuariom);
                        link = sesion(rol, bmod);
                        return link;

                    case 3:
                        nombre = registros.Rows[0]["nombre"].ToString();
                        //Session["user_id"] = registros.Rows[0]["user_id"].ToString();


                        int badmon = Convert.ToInt32(registros.Rows[0]["user_id"].ToString());

                        U_session datosUsuarioad = new U_session();
                        L_mac datosConexionadmon = new L_mac();

                        datosUsuarioad.UserId = badmon;
                        datosUsuarioad.Ip = datosConexionadmon.ip();
                        datosUsuarioad.Mac = datosConexionadmon.mac();
                        //datosUsuarioad.Session = Session.SessionID;

                        datos.guardadoSession(datosUsuarioad);
                        link = sesion(rol, badmon);
                        return link;

                    default:
                        rol = 0;
                        link = sesion(rol, 0);
                        return link;
                }

            }
            else
            {
                rol = 0;
                link = sesion(rol, 0);
                return link;
            }

        }

        public string ActualizarRango(DataTable data, int b)
        {
            string mensaje="";
            if (data.Rows.Count > 0)
            {
                D_User us = new D_User();
                
                U_Datos dato = new U_Datos();
                dato.Id = int.Parse(data.Rows[0]["id"].ToString());
                

                if (int.Parse(data.Rows[0]["id"].ToString()) == b)
                {

                    int puntos = int.Parse(data.Rows[0]["puntos"].ToString());
                    if (puntos > 150 && puntos < 300)
                    {
                        dato.Rango = 2;
                        us.actualizarRango(dato);
                    }
                    else if (puntos > 300 && puntos < 700)
                    {
                        dato.Rango = 3;
                        us.actualizarRango(dato);
                    }
                    else if (puntos > 700 && puntos < 1700)
                    {
                        dato.Rango = 4;
                        us.actualizarRango(dato);
                    }
                    else if (puntos > 1700 && puntos < 2700)
                    {
                        dato.Rango = 5;
                        us.actualizarRango(dato);
                    }
                    else if (puntos > 2700)
                    {
                        dato.Rango = 6;
                        us.actualizarRango(dato);
                        mensaje = "Puedes solicitar tu ascenso a moderador";
                    }
                   
                }
                return mensaje;
            }
            return mensaje;

        }

        public U_Datos cargaDatos(DataTable dat, int b)
        {
            U_Datos datos = new U_Datos();
            if (dat.Rows.Count > 0)
            {
               

                if (int.Parse(dat.Rows[0]["id"].ToString()) == b)
                {
                    datos.Nick = dat.Rows[0]["nick"].ToString();
                    datos.Puntos = int.Parse(dat.Rows[0]["puntos"].ToString());
                    datos.Mensaje1 = dat.Rows[0]["tipo"].ToString();
                    datos.Id = int.Parse(dat.Rows[0]["id"].ToString());

                }
                return datos;
            }
            else
            {
                return datos;
            }
        }
        public String buscar(int x)
        {
            string busqueda = "";
            if (x == 0)
            {
                busqueda = "No existe el post a buscar";
            }
            else
            {
                busqueda = "El Resultado de La Busqueda es:";

            }
            return busqueda;
        }


        public DataTable obtenerInteraccion(int x)
        {

            D_User data = new D_User();
            U_userCrearpost id = new U_userCrearpost();

            id.Id = x;

            DataTable iter = data.ObtenerInteraccion(id);

            return iter;
        }

        public U_Interaccion validarInteraccion(U_Interaccion inter)
        {


            if (inter.Iteraccion == 10)
            {
                
                inter.Estado = false;
                inter.Mensaje = "Numero maximo de interacciones por dia  alcanzado";
            }
            else {
                inter.Contador = inter.Contador + 1;
                inter.Estado = true;
            }

                return inter;
        }

        public DataTable obtenerUsercrear(int x)
        {

            D_User data = new D_User();
            U_userCrearpost id = new U_userCrearpost();

            id.Id = x;

            DataTable iter = data.obtenerUsercrear(id);

            return iter;
        }

        public void actualizarpuntoUser(int b,int x)
        {

            D_User data = new D_User();
            U_Interaccion id = new U_Interaccion();

            id.Id = b;
            id.Puntos = x;

            DataTable iter = data.actualizarpuntoUser(id);

           
        }

        public void insertarPost(U_userCrearpost datos)
        {

            D_User data = new D_User();
             data.insertarPost(datos);


        }


        public U_user retornoUsuario()
        {

            U_user dat = new U_user();

            dat.Link_observador = "usuarios.aspx";
            return dat;
        }

        public DataTable retornoDDL()
        {


            D_User llamar = new D_User();

            DataTable dat = llamar.ObtenerDdl();
            return dat;
        }

        public void insertarPqr(U_Datospqr pqr)
        {


            D_User llamar = new D_User();

            llamar.insertarPQR(pqr);
           
        }

        public DataTable retornoPqrData()
        {


            D_User llamar = new D_User();

            DataTable dat = llamar.ObtenerPqrdatatable();
            return dat;
        }

        public DataTable Listarusermoder()
        {


            D_User llamar = new D_User();

            DataTable dat = llamar.ListarUsuarios();
            return dat;
        }
        public void eliminarUsermoderador(int  h)
        {


            D_User llamar = new D_User();
            U_user data = new U_user();

            data.Id = h;
            llamar.eliminarUsuario(data);

            
        }

    }
}
