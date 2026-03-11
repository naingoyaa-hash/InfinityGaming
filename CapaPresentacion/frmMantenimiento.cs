using InfinityGaming.CapaDatos;
using InfinityGaming.CapaPresentacion;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace InfinityGaming
{
    public partial class frmMantenimiento : Form
    {
        csMantenimiento mantenimiento = new csMantenimiento();
        long IdSeleccionado = 0;
        public frmMantenimiento()
        {
            InitializeComponent();
        }

        private void frmMantenimiento_Load(object sender, EventArgs e)
        {
            CargarDatos();
            DiseñarGrid();
            CargarCmb();
            LimpiarCampos();
        }

        private void CargarCmb()
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

            cmbTipo.Items.Clear();

            cmbTipo.Items.Add("Preventivo");
            cmbTipo.Items.Add("Correctivo");
            cmbTipo.Items.Add("Limpieza");
        }

        private void LimpiarCampos()
        {
            cmbEquipo.SelectedIndex = -1;
            cmbTipo.SelectedIndex = -1;

            txtCosto.Clear();
            txtDescripcion.Clear();

            dtpFecha.Value = DateTime.Now;

            IdSeleccionado = 0;
        }

        private void CargarDatos()
        {
            dgvMantenimiento.DataSource = mantenimiento.Listar();

            dgvMantenimiento.Columns["IdEquipo"].Visible = false;
            dgvMantenimiento.Columns["IdMantenimiento"].Visible = false;
        }

        private void DiseñarGrid()
        {
            dgvMantenimiento.BorderStyle = BorderStyle.None;
            dgvMantenimiento.BackgroundColor = Color.FromArgb(20, 20, 20);

            dgvMantenimiento.DefaultCellStyle.BackColor = Color.FromArgb(20, 20, 20);
            dgvMantenimiento.DefaultCellStyle.ForeColor = Color.Plum;

            dgvMantenimiento.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(30, 30, 30);

            dgvMantenimiento.ColumnHeadersDefaultCellStyle.BackColor = Color.Purple;
            dgvMantenimiento.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvMantenimiento.EnableHeadersVisualStyles = false;

            dgvMantenimiento.AllowUserToAddRows = false;

            dgvMantenimiento.RowHeadersVisible = false;

            dgvMantenimiento.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvMantenimiento.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvMantenimiento.MultiSelect = false;

            dgvMantenimiento.ReadOnly = true;

            dgvMantenimiento.AllowUserToResizeRows = false;

            dgvMantenimiento.Columns["Finalizado"].Visible = false;
        }

        private void dgvMantenimiento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dgvMantenimiento.Rows[e.RowIndex];

            IdSeleccionado = Convert.ToInt64(
                fila.Cells["IdMantenimiento"].Value);

            cmbEquipo.SelectedValue =
                Convert.ToInt64(fila.Cells["IdEquipo"].Value);

            cmbTipo.Text =
                fila.Cells["Tipo"].Value.ToString();

            dtpFecha.Value =
                Convert.ToDateTime(fila.Cells["Fecha"].Value);

            txtDescripcion.Text =
                fila.Cells["Descripcion"].Value.ToString();

            txtCosto.Text =
                fila.Cells["Costo"].Value.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (IdSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un registro");
                return;
            }

            if (MessageBox.Show("¿Cancelar mantenimiento?",
                "Confirmar",
                MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            mantenimiento.IdMantenimiento = IdSeleccionado;

            var resp = mantenimiento.Eliminar();

            MessageBox.Show(
                resp.mensaje,
                resp.ok ? "Correcto" : "Aviso",
                MessageBoxButtons.OK,
                resp.ok ? MessageBoxIcon.Information : MessageBoxIcon.Warning
            );

            if (resp.ok)
                CargarDatos();
        }

        private void frmMantenimiento_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                csMoverFormulario.Mover(this);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (IdSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un mantenimiento.");
                return;
            }

            bool finalizado = Convert.ToBoolean(
                dgvMantenimiento.CurrentRow.Cells["Finalizado"].Value);

            if (finalizado)
            {
                MessageBox.Show(
                    "El mantenimiento ya está finalizado.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            DialogResult r = MessageBox.Show(
                "¿Finalizar mantenimiento?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (r != DialogResult.Yes) return;

            mantenimiento.IdMantenimiento = IdSeleccionado;

            var resp = mantenimiento.Finalizar();

            MessageBox.Show(
                resp.mensaje,
                resp.ok ? "Correcto" : "Aviso",
                MessageBoxButtons.OK,
                resp.ok ? MessageBoxIcon.Information : MessageBoxIcon.Warning
            );

            if (resp.ok)
                CargarDatos();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            decimal costo;

            if (!decimal.TryParse(txtCosto.Text, out costo))
            {
                MessageBox.Show("Ingrese un costo válido");
                return;
            }

            mantenimiento.IdEquipo =
                Convert.ToInt64(cmbEquipo.SelectedValue);

            mantenimiento.Tipo = cmbTipo.Text;
            mantenimiento.Fecha = dtpFecha.Value;
            mantenimiento.Descripcion = txtDescripcion.Text;
            mantenimiento.Costo = costo;
            mantenimiento.Finalizado = false;

            var resp = mantenimiento.Registrar();

            MessageBox.Show(
                resp.mensaje,
                resp.ok ? "Correcto" : "Aviso",
                MessageBoxButtons.OK,
                resp.ok ? MessageBoxIcon.Information : MessageBoxIcon.Warning
            );

            if (resp.ok)
            {
                LimpiarCampos();
                CargarDatos();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (IdSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un mantenimiento");
                return;
            }

            decimal costo;

            if (!decimal.TryParse(txtCosto.Text, out costo))
            {
                MessageBox.Show("Ingrese un costo válido");
                return;
            }

            mantenimiento.IdMantenimiento = IdSeleccionado;

            mantenimiento.IdEquipo =
                Convert.ToInt64(cmbEquipo.SelectedValue);

            mantenimiento.Tipo = cmbTipo.Text;
            mantenimiento.Fecha = dtpFecha.Value;
            mantenimiento.Descripcion = txtDescripcion.Text;
            mantenimiento.Costo = costo;

            var resp = mantenimiento.Actualizar();

            MessageBox.Show(
                resp.mensaje,
                resp.ok ? "Correcto" : "Aviso",
                MessageBoxButtons.OK,
                resp.ok ? MessageBoxIcon.Information : MessageBoxIcon.Warning
            );

            if (resp.ok)
            {
                LimpiarCampos();
                CargarDatos();
            }
        }

        private void btnCerra_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
