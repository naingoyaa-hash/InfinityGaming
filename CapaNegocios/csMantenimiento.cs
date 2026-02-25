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
    internal class csMantenimiento
    {
        public long IdMantenimiento { get; set; }
        public long IdEquipo { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public decimal Costo { get; set; }
        public bool Finalizado { get; set; }

        csCRUD crud = new csCRUD();

        public void Registrar()
        {
            crud.EjecutarSP_NonQuery("IMantenimiento",
                new SqlParameter("@IdEquipo", IdEquipo),
                new SqlParameter("@Fecha", Fecha),
                new SqlParameter("@Descripcion", Descripcion),
                new SqlParameter("@Tipo", Tipo),
                new SqlParameter("@Costo", Costo),
                new SqlParameter("@Finalizado", Finalizado));
        }

        public void Actualizar()
        {
            crud.EjecutarSP_NonQuery("UMantenimiento",
                new SqlParameter("@IdMantenimiento", IdMantenimiento),
                new SqlParameter("@IdEquipo", IdEquipo),
                new SqlParameter("@Fecha", Fecha),
                new SqlParameter("@Descripcion", Descripcion),
                new SqlParameter("@Tipo", Tipo),
                new SqlParameter("@Costo", Costo),
                new SqlParameter("@Finalizado", Finalizado));
        }

        public void Eliminar()
        {
            crud.EjecutarSP_NonQuery("DMantenimiento",
                new SqlParameter("@IdMantenimiento", IdMantenimiento));
        }
        public DataTable Listar()
        {
            return crud.EjecutarSP_DataTable("SMantenimiento");
        }
    }
}