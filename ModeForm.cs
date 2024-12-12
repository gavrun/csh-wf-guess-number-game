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
    public partial class ModeForm : Form
    {
        public ModeForm()
        {
            InitializeComponent();
        }

        private void buttonMainMode_Click(object sender, EventArgs e)
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

        private void buttonProMode_Click(object sender, EventArgs e)
        {
            ProForm proForm = new ProForm();
            proForm.Show();

            this.Hide();
        }

        private void buttonMultiMode_Click(object sender, EventArgs e)
        {
            MultiForm multiForm = new MultiForm();
            multiForm.Show();
            
            // not implemented

            this.Hide();
        }

        private void ModeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            menuForm.Show();

            this.Hide();
        }
    }
}
