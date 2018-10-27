using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Data_entity;
using Data;
using Persistencia_funciones;
using Utilitarios;

namespace Data_entity
{
    public class DaoAuditoria
    {
        public static void add(Entity_auditoria eAuditoria)
        {
            using (var dbc = new Mapeo("seguridad"))
            {
                dbc.Entry(eAuditoria).State = EntityState.Added;
                dbc.SaveChanges();
            }
        }

        public static Entity_auditoria get(int id)
        {
            using (var dbc = new Mapeo("seguridad"))
            {
                Entity_auditoria eAuditoria = dbc.audit.Find(id);
                return eAuditoria ?? Entity_auditoria.newEmpty();
            }
        }

        public static List<Entity_auditoria> getAll(int id)
        {
            using (var dbc = new Mapeo("seguridad"))
            {
                return dbc.audit.ToList();
            }
        }

        public static List<Entity_auditoria> getAuditoriaTabla(string nombreTabla)
        {
            using (var dbc = new Mapeo("seguridad"))
            {
                return (from x in dbc.audit where x.Tabla == nombreTabla select x).ToList();
            }
        }

        public  void insert(Object obj, Entity_usuario eAcceso, string esquema, string tabla)
        {
            Entity_auditoria eAuditoria = Entity_auditoria.newEmpty();
            eAuditoria.Fecha = DateTime.Now;
            eAuditoria.Accion = "INSERT";
            eAuditoria.User_bd = "SQL Server";
            eAuditoria.Schema = esquema;
            eAuditoria.Tabla = tabla;
            eAuditoria.Session = "Prueba";
            eAuditoria.Pk = eAcceso.Nombre;

            JObject jObject = new JObject();

            foreach (PropertyInfo propertyInfo in obj.GetType().GetProperties())
            {
                if (propertyInfo.PropertyType == typeof(string) || propertyInfo.PropertyType == typeof(int) || propertyInfo.PropertyType == typeof(Boolean))
                {
                    jObject[propertyInfo.Name] = propertyInfo.GetValue(obj).ToString();
                }
            }

            eAuditoria.Data = JsonConvert.SerializeObject(jObject);
            DaoAuditoria.add(eAuditoria);
        }

        public void update(Object newObj, Object oldObj, Entity_usuario eAcceso, string esquema, string tabla)
        {
            Entity_auditoria eAuditoria = Entity_auditoria.newEmpty();
            eAuditoria.Fecha = DateTime.Now;
            eAuditoria.Accion = "UPDATE";
            eAuditoria.User_bd = "SQL Server";
            eAuditoria.Schema = esquema;
            eAuditoria.Tabla = tabla;
            eAuditoria.Session = "Prueba";
            eAuditoria.Pk = eAcceso.Nombre;

            JObject jObject = new JObject();

            Boolean sinCambios = true;

            foreach (PropertyInfo propertyInfo in newObj.GetType().GetProperties())
            {
                if (propertyInfo.PropertyType == typeof(string) || propertyInfo.PropertyType == typeof(int) || propertyInfo.PropertyType == typeof(Boolean))
                {
                    if (propertyInfo.Name.Equals("Id"))
                    {
                        jObject[propertyInfo.Name] = propertyInfo.GetValue(newObj).ToString();
                    }
                    if (!propertyInfo.GetValue(newObj).ToString().Equals(propertyInfo.GetValue(oldObj).ToString()) && !propertyInfo.Name.Equals("IdAcceso"))
                    {
                        jObject["new_" + propertyInfo.Name] = propertyInfo.GetValue(newObj).ToString();
                        jObject["old_" + propertyInfo.Name] = propertyInfo.GetValue(oldObj).ToString();
                        sinCambios = false;
                    }
                }
                else if (propertyInfo.PropertyType == typeof(List<int>) && !JsonConvert.SerializeObject(propertyInfo.GetValue(newObj)).Equals(JsonConvert.SerializeObject(propertyInfo.GetValue(oldObj))))
                {
                    jObject["new_" + propertyInfo.Name] = JsonConvert.SerializeObject(propertyInfo.GetValue(newObj));
                    jObject["old_" + propertyInfo.Name] = JsonConvert.SerializeObject(propertyInfo.GetValue(oldObj));
                    sinCambios = false;
                }
            }

            if (sinCambios)
            {
                return;
            }

            eAuditoria.Data = JsonConvert.SerializeObject(jObject);
            DaoAuditoria.add(eAuditoria);
        }

        public void delete(Object obj, Entity_usuario eAcceso, string esquema, string tabla)
        {
            Entity_auditoria eAuditoria = Entity_auditoria.newEmpty();
            eAuditoria.Fecha = DateTime.Now;
            eAuditoria.Accion = "DELETE";
            eAuditoria.User_bd = "SQL server";
            eAuditoria.Schema = esquema;
            eAuditoria.Tabla = tabla;
            eAuditoria.Session = "Prueba";
            eAuditoria.Pk = eAcceso.Nombre;

            JObject jObject = new JObject();

            foreach (PropertyInfo propertyInfo in obj.GetType().GetProperties())
            {
                if (propertyInfo.PropertyType == typeof(string) || propertyInfo.PropertyType == typeof(int) || propertyInfo.PropertyType == typeof(Boolean))
                {
                    jObject[propertyInfo.Name] = propertyInfo.GetValue(obj).ToString();
                }
            }

            eAuditoria.Data = JsonConvert.SerializeObject(jObject);
            DaoAuditoria.add(eAuditoria);
        }

    }
}
