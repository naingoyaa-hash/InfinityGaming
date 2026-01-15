using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityGaming
{
    internal class Mantenimiento
    {
        private int IdMantenimiento { get; set; }
        public double Fecha { get; set; }
        public string Descripcion { get; set; }
        private string Tipo { get; set; }
        public double Costo { get; set; }

        public void RegistrarMantenimiento(double fecha, string descripcion, string tipo)

        {

        }
        public void ActualizarCosto(double nuevoCosto)

        {

        }
        public void FinalizarMantenimiento()

        {

        }
    }
}