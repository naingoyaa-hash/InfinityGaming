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
    internal class csEquipo
    {
        public long IdEquipo { get; set; }
        public string NombreEquipo { get; set; }
        public string Tipo { get; set; }
        public string Especificaciones { get; set; }
        public string Estado { get; set; }

        csCRUD crud = new csCRUD();

        public (bool ok, string mensaje) Insertar()
        {
            var row = crud.EjecutarSP_UnRegistro("IEquipo",
                new SqlParameter("@NombreEquipo", NombreEquipo),
                new SqlParameter("@Tipo", Tipo),
                new SqlParameter("@Especificaciones", Especificaciones),
                new SqlParameter("@Estado", Estado));

            if (row == null) return (false, "No hubo respuesta de la BD.");

            return (
                row.Table.Columns.Contains("Resultado") ? Convert.ToInt32(row["Resultado"]) == 1 : true,
                row.Table.Columns.Contains("Mensaje") ? row["Mensaje"].ToString() : ""
            );
        }

        public (bool ok, string mensaje) Actualizar()
        {
            var row = crud.EjecutarSP_UnRegistro("UEquipo",
                new SqlParameter("@IdEquipo", IdEquipo),
                new SqlParameter("@NombreEquipo", NombreEquipo),
                new SqlParameter("@Tipo", Tipo),
                new SqlParameter("@Especificaciones", Especificaciones),
                new SqlParameter("@Estado", Estado));

            if (row == null) return (false, "No hubo respuesta de la BD.");

            return (
                row.Table.Columns.Contains("Resultado") ? Convert.ToInt32(row["Resultado"]) == 1 : true,
                row.Table.Columns.Contains("Mensaje") ? row["Mensaje"].ToString() : ""
            );
        }

        public (bool ok, string mensaje) Eliminar()
        {
            var row = crud.EjecutarSP_UnRegistro("DEquipo",
                new SqlParameter("@IdEquipo", IdEquipo));

            if (row == null) return (false, "No hubo respuesta de la BD.");

            return (
                row.Table.Columns.Contains("Resultado") ? Convert.ToInt32(row["Resultado"]) == 1 : true,
                row.Table.Columns.Contains("Mensaje") ? row["Mensaje"].ToString() : ""
            );
        }
    }
}