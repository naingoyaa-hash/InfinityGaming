using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityGaming.CapaNegocios.Interfaces
{
    public interface IEquipo
    {
        (bool ok, string mensaje) Insertar();
        (bool ok, string mensaje) Actualizar();
        (bool ok, string mensaje) Eliminar();
    }
}
