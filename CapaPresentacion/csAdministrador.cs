
using InfinityGaming.CapaDatos;
using InfinityGaming.CapaNegocios.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityGaming
{
    internal class csAdministrador : csUsuario, IAdministrador
    {
        private int CodigoAcceso { get; set; }

        csCRUD crud = new csCRUD();
        public DataTable GenerarReporte(string tipoReporte, long idFactura = 0)
        {
            switch (tipoReporte)
            {
                case "Factura":
                    return crud.EjecutarSP_DataTable(
                        "SPReporteFactura",
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
        public int ObtenerEquiposDisponibles()
        {
            DataTable dt = crud.EjecutarSP_DataTable("sp_EquiposDisponibles");

            if (dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0]["Total"]);

            return 0;
        }
        public decimal ObtenerVentasDelDia()
        {
            DataTable dt = crud.EjecutarSP_DataTable("sp_VentasDelDia");

            if (dt.Rows.Count > 0)
                return Convert.ToDecimal(dt.Rows[0]["TotalVentas"]);

            return 0;
        }
    }
}