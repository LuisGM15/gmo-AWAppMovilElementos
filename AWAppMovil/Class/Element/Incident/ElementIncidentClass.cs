using AWAppMovil.Class.Datetime;
using AWAppMovil.Models.Element.Incident;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AWAppMovil.Class.Element.Incident
{
    public class ElementIncidentClass
    {
        public static List<ElementIncidentModel> GetIncidents(string numEmp, string proyecto, string subproyecto, string servicio, string f1, string f2, string f3, string f4, string f5, string f6, string f7, string f8, string f9, string f10, string f11, string f12, string f13, string f14, string f15)
        {
            ClassBD db = new ClassBD();
            List<ElementIncidentModel> incidents = new List<ElementIncidentModel>();
            db.strSQL = "SELECT Fecha, Incidencia FROM  T_Asistenciasb WHERE (Num_empleado = '" + numEmp + "') AND Fecha IN ('" + f1 + "', '" + f2 + "', '" + f3 + "', '" + f4 + "', '" + f5 + "', '" + f6 + "', '" + f7 + "', '" + f8 + "', '" + f9 + "', '" + f10 + "', '" + f11 + "', '" + f12 + "', '" + f13 + "', '" + f14 + "', '" + f15 + "') ORDER BY Fecha";

            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    ElementIncidentModel inc = new ElementIncidentModel();
                    inc.Success = true;
                    inc.Fecha = row["Fecha"].ToString();
                    inc.Incidencia = row["Incidencia"].ToString();

                    incidents.Add(inc);
                }
                return incidents;
            }
            else
            {
                ElementIncidentModel inc = new ElementIncidentModel();
                inc.Success = false;
                incidents.Add(inc);

                return incidents;
            }
        }

        public static List<IncidenciaElementoModel> GetIncidencias15dias(string num, int servicio)
        {
            string cd = DatetimeClass.GetDateFormatYYYYMMDD();
            ClassBD db = new ClassBD();
            List<IncidenciaElementoModel> incidencias = new List<IncidenciaElementoModel> ();
            db.strSQL = "SELECT TOP 15 Fecha, Incidencia FROM  T_Asistenciasb WHERE (Num_empleado = '"+num+"') AND Fecha < CAST('"+cd+"' AS Date) ORDER BY Fecha DESC";

            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    IncidenciaElementoModel inci = new IncidenciaElementoModel
                    {
                        Fecha = row["Fecha"].ToString(),
                        Incidencia = row["Incidencia"].ToString()
                    };

                    incidencias.Add(inci);
                }
            }
            return incidencias;
        }
    
        public static List<IncidenciaModel> GetCatalogoIncidencias()
        {
            ClassBD db = new ClassBD();
            List<IncidenciaModel> incidencias = new List<IncidenciaModel>();
            db.strSQL = "SELECT * FROM C_Inciden;";

            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    IncidenciaModel inci = new IncidenciaModel
                    {
                        Inci = row["Inci"].ToString(),
                        Titulo = row["Titulo"].ToString(),
                        Descripcion = row["Descripcion"].ToString(),
                        Tipo = int.Parse(row["Tipo"].ToString())
                    };

                    incidencias.Add(inci);
                }
            }
            return incidencias;
        }
    
        public static ProyectoIncidenciaModel GetProyectoElemento(string num)
        {
            ClassBD db = new ClassBD();
            ProyectoIncidenciaModel proyecto = new ProyectoIncidenciaModel();
            db.strSQL = "SELECT DISTINCT t1.Id, t1.Num_Empleado, ltrim(rtrim(t1.Nombres)) + ' ' + ltrim(rtrim(t1.APaterno)) + ' ' + ltrim(rtrim(t1.AMaterno)) Nombre, c1.Id Proyecto_id, c1.Proyecto, c2.Id Subproyecto_id, c2.SubProyecto, c3.Id Servicio_id, c3.Servicio FROM T_Empleado t1 LEFT JOIN T_m_Estatus t2 ON t1.Num_empleado = t2.Num_Empleado LEFT JOIN T_Fechas t3 ON t1.Num_Empleado = t3.Num_Empleado and t2.Estatus = t3.Estatus and t2.Proyecto = t3.Proyecto LEFT JOIN C_Proyecto c1 ON c1.id = t2.Proyecto LEFT JOIN C_SubProyecto c2 ON c2.Id = t3.SubProyecto LEFT JOIN C_Servicio c3 ON c3.Id = t3.Servicio WHERE t1.Num_Empleado = '"+num+"' AND t2.Estatus = 1";

            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    proyecto.Id = int.Parse(row["Proyecto_id"].ToString());
                    proyecto.Proyecto = row["Proyecto"].ToString();
                }
            }
            else
            {
                proyecto.Id = 0;
            }
            return proyecto;
        }
    
        public static List<IncidenciaElementoModel> GetDobletesAeropuerto(string num)
        {
            string cd = DatetimeClass.GetDateFormatYYYYMMDD();
            ClassBD db = new ClassBD();
            List<IncidenciaElementoModel> incidencias = new List<IncidenciaElementoModel>();
            db.strSQL = "SELECT TOP 7 Fecha, Incidencia FROM T_Asistenciasb WHERE (Num_empleado = '"+num+"' AND Proyecto = 1225 AND SubProyecto = 699 AND Servicio = 18041) AND Fecha < CAST('"+cd+"' AS Date) ORDER BY Fecha DESC";

            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    IncidenciaElementoModel inci = new IncidenciaElementoModel
                    {
                        Fecha = row["Fecha"].ToString(),
                        Incidencia = row["Incidencia"].ToString()
                    };

                    incidencias.Add(inci);
                }
            }
            return incidencias;
        }
    }
}