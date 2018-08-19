using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de EDatosCrearPost
/// </summary>
public class EDatosCrearPost
{

    private String titulo;
    private String Autor;
    private String Contenido;
    private DateTime fecha;
    private Int32 id;
    private Int64 puntos;
    private Int32 id_user;
    private Int32 id_etiqueta;
    private Int32 puntosA;
    private Int32 nump;
    private int interacciones;

    public EDatosCrearPost()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public string Titulo
    {
        get
        {
            return titulo;
        }

        set
        {
            titulo = value;
        }
    }

    public string Autor1
    {
        get
        {
            return Autor;
        }

        set
        {
            Autor = value;
        }
    }

    public string Contenido1
    {
        get
        {
            return Contenido;
        }

        set
        {
            Contenido = value;
        }
    }

    public DateTime Fecha
    {
        get
        {
            return fecha;
        }

        set
        {
            fecha = value;
        }
    }

    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public long Puntos
    {
        get
        {
            return puntos;
        }

        set
        {
            puntos = value;
        }
    }

    public int Id_user
    {
        get
        {
            return id_user;
        }

        set
        {
            id_user = value;
        }
    }

    public int Id_etiqueta
    {
        get
        {
            return id_etiqueta;
        }

        set
        {
            id_etiqueta = value;
        }
    }

    public int PuntosA
    {
        get
        {
            return puntosA;
        }

        set
        {
            puntosA = value;
        }
    }

    public int Nump
    {
        get
        {
            return nump;
        }

        set
        {
            nump = value;
        }
    }

    public int Interacciones
    {
        get
        {
            return interacciones;
        }

        set
        {
            interacciones = value;
        }
    }
}