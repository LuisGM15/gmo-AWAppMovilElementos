using AWAppMovil.Models.Element.Expedient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AWAppMovil.Class.Element.Expedient
{
    public class ElementExpedientClass
    {
        public static List<ElementExpedientModel> GetExpedient(string number)
        {
            ClassBD db = new ClassBD();
            List<ElementExpedientModel> exps = new List<ElementExpedientModel>();
            db.strSQL = "declare @T_Archivo table (num_Empleado varchar(6), Archivo varchar(max), Ruta varchar(max), original varchar(2), copia varchar(2)); insert into @T_Archivo (num_Empleado, Archivo, Ruta) select * from Vi_ListaUltimosDocumentos where num_empleado = '" + number + "'; update @T_Archivo set original = t2.Acta_O, copia = t2.Acta_C from @T_Archivo t1 inner join T_CExpediente t2 on t1.num_empleado = t2.num_empleado where t1.Archivo = 'ACTA DE NACIMIENTO'; update @T_Archivo set original = t2.Cest_O, copia = t2.Cest_C from @T_Archivo t1 inner join T_CExpediente t2 on t1.num_empleado = t2.num_empleado where t1.Archivo = 'CERTIFICADOS DE ESTUDIOS'; update @T_Archivo set original = t2.Cartilla_O, copia = t2.Cartilla_C from @T_Archivo t1 inner join T_CExpediente t2 on t1.num_empleado = t2.num_empleado where t1.Archivo = 'CARTILLA DEL SERVICIO MILITAR'; update @T_Archivo set original = t2.Cdomi_O, copia = t2.Cdomi_C from @T_Archivo t1 inner join T_CExpediente t2 on t1.num_empleado = t2.num_empleado where t1.Archivo = 'COMPROBANTE DE DOMICILIO RECIENTE'; update @T_Archivo set original = t2.Cine_O, copia = t2.Cine_C from @T_Archivo t1 inner join T_CExpediente t2 on t1.num_empleado = t2.num_empleado where t1.Archivo = 'CREDENCIAL DE ELECTOR'; update @T_Archivo set original = t2.curp_o, copia = t2.Curp_C from @T_Archivo t1 inner join T_CExpediente t2 on t1.num_empleado = t2.num_empleado where t1.Archivo = 'CURP'; update @T_Archivo set original = t2.Rfc_O, copia = t2.Rfc_C from @T_Archivo t1 inner join T_CExpediente t2 on t1.num_empleado = t2.num_empleado where t1.Archivo = 'RFC'; update @T_Archivo set original = t2.afil_o, copia = t2.afil_C from @T_Archivo t1 inner join T_CExpediente t2 on t1.num_empleado = t2.num_empleado where t1.Archivo = 'NUMERO DE AFILIACION DE IMSS'; update @T_Archivo set original = t2.Cante_O, copia = t2.Cante_C from @T_Archivo t1 inner join T_CExpediente t2 on t1.num_empleado = t2.num_empleado where t1.Archivo = 'CERTIFICADO DE ANTECEDENTES PENALES'; update @T_Archivo set original = t2.Clabo_O, copia = t2.Clabo_C from @T_Archivo t1 inner join T_CExpediente t2 on t1.num_empleado = t2.num_empleado where t1.Archivo = 'ANTECEDENTES LABORALES'; update @T_Archivo set original = t2.Exa_O, copia = t2.Exa_C from @T_Archivo t1 inner join T_CExpediente t2 on t1.num_empleado = t2.num_empleado where t1.Archivo = 'EXAMEN MEDICO'; update @T_Archivo set original = t2.Cont_O, copia = t2.Cont_C from @T_Archivo t1 inner join T_CExpediente t2 on t1.num_empleado = t2.num_empleado where t1.Archivo = 'CONTRATO'; update @T_Archivo set original = t2.Ced_O, copia = t2.Ced_C from @T_Archivo t1 inner join T_CExpediente t2 on t1.num_empleado = t2.num_empleado where t1.Archivo = 'CEDULA COMPLETA'; update @T_Archivo set original = t2.examp_o, copia = t2.examp_C from @T_Archivo t1 inner join T_CExpediente t2 on t1.num_empleado = t2.num_empleado where t1.Archivo = 'EXAMEN PSICOLOGICO'; update @T_Archivo set original = t2.examt_o, copia = t2.examt_c from @T_Archivo t1 inner join T_CExpediente t2 on t1.num_empleado = t2.num_empleado where t1.Archivo = 'EXAMEN TOXICOLOGICO'; update @T_Archivo set original = t2.dc_O, copia = t2.dc_c from @T_Archivo t1 inner join T_CExpediente t2 on t1.num_empleado = t2.num_empleado where t1.Archivo = 'DC3'; update @T_Archivo set original = t2.cuip_o, copia = t2.cuip_c from @T_Archivo t1 inner join T_CExpediente t2 on t1.num_empleado = t2.num_empleado where t1.Archivo = 'CUIP'; update @T_Archivo set original = t2.cip_o, copia = t2.cip_c from @T_Archivo t1 inner join T_CExpediente t2 on t1.num_empleado = t2.num_empleado where t1.Archivo = 'CIP'; select ROW_NUMBER() over(order by archivo) num, * from @T_Archivo;";

            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    ElementExpedientModel exp = new ElementExpedientModel();
                    exp.Success = true;
                    exp.Num_empleado = row["num_Empleado"].ToString();
                    exp.Archivo = row["Archivo"].ToString();
                    exp.Ruta = row["Ruta"].ToString();

                    exps.Add(exp);
                }
                return exps;
            }
            else
            {
                ElementExpedientModel exp = new ElementExpedientModel();
                exp.Success = false;
                exps.Add(exp);

                return exps;
            }
        }
    }
}