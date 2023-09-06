using AWAppMovil.Models.Support.Account;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AWAppMovil.Class.Support.Auth
{
    public class SupportAuthClass
    {
        public static SupportAuthModel Login(string user, string password)
        {
            ClassBD db = new ClassBD();
            SupportAuthModel auth = new SupportAuthModel();
            db.strSQL = "SELECT C.Id, C.Nombre, C.Password, C.Tema_id, C.Created_at, T.Titulo As Tema FROM APP_T_Soporte_Cuenta C INNER JOIN APP_C_Tema T ON T.Id = c.Tema_id WHERE C.Nombre = '" + user+"' AND C.Password = '"+password+ "' AND C.Status = 1; ";

            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    auth.Success = true;
                    auth.Id = int.Parse(row["Id"].ToString());
                    auth.Nombre = row["Nombre"].ToString();
                    auth.Tema_id = row["Tema_id"].ToString();
                    auth.Tema = row["Tema"].ToString();
                }
                return auth;
            }
            else
            {
                auth.Success = false;
                return auth;
            }
        }
    }
}