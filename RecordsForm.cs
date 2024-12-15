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
    public partial class RecordsForm : Form
    {
        private readonly IData data;

        public RecordsForm(IData dataStore)
        {
            InitializeComponent();

            data = dataStore;

            // data bound to grid

            var records = data.GetAllRecords();

            gameRecordBindingSource.DataSource = records;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = new MenuForm(data);
            menuForm.Show();

            this.Hide();
        }

        private void RecordsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuForm menuForm = new MenuForm(data);
            menuForm.Show();

            this.Hide();
        }
    }
}
