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
    }
}