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
    public partial class frmReserva : Form
    {
        csCRUD crud = new csCRUD();
        DataTable dt;
        public frmReserva()
        {
            InitializeComponent();
            InicializarFormulario();

            dgvReservas.CellFormatting += dgvReservas_CellFormatting;
        }
        public void InicializarFormulario()
        {
            dt = crud.EjecutarSP_DataTable("SReserva");
            if (dt != null)
                dgvReservas.DataSource = dt;
            EstiloDGV();
        }
        private void EstiloDGV()
        {
            dgvReservas.BackgroundColor = Color.FromArgb(20, 20, 35);
            dgvReservas.BorderStyle = BorderStyle.None;
            dgvReservas.GridColor = Color.FromArgb(120, 0, 180);

            dgvReservas.EnableHeadersVisualStyles = false;

            dgvReservas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvReservas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(90, 0, 140);
            dgvReservas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReservas.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);
            dgvReservas.ColumnHeadersHeight = 38;

            dgvReservas.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 50);
            dgvReservas.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            dgvReservas.DefaultCellStyle.Font =
                new Font("Segoe UI", 9, FontStyle.Regular);

            dgvReservas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 0, 255);
            dgvReservas.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvReservas.RowsDefaultCellStyle.SelectionBackColor =
                Color.FromArgb(180, 0, 255);

            dgvReservas.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(25, 25, 45);

            dgvReservas.RowHeadersVisible = false;
            dgvReservas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservas.MultiSelect = false;
            dgvReservas.ReadOnly = true;
            dgvReservas.AllowUserToAddRows = false;
            dgvReservas.AllowUserToResizeRows = false;

            dgvReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            frmRegistrarReserva reserva = new frmRegistrarReserva();
            reserva.ShowDialog();
            InicializarFormulario();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmRegistrarReserva reserva = new frmRegistrarReserva(
                Convert.ToInt32(dgvReservas.CurrentRow.Cells["IdReserva"].Value));
            reserva.ShowDialog();
            InicializarFormulario();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            cancelarFinalizar("cancelar", "Cancelada");
            InicializarFormulario();
        }
        private void cancelarFinalizar(string mensaje, string opcion)
        {
            if (dgvReservas.CurrentRow == null)
            {
                MessageBox.Show(
                    $"Selecciona una reserva para {mensaje}.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                $"¿Estás seguro de que deseas {mensaje} esta Reserva?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (respuesta != DialogResult.Yes)
                return;

            if (crud.ejecutarSP("UReserva",
                new SqlParameter("@IdReserva", Convert.ToInt32(dgvReservas.CurrentRow.Cells["IdReserva"].Value)),
                new SqlParameter("@IdEquipo", Convert.ToInt32(dgvReservas.CurrentRow.Cells["IdEquipo"].Value)),
                new SqlParameter("@InicioReserva", dgvReservas.CurrentRow.Cells["InicioReserva"].Value),
                new SqlParameter("@FinReserva", dgvReservas.CurrentRow.Cells["FinReserva"].Value),
                new SqlParameter("@Estado", opcion)))
                MessageBox.Show($"Reserva {opcion}.");
            else
                MessageBox.Show($"Error al {mensaje} la reserva.");
        }

        private void dgvReservas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvReservas.Columns[e.ColumnIndex].Name == "Estado")
            {
                if (e.Value.ToString() == "Reservada")
                    e.CellStyle.ForeColor = Color.LightGreen;
                else if (e.Value.ToString() == "Cancelada")
                    e.CellStyle.ForeColor = Color.IndianRed;
                else if (e.Value.ToString() == "Finalizada")
                    e.CellStyle.ForeColor = Color.LightSkyBlue;
            }
        }

        private void btnFinalizarReserva_Click(object sender, EventArgs e)
        {
            cancelarFinalizar("finalizar", "Finalizada");
            InicializarFormulario();
        }

        private void frmReserva_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                csMoverFormulario.Mover(this);
            }
        }
    }
}
