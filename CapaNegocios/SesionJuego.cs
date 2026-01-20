using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityGaming
{
    internal class SesionJuegos
    {
        public int IdSesion { get; set; }
        public int IdReserva { get; set; } 
        public DateTime InicioSesion { get; set; }
        public DateTime? FinSesion { get; set; }
        public int? DuracionSegundos { get; set; }
        public decimal? CostoTotal { get; set; }

        public void IniciarSesion(double horaInicio)
        {

        }
        public void FinalizarSesion(double horaFin)

        {

        }
        public double CalcularDuracion()

        {
            return 0;
        }
        public double CalcularCosto(double costoHora)

        {
            return 0;
        }
    }
}
