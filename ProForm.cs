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
        private readonly IData data; // data model

        private GameLogic game;

        private readonly string _playerName;

        // Timer
        private Timer gameTimer;
        private int remainingTime;

        private int timeTaken;

        public ProForm(IData dataStore, string playerName)
        {
            InitializeComponent();

            data = dataStore;

            game = new GameLogic();

            _playerName = playerName; // _name local

            buttonCheck.Enabled = false;
            buttonRestart.Enabled = false;
        }

        // Starts a new game with limited time and attempts
        private void StartGame()
        {
            int minRange;
            int maxRange; // can be changed

            //minRange = int.Parse(txtMinRange.Text);
            //maxRange = int.Parse(txtMaxRange.Text);

            if (!int.TryParse(txtMinRange.Text, out minRange) || !int.TryParse(txtMaxRange.Text, out maxRange))
            {
                MessageBox.Show("Please enter valid numbers", "Error");
                return;
            }

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
            if (gameTimer == null)
            {
                gameTimer = new Timer { Interval = 1000 };

                gameTimer.Tick += GameTimer_Tick;
            }

            remainingTime = seconds;

            //gameTimer = new Timer();
            //gameTimer.Interval = 1000; // 1 second, make it constant timer gets faster BUG

            //gameTimer.Tick += GameTimer_Tick;

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
                ModeForm modeForm = new ModeForm(data);
                modeForm.Show();

                this.Hide();
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

        // add game record 
        private void RecordGame(string _playerName, int attempts, int timeTaken)
        {
            var record = new GameRecord
            {
                // DEBUG test data
                //PlayerName = "PlayerName1", Attempts = 7, TimeTaken = 60, Date = DateTime.Now 

                PlayerName = _playerName,
                Attempts = attempts,
                TimeTaken = timeTaken,
                Date = DateTime.Now,
            };

            data.AddRecord(record);
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

                    // timerSeconds - remainingTime
                    timeTaken = (int)numericUpDownTimer.Value - remainingTime;

                    RecordGame(_playerName, game.Attempts, timeTaken);
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
                PauseGame();

                //ModeForm modeForm = new ModeForm(data);
                //modeForm.Show();

                //this.Hide();

                FormNav.BackToMode(this, data);
            }
        }

        private void ProForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
