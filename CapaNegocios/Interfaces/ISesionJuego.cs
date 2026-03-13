using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityGaming.CapaNegocios.Interfaces
{
    public interface ISesionJuego
    {
        (bool ok, string mensaje) Iniciar();
        (bool ok, string mensaje) Actualizar();
        bool IniciarDesdeReserva(
           long idReserva,
           long idPersona,
           long idEquipo,
           DateTime inicioReserva,
           DateTime finReserva,
           decimal precioHora,
           out string mensaje);
    }
}
