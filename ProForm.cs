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
    public partial class ProForm : Form
    {
        private GameLogic game;

        // Timer
        private Timer gameTimer;
        private int remainingTime;

        public ProForm()
        {
            InitializeComponent();

            game = new GameLogic(); 
        }

        // Starts a new game with limited time and attempts
        private void StartGame()
        {
            int minRange;
            int maxRange; // can be changed

            minRange = int.Parse(txtMinRange.Text);
            maxRange = int.Parse(txtMaxRange.Text);

            // 1-minute timer default
            int timerSeconds = 60;  // can be set 

            game.StartGame(minRange, maxRange);

            labelMessage.Text = $"Guess number from {txtMinRange.Text} to {txtMaxRange.Text}!";

            StartTimer(timerSeconds);
        }

        private void StartTimer(int seconds)
        {
            remainingTime = seconds;

            gameTimer = new Timer();
            gameTimer.Interval = 1000; // 1 second

            gameTimer.Tick += GameTimer_Tick;

            gameTimer.Start();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            remainingTime--;
            labelTimer.Text = $"Time left: {remainingTime}s"; // not exists in this context

            if (remainingTime <= 0)
            {
                gameTimer.Stop();
                MessageBox.Show("Time is up! Game over.", "Game Over");
                this.Close();
            }
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
                //game.Attempts++;
                string result = game.CheckGuess(userGuess);

                labelMessage.Text = result;

                if (result == "Correct!")
                {
                    gameTimer.Stop();

                    MessageBox.Show($"Congrats! You guessed it for {game.Attempts} attempts.", "Win");
                    StartGame();
                }
            }
            else
            {
                labelMessage.Text = "Input correct number.";
            }
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            StartGame();

            buttonCheck.Enabled = true;
            buttonStart.Enabled = false;
        }


        private void buttonBack_Click(object sender, EventArgs e)
        {
            ModeForm modeForm = new ModeForm();
            modeForm.Show();

            this.Hide();
        }

    }
}
