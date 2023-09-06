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

            //db.strSQL = "SELECT Id, Num_empleado, Num_Asistencia, Fecha, Incidencia, Dia, Proyecto, SubProyecto, Servicio, Tipo, id_cf, DiaA  FROM  T_Asistenciasb WHERE Num_empleado = '" + numEmp + "' AND Proyecto = '" + proyecto + "' AND SubProyecto = '" + subproyecto + "' AND Servicio = '" + servicio + "' AND Fecha IN ('2023-06-26', '2023-06-27', '2023-06-28', '2023-06-29', '2023-06-30', '2023-07-01', '2023-07-02', '2023-07-03', '2023-07-04', '2023-07-05', '2023-07-06', '2023-07-07', '2023-07-08', '2023-07-09', '2023-07-10') ORDER BY Fecha";
            // CHIDA -- db.strSQL = "SELECT Fecha, Incidencia FROM  T_Asistenciasb WHERE (Num_empleado = '" + numEmp + "') AND (Proyecto = '" + proyecto + "') AND (SubProyecto = '" + subproyecto + "') AND (Servicio = '" + servicio + "') AND Fecha IN ('" + f1 + "', '" + f2 + "', '" + f3 + "', '" + f4 + "', '" + f5 + "', '" + f6 + "', '" + f7 + "', '" + f8 + "', '" + f9 + "', '" + f10 + "', '" + f11 + "', '" + f12 + "', '" + f13 + "', '" + f14 + "', '" + f15 + "') ORDER BY Fecha";
            //db.strSQL = "SELECT Fecha, Incidencia FROM T_Asistenciasb WHERE Num_empleado = '" + number + "' AND Fecha IN ('" + fecha + "', dateadd(day,-1, '" + fecha + "'), dateadd(day,-2,'" + fecha + "'), dateadd(day,-3,'" + fecha + "'), dateadd(day,-4,'" + fecha + "'), dateadd(day,-5,'" + fecha + "'), dateadd(day,-6,'" + fecha + "') , dateadd(day,-7,'" + fecha + "'), dateadd(day,-8, '" + fecha + "'), dateadd(day,-9, '" + fecha + "'), dateadd(day,-10, '" + fecha + "'), dateadd(day,-11,'12-06-2023'), dateadd(day,-12, '" + fecha + "'), dateadd(day,-13,'12-06-2023'), dateadd(day,-14, '" + fecha + "') ) order by Fecha";

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
    }
}