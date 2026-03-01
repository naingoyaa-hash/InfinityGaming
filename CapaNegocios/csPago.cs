using InfinityGaming.CapaDatos;
using System;
using System.Data;
using System.Data.SqlClient;

namespace InfinityGaming
{
    internal class csPago
    {
        public long IdPago { get; set; }
        public long IdSesion { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public string TipoPago { get; set; }
        public string EstadoPago { get; set; }

        csCRUD crud = new csCRUD();

        public (bool ok, string mensaje) RegistrarPago()
        {
            var row = crud.EjecutarSP_UnRegistro(
                "IPago",
                new SqlParameter("@IdSesion", IdSesion),
                new SqlParameter("@Monto", Monto),
                new SqlParameter("@FechaPago", FechaPago),
                new SqlParameter("@TipoPago", TipoPago),
                new SqlParameter("@EstadoPago", EstadoPago)
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
                "UPago",
                new SqlParameter("@IdPago", IdPago),
                new SqlParameter("@IdSesion", IdSesion),
                new SqlParameter("@Monto", Monto),
                new SqlParameter("@FechaPago", FechaPago),
                new SqlParameter("@TipoPago", TipoPago),
                new SqlParameter("@EstadoPago", EstadoPago)
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
                "DPago",
                new SqlParameter("@IdPago", IdPago)
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