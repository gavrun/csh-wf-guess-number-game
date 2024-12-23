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
    public partial class MultiForm : Form
    {
        private readonly IData data;

        public MultiForm(IData dataStore)
        {
            InitializeComponent();

            data = dataStore;
        }

        // multiplayer logic to be implemented

        private void MultiForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            ModeForm modeForm = new ModeForm(data);
            modeForm.Show();

            this.Hide();
        }
    }
}
