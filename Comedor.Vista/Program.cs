using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Comedor.Vista
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Acceso.Loading form = new Acceso.Loading();
            form.iniciar = true;
            Application.Run(form);
          //  Application.Run(new frmConsumidor());
          //  Application.Run(new frmRegistroTurno());
          //  Application.Run(new frmConsumoPersona());
        }
    }
}
