using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de EDatosReporteCom
/// </summary>
public class EDatosReporteCom
{

    private int id_com_reportado;
    private string contenido;
    private DateTime fecha;
    private int id_user;

    public EDatosReporteCom()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public int Id_com_reportado
    {
        get
        {
            return id_com_reportado;
        }

        set
        {
            id_com_reportado = value;
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
}