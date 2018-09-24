using System;
using System.Collections;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using Datos;
using Newtonsoft.Json;
using Utilitarios;


namespace Logica
{
    public class L_Usercs
    {

        public DataTable obtenerPQRadmin()
        {
            DataTable prueba = new DataTable();
            D_User pqr = new D_User();
            prueba = pqr.Obtenerpqrmoderador();
            return prueba;
        }

        public U_user cerrarse(U_user datos) {

            D_User llamada = new D_User();
            U_user link = new U_user();

            llamada.cerrarSession(datos);

            link.Link_observador = "Ingresar.aspx";

            return link; 
        }

        public U_user cerrarse1(U_user datos)
        {

            D_User llamada = new D_User();
            U_user link = new U_user();

            llamada.cerrarSession(datos);

            link.Link_observador = "Observador.aspx";

            return link;
        }


        public U_Datos validarCerrarsesion(U_Datos sesion) {

            U_Datos llamado = new U_Datos();

            if (sesion.Sesion == null)
            {
                llamado.Link = "Ingresar.aspx";
            }
            
            return llamado;
        }

        public U_Datos validarCerrarsesion1(U_Datos sesion)
        {

            U_Datos llamado = new U_Datos();

            if (sesion.Sesion == null)
            {
                llamado.Link = "Observador.aspx";
            }

            return llamado;
        }

        public void actualizarMispost(U_userCrearpost dato)
        {

            D_User llamado = new D_User();

            llamado.actualizarMipost(dato);


        }

        public DataTable misPostcomentados(U_misPost dato)
        {

            D_User llamado = new D_User();

            DataTable regis = llamado.ObtenerPostE(dato);

            return regis;
        }

        public U_respuestasPqr misRespuestaspqr(int dato)
        {

            D_User llamado = new D_User();
            U_respuestasPqr dat = new U_respuestasPqr();

            dat.Id_respuesta = dato;

            DataTable regis = llamado.ObtenerVerRes(dat);

            dat.Respuesta = regis.Rows[0]["respuesta"].ToString();

            return dat;
        }






        public U_userCrearpost eliminarMiscomentarios(U_userCrearpost dato)
        {

            D_User llamado = new D_User();
            U_userCrearpost dat = new U_userCrearpost();

            DataTable regis = llamado.verpag(dato);

            if (regis.Rows.Count > 0)
            {
                dat.Contenido1 = regis.Rows[0]["contenido"].ToString();
                dat.Autor1 = regis.Rows[0]["autor"].ToString();
            }

            return dat;
        }



        public DataTable dataEliminarcoment(int dato1, int dato2)
        {

            D_User llamado = new D_User();
            U_misPost dat = new U_misPost();

            dat.Dato1 = dato1;
            dat.Dato2 = dato2;

            DataTable regis = llamado.ObtenerComentUS(dat);


            return regis;
        }


        public void dataEliminarcomentaction(int dato1)
        {

            D_User llamado = new D_User();
            U_misPost dat = new U_misPost();

            dat.Dato1 = dato1;


            DataTable regis = llamado.EliminarComent(dat);



        }

        public int consultaUsuario(string nick)
        {

            D_User llamado = new D_User();


          DataTable dato = llamado.consultaUsuario(nick);
           int id = int.Parse(dato.Rows[0]["user_id"].ToString());
            insertarSesion(id);
            return id;


        }
        public int consultaid(string nick)
        {

            D_User llamado = new D_User();


            DataTable dato = llamado.consultaUsuario(nick);
            int id = int.Parse(dato.Rows[0]["user_id"].ToString());
         
            return id;


        }

        public void insertarSesion(int id_user)
        {

            D_User llamado = new D_User();

            llamado.insertarSesion(id_user);



        }


        public DataTable eliminarMiscomentariospuntos(U_userCrearpost dato)
        {

            D_User llamado = new D_User();

            DataTable punt = llamado.verpuntos(dato);

            return punt;
        }

        public DataTable respuestaPqr(U_respuestasPqr dato)
        {

            D_User llamado = new D_User();

            DataTable punt = llamado.ObtenerRespuesta(dato);

            return punt;
        }


        public U_misPost VerMisdatosaeditar(U_misPost dato)
        {

            D_User llamado = new D_User();
            U_misPost infor = new U_misPost();


            DataTable regis = llamado.verEditar(dato);

            if (regis.Rows.Count > 0)
            {

                infor.Contenido = regis.Rows[0]["contenido"].ToString();
                infor.Autor = regis.Rows[0]["autor"].ToString();
                infor.EstadoCK = false;
                infor.EstadoBT = false;
            }


            return infor;
        }



        public void eliminarMipost(U_misPost dato)
        {

            D_User llamado = new D_User();

            llamado.eliminarMiPost(dato);
        }


        public DataTable misPostCristal(DataTable informacion, int dato)
        {

            D_User data = new D_User();
            U_misPost mio = new U_misPost();

            DataRow fila;

            mio.Id_mipost = dato;
            DataTable intermedio = data.ObtenerPostR(mio);

            for (int i = 0; i < intermedio.Rows.Count; i++)
            {
                fila = informacion.NewRow();

                fila["Titulo"] = intermedio.Rows[i]["titulo"].ToString();
                fila["Fecha"] = intermedio.Rows[i]["fecha"].ToString();
                fila["Estado"] = intermedio.Rows[i]["estado"].ToString();
                fila["Etiqueta"] = intermedio.Rows[i]["etiqueta"].ToString();


                informacion.Rows.Add(fila);
            }

            return informacion;

        }



