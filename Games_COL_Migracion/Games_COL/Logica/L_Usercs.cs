using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Datos;
using Newtonsoft.Json;
using Utilitarios;


namespace Logica
{
    public class L_Usercs
    {


        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }




        public DataTable obtenerPQRadmin()
        {
            DataTable prueba = new DataTable();
            Dsql pqr = new Dsql();
            prueba = pqr.Obtenerpqrmoderador();
            return prueba;
        }

        public DataTable obtenerComentarioEsp(int id)
        {
            DataTable prueba = new DataTable();
            Dsql dato = new Dsql();
            prueba = dato.ListarComent(id);
            return prueba;
        }

        public DataTable traerPQR(int id)
        {
            DataTable prueba = new DataTable();
            Dsql dato = new Dsql();
            prueba = dato.traerPQR(id);
            return prueba;
        }

        public DataTable obtenerMiPost(int id, int user)
        {
            DataTable prueba = new DataTable();
            Dsql pqr = new Dsql();
            prueba = pqr.obtenerMipost(id, user);
            return prueba;
        }

        public DataTable obtenerUsuario(int id)
        {
            DataTable prueba = new DataTable();
            Dsql pqr = new Dsql();
            prueba = pqr.obtenerUser(id);
            return prueba;
        }

        public U_user cerrarse(U_user datos) {

            Dsql llamada = new Dsql();
            U_user link = new U_user();

            llamada.cerrarSession(datos);

            link.Link_observador = "Ingresar.aspx";

            return link;
        }

        public U_user cerrarse1(U_user datos)
        {

            Dsql llamada = new Dsql();
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

            Dsql llamado = new Dsql();

            llamado.actualizarMipost(dato);


        }

        public DataTable misPostcomentados(U_misPost dato)
        {

            Dsql llamado = new Dsql();

            DataTable regis = llamado.ObtenerPostE(dato);

            return regis;
        }

        public U_respuestasPqr misRespuestaspqr(int dato)
        {

            Dsql llamado = new Dsql();
            U_respuestasPqr dat = new U_respuestasPqr();

            dat.Id_respuesta = dato;

            DataTable regis = llamado.ObtenerVerRes(dat);

            dat.Respuesta = regis.Rows[0]["respuesta"].ToString();

            return dat;
        }






        public U_userCrearpost eliminarMiscomentarios(U_userCrearpost dato)
        {

            Dsql llamado = new Dsql();
            U_userCrearpost dat = new U_userCrearpost();

            DataTable regis = llamado.verpag(dato);

            if (regis.Rows.Count > 0)
            {
                dat.Contenido1 = regis.Rows[0]["contenido"].ToString();
                dat.Autor1 = regis.Rows[0]["nick"].ToString();
            }

            return dat;
        }



        public DataTable dataEliminarcoment(int dato1, int dato2)
        {

            Dsql llamado = new Dsql();
            U_misPost dat = new U_misPost();

            dat.Dato1 = dato1;
            dat.Dato2 = dato2;

            DataTable regis = llamado.ObtenerComentUS(dat);


            return regis;
        }


        public void dataEliminarcomentaction(int dato1)
        {

            Dsql llamado = new Dsql();
            U_misPost dat = new U_misPost();

            dat.Dato1 = dato1;


            DataTable regis = llamado.EliminarComent(dat);



        }

        public int consultaUsuario(string nick)
        {

            Dsql llamado = new Dsql();


            DataTable dato = llamado.consultaUsuario(nick);
            int id = int.Parse(dato.Rows[0]["id"].ToString());
            insertarSesion(id);
            return id;


        }
        public int consultaid(string nick)
        {

            Dsql llamado = new Dsql();


            DataTable dato = llamado.consultaUsuario(nick);

            int id = int.Parse(dato.Rows[0]["id"].ToString());

            return id;


        }


        public DataTable consultaUsusariocorreo(string correo)
        {

            Dsql llamado = new Dsql();


            DataTable dato = llamado.consultaUsuarioCorreo(correo);


            return dato;


        }

        public void insertarSesion(int iDsql)
        {

            Dsql llamado = new Dsql();

            llamado.insertarSesion(iDsql);



        }


