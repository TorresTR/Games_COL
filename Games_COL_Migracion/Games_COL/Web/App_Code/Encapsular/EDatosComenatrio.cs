using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de EDatosComenatrio
/// </summary>
public class EDatosComenatrio
{

    private String Conetinido;
    private Int32 id_post;
    private Int32 id;
    private Int32 id_user;
    private int interaccion;
    private DateTime fecha;
    

    public EDatosComenatrio()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    

    public string Conetinido1
    {
        get
        {
            return Conetinido;
        }

        set
        {
            Conetinido = value;
        }
    }

    public int Id_post
    {
        get
        {
            return id_post;
        }

        set
        {
            id_post = value;
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

    public int Interaccion
    {
        get
        {
            return interaccion;
        }

        set
        {
            interaccion = value;
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
}