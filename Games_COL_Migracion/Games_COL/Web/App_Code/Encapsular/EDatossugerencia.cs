using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de EDatossugerencia
/// </summary>
public class EDatossugerencia
{

    private String correo;
    private String sugerencia;


    public EDatossugerencia()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
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

    public string Sugerencia
    {
        get
        {
            return sugerencia;
        }

        set
        {
            sugerencia = value;
        }
    }
}