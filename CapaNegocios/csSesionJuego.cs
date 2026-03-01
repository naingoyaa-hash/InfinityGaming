using InfinityGaming.CapaDatos;
using System;
using System.Data.SqlClient;
using System.Data;

namespace InfinityGaming
{
    public class csSesionJuegos
    {
        public long IdSesion { get; set; }
        public long IdPersona { get; set; }
        public long IdEquipo { get; set; }
        public long? IdReserva { get; set; }
        public DateTime InicioSesion { get; set; }
        public DateTime FinSesion { get; set; }

        public int DuracionSegundos
        {
            get
            {
                int segundos = (int)(FinSesion - InicioSesion).TotalSeconds;
                return Math.Max(0, segundos);
            }
        }

        public decimal PrecioPorHora { get; set; } = 2m;

        public decimal CostoTotal
        {
            get
            {
                return Math.Round((DuracionSegundos / 3600m) * PrecioPorHora, 2);
            }
        }

        csCRUD crud = new csCRUD();

        public (bool ok, string mensaje) Iniciar()
        {
            var row = crud.EjecutarSP_UnRegistro(
                "ISesionJuego",
                new SqlParameter("@IdPersona", IdPersona),
                new SqlParameter("@IdEquipo", IdEquipo),
                new SqlParameter("@IdReserva", (object)IdReserva ?? DBNull.Value),
                new SqlParameter("@InicioSesion", InicioSesion),
                new SqlParameter("@FinSesion", FinSesion),
                new SqlParameter("@CostoTotal", CostoTotal)
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
                "USesionJuego",
                new SqlParameter("@IdSesion", IdSesion),
                new SqlParameter("@IdPersona", IdPersona),
                new SqlParameter("@InicioSesion", InicioSesion),
                new SqlParameter("@FinSesion", FinSesion),
                new SqlParameter("@CostoTotal", CostoTotal)
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
                "DSesionJuego",
                new SqlParameter("@IdSesion", IdSesion)
            );

            if (row == null)
                return (false, "No hubo respuesta de la BD.");

            return (
                Convert.ToInt32(row["Resultado"]) == 1,
                row["Mensaje"].ToString()
            );
        }

        public bool IniciarDesdeReserva(
            long idReserva,
            long idPersona,
            long idEquipo,
            DateTime inicioReserva,
            DateTime finReserva,
            decimal precioHora,
            out string mensaje)
        {
            DateTime ahora = DateTime.Now;

            if (ahora >= finReserva)
            {
                mensaje = "La reserva ya terminó. No se puede iniciar la sesión.";
                return false;
            }

            InicioSesion = ahora;
            FinSesion = finReserva;
            IdReserva = idReserva;
            IdPersona = idPersona;
            IdEquipo = idEquipo;
            PrecioPorHora = precioHora;

            var resultadoSesion = Iniciar();

            if (!resultadoSesion.ok)
            {
                mensaje = resultadoSesion.mensaje;
                return false;
            }

            csReserva reserva = new csReserva()
            {
                IdReserva = idReserva,
                IdPersona = idPersona,
                IdEquipo = idEquipo,
                InicioReserva = inicioReserva,
                FinReserva = finReserva
            };

            var resultadoReserva = reserva.Finalizar();

            if (!resultadoReserva.ok)
            {
                mensaje = resultadoReserva.mensaje;
                return false;
            }

            mensaje = resultadoSesion.mensaje;
            return true;
        }
    }
}