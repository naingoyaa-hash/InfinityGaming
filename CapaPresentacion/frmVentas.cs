using InfinityGaming.CapaDatos;
using InfinityGaming.CapaNegocios;
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

namespace InfinityGaming.CapaPresentacion
{
    public partial class frmVentas : Form
    {
        public long IdSesion { get; private set; }
        public long IdPersona { get; private set; }
        public decimal CostoSesion { get; private set; }
        public string NombreCliente { get; private set; }
        csCRUD crud = new csCRUD();
        csProducto producto = new csProducto();
        csPago pago = new csPago();
        csFactura factura = new csFactura();

        decimal subtotal = 0;
        decimal iva = 0;
        decimal total = 0;
        public frmVentas()
        {
            InitializeComponent();
            this.Load += frmVentas_Load;
        }

        public frmVentas(long idSesion, long idPersona,
                 decimal costoSesion, string nombreCliente)
        {
            InitializeComponent();

            IdSesion = idSesion;
            IdPersona = idPersona;
            CostoSesion = costoSesion;
            NombreCliente = nombreCliente;

            this.Load += frmVentas_Load;
        }
        private void CargarProductos()
        {
            dgvProducto.DataSource = producto.Listar("");

            dgvProducto.Columns["IdProducto"].Visible = false;
        }
        private void AgregarSesionAVenta()
        {
            dgvVenta.Rows.Add(
                IdSesion, 
                "Sesion",  
                "Tiempo de Juego",
                1,
                CostoSesion,
                CostoSesion
            );
        }

        private void frmVentas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                csMoverFormulario.Mover(this);
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            CrearColumnasVenta();

            CargarProductos();
            EstiloDGV(dgvProducto);
            EstiloDGV(dgvVenta);

            if (IdSesion > 0)
            {
                AgregarSesionAVenta();
                CalcularTotales();
            }
            if (dgvProducto.Columns.Contains("Activo"))
                dgvProducto.Columns["Activo"].Visible = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dgvProducto.CurrentRow == null)
                return;

            if (txtCantidad.Text == "")
            {
                MessageBox.Show("Ingrese una cantidad.");
                return;
            }

            int cantidad = Convert.ToInt32(txtCantidad.Text);

            long idProducto = Convert.ToInt64(
                dgvProducto.CurrentRow.Cells["IdProducto"].Value
            );

            string nombre = dgvProducto.CurrentRow.Cells["NombreProducto"].Value.ToString();

            decimal precio = Convert.ToDecimal(
                dgvProducto.CurrentRow.Cells["PrecioVenta"].Value
            );

            int stock = Convert.ToInt32(
                dgvProducto.CurrentRow.Cells["Stock"].Value
            );

