using InfinityGaming.CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityGaming
{
    internal class csEmpleado : csUsuario
    {
        private long idEmpleado { get; set; }
        private bool estado { get; set; }
        csCRUD crud = new csCRUD();
        public int ObtenerSesionesHoy()
        {

            var tabla = crud.EjecutarSP_DataTable("SSesionJuego");

            int contador = 0;

            foreach (System.Data.DataRow row in tabla.Rows)
            {
                DateTime fecha = Convert.ToDateTime(row["InicioSesion"]);

                if (fecha.Date == DateTime.Now.Date)
                    contador++;
            }

            return contador;
        }
    }
}