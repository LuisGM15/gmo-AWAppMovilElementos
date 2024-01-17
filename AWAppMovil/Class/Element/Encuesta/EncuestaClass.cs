
using AWAppMovil.Class.Datetime;
using AWAppMovil.Models.Element.Encuesta;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AWAppMovil.Class.Element.Encuesta
{
    public class EncuestaClass
    {
        public static List<EncuestaModel> GetEncuestasVigentes(string numElemento)
        {
            ClassBD db = new ClassBD();
            string cd = DatetimeClass.GetDateFormatYYYYMMDD();
            List<EncuestaModel> encuestas = new List<EncuestaModel>();
            db.strSQL = "SELECT T1.Id, T1.Titulo, T1.Descripcion, T1.Vigente, T1.Vigencia, T1.Created_at, CASE WHEN R1.Id IS NULL THEN 0 ELSE R1.Id END AS Relacion_id FROM APP_T_Encuesta T1 LEFT JOIN APP_R_Elemento_Encuesta R1 ON (R1.Encuesta_id = T1.Id AND R1.Num_elemento = '"+numElemento+"') WHERE T1.Vigente = 1 AND (CAST(Vigencia As Date) >= CAST('"+cd+"' AS Date))";

            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    EncuestaModel enc = new EncuestaModel
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        Titulo = row["Titulo"].ToString(),
                        Descripcion = row["Descripcion"].ToString(),
                        Vigente = int.Parse(row["Vigente"].ToString()),
                        Vigencia = row["Vigencia"].ToString(),
                        Relacion_id = int.Parse(row["Relacion_id"].ToString())
                    };

                    encuestas.Add(enc);
                }
            }
            return encuestas;
        }

        public static List<PreguntaModel> GetPreguntasByEncuesta(int encuestaId)
        {
            ClassBD db = new ClassBD();
            List<PreguntaModel> preguntas = new List<PreguntaModel>();
            db.strSQL = "SELECT * FROM APP_T_Pregunta WHERE Encuesta_id = "+encuestaId+" ORDER BY Posicion";

            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    PreguntaModel p = new PreguntaModel
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        Encuesta_id = int.Parse(row["Encuesta_id"].ToString()),
                        Pregunta = row["Pregunta"].ToString(),
                        Tipo = int.Parse(row["Tipo"].ToString()),
                        Posicion = int.Parse(row["Posicion"].ToString()),
                        Obligatorio = int.Parse(row["Obligatorio"].ToString()),
                    };
                    preguntas.Add(p);
                }
            }
            return preguntas;
        }

        public static RespuestaModel SaveRespuestas(string values)
        {
            ClassBD db = new ClassBD();
            RespuestaModel resp = new RespuestaModel();
            db.strSQL = "INSERT INTO APP_T_Respuesta(Pregunta_id, Respuesta, Num_elemento) VALUES " + values;

            if (db.bol_Ejecucion())
            {
                resp.Success = true;
                return resp;
            }
            else
            {
                resp.Success = false;
                return resp;
            }
            
        }

        public static RElementoEncuestaModel SaveRegistroEncuestaFinalizada(string numElemento, int encuestaId, string comentarios)
        {
            string cd = DatetimeClass.GetDateFormatYYYYMMDD();
            string ch = DatetimeClass.GetHourFormatHHMMSS();
            ClassBD db = new ClassBD();
            RElementoEncuestaModel ree = new RElementoEncuestaModel();
            db.strSQL = "INSERT INTO APP_R_Elemento_Encuesta(Num_elemento, Encuesta_id, Comentarios, Fecha, Hora) VALUES ('"+numElemento+"', "+encuestaId+", '"+comentarios+"', '"+cd+"', '"+ch+"');";

            if (db.bol_Ejecucion())
            {
                ree.Success = true;
                return ree;
            }
            else
            {
                ree.Success = false;
                return ree;
            }
        }
    }
}