using InfinityGaming.CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Crear()
        {
            crud.EjecutarSP_NonQuery("IReserva",
                new SqlParameter("@IdPersona", IdPersona),
                new SqlParameter("@IdEquipo", IdEquipo),
                new SqlParameter("@InicioReserva", InicioReserva),
                new SqlParameter("@FinReserva", FinReserva),
                new SqlParameter("@Estado", Estado));
        }

        public void Actualizar()
        {
            crud.EjecutarSP_NonQuery("UReserva",
                new SqlParameter("@IdReserva", IdReserva),
                new SqlParameter("@IdPersona", IdPersona),
                new SqlParameter("@IdEquipo", IdEquipo),
                new SqlParameter("@InicioReserva", InicioReserva),
                new SqlParameter("@FinReserva", FinReserva),
                new SqlParameter("@Estado", Estado));
        }
        public void Finalizar()
        {
            crud.EjecutarSP_NonQuery("UReserva",
                new SqlParameter("@IdReserva", IdReserva),
                new SqlParameter("@IdPersona", IdPersona),
                new SqlParameter("@IdEquipo", IdEquipo),
                new SqlParameter("@InicioReserva", InicioReserva),
                new SqlParameter("@FinReserva", FinReserva),
                new SqlParameter("@Estado", "Finalizada"));
        }

        public void Cancelar()
        {
            crud.EjecutarSP_NonQuery("DReserva",
                new SqlParameter("@IdReserva", IdReserva));
        }

        public DataTable Listar(long? id = null)
        {
            return crud.EjecutarSP_DataTable("SReserva",
                new SqlParameter("@IdReserva", (object)id ?? DBNull.Value));
        }

        public void AutoCancelarVencidas()
        {
            crud.EjecutarSP_NonQuery("AutoCancelarReservasVencidas");
        }
    }
}