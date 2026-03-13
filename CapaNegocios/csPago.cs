using InfinityGaming.CapaDatos;
using InfinityGaming.CapaNegocios.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;

namespace InfinityGaming
{
    internal class csPago : IPago
    {
        public long IdPago { get; set; }
        public long? IdSesion { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public string TipoPago { get; set; }
        public string EstadoPago { get; set; }

        csCRUD crud = new csCRUD();

        public (bool ok, string mensaje) RegistrarPago()
        {
            var row = crud.EjecutarSP_UnRegistro(
                "IPago",
                new SqlParameter("@IdSesion", (object)IdSesion ?? DBNull.Value),
                new SqlParameter("@Monto", Monto),
                new SqlParameter("@FechaPago", FechaPago),
                new SqlParameter("@TipoPago", TipoPago),
                new SqlParameter("@EstadoPago", EstadoPago)
            );

            if (row == null)
                return (false, "No hubo respuesta de la BD.");

            long resultado = Convert.ToInt64(row["Resultado"]);
            string mensaje = row["Mensaje"].ToString();

            if (resultado <= 0)
                return (false, mensaje);

            IdPago = resultado;

            return (true, mensaje);
        }
    }
}