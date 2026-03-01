using InfinityGaming.CapaDatos;
using System;
using System.Data.SqlClient;
using System.Data;

namespace InfinityGaming
{
    internal class csFactura
    {
        public long IdFactura { get; set; }
        public long IdPersona { get; set; }
        public long IdPago { get; set; }
        public string NumeroFactura { get; set; }
        public DateTime FechaEmision { get; set; }
        public decimal Total { get; set; }

        csCRUD crud = new csCRUD();

        public (bool ok, string mensaje) Generar()
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
                return (false, "No hubo respuesta de la BD.");

            return (
                Convert.ToInt32(row["Resultado"]) == 1,
                row["Mensaje"].ToString()
            );
        }

        public (bool ok, string mensaje) Actualizar()
        {
            var row = crud.EjecutarSP_UnRegistro(
                "UFactura",
                new SqlParameter("@IdFactura", IdFactura),
                new SqlParameter("@IdPersona", IdPersona),
                new SqlParameter("@IdPago", IdPago),
                new SqlParameter("@NumeroFactura", NumeroFactura),
                new SqlParameter("@FechaEmision", FechaEmision),
                new SqlParameter("@Total", Total)
            );

            if (row == null)
                return (false, "No hubo respuesta de la BD.");

            return (
                Convert.ToInt32(row["Resultado"]) == 1,
                row["Mensaje"].ToString()
            );
        }

        public (bool ok, string mensaje) Eliminar()
        {
            var row = crud.EjecutarSP_UnRegistro(
                "DFactura",
                new SqlParameter("@IdFactura", IdFactura)
            );

            if (row == null)
                return (false, "No hubo respuesta de la BD.");

            return (
                Convert.ToInt32(row["Resultado"]) == 1,
                row["Mensaje"].ToString()
            );
        }
    }
}