using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csh_wf_guess_number_game
{
    public class GameLogic
    {
        private int randomNumber; //number to guess

        public int Attempts { get; private set; } // count of user attempts

        private Random random;


        public GameLogic()
        {
            random = new Random();
        }

        // Starts new game by generating a random number and resetting attempts
        public void StartGame(int min, int max)
        {
            randomNumber = random.Next(min, max + 1); // random number in range

            Attempts = 0; // reset attempts counter
        }

        //public int GetRandomNumber()
        //{
        //    return randomNumber;
        //}

        public string CheckGuess(int userGuess) 
        {
            Attempts++;

            if (userGuess < randomNumber)
            {
                //labelMessage.Text = "Number is bigger.";
                return "Number is bigger.";
            }
            else if (userGuess > randomNumber)
            {
                //labelMessage.Text = "Number is smaller.";
                return "Number is smaller.";
            }
            else
            {
                return "Correct!";

                //MessageBox.Show($"Congrats! You guessed it for {attempts} attempts.", "Win");
                //StartGame();
            }
        }

        // Validates if input a valid number
        //public bool Validate(string input, out int result)
        //{
        //    return int.TryParse(input, out result);
        //}
    }
}
