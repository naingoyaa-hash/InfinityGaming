using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using InfinityGaming.CapaDatos;

namespace InfinityGaming.CapaPresentacion
{
    public partial class frmRegistrarReserva : Form
    {
        csCRUD crud = new csCRUD();
        int idReserva = 0; 

        public frmRegistrarReserva()
        {
            InitializeComponent();
            InicializarFormulario();
        }

        public frmRegistrarReserva(int _idReserva)
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

            dtpInicioReserva.MinDate = DateTime.Now;
            dtpFinReserva.MinDate = DateTime.Now;

            dtpInicioReserva.Value = DateTime.Now;
            dtpFinReserva.Value = DateTime.Now.AddHours(1);
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

        private void CargarReserva()
        {
            DataTable dt = crud.EjecutarSP_DataTable(
                "SReserva",
                new SqlParameter("@IdReserva", idReserva)
            );

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró la reserva", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            cmbEquipo.SelectedValue = dt.Rows[0]["IdEquipo"];
            dtpInicioReserva.Value = Convert.ToDateTime(dt.Rows[0]["InicioReserva"]);
            dtpFinReserva.Value = Convert.ToDateTime(dt.Rows[0]["FinReserva"]);

            groupBox1.Text = "EDITAR RESERVA";
            btnGuardar.Text = "ACTUALIZAR";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (cmbEquipo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un equipo", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpInicioReserva.Value >= dtpFinReserva.Value)
            {
                MessageBox.Show("La fecha inicio debe ser menor a la fecha fin", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (idReserva == 0)
                {
                    crud.ejecutarSP(
                        "IReserva",
                        new SqlParameter("@IdEquipo", cmbEquipo.SelectedValue),
                        new SqlParameter("@InicioReserva", dtpInicioReserva.Value),
                        new SqlParameter("@FinReserva", dtpFinReserva.Value),
                        new SqlParameter("@Estado", "Reservada")
                    );

                    MessageBox.Show("Reserva registrada correctamente",
                        "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    crud.ejecutarSP(
                        "UReserva",
                        new SqlParameter("@IdReserva", idReserva),
                        new SqlParameter("@IdEquipo", cmbEquipo.SelectedValue),
                        new SqlParameter("@InicioReserva", dtpInicioReserva.Value),
                        new SqlParameter("@FinReserva", dtpFinReserva.Value),
                        new SqlParameter("@Estado", "Reservada")
                    );

                    MessageBox.Show("Reserva actualizada correctamente",
                        "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRegistrarReserva_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                csMoverFormulario.Mover(this);
            }
        }
    }
}