            if (cantidad > stock)
            {
                MessageBox.Show(
                    "La cantidad supera el stock disponible.\nStock actual: " + stock,
                    "Stock insuficiente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            bool productoExiste = false;

            foreach (DataGridViewRow row in dgvVenta.Rows)
            {
                if (row.IsNewRow)
                    continue;

                if (row.Cells["Tipo"].Value == null || row.Cells["IdItem"].Value == null)
                    continue;

                if (row.Cells["Tipo"].Value.ToString() == "Producto" &&
                    Convert.ToInt64(row.Cells["IdItem"].Value) == idProducto)
                {
                    int cantidadActual = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    int nuevaCantidad = cantidadActual + cantidad;

                    if (nuevaCantidad > stock)
                    {
                        MessageBox.Show(
                            "No hay suficiente stock para agregar más unidades.\nStock disponible: " + stock,
                            "Stock insuficiente",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }

                    row.Cells["Cantidad"].Value = nuevaCantidad;

                    decimal nuevoSubtotal = nuevaCantidad * precio;
                    row.Cells["Subtotal"].Value = nuevoSubtotal;

                    productoExiste = true;
                    break;
                }
            }

            if (!productoExiste)
            {
                decimal sub = precio * cantidad;

                dgvVenta.Rows.Add(
                    idProducto,
                    "Producto",
                    nombre,
                    cantidad,
                    precio,
                    sub
                );
            }

            CalcularTotales();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvVenta.CurrentRow == null)
                return;

            if (dgvVenta.CurrentRow.Cells["Tipo"].Value != null &&
                dgvVenta.CurrentRow.Cells["Tipo"].Value.ToString() == "Sesion")
            {
                MessageBox.Show(
                    "No se puede eliminar el tiempo de juego de la venta.",
                    "Operación no permitida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DialogResult resp = MessageBox.Show(
                "¿Desea eliminar este producto de la venta?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resp == DialogResult.No)
                return;

            dgvVenta.Rows.Remove(dgvVenta.CurrentRow);

            CalcularTotales();
        }

        private void CalcularTotales()
        {
            subtotal = 0;

            foreach (DataGridViewRow row in dgvVenta.Rows)
            {
                if (row.IsNewRow)
                    continue;

                if (row.Cells["Subtotal"].Value == null)
                    continue;

                subtotal += Convert.ToDecimal(row.Cells["Subtotal"].Value);
            }

            iva = subtotal * 0.15m;
            total = subtotal + iva;

            lblSubtotal.Text = subtotal.ToString("0.00");
            lblIva.Text = iva.ToString("0.00");
            lblTotal.Text = total.ToString("0.00");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show(
                "¿Está seguro de cancelar la venta?",
                "Confirmar cancelación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resp == DialogResult.No)
                return;

            if (IdSesion > 0)
            {
                dgvVenta.Rows.Clear();
                AgregarSesionAVenta();
            }
            else
            {
                dgvVenta.Rows.Clear();
            }

            CalcularTotales();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdPersona == 0)
                {
                    MessageBox.Show("Debe seleccionar un cliente antes de pagar.");
                    return;
                }

                if (dgvVenta.Rows.Count == 0 || dgvVenta.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow))
                {
                    MessageBox.Show("Debe agregar al menos un producto o sesión.");
                    return;
                }

                pago.IdSesion = IdSesion > 0 ? IdSesion : (long?)null;
                pago.Monto = total;
                pago.FechaPago = DateTime.Now;
                pago.TipoPago = "Efectivo";
                pago.EstadoPago = "Pagado";

                var respPago = pago.RegistrarPago();

                if (!respPago.ok)
                {
                    MessageBox.Show(respPago.mensaje);
                    return;
                }

                long idPago = pago.IdPago;

                foreach (DataGridViewRow row in dgvVenta.Rows)
                {
                    if (row.IsNewRow || row.Cells["Tipo"].Value == null)
                        continue;

                    string tipo = row.Cells["Tipo"].Value.ToString();
                    long idItem = Convert.ToInt64(row.Cells["IdItem"].Value);
                    int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);

                    if (tipo == "Producto")
                    {
                        crud.EjecutarSP_UnRegistro(
                            "IDetallePagoProducto",
                            new SqlParameter("@IdPago", idPago),
                            new SqlParameter("@IdProducto", idItem),
                            new SqlParameter("@Cantidad", cantidad)
                        );
                    }
                    else if (tipo == "Sesion")
                    {
                        crud.EjecutarSP_UnRegistro(
                            "IDetallePagoSesion",
                            new SqlParameter("@IdPago", idPago),
                            new SqlParameter("@IdSesion", idItem)
                        );
                    }
                }

                crud.EjecutarSP_UnRegistro(
                    "RecalcularPago",
                    new SqlParameter("@IdPago", idPago)
                );

                factura.IdPersona = IdPersona;
                factura.IdPago = idPago;
                factura.NumeroFactura = "FAC-" + DateTime.Now.Ticks;
                factura.FechaEmision = DateTime.Now;
                factura.Total = total;

                factura.Generar();

                MessageBox.Show("Venta registrada correctamente");

                dgvVenta.Rows.Clear();
                CalcularTotales();
                CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EstiloDGV(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;

            dgv.BackgroundColor = Color.FromArgb(30, 30, 46);
            dgv.BorderStyle = BorderStyle.None;
            dgv.GridColor = Color.FromArgb(106, 13, 173);

            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 3, 59);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 35;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgv.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 46);
            dgv.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(106, 13, 173);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(37, 37, 64);

            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgv.RowHeadersVisible = false;
            dgv.ReadOnly = true;

            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows = false;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowTemplate.Height = 28;

            dgv.RowHeadersDefaultCellStyle.SelectionBackColor = dgv.RowHeadersDefaultCellStyle.BackColor;
            
        }
        private void CrearColumnasVenta()
        {
            dgvVenta.Columns.Clear();

            dgvVenta.Columns.Add("IdItem", "IdItem");
            dgvVenta.Columns.Add("Tipo", "Tipo");
            dgvVenta.Columns.Add("Descripcion", "Descripción");
            dgvVenta.Columns.Add("Cantidad", "Cant");
            dgvVenta.Columns.Add("Precio", "Precio");
            dgvVenta.Columns.Add("Subtotal", "Subtotal");

            dgvVenta.Columns["IdItem"].Visible = false;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            frmBuscarPersona frm = new frmBuscarPersona();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                IdPersona = frm.IdPersonaSeleccionada;
                NombreCliente = frm.NombrePersonaSeleccionada;

                txtCliente.Text = NombreCliente;
            }
        }
    }
}
