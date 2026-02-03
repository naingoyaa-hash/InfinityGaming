using InfinityGaming.CapaDatos;
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
using System.Data.SqlClient;

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
            dgvEquipos.DataSource = crud.cargarBDData("SEquipo",
                new SqlParameter("@IdEquipo", 0),
                new SqlParameter("@Buscar", txtBuscarEquipos.Text));
            
            dgvEquipos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvEquipos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void txtBuscarEquipos_TextChanged(object sender, EventArgs e)
        {
            cargarData();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            frmRegistrarEquipo registar = new frmRegistrarEquipo(false, 0);
            registar.ShowDialog();
            cargarData();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmRegistrarEquipo registar = new frmRegistrarEquipo(true, 
                Convert.ToInt32(dgvEquipos.CurrentRow.Cells["IdEquipo"].Value));
            registar.ShowDialog();
            cargarData();
        }
    }
}
