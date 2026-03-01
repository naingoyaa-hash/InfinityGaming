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
    public partial class frmRegistrarMantenimiento : Form
    {
        csCRUD crud = new csCRUD();
        csMantenimiento mantenimiento = new csMantenimiento();

        long IdEditar = 0;
        public frmRegistrarMantenimiento()
        {
            InitializeComponent();
        }
        public frmRegistrarMantenimiento(long id)
        {
            InitializeComponent();
            IdEditar = id;
        }

        private void frmRegistrarMantenimiento_Load(object sender, EventArgs e)
        {
            CargarEquipos();
            CargarTipos();

            if (IdEditar != 0)
                CargarRegistro();
        }
        private void CargarRegistro()
        {
            DataTable dt = crud.EjecutarSP_DataTable(
                "SMantenimiento",
                new SqlParameter("@IdMantenimiento", IdEditar)
            );

            if (dt.Rows.Count == 0)
                return;

            DataRow fila = dt.Rows[0];

            comboBox1.SelectedValue = Convert.ToInt64(fila["IdEquipo"]);

            comboBox2.Text = fila["Tipo"].ToString();

            dtpFecha.Value = Convert.ToDateTime(fila["Fecha"]);

            richTextBox1.Text = fila["Descripcion"].ToString();

            txtCosto.Text = fila["Costo"].ToString();
        }

        private void CargarEquipos()
        {
            DataTable dt = crud.EjecutarSP_DataTable("SEquipo",
                new SqlParameter("@IdEquipo", 0),
                new SqlParameter("@Buscar", ""));

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "NombreEquipo";
            comboBox1.ValueMember = "IdEquipo";
        }
        private void CargarTipos()
        {
            comboBox2.Items.Add("Preventivo");
            comboBox2.Items.Add("Correctivo");
            comboBox2.Items.Add("Limpieza");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            decimal costo = 0;

            if (!decimal.TryParse(txtCosto.Text, out costo))
            {
                MessageBox.Show("Ingrese un costo válido");
                return;
            }

            mantenimiento.IdEquipo =
                Convert.ToInt64(comboBox1.SelectedValue);

            mantenimiento.Tipo = comboBox2.Text;
            mantenimiento.Fecha = dtpFecha.Value;
            mantenimiento.Descripcion = richTextBox1.Text;
            mantenimiento.Costo = costo;
            mantenimiento.Finalizado = false;

            (bool ok, string mensaje) resp;

            if (IdEditar == 0)
            {
                resp = mantenimiento.Registrar();
            }
            else
            {
                mantenimiento.IdMantenimiento = IdEditar;
                resp = mantenimiento.Actualizar();
            }

            MessageBox.Show(
                resp.mensaje,
                resp.ok ? "Correcto" : "Aviso",
                MessageBoxButtons.OK,
                resp.ok ? MessageBoxIcon.Information : MessageBoxIcon.Warning
            );

            if (resp.ok)
                Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRegistrarMantenimiento_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                csMoverFormulario.Mover(this);
        }
    }
}
