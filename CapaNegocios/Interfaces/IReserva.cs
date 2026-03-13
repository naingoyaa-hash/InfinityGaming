using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityGaming.CapaNegocios.Interfaces
{
    public interface IReserva
    {
        (bool ok, string mensaje) Crear();
        (bool ok, string mensaje) Actualizar();
        (bool ok, string mensaje) Finalizar();
        (bool ok, string mensaje) Cancelar();
        DataTable Listar(long? id = null);
        (bool ok, string mensaje) AutoCancelarVencidas();
    }
}
