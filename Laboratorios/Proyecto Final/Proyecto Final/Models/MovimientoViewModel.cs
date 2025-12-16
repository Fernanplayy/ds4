using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Final.Models
{
    public class MovimientoViewModel
    {
        public string Tipo { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public decimal? SaldoAnterior { get; set; }
        public decimal? SaldoNuevo { get; set; }
        public string NumeroCuenta { get; set; }
        public string NombreUsuario { get; set; }

    }
}