﻿using System;
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
            int minRange = 1; 
            int maxRange = 100;

            if (int.TryParse(txtMinRange.Text, out int min) && int.TryParse(txtMaxRange.Text, out int max) && min < max)
            {
                minRange = min;
                maxRange = max;
            }

            Random rnd = new Random();
            randomNumber = rnd.Next(minRange, maxRange + 1);

            attempts = 0;

            lblMessage.Text = $"Guess number from {txtMinRange.Text} to {txtMaxRange.Text}!";

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
