using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miniTC
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Models.miniTCModel model = new Models.miniTCModel();
            miniTCView view = new miniTCView();
            Presenters.miniTCPresenter presenter = new Presenters.miniTCPresenter(model,view);
            Application.Run(view);
        }
    }
}
