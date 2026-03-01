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

            var resp = reserva.AutoCancelarVencidas();

            if (!resp.ok)
                MessageBox.Show(resp.mensaje);

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
            if (dgvReservas.Columns.Contains("IdPersona"))
                dgvReservas.Columns["IdPersona"].Visible = false;
            if (dgvReservas.Columns.Contains("IdEquipo"))
                dgvReservas.Columns["IdEquipo"].Visible = false;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            frmRegistrarReserva frm = new frmRegistrarReserva();
            frm.ShowDialog();
            InicializarFormulario();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvReservas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una reserva.");
                return;
            }

            string estado =
                dgvReservas.CurrentRow.Cells["Estado"].Value.ToString();

            if (!ReservaEditable(estado))
            {
                MessageBox.Show("Solo se pueden editar reservas activas.");
                return;
            }

            long idReserva =
                Convert.ToInt64(dgvReservas.CurrentRow.Cells["IdReserva"].Value);

            frmRegistrarReserva frm =
                new frmRegistrarReserva(idReserva);

            frm.ShowDialog();
            InicializarFormulario();
        }

        private bool ReservaEditable(string estado)
        {
            return estado == "Reservada";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
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
                MessageBox.Show(
                    "La reserva ya está finalizada. No se puede cancelar.");
                return;
            }

            if (estado == "Cancelada")
            {
                MessageBox.Show("La reserva ya está cancelada.");
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

            var resp = rsv.Cancelar();

            MessageBox.Show(resp.mensaje);

            if (resp.ok)
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

        private void bntIniciar_Click(object sender, EventArgs e)
        {
            if (dgvReservas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una reserva.");
                return;
            }

            string estado = dgvReservas.CurrentRow.Cells["Estado"].Value.ToString();

            if (estado != "Reservada")
            {
                MessageBox.Show("Solo se pueden iniciar reservas activas.");
                return;
            }

            long idReserva = Convert.ToInt64(dgvReservas.CurrentRow.Cells["IdReserva"].Value);
            long idPersona = Convert.ToInt64(dgvReservas.CurrentRow.Cells["IdPersona"].Value);
            long idEquipo = Convert.ToInt64(dgvReservas.CurrentRow.Cells["IdEquipo"].Value);
            DateTime inicioReserva = Convert.ToDateTime(dgvReservas.CurrentRow.Cells["InicioReserva"].Value);
            DateTime finReserva = Convert.ToDateTime(dgvReservas.CurrentRow.Cells["FinReserva"].Value);

            csSesionJuegos sesion = new csSesionJuegos();
            string mensaje;

            bool iniciado = sesion.IniciarDesdeReserva(
                idReserva,
                idPersona,
                idEquipo,
                inicioReserva,
                finReserva,
                2m,      
                out mensaje
            );

            MessageBox.Show(mensaje);

            if (!iniciado) return;

            frmSesion frmSesion = new frmSesion();
            frmSesion.Show();

            this.Close();
        }
    }
}