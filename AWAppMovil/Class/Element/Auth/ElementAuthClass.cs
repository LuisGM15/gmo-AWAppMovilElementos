using AWAppMovil.Models.Element.Auth;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AWAppMovil.Class.Element.Auth
{
    public class ElementAuthClass
    {
        public static List<ElementAuthModel> elementAuth(string num, string password)

        { 
            ClassBD db = new ClassBD();
            List<ElementAuthModel> elements = new List<ElementAuthModel>();
            db.strSQL = "SELECT CE.Num_Empleado, ltrim(rtrim(EMP.Nombres)) + ' ' + ltrim(rtrim(EMP.APaterno)) + ' ' + ltrim(rtrim(EMP.AMaterno)) Nombre, c1.Id As Proyecto_id, c2.Id As Subproyecto_id, c3.Id As Servicio_Id FROM APP_T_Cuenta_Elemento CE left join T_m_Estatus ES on CE.Num_empleado = ES.Num_Empleado left join T_Empleado EMP on EMP.Num_Empleado = CE.Num_Empleado left join T_m_Estatus t2 on CE.Num_empleado = t2.Num_Empleado left join T_Fechas t3 on CE.Num_Empleado = t3.Num_Empleado and t2.Estatus = t3.Estatus and t2.Proyecto = t3.Proyecto left join C_Proyecto c1 on c1.id = t2.Proyecto left join C_SubProyecto c2 on c2.Id = t3.SubProyecto left join C_Servicio c3 on c3.Id = t3.Servicio WHERE CE.Num_Empleado='"+num+"' AND CE.Password='"+password+"' AND ES.Estatus = 1 AND CE.Status = 1";
            //db.strSQL = "SELECT CE.Num_Empleado, ltrim(rtrim(EMP.Nombres)) + ' ' + ltrim(rtrim(EMP.APaterno)) + ' ' + ltrim(rtrim(EMP.AMaterno)) Nombre FROM APP_T_Cuenta_Elemento CE left join T_m_Estatus ES on CE.Num_empleado = ES.Num_Empleado left join T_Empleado EMP on EMP.Num_Empleado = CE.Num_Empleado WHERE CE.Num_Empleado='"+num+"' AND CE.Password='"+password+"' AND ES.Estatus = 1 AND CE.Status = 1";

            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    ElementAuthModel element = new ElementAuthModel();
                    element.Success = true;
                    element.Num_empleado = row["Num_Empleado"].ToString();
                    element.Nombre = row["Nombre"].ToString();
                    element.Proyecto_id = row["Proyecto_id"].ToString();
                    element.Subproyecto_id = row["Subproyecto_id"].ToString();
                    element.Servicio_id = row["Servicio_id"].ToString();

                    elements.Add(element);
                }
                return elements;
            }
            else
            {
                ElementAuthModel element = new ElementAuthModel();
                element.Success = false;
                elements.Add(element);

                return elements;
            }

        }
    }
}