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

            buttonCheck.Enabled = false;
            buttonRestart.Enabled = false;
        }

        // Starts a new game with limited time and attempts
        private void StartGame()
        {
            int minRange;
            int maxRange; // can be changed

            minRange = int.Parse(txtMinRange.Text);
            maxRange = int.Parse(txtMaxRange.Text);

            // 1-minute timer default
            int timerSeconds = (int)numericUpDownTimer.Value;  // can be set 

            game.StartGame(minRange, maxRange);

            labelMessage.Text = $"Guess number from {txtMinRange.Text} to {txtMaxRange.Text}!";

            StartTimer(timerSeconds);

            buttonCheck.Enabled = true;
            buttonStart.Enabled = false;
            buttonRestart.Enabled = true;
        }

        private void StartTimer(int seconds)
        {
            remainingTime = seconds;

            gameTimer = new Timer();
            gameTimer.Interval = 1000; // 1 second, make it constant timer gets faster 

            gameTimer.Tick += GameTimer_Tick;

            gameTimer.Start();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (remainingTime > 0)
            {
                remainingTime--;
                labelTimer.Text = $"Time left: {remainingTime}s";
            }

            if (remainingTime <= 0)
            {
                gameTimer.Stop();
                PauseGame();

                MessageBox.Show("Time is up! Game over.", "Game Over");
                
                //this.close and open ModeForm 
            }
        }

        // Stops game and timer and disables buttons
        private void PauseGame()
        {
            if (gameTimer != null)
                gameTimer.Stop();

            buttonCheck.Enabled = false;
            buttonRestart.Enabled = true;
            buttonStart.Enabled = false;
        }
        // Resume timer and enable buttons
        private void ResumeGame()
        {
            
            if (gameTimer != null)
                gameTimer.Start();

            buttonCheck.Enabled = true;
            buttonRestart.Enabled = true;
            buttonStart.Enabled = false;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            StartGame();
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
                    PauseGame();

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
            PauseGame();

            DialogResult restart = MessageBox.Show("Want to restart?", "Restart", MessageBoxButtons.YesNo);

            if (restart == DialogResult.Yes)
            {
                StartGame();
            }
            else
            {
                ResumeGame();
            }

            //buttonCheck.Enabled = true;
            //buttonStart.Enabled = false;
        }


        private void buttonBack_Click(object sender, EventArgs e)
        {
            DialogResult back = MessageBox.Show("Want to quit?", "Back", MessageBoxButtons.YesNo);

            if (back == DialogResult.Yes)
            {
                ModeForm modeForm = new ModeForm();
                modeForm.Show();

                this.Hide();
            }
        }

        private void ProForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ProForm_Load(object sender, EventArgs e)
        {

        }
    }
}
