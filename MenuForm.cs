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
    public partial class MenuForm : Form
    {
        private readonly IData data; // data model

        public MenuForm(IData dataStore)
        {
            InitializeComponent();

            data = dataStore;
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            // pass data
            ModeForm modeForm = new ModeForm(data);
            modeForm.Show();

            this.Hide();
            //this.Close();

            // alternative approach 

            //this.Hide();
            //using (MainForm mainForm = new MainForm())
            //{
            //    mainForm.ShowDialog();
            //}
            //Application.Exit();
        }

        private void buttonRules_Click(object sender, EventArgs e)
        {
            RulesForm rulesForm = new RulesForm(data);
            rulesForm.Show();

            this.Hide();
        }


        private void buttonViewRecords_Click(object sender, EventArgs e)
        {
            //AddTestRecord(); // DEBUG

            var records = data.GetAllRecords();

            if (records.Count == 0)
            {
                MessageBox.Show("No records found.", "Game Records");
                return;
            }

            RecordsForm recordsForm = new RecordsForm(data);
            recordsForm.Show();

            this.Hide();

            //string recordList = string.Join(Environment.NewLine, records.Select(r => 
            //    $"{r.PlayerName} - {r.Attempts} attempts in {r.TimeTaken} seconds on {r.Date}"));

            //MessageBox.Show(recordList, "Game Records");

        }
        private void AddTestRecord()
        {
            var record = new GameRecord
            {
                PlayerName = "Test",
                Attempts = 1,
                TimeTaken = 1,
                Date = DateTime.UtcNow
            };

            data.AddRecord(record);
        }


        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult back = MessageBox.Show("Are you sure to exit?", "Exit", MessageBoxButtons.YesNo);

            if (back == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void MenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Exit application when clicking [X]
            Application.Exit();
        }
    }
}
