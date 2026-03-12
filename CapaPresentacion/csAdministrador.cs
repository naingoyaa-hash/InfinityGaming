
using InfinityGaming.CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityGaming
{
    internal class csAdministrador : csUsuario
    {
        private int CodigoAcceso { get; set; }

        csCRUD crud = new csCRUD();
        public DataTable GenerarReporte(string tipoReporte, long idFactura = 0)
        {
            switch (tipoReporte)
            {
                case "Factura":
                    return crud.EjecutarSP_DataTable(
                        "SFactura",
                        new SqlParameter("@IdFactura", idFactura)
                    );

                case "Ventas":
                    return crud.EjecutarSP_DataTable(
                        "ReporteVentasDetallado"
                    );

                case "Productos":
                    return crud.EjecutarSP_DataTable(
                        "ReporteProductosMasVendidos"
                    );

                case "Ingresos":
                    return crud.EjecutarSP_DataTable(
                        "ReporteIngresosDiarios"
                    );

                default:
                    return null;
            }
        }
    }
}