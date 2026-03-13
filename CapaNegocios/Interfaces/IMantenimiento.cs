using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityGaming.CapaNegocios.Interfaces
{
    public interface IMantenimiento
    {
        (bool ok, string mensaje) Registrar();
        (bool ok, string mensaje) Actualizar();
        (bool ok, string mensaje) Eliminar();
        (bool ok, string mensaje) Finalizar();
        DataTable Listar();
    }
}
