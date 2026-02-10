using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InfinityGaming.CapaDatos
{
    internal class csCRUD
    {
        private csConexionBD conexion;
        private SqlCommand oCom;
        private SqlDataAdapter oDA;
        private DataTable oDT;

        public DataTable EjecutarSP_DataTable(string sp, params SqlParameter[] parametros)
        {
            try
            {
                conexion = new csConexionBD();
                conexion.abrirConexion();

                oCom = new SqlCommand(sp, conexion.obtenerConexion());
                oCom.CommandType = CommandType.StoredProcedure;

                if (parametros != null && parametros.Length > 0)
                    oCom.Parameters.AddRange(parametros);

                oDA = new SqlDataAdapter(oCom);
                oDT = new DataTable();
                oDA.Fill(oDT);

                conexion.cerrarConexion();
                return oDT;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error SP_DataTable: " + ex.Message);
                return null;
            }
        }

        public DataTable ejecutarSP(string nombreSP, params SqlParameter[] parametros)
        {
            DataTable dt = new DataTable();

            using (SqlCommand cmd = new SqlCommand(nombreSP, conexion.obtenerConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                if (parametros != null)
                    cmd.Parameters.AddRange(parametros);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }


        public DataRow EjecutarSP_UnRegistro(string sp, params SqlParameter[] parametros)
        {
            var tabla = EjecutarSP_DataTable(sp, parametros);

            if (tabla != null && tabla.Rows.Count > 0)
                return tabla.Rows[0];

            return null;
        }


        public int login(string usuario, string password)
        {
            DataRow row = EjecutarSP_UnRegistro(
                "LoginUsuario",
                new SqlParameter("@Usuario", usuario),
                new SqlParameter("@Password", password)
            );

            if (row == null)
                return -1;

            return Convert.ToInt32(row["EsAdmin"]); 
        }
    }
}
