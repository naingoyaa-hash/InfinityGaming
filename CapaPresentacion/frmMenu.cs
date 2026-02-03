using InfinityGaming.CapaPresentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfinityGaming
{
    public partial class frmMenu : Form
    {
        bool Admin;
        public frmMenu()
        {
            InitializeComponent();
            this.FormClosed += frmMenu_FormClosed;
        }
        public frmMenu(bool admin) 
        {
            InitializeComponent();
            Admin = admin;
            this.FormClosed += frmMenu_FormClosed;
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            frmReserva reserva = new frmReserva();
            reserva.ShowDialog();
        }

        private void btnEquipos_Click(object sender, EventArgs e)
        {
            frmEquipos equipos = new frmEquipos();
            equipos.ShowDialog();
        }

        private void btnAdministrador_Click(object sender, EventArgs e)
        {
            if (Admin)
            {
                frmAdministrador frm = new frmAdministrador();
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Solo el administrador tiene acceso");
        }

        private void btnJuegos_Click(object sender, EventArgs e)
        {
            frmJuegos juego = new frmJuegos();
            juego.ShowDialog();
        }

        private void btnSesionJuego_Click(object sender, EventArgs e)
        {
            
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {

        }

        private void btnMantenimiento_Click(object sender, EventArgs e)
        {
            frmMantenimiento mantenimiento = new frmMantenimiento();
            mantenimiento.ShowDialog();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {

        }

        private void frmMenu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                csMoverFormulario.Mover(this);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void frmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms["frmLogin"]?.Show();
        }
    }
}
