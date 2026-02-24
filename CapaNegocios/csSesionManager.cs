using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InfinityGaming
{
    public static class csSesionManager
    {
        public static Dictionary<long, csSesionJuegos> SesionesActivas
            = new Dictionary<long, csSesionJuegos>();

        private static Timer timerGlobal = new Timer();

        public static decimal PrecioPorMinuto = 0.10m;

        public static event Action OnActualizar;

        static csSesionManager()
        {
            timerGlobal.Interval = 1000;
            timerGlobal.Tick += Tick;
            timerGlobal.Start();
        }

        private static void Tick(object sender, EventArgs e)
        {
            DateTime ahora = DateTime.Now;

            List<long> sesionesTerminadas =
                new List<long>();

            foreach (var item in SesionesActivas)
            {
                var sesion = item.Value;

                TimeSpan tiempo = ahora - sesion.InicioSesion;

                decimal minutos = (decimal)tiempo.TotalMinutes;
                sesion.CostoTotal =
                    Math.Round(minutos * PrecioPorMinuto, 2);

                if (sesion.TiempoFinalizado())
                {
                    sesion.FinalizarAutomaticamente(PrecioPorMinuto);
                    sesionesTerminadas.Add(item.Key);
                }
            }

            foreach (var id in sesionesTerminadas)
                SesionesActivas.Remove(id);

            OnActualizar?.Invoke();
        }
    }
}