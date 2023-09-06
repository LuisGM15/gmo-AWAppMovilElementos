using AWAppMovil.Models.Element.Notices;
using AWAppMovil.Models.Element.Registry;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace AWAppMovil.Class.Element.Notices
{
    public class ElementNoticesClass
    {
        public static List<ElementNoticeModel> GetNotices()
        {
            ClassBD db = new ClassBD();
            List<ElementNoticeModel> notices = new List<ElementNoticeModel>();
            db.strSQL = "SELECT * FROM INTRA_T_Aviso A WHERE (A.Sitio = 2 OR A.SItio = 3) AND A.Visible = 1 ";

            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    ElementNoticeModel notice = new ElementNoticeModel();

                    notice.Success = true;
                    notice.Id = int.Parse(row["Id"].ToString());
                    notice.Titulo = row["Titulo"].ToString();
                    notice.Descripcion = row["Descripcion"].ToString();
                    notice.Url = row["Url"].ToString();
                    notice.Formato = int.Parse(row["Formato"].ToString());
                    notice.Sitio = int.Parse(row["Sitio"].ToString());
                    notice.Visible = int.Parse(row["Visible"].ToString());
                    notice.Created_at = row["Created_at"].ToString();
                    notice.Updated_at = row["Updated_at"].ToString();

                    notices.Add(notice);
                }
                return notices;
            }
            else
            {
                ElementNoticeModel notice = new ElementNoticeModel();

                notice.Success = false;

                notices.Add(notice);
                return notices;
            }
        }

        public static List<ElementNoticeModel> GetTop5Notices()
        {
            ClassBD db = new ClassBD();
            List<ElementNoticeModel> notices = new List<ElementNoticeModel>();
            db.strSQL = "SELECT TOP 5 * FROM INTRA_T_Aviso  WHERE (Sitio = 2 OR Sitio = 3) AND Visible = 1 ORDER BY Id DESC";

            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    ElementNoticeModel notice = new ElementNoticeModel();

                    notice.Success = true;
                    notice.Id = int.Parse(row["Id"].ToString());
                    notice.Titulo = row["Titulo"].ToString();
                    notice.Descripcion = row["Descripcion"].ToString();
                    notice.Url = row["Url"].ToString();
                    notice.Formato = int.Parse(row["Formato"].ToString());
                    notice.Sitio = int.Parse(row["Sitio"].ToString());
                    notice.Visible = int.Parse(row["Visible"].ToString());
                    notice.Created_at = row["Created_at"].ToString();
                    notice.Updated_at = row["Updated_at"].ToString();

                    notices.Add(notice);
                }
                return notices;
            }
            else
            {
                ElementNoticeModel notice = new ElementNoticeModel();
                notice.Success = false;

                notices.Add(notice);
                return notices;
            }
        }
    
        public static ElementNoticeModel GetNoticeById(int id)
        {
            ClassBD db = new ClassBD();
            ElementNoticeModel notice = new ElementNoticeModel();
            db.strSQL = "SELECT * FROM INTRA_T_Aviso A WHERE A.Id = '"+id+"'";

            if (db.bol_Consulta())
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    notice.Success = true;
                    notice.Id = int.Parse(row["Id"].ToString());
                    notice.Titulo = row["Titulo"].ToString();
                    notice.Descripcion = row["Descripcion"].ToString();
                    notice.Url = row["Url"].ToString();
                    notice.Formato = int.Parse(row["Formato"].ToString());
                    notice.Sitio = int.Parse(row["Sitio"].ToString());
                    notice.Visible = int.Parse(row["Visible"].ToString());
                    notice.Created_at = row["Created_at"].ToString();
                    notice.Updated_at = row["Updated_at"].ToString();
                }
                return notice;
            }
            else
            {
                notice.Success = false;
                return notice;
            }
        }
    }
}