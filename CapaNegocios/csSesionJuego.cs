using InfinityGaming.CapaDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityGaming
{
    internal class csSesionJuegos
    {
        public long IdSesion { get; set; }
        public long IdPersona { get; set; }
        public long IdEquipo { get; set; }
        public long IdReserva { get; set; }
        public DateTime InicioSesion { get; set; }
        public DateTime FinSesion { get; set; }
        public decimal CostoTotal { get; set; }

        csCRUD crud = new csCRUD();

        public void Iniciar()
        {
            crud.EjecutarSP_NonQuery("ISesionJuego",
                new SqlParameter("@IdPersona", IdPersona),
                new SqlParameter("@IdEquipo", IdEquipo),
                new SqlParameter("@IdReserva", IdReserva),
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
    }
}

