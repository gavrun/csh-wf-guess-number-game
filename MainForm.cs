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
        private readonly IData data;

        private GameLogic game;

        public MainForm(IData dataStore)
        {
            InitializeComponent();

            data = dataStore;

            game = new GameLogic();
            //StartGame();

            buttonCheck.Enabled = false;
            buttonStart.Enabled = true;
            buttonRestart.Enabled = false;

        }

        // Starts new game by generating a random number and setting range
        private void StartGame()
        {
            int minRange;
            int maxRange; // can be changed

            minRange = int.Parse(txtMinRange.Text);
            maxRange = int.Parse(txtMaxRange.Text);

            game.StartGame(minRange, maxRange);

            labelMessage.Text = $"Guess number from {txtMinRange.Text} to {txtMaxRange.Text}!";

            txtGuess.Clear();
            txtGuess.Focus();

            buttonCheck.Enabled = true;
            buttonStart.Enabled = false;
            buttonRestart.Enabled = true;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            StartGame();

            buttonCheck.Enabled = true;
            buttonStart.Enabled = false;
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtGuess.Text, out int userGuess))
            {
                string result = game.CheckGuess(userGuess);
                labelMessage.Text = result;

                if (result == "Correct!")
                {
                    MessageBox.Show($"Congrats! You guessed it in {game.Attempts} attempts.", "Win");
                    //StartGame();
                }
            }
            else
            {
                labelMessage.Text = "Input correct number.";
            }
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            DialogResult restart = MessageBox.Show("Want to restart?", "Restart", MessageBoxButtons.YesNo);

            if (restart == DialogResult.Yes)
            {
                StartGame();
            }
        }

        private void buttonMainBack_Click(object sender, EventArgs e)
        {
            DialogResult back = MessageBox.Show("Want to quit?", "Back", MessageBoxButtons.YesNo);

            if (back == DialogResult.Yes)
            {
                ModeForm modeForm = new ModeForm(data);
                modeForm.Show();

                this.Hide();
            }
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
