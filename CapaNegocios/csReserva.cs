using InfinityGaming.CapaDatos;
using System;
using System.Data;
using System.Data.SqlClient;

namespace InfinityGaming
{
    internal class csReserva
    {
        public long IdReserva { get; set; }
        public long IdPersona { get; set; }
        public long IdEquipo { get; set; }
        public DateTime InicioReserva { get; set; }
        public DateTime FinReserva { get; set; }
        public string Estado { get; set; }

        csCRUD crud = new csCRUD();

        public (bool ok, string mensaje) Crear()
        {
            var row = crud.EjecutarSP_UnRegistro("IReserva",
                new SqlParameter("@IdPersona", IdPersona),
                new SqlParameter("@IdEquipo", IdEquipo),
                new SqlParameter("@InicioReserva", InicioReserva),
                new SqlParameter("@FinReserva", FinReserva),
                new SqlParameter("@Estado", Estado));

            if (row == null)
                return (false, "No hubo respuesta de la BD.");

            return (
                Convert.ToInt32(row["Resultado"]) == 1,
                row["Mensaje"].ToString()
            );
        }

        public (bool ok, string mensaje) Actualizar()
        {
            var row = crud.EjecutarSP_UnRegistro("UReserva",
                new SqlParameter("@IdReserva", IdReserva),
                new SqlParameter("@IdPersona", IdPersona),
                new SqlParameter("@IdEquipo", IdEquipo),
                new SqlParameter("@InicioReserva", InicioReserva),
                new SqlParameter("@FinReserva", FinReserva),
                new SqlParameter("@Estado", Estado));

            if (row == null)
                return (false, "No hubo respuesta de la BD.");

            return (
                Convert.ToInt32(row["Resultado"]) == 1,
                row["Mensaje"].ToString()
            );
        }

        public (bool ok, string mensaje) Finalizar()
        {
            var row = crud.EjecutarSP_UnRegistro("UReserva",
                new SqlParameter("@IdReserva", IdReserva),
                new SqlParameter("@IdPersona", IdPersona),
                new SqlParameter("@IdEquipo", IdEquipo),
                new SqlParameter("@InicioReserva", InicioReserva),
                new SqlParameter("@FinReserva", FinReserva),
                new SqlParameter("@Estado", "Finalizada"));

            if (row == null)
                return (false, "No hubo respuesta de la BD.");

            return (
                Convert.ToInt32(row["Resultado"]) == 1,
                row["Mensaje"].ToString()
            );
        }

        public (bool ok, string mensaje) Cancelar()
        {
            var row = crud.EjecutarSP_UnRegistro("DReserva",
                new SqlParameter("@IdReserva", IdReserva));

            if (row == null)
                return (false, "No hubo respuesta de la BD.");

            return (
                Convert.ToInt32(row["Resultado"]) == 1,
                row["Mensaje"].ToString()
            );
        }

        public DataTable Listar(long? id = null)
        {
            return crud.EjecutarSP_DataTable("SReserva",
                new SqlParameter("@IdReserva", (object)id ?? DBNull.Value));
        }

        public (bool ok, string mensaje) AutoCancelarVencidas()
        {
            var row = crud.EjecutarSP_UnRegistro("AutoCancelarReservasVencidas");

            if (row == null)
                return (false, "No hubo respuesta de la BD.");

            return (
                Convert.ToInt32(row["Resultado"]) == 1,
                row["Mensaje"].ToString()
            );
        }
    }
}