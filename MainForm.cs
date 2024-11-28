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
    public partial class MainForm : Form
    {
        private int randomNumber;
        private int attempts;


        public MainForm()
        {
            InitializeComponent();

            StartGame();
        }

        private void StartGame()
        {
            Random rnd = new Random();
            randomNumber = rnd.Next(1, 101);

            attempts = 0;

            lblMessage.Text = "Guess number from 1 to 100!";

            txtGuess.Clear();
            txtGuess.Focus();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtGuess.Text, out int userGuess))
            {
                attempts++;
                if (userGuess < randomNumber)
                {
                    lblMessage.Text = "Number is bigger.";
                }
                else if (userGuess > randomNumber)
                {
                    lblMessage.Text = "Number is smaller.";
                }
                else
                {
                    MessageBox.Show($"Congrats! You guessed it for {attempts} attempts.", "Win");
                    StartGame();
                }
            }
            else
            {
                lblMessage.Text = "Input correct number.";
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            StartGame();
        }
    }
}
