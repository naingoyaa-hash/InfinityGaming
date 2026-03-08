using InfinityGaming.CapaDatos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace InfinityGaming.CapaPresentacion
{
    public partial class frmSesion : Form
    {
        csCRUD crud = new csCRUD();
        csSesionJuegos sesion = new csSesionJuegos();

        long IdPersonaSeleccionada = 0;
        long IdSesionSeleccionada = 0;

        public frmSesion()
        {
            InitializeComponent();

            ConfigurarDateTimePickers();
            EstiloDgvSesion();

            CargarEquipos();
            CargarSesiones();
        }

        private void ConfigurarDateTimePickers()
        {
            dtpInicioReserva.Format = DateTimePickerFormat.Custom;
            dtpInicioReserva.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpInicioReserva.ShowUpDown = true;

            dtpFinReserva.Format = DateTimePickerFormat.Custom;
            dtpFinReserva.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpFinReserva.ShowUpDown = true;
        }

        private void EstiloDgvSesion()
        {
            dgvSesion.BorderStyle = BorderStyle.None;
            dgvSesion.BackgroundColor = Color.FromArgb(25, 25, 35);
            dgvSesion.EnableHeadersVisualStyles = false;

            dgvSesion.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(90, 24, 154);
            dgvSesion.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSesion.ColumnHeadersHeight = 40;

            dgvSesion.DefaultCellStyle.BackColor = Color.FromArgb(35, 35, 55);
            dgvSesion.DefaultCellStyle.ForeColor = Color.White;

            dgvSesion.RowHeadersVisible = false;
            dgvSesion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvSesion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvSesion.ReadOnly = true;
            dgvSesion.AllowUserToAddRows = false;

            dgvSesion.CellDoubleClick += dgvSesion_CellDoubleClick;
        }

        private void CargarEquipos()
        {
            DataTable dt = crud.EjecutarSP_DataTable(
                "SEquipo",
                new SqlParameter("@IdEquipo", 0),
                new SqlParameter("@Buscar", "")
            );

            cmbEquipo.DataSource = dt;
            cmbEquipo.DisplayMember = "NombreEquipo";
            cmbEquipo.ValueMember = "IdEquipo";
            cmbEquipo.SelectedIndex = -1;
        }

        private void CargarSesiones()
        {
            dgvSesion.DataSource = crud.EjecutarSP_DataTable("SSesionJuego");
            dgvSesion.Columns["IdSesion"].Visible = false;
            dgvSesion.Columns["IdReserva"].Visible = false;
            dgvSesion.Columns["IdPersona"].Visible = false;
            dgvSesion.Columns["IdEquipo"].Visible = false;
            dgvSesion.Columns["DuracionSegundos"].Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarPersona frm = new frmBuscarPersona();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                IdPersonaSeleccionada = frm.IdPersonaSeleccionada;
                txtPersona.Text = frm.NombrePersonaSeleccionada;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (IdPersonaSeleccionada == 0)
            {
                MessageBox.Show("Seleccione una persona");
                return;
            }

            if (cmbEquipo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un equipo");
                return;
            }

            sesion.IdPersona = IdPersonaSeleccionada;
            sesion.IdEquipo = Convert.ToInt64(cmbEquipo.SelectedValue);
            sesion.IdReserva = null;
            sesion.InicioSesion = dtpInicioReserva.Value;
            sesion.FinSesion = dtpFinReserva.Value;

            var resp = sesion.Iniciar();

            MessageBox.Show(
                resp.mensaje,
                resp.ok ? "Correcto" : "Aviso",
                MessageBoxButtons.OK,
                resp.ok ? MessageBoxIcon.Information : MessageBoxIcon.Warning
            );

            if (resp.ok)
            {
                Limpiar();
                CargarSesiones();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (IdSesionSeleccionada == 0)
            {
                MessageBox.Show("Seleccione una sesión");
                return;
            }

            sesion.IdSesion = IdSesionSeleccionada;
            sesion.IdPersona = IdPersonaSeleccionada;
            sesion.IdEquipo = Convert.ToInt64(cmbEquipo.SelectedValue);
            sesion.InicioSesion = dtpInicioReserva.Value;
            sesion.FinSesion = dtpFinReserva.Value;

            var resp = sesion.Actualizar();

            MessageBox.Show(
                resp.mensaje,
                resp.ok ? "Correcto" : "Aviso",
                MessageBoxButtons.OK,
                resp.ok ? MessageBoxIcon.Information : MessageBoxIcon.Warning
            );

            if (resp.ok)
            {
                Limpiar();
                CargarSesiones();
            }
        }


        private void dgvSesion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSesion.CurrentRow == null) return;

            IdSesionSeleccionada = Convert.ToInt64(dgvSesion.CurrentRow.Cells["IdSesion"].Value);
            IdPersonaSeleccionada = Convert.ToInt64(dgvSesion.CurrentRow.Cells["IdPersona"].Value);

            txtPersona.Text = dgvSesion.CurrentRow.Cells["Nombre"].Value.ToString();
            cmbEquipo.SelectedValue = dgvSesion.CurrentRow.Cells["IdEquipo"].Value;

            dtpInicioReserva.Value = Convert.ToDateTime(dgvSesion.CurrentRow.Cells["InicioSesion"].Value);
            dtpFinReserva.Value = Convert.ToDateTime(dgvSesion.CurrentRow.Cells["FinSesion"].Value);

            dtpInicioReserva.Enabled = false;
        }

        private void Limpiar()
        {
            IdSesionSeleccionada = 0;
            IdPersonaSeleccionada = 0;

            txtPersona.Clear();
            cmbEquipo.SelectedIndex = -1;

            dtpInicioReserva.Enabled = true;
            dtpInicioReserva.Value = DateTime.Now;
            dtpFinReserva.Value = DateTime.Now.AddHours(1);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmSesion_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                csMoverFormulario.Mover(this);
        }

        private void btnFinSesion_Click_1(object sender, EventArgs e)
        {
            if (IdSesionSeleccionada == 0)
            {
                MessageBox.Show("Seleccione una sesión");
                return;
            }

            sesion.IdSesion = IdSesionSeleccionada;

            DateTime inicio =
                Convert.ToDateTime(dgvSesion.CurrentRow.Cells["InicioSesion"].Value);

            string nombreCliente =
                dgvSesion.CurrentRow.Cells["Nombre"].Value.ToString();

            sesion.IdPersona = IdPersonaSeleccionada;
            sesion.InicioSesion = inicio;
            sesion.FinSesion = DateTime.Now;

            var resp = sesion.Actualizar();

            MessageBox.Show(
                resp.mensaje +
                $"\nCosto total: ${sesion.CostoTotal}",
                resp.ok ? "Correcto" : "Aviso",
                MessageBoxButtons.OK,
                resp.ok ? MessageBoxIcon.Information : MessageBoxIcon.Warning
            );

            if (!resp.ok) return;

            frmVentas venta = new frmVentas(
                IdSesionSeleccionada,
                IdPersonaSeleccionada,
                sesion.CostoTotal,
                nombreCliente
            );

            venta.Show();

            Limpiar();
            CargarSesiones();
        }
    }
}