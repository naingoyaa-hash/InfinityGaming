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
            DiseñoGamingGrid();
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
                ImageLayout = DataGridViewImageCellLayout.Stretch
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
        private void DiseñoGamingGrid()
        {
            dgvJuegos.BorderStyle = BorderStyle.None;
            dgvJuegos.BackgroundColor = Color.FromArgb(18, 18, 18);
            dgvJuegos.GridColor = Color.FromArgb(40, 40, 40);

            dgvJuegos.EnableHeadersVisualStyles = false;

            dgvJuegos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvJuegos.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(32, 32, 32);
            dgvJuegos.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.FromArgb(180, 120, 255);
            dgvJuegos.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 11, FontStyle.Bold);
            dgvJuegos.ColumnHeadersHeight = 40;

            dgvJuegos.DefaultCellStyle.BackColor =
                Color.FromArgb(22, 22, 22);

            dgvJuegos.DefaultCellStyle.ForeColor = Color.Gainsboro;

            dgvJuegos.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(90, 45, 160);

            dgvJuegos.DefaultCellStyle.SelectionForeColor =
                Color.White;

            dgvJuegos.DefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Regular);

            dgvJuegos.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(26, 26, 26);

            dgvJuegos.RowHeadersVisible = false;
            dgvJuegos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvJuegos.RowTemplate.Height = 70;

            dgvJuegos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvJuegos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvJuegos.DefaultCellStyle.Padding =
                new Padding(5, 0, 5, 0);
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

            string col = dgvJuegos.Columns[e.ColumnIndex].Name;

            if (col == "Accion" || col == "Extra")
            {
                e.PaintBackground(e.CellBounds, true);

                string texto = e.FormattedValue?.ToString() ?? "";

                Color fondo;

                if (texto.Contains("Instalar"))
                    fondo = Color.FromArgb(46, 204, 113); 
                else if (texto.Contains("Jugar"))
                    fondo = Color.FromArgb(111, 66, 193); 
                else
                    fondo = Color.FromArgb(200, 60, 60); 

                Rectangle rect = new Rectangle(
                    e.CellBounds.X + 8,
                    e.CellBounds.Y + 10,
                    e.CellBounds.Width - 16,
                    e.CellBounds.Height - 20);

                using (SolidBrush b = new SolidBrush(fondo))
                    e.Graphics.FillRectangle(b, rect);

                TextRenderer.DrawText(
                    e.Graphics,
                    texto,
                    new Font("Segoe UI", 9, FontStyle.Bold),
                    rect,
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

        private void dgvJuegos_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                dgvJuegos.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                    Color.FromArgb(35, 35, 35);
        }

        private void dgvJuegos_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                dgvJuegos.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                    Color.FromArgb(22, 22, 22);
        }
    }
}