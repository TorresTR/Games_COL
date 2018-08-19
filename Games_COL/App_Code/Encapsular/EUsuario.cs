using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de EUsuario
/// </summary>
public class EUsuario
{
    public EUsuario()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    private Int32 userId;
    private Int32 rol;
    private String session;
    private String ip;
    private String mac;
    private String clave;
    private String user_name;
    
   
   

    public string Session
    {
        get
        {
            return session;
        }

        set
        {
            session = value;
        }
    }

    public string Ip
    {
        get
        {
            return ip;
        }

        set
        {
            ip = value;
        }
    }

    public string Mac
    {
        get
        {
            return mac;
        }

        set
        {
            mac = value;
        }
    }

    public int UserId
    {
        get
        {
            return userId;
        }

        set
        {
            userId = value;
        }
    }

    public string Clave
    {
        get
        {
            return clave;
        }

        set
        {
            clave = value;
        }
    }

    public string user_name1
    {
        get
        {
            return user_name;
        }

        set
        {
            user_name = value;
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
}