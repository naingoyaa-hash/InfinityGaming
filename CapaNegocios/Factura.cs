using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityGaming
{
    internal class Factura
    {
        public int IdFactura { get; set; }
        public string NumeroFactura { get; set; } 
        public DateTime FechaEmision { get; set; }
        public decimal Total { get; set; }  
        public int IdPago { get; set; }

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
