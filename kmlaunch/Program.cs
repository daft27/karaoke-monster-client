using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Threading;
using System.IO;
using System.Security.Cryptography;

namespace kmlaunch
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]


        static void Main()
        {
            String destPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + System.IO.Path.DirectorySeparatorChar + "KaraokeMONSTER" + System.IO.Path.DirectorySeparatorChar;
            if (!Directory.Exists(destPath))
                Directory.CreateDirectory(destPath);

            Thread.Sleep(1000);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (File.Exists(destPath + "Karaoke Monsutaa.exe") && (Environment.CurrentDirectory + System.IO.Path.DirectorySeparatorChar) != destPath)
            {
                Environment.CurrentDirectory = destPath;
                System.Diagnostics.Process.Start(destPath + "Karaoke Monsutaa.exe");
            }
            else if (File.Exists(destPath + "kmlaunch.exe") && (Environment.CurrentDirectory + System.IO.Path.DirectorySeparatorChar) != destPath)
            {
                Environment.CurrentDirectory = destPath;
                System.Diagnostics.Process.Start(destPath + "kmlaunch.exe");
            }
            else
            {
                Environment.CurrentDirectory = destPath;
                Application.Run(new Launcher(destPath));
                System.Diagnostics.Process.Start(destPath + "Karaoke Monsutaa.exe");
            }
        }
    }
}
