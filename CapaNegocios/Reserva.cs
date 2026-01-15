using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityGaming
{
    internal class Reserva
    {
        private int IdReserva { get; set; }
        public double Fecha { get; set; }
        protected double HoraInicio { get; set; }
        protected double HoraFin { get; set; }
        private bool Estado { get; set; }

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