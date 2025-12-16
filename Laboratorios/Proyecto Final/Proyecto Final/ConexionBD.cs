using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace Proyecto_Final
{
    public class ConexionBD
    {
        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(
                ConfigurationManager.ConnectionStrings["BancoDB"].ConnectionString
            );
        }
    }
}