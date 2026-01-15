using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityGaming
{
    internal class Factura
    {
        private int IdFactura { get; set; }
        public string NumeroFactura { get; set; }
        public double FechaEmision { get; set; }
        public double Total { get; set; }

        public void GenerarFactura(Pago pago)

        {

        }
        public double CalcularTotal(double monto)

        {
            return 0;
        }
        public void ImprimirFactura()

        {

        }
    }
}
