using AWAppMovil.Models.Element.Profile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace AWAppMovil.Class.Element.Profile
{
    public class ElementProfileClass
    {
        public static ElementProfileModel GetProfile(string num)
        {
            ClassBD db = new ClassBD();
            ElementProfileModel profile = new ElementProfileModel();
            db.strSQL =
               "select distinct t1.Id, t1.Num_Empleado, ltrim(rtrim(t1.Nombres)) + ' ' + ltrim(rtrim(t1.APaterno)) + ' ' + ltrim(rtrim(t1.AMaterno)) Nombre, c5.Estatus, c1.Proyecto, c2.SubProyecto, c3.Servicio, c4.Puesto, T4.CURP, T5.RFC, T6.NSS, c8.Empresa, t8.EstadoCivil, C10.Jornada, c11.Dias, c12.turno, t12.Cuip from T_Empleado t1 left join T_m_Estatus t2 on t1.Num_empleado = t2.Num_Empleado left join T_Fechas t3 on t1.Num_Empleado = t3.Num_Empleado and t2.Estatus = t3.Estatus and t2.Proyecto = t3.Proyecto left join T_CURP T4 on t1.Num_Empleado = T4.Num_Empleado left join T_rfc T5 on T1.Num_Empleado = T5.Num_Empleado left join T_nss T6 on T1.Num_Empleado = T6.Num_Empleado left join T_Direccion t7 on t7.num_empleado = t1.Num_Empleado left join C_Proyecto c1 on c1.id = t2.Proyecto left join C_SubProyecto c2 on c2.Id = t3.SubProyecto left join C_Servicio c3 on c3.Id = t3.Servicio left join C_Puesto c4 on c4.Id = t1.Puesto left join C_Estatus c5 on c5.Id = t2.Estatus left join C_Estado c6 on c6.Id = t7.Estado left join C_Empresa c8 on c8.Id = t1.Empresa left join C_Municipios c9 on c9.Id = t7.Municipio left join T_DatosPersonales t8 on t8.Num_Empleado = t1.Num_Empleado LEFT JOIN T_Jornada t9 ON t9.Num_Empleado = t1.Num_Empleado LEFT JOIN C_Jornada c10 ON C10.Id = t9.Jornada LEFT JOIN T_Dias t10 ON t10.Num_Empleado = t1.Num_Empleado LEFT JOIN C_Dias c11 ON c11.Id = t10.Dias LEFT JOIN T_Turno t11 ON t11.Num_Empleado = t1.Num_Empleado LEFT JOIN C_Turno c12 ON c12.Id = t11.Turno LEFT JOIN T_Cuip t12 ON t12.Num_Empleado = t1.Num_Empleado WHERE t1.Num_Empleado = '"+num+"' AND t2.Estatus = 1 ";
            //db.strSQL =
            //    "select distinct t1.Id, t1.Num_Empleado, ltrim(rtrim(t1.Nombres)) + ' ' + ltrim(rtrim(t1.APaterno)) + ' ' + ltrim(rtrim(t1.AMaterno)) Nombre," +
            //   " t2.Estatus Estatus_id, c5.Estatus, t2.Proyecto Proyecto_id, c1.Proyecto, t3.SubProyecto Subproyecto_id, c2.SubProyecto, t3.Servicio Servicio_id, c3.Servicio, t1.Puesto Puesto_id, c4.Puesto, T4.CURP," +
            //   " T5.RFC, T6.NSS, t7.Estado Estado_id, c6.Estado EstadoN, t7.Calle, t7.Colonia, t7.CP, c9.Municipio, c8.Empresa, t1.Empresa Empresa_id, t8.EstadoCivil" +
            //   " from T_Empleado t1" +
            //   " left join T_m_Estatus t2 on t1.Num_empleado = t2.Num_Empleado" +
            //   " left join T_Fechas t3 on t1.Num_Empleado = t3.Num_Empleado and t2.Estatus = t3.Estatus and t2.Proyecto = t3.Proyecto" +
            //   " left join T_CURP T4 on t1.Num_Empleado = T4.Num_Empleado left join T_rfc T5 on T1.Num_Empleado = T5.Num_Empleado" +
            //   " left join T_nss T6 on T1.Num_Empleado = T6.Num_Empleado" +
            //   " left join T_Direccion t7 on t7.num_empleado = t1.Num_Empleado" +
            //   " left join C_Proyecto c1 on c1.id = t2.Proyecto" +
            //   " left join C_SubProyecto c2 on c2.Id = t3.SubProyecto" +
            //   " left join C_Servicio c3 on c3.Id = t3.Servicio" +
            //   " left join C_Puesto c4 on c4.Id = t1.Puesto" +
            //   " left join C_Estatus c5 on c5.Id = t2.Estatus" +
            //   " left join C_Estado c6 on c6.Id = t7.Estado" +
            //   " left join C_Empresa c8 on c8.Id = t1.Empresa" +
            //   " left join C_Municipios c9 on c9.Id = t7.Municipio" +
            //   " left join T_DatosPersonales t8 on t8.Num_Empleado = t1.Num_Empleado" +
            //   " WHERE t1.Num_Empleado = " + num + "AND t2.Estatus = 1";

            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    profile.Success = true;
                    profile.Num_empleado = row["Num_Empleado"].ToString();
                    profile.Nombre = row["Nombre"].ToString();
                    profile.Proyecto = row["Proyecto"].ToString();
                    profile.Subproyecto = row["Subproyecto"].ToString();
                    profile.Servicio = row["Servicio"].ToString();
                    profile.Puesto = row["Puesto"].ToString();
                    profile.Curp = row["CURP"].ToString();
                    profile.Rfc = row["RFC"].ToString();
                    profile.Nss = row["NSS"].ToString();
                    profile.Empresa = row["Empresa"].ToString();
                    profile.Estadocivil = row["EstadoCivil"].ToString();
                    profile.Jornada = row["Jornada"].ToString().Trim();
                    profile.Dias = row["Dias"].ToString().Trim();
                    profile.Turno = row["Turno"].ToString().Trim();
                    profile.Cuip = row["Cuip"].ToString();

                }
                return profile;
            }
            else

                profile.Success = false;
                return profile;
            }

        public static ElementFileModel getAvatar(string number)
        {
            ClassBD db = new ClassBD();
            ElementFileModel file = new ElementFileModel();
            db.strSQL = "Select Foto from T_Foto where Num_Empleado = '" + number + "'";
            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    file.Success = true;
                    file.Tipo = "avatar";
                    file.Url = row["Foto"].ToString();
                }
                return file;
            }
            else
            {
                file.Success = false;

                return file;
            }
        }
        public static List<ElementFileModel> getPhotos(string number)
        {
            ClassBD db = new ClassBD();
            List<ElementFileModel> files = new List<ElementFileModel>();
            db.strSQL = "Select * from t_FFOTOS F WHERE F.Num_Empleado = '" + number + "'";

            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    ElementFileModel file = new ElementFileModel();
                    file.Success = true;
                    file.Tipo = "image";
                    file.Num_empleado = row["Num_Empleado"].ToString();
                    file.Url = row["Archivo"].ToString();
                    file.Fecha = row["Fecha"].ToString();

                    files.Add(file);
                }
                return files;
            }
            else
            {
                ElementFileModel file = new ElementFileModel();
                file.Success = false;
                files.Add(file);

                return files;
            }
        }
    }   
}