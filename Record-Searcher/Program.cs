using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Record_Searcher
{
    static class Program
    {
        public static string DirectoryPath { get; set; }
        public static int normalRange { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
        static int Main(string[] args)
        {
            normalRange = 10;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0 && !string.IsNullOrWhiteSpace(args[0]))
            {
                DirectoryPath = args[0];
            }
            else
            {
                DirectoryPath = Properties.Settings.Default.Directory;
                if (string.IsNullOrWhiteSpace(Program.DirectoryPath))
                {
                    Program.DirectoryPath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    if (!GetBaseDirectory())
                    {
                        // 
                        return 1;
                    }
                }
            }
            Application.Run(new Form2(MetroAllowed()));
           // Application.Run(new Form2(MetroAllowed()));
            return 0;
        }

        public static bool GetBaseDirectory()
        {
            System.Windows.Forms.FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.SelectedPath = Program.DirectoryPath;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Program.DirectoryPath = dlg.SelectedPath;
                Properties.Settings.Default.Directory = Program.DirectoryPath;
                Properties.Settings.Default.Save();
                return true;
            }

            return false;
        }
        static bool MetroAllowed()
        {
            OperatingSystem OPSystem = System.Environment.OSVersion;
            if (OPSystem.Version.Major >= 6 && OPSystem.Version.Minor >= 2)
            {
                return true;

            }

            else
            {
                return false;
            }


        }
    }
}
