using InfinityGaming.CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfinityGaming.CapaPresentacion
{
    public partial class frmAñadirStock : Form
    {
        csProducto producto = new csProducto();
        long idProducto;

        public frmAñadirStock(long id)
        {
            InitializeComponent();
            idProducto = id;
        }
        public frmAñadirStock()
        {
            InitializeComponent();
        }

        private void frmAñadirStock_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                csMoverFormulario.Mover(this);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbMotivo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione motivo");
                return;
            }

            int cantidad = (int)nudCantidad.Value;

            if (cantidad <= 0)
            {
                MessageBox.Show("Cantidad inválida");
                return;
            }

            string motivo = cmbMotivo.Text;

            if (motivo == "Venta" ||
                motivo == "Daño" ||
                motivo == "ConsumoInterno" ||
                motivo == "Ajuste-")
            {
                cantidad *= -1;
            }

            producto.IdProducto = idProducto;

            DataTable r = producto.AjustarStock(cantidad, motivo);

            MessageBox.Show(r.Rows[0]["Mensaje"].ToString());

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
