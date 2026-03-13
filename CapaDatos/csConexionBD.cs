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
    internal class csConexionBD
    {
        SqlConnection oCon;

        string servidor;
        string basedatos;
        string usuario;
        string clave;

        public csConexionBD(string server, string bd, string user, string pass)
        {
            servidor = server;
            basedatos = bd;
            usuario = user;
            clave = pass;
        }

        public csConexionBD()
        {
            servidor = "NAIN\\SQLEXPRESS";
            basedatos = "GamingRoom";
            usuario = "sa";
            clave = "abcdef";
        }

        public void abrirConexion()
        {
            oCon = new SqlConnection();
            oCon.ConnectionString = "Server = " + servidor + "; Database = " + basedatos + "; User id = " + usuario + "; Password = " + clave;
            try
            {
                oCon.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void cerrarConexion()
        {
            try
            {
                oCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public SqlConnection obtenerConexion()
        {
            return oCon;
        }
    }
}
