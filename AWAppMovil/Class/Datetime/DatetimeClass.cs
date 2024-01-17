using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AWAppMovil.Class.Datetime
{
    public class DatetimeClass
    {
        static string addCero(string valor)
        {
            if (valor.Length == 1)
            {
                valor = "0" + valor;
            }
            return valor;
        }

        public static string GetDateFormatYYYYMMDD()
        {
            DateTime currentDate = DateTime.Now;
            string fecha = currentDate.Year.ToString() + "-" + addCero(currentDate.Month.ToString()) + "-" + addCero(currentDate.Day.ToString());
            return fecha;
        }

        public static int GetDateFormatD()
        {
            DateTime currentDate = DateTime.Now;
            int fecha = currentDate.Day;
            return fecha;
        }

        public static string GetHourFormatHHMMSS()
        {
            DateTime currentdate = DateTime.Now;
            string hora = addCero(currentdate.Hour.ToString()) +":"+ addCero(currentdate.Minute.ToString());
            return hora;
        }
    }
}