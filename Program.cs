using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csh_wf_guess_number_game
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Switch to starting from MenuForm 

            //using (MenuForm menuForm = new MenuForm())
            //{
            //    if (menuForm.ShowDialog() == DialogResult.OK)
            //    {
            //        Application.Run(new MainForm());
            //    }
            //}

            Application.Run(new MenuForm());
        }
    }
}
