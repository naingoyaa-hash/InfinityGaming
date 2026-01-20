using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityGaming
{
    internal class Computadora
    {
        private int IdComputadora { get; set; }
        private string nombreComputadora { get; set; }
        private bool Estado { get; set; }
        private int TiempoRestanteSegundos { get; set; }
        public string JuegoActual { get; set; }

        public void AsignarPlataforma(PlataformaJuegos plataforma) { }
        public void CambiarEstado(bool estado) { }
        public double CalcularCosto(double horas) { return 0; }
        public void RegistrarMantenimiento(Mantenimiento mantenimiento) { }
    }
}