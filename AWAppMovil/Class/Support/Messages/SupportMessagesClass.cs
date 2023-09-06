using AWAppMovil.Models.Support.Messages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AWAppMovil.Class.Support.Messages
{
    public class SupportMessagesClass
    {
        public static List<SupportSalaModel> GetSalas(string temaId)
        {
            ClassBD db = new ClassBD();
            List<SupportSalaModel> salas = new List<SupportSalaModel>();
            db.strSQL = "SELECT S.Id, S.Tema_id, S.Num_empleado, S.Fecha, ltrim(rtrim(E.Nombres)) + ' ' + ltrim(rtrim(E.APaterno)) + ' ' + ltrim(rtrim(E.AMaterno)) Elemento FROM APP_T_Sala  S  LEFT JOIN T_Empleado E ON E.Num_Empleado = S.Num_empleado WHERE S.Tema_id= '"+temaId+"' ";

            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    SupportSalaModel sala = new SupportSalaModel();
                    sala.Success = true;
                    sala.Id = int.Parse(row["Id"].ToString());
                    sala.Tema_id = row["Tema_id"].ToString();
                    sala.Num_empleado = row["Num_empleado"].ToString();
                    sala.Fecha = row["Fecha"].ToString();
                    sala.Elemento = row["Elemento"].ToString();

                    salas.Add(sala);
                }
                return salas;
            }
            else
            {
                SupportSalaModel sala = new SupportSalaModel();
                sala.Success = false;
                salas.Add(sala);

                return salas;
            }
        }

        public static SupportMensajeModel FindLastMessage(string sala)
        {
            ClassBD db = new ClassBD();
            SupportMensajeModel msj = new SupportMensajeModel();
            db.strSQL = "SELECT TOP 1 * FROM APP_T_Mensaje WHERE Sala_id='" + sala + "' ORDER BY Id DESC";

            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    msj.Success = true;
                    msj.Id = int.Parse(row["Id"].ToString());
                    msj.Sala_id = row["Sala_id"].ToString();
                    msj.Num_empleado = row["Num_empleado"].ToString();
                    msj.Contenido = row["Contenido"].ToString();
                    msj.Fecha = row["Fecha"].ToString();
                    msj.Visto = row["Visto"].ToString();
                }
                return msj;
            }
            else
            {
                msj.Success = false;
                return msj;
            }
        }

        public static List<SupportMensajeModel> GetMessages(string salaId)
        {
            ClassBD db = new ClassBD();
            List<SupportMensajeModel> msjs = new List<SupportMensajeModel>();
            db.strSQL = "SELECT * FROM APP_T_Mensaje M WHERE M.Sala_id = '" + salaId + "'";

            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    SupportMensajeModel msj = new SupportMensajeModel();
                    msj.Success = true;
                    msj.Id = int.Parse(row["Id"].ToString());
                    msj.Sala_id = row["Sala_id"].ToString();
                    msj.Num_empleado = row["Num_empleado"].ToString();
                    msj.Fecha = row["Fecha"].ToString();
                    msj.Soporte_id = row["Soporte_id"].ToString();
                    msj.Contenido = row["Contenido"].ToString();
                    msj.Visto = row["Visto"].ToString();

                    msjs.Add(msj);
                }
                return msjs;
            }
            else
            {
                SupportMensajeModel msj = new SupportMensajeModel();
                msj.Success = false;
                msjs.Add(msj);

                return msjs;
            }
        }

        public static SupportMensajeModel NewMensaje(string sala, string numEmp, string soporteId, string contenido, string fecha)
        {
            ClassBD db = new ClassBD();
            SupportMensajeModel mensaje = new SupportMensajeModel();
            db.strSQL = "INSERT INTO APP_T_Mensaje (Sala_id, Num_empleado, Soporte_id, Contenido, Fecha, Visto) VALUES ('" + sala + "', '" + numEmp + "', '" + soporteId + "', '" + contenido + "', '" + fecha + "', 'false'); SELECT SCOPE_IDENTITY() AS Mensaje_id;";

            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    mensaje.Success = true;
                    mensaje.Id = int.Parse(row["Mensaje_id"].ToString());
                }
                return mensaje;
            }
            else
            {
                mensaje.Success = false;
                return mensaje;
            }
        }
    }
}