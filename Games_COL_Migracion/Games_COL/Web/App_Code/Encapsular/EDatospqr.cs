using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de EDatospqr
/// </summary>
public class EDatospqr
{


    private String asunto;
    private String contenido;
    private DateTime fecha;
    private Int32 id_user;
    private Int32 id_pqrestado;
    private String respuesta;
    private Int32 id_respondedor;
    private DateTime fecha_respuesta;
    private Int32 id_pqr;
    private Int32 estado_respuesta;
    public EDatospqr()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public int Id_pqrestado
    {
        get
        {
            return id_pqrestado;
        }

        set
        {
            id_pqrestado = value;
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

  

    public string Contenido
    {
        get
        {
            return contenido;
        }

        set
        {
            contenido = value;
        }
    }

    public string Asunto
    {
        get
        {
            return asunto;
        }

        set
        {
            asunto = value;
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

    public DateTime Fecha_respuesta
    {
        get
        {
            return fecha_respuesta;
        }

        set
        {
            fecha_respuesta = value;
        }
    }

    public int Id_respondedor
    {
        get
        {
            return id_respondedor;
        }

        set
        {
            id_respondedor = value;
        }
    }

    public string Respuesta
    {
        get
        {
            return respuesta;
        }

        set
        {
            respuesta = value;
        }
    }

    public int Id_pqr
    {
        get
        {
            return id_pqr;
        }

        set
        {
            id_pqr = value;
        }
    }

    public int Estado_respuesta
    {
        get
        {
            return estado_respuesta;
        }

        set
        {
            estado_respuesta = value;
        }
    }
}