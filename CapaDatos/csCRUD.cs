using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfinityGaming.CapaDatos
{
    internal class csCRUD
    {
        public csConexionBD conexion;
        SqlCommand oCom;
        SqlDataAdapter oDA;
        DataTable oDT;
        SqlDataReader oDTR;

        public csCRUD() { }

        public DataTable cargarBDData(string sentencia, params SqlParameter[] parametros)
        {
            try
            {
                conexion = new csConexionBD();
                conexion.abrirConexion();
                oCom = new SqlCommand(sentencia, conexion.obtenerConexion());
                if (parametros != null)
                {
                    foreach (var p in parametros)
                        oCom.Parameters.Add(p);
                }
                oDA = new SqlDataAdapter(oCom);
                oDT = new DataTable();
                oDA.Fill(oDT);
                conexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
            return oDT;
        }

        public bool agregarBD(string sentencia, params SqlParameter[] parametros)
        {
            try
            {
                conexion = new csConexionBD();
                conexion.abrirConexion();
                oCom = new SqlCommand(sentencia, conexion.obtenerConexion());
                foreach (var parametro in parametros)
                    oCom.Parameters.Add(parametro);
                oCom.ExecuteNonQuery();
                conexion.cerrarConexion();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        public bool eliminarBD(string sentencia, int id)
        {
            try
            {
                conexion = new csConexionBD();
                conexion.abrirConexion();
                oCom = new SqlCommand(sentencia, conexion.obtenerConexion());
                oCom.Parameters.AddWithValue("@id", id);
                oCom.ExecuteNonQuery();
                conexion.cerrarConexion();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        public bool editarBD(string sentencia, params SqlParameter[] parametros)
        {
            try
            {
                conexion = new csConexionBD();
                conexion.abrirConexion();
                oCom = new SqlCommand(sentencia, conexion.obtenerConexion());
                foreach (var parametro in parametros)
                    oCom.Parameters.Add(parametro);
                oCom.ExecuteNonQuery();
                conexion.cerrarConexion();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        public SqlDataReader EjecutarQuery(string sentencia)
        {
            SqlDataReader reader = null;
            try
            {
                conexion = new csConexionBD();
                conexion.abrirConexion();
                oCom = new SqlCommand(sentencia, conexion.obtenerConexion());
                reader = oCom.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar consulta: " + ex.Message);
            }
            return reader;
        }

        public int login(string usuario, string contraseña)
        {
            try
            {
                conexion = new csConexionBD();
                conexion.abrirConexion();
                oCom = new SqlCommand("EXECUTE SUsuario ''", conexion.obtenerConexion());
                oDTR = oCom.ExecuteReader();
                while (oDTR.Read())
                    if (oDTR["Usuario"].ToString() == usuario && oDTR["Contraseña"].ToString() == contraseña)
                        if (oDTR["Rol"].ToString() == "Admin")
                            return 1;
                        else 
                            return 0;
                conexion.cerrarConexion();
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return 0;
            }
            return 0;
        }
    }
}
