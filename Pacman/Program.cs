using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Pacman
{
    static class Program
    {
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private static Mutex m_instance;
        private const string m_appName = "Pacman_mutex";

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool tryCreateNewApp;
            m_instance = new Mutex(true, m_appName, out tryCreateNewApp);
            if (tryCreateNewApp)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ControllerMainForm());
            }
            else
            {
                Process[] p = Process.GetProcessesByName("Pacman");
                if (p.Count() > 0)
                {
                    ShowWindow(p[0].MainWindowHandle, 1);
                    SetForegroundWindow(p[0].MainWindowHandle);
                }
            }
        }
    }
}
