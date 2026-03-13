using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityGaming.CapaNegocios.Interfaces
{
    public interface IJuego
    {
        Task<List<csJuego>> ObtenerJuegosSteam();
        bool EstaInstalado(int appId);
        Task<Image> ObtenerIconoAsync();
        void Jugar();
        void Instalar();
        void Desinstalar();
        List<csJuego> Filtrar(List<csJuego> lista, string texto);
    }
}
