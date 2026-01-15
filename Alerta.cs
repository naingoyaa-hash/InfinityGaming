
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityGaming
{
    internal class Alerta
    {
        private int IdAlerta { get; set; }
        public string Mensaje { get; set; }
        public double Fecha { get; set; }
        public string Tipo { get; set; }
        private bool Leida { get; set; }

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
