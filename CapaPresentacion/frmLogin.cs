using InfinityGaming.CapaDatos;
using InfinityGaming.CapaPresentacion;
using System;
using System.Windows.Forms;

namespace InfinityGaming
{
    public partial class frmLogin : Form
    {
        csUsuario usuario = new csUsuario();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("Ingrese usuario y contraseña");
                return;
            }

            bool loginCorrecto = usuario.Login(
                txtUsuario.Text.Trim(),
                txtPass.Text.Trim()
            );

            if (loginCorrecto)
            {
                frmMenu menu = new frmMenu(usuario.VerificarRol());
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas.");
            }

            txtUsuario.Clear();
            txtPass.Clear();
        }

        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                csMoverFormulario.Mover(this);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            frmRecuperarContraseña recuperar = new frmRecuperarContraseña();
            recuperar.Show();
            this.Hide();
        }
    }
}