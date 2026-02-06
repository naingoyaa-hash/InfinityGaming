using InfinityGaming.CapaDatos;
using InfinityGaming.CapaPresentacion;
using System;
using System.Data;
using System.Data.SqlClient;
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

    }
}
