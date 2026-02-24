using InfinityGaming.CapaDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void RegistrarPago()
        {
            crud.EjecutarSP_NonQuery("IPago",
                new SqlParameter("@IdSesion", IdSesion),
                new SqlParameter("@Monto", Monto),
                new SqlParameter("@FechaPago", FechaPago),
                new SqlParameter("@TipoPago", TipoPago),
                new SqlParameter("@EstadoPago", EstadoPago));
        }

        public void Actualizar()
        {
            crud.EjecutarSP_NonQuery("UPago",
                new SqlParameter("@IdPago", IdPago),
                new SqlParameter("@IdSesion", IdSesion),
                new SqlParameter("@Monto", Monto),
                new SqlParameter("@FechaPago", FechaPago),
                new SqlParameter("@TipoPago", TipoPago),
                new SqlParameter("@EstadoPago", EstadoPago));
        }

        public void Eliminar()
        {
            crud.EjecutarSP_NonQuery("DPago",
                new SqlParameter("@IdPago", IdPago));
        }
    }
}