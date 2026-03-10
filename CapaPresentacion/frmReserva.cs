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
        long idReserva = 0;
        long idPersona = 0;

        public frmReserva()
        {
            InitializeComponent();

            var resp = reserva.AutoCancelarVencidas();

            if (!resp.ok)
                MessageBox.Show(resp.mensaje);

            InicializarFormulario();
            dgvReservas.CellFormatting += dgvReservas_CellFormatting;
        }

        private void CargarEquipos()
        {
            csCRUD crud = new csCRUD();

            DataTable dt = crud.EjecutarSP_DataTable(
                "SEquipo",
                new System.Data.SqlClient.SqlParameter("@IdEquipo", 0),
                new System.Data.SqlClient.SqlParameter("@Buscar", "")
            );

            cmbEquipo.DataSource = dt;
            cmbEquipo.DisplayMember = "NombreEquipo";
            cmbEquipo.ValueMember = "IdEquipo";
            cmbEquipo.SelectedIndex = -1;
        }

        private void LimpiarCampos()
        {
            cmbEquipo.SelectedIndex = -1;
            txtPersona.Clear();

            dtpInicioReserva.Value = DateTime.Now;
            dtpFinReserva.Value = DateTime.Now.AddHours(1);

            idPersona = 0;
            idReserva = 0;

            groupBox1.Text = "NUEVA RESERVA";
            btnRegistrar.Text = "REGISTRAR";
        }

        public void InicializarFormulario()
        {
            dgvReservas.DataSource = reserva.Listar();

            CargarEquipos();

            dtpInicioReserva.Format = DateTimePickerFormat.Custom;
            dtpInicioReserva.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpInicioReserva.ShowUpDown = true;

            dtpFinReserva.Format = DateTimePickerFormat.Custom;
            dtpFinReserva.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpFinReserva.ShowUpDown = true;

            dtpInicioReserva.Value = DateTime.Now;
            dtpFinReserva.Value = DateTime.Now.AddHours(1);

            LimpiarCampos();

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
            if (idPersona == 0)
            {
                MessageBox.Show("Seleccione un cliente");
                return;
            }

            if (cmbEquipo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un equipo");
                return;
            }

            if (dtpInicioReserva.Value >= dtpFinReserva.Value)
            {
                MessageBox.Show("La fecha inicio debe ser menor a la fecha fin");
                return;
            }

            try
            {
                reserva.IdPersona = idPersona;
                reserva.IdEquipo = Convert.ToInt64(cmbEquipo.SelectedValue);
                reserva.InicioReserva = dtpInicioReserva.Value;
                reserva.FinReserva = dtpFinReserva.Value;
                reserva.Estado = "Reservada";

                var resp = reserva.Crear();

                MessageBox.Show(resp.mensaje);

                if (resp.ok)
                {
                    LimpiarCampos();
                    InicializarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idReserva == 0)
            {
                MessageBox.Show("Seleccione una reserva para editar.");
                return;
            }

            if (idPersona == 0)
            {
                MessageBox.Show("Seleccione un cliente");
                return;
            }

            if (cmbEquipo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un equipo");
                return;
            }

            if (dtpInicioReserva.Value >= dtpFinReserva.Value)
            {
                MessageBox.Show("La fecha inicio debe ser menor a la fecha fin");
                return;
            }

            try
            {
                reserva.IdReserva = idReserva;
                reserva.IdPersona = idPersona;
                reserva.IdEquipo = Convert.ToInt64(cmbEquipo.SelectedValue);
                reserva.InicioReserva = dtpInicioReserva.Value;
                reserva.FinReserva = dtpFinReserva.Value;
                reserva.Estado = "Reservada";

                var resp = reserva.Actualizar();

                MessageBox.Show(resp.mensaje);

                if (resp.ok)
                {
                    LimpiarCampos();
                    InicializarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarPersona frm = new frmBuscarPersona();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                idPersona = frm.IdPersonaSeleccionada;
                txtPersona.Text = frm.NombrePersonaSeleccionada;
            }
        }

        private void dgvReservas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvReservas.CurrentRow == null)
                return;

            idReserva = Convert.ToInt64(dgvReservas.CurrentRow.Cells["IdReserva"].Value);

            cmbEquipo.SelectedValue =
                dgvReservas.CurrentRow.Cells["IdEquipo"].Value;

            idPersona =
                Convert.ToInt64(dgvReservas.CurrentRow.Cells["IdPersona"].Value);

            txtPersona.Text =
                dgvReservas.CurrentRow.Cells["NombrePersona"].Value.ToString();

            dtpInicioReserva.Value =
                Convert.ToDateTime(dgvReservas.CurrentRow.Cells["InicioReserva"].Value);

            dtpFinReserva.Value =
                Convert.ToDateTime(dgvReservas.CurrentRow.Cells["FinReserva"].Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}