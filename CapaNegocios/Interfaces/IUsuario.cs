using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityGaming.CapaNegocios.Interfaces
{
    public interface IUsuario
    {
        (bool ok, string mensaje) Login(string usuario, string contrasena);
        void CerrarSesion();
        (bool ok, string mensaje) Insertar();
        (bool ok, string mensaje) EditarPerfil(string nombre, string correo, string direccion);
        (bool ok, string mensaje) ActualizarUsuario();
        bool VerificarRol();
    }
}
