using InfinityGaming.CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityGaming
{
    internal class csEquipo
    {
        public long IdEquipo { get; set; }
        public string NombreEquipo { get; set; }
        public string Tipo { get; set; }
        public string Especificaciones { get; set; }
        public string Estado { get; set; }

        csCRUD crud = new csCRUD();

        public void Insertar()
        {
            crud.EjecutarSP_NonQuery("IEquipo",
                new SqlParameter("@NombreEquipo", NombreEquipo),
                new SqlParameter("@Tipo", Tipo),
                new SqlParameter("@Especificaciones", Especificaciones),
                new SqlParameter("@Estado", Estado));
        }

        public void Actualizar()
        {
            crud.EjecutarSP_NonQuery("UEquipo",
                new SqlParameter("@IdEquipo", IdEquipo),
                new SqlParameter("@NombreEquipo", NombreEquipo),
                new SqlParameter("@Tipo", Tipo),
                new SqlParameter("@Especificaciones", Especificaciones),
                new SqlParameter("@Estado", Estado));
        }

        public void Eliminar()
        {
            crud.EjecutarSP_NonQuery("DEquipo",
                new SqlParameter("@IdEquipo", IdEquipo));
        }
    }
}