        public DataTable eliminarMiscomentariospuntos(U_userCrearpost dato)
        {

            Dsql llamado = new Dsql();

            DataTable punt = llamado.verpuntos(dato);

            return punt;
        }

        public DataTable respuestaPqr(U_respuestasPqr dato)
        {

            Dsql llamado = new Dsql();

            DataTable punt = llamado.ObtenerRespuesta(dato);

            return punt;
        }


        public U_misPost VerMisdatosaeditar(U_misPost dato)
        {

            Dsql llamado = new Dsql();
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

            Dsql llamado = new Dsql();

            llamado.eliminarMiPost(dato);
        }


        public DataTable misPostCristal(DataTable informacion, int dato)
        {

            Dsql data = new Dsql();
            U_misPost mio = new U_misPost();

            DataRow fila;

            mio.Id_mipost = dato;
            DataTable intermedio = data.ObtenerPostR(mio);

            for (int i = 0; i < intermedio.Rows.Count; i++)
            {
                fila = informacion.NewRow();

                fila["Titulo"] = intermedio.Rows[i]["titulo"].ToString();
                fila["Fecha"] = intermedio.Rows[i]["fecha"].ToString();
                fila["Estado"] = intermedio.Rows[i]["estado_bloqueo"].ToString();
                fila["Etiqueta"] = intermedio.Rows[i]["nombre_etiqueta"].ToString();


                informacion.Rows.Add(fila);
            }

            return informacion;

        }



        public DataTable misPost(U_misPost mio)
        {

            Dsql data = new Dsql();

            DataTable mioresul = data.ObtenermisPost(mio);

            return mioresul;
        }

        public void cerrarSesio(int id)
        {

            Dsql data = new Dsql();

            DataTable mioresul = data.cerradoSesion(id);
        }





