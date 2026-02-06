using InfinityGaming.CapaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfinityGaming.CapaPresentacion
{
    public partial class frmNuevaContraseña : Form
    {
        csCRUD crud = new csCRUD();
        DataTable dt = new DataTable();
        int IdUsuario;
        public frmNuevaContraseña()
        {
            InitializeComponent();
        }
        public frmNuevaContraseña(int idUsuario)
        {
            InitializeComponent();
            IdUsuario = idUsuario;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Text == txtRepite.Text)
            {
                dt = crud.EjecutarSP_DataTable("SBuscarUsuario", new SqlParameter("@IdUsuario", IdUsuario));
                if (crud.ejecutarSP("UUsuario",
                    new SqlParameter("@IdUsuario", Convert.ToInt32(dt.Rows[0]["IdUsuario"])),
                    new SqlParameter("@Usuario", dt.Rows[0]["Usuario"].ToString()),
                    new SqlParameter("@Contraseña", txtContraseña.Text),
                    new SqlParameter("@Admin", dt.Rows[0]["Admin"])))
                {
                    MessageBox.Show("Contraseña Actualizada Correctamente.");
                    this.Close();
                }
                else
                    MessageBox.Show("Error al guardar la contraseña.");
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden.");
            }
        }

        private void frmNuevaContraseña_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                csMoverFormulario.Mover(this);
            }
        }

        private void frmNuevaContraseña_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms["frmLogin"]?.Show();
        }
    }
}
