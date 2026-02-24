using InfinityGaming.CapaDatos;
using InfinityGaming.CapaPresentacion;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InfinityGaming
{
    public partial class frmRegistrarEquipo : Form
    {
        bool edit;
        long id;

        csEquipo equipo = new csEquipo();
        csCRUD crud = new csCRUD();

        public frmRegistrarEquipo()
        {
            InitializeComponent();
            cargarCmb();
        }

        public frmRegistrarEquipo(bool edit, long id)
        {
            InitializeComponent();
            cargarCmb();

            this.edit = edit;
            this.id = id;

            if (edit)
                cargarEquipo();
        }

        // =============================
        // CARGAR EQUIPO
        // =============================
        private void cargarEquipo()
        {
            DataTable dt = crud.EjecutarSP_DataTable(
                "SEquipo",
                new SqlParameter("@IdEquipo", id),
                new SqlParameter("@Buscar", "")
            );

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Equipo no encontrado.");
                Close();
                return;
            }

            DataRow row = dt.Rows[0];

            btnRegistrar.Text = "EDITAR";

            txtNombre.Text = row["NombreEquipo"].ToString();
            cmbTipo.Text = row["Tipo"].ToString();
            txtEspecificaciones.Text = row["Especificaciones"].ToString();
            cmbEstado.Text = row["Estado"].ToString();
        }

        // =============================
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

        // =============================
        // GUARDAR
        // =============================
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

                if (!edit)
                {
                    equipo.Insertar();
                    MessageBox.Show("Equipo registrado correctamente.");
                }
                else
                {
                    equipo.IdEquipo = id;
                    equipo.Actualizar();
                    MessageBox.Show("Equipo actualizado correctamente.");
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        // =============================
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmRegistrarEquipo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                csMoverFormulario.Mover(this);
        }
    }
}