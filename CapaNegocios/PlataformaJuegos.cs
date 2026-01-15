using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityGaming
{
    internal class PlataformaJuegos
    {
        private int IdPlataformaJuegos { get; set; }
        private string Version { get; set; }
        public string JuegosDisponibles { get; set; }
        private bool ConexionActiva { get; set; }

        public void ActualizarVersion(string nuevaVersion)

        {

        }
        public bool VerificarCompatibilidad(Computadora computadora)

        {
            return false;
        }
    }
}