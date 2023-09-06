using AWAppMovil.Models.Element.Messages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace AWAppMovil.Class.Element
{
    public class ElementMessagesClass
    {
        public static List<ElementTemaModel> GetThemes()
        {
            ClassBD db = new ClassBD();
            List<ElementTemaModel> themes = new List<ElementTemaModel>();
            db.strSQL = "Select * from APP_C_Tema";

            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    ElementTemaModel tema = new ElementTemaModel();
                    tema.Success = true;
                    tema.Id = int.Parse(row["Id"].ToString());
                    tema.Titulo = row["Titulo"].ToString();

                    themes.Add(tema);
                }
                return themes;
            }
            else
            {
                ElementTemaModel tema = new ElementTemaModel();
                tema.Success = false;
                themes.Add(tema);

                return themes;
            }
        }

        public static List<ElementSalaModel> GetSalas(string num)
        {
            ClassBD db = new ClassBD();
            List<ElementSalaModel> salas = new List<ElementSalaModel>();
            db.strSQL = "Select S.Tema_id, S.Id, S.Num_empleado, S.Fecha, Tema.Titulo from APP_T_Sala S left join APP_C_Tema Tema on Tema.Id = S.Tema_id WHERE S.Num_empleado =  '" + num+ "' ORDER BY S.Id DESC";

            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    ElementSalaModel sala = new ElementSalaModel();
                    sala.Success = true;
                    sala.Id = int.Parse(row["Id"].ToString());
                    sala.Tema_id = row["Tema_id"].ToString();
                    sala.Num_empleado = row["Num_empleado"].ToString();
                    sala.Fecha = row["Fecha"].ToString();
                    sala.Tema = row["Titulo"].ToString();
                    salas.Add(sala);
                }
                return salas;
            }
            else
            {
                ElementSalaModel sala = new ElementSalaModel();
                sala.Success = false;
                salas.Add(sala);

                return salas;
            }
        }

        public static ElementSalaModel FindSala(string num, string tema) { 
            ClassBD db = new ClassBD();
            ElementSalaModel sala = new ElementSalaModel();

            db.strSQL = "SELECT S.Id, S.Tema_id, S.Num_empleado, S.Fecha, Tema.Titulo As Tema FROM APP_T_Sala S left join APP_C_Tema Tema on Tema.Id = S.Tema_id WHERE S.Tema_id  = '" +tema+"' AND S.Num_empleado = '"+num+"'";

            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    sala.Success = true;
                    sala.Id = int.Parse(row["Id"].ToString());
                    sala.Tema_id = row["Tema_id"].ToString();
                    sala.Num_empleado = row["Num_empleado"].ToString();
                    sala.Fecha = row["Fecha"].ToString();
                    sala.Tema = row["Tema"].ToString();
                }
                return sala;
            }
            else
            {
                sala.Success = false;
                return sala;
            }
        }

        public static ElementMensajeModel FindLastMessage(string sala) 
        {
            ClassBD db = new ClassBD();
            ElementMensajeModel msj = new ElementMensajeModel();
            db.strSQL = "SELECT TOP 1 * FROM APP_T_Mensaje WHERE Sala_id='"+sala+"' ORDER BY Id DESC";
            //db.strSQL = "SELECT TOP 1 * FROM APP_T_Mensaje WHERE Num_empleado='" + num+"' AND Sala_id='"+sala+"' ORDER BY Id DESC";

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

        public static List<ElementMensajeModel> GetMsjs(string sala)
        {
            ClassBD db = new ClassBD();
            List<ElementMensajeModel> msjs = new List<ElementMensajeModel>();
            db.strSQL = "Select * from APP_T_Mensaje where Sala_id = '" + sala + "'";


            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    ElementMensajeModel msj = new ElementMensajeModel();
                    msj.Success = true;
                    msj.Id = int.Parse(row["Id"].ToString());
                    msj.Sala_id = row["Sala_id"].ToString();
                    msj.Num_empleado = row["Num_empleado"].ToString();
                    msj.Soporte_id = row["Soporte_id"].ToString();
                    msj.Contenido = row["Contenido"].ToString();
                    msj.Fecha = row["Fecha"].ToString();
                    msj.Visto = row["Visto"].ToString();
                    msjs.Add(msj);
                }
                return msjs;
            }
            else
            {
                ElementMensajeModel msj = new ElementMensajeModel();
                msj.Success = false;
                msjs.Add(msj);

                return msjs;
            }
        }

        public static ElementSalaModel NewSala(string tema, string num_empleado, string fecha)
        {
            ClassBD db = new ClassBD();
            ElementSalaModel sala = new ElementSalaModel();
            db.strSQL = "INSERT INTO APP_T_Sala (Tema_id, Num_empleado, Fecha) VALUES ('" + tema + "', '" + num_empleado + "', '" + fecha + "'); SELECT SCOPE_IDENTITY() AS Sala_id;";

            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    sala.Success = true;
                    sala.Id = int.Parse(row["Sala_id"].ToString());   
                }
                return sala;
            }
            else
            {
                sala.Success = false;
                return sala;
            }
        }

        public static ElementMensajeModel NewMensaje(string sala, string numEmp, string soporteId, string contenido, string fecha)
        {
            ClassBD db = new ClassBD();
            ElementMensajeModel mensaje = new ElementMensajeModel();
            db.strSQL = "INSERT INTO APP_T_Mensaje (Sala_id, Num_empleado, Soporte_id, Contenido, Fecha, Visto) VALUES ('" + sala + "', '" + numEmp + "', '" + soporteId + "', '"+contenido+"', '"+fecha+"', 'false'); SELECT SCOPE_IDENTITY() AS Mensaje_id;";
            
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