        public U_Datos insertarUsuarionuevo(U_Datos datos, Entity_usuario datosu)
        {

            Dsql dat = new Dsql();
            U_Datos dato = new U_Datos();
            L_persistencia log = new L_persistencia();


            if (datos.Pass == datos.Confirma)
            {


                DataTable validez = dat.validarNickusuario(datos);
                if (int.Parse(validez.Rows[0]["id"].ToString()) > 0)
                {

                    log.insertarUsuario(datosu);
                    dato.Mensaje1 = "Usuario registrado con exito";
                    dato.Link = "Ingresar.aspx";


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
            Dsql dato = new Dsql();
            DataTable datos = dato.validarIdioma(c);
            idioma(datos, c);

        }
        public void idioma(DataTable dat, int c)
        {
            Dsql datos = new Dsql();
            int idi = 0;
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
            Dsql dac = new Dsql();

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

            Dsql datos = new Dsql();

            datos.insertarreporte(dat);
        }




        public DataTable obtenerPostObservador()
        {

            Dsql datos = new Dsql();
            DataTable data = new DataTable();

            data = datos.obtenerPostobser();

            return data;

        }

        public U_userCrearpost obtenerPostObservadorreportadomoder(U_userCrearpost doct)
        {

            Dsql datos = new Dsql();
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
            Dsql dato = new Dsql();
            U_Sugerencia dat = new U_Sugerencia();

            //dato.insertarSugerenciaUsuario(sugere);
            dat.Mensaje = "<script type='text/javascript'>alert('Solicitud registrada con exito');</script>";
            dat.Link = "observador.aspx";

            return dat;
        }


        public void insertarNoticias(U_userCrearpost h)
        {

            Dsql dat = new Dsql();

            dat.insertarNoticias(h);


        }


        public DataTable minoticiagv(int h)
        {

            Dsql dat = new Dsql();
            U_userCrearpost data = new U_userCrearpost();

            data.Id = h;
            DataTable fun = dat.ObtenermisNoticia(data);

            return fun;
        }



        public void bloquearComent(int h)
        {

            Dsql dat = new Dsql();
            U_user dato = new U_user();

            dato.Id = h;

            dat.bloquearComentario(dato);


        }
        public void eliminarComent(int h)
        {

            Dsql dat = new Dsql();
            U_user dato = new U_user();

            dato.Id = h;

            dat.eliminarComentario(dato);


        }

        public DataTable listadoModerador(DataTable informacion)
        {

            DataRow fila;
            Dsql persona = new Dsql();


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
            Dsql llamado = new Dsql();

            dat.Id = x;
            llamado.eliminarNoticia(dat);


        }

        public void actualizarmoderPostreportado(Int32 id_post, Int32 user_bloqueador, Int32 estado_bloqueo, Int32 respuesta)
        {

            U_actualizarBloqueo dat = new U_actualizarBloqueo();
            Dsql llamado = new Dsql();

            dat.Id_post = id_post;
            dat.User_bloqueador = user_bloqueador;
            dat.Estado_bloqueo = estado_bloqueo;
            dat.Respuesta = respuesta;

            llamado.actualizarBloqueo(dat);


        }
        public void bloquear_Post(int h)
        {
            Dsql datos = new Dsql();
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

            Dsql llamado = new Dsql();

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
            Dsql dac = new Dsql();
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

            Dsql datos = new Dsql();
            DataTable data = new DataTable();

            data = datos.ObtenerNoti();

            return data;

        }


        public DataTable obtenerSolicitudAmoder()
        {

            Dsql datos = new Dsql();
            DataTable data = new DataTable();

            data = datos.ObtenerSolicitudes();

            return data;

        }

        public DataTable obtenerpostReport()
        {

            Dsql datos = new Dsql();
            DataTable data = new DataTable();

            data = datos.ObtenerpsotReportados();

            return data;

        }

        public DataTable obtenercomnetReport()
        {

            Dsql datos = new Dsql();
            DataTable data = new DataTable();

            data = datos.ObtenerComentRepor();

            return data;

        }

        public DataTable obtenerPostpc()
        {

            Dsql datos = new Dsql();
            DataTable data = new DataTable();

            data = datos.obtenerPostpc();

            return data;

        }

        public DataTable obtenerPostps()
        {

            Dsql datos = new Dsql();
            DataTable data = new DataTable();

            data = datos.ObtenerpostPS();

            return data;

        }

        public DataTable obtenerPostxbox()
        {

            Dsql datos = new Dsql();
            DataTable data = new DataTable();

            data = datos.ObtenerpostXbox();

            return data;

        }

        public DataTable obtenerPostandroid()
        {

            Dsql datos = new Dsql();
            DataTable data = new DataTable();

            data = datos.ObtenerpostAndroid();

            return data;

        }

        public U_userCrearpost postObservador(U_userCrearpost doc)
        {

            Dsql data = new Dsql();
            U_userCrearpost user = new U_userCrearpost();

            DataTable dat = data.verpag(doc);


            if (dat.Rows.Count > 0)
            {
                user.Contenido1 = dat.Rows[0]["contenido"].ToString();
                user.Autor1 = dat.Rows[0]["nick"].ToString();
            }

            DataTable punt = data.verpuntos(doc);


            if (punt.Rows.Count > 0)
            {

                int puntos = 0, num = 0, tot = 0;
                puntos = int.Parse(punt.Rows[0]["puntos"].ToString());
                num = int.Parse(punt.Rows[0]["num_puntos"].ToString());
                tot = puntos;
                user.Totpunt = tot.ToString();
            }


            return user;
        }

        public U_userCrearpost postObservadorNoticias(U_userCrearpost doc)
        {

            Dsql data = new Dsql();
            U_userCrearpost user = new U_userCrearpost();

            DataTable dat = data.verNoticia(doc);


            if (dat.Rows.Count > 0)
            {
                user.Contenido1 = dat.Rows[0]["contenido"].ToString();
                user.Autor1 = dat.Rows[0]["nick"].ToString();
            }


            return user;
        }



        public void insertarComentarioReportado(U_comentarios x)
        {

            Dsql data = new Dsql();

            data.insertarreporteComentariosUser(x);


        }

        public void insertarControl(U_control x)
        {

            Dsql data = new Dsql();

            data.insertarControles(x);


        }


        public DataTable obtenerComentario1(int x)
        {

            Dsql data = new Dsql();
            U_comentarios comentario = new U_comentarios();

            comentario.Id = x;

            DataTable punt = data.ObtenerComent1(comentario);

            return punt;
        }


        public DataTable obtenerComentario(int x)
        {

            Dsql data = new Dsql();
            U_userCrearpost comentario = new U_userCrearpost();

            comentario.Comentarios1 = x;

            DataTable punt = data.ObtenerComent(comentario);

            return punt;
        }


        public DataTable obtenerComentariofinal(int x)
        {

            Dsql data = new Dsql();
            U_userCrearpost comentario = new U_userCrearpost();

            comentario.Comentarios1 = x;

            DataTable punt = data.ObtenerComentFinal(comentario);

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

        public void insertarContacto(string correo, string sugerencia)
        {
            Dsql dao = new Dsql();
            dao.insertarContacto(correo,sugerencia);
        }

        public DataView postPuntuados()
        {
            L_persistencia per = new L_persistencia();
            L_Usercs user = new L_Usercs();
            DataTable data =user.ToDataTable(per.obtenerPost());
            DataView vista = new DataView(data);
            vista.Sort = "puntos DESC";
            return vista;
        }

        //public void MetodoBurbuja()
        //{
        //    int t;
        //    for (int a = 1; a < vector.Length; a++)
        //        for (int b = vector.Length - 1; b >= a; b--)
        //        {
        //            if (vector[b - 1] > vector[b])
        //            {
        //                t = vector[b - 1];
        //                vector[b - 1] = vector[b];
        //                vector[b] = t;
        //            }
        //        }
        //}

        public DataTable Busqueda(string busqueda)
        {

            Dsql data = new Dsql();
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
            Dsql dato = new Dsql();
            dato.validaBloqueo(id);
        }

        public DataTable validaSesion(int id)
        {
            Dsql dato = new Dsql();
            DataTable dat = dato.validaSesion(id);
            return dat;
        }

        public void validaCerradoSesion(int id)
        {
            Dsql dato = new Dsql();
            dato.cerradoSesion(id);
            
        }

        public DataTable valida(U_logueo user)
        {
            Dsql data = new Dsql();
            DataTable datos = data.loggin(user);
            int id =consultaid(user.Nick);
            
            return datos;
        }
        public DataTable validaWS(string nick, string pass)
        {
            Dsql data = new Dsql();
            DataTable datos = data.logginws(nick,pass);

            return datos;
        }

        public U_user loggin(DataTable registros,string a,string nick,int id_usuario)
        {
            Dsql datos = new Dsql();
            U_user link = new U_user();
            int rol = int.Parse(registros.Rows[0]["id_rol"].ToString());
            int iDsql = consultaid(nick);
            string sesi;
            string nombre;
            string user;

            if (registros.Rows.Count > 0)
            {

                switch (rol)
                {
                    case 1:

                        DataTable llamado = datos.comparaerror(iDsql);

                        if (int.Parse(llamado.Rows[0]["intentos_erroneos"].ToString()) >= 3 || int.Parse(llamado.Rows[0]["sesiones_activas"].ToString()) >=2)
                        {
                            link.Mensaje_Alertaobservador1 = "Tiene mas sesiones abiertas de las permitidas, por favor cierrelas e intente de nuevo";
                            link.Link_demas = "ingresar.aspx";
                        }
                        else
                        {
                            DataTable val = validaSesion(id_usuario);

                            nombre = registros.Rows[0]["nombre"].ToString();
                            user = registros.Rows[0]["id"].ToString();

                            int b = Convert.ToInt32(registros.Rows[0]["id"].ToString());

                            U_session datosUsuario = new U_session();
                            L_mac datosConexion = new L_mac();

                            datosUsuario.UserId = b;
                            datosUsuario.Ip = datosConexion.ip();
                            datosUsuario.Mac = datosConexion.mac();
                            datosUsuario.Session = a;
                            if (int.Parse(val.Rows[0]["intentos"].ToString()) == 0)
                            {
                                datos.guardadoSession(datosUsuario);
                                int id = int.Parse(registros.Rows[0]["id"].ToString());

                                link = sesion(rol, b);
                            }
                            else
                            {
                                link.Mensaje_Alertaobservador1 = "Tiene mas sesiones abiertas de las permitidas, por favor cierrelas e intente de nuevo";
                                link.Link_demas = "ingresar.aspx";
                            }


                        }


                        return link;

                    case 2:

                        DataTable llomod = datos.comparaerror(iDsql);

                        if (int.Parse(llomod.Rows[0]["intentos_erroneos"].ToString()) >= 3 || int.Parse(llomod.Rows[0]["sesiones_activas"].ToString()) >= 2)
                        {
                            link.Mensaje_Alertaobservador1 = "Tiene mas sesiones abiertas de las permitidas, por favor cierrelas e intente de nuevo";
                            link.Link_demas = "ingresar.aspx";
                        }
                        else
                        {

                            DataTable valMod = validaSesion(id_usuario);
                            nombre = registros.Rows[0]["nombre"].ToString();
                            sesi = registros.Rows[0]["id"].ToString();


                            int bmod = Convert.ToInt32(registros.Rows[0]["id"].ToString());

                            U_session datosUsuariom = new U_session();
                            L_mac datosConexionMod = new L_mac();

                            datosUsuariom.UserId = bmod;
                            datosUsuariom.Ip = datosConexionMod.ip();
                            datosUsuariom.Mac = datosConexionMod.mac();
                            datosUsuariom.Session = a;

                            datos.guardadoSession(datosUsuariom);


                            link = sesion(rol, bmod);
                        }
                        return link;

                    case 3:

                        DataTable lladmin = datos.comparaerror(iDsql);

                        if (int.Parse(lladmin.Rows[0]["intentos_erroneos"].ToString()) >= 3 || int.Parse(lladmin.Rows[0]["sesiones_activas"].ToString()) >= 2)
                        {
                            link.Mensaje_Alertaobservador1 = "Tiene mas sesiones abiertas de las permitidas, por favor cierrelas e intente de nuevo";
                            link.Link_demas = "ingresar.aspx";
                        }
                        else
                        {

                            DataTable valAdm = validaSesion(id_usuario);
                            nombre = registros.Rows[0]["nombre"].ToString();
                            sesi = registros.Rows[0]["id"].ToString();


                            int badmon = Convert.ToInt32(registros.Rows[0]["id"].ToString());

                            U_session datosUsuarioad = new U_session();
                            L_mac datosConexionadmon = new L_mac();

                            datosUsuarioad.UserId = badmon;
                            datosUsuarioad.Ip = datosConexionadmon.ip();
                            datosUsuarioad.Mac = datosConexionadmon.mac();
                            datosUsuarioad.Session = a;

                            datos.guardadoSession(datosUsuarioad);



                            link = sesion(rol, badmon);
                        }
                        return link;

                    default:
                        DataTable errord = datos.validarErroneo(iDsql);
                        if (int.Parse(errord.Rows[0]["intentos_erroneos"].ToString()) == 3)
                        {
                            link.Mensaje_Alertaobservador1 = "Ha superado la cantidad de intentos permitidos, su cuenta esta bloqueada, por favor intente mas tarde";
                        }
                        else
                        {
                            link.Mensaje_Alertaobservador1 = "";
                            link.Link_demas = "Ingresar.aspx";
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
                Dsql us = new Dsql();
                L_persistencia per = new L_persistencia();//agregar
                Entity_usuario user = new Entity_usuario();//agregar

                U_Datos dato = new U_Datos();
                dato.Id = int.Parse(data.Rows[0]["id"].ToString());


                if (int.Parse(data.Rows[0]["id"].ToString()) == b)
                {
                    DataTable usuario = obtenerUsuario(b);//agregar
                    user.Id = b;//agregar
                    user.Nombre = usuario.Rows[0]["nombre"].ToString();//agregar
                    user.Nick = usuario.Rows[0]["nick"].ToString();//agregar
                    user.Correo = usuario.Rows[0]["correo"].ToString();//agregar
                    user.Contra = usuario.Rows[0]["contra"].ToString();//agregar
                    user.Puntos = int.Parse(usuario.Rows[0]["puntos"].ToString());//agregar
                    user.Id_rol = int.Parse(usuario.Rows[0]["id_rol"].ToString());//agregar
                    user.Estado = int.Parse(usuario.Rows[0]["estado"].ToString());//agregar
                    user.Session = usuario.Rows[0]["session"].ToString();//agregar
                    user.Interacciones = int.Parse(usuario.Rows[0]["interacciones"].ToString());//agregar
                    user.Fecha_interaccion = DateTime.Parse(usuario.Rows[0]["fecha_interaccion"].ToString());//agregar

                    int puntos = int.Parse(data.Rows[0]["puntos"].ToString());
                    if (puntos > 150 && puntos < 300)
                    {
                        dato.Rango = 2;
                        user.Id_rango = 2;//agregar
                        per.actualizarUsuario(user);//agregar
                        //us.actualizarRango(dato);
                    }
                    else if (puntos > 300 && puntos < 700)
                    {
                        dato.Rango = 3;
                        user.Id_rango = 3;//agregar
                        per.actualizarUsuario(user);//agregar
                        //us.actualizarRango(dato);
                    }
                    else if (puntos > 700 && puntos < 1700)
                    {
                        dato.Rango = 4;
                        user.Id_rango = 4;//agregar
                        per.actualizarUsuario(user);//agregar
                        //us.actualizarRango(dato);
                    }
                    else if (puntos > 1700 && puntos < 2700)
                    {
                        dato.Rango = 5;
                        user.Id_rango = 5;//agregar
                        per.actualizarUsuario(user);//agregar
                        //us.actualizarRango(dato);
                    }
                    else if (puntos > 2700)
                    {
                        dato.Rango = 6;
                        user.Id_rango = 6;//agregar
                        per.actualizarUsuario(user);//agregar
                        //us.actualizarRango(dato);
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
                Dsql us = new Dsql();
                L_persistencia per = new L_persistencia();//agregar
                Entity_usuario user = new Entity_usuario();//agregar

                U_Datos dato = new U_Datos();
                dato.Id = int.Parse(data.Rows[0]["id"].ToString());


                if (int.Parse(data.Rows[0]["id"].ToString()) == b)
                {
                    DataTable usuario = obtenerUsuario(b);//agregar
                    user.Id = b;//agregar
                    user.Nombre = usuario.Rows[0]["nombre"].ToString();//agregar
                    user.Nick = usuario.Rows[0]["nick"].ToString();//agregar
                    user.Correo = usuario.Rows[0]["correo"].ToString();//agregar
                    user.Contra = usuario.Rows[0]["contra"].ToString();//agregar
                    user.Puntos = int.Parse(usuario.Rows[0]["puntos"].ToString());//agregar
                    user.Id_rol = int.Parse(usuario.Rows[0]["id_rol"].ToString());//agregar
                    user.Estado = int.Parse(usuario.Rows[0]["estado"].ToString());//agregar
                    user.Session = usuario.Rows[0]["session"].ToString();//agregar
                    user.Interacciones = int.Parse(usuario.Rows[0]["interacciones"].ToString());//agregar
                    user.Fecha_interaccion = DateTime.Parse(usuario.Rows[0]["fecha_interaccion"].ToString());//agregar

                    int puntos = int.Parse(data.Rows[0]["puntos"].ToString());
                    if (puntos > 3700 && puntos < 5800)
                    {
                        dato.Rango = 7;
                        user.Id_rango = 7;//agregar
                        per.actualizarUsuario(user);//agregar
                        //us.actualizarRango(dato);
                    }
                    else if (puntos > 5800 && puntos < 7900)
                    {
                        dato.Rango = 8;
                        user.Id_rango = 8;//agregar
                        per.actualizarUsuario(user);//agregar
                        //us.actualizarRango(dato);
                    }
                    else if (puntos > 7900)
                    {
                        dato.Rango = 9;
                        user.Id_rango = 9;//agregar
                        per.actualizarUsuario(user);//agregar
                        //us.actualizarRango(dato);
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
                    datos.Mensaje1 = dat.Rows[0]["id_rango"].ToString();
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

            Dsql data = new Dsql();
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

            Dsql data = new Dsql();
            U_userCrearpost id = new U_userCrearpost();

            id.Id = x;

            DataTable iter = data.obtenerUsercrear(id);

            return iter;
        }

        public void actualizarpuntoUser(int b, int x)
        {

            Dsql data = new Dsql();
            U_Interaccion id = new U_Interaccion();

            id.Id = b;
            id.Puntos = x;

            DataTable iter = data.actualizarpuntoUser(id);


        }

        public void insertarPost(U_userCrearpost datos)
        {

            Dsql data = new Dsql();
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


            Dsql llamar = new Dsql();

            DataTable dat = llamar.ObtenerDdl();
            return dat;
        }

        public void insertarPqr(U_Datospqr pqr)
        {


            Dsql llamar = new Dsql();

            llamar.insertarPQR(pqr);

        }

        public DataTable retornoPqrData()
        {


            Dsql llamar = new Dsql();

            DataTable dat = llamar.ObtenerPqrdatatable();
            return dat;
        }

        public DataTable Listarusermoder()
        {


            Dsql llamar = new Dsql();

            DataTable dat = llamar.ListarUsuarios();
            return dat;
        }
        public void eliminarUsermoderador(int h)
        {


            Dsql llamar = new Dsql();
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
                dat.Autor1 = regis.Rows[0]["nick"].ToString();
            }
            return dat;
        }
        public U_userCrearpost promedioPunt(DataTable punt)
        {
            U_userCrearpost puntos = new U_userCrearpost();
            if (punt.Rows.Count > 0)
            {
                puntos.PuntosA = int.Parse(punt.Rows[0]["puntos"].ToString());
                puntos.Nump = int.Parse(punt.Rows[0]["num_puntos"].ToString());
            }
            return puntos;
        }

        public U_userCrearpost puntosBoton(DataTable punt, int inter, U_userCrearpost puntot, DataTable us)
        {


            Dsql dac = new Dsql();

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

                        String puntosA = us.Rows[0]["puntos"].ToString();
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


        public U_userCrearpost puntosBotonDos(DataTable punt, int inter, U_userCrearpost puntot, DataTable us)
        {


            Dsql dac = new Dsql();

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

                        String puntosA = us.Rows[0]["puntos"].ToString();
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


        public U_userCrearpost puntosBotonTres(DataTable punt, int inter, U_userCrearpost puntot, DataTable us)
        {


            Dsql dac = new Dsql();

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

                        String puntosA = us.Rows[0]["puntos"].ToString();
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

        public U_userCrearpost puntosBotonCuatro(DataTable punt, int inter, U_userCrearpost puntot, DataTable us)
        {


            Dsql dac = new Dsql();

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

                        String puntosA = us.Rows[0]["puntos"].ToString();
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

        public U_userCrearpost puntosBotonCinco(DataTable punt, int inter, U_userCrearpost puntot, DataTable us)
        {


            Dsql dac = new Dsql();

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

                        String puntosA = us.Rows[0]["puntos"].ToString();
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
            Dsql dac = new Dsql();
            if (inter < 10)
            {
                inter = inter + 1;
                coment.Interaccion = inter;
               
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
            Dsql dao = new Dsql();
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

            Dsql dao = new Dsql();
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
            Dsql dao = new Dsql();
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

                Dsql user = new Dsql();
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
            Dsql user = new Dsql();
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


            Dsql llamar = new Dsql();

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
            Dsql data = new Dsql();
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
            Dsql data = new Dsql();
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
                moder.Confirma = regis.Rows[0]["id_rango"].ToString();
                moder.Correo = regis.Rows[0]["correo"].ToString();
                moder.Bin = false;


            }
            return moder;
        }
        public DataTable verUser(int id)
        {
            DataTable regis = new DataTable();
            Dsql data = new Dsql();
            regis = data.VerUser(id);
            return regis;
        }

        public void actualizarUser(U_Datos usuario)
        {
            Dsql user = new Dsql();
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
            Dsql user = new Dsql();
            user.ListarUsuariosAdmin();

        }
        public void listarModeradoresAdmin()
        {
            Dsql user = new Dsql();
            user.ListarModeradoresAdmin();

        }
        public void listarAdmin()
        {
            Dsql user = new Dsql();
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
            Dsql user = new Dsql();
           


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
            Dsql user = new Dsql();
            DataTable admin = user.ListarAdministradoresAdmin();
            return admin;
        }
        public DataTable listarModerAdmin()
        {
            Dsql user = new Dsql();
            DataTable admin = user.ListarModeradoresAdmin();
            return admin;
        }
        public DataTable listarUserAdmin()
        {
            Dsql user = new Dsql();
            DataTable admin = user.ListarUsuariosAdmin();
            return admin;
        }
        public void Ascenso(int h)
        {
            Dsql ascenso = new Dsql();
            ascenso.Ascenso(h);
        }

        public void ignorarAscenso(int h)
        {
            Dsql ascenso = new Dsql();
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
            Dsql ascenso = new Dsql();
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
            Dsql data = new Dsql();
            tabla = data.verpqr(respuesta);
            return tabla;
        }
        public void actualizarpqr(U_Datospqr respuesta)
        {
 
            Dsql data = new Dsql();
            data.actualizarPQR(respuesta);

        }
        public DataTable obtenerRangoUser()
        {

            Dsql data = new Dsql();
            DataTable rango = data.obtenerRangoUser();
            return rango;

        }

        public DataTable obtenerRangoModer()
        {

            Dsql data = new Dsql();
            DataTable rango = data.obtenerRangomoder();
            return rango;

        }

        public DataTable obtenerIdioma()
        {
            DataTable prueba = new DataTable();
            Dsql idioma = new Dsql();
            Dsql idio = new Dsql();
            prueba = idioma.idiomas();
            return prueba;
        }

        public DataTable obtenerIdiomaActivo()
        {
            DataTable prueba = new DataTable();
            Dsql idioma = new Dsql();
            prueba = idioma.idiomasactivos();
            return prueba;
        }

        public DataTable obtenerIdiomaActivoprueba()
        {
            DataTable prueba = new DataTable();
            //Dsql idioma = new Dsql();
            L_persistencia log = new L_persistencia();
            prueba = ToDataTable(log.obteneridiomaactivo());
            return prueba;
        }


        public DataTable traducir(Int32  FORMULARIO, int x)
        {
            Dsql idioma = new Dsql();
            Dsql idio = new Dsql();
            DataTable info = idio.obtenerIdioma(FORMULARIO, x);
            return info;


        }

        public String select_idioma(Int32 idioma)
        {
            String cultura = "es-CO";
            //Didioma idioam = new Didioma();
            Dsql idioam = new Dsql();
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

            Dsql llamar = new Dsql();

            DataTable dat = llamar.formularios();
            return dat;
        }

        public DataTable controles(int idio,int form)
        {

            Dsql llamar = new Dsql();

            DataTable dat = llamar.controles(idio,form);
            return dat;
        }

        public DataTable insertarIdioma(string idioma, string terminacion)
        {

            Dsql llamar = new Dsql();

            DataTable dat = llamar.insertarIdioma(idioma, terminacion);
            return dat;
        }

        public DataTable ObtenerIdioE(string idioma)
        {

            Dsql llamar = new Dsql();

            DataTable dat = llamar.ObtenerIdiomaEsp(idioma);
            return dat;
        }

      


        public Hashtable hastableIdioma(DataTable info, Hashtable compIdioma)
        {
            for (int i = 0; i < info.Rows.Count; i++)
            {
                compIdioma.Add(info.Rows[i]["nombre"].ToString(), info.Rows[i]["contenido"].ToString());
            }
            return compIdioma;
        }

        public void eliminarIdioma(int i)
        {
            Dsql log = new Dsql();
            log.eliminarIdioma(i);
        }

        public void editarCont(int id, string cont)
        {
            Dsql datos = new Dsql();
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

        public DataTable traerPost(int id)
        {
            DataTable prueba = new DataTable();
            Dsql dato = new Dsql();
            prueba = dato.traerPost(id);
            return prueba;
        }

        public DataTable traerNoticia(int id)
        {
            DataTable prueba = new DataTable();
            Dsql dato = new Dsql();
            prueba = dato.traerNoticia(id);
            return prueba;
        }


    }


}