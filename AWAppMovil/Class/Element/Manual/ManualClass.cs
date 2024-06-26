using AWAppMovil.Models.Element.Manual;
using System.Data;

namespace AWAppMovil.Class.Element.Manual
{
    public class ManualClass
    {
        public static ManualModel GetManualUsuario()
        {
            ClassBD db = new ClassBD();
            ManualModel manual = new ManualModel();
            db.strSQL = "SELECT * FROM APPS_T_Manual WHERE Num_app = 3";

            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    manual.Id = int.Parse(row["Id"].ToString());
                    manual.Num_app = int.Parse(row["Num_app"].ToString());
                    manual.Archivo = row["Archivo"].ToString();

                }

                return manual;
            }
            else
            {
                manual.Id = 0;
                return manual;
            }
        }
    }
}