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
        public fmMenu()
        {
            InitializeComponent();

        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            fmReservas reservas = new fmReservas();
            reservas.Show();
        }

        private void btnEquipos_Click(object sender, EventArgs e)
        {

        }
    }
}
