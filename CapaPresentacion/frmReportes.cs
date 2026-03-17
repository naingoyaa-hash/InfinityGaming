using InfinityGaming;
using InfinityGaming.CapaNegocios.Interfaces;
using Microsoft.Reporting.WinForms;
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
    public partial class frmReportes : Form
    {
        csAdministrador admin = new csAdministrador();
        public frmReportes(bool modoFactura = false, long idFactura = 0)
        {
            InitializeComponent();

            if (modoFactura)
            {
                menuReportes.Visible = false;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                if (idFactura != 0)
                {
                    var datos = admin.GenerarReporte("Factura", idFactura);
                    CargarReporte("rptFactura", "dsFactura", datos);
                }
                else 
                {
                    MessageBox.Show("Error  al cargar Factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }

            }
        }
        private void CargarReporte(string nombreReporte, string dataSet, DataTable datos)
        {
            if (datos == null || datos.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para mostrar");
                return;
            }

            pnlReportes.Controls.Clear();

            ReportViewer visor = new ReportViewer();
            visor.Dock = DockStyle.Fill;
            visor.ProcessingMode = ProcessingMode.Local;

            string ruta = System.IO.Path.Combine(
                Application.StartupPath,
                "CapaPresentacion",
                "Reportes",
                nombreReporte + ".rdlc"
            );

            if (!System.IO.File.Exists(ruta))
            {
                MessageBox.Show("No se encontró el reporte:\n" + ruta);
                return;
            }

            visor.LocalReport.ReportPath = ruta;
            visor.LocalReport.DataSources.Clear();
            visor.LocalReport.DataSources.Add(
                new ReportDataSource(dataSet, datos)
            );

            visor.RefreshReport();

            pnlReportes.Controls.Add(visor);
        }

        private void iNGRESOSDIARIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var datos = admin.GenerarReporte("Ingresos");

            CargarReporte("rptIngresosDiarios", "dsIngresosDiarios", datos);
        }

        private void pRODUCTOSMASVENDIDOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var datos = admin.GenerarReporte("Productos");

            CargarReporte("rptProductosMasVendidos", "dsProductosMasVendidos", datos);
        }

        private void dETALLESVENTASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var datos = admin.GenerarReporte("Ventas");

            CargarReporte("rptVentasDetallado", "dsDetalleVentas", datos);
        }
    }
}
