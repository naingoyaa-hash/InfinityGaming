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
    public partial class fmMenu : Form
    {
        bool Admin;
        public fmMenu()
        {
            InitializeComponent();
        }
        public fmMenu(bool admin) 
        {
            InitializeComponent();
            Admin = admin;
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            fmReservas reservas = new fmReservas();
            reservas.Show();
        }

        private void btnEquipos_Click(object sender, EventArgs e)
        {

        }

        private void btnAdministrador_Click(object sender, EventArgs e)
        {
            if (Admin)
            {
                frmAdministrador frm = new frmAdministrador();
                frm.Show();
            }
            else
                MessageBox.Show("Solo el administrador tiene acceso");
        }
    }
}
