
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityGaming
{
    internal class Alerta
    {
        public int IdAlerta { get; set; }
        public string Mensaje { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public bool Leida { get; set; }

        public int? IdComputadora { get; set; }
        public int? IdSesion { get; set; }

        public void GenerarAlarma(string mensaje, string tipo)

        {

        }
        public void MarcarComoLeida()

        {

        }
        public void EnviarNotificacion()

        {

        }

    }
}
