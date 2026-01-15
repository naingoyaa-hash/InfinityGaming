using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityGaming
{
    internal class Usuario
    {
        private int IdUsuario { get; set; }
        protected string Nombre { get; set; }
        protected string Cedula { get; set; }
        protected string Correo { get; set; }
        protected string Direccion { get; set; }
        protected bool Admin { get; set; }

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
