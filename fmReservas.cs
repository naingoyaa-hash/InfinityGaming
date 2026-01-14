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
    public partial class fmReservas : Form
    {
        public fmReservas()
        {
            InitializeComponent();
            DiseñarFormulario();
            CargarDatos();
        }

        void DiseñarFormulario()
        {
            this.Text = "Infinity Gaming - Reservas";
            this.BackColor = Color.Black;
            this.Size = new Size(900, 600);

            btnReservar.Text = "RESERVAR";
            btnReservar.BackColor = Color.LimeGreen;
            btnReservar.ForeColor = Color.Black;
        }

        void CargarDatos()
        {
            cmbEstacion.Items.AddRange(new string[]
            {
                "PC #01", "PC #02", "PC #03", "Consola #01"
            });

            dgvHorarios.Columns.Add("Hora", "Hora");
            dgvHorarios.Columns.Add("Disponible", "Disponible");

            for (int i = 12; i <= 20; i++)
            {
                dgvHorarios.Rows.Add("{}:", "Sí");
            }
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            if (cmbEstacion.Text == "")
            {
                MessageBox.Show("Seleccione una estación");
                return;
            }

            MessageBox.Show("Reserva realizada con éxito 🔥");
        }

        private void btnReservar_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
