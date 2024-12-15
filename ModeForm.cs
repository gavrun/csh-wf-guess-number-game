using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csh_wf_guess_number_game
{
    public partial class ModeForm : Form
    {
        private readonly IData data;

        private readonly ErrorProvider errorProvider = new ErrorProvider();

        public ModeForm(IData dataStore)
        {
            InitializeComponent();

            data = dataStore;
        }

        private void buttonMainMode_Click(object sender, EventArgs e)
        {
            // Create MainForm
            MainForm mainForm = new MainForm(data);
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
            string playerName = textBoxPlayerName.Text;

            // text box error check
            errorProvider.Clear();

            if (string.IsNullOrWhiteSpace(playerName))
            {
                errorProvider.SetError(textBoxPlayerName, "Enter your name before starting the game please");
                return;
            }
            if (!Regex.IsMatch(playerName, @"^[a-zA-Z0-9]+$"))
            {
                errorProvider.SetError(textBoxPlayerName, "Only letters and numbers");
                return;
            }
           
            errorProvider.SetError(textBoxPlayerName, string.Empty);

            ProForm proForm = new ProForm(data, playerName);
            proForm.Show();

            this.Hide();
        }

        private void buttonMultiMode_Click(object sender, EventArgs e)
        {
            MultiForm multiForm = new MultiForm(data);
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
            MenuForm menuForm = new MenuForm(data);
            menuForm.Show();

            this.Hide();
        }
    }
}
