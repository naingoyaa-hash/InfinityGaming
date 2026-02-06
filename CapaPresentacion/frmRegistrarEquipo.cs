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
        int id;
        csCRUD crud = new csCRUD();
        DataTable oDT = null;

        public frmRegistrarEquipo()
        {
            InitializeComponent();
            cargarCmb();
        }

        public frmRegistrarEquipo(bool edit, int id)
        {
            InitializeComponent();
            cargarCmb();
            this.edit = edit;
            this.id = id;

            oDT = crud.EjecutarSP_DataTable(
                "SEquipo",
                new SqlParameter("@IdEquipo", this.id),
                new SqlParameter("@Buscar", "")
            );

            if (edit && oDT != null && oDT.Rows.Count > 0)
            {
                DataRow row = oDT.Rows[0];
                btnRegistrar.Text = "EDITAR";
                txtNombre.Text = row["NombreEquipo"].ToString();
                cmbTipo.Text = row["Tipo"].ToString();
                txtEspecificaciones.Text = row["Especificaciones"].ToString();
                cmbEstado.Text = row["Estado"].ToString();
            }
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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del equipo es obligatorio.");
                return;
            }

            bool resultado;

            if (!edit)
            {
                resultado = crud.ejecutarSP(
                    "IEquipo",
                    new SqlParameter("@NombreEquipo", txtNombre.Text.Trim()),
                    new SqlParameter("@Tipo", cmbTipo.Text),
                    new SqlParameter("@Especificaciones", txtEspecificaciones.Text.Trim()),
                    new SqlParameter("@Estado", cmbEstado.Text)
                );
            }
            else
            {
                resultado = crud.ejecutarSP(
                    "UEquipo",
                    new SqlParameter("@IdEquipo", id),
                    new SqlParameter("@NombreEquipo", txtNombre.Text.Trim()),
                    new SqlParameter("@Tipo", cmbTipo.Text),
                    new SqlParameter("@Especificaciones", txtEspecificaciones.Text.Trim()),
                    new SqlParameter("@Estado", cmbEstado.Text)
                );
            }

            if (resultado)
                MessageBox.Show("Operación realizada correctamente.");
            else
                MessageBox.Show("Ocurrió un error al guardar.");

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRegistrarEquipo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                csMoverFormulario.Mover(this);
            }
        }
    }
}
