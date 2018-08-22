using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de EDatosreporte
/// </summary>
public class EDatosreporte
{

    private Int32 id_post_reportado;
    private String contido_reporte;
    private DateTime fecha_reporte;
    private Int32 user_reportador;
    public EDatosreporte()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public int Id_post_reportado
    {
        get
        {
            return id_post_reportado;
        }

        set
        {
            id_post_reportado = value;
        }
    }

    public string Contido_reporte
    {
        get
        {
            return contido_reporte;
        }

        set
        {
            contido_reporte = value;
        }
    }

    public DateTime Fecha_reporte
    {
        get
        {
            return fecha_reporte;
        }

        set
        {
            fecha_reporte = value;
        }
    }

    public int User_reportador
    {
        get
        {
            return user_reportador;
        }

        set
        {
            user_reportador = value;
        }
    }
}