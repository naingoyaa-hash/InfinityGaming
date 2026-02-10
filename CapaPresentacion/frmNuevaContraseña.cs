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

            DataTable dtUsuario = crud.EjecutarSP_DataTable(
                "SBuscarUsuario",
                new SqlParameter("@IdUsuario", IdUsuario)
            );

            if (dtUsuario.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Usuario no encontrado.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            DataTable dtResultado = crud.ejecutarSP(
                "UUsuario",
                new SqlParameter("@IdUsuario", Convert.ToInt32(dtUsuario.Rows[0]["IdUsuario"])),
                new SqlParameter("@Usuario", dtUsuario.Rows[0]["Usuario"].ToString()),
                new SqlParameter("@Contraseña", txtContraseña.Text),
                new SqlParameter("@Admin", dtUsuario.Rows[0]["Admin"])
            );

            if (dtResultado.Rows.Count > 0)
            {
                int resultado = Convert.ToInt32(dtResultado.Rows[0]["Resultado"]);
                string mensaje = dtResultado.Rows[0]["Mensaje"].ToString();

                if (resultado == 1)
                {
                    MessageBox.Show(
                        mensaje,
                        "Correcto",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        mensaje,
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
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
