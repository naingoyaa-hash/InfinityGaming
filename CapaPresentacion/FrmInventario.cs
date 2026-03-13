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
    public partial class frmInventario : Form
    {
        csProducto producto = new csProducto();
        long idSeleccionado = 0;
        public frmInventario()
        {
            InitializeComponent();
            DiseñarGrid();
            Load += frmInventario_Load;
            dgvProductos.CellClick += dgvProductos_CellClick;
        }

        private void frmInventario_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }
        private void CargarProductos()
        {
            dgvProductos.DataSource = producto.Listar("");
            dgvProductos.ClearSelection();

            dgvProductos.Columns["IdProducto"].Visible = false;
            dgvProductos.Columns["Activo"].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtProducto.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese nombre del producto");
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("Precio inválido");
                return;
            }

            producto.NombreProducto = txtProducto.Text;
            producto.Descripcion = txtDescripcion.Text;
            producto.PrecioVenta = precio;
            producto.Stock = 0;
            producto.Activo = true;

            var resp = producto.Insertar(); 

            MessageBox.Show(resp.mensaje);

            if (resp.ok)
            {
                Limpiar();
                CargarProductos();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0) return;

            producto.IdProducto = idSeleccionado;
            producto.NombreProducto = txtProducto.Text;
            producto.Descripcion = txtDescripcion.Text;
            producto.PrecioVenta = decimal.Parse(txtPrecio.Text);
            producto.Activo = true;

            var resp = producto.Actualizar(); 

            MessageBox.Show(resp.mensaje);

            if (resp.ok)
            {
                Limpiar();
                CargarProductos();
            }
        }

        private void btnEleminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0) return;

            DialogResult resultado = MessageBox.Show(
                "¿Desea eliminar este producto?",
                "Advertencia",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation);

            if (resultado == DialogResult.Yes)
            {
                producto.IdProducto = idSeleccionado;

                var resp = producto.Eliminar();

                MessageBox.Show(resp.mensaje);

                if (resp.ok)
                {
                    Limpiar();
                    CargarProductos();
                }
            }
        }

        private void Limpiar()
        {
            idSeleccionado = 0;
            txtProducto.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
        }

        private void btnAñadirStock_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un producto");
                return;
            }

            frmAñadirStock f = new frmAñadirStock(idSeleccionado);
            f.ShowDialog();

            CargarProductos();
        }
        private void DiseñarGrid()
        {
            dgvProductos.BorderStyle = BorderStyle.None;
            dgvProductos.BackgroundColor = Color.FromArgb(20, 20, 20);
            dgvProductos.GridColor = Color.FromArgb(45, 45, 45);

            dgvProductos.DefaultCellStyle.BackColor = Color.FromArgb(20, 20, 20);
            dgvProductos.DefaultCellStyle.ForeColor = Color.Plum;
            dgvProductos.DefaultCellStyle.SelectionBackColor = Color.Purple;
            dgvProductos.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvProductos.DefaultCellStyle.Font =
                new Font("Segoe UI", 10F, FontStyle.Regular);

            dgvProductos.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(30, 30, 30);

            dgvProductos.EnableHeadersVisualStyles = false;
            dgvProductos.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgvProductos.ColumnHeadersDefaultCellStyle.BackColor =
                Color.Purple;

            dgvProductos.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvProductos.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 11F, FontStyle.Bold);

            dgvProductos.ColumnHeadersHeight = 40;

            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AllowUserToResizeRows = false;

            dgvProductos.RowHeadersVisible = false;

            dgvProductos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvProductos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvProductos.MultiSelect = false;

            dgvProductos.ReadOnly = true;

            dgvProductos.Cursor = Cursors.Hand;


        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];

            idSeleccionado = Convert.ToInt64(fila.Cells["IdProducto"].Value);

            txtProducto.Text = fila.Cells["NombreProducto"].Value.ToString();
            txtDescripcion.Text = fila.Cells["Descripcion"].Value.ToString();
            txtPrecio.Text = fila.Cells["PrecioVenta"].Value.ToString();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
