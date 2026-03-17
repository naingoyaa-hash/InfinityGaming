using InfinityGaming.CapaDatos;
using InfinityGaming.CapaNegocios.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;

namespace InfinityGaming
{
    internal class csUsuario : IUsuario
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

        public (bool ok, string mensaje) Login(string usuario, string contrasena)
        {
            var row = crud.EjecutarSP_UnRegistro(
                "LoginUsuario",
                new SqlParameter("@Usuario", usuario),
                new SqlParameter("@Contraseña", contrasena)
            );

            if (row == null)
                return (false, "Usuario o contraseña incorrectos.");

            IdUsuario = Convert.ToInt64(row["IdUsuario"]);
            Usuario = usuario;
            Admin = Convert.ToBoolean(row["EsAdmin"]);

            return (true, "Login correcto.");
        }

        public void CerrarSesion()
        {
            IdUsuario = 0;
            Usuario = null;
            Admin = false;
        }

        public (bool ok, string mensaje) Insertar()
        {
            var persona = crud.EjecutarSP_UnRegistro(
                "IPersona",
                new SqlParameter("@Nombre", Nombre),
                new SqlParameter("@Cedula", Cedula),
                new SqlParameter("@Correo", Correo),
                new SqlParameter("@Direccion", Direccion)
            );

            if (persona == null)
                return (false, "No hubo respuesta de la BD.");

            if (Convert.ToInt32(persona["Resultado"]) == 0)
                return (false, persona["Mensaje"].ToString());

            IdPersona = Convert.ToInt64(persona["IdPersona"]);

            var usuario = crud.EjecutarSP_UnRegistro(
                "IUsuario",
                new SqlParameter("@IdPersona", IdPersona),
                new SqlParameter("@Usuario", Usuario),
                new SqlParameter("@Contraseña", Contraseña),
                new SqlParameter("@Admin", Admin)
            );

            if (usuario == null)
                return (false, "No se pudo crear el usuario.");

            return (
                Convert.ToInt32(usuario["Resultado"]) == 1,
                usuario["Mensaje"].ToString()
            );
        }

        public (bool ok, string mensaje) EditarPerfil(string nombre, string correo, string direccion)
        {
            Nombre = nombre;
            Correo = correo;
            Direccion = direccion;

            var row = crud.EjecutarSP_UnRegistro(
                "UPersona",
                new SqlParameter("@IdPersona", IdPersona),
                new SqlParameter("@Nombre", Nombre),
                new SqlParameter("@Cedula", Cedula),
                new SqlParameter("@Correo", Correo),
                new SqlParameter("@Direccion", Direccion)
            );

            if (row == null)
                return (false, "No hubo respuesta de la BD.");

            return (
                Convert.ToInt32(row["Resultado"]) == 1,
                row["Mensaje"].ToString()
            );
        }

        public (bool ok, string mensaje) ActualizarUsuario()
        {
            var persona = crud.EjecutarSP_UnRegistro(
        "UPersona",
        new SqlParameter("@IdPersona", IdPersona),
        new SqlParameter("@Nombre", Nombre),
        new SqlParameter("@Cedula", Cedula),
        new SqlParameter("@Correo", Correo),
        new SqlParameter("@Direccion", Direccion)
    );

            if (persona == null)
                return (false, "Error actualizando persona.");

            if (Convert.ToInt32(persona["Resultado"]) == 0)
                return (false, persona["Mensaje"].ToString());

            var usuario = crud.EjecutarSP_UnRegistro(
                "UUsuario",
                new SqlParameter("@IdUsuario", IdUsuario),
                new SqlParameter("@Usuario", Usuario),
                new SqlParameter("@Contraseña", Contraseña),
                new SqlParameter("@Admin", Admin)
            );

            if (usuario == null)
                return (false, "Error actualizando usuario.");

            return (
                Convert.ToInt32(usuario["Resultado"]) == 1,
                usuario["Mensaje"].ToString()
            );
        }

        public (bool ok, string mensaje) Eliminar()
        {
            var row = crud.EjecutarSP_UnRegistro(
                "DUsuario",
                new SqlParameter("@IdUsuario", IdUsuario)
            );

            if (row == null)
                return (false, "No hubo respuesta de la BD.");

            return (
                Convert.ToInt32(row["Resultado"]) == 1,
                row["Mensaje"].ToString()
            );
        }

        public DataTable Listar(string buscar)
        {
            return crud.EjecutarSP_DataTable(
                "SUsuario",
                new SqlParameter("@Buscar", buscar ?? "")
            );
        }

        public bool VerificarRol()
        {
            return Admin;
        }
    }
}