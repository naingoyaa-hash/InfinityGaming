using InfinityGaming.CapaDatos;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace InfinityGaming.CapaPresentacion
{
    public partial class frmReserva : Form
    {
        csReserva reserva = new csReserva();

        public frmReserva()
        {
            InitializeComponent();
            InicializarFormulario();
            dgvReservas.CellFormatting += dgvReservas_CellFormatting;
        }

        public void InicializarFormulario()
        {
            dgvReservas.DataSource = reserva.Listar();
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

            dgvReservas.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(180, 0, 255);

            dgvReservas.RowHeadersVisible = false;
            dgvReservas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservas.MultiSelect = false;
            dgvReservas.ReadOnly = true;
            dgvReservas.AllowUserToAddRows = false;

            dgvReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvReservas.Columns.Contains("IdReserva"))
                dgvReservas.Columns["IdReserva"].Visible = false;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            frmRegistrarReserva frm = new frmRegistrarReserva();
            frm.ShowDialog();
            InicializarFormulario();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvReservas.CurrentRow == null) return;

            long idReserva =
                Convert.ToInt64(dgvReservas.CurrentRow.Cells["IdReserva"].Value);

            frmRegistrarReserva frm =
                new frmRegistrarReserva(idReserva);

            frm.ShowDialog();
            InicializarFormulario();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvReservas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una reserva.");
                return;
            }

            DialogResult r = MessageBox.Show(
                "¿Cancelar esta reserva?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (r != DialogResult.Yes) return;

            csReserva rsv = new csReserva();
            rsv.IdReserva =
                Convert.ToInt64(dgvReservas.CurrentRow.Cells["IdReserva"].Value);

            rsv.Cancelar();

            MessageBox.Show("Reserva cancelada correctamente.");
            InicializarFormulario();
        }

        private void dgvReservas_CellFormatting(object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (dgvReservas.Columns[e.ColumnIndex].Name == "Estado")
            {
                string estado = e.Value?.ToString();

                if (estado == "Reservada")
                    e.CellStyle.ForeColor = Color.LightGreen;
                else if (estado == "Cancelada")
                    e.CellStyle.ForeColor = Color.IndianRed;
                else if (estado == "Finalizada")
                    e.CellStyle.ForeColor = Color.LightSkyBlue;
            }
        }

        private void frmReserva_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                csMoverFormulario.Mover(this);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFinalizarReserva_Click(object sender, EventArgs e)
        {
            if (dgvReservas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una reserva.");
                return;
            }

            string estado =
                dgvReservas.CurrentRow.Cells["Estado"].Value.ToString();

            if (estado == "Finalizada")
            {
                MessageBox.Show("La reserva ya está finalizada.");
                return;
            }

            if (estado == "Cancelada")
            {
                MessageBox.Show("No se puede finalizar una reserva cancelada.");
                return;
            }

            DialogResult r = MessageBox.Show(
                "¿Finalizar esta reserva?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (r != DialogResult.Yes) return;

            csReserva rsv = new csReserva();

            rsv.IdReserva =
                Convert.ToInt64(dgvReservas.CurrentRow.Cells["IdReserva"].Value);

            rsv.IdPersona =
                Convert.ToInt64(dgvReservas.CurrentRow.Cells["IdPersona"].Value);

            rsv.IdEquipo =
                Convert.ToInt64(dgvReservas.CurrentRow.Cells["IdEquipo"].Value);

            rsv.InicioReserva =
                Convert.ToDateTime(dgvReservas.CurrentRow.Cells["InicioReserva"].Value);

            rsv.FinReserva =
                Convert.ToDateTime(dgvReservas.CurrentRow.Cells["FinReserva"].Value);

            rsv.Finalizar();

            MessageBox.Show("Reserva finalizada correctamente.");

            InicializarFormulario();
        }
    }
}