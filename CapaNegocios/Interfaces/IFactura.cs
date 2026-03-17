using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityGaming.CapaNegocios.Interfaces
{
    public interface IFactura
    {
        (bool ok, string mensaje, long idFactura) Generar();
    }
}
