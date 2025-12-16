using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace Proyecto_Final
{
    public class TestController : Controller
    {
        public ActionResult Index()
        {
            using (SqlConnection cn = ConexionBD.ObtenerConexion())
            {
                cn.Open();
            }
            return Content("Conexión exitosa a la base de datos");
        }
    }
}