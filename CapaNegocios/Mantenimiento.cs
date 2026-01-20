using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityGaming
{
    internal class Mantenimiento
    {
        public int IdMantenimiento { get; set; } 
        public int IdComputadora { get; set; }    
        public DateTime Fecha { get; set; }  
        public string Descripcion { get; set; }  
        public string Tipo { get; set; }   
        public decimal Costo { get; set; }  
        public bool Finalizado { get; set; }

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