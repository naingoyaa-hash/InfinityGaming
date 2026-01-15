using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityGaming
{
    internal class Pago
    {
        private int IdPago { get; set; }
        public double Monto { get; set; }
        public double FechaPago { get; set; }
        public string TipoPago { get; set; }
        private string EstadoPago { get; set; }

        public void RegistrarPago(double monto, string tipoPago)

        {

        }
        public void ConfirmarPago()

        {

        }
        public void AnularPago()

        {

        }
    }
}