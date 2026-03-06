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
        bool edit = false;
        long idEquipo = 0;

        csEquipo equipo = new csEquipo();
        public frmEquipos()
        {
            InitializeComponent();
            cargarCmb();
            cargarData();
        }

        private void cargarCmb()
        {
            cmbTipo.Items.Clear();
            cmbEstado.Items.Clear();

            cmbTipo.Items.AddRange(new object[]
            {
        "Computadora",
        "Consola"
            });

            cmbEstado.Items.AddRange(new object[]
            {
        "Disponible",
        "Ocupado",
        "Mantenimiento",
        "No Disponible"
            });
        }

        private void limpiarCampos()
        {
            txtNombre.Clear();
            txtEspecificaciones.Clear();

            cmbTipo.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;

            edit = false;
            idEquipo = 0;

            btnRegistrar.Text = "REGISTRAR";
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idEquipo == 0)
            {
                MessageBox.Show("Selecciona un equipo primero.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del equipo es obligatorio.");
                return;
            }

            try
            {
                equipo.IdEquipo = idEquipo;
                equipo.NombreEquipo = txtNombre.Text.Trim();
                equipo.Tipo = cmbTipo.Text;
                equipo.Especificaciones = txtEspecificaciones.Text.Trim();
                equipo.Estado = cmbEstado.Text;

                var resp = equipo.Actualizar();

                MessageBox.Show(
                    resp.mensaje,
                    resp.ok ? "Correcto" : "Aviso",
                    MessageBoxButtons.OK,
                    resp.ok ? MessageBoxIcon.Information : MessageBoxIcon.Warning
                );

                if (resp.ok)
                {
                    limpiarCampos();
                    cargarData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

            try
            {
                long idEquipo = Convert.ToInt64(
                    dgvEquipos.CurrentRow.Cells["IdEquipo"].Value
                );

                csEquipo equipo = new csEquipo();
                equipo.IdEquipo = idEquipo;

                var resp = equipo.Eliminar();

                MessageBox.Show(
                    resp.mensaje,
                    resp.ok ? "Éxito" : "Aviso",
                    MessageBoxButtons.OK,
                    resp.ok ? MessageBoxIcon.Information : MessageBoxIcon.Warning
                );

                if (resp.ok)
                    cargarData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al eliminar:\n" + ex.Message,
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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del equipo es obligatorio.");
                return;
            }

            try
            {
                equipo.NombreEquipo = txtNombre.Text.Trim();
                equipo.Tipo = cmbTipo.Text;
                equipo.Especificaciones = txtEspecificaciones.Text.Trim();
                equipo.Estado = cmbEstado.Text;

                var resp = equipo.Insertar();

                MessageBox.Show(
                    resp.mensaje,
                    resp.ok ? "Correcto" : "Aviso",
                    MessageBoxButtons.OK,
                    resp.ok ? MessageBoxIcon.Information : MessageBoxIcon.Warning
                );

                if (resp.ok)
                {
                    limpiarCampos();
                    cargarData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvEquipos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEquipos.CurrentRow == null)
                return;

            idEquipo = Convert.ToInt64(
                dgvEquipos.CurrentRow.Cells["IdEquipo"].Value
            );

            txtNombre.Text = dgvEquipos.CurrentRow.Cells["NombreEquipo"].Value.ToString();
            cmbTipo.Text = dgvEquipos.CurrentRow.Cells["Tipo"].Value.ToString();
            txtEspecificaciones.Text = dgvEquipos.CurrentRow.Cells["Especificaciones"].Value.ToString();
            cmbEstado.Text = dgvEquipos.CurrentRow.Cells["Estado"].Value.ToString();

            edit = true;
        }
    }
}
