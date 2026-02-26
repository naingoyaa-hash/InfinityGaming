using InfinityGaming.CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public DataTable Insertar()
        {
            return crud.EjecutarSP_DataTable(
                "IProducto",
                new SqlParameter("@NombreProducto", NombreProducto),
                new SqlParameter("@Descripcion",
                    (object)Descripcion ?? DBNull.Value),
                new SqlParameter("@PrecioVenta", PrecioVenta),
                new SqlParameter("@Stock", Stock)
            );
        }

        public DataTable Actualizar()
        {
            return crud.EjecutarSP_DataTable(
                "UProducto",
                new SqlParameter("@IdProducto", IdProducto),
                new SqlParameter("@NombreProducto", NombreProducto),
                new SqlParameter("@Descripcion",
                    (object)Descripcion ?? DBNull.Value),
                new SqlParameter("@PrecioVenta", PrecioVenta),
                new SqlParameter("@Activo", Activo)
            );
        }

        public int Eliminar()
        {
            return crud.EjecutarSP_NonQuery(
                "DProducto",
                new SqlParameter("@IdProducto", IdProducto)
            );
        }

        public DataTable Listar(string buscar)
        {
            return crud.EjecutarSP_DataTable(
                "SProducto",
                new SqlParameter("@Buscar", buscar ?? "")
            );
        }

        public DataTable AjustarStock(int cantidad, string motivo)
        {
            return crud.EjecutarSP_DataTable(
                "AjusteInventario",
                new SqlParameter("@IdProducto", IdProducto),
                new SqlParameter("@Cantidad", cantidad),
                new SqlParameter("@Motivo", motivo)
            );
        }

        public DataRow ObtenerPorId(long id, string buscar)
        {
            return crud.EjecutarSP_UnRegistro(
                "SProducto",
                new SqlParameter("@IdProducto", id)
            );
        }
    }
}
