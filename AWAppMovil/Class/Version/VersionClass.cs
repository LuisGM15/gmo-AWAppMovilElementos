using AWAppMovil.Models.Version;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AWAppMovil.Class.Version
{
    public class VersionClass
    {
        public static VersionModel CheckVersionActual(string version)
        {
            ClassBD db = new ClassBD();
            VersionModel mversion = new VersionModel();
            db.strSQL = "SELECT * FROM APPS_T_Version WHERE Num_app = 3 AND Version = '" + version + "' AND Vigencia = 1";

            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    mversion.Success = true;
                    mversion.Id = int.Parse(row["Id"].ToString());
                    mversion.Num_aplicacion = int.Parse(row["Num_app"].ToString());
                    mversion.Version = row["Version"].ToString();
                    mversion.Vigencia = int.Parse(row["Vigencia"].ToString());
                    mversion.Fecha = row["Fecha"].ToString();
                }
                return mversion;
            }
            else
            {
                mversion.Success = false;
                return mversion;
            }
        }
    }
}