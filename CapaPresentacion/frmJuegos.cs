using InfinityGaming.CapaNegocios;
using InfinityGaming.CapaPresentacion;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfinityGaming
{
    public partial class frmJuegos : Form
    {
        private List<csJuego> juegosSteam = new List<csJuego>();

        public frmJuegos()
        {
            InitializeComponent();

            Load += frmJuegos_Load;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            dgvJuegos.CellContentClick += dgvJuegos_CellContentClick;
            dgvJuegos.CellPainting += dgvJuegos_CellPainting;
        }

        private async void frmJuegos_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();

            juegosSteam = await csJuego.ObtenerJuegosSteam();

            await CargarFilas(juegosSteam);

            lblCantidadJuegos.Text = juegosSteam.Count.ToString();
        }

        private void ConfigurarGrid()
        {
            dgvJuegos.Columns.Clear();
            dgvJuegos.AutoGenerateColumns = false;

            dgvJuegos.Columns.Add(new DataGridViewImageColumn()
            {
                Name = "Icono",
                Width = 60,
                ImageLayout = DataGridViewImageCellLayout.Zoom
            });

            dgvJuegos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Nombre",
                HeaderText = "Juego",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvJuegos.Columns.Add(new DataGridViewButtonColumn()
            {
                Name = "Accion",
                HeaderText = "Acción"
            });

            dgvJuegos.Columns.Add(new DataGridViewButtonColumn()
            {
                Name = "Extra",
                HeaderText = "Extra"
            });

            dgvJuegos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Estado",
                Width = 120
            });

            dgvJuegos.RowTemplate.Height = 64;
            dgvJuegos.ReadOnly = true;
            dgvJuegos.AllowUserToAddRows = false;
            dgvJuegos.RowHeadersVisible = false;
            dgvJuegos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private async Task CargarFilas(List<csJuego> lista)
        {
            dgvJuegos.Rows.Clear();

            foreach (var juego in lista)
            {
                Image icono = await juego.ObtenerIconoAsync();

                string accion = juego.Instalado ? "▶ Jugar" : "⬇ Instalar";
                string extra = juego.Instalado ? "🗑 Desinstalar" : "";
                string estado = juego.Instalado ? "Instalado" : "No instalado";

                dgvJuegos.Rows.Add(icono, juego.Nombre, accion, extra, estado);
            }
        }

        private async void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            var filtrados = csJuego.Filtrar(juegosSteam, txtBuscar.Text);

            await CargarFilas(filtrados);

            lblCantidadJuegos.Text = filtrados.Count.ToString();
        }

        private async void dgvJuegos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nombre =
                dgvJuegos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();

            var juego = juegosSteam.First(j => j.Nombre == nombre);

            string columna = dgvJuegos.Columns[e.ColumnIndex].Name;

            if (columna == "Accion")
            {
                if (juego.Instalado)
                    juego.Jugar();
                else
                    juego.Instalar();
            }

            if (columna == "Extra" && juego.Instalado)
            {
                if (MessageBox.Show(
                    $"¿Desinstalar {juego.Nombre}?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    juego.Desinstalar();
                }
            }

            await Task.Delay(3000);
            juegosSteam = await csJuego.ObtenerJuegosSteam();
            await CargarFilas(juegosSteam);
        }

        private void dgvJuegos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvJuegos.Columns[e.ColumnIndex].Name == "Accion" ||
                dgvJuegos.Columns[e.ColumnIndex].Name == "Extra")
            {
                e.PaintBackground(e.CellBounds, true);

                string texto = e.FormattedValue?.ToString();

                Color fondo =
                    texto.Contains("Instalar")
                    ? Color.FromArgb(45, 140, 90)
                    : Color.FromArgb(90, 45, 160);

                using (Brush b = new SolidBrush(fondo))
                    e.Graphics.FillRectangle(b, e.CellBounds);

                TextRenderer.DrawText(
                    e.Graphics,
                    texto,
                    new Font("Segoe UI", 9, FontStyle.Bold),
                    e.CellBounds,
                    Color.White,
                    TextFormatFlags.HorizontalCenter |
                    TextFormatFlags.VerticalCenter);

                e.Handled = true;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmJuegos_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                csMoverFormulario.Mover(this);
        }

        private void txtBuscar_TextChanged_1(object sender, EventArgs e)
        {
            txtBuscar.Clear();
        }
    }
}