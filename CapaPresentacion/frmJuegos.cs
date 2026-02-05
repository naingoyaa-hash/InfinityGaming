using InfinityGaming.CapaNegocios;
using InfinityGaming.CapaPresentacion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfinityGaming
{
    public partial class frmJuegos : Form
    {
        private const string STEAM_API_KEY = "4F29C9C4E77948153BE4CC5B064FB2CD";
        private const string STEAM_ID = "76561198366845135";

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
            juegosSteam = await ObtenerJuegosSteam();
            ConfigurarGrid();
            CargarFilas(juegosSteam);
            lblCantidadJuegos.Text = juegosSteam.Count.ToString();
        }

        private void ConfigurarGrid()
        {
            dgvJuegos.Columns.Clear();
            dgvJuegos.AutoGenerateColumns = false;

            dgvJuegos.Columns.Add(new DataGridViewImageColumn
            {
                Name = "Icono",
                HeaderText = "",
                Width = 60,
                ImageLayout = DataGridViewImageCellLayout.Zoom
            });

            dgvJuegos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nombre",
                HeaderText = "Juego",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvJuegos.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Accion",
                HeaderText = "Acción"
            });

            dgvJuegos.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Extra",
                HeaderText = "Extra"
            });

            dgvJuegos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Estado",
                HeaderText = "Estado",
                Width = 120
            });

            dgvJuegos.RowTemplate.Height = 64;
            dgvJuegos.ReadOnly = true;
            dgvJuegos.AllowUserToAddRows = false;
            dgvJuegos.RowHeadersVisible = false;
            dgvJuegos.MultiSelect = false;
            dgvJuegos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvJuegos.BackgroundColor = Color.FromArgb(18, 10, 30);
            dgvJuegos.BorderStyle = BorderStyle.None;

            dgvJuegos.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgvJuegos.DefaultCellStyle.ForeColor = Color.FromArgb(230, 230, 240);
            dgvJuegos.DefaultCellStyle.BackColor = Color.FromArgb(28, 16, 45);

            dgvJuegos.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(36, 22, 60);

            dgvJuegos.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(130, 70, 255);
            dgvJuegos.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvJuegos.EnableHeadersVisualStyles = false;
            dgvJuegos.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(45, 25, 80);
            dgvJuegos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvJuegos.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvJuegos.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvJuegos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvJuegos.RowTemplate.Height = 64;
            dgvJuegos.GridColor = Color.FromArgb(80, 0, 120);

        }

        private async System.Threading.Tasks.Task<List<csJuego>> ObtenerJuegosSteam()
        {
            string url =
                $"https://api.steampowered.com/IPlayerService/GetOwnedGames/v1/" +
                $"?key={STEAM_API_KEY}&steamid={STEAM_ID}&include_appinfo=true";

            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(url);
            dynamic data = JsonConvert.DeserializeObject(json);

            var lista = new List<csJuego>();

            foreach (var game in data.response.games)
            {
                int appId = (int)game.appid;

                lista.Add(new csJuego
                {
                    AppId = appId,
                    Nombre = (string)game.name,
                    IconoUrl =
                        $"https://media.steampowered.com/steamcommunity/public/images/apps/{appId}/{game.img_icon_url}.jpg",
                    Instalado = JuegoInstalado(appId)
                });
            }

            return lista;
        }

        private bool JuegoInstalado(int appId)
        {
            string steamPath = @"C:\Program Files (x86)\Steam\steamapps";
            string manifest = Path.Combine(steamPath, $"appmanifest_{appId}.acf");
            return File.Exists(manifest);
        }

        private async void CargarFilas(List<csJuego> lista)
        {
            dgvJuegos.Rows.Clear();

            foreach (var juego in lista)
            {
                Image icono = null;

                try
                {
                    var wc = new System.Net.WebClient();
                    byte[] bytes = await wc.DownloadDataTaskAsync(juego.IconoUrl);
                    var ms = new MemoryStream(bytes);
                    icono = Image.FromStream(ms);
                }
                catch { }

                string accion = juego.Instalado ? "▶ Jugar" : "⬇ Instalar";
                string extra = juego.Instalado ? "🗑 Desinstalar" : "";
                string estado = juego.Instalado ? "Instalado" : "No instalado";

                dgvJuegos.Rows.Add(icono, juego.Nombre, accion, extra, estado);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.ToLower();

            var filtrados = juegosSteam
                .Where(j => j.Nombre.ToLower().Contains(filtro))
                .ToList();

            CargarFilas(filtrados);
            lblCantidadJuegos.Text = filtrados.Count.ToString();
        }

        private async void dgvJuegos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nombre = dgvJuegos.Rows[e.RowIndex]
                .Cells["Nombre"].Value.ToString();

            var juego = juegosSteam.First(j => j.Nombre == nombre);
            string columna = dgvJuegos.Columns[e.ColumnIndex].Name;

            if (columna == "Accion")
            {
                if (juego.Instalado)
                {
                    Process.Start($"steam://run/{juego.AppId}");
                }
                else
                {
                    Process.Start($"steam://install/{juego.AppId}");

                    await Task.Delay(3000);
                    juegosSteam = await ObtenerJuegosSteam();
                    CargarFilas(juegosSteam);
                }
            }

            if (columna == "Extra" && juego.Instalado)
            {
                DialogResult r = MessageBox.Show(
                    $"¿Desinstalar {juego.Nombre}?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (r == DialogResult.Yes)
                {
                    Process.Start($"steam://uninstall/{juego.AppId}");

                    await Task.Delay(3000);
                    juegosSteam = await ObtenerJuegosSteam();
                    CargarFilas(juegosSteam);
                }
            }
        }



        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtBuscar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
        }
        private void frmJuegos_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                csMoverFormulario.Mover(this);
            }
        }
        private void dgvJuegos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvJuegos.Columns[e.ColumnIndex].Name == "Accion" ||
                dgvJuegos.Columns[e.ColumnIndex].Name == "Extra")
            {
                e.PaintBackground(e.CellBounds, true);

                bool esAccion = dgvJuegos.Columns[e.ColumnIndex].Name == "Accion";
                string texto = e.FormattedValue?.ToString();

                Color fondo;

                if (!esAccion) 
                {
                    fondo = Color.FromArgb(160, 45, 80);
                }
                else if (texto.Contains("Instalar"))
                {
                    fondo = Color.FromArgb(45, 140, 90);
                }
                else
                {
                    fondo = Color.FromArgb(90, 45, 160);
                }

                using (Brush b = new SolidBrush(fondo))
                    e.Graphics.FillRectangle(b, e.CellBounds);

                TextRenderer.DrawText(
                    e.Graphics,
                    texto,
                    new Font("Segoe UI", 9, FontStyle.Bold),
                    e.CellBounds,
                    Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );

                e.Handled = true;
            }
        }

    }
}
