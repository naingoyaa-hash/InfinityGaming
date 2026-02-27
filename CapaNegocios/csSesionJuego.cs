using InfinityGaming.CapaDatos;
using System;
using System.Data.SqlClient;

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

        public decimal CostoTotal
        {
            get
            {
                return Math.Round((DuracionSegundos / 3600m) * PrecioPorHora, 2);
            }
        }

        public decimal PrecioPorHora { get; set; } = 2m; 

        csCRUD crud = new csCRUD();

        public void Iniciar()
        {

            crud.EjecutarSP_NonQuery("ISesionJuego",
                new SqlParameter("@IdPersona", IdPersona),
                new SqlParameter("@IdEquipo", IdEquipo),
                new SqlParameter("@IdReserva", (object)IdReserva ?? DBNull.Value),
                new SqlParameter("@InicioSesion", InicioSesion),
                new SqlParameter("@FinSesion", FinSesion),
                new SqlParameter("@CostoTotal", CostoTotal));
        }

        public void Actualizar()
        {
            crud.EjecutarSP_NonQuery("USesionJuego",
                new SqlParameter("@IdSesion", IdSesion),
                new SqlParameter("@IdPersona", IdPersona),
                new SqlParameter("@InicioSesion", InicioSesion),
                new SqlParameter("@FinSesion", FinSesion),
                new SqlParameter("@CostoTotal", CostoTotal));
        }

        public void Eliminar()
        {
            crud.EjecutarSP_NonQuery("DSesionJuego",
                new SqlParameter("@IdSesion", IdSesion));
        }

        public bool IniciarDesdeReserva(long idReserva, long idPersona, long idEquipo,
    DateTime inicioReserva, DateTime finReserva, decimal precioHora, out string mensaje)
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

            Iniciar();

            csReserva reserva = new csReserva()
            {
                IdReserva = idReserva,
                IdPersona = idPersona,
                IdEquipo = idEquipo,
                InicioReserva = inicioReserva,
                FinReserva = finReserva
            };

            reserva.Finalizar();

            mensaje = "Sesión iniciada correctamente.";
            return true;
        }
    }
}