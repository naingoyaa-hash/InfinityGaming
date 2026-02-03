using InfinityGaming.CapaNegocios;
using InfinityGaming.CapaPresentacion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;


namespace InfinityGaming
{
    public partial class frmJuegos : Form
    {
        csJuego juego = new csJuego();
        private string STEAM_API_KEY = "4F29C9C4E77948153BE4CC5B064FB2CD";
        private string STEAM_ID = "76561198366845135";

        private List<csJuego> juegosSteam = new List<csJuego>();

        public frmJuegos()
        {
            InitializeComponent();

            this.Load += frmJuegos_Load;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            dgvJuegos.CellClick += dgvJuegos_CellClick;
        }

        private async void frmJuegos_Load(object sender, EventArgs e)
        {
            juegosSteam = await ObtenerJuegosSteam();

            dgvJuegos.Columns.Clear();
            dgvJuegos.AutoGenerateColumns = false;

            dgvJuegos.Columns.Add(new DataGridViewImageColumn
            {
                Name = "Icono",
                HeaderText = "Icono",
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
                Name = "Iniciar",
                HeaderText = "Iniciar",
                Text = "▶ Jugar",
                UseColumnTextForButtonValue = true
            });

            dgvJuegos.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Instalar",
                HeaderText = "Instalar",
                Text = "⬇ Instalar",
                UseColumnTextForButtonValue = true
            });

            dgvJuegos.RowTemplate.Height = 64;
            dgvJuegos.AllowUserToAddRows = false;
            dgvJuegos.ReadOnly = true;
            dgvJuegos.AllowUserToAddRows = false;
            dgvJuegos.AllowUserToDeleteRows = false;
            dgvJuegos.AllowUserToResizeRows = false;
            dgvJuegos.AllowUserToResizeColumns = false;

            dgvJuegos.RowHeadersVisible = false;

            dgvJuegos.MultiSelect = false;
            dgvJuegos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvJuegos.ReadOnly = true;
            dgvJuegos.ClearSelection();

            CargarFilas(juegosSteam);
            lblCantidadJuegos.Text = juegosSteam.Count.ToString();
        }

        private async System.Threading.Tasks.Task<List<csJuego>> ObtenerJuegosSteam()
        {
            string url =
                $"https://api.steampowered.com/IPlayerService/GetOwnedGames/v1/" +
                $"?key={STEAM_API_KEY}&steamid={STEAM_ID}&include_appinfo=true";

            using (HttpClient client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                dynamic data = JsonConvert.DeserializeObject(json);

                var lista = new List<csJuego>();

                foreach (var game in data.response.games)
                {
                    lista.Add(new csJuego
                    {
                        AppId = (int)game.appid,
                        Nombre = (string)game.name,
                        IconoUrl =
                        $"https://media.steampowered.com/steamcommunity/public/images/apps/{game.appid}/{game.img_icon_url}.jpg"
                    });
                }

                return lista;
            }
        }

        private async void CargarFilas(List<csJuego> lista)
        {
            dgvJuegos.Rows.Clear();

            foreach (var juego in lista)
            {
                Image icono = null;

                try
                {
                    using (var wc = new System.Net.WebClient())
                    {
                        byte[] bytes = await wc.DownloadDataTaskAsync(juego.IconoUrl);
                        using (var ms = new System.IO.MemoryStream(bytes))
                        {
                            icono = Image.FromStream(ms);
                        }
                    }
                }
                catch { }

                dgvJuegos.Rows.Add(icono, juego.Nombre, "▶ Jugar", "⬇ Instalar");
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


        private void dgvJuegos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nombre = dgvJuegos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
            int appId = juegosSteam.First(j => j.Nombre == nombre).AppId;

            if (dgvJuegos.Columns[e.ColumnIndex].Name == "Iniciar")
                Process.Start($"steam://run/{appId}");

            if (dgvJuegos.Columns[e.ColumnIndex].Name == "Instalar")
                Process.Start($"steam://install/{appId}");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
        }

        private void frmJuegos_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                csMoverFormulario.Mover(this);
            }
        }
    }
}