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
    public partial class RulesForm : Form
    {
        private readonly IData data;

        public RulesForm(IData dataStore)
        {
            InitializeComponent();

            data = dataStore;

            label1.Text = "Rules of the Game:\r\n\n" +
                                "1. Objective: Guess a secret number within the given range.\r\n\n" +
                                "2. How to Play:\r\n" +
                                "   - A random number is chosen at the start of the game.\r\n" +
                                "   - Enter your guess in the input field and press the \"Check\" button.\r\n" +
                                "   - The game will provide hints:\r\n" +
                                "           \"Higher\" if the number is larger, \"Lower\" if the number is smaller.\r\n" +
                                "           ..to be done\r\n\n" +
                                "3. Attempts: Try to guess the number in the least attempts possible.\r\n\n" +
                                "4. Timer: If playing a timed mode, guess the number before time runs out.\r\n\n" +
                                "5. Modes:\r\n" +
                                "   - Main Mode: No time limit, infinite guesses.\r\n\n" +
                                "   - Pro Mode: Guess the number within the given time.";

        }

        private void RulesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuForm menuForm = new MenuForm(data);
            menuForm.Show();

            this.Hide();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = new MenuForm(data);
            menuForm.Show();

            this.Hide();
        }
    }
}
