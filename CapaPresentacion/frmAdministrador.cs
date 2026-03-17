using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InfinityGaming.CapaPresentacion;

namespace InfinityGaming
{
    public partial class frmAdministrador : Form
    {
        csAdministrador admin = new csAdministrador();
        public frmAdministrador()
        {
            InitializeComponent();
            this.btnUsuario.Click += new System.EventHandler(this.btnUsuario_Click);
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            this.Load += new System.EventHandler(this.frmAdministrador_Load);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AbrirFormulario(Form frmHijo)
        {
            pnlAdministrador.Controls.Clear();

            frmHijo.TopLevel = false;
            frmHijo.FormBorderStyle = FormBorderStyle.None;
            frmHijo.Dock = DockStyle.Fill;

            pnlAdministrador.Controls.Add(frmHijo);
            pnlAdministrador.Tag = frmHijo;

            frmHijo.Show();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmUsuario());
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmReportes());
        }
        private void CargarDatos()
        {
            lbDisponibles.Text = admin.ObtenerEquiposDisponibles().ToString();
            lbVentas.Text = admin.ObtenerVentasDelDia().ToString("0.00");
        }

        private void frmAdministrador_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
