using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using InfinityGaming.CapaNegocios.Interfaces;

namespace InfinityGaming.CapaDatos
{
    internal class csCRUD : ICRUD
    {
        private csConexionBD conexion;

        public DataTable EjecutarSP_DataTable(string sp, params SqlParameter[] parametros)
        {
            DataTable dt = new DataTable();

            conexion = new csConexionBD();
            conexion.abrirConexion();

            using (SqlCommand cmd = new SqlCommand(sp, conexion.obtenerConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                if (parametros != null)
                    cmd.Parameters.AddRange(parametros);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            conexion.cerrarConexion();
            return dt;
        }

        public int EjecutarSP_NonQuery(string sp, params SqlParameter[] parametros)
        {
            int filas;

            conexion = new csConexionBD();
            conexion.abrirConexion();

            using (SqlCommand cmd = new SqlCommand(sp, conexion.obtenerConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                if (parametros != null)
                    cmd.Parameters.AddRange(parametros);

                filas = cmd.ExecuteNonQuery();
            }

            conexion.cerrarConexion();
            return filas;
        }

        public DataRow EjecutarSP_UnRegistro(string sp, params SqlParameter[] parametros)
        {
            DataTable dt = EjecutarSP_DataTable(sp, parametros);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }
    }
}
