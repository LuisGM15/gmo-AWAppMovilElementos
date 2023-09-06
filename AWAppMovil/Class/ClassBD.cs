using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace AWAppMovil.Class
{
    public class ClassBD
    {
        private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conSEIC"].ConnectionString);
        private SqlDataAdapter da;
        private SqlCommand cmd;

        public string strSQL { get; set; }
        public DataSet ds { get; set; }

        public bool bol_Consulta()
        {
            try
            {
                cmd = new SqlCommand(strSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                cmd.Connection.Close();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                    return true;
                return false;
            }
            catch
            {
                cmd.Connection.Close();
                return false;
            }
        }

        public bool bol_Ejecucion()
        {
            int intVal = 0;
            cmd = new SqlCommand(strSQL, con);
            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();
            intVal = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            if (intVal > 0)
                return true;
            return false;
        }

        public string strValSQL_Texto(string text)
        {
            if (text.Trim().Length > 0)
                return "'" + text.Trim() + "'";
            return "Null";
        }

        public string strValSQL_Num(string Numero)
        {
            if (Numero.Trim().Length > 0)
                return Numero.Trim();
            return "Null";
        }

        public string strValSQL_Num(int Numero)
        {
            if (Numero.ToString().Trim().Length > 0)
                return Numero.ToString().Trim();
            return "Null";
        }

        public string strValSQL_Num(double Numero)
        {
            if (Numero.ToString().Trim().Length > 0)
                return Numero.ToString().Trim();
            return "Null";
        }

        public string strValSQL_Num(float Numero)
        {
            if (Numero.ToString().Trim().Length > 0)
                return Numero.ToString().Trim();
            return "Null";
        }
    }
}