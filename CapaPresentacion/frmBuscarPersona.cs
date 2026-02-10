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
    public partial class frmBuscarPersona : Form
    {
        public int IdPersonaSeleccionada { get; private set; }
        public string NombrePersonaSeleccionada { get; private set; }
        
        csCRUD crud = new csCRUD();
        public frmBuscarPersona()
        {
            InitializeComponent();
            dgvPersonas.DataSource = crud.EjecutarSP_DataTable("SPersona",
                new SqlParameter("@Buscar", ""));
            EstiloDgv();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dgvPersonas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una persona",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IdPersonaSeleccionada = Convert.ToInt32(
                dgvPersonas.CurrentRow.Cells["IdPersona"].Value);

            NombrePersonaSeleccionada =
                dgvPersonas.CurrentRow.Cells["Nombre"].Value.ToString();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtBuscarPersona_TextChanged(object sender, EventArgs e)
        {
            dgvPersonas.DataSource = crud.EjecutarSP_DataTable("SPersona",
                new SqlParameter("@Buscar", txtBuscarPersona.Text));
        }
        private void EstiloDgv()
        {
            dgvPersonas.BorderStyle = BorderStyle.None;
            dgvPersonas.BackgroundColor = Color.FromArgb(25, 25, 35);
            dgvPersonas.EnableHeadersVisualStyles = false;

            dgvPersonas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvPersonas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(90, 24, 154);
            dgvPersonas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPersonas.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe Print", 10, FontStyle.Bold);
            dgvPersonas.ColumnHeadersHeight = 40;

            dgvPersonas.DefaultCellStyle.BackColor = Color.FromArgb(35, 35, 55);
            dgvPersonas.DefaultCellStyle.ForeColor = Color.White;
            dgvPersonas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(157, 78, 221);
            dgvPersonas.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvPersonas.DefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Regular);

            dgvPersonas.RowHeadersVisible = false;
            dgvPersonas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPersonas.MultiSelect = false;

            dgvPersonas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPersonas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvPersonas.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgvPersonas.AllowUserToResizeRows = false;
            dgvPersonas.AllowUserToAddRows = false;
            dgvPersonas.ReadOnly = true;
        }

        private void frmBuscarPersona_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                csMoverFormulario.Mover(this);
            }
        }
    }
}
