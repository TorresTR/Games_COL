using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Edatos
/// </summary>
public class Edatos
{

    private String nombre;
    private String nick;
    private String correo;
    private String pass;
    private String imagen;
    private int puntos;
    private int rol;
    private int rango;
    private int estado;
    private int id;
    private DateTime fecha;
    private int interaccion;
    

    public Edatos()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public string Nombre
    {
        get
        {
            return nombre;
        }

        set
        {
            nombre = value;
        }
    }

    public string Nick
    {
        get
        {
            return nick;
        }

        set
        {
            nick = value;
        }
    }

    public string Correo
    {
        get
        {
            return correo;
        }

        set
        {
            correo = value;
        }
    }

    public string Pass
    {
        get
        {
            return pass;
        }

        set
        {
            pass = value;
        }
    }

    public string Imagen
    {
        get
        {
            return imagen;
        }

        set
        {
            imagen = value;
        }
    }

    public int Puntos
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

    public int Rol
    {
        get
        {
            return rol;
        }

        set
        {
            rol = value;
        }
    }

    public int Rango
    {
        get
        {
            return rango;
        }

        set
        {
            rango = value;
        }
    }

    public int Estado
    {
        get
        {
            return estado;
        }

        set
        {
            estado = value;
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
}