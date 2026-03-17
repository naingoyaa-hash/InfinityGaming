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
        
        Task<Image> ObtenerIconoAsync();
        void Jugar();
        void Instalar();
        void Desinstalar();
    }
}
