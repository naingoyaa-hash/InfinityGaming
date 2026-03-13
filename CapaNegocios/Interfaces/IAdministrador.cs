using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace InfinityGaming.CapaNegocios.Interfaces
{
    public interface IAdministrador
    {
        DataTable GenerarReporte(string tipoReporte, long idFactura = 0);

    }
}
