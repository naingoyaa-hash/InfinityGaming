using InfinityGaming.CapaDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public decimal CostoTotal { get; set; }
        public int MinutosContratados { get; set; }
        public DateTime HoraFinProgramada
        {
            get { return InicioSesion.AddMinutes(MinutosContratados); }
        }

        csCRUD crud = new csCRUD();

        public void Iniciar()
        {
            if (FinSesion == DateTime.MinValue)
                FinSesion = InicioSesion;

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
        public decimal CalcularCostoTotal(decimal precioPorHora)
        {
            if (FinSesion <= InicioSesion)
            {
                CostoTotal = 0;
                return CostoTotal;
            }

            TimeSpan tiempo = FinSesion - InicioSesion;

            decimal minutos = Math.Max(1, Math.Ceiling((decimal)tiempo.TotalMinutes));

            CostoTotal = Math.Round((minutos * precioPorHora) / 60m, 2);

            return CostoTotal;
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

            DateTime inicioSesionReal = ahora > inicioReserva ? ahora : inicioReserva;

            IdReserva = idReserva;
            IdPersona = idPersona;
            IdEquipo = idEquipo;
            InicioSesion = inicioSesionReal;
            FinSesion = finReserva;

            CalcularCostoTotal(precioHora);

            Iniciar();

            mensaje = "Sesión iniciada correctamente desde la reserva.";
            return true;
        }
        public void FinalizarAutomaticamente(decimal precioPorMinuto)
        {
            FinSesion = HoraFinProgramada;

            TimeSpan tiempo = FinSesion - InicioSesion;

            decimal minutos = (decimal)tiempo.TotalMinutes;

            CostoTotal = Math.Round(minutos * precioPorMinuto, 2);

            Actualizar();
        }
        public bool TiempoFinalizado()
        {
            return TiempoFinalizado(DateTime.Now);
        }
        public bool TiempoFinalizado(DateTime ahora)
        {
            return ahora >= HoraFinProgramada;
        }
    }
}

