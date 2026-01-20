using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityGaming
{
    internal class Usuario
    {
        private int idUsuario { get; set; }
        protected string nombre { get; set; }
        protected string cedula { get; set; }
        protected string correo { get; set; }
        protected string direccion { get; set; }
        protected string user { get; set; }
        protected string password { get; set; }
        protected bool admin { get; set; }

        public void Login(string usuario, string contrasena)
        {

        }
        public void CerrarSesion()
        {

        }
        public void CambiarContrasena(string conActual, string conNuevo)
        {

        }
        public void EditarPerfil(string nombre, string correo, string direccion)
        {

        }
        public bool VerificarRol() { return false; }
    }
}
