using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityGaming.CapaNegocios.Interfaces
{
    public interface ICRUD
    {
        DataTable EjecutarSP_DataTable(string sp, params SqlParameter[] parametros);
        int EjecutarSP_NonQuery(string sp, params SqlParameter[] parametros);
        DataRow EjecutarSP_UnRegistro(string sp, params SqlParameter[] parametros);
    }
}
