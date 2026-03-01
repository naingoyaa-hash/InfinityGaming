using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using InfinityGaming.CapaDatos;

namespace InfinityGaming.CapaPresentacion
{
    public partial class frmRegistrarReserva : Form
    {
        csReserva reserva = new csReserva();

        long idReserva = 0;
        long idPersona = 0;

        public frmRegistrarReserva()
        {
            InitializeComponent();
            InicializarFormulario();
        }

        public frmRegistrarReserva(long _idReserva)
        {
            InitializeComponent();
            idReserva = _idReserva;
            InicializarFormulario();
            CargarReserva();
        }

        private void InicializarFormulario()
        {
            CargarEquipos();

            dtpInicioReserva.Format = DateTimePickerFormat.Custom;
            dtpInicioReserva.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpInicioReserva.ShowUpDown = true;

            dtpFinReserva.Format = DateTimePickerFormat.Custom;
            dtpFinReserva.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpFinReserva.ShowUpDown = true;

            dtpInicioReserva.Value = DateTime.Now;
            dtpFinReserva.Value = DateTime.Now.AddHours(1);
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

        private void CargarReserva()
        {
            DataTable dt = reserva.Listar(idReserva);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró la reserva");
                Close();
                return;
            }

            DataRow row = dt.Rows[0];

            cmbEquipo.SelectedValue = row["IdEquipo"];
            dtpInicioReserva.Value =
                Convert.ToDateTime(row["InicioReserva"]);
            dtpFinReserva.Value =
                Convert.ToDateTime(row["FinReserva"]);

            idPersona = Convert.ToInt64(row["IdPersona"]);
            txtPersona.Text = row["NombrePersona"].ToString();

            groupBox1.Text = "EDITAR RESERVA";
            btnGuardar.Text = "ACTUALIZAR";
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
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
                reserva.IdReserva = idReserva;
                reserva.IdPersona = idPersona;
                reserva.IdEquipo =
                    Convert.ToInt64(cmbEquipo.SelectedValue);
                reserva.InicioReserva = dtpInicioReserva.Value;
                reserva.FinReserva = dtpFinReserva.Value;
                reserva.Estado = "Reservada";

                (bool ok, string mensaje) resp;

                if (idReserva == 0)
                    resp = reserva.Crear();
                else
                    resp = reserva.Actualizar();

                MessageBox.Show(resp.mensaje);

                if (resp.ok)
                    Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
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

        private void frmRegistrarReserva_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                csMoverFormulario.Mover(this);
        }
    }
}