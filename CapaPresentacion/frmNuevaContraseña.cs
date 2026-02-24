using InfinityGaming.CapaDatos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InfinityGaming.CapaPresentacion
{
    public partial class frmNuevaContraseña : Form
    {
        csCRUD crud = new csCRUD();
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
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Text.Trim() == "" ||
                txtRepite.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la contraseña.");
                return;
            }

            if (txtContraseña.Text != txtRepite.Text)
            {
                MessageBox.Show(
                    "Las contraseñas no coinciden.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                DataRow usuario = crud.EjecutarSP_UnRegistro(
                    "SBuscarUsuario",
                    new SqlParameter("@IdUsuario", IdUsuario)
                );

                if (usuario == null)
                {
                    MessageBox.Show("Usuario no encontrado.");
                    return;
                }

                crud.EjecutarSP_NonQuery(
                    "UUsuario",
                    new SqlParameter("@IdUsuario", usuario["IdUsuario"]),
                    new SqlParameter("@Usuario", usuario["Usuario"].ToString()),
                    new SqlParameter("@Contraseña", txtContraseña.Text),
                    new SqlParameter("@Admin", usuario["Admin"])
                );

                MessageBox.Show(
                    "Contraseña actualizada correctamente.",
                    "Correcto",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void frmNuevaContraseña_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                csMoverFormulario.Mover(this);
        }

        private void frmNuevaContraseña_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms["frmLogin"]?.Show();
        }
    }
}