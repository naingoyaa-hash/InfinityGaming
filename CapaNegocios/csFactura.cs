using InfinityGaming.CapaDatos;
using InfinityGaming.CapaNegocios.Interfaces;
using System;
using System.Data.SqlClient;
using System.Data;

namespace InfinityGaming
{
    internal class csFactura : IFactura
    {
        public long IdFactura { get; set; }
        public long IdPersona { get; set; }
        public long IdPago { get; set; }
        public string NumeroFactura { get; set; }
        public DateTime FechaEmision { get; set; }
        public decimal Total { get; set; }

        csCRUD crud = new csCRUD();

        public (bool ok, string mensaje, long idFactura) Generar()
        {
            var row = crud.EjecutarSP_UnRegistro(
                "IFactura",
                new SqlParameter("@IdPersona", IdPersona),
                new SqlParameter("@IdPago", IdPago),
                new SqlParameter("@NumeroFactura", NumeroFactura),
                new SqlParameter("@FechaEmision", FechaEmision),
                new SqlParameter("@Total", Total)
            );

            if (row == null)
                return (false, "No hubo respuesta de la BD.", 0);

            return (
        Convert.ToInt32(row["Resultado"]) == 1,
            row["Mensaje"].ToString(),
            row.Table.Columns.Contains("IdFactura") ? Convert.ToInt64(row["IdFactura"]) : 0
    );
        }
    }
}