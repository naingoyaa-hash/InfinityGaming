using InfinityGaming.CapaPresentacion;
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
        }

        private void dgvMantenimiento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                IdSeleccionado = Convert.ToInt64(
                    dgvMantenimiento.Rows[e.RowIndex]
                    .Cells["IdMantenimiento"].Value);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            frmRegistrarMantenimiento frm =
        new frmRegistrarMantenimiento();

            frm.ShowDialog();
            CargarDatos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (IdSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un mantenimiento");
                return;
            }

            frmRegistrarMantenimiento frm =
                new frmRegistrarMantenimiento(IdSeleccionado);

            frm.ShowDialog();
            CargarDatos();
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
    }
}
