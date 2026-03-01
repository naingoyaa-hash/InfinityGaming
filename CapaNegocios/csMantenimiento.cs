using InfinityGaming.CapaDatos;
using System;
using System.Data;
using System.Data.SqlClient;

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

        public (bool ok, string mensaje) Registrar()
        {
            var row = crud.EjecutarSP_UnRegistro(
                "IMantenimiento",
                new SqlParameter("@IdEquipo", IdEquipo),
                new SqlParameter("@Fecha", Fecha),
                new SqlParameter("@Descripcion", Descripcion),
                new SqlParameter("@Tipo", Tipo),
                new SqlParameter("@Costo", Costo),
                new SqlParameter("@Finalizado", Finalizado)
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
                "UMantenimiento",
                new SqlParameter("@IdMantenimiento", IdMantenimiento),
                new SqlParameter("@IdEquipo", IdEquipo),
                new SqlParameter("@Fecha", Fecha),
                new SqlParameter("@Descripcion", Descripcion),
                new SqlParameter("@Tipo", Tipo),
                new SqlParameter("@Costo", Costo),
                new SqlParameter("@Finalizado", Finalizado)
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
                "DMantenimiento",
                new SqlParameter("@IdMantenimiento", IdMantenimiento)
            );

            if (row == null)
                return (false, "No hubo respuesta de la BD.");

            return (
                Convert.ToInt32(row["Resultado"]) == 1,
                row["Mensaje"].ToString()
            );
        }

        public (bool ok, string mensaje) Finalizar()
        {
            var row = crud.EjecutarSP_UnRegistro(
                "FinalizarMantenimiento",
                new SqlParameter("@IdMantenimiento", IdMantenimiento)
            );

            if (row == null)
                return (false, "No hubo respuesta de la BD.");

            return (
                Convert.ToInt32(row["Resultado"]) == 1,
                row["Mensaje"].ToString()
            );
        }

        public DataTable Listar()
        {
            return crud.EjecutarSP_DataTable("SMantenimiento");
        }
    }
}