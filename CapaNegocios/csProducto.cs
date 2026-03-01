using InfinityGaming.CapaDatos;
using System;
using System.Data;
using System.Data.SqlClient;

namespace InfinityGaming.CapaNegocios
{
    internal class csProducto
    {
        private csCRUD crud = new csCRUD();

        public long IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public bool Activo { get; set; }

        public (bool ok, string mensaje) Insertar()
        {
            var row = crud.EjecutarSP_UnRegistro(
                "IProducto",
                new SqlParameter("@NombreProducto", NombreProducto),
                new SqlParameter("@Descripcion", (object)Descripcion ?? DBNull.Value),
                new SqlParameter("@PrecioVenta", PrecioVenta),
                new SqlParameter("@Stock", Stock)
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
                "UProducto",
                new SqlParameter("@IdProducto", IdProducto),
                new SqlParameter("@NombreProducto", NombreProducto),
                new SqlParameter("@Descripcion", (object)Descripcion ?? DBNull.Value),
                new SqlParameter("@PrecioVenta", PrecioVenta),
                new SqlParameter("@Activo", Activo)
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
                "DProducto",
                new SqlParameter("@IdProducto", IdProducto)
            );

            if (row == null)
                return (false, "No hubo respuesta de la BD.");

            return (
                Convert.ToInt32(row["Resultado"]) == 1,
                row["Mensaje"].ToString()
            );
        }

        public DataTable Listar(string buscar)
        {
            return crud.EjecutarSP_DataTable(
                "SProducto",
                new SqlParameter("@Buscar", buscar ?? "")
            );
        }

        public (bool ok, string mensaje) AjustarStock(int cantidad, string motivo)
        {
            var row = crud.EjecutarSP_UnRegistro(
                "AjusteInventario",
                new SqlParameter("@IdProducto", IdProducto),
                new SqlParameter("@Cantidad", cantidad),
                new SqlParameter("@Motivo", motivo)
            );

            if (row == null)
                return (false, "No hubo respuesta de la BD.");

            return (
                Convert.ToInt32(row["Resultado"]) == 1,
                row["Mensaje"].ToString()
            );
        }

        public DataRow ObtenerPorId(long id)
        {
            return crud.EjecutarSP_UnRegistro(
                "SProducto",
                new SqlParameter("@IdProducto", id)
            );
        }
    }
}