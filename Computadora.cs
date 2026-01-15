using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityGaming
{
    internal class Computadora
    {
        public int IdComputadora { get; set; }
        public bool Estado { get; set; }
        private double TiempoRestante { get; set; }
        public string JuegoActual { get; set; }

        public void AsignarPlataforma(PlataformaJuegos plataforma) { }
        public void CambiarEstado(bool estado) { }
        public double CalcularCosto(double horas) { return 0; }
        public void RegistrarMantenimiento(Mantenimiento mantenimiento) { }
    }
}