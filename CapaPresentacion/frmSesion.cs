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

            dgvSesion.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(90, 24, 154);
            dgvSesion.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSesion.ColumnHeadersHeight = 40;

            dgvSesion.DefaultCellStyle.BackColor =
                Color.FromArgb(35, 35, 55);
            dgvSesion.DefaultCellStyle.ForeColor = Color.White;

            dgvSesion.RowHeadersVisible = false;
            dgvSesion.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvSesion.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

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
            dgvSesion.DataSource =
                crud.EjecutarSP_DataTable("SSesionJuego");
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

            sesion.CalcularCostoTotal(2m);

            sesion.Iniciar();

            MessageBox.Show("Sesión iniciada correctamente");

            Limpiar();
            CargarSesiones();
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
            sesion.InicioSesion = dtpInicioReserva.Value;
            sesion.FinSesion = dtpFinReserva.Value;
            sesion.CostoTotal = 0;

            sesion.Actualizar();

            MessageBox.Show("Sesión actualizada");

            Limpiar();
            CargarSesiones();
        }

        private void btnFinSesion_Click(object sender, EventArgs e)
        {
            if (IdSesionSeleccionada == 0)
            {
                MessageBox.Show("Seleccione una sesión");
                return;
            }

            sesion.IdSesion = IdSesionSeleccionada;
            sesion.Eliminar();

            MessageBox.Show("Sesión eliminada");

            Limpiar();
            CargarSesiones();
        }

        private void dgvSesion_CellDoubleClick(object sender,
            DataGridViewCellEventArgs e)
        {
            if (dgvSesion.CurrentRow == null) return;

            IdSesionSeleccionada =
                Convert.ToInt64(dgvSesion.CurrentRow.Cells["IdSesion"].Value);

            IdPersonaSeleccionada =
                Convert.ToInt64(dgvSesion.CurrentRow.Cells["IdPersona"].Value);

            txtPersona.Text =
                dgvSesion.CurrentRow.Cells["Nombre"].Value.ToString();

            cmbEquipo.SelectedValue =
                dgvSesion.CurrentRow.Cells["IdEquipo"].Value;

            dtpInicioReserva.Value =
                Convert.ToDateTime(
                    dgvSesion.CurrentRow.Cells["InicioSesion"].Value);

            dtpFinReserva.Value =
                Convert.ToDateTime(
                    dgvSesion.CurrentRow.Cells["FinSesion"].Value);
        }

        private void Limpiar()
        {
            IdSesionSeleccionada = 0;
            IdPersonaSeleccionada = 0;

            txtPersona.Clear();
            cmbEquipo.SelectedIndex = -1;

            dtpInicioReserva.Value = DateTime.Now;
            dtpFinReserva.Value = DateTime.Now;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void RefrescarGrid()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(RefrescarGrid));
                return;
            }

            ActualizarVistaSesiones();
        }
        private void ActualizarVistaSesiones()
        {
            foreach (DataGridViewRow row in dgvSesion.Rows)
            {
                long idEquipo =
                    Convert.ToInt64(row.Cells["IdEquipo"].Value);

                if (csSesionManager.SesionesActivas.ContainsKey(idEquipo))
                {
                    var sesion =
                        csSesionManager.SesionesActivas[idEquipo];

                    TimeSpan tiempo =
                        DateTime.Now - sesion.InicioSesion;

                    row.Cells["Tiempo"].Value =
                        tiempo.ToString(@"hh\:mm\:ss");

                    row.Cells["Costo"].Value =
                        sesion.CostoTotal.ToString("0.00");
                }
            }
        }

        private void frmSesion_Load(object sender, EventArgs e)
        {
            csSesionManager.OnActualizar += RefrescarGrid;
        }

        private void frmSesion_FormClosed(object sender, FormClosedEventArgs e)
        {
            csSesionManager.OnActualizar -= RefrescarGrid;
        }
    }
}