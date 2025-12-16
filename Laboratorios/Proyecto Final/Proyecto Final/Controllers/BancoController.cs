using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;
using Proyecto_Final.Models;

namespace Proyecto_Final.Controllers
{
    public class BancoController : Controller
    {
        //LOGEARSE
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            using (SqlConnection cn = ConexionBD.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_LoginUsuario", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Session["UsuarioId"] = dr["UsuarioId"];
                    Session["Nombre"] = dr["Nombre"];
                    return RedirectToAction("Dashboard");
                }
            }

            ViewBag.Error = "Usuario o contraseña incorrectos";
            return View();
        }

        //REGISTO DE CUENTA
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string nombre, string email, string password)
        {
            using (SqlConnection cn = ConexionBD.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                cn.Open();

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    ViewBag.Error = "El correo ya está registrado";
                    return View();
                }
            }

            return RedirectToAction("Login");
        }

        //DASHBOARD
        public ActionResult Dashboard()
        {
            if (Session["UsuarioId"] == null)
                return RedirectToAction("Login");

            int usuarioId = (int)Session["UsuarioId"];

            using (SqlConnection cn = ConexionBD.ObtenerConexion())
            {
                string sql = "SELECT Saldo FROM Cuenta WHERE UsuarioId = @uid";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@uid", usuarioId);

                cn.Open();
                ViewBag.Saldo = cmd.ExecuteScalar();
            }

            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        //VER CUENTA
        public ActionResult Cuenta()
        {
            if (Session["UsuarioId"] == null)
                return RedirectToAction("Login");

            int usuarioId = (int)Session["UsuarioId"];

            using (SqlConnection cn = ConexionBD.ObtenerConexion())
            {
                cn.Open();

                //OBTENER DATOS DE LA CUENTA
                string sqlCuenta = @"
            SELECT CuentaId, NumeroCuenta, Saldo
            FROM Cuenta
            WHERE UsuarioId = @uid";

                SqlCommand cmdCuenta = new SqlCommand(sqlCuenta, cn);
                cmdCuenta.Parameters.AddWithValue("@uid", usuarioId);

                SqlDataReader drCuenta = cmdCuenta.ExecuteReader();

                if (!drCuenta.Read())
                {
                    ViewBag.Error = "No se encontró la cuenta.";
                    return View();
                }

                int cuentaId = Convert.ToInt32(drCuenta["CuentaId"]);
                ViewBag.NumeroCuenta = drCuenta["NumeroCuenta"];
                ViewBag.Saldo = drCuenta["Saldo"];

                drCuenta.Close();

                //OBTENER MOVIMIENTOS DE LA CUENTA
                string sqlMov = @"SELECT c.NumeroCuenta, u.Nombre, m.Tipo, m.Monto, m.Fecha, m.SaldoAnterior, m.SaldoNuevo FROM Movimiento m 
                                INNER JOIN Cuenta c ON m.CuentaId = c.CuentaId
                                INNER JOIN Usuario u ON c.UsuarioId = u.UsuarioId
                                WHERE m.CuentaId = @cid
                                ORDER BY m.Fecha DESC";

                SqlCommand cmdMov = new SqlCommand(sqlMov, cn);
                cmdMov.Parameters.AddWithValue("@cid", cuentaId);

                SqlDataReader drMov = cmdMov.ExecuteReader();

                var movimientos = new List<Proyecto_Final.Models.MovimientoViewModel>();

                while (drMov.Read())
                {
                    movimientos.Add(new MovimientoViewModel
                    {
                        NumeroCuenta = drMov["NumeroCuenta"].ToString(),
                        NombreUsuario = drMov["Nombre"].ToString(),
                        Tipo = drMov["Tipo"].ToString(),
                        Monto = Convert.ToDecimal(drMov["Monto"]),
                        Fecha = Convert.ToDateTime(drMov["Fecha"]),
                        SaldoAnterior = drMov["SaldoAnterior"] == DBNull.Value ? null : (decimal?)drMov["SaldoAnterior"],
                        SaldoNuevo = drMov["SaldoNuevo"] == DBNull.Value ? null : (decimal?)drMov["SaldoNuevo"]
                    });
                }

                ViewBag.Movimientos = movimientos;
            }
            return View();
        }

        //TRANSFERIR DINERO
        public ActionResult Transferir()
        {
            if (Session["UsuarioId"] == null)
                return RedirectToAction("Login");

            return View();
        }

        [HttpPost]
        public ActionResult Transferir(string numeroCuentaDestino, decimal monto)
        {
            if (Session["UsuarioId"] == null)
                return RedirectToAction("Login");

            int usuarioId = (int)Session["UsuarioId"];
            int cuentaOrigenId;

            using (SqlConnection cn = ConexionBD.ObtenerConexion())
            {
                cn.Open();

                //Obtener CuentaId del usuario logueado
                string sqlCuenta = "SELECT CuentaId FROM Cuenta WHERE UsuarioId = @uid";
                SqlCommand cmdCuenta = new SqlCommand(sqlCuenta, cn);
                cmdCuenta.Parameters.AddWithValue("@uid", usuarioId);

                cuentaOrigenId = (int)cmdCuenta.ExecuteScalar();

                //Ejecutar el procedimiento de transferencia
                SqlCommand cmd = new SqlCommand("sp_TransferirSimple", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CuentaOrigenId", cuentaOrigenId);
                cmd.Parameters.AddWithValue("@NumeroCuentaDestino", numeroCuentaDestino);
                cmd.Parameters.AddWithValue("@Monto", monto);

                try
                {
                    cmd.ExecuteNonQuery();
                    ViewBag.Mensaje = "Transferencia realizada correctamente";
                }
                catch (SqlException ex)
                {
                    ViewBag.Error = ex.Message;
                }
            }
            return View();
        }

        //HISTORIAL DE MOVIMIENTOS
        public ActionResult Movimientos()
        {
            if (Session["UsuarioId"] == null)
                return RedirectToAction("Login");

            int usuarioId = (int)Session["UsuarioId"];

            using (SqlConnection cn = ConexionBD.ObtenerConexion())
            {
                cn.Open();

                //Obtener CuentaId del usuario
                string sqlCuenta = "SELECT CuentaId FROM Cuenta WHERE UsuarioId = @uid";
                SqlCommand cmdCuenta = new SqlCommand(sqlCuenta, cn);
                cmdCuenta.Parameters.AddWithValue("@uid", usuarioId);

                int cuentaId = (int)cmdCuenta.ExecuteScalar();

                //Obtener movimientos
                string sql = @"
                SELECT Tipo, Monto, Fecha, SaldoAnterior, SaldoNuevo
                FROM Movimiento
                WHERE CuentaId = @cid
                ORDER BY Fecha DESC";

                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@cid", cuentaId);

                SqlDataReader dr = cmd.ExecuteReader();

                List<dynamic> lista = new List<dynamic>();

                while (dr.Read())
                {
                    lista.Add(new
                    {
                        Tipo = dr["Tipo"].ToString(),
                        Monto = dr["Monto"],
                        Fecha = dr["Fecha"],
                        SaldoAnterior = dr["SaldoAnterior"],
                        SaldoNuevo = dr["SaldoNuevo"]
                    });
                }

                ViewBag.Movimientos = lista;
            }

            return View();
        }

        //DEPOSITAR Y RETIRAR DINERO
        public ActionResult Operaciones()
        {
            if (Session["UsuarioId"] == null)
                return RedirectToAction("Login");

            return View();
        }

        [HttpPost]
        public ActionResult Operaciones(string tipo, decimal monto)
        {
            if (Session["UsuarioId"] == null)
                return RedirectToAction("Login");

            int usuarioId = (int)Session["UsuarioId"];

            using (SqlConnection cn = ConexionBD.ObtenerConexion())
            {
                cn.Open();

                //Obtener datos de la cuenta
                string sqlCuenta = "SELECT CuentaId, Saldo FROM Cuenta WHERE UsuarioId = @uid";
                SqlCommand cmdCuenta = new SqlCommand(sqlCuenta, cn);
                cmdCuenta.Parameters.AddWithValue("@uid", usuarioId);

                SqlDataReader dr = cmdCuenta.ExecuteReader();

                if (!dr.Read())
                {
                    ViewBag.Error = "Cuenta no encontrada";
                    return View();
                }

                int cuentaId = Convert.ToInt32(dr["CuentaId"]);
                decimal saldoActual = Convert.ToDecimal(dr["Saldo"]);

                dr.Close();

                if (tipo == "RETIRO" && saldoActual < monto)
                {
                    ViewBag.Error = "Saldo insuficiente";
                    return View();
                }

                decimal nuevoSaldo = tipo == "DEPOSITO"
                    ? saldoActual + monto
                    : saldoActual - monto;

                //Actualizar saldo
                string sqlUpdate = "UPDATE Cuenta SET Saldo = @s WHERE CuentaId = @cid";
                SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, cn);
                cmdUpdate.Parameters.AddWithValue("@s", nuevoSaldo);
                cmdUpdate.Parameters.AddWithValue("@cid", cuentaId);
                cmdUpdate.ExecuteNonQuery();

                //Registrar movimiento
                string sqlMov = @"
            INSERT INTO Movimiento
            (CuentaId, Tipo, Monto, SaldoAnterior, SaldoNuevo)
            VALUES (@cid, @tipo, @monto, @sa, @sn)";

                SqlCommand cmdMov = new SqlCommand(sqlMov, cn);
                cmdMov.Parameters.AddWithValue("@cid", cuentaId);
                cmdMov.Parameters.AddWithValue("@tipo", tipo);
                cmdMov.Parameters.AddWithValue("@monto", monto);
                cmdMov.Parameters.AddWithValue("@sa", saldoActual);
                cmdMov.Parameters.AddWithValue("@sn", nuevoSaldo);
                cmdMov.ExecuteNonQuery();

                ViewBag.Mensaje = "Operación realizada correctamente";
            }

            return View();
        }
    }
}
