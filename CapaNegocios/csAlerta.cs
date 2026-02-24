
using InfinityGaming.CapaDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfinityGaming
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    internal class csAlerta
    {
        public long IdAlerta { get; set; }
        public string Mensaje { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public bool Leida { get; set; }
        public long? IdComputadora { get; set; }
        public long? IdSesion { get; set; }

        csCRUD crud = new csCRUD();

        public void GenerarAlarma()
        {
            crud.EjecutarSP_NonQuery("IAlerta",
                new SqlParameter("@IdComputadora", (object)IdComputadora ?? DBNull.Value),
                new SqlParameter("@IdSesion", (object)IdSesion ?? DBNull.Value),
                new SqlParameter("@Mensaje", Mensaje),
                new SqlParameter("@Tipo", Tipo));
        }

        public void MarcarComoLeida()
        {
            crud.EjecutarSP_NonQuery("UAlerta",
                new SqlParameter("@IdAlerta", IdAlerta),
                new SqlParameter("@Leida", true));
        }

        public DataTable Listar(bool? leida = null, string tipo = null)
        {
            return crud.EjecutarSP_DataTable("SAlertas",
                new SqlParameter("@Leida", (object)leida ?? DBNull.Value),
                new SqlParameter("@Tipo", (object)tipo ?? DBNull.Value));
        }
    }
}
