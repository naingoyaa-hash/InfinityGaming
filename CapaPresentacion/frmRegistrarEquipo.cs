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

            if (edit)
                cargarEquipo();
        }

        private void cargarEquipo()
        {
            DataTable dt = crud.EjecutarSP_DataTable(
                "SEquipo",
                new SqlParameter("@IdEquipo", id),
                new SqlParameter("@Buscar", "")
            );

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Equipo no encontrado.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                this.Close();
                return;
            }

            DataRow row = dt.Rows[0];

            btnRegistrar.Text = "EDITAR";
            txtNombre.Text = row["NombreEquipo"].ToString();
            cmbTipo.Text = row["Tipo"].ToString();
            txtEspecificaciones.Text = row["Especificaciones"].ToString();
            cmbEstado.Text = row["Estado"].ToString();
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
                MessageBox.Show(
                    "El nombre del equipo es obligatorio.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DataTable dtResultado;

            if (!edit)
            {
                dtResultado = crud.ejecutarSP(
                    "IEquipo",
                    new SqlParameter("@NombreEquipo", txtNombre.Text.Trim()),
                    new SqlParameter("@Tipo", cmbTipo.Text),
                    new SqlParameter("@Especificaciones", txtEspecificaciones.Text.Trim()),
                    new SqlParameter("@Estado", cmbEstado.Text)
                );
            }
            else
            {
                dtResultado = crud.ejecutarSP(
                    "UEquipo",
                    new SqlParameter("@IdEquipo", id),
                    new SqlParameter("@NombreEquipo", txtNombre.Text.Trim()),
                    new SqlParameter("@Tipo", cmbTipo.Text),
                    new SqlParameter("@Especificaciones", txtEspecificaciones.Text.Trim()),
                    new SqlParameter("@Estado", cmbEstado.Text)
                );
            }

            if (dtResultado.Rows.Count > 0)
            {
                int resultado = Convert.ToInt32(dtResultado.Rows[0]["Resultado"]);
                string mensaje = dtResultado.Rows[0]["Mensaje"].ToString();

                MessageBox.Show(
                    mensaje,
                    resultado == 1 ? "Correcto" : "Aviso",
                    MessageBoxButtons.OK,
                    resultado == 1 ? MessageBoxIcon.Information : MessageBoxIcon.Warning
                );

                if (resultado == 1)
                    this.Close();
            }
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
