using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityGaming
{
    internal class PlataformaJuegos
    {
        public int IdPlataformaJuegos { get; set; } 
        public string Nombre { get; set; }
        public string Version { get; set; }    
        public List<string> JuegosDisponibles { get; set; }

        public void ActualizarVersion(string nuevaVersion)

        {

        }
        public bool VerificarCompatibilidad(csComputadora computadora)

        {
            return false;
        }
    }
}