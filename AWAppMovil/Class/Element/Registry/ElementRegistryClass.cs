using AWAppMovil.Models.Element.Registry;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace AWAppMovil.Class.Element.Registry
{
    public class ElementRegistryClass
    {
        public static ElementRegistryModel SearchAccountByNum(string num)
        {
            ClassBD db = new ClassBD();
            ElementRegistryModel element = new ElementRegistryModel();
            db.strSQL = "SELECT * FROM APP_T_Cuenta_Elemento CE WHERE CE.Num_empleado = '"+ num + "'";

            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    element.Success = true;
                    element.Num_empleado = row["Num_empleado"].ToString();
                }
                return element;
            }
            else
            {
                element.Success = false;
                return element;
            }
        }

        public static ElementRegistryModel GetElementToRegistry(string num)
        {
            ClassBD db = new ClassBD();
            ElementRegistryModel element = new ElementRegistryModel();
            db.strSQL = "SELECT DISTINCT t1.Id, t1.Num_Empleado, ltrim(rtrim(t1.Nombres)) + ' ' + ltrim(rtrim(t1.APaterno)) + ' ' + ltrim(rtrim(t1.AMaterno)) Nombre, c4.Puesto, t3.CURP FROM T_Empleado t1 LEFT JOIN T_m_Estatus t2 ON t1.Num_empleado = t2.Num_Empleado LEFT JOIN C_Puesto c4 ON c4.Id = t1.Puesto LEFT JOIN C_Estatus c5 ON c5.Id = t2.Estatus LEFT JOIN T_Curp t3 ON t1.Num_Empleado = t3.Num_Empleado WHERE t1.Num_Empleado = '"+num+"' AND t2.Estatus = 1";

            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    element.Success = true;
                    element.Id = int.Parse(row["Id"].ToString());
                    element.Num_empleado = row["Num_Empleado"].ToString();
                    element.Nombre = row["Nombre"].ToString();
                    element.Puesto = row["Puesto"].ToString();
                    element.Curp = row["Curp"].ToString();
                }
                return element;
            }
            else
            {
                element.Success = false;
                return element;
            }
        }

        public static ElementRegistryModel GetElementToRegistryByName(string name, string curp)
        {
            ClassBD db = new ClassBD();
            ElementRegistryModel element = new ElementRegistryModel();
            db.strSQL = "SELECT DISTINCT t1.Id, t1.Num_Empleado, ltrim(rtrim(t1.Nombres)) + ' ' + ltrim(rtrim(t1.APaterno)) + ' ' + ltrim(rtrim(t1.AMaterno)) Nombre, c4.Puesto, t3.CURP FROM T_Empleado t1 LEFT JOIN T_m_Estatus t2 ON t1.Num_empleado = t2.Num_Empleado LEFT JOIN C_Puesto c4 ON c4.Id = t1.Puesto LEFT JOIN C_Estatus c5 ON c5.Id = t2.Estatus LEFT JOIN T_Curp t3 ON t1.Num_Empleado = t3.Num_Empleado WHERE REPLACE(t1.Nombres + t1.APaterno + t1.AMaterno, ' ', '') LIKE '%" + name + "%' AND t2.Estatus = 1 AND t3.CURP = '" + curp + "'";

            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    element.Success = true;
                    element.Num_empleado = row["Num_empleado"].ToString();
                    element.Nombre = row["Nombre"].ToString();
                    element.Puesto = row["Puesto"].ToString();
                    element.Curp = row["Curp"].ToString();
                }
                return element;
            }
            else
            {
                element.Success = false;
                element.Nombre = name;
                element.Password = curp;
                return element;
            }
        }

        public static List<ElementRegistryModel> SearchAccountByName(string name)
        {
            ClassBD db = new ClassBD();
            List<ElementRegistryModel> elements = new List<ElementRegistryModel>(); 
            db.strSQL = "SELECT DISTINCT CE.Id, CE.Num_empleado, CE.Password, ltrim(rtrim(E.Nombres)) + ' ' + ltrim(rtrim(E.APaterno)) + ' ' + ltrim(rtrim(E.AMaterno)) Nombre FROM APP_T_Cuenta_Elemento CE LEFT JOIN T_Empleado E ON  CE.Num_empleado = E.Num_Empleado WHERE REPLACE(E.Nombres+E.APaterno+E.AMaterno, ' ', '') LIKE '%"+name+"%'";

            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    ElementRegistryModel element = new ElementRegistryModel();

                    element.Success = true;
                    element.Num_empleado = row["Num_empleado"].ToString();

                    elements.Add(element);
                }
                return elements;
            }
            else
            {
                ElementRegistryModel element = new ElementRegistryModel();

                element.Success = false;

                elements.Add(element);
                return elements;
            }
        }
        
        public static ElementRegistryModel CreateAccount(string num, string password, int status, string fecha)
        {
            ClassBD db = new ClassBD();
            ElementRegistryModel element = new ElementRegistryModel();
            db.strSQL = "INSERT INTO APP_T_Cuenta_Elemento(Num_empleado, Password, Status, Created_at) VALUES ('"+num+"', '"+password+"', "+status+", '"+fecha+ "'); SELECT SCOPE_IDENTITY() AS Account_id;";

            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    element.Success = true;
                    element.Id = int.Parse(row["Account_id"].ToString());
                }
                return element;
            }
            else
            {
                element.Success = false;
                return element;
            }

        }

        public static ElementRegistryModel BuscarElementoPorNombreCurp()
        {
            ClassBD db = new ClassBD();
            ElementRegistryModel element = new ElementRegistryModel();
            db.strSQL = "SELECT * FROM T_Empleado WHERE Num_empleado = 043055";

            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    element.Success = true;
                    element.Num_empleado = row["Num_Empleado"].ToString();
                    element.Nombre = row["Nombres"].ToString();
                    //element.Puesto = row["Puesto"].ToString();
                    //element.Curp = row["Curp"].ToString();
                }
            }
            else
            {
                element.Success = false;
                //element.Nombre = name;
                //element.Password = curp;
            }
            return element;
        }
    }
}