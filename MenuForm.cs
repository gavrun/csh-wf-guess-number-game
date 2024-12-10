using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csh_wf_guess_number_game
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            // Create MainForm
            MainForm mainForm = new MainForm();
            mainForm.Show();

            // Close MenuForm
            this.Hide();

            // alternative approach 
                
            //this.Hide();
            //using (MainForm mainForm = new MainForm())
            //{
            //    mainForm.ShowDialog();
            //}
            //Application.Exit();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            // Exit application
            Application.Exit();
        }

        private void MenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
