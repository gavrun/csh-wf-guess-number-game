using System;
using System.Collections.Generic;
using System.IO;
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

            // Data model

            // local file path
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GameRecords.xml");

            //IData dataStore = new InMemoryData();

            IData dataStore = new FileData(filePath);

            // Switch to starting from MenuForm 
            //using (MenuForm menuForm = new MenuForm())
            //{
            //    if (menuForm.ShowDialog() == DialogResult.OK)
            //    {
            //        Application.Run(new MainForm());
            //    }
            //}

            Application.Run(new MenuForm(dataStore));
        }
    }

    public static class FormNav
    {
        //public static void BackToMenu(Form currentForm, IData data)
        //{
        //    MenuForm menuForm = new MenuForm(data);
        //    menuForm.Show();
        //
        //    currentForm.Hide();
        //}

        public static void BackToMode(Form currentForm, IData data)
        {
            ModeForm modeForm = new ModeForm(data);
            modeForm.Show();

            currentForm.Hide();
        }
    }
}
