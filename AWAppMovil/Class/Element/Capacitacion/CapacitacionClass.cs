using AWAppMovil.Models.Element.Capacitacion;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace AWAppMovil.Class.Element.Capacitacion
{
    public class CapacitacionClass
    {
        public static List<ModuloModel> GetModulosCapacitacion()
        {
            ClassBD db = new ClassBD();
            List<ModuloModel> modulos = new List<ModuloModel>();
            db.strSQL = "SELECT * FROM CAP_T_Modulo";

            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    ModuloModel modulo = new ModuloModel
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        Titulo = row["Titulo"].ToString()
                    };

                    modulos.Add(modulo);
                }
            }
            return modulos;
        }

        public static List<MaterialModel> GetMaterialPorModulo(int id)
        {
            ClassBD db = new ClassBD();
            List<MaterialModel> materiales = new List<MaterialModel>();
            db.strSQL = "SELECT * FROM CAP_T_Material WHERE Modulo_id = "+id;

            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    MaterialModel material = new MaterialModel
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        Titulo = row["Titulo"].ToString(),
                        Url = row["Url"].ToString(),
                        Modulo_id = int.Parse(row["Modulo_id"].ToString()),
                        Tipo = int.Parse(row["Tipo"].ToString()),
                    };

                    materiales.Add(material);
                }
            }
            return materiales;
        }
    }
}