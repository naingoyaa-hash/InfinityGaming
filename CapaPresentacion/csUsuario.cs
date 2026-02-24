using InfinityGaming.CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfinityGaming
{
    internal class csUsuario
    {
        public long IdUsuario { get; set; }
        public long IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public bool Admin { get; set; }

        private csCRUD crud = new csCRUD();

        public bool Login(string usuario, string contrasena)
        {
            DataRow row = crud.EjecutarSP_UnRegistro(
                "LoginUsuario",
                new SqlParameter("@Usuario", usuario),
                new SqlParameter("@Contraseña", contrasena)
            );

            if (row == null)
                return false;

            IdUsuario = Convert.ToInt64(row["IdUsuario"]);
            Usuario = usuario;
            Admin = Convert.ToBoolean(row["EsAdmin"]);

            return true;
        }

        public void CerrarSesion()
        {
            IdUsuario = 0;
            Usuario = null;
            Admin = false;
        }

        public void Insertar()
        {
            DataRow persona = crud.EjecutarSP_UnRegistro(
                "IPersona",
                new SqlParameter("@Nombre", Nombre),
                new SqlParameter("@Cedula", Cedula),
                new SqlParameter("@Correo", Correo),
                new SqlParameter("@Direccion", Direccion)
            );

            if (persona == null)
            {
                MessageBox.Show("No se pudo crear la persona");
                return;
            }

            IdPersona = Convert.ToInt64(persona["IdPersona"]);

            crud.EjecutarSP_NonQuery(
                "IUsuario",
                new SqlParameter("@IdPersona", IdPersona),
                new SqlParameter("@Usuario", Usuario),
                new SqlParameter("@Contraseña", Contraseña),
                new SqlParameter("@Admin", Admin)
            );
        }

        public void EditarPerfil(string nombre, string correo, string direccion)
        {
            Nombre = nombre;
            Correo = correo;
            Direccion = direccion;

            crud.EjecutarSP_NonQuery(
                "UPersona",
                new SqlParameter("@IdPersona", IdPersona),
                new SqlParameter("@Nombre", Nombre),
                new SqlParameter("@Cedula", Cedula),
                new SqlParameter("@Correo", Correo),
                new SqlParameter("@Direccion", Direccion)
            );
        }

        public void CambiarContrasena(string conActual, string conNuevo)
        {
            if (Contraseña != conActual)
            {
                MessageBox.Show("La contraseña actual no coincide");
                return;
            }

            Contraseña = conNuevo;

            crud.EjecutarSP_NonQuery(
                "UUsuario",
                new SqlParameter("@IdUsuario", IdUsuario),
                new SqlParameter("@Usuario", Usuario),
                new SqlParameter("@Contraseña", Contraseña),
                new SqlParameter("@Admin", Admin)
            );
        }

        public void ActualizarUsuario()
        {
            crud.EjecutarSP_NonQuery(
                "UPersona",
                new SqlParameter("@IdPersona", IdPersona),
                new SqlParameter("@Nombre", Nombre),
                new SqlParameter("@Cedula", Cedula),
                new SqlParameter("@Correo", Correo),
                new SqlParameter("@Direccion", Direccion)
            );

            crud.EjecutarSP_NonQuery(
                "UUsuario",
                new SqlParameter("@IdUsuario", IdUsuario),
                new SqlParameter("@Usuario", Usuario),
                new SqlParameter("@Contraseña", Contraseña),
                new SqlParameter("@Admin", Admin)
            );
        }

        public void Eliminar()
        {
            crud.EjecutarSP_NonQuery(
                "DUsuario",
                new SqlParameter("@IdUsuario", IdUsuario)
            );
        }

        public DataTable Listar(string buscar)
        {
            return crud.EjecutarSP_DataTable(
                "SUsuario",
                new SqlParameter("@Buscar", buscar)
            );
        }

        public bool VerificarRol()
        {
            return Admin;
        }
    }
}
