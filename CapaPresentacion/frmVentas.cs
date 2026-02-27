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
    public partial class frmVentas : Form
    {
        public long IdSesion { get; private set; }
        public long IdPersona { get; private set; }
        public decimal CostoSesion { get; private set; }
        public string NombreCliente { get; private set; }
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

        private void AgregarSesionAVenta()
        {
            if (dgvVenta.Columns.Count == 0)
            {
                dgvVenta.Columns.Add("Descripcion", "Descripción");
                dgvVenta.Columns.Add("Cantidad", "Cant");
                dgvVenta.Columns.Add("Precio", "Precio");
                dgvVenta.Columns.Add("Subtotal", "Subtotal");
            }

            dgvVenta.Rows.Add(
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
            if (IdSesion > 0)
            {
                AgregarSesionAVenta();
            }
        }
    }
}