        public DataTable misPost(U_misPost mio)
        {

            D_User data = new D_User();

            DataTable mioresul = data.ObtenermisPost(mio);

            return mioresul;
        }

        public void cerrarSesio(int id)
        {

            D_User data = new D_User();

            DataTable mioresul = data.cerradoSesion(id);
        }





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
                    dato.Mensaje1 = "Usuario registrado con exito";
                    dato.Link = "Ingresar.aspx";
                    consultaUsuario(datos.Nick);

                }
                else
                {
                    dato.Mensaje1 = "Nick o correo ya existente";
                    dato.Link = "registro.aspx";
                }

            }
            else
            {
                dato.Mensaje1 = "Las contraseñas no coinciden";
                dato.Link = "registro.aspx";
            }

            return dato;
        }

        public void comparaIdioma(int c)
        {
            D_User dato = new D_User();
            DataTable datos = dato.validarIdioma(c);
             idioma(datos, c);

        }
        public void idioma(DataTable dat,int c)
        {
            D_User datos = new D_User();
            int idi=0;
            if (int.Parse(dat.Rows[0]["id"].ToString()) > 0)
            {
                idi = c;
                datos.cambiarEstado(idi);
            }
            else
            {
                
            }

        }
        public U_comentarios ObtenerComentarioreportar(int c)
        {
            U_comentarios dat = new U_comentarios();
            D_User dac = new D_User();

            dat.Id = c;
            DataTable regis = dac.ObtenerComentariouserreporte(dat);

            int contcolum = regis.Columns.Count;

            int p = int.Parse(regis.Rows[0]["id"].ToString());
            if (c == int.Parse(regis.Rows[0]["id"].ToString()))
            {
                dat.Coment = regis.Rows[0]["comentarios"].ToString();
            }

            return dat;
        }


        public void insertarPostaReportar(U_Datosreporte dat)
        {

            D_User datos = new D_User();

            datos.insertarreporte(dat);
        }




        public DataTable obtenerPostObservador()
        {

            D_User datos = new D_User();
            DataTable data = new DataTable();

            data = datos.obtenerPostobser();

            return data;

        }

        public U_userCrearpost obtenerPostObservadorreportadomoder(U_userCrearpost doct)
        {

            D_User datos = new D_User();
            DataTable data = new DataTable();
            U_userCrearpost doc = new U_userCrearpost();

            data = datos.verpag(doct);

            if (data.Rows.Count > 0)
            {

                doc.Contenido1 = data.Rows[0]["contenido"].ToString();
                doc.Autor1 = data.Rows[0]["autor"].ToString();

            }

            return doc;

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


        public void insertarNoticias(U_userCrearpost h)
        {

            D_User dat = new D_User();

            dat.insertarNoticias(h);


        }


        public DataTable minoticiagv(int h)
        {

            D_User dat = new D_User();
            U_userCrearpost data = new U_userCrearpost();

            data.Id = h;
            DataTable fun = dat.ObtenermisNoticia(data);

            return fun;
        }



        public void bloquearComent(int h)
        {

            D_User dat = new D_User();
            U_user dato = new U_user();

            dato.Id = h;

            dat.bloquearComentario(dato);


        }
        public void eliminarComent(int h)
        {

            D_User dat = new D_User();
            U_user dato = new U_user();

            dato.Id = h;

            dat.eliminarComentario(dato);


        }

        public DataTable listadoModerador(DataTable informacion)
        {

            DataRow fila;
            D_User persona = new D_User();


            DataTable intermedio = persona.ListarUsuariosR();

            for (int i = 0; i < intermedio.Rows.Count; i++)
            {
                fila = informacion.NewRow();

                fila["Nick"] = intermedio.Rows[i]["nick"].ToString();
                fila["Puntos"] = int.Parse(intermedio.Rows[i]["puntos"].ToString());
                fila["Rango"] = intermedio.Rows[i]["tipo"].ToString();



                informacion.Rows.Add(fila);
            }

            return informacion;
        }


        public U_user verCompletoModerRegistrado()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Moderador_verCompleto.aspx";


            return dat;
        }

        public U_user irPCModerador()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Moderador_pc.aspx";


            return dat;
        }

        public U_user irXboxModerador()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Moderador_xbox.aspx";


            return dat;
        }

        public U_user irPSModerador()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Moderador_playstation.aspx";


            return dat;
        }

        public U_user irAndroidModerador()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Moderador_android.aspx";


            return dat;
        }

        public U_user irHomeModerador()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Moderador.aspx";


            return dat;
        }


        public U_user verNoticiaModerador(string x)
        {

            U_user dat = new U_user();

            dat.Link_observador = "Moderador_ver_noticias.aspx";
            dat.ID_vermasObservador1 = x;

            return dat;
        }

        public U_user redirigirCompletoModerador()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Moderador_verCompleto.aspx";


            return dat;
        }

        public U_user reporteModerpost()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Moderador_reportar_post.aspx";


            return dat;
        }

        public U_user reporteModercoment()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Moderador_reportar_coment.aspx";


            return dat;
        }

        public U_user ModeradorEditarMispost()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Moderador_editar.aspx";
            return dat;
        }

        public U_user ModeradorMispost()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Moderador_miPost.aspx";
            return dat;
        }


        public U_user vermasPostreportadomoder()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Moderador_verMasPostReportado.aspx";
            return dat;
        }

        public U_user recargarationpost()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Moderador_atencion_bloquer_post.aspx";
            return dat;
        }

        public U_user moderadoradmincoment()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Moderador_admin_coment.aspx";
            return dat;
        }

        public void eliminarminoticia(int x)
        {

            U_userCrearpost dat = new U_userCrearpost();
            D_User llamado = new D_User();

            dat.Id = x;
            llamado.eliminarNoticia(dat);


        }

        public void actualizarmoderPostreportado(Int32 id_post, Int32 user_bloqueador, Int32 estado_bloqueo, Int32 respuesta)
        {

            U_actualizarBloqueo dat = new U_actualizarBloqueo();
            D_User llamado = new D_User();

            dat.Id_post = id_post;
            dat.User_bloqueador = user_bloqueador;
            dat.Estado_bloqueo = estado_bloqueo;
            dat.Respuesta = respuesta;

            llamado.actualizarBloqueo(dat);


        }
        public void bloquear_Post(int h)
        {
            D_User datos = new D_User();
            U_actualizarBloqueo bloqueo = new U_actualizarBloqueo();
            bloqueo.Id_post = h;
            datos.bloqueoPost(bloqueo);
        }

        public U_user recargaminoticia()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Moderador_editar_Noticia.aspx";


            return dat;
        }

        public void actualizaModernoticia(U_userCrearpost post)
        {

            D_User llamado = new D_User();

            llamado.actualizarNoticia(post);

        }

        public U_user recargapgnotimoder()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Moderador_miNoticia.aspx";


            return dat;
        }


        public U_user reporteUsuariocoment()
        {

            U_user dat = new U_user();

            dat.Link_observador = "usuario_reportar_coment.aspx";


            return dat;
        }

        public U_user editarMispost()
        {

            U_user dat = new U_user();

            dat.Link_observador = "usuario_editar.aspx";
            return dat;
        }

        public U_user redireccionComentariot()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Usuario_comentarios.aspx";


            return dat;
        }

        public U_user redireccionMisrespuestaspqr()
        {

            U_user dat = new U_user();

            dat.Link_observador = "usuario_verRespuestas.aspx";


            return dat;
        }

        public U_user redireccionMiscoment()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Usuario_misComents.aspx";


            return dat;
        }

        public U_user redireccionMispost()
        {

            U_user dat = new U_user();

            dat.Link_observador = "usuario_miPost.aspx";


            return dat;
        }

        public U_user verCompletousuarioRegistrado()
        {

            U_user dat = new U_user();

            dat.Link_observador = "verCompletoUserregistrado.aspx";


            return dat;
        }

        public U_user volverUsuariosRegistrado()
        {

            U_user dat = new U_user();

            dat.Link_observador = "usuarios.aspx";


            return dat;
        }

        public U_user irPCusuarioregistrado()
        {

            U_user dat = new U_user();

            dat.Link_observador = "usuarios_pc.aspx";


            return dat;
        }

        public U_user irXboxusuarioregistrado()
        {

            U_user dat = new U_user();

            dat.Link_observador = "usuarios_xbox.aspx";


            return dat;
        }

        public U_user irPSusuarioregistrado()
        {

            U_user dat = new U_user();

            dat.Link_observador = "usuarios_playstation.aspx";


            return dat;
        }

        public U_user irAndroidusuarioregistrado()
        {

            U_user dat = new U_user();

            dat.Link_observador = "usuarios_android.aspx";


            return dat;
        }

        public U_user reporteUsuariopost()
        {

            U_user dat = new U_user();

            dat.Link_observador = "usuarios_reportar_post.aspx";


            return dat;
        }

        public U_user usuarioVernoticia()
        {

            U_user dat = new U_user();

            dat.Link_observador = "usuarios_ver_noticias.aspx";


            return dat;
        }


        public U_user Vermas(string x)
        {

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

        public U_user redirigirCompletousuarioregistrado()
        {

            U_user dat = new U_user();

            dat.Link_observador = "verCompletoUserregistrado.aspx";


            return dat;
        }

        public U_user obtenerPostparareportar(int c)
        {
            D_User dac = new D_User();
            U_user mensaje = new U_user();

            DataTable regis = dac.obtenerPostobser();

            int contcolum = regis.Columns.Count;


            for (int i = 0; i <= contcolum; i++)
            {


                if (regis.Rows.Count > 0)
                {
                    if (c == int.Parse(regis.Rows[i]["id"].ToString()))
                    {
                        mensaje.Mensaje_Alertaobservador1 = regis.Rows[i]["titulo"].ToString();
                        break;
                    }


                }
            }

            return mensaje;
        }



        public U_user verNoticiasusuariosregistrados(string x)
        {

            U_user dat = new U_user();

            dat.Link_observador = "usuarios_ver_noticias.aspx";
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


        public DataTable obtenerSolicitudAmoder()
        {

            D_User datos = new D_User();
            DataTable data = new DataTable();

            data = datos.ObtenerSolicitudes();

            return data;

        }

        public DataTable obtenerpostReport()
        {

            D_User datos = new D_User();
            DataTable data = new DataTable();

            data = datos.ObtenerpsotReportados();

            return data;

        }

        public DataTable obtenercomnetReport()
        {

            D_User datos = new D_User();
            DataTable data = new DataTable();

            data = datos.ObtenerComentRepor();

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

        public U_userCrearpost postObservador(U_userCrearpost doc)
        {

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
                tot = puntos;
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



        public void insertarComentarioReportado(U_comentarios x)
        {

            D_User data = new D_User();

            data.insertarreporteComentariosUser(x);


        }

        public void insertarControl(U_control x)
        {

            D_User data = new D_User();

            data.insertarControles(x);


        }


        public DataTable obtenerComentario1(int x)
        {

            D_User data = new D_User();
            U_comentarios comentario = new U_comentarios();

            comentario.Id = x;

            DataTable punt = data.ObtenerComent1(comentario);

            return punt;
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


        public DataTable Busqueda(string busqueda)
        {

            D_User data = new D_User();
            U_user bus = new U_user();

            bus.Busqueda_Dato = busqueda;
            DataTable busq = data.buscarPost(bus);

            busquedaMensaje(busq);

            return busq;
        }


        public U_user busquedaMensaje(DataTable busq)
        {

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

        public U_user busquedaMensaje1(DataTable busq,string r1,string r2)
        {

            U_user bus = new U_user();
            int x = busq.Rows.Count;

            if (x == 0)
            {
                bus.Estado = true;
                bus.Mensaje_Alertaobservador1 = r1;
            }
            else
            {
                bus.Estado = true;
                bus.Mensaje_Alertaobservador1 = r2;

            }

            return bus;
        }

        public void validar_Bloqueo(int id)
        {
            D_User dato = new D_User();
            dato.validaBloqueo(id);
        }

        public DataTable validaSesion(int id)
        {
            D_User dato = new D_User();
            DataTable dat = dato.validaSesion(id);
            return dat;
        }

        public void validaCerradoSesion(int id)
        {
            D_User dato = new D_User();
            dato.cerradoSesion(id);
            
        }

        public U_user loggin(DataTable registros,string a,string nick,int id_usuario)
        {
            D_User datos = new D_User();
            U_user link = new U_user();
            int rol = int.Parse(registros.Rows[0]["rol"].ToString());
            int id_user = consultaid(nick);
            string sesi;

            if (registros.Rows.Count > 0)
            {

                switch (rol)
                {
                    case 1:
                        DataTable val = validaSesion(id_usuario);
                       
                            string nombre = registros.Rows[0]["nombre"].ToString();
                            string user = registros.Rows[0]["user_id"].ToString();

                            int b = Convert.ToInt32(registros.Rows[0]["user_id"].ToString());

                            U_session datosUsuario = new U_session();
                            L_mac datosConexion = new L_mac();

                            datosUsuario.UserId = b;
                            datosUsuario.Ip = datosConexion.ip();
                            datosUsuario.Mac = datosConexion.mac();
                            datosUsuario.Session = a;
                            if (int.Parse(val.Rows[0]["intentos"].ToString()) == 0)
                            {
                                datos.guardadoSession(datosUsuario);
                                int id = int.Parse(registros.Rows[0]["user_id"].ToString());
                                
                                link = sesion(rol, b);
                            }
                            else
                            {
                                link.Mensaje_Alertaobservador1 = "Tiene mas sesiones abiertas de las permitidas, por favor cierrelas e intente de nuevo";
                            link.Link_demas = "ingresar.aspx";
                            }

                        return link;
                        
                        
                        

                    case 2:
                        DataTable valMod = validaSesion(id_usuario);
                        nombre = registros.Rows[0]["nombre"].ToString();
                        sesi = registros.Rows[0]["user_id"].ToString();


                        int bmod = Convert.ToInt32(registros.Rows[0]["user_id"].ToString());

                        U_session datosUsuariom = new U_session();
                        L_mac datosConexionMod = new L_mac();
                        
                        datosUsuariom.UserId = bmod;
                        datosUsuariom.Ip = datosConexionMod.ip();
                        datosUsuariom.Mac = datosConexionMod.mac();
                        datosUsuariom.Session = a;
                        if (int.Parse(valMod.Rows[0]["intentos"].ToString()) == 0)
                        {
                            datos.guardadoSession(datosUsuariom);
                            int id = int.Parse(registros.Rows[0]["user_id"].ToString());

                            link = sesion(rol, bmod);
                        }
                        else
                        {
                            link.Mensaje_Alertaobservador1 = "Tiene mas sesiones abiertas de las permitidas, por favor cierrelas e intente de nuevo";
                            link.Link_demas = "ingresar.aspx";
                        }
                        

                       
                        link = sesion(rol, bmod);
                        return link;

                    case 3:
                        DataTable valAdm = validaSesion(id_usuario);
                        nombre = registros.Rows[0]["nombre"].ToString();
                        sesi = registros.Rows[0]["user_id"].ToString();


                        int badmon = Convert.ToInt32(registros.Rows[0]["user_id"].ToString());
                        
                        U_session datosUsuarioad = new U_session();
                        L_mac datosConexionadmon = new L_mac();

                        datosUsuarioad.UserId = badmon;
                        datosUsuarioad.Ip = datosConexionadmon.ip();
                        datosUsuarioad.Mac = datosConexionadmon.mac();
                        datosUsuarioad.Session = a;
                        if (int.Parse(valAdm.Rows[0]["intentos"].ToString()) == 0)
                        {
                            datos.guardadoSession(datosUsuarioad);
                            int id = int.Parse(registros.Rows[0]["user_id"].ToString());

                            link = sesion(rol, badmon);
                        }
                        else
                        {
                            link.Mensaje_Alertaobservador1 = "Tiene mas sesiones abiertas de las permitidas, por favor cierrelas e intente de nuevo";
                            link.Link_demas = "ingresar.aspx";
                        }
                       


                       
                        link = sesion(rol, badmon);
                        return link;

                    default:
                        DataTable errord = datos.validarErroneo(id_user);
                        if (int.Parse(errord.Rows[0]["intentos"].ToString()) == 1)
                        {
                            link.Mensaje_Alertaobservador1 = "Ha superado la cantidad de intentos permitidos, su cuenta esta bloqueada, por favor intente mas tarde";
                        }
                        else
                        {
                            link.Mensaje_Alertaobservador1 = "";
                        }
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
            string mensaje = "";
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

        public void ActualizarRangoM(DataTable data, int b)
        {

            if (data.Rows.Count > 0)
            {
                D_User us = new D_User();

                U_Datos dato = new U_Datos();
                dato.Id = int.Parse(data.Rows[0]["id"].ToString());


                if (int.Parse(data.Rows[0]["id"].ToString()) == b)
                {

                    int puntos = int.Parse(data.Rows[0]["puntos"].ToString());
                    if (puntos > 3700 && puntos < 5800)
                    {
                        dato.Rango = 7;
                        us.actualizarRango(dato);
                    }
                    else if (puntos > 5800 && puntos < 7900)
                    {
                        dato.Rango = 8;
                        us.actualizarRango(dato);
                    }
                    else if (puntos > 7900)
                    {
                        dato.Rango = 9;
                        us.actualizarRango(dato);
                    }

                }

            }


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

        public U_user ingresar()
        {

            U_user dat = new U_user();

            dat.Link_observador = "ingresar.aspx";

            return dat;
        }


        public DataTable obtenerInteraccion(int x)
        {

            D_User data = new D_User();
            U_userCrearpost id1 = new U_userCrearpost();

            int Id = x;

            DataTable iter = data.ObtenerInteraccion(Id);

            return iter;
        }

        public U_Interaccion validarInteraccion(U_Interaccion inter)
        {


            if (inter.Iteraccion == 10)
            {

                inter.Estado = false;
                inter.Mensaje = "Numero maximo de interacciones por dia  alcanzado";
            }
            else
            {
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

        public void actualizarpuntoUser(int b, int x)
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
        public void eliminarUsermoderador(int h)
        {


            D_User llamar = new D_User();
            U_user data = new U_user();

            data.Id = h;
            llamar.eliminarUsuario(data);


        }

        public Boolean comparaPropioP(DataTable regisval, int comparador_idpost, int comparador_iduser)
        {
            Boolean estado = true;
            foreach (DataRow fila in regisval.Rows)
            {
                string valor = fila["id_usuario"].ToString();
                string valor_post = fila["id_post"].ToString();

                if (comparador_idpost == int.Parse(valor_post) && comparador_iduser == int.Parse(valor))
                {
                    estado = false;

                }
            }
            return estado;

        }

        public Boolean compara(string z, string x)
        {
            Boolean estado = true;
            if (z == x)
            {
                estado = false;
            }
            return estado;
        }
        public U_userCrearpost comp(DataTable regis)
        {
            U_userCrearpost dat = new U_userCrearpost();
            if (regis.Rows.Count > 0)
            {
                dat.Contenido1 = regis.Rows[0]["contenido"].ToString();
                dat.Autor1 = regis.Rows[0]["autor"].ToString();
            }
            return dat;
        }
        public U_userCrearpost promedioPunt(DataTable punt)
        {
            U_userCrearpost puntos = new U_userCrearpost();
            if (punt.Rows.Count > 0)
            {
                puntos.PuntosA = int.Parse(punt.Rows[0]["puntos"].ToString());
                puntos.Nump = int.Parse(punt.Rows[0]["nump"].ToString());
            }
            return puntos;
        }

        public U_userCrearpost puntosBoton(DataTable punt, int inter, U_userCrearpost puntot)
        {


            D_User dac = new D_User();

            int val, pun;
            if (inter < 10)
            {
                inter = inter + 1;
                if (puntot.Nick != puntot.Autor1)
                {

                    String d = punt.Rows[0]["id"].ToString();

                    if (puntot.Id == int.Parse(d))
                    {

                        String a = punt.Rows[0]["puntos"].ToString();

                        val = int.Parse(a);
                        val = val + 1;

                        String puntosA = punt.Rows[0]["puntosautor"].ToString();
                        pun = int.Parse(puntosA);
                        pun = pun + 1;


                        puntot.Puntos = val;
                        puntot.Interacciones = inter;
                        puntot.PuntosA = pun;


                    }


                }

                dac.guardaPuntos(puntot);
            }
            return puntot;
        }


        public U_userCrearpost puntosBotonDos(DataTable punt, int inter, U_userCrearpost puntot)
        {


            D_User dac = new D_User();

            int val, pun;
            if (inter < 10)
            {
                inter = inter + 1;
                if (puntot.Nick != puntot.Autor1)
                {

                    String d = punt.Rows[0]["id"].ToString();

                    if (puntot.Id == int.Parse(d))
                    {

                        String a = punt.Rows[0]["puntos"].ToString();

                        val = int.Parse(a);
                        val = val + 2;

                        String puntosA = punt.Rows[0]["puntosautor"].ToString();
                        pun = int.Parse(puntosA);
                        pun = pun + 1;


                        puntot.Puntos = val;
                        puntot.Interacciones = inter;
                        puntot.PuntosA = pun;


                    }


                }

                dac.guardaPuntos(puntot);
            }
            return puntot;
        }


        public U_userCrearpost puntosBotonTres(DataTable punt, int inter, U_userCrearpost puntot)
        {


            D_User dac = new D_User();

            int val, pun;
            if (inter < 10)
            {
                inter = inter + 1;
                if (puntot.Nick != puntot.Autor1)
                {

                    String d = punt.Rows[0]["id"].ToString();

                    if (puntot.Id == int.Parse(d))
                    {

                        String a = punt.Rows[0]["puntos"].ToString();

                        val = int.Parse(a);
                        val = val + 3;

                        String puntosA = punt.Rows[0]["puntosautor"].ToString();
                        pun = int.Parse(puntosA);
                        pun = pun + 1;


                        puntot.Puntos = val;
                        puntot.Interacciones = inter;
                        puntot.PuntosA = pun;


                    }


                }

                dac.guardaPuntos(puntot);
            }
            return puntot;
        }

        public U_userCrearpost puntosBotonCuatro(DataTable punt, int inter, U_userCrearpost puntot)
        {


            D_User dac = new D_User();

            int val, pun;
            if (inter < 10)
            {
                inter = inter + 1;
                if (puntot.Nick != puntot.Autor1)
                {

                    String d = punt.Rows[0]["id"].ToString();

                    if (puntot.Id == int.Parse(d))
                    {

                        String a = punt.Rows[0]["puntos"].ToString();

                        val = int.Parse(a);
                        val = val + 4;

                        String puntosA = punt.Rows[0]["puntosautor"].ToString();
                        pun = int.Parse(puntosA);
                        pun = pun + 1;


                        puntot.Puntos = val;
                        puntot.Interacciones = inter;
                        puntot.PuntosA = pun;


                    }


                }

                dac.guardaPuntos(puntot);
            }
            return puntot;
        }

        public U_userCrearpost puntosBotonCinco(DataTable punt, int inter, U_userCrearpost puntot)
        {


            D_User dac = new D_User();

            int val, pun;
            if (inter < 10)
            {
                inter = inter + 1;
                if (puntot.Nick != puntot.Autor1)
                {

                    String d = punt.Rows[0]["id"].ToString();

                    if (puntot.Id == int.Parse(d))
                    {

                        String a = punt.Rows[0]["puntos"].ToString();

                        val = int.Parse(a);
                        val = val + 5;

                        String puntosA = punt.Rows[0]["puntosautor"].ToString();
                        pun = int.Parse(puntosA);
                        pun = pun + 1;


                        puntot.Puntos = val;
                        puntot.Interacciones = inter;
                        puntot.PuntosA = pun;


                    }


                }

                dac.guardaPuntos(puntot);
            }
            return puntot;
        }

        public string comentar(int inter, U_comentarios coment)
        {
            string mensaje = "";
            D_User dac = new D_User();
            if (inter < 10)
            {
                inter = inter + 1;
                coment.Interaccion = inter;
                dac.insertarComentarios(coment);
                DataTable regis = dac.obtenerUss(coment.Id_user);
                int x = int.Parse(regis.Rows[0]["puntos"].ToString());
                x = x + 1;

                dac.actualizarpuntoUser(coment.Id_user, x);
            }
            else
            {
                mensaje = "Numero maximo de interacciones por dia alcanzado";
            }
            return mensaje;
        }

      
        public U_Interaccion solicitudModer(U_Datos datos, System.Data.DataTable validez,string r1,string r2)
        {
            D_User dao = new D_User();
            U_Interaccion inter = new U_Interaccion();

            if (int.Parse(validez.Rows[0]["puntos"].ToString()) >= 3700)
            {
                dao.insertarSolicitud(datos);
                inter.Mensaje = r1;
                inter.Estado = false;
            }
            else
            {
                inter.Mensaje = r2;
                inter.Estado = false;
            }
            return inter;
        }

        public U_Datospqr pqr(DataTable regis)
        {
            U_Datospqr pqr = new U_Datospqr();
            if (regis.Rows.Count > 0)
            {

                pqr.Contenido = regis.Rows[0]["contenido"].ToString();
                pqr.Autor = regis.Rows[0]["autor"].ToString();

            }
            return pqr;
        }

        public string Token(System.Data.DataTable validez, string r1, string r2, string r3)
        {

            D_User dao = new D_User();
            string men = "";
            if (int.Parse(validez.Rows[0]["id"].ToString()) > 0)
            {
                U_token token = new U_token();
                //EUserToken token = new EUserToken();
                token.Id = int.Parse(validez.Rows[0]["id"].ToString());
                token.Nombre = validez.Rows[0]["nombre"].ToString();
                token.User_name = validez.Rows[0]["nick"].ToString();
                token.Estado = int.Parse(validez.Rows[0]["estado"].ToString());
                token.Correo = validez.Rows[0]["correo"].ToString();
                token.Fecha = DateTime.Now.ToFileTimeUtc();


                String userToken = encriptar(JsonConvert.SerializeObject(token));
                dao.almacenarToken(userToken, token.Id);

                D_correo correo = new D_correo();


                String mensaje = "su link de acceso es: " + "http://18.222.174.227/View/Recuperar_contra.aspx?" + userToken;
                correo.enviarCorreo(token.Correo, userToken, mensaje);

                men = r1;
            }
            else if (int.Parse(validez.Rows[0]["id"].ToString()) == -2)
            {
                men = r2;
            }
            else
            {
                men = r3;
            }
            return men;
        }

        public DataTable genera(string valida)
        {
            D_User dao = new D_User();
            DataTable validez = dao.generarToken(valida);
            return validez;
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

        public U_token validaToken(int a, string var)
        {
            U_token inicio = new U_token();
            if (a > 0)
            {

                D_User user = new D_User();
                DataTable info = user.obtenerUsusarioToken(var);

                if (int.Parse(info.Rows[0][0].ToString()) == -1)

                    inicio.Nombre = "El Token es invalido. Genere uno nuevo";

                else if (int.Parse(info.Rows[0][0].ToString()) == -1)
                    inicio.Nombre = "El Token esta vencido. Genere uno nuevo";
                else
                    inicio.Id = int.Parse(info.Rows[0][0].ToString());
            }
            return inicio;


        }

        public void contraseña(U_Datos eUser)
        {
            D_User user = new D_User();
            user.actualziarContrasena(eUser);
        }

        public U_user verCompletoAdmin()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Administrador_verCompleto.aspx";


            return dat;
        }

        public U_user irXboxAdmin()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Administrador_xbox.aspx";


            return dat;
        }

        public U_user irPCAdmin()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Administrador_pc.aspx";


            return dat;
        }
        public U_user irPSAdmin()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Administrador_playstation.aspx";


            return dat;
        }

        public U_user irAndroidAdmin()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Administrador_android.aspx";


            return dat;
        }

        public U_user verNoticiasAdmin(string x)
        {

            U_user dat = new U_user();

            dat.Link_observador = "Adminsitrador_ver_noticias.aspx";
            dat.ID_vermasObservador1 = x;

            return dat;
        }

        public U_user redirigirCompletoAdmin()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Administrador_verCompleto.aspx";


            return dat;
        }

        public U_user reporteAdminpost()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Administrador_reportar_post.aspx";


            return dat;
        }

        public U_user reporteAdmincoment()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Administrador_reportar_coment.aspx";


            return dat;
        }

        public U_user retornoAdmin()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Administrador.aspx";
            return dat;
        }

        public U_user editarListadoAdmin()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Administrador_editar_usuario.aspx";
            return dat;
        }

        public U_user editarListadoAdminmoder()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Administrador_editar_moderador.aspx";
            return dat;
        }

        public void eliminarUsuario(int h)
        {


            D_User llamar = new D_User();

            llamar.eliminarUsuario(h);

        }

        public U_user reporteUser()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Administrador_reporteUser.aspx";


            return dat;
        }

        public U_user reporteModer()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Administrador_reporte_Moder.aspx";


            return dat;
        }

        public U_user reporteAdmin()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Administrador_reporte_admin.aspx";


            return dat;
        }

        public U_user admindbloauearpost()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Administrador_atencion_bloquer_post.aspx";


            return dat;
        }

        public void bloquearComentario(int h)
        {
            D_User data = new D_User();
            data.bloquearComentario(h);
        }

        public U_user administrarComentario()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Administrador_admin_coment.aspx";


            return dat;
        }

        public U_user verPostRepor()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Administrador_verMasPostReportado.aspx";


            return dat;
        }

        public void bloquearPost(int h, int b, int x, int z)
        {
            D_User data = new D_User();
            data.actualizarBloqueo(h, b, x, z);
        }

        public U_user atencionBloquearPost()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Administrador_atencion_bloquer_post.aspx";


            return dat;
        }

        public U_user administrarMiPost()
        {
            U_user dat = new U_user();
            dat.Link_observador = "Administrador_miPost.aspx";
            return dat;
        }

        public U_Datos datosModerador(DataTable regis)
        {
            U_Datos moder = new U_Datos();
            if (regis.Rows.Count > 0)
            {
                moder.Id = int.Parse(regis.Rows[0]["id"].ToString());
                moder.Nombre = regis.Rows[0]["nombre"].ToString();
                moder.Nick = regis.Rows[0]["nick"].ToString();
                moder.Puntos = int.Parse(regis.Rows[0]["puntos"].ToString());
                moder.Confirma = regis.Rows[0]["tipo"].ToString();
                moder.Correo = regis.Rows[0]["correo"].ToString();
                moder.Bin = false;


            }
            return moder;
        }
        public DataTable verUser(int id)
        {
            DataTable regis = new DataTable();
            D_User data = new D_User();
            regis = data.VerUser(id);
            return regis;
        }

        public void actualizarUser(U_Datos usuario)
        {
            D_User user = new D_User();
            user.actualizarUser(usuario);

        }
        public U_user listadoUser()
        {
            U_user dat = new U_user();
            dat.Link_observador = "Administrador_listado_user.aspx";
            return dat;
        }
        public U_user miNoticia()
        {
            U_user dat = new U_user();
            dat.Link_observador = "Administrador_miNoticia.aspx";
            return dat;
        }
        public void listarUsuariosAdmin()
        {
            D_User user = new D_User();
            user.ListarUsuariosAdmin();

        }
        public void listarModeradoresAdmin()
        {
            D_User user = new D_User();
            user.ListarModeradoresAdmin();

        }
        public void listarAdmin()
        {
            D_User user = new D_User();
            user.ListarAdministradoresAdmin();

        }


        public U_user recargaminoticiaAdmin()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Administrador_editar_Noticia.aspx";


            return dat;
        }
        public U_user recargapgnotiAdmin()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Administrador_miNoticia.aspx";


            return dat;
        }

        public U_user AdminEditarMispost()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Administrador_editar.aspx";
            return dat;
        }
        public U_user AdminMispost()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Administrador_miPost.aspx";
            return dat;
        }

        public DataTable reporteAdministrador(DataTable inter, DataTable informacion)
        {
            DataRow fila  ;
            D_User user = new D_User();
           


            for (int i = 0; i<inter.Rows.Count; i++)
            {
                fila = informacion.NewRow();

                fila["Nick"] = inter.Rows[i]["nick"].ToString();
                fila["Puntos"] = int.Parse(inter.Rows[i]["puntos"].ToString());
                fila["Rango"] = inter.Rows[i]["tipo"].ToString();



                informacion.Rows.Add(fila);
            }

                return informacion;

            
        }

        public DataTable listarAdministradoresAdmin()
        {
            D_User user = new D_User();
            DataTable admin = user.ListarAdministradoresAdmin();
            return admin;
        }
        public DataTable listarModerAdmin()
        {
            D_User user = new D_User();
            DataTable admin = user.ListarModeradoresAdmin();
            return admin;
        }
        public DataTable listarUserAdmin()
        {
            D_User user = new D_User();
            DataTable admin = user.ListarUsuariosAdmin();
            return admin;
        }
        public void Ascenso(int h)
        {
            D_User ascenso = new D_User();
            ascenso.Ascenso(h);
        }

        public void ignorarAscenso(int h)
        {
            D_User ascenso = new D_User();
            ascenso.IgnorarSolicitud(h);
        }
        public U_user listaAscenso()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Administrador_solicitudes.aspx";
            return dat;
        }

        public U_user verPQRCompleto()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Administrador_verpqrCompleto.aspx";
            return dat;
        }
        public void ignorarPQR(U_Datospqr id)
        {
            D_User ascenso = new D_User();
            ascenso.ignorarpqr(id);
        }
        public U_user verPQR()
        {

            U_user dat = new U_user();

            dat.Link_observador = "Administrador_ver_pqr.aspx";
            return dat;
        }
        public DataTable pqr(U_Datospqr respuesta)
        {
            DataTable tabla = new DataTable();
            D_User data = new D_User();
            tabla = data.verpqr(respuesta);
            return tabla;
        }
        public void actualizarpqr(U_Datospqr respuesta)
        {
 
            D_User data = new D_User();
            data.actualizarPQR(respuesta);

        }
        public DataTable obtenerRangoUser()
        {

            D_User data = new D_User();
            DataTable rango = data.obtenerRangoUser();
            return rango;

        }

        public DataTable obtenerRangoModer()
        {

            D_User data = new D_User();
            DataTable rango = data.obtenerRangomoder();
            return rango;

        }

        public DataTable obtenerIdioma()
        {
            DataTable prueba = new DataTable();
            D_User idioma = new D_User();
            prueba = idioma.idiomas();
            return prueba;
        }
        public DataTable obtenerIdiomaActivo()
        {
            DataTable prueba = new DataTable();
            D_User idioma = new D_User();
            prueba = idioma.idiomasactivos();
            return prueba;
        }
        public DataTable traducir(Int32  FORMULARIO, int x)
        {
            D_User idioma = new D_User();
            DataTable info = idioma.obtenerIdioma(FORMULARIO, x);
            return info;


        }

        public String select_idioma(Int32 idioma)
        {
            String cultura = "es-CO";
            //Didioma idioam = new Didioma();
            D_User idioam = new D_User();
            DataTable datos = idioam.ObtenerIdio();
            if (datos.Rows.Count > 0)
            {
                for (int i = 0; i < datos.Rows.Count; i++)
                {
                    if (Int32.Parse(datos.Rows[i][0].ToString()) == idioma)
                    {
                        cultura = datos.Rows[i][2].ToString();
                    }
                }
            }
            return cultura;

        }

        public DataTable formularios()
        {

            D_User llamar = new D_User();

            DataTable dat = llamar.formularios();
            return dat;
        }

        public DataTable controles(int idio,int form)
        {

            D_User llamar = new D_User();

            DataTable dat = llamar.controles(idio,form);
            return dat;
        }

        public DataTable insertarIdioma(string idioma, string terminacion)
        {

            D_User llamar = new D_User();

            DataTable dat = llamar.insertarIdioma(idioma, terminacion);
            return dat;
        }

        public DataTable ObtenerIdioE(string idioma)
        {

            D_User llamar = new D_User();

            DataTable dat = llamar.ObtenerIdiomaEsp(idioma);
            return dat;
        }

      


        public Hashtable hastableIdioma(DataTable info, Hashtable compIdioma)
        {
            for (int i = 0; i < info.Rows.Count; i++)
            {
                compIdioma.Add(info.Rows[i]["nombre"].ToString(), info.Rows[i]["valor"].ToString());
            }
            return compIdioma;
        }

        public void eliminarIdioma(int i)
        {
            D_User log = new D_User();
            log.eliminarIdioma(i);
        }

        public void editarCont(int id, string cont)
        {
            D_User datos = new D_User();
            datos.modificarControles(cont,id);
        }

        public U_Datos comparaIdioma(int i,int idioma)
        {
            U_Datos dato = new U_Datos();
            
            if (i == 1)
            {
                dato.Mensaje1 = "alert('No se puede eliminar el idioma por defecto');";
                dato.Id = idioma;

            }
            else
            {
                dato.Mensaje1 = "alert('Idioma eliminado con exito');";
                if (i == idioma)
                {
                    dato.Id = 1;
                }
                eliminarIdioma(i);

            }
            return dato;
        }

        


    }


}