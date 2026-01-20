using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityGaming
{
    internal class Reserva
    {
        public int IdReserva { get; set; }
        public int IdComputadora { get; set; } 
        public DateTime InicioReserva { get; set; }
        public DateTime FinReserva { get; set; }
        public bool Estado { get; set; } 

        public void CrearReserva(double fecha, double horaInicio, double horaFin)

        {

        }
        public void CancelarReserva()

        {

        }
        public void ModificarHorario(double nuevaHoraInicio, double nuevaHoraFin)

        {

        }
    }
}