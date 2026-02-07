using InfinityGaming.CapaDatos;
using InfinityGaming.CapaPresentacion;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace InfinityGaming
{
    public partial class frmEquipos : Form
    {
        csCRUD crud = new csCRUD();

        public frmEquipos()
        {
            InitializeComponent();
            cargarData();
        }

        private void frmEquipos_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                csMoverFormulario.Mover(this);
            }
        }

        private void cargarData()
        {
            DataTable dt = crud.EjecutarSP_DataTable(
                "SEquipo", 
                new SqlParameter("@IdEquipo", 0),
                new SqlParameter("@Buscar", txtBuscarEquipos.Text.Trim())
            );

            dgvEquipos.DataSource = dt;

            dgvEquipos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvEquipos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvEquipos.ClearSelection();

            EstiloDGV();
        }

        private void txtBuscarEquipos_TextChanged(object sender, EventArgs e)
        {
            cargarData();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            frmRegistrarEquipo registrar = new frmRegistrarEquipo(false, 0);
            registrar.ShowDialog();
            cargarData();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEquipos.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un equipo para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idEquipo = Convert.ToInt32(
                dgvEquipos.CurrentRow.Cells["IdEquipo"].Value
            );

            frmRegistrarEquipo registrar = new frmRegistrarEquipo(true, idEquipo);
            registrar.ShowDialog();
            cargarData();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEquipos.CurrentRow == null)
            {
                MessageBox.Show(
                    "Selecciona un equipo para eliminar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Estás seguro de que deseas eliminar este equipo?\n\nEsta acción no se puede deshacer.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (respuesta != DialogResult.Yes)
                return;

            int idEquipo = Convert.ToInt32(
                dgvEquipos.CurrentRow.Cells["IdEquipo"].Value
            );

            bool eliminado = crud.ejecutarSP(
                "DEquipo",
                new SqlParameter("@IdEquipo", idEquipo)
            );

            if (eliminado)
            {
                MessageBox.Show(
                    "Equipo eliminado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                cargarData();
            }
            else
            {
                MessageBox.Show(
                    "Ocurrió un error al eliminar el equipo.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void EstiloDGV()
        {
            dgvEquipos.EnableHeadersVisualStyles = false;

            dgvEquipos.BackgroundColor = Color.FromArgb(30, 30, 46);
            dgvEquipos.GridColor = Color.FromArgb(106, 13, 173);
            dgvEquipos.BorderStyle = BorderStyle.None;

            dgvEquipos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 3, 59);
            dgvEquipos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEquipos.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);
            dgvEquipos.ColumnHeadersHeight = 35;

            dgvEquipos.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 46);
            dgvEquipos.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            dgvEquipos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(106, 13, 173);
            dgvEquipos.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvEquipos.DefaultCellStyle.Font =
                new Font("Segoe UI", 9, FontStyle.Regular);

            dgvEquipos.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(37, 37, 64);

            dgvEquipos.RowHeadersDefaultCellStyle.SelectionBackColor =
                dgvEquipos.RowHeadersDefaultCellStyle.BackColor;

            dgvEquipos.RowHeadersVisible = false;
            dgvEquipos.MultiSelect = false;
            dgvEquipos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

    }
}
