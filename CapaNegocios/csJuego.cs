using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using InfinityGaming.CapaNegocios.Interfaces;

namespace InfinityGaming.CapaNegocios
{
    public  class csJuego : IJuego
    {
        private const string STEAM_API_KEY = "4F29C9C4E77948153BE4CC5B064FB2CD";
        private const string STEAM_ID = "76561198366845135";

        private const string STEAM_APPS =
            @"C:\Program Files (x86)\Steam\steamapps";

        public int AppId { get; set; }
        public string Nombre { get; set; }
        public string IconoUrl { get; set; }
        public bool Instalado { get; set; }

        public static async Task<List<csJuego>> ObtenerJuegosSteam()
        {
            string url =
                $"https://api.steampowered.com/IPlayerService/GetOwnedGames/v1/" +
                $"?key={STEAM_API_KEY}&steamid={STEAM_ID}&include_appinfo=true";

            using (HttpClient client = new HttpClient())
            {
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
                        Instalado = EstaInstalado(appId)
                    });
                }

                return lista;
            }
        }

        public static  bool EstaInstalado(int appId)
        {
            string manifest =
                Path.Combine(STEAM_APPS, $"appmanifest_{appId}.acf");

            return File.Exists(manifest);
        }

        public async Task<Image> ObtenerIconoAsync()
        {
            try
            {
                using (var wc = new System.Net.WebClient())
                {
                    byte[] bytes =
                        await wc.DownloadDataTaskAsync(IconoUrl);

                    using (MemoryStream ms = new MemoryStream(bytes))
                        return Image.FromStream(ms);
                }
            }
            catch
            {
                return null;
            }
        }

        public void Jugar()
        {
            Process.Start($"steam://run/{AppId}");
        }

        public void Instalar()
        {
            Process.Start($"steam://install/{AppId}");
        }

        public void Desinstalar()
        {
            Process.Start($"steam://uninstall/{AppId}");
        }

        public static List<csJuego> Filtrar(
            List<csJuego> lista,
            string texto)
        {
            return lista
                .Where(j => j.Nombre
                .ToLower()
                .Contains(texto.ToLower()))
                .ToList();
        }
    }
}