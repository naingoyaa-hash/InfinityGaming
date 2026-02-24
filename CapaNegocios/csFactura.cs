using InfinityGaming.CapaDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public void Generar()
        {
            crud.EjecutarSP_NonQuery("IFactura",
                new SqlParameter("@IdPersona", IdPersona),
                new SqlParameter("@IdPago", IdPago),
                new SqlParameter("@NumeroFactura", NumeroFactura),
                new SqlParameter("@FechaEmision", FechaEmision),
                new SqlParameter("@Total", Total));
        }

        public void Actualizar()
        {
            crud.EjecutarSP_NonQuery("UFactura",
                new SqlParameter("@IdFactura", IdFactura),
                new SqlParameter("@IdPersona", IdPersona),
                new SqlParameter("@IdPago", IdPago),
                new SqlParameter("@NumeroFactura", NumeroFactura),
                new SqlParameter("@FechaEmision", FechaEmision),
                new SqlParameter("@Total", Total));
        }

        public void Eliminar()
        {
            crud.EjecutarSP_NonQuery("DFactura",
                new SqlParameter("@IdFactura", IdFactura));
        }
    }
}
