using InfinityGaming.CapaDatos;
using System;
using System.Data;
using System.Data.SqlClient;

namespace InfinityGaming
{
    internal class csAlerta
    {
        public long IdAlerta { get; set; }
        public string Mensaje { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public bool Leida { get; set; }
        public long? IdComputadora { get; set; }
        public long? IdSesion { get; set; }

        csCRUD crud = new csCRUD();

        public (bool ok, string mensaje) GenerarAlarma()
        {
            var row = crud.EjecutarSP_UnRegistro(
                "IAlerta",
                new SqlParameter("@IdComputadora", (object)IdComputadora ?? DBNull.Value),
                new SqlParameter("@IdSesion", (object)IdSesion ?? DBNull.Value),
                new SqlParameter("@Mensaje", Mensaje),
                new SqlParameter("@Tipo", Tipo)
            );

            if (row == null)
                return (false, "No hubo respuesta de la BD.");

            return (
                Convert.ToInt32(row["Resultado"]) == 1,
                row["Mensaje"].ToString()
            );
        }

        public (bool ok, string mensaje) MarcarComoLeida()
        {
            var row = crud.EjecutarSP_UnRegistro(
                "UAlerta",
                new SqlParameter("@IdAlerta", IdAlerta),
                new SqlParameter("@Leida", true)
            );

            if (row == null)
                return (false, "No hubo respuesta de la BD.");

            return (
                Convert.ToInt32(row["Resultado"]) == 1,
                row["Mensaje"].ToString()
            );
        }
    }
}