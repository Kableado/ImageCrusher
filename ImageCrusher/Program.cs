﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ImageCrusher
{
    static class Program
    {
        private static bool CreateShortcut(string shortcut, string exe, string dir)
        {
            bool created = false;
            Type shellType = null;
            object shell = null;
            try
            {
                shellType = Type.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")); //Windows Script Host Shell Object
                shell = Activator.CreateInstance(shellType);
            }
            catch (Exception)
            {
                return created;
            }
            try
            {
                object lnk = shellType.InvokeMember("CreateShortcut", BindingFlags.InvokeMethod, null, shell, new object[] { shortcut });
                try
                {
                    string targetPath = (string)shellType.InvokeMember("TargetPath", BindingFlags.GetProperty, null, lnk, null);
                    if (targetPath != exe)
                    {
                        shellType.InvokeMember("TargetPath", BindingFlags.SetProperty, null, lnk, new object[] { exe });
                        shellType.InvokeMember("WorkingDirectory", BindingFlags.SetProperty, null, lnk, new object[] { dir });
                        shellType.InvokeMember("IconLocation", BindingFlags.SetProperty, null, lnk, new object[] { String.Format("{0}, 1", exe) });
                        shellType.InvokeMember("Save", BindingFlags.InvokeMethod, null, lnk, null);
                        created = true;
                    }
                }
                finally
                {
                    Marshal.FinalReleaseComObject(lnk);
                }
            }
            finally
            {
                Marshal.FinalReleaseComObject(shell);
            }
            return created;
        }

        private static bool InstallSendToShortcut()
        {
            String shortcutPath = String.Format("{0}\\ImageCrusher.lnk", Environment.GetFolderPath(Environment.SpecialFolder.SendTo));
            string exeName = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
            string exePath = Path.GetDirectoryName(Application.ExecutablePath);
            return CreateShortcut(shortcutPath, string.Format("{0}\\{1}.exe", exePath, exeName), exePath);
        }

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (InstallSendToShortcut())
            {
                MessageBox.Show("Acceso directo creado correctamente");
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FrmImageCrusher frmImageCrusher = new FrmImageCrusher();
            if (args.Count() > 0)
            {
                String path = args[0];
                if (!Directory.Exists(path))
                {
                    if (File.Exists(path))
                    {
                        path = Path.GetDirectoryName(path);
                        frmImageCrusher.InitialPath = path;
                    }
                }
                else
                {
                    frmImageCrusher.InitialPath = path;
                }
            }
            Application.Run(frmImageCrusher);
        }
    }
}
