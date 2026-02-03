using InfinityGaming.CapaDatos;
using InfinityGaming.CapaPresentacion;
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
            oDT = crud.cargarBDData("SEquipo",
                new SqlParameter("@IdEquipo", this.id),
                new SqlParameter("@Buscar", ""));
            if ((edit) && (oDT != null && oDT.Rows.Count > 0))
            {
                DataRow row = oDT.Rows[0];

                txtNombre.Text = row["NombreEquipo"].ToString();
                cmbTipo.Text = row["Tipo"].ToString();
                txtEspecificaciones.Text = row["Especificaciones"].ToString();
                cmbEstado.Text = row["Estado"].ToString();
            }
        }
        public void cargarCmb()
        {
            cmbTipo.Items.AddRange(new object[] {
                "Computadora",
                "Consola"});
            cmbEstado.Items.AddRange(new object[] {
                "Disponible",
                "Ocupado",
                "Mantenimiento",
                "No Disponible"});
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!edit)
            {
                if (crud.agregarBD("EXECUTE IEquipo @NombreEquipo, @Tipo, @Especificaciones, @Estado",
                    new SqlParameter("@NombreEquipo", txtNombre.Text),
                    new SqlParameter("@Tipo", cmbTipo.Text),
                    new SqlParameter("@Especificaciones", txtEspecificaciones.Text),
                    new SqlParameter("@Estado", cmbEstado.Text)))
                    MessageBox.Show("Datos ingresados correctamente.");
                else
                    MessageBox.Show("Error al ingresar los datos.");
            }
            else
            {
                if (crud.editarBD("EXECUTE UEquipo @IdEquipo, @NombreEquipo, @Tipo, @Especificaciones, @Estado",
                    new SqlParameter("@IdEquipo", id),
                    new SqlParameter("@NombreEquipo", txtNombre.Text),
                    new SqlParameter("@Tipo", cmbTipo.Text),
                    new SqlParameter("@Especificaciones", txtEspecificaciones.Text),
                    new SqlParameter("@Estado", cmbEstado.Text)))
                    MessageBox.Show("Datos ingresados correctamente.");
                else
                    MessageBox.Show("Error al ingresar los datos.");
            }
            this.Close();
        }
    }
